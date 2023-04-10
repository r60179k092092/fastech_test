Imports APSQL
Public Class PM0311
  Dim WithEvents clsdt As clsEDIT2012.clsEDITx2013
  Private bolLock As Boolean = False
  Private aryTB03 As New Dictionary(Of String, String)

#Region "load  and close"
  Sub New()
    ' 此調用是設計器所必需的。
    InitializeComponent()
    ' 在 InitializeComponent() 調用之后添加任何初始化。
    languagechange(Me)
    dgdaochu(DGjt)
  End Sub
  Private Sub DownLoad()
    Dim bolW As Boolean = False
    If MsgBox(BIG2GB("是否要覆蓋重複的生產標準？"), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
      bolW = True
    End If
    Dim OFL As New OpenFileDialog
    OFL.Title = BIG2GB("請選擇一個導入Excel資料")
    OFL.Filter = BIG2GB("Excel|*.xls;*.xlsx|所有檔案|*.*")
    OFL.FileName = ""
    Dim sqlCV As New APSQL.SQLCNV, strM As String = "", intI As Integer = 0
    If OFL.ShowDialog = Windows.Forms.DialogResult.OK Then
      dt_Frm_Clear(Nothing)
      Dim xlsF As New XLS_FILE(OFL.FileName)
      Dim rs As DataTable = xlsF.XLS2Rs(0)
      For Each r As DataRow In rs.Rows
        If r.Item(3).ToString.Trim = "" Then
          Continue For
        End If
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TBB")
        sqlCV.Where("TBB03", "=", r.Item(3).ToString.Trim)
        sqlCV.SqlFields("*")
        Dim rs1 As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        If rs1.Rows.Count = 0 Then
          strM &= BIG2GB("項目") & r.Item(0).ToString.Trim & " " & r.Item(3).ToString.Trim & BIG2GB("找不到料號無法轉檔") & vbCrLf
          Continue For
        End If
        If rs1.Rows(0)!TBB01.ToString.Trim = "" And rs1.Rows(0)!TBB02.ToString.Trim = "" Then
          strM &= BIG2GB("項目") & r.Item(0).ToString.Trim & " " & r.Item(3).ToString.Trim & BIG2GB("沒有設定對應流程") & vbCrLf
          Continue For
        End If
        If (r.Item(1).ToString.Trim <> "" And r.Item(1).ToString.Trim <> rs1.Rows(0)!TBB04.ToString.Trim) Or
           (r.Item(2).ToString.Trim <> "" And r.Item(2).ToString.Trim <> rs1.Rows(0)!TBB05.ToString.Trim) Then
          sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_TBB")
          sqlCV.Where("TBB03", "=", r.Item(3).ToString.Trim)
          If r.Item(1).ToString.Trim <> "" Then sqlCV.SqlFields("TBB04", r.Item(1).ToString.Trim)
          If r.Item(2).ToString.Trim <> "" Then sqlCV.SqlFields("TBB05", r.Item(2).ToString.Trim)
          DB.RsSQL(sqlCV.Text)
        End If
        If bolW = False Then
          sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TJAB")
          sqlCV.Where("TJAB01", "=", "@" & rs1.Rows(0)!TBB01.ToString.Trim & "-" & rs1.Rows(0)!TBB02.ToString.Trim)
          sqlCV.Where("TJAB02", "=", r.Item(3).ToString.Trim)
          sqlCV.SqlFields("TJAB03")
          Dim rs2 As DataTable = DB.RsSQL(sqlCV.Text, "RT1")
          If rs2.Rows.Count > 0 Then Continue For
          intI = 0
        Else
          sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_TJAB")
          sqlCV.Where("TJAB01", "=", "@" & rs1.Rows(0)!TBB01.ToString.Trim & "-" & rs1.Rows(0)!TBB02.ToString.Trim)
          sqlCV.Where("TJAB02", "=", r.Item(3).ToString.Trim)
          sqlCV.SqlFields("TJAB03", r.Item(6).ToString.Trim, intFMode.msfld_num)
          sqlCV.SqlFields("TJAB10", r.Item(5).ToString.Trim, intFMode.msfld_num)
          intI = DB.RsSQL(sqlCV.Text)
        End If
        If intI = 0 Then
          sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_TJAB")
          sqlCV.SqlFields("TJAB01", "@" & rs1.Rows(0)!TBB01.ToString.Trim & "-" & rs1.Rows(0)!TBB02.ToString.Trim)
          sqlCV.SqlFields("TJAB02", r.Item(3).ToString.Trim)
          sqlCV.SqlFields("TJAB03", r.Item(6).ToString.Trim, intFMode.msfld_num)
          sqlCV.SqlFields("TJAB10", r.Item(5).ToString.Trim, intFMode.msfld_num)
          intI = DB.RsSQL(sqlCV.Text)
        End If
      Next
      xlsF.Quit()
      clsdt.Updated = True
      clsdt.Clean()
      If strM = "" Then
        MsgBox(BIG2GB("導入成功"))
      Else
        MsgBox(strM & "部分錯誤，導入結束")
      End If
    End If
  End Sub
  '' load
  Private Sub FrmJCwuliao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.WindowState = FormWindowState.Maximized
    clsdt = New clsEDIT2012.clsEDITx2013(DGjt, DB, language)
    clsdt.InsertToolsItem(3, "-", Nothing, Nothing)
    clsdt.InsertToolsItem(3, BIG2GB("導入標準工時表"), My.Resources.XDOWN, AddressOf DownLoad)
    Me.KeyPreview = True
    DGjt.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlLight
    clsdt.Clean()
    '-------------------------------------------------------------
    '自動定位到這一個編輯清單，讓操作者更方便運作數據
    clsdt.AddKeyColumns(BIG2GB("工序")) ''保存后自動定位到 dg
    clsdt.AddKeyColumns(BIG2GB("物料編號"))

    clsdt.GetToolsItem("Delete").Enabled = clsRTS.GetRight(Me.Tag & "/003")
    clsdt.GetToolsItem("save").Enabled = clsRTS.GetRight(Me.Tag & "/001")
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TB")
    sqlCV.SqlFields("TB01", , , , True)
    sqlCV.SqlFields("TB02", , , , True)
    sqlCV.SqlFields("TB03")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    For Each r As DataRow In rs.Rows
      aryTB03.Add("@" & r!TB01.ToString.Trim & "-" & r!TB02.ToString.Trim, r!TB03.ToString.Trim)
    Next
  End Sub
  Private Sub FrmJCwuliao_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
    TuiCK(Me)
  End Sub

  Private Sub PM030201_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
    If e.KeyChar = Chr(13) Then
      Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End If
  End Sub
#End Region


#Region "選擇 dg"
  Private Sub dt_DVSelect(ByVal s As clsEDIT2012.clsEDITx2013, ByVal r As System.Windows.Forms.DataGridViewRow) Handles clsdt.DVSelect
    If bolLock = True Then Return
    bolLock = True
    Txtwuliao.Text = r.Cells(2).Value.ToString
    cmbgx_GotFocus(Nothing, Nothing)
    cmbgx.SelectedValue = GCell(r.Cells(0))
    SPEC.Text = GCell(r.Cells(3))
    numgongshi.Text = GCell(r.Cells(4))
    TJAB10.Text = IIf(Val(GCell(r.Cells(5))) < 1, 1, Val(GCell(r.Cells(5))))
    numgongshicx.Text = GCell(r.Cells(6))
    numgongshix.Text = GCell(r.Cells(7))
    Numblcx.Text = GCell(r.Cells(8))
    Numblx.Text = GCell(r.Cells(9))
    numdjcx.Text = GCell(r.Cells(10))
    numdjx.Text = GCell(r.Cells(11))
    bolLock = False
    My.Application.DoEvents()
    '------------------------------------------------
    '這一行加入可以確保編號不被覆蓋
    'cmbgx.Enabled = False
    'Txtwuliao.Enabled = False
    'Btnproduct.Enabled = False
    '-------------------------------------------------
  End Sub
#End Region
#Region "dvtable"
  Private Sub dt_DVTable(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles clsdt.DVTable
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TJAB")
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "SFIS_TA", "TA01", "=", "^0.TJAB01")
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "SFIS_TBB", "TBB03", "=", "^0.TJAB02")
    sqlCV.SqlFields("TJAB01", "工序")
    sqlCV.SqlFields("^1.TA02", "工序說明")
    sqlCV.SqlFields("TJAB02", "物料編號")
    sqlCV.SqlFields("^2.TBB05+' '+^2.TBB06", "品名規格")
    sqlCV.SqlFields("TJAB03", "標準產能")
    sqlCV.SqlFields("TJAB10", "標準編制")
    sqlCV.SqlFields("TJAB04", "超下限")
    sqlCV.SqlFields("TJAB05", "下限")
    sqlCV.SqlFields("TJAB06", "不良率超下限")
    sqlCV.SqlFields("TJAB07", "不良率下限")
    sqlCV.SqlFields("TJAB08", "堆積超下限")
    sqlCV.SqlFields("TJAB09", "堆積下限")
    strSQL = BIG2GB(sqlCV.Text)
  End Sub
