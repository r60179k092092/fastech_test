Imports APSQL
Public Class PM0301
  Dim WithEvents clsdt As clsEDIT2012.clsEDITx2013
  'Dim Ddanwei As FrmDialog
  'Dim Dzhonglei As FrmDialog
#Region "load  and close"
  Sub New()

    ' 此調用是設計器所必需的。
    InitializeComponent()

    ' 在 InitializeComponent() 調用之后添加任何初始化。
    languagechange(Me)
    'Cmbmachinestate.Items.Clear()
    'Cmbmachinestate.Items.AddRange(getlanguagecmb(Me, "Cmbmachinestate01"))
    dgdaochu(DGjt)
  End Sub
  '' load
  Private Sub FrmJCwuliao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    clsdt = New clsEDIT2012.clsEDITx2013(DGjt, DB, language)
    Me.KeyPreview = True
    DGjt.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlLight
    clsdt.Clean()
    '-------------------------------------------------------------
    '自動定位到這一個編輯清單，讓操作者更方便運作數據
    clsdt.AddKeyColumns(BIG2GB("機臺編號")) ''保存后自動定位到 dg

    clsdt.GetToolsItem("Delete").Enabled = clsRTS.GetRight(Me.Tag & "/003")
    clsdt.GetToolsItem("save").Enabled = clsRTS.GetRight(Me.Tag & "/001")
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", "LINE")
    sqlCV.SqlFields("QTN02", , , , True)
    sqlCV.SqlFields("QTN02 + ' ' + QTN03", "DATAS")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RTJ03")
    Dim bolM As Boolean = False
    For Each r As DataRow In rs.Rows
      If r!QTN02.ToString.Trim = "NA" Then
        bolM = True
        Exit For
      End If
    Next
    If bolM = False Then rs.Rows.Add("NA", BIG2GB("未設定線別"))
    Cmbline.DisplayMember = "DATAS"
    Cmbline.ValueMember = "QTN02"
    Cmbline.DataSource = rs
    If rs.Rows.Count > 0 Then
      Cmbline.SelectedValue = rs.Rows(0)!QTN02.ToString.Trim
    End If
  End Sub

  Private Sub FrmJCwuliao_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
    TuiCK(Me)
  End Sub
  '’_KeyDown
  Private Sub FrmJCwuliao_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    If e.KeyCode = 13 Then
      e.Handled = True
      e.SuppressKeyPress = True
      Me.SelectNextControl(Me.ActiveControl, True, True, True, True)

    End If
  End Sub
#End Region


#Region "選擇 dg"
  Private Sub dt_DVSelect(ByVal s As clsEDIT2012.clsEDITx2013, ByVal r As System.Windows.Forms.DataGridViewRow) Handles clsdt.DVSelect
    Txtmachinecode.Text = r.Cells(0).Value.ToString
    Txtmachinename.Text = r.Cells(1).Value.ToString
    Cmbline.SelectedValue = r.Cells(2).Value.ToString
    If Cmbline.SelectedValue Is Nothing Then
      Cmbline.SelectedValue = "NA"
    End If
    Datlastmaintain.Text = r.Cells(3).Value.ToString
    Datnextmaintain.Text = r.Cells(4).Value.ToString
    Txtcurrentwork.Text = r.Cells(5).Value.ToString
    Cmbmachinestate.Text = r.Cells(6).FormattedValue
    Txtmaintenance.Text = r.Cells(7).Value.ToString
    Txtmanage.Text = r.Cells(8).Value.ToString
    Txtlastusedate.Text = r.Cells(9).Value.ToString
    BT.Text = r.Cells(10).Value.ToString
    txtPATH.Text = GCell(r.Cells(11)).Split(";")(0)
    txtPNG.Text = (GCell(r.Cells(11)) & ";").Split(";")(1)
    txtEXT.Text = GCell(r.Cells(12))
    txtSCAN.Text = Val(GCell(r.Cells(13)))
    If Val(txtSCAN.Text) <= 0 Then txtSCAN.Text = 1
    cmbTYPE.SelectedIndex = Val(GCell(r.Cells(14)))
    TJ16.Text = GCell(r.Cells(15))
    If IsDate(GCell(r.Cells(16))) = False Then
      TJ17.Value = Now.AddDays(30).Date
    Else
      TJ17.Value = GCell(r.Cells(16))
    End If
    If IsDate(GCell(r.Cells(17))) = False Then
      TJ18.Value = Now.AddDays(180).Date
    Else
      TJ18.Value = GCell(r.Cells(17))
    End If
    '------------------------------------------------
    '這一行加入可以確保編號不被覆蓋
    Txtmachinecode.Enabled = False
    '-------------------------------------------------
  End Sub
