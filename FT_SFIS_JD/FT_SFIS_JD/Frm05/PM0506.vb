Public Class PM0506
  Private XLSMA As clsExcelImport = Nothing
  Private bolMA As Boolean = False
  Private XLSAP As Object
  Private strDBG As String = ""
  Private strDED As String = ""
  Private aryMach As New Dictionary(Of String, String)
  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()

    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    languagechange(Me)
  End Sub
  Private Class AID
    Public strID As String = ""
    Public bolCmpl As Boolean = False
    Public bolDefe As Boolean = False
    Public bolRewk As Boolean = False
    Public bolFrst As Boolean = False
  End Class
  'Private Function GetTotal(intType As String, strLine As String, strDB As String, strDE As String) As Integer
  '  Dim sqlCV As New APSQL.SQLCNV
  '  sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TP")
  '  sqlCV.Where("TP01", ">=", strDB)
  '  sqlCV.Where("TP01", "<=", strDE)
  '  If strLine <> "" Then sqlCV.Where("TP02", "=", strLine)
  '  If intType <> "" Then sqlCV.Where("TP05", "=", intType, APSQL.intFMode.msfld_num)
  '  sqlCV.SqlFields("SUM(TP07)", "QTY")
  '  Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "TPT")
  '  If rs.Rows.Count = 0 Then
  '    DB.CloseRs(rs)
  '    Return 0
  '  Else
  '    Dim intV As Integer = Val(rs.Rows(0)!QTY.ToString)
  '    DB.CloseRs(rs)
  '    Return intV
  '  End If
  'End Function
  Private Sub ReList()
    'Dim dt As Date = DTP1.Value
    strDBG = DTP1.Value.ToString("yyyy\/MM\/dd")
    strDED = DTP2.Value.ToString("yyyy\/MM\/dd")
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TP")
    sqlCV.Where("TP01", ">=", strDBG)
    sqlCV.Where("TP01", "<=", strDED)
    'sqlCV.Where("TP02", "<>", "Q")
    sqlCV.SqlFields("TP05", "分類", , True, True)
    sqlCV.SqlFields("TP02", "拉別", , True, True)
    sqlCV.SqlFields("TP03", "製令編號", , True, True)
    sqlCV.SqlFields("TP04", "成品編號", , True)
    sqlCV.SqlFields("SUM(0)", "訂單數量")
    sqlCV.SqlFields("SUM(TP07)", "生產數量")
    sqlCV.SqlFields("SUM(0)", "未測數量")
    sqlCV.SqlFields("SUM(TP08)", "不良數")
    Dim rs As DataTable = DB.RsSQL(BIG2GB(sqlCV.Text), "RV")
    If rs.Rows.Count = 0 Then
      DG.DataSource = Nothing
      Return
    End If
    Dim strM As String = "", strK As String = "", aryD As New Dictionary(Of String, Integer)
    For Each r As DataRow In rs.Rows
      If aryD.ContainsKey(r.Item(2).ToString.Trim) = False Then
        aryD.Add(r.Item(2).ToString.Trim, 0)
      End If
      strM = "'" & r.Item(0).ToString.Trim & "_" & r.Item(1).ToString.Trim & "'"
      If strK.Contains(strM) = False Then
        strK &= strM & ","
      End If
    Next
    strM = ""
    For Each strS As String In aryD.Keys
      strM &= "'" & strS & "',"
    Next
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TD")
    sqlCV.Where("TD01", "IN", strM.Trim(","), APSQL.intFMode.msfld_field)
    sqlCV.SqlFields("TD01")
    sqlCV.SqlFields("TD07")
    Dim rs1 As DataTable = DB.RsSQL(sqlCV.Text, "RTP")
    For Each r As DataRow In rs1.Rows
      aryD(r!TD01.ToString.Trim) = Val(r!TD07.ToString.Trim)
    Next
    For Each r As DataRow In rs.Rows
      Dim strP As String = r.Item(2).ToString.Trim
      If aryD.ContainsKey(strP) Then
        r.Item(4) = aryD(strP)
        r.Item(6) = aryD(strP) - Val(r.Item(5).ToString)
      Else
        r.Item(4) = 0
      End If
    Next
    Dim strK1 As String = ""
    Dim strK2 As String = ""
    Dim intQ4 As Integer = 0
    Dim intQ5 As Integer = 0
    Dim intQ6 As Integer = 0
    Dim intQ7 As Integer = 0
    Dim intS4 As Integer = 0
    Dim intS5 As Integer = 0
    Dim intS6 As Integer = 0
    Dim intS7 As Integer = 0
    Dim intI As Integer = 0
    While intI < rs.Rows.Count
      If strK2 <> rs.Rows(intI).Item(1).ToString Or strK1 <> rs.Rows(intI).Item(0).ToString Then
        If strK2 <> "" Then
          Dim r1 As DataRow = rs.NewRow
          r1.Item(0) = strK1
          r1.Item(1) = strK2
          r1.Item(3) = BIG2GB("小計：")
          r1.Item(4) = intQ4
          r1.Item(5) = intQ5
          r1.Item(6) = intQ6
          r1.Item(7) = intQ7
          rs.Rows.InsertAt(r1, intI)
          intI += 1
        End If
        strK2 = rs.Rows(intI).Item(1).ToString
        intS4 += intQ4
        intS5 += intQ5
        intS6 += intQ6
        intS7 += intQ7
        intQ4 = 0
        intQ5 = 0
        intQ6 = 0
        intQ7 = 0
      End If
      If strK1 <> rs.Rows(intI).Item(0).ToString Then
        If strK1 <> "" Then
          Dim r1 As DataRow = rs.NewRow
          r1.Item(0) = strK1
          r1.Item(1) = ""
          r1.Item(3) = BIG2GB("總計：")
          r1.Item(4) = intS4
          r1.Item(5) = intS5
          r1.Item(6) = intS6
          r1.Item(7) = intS7
          rs.Rows.InsertAt(r1, intI)
          intI += 1
        End If
        strK1 = rs.Rows(intI).Item(0).ToString
        intS4 = 0
        intS5 = 0
        intS6 = 0
        intS7 = 0
      End If
      intQ4 += rs.Rows(intI).Item(4)
      intQ5 += rs.Rows(intI).Item(5)
      intQ6 += rs.Rows(intI).Item(6)
      intQ7 += rs.Rows(intI).Item(7)
      intI += 1
    End While
    If strK2 <> "" Then
      Dim r1 As DataRow = rs.NewRow
      r1.Item(0) = strK1
      r1.Item(1) = strK2
      r1.Item(3) = BIG2GB("小計：")
      r1.Item(4) = intQ4
      r1.Item(5) = intQ5
      r1.Item(6) = intQ6
      r1.Item(7) = intQ7
      rs.Rows.Add(r1)
    End If
    intS4 += intQ4
    intS5 += intQ5
    intS6 += intQ6
    intS7 += intQ7
    If strK1 <> "" Then
      Dim r1 As DataRow = rs.NewRow
      r1.Item(0) = strK1
      r1.Item(1) = ""
      r1.Item(3) = BIG2GB("總計：")
      r1.Item(4) = intS4
      r1.Item(5) = intS5
      r1.Item(6) = intS6
      r1.Item(7) = intS7
      rs.Rows.Add(r1)
    End If
    DG.DataSource = rs
    For Each c As DataGridViewColumn In DG.Columns
      c.SortMode = DataGridViewColumnSortMode.NotSortable
    Next
    For Each r As DataGridViewRow In DG.Rows
      If GCell(r.Cells(3)) = BIG2GB("小計：") Then
        r.DefaultCellStyle.BackColor = Color.Wheat
      ElseIf GCell(r.Cells(3)) = BIG2GB("總計：") Then
        r.DefaultCellStyle.BackColor = Color.Black
        r.DefaultCellStyle.ForeColor = Color.White
      End If
    Next
  End Sub
  Private Sub UpdateTP(sD As Dictionary(Of String, AID), s1 As String, s2 As String, s3 As String, s4 As String)
    Dim intQ1 As Integer = 0
    Dim intQ2 As Integer = 0
    Dim intQ3 As Integer = 0
    Dim intQ5 As Integer = 0
    Dim intQ4 As Integer = 0
    Dim intA2 As Integer = 0
    Dim intA3 As Integer = 0
    Dim intA5 As Integer = 0
    For Each s As AID In sD.Values
      If s.bolRewk Then
        intQ4 += 1
        If s.bolCmpl Then intA2 += 1
        If s.bolDefe Then intA3 += 1
        If s.bolFrst Then intA5 += 1
      Else
        intQ1 += 1
        If s.bolCmpl Then intQ2 += 1
        If s.bolDefe Then intQ3 += 1
        If s.bolFrst Then intQ5 += 1
      End If
    Next
    If intQ1 > 0 Then
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "SFIS_TP")
      sqlCV.SqlFields("TP01", s1)
      sqlCV.SqlFields("TP02", s2)
      sqlCV.SqlFields("TP03", s3)
      sqlCV.SqlFields("TP04", s4)
      If s4.StartsWith("S008.") Then
        sqlCV.SqlFields("TP05", 0, APSQL.intFMode.msfld_num)
      ElseIf s4.StartsWith("D001.") Then
        sqlCV.SqlFields("TP05", 1, APSQL.intFMode.msfld_num)
      Else
        sqlCV.SqlFields("TP05", 9, APSQL.intFMode.msfld_num)
      End If
      sqlCV.SqlFields("TP06", intQ5, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TP07", intQ2, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TP08", intQ3, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TP09", intQ1 - intQ2, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TP10", CDate(s1).Month, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TP11", DatePart(DateInterval.WeekOfYear, CDate(s1)))
      DB.RsSQL(sqlCV.Text)
    End If
    If intQ4 > 0 Then
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "SFIS_TP")
      sqlCV.SqlFields("TP01", s1)
      sqlCV.SqlFields("TP02", s2)
      sqlCV.SqlFields("TP03", s3)
      sqlCV.SqlFields("TP04", s4)
      sqlCV.SqlFields("TP05", 2, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TP06", intA5, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TP07", intA2, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TP08", intA3, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TP09", intQ4 - intA2, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TP10", CDate(s1).Month, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TP11", DatePart(DateInterval.WeekOfYear, CDate(s1)))
      DB.RsSQL(sqlCV.Text)
    End If
  End Sub
  Private Function GetLine(strL As String) As String
    If aryMach.Count = 0 Then
      Dim sqlCV As New APSQL.SQLCNV
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TJ")
      sqlCV.SqlFields("TJ01")
      sqlCV.SqlFields("TJ03")
      Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
      For Each r As DataRow In rs.Rows
        If aryMach.ContainsKey(r!TJ01.ToString.Trim) = False Then
          aryMach.Add(r!TJ01.ToString.Trim, r!TJ03.ToString.Trim)
        End If
      Next
      DB.CloseRs(rs)
    End If
    Dim strV() As String = strL.Split(",")
    Dim strLine As String = ""
    If aryMach.ContainsKey(strV(0)) = True Then
      strLine = aryMach(strV(0))
    End If
    If strLine = "" Then strLine = "COMMON"
    Return strLine
  End Function
  Private Sub CalcSum(strD As String)
    Dim sqlCV As New APSQL.SQLCNV
    Dim strKey As String = ""
    Dim strK1 As String = ""
    Dim strItem As String = ""
    Dim strGrp As String = ""
    Dim strLGrp As String = ""
    Dim aryIDs As New Dictionary(Of String, AID)
    Dim aryMOs As New Dictionary(Of String, String)
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TM")
    sqlCV.SqlJoin(APSQL.SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TN", "TN01", "=", "^0.TM01")
    sqlCV.Where("Convert(varchar(10),^0.TM06,111)", "=", strD)
    sqlCV.SqlFields("^0.TM04", "LINE", , , True)
    sqlCV.SqlFields("^0.TM01", , , , True)
    sqlCV.SqlFields("^0.TM06", , , , True)
    sqlCV.SqlFields("^0.TM02")
    sqlCV.SqlFields("^0.TM08")
    sqlCV.SqlFields("^1.TN02")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT1")
    For Each r As DataRow In rs.Rows
      r!LINE = getLine(r!LINE.ToString.Trim)
    Next
    rs.DefaultView.Sort = "LINE ASC,TM01 ASC,TM06 ASC"
    Dim strM As String = ""
    For Each r As DataRowView In rs.DefaultView
      If r!TM08.ToString.Trim = "8" Then Continue For
      If aryMOs.ContainsKey(r!TN02.ToString.Trim) = False Then
        aryMOs.Add(r!TN02.ToString.Trim, "")
        strM &= "'" & r!TN02.ToString.Trim & "',"
      End If
    Next
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TD")
    sqlCV.Where("^0.TD01", "IN", strM.Trim(","), APSQL.intFMode.msfld_field)
    sqlCV.SqlJoin(APSQL.SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TDA", "TDA01", "=", "^0.TD01")
    sqlCV.SqlJoin(APSQL.SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TA", "TA01", "=", "^1.TDA03")
    sqlCV.Where("^1.TDA04", "=", "0")
    sqlCV.SqlFields("^0.TD01", , , , True)
    sqlCV.SqlFields("^1.TDA02", , , , True)
    sqlCV.SqlFields("^1.TDA03")
    sqlCV.SqlFields("^2.TA04")
    sqlCV.SqlFields("TD02")
    Dim rs1 As DataTable = DB.RsSQL(sqlCV.Text, "RTDA")
    For Each r As DataRow In rs1.Rows
      Dim strTD01 As String = r!TD01.ToString.Trim
      If aryMOs.ContainsKey(strTD01) = True Then
        If aryMOs(strTD01) = "" Then
          aryMOs(strTD01) = r!TD02.ToString.Trim
        End If
        If r!TA04.ToString.Trim.StartsWith("100%") Then
          aryMOs(strTD01) &= "^" & r!TDA03.ToString.Trim
        End If
      End If
    Next
    DB.CloseRs(rs1)
    Dim rsv As DataView = rs.AsDataView
    rsv.Sort = "LINE ASC,TN02 ASC"
    For Each r As DataRowView In rsv
      If r!TM08.ToString.Trim = "8" Or r!LINE.ToString = "COMMON" Then Continue For
      Debug.Print(r!LINE.ToString & "," & r!TN02.ToString)
      If strKey <> r!LINE.ToString Or strK1 <> r!TN02.ToString.Trim Then
        If strKey <> "" Then
          UpdateTP(aryIDs, strD, strKey, strK1, strItem)
        End If
        aryIDs.Clear()
        strKey = r!LINE.ToString
        strK1 = r!TN02.ToString
        If aryMOs.ContainsKey(strK1) Then
          Dim strV() As String = aryMOs(strK1).Split("^")
          strItem = strV(0)
          strGrp = strV(1)
          strLGrp = strV(strV.GetUpperBound(0))
        End If
      End If
      Dim s As AID = Nothing
      Dim strID As String = r!TM01.ToString.Trim
      If aryIDs.ContainsKey(strID) Then
        s = aryIDs(strID)
      Else
        s = New AID
        s.strID = strID
        If r!TN02.ToString.Trim.StartsWith("#") Then
          s.bolRewk = True
        End If
        aryIDs.Add(s.strID, s)
      End If
      Select Case r!TM08.ToString.Trim
        Case "0", "3"
          If r!TM02.ToString.Trim = strGrp Then
            s.bolFrst = True
          ElseIf r!TM02.ToString.Trim = strLGrp Then
            s.bolCmpl = True
          End If
        Case "1", "2", "5"
          s.bolDefe = True
      End Select
    Next
    If strKey <> "" Then
      UpdateTP(aryIDs, strD, strKey, strK1, strItem)
    End If
  End Sub
  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    Dim sqlCV As New APSQL.SQLCNV
    Dim dt As Date = DTP1.Value
    Dim strBG As String = DTP1.Value.ToString("yyyy\/MM\/dd")
    Dim strED As String = DTP2.Value.ToString("yyyy\/MM\/dd") 'CDate(dt.AddMonths(1).ToString("yyyy/MM") & "/01").AddDays(-1).ToString("yyyy\/MM\/dd")
    'strED = CDate(strED).AddDays(-1).ToString("yyyy\/MM\/dd")
    If strBG.StartsWith(strED.Substring(0, 8)) Then strBG = strED.Substring(0, 8) & "01"
    If CheckBox1.Checked Then
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_delete, "SFIS_TP")
      sqlCV.Where("TP01", ">=", strBG)
      sqlCV.Where("TP01", "<=", strED)
      DB.RsSQL(sqlCV.Text)
    End If
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_distinc, "SFIS_TM")
    sqlCV.Where("TM06", ">=", strBG & " 00:00:00", APSQL.intFMode.msfld_datetime)
    sqlCV.Where("TM06", "<=", strED & " 23:59:59", APSQL.intFMode.msfld_datetime)
    sqlCV.SqlFields("Convert(Varchar(10),TM06,111)", "DATES", , , True)
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    For Each r As DataRow In rs.Rows
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TP")
      sqlCV.Where("TP01", "=", r!DATES.ToString)
      sqlCV.SqlFields("*")
      Dim rs1 As DataTable = DB.RsSQL(sqlCV.Text, "RT1")
      If rs1.Rows.Count = 0 Then
        CalcSum(r!DATES.ToString)
      End If
      DB.CloseRs(rs1)
    Next
    ReList()
    DB.CloseRs(rs)
  End Sub

  Private Sub PM0506_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    Try
      If XLSMA IsNot Nothing Then
        XLSMA.Quit(True)
      End If
    Catch ex As Exception

    End Try
    If XLSAP IsNot Nothing Then
      XLSAP.Quit()
      XLSAP = Nothing
    End If
    GC.Collect()
    TuiCK(Me)
  End Sub

  Private Sub PM0506_Load(sender As Object, e As EventArgs) Handles Me.Load
    DTP1.Value = Now.AddDays(-1).Date
    DTP2.Value = DTP1.Value
    dgdaochu(DG)
    TextBox1.Text = My.Settings.XLS0506
  End Sub

  Private Sub DG_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DG.CellFormatting
    If e.ColumnIndex = 0 Then
      Select Case GCell(DG.Rows(e.RowIndex).Cells(0))
        Case "0"
          e.Value = BIG2GB("主機")
        Case "1"
          e.Value = BIG2GB("成品")
        Case "2"
          e.Value = BIG2GB("返工")
      End Select
    End If
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    Dim OFL As New SaveFileDialog
    If TextBox1.Text.Trim = "" Then
      OFL.InitialDirectory = Environment.SpecialFolder.MyDocuments
    Else
      OFL.InitialDirectory = IO.Path.GetDirectoryName(TextBox1.Text)
    End If
    OFL.DefaultExt = "XLS"
    OFL.Filter = BIG2GB("Excel檔案|*.XLS|所有檔案|*.*")
    OFL.FileName = IO.Path.GetFileName(TextBox1.Text)
    OFL.Title = BIG2GB("請選擇檔案")
    If OFL.ShowDialog = Windows.Forms.DialogResult.OK Then
      TextBox1.Text = OFL.FileName
      Dim strO As String = GetXLS("0506", TextBox1.Text.Trim, "#@REPORTS||03PATH")
      If strO = "" Then
        MsgBox(BIG2GB("無法存檔，找不到母版"))
        Return
      End If
      My.Settings.XLS0506 = TextBox1.Text.Trim
      bolMA = True
      XLSMA = New clsExcelImport(XLSAP, strO)
      XLSAP = XLSMA.XLSAPP
      XLSMA.ReadXlt("DATAS")
      Dim intI As Integer = 0, intE As Integer = -1, intB As Integer = 0
      For intI = 0 To DG.Rows.Count - 1
        If GCell(DG.Rows(intI).Cells(0)) = "0" Or GCell(DG.Rows(intI).Cells(0)) = "9" Then
          intE = intI
        Else
          Exit For
        End If
      Next
      If intE = -1 Then
        XLSMA.SheetDelete("REPORT")
      Else
        ToPutData("0", 0, intE)
      End If
      intB = intE + 1
      For intI = intB To DG.Rows.Count - 1
        If GCell(DG.Rows(intI).Cells(0)) = "1" Then
          intE = intI
        Else
          Exit For
        End If
      Next
      If intB > intE Then
        XLSMA.SheetDelete("REPORT1")
      Else
        ToPutData("1", intB, intE)
      End If
      intB = intE + 1
      For intI = intB To DG.Rows.Count - 1
        If GCell(DG.Rows(intI).Cells(0)) = "2" Then
          intE = intI
        Else
          Exit For
        End If
      Next
      If intB > intE Then
        XLSMA.SheetDelete("REPORT2")
      Else
        ToPutData("2", intB, intE)
      End If
      XLSMA.SheetDelete("DATAS")
      XLSMA.Add_Data("SHOW", "")
      XLSMA.SaveXLS()
    End If
  End Sub
  Private Sub ToPutData(strTYPE As String, intB As Integer, intE As Integer)
    If strTYPE <> "0" Then
      XLSMA.Extra = strTYPE
    Else
      XLSMA.Extra = ""
    End If
    XLSMA.Add_Data("EXPAND", (intE - intB + 1).ToString("0"))
    Dim strM As String = "生產部" & strDBG.Substring(0, 4) & "年" & strDBG.Substring(5, 2) & "月" & strDBG.Substring(8, 2) & "日"
    If strDBG = strDED Then
      strM &= " $$MD$$生產日報表"
    Else
      strM &= "至" & strDED.Substring(0, 4) & "年" & strDED.Substring(5, 2) & "月" & strDED.Substring(8, 2) & "日"
      strM &= " $$MD$$生產統計表"
    End If
    Select Case strTYPE
      Case "0", "9"
        XLSMA.Add_Data("DATE", BIG2GB(strM.Replace("$$MD$$", "主機")))
      Case "1"
        XLSMA.Add_Data("DATE", BIG2GB(strM.Replace("$$MD$$", "成品")))
      Case "2"
        XLSMA.Add_Data("DATE", BIG2GB(strM.Replace("$$MD$$", "返工")))
    End Select
    For intI As Integer = intB To intE
      Dim c1 As Color = Color.White, c2 As Color = Color.Black
      Dim r As DataGridViewRow = DG.Rows(intI)
      If GCell(r.Cells(3)) = BIG2GB("小計：") Then
        c2 = Color.Red
        c1 = Color.Wheat
      ElseIf GCell(r.Cells(3)) = BIG2GB("總計：") Then
        c2 = Color.Blue
        c1 = Color.Wheat
      End If
      XLSMA.Add_Data("LINE", GCell(r.Cells(1)), c2.ToArgb, c1.ToArgb)
      XLSMA.Add_Data("MO", GCell(r.Cells(2)), c2.ToArgb, c1.ToArgb)
      XLSMA.Add_Data("ITEM", GCell(r.Cells(3)), c2.ToArgb, c1.ToArgb)
      XLSMA.Add_Data("MOQTY", GCell(r.Cells(4)), c2.ToArgb, c1.ToArgb)
      XLSMA.Add_Data("DQTY", GCell(r.Cells(5)), c2.ToArgb, c1.ToArgb)
      XLSMA.Add_Data("DWIP", GCell(r.Cells(6)), c2.ToArgb, c1.ToArgb)
      XLSMA.Add_Data("DEFECT", GCell(r.Cells(7)), c2.ToArgb, c1.ToArgb)
    Next
    XLSMA.ClearMap()
  End Sub

  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    Me.Close()
  End Sub
End Class