#End Region
#Region "清空"
  Private Sub dt_Frm_Clear(ByVal s As clsEDIT2012.clsEDITx2013) Handles clsdt.Frm_Clear
    For Each ct In Panel1.Controls
      If TypeOf (ct) Is NumericUpDown Then
        With CType(ct, NumericUpDown)
          .Value = .Minimum
        End With
      End If
    Next
    '-------------------------------------------------
    '這一行加入讓新增能夠運行
    Txtwuliao.Text = ""
    'cmbgx.Enabled = True
    'Txtwuliao.Enabled = True
    'Btnproduct.Enabled = True
  End Sub
#End Region
#Region "刪除"
  Private Sub dt_Frm_Delete(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String, ByRef bolOK As Boolean) Handles clsdt.Frm_Delete
    If MsgBox(BIG2GB("是否刪除數據"), MsgBoxStyle.OkCancel, BIG2GB("提示")) = MsgBoxResult.Ok Then
      Dim sqlCV As New APSQL.SQLCNV
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_delete, "SFIS_TJAB")
      sqlCV.Where("TJAB01", "=", cmbgx.SelectedValue)
      sqlCV.Where("TJAB02", "=", Txtwuliao.Text)
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
  ''保存前檢驗是否合格 ^([1-9]+/d{0,}|\0\.\d+)$
  'Dim reg As New System.Text.RegularExpressions.Regex("^[1-9]{1}/d{0,}$")
  Private Sub dt_isDataValid(ByVal s As clsEDIT2012.clsEDITx2013, ByRef bolOK As Boolean) Handles clsdt.isDataValid
    If Txtwuliao.Text.Trim = "" Then
      MsgBox(BIG2GB("物料編號不得空白"), MsgBoxStyle.OkOnly, BIG2GB("提示"))
      Txtwuliao.Focus()
      Return
    End If
    If cmbgx.SelectedValue Is Nothing OrElse cmbgx.SelectedValue.ToString.Trim = "" Then
      MsgBox(BIG2GB("工序不得空白"), MsgBoxStyle.OkOnly, BIG2GB("提示"))
      cmbgx.Focus()
      Return
    End If
    bolOK = True
  End Sub
