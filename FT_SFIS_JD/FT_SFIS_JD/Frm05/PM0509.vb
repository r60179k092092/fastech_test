Public Class Frm0509
    Private aryMO As New Dictionary(Of String, Defects)
    Private sngX As Double = 1.5
    Private sngY As Double = 1.5
    Private strOrd As String = ""
    Private strCust As String = ""
    Private strModel As String = ""
    Private strQTY As String = ""
    Private LBT As New clsLBPRT
    Private aryMFNO As New Dictionary(Of String, String)
    Private Class SubDefects
        Public strCode As String = ""
        Public aryScode As New Dictionary(Of String, Integer)
        Public aryDuty As New Dictionary(Of String, Integer)
        Public intCount As Integer = 0
        Public aryIDs As New ArrayList
        Sub New(strC As String)
            strCode = strC
        End Sub
        Public Function SubCode() As String
            Dim strM As String = ""
            For Each strK As String In aryScode.Keys
                strM &= strK & ","
            Next
            Return GetErrCode(strM, , False)
        End Function
        Public Function DutyCode() As String
            Dim strM As String = ""
            For Each strk As String In aryDuty.Keys
                strM &= strk & ","
            Next
            Return GetErrCode(strM, "TH", False)
        End Function
        Public Sub Add(strID As String, strScode As String, strDuty As String)
            If aryIDs.Contains(strID) = False Then
                aryIDs.Add(strID)
            End If
            intCount += 1
            Dim strV() As String = MakeErrCode(strScode).Split(strERSPLIT)
            For Each strK As String In strV
                If strK.Trim = "" Then Continue For
                If aryScode.ContainsKey(strK) = False Then
                    aryScode.Add(strK, 1)
                Else
                    aryScode(strK) += 1
                End If
            Next
            strV = MakeErrCode(strDuty).Split(strERSPLIT)
            For Each strK As String In strV
                If strK.Trim = "" Then Continue For
                If aryDuty.ContainsKey(strK) = False Then
                    aryDuty.Add(strK, 1)
                Else
                    aryDuty(strK) += 1
                End If
            Next
        End Sub
    End Class
    Private Class Defects
        Public strMO As String = ""
        Public strDtB As String = ""
        Public strDtE As String = ""
        Public aryIDs As New ArrayList
        Public aryErr As New Dictionary(Of String, SubDefects)
        Public aryRes As New Dictionary(Of String, SubDefects)
        Public Sub Add(r As DataRow)
            If strMO = "" Then
                strMO = r.Item(0).ToString.Trim
            End If
            Dim strI As String = r.Item(15).ToString.Trim
            If aryIDs.Contains(strI) = False Then
                aryIDs.Add(strI)
            End If
            If strDtB = "" Or strDtB > r.Item(1).ToString.Trim Then
                strDtB = r.Item(1).ToString.Trim
            End If
            If strDtE = "" Or strDtE < r.Item(1).ToString.Trim Then
                strDtE = r.Item(1).ToString.Trim
            End If
            Dim strEC As String = MakeErrCode(r.Item(6).ToString.Trim)
            Dim strRS As String = MakeErrCode(r.Item(5).ToString.Trim)
            Dim strDu As String = MakeErrCode(r.Item(7).ToString.Trim)
            Dim strV() As String = strEC.Split(",")
            For Each strK As String In strV
                If strK.Trim = "" Then Continue For
                If aryErr.ContainsKey(strK) = False Then
                    aryErr.Add(strK, New SubDefects(strK))
                End If
                aryErr(strK).Add(strI, strRS, strDu)
            Next
            strV = strRS.Split(",")
            For Each strK As String In strV
                If strK.Trim = "" Then Continue For
                If aryRes.ContainsKey(strK) = False Then
                    aryRes.Add(strK, New SubDefects(strK))
                End If
                aryRes(strK).Add(strI, strEC, strDu)
            Next
        End Sub
    End Class
    Sub New()

        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        languagechange(Me)

    End Sub

    Private Sub PM0509_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        TuiCK(Me)
    End Sub
    Private Sub PM0509_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        sqlCV.SqlFields("TD23")
        ComboBox2.DisplayMember = "DATAS"
        ComboBox2.ValueMember = "KEYS"
        Dim a As String = sqlCV.Text
        'ComboBox2.DataSource = DB.RsSQL(sqlCV.Text, "TDS") '增加製令單號顯示by yang 180911 - Begin
        Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "TDS")
        ComboBox2.DataSource = rs
        For Each r As DataRow In rs.Rows
            aryMFNO.Add(r!KEYS.ToString.Trim, r!TD23.ToString.Trim)  'key: 工單號 , value: 製令單
        Next                                                 '增加製令單號顯示by yang 180911 - End

        Button1_Click(Nothing, Nothing)
        dgdaochu(DG)
        dgdaochu(DG1)
        dgdaochu(DG2)
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        DTP2.Enabled = CheckBox1.Checked
        DTP1.Enabled = CheckBox1.Checked
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim intM As Integer = 1
        Dim strM As String = ""
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
            Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
            If rs.Rows.Count = 0 Then Return
            For Each r As DataRow In rs.Rows
                strM &= "'" & r!TD01.ToString.Trim & "',"
            Next
        End If
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TMA")
        If CheckBox1.Checked Then
            sqlCV.Where("^0.TMA10", ">=", DTP1.Value.ToString("yyyy\/MM\/dd") & " 00:00:00", APSQL.intFMode.msfld_datetime)
            sqlCV.Where("^0.TMA10", "<=", DTP2.Value.ToString("yyyy\/MM\/dd") & " 23:59:59", APSQL.intFMode.msfld_datetime)
        End If
        'sqlCV.Where("ISNULL(TM09,'')", "<>", "")
        sqlCV.SqlJoin(APSQL.SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TN", "TN01", "=", "^0.TMA01")
        sqlCV.SqlJoin(APSQL.SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TM", "USEQ", "=", "^0.TMA02")
        sqlCV.SqlJoin(APSQL.SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TD", "TD01", "=", "^1.TN02")
        If strM <> "" Then
            sqlCV.Where("^1.TN02", "IN", strM.Trim(","), APSQL.intFMode.msfld_field)
        End If
        sqlCV.SqlFields("^3.TD23", "製令單號") '增加製令單號顯示by yang 180911
        sqlCV.SqlFields("^1.TN02", "工單號", , , True)  '工單
        sqlCV.SqlFields("CONVERT(Varchar(10),^0.TMA10,111)", "維修日期", , , True)
        sqlCV.SqlFields("^3.TD02", "料號")
        sqlCV.SqlFields("ISNULL(^3.TD07,0)+ISNULL(^3.TD29,0)", "生產數量")
        sqlCV.SqlFields("^0.TMA03", "工序")  '工序
        sqlCV.SqlFields("^0.TMA04", "不良現象")
        sqlCV.SqlFields("^0.TMA05", "不良原因")
        sqlCV.SqlFields("^0.TMA06", "不良責任")
        sqlCV.SqlFields("^0.TMA11", "維修說明")
        sqlCV.SqlFields("^0.TMA07", "維修員")  '員工
        sqlCV.SqlFields("^0.TMA08", "維修站名")
        sqlCV.SqlFields("Convert(Varchar(1),^0.TMA12)", "結果")
        sqlCV.SqlFields("^2.TM09", "作業員判定")  '不良原因 
        sqlCV.SqlFields("^2.TM03", "作業員")
        sqlCV.SqlFields("^2.TM04", "工作站名")
        sqlCV.SqlFields("^0.TMA01", "PPID")
        Dim dt1 As DataTable = DB.RsSQL(BIG2GB(sqlCV.Text), "TMA")
        'Dim aryDuty As New ArrayList, arrErr As New ArrayList, arrRes As New ArrayList
        aryMO.Clear()
        For Each r As DataRow In dt1.Rows
            'If aryMO.ContainsKey(r.Item(0).ToString.Trim) = False Then
            '  aryMO.Add(r.Item(0).ToString.Trim, New Defects)
            'End If
            'aryMO(r.Item(0).ToString.Trim).Add(r)
            If aryMO.ContainsKey(r.Item(1).ToString.Trim) = False Then '增加製令單號顯示by yang 180911 - Begin
                aryMO.Add(r.Item(1).ToString.Trim, New Defects)
            End If
            aryMO(r.Item(1).ToString.Trim).Add(r)  '增加製令單號顯示by yang 180911 - End

            'Dim strV() As String = MakeErrCode(r.Item(5).ToString.Trim).Split(",")
            'For Each strK As String In strV
            '  If strK.Trim = "" Then Continue For
            '  If arrRes.Contains(strK) = False Then
            '    arrRes.Add(strK)
            '  End If
            'Next
            'strV = MakeErrCode(r.Item(6).ToString.Trim).Split(",")
            'For Each strK As String In strV
            '  If strK.Trim = "" Then Continue For
            '  If arrErr.Contains(strK) = False Then
            '    arrErr.Add(strK)
            '  End If
            'Next
            'strV = MakeErrCode(r.Item(7).ToString.Trim).Split(",")
            'For Each strK As String In strV
            '  If strK.Trim = "" Then Continue For
            '  If aryDuty.Contains(strK) = False Then
            '    aryDuty.Add(strK)
            '  End If
            'Next

            'r.Item(5) = GetErrCode(r.Item(5).ToString.Trim, , False)
            'r.Item(6) = GetErrCode(r.Item(6).ToString.Trim, "TG", False)
            'r.Item(7) = GetErrCode(r.Item(7).ToString.Trim, "TH", False)
            'r.Item(4) = getgx(r.Item(4).ToString.Trim).Split("|")(0)
            'r.Item(9) = GetUser(r.Item(9).ToString.Trim)
            'r.Item(12) = GetErrCode(r.Item(12).ToString.Trim, , False)
            'r.Item(13) = GetUser(r.Item(13).ToString.Trim)
            'Select Case r.Item(11).ToString.Trim
            '  Case "1"
            '    r.Item(11) = BIG2GB("換人再修")
            '  Case "8"
            '    r.Item(11) = BIG2GB("報廢")
            '  Case "0"
            '    r.Item(11) = BIG2GB("完修")
            '  Case Else
            '    r.Item(11) = BIG2GB("待修")
            'End Select
            r.Item(6) = GetErrCode(r.Item(6).ToString.Trim, , False) '增加製令單號顯示by yang 180911 - Begin
            r.Item(7) = GetErrCode(r.Item(7).ToString.Trim, "TG", False)
            r.Item(8) = GetErrCode(r.Item(8).ToString.Trim, "TH", False)
            r.Item(5) = getgx(r.Item(5).ToString.Trim).Split("|")(0)
            r.Item(10) = GetUser(r.Item(10).ToString.Trim)
            r.Item(13) = GetErrCode(r.Item(13).ToString.Trim, , False)
            r.Item(14) = GetUser(r.Item(14).ToString.Trim)
            Select Case r.Item(12).ToString.Trim
                Case "1"
                    r.Item(12) = BIG2GB("換人再修")
                Case "8"
                    r.Item(12) = BIG2GB("報廢")
                Case "0"
                    r.Item(12) = BIG2GB("完修")
                Case Else
                    r.Item(12) = BIG2GB("待修")
            End Select            '增加製令單號顯示by yang 180911 - End
        Next
        DG.DataSource = dt1
        TabControl1.SelectedIndex = 0
        'aryDuty.Sort()
        'arrErr.Sort()
        'arrRes.Sort()
        Dim rs1 As New DataTable
        rs1.TableName = "ErrCode"
        rs1.Columns.Add(BIG2GB("製令單號"), GetType(String)) '增加製令單號顯示by yang 180911
        rs1.Columns.Add(BIG2GB("工單號"), GetType(String))
        rs1.Columns.Add(BIG2GB("不良原因"), GetType(String))
        rs1.Columns.Add(BIG2GB("次數"), GetType(Integer))
        rs1.Columns.Add(BIG2GB("不良現象"), GetType(String))
        rs1.Columns.Add(BIG2GB("責任歸屬"), GetType(String))
        Dim rs2 As New DataTable
        rs2.TableName = "ResonCode"
        rs2.Columns.Add(BIG2GB("製令單號"), GetType(String)) '增加製令單號顯示by yang 180911
        rs2.Columns.Add(BIG2GB("工單號"), GetType(String))
        rs2.Columns.Add(BIG2GB("不良現象"), GetType(String))
        rs2.Columns.Add(BIG2GB("次數"), GetType(Integer))
        rs2.Columns.Add(BIG2GB("不良原因"), GetType(String))
        rs2.Columns.Add(BIG2GB("責任歸屬"), GetType(String))
        For Each strK As String In aryMO.Keys
            For Each s As SubDefects In aryMO(strK).aryRes.Values
                'rs2.Rows.Add(strK, GetErrCode(s.strCode, "TF", False), s.intCount, s.SubCode, s.DutyCode)
                rs2.Rows.Add(aryMFNO(strK), strK, GetErrCode(s.strCode, "TF", False), s.intCount, s.SubCode, s.DutyCode) '增加製令單號顯示by yang 180911
            Next
            For Each s As SubDefects In aryMO(strK).aryErr.Values
                'rs1.Rows.Add(strK, GetErrCode(s.strCode, "TG", False), s.intCount, s.SubCode, s.DutyCode)
                rs1.Rows.Add(aryMFNO(strK), strK, GetErrCode(s.strCode, "TG", False), s.intCount, s.SubCode, s.DutyCode) '增加製令單號顯示by yang 180911
            Next
        Next
        DG1.DataSource = rs1
        DG2.DataSource = rs2
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
    Private Sub Heading()
        'If sngY > 1.5 Then
        '  LBT.ADD_PG("20", "")
        '  LBT.ADD_PG("09", "")
        '  LBT.PrtLBL(sngX, sngY)
        '  LBT.NewPage()
        'End If
        'sngX = 1
        'sngY = 1.5
        'LBT.NewSession()
        LBT.ADD_PG("01", "")
        LBT.ADD_PG("04", strModel)
        LBT.ADD_PG("05", strOrd)
        LBT.ADD_PG("06", strCust)
        LBT.PrtLBL()
        LBT.ADD_PG("02", "")
        LBT.ADD_PG("03", "")
        LBT.PrtLBL()
        'LBT.PrtLBL(sngX, sngY)
        'Dim sngTop As Single = 27 - LBT.GetBound().Bottom
        'Debug.Print("HEADING " & LBT.GetBound.ToString)
        'Dim s() As clsLBPRT.LBPCell = LBT.GetSession("05,06,04")
        'CType(s(0), clsLBPRT.PCell).Br = New SolidBrush(Color.Red)
        'CType(s(0),clsLBPRT .PCell ).
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim strF As String = BIG2GB(GetTextFile("0509"))
        'sngY = 1.5
        'sngX = 1
        LBT.InitLBL(strF)
        LBT.EdgeTop = 1.5
        LBT.EdgeLeft = 1
        LBT.EdgeBottom = 1.5
        LBT.FootHeight = 1
        LBT.PrinterName = System.Drawing.Printing.PrinterSettings.InstalledPrinters(0)
        LBT.SelectPrt = True
        LBT.AutoPage = True
        Dim strMOK As String = ""
        'sngX = 1.5
        'sngY = 1
        Dim sqlCV As New APSQL.SQLCNV
        For Each s As Defects In aryMO.Values
            strMOK = s.strMO
            sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TD")
            sqlCV.Where("TD01", "=", strMOK)
            sqlCV.SqlFields("*")
            Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
            If rs.Rows.Count = 0 Then
                strOrd = strMOK
                strModel = ""
            Else
                strOrd = strMOK
                strModel = rs.Rows(0)!TD19.ToString.Trim
                If strModel = "" Then strModel = rs.Rows(0)!TD02.ToString.Trim
            End If
            strCust = s.strDtB & "-" & s.strDtE
            Heading()
            For Each s1 As SubDefects In s.aryErr.Values
                If LBT.IsFullPage Then
                    LBT.ADD_PG("20", "")
                    LBT.ADD_PG("09", "")
                    LBT.PrtLBL()
                    LBT.NewPage()
                    Heading()
                End If
                'If sngY > 16 Then
                '  Heading()
                'End If
                'LBT.NewSession()
                LBT.ADD_PG("20", "")
                LBT.PrtLBL()
                LBT.ADD_PG("11", GetErrCode(s1.strCode, , False))
                LBT.ADD_PG("12", s1.aryIDs.Count)
                LBT.ADD_PG("13", GetErrCode(s1.SubCode, , False))
                LBT.ADD_PG("14", GetErrCode(s1.DutyCode, , False))
                LBT.ADD_PG("10", "")
                LBT.PrtLBL()
                'LBT.PrtLBL(sngX, sngY)
                'Debug.Print("BODY " & LBT.GetBound.ToString)
                'sngY += 0.6
                'sngY += LBT.GetBound().Height
            Next
            LBT.ADD_PG("20", "")
            LBT.ADD_PG("09", "")
            LBT.PrtLBL()
        Next
        LBT.PrtDialog()
    End Sub
End Class