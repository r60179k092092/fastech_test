Public Class frm0330
  Private WithEvents s1 As clsEDIT2012.clsEDITx2013
  Private intU As Integer = 0
  Private pid As System.Diagnostics.Process = Nothing
  Private strFPATH As String = ""
  Private strFPATHL As String = ""
  Private bolHasMap As Boolean = False

  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()

    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    languagechange(Me)

  End Sub

  Private Sub frm0330_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
  Private Sub frm0330_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    s1 = New clsEDITx2013(DG, DB, language)
    s1.ShowSearch = True
    s1.UnVisibles("USEQ")
    s1.Clean()
    strFPATH = IO.Path.GetTempFileName
    strFPATH = IO.Path.GetDirectoryName(strFPATH) & "\" & IO.Path.GetFileNameWithoutExtension(strFPATH)
    If IO.Directory.Exists(IO.Path.GetDirectoryName(strFPATH)) = False Then
      IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(strFPATH))
    End If
  End Sub

  Private Sub ClearAll()
    txtCode.Text = ""
    txtFilePath.Text = ""
    txtPartNO.Text = ""
    txtBatchNO.Text = ""
    txtVerdor.Text = ""
    TextBox1.Text = "001"
    ComboBox1.SelectedIndex = 0
    bolHasMap = False
    If pid IsNot Nothing Then
      If pid.HasExited = False Then
        pid.Kill()
        pid.WaitForExit(100)
      End If
      pid = Nothing
    End If
    txtCode.Focus()
  End Sub

  Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
    If pid IsNot Nothing Then
      If pid.HasExited = False Then
        pid.Kill()
        pid.WaitForExit(100)
      End If
      pid = Nothing
    End If
    If bolHasMap = True Then
      If System.IO.File.Exists(strFPATHL) = False Then Return
      pid = System.Diagnostics.Process.Start(strFPATHL)
    Else
      If System.IO.File.Exists(txtFilePath.Text) = False Then Return
      pid = System.Diagnostics.Process.Start(txtFilePath.Text.Trim)
    End If
  End Sub

  Private Sub s1_DVSelect(s As clsEDITx2013, r As DataGridViewRow) Handles s1.DVSelect
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_IQF")
    sqlCV.Where("USEQ", "=", GCell(r.Cells("USEQ")), intFMode.msfld_num)
    sqlCV.SqlFields("*")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count = 0 Then Return
    txtCode.Text = rs.Rows(0)!IQF01.ToString.Trim
    intU = Val(rs.Rows(0)!USEQ.ToString)
    txtCode_LostFocus(Nothing, Nothing)
    txtFilePath.Text = rs.Rows(0)!IQF04.ToString.Trim
    Dim intI As Integer = ComboBox1.Items.IndexOf(rs.Rows(0)!IQF08.ToString.Trim)
    If intI >= 0 Then
      ComboBox1.SelectedIndex = intI
    Else
      ComboBox1.SelectedIndex = 0
    End If
    TextBox1.Text = rs.Rows(0)!IQF02.ToString.Trim
    bolHasMap = False
    If rs.Rows(0)!IQF09.GetType IsNot GetType(DBNull) Then
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
      strFPATHL = strFPATH & IO.Path.GetExtension(txtFilePath.Text.Trim)
      IO.File.WriteAllBytes(strFPATHL, bytV)
      bolHasMap = True
    End If
  End Sub

  Private Sub s1_DVTable1(s As clsEDITx2013, ByRef strSQL As String) Handles s1.DVTable
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_IQF", , "TOP 200")
    sqlCV.SqlFields("IQF01", BIG2GB("條碼"))
    sqlCV.SqlFields("IQF02", BIG2GB("版次"))
    sqlCV.SqlFields("IQF08", BIG2GB("檢驗判定"))
    sqlCV.SqlFields("IQF04", BIG2GB("Excel檔名路徑"))
    sqlCV.SqlFields("IQF05", BIG2GB("用戶"))
    sqlCV.SqlFields("IQF06", BIG2GB("電腦名稱"))
    sqlCV.SqlFields("IQF07", BIG2GB("時間"))
    sqlCV.SqlFields("USEQ")
    sqlCV.sqlOrder("IQF06", SQLCNV.intOrder.Order_Dsc)
    strSQL = sqlCV.Text
  End Sub

  Private Sub s1_Frm_InsertM(s As clsEDITx2013, ByRef strSQL As String) Handles s1.Frm_InsertM
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_IQF")
    sqlCV.SqlFields("IQF01", txtCode.Text.Trim)
    sqlCV.SqlFields("IQF02", TextBox1.Text.Trim)
    sqlCV.SqlFields("IQF03", "")
    sqlCV.SqlFields("IQF04", txtFilePath.Text.Trim)
    sqlCV.SqlFields("IQF05", lgnname)
    sqlCV.SqlFields("IQF06", My.Computer.Name)
    sqlCV.SqlFields("IQF07", Now.ToString("yyyy\/MM\/dd HH:mm:ss"), intFMode.msfld_datetime)
    sqlCV.SqlFields("IQF08", ComboBox1.Text.Trim)
    sqlCV.SqlFields("IQF09", txtFilePath.Text.Trim, intFMode.msfld_Image)
    DB.RsSQL(sqlCV.Text, sqlCV.GetImgs)
    intU = DB.intUSEQ
    s1.Updated = True
    s1.Clean()
    strSQL = ""
  End Sub

  Private Sub s1_Frm_Clear(s As clsEDITx2013) Handles s1.Frm_Clear
    ClearAll()
  End Sub

  Private Sub s1_Frm_Delete(s As clsEDITx2013, ByRef strSQL As String, ByRef bolOK As Boolean) Handles s1.Frm_Delete
    If MsgBox(BIG2GB("確定刪除檔案?"), MsgBoxStyle.YesNo) = MsgBoxResult.No Then Return
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_delete, "SFIS_IQF")
    sqlCV.Where("USEQ", "=", intU, intFMode.msfld_num)
    strSQL = sqlCV.Text
    bolOK = True
  End Sub

  Private Sub s1_isDataValid(s As clsEDITx2013, ByRef bolOK As Boolean) Handles s1.isDataValid
    If txtCode.Text.Trim = "" Then
      MsgBox(BIG2GB("條碼內容不得為空"), MsgBoxStyle.OkOnly, BIG2GB("提示"))
      txtCode.Focus()
      Return
    End If
    bolOK = True
  End Sub

  Private Sub s1_Frm_CheckDup(s As clsEDITx2013, ByRef strSQL As String) Handles s1.Frm_CheckDup
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_IQF")
    sqlCV.Where("USEQ", "=", intU)
    sqlCV.SqlFields("USEQ")
    strSQL = sqlCV.Text
  End Sub

  Private Sub btnFileSele_Click(sender As Object, e As EventArgs) Handles btnFileSele.Click
    Dim OFD As New OpenFileDialog
    OFD.Title = BIG2GB("請選擇一個導入Excel資料")
    OFD.Filter = BIG2GB("Excel|*.xls;*.xlsx|PDF文件|*.PDF|圖檔|*.jpg;*.jpeg;*.png;*.bmp|所有檔案|*.*")
    OFD.InitialDirectory = My.Settings.strEXLPath
    If OFD.ShowDialog = Windows.Forms.DialogResult.OK Then
      If intU > 0 And txtFilePath.Text.Trim <> OFD.FileName Then
        If MsgBox(BIG2GB("這個條碼的IQC檢驗檔已經存在，是否新增一個版本"), vbOKCancel, Me.Text) = MsgBoxResult.Ok Then
          intU = 0
          Dim sqlCV As New APSQL.SQLCNV
          sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_IQF")
          sqlCV.Where("IQF01", "=", txtCode.Text.Trim)
          sqlCV.SqlFields("MAX(IQF02)", "MAXV")
          Dim rs1 As DataTable = DB.RsSQL(sqlCV.Text, "RT1")
          If rs1.Rows.Count > 0 Then
            TextBox1.Text = rs1.Rows(0)!MAXV.ToString.Trim
            If Val(TextBox1.Text) = 0 Then
              TextBox1.Text = "001"
            Else
              TextBox1.Text = (Val(TextBox1.Text) + 1).ToString("000")
            End If
          Else
            TextBox1.Text = "001"
          End If
        End If
      End If
      txtFilePath.Text = OFD.FileName
      My.Settings.strEXLPath = IO.Path.GetDirectoryName(txtFilePath.Text)
    End If
  End Sub

  Private Sub txtCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCode.KeyPress, ComboBox1.KeyPress, txtFilePath.KeyPress, TextBox1.KeyPress
    If e.KeyChar = vbLf Or e.KeyChar = vbCr Then
      e.Handled = True
      My.Computer.Keyboard.SendKeys(vbTab)
    End If
  End Sub

  Private Sub txtCode_LostFocus(sender As Object, e As EventArgs) Handles txtCode.LostFocus
    If txtCode.Text.Trim = "" Then Return
    Dim strB() As String = Split(txtCode.Text.Trim, "|")
    Select Case strB.Length
      Case 3
        txtPartNO.Text = strB(0).Trim
        txtBatchNO.Text = strB(1).Trim
        txtVerdor.Text = ""
      Case 4, 5, 6, 7, 8, 9
        txtPartNO.Text = strB(0).Trim
        txtBatchNO.Text = strB(1).Trim
        txtVerdor.Text = strB(2).Trim
    End Select
    If intU = 0 Then
      Dim sqlCV As New APSQL.SQLCNV
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_IQF")
      sqlCV.Where("IQF01", "=", txtCode.Text.Trim)
      sqlCV.SqlFields("MAX(IQF02)", "MAXV")
      Dim rs1 As DataTable = DB.RsSQL(sqlCV.Text, "RT1")
      If rs1.Rows.Count > 0 Then
        TextBox1.Text = rs1.Rows(0)!MAXV.ToString.Trim
        If Val(TextBox1.Text) = 0 Then
          TextBox1.Text = "001"
        Else
          TextBox1.Text = (Val(TextBox1.Text) + 1).ToString("000")
        End If
      Else
        TextBox1.Text = "001"
      End If
      btnFileSele_Click(Nothing, Nothing)
    End If
  End Sub

  Private Sub s1_Frm_UpdateM(s As clsEDITx2013, ByRef strSQL As String) Handles s1.Frm_UpdateM
    If intU > 0 Then
      Dim sqlCV As New APSQL.SQLCNV
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_IQF")
      sqlCV.Where("USEQ", "=", intU)
      sqlCV.SqlFields("IQF01", txtCode.Text.Trim)
      sqlCV.SqlFields("IQF02", TextBox1.Text.Trim)
      sqlCV.SqlFields("IQF08", ComboBox1.Text.Trim)
      strSQL = sqlCV.Text
    Else
      strSQL = ""
    End If
  End Sub
End Class