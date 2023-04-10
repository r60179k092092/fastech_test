Imports System.Data
Imports System.IO
Imports APSQL
Imports System.Data.SqlClient
Public Class PM0401
    Private SNP As New clsSNGEN
    Private PPIDP As New clsSNGEN
    Private strGP As String = ""
    Private strWF As String = ""
    Private strSWF As String = ""
    Private bolChg As Boolean = False
    Private bolMOChg As Boolean = False
    Private bolSMT_SN As Boolean = False
    Private snoMO As SerialID = Nothing
    Private snoSE As SerialID = Nothing
    Private strSE01 As String = ""
    Private bolSaveInv As Boolean = False
    Private bolMOCloseChg As Boolean = False
    Private DG As DataGridView = Nothing
#If SAP <> 0 Then
  Private SapL As New SAPFunc.SapFunc(New SAPFunc.SAPLink)
#End If
    Private WithEvents s1 As clsEDIT2012.clsEDITx2013
    Sub New()

        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        languagechange(Me)

    End Sub
    Private Sub FrmGongXu_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If bolMOCloseChg Then My.Settings.Save()
        TuiCK(Me)
    End Sub
    Private Sub FrmGongDan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = vbCr Then
            'If Me.ActiveControl.Text <> "" Then
            e.Handled = True
            My.Computer.Keyboard.SendKeys(vbTab)
            'Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
            'End If
            'Else
            '  If Me.ActiveControl Is Txtworkppid11 Or Me.ActiveControl Is Txtworkppid21 Then
            '    If e.KeyChar.ToString Like "[0-9.]" Or e.KeyChar = Chr(8) Then
            '    Else
            '      e.KeyChar = Chr(0)
            '    End If
            '  End If
        End If
    End Sub
    Private Sub FrmJiTai2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        s1 = New clsEDIT2012.clsEDITx2013(DGV, DB, language)
        s1.Clean()
        With DGV
            AddHandler .CellFormatting, AddressOf dgfrmat
            AddHandler .Sorted, AddressOf Dgsort
            AddHandler .DataSourceChanged, AddressOf Dgsort1
        End With
#If EP = 1 Then
        PPIDB.Enabled = False
        PPIPE.Enabled = False
        BTNPPID.Visible = True
#End If
#If K3 = 2 Then
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "CMSMQ")
    sqlCV.Where("MQ003", "Like", "5%")
    sqlCV.SqlFields("MQ001", , , , True)
    sqlCV.SqlFields("RTRIM(MQ001) + '-' + RTRIM(MQ002)", "DATAS")
    sqlCV.SqlFields("MQ002")
    SaveLog(sqlCV.Text)
    Dim rs As DataTable = DBERP.RsSQL(sqlCV.Text, "RMQ")
    SaveLog("Completed .." & rs.Rows.Count)
    TA001.DisplayMember = "DATAS"
    TA001.ValueMember = "MQ001"
    TA001.DataSource = rs
    If rs.Rows.Count > 0 Then
      TA001.SelectedValue = rs.Rows(0)!MQ001.ToString
    End If
#ElseIf K3 = 3 Then
    TA001.Items.Clear()
    TA001.Visible = False
#End If
        dgdaochu(DG1)
        Cmbworkstate.SelectedIndex = 0
        s1.GetToolsItem("DELETE").Enabled = clsRTS.GetRight(Me.Tag & "/003")
        s1.GetToolsItem("SAVE").Enabled = clsRTS.GetRight(Me.Tag & "/001")
        Button2.Enabled = clsRTS.GetRight(Me.Tag & "/004")  '產品號碼
        Button1.Enabled = clsRTS.GetRight(Me.Tag & "/004")  '工單號碼打印
        'sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
        'sqlCV.Where("QTN01", "=", "#SAP_PARA")
        'sqlCV.SqlFields("QTN02", , , , True)
        'sqlCV.SqlFields("QTN03")
        'dt = DB.RsSQL(sqlCV.Text, "RTSAP")
        'dt.Rows.Add("Con", "")
        'ComboBox1.ValueMember = "QTN02"
        'ComboBox1.DisplayMember = "QTN02"
        'ComboBox1.DataSource = dt
        'ComboBox1.SelectedValue = My.Settings.SAPName
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
        sqlCV.Where("QTN01", "=", "MOTICKET")
        sqlCV.SqlFields("QTN02")
        sqlCV.SqlFields("QTN04")
        Dim rs1 As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        For Each r As DataRow In rs1.Rows
            Select Case r!QTN02.ToString.Trim.ToUpper
                Case "MO"
                    snoMO = New SerialID
                    snoMO.ConcatID(r!QTN04.ToString.Trim.ToUpper)
                Case "ISU"
                    snoSE = New SerialID
                    snoSE.ConcatID(r!QTN04.ToString.Trim.ToUpper)
                    strSE01 = r!QTN04.ToString.Trim.ToUpper.Split(",")(0)
            End Select
        Next
        CheckBox1.Checked = My.Settings.MOClosed
        TextBox1.Text = My.Settings.MOCDATE.ToString
        bolMOCloseChg = False
        Dgsort1(DGV, Nothing)
        Timer1.Enabled = True
    End Sub
#If GF <> 1 Then
  Private Sub SetMOComb()
    If txtMF_NO.Text.Trim = "" Then
      cbMO.Items.Clear()
      Return
    End If
    Dim intMax As Integer = 0
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TD")
    sqlCV.Where("TD23", "=", txtMF_NO.Text)
    sqlCV.SqlFields("TD01", , , , True)
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "TD")
    cbMO.Items.Clear()
    If rs.Rows.Count > 0 Then
      For Each s As DataRow In rs.Rows
        cbMO.Items.Add(s!TD01.ToString.Trim)
      Next
    Else
      cbMO.Items.Add(txtMF_NO.Text.Trim & "-1")
    End If
    'If cbMO.Items.Count > 0 Then
    '  For Each s As String In cbMO.Items
    '    Dim strS() As String = Split(s, "-")
    '    If strS.Count > 1 And strS(0) = txtMF_NO.Text Then
    '      If Val(strS(1)) > intMax Then
    '        intMax = Val(strS(1))
    '      End If
    '    End If
    '  Next
    '  cbMO.Text = txtMF_NO.Text & "-" & intMax + 1
    'Else
    '  cbMO.Text = txtMF_NO.Text & "-" & intMax + 1
    'End If
    'Txtworkcode.Text = cbMO.Text
  End Sub
#End If
    Private Sub dgfrmat(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex = 7 Then
            Select Case e.Value
                Case 0
                    e.Value = BIG2GB("未開工")
                Case 1
                    e.Value = BIG2GB("生產中")
                Case 2
                    e.Value = BIG2GB("完工")
                    's1.GetDGV.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.RosyBrown
                    's1.GetDGV.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Yellow
                Case 3
                    e.Value = BIG2GB("暫停")
                Case 8
                    e.Value = BIG2GB("作廢")
            End Select
        End If
    End Sub

#Region "table"
    Private Sub s1_DVTable(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles s1.DVTable
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TD")
        sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "SFIS_TBB", "TBB03", "=", "SFIS_TD.TD02")
        sqlCV.Where("TD12", "IN", "0,1,2,3", intFMode.msfld_field)
        'sqlCV.Where("TD12", "=", "2", , 1, "OR")
        'sqlCV.Where("TD08", ">", Now.AddDays(-7).ToString("yyyy\/MM\/dd") & " 00:00:00", intFMode.msfld_datetime)
        sqlCV.SqlFields("TD01", "工單編號", , , True)
        sqlCV.SqlFields("TD02", "物料編號")
        sqlCV.SqlFields("TD28", "客戶名稱")
        sqlCV.SqlFields("TD34", "客戶料號")
        sqlCV.SqlFields("TD07", "工單數量")
        sqlCV.SqlFields("TD30", "樣品數量")
        sqlCV.SqlFields("^1.TBB05+' '+^1.TBB06", "品名規格")
        sqlCV.SqlFields("TD12", "工單狀態")
        'sqlCV.SqlFields("TD03+'-'+TD04", "專案代號")
        'sqlCV.SqlFields("TD05+'-'+TD06", "銷售訂單")
        sqlCV.SqlFields("Convert(Varchar(10),TD08,111)", "開工日期")
        sqlCV.SqlFields("Convert(Varchar(10),TD09,111)", "預計日期")
        sqlCV.SqlFields("TD27+' '+TD28", "客戶")
        sqlCV.SqlFields("TD26", "客戶訂單")
#If GF <> 1 Then
    sqlCV.SqlFields("TD23", "製令單號")
#End If
        strSQL = BIG2GB(sqlCV.Text)
    End Sub
#End Region
#Region "dvselect"
    'If bolMOChg = True Then
    '    sqlCV.Where("TD01", "=", Txtworkcode.Text)
    'Else
    '    sqlCV.Where("TD01", "=", GCell(r.Cells(0)))
    'End If
    Private Sub ShowLOTS(strK As String)
        BTNSN.Enabled = True
        BTNPPID.Enabled = True
        SNOB.Enabled = True
        SNO.Enabled = True
        SNOE.Enabled = True
        PPIPE.Enabled = True
        PPIDB.Enabled = True
        PPIDO.Enabled = True
        Dim sqlCV As New APSQL.SQLCNV
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TD")
        sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TBB", "TBB03", "=", "^0.TD02")
        sqlCV.Where("TD01", "=", strK)
        sqlCV.SqlFields("^0.*")
        sqlCV.SqlFields("^1.TBB05 + ' ' + ^1.TBB06", "V1")
        sqlCV.SqlFields("^1.TBB01")
        sqlCV.SqlFields("^1.TBB02")
        sqlCV.SqlFields("^1.TBB04")
        sqlCV.SqlFields("^1.TBB07")
        sqlCV.SqlFields("^1.TBB08")
        sqlCV.SqlFields("^1.SA14")
        Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        If rs.Rows.Count = 0 Then Return
        Dim r1 As DataRow = rs.Rows(0)
        Txtworkcode.Text = r1!TD01.ToString.Trim
        If r1!TD23.ToString.Trim <> txtMF_NO.Text.Trim Then
            txtMF_NO.Text = r1!TD23.ToString.Trim
            txtMF_NO_Validated(Nothing, Nothing)
        End If
        MOQTY.Text = Val(r1!TD07.ToString).ToString("0")
        Dim strM As String = r1!TD12.ToString.Trim
        For intI As Integer = 0 To Cmbworkstate.Items.Count - 1
            If Cmbworkstate.Items(intI).ToString.StartsWith(strM) = True Then
                Cmbworkstate.SelectedIndex = intI
                Exit For
            End If
        Next
        Datworkopen.Value = r1!TD08
        Datworkfinsh.Value = r1!TD09
        Txtproductcode.Text = r1!TD02.ToString.Trim
        SPEC.Text = r1!V1.ToString.Trim
        Labdw.Text = r1!TBB07.ToString.Trim
        strWF = r1!TBB01.ToString.Trim
        strSWF = r1!TBB02.ToString.Trim
        TD28.Text = r1!TD28.ToString.Trim
        TD14.Text = r1!TD14.ToString.Trim
        bolSaveInv = False
        Txtprojectcode.Text = (r1!TD03.ToString.Trim & "-" & r1!TD04.ToString.Trim).Trim("-")
        'txtSKU.Text = r1!TD19.ToString.Trim
        TD34.Text = r1!TD34.ToString.Trim
        Dim str24() As String = (r1!TD24.ToString.Trim & ",").Split(",")
        TD24A.Text = str24(0)
        TD24B.Text = str24(1)
        Txtsalecode.Text = (r1!TD05.ToString.Trim & "-" & r1!TD06.ToString.Trim).Trim("-")
        TxtCustomerOlder.Text = r1!TD26.ToString.Trim
        TxtCustomerID.Text = r1!TD27.ToString.Trim
        SmpQTY.Text = r1!TD30.ToString.Trim
        strGP = r1!TD25.ToString.Trim & "^^^^^^"
        Dim strV() As String = strGP.Split("^")
        SNOB.Text = strV(0).Trim
        SNO.Text = strV(1).Trim
        SNOE.Text = strV(2).Trim
        PPIDB.Text = strV(3).Trim
        PPIDO.Text = strV(4).Trim
        PPIPE.Text = strV(5).Trim
        Dim strTBB08 As String = r1!TBB08.ToString.Trim.ToUpper
        Panel6.Visible = False
        If strTBB08 = "1003" Or strTBB08 = "1004" Or strTBB08 = "1008" Or strTBB08 = "1009" Then
            strTBB08 = r1!SA14.ToString.Trim
            If strTBB08 <> "" Then
                Dim scl As New clsLabSpec
                scl.LSDecode(strTBB08)
                Panel6.Visible = True
                Panel6.BackgroundImage = scl.GetBmp
            End If
        End If
        SNP.SetConcat(SNOB.Text, SNO.Text, SNOE.Text)
        PPIDP.SetConcat(PPIDB.Text, PPIDO.Text, PPIPE.Text)
        If SNP.GetRange("TN02", Txtworkcode.Text.Trim) Is Nothing Then
            SNOB.Enabled = True
            SNO.Enabled = True
            SNOE.Enabled = True
            BTNSN.Enabled = True
        Else
            SNOB.Enabled = False
            SNO.Enabled = False
            SNOE.Enabled = False
            BTNSN.Enabled = False
        End If
        If PPIDP.GetRange("TN02", Txtworkcode.Text.Trim) Is Nothing Then
            PPIDB.Enabled = True
            PPIDO.Enabled = True
            PPIPE.Enabled = True
            BTNPPID.Enabled = True
        Else
            PPIDB.Enabled = False
            PPIDO.Enabled = False
            PPIPE.Enabled = False
            BTNPPID.Enabled = False
        End If
        PCBA.Text = r1!TD31.ToString.Trim
        PCBABOT.Text = r1!TD37.ToString.Trim
        SINVC.Text = r1!TD36.ToString.Trim
        CSTENG.Text = r1!TD35.ToString.Trim
        DGBOM(True)
        Txtworkcode.Enabled = False
        'cbMO.Enabled = False
        'Btnproduct.Enabled = False
        'Txtproductcode.Enabled = False
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TDE")
        sqlCV.Where("TDE01", "=", strK)
        sqlCV.SqlFields("TDE02", "產品分號", , , True)
        sqlCV.SqlFields("TDE03", "產品名稱", , , True)
        sqlCV.SqlFields("TDE04", "產品型號")
        sqlCV.SqlFields("TDE06", "硬件版本")
        sqlCV.SqlFields("TDE07", "軟件版本")
        sqlCV.SqlFields("TDE08", "配置版本")
        sqlCV.SqlFields("TDE09", "客戶名稱")
        sqlCV.SqlFields("TDE10", "客戶料號")
        rs = DB.RsSQL(BIG2GB(sqlCV.Text), "TDE")
        If rs.Rows.Count = 0 Then
            rs.Rows.Add("", r1!TD38.ToString.Trim, r1!TD19.ToString.Trim, _
                        r1!TD39.ToString.Trim, r1!TD32.ToString.Trim, _
                        r1!TD33.ToString.Trim, r1!TD28.ToString.Trim, r1!TD34.ToString.Trim)
        End If
        FDG2.DataSource = rs
        FDG2.AppendBegin()
#If GF <> 1 Then
    GetMFData(txtMF_NO.Text.Trim)
#End If
        My.Application.DoEvents()
        bolChg = False
        TBC.SelectedIndex = 0
        txtQTY.Focus()
    End Sub
    Private Sub s1_DVSelect(ByVal s As clsEDIT2012.clsEDITx2013, ByVal r As System.Windows.Forms.DataGridViewRow) Handles s1.DVSelect
        Label47.Text = ""
        Label48.Text = ""
        Label49.Text = ""
        Label50.Text = ""
        Txtworkcode.Text = ""
        My.Settings.X401 = ""
        My.Settings.X401NUM = 0
        My.Settings.X402 = ""
        My.Settings.X402NUM = 0
        My.Settings.Save()
        ShowLOTS(GCell(r.Cells(0)))
    End Sub
#End Region
#Region "clear"
    Private Sub s1_Frm_Clear(ByVal s As clsEDIT2012.clsEDITx2013) Handles s1.Frm_Clear
        For Each ct In Panel1.Controls
            If TypeOf (ct) Is TextBox Then ct.text = ""
            If TypeOf (ct) Is Panel Then
                For Each c1 In ct.controls
                    If TypeOf (c1) Is TextBox Then c1.text = ""
                Next
            End If
        Next
        bolSaveInv = False
        strGP = "^^^^^"
        SPEC.Text = ""
        strWF = ""
        strSWF = ""
        Datworkfinsh.Value = Now.Date
        Datworkopen.Value = Now.Date
        MOQTY.Text = 1
        CSTENG.Text = ""
        TD24A.Text = "0"
        TD24B.Text = "0"
        'CBFmtLb.SelectedValue = ""
        Cmbworkstate.SelectedIndex = 0
        DG1.DataSource = Nothing
        dglc.DataSource = Nothing
        FDG2.DataSource = Nothing
        FDG2.Rows.Clear()
        FDG2.Columns.Clear()
        Txtworkcode.Enabled = True
        cbMO.Enabled = True
        Txtproductcode.Enabled = True
        Btnproduct.Enabled = True
        PCBA.Text = ""
        PCBABOT.Text = ""
        SNO.Text = ""
        SNOB.Text = ""
        SNOE.Text = ""
        PPIDO.Text = ""
        PPIDB.Text = ""
        PPIPE.Text = ""
        Label37.Text = ""
        Label39.Text = ""
        Label47.Text = ""
        Label48.Text = ""
        EXTRA.Text = ""
        CleartxtMF()
        My.Application.DoEvents()
        txtMF_NO.Focus()
        bolChg = False
    End Sub
    Private Sub CleartxtMF()
        txtMF_NO.Text = ""
        txtMRP_NO.Text = ""
        txtQTY.Text = ""
        cbMO.Text = ""
        MOQTY.Text = ""
        SmpQTY.Text = ""
        Txtproductcode.Text = ""
        TD28.Text = ""
        TD34.Text = ""
        txtSKU.Text = ""
        lbMFSPEC.Text = ""
        cbMO.Items.Clear()
        txtMF_NO.Enabled = True
    End Sub
#End Region

#Region "delete"
    Private Sub s1_Frm_Delete(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String, ByRef bolOK As Boolean) Handles s1.Frm_Delete
        bolChg = False
        Dim sqlCV As New APSQL.SQLCNV
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TD")
        sqlCV.Where("TD01", "=", Txtworkcode.Text.Trim)
        sqlCV.SqlFields("TD12")
        Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        If rs.Rows.Count = 0 Then Return
        If rs.Rows(0)!TD12.ToString.Trim = "0" Or rs.Rows(0)!TD12.ToString.Trim = "8" Then
            If MsgBox(BIG2GB("是否刪除該工單編號? 目前工單（") & Txtworkcode.Text.Trim & "）", MsgBoxStyle.OkCancel, BIG2GB("工單刪除提示")) <> MsgBoxResult.Ok Then Return
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_delete, "SFIS_TDA")
            sqlCV.Where("TDA01", "=", Txtworkcode.Text.Trim)
            DB.RsSQL(sqlCV.Text)
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_delete, "SFIS_TN")
            sqlCV.Where("TN02", "=", Txtworkcode.Text.Trim)
            DB.RsSQL(sqlCV.Text)
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_delete, "SFIS_TD")
            sqlCV.Where("TD01", "=", Txtworkcode.Text.Trim)
            DB.RsSQL(sqlCV.Text)
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_delete, "SFIS_TDE")
            sqlCV.Where("TDE01", "=", Txtworkcode.Text.Trim)
            strSQL = sqlCV.Text
            bolOK = True
        Else
            MsgBox(BIG2GB("工單已經開工無法刪除"))
            Return
        End If
        bolSaveInv = False
    End Sub
