Public Class Frm0326
  Private strLKey As String = ""
  Private aryBMPS As New Dictionary(Of String, Byte())
  Private intSEQ As Integer = 0
  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()
    languagechange(Me)
    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

  End Sub

  Private Sub Frm0326_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    TuiCK(Me)
  End Sub
  Private Sub Frm0326_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_distinc, "SFIS_TBB")
    sqlCV.Where("ISNULL(TBB01,'')", "<>", "")
    sqlCV.Where("ISNULL(TBB02,'')", "<>", "")
    sqlCV.SqlFields("TBB04", , , , True)
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    ComboBox1.Items.Clear()
    ComboBox1.Items.Add("Any")
    For Each r As DataRow In rs.Rows
      If r!TBB04.ToString.Trim = "" Then Continue For
      ComboBox1.Items.Add(r!TBB04.ToString.Trim)
    Next
    ComboBox1.SelectedIndex = 0
  End Sub

  Private Sub ComboBox2_GotFocus(sender As Object, e As EventArgs) Handles ComboBox2.GotFocus
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TBB")
    sqlCV.Where("ISNULL(TBB01,'')", "<>", "")
    sqlCV.Where("ISNULL(TBB02,'')", "<>", "")
    If ComboBox1.Text <> "Any" Then
      sqlCV.Where("TBB04", "=", ComboBox1.Text)
    End If
    sqlCV.SqlFields("TBB03", "KEYS", , , True)
    sqlCV.SqlFields("TBB03+' '+ISNULL(TBB04,'')+' '+ISNULL(TBB05,'')+' '+ISNULL(TBB06,'')", "DATAS")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RTITM")
    'If rs.Rows.Count = 0 Or ComboBox1.Text <> "Any" Then
    Dim r As DataRow = rs.NewRow
    r.Item(0) = "Any"
    r.Item(1) = BIG2GB("所有成品編號")
    rs.Rows.InsertAt(r, 0)
    'End If
    ComboBox2.DisplayMember = "DATAS"
    ComboBox2.ValueMember = "KEYS"
    ComboBox2.DataSource = rs
    ComboBox2.SelectedValue = rs.Rows(0)!KEYS.ToString.Trim
  End Sub

  Private Sub ComboBox3_GotFocus(sender As Object, e As EventArgs) Handles ComboBox3.GotFocus
    If ComboBox2.SelectedValue Is Nothing Then
      ComboBox2.Focus()
    End If
    Dim sqlCV As New APSQL.SQLCNV, rs As DataTable = Nothing
    If ComboBox2.SelectedValue.ToString = "Any" And ComboBox1.Text = "Any" Then
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TA")
      sqlCV.SqlFields("TA01", "KEYS", , , True)
      sqlCV.SqlFields("TA01+' '+TA02", "DATAS")
      rs = DB.RsSQL(sqlCV.Text, "RGRP")
    Else
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_distinc, "SFIS_TBB")
      If ComboBox2.SelectedValue.ToString <> "Any" Then
        sqlCV.Where("TBB03", "=", ComboBox2.SelectedValue.ToString.Trim)
      Else
        sqlCV.Where("TBB04", "=", ComboBox1.Text)
      End If
      Dim w As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TBA", "TBA01", "=", "^0.TBB01")
      w.Add("SFIS_TBA.TBA02", "=", "SFIS_TBB.TBB02")
      sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TA", "TA01", "=", "^1.TBA04")
      sqlCV.SqlFields("^2.TA01", "KEYS", , , True)
      sqlCV.SqlFields("^2.TA01+' '+^2.TA02", "DATAS")
      rs = DB.RsSQL(sqlCV.Text, "RGRP")
    End If
    If rs Is Nothing Then Return
    Dim r As DataRow = rs.NewRow
    r.Item(0) = "Any"
    r.Item(1) = BIG2GB("所有工序")
    rs.Rows.InsertAt(r, 0)
    ComboBox3.DisplayMember = "DATAS"
    ComboBox3.ValueMember = "KEYS"
    ComboBox3.DataSource = rs
    ComboBox3.SelectedValue = rs.Rows(0)!KEYS.ToString.Trim
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    If ComboBox2.SelectedValue Is Nothing Or ComboBox3.SelectedValue Is Nothing Then
      Label4.Text = BIG2GB("請先選擇品號工序")
      aryBMPS.Clear()
      DG.Rows.Clear()
      Panel1.Enabled = True
      Panel4.Enabled = False
      strLKey = ""
      Return
    End If
    strLKey = "@SOP_"
    If ComboBox2.SelectedValue.ToString.Trim <> "Any" Then
      strLKey &= ComboBox2.SelectedValue.ToString.Trim
    ElseIf ComboBox1.Text <> "Any" Then
      strLKey &= ComboBox1.Text.Trim
    Else
      strLKey &= "*"
      If ComboBox3.SelectedValue.ToString.Trim = "Any" Then
        MsgBox(BIG2GB("無法所有條件皆模糊"))
        strLKey = ""
        Label4.Text = BIG2GB("請先選擇品號工序")
        aryBMPS.Clear()
        DG.Rows.Clear()
        Panel1.Enabled = True
        Panel4.Enabled = False
        Return
      End If
    End If
    strLKey &= "_" & ComboBox3.SelectedValue.ToString.Trim
    Label4.Text = strLKey
    Button1.Enabled = False
    Panel4.Enabled = True
    Panel1.Enabled = False
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", strLKey)
    sqlCV.SqlFields("QTN02", , , , True)
    sqlCV.SqlFields("QTN03")
    sqlCV.SqlFields("QTN05")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    DG.Rows.Clear()
    aryBMPS.Clear()
    intSEQ = 0
    Dim bmpY As Bitmap
    For Each r As DataRow In rs.Rows
      If r!QTN05.GetType Is GetType(DBNull) Then Continue For
      Dim bytV() As Byte = r!QTN05
      If IO.Path.GetExtension(r!QTN03.ToString.Trim).ToUpper.EndsWith("XPS") Then
        bmpY = Nothing
        intSEQ += 1
      Else
        If bytV Is Nothing OrElse bytV.Length = 0 Then Continue For
        Dim fs As New IO.MemoryStream
        fs.Write(bytV, 0, bytV.Length)
        Dim bmpX As New Bitmap(fs)
        fs.Close()
        Dim sngX As Single = bmpX.Width / bmpX.Height
        If sngX >= 1 Then
          bmpY = New Bitmap(80, CType(80 / sngX, Integer))
        Else
          bmpY = New Bitmap(CType(80 * sngX, Integer), 80)
        End If
        Dim gx As Graphics = Graphics.FromImage(bmpY)
        fs.Close()
        fs.Dispose()
        gx.DrawImage(bmpX, New Rectangle(1, 1, bmpY.Width - 2, bmpY.Height - 2))
        intSEQ += 1
      End If
      DG.Rows.Add(r!QTN02.ToString.Trim, r!QTN03.ToString.Trim, bmpY, intSEQ.ToString("000"))
      aryBMPS.Add(intSEQ.ToString("000"), bytV)
    Next
    'Next
  End Sub

  Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
    Me.Close()
  End Sub

  Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    If strLKey = "" Then Return
    Dim oFL As New OpenFileDialog
    oFL.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyPictures
    oFL.Filter = BIG2GB("XPS檔案|*.XPS;*.oxps|圖檔|*.png;*.jpg;*.jpeg;*.bmp;*.gif|所有檔案|*.*")
    If oFL.ShowDialog = Windows.Forms.DialogResult.OK Then
      Try
        Dim bmpX As Bitmap = Nothing
        Dim bmpY As Bitmap = Nothing
        Dim strN As String = "001"
        If DG.Rows.Count > 0 Then
          strN = (Val(GCell(DG.Rows(DG.Rows.Count - 1).Cells(0))) + 1).ToString("000")
        End If
        intSEQ += 1
        Dim strR As String = intSEQ.ToString("000")
        If IO.Path.GetExtension(oFL.FileName).ToUpper.EndsWith("XPS") = False Then
          bmpX = New Bitmap(oFL.FileName)
          If bmpX IsNot Nothing Then
            Dim sngX As Single = bmpX.Width / bmpX.Height
            If sngX >= 1 Then
              bmpY = New Bitmap(80, CType(80 / sngX, Integer))
            Else
              bmpY = New Bitmap(CType(80 * sngX, Integer), 80)
            End If
            Dim gx As Graphics = Graphics.FromImage(bmpY)
            gx.Clear(Color.DarkGray)
            gx.DrawImage(bmpX, New Rectangle(1, 1, bmpY.Width - 2, bmpY.Height - 2))
          End If
        End If
        DG.Rows.Add(strN, oFL.FileName, bmpY, strR)
        Dim bytV() As Byte = IO.File.ReadAllBytes(oFL.FileName)
        aryBMPS.Add(strR, bytV)
      Catch ex As Exception

      End Try
    End If
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_delete, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", strLKey)
    DB.RsSQL(sqlCV.Text)
    For Each r As DataGridViewRow In DG.Rows
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_QTN")
      sqlCV.SqlFields("QTN01", strLKey)
      sqlCV.SqlFields("QTN02", GCell(r.Cells(0)))
      sqlCV.SqlFields("QTN03", GCell(r.Cells(1)))
      Dim strR As String = GCell(r.Cells(3))
      If aryBMPS.ContainsKey(strR) = True Then
        sqlCV.SqlFields("QTN05", aryBMPS(strR))
        DB.RsSQL(sqlCV.Text, sqlCV.GetImgs)
      Else
        DB.RsSQL(sqlCV.Text)
      End If
    Next
    Button1.Enabled = True
    Panel4.Enabled = False
    Panel1.Enabled = True
  End Sub

  Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", strLKey)
    sqlCV.SqlFields("QTN02", , , , True)
    sqlCV.SqlFields("QTN03")
    sqlCV.SqlFields("QTN05")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count = 0 Then Return
    Dim frm As New frmESOP
    frm.LoadBmp(rs)
    frm.ShowDialog()
  End Sub

  Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
    If DG.CurrentRow Is Nothing Then Return
    If strLKey = "" Then Return
    DG.Rows.Remove(DG.CurrentRow)
  End Sub

  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    If strLKey = "" Then Return
    If MsgBox(BIG2GB("確定要刪除這個SOP檔案?" & vbCrLf & strLKey.Substring(5)), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Return
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_delete, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", strLKey)
    DB.RsSQL(sqlCV.Text)
    DG.Rows.Clear()
    aryBMPS.Clear()
    Label4.Text = BIG2GB("請先選擇品號工序")
    Button1.Enabled = True
    Panel4.Enabled = False
    Panel1.Enabled = True
    strLKey = ""
  End Sub

  Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
    If DG.CurrentRow Is Nothing Then Return
    If DG.CurrentRow.Index = 0 Then
      MsgBox(BIG2GB("已經是最上一行無法上移"))
      Return
    End If
    Dim strS As String = GCell(DG.CurrentRow.Cells(1)), bmpY As Bitmap = DG.CurrentRow.Cells(2).Value
    Dim strR As String = GCell(DG.CurrentRow.Cells(3)), r As DataGridViewRow = DG.Rows(DG.CurrentRow.Index - 1)
    DG.CurrentRow.Cells(1).Value = GCell(r.Cells(1))
    DG.CurrentRow.Cells(2).Value = r.Cells(2).Value
    DG.CurrentRow.Cells(3).Value = GCell(r.Cells(3))
    r.Cells(1).Value = strS
    r.Cells(2).Value = bmpY
    r.Cells(3).Value = strR
    DG.CurrentCell = r.Cells(0)
  End Sub

  Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
    If DG.CurrentRow Is Nothing Then Return
    If DG.CurrentRow.Index = DG.Rows.Count - 1 Then
      MsgBox(BIG2GB("已經是最末一行無法下移"))
      Return
    End If
    Dim strS As String = GCell(DG.CurrentRow.Cells(1)), bmpY As Bitmap = DG.CurrentRow.Cells(2).Value
    Dim strR As String = GCell(DG.CurrentRow.Cells(3)), r As DataGridViewRow = DG.Rows(DG.CurrentRow.Index + 1)
    DG.CurrentRow.Cells(1).Value = GCell(r.Cells(1))
    DG.CurrentRow.Cells(2).Value = r.Cells(2).Value
    DG.CurrentRow.Cells(3).Value = GCell(r.Cells(3))
    r.Cells(1).Value = strS
    r.Cells(2).Value = bmpY
    r.Cells(3).Value = strR
    DG.CurrentCell = r.Cells(0)
  End Sub

  Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
    strLKey = ""
    Label4.Text = BIG2GB("請先選擇品號工序")
    aryBMPS.Clear()
    DG.Rows.Clear()
    Panel1.Enabled = True
    Panel4.Enabled = False
    Button1.Enabled = True
    ComboBox1.SelectedIndex = 0
    ComboBox2.SelectedIndex = 0
    ComboBox3.SelectedIndex = 0
  End Sub
End Class