Imports APSQL
Public Class PM0310
  Dim WithEvents clsdt As clsEDIT2012.clsEDITx2013
  'Dim Ddanwei As FrmDialog
  'Dim Dzhonglei As FrmDialog
  Dim Dliucheng As FrmDialog
  Private strLAB As String = ""
#Region "load  and close"
  Sub New()
    ' 此調用是設計器所必需的。
    InitializeComponent()
    ' 在 InitializeComponent() 調用之后添加任何初始化。
    languagechange(Me)
    dgdaochu(DGwl)
  End Sub
#If GF = 0 Then
  Private Sub DownErp()
    Me.Enabled = False
    Dim bolT As Boolean = False
    If MsgBox(BIG2GB("從ERP匯入物料編號，是否要更新已導入部分"), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
      bolT = True
    End If
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TBB")
    sqlCV.SqlFields("TBB03")
    sqlCV.SqlFields("TBB05")
    sqlCV.SqlFields("TBB06")
    sqlCV.SqlFields("TBB07")
    sqlCV.SqlFields("TBB08")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    Dim aryT As New Dictionary(Of String, DataRow)
    For Each r As DataRow In rs.Rows
      aryT.Add(r!TBB03.ToString.Trim, r)
    Next
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "PRDT")
    sqlCV.SqlFields("PRD_NO")
    sqlCV.SqlFields("NAME")
    sqlCV.SqlFields("SPC")
    sqlCV.SqlFields("UT")
    sqlCV.SqlFields("UT1")
    sqlCV.SqlFields("DFU_UT")
    sqlCV.SqlFields("KND")
    Dim rs1 As DataTable = DBERP.RsSQL(sqlCV.Text, "RT")
    PB.Maximum = rs1.Rows.Count
    PB.Minimum = 0
    PB.Value = 0
    PBCNT.Text = "0/" & rs1.Rows.Count
    Dim intI As Integer = 0
    Dim strTS As String = ""
    For Each r As DataRow In rs1.Rows
      Dim strUnit As String = r!DFU_UT.ToString.Trim
      If strUnit = "1" Then
        strUnit = r!UT.ToString.Trim
      ElseIf r!UT1.ToString.Trim <> "" Then
        strUnit = r!UT1.ToString.Trim
      End If
      intI += 1
      If (intI Mod 10) = 9 Then
        PB.Value = intI
        PBCNT.Text = intI & "/" & rs1.Rows.Count
        PB.Refresh()
        PBCNT.Refresh()
      End If
      Dim strT As String = r!PRD_NO.ToString.Trim
      If aryT.ContainsKey(strT) = False Then
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_TBB")
        sqlCV.SqlFields("TBB03", strT)
        sqlCV.SqlFields("TBB05", r!NAME.ToString.Trim)
        sqlCV.SqlFields("TBB06", r!SPC.ToString.Trim)
        sqlCV.SqlFields("TBB07", strUnit)
        sqlCV.SqlFields("TBB08", r!KND.ToString.Trim)
        strTS &= sqlCV.Text & ";"
        aryT.Add(strT, Nothing)
      Else
        If bolT Then
          If aryT(strT) IsNot Nothing Then
            If r!NAME.ToString.Trim <> aryT(strT)!TBB05.ToString.Trim Or _
               r!SPC.ToString.Trim <> aryT(strT)!TBB06.ToString.Trim Or _
               strUnit <> aryT(strT)!TBB07.ToString.Trim Or _
               r!KND.ToString.Trim <> aryT(strT)!TBB08.ToString.Trim Then
              sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_TBB")
              sqlCV.Where("TBB03", "=", strT)
              sqlCV.SqlFields("TBB05", r!NAME.ToString.Trim)
              sqlCV.SqlFields("TBB06", r!SPC.ToString.Trim)
              sqlCV.SqlFields("TBB07", strUnit)
              sqlCV.SqlFields("TBB08", r!KND.ToString.Trim)
              strTS &= sqlCV.Text & ";"
            End If
          Else
            MsgBox(BIG2GB("ERP 料號重覆" & strT))
          End If
        End If
      End If
      If strTS.Length > 5000 Then
        DB.RsSQL(strTS)
        strTS = ""
      End If
    Next
    If strTS.Length > 0 Then
      DB.RsSQL(strTS)
      strTS = ""
    End If
    PB.Value = intI
    PBCNT.Text = intI & "/" & rs1.Rows.Count
    Me.Enabled = True
    clsdt.Updated = True
    clsdt.Clean()
  End Sub
#End If
  '' load
  Private Sub FrmJCwuliao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.WindowState = FormWindowState.Maximized
    clsdt = New clsEDIT2012.clsEDITx2013(DGwl, DB, language)
    clsdt.ShowSearch = True