#End Region
#Region "dt_Frm_CheckDup保存檢驗數據是否存在"
  '’保存檢驗數據是否存在
  Private Sub dt_Frm_CheckDup(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles clsdt.Frm_CheckDup
    strSQL = "select *  from sfis_TJAB where TJAB01='" & cmbgx.SelectedValue & "' AND TJAB02 ='" & Txtwuliao.Text & "'"
  End Sub
#End Region
#Region "添加"
  Private Sub dt_Frm_InsertM(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles clsdt.Frm_InsertM
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "sfis_TJAB")
    sqlCV.SqlFields("TJAB01", cmbgx.SelectedValue)
    sqlCV.SqlFields("TJAB02", Txtwuliao.Text)
    sqlCV.SqlFields("TJAB03", numgongshi.Text)
    sqlCV.SqlFields("TJAB04", numgongshicx.Text)
    sqlCV.SqlFields("TJAB05", numgongshix.Text)
    sqlCV.SqlFields("TJAB06", Numblcx.Text.Trim)
    sqlCV.SqlFields("TJAB07", Numblx.Text.Trim)
    sqlCV.SqlFields("TJAB08", numdjcx.Text.Trim)
    sqlCV.SqlFields("TJAB09", numdjx.Text.Trim)
    sqlCV.SqlFields("TJAB10", TJAB10.Value.ToString)
    strSQL = sqlCV.Text
    'Btnproduct.Enabled = False
    '---------------------------------------------------------
    '信息非必要，只有增加操作員困擾，你可以參考ERP，他們讓操作員很舒服
    'MsgBox("物料保存成功", MsgBoxStyle.OkOnly, BIG2GB("提示"))
  End Sub
#End Region
#Region "更改"
  Private Sub dt_Frm_UpdateM(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles clsdt.Frm_UpdateM
    Dim sqlCV As New APSQL.SQLCNV
    'If MsgBox("該物料已存在是否保存", MsgBoxStyle.OkCancel, "修改提示") = MsgBoxResult.Ok Then
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_TJAB")
    sqlCV.Where("TJAB01", "=", cmbgx.SelectedValue)
    sqlCV.Where("TJAB02", "=", Txtwuliao.Text)
    sqlCV.SqlFields("TJAB03", numgongshi.Text)
    sqlCV.SqlFields("TJAB04", numgongshicx.Text)
    sqlCV.SqlFields("TJAB05", numgongshix.Text)
    sqlCV.SqlFields("TJAB06", Numblcx.Text.Trim)
    sqlCV.SqlFields("TJAB07", Numblx.Text.Trim)
    sqlCV.SqlFields("TJAB08", numdjcx.Text.Trim)
    sqlCV.SqlFields("TJAB09", numdjx.Text.Trim)
    sqlCV.SqlFields("TJAB10", TJAB10.Value.ToString)
    strSQL = sqlCV.Text
    'Btnproduct.Enabled = False
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

  Private Sub DGjt_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGjt.CellFormatting
    If e.ColumnIndex = 1 Then
      Dim strM As String = GCell(DGjt.Rows(e.RowIndex).Cells(0))
      If strM.StartsWith("@") Then
        If aryTB03.ContainsKey(strM) = True Then
          e.Value = aryTB03(strM)
        Else
          e.Value = strM
        End If
      End If
    End If
  End Sub

  ''行號顯示
  Private Sub DGjt_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGjt.RowPostPaint
    Dim Rectangle As System.Drawing.Rectangle = New System.Drawing.Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, DGjt.RowHeadersWidth - 4, e.RowBounds.Height)
    TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), DGjt.RowHeadersDefaultCellStyle.Font, Rectangle, DGjt.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter & TextFormatFlags.Right)
  End Sub

  Private Sub cmbgx_GotFocus(sender As Object, e As EventArgs) Handles cmbgx.GotFocus
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_distinc, "SFIS_TBB")
    sqlCV.Where("^0.TBB03", "=", Txtwuliao.Text.Trim)
    sqlCV.SqlFields("*")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count = 0 Then
      cmbgx.DataSource = Nothing
      Return
    End If
    Dim strM1 As String = rs.Rows(0)!TBB01.ToString.Trim
    Dim strM2 As String = rs.Rows(0)!TBB02.ToString.Trim
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TB")
    sqlCV.Where("TB01", "=", strM1)
    sqlCV.Where("TB02", "=", strM2)
    Dim w As APSQL.SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TBA", "TBA01", "=", "^0.TB01")
    w.Add("SFIS_TBA.TBA02", "=", "SFIS_TB.TB02")
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TA", "TA01", "=", "SFIS_TBA.TBA04")
    sqlCV.SqlFields("^2.TA01", "KEYS")
    sqlCV.SqlFields("^2.TA01 + ' ' + TA02", "DATAS")
    sqlCV.SqlFields("^0.TB03")
    rs = DB.RsSQL(sqlCV.Text, "TAQ")
    Dim r As DataRow = rs.NewRow
    r.Item(0) = "@" & strM1 & "-" & strM2
    If rs.Rows.Count = 0 Then
      r.Item(1) = BIG2GB("流程:") & strM1 & "-" & strM2
    Else
      r.Item(1) = BIG2GB("流程:") & strM1 & "-" & strM2 & "  " & rs.Rows(0)!TB03.ToString.Trim
    End If
    rs.Rows.InsertAt(r, 0)
    cmbgx.DisplayMember = "DATAS"
    cmbgx.ValueMember = "KEYS"
    cmbgx.DataSource = rs
  End Sub
  ''' <summary>
  ''' 加入這段可以讓輸入Txtmachinecode判斷是否已存在料號
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub Txtmachinecode_Validated(ByVal sender As Object, ByVal e As EventArgs) Handles cmbgx.SelectedValueChanged, Txtwuliao.TextChanged
    For Each r As DataGridViewRow In DGjt.Rows
      Try
        If cmbgx.SelectedValue = r.Cells(0).Value.ToString And Txtwuliao.Text.Trim = r.Cells(2).Value.ToString Then
          dt_DVSelect(Nothing, r)
          DGjt.CurrentCell = r.Cells(0)
          Exit For
        End If
      Catch ex As Exception
      End Try
    Next
  End Sub

  Private Sub Btnproduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnproduct.Click
    Dim Dwuliao_gd As FrmDialog = getwuliao(" ISNULL(TBB01,'')<>''")
    If Dwuliao_gd.ShowDialog = DialogResult.OK Then
      Txtwuliao.Text = GCell(Dwuliao_gd.rw.Cells(0))
      SPEC.Text = GCell(Dwuliao_gd.rw.Cells(3)) & " " & GCell(Dwuliao_gd.rw.Cells(4))
    End If
  End Sub
End Class