#End Region
#Region "dvtable"
  Private Sub dt_DVTable(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles clsdt.DVTable
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TJ")
    sqlCV.SqlFields("TJ01", "機臺編號")
    sqlCV.SqlFields("TJ02", "機臺名稱")
    sqlCV.SqlFields("TJ03", "線別")
    sqlCV.SqlFields("convert(varchar(10),TJ04,111)", "最后保養日期")
    sqlCV.SqlFields("convert(varchar(10),TJ05,111)", "下次保養日期")
    sqlCV.SqlFields("TJ06", "目前工單")
    sqlCV.SqlFields("TJ07", "機臺狀態")
    sqlCV.SqlFields("TJ08", "保養責任人")
    sqlCV.SqlFields("TJ09", "管理責任人")
    sqlCV.SqlFields("convert(varchar(10),TJ10,111)", "最后使用日期")
    sqlCV.SqlFields("TJ11", "SMT藍芽ID")
    sqlCV.SqlFields("TJ12", "路徑")
    sqlCV.SqlFields("TJ13", "副檔名")
    sqlCV.SqlFields("TJ14", "秒數")
    sqlCV.SqlFields("TJ15", "格式")
    sqlCV.SqlFields("TJ16", "連結機台序號")
    sqlCV.SqlFields("convert(varchar(10),TJ17,111)", "下次內校日期")
    sqlCV.SqlFields("convert(varchar(10),TJ18,111)", "下次外校日期")
    sqlCV.SqlFields("uact", "最后異動人")
    sqlCV.SqlFields("udate", "最后異動時間")
    strSQL = BIG2GB(sqlCV.Text)
  End Sub
#End Region
#Region "清空"
  Private Sub dt_Frm_Clear(ByVal s As clsEDIT2012.clsEDITx2013) Handles clsdt.Frm_Clear
    For Each ct In Panel1.Controls
      If TypeOf (ct) Is TextBox Then ct.text = ""
    Next
    Txtmaintenance.Text = ""
    Cmbmachinestate.Text = ""
    '-------------------------------------------------
    '這一行加入讓新增能夠運行
    Txtmachinecode.Enabled = True
    Cmbline.SelectedValue = "NA"
    cmbTYPE.SelectedIndex = 0
    Cmbmachinestate.SelectedIndex = 0
    txtSCAN.Text = 1
  End Sub
#End Region
#Region "刪除"
  Private Sub dt_Frm_Delete(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String, ByRef bolOK As Boolean) Handles clsdt.Frm_Delete
    If MsgBox(BIG2GB("是否刪除機臺編號:") & Txtmachinecode.Text, MsgBoxStyle.OkCancel, BIG2GB("提示")) = MsgBoxResult.Ok Then
      Dim sqlCV As New APSQL.SQLCNV
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_delete, "Sfis_TJ")
      sqlCV.Where("TJ01", "=", Txtmachinecode.Text)
      strSQL = sqlCV.Text
      bolOK = True
      '---------------------------------------------------------
      '信息非必要，只有增加操作員困擾，你可以參考ERP，他們讓操作員很舒服
      'MsgBox("數據刪除成功", MsgBoxStyle.OkOnly, BIG2GB("提示"))
    End If
    'Catch ex As Exception
    '  MsgBox("數據刪除失敗", MsgBoxStyle.OkOnly, BIG2GB("提示"))
    'End Try
  End Sub
#End Region

#Region "dt_isDataValid 保存檢驗數據"
  ''保存前檢驗是否合格 
  Private Sub dt_isDataValid(ByVal s As clsEDIT2012.clsEDITx2013, ByRef bolOK As Boolean) Handles clsdt.isDataValid
    If Txtmachinecode.Text.Trim.Length = 0 Then
      MsgBox(BIG2GB("機臺編號不得空白"), MsgBoxStyle.OkOnly, BIG2GB("提示"))
      Txtmachinecode.Focus()
      Return
    End If
    bolOK = True
    'MsgBox("CHKDATA OK")
  End Sub