#If GF = 0 Then
    clsdt.InsertToolsItem(3, BIG2GB("ERP導入"), My.Resources.XDOWN, AddressOf DownErp)
#End If
    clsdt.FindColumns = "TBB03+TBB05+TBB06"
    Me.KeyPreview = True
    clsdt.Clean()
    '-------------------------------------------------------------
    '自動定位到這一個編輯清單，讓操作者更方便運作數據
    clsdt.AddKeyColumns(BIG2GB("物料編號")) ''保存后自動定位到 dg
    lod()
#If GF = 0 Then
    clsdt.GetToolsItem("Delete").Enabled = clsRTS.GetRight(Me.Tag & "/003")
#Else
    clsdt.GetToolsItem("Delete").Enabled = False
#End If
    clsdt.GetToolsItem("save").Enabled = clsRTS.GetRight(Me.Tag & "/001")
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", "ICLASS")
    sqlCV.SqlFields("QTN02", , , , True)
    sqlCV.SqlFields("QTN02+' '+QTN03", "DATAS")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RCLS")
    txtZL.DisplayMember = "DATAS"
    txtZL.ValueMember = "QTN02"
    txtZL.DataSource = rs
    If rs.Rows.Count > 0 Then
      txtZL.SelectedValue = rs.Rows(0)!QTN02.ToString.Trim
    End If
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", "UNIT")
    sqlCV.SqlFields("QTN02", , , , True)
    rs = DB.RsSQL(sqlCV.Text, "RUNT")
    txtDw.DisplayMember = "QTN02"
    txtDw.ValueMember = "QTN02"
    txtDw.DataSource = rs
    If rs.Rows.Count > 0 Then
      txtDw.SelectedValue = rs.Rows(0)!QTN02.ToString.Trim
    End If
  End Sub
  Sub lod()
    '這個寫法，操作員必須Double Click 欄位然後選單，總共要按三下滑鼠
    '使用ComboBox只需按二下滑鼠，我不認為有比較簡單
    '非支持的選單可以使用ComboBox一樣有效，這樣寫並沒有好處。
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TB")
    sqlCV.SqlFields("TB01", "流程編號")
    sqlCV.SqlFields("TB02", "流程版本")
    sqlCV.SqlFields("TB03", "流程說明")
    Dliucheng = New FrmDialog(BIG2GB("流程編號"), BIG2GB(sqlCV.Text) & "$^$")
  End Sub
  '' close
  Private Sub FrmJCwuliao_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    TuiCK(Me)
  End Sub
  '’_KeyDown
  Private Sub FrmJCwuliao_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    If e.KeyCode = 13 Then
      If Me.ActiveControl.Parent.GetType Is GetType(ToolStrip) Then Return
      e.Handled = True
      e.SuppressKeyPress = True
      Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End If
  End Sub
#End Region

#Region "選擇 dg"
  Private Sub ShowDisp(strK As String)
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TBB")
    sqlCV.Where("TBB03", "=", strK.Trim)
    sqlCV.SqlFields("*")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count = 0 Then
      Dim strITNO As String = strK
      dt_Frm_Clear(Nothing)
      Txtwl.Text = strITNO
      Txtwl.Enabled = False
      Return
    End If
    Txtwl.Text = rs.Rows(0)!TBB03.ToString.Trim 'r.Cells(0).Value.ToString
    Txtxh.Text = rs.Rows(0)!TBB04.ToString.Trim 'r.Cells(1).Value.ToString
    Txtsm.Text = rs.Rows(0)!TBB05.ToString.Trim 'r.Cells(2).Value.ToString
    Txtch.Text = rs.Rows(0)!TBB06.ToString.Trim 'r.Cells(3).Value.ToString
    txtDw.SelectedValue = rs.Rows(0)!TBB07.ToString.Trim 'r.Cells(4).Value.ToString
    txtZL.SelectedValue = rs.Rows(0)!TBB08.ToString.Trim 'r.Cells(5).Value.ToString
    Lablcbh.Text = rs.Rows(0)!TBB01.ToString.Trim 'r.Cells(6).Value.ToString
    Lablcbb.Text = rs.Rows(0)!TBB02.ToString.Trim 'r.Cells(7).Value.ToString
    strLAB = rs.Rows(0)!SA14.ToString.Trim
    Txtwl.Enabled = False
    txtZL_SelectionChangeCommitted(Nothing, Nothing)
  End Sub
  Private Sub dt_DVSelect(ByVal s As clsEDIT2012.clsEDITx2013, ByVal r As System.Windows.Forms.DataGridViewRow) Handles clsdt.DVSelect
    ShowDisp(GCell(r.Cells(0)))
  End Sub