#End Region
#Region "s1_isDataValid"
    Private Sub s1_isDataValid(ByVal s As clsEDIT2012.clsEDITx2013, ByRef bolOK As Boolean) Handles s1.isDataValid
        If Txtworkcode.Text.Trim.Length = 0 Then
            MsgBox(BIG2GB("工單編號不能為空"), MsgBoxStyle.OkOnly, BIG2GB("提示"))
            Txtworkcode.Focus()
            Return
        End If
        If Txtproductcode.Text.Trim.Length = 0 Then
            MsgBox(BIG2GB("請選擇物料編號"), MsgBoxStyle.OkOnly, BIG2GB("提示"))
            Txtproductcode.Focus() : Return
        End If
        If Val(MOQTY.Text) < 1 Then
            MsgBox("工單生產數量不能為0", MsgBoxStyle.OkOnly, BIG2GB("提示"))
            MOQTY.Focus()
            Return
        End If
        If Cmbworkstate.Text = "" Then
            MsgBox(BIG2GB("請選擇工作狀態"), MsgBoxStyle.OkOnly, BIG2GB("提示"))
            Cmbworkstate.Focus()
            Return
        End If
        bolOK = True
    End Sub
#End Region

#Region "check"
    Private Sub s1_Frm_CheckDup(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles s1.Frm_CheckDup
        Dim sqlCV As New APSQL.SQLCNV
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TD")
        sqlCV.Where("TD01", "=", Txtworkcode.Text.Trim)
        sqlCV.SqlFields("TD01")
        strSQL = sqlCV.Text
    End Sub
#End Region
#Region "insert"
    Private Sub s1_Frm_InsertM(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles s1.Frm_InsertM
        bolChg = False
        '工單表
        'Txtworkcode.Text = cbMO.Text.Trim
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "SFIS_TD")
        sqlCV.SqlFields("TD01", Txtworkcode.Text.Trim)
        sqlCV.SqlFields("TD02", Txtproductcode.Text.Trim)
        Dim strV() As String = (Txtprojectcode.Text.Trim & "-").Split("-")
        sqlCV.SqlFields("TD03", strV(0).Trim)
        sqlCV.SqlFields("TD04", strV(1).Trim)
        strV = (Txtsalecode.Text.Trim & "-").Split("-")
        If strV.Length = 2 Then
            sqlCV.SqlFields("TD05", strV(0).Trim)
            sqlCV.SqlFields("TD06", strV(1).Trim)
        ElseIf strV.Length >= 3 Then
            sqlCV.SqlFields("TD05", strV(0).Trim & "-" & strV(1))
            sqlCV.SqlFields("TD06", strV(2).Trim)
        End If
        sqlCV.SqlFields("TD07", Val(MOQTY.Text), intFMode.msfld_num)
        sqlCV.SqlFields("TD08", Datworkopen.Value, APSQL.intFMode.msfld_date)
        sqlCV.SqlFields("TD09", Datworkfinsh.Value, intFMode.msfld_date) 'Format(DateTimePicker2.Value.Date, "yyyy-M-dd"), APSQL.intFMode.msfld_date)
        sqlCV.SqlFields("TD10", PPIDB.Text.Trim & PPIDO.Text.Trim & PPIPE.Text.Trim)
        sqlCV.SqlFields("TD11", "")
        If Cmbworkstate.SelectedIndex = 2 Then sqlCV.SqlFields("TD18", Format(Now.Date, "yyyy-M-dd"), APSQL.intFMode.msfld_date)
        sqlCV.SqlFields("TD12", Val(Cmbworkstate.Text.Trim.Substring(0, 1)))
        sqlCV.SqlFields("TD13", 0, intFMode.msfld_num)
        sqlCV.SqlFields("TD14", TD14.Text.Trim)
        sqlCV.SqlFields("TD16", SNOB.Text.Trim & SNO.Text.Trim & SNOE.Text.Trim)
        sqlCV.SqlFields("TD17", "")
        sqlCV.SqlFields("TD20", strWF)
        sqlCV.SqlFields("TD21", strSWF)
        sqlCV.SqlFields("TD23", txtMF_NO.Text.Trim)
        sqlCV.SqlFields("TD24", TD24A.Text.Trim & "," & TD24B.Text.Trim)
        sqlCV.SqlFields("TD25", SNOB.Text.Trim & "^" & SNO.Text.Trim & "^" & SNOE.Text.Trim & "^" & PPIDB.Text.Trim & "^" & PPIDO.Text.Trim & "^" & PPIPE.Text.Trim)
        sqlCV.SqlFields("TD26", TxtCustomerOlder.Text.Trim)
        sqlCV.SqlFields("TD27", TxtCustomerID.Text.Trim)
        sqlCV.SqlFields("TD28", TD28.Text.Trim)
        sqlCV.SqlFields("TD30", SmpQTY.Text, intFMode.msfld_num)
        sqlCV.SqlFields("TD31", PCBA.Text.Trim)
        sqlCV.SqlFields("TD34", TD34.Text.Trim)
        sqlCV.SqlFields("TD35", CSTENG.Text.Trim)
        sqlCV.SqlFields("TD36", SINVC.Text.Trim)
        sqlCV.SqlFields("TD37", PCBABOT.Text.Trim)
        'sqlCV.SqlFields("TD19", txtSKU.Text.Trim)
        If FDG2.Rows.Count >= 1 AndAlso GCell(FDG2.Rows(0).Cells(1)) <> "" Then
            sqlCV.SqlFields("TD38", GCell(FDG2.Rows(0).Cells(1)))
            sqlCV.SqlFields("TD39", GCell(FDG2.Rows(0).Cells(3)))
            sqlCV.SqlFields("TD32", GCell(FDG2.Rows(0).Cells(4)))
            sqlCV.SqlFields("TD33", GCell(FDG2.Rows(0).Cells(5)))
            sqlCV.SqlFields("TD28", GCell(FDG2.Rows(0).Cells(6)))
            sqlCV.SqlFields("TD34", GCell(FDG2.Rows(0).Cells(7)))
        End If
        If Label49.Text <> "" Then
            sqlCV.SqlFields("TD41", Label49.Text)
        End If
        DB.RsSQL(sqlCV.Text)
        If Label50.Text <> "" Then
            Dim strA() As String = Label50.Text.Split(";")
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "WMSAA")
            sqlCV.SqlFields("SAA01", Txtproductcode.Text)
            sqlCV.SqlFields("SAA02", strA(0))
            sqlCV.SqlFields("SAA09", strA(1))
            sqlCV.SqlFields("SAA10", strA(2))
            sqlCV.SqlFields("SAA08", strA(3))
            sqlCV.SqlFields("SAA07", strA(4))
            sqlCV.SqlFields("SAA11", strA(5))
            DB.RsSQL(sqlCV.Text)
        End If
        For Each r1 As DataGridViewRow In dglc.Rows
            '工單對應流程表
            sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "SFIS_TDA")
            sqlCV.SqlFields("TDA01", Txtworkcode.Text.Trim)
            sqlCV.SqlFields("TDA02", GCell(r1.Cells(0)))
            sqlCV.SqlFields("TDA03", GCell(r1.Cells(1)))
            sqlCV.SqlFields("TDA04", 0, intFMode.msfld_num)
            sqlCV.SqlFields("TDA05", 0, intFMode.msfld_num)
            sqlCV.SqlFields("TDA06", 0, intFMode.msfld_num)
            sqlCV.SqlFields("TDA07", 0, intFMode.msfld_num)
            sqlCV.SqlFields("TDA08", 0, intFMode.msfld_num)
            sqlCV.SqlFields("TDA09", 0, intFMode.msfld_num)
            sqlCV.SqlFields("TDA10", 0, intFMode.msfld_num)
            sqlCV.SqlFields("TDA11", 0, intFMode.msfld_num)
            sqlCV.SqlFields("TDA12", 0, intFMode.msfld_num)
            sqlCV.SqlFields("TDA13", 0, intFMode.msfld_num)
            sqlCV.SqlFields("TDA14", 0, intFMode.msfld_num)
            sqlCV.SqlFields("TDA15", 0, intFMode.msfld_num)
            DB.RsSQL(sqlCV.Text)
        Next
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_delete, "SFIS_TDE")
        sqlCV.Where("TDE01", "=", Txtworkcode.Text.Trim)
        DB.RsSQL(sqlCV.Text)
        For Each r As DataGridViewRow In FDG2.Rows
            If GCell(r.Cells(1)) = "" Then Continue For
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_TDE")
            sqlCV.SqlFields("TDE01", Txtworkcode.Text.Trim)
            sqlCV.SqlFields("TDE02", GCell(r.Cells(0)))
            sqlCV.SqlFields("TDE03", GCell(r.Cells(1)))
            sqlCV.SqlFields("TDE04", GCell(r.Cells(2)))
            sqlCV.SqlFields("TDE05", CSTENG.Text.Trim)
            sqlCV.SqlFields("TDE06", GCell(r.Cells(3)))
            sqlCV.SqlFields("TDE07", GCell(r.Cells(4)))
            sqlCV.SqlFields("TDE08", GCell(r.Cells(5)))
            sqlCV.SqlFields("TDE09", GCell(r.Cells(6)))
            sqlCV.SqlFields("TDE10", GCell(r.Cells(7)))
            DB.RsSQL(sqlCV.Text)
        Next
        If bolSaveInv Then
            Button9_Click_1(Nothing, Nothing)
            bolSaveInv = False
        End If
        ' ''然后初始化部分工單用料表 TDB     改到發料那里
        'Dim firstgx As String = ""
        'For Each row As DataGridViewRow In dglc.Rows
        '  If row.Cells("順序").Value = 0 Then
        '    firstgx = row.Cells("工序").Value
        '    Exit For
        '  End If
        'Next
        ''主ppid
        'If Txtworkppid12.Text.Length <> 0 Then
        '  FrmJinDu.ProgressBar1.Maximum = numworknum.Value
        '  FrmJinDu.ProgressBar1.Minimum = 0
        '  FrmJinDu.Text = "正在產生主條碼標識，請稍等......"
        '  FrmJinDu.TopMost = True
        '  FrmJinDu.Show()
        '  For i = 0 To numworknum.Value - 1
        '    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_TN")
        '    sqlCV.SqlFields("TN01", TxtworkPPID11A.Text.Trim & (Txtworkppid11.Text.Trim + i).ToString.PadLeft(Txtworkppid11.Text.Length, "0") & TxtworkPPID11c.Text)
        '    sqlCV.SqlFields("TN02", Txtworkcode.Text)
        '    sqlCV.SqlFields("TN03", firstgx)
        '    sqlCV.SqlFields("TN06", 0)
        '    DB.RsSQL(sqlCV.Text)
        '    FrmJinDu.ProgressBar1.Value = i
        '    FrmJinDu.ProgressBar1.Refresh()
        '  Next
        '  FrmJinDu.Close()
        'End If
        ''副ppid
        'If Txtworkppid22.Text.Length <> 0 Then
        '  FrmJinDu.ProgressBar1.Maximum = numworknum.Value
        '  FrmJinDu.ProgressBar1.Minimum = 0
        '  FrmJinDu.Text = "正在產生副條碼標識，請稍等......"
        '  FrmJinDu.TopMost = True
        '  FrmJinDu.Show()
        '  For i = 0 To numworknum.Value - 1
        '    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_TN")
        '    sqlCV.SqlFields("TN01", TxtworkPPID21A.Text.Trim & (Txtworkppid21.Text.Trim + i).ToString.PadLeft(Txtworkppid21.Text.Length, "0") & TxtworkPPID21c.Text)
        '    sqlCV.SqlFields("TN02", Txtworkcode.Text)
        '    sqlCV.SqlFields("TN06", 0)
        '    DB.RsSQL(sqlCV.Text)
        '    FrmJinDu.ProgressBar1.Value = i
        '    FrmJinDu.ProgressBar1.Refresh()
        '  Next
        '  FrmJinDu.Close()
        '  sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_TDC")
        '  sqlCV.SqlFields("tdc01", Txtworkcode.Text) ''工單
        '  sqlCV.SqlFields("tdc02", 0) ''標識類別1.主,0副
        '  sqlCV.SqlFields("tdc03", TxtworkPPID21A.Text) ''前綴
        '  sqlCV.SqlFields("tdc04", TxtworkPPID21c.Text) ''后綴
        '  sqlCV.SqlFields("tdc05", Txtworkppid21.Text) ''起始號碼
        '  sqlCV.SqlFields("tdc06", Val(Txtworkppid21.Text) + numworknum.Value - 1, intFMode.msfld_num) ''結束號碼
        '  sqlCV.SqlFields("tdc07", Txtworkppid21.TextLength) ''字符寬度
        '  sqlCV.SqlFields("tdc08", numworknum.Value, intFMode.msfld_num) ''數量
        '  sqlCV.SqlFields("tdc09", "Getdate()", intFMode.msfld_field) ''時間
        '  sqlCV.SqlFields("tdc10", lgnname) ''創建人
        '  DB.RsSQL(sqlCV.Text)
        'End If
        'DB.CommitTransaction()
        'Catch ex As Exception
        '  DB.AbortTransaction()
        '  MsgBox(ex.ToString, MsgBoxStyle.OkOnly, "==錯誤提示==")
        'End Try

        ' ''生產管制表建立工單的PPID清單
        ' ''主ppid
        ''If Txtworkppid12.Text.Length <> 0 Then
        ''    PPIDinstore(TxtworkPPID11A.Text.Trim, Txtworkppid11.Text.Trim, TxtworkPPID11c.Text.Trim, numworknum.Value, Txtworkcode.Text)
        ''End If
        ' ''副ppid
        ''If Txtworkppid22.Text.Length <> 0 Then
        ''    PPIDinstore(TxtworkPPID21A.Text.Trim, Txtworkppid21.Text.Trim, TxtworkPPID21c.Text.Trim, numworknum.Value, Txtworkcode.Text)
        ''End If

        'MsgBox("新增成功！", vbOKOnly, BIG2GB("提示"))
        s1_Frm_Clear(Nothing)
        s1.Updated = True
        '    BarCode_CS(TextBox1.Text.Trim, TextBox2.Text, TextBox4.Text)
    End Sub
