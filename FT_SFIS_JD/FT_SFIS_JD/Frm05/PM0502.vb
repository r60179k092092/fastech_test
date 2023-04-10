Imports APSQL
Public Class PM0502
  Private Class ErrCount
    Public strID As String = ""
    Public intPcs As Integer = 0
    Public intCount As Integer = 0
    Public strRng As String = ""
  End Class
  Private Class ErrCode
    Public strID As String = ""
    Public strName As String = ""
    Public intCount As Integer = 0
    Public intPcs As Integer = 0
    Public aryList As New ArrayList
    Public intMode As Integer = 0
    Public aryRng As New Dictionary(Of String, ErrCount)
    Public Sub Add(r As DataRow)
      Dim intP As Integer = 0
      If aryList.Contains(r!TM01.ToString.Trim) = False Then
        intP = 1
        aryList.Add(r!TM01.ToString.Trim)
      End If
      intPcs += intP
      intCount += 1
      Dim s As ErrCount
      Select Case intMode
        Case 0
          Dim strV As String = r!TN02.ToString.Trim
          If aryRng.ContainsKey(strV) = False Then
            s = New ErrCount
            s.strID = strID
            s.strRng = strV
            aryRng.Add(strV, s)
          Else
            s = aryRng(strV)
          End If
          s.intCount += 1
          s.intPcs += intP
        Case 1
          Dim strV As String = CDate(r!TM06.ToString).ToString("yyyy\/MM\/dd")
          If aryRng.ContainsKey(strV) = False Then
            s = New ErrCount
            s.strID = strID
            s.strRng = strV
            aryRng.Add(strV, s)
          Else
            s = aryRng(strV)
          End If
          s.intCount += 1
          s.intPcs += intP
        Case 2
          Dim strV As String = CDate(r!TM06.ToString).ToString("yyyy\/MM\/dd HH")
          If aryRng.ContainsKey(strV) = False Then
            s = New ErrCount
            s.strID = strID
            s.strRng = strV
            aryRng.Add(strV, s)
          Else
            s = aryRng(strV)
          End If
          s.intCount += 1
          s.intPcs += intP
        Case 3
          Dim strV As String = BIG2GB("合計")
          If aryRng.ContainsKey(strV) = False Then
            s = New ErrCount
            s.strID = strID
            s.strRng = strV
            aryRng.Add(strV, s)
          Else
            s = aryRng(strV)
          End If
          s.intCount += 1
          s.intPcs += intP
        Case 4
          Dim strV As String = r!TM02.ToString.Trim
          If strV = "" Then strV = "UNKNOW"
          If aryRng.ContainsKey(strV) = False Then
            s = New ErrCount
            s.strID = strID
            s.strRng = strV
            aryRng.Add(strV, s)
          Else
            s = aryRng(strV)
          End If
          s.intCount += 1
          s.intPcs += intP
        Case 5
          Dim strV As String = r!TM03.ToString.Trim
          If strV = "" Then strV = "UNKNOW"
          If aryRng.ContainsKey(strV) = False Then
            s = New ErrCount
            s.strID = strID
            s.strRng = strV
            aryRng.Add(strV, s)
          Else
            s = aryRng(strV)
          End If
          s.intCount += 1
          s.intPcs += intP
        Case 6
          Dim strV As String = r!TM04.ToString.Trim
          If strV = "" Then strV = "UNKNOW"
          If aryRng.ContainsKey(strV) = False Then
            s = New ErrCount
            s.strID = strID
            s.strRng = strV
            aryRng.Add(strV, s)
          Else
            s = aryRng(strV)
          End If
          s.intCount += 1
          s.intPcs += intP
      End Select
    End Sub
  End Class
  Private aryC As New Dictionary(Of String, ErrCode)
  Private aryTL As Dictionary(Of String, Integer)
  Private aryMO As New Dictionary(Of String, Dictionary(Of String, Integer))
  Private strOrd As String = ""
  Private strCust As String = ""
  Private strModel As String = ""
  Private strQTY As String = ""
  Private strLines As String = ""
  Private strLCase As String = ""
  Private sngLCase As Double = 0
  Private lbt As New clsLBPRT
  Private sngX As Single = 1, sngY As Single = 1.5
  Private intP As Integer = 0
  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()

    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    languagechange(Me)

  End Sub

  Private Sub PM0502_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    TuiCK(Me)
  End Sub
  Private Sub PM0502_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    DTP1.Value = Now
    DTP2.Value = Now
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TD")
    sqlCV.Where("TD12", "IN", "0,1,2", APSQL.intFMode.msfld_field)
    sqlCV.SqlFields("TD01", "KEYS", , , True)
    sqlCV.SqlFields("TD01 + ' ' + ISNULL(TD19,'') + ' ' + ISNULL(TD02,'')", "DATAS")
    sqlCV.SqlFields("TD19")
    sqlCV.SqlFields("TD02")
    sqlCV.SqlFields("TD03")
    sqlCV.SqlFields("TD04")
    sqlCV.SqlFields("TD05")
    sqlCV.SqlFields("TD06")
    sqlCV.SqlFields("TD07")
    sqlCV.SqlFields("TD26")
    sqlCV.SqlFields("TD27")
    sqlCV.SqlFields("TD28")
    ComboBox2.DisplayMember = "DATAS"
    ComboBox2.ValueMember = "KEYS"
    ComboBox2.DataSource = DB.RsSQL(sqlCV.Text, "TDS")
    Button1_Click(Nothing, Nothing)
    dgdaochu(DG)
  End Sub

  Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
    DTP2.Enabled = CheckBox1.Checked
    DTP1.Enabled = CheckBox1.Checked
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    Dim intM As Integer = 1
    Dim strM As String = ""
    aryC.Clear()
    aryMO.Clear()
    If CheckBox2.Checked = True Or TextBox2.Text.Trim <> "" Or TextBox5.Text.Trim <> "" Then
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TD")
      If CheckBox2.Checked = True AndAlso ComboBox2.SelectedValue IsNot Nothing Then
        sqlCV.Where("TD01", "=", ComboBox2.SelectedValue.ToString.Trim)
      End If
      If TextBox2.Text.Trim <> "" Then
        sqlCV.Where("TD05+'-'+TD06", "LIKE", TextBox2.Text.Trim & "%")
      End If
      If TextBox5.Text.Trim <> "" Then
        sqlCV.Where("TD03+'-'+TD04", "LIKE", TextBox5.Text.Trim & "%")
      End If
      sqlCV.SqlFields("TD01", , , , True)
      sqlCV.SqlFields("TD23", , , , True)
      Dim rs1 As DataTable = DB.RsSQL(sqlCV.Text, "RT")
      If rs1.Rows.Count = 0 Then Return
      For Each r As DataRow In rs1.Rows
        strM &= "'" & r!TD01.ToString.Trim & "',"
      Next
    End If
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TM")
    If CheckBox1.Checked Then
      sqlCV.Where("^0.TM06", ">=", DTP1.Value.ToString("yyyy\/MM\/dd") & " 00:00:00", APSQL.intFMode.msfld_datetime)
      sqlCV.Where("^0.TM06", "<=", DTP2.Value.ToString("yyyy\/MM\/dd") & " 23:59:59", APSQL.intFMode.msfld_datetime)
    End If
    'sqlCV.Where("ISNULL(TM09,'')", "<>", "")
    sqlCV.SqlJoin(APSQL.SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TN", "TN01", "=", "^0.TM01")
    If strM <> "" Then
      sqlCV.Where("^1.TN02", "IN", strM.Trim(","), APSQL.intFMode.msfld_field)
    End If
    sqlCV.SqlFields("^0.TM01")
    sqlCV.SqlFields("^0.TM06", , , , True)
    sqlCV.SqlFields("^1.TN02")  '工單
    sqlCV.SqlFields("^0.TM02")  '工序
    sqlCV.SqlFields("^0.TM03")  '員工
    sqlCV.SqlFields("^0.TM04")  '機台
    sqlCV.SqlFields("^0.TM09")  '不良原因 
    Dim dt1 As DataTable = DB.RsSQL(sqlCV.Text, "RT"), s1 As ErrCode
    For Each r As DataRow In dt1.Rows
      If aryMO.ContainsKey(r!TN02.ToString.Trim) = False Then
        aryTL = New Dictionary(Of String, Integer)
        aryMO.Add(r!TN02.ToString.Trim, aryTL)
      Else
        aryTL = aryMO(r!TN02.ToString.Trim)
      End If
      If aryTL.ContainsKey(r!TM01.ToString.Trim) = False Then
        aryTL.Add(r!TM01.ToString.Trim, 1)
      Else
        aryTL(r!TM01.ToString.Trim) += 1
      End If
      If r!TM09.ToString.Trim = "" Then Continue For
      Dim strV1() As String = MakeErrCode(r!TM09.ToString.Trim).Split(strERSPLIT)
      For Each strK As String In strV1

        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TD") '增加製令單號顯示by yang 180911 - Begin
        sqlCV.Where("TD01", "=", r!TN02.ToString.Trim)
        sqlCV.SqlFields("TD23")
        Dim rsTD As DataTable = DB.RsSQL(sqlCV.Text, "RSTD")
        Dim rsTDw As DataRow = rsTD.Rows(0)
        Dim strMF As String = rsTDw!TD23.ToString.Trim '增加製令單號顯示by yang 180911 - End

        'Dim strK1 As String = r!TN02.ToString.Trim & "||" & strK
        Dim strK1 As String = strMF & "||" & r!TN02.ToString.Trim & "||" & strK '增加製令單號顯示by yang 180911
        If aryC.ContainsKey(strK1) = False Then
          s1 = New ErrCode
          s1.intMode = intM
          s1.strID = strK
          s1.strName = GetErrCode(strK).Trim
          aryC.Add(strK1, s1)
        Else
          s1 = aryC(strK1)
        End If
        s1.Add(r)
      Next
    Next
    Dim aryL As New ArrayList
    Dim strL(aryC.Count - 1) As String
    aryC.Keys.CopyTo(strL, 0)
    aryL.AddRange(strL)
    aryL.Sort()
    Dim aryT As New ArrayList
    For Each s1 In aryC.Values
      For Each strR As String In s1.aryRng.Keys
        If aryT.Contains(strR) = False Then
          aryT.Add(strR)
        End If
      Next
    Next
    aryT.Sort()
    Dim rs As New DataTable
    rs.TableName = "ARYLIST"
    rs.Columns.Add(BIG2GB("製令單號"), GetType(String))
    rs.Columns.Add(BIG2GB("工單編號"), GetType(String))
    rs.Columns.Add(BIG2GB("不良代碼"), GetType(String))
    rs.Columns.Add(BIG2GB("名稱"), GetType(String))
    For Each strR As String In aryT
      rs.Columns.Add(strR, GetType(String))
    Next
    If intM <> 3 Then
      rs.Columns.Add(BIG2GB("合計"), GetType(String))
    End If
    For Each strK As String In aryL
      Dim strK1() As String = Split(strK, "||")
      Dim s2 As ErrCode = aryC(strK)
      Dim rw As DataRow = rs.NewRow
      'rw.Item(0) = strK1(0).Trim
      'rw.Item(1) = strK1(1).Trim
      'rw.Item(2) = s2.strName
      rw.Item(0) = strK1(0).Trim
      rw.Item(1) = strK1(1).Trim
      rw.Item(2) = strK1(2).Trim
      rw.Item(3) = s2.strName
      If intM <> 3 Then
        For Each s3 As ErrCount In s2.aryRng.Values
          rw.Item(s3.strRng) = s3.intCount.ToString("0") & BIG2GB("次") & s3.intPcs.ToString("0") & "Pcs"
        Next
      End If
      rw.Item(BIG2GB("合計")) = s2.intCount.ToString("0") & BIG2GB("次") & s2.intPcs.ToString("0") & "Pcs"
      rs.Rows.Add(rw)
    Next
    DG.Columns.Clear()
    DG.DataSource = rs
    For intI As Integer = 2 To DG.Columns.Count - 1
      DG.Columns(intI).SortMode = DataGridViewColumnSortMode.NotSortable
    Next
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    ComboBox2.SelectedValue = ""
    TextBox2.Text = ""
    TextBox5.Text = ""
    DTP1.Value = Now
    DTP2.Value = Now
    GroupBox1.Visible = True
  End Sub

  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    Me.Close()
  End Sub

  Private Sub ComboBox2_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBox2.SelectionChangeCommitted
    CheckBox1.Checked = False
    CheckBox2.Checked = True
    Button2_Click(Nothing, Nothing)
  End Sub

  Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    Dim strF As String = BIG2GB(GetTextFile("0502"))
    'Dim aryIDErrs As New ArrayList
    'For Each c As ErrCode In aryC.Values
    '  For Each strK As String In c.aryList
    '    If aryIDErrs.Contains(strK) = False Then
    '      aryIDErrs.Add(strK)
    '    End If
    '  Next
    'Next
    '不良數，全檢數
    intP = 0
    sngY = 1.5
    sngX = 1
    'MsgBox("Defect QTY" & aryIDErrs.Count & "," & "Total Insp" & aryTL.Count)
    'If PrtD1.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Return
    lbt.InitLBL(strF)
    lbt.PrinterName = System.Drawing.Printing.PrinterSettings.InstalledPrinters(0)
    lbt.SelectPrt = True
    'Dim sngDiv As Double = 39.37
    'lbt.PageWidth = PrtD1.PrinterSettings.DefaultPageSettings.PaperSize.Width / sngDiv
    'lbt.PageHeight = PrtD1.PrinterSettings.DefaultPageSettings.PaperSize.Height / sngDiv
    'lbt.PageOrint = PrtD1.PrinterSettings.DefaultPageSettings.Landscape
    Dim strMOK As String = ""
    Dim sqlCV As New APSQL.SQLCNV
    strLCase = ""
    sngLCase = 1.5
    For Each r As DataGridViewRow In DG.Rows
      If strMOK <> GCell(r.Cells(0)) Then
        If strMOK <> "" Then
          If sngLCase <> sngY Then
            Dim sngTY As Single = (sngY + sngLCase - 1) / 2
            lbt.ADD_PG("11", GetDesc(GetErrCode(strLCase)))
            lbt.PrtLBL(sngX, sngTY)
          End If
          sngLCase = 1.5
          strLCase = ""
          Tail(strMOK)
        End If
        strMOK = GCell(r.Cells(0))
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TD")
        sqlCV.Where("TD01", "=", strMOK)
        sqlCV.SqlFields("*")
        Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        If rs.Rows.Count = 0 Then
          strOrd = strMOK
          strQTY = ""
          strCust = ""
          strModel = ""
        Else
          strOrd = (rs.Rows(0)!TD05.ToString.Trim & "-" & rs.Rows(0)!TD06.ToString.Trim).Trim("-")
          If strOrd = "" Then strOrd = strMOK
          strQTY = Val(rs.Rows(0)!TD07.ToString).ToString("0")
          strModel = rs.Rows(0)!TD19.ToString.Trim
          If strModel = "" Then strModel = rs.Rows(0)!TD02.ToString.Trim
          strCust = rs.Rows(0)!TD28.ToString.Trim
          If strCust = "" Then strCust = rs.Rows(0)!TD27.ToString.Trim
        End If
        Heading()
      End If
      Body(r)
      If sngY > 19.3 Then
        Heading()
      End If
    Next
    If sngLCase <> sngY Then
      Dim sngTY As Single = (sngY + sngLCase - 1) / 2
      lbt.ADD_PG("11", GetDesc(GetErrCode(strLCase)))
      lbt.PrtLBL(sngX, sngTY)
    End If
    Tail(strMOK)
    lbt.SaveRep("D:\TEST.TXT")
    Dim lb2 As New clsLBPRT
    lb2.PrinterName = System.Drawing.Printing.PrinterSettings.InstalledPrinters(0)
    lb2.SelectPrt = True
    lb2.ReLoad("D:\TEST.TXT")
    lb2.PrtDialog()
  End Sub

#Region "Report"
  Private Sub Heading()
    If sngY > 1.5 Then
      If sngLCase <> 0 Then
        Dim sngTY As Single = (sngY + sngLCase - 1) / 2
        lbt.ADD_PG("11", GetDesc(GetErrCode(strLCase)))
        lbt.PrtLBL(sngX, sngTY)
        lbt.ADD_PG("21", "")
        lbt.PrtLBL(sngX, sngY)
        sngLCase = 1.5
      End If
      lbt.NewPage()
    End If
    sngX = 1
    sngY = 1.5
    lbt.ADD_PG("01", "")
    lbt.ADD_PG("04", strLines)
    lbt.ADD_PG("05", strCust)
    lbt.ADD_PG("06", strOrd)
    lbt.ADD_PG("07", strModel)
    lbt.ADD_PG("08", strQTY)
    lbt.ADD_PG("21", "")
    lbt.PrtLBL(sngX, sngY)
  End Sub
  Private Function GetDesc(strA As String) As String
    Dim strV1(2) As String
    Dim intI As Integer = strA.IndexOf(" ")
    If intI > 0 Then
      strV1(0) = strA.Substring(0, intI).Trim
      strA = strA.Substring(intI).Trim
    End If
    intI = strA.IndexOf("|")
    If intI > 0 Then
      strV1(1) = strA.Substring(0, intI).Trim("| ".ToCharArray)
      strV1(2) = strA.Substring(intI).Trim("| ".ToCharArray)
    Else
      strV1(1) = strA
      strV1(2) = ""
    End If
    If strV1(1) = "" Then
      strV1(1) = strV1(2)
      strV1(2) = ""
    End If
    If strV1(2) = "" Then
      Return strV1(1)
    Else
      Return strV1(2) & vbCrLf & strV1(1)
    End If
  End Function
  Private Sub Body(r As DataGridViewRow)
    Dim strA As String = GCell(r.Cells(2))

    'CODE,CNAME,ENAME
    Dim strM As String = ""
    Dim bolP As Boolean = False
    Dim sngTY As Single = 0
    Dim strTY As String = ""
    For intX As Integer = 3 To DG.ColumnCount - 2
      If GCell(r.Cells(intX)) = "" Then Continue For
      strM &= DG.Columns(intX).HeaderText & "=" & GCell(r.Cells(intX)).Replace(BIG2GB("次"), "/") & " , "
    Next
    lbt.ADD_PG("12", GetDesc(strA))
    lbt.ADD_PG("13", strM.TrimEnd(" ,".ToCharArray))
    If strLCase <> GCell(r.Cells(1)).Substring(0, 2) Then
      If strLCase = "" Then
        lbt.ADD_PG("21", "")
      Else
        lbt.ADD_PG("21", "")
        sngTY = (sngY + sngLCase - 1) / 2
        strTY = strLCase
        bolP = True
      End If
      strLCase = GCell(r.Cells(1)).Substring(0, 2)
      sngLCase = sngY
    Else
      lbt.ADD_PG("22", "")
    End If
    lbt.ADD_PG("20", "")
    lbt.PrtLBL(sngX, sngY)
    If bolP = True Then
      lbt.ADD_PG("11", GetDesc(GetErrCode(strTY)))
      lbt.PrtLBL(sngX, sngTY)
    End If
    sngY += 1
  End Sub
  Private Sub Tail(strM As String)
    Dim aryIDErrs As New ArrayList
    For Each strK1 As String In aryC.Keys
      If strK1.StartsWith(strM) Then
        Dim c As ErrCode = aryC(strK1)
        For Each strK As String In c.aryList
          If aryIDErrs.Contains(strK) = False Then
            aryIDErrs.Add(strK)
          End If
        Next
      End If
    Next
    Dim intTot As Integer = 0
    If aryMO.ContainsKey(strM) = True Then intTot = aryMO(strM).Count
    Dim intErr As Integer = aryIDErrs.Count
    Dim sngRat As Double = 0
    If intTot <= 0.001 Then
      sngRat = 0
    Else
      sngRat = Math.Round(intErr / intTot, 4)
    End If
    lbt.ADD_PG("23", "")
    lbt.ADD_PG("33", "  " & intTot & "Pcs")
    lbt.ADD_PG("20", "")
    lbt.ADD_PG("21", "")
    lbt.PrtLBL(sngX, sngY)
    sngY += 1
    lbt.ADD_PG("24", "")
    lbt.ADD_PG("34", "  " & intErr & "Pcs")
    lbt.ADD_PG("20", "")
    lbt.ADD_PG("21", "")
    lbt.PrtLBL(sngX, sngY)
    sngY += 1
    lbt.ADD_PG("25", "")
    lbt.ADD_PG("35", "  " & intTot - intErr & "Pcs")
    lbt.ADD_PG("20", "")
    lbt.ADD_PG("21", "")
    lbt.PrtLBL(sngX, sngY)
    sngY += 1
    lbt.ADD_PG("26", "")
    lbt.ADD_PG("36", "  " & (sngRat * 100).ToString("0.00") & "%")
    lbt.ADD_PG("20", "")
    lbt.ADD_PG("21", "")
    lbt.PrtLBL(sngX, sngY)
    sngY += 1
    lbt.ADD_PG("37", "")
    lbt.ADD_PG("21", "")
    lbt.PrtLBL(sngX, sngY)
  End Sub
#End Region
End Class