#End Region
#Region "dvtable"
  Private Sub dt_DVTable(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles clsdt.DVTable
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TBB", , "TOP 500")
    sqlCV.SqlFields("TBB03", BIG2GB("物料編號"))
    sqlCV.SqlFields("TBB04", BIG2GB("型號"))
    sqlCV.SqlFields("TBB05", BIG2GB("說明"))
    sqlCV.SqlFields("TBB06", BIG2GB("規格"))
    sqlCV.SqlFields("TBB07", BIG2GB("單位"))
    sqlCV.SqlFields("TBB08", BIG2GB("種類"))
    sqlCV.SqlFields("TBB01", BIG2GB("流程編號"))
    sqlCV.SqlFields("TBB02", BIG2GB("流程版本"))
    strSQL = sqlCV.Text
  End Sub
#End Region
#Region "清空"
  Private Sub dt_Frm_Clear(ByVal s As clsEDIT2012.clsEDITx2013) Handles clsdt.Frm_Clear
    For Each ct In Panel1.Controls
      If TypeOf (ct) Is TextBox Then ct.text = ""
    Next
    Lablcbb.Text = ""
    Lablcbh.Text = ""
    Txtwl.Text = ""
    Dim rs As DataTable = txtZL.DataSource
    If rs IsNot Nothing AndAlso rs.Rows.Count > 0 Then
      txtZL.SelectedValue = rs.Rows(0)!QTN02.ToString.Trim
    End If
    rs = txtDw.DataSource
    If rs IsNot Nothing AndAlso rs.Rows.Count > 0 Then
      txtDw.SelectedValue = rs.Rows(0)!QTN02.ToString.Trim
    End If
    '-------------------------------------------------
    '這一行加入讓新增能夠運行
    Txtwl.Enabled = True
  End Sub
#End Region
#Region "刪除"
  Private Sub dt_Frm_Delete(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String, ByRef bolOK As Boolean) Handles clsdt.Frm_Delete
    If MsgBox(BIG2GB("是否刪除數據") & Txtwl.Text, MsgBoxStyle.OkCancel, BIG2GB("提示")) = MsgBoxResult.Ok Then
      Dim sqlCV As New APSQL.SQLCNV
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_delete, "Sfis_tbb")
      sqlCV.Where("tbb03", "=", Txtwl.Text)
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
    If Txtwl.Text.Trim.Length = 0 Then
      MsgBox(BIG2GB("物料編號不得為空"), MsgBoxStyle.OkOnly, BIG2GB("提示"))
      Txtwl.Focus()
      Return
    End If
    '物料型號非必要
    'If Txtxh.Text.Trim.Length = 0 Then
    '  MsgBox("請輸入物料型號，物料型號不能為空", MsgBoxStyle.OkOnly, BIG2GB("提示"))
    '  Txtxh.Focus()
    '  Return
    'End If
    If txtZL.SelectedValue Is Nothing Then
      MsgBox(BIG2GB("種類不得為空"), MsgBoxStyle.OkOnly, BIG2GB("提示"))
      txtZL.Focus()
      Return
    End If
    If txtDw.SelectedValue Is Nothing Then
      MsgBox(BIG2GB("單位不得為空"), MsgBoxStyle.OkOnly, BIG2GB("提示"))
      txtDw.Focus()
      Return
    End If
    bolOK = True
  End Sub
#End Region
#Region "dt_Frm_CheckDup保存檢驗數據是否存在"
  '’保存檢驗數據是否存在
  Private Sub dt_Frm_CheckDup(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles clsdt.Frm_CheckDup
    strSQL = "select *  from sfis_tbb where tbb03='" & Txtwl.Text & "'"
  End Sub
#End Region
#Region "添加"
  Private Sub dt_Frm_InsertM(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles clsdt.Frm_InsertM
    Dim sqlCV As New APSQL.SQLCNV
#If GF = 1 Then
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "WMSA")
    sqlCV.SqlFields("SA01", Txtwl.Text.Trim)
    sqlCV.SqlFields("SA15", Txtxh.Text.Trim)
    sqlCV.SqlFields("SA02", Txtsm.Text.Trim)
    sqlCV.SqlFields("SA03", Txtch.Text.Trim)
    sqlCV.SqlFields("SA05", txtDw.SelectedValue.ToString)
    sqlCV.SqlFields("SA04", txtZL.SelectedValue.ToString)
    sqlCV.SqlFields("SA12", Lablcbh.Text.Trim)
    sqlCV.SqlFields("SA13", Lablcbb.Text.Trim)
#Else
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "sfis_tbb")
    sqlCV.SqlFields("TBB03", Txtwl.Text.Trim)
    sqlCV.SqlFields("TBB04", Txtxh.Text.Trim)
    sqlCV.SqlFields("TBB05", Txtsm.Text.Trim)
    sqlCV.SqlFields("TBB06", Txtch.Text.Trim)
    sqlCV.SqlFields("TBB07", Txtdw.Text.Trim)
    sqlCV.SqlFields("TBB08", Txtzl.Text.Trim)
    sqlCV.SqlFields("TBB01", Lablcbh.Text.Trim)
    sqlCV.SqlFields("TBB02", Lablcbb.Text.Trim)