#End Region
#Region " update"
    Private Sub s1_Frm_UpdateM(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles s1.Frm_UpdateM
        bolChg = False
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_update, "SFIS_TD")
        sqlCV.Where("TD01", "=", Txtworkcode.Text.Trim)
        sqlCV.SqlFields("TD02", Txtproductcode.Text.Trim)
        Dim strV() As String = (Txtprojectcode.Text.Trim & "-").Split("-")
        sqlCV.SqlFields("TD03", strV(0).Trim)
        sqlCV.SqlFields("TD04", strV(1).Trim)
        strV = (Txtsalecode.Text.Trim & "-").Split("-")
        If strV.Length = 2 Then
            sqlCV.SqlFields("TD05", strV(0).Trim)
            sqlCV.SqlFields("TD06", strV(1).Trim)
        ElseIf strV.Length >= 3 Then
            sqlCV.SqlFields("TD05", strV(0).Trim & "-" & strV(1))
            sqlCV.SqlFields("TD06", strV(2).Trim)
        End If
        sqlCV.SqlFields("TD07", Val(MOQTY.Text), intFMode.msfld_num)
        sqlCV.SqlFields("TD08", Datworkopen.Value, APSQL.intFMode.msfld_date)
        sqlCV.SqlFields("TD09", Datworkfinsh.Value, intFMode.msfld_date) 'Format(DateTimePicker2.Value.Date, "yyyy-M-dd"), APSQL.intFMode.msfld_date)
        sqlCV.SqlFields("Td10", PPIDB.Text.Trim & PPIDO.Text.Trim & PPIPE.Text.Trim)
        sqlCV.SqlFields("TD11", "")
        If Cmbworkstate.SelectedIndex = 2 Then sqlCV.SqlFields("TD18", Format(Now.Date, "yyyy-M-dd"), APSQL.intFMode.msfld_date)
        ''如為加工單,需更新已完成數量;或請副總在組裝時填寫
        sqlCV.SqlFields("TD12", Val(Cmbworkstate.Text.Trim.Substring(0, 1)))
        sqlCV.SqlFields("TD14", TD14.Text.Trim)
        sqlCV.SqlFields("TD16", SNOB.Text.Trim & SNO.Text.Trim & SNOE.Text.Trim)
        sqlCV.SqlFields("TD17", "")
        sqlCV.SqlFields("TD20", strWF)
        sqlCV.SqlFields("TD21", strSWF)
        sqlCV.SqlFields("TD23", txtMF_NO.Text.Trim)
        sqlCV.SqlFields("TD24", TD24A.Text.Trim & "," & TD24B.Text.Trim)
        sqlCV.SqlFields("TD25", SNOB.Text.Trim & "^" & SNO.Text.Trim & "^" & SNOE.Text.Trim & "^" & PPIDB.Text.Trim & "^" & PPIDO.Text.Trim & "^" & PPIPE.Text.Trim)
        sqlCV.SqlFields("TD26", TxtCustomerOlder.Text.Trim)
        sqlCV.SqlFields("TD27", TxtCustomerID.Text.Trim)
        sqlCV.SqlFields("TD28", TD28.Text.Trim)
        sqlCV.SqlFields("TD30", SmpQTY.Text, intFMode.msfld_num)
        sqlCV.SqlFields("TD31", PCBA.Text.Trim)
        sqlCV.SqlFields("TD34", TD34.Text.Trim)
        sqlCV.SqlFields("TD35", CSTENG.Text.Trim)
        sqlCV.SqlFields("TD36", SINVC.Text.Trim)
        sqlCV.SqlFields("TD37", PCBABOT.Text.Trim)
        'sqlCV.SqlFields("TD19", txtSKU.Text.Trim)
        If FDG2.Rows.Count >= 1 AndAlso GCell(FDG2.Rows(0).Cells(1)) <> "" Then
            sqlCV.SqlFields("TD38", GCell(FDG2.Rows(0).Cells(1)))
            sqlCV.SqlFields("TD39", GCell(FDG2.Rows(0).Cells(3)))
            sqlCV.SqlFields("TD32", GCell(FDG2.Rows(0).Cells(4)))
            sqlCV.SqlFields("TD33", GCell(FDG2.Rows(0).Cells(5)))
            sqlCV.SqlFields("TD28", GCell(FDG2.Rows(0).Cells(6)))
            sqlCV.SqlFields("TD34", GCell(FDG2.Rows(0).Cells(7)))
        End If
        If Label49.Text <> "" Then
            sqlCV.SqlFields("TD41", Label49.Text)
        End If
        strSQL = sqlCV.Text
        If Label50.Text <> "" Then
            Dim strA() As String = Label50.Text.Split(";")
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "WMSAA")
            sqlCV.Where("SAA01", "=", Txtproductcode.Text)
            sqlCV.Where("SAA02", "=", strA(0))
            sqlCV.SqlFields("SAA09", strA(1))
            sqlCV.SqlFields("SAA10", strA(2))
            sqlCV.SqlFields("SAA08", strA(3))
            sqlCV.SqlFields("SAA07", strA(4))
            sqlCV.SqlFields("SAA11", strA(5))
            DB.RsSQL(sqlCV.Text)
        End If
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TDA")
        sqlCV.Where("TDA01", "=", Txtworkcode.Text.Trim)
        sqlCV.SqlFields("*")
        Dim rs1 As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        Dim aryS As New Dictionary(Of String, DataRow)
        Dim bolT As Boolean = False
        For Each r As DataRow In rs1.Rows
            Dim strM As String = r!TDA03.ToString.Trim
            If Val(r!TDA05.ToString) <> 0 Then bolT = True
            If aryS.ContainsKey(strM) = False Then
                aryS.Add(strM, r)
            End If
        Next
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_delete, "SFIS_TDE")
        sqlCV.Where("TDE01", "=", Txtworkcode.Text.Trim)
        DB.RsSQL(sqlCV.Text)
        For Each r As DataGridViewRow In FDG2.Rows
            If GCell(r.Cells(1)) = "" Then Continue For
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_TDE")
            sqlCV.SqlFields("TDE01", Txtworkcode.Text.Trim)
            sqlCV.SqlFields("TDE02", GCell(r.Cells(0)))
            sqlCV.SqlFields("TDE03", GCell(r.Cells(1)))
            sqlCV.SqlFields("TDE04", GCell(r.Cells(2)))
            sqlCV.SqlFields("TDE05", CSTENG.Text.Trim)
            sqlCV.SqlFields("TDE06", GCell(r.Cells(3)))
            sqlCV.SqlFields("TDE07", GCell(r.Cells(4)))
            sqlCV.SqlFields("TDE08", GCell(r.Cells(5)))
            sqlCV.SqlFields("TDE09", GCell(r.Cells(6)))
            sqlCV.SqlFields("TDE10", GCell(r.Cells(7)))
            DB.RsSQL(sqlCV.Text)
        Next
        '只要開始生產就不能修改流程表
        If bolT = True Then
            Return
        End If
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_delete, "SFIS_TDA")
        sqlCV.Where("TDA01", "=", Txtworkcode.Text.Trim)
        DB.RsSQL(sqlCV.Text)
        For Each r1 As DataGridViewRow In dglc.Rows
            '工單對應流程表
            sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "SFIS_TDA")
            sqlCV.SqlFields("TDA01", Txtworkcode.Text.Trim)
            sqlCV.SqlFields("TDA02", GCell(r1.Cells(0)))
            sqlCV.SqlFields("TDA03", GCell(r1.Cells(1)))
            sqlCV.SqlFields("TDA04", 0, intFMode.msfld_num)
            sqlCV.SqlFields("TDA05", 0, intFMode.msfld_num)
            sqlCV.SqlFields("TDA06", 0, intFMode.msfld_num)
            sqlCV.SqlFields("TDA07", 0, intFMode.msfld_num)
            sqlCV.SqlFields("TDA08", 0, intFMode.msfld_num)
            sqlCV.SqlFields("TDA09", 0, intFMode.msfld_num)
            sqlCV.SqlFields("TDA10", 0, intFMode.msfld_num)
            sqlCV.SqlFields("TDA11", 0, intFMode.msfld_num)
            sqlCV.SqlFields("TDA12", 0, intFMode.msfld_num)
            sqlCV.SqlFields("TDA13", 0, intFMode.msfld_num)
            sqlCV.SqlFields("TDA14", 0, intFMode.msfld_num)
            sqlCV.SqlFields("TDA15", 0, intFMode.msfld_num)
            DB.RsSQL(sqlCV.Text)
        Next
        bolSaveInv = False
    End Sub
