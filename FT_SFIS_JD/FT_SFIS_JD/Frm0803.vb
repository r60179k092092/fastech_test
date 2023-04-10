Public Class Frm0803
    Private WithEvents s1 As clsEDIT2012.clsEDITx2013
    Dim dt1 As DataTable = Nothing
    Dim dt2 As DataTable = Nothing
    Dim JT As String = ""
    Dim QTN01 As String = ""

    Sub New()
        ' 此為設計工具所需的呼叫。
        InitializeComponent()
        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        languagechange(Me)
    End Sub

    Private Sub datatable(strT1 As String, strT2 As String)
        dt1 = New DataTable()
        Dim strM() As String = Split(strT1, ",")
        For Each s As String In strM
            If s = "" Then Continue For
            dt1.Columns.Add(s, GetType(String))
        Next
        dt1.Rows.Add("30")
        dt1.Rows.Add("60")
        dt1.Rows.Add("90")
        dt1.Rows.Add("120")
        dt1.Rows.Add("160")
        dt1.Rows.Add("210")

        dt2 = New DataTable()
        Dim strA() As String = Split(strT2, ",")
        For Each s As String In strA
            If s = "" Then Continue For
            dt2.Columns.Add(s, GetType(String))
        Next
        dt2.Rows.Add("一色")
        dt2.Rows.Add("二色")
        dt2.Rows.Add("三色")
        dt2.Rows.Add("四色")
    End Sub

    'Private Function StrA(DG As DataGridView)
    '  Dim dt As DataTable = DG.DataSource
    '  Dim QTN(1) As String
    '  Dim a As String = ""
    '  For i As Integer = 0 To dt.Rows.Count - 1
    '    Dim b As String = ""
    '    For ii As Integer = 0 To dt.Columns.Count - 1
    '      If i = 0 Then
    '        If ii <> dt.Columns.Count - 1 Then
    '          a += dt.Rows(i)(ii).ToString + ","
    '        Else
    '          a += dt.Rows(i)(ii).ToString
    '        End If
    '      Else
    '        If ii <> dt.Columns.Count - 1 Then
    '          b += dt.Rows(i)(ii).ToString + "^"
    '        Else
    '          b += dt.Rows(i)(ii).ToString
    '        End If
    '      End If
    '    Next
    '    If i = 0 Then
    '      QTN(0) += a
    '    Else
    '      If i <> dt.Rows.Count - 1 Then
    '        QTN(1) += b + ","
    '      Else
    '        QTN(1) += b
    '      End If
    '    End If
    '  Next
    '  Return QTN
    'End Function

    'Private Function strB(dtA As DataTable, dtB As DataTable)
    '  If (dtA.Rows.Count <> 0) Then
    '    Dim QTN03() As String = dtA.Rows(0)("QTN03").ToString().Split(",")
    '    Dim dr03 As DataRow = dtB.NewRow()
    '    For i As Integer = 0 To QTN03.Length - 1
    '      dr03(i) = QTN03(i).ToString()
    '    Next
    '    dtB.Rows.Add(dr03)

    '    Dim QTN04() As String = dtA.Rows(0)("QTN04").ToString().Split(",")
    '    For i As Integer = 0 To QTN04.Length - 1
    '      Dim dr04 As DataRow = dtB.NewRow()
    '      Dim QTN041() As String = QTN04(i).ToString().Split("^")
    '      For ii As Integer = 0 To QTN041.Length - 1
    '        dr04(ii) = QTN041(ii).ToString()
    '      Next
    '      dtB.Rows.Add(dr04)
    '    Next
    '  Else
    '    Dim dr As DataRow = dtB.NewRow()
    '    dtB.Rows.Add(dr)
    '  End If
    '  Return dtB
    'End Function

    Private Sub Frm0802_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        s1 = New clsEDIT2012.clsEDITx2013(DG1, DB, language)
        If My.Settings.strRange1 = "" Then
            PaperHeader.Text = "跳距,印刷,二度,打底色"
            HPaperHeader.Text = "颜色,普通墨,UV墨,压色"
        Else
            PaperHeader.Text = My.Settings.strRange1
            HPaperHeader.Text = My.Settings.strRange2
        End If
        s1.Clean()
    End Sub

    Private Sub Frm0802_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        TuiCK(Me)
    End Sub

    Private Sub s1_DVSelect(s As clsEDITx2013, r As DataGridViewRow) Handles s1.DVSelect
        If r IsNot Nothing Then showData(GCell(r.Cells(0)))
    End Sub

    Private Sub showData(strV As String)
        If PaperHeader.Text = "" Then
            MsgBox(BIG2GB("印刷效率未定標題分類"))
            Return
        ElseIf HPaperHeader.Text = "" Then
            MsgBox(BIG2GB("调机时间未定標題分類"))
            Return
        End If
        datatable(PaperHeader.Text.Trim, HPaperHeader.Text.Trim)
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QTN")
        sqlCV.Where("QTN01", "=", "@PRINTING")
        sqlCV.Where("QTN02", "=", strV)
        sqlCV.SqlFields("QTN04")
        Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        If dt.Rows.Count = 0 Then
            s1_Frm_Clear(s1)
            MACH.Text = strV
            MACH.Enabled = True
            showMachine(strV)
            DG2.DataSource = dt1
            DG3.DataSource = dt2
            Return
        End If
        'Dim strJ As String = dt.Rows(0)!QTN04.ToString.Trim
        Dim js As New JSON(dt.Rows(0)!QTN04.ToString.Trim)
        PaperHeader.Text = js.ItemNull("PRINTINGHeader")
        DG2.DataSource = dt1
        initDG(DG2, js, "EFRATEROW")
        showMachine(strV)
        MACH.Text = strV
        MACH.Enabled = False

        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QTN")
        sqlCV.Where("QTN01", "=", "@AMTIME")
        sqlCV.Where("QTN02", "=", strV)
        sqlCV.SqlFields("QTN04")
        dt = DB.RsSQL(sqlCV.Text, "RTH")
        Dim js1 As New JSON(dt.Rows(0)!QTN04.ToString.Trim)
        If dt.Rows.Count = 0 Then
            DG3.DataSource = dt2
            Return
        End If
        HPaperHeader.Text = js1.ItemNull("AMTIMEHeader")
        DG3.DataSource = dt2
        initDG(DG3, js1, "EFRATEHROW")
    End Sub
    Private Sub initDG(DG As DataGridView, js As JSON, strV As String)
        Dim strM As String = js.ItemNull(strV)
        If strM = "" Then Return
        Dim strR() As String = strM.Split(vbCr)
        Dim intI As Integer = 0
        For Each strK As String In strR
            If strK = "" Then Exit For
            Dim strF() As String = strK.Split(vbTab)
            If strF(0) = "" Then Exit For
            If intI >= strR.Length Then Exit For
            Dim r As DataGridViewRow = DG.Rows(intI)
            For intJ As Integer = 0 To strF.GetUpperBound(0)
                If intJ >= r.Cells.Count Then
                    Exit For
                Else
                    r.Cells(intJ).Value = strF(intJ)
                End If
            Next
            intI += 1
        Next
    End Sub
    Private Sub showMachine(strV As String)
        Dim sqlCV As New APSQL.SQLCNV
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TJ")
        sqlCV.Where("TJ01", "=", strV)
        sqlCV.SqlFields("TJ02")
        Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        If rs.Rows.Count = 0 Then
            MACHNAME.Text = ""
        Else
            MACHNAME.Text = rs.Rows(0)!TJ02.ToString.Trim
        End If
    End Sub

    Private Sub s1_DVTable(s As clsEDITx2013, ByRef strSQL As String) Handles s1.DVTable
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QTN")
        sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TJ", "TJ01", "=", "^0.QTN02")
        sqlCV.Where("QTN01", "=", "@PRINTING")
        sqlCV.SqlFields("QTN02", "机台编号")
        sqlCV.SqlFields("TJ02", "机台名称")
        sqlCV.SqlFields("QTN03", "设置时间")
        strSQL = sqlCV.Text()
    End Sub

    Private Sub s1_Frm_CheckDup(s As clsEDITx2013, ByRef strSQL As String) Handles s1.Frm_CheckDup
        Dim sqlCV As New APSQL.SQLCNV
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QTN")
        sqlCV.Where("QTN01", "=", "@PRINTING")
        sqlCV.Where("QTN02", "=", MACH.Text)
        sqlCV.SqlFields("QTN04")
        strSQL = sqlCV.Text()
    End Sub

    Private Sub s1_Frm_Clear(s As clsEDITx2013) Handles s1.Frm_Clear
        MACH.Text = ""
        MACHNAME.Text = ""
        DG2.Columns.Clear()
        DG3.Columns.Clear()
        MACH.Enabled = True
    End Sub

    Private Sub s1_Frm_Delete(s As clsEDITx2013, ByRef strSQL As String, ByRef bolOK As Boolean) Handles s1.Frm_Delete
        Dim sqlCV As New APSQL.SQLCNV
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_delete, "SFIS_QTN")
        sqlCV.Where("QTN01", "=", "@PRINTING")
        sqlCV.Where("QTN02", "=", MACH.Text.Trim)
        strSQL = sqlCV.Text
        bolOK = True
    End Sub

    Private Sub s1_Frm_UpdateM(s As clsEDITx2013, ByRef strSQL As String) Handles s1.Frm_UpdateM, s1.Frm_InsertM
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_update, "SFIS_QTN")
        sqlCV.Where("QTN01", "=", "@PRINTING")
        sqlCV.Where("QTN02", "=", MACH.Text.Trim)
        sqlCV.SqlFields("QTN03", Now.ToString("yyyy/MM/dd"))
        Dim js As New JSON("")
        Dim strV As String = ""
        js.Add("PRINTINGHeader", PaperHeader.Text.Trim)
        For Each r As DataGridViewRow In DG2.Rows
            For Each c As DataGridViewCell In r.Cells
                strV &= c.Value & vbTab
            Next
            strV &= vbCr
        Next
        js.Add("EFRATEROW", strV)
        sqlCV.SqlFields("QTN04", js.ToString)
        Dim intI As Integer = DB.RsSQL(sqlCV.Text)
        If intI = 0 Then
            sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "SFIS_QTN")
            sqlCV.SqlFields("QTN01", "@PRINTING")
            sqlCV.SqlFields("QTN02", MACH.Text.Trim)
            sqlCV.SqlFields("QTN03", Now.ToString("yyyy/MM/dd"))
            sqlCV.SqlFields("QTN04", js.ToString)
            DB.RsSQL(sqlCV.Text)
        End If

        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_update, "SFIS_QTN")
        sqlCV.Where("QTN01", "=", "@AMTIME")
        sqlCV.Where("QTN02", "=", MACH.Text.Trim)
        sqlCV.SqlFields("QTN03", Now.ToString("yyyy/MM/dd"))
        js = New JSON("")
        strV = ""
        js.Add("AMTIMEHeader", HPaperHeader.Text.Trim)
        strV = ""
        For Each r As DataGridViewRow In DG3.Rows
            For Each c As DataGridViewCell In r.Cells
                strV &= c.Value & vbTab
            Next
            strV &= vbCr
        Next
        js.Add("EFRATEHROW", strV)
        sqlCV.SqlFields("QTN04", js.ToString)
        intI = DB.RsSQL(sqlCV.Text)
        If intI = 0 Then
            sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "SFIS_QTN")
            sqlCV.SqlFields("QTN01", "@AMTIME")
            sqlCV.SqlFields("QTN02", MACH.Text.Trim)
            sqlCV.SqlFields("QTN03", Now.ToString("yyyy/MM/dd"))
            sqlCV.SqlFields("QTN04", js.ToString)
            DB.RsSQL(sqlCV.Text)
        End If
        s1.Updated = True
        s1.Clean()
    End Sub

    Private Sub s1_isDataValid(s As clsEDITx2013, ByRef bolOK As Boolean) Handles s1.isDataValid
        If MACH.Text = "" Then
            MsgBox(BIG2GB("機台號不可空白"))
            Return
        End If
        bolOK = True
    End Sub

    Private Sub MACH_LostFocus(sender As Object, e As EventArgs) Handles MACH.LostFocus
        If MACH.Text = "" Then Return
        showData(MACH.Text.Trim)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm As New FrmMACH
        If frm.ShowDialog() = DialogResult.OK Then
            MACH.Text = frm.MachNo
            MACH_LostFocus(Nothing, Nothing)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        EsClass.AMTIME("0001", "UV墨", "二色")
    End Sub
End Class