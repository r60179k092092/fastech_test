Public Class Frm0520
  Private clsPWR As clsPowerOnReport = Nothing
  Private XLSMA As XLS_FILE = Nothing

  Private Sub Frm0520_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    GetGX()
  End Sub
  Private Sub Frm0520_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    TuiCK(Me)
  End Sub

  Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
    Me.Close()
  End Sub
  Private Sub GetGX()
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TA")
    sqlCV.SqlFields("TA01", "KEYS")
    sqlCV.SqlFields("TA01 + ' ' + TA02", "DATAS") '"QTN02 + ' ' + QTN03", "DATAS"
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "TA")
    If rs.Rows.Count = 0 Then Return
    cbGX.DisplayMember = "DATAS"
    cbGX.ValueMember = "KEYS"
    cbGX.DataSource = rs
    cbGX.SelectedIndex = 0
  End Sub

  Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
    If TabControl1.SelectedIndex = 1 Then
      DGMO.DataSource = GetTD()
    End If
  End Sub
  Private Function GetTD(Optional strM As String = "") As DataTable
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TD")
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TBB", "TBB03", "=", "^0.TD02")
    If strM <> "" Then
      sqlCV.Where("TD01", "LIKE", strM & "%")
    End If
    sqlCV.SqlFields("TD23", BIG2GB("製令單號"))
    sqlCV.SqlFields("TD01", BIG2GB("工單號"))
    sqlCV.SqlFields("TD02", BIG2GB("物料編號"))
    sqlCV.SqlFields("^1.TBB05 + ' ' + ^1.TBB06", BIG2GB("品名規格"))
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "TD")
    If rs.Rows.Count = 0 Then Return Nothing
    Return rs
  End Function

  Private Sub DGMO_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGMO.CellContentDoubleClick
    If e.RowIndex < 0 Or e.RowIndex > DGMO.Rows.Count Then Return
    Dim MoDatarow As DataGridViewRow = DGMO.Rows(e.RowIndex)
    TabControl1.SelectedIndex = 0
    lbMF_NO.Text = GCell(MoDatarow.Cells(0))
    txtMO_NO.Text = GCell(MoDatarow.Cells(1))
    lbMRP_NO.Text = GCell(MoDatarow.Cells(2))
    lbSPEC.Text = GCell(MoDatarow.Cells(3))
    MoDatarow = Nothing
  End Sub

  Private Sub btnSrchMO_Click(sender As Object, e As EventArgs) Handles btnSrchMO.Click
    DGMO.DataSource = GetTD(txtSrchMO.Text.Trim)
  End Sub

  Private Sub txtMO_NO_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMO_NO.KeyDown
    If e.KeyCode = Keys.Enter Then
      My.Computer.Keyboard.SendKeys(vbTab)
    End If
  End Sub

  Private Sub txtMO_NO_LostFocus(sender As Object, e As EventArgs) Handles txtMO_NO.LostFocus
    Dim rs As DataTable = GetTD(txtMO_NO.Text.Trim)
    If rs.Rows.Count <> 1 Then
      lbMF_NO.Text = ""
      lbMRP_NO.Text = ""
      lbSPEC.Text = ""
      Return
    End If
    lbMF_NO.Text = rs.Rows(0).Item(0)
    lbMRP_NO.Text = rs.Rows(0).Item(2)
    lbSPEC.Text = rs.Rows(0).Item(3)
  End Sub

  Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
    txtMO_NO.Text = ""
    lbMF_NO.Text = ""
    lbMRP_NO.Text = ""
    lbSPEC.Text = ""
    cbGX.SelectedIndex = 0
  End Sub
  Private Sub GetPPID()
    If txtMO_NO.Text.Trim = "" Or cbGX.Text.Trim = "" Then Return
    'Dim rs As DataTable = DB.RsSQL("select SFIS_TM.TM01 " & BIG2GB("PPID") & ",SFIS_TM.TM02 " & BIG2GB("工序") & ",SFIS_TM.TM03 " & BIG2GB("員工") & _
    '                               ",SFIS_TM.TM04 " & BIG2GB("機台") & ",SFIS_TM.TM06 " & BIG2GB("時間") & ",SFIS_TM.TM07 " & BIG2GB("測試數據") & ",SFIS_TM.TM08 " & BIG2GB("結果") & _
    '                               ",SFIS_TM.TM09 " & BIG2GB("不良現象代碼") & " from SFIS_TM where TM02='" & cbGX.SelectedValue.ToString & _
    '                               "'  and TM01 in (select TN01 from sfis_TN where TN02='" & txtMO_NO.Text.Trim & "')", "PPID")
    Dim rs As DataTable = DB.RsSQL("select TM01,TM02,TM03,TM04,TM06,TM07,TM08,TM09 from SFIS_TM where TM02='" & cbGX.SelectedValue.ToString & _
                                "'  and TM01 in (select TN01 from sfis_TN where TN02='" & txtMO_NO.Text.Trim & "')", "PPID")
    If rs.Rows.Count = 0 Then
      'DG.DataSource = Nothing
      Return
    End If
    'DG.DataSource = rs
    clsPWR = New clsPowerOnReport(rs)
    clsPWR.SetReport2DG(DG)
    DG.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    DG.GridColor = Color.Black
  End Sub

  Private Sub btnSrch_Click(sender As Object, e As EventArgs) Handles btnSrch.Click
    GetPPID()
  End Sub

  Private Sub DGP_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
    If e.RowIndex < 0 Or e.RowIndex > DG.Rows.Count Then Return
    Dim PPIDDatarow As DataGridViewRow = DG.Rows(e.RowIndex)

  End Sub
  Private Sub SetExcelForm()
    XLSMA = New XLS_FILE
    Dim strT As String = ""
    Dim aryComb As New Dictionary(Of Integer, String)
    Dim intTitleLen As Integer = 0
    If clsPWR.TestType = "S" Then
      strT = BIG2GB("單色燈具通電測試參數")
      intTitleLen = 8
    ElseIf clsPWR.TestType = "D" Then
      strT = BIG2GB("三色燈具通電測試參數")
      intTitleLen = 9
    ElseIf clsPWR.TestType = "G" Then
      strT = BIG2GB("2.4G燈具通電測試參數")
      intTitleLen = 9
    End If
    Dim strC As String = "中 山 泽 东 照 明 有 限 公 司"
    XLSMA.SetNewSheet(BIG2GB(strT))

    With XLSMA
      .AddCell(1, 1, strC & vbCrLf & strT)
      .CombineCells(0, 1, intTitleLen - 1, 1)
      .AddBorder(0, 1, intTitleLen - 1, 1, BorderType.ALL, ExcelPara.xlThin)
      Dim intR As Integer = 0
      Dim intX As Integer = 0
      Dim intC As Integer = 0
      For Each c As DataGridViewColumn In DG.Columns
        intC += 1
        .AddCell(2, intC, c.HeaderText)
      Next
      .AddBorder(0, 2, intTitleLen - 1, 2, BorderType.ALLLines, ExcelPara.xlThin)
      For Each r As DataGridViewRow In DG.Rows
        intX = 3 + intR
        .AddCell(intX, 1, GCell(r.Cells(0)))
        .AddCell(intX, 2, GCell(r.Cells(1)))
        If aryComb.ContainsKey(intX) = False Then
          aryComb.Add(intX, GCell(r.Cells(1)).Trim)
        End If
        .AddCell(intX, 3, GCell(r.Cells(2)))
        .AddCell(intX, 4, GCell(r.Cells(3)))
        .AddCell(intX, 5, GCell(r.Cells(4)))
        .AddCell(intX, 6, GCell(r.Cells(5)))
        .AddCell(intX, 7, GCell(r.Cells(6)))
        .AddCell(intX, 8, GCell(r.Cells(7)))
        If intTitleLen > 8 Then
          .AddCell(intX, 9, GCell(r.Cells(8)))
        End If
        intR += 1
      Next
      If intTitleLen > 8 Then
        Dim intU As Integer = 0
        Dim intD As Integer = 0
        Dim bolU As Boolean = False
        For Each i As Integer In aryComb.Keys
          If aryComb(i) <> "" Then
            If bolU Then
              .CombineCells(1, intU, 1, intD)
            End If
            intU = i
            bolU = True
          Else
            intD = i
          End If
        Next
      End If
      .AddBorder(0, 3, DG.Columns.Count - 1, DG.Rows.Count + 2, BorderType.ALLLines, ExcelPara.xlThin)
    End With
  End Sub
  Private Sub btnDCEXL_Click(sender As Object, e As EventArgs) Handles btnDCEXL.Click
    If DG.Rows.Count = 0 Then Return
    SetExcelForm()
    DoXLS()
  End Sub
  Private Sub DoXLS()
    '輸出成EXCEL檔
    Dim OFL As New SaveFileDialog
    If My.Settings.XLS0512 = "" Then
      OFL.InitialDirectory = Environment.SpecialFolder.MyDocuments
    Else
      OFL.InitialDirectory = IO.Path.GetDirectoryName(My.Settings.XLS0512)
    End If
    OFL.DefaultExt = "Xlsx"
    OFL.Filter = BIG2GB("Excel檔案|*.Xlsx|所有檔案|*.*")
    OFL.Title = BIG2GB("請選擇檔案")
    If OFL.ShowDialog = Windows.Forms.DialogResult.OK Then
      My.Settings.XLS0512 = OFL.FileName
      My.Settings.Save()
      XLSMA.Free2XLS(True)
      XLSMA.Close(OFL.FileName)
      XLSMA.Quit()
      XLSMA = Nothing
    End If

  End Sub

End Class