#End Region

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnproduct.Click
        Dim Frm As New FrmQrySA
        Frm.QRY = Txtproductcode.Text.Trim
        Frm.HasWF = True
        If Frm.ShowDialog = DialogResult.OK Then
            Dim strV() As String = Frm.Item
            If strV Is Nothing OrElse strV.Length = 0 Then Return
            Txtproductcode.Text = strV(0).Trim
            Txtproductcode_LostFocus(Nothing, Nothing)
        End If
    End Sub
#If GF <> 1 And k3 = 3 Then
  Private Sub GetMFData(strM As String)
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "MF_MO", , "TOP 200")
    If txtMF_NO.Text.Trim <> "" Then
      sqlCV.Where("^0.MO_NO", "Like", txtMF_NO.Text.Trim & "%")
    End If
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "PRDT", "PRD_NO", "=", "^0.MRP_NO")
    sqlCV.SqlFields("^0.MO_NO", "工單編號")
    sqlCV.SqlFields("^0.MRP_NO", "製品編號")
    sqlCV.SqlFields("^1.NAME", "品名")
    sqlCV.SqlFields("^1.SPC", "規格")
    sqlCV.SqlFields("^0.QTY", "數量")
    Dim rsE As DataTable = DBERP.RsSQL(BIG2GB(sqlCV.Text), "ERPRT")
    If rsE.Rows.Count > 0 Then
      Dim r2 As DataRow = rsE.Rows(0)
      txtMRP_NO.Text = r2!製品編號.ToString
      txtQTY.Text = Val(r2!數量).ToString("0.00")
      lbMFSPEC.Text = r2!品名.ToString & " " & r2!規格.ToString
    End If
    txtMF_NO.Enabled = False
  End Sub
#End If
    Private Sub GetQJData(strK As String)
        'sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QJB")
        'sqlCV.Where("QJB02", "=", strK)
        'sqlCV.SqlFields("QJB01")
        'sqlCV.SqlFields("QJB08")
        'Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RS")
        'If rs.Rows.Count = 0 Then Return
    End Sub
    '’調工單BOM    dvselect 調用
    Private Sub DGBOM(Optional bolM As Boolean = False)
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_distinc, "SFIS_TC")
        sqlCV.Where("TC01", "=", Txtproductcode.Text.Trim)
        sqlCV.Where("TC04", "=", 3, intFMode.msfld_num)
        sqlCV.Where("TC05", "=", "any")
        sqlCV.SqlFields("TC10", , , , True)
        Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        Dim strM As String = ""
        If rs.Rows.Count > 0 Then
            strM = rs.Rows(rs.Rows.Count - 1)!TC10.ToString.Trim
        End If
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TC")
        sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "SFIS_TBB", "TBB03", "=", "^0.TC02")
        If strM <> "" Then
            sqlCV.Where("( TC04", "<>", 3, intFMode.msfld_num)
            sqlCV.Where("TC04", "=", 3, intFMode.msfld_num, , "OR (")
            sqlCV.Where("TC10", "=", "'" & strM & "' ))", intFMode.msfld_field)
        End If
        sqlCV.Where("TC01", "=", Txtproductcode.Text)
        sqlCV.SqlFields("TC03", "工序", , , True)
        sqlCV.SqlFields("TC02", "原料編號", , , True)
        sqlCV.SqlFields("^1.TBB05+' '+^1.TBB06", "品名規格")
        sqlCV.SqlFields("TC06", "單位用量")
        sqlCV.SqlFields("^1.TBB07", "單位")
        sqlCV.SqlFields("TC04", "類型")
        sqlCV.SqlFields("TC05", "扣料模式")
        sqlCV.SqlFields("TC08", "替代料號")
        sqlCV.SqlFields("SA14")
        sqlCV.SqlFields("TBB06")
        sqlCV.SqlFields("TBB08")
        DG1.DataSource = DB.RsSQL(BIG2GB(sqlCV.Text), "BOM")
        For Each dm As DataGridViewColumn In DG1.Columns
            dm.SortMode = DataGridViewColumnSortMode.NotSortable
            If dm.HeaderText = "SA14" Or dm.HeaderText = "TBB06" Or dm.HeaderText = "TBB08" Then
                dm.Visible = False
            Else
                dm.Visible = True
            End If
        Next
        Dim sngT As Double = 0
        For Each rg As DataGridViewRow In DG1.Rows
            Select Case GCell(rg.Cells("TBB08"))
                Case "1010", "1011"
                    Dim ss As New clsDieSpec
                    ss.DieDecode(GCell(rg.Cells("SA14")))
                    Dim intJ As Integer = (Val(MOQTY.Text) + Val(SmpQTY.Text) + ss.GetPcs - 1) \ ss.GetPcs
                    Label39.Text = intJ
                    Label37.Text = (intJ * ss.JumpLength * 0.001).ToString("0.0")
                Case "1001"
                    Dim sngW As Double = Val(GCell(rg.Cells("TBB06")))
                    EXTRA.Tag = (sngW * 0.001).ToString("0.0000")
                    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "WMSE")
                    sqlCV.Where("^0.SE11", "=", Txtworkcode.Text.Trim)
                    Dim w As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "WMSEA", "SEA01", "=", "^0.SE01")
                    w.Add("WMSEA.SEA02", "=", "WMSE.SE02")
                    sqlCV.Where("^1.SEA04", "=", GCell(rg.Cells(1)))
                    sqlCV.SqlFields("SEA06")
                    Dim rsg As DataTable = DB.RsSQL(sqlCV.Text, "RT")
                    If rsg.Rows.Count > 0 Then
                        sngT = Val(rsg.Rows(0)!SEA06.ToString) / (sngW * 0.001)
                    End If
            End Select
        Next
        If sngT > Val(Label37.Text) Then
            EXTRA.Text = (sngT - Val(Label37.Text)).ToString("0.00").TrimEnd("0").TrimEnd(".")
        Else
            EXTRA.Text = ""
        End If
        Dim bolT As Boolean = False
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TDA")
        sqlCV.Where("TDA01", "=", Txtworkcode.Text.Trim)
        sqlCV.SqlFields("*")
        rs = DB.RsSQL(sqlCV.Text, "RT")
        For Each r As DataRow In rs.Rows
            If Val(r!TDA05.ToString) <> 0 Then bolT = True
        Next
        If bolT = True Or bolM = True Then
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TDA")
            sqlCV.Where("TDA01", "=", Txtworkcode.Text.Trim)
            Dim w As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TA", "TA01", "=", "^0.TDA03")
            w.Add("SFIS_TA.TA01", "<>", "'STS'")
            sqlCV.SqlFields("^0.TDA02", "序", , , True)
            sqlCV.SqlFields("^0.TDA03", "工序")
            sqlCV.SqlFields("^1.TA02", "說明")
            sqlCV.SqlFields("^0.TDA05", "生產數")
            dglc.DataSource = DB.RsSQL(BIG2GB(sqlCV.Text), "TBAS")
            If bolT = True Then
                Panel2.Enabled = False
            Else
                Panel2.Enabled = True
            End If
        Else
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TBA")
            sqlCV.Where("TBA01", "=", strWF)
            sqlCV.Where("TBA02", "=", strSWF)
            Dim w As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TA", "TA01", "=", "^0.TBA04")
            w.Add("SFIS_TA.TA04", "<>", "'STS'")
            sqlCV.SqlFields("TBA03", "序", , , True)
            sqlCV.SqlFields("TBA04", "工序")
            sqlCV.SqlFields("^1.TA02", "說明")
            sqlCV.SqlFields("(0)", "生產數")
            dglc.DataSource = DB.RsSQL(BIG2GB(sqlCV.Text), "TBAS")
            Panel2.Enabled = True
        End If
        For Each c As DataGridViewColumn In dglc.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        dglc.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
    End Sub
    ''行號顯示
    Private Sub dgblzr_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DG1.RowPostPaint
        Dim Rectangle As System.Drawing.Rectangle = New System.Drawing.Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, DG1.RowHeadersWidth - 4, e.RowBounds.Height)
        TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), DG1.RowHeadersDefaultCellStyle.Font, Rectangle, DG1.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter & TextFormatFlags.Right)
    End Sub
    ''轉換顯示
    Private Sub DG1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DG1.CellFormatting
        Select Case e.ColumnIndex
            Case 5
                Dim intI As Integer = Val(GCell(DG1.Rows(e.RowIndex).Cells(5)))
                Select Case intI
                    Case 0
                        e.Value = BIG2GB("主料")
                    Case 1
                        e.Value = BIG2GB("副料")
                    Case 2
                        e.Value = BIG2GB("不管控")
                    Case 3
                        e.Value = BIG2GB("SMT")
                End Select
            Case 6
                Dim strV As String = GCell(DG1.Rows(e.RowIndex).Cells(6))
                Select Case (strV & " ").Substring(0, 1)
                    Case "1"
                        e.Value = strV & BIG2GB(" 扣批號數量")
                    Case "2"
                        e.Value = strV & BIG2GB(" 批號不扣數量")
                    Case "4"
                        e.Value = strV & BIG2GB(" 單一序號")
                End Select
        End Select
    End Sub

    Private Sub txtMF_NO_DoubleClick(sender As Object, e As EventArgs) Handles txtMF_NO.DoubleClick
        Dim frm As New FrmERP_DLG
#If K3 = 1 Then
        frm.KeyValue = Txtworkcode.Text.Trim
#ElseIf K3 = 2 Then
        If TA001.SelectedValue Is Nothing OrElse TA001.SelectedValue.ToString.Trim = "" Then Return
        If Txtworkcode.Text.Trim.StartsWith(TA001.SelectedValue.ToString.Trim & "-") = True Then
          frm.KeyValue = Txtworkcode.Text.Trim
        Else
          frm.KeyValue = TA001.SelectedValue.ToString.Trim & "-" & Txtworkcode.Text.Trim
        End If
#ElseIf K3 = 3 Then
    frm.KeyValue = txtMF_NO.Text.Trim