#End Region
#Region "dt_Frm_CheckDup保存檢驗數據是否存在"
  '’保存檢驗數據是否存在
  Private Sub dt_Frm_CheckDup(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles clsdt.Frm_CheckDup
    strSQL = "select *  from sfis_TJ where TJ01='" & Txtmachinecode.Text & "'"
  End Sub
#End Region
#Region "添加"
  Private Sub dt_Frm_InsertM(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles clsdt.Frm_InsertM
    Dim sqlCV As New APSQL.SQLCNV
    'MsgBox("TO INSERT BEGIN")
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "sfis_TJ")
    sqlCV.SqlFields("TJ01", Txtmachinecode.Text.Trim)
    sqlCV.SqlFields("TJ02", Txtmachinename.Text.Trim)
    If Cmbline.SelectedValue Is Nothing Then
      sqlCV.SqlFields("TJ03", "NA")
    Else
      sqlCV.SqlFields("TJ03", Cmbline.SelectedValue.ToString.Trim)
    End If
    sqlCV.SqlFields("TJ04", Datlastmaintain.Text)
    sqlCV.SqlFields("TJ05", Datnextmaintain.Text)
    sqlCV.SqlFields("TJ06", Txtcurrentwork.Text.Trim)
    sqlCV.SqlFields("TJ07", Cmbmachinestate.SelectedIndex)
    sqlCV.SqlFields("TJ08", Txtmaintenance.Text.Trim)
    sqlCV.SqlFields("TJ09", Txtmanage.Text.Trim)
    sqlCV.SqlFields("TJ11", BT.Text.Trim)
    sqlCV.SqlFields("TJ12", txtPATH.Text.Trim & ";" & txtPNG.Text.Trim)
    sqlCV.SqlFields("TJ13", txtEXT.Text.Trim)
    sqlCV.SqlFields("TJ14", txtSCAN.Text.Trim, intFMode.msfld_num)
    sqlCV.SqlFields("TJ15", cmbTYPE.SelectedIndex, intFMode.msfld_num)
    sqlCV.SqlFields("TJ16", TJ16.Text.Trim)
    sqlCV.SqlFields("TJ17", TJ17.Text, intFMode.msfld_datetime)
    sqlCV.SqlFields("TJ18", TJ18.Text, intFMode.msfld_datetime)
    sqlCV.SqlFields("UACT", lgnname)
    sqlCV.SqlFields("UDATE", "GETDATE()", intFMode.msfld_field)
    strSQL = sqlCV.Text
    'MsgBox("INSERT OK" & strSQL)
    '---------------------------------------------------------
    '信息非必要，只有增加操作員困擾，你可以參考ERP，他們讓操作員很舒服
    'MsgBox("物料保存成功", MsgBoxStyle.OkOnly, BIG2GB("提示"))
  End Sub
#End Region
#Region "更改"
  Private Sub dt_Frm_UpdateM(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles clsdt.Frm_UpdateM
    Dim sqlCV As New APSQL.SQLCNV
    'MsgBox("To Update BEGING")
    'If MsgBox("該物料已存在是否保存", MsgBoxStyle.OkCancel, "修改提示") = MsgBoxResult.Ok Then
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "sfis_TJ")
    sqlCV.Where("TJ01", "=", Txtmachinecode.Text.Trim)
    sqlCV.SqlFields("TJ02", Txtmachinename.Text.Trim)
    If Cmbline.SelectedValue Is Nothing Then
      sqlCV.SqlFields("TJ03", "NA")
    Else
      sqlCV.SqlFields("TJ03", Cmbline.SelectedValue.ToString.Trim)
    End If
    sqlCV.SqlFields("TJ04", Datlastmaintain.Text)
    sqlCV.SqlFields("TJ05", Datnextmaintain.Text)
    sqlCV.SqlFields("TJ06", Txtcurrentwork.Text.Trim)
    sqlCV.SqlFields("TJ07", Cmbmachinestate.SelectedIndex)
    sqlCV.SqlFields("TJ08", Txtmaintenance.Text.Trim)
    sqlCV.SqlFields("TJ09", Txtmanage.Text.Trim)
    sqlCV.SqlFields("TJ11", BT.Text.Trim)
    sqlCV.SqlFields("TJ12", txtPATH.Text.Trim & ";" & txtPNG.Text.Trim)
    sqlCV.SqlFields("TJ13", txtEXT.Text.Trim)
    sqlCV.SqlFields("TJ14", txtSCAN.Text.Trim, intFMode.msfld_num)
    sqlCV.SqlFields("TJ15", cmbTYPE.SelectedIndex, intFMode.msfld_num)
    sqlCV.SqlFields("TJ16", TJ16.Text.Trim)
    sqlCV.SqlFields("TJ17", TJ17.Text, intFMode.msfld_datetime)
    sqlCV.SqlFields("TJ18", TJ18.Text, intFMode.msfld_datetime)
    sqlCV.SqlFields("UACT", lgnname)
    sqlCV.SqlFields("UDATE", "GETDATE()", intFMode.msfld_field)
    strSQL = sqlCV.Text
    'MsgBox("Update OK" & strSQL)
    '---------------------------------------------------------
    '信息非必要，只有增加操作員困擾，你可以參考ERP，他們讓操作員很舒服
    'MsgBox("物料保存成功", MsgBoxStyle.OkOnly, BIG2GB("提示"))
    'Else
    'strSQL = ""
    'End If
  End Sub
#End Region
#Region "dt_DV_HasError"
  Private Sub dt_DV_HasError(ByVal s As clsEDIT2012.clsEDITx2013, ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles clsdt.DV_HasError

  End Sub
#End Region



  ''行號顯示
  Private Sub DGjt_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGjt.RowPostPaint
    Dim Rectangle As System.Drawing.Rectangle = New System.Drawing.Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, DGjt.RowHeadersWidth - 4, e.RowBounds.Height)
    TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), DGjt.RowHeadersDefaultCellStyle.Font, Rectangle, DGjt.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter & TextFormatFlags.Right)
  End Sub
  ''' <summary>
  ''' 加入這段可以讓輸入Txtmachinecode判斷是否已存在料號
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub Txtmachinecode_Validated(ByVal sender As Object, ByVal e As EventArgs) Handles Txtmachinecode.Validated
    For Each r As DataGridViewRow In DGjt.Rows
      If Txtmachinecode.Text.Trim = r.Cells(0).Value.ToString Then
        dt_DVSelect(Nothing, r)
        DGjt.CurrentCell = r.Cells(0)
        Exit For
      End If
    Next
  End Sub

  Private Sub DGjt_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGjt.CellFormatting
    If e.ColumnIndex = 6 Then
      e.Value = Cmbmachinestate.Items(e.Value)
      'Select Case e.Value
      '    Case 0 : e.Value = "正常"
      '    Case 1 : e.Value = "維修保養中"
      '    Case 2 : e.Value = "暫停使用"
      '    Case 3 : e.Value = "外修中"
      'End Select
    ElseIf e.ColumnIndex = 14 Then
      Dim strK As String = GCell(DGjt.Rows(e.RowIndex).Cells(e.ColumnIndex))
      If Val(strK) >= 0 And Val(strK) < cmbTYPE.Items.Count Then
        e.Value = cmbTYPE.Items(Val(strK)).ToString.Split(" ")(1)
      End If
    End If
  End Sub

  Private Sub BtnOFL_Click(sender As Object, e As EventArgs) Handles BtnOFL.Click
    Dim OFL As New FolderBrowserDialog
    OFL.Description = Me.Text
    OFL.RootFolder = Environment.SpecialFolder.MyComputer
    OFL.SelectedPath = txtPATH.Text.Trim
    If OFL.ShowDialog = Windows.Forms.DialogResult.OK Then
      txtPATH.Text = OFL.SelectedPath
    End If
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    Dim OFL As New FolderBrowserDialog
    OFL.Description = Me.Text
    OFL.RootFolder = Environment.SpecialFolder.MyComputer
    OFL.SelectedPath = txtPNG.Text.Trim
    If OFL.ShowDialog = Windows.Forms.DialogResult.OK Then
      txtPNG.Text = OFL.SelectedPath
    End If
  End Sub
End Class