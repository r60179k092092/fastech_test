
Public Class Frm0804
    Private dt1 As DataTable = Nothing
    Private WithEvents cs As clsEDIT2012.clsEDITx2013
    Sub New()
        ' 此為設計工具所需的呼叫。
        InitializeComponent()
        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        languagechange(Me)
    End Sub
    Private Sub datatable(strT1 As String)
        dt1 = New DataTable()
        Dim strM() As String = Split(strT1, ",")
        For Each s As String In strM
            If s = "" Then Continue For
            dt1.Columns.Add(s, GetType(String))
        Next
        dt1.Rows.Add("40")
        dt1.Rows.Add("70")
        dt1.Rows.Add("110")
        dt1.Rows.Add("140")
        dt1.Rows.Add("160")
        dt1.Rows.Add("180")
        dt1.Rows.Add("200")
        dt1.Rows.Add("999")
    End Sub
    Private Sub Frm0804_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cs = New clsEDIT2012.clsEDITx2013(DG, DB, language)
        cs.Clean()
        Me.WindowState = FormWindowState.Maximized
        AUNTHeader.Text = "模數,5,10,16,20,21"
    End Sub

    Private Sub cs_DVSelect(s As clsEDITx2013, r As DataGridViewRow) Handles cs.DVSelect
        If r IsNot Nothing Then showData(GCell(r.Cells(0)))
    End Sub

    Private Sub showData(strBh As String)
        MACH.Text = strBh
        showMachine(strBh)
        If AUNTHeader.Text = "" Then
            MsgBox(BIG2GB("模数未定标题分类"))
            Return
        End If
        datatable(AUNTHeader.Text.Trim)
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
        sqlCV.Where("QTN01", "=", "@EFTUNE")
        sqlCV.Where("QTN02", "=", strBh)
        sqlCV.SqlFields("QTN04")
        Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "Aune")
        If dt.Rows.Count = 0 Then
            showMachine(strBh)
            MACH.Enabled = True
            DG1.DataSource = dt1
            Return
        End If
        Dim strQtn04 As String = dt.Rows(0)!QTN04.ToString
        Dim js As New JSON(strQtn04)
        AUNTHeader.Text = js.ItemNull("EFTUNEHeader")
        DG1.DataSource = dt1
        initDG(DG1, js, "EFTUNEROW")
        MACH.Enabled = False
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
    Private Sub cs_DVTable(s As clsEDITx2013, ByRef strSQL As String) Handles cs.DVTable
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QTN")
        sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TJ", "TJ01", "=", "^0.QTN02")
        sqlCV.Where("QTN01", "=", "@EFTUNE")
        sqlCV.SqlFields("QTN02", "机台编号")
        sqlCV.SqlFields("TJ02", "机台名称")
        sqlCV.SqlFields("QTN03", "设置时间")
        strSQL = sqlCV.Text()
    End Sub

    Private Sub cs_Frm_CheckDup(s As clsEDITx2013, ByRef strSQL As String) Handles cs.Frm_CheckDup
        Dim sqlCV As New APSQL.SQLCNV
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QTN")
        sqlCV.Where("QTN01", "=", "@EFTUNE")
        sqlCV.Where("QTN02", "=", MACH.Text)
        sqlCV.SqlFields("QTN04")
        strSQL = sqlCV.Text()
    End Sub

    Private Sub cs_Frm_Clear(s As clsEDITx2013) Handles cs.Frm_Clear
        MACH.Text = ""
        DG1.DataSource = Nothing
        MACHNAME.Text = ""
    End Sub

    Private Sub cs_Frm_Delete(s As clsEDITx2013, ByRef strSQL As String, ByRef bolOK As Boolean) Handles cs.Frm_Delete
        If MsgBox(BIG2GB("是否刪除机台:" & MACH.Text & " 的相关咨迅？请确定"), MsgBoxStyle.YesNo) = MsgBoxResult.No Then Return
        Dim sqlCV As New APSQL.SQLCNV
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_delete, "SFIS_QTN")
        sqlCV.Where("QTN01", "=", "@EFTUNE")
        sqlCV.Where("QTN02", "=", MACH.Text.Trim)
        strSQL = sqlCV.Text
        bolOK = True
    End Sub

    'Private Sub cs_Frm_InsertM(s As clsEDITx2013, ByRef strSQL As String) Handles cs.Frm_InsertM
    '    MsgBox("t")
    'End Sub

    Private Sub cs_Frm_Update_Errror(s As clsEDITx2013, strMsg As String, strSql As String) Handles cs.Frm_Update_Errror

    End Sub

    Private Sub cs_Frm_UpdateM(s As clsEDITx2013, ByRef strSQL As String) Handles cs.Frm_UpdateM, cs.Frm_InsertM
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_update, "SFIS_QTN")
        sqlCV.Where("QTN01", "=", "@EFTUNE")
        sqlCV.Where("QTN02", "=", MACH.Text.Trim)
        sqlCV.SqlFields("QTN03", Now.ToString("yyyy/MM/dd"))
        Dim js As New JSON("")
        Dim strV As String = ""
        js.Add("EFTUNEHeader", AUNTHeader.Text.Trim)
        For Each r As DataGridViewRow In DG1.Rows
            For Each c As DataGridViewCell In r.Cells
                strV &= c.Value & vbTab
            Next
            strV &= vbCr
        Next
        js.Add("EFTUNEROW", strV)
        sqlCV.SqlFields("QTN04", js.ToString)
        Dim intI As Integer = DB.RsSQL(sqlCV.Text)
        If intI = 0 Then
            sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "SFIS_QTN")
            sqlCV.SqlFields("QTN01", "@EFTUNE")
            sqlCV.SqlFields("QTN02", MACH.Text.Trim)
            sqlCV.SqlFields("QTN03", Now.ToString("yyyy/MM/dd"))
            sqlCV.SqlFields("QTN04", js.ToString)
            DB.RsSQL(sqlCV.Text)
        End If
        cs.Updated = True
        cs.Clean()
    End Sub

    Private Sub cs_isDataValid(s As clsEDITx2013, ByRef bolOK As Boolean) Handles cs.isDataValid
        If MACH.Text = "" Then
            MsgBox(BIG2GB("机台号不可空白"))
            Return
        End If
        bolOK = True
    End Sub

    Private Sub Frm0804_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        TuiCK(Me) '关闭选项卡
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm As New FrmMACH
        If frm.ShowDialog() = DialogResult.OK Then
            MACH.Text = frm.MachNo
            MACH_LostFocus(Nothing, Nothing)
        End If
    End Sub
    Private Sub MACH_LostFocus(sender As Object, e As EventArgs) Handles MACH.LostFocus
        If MACH.Text = "" Then Return
        showData(MACH.Text.Trim)
    End Sub
End Class