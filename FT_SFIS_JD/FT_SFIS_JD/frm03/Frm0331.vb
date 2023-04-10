Public Class frm0331
  Private pid As System.Diagnostics.Process = Nothing
  Private strFPATH As String = ""
  Private strFPATHL As String = ""
  Private bolHasMap As Boolean = False
  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()
    languagechange(Me)
    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

  End Sub
  Private Sub frm0331_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    Try
      If pid IsNot Nothing Then
        If pid.HasExited = False Then
          pid.Kill()
          pid.WaitForExit(100)
        End If
      End If
      If IO.File.Exists(strFPATHL) Then
        IO.File.Delete(strFPATHL)
      End If
      If IO.File.Exists(strFPATH & ".tmp") Then
        IO.File.Delete(strFPATH & ".tmp")
      End If
    Catch ex As Exception

    End Try
    TuiCK(Me)
  End Sub

  Private Sub frm0331_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_IQF")
    sqlCV.SqlFields("IQF05", , , True, True) '用戶
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RSS")
    SetComBo(rs, cbUser)
    strFPATH = IO.Path.GetTempFileName
    strFPATH = IO.Path.GetDirectoryName(strFPATH) & "\" & IO.Path.GetFileNameWithoutExtension(strFPATH)
    If IO.Directory.Exists(IO.Path.GetDirectoryName(strFPATH)) = False Then
      IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(strFPATH))
    End If
    ComboBox1.SelectedIndex = 0
  End Sub
  Private Sub SetComBo(rs As DataTable, cb As ComboBox)
    cb.Items.Clear()
    cb.Items.Add("Any")
    For Each r As DataRow In rs.Rows
      cb.Items.Add(r.Item(0))
    Next
    cb.SelectedIndex = 0
  End Sub

  Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_IQF", , "TOP 300")
    If cbUser.Text.Trim <> "" And cbUser.Text.Trim <> "Any" Then sqlCV.Where("IQF05", "=", cbUser.Text.Trim)
    If CheckBox1.Checked Then
      sqlCV.Where("IQF07", ">=", DTP1.Value.ToString("yyyy\/MM\/dd") & " 00:00:00", APSQL.intFMode.msfld_datetime)
      sqlCV.Where("IQF07", "<=", DTP2.Value.ToString("yyyy\/MM\/dd") & " 23:59:59", APSQL.intFMode.msfld_datetime)
    End If
    If ComboBox1.Text.Trim <> "" And ComboBox1.Text.Trim <> "Any" Then
      sqlCV.Where("IQF08", "=", ComboBox1.Text.Trim)
    End If
    If TextBox2.Text <> "" Then
      sqlCV.Where("ISNULL(IQF01,'')+' '+ ISNULL(IQF04,'')+' '+ISNULL(IQF06,'')", "Like", "%" & TextBox2.Text.Trim & "%")
    Else
      If BARID.Text.Trim <> "" Then
        sqlCV.Where("IQF01", "=", BARID.Text.Trim)
      End If
    End If
    sqlCV.SqlFields("IQF01", BIG2GB("物料條碼"))
    sqlCV.SqlFields("IQF02", BIG2GB("版次"))
    sqlCV.SqlFields("IQF08", "[OK/NG]")
    sqlCV.SqlFields("IQF04", BIG2GB("原始檔名"))
    sqlCV.SqlFields("IQF05", BIG2GB("操作員"))
    sqlCV.SqlFields("IQF06", BIG2GB("電腦名稱"))
    sqlCV.SqlFields("IQF07", BIG2GB("時間"))
    sqlCV.SqlFields("USEQ")
    sqlCV.sqlOrder("IQF07", SQLCNV.intOrder.Order_Dsc)
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    DG.DataSource = rs
    DG.Columns("USEQ").Visible = False
  End Sub

  Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
    Me.Close()
  End Sub

  Private Sub BARID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles BARID.KeyPress, cbUser.KeyPress, DTP1.KeyPress, DTP2.KeyPress, ComboBox1.KeyPress, TextBox2.KeyPress
    If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
      e.Handled = True
      My.Computer.Keyboard.SendKeys(vbTab)
    End If
  End Sub

  Private Sub TextBox2_LostFocus(sender As Object, e As EventArgs) Handles TextBox2.LostFocus
    If TextBox2.Text.Trim = "" Then Return
    btnSearch_Click(Nothing, Nothing)
  End Sub

  Private Sub DG_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG.CellContentDoubleClick
    If e.RowIndex < 0 Or e.RowIndex >= DG.Rows.Count Then
      Return
    End If
    Dim intU As Integer = Val(GCell(DG.Rows(e.RowIndex).Cells("USEQ")))
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_IQF")
    sqlCV.Where("USEQ", "=", intU, intFMode.msfld_num)
    sqlCV.SqlFields("IQF04")
    sqlCV.SqlFields("IQF09")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count = 0 Then
      Return
    End If
    If rs.Rows(0)!IQF09.GetType Is GetType(DBNull) Then
      Return
    End If
    Dim bytV() As Byte = rs.Rows(0)!IQF09
    If bytV Is Nothing OrElse bytV.Length = 0 Then
      Return
    End If
    If IO.File.Exists(strFPATHL) = True Then
      If pid IsNot Nothing Then
        If pid.HasExited = False Then
          pid.Kill()
        End If
        pid.WaitForExit(300)
        pid = Nothing
      End If
      IO.File.Delete(strFPATHL)
    End If
    strFPATHL = strFPATH & IO.Path.GetExtension(rs.Rows(0)!IQF04.ToString.Trim)
    IO.File.WriteAllBytes(strFPATHL, bytV)
    bolHasMap = True
    If System.IO.File.Exists(strFPATHL) = False Then Return
    pid = System.Diagnostics.Process.Start(strFPATHL)
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    If DG.CurrentRow Is Nothing Then
      MsgBox(BIG2GB("沒有選擇任何一列資料`,無法導出"))
      Return
    End If
    DG_CellContentDoubleClick(DG, New DataGridViewCellEventArgs(0, DG.CurrentRow.Index))
  End Sub
End Class