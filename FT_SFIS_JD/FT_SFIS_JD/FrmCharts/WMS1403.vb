Public Class WMS1403
  Private XLS As XLS_FILE = Nothing
  Private Class ITSUM
    Public strI As String = ""
    Public strN As String = ""
    Public strM As String = ""
    Public sngU1 As Double = 0
    Public sngU2 As Double = 0
    Public sngQT As Double = 0
    Public sngRV As Double = 0
    Public sngUP As Double = 0
    Public sngRe As Double = 0
    Public sngIS As Double = 0
    Public sngISRe As Double = 0
    Public intI As Integer = 0
  End Class
  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    Me.Close()
  End Sub

  Private Sub PM0403_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    TuiCK(Me)
  End Sub

  Private Sub PM0403_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    TextBox2.Text = lgnname
    TextBox3.Text = lgnname
    TextBox7.Text = Now.ToString("yyyy-M-dd")
    TextBox8.Text = Now.ToString("yyyy-M-dd")
  End Sub

  Private Sub Btnproduct_Click(sender As Object, e As EventArgs) Handles Btnproduct.Click
    Dim frm As New FrmTDQry
    If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
      Txtworkcode.Text = frm.TD01
      txtmachine.Text = frm.TD02
      Button1_Click(Nothing, Nothing)
    End If
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    If Txtworkcode.Text = "" Then Return
    ShowTC(txtmachine.Text.Trim)
  End Sub

  Private Sub Txtworkcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txtworkcode.KeyPress
    If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
      e.Handled = True
      My.Computer.Keyboard.SendKeys(vbTab)
    End If
  End Sub
  Private Sub ShowTC(strV As String)
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TC")
    sqlCV.Where("TC01", "=", strV)
    sqlCV.SqlFields("MAX(TC10)", "MVAL")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count = 0 Then
      Return
    End If
    Dim strTC10 As String = rs.Rows(0)!MVAL.ToString.Trim
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TD")
    sqlCV.Where("TD01", "=", Txtworkcode.Text.Trim)
    sqlCV.Where("TD02", "=", strV)
    sqlCV.SqlFields("*")
    Dim rtd As DataTable = DB.RsSQL(sqlCV.Text, "RTD")
    txtNum.Text = rtd.Rows(0)!TD07.ToString.Trim
    txtCUST.Text = rtd.Rows(0)!TD27.ToString.Trim

    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TC")
    sqlCV.Where("^0.TC01", "=", strV)
    sqlCV.Where("^0.TC10", "=", strTC10)
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "WMSA", "SA01", "=", "^0.TC02")
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TA", "TA01", "=", "^0.TC03")
    sqlCV.SqlFields("^0.TC03", "工序編號", , , True)
    sqlCV.SqlFields("^0.TC02", "料號", , , True)
    sqlCV.SqlFields("^1.SA02+' '+^1.SA03", "品名規格")
    sqlCV.SqlFields("^0.TC06", "單位數量")
    sqlCV.SqlFields("(0)", "總用量")
    sqlCV.SqlFields("^0.TC07", "料站位")
    sqlCV.SqlFields("^0.TC11", "零件位")
    sqlCV.SqlFields("^0.TC08", "替代料號")
    sqlCV.SqlFields("^1.SA04", "分類")
    rs = DB.RsSQL(sqlCV.Text, "RTC")
    For Each r As DataRow In rs.Rows
      r.Item(4) = (Val(r.Item(3).ToString.Trim) * Val(rtd.Rows(0)!TD07.ToString.Trim)).ToString("0")
    Next

    Dim aryIT As New Dictionary(Of String, ITSUM)
    Dim aryL As New ArrayList
    For Each r As DataRow In rs.Rows
      Dim strI As String = r.Item(0).ToString.Trim
      If aryL.Contains(strI) = False Then
        aryL.Add(strI)
      End If
    Next
    aryL.Sort()
    For Each r As DataRow In rs.Rows
      Dim strI As String = r.Item(1).ToString.Trim
      If aryIT.ContainsKey(strI) = False Then
        aryIT.Add(strI, New ITSUM)
        aryIT(strI).strI = strI
        aryIT(strI).strN = r.Item(2).ToString.Trim
        aryIT(strI).strM = r.Item(0).ToString.Trim
      End If
      If aryL(0) = r.Item(0).ToString.Trim Then
        aryIT(strI).sngU1 += Val(r.Item(3).ToString.Trim)
      Else
        aryIT(strI).sngU2 += Val(r.Item(3).ToString.Trim)
      End If
      aryIT(strI).sngQT += Val(r.Item(4).ToString.Trim)
    Next
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "WMSEA")
    Dim w As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "WMSE", "SE01", "=", "^0.SEA01")
    w.Add("WMSE.SE02", "=", "WMSEA.SEA02")
    sqlCV.Where("^1.SE12", "=", Txtworkcode.Text.Trim)
    sqlCV.SqlFields("^0.SEA01")
    sqlCV.SqlFields("^0.SEA04")
    sqlCV.SqlFields("^0.SEA06")
    sqlCV.SqlFields("^0.SEA14")
    Dim rs1 As DataTable = DB.RsSQL(sqlCV.Text, "RT")

    For Each r As DataRow In rs1.Rows
      Dim strI As String = r!SEA04.ToString.Trim
      If aryIT.ContainsKey(strI) = False Then
        aryIT.Add(strI, New ITSUM)
        aryIT(strI).strI = strI
      End If
      Select Case r!SEA01.ToString.Trim
        Case "EI0" '來料
          aryIT(strI).sngRV += Val(r!SEA06.ToString)
          aryIT(strI).sngUP += Val(r!SEA14.ToString)
          aryIT(strI).intI += 1
        Case "EI1" '退料
          aryIT(strI).sngRe += Val(r!SEA14.ToString)
        Case "EI2" '發料
          aryIT(strI).sngIS += Val(r!SEA14.ToString)
        Case "EI3" '退倉
          aryIT(strI).sngISRe += Val(r!SEA14.ToString)
      End Select
    Next
    DG1.Rows.Clear()
    Dim intI As Integer = 0
    For Each strI As String In aryIT.Keys
      Dim itS As ITSUM = aryIT(strI)
      intI += 1
      DG1.Rows.Add(intI.ToString("000"), itS.strM, itS.strI, itS.strN, itS.sngU1, itS.sngU2, _
                   itS.sngQT, itS.sngRV, aryIT(strI).intI, "", itS.sngRV - itS.sngQT, itS.sngRe, _
                   itS.sngRV - itS.sngQT - itS.sngRe
                  )
    Next
    DG1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
  End Sub

  Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    If DG1.Rows.Count = 0 Then Return
    setExcelFile()
    DoXLS()
  End Sub
  Private Sub setExcelFile()
    XLS = New XLS_FILE
    XLS.SetNewSheet("NEWSHEET")
    With XLS
      Dim intC As Integer = 0
      Dim intR As Integer = 0
      Dim intX As Integer = 0
      .AddCell(1, 1, BIG2GB("東莞勇曜電子有限公司"))
      .CombineCells(0, 1, 15, 1)
      '.AddBorder(0, 1, 5, 1, BorderType.ALL, ExcelPara.xlThin)

      .AddCell(2, 1, BIG2GB("發/退料明細表"))
      .CombineCells(0, 2, 15, 2)
      '.AddBorder(0, 2, 5, 2, BorderType.ALL, ExcelPara.xlThin)

      .AddCell(3, 1, BIG2GB("客戶:") & txtCUST.Text.Trim)
      .CombineCells(0, 3, 2, 3)
      '.AddBorder(0, 3, 1, 3, BorderType.ALL, ExcelPara.xlThin)

      .AddCell(3, 4, BIG2GB("機種:") & txtmachine.Text.Trim)
      .AddCell(3, 8, BIG2GB("工單:"))
      .AddCell(3, 9, Txtworkcode.Text.Trim)
      .AddCell(3, 13, BIG2GB("批量"))
      .AddCell(3, 14, txtNum.Text.Trim)
      For Each c As DataGridViewColumn In DG1.Columns
        intC += 1
        .AddCell(4, intC, c.HeaderText)
      Next

      For Each r As DataGridViewRow In DG1.Rows
        intX = intR + 5
        .AddCell(intX, 1, GCell(r.Cells(0)))
        .AddCell(intX, 2, GCell(r.Cells(1)))
        .AddCell(intX, 3, GCell(r.Cells(2)))
        .AddCell(intX, 4, GCell(r.Cells(3)))
        .AddCell(intX, 5, GCell(r.Cells(4)))
        .AddCell(intX, 6, GCell(r.Cells(5)))
        .AddCell(intX, 7, GCell(r.Cells(6)))
        .AddCell(intX, 8, GCell(r.Cells(7)))
        .AddCell(intX, 9, GCell(r.Cells(8)))
        .AddCell(intX, 10, GCell(r.Cells(9)))
        .AddCell(intX, 11, GCell(r.Cells(10)))
        .AddCell(intX, 12, GCell(r.Cells(11)))
        .AddCell(intX, 13, GCell(r.Cells(12)))
        .AddCell(intX, 14, GCell(r.Cells(13)))
        .AddCell(intX, 15, GCell(r.Cells(14)))
        .AddCell(intX, 16, GCell(r.Cells(15)))
        intR += 1
      Next
      '加入邊框線條
      '.AddBorder(0, 2, 18, 2, BorderType.ALLLines, ExcelPara.xlThin)
      .AddCell(intX + 1, 1, BIG2GB("發料人:") & TextBox2.Text.Trim & TextBox8.Text.Trim)
      .CombineCells(0, intX + 1, 3, intX + 1)
      '.AddBorder(0, intX + 1, 1, intX + 1, BorderType.ALL, ExcelPara.xlThin)

      .AddCell(intX + 1, 7, BIG2GB("單位主管:") & TextBox1.Text.Trim)
      .CombineCells(6, intX + 1, 7, intX + 1)
      '.AddBorder(4, intX + 1, 5, intX + 1, BorderType.ALL, ExcelPara.xlThin)

      .AddCell(intX + 1, 12, BIG2GB("收料人:") & TextBox6.Text.Trim)
      .CombineCells(11, intX + 1, 12, intX + 1)
      '.AddBorder(4, intX + 2, 5, intX + 2, BorderType.ALL, ExcelPara.xlThin)

      .AddCell(intX + 2, 1, BIG2GB("製表人:") & TextBox3.Text.Trim & TextBox7.Text.Trim)
      .CombineCells(0, intX + 2, 3, intX + 2)
      '.AddBorder(4, intX + 3, 5, intX + 3, BorderType.ALL, ExcelPara.xlThin)

      .AddCell(intX + 2, 7, BIG2GB("IQC確認:") & TextBox4.Text.Trim)
      .CombineCells(6, intX + 2, 7, intX + 2)

      .AddCell(intX + 2, 12, BIG2GB("編碼:") & TextBox5.Text.Trim)
      .CombineCells(11, intX + 2, 12, intX + 2)
    End With
  End Sub
  Private Sub DoXLS()
    Dim SFL As New SaveFileDialog
    If My.Settings.XLS1406 = "" Then
      SFL.InitialDirectory = Environment.SpecialFolder.MyDocuments
    Else
      SFL.InitialDirectory = IO.Path.GetDirectoryName(My.Settings.XLS1406)
    End If
    SFL.DefaultExt = "Xlsx"
    SFL.Filter = BIG2GB("Excel檔案|*.Xlsx|所有檔案|*.*")
    SFL.Title = BIG2GB("請選擇檔案")
    If SFL.ShowDialog = Windows.Forms.DialogResult.OK Then
      My.Settings.XLS1406 = SFL.FileName
      My.Settings.Save()
      XLS.Free2XLS(True)
      XLS.Close(SFL.FileName)
      XLS.Quit()
      XLS = Nothing
    End If
  End Sub
End Class