#End If
        frm.Mode = 0
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtMF_NO.Text = GCell(frm.GetSelect.Cells(0))
            lbMFSPEC.Text = GCell(frm.GetSelect.Cells(2)) & " " & GCell(frm.GetSelect.Cells(3))
            cbMO.Focus()
            'txtMF_NO_Validated(Nothing, Nothing)
        End If
    End Sub
    '’製令單輸入
    Private Sub txtMF_NO_Validated(ByVal sender As Object, ByVal e As EventArgs) Handles txtMF_NO.Validated
        If txtMF_NO.Text.Trim = "" Then Return
        'For Each r As DataGridViewRow In s1.GetDGV.Rows
        '  If Txtworkcode.Text.Trim = r.Cells(0).Value.ToString Then
        '    s1_DVSelect(Nothing, r)
        '    s1.GetDGV.CurrentCell = r.Cells(0)
        '    Return
        '  End If
        'Next
#If SAP <> 0 Then
    Dim strID As String = Txtworkcode.Text.Trim
    If strID = "" Then Return
    strID = New String("0", 12 - strID.Length) & strID
    Dim rc As DataRowView = ComboBox1.SelectedItem
    If rc!QTN03.ToString.Trim <> "" Then
      Dim strSAP() As String = (CType(jiemi(rc!QTN03.ToString.Trim), String) & "######").Split("#")
      Dim sapS As New SAPFunc.SAPLink(strSAP(0), strSAP(1), strSAP(2), strSAP(3), strSAP(4), strSAP(5))
      If My.Settings.SAPName <> rc!QTN02.ToString.Trim Then
        My.Settings.SAPName = rc!QTN02.ToString.Trim
        My.Settings.Save()
      End If
      SapL.Add(My.Settings.SAPName, sapS)
      If SapL.isConnected(My.Settings.SAPName) = False Then
        MsgBox(BIG2GB("SAP無法連線"))
      End If
    End If

    If SapL.GetStru("ZPP_PRDORD_GET", "AUFNR=" & strID, "ITEMS", "AUFNR,GAMNG,GMEIN,PLNBEZ,GSTRP,GLTRP,RMANR,STATUS,FTRMS") = False Then
      MsgBox(BIG2GB(SapL.LastError))
      Return
    End If
    If SapL.Table Is Nothing OrElse SapL.Table.Rows.Count = 0 Then
      MsgBox(BIG2GB("沒有這個入庫單號"))
      Return
    End If
    Dim r1 As DataRow = SapL.Table.Rows(0)
    MOQTY.Text = r1!GAMNG.ToString.Trim
    Cmbworkstate.SelectedIndex = 0
    Txtproductcode.Text = r1!PLNBEZ.ToString.Trim
    If IsDate(r1!GSTRP.ToString) Then
      Datworkopen.Value = CDate(r1!GSTRP.ToString)
    Else
      Datworkopen.Value = Now.Date
    End If
    If IsDate(r1!GLTRP.ToString) Then
      Datworkfinsh.Value = CDate(r1!GLTRP.ToString)
    Else
      Datworkfinsh.Value = Now.AddDays(7).Date
    End If
    Txtsalecode.Text = r1!RMANR.ToString.Trim

#Else
#If K3 = 1 Then
        If DBERP IsNot Nothing AndAlso DBERP.Active = True Then
            Dim sqlCV As New APSQL.SQLCNV
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "ICMO")
            sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "t_ICItem", "FItemID", "=", "^0.FItemID")
            sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "SEOrder", "FInterID", "=", "^0.FOrderInterID")
            sqlCV.Where("^0.FBillNO", "=", Txtworkcode.Text.Trim)
            sqlCV.Where("^0.FStatus", "IN", "0,1", intFMode.msfld_field)
            sqlCV.SqlFields("^0.*")
            sqlCV.SqlFields("^1.FNumber")
            sqlCV.SqlFields("^2.FBillNO", "OrderNo")
            Dim rs As DataTable = DBERP.RsSQL(sqlCV.Text, "RT")
            If rs.Rows.Count = 0 Then
                MsgBox(BIG2GB("這個工單號不存在或是已經結案"))
                Return
            End If
            MOQTY.Text = rs.Rows(0)!FQTY.ToString.TrimEnd("0").TrimEnd(".")
            Cmbworkstate.SelectedIndex = Val(rs.Rows(0)!FStatus.ToString)
            Txtproductcode.Text = rs.Rows(0)!FNumber.ToString
            Txtworkremark.Text = rs.Rows(0)!FNote.ToString
            Datworkopen.Value = rs.Rows(0)!FPlanCommitDate
            Datworkfinsh.Value = rs.Rows(0)!FPlanFinishDate
            Txtsalecode.Text = rs.Rows(0)!OrderNo.ToString.Trim
            TD24A.Text = "0"
            TD24B.Text = "0"
            ' CBFmtLb.SelectedValue = ""
        End If
#ElseIf K3 = 2 Then
    If DBERP IsNot Nothing AndAlso DBERP.Active = True Then
      Dim sqlCV As New APSQL.SQLCNV
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "MOCTA")
      sqlCV.Where("^0.TA001", "=", TA001.SelectedValue.ToString.Trim)
      If Txtworkcode.Text.Trim.StartsWith(TA001.SelectedValue.ToString.Trim & "-") = True Then
        sqlCV.Where("^0.TA002", "=", Txtworkcode.Text.Trim.Substring(TA001.SelectedValue.ToString.Trim.Length + 1))
      Else
        sqlCV.Where("^0.TA002", "=", Txtworkcode.Text.Trim)
      End If
      sqlCV.SqlFields("^0.TA001")
      sqlCV.SqlFields("^0.TA002")
      sqlCV.SqlFields("^0.TA006")
      sqlCV.SqlFields("^0.TA009")
      sqlCV.SqlFields("^0.TA010")
      sqlCV.SqlFields("^0.TA011")
      sqlCV.SqlFields("^0.TA015")
      sqlCV.SqlFields("^0.TA026")
      sqlCV.SqlFields("^0.TA027")
      sqlCV.SqlFields("^0.TA028")
      sqlCV.SqlFields("^0.TA029")
      Dim rs As DataTable = DBERP.RsSQL(sqlCV.Text, "RT")
      If rs.Rows.Count = 0 Then
        MsgBox(BIG2GB("這個工單號不存在或是已經結案"))
        Return
      End If
      MOQTY.Text = rs.Rows(0)!TA015.ToString.Trim.TrimEnd("0").TrimEnd(".")
      Select Case rs.Rows(0)!TA011
        Case "1"
          Cmbworkstate.SelectedIndex = 0
        Case "3", "2"
          Cmbworkstate.SelectedIndex = 1
        Case "Y", "y"
          Cmbworkstate.SelectedIndex = 2
      End Select
      Txtproductcode.Text = rs.Rows(0)!TA006.ToString.Trim
      Txtworkremark.Text = rs.Rows(0)!TA029.ToString.Trim
      Datworkopen.Value = toDATE(rs.Rows(0)!TA009.ToString.Trim)
      Datworkfinsh.Value = toDATE(rs.Rows(0)!TA010.ToString.Trim)
      Txtsalecode.Text = (rs.Rows(0)!TA026.ToString.Trim & "-" & rs.Rows(0)!TA027.ToString.Trim & "-" & rs.Rows(0)!TA028.ToString.Trim).Trim("-")
      CBFmtLb.SelectedValue = ""
    End If
#ElseIf K3 = 3 And GF <> 1 Then
    If DBERP IsNot Nothing AndAlso DBERP.Active = True Then
      Dim sqlCV As New APSQL.SQLCNV
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "MF_MO")
      sqlCV.Where("^0.MO_NO", "=", txtMF_NO.Text.Trim)
      sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "PRDT", "PRD_NO", "=", "^0.MRP_NO")
      sqlCV.SqlFields("^0.MO_NO")
      sqlCV.SqlFields("^0.MRP_NO")
      sqlCV.SqlFields("^0.STA_DD")
      sqlCV.SqlFields("^0.END_DD")
      sqlCV.SqlFields("^0.QTY")
      sqlCV.SqlFields("^0.QTY1")
      sqlCV.SqlFields("^0.CLOSE_ID")
      sqlCV.SqlFields("^0.BIL_NO")
      sqlCV.SqlFields("^0.REM", "REMV")
      sqlCV.SqlFields("^1.NAME")
      sqlCV.SqlFields("^1.SPC")
      Dim rs As DataTable = DBERP.RsSQL(sqlCV.Text, "RT")
      If rs.Rows.Count = 0 Then
        MsgBox(BIG2GB("這個製令工單號不存在或是已經結案"))
        txtMF_NO.Text = ""
        txtMRP_NO.Text = ""
        txtQTY.Text = ""
        lbMFSPEC.Text = ""
        Return
      End If
      'Select Case rs.Rows(0)!CLOSE_ID.ToString.Trim
      '  Case "1"
      '    Cmbworkstate.SelectedIndex = 0
      '  Case "3", "2"
      '    Cmbworkstate.SelectedIndex = 1
      '  Case "T", "t"
      '    Cmbworkstate.SelectedIndex = 2
      'End Select
      txtMRP_NO.Text = rs.Rows(0)!MRP_NO.ToString.Trim
      txtQTY.Text = Val(rs.Rows(0)!QTY).ToString("0.00")
      txtMF_NO.Enabled = False
      'Txtproductcode.Text = txtMRP_NO.Text
      lbMFSPEC.Text = rs.Rows(0)!NAME.ToString.Trim & " " & rs.Rows(0)!SPC.ToString.Trim
      SetMOComb()
      Dim intI As Integer = cbMO.Items.IndexOf(Txtworkcode.Text.Trim)
      If intI < 0 Then
        cbMO.Focus()
      Else
        cbMO.SelectedIndex = intI
        cbMO_SelectionChangeCommitted(Nothing, Nothing)
      End If
      'AutoGetSPEC_BOM()
      'MOQTY.Focus()
    End If
    'Txtproductcode.Text = rs.Rows(0)!MRP_NO.ToString.Trim
    'Txtworkremark.Text = rs.Rows(0)!REMV.ToString.Trim
    'SmpQTY.Text = Val(rs.Rows(0)!QTY1.ToString).ToString("0.0000").TrimEnd("0").TrimEnd(".")
    'Datworkopen.Value = toDate(rs.Rows(0)!STA_DD.ToString.Trim)
    'Datworkfinsh.Value = toDate(rs.Rows(0)!END_DD.ToString.Trim)
    'Txtsalecode.Text = rs.Rows(0)!BIL_NO.ToString.Trim
    'CBFmtLb.SelectedValue = ""
#End If
#End If
    End Sub

    Private Sub cbMO_LostFocus(sender As Object, e As EventArgs) Handles cbMO.LostFocus
        If cbMO.Text.Trim = "" Then Return
        Txtworkcode.Text = cbMO.Text.Trim
        ShowLOTS(Txtworkcode.Text.Trim)
    End Sub

    'Private Sub cbMO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMO.SelectedIndexChanged
    '  Txtworkcode.Text = cbMO.SelectedItem.Trim
    '  ShowLOTS(Txtworkcode.Text.Trim)
    'End Sub

    Private Function toDate(strD As String) As String
        If strD.Length = 8 Then
            Return strD.Substring(0, 4) & "/" & strD.Substring(4, 2) & "/" & strD.Substring(6, 2)
        ElseIf strD.Length = 6 Then
            strD = "20" & strD
            Return strD.Substring(0, 4) & "/" & strD.Substring(4, 2) & "/" & strD.Substring(6, 2)
        Else
            Return Now.ToString("yyyy\/MM\/dd")
        End If
    End Function
    '’獲取工單狀態
    Function getgdstate() As String
        For Each r As DataGridViewRow In DGV.Rows
            If Txtworkcode.Text.Trim = GCell(r.Cells(0)) Then
                Return r.Cells(6).FormattedValue
            End If
        Next
        Return ""
    End Function

    ''判斷是否在外范圍內
    Private Function getIsExit(ByVal first As String, ByVal last As String) As Boolean
        Dim d As Int32 = DB.ExecuteScalar("select count(tn01) from sfis_tn where tn01 between '" & first & "' and '" & last & "'")
        If d > 0 Then Return True
        Return False
    End Function

    '’工單
    Private Sub Btnppidnfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Txtworkcode.Text.Length = 0 Then Return
        cs6pritF("#@IMAGES||03PATH^GD", 1, 1, Txtworkcode.Text)
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If dglc.Rows.Count = 0 Then
            MsgBox(BIG2GB("工單沒有任何工序"), MsgBoxStyle.OkOnly, BIG2GB("提示"))
            Return
        End If
        If Txtworkcode.Enabled = True Or bolChg = True Then
            MsgBox(BIG2GB("工單請先存檔再來產生序號"), MsgBoxStyle.OkOnly, BIG2GB("提示"))
            Return
        End If
        If SNOB.Text.Trim = "" And SNOE.Text.Trim = "" And SNO.Text.Trim = "" And _
          PPIDB.Text.Trim = "" And PPIPE.Text.Trim = "" And PPIDO.Text.Trim = "" Then
            MsgBox(BIG2GB("工單沒有序號可以產生或打印"), MsgBoxStyle.OkOnly, BIG2GB("提示"))
            Return
        End If
        Dim firstgx As String = GCell(dglc.Rows(0).Cells(1))
        Dim d As New PM0401ppid(Txtworkcode.Text, firstgx)
        d.ShowDialog()
    End Sub