#End If
    strSQL = sqlCV.Text
  End Sub
#End Region
#Region "更改"
  Private Sub dt_Frm_UpdateM(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles clsdt.Frm_UpdateM
    Dim sqlCV As New APSQL.SQLCNV
    'If MsgBox("該物料已存在是否保存", MsgBoxStyle.OkCancel, "修改提示") = MsgBoxResult.Ok Then
#If GF = 1 Then
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "WMSA")
    sqlCV.Where("SA01", "=", Txtwl.Text.Trim)
    sqlCV.SqlFields("SA15", Txtxh.Text.Trim)
    sqlCV.SqlFields("SA02", Txtsm.Text.Trim)
    sqlCV.SqlFields("SA03", Txtch.Text.Trim)
    sqlCV.SqlFields("SA05", txtDw.SelectedValue.ToString.Trim)
    sqlCV.SqlFields("SA04", txtZL.SelectedValue.ToString.Trim)
    sqlCV.SqlFields("SA12", Lablcbh.Text.Trim)
    sqlCV.SqlFields("SA13", Lablcbb.Text.Trim)
#Else
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "sfis_tbb")
    sqlCV.Where("TBB03", "=", Txtwl.Text.Trim)
    sqlCV.SqlFields("TBB04", Txtxh.Text.Trim)
    sqlCV.SqlFields("TBB05", Txtsm.Text.Trim)
    sqlCV.SqlFields("TBB06", Txtch.Text.Trim)
    sqlCV.SqlFields("TBB07", Txtdw.Text.Trim)
    sqlCV.SqlFields("TBB08", Txtzl.Text.Trim)
    sqlCV.SqlFields("TBB01", Lablcbh.Text.Trim)
    sqlCV.SqlFields("TBB02", Lablcbb.Text.Trim)
#End If
    strSQL = sqlCV.Text
  End Sub
#End Region
#Region "dt_DV_HasError"
  Private Sub dt_DV_HasError(ByVal s As clsEDIT2012.clsEDITx2013, ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles clsdt.DV_HasError

  End Sub
#End Region
#Region "選擇流程"
  ''選擇流程
  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectflow.Click
    If Dliucheng.ShowDialog() = DialogResult.OK Then
      Lablcbb.Text = Dliucheng.rw.Cells(1).Value.ToString
      Lablcbh.Text = Dliucheng.rw.Cells(0).Value.ToString
    Else
      Lablcbh.Text = ""
      Lablcbb.Text = ""
    End If
  End Sub
#End Region
  Private Sub DGwl_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGwl.RowPostPaint
    Dim Rectangle As System.Drawing.Rectangle = New System.Drawing.Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, DGwl.RowHeadersWidth - 4, e.RowBounds.Height)
    TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), DGwl.RowHeadersDefaultCellStyle.Font, Rectangle, DGwl.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter & TextFormatFlags.Right)
  End Sub
  ''' <summary>
  ''' 加入這段可以讓輸入Txtwl判斷是否已存在料號
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub Txtwl_Validated(ByVal sender As Object, ByVal e As EventArgs) Handles Txtwl.TextChanged
    ShowDisp(Txtwl.Text.Trim)
  End Sub

  Private Sub DGwl_Scroll(sender As Object, e As ScrollEventArgs) Handles DGwl.Scroll
    DGwl.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
  End Sub

  Private Sub txtZL_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles txtZL.SelectionChangeCommitted
    If txtZL.SelectedValue Is Nothing Then Return
    Txtxh.ReadOnly = False
    C1003.Visible = False
    C1010.Visible = False
    Panel3.Visible = False
    Select Case txtZL.SelectedValue.ToString.Trim
      Case "1003", "1004"
        Txtxh.ReadOnly = True
        C1003.Visible = True
        Panel3.Visible = True
        C1003.SetLabSpec(Txtwl.Text.Trim, Txtsm.Text.Trim, strLAB)
        Panel3.BackgroundImage = C1003.GetBmp
      Case "1010"
        Txtxh.ReadOnly = True
        C1010.Visible = True
        Panel3.Visible = True
        C1010.SetLabSpec(Txtwl.Text.Trim, Txtsm.Text.Trim, strLAB)
        Panel3.BackgroundImage = C1010.GetBmp
    End Select
  End Sub
End Class