#If EP = 1 Then
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles BTNPPID.Click
        Dim TK As String = ""
        bolChg = True
        Dim chrV() As Char = Txtworkcode.Text.Trim.ToCharArray
        For intI As Integer = chrV.GetUpperBound(0) To 0 Step -1
            If Char.IsNumber(chrV(intI)) Then
                TK = chrV(intI) & TK
            End If
            If TK.Length = 9 Then Exit For
        Next
        If TK.Length < 9 Then
            TK = New String("0", 9 - TK.Length) & TK
        End If
        TK &= Datworkopen.Value.ToString("yyyyMMdd").Substring(2)
        PPIDB.Text = TK
        PPIDO.Text = "00001"
    End Sub
#End If

    Private Sub cbMO_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbMO.SelectionChangeCommitted
        My.Computer.Keyboard.SendKeys(vbTab)
    End Sub

    Private Sub PPIDO_LostFocus(sender As Object, e As EventArgs) Handles PPIDO.LostFocus
        If PPIDO.Text.Trim = "" Then
            PPIDB.Text = ""
            PPIPE.Text = ""
        End If
    End Sub

    Private Sub SNO_LostFocus(sender As Object, e As EventArgs) Handles SNO.LostFocus
        If SNO.Text.Trim = "" Then
            SNOB.Text = ""
            SNOE.Text = ""
        End If
    End Sub

    Private Sub Txtproductcode_LostFocus(sender As Object, e As EventArgs) Handles Txtproductcode.LostFocus
        Dim sqlCV As New APSQL.SQLCNV
        If Txtproductcode.Text.Trim = "" Then Return
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TBB")
        sqlCV.Where("TBB03", "=", Txtproductcode.Text)
        sqlCV.SqlFields("TBB03")
        sqlCV.SqlFields("TBB04")
        sqlCV.SqlFields("TBB05")
        sqlCV.SqlFields("TBB06")
        sqlCV.SqlFields("TBB07")
        sqlCV.SqlFields("TBB01")
        sqlCV.SqlFields("TBB02")
        Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        If rs.Rows.Count = 0 Then Return
        SPEC.Text = rs.Rows(0)!TBB05.ToString.Trim & " " & rs.Rows(0)!TBB06.ToString.Trim
        Labdw.Text = rs.Rows(0)!TBB07.ToString.Trim
        strWF = rs.Rows(0)!TBB01.ToString.Trim
        strSWF = rs.Rows(0)!TBB02.ToString.Trim
        DGBOM()
    End Sub

    Private Sub MOQTY_LostFocus(sender As Object, e As EventArgs) Handles MOQTY.LostFocus, SmpQTY.LostFocus
        For Each rg As DataGridViewRow In DG1.Rows
            Select Case GCell(rg.Cells("TBB08"))
                Case "1010", "1011"
                    Dim ss As New clsDieSpec
                    ss.DieDecode(GCell(rg.Cells("SA14")))
                    Dim intJ As Integer = (Val(MOQTY.Text) + Val(SmpQTY.Text) + ss.GetPcs - 1) \ ss.GetPcs
                    Label39.Text = intJ
                    Label37.Text = (intJ * ss.JumpLength * 0.001).ToString("0.0")
                Case "1001"
                    Dim sngW As Double = Val(GCell(rg.Cells("TBB06")))
                    EXTRA.Tag = (sngW * 0.001).ToString("0.0000")
            End Select
        Next
    End Sub

    Private Sub Txtworkcode_TextChanged(sender As Object, e As EventArgs) Handles cbMO.TextChanged, _
      MOQTY.TextChanged, SmpQTY.TextChanged, Txtaddress.TextChanged, _
       Txtproductcode.TextChanged, _
       SNO.TextChanged, _
      SNOB.TextChanged, SNOE.TextChanged, PPIDO.TextChanged, _
      PPIDB.TextChanged, PPIPE.TextChanged, Txtworkremark.TextChanged, _
      PCBA.TextChanged, CSTENG.TextChanged, _
       PCBABOT.TextChanged
        bolChg = True
    End Sub

    Private Sub Datworkopen_ValueChanged(sender As Object, e As EventArgs) Handles Datworkopen.ValueChanged
        bolChg = True
    End Sub

    Private Sub TBC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TBC.SelectedIndexChanged
        If TBC.SelectedIndex = 1 Then
            Dim sqlCV As New SQLCNV
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
            sqlCV.Where("^0.TN02", "=", Txtworkcode.Text.Trim)
            sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Outer, "SFIS_TN", "S1.TN07", "=", "^0.TN01")
            sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Outer, "SFIS_TN", "S2.TN01", "=", "^0.TN07")
            sqlCV.SqlFields("^0.TN01", "PPID", , , True)
            sqlCV.SqlFields("^0.TN03", "工序")
            sqlCV.SqlFields("^0.TN04", "時間")
            sqlCV.SqlFields("^0.TN06", "狀態")
            sqlCV.SqlFields("^1.TN01", "上層PPID")
            sqlCV.SqlFields("^1.TN02", "上層工單")
            sqlCV.SqlFields("^1.TN03", "上層工序")
            sqlCV.SqlFields("^2.TN01", "下層PPID")
            sqlCV.SqlFields("^2.TN02", "下層工單")
            sqlCV.SqlFields("^2.TN03", "下層工序")
            sqlCV.SqlFields("^0.TN15", "合板")
            DG2.DataSource = DB.RsSQL(BIG2GB(sqlCV.Text), "RTNS")
            DGP.DataSource = Nothing
        ElseIf TBC.SelectedIndex = 2 Then
#If GF <> 1 Then
      s1.GetDGV.Columns(BIG2GB("製令單號")).DisplayIndex = 0
#End If
            DGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        End If
    End Sub

    Private Sub DG2_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DG2.CellFormatting
        If e.ColumnIndex = 3 Then
            Select Case GCell(DG2.Rows(e.RowIndex).Cells(e.ColumnIndex))
                Case "0"
                    e.Value = "OK"
                Case "1"
                    e.Value = BIG2GB("待修")
                Case "2"
                    e.Value = BIG2GB("返工")
                Case "3"
                    e.Value = BIG2GB("暫停")
                Case "4"
                    e.Value = BIG2GB("完工")
                Case "5"
                    e.Value = BIG2GB("出貨")
                Case "7"
                    e.Value = BIG2GB("綁定下層")
                Case "8"
                    e.Value = BIG2GB("報廢")
                Case "100"
                    e.Value = BIG2GB("底面")
            End Select
        End If
    End Sub

    Private Sub DG2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG2.CellContentClick
        If e.ColumnIndex < 0 Or e.ColumnIndex >= DG2.ColumnCount Or e.RowIndex < 0 Or e.RowIndex >= DG2.RowCount Then Return
        TV.Nodes.Clear()
        TV.Visible = False
        Dim sqlCV As New APSQL.SQLCNV
        Dim strKey As String = GCell(DG2.Rows(e.RowIndex).Cells(0))
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
        sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TD", "TD01", "=", "^0.TN02")
        sqlCV.Where("^0.TN01", "=", strKey)
        sqlCV.SqlFields("^0.TN01", "PPID", , , True)
        sqlCV.SqlFields("^0.TN02", "工單")
        sqlCV.SqlFields("^1.TD02", "料號")
        sqlCV.SqlFields("^0.TN03", "工序")
        sqlCV.SqlFields("^0.TN04", "時間")
        sqlCV.SqlFields("^0.TN06", "狀態")
        sqlCV.SqlFields("^0.TN07", "下層PPID")
        sqlCV.SqlFields("^0.TN12", "箱號")
        Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        If rs.Rows.Count = 0 Then Return
        Dim strKMO As String = rs.Rows(0).Item(1).ToString.Trim
        Dim rs1 As DataTable = rs.Clone
        rs1.Rows.Clear()
        rs1.Rows.Add(rs.Rows(0).ItemArray)
        '回溯到這個ID最上方
        While -1
            Dim strP As String = rs1.Rows(rs1.Rows.Count - 1).Item(6).ToString.Trim
            If strP = "" Then Exit While
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
            sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TD", "TD01", "=", "^0.TN02")
            sqlCV.Where("^0.TN01", "=", strP)
            sqlCV.SqlFields("^0.TN01", "PPID", , , True)
            sqlCV.SqlFields("^0.TN02", "工單")
            sqlCV.SqlFields("^1.TD02", "料號")
            sqlCV.SqlFields("^0.TN03", "工序")
            sqlCV.SqlFields("^0.TN04", "時間")
            sqlCV.SqlFields("^0.TN06", "狀態")
            sqlCV.SqlFields("^0.TN07", "下層PPID")
            sqlCV.SqlFields("^0.TN12", "箱號")
            rs = DB.RsSQL(sqlCV.Text, "RT")
            If rs.Rows.Count = 0 Then Exit While
            rs1.Rows.Clear()
            rs1.Rows.Add(rs.Rows(0).ItemArray)
        End While
        Dim strN As String = "'" & rs1.Rows(rs1.Rows.Count - 1).Item(0).ToString.Trim & "'"
        Dim aryNode As New Dictionary(Of String, TreeNode)
        Dim n As TreeNode = TV.Nodes.Add(rs1.Rows(rs1.Rows.Count - 1).Item(0).ToString.Trim, rs1.Rows(rs1.Rows.Count - 1).Item(0).ToString.Trim)
        aryNode.Add(n.Name, n)
        If n.Name = strKey Then n.ForeColor = Color.Red
        '抓回ID最底端
        While -1
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
            sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TD", "TD01", "=", "^0.TN02")
            sqlCV.Where("^0.TN07", "IN", strN.Trim(","), intFMode.msfld_field)
            sqlCV.SqlFields("^0.TN01", "PPID")
            sqlCV.SqlFields("^0.TN02", "工單")
            sqlCV.SqlFields("^1.TD02", "料號")
            sqlCV.SqlFields("^0.TN03", "工序")
            sqlCV.SqlFields("^0.TN04", "時間")
            sqlCV.SqlFields("^0.TN06", "狀態")
            sqlCV.SqlFields("^0.TN07", "下層PPID")
            sqlCV.SqlFields("^0.TN12", "箱號")
            sqlCV.sqlOrder("TN02", SQLCNV.intOrder.Order_Dsc)
            sqlCV.sqlOrder("TN01", SQLCNV.intOrder.Order_Dsc)
            rs = DB.RsSQL(sqlCV.Text, "RT")
            If rs.Rows.Count = 0 Then Exit While
            strN = ""
            For Each r2 As DataRow In rs.Rows
                Dim r As DataRow = rs1.NewRow
                For intI As Integer = 0 To rs.Columns.Count - 1
                    r.Item(intI) = r2.Item(intI)
                Next
                strN &= "'" & r.Item(0).ToString.Trim & "',"
                rs1.Rows.InsertAt(r, 0)
            Next
        End While
        DGP.DataSource = rs1
        While -1
            Dim bolNode As Boolean = False
            For Each r As DataRow In rs1.Rows
                Dim strK As String = r.Item(6).ToString.Trim
                Dim strN1 As String = r.Item(0).ToString.Trim
                If strK = "" Then Continue For
                If aryNode.ContainsKey(strK) = True Then
                    If aryNode.ContainsKey(strN1) = True Then Continue For
                    n = aryNode(strK).Nodes.Add(strN1, strN1)
                    If strN1 = strKey Then n.ForeColor = Color.Red
                    aryNode.Add(n.Name, n)
                    bolNode = True
                End If
            Next
            If bolNode = False Then Exit While
        End While
        For Each r1 As DataGridViewRow In DGP.Rows
            If GCell(r1.Cells(0)) = strKey Then
                r1.DefaultCellStyle.ForeColor = Color.Red
            End If
        Next
        If n IsNot Nothing And n.Level > 0 Then
            TV.Visible = True
            TV.ExpandAll()
        End If
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
        sqlCV.Where("TN02", "=", strKMO & "@")
        sqlCV.Where("TN01", "Like", strKey & "[0123456789]", , 1)
        sqlCV.Where("TN07", "Like", strKey & "[0123456789]", , , "OR")
        sqlCV.SqlFields("TN01", , , , True)
        sqlCV.SqlFields("TN07")
        sqlCV.SqlFields("TN06")
        rs1 = DB.RsSQL(sqlCV.Text, "RT")
        If rs1.Rows.Count = 0 Then Return
        TV.Visible = True
        Dim strMS As String = "", aryPP As New ArrayList
        For Each r As DataRow In rs1.Rows
            aryPP.Add(r!TN01.ToString.Trim)
            If r!TN07.ToString.Trim <> "" Then
                If aryPP.Contains(r!TN07.ToString.Trim) = True Then
                    aryPP.Add(r!TN07.ToString.Trim)
                End If
            End If
        Next
        For Each strKK As String In aryPP
            strMS &= "'" & strKK & "',"
        Next
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
        sqlCV.Where("TN01", "IN", strMS.Trim(","), intFMode.msfld_field)
        sqlCV.Where("TN02", "=", strKMO & "@")
        sqlCV.SqlFields("TN01", , , , True)
        sqlCV.SqlFields("TN07")
        rs1 = DB.RsSQL(sqlCV.Text, "RT")
        aryPP.Clear()
        For Each r As DataRow In rs1.Rows
            If aryPP.Contains(r!TN07.ToString.Trim) = False And r!TN07.ToString.Trim <> "" Then
                aryPP.Add(r!TN07.ToString.Trim)
            End If
        Next
        For Each r As DataRow In rs1.Rows
            If aryPP.Contains(r!TN01.ToString.Trim) = True Then
                TV.Nodes.Add(r!TN01.ToString.Trim, r!TN01.ToString.Trim)
            End If
        Next
        For Each r As DataRow In rs1.Rows
            If aryPP.Contains(r!TN01.ToString.Trim) = False Then
                If TV.Nodes.ContainsKey(r!TN07.ToString.Trim) = True Then
                    TV.Nodes.Item(r!TN07.ToString.Trim).Nodes.Add(r!TN01.ToString.Trim)
                End If
            End If
        Next
    End Sub

    'Private Sub DG2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG2.CellContentClick
    '  If e.ColumnIndex < 0 Or e.ColumnIndex >= DG2.ColumnCount Or e.RowIndex < 0 Or e.RowIndex >= DG2.RowCount Then Return
    '  Dim sqlCV As New APSQL.SQLCNV
    '  Dim strKey As String = GCell(DG2.Rows(e.RowIndex).Cells(0))
    '  sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
    '  sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TD", "TD01", "=", "^0.TN02")
    '  sqlCV.Where("^0.TN01", "=", strKey)
    '  sqlCV.SqlFields("^0.TN01", "PPID", , , True)
    '  sqlCV.SqlFields("^0.TN02", "工單")
    '  sqlCV.SqlFields("^1.TD02", "料號")
    '  sqlCV.SqlFields("^0.TN03", "工序")
    '  sqlCV.SqlFields("^0.TN04", "時間")
    '  sqlCV.SqlFields("^0.TN06", "狀態")
    '  sqlCV.SqlFields("^0.TN07", "下層PPID")
    '  sqlCV.SqlFields("^0.TN12", "箱號")
    '  Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    '  If rs.Rows.Count = 0 Then Return
    '  Dim rs1 As DataTable = rs.Clone
    '  rs1.Rows.Clear()
    '  rs1.Rows.Add(rs.Rows(0).ItemArray)
    '  While -1
    '    Dim strP As String = rs1.Rows(rs1.Rows.Count - 1).Item(6).ToString.Trim
    '    If strP = "" Then Exit While
    '    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
    '    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TD", "TD01", "=", "^0.TN02")
    '    sqlCV.Where("^0.TN01", "=", strP)
    '    sqlCV.SqlFields("^0.TN01", "PPID", , , True)
    '    sqlCV.SqlFields("^0.TN02", "工單")
    '    sqlCV.SqlFields("^1.TD02", "料號")
    '    sqlCV.SqlFields("^0.TN03", "工序")
    '    sqlCV.SqlFields("^0.TN04", "時間")
    '    sqlCV.SqlFields("^0.TN06", "狀態")
    '    sqlCV.SqlFields("^0.TN07", "下層PPID")
    '    sqlCV.SqlFields("^0.TN12", "箱號")
    '    rs = DB.RsSQL(sqlCV.Text, "RT")
    '    If rs.Rows.Count = 0 Then Exit While
    '    rs1.Rows.Add(rs.Rows(0).ItemArray)
    '  End While
    '  Dim strN As String = "'" & rs1.Rows(0).Item(0).ToString.Trim & "'"
    '  While -1
    '    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
    '    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TD", "TD01", "=", "^0.TN02")
    '    sqlCV.Where("^0.TN07", "IN", strN.Trim(","), intFMode.msfld_field)
    '    sqlCV.SqlFields("^0.TN01", "PPID")
    '    sqlCV.SqlFields("^0.TN02", "工單")
    '    sqlCV.SqlFields("^1.TD02", "料號")
    '    sqlCV.SqlFields("^0.TN03", "工序")
    '    sqlCV.SqlFields("^0.TN04", "時間")
    '    sqlCV.SqlFields("^0.TN06", "狀態")
    '    sqlCV.SqlFields("^0.TN07", "下層PPID")
    '    sqlCV.SqlFields("^0.TN12", "箱號")
    '    sqlCV.sqlOrder("TN02", SQLCNV.intOrder.Order_Dsc)
    '    sqlCV.sqlOrder("TN01", SQLCNV.intOrder.Order_Dsc)
    '    rs = DB.RsSQL(sqlCV.Text, "RT")
    '    If rs.Rows.Count = 0 Then Exit While
    '    strN = ""
    '    For Each r2 As DataRow In rs.Rows
    '      Dim r As DataRow = rs1.NewRow
    '      For intI As Integer = 0 To rs.Columns.Count - 1
    '        r.Item(intI) = r2.Item(intI)
    '      Next
    '      strN &= "'" & r.Item(0).ToString.Trim & "',"
    '      rs1.Rows.InsertAt(r, 0)
    '    Next
    '  End While
    '  DGP.DataSource = rs1
    '  For Each r1 As DataGridViewRow In DGP.Rows
    '    If GCell(r1.Cells(0)) = strKey Then
    '      r1.DefaultCellStyle.ForeColor = Color.Red
    '    End If
    '  Next
    'End Sub

    Private Sub DGP_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGP.CellFormatting
        If e.ColumnIndex = 5 Then
            Select Case GCell(DGP.Rows(e.RowIndex).Cells(e.ColumnIndex))
                Case "0"
                    e.Value = "OK"
                Case "1"
                    e.Value = BIG2GB("待修")
                Case "2"
                    e.Value = BIG2GB("返工")
                Case "3"
                    e.Value = BIG2GB("暫停")
                Case "4"
                    e.Value = BIG2GB("完工")
                Case "5"
                    e.Value = BIG2GB("出貨")
                Case "7"
                    e.Value = BIG2GB("綁定下層")
                Case "8"
                    e.Value = BIG2GB("報廢")
                Case "100"
                    e.Value = BIG2GB("底面")
            End Select
        End If
    End Sub

    Private Sub dglc_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dglc.CellContentClick

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TBA")
        sqlCV.Where("TBA01", "=", strWF)
        sqlCV.Where("TBA02", "=", strSWF)
        Dim w As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TA", "TA01", "=", "^0.TBA04")
        w.Add("SFIS_TA.TA04", "<>", "'STS'")
        sqlCV.SqlFields("TBA03", "序", , , True)
        sqlCV.SqlFields("TBA04", "工序")
        sqlCV.SqlFields("^1.TA02", "說明")
        sqlCV.SqlFields("(0)", "生產數")
        dglc.DataSource = DB.RsSQL(BIG2GB(sqlCV.Text), "TBAS")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If dglc.CurrentRow Is Nothing Or dglc.Rows.Count = 1 Then Return
        dglc.Rows.Remove(dglc.CurrentRow)
        Dim intI As Integer = 0
        For Each r As DataGridViewRow In dglc.Rows
            r.Cells(0).Value = intI
            intI += 1
        Next
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim sqlCV As New APSQL.SQLCNV
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_IE")
        sqlCV.Where("IE03", "=", CSTENG.Text.Trim)
        sqlCV.SqlFields("*")
        Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        If rs.Rows.Count = 0 Then Return
        Dim aryL As New Dictionary(Of String, DataGridViewRow)
        For Each r As DataGridViewRow In FDG2.Rows
            Dim s As String = GCell(r.Cells(0)) & vbTab & GCell(r.Cells(1))
            If aryL.ContainsKey(s) = False Then
                aryL.Add(s, r)
            End If
        Next
        For Each r As DataRow In rs.Rows
            Dim s As String = r!IE10.ToString.Trim & vbTab & r!IE01.ToString.Trim
            If aryL.ContainsKey(s) Then
                Dim r1 As DataGridViewRow = aryL(s)
                r1.Cells(0).Value = r!IE10.ToString.Trim
                r1.Cells(1).Value = r!IE01.ToString.Trim
                r1.Cells(2).Value = r!IE02.ToString.Trim
                r1.Cells(3).Value = r!IE04.ToString.Trim
                r1.Cells(4).Value = r!IE05.ToString.Trim
                r1.Cells(5).Value = r!IE06.ToString.Trim
                r1.Cells(6).Value = r!IE07.ToString.Trim
                r1.Cells(7).Value = r!IE08.ToString.Trim
            Else
                Dim rs1 As DataTable = FDG2.DataSource
                rs1.Rows.Add(r!IE10.ToString.Trim, r!IE01.ToString.Trim, r!IE02.ToString, _
                                r!IE04.ToString.Trim, r!IE05.ToString.Trim, r!IE06.ToString, _
                                r!IE07.ToString.Trim, r!IE08.ToString.Trim)
            End If
        Next
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If FDG2.CurrentRow Is Nothing Then Return
        FDG2.Rows.Remove(FDG2.CurrentRow)
        FDG2.AppendBegin()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim OFL As New OpenFileDialog
        OFL.Title = BIG2GB("使用Excel導入必要序號")
        OFL.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OFL.Filter = BIG2GB("xls Excel 2003檔案|*.xls|xlsx Excel檔案|*.xlsx|所有檔案|*.*")
        OFL.FilterIndex = 2
        OFL.FileName = ""
        If OFL.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim xs As New XLS_FILE(OFL.FileName)
            Dim rs As DataTable = xs.XLS2Rs(0)
            xs.Quit()
            Dim strC As String = rs.Columns(0).ColumnName
            Dim bolDISP As Boolean = False
            If strC <> "SN" And rs.Columns.Contains("SN") = True Then
                If MsgBox(BIG2GB("Excel表第一欄不是SN，是否" & strC & "與SN不綁定？"), vbYesNo, Me.Text) = MsgBoxResult.Yes Then
                    bolDISP = True
                End If
            End If
            Dim sqlCV As New APSQL.SQLCNV
            For Each r As DataRow In rs.Rows
                Dim strSN As String = r.Item(strC).ToString.Trim
                sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TS")
                sqlCV.Where("TS02", "=", strSN)
                sqlCV.SqlFields("*")
                Dim rs1 As DataTable = DB.RsSQL(sqlCV.Text, "RT")
                If rs1.Rows.Count > 0 Then
                    If MsgBox(BIG2GB(strC & " [" & strSN & "] 已經導入，無法重複作業，是否取消導入？" & vbCrLf & "確定表示繼續，取消代表中斷"), vbOKCancel, Me.Text) = MsgBoxResult.Cancel Then Return
                    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_delete, "SFIS_TS")
                    sqlCV.Where("TS01", "=", strSN)
                    sqlCV.Where("TS01", "=", rs1.Rows(0)!TS01.ToString.Trim, "OR")
                    DB.RsSQL(sqlCV.Text)
                End If
                For intI As Integer = 0 To rs.Columns.Count - 1
                    If r.Item(intI).ToString.Trim = "" Then Continue For
                    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TS")
                    sqlCV.Where("TS02", "=", r.Item(intI).ToString.Trim)
                    sqlCV.SqlFields("TS01")
                    rs1 = DB.RsSQL(sqlCV.Text, "RT")
                    If rs1.Rows.Count > 0 Then
                        MsgBox(BIG2GB(rs.Columns(intI).ColumnName.Trim & "重複，在" & strC & "=" & strSN))
                        Continue For
                    End If
                    If intI > 0 And rs.Columns(intI).ColumnName = "SN" And bolDISP Then
                        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TS")
                        sqlCV.Where("TS02", "=", r.Item(intI).ToString.Trim)
                        sqlCV.SqlFields("TS01")
                        rs1 = DB.RsSQL(sqlCV.Text, "RT")
                        If rs1.Rows.Count > 0 Then
                            MsgBox(BIG2GB(rs.Columns(intI).ColumnName.Trim & "重複，在SN = " & r.Item(intI).ToString.Trim))
                            Continue For
                        End If
                        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_TS")
                        sqlCV.SqlFields("TS01", r.Item(intI).ToString.Trim)
                        sqlCV.SqlFields("TS02", r.Item(intI).ToString.Trim)
                        sqlCV.SqlFields("TS03", Txtworkcode.Text.Trim & vbTab & rs.Columns(intI).ColumnName.Trim)
                    Else
                        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_TS")
                        sqlCV.SqlFields("TS01", strSN)
                        sqlCV.SqlFields("TS02", r.Item(intI).ToString.Trim)
                        sqlCV.SqlFields("TS03", Txtworkcode.Text.Trim & vbTab & rs.Columns(intI).ColumnName.Trim)
                    End If
                    DB.RsSQL(sqlCV.Text)
                Next
            Next
            MsgBox(BIG2GB("Excel檔案導入完成"))
        End If
    End Sub

    Private Sub BTNSN_Click(sender As Object, e As EventArgs) Handles BTNSN.Click
        '自動產生SN
        If SNO.Text.Trim = "" Then
            If SNOB.Text.Trim = "" Then
                SNOB.Text = "XD100/"
                SNOE.Text = ""
                SNO.Text = "00000000"
            End If
        End If
        SNO.Text = SNO.Text.Trim.ToUpper
        SNOB.Text = SNOB.Text.Trim.ToUpper
        SNOE.Text = SNOE.Text.Trim.ToUpper
        SNP.SetConcat(SNOB.Text.Trim, SNO.Text.Trim, SNOE.Text.Trim)
        Dim strM As String = SNP.GetMax
        SNO.Text = SNP.GetSNC


        'If Txtworkcode.Text.Trim = "" Then Return
        'Dim sqlCV As New APSQL.SQLCNV
        'If cbMO.Items.Count = 0 Then Return
        'SNOB.Text = ""
        'SNO.Text = ""
        'SNOE.Text = ""
        'Dim intMax As Integer = 0
        'Dim strSNH As String = ""
        'For Each c As String In cbMO.Items
        '  If c = Txtworkcode.Text.Trim Then Continue For
        '  sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
        '  sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TD", "TD01", "=", "^0.TN02")
        '  sqlCV.Where("^0.TN02", "=", c)
        '  sqlCV.Where("^1.TD02", "=", Txtproductcode.Text.Trim)
        '  sqlCV.SqlFields("^0.TN01")
        '  Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RS")
        '  If rs.Rows.Count = 0 Then Continue For
        '  Dim strTN() As String
        '  For Each r As DataRow In rs.Rows
        '    strTN = Split(r!TN01.ToString, "/")
        '    strSNH = strTN(0)
        '    If strTN.Count >= 2 Then
        '      Dim intN As Integer = Val(strTN(1))
        '      If intN > 0 Then
        '        If intN > intMax Then
        '          intMax = Val(strTN(1))
        '        End If
        '      End If
        '    End If
        '  Next
        'Next
        'If strSNH <> "" Then
        '  SNOB.Text = strSNH & "/"
        'Else
        '  SNOB.Text = ""
        'End If
        'If intMax > 0 Then
        '  intMax += 1
        '  SNO.Text = intMax.ToString("00000000")
        'Else
        '  SNO.Text = "00000001"
        'End If
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        If snoMO Is Nothing Or Txtworkcode.Enabled = False Then Return
        Dim sqlCV As New APSQL.SQLCNV
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TD")
        sqlCV.Where("TD01", "Like", snoMO.IDPAT)
        sqlCV.SqlFields("MAX(TD01)", "MV")
        Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        Dim strP As String = "", intI As Integer = 500
        If rs.Rows.Count = 0 Then
            intI = 500
        Else
            strP = rs.Rows(0)!MV.ToString.Trim.ToUpper
            If strP.Length <> snoMO.IDPAT.Length Then
                intI = 500
            Else
                intI = snoMO.Diff(strP)
                If intI < 500 Then intI = 500
            End If
        End If
        Txtworkcode.Text = snoMO.GetID(intI + 1)
        ShowLOTS(Txtworkcode.Text.Trim)
    End Sub

    Private Sub Button9_Click_1(sender As Object, e As EventArgs) Handles Button9.Click
        If snoSE Is Nothing OrElse strSE01 = "" Then
            MsgBox(BIG2GB("沒有設置單別單號"))
            Return
        End If
        If DG1.Rows.Count = 0 Then
            MsgBox(BIG2GB("沒有設定料站表，無法產生領料單"))
            Return
        End If
        If Txtworkcode.Enabled = True And sender IsNot Nothing And bolSaveInv = False Then
            bolSaveInv = True
            MsgBox(BIG2GB("這筆工單尚未存檔，等存檔再一併保存"))
            Return
        End If
        Dim sqlCV As New APSQL.SQLCNV
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "WMSE")
        sqlCV.Where("SE11", "=", Txtworkcode.Text.Trim.ToUpper)
        sqlCV.SqlFields("SE01")
        sqlCV.SqlFields("SE02")
        Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        If rs.Rows.Count > 0 Then
            MsgBox(BIG2GB("這個工單已經轉出發料單") & rs.Rows(0)!SE01.ToString.Trim & "-" & rs.Rows(0)!SE02.ToString.Trim)
            Return
        End If
        If Val(EXTRA.Text) < 0.001 Then
            If MsgBox(BIG2GB("沒有設置損耗量是否繼續產生領料單?"), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Return
        End If
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "WMSE")
        sqlCV.Where("SE02", "Like", snoSE.IDPAT)
        sqlCV.SqlFields("MAX(SE02)", "MV")
        rs = DB.RsSQL(sqlCV.Text, "RT")
        Dim strP As String = ""
        If rs.Rows.Count = 0 Then
            strP = snoSE.GetID(0)
        Else
            strP = rs.Rows(0)!MV.ToString.Trim.ToUpper
            If strP.Length <> snoSE.IDPAT.Length Then
                strP = snoSE.GetID(0)
            Else
                snoSE.BeginID = strP
            End If
        End If
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "WMSE")
        sqlCV.SqlFields("SE01", strSE01)
        sqlCV.SqlFields("SE02", snoSE.GetID(1))
        sqlCV.SqlFields("SE03", Now.ToString("yyyy\/MM\/dd"))
        sqlCV.SqlFields("SE04", lgncode)
        sqlCV.SqlFields("SE05", "")
        sqlCV.SqlFields("SE06", "")
        sqlCV.SqlFields("SE07", "")
        sqlCV.SqlFields("SE08", 0, intFMode.msfld_num)
        sqlCV.SqlFields("SE11", Txtworkcode.Text.Trim.ToUpper)
        sqlCV.SqlFields("SE12", "")
        DB.RsSQL(sqlCV.Text)
        Dim sngQ As Double = Val(MOQTY.Text) + Val(SmpQTY.Text)
        For intI As Integer = 0 To DG1.Rows.Count - 1
            Dim r1 As DataGridViewRow = DG1.Rows(intI)
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "WMSEA")
            sqlCV.SqlFields("SEA01", strSE01)
            sqlCV.SqlFields("SEA02", snoSE.GetID(1))
            sqlCV.SqlFields("SEA03", snoSE.GetID(1) & "_" & (intI + 1).ToString("000"))
            sqlCV.SqlFields("SEA04", GCell(r1.Cells(1)))
            sqlCV.SqlFields("SEA05", "")
            If GCell(r1.Cells(4)) = BIG2GB("平方米") Or GCell(r1.Cells(4)).ToUpper = "M2" Then
                If EXTRA.Tag Is Nothing OrElse EXTRA.Tag.ToString.Trim = "" Then
                    sqlCV.SqlFields("SEA06", (Val(GCell(r1.Cells(3))) * sngQ).ToString("0.000"), intFMode.msfld_num)
                Else
                    sqlCV.SqlFields("SEA06", ((Val(Label37.Text) + Val(EXTRA.Text)) * Val(EXTRA.Tag)).ToString("0.000"), intFMode.msfld_num)
                End If
            Else
                sqlCV.SqlFields("SEA06", Val(GCell(r1.Cells(3))), intFMode.msfld_num)
            End If
            sqlCV.SqlFields("SEA07", GCell(r1.Cells(4)))
            sqlCV.SqlFields("SEA08", 0, intFMode.msfld_num)
            sqlCV.SqlFields("SEA09", "")
            sqlCV.SqlFields("SEA11", 0, intFMode.msfld_num)
            sqlCV.SqlFields("SEA16", Txtworkcode.Text.Trim.ToUpper)
            sqlCV.SqlFields("SEA17", 0, intFMode.msfld_num)
            sqlCV.SqlFields("SEA18", 1, intFMode.msfld_num)
            sqlCV.SqlFields("SEA19", 0, intFMode.msfld_num)
            DB.RsSQL(sqlCV.Text)
        Next
        MsgBox(BIG2GB("工單轉發料單成功 單號:" & strSE01 & "-" & snoSE.GetID(1)))
    End Sub

    Private Sub Panel6_DoubleClick(sender As Object, e As EventArgs) Handles Panel6.DoubleClick
        Dim frm As New WMS0302A
        frm.SetImage(Panel6.BackgroundImage)
        frm.ShowDialog()
    End Sub
    Private Sub Dgsort(sender As Object, e As EventArgs)
        DG = sender
    End Sub
    Private Sub Dgsort1(sender As Object, e As EventArgs)
        DG = sender
        If CheckBox1.Checked And DG.DataSource IsNot Nothing Then
            Dim rs As DataTable = DG.DataSource
            Dim aryL As New ArrayList
            Dim strMD As Date = Now.AddDays(-Val(TextBox1.Text)).Date
            For Each r As DataRow In rs.Rows
                If IsDate(r.Item(9).ToString) Then
                    If r.Item(7).ToString.Trim = "2" And CDate(r.Item(9).ToString).Date < strMD Then
                        aryL.Add(r)
                    End If
                End If
            Next
            For Each r As DataRow In aryL
                rs.Rows.Remove(r)
            Next
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If DG Is Nothing Then Return
        TBC.SelectedIndex = 2
        For Each r As DataGridViewRow In DG.Rows
            If GCell(r.Cells(7)) = "2" Then
                r.DefaultCellStyle.BackColor = Color.RosyBrown
                r.DefaultCellStyle.ForeColor = Color.Yellow
            End If
        Next
        DG.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        DG = Nothing
    End Sub

    Private Sub Txtworkcode_Validated(sender As Object, e As EventArgs) Handles Txtworkcode.Validated
        If Txtworkcode.Text.Trim <> "" Then
            ShowLOTS(Txtworkcode.Text.Trim)
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If s1 IsNot Nothing And Timer1.Enabled = True Then
            s1.Updated = True
            s1.Clean()
        End If
        My.Settings.MOClosed = CheckBox1.Checked
        bolMOCloseChg = True
    End Sub

    Private Sub TextBox1_Validated(sender As Object, e As EventArgs) Handles TextBox1.Validated
        If CheckBox1.Checked = True Then
            My.Settings.MOCDATE = Val(TextBox1.Text)
            bolMOCloseChg = True
            If s1 IsNot Nothing And Timer1.Enabled = True Then
                s1.Updated = True
                s1.Clean()
            End If
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If Txtworkcode.Enabled = True Then Return
        Dim sqlCV As New APSQL.SQLCNV
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TD")
        sqlCV.Where("TD01", "=", Txtworkcode.Text)
        sqlCV.SqlFields("TD41")
        Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        If My.Settings.X401NUM = 0 Then
            ClsX0401.FrmX401.Code = dt.Rows(0)!TD41.ToString()
        Else
            ClsX0401.FrmX401.Code = My.Settings.X401
        End If
        Dim frm As ClsX0401.FrmX401 = New ClsX0401.FrmX401()
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            Dim strV() As String = ClsX0401.FrmX401.strCode.Split(",")
            Label47.Text = "颜料:" + strV(0) + "," + "二度冲模:" + strV(1) + "," + "冲孔:" + strV(2) + "," + "颜色数:" + strV(3) + "," + "高温纸:" + strV(4) + "," + "印刷方式:" + strV(5)
            Label49.Text = ClsX0401.FrmX401.Code
            My.Settings.X401 = Label49.Text
            My.Settings.X401NUM += 1
            My.Settings.Save()
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If Txtworkcode.Enabled = True Then Return
        Dim sqlCV As New APSQL.SQLCNV
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TD")
        sqlCV.Where("TD01", "=", Txtworkcode.Text)
        sqlCV.Where("TD02", "=", Txtproductcode.Text)
        sqlCV.SqlFields("TD27")
        sqlCV.SqlFields("TD24")
        sqlCV.SqlFields("TD34")
        sqlCV.SqlFields("TD39")
        sqlCV.SqlFields("TD35")
        sqlCV.SqlFields("TD38")
        Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        If dt.Rows(0)!TD34.ToString() = "" Then
            dt.Rows(0)!TD34 = Txtproductcode.Text
        End If
        If dt.Rows(0)!TD39.ToString() = "" Then
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "WMSAA")
            sqlCV.Where("SAA01", "=", Txtproductcode.Text)
            'sqlCV.Where("SAA02", "=", dt.Rows(0)!TD27.ToString())
            sqlCV.SqlFields("SAA08")
            Dim dt1 As DataTable = DB.RsSQL(sqlCV.Text, "RT")
            If dt1.Rows.Count = 0 Then Return '20220729新增
            dt.Rows(0)!TD39 = dt1.Rows(0)!SAA08.ToString()
        End If
        Dim strA(5) As String
        For i As Integer = 0 To dt.Columns.Count - 1
            strA(i) = dt.Rows(0)(i).ToString()
        Next
        If My.Settings.X402NUM = 0 Then
            ClsX0401.FrmX402.strV = strA
        Else
            ClsX0401.FrmX402.strV = My.Settings.X402.Split(";")
        End If
        Dim frm As ClsX0401.FrmX402 = New ClsX0401.FrmX402()
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            Dim strV() As String = ClsX0401.FrmX402.strCode.Split(";")
            Label48.Text = "客户编号:" + strV(0) + "," + "产品包装容量:" + strV(1) + "," + "客户料号:" + strV(2) + "," + "包装标签格式:" + strV(3) + "," + "纸管直径:" + strV(4) + ",包装注意事项:" + Chr(13) + ""
            Dim strY() As String = strV(5).Split(",")
            For i As Integer = 0 To strY.Length - 1
                If strY(i) = "" Then
                    Continue For
                End If
                Label48.Text += strY(i) + ":TRUE"
                If (i <> strY.Length - 1) Then
                    Label48.Text += ","
                End If
            Next
            Label50.Text = ClsX0401.FrmX402.Code
            My.Settings.X402 = Label50.Text
            My.Settings.X402NUM += 1
            My.Settings.Save()
        End If
    End Sub
End Class
