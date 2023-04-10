Public Class PM0309
  Dim WithEvents clsdt As clsEDIT2012.clsEDITx2013
#Region "load  and close"
  Sub New()
    ' 此调用是设计器所必需的。
    InitializeComponent()
    ' 在 InitializeComponent() 调用之后添加任何初始化。
    languagechange(Me)
    dgdaochu(dgblzr)
  End Sub
  '' load
  Private Sub FrmJCwuliao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.WindowState = FormWindowState.Maximized
    clsdt = New clsEDIT2012.clsEDITx2013(dgblzr, DB, language)
    Me.KeyPreview = True
    dgblzr.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlLight
    clsdt.Clean()
    '-------------------------------------------------------------
    '自動定位到這一個編輯清單，讓操作者更方便運作數據
    clsdt.AddKeyColumns(BIG2GB("不良原因代碼")) ''保存后自動定位到 dg
    clsdt.GetToolsItem("Delete").Enabled = clsRTS.GetRight(Me.Tag & "/003")
    clsdt.GetToolsItem("save").Enabled = clsRTS.GetRight(Me.Tag & "/001")
  End Sub

  Private Sub FrmJCwuliao_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
    TuiCK(Me)
  End Sub
  '’_KeyDown
  Private Sub FrmJCwuliao_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    If e.KeyCode = 13 Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
  End Sub
#End Region


#Region "選擇 dg"
  Private Sub dt_DVSelect(ByVal s As clsEDIT2012.clsEDITx2013, ByVal r As System.Windows.Forms.DataGridViewRow) Handles clsdt.DVSelect
    Txtdutycode.Text = r.Cells(0).Value.ToString
    Txtdutych.Text = r.Cells(1).Value.ToString
    Txtdutyen.Text = r.Cells(2).Value.ToString
    '------------------------------------------------
    '這一行加入可以確保編號不被覆蓋
    Txtdutycode.Enabled = False
    '-------------------------------------------------
  End Sub
#End Region
#Region "dvtable"
  Private Sub dt_DVTable(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles clsdt.DVTable
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TG")
    sqlCV.SqlFields("TG01", BIG2GB("不良原因代碼"))
    sqlCV.SqlFields("TG02", BIG2GB("不良原因中文"))
    sqlCV.SqlFields("TG03", BIG2GB("不良原因英文"))
    strSQL = sqlCV.Text
  End Sub
#End Region
#Region "清空"
  Private Sub dt_Frm_Clear(ByVal s As clsEDIT2012.clsEDITx2013) Handles clsdt.Frm_Clear
    For Each ct In GroupBox1.Controls
      If TypeOf (ct) Is TextBox Then ct.text = ""
    Next
    '-------------------------------------------------
    '這一行加入讓新增能夠運行
    Txtdutycode.Enabled = True
  End Sub
#End Region
#Region "刪除"
  Private Sub dt_Frm_Delete(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String, ByRef bolOK As Boolean) Handles clsdt.Frm_Delete
    If MsgBox("是否刪除數據" & ":" & Txtdutycode.Text, MsgBoxStyle.OkCancel, BIG2GB("提示")) = MsgBoxResult.Ok Then
      Dim sqlCV As New APSQL.SQLCNV
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_delete, "SFIS_TG")
      sqlCV.Where("TG01", "=", Txtdutycode.Text)
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
    If Txtdutycode.Text.Trim.Length < 2 Then
      MsgBox(BIG2GB("請輸入責任代碼"), MsgBoxStyle.OkOnly, BIG2GB("提示"))
      Txtdutycode.Focus()
      Return
    End If
    '物料型號非必要
    If Txtdutych.Text.Trim.Length = 0 Then
      MsgBox(BIG2GB("請輸入責任中文名稱，責任中文名稱不能為空"), MsgBoxStyle.OkOnly, BIG2GB("提示"))
      Txtdutych.Focus()
      Return
    End If

    bolOK = True
  End Sub
#End Region
#Region "dt_Frm_CheckDup保存檢驗數據是否存在"
  '’保存檢驗數據是否存在
  Private Sub dt_Frm_CheckDup(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles clsdt.Frm_CheckDup
    strSQL = "select *  from SFIS_TG where TG01='" & Txtdutycode.Text & "'"
  End Sub
#End Region
#Region "添加"
  Private Sub dt_Frm_InsertM(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles clsdt.Frm_InsertM
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "SFIS_TG")
    sqlCV.SqlFields("TG01", Txtdutycode.Text.Trim)
    sqlCV.SqlFields("TG02", Txtdutych.Text.Trim)
    sqlCV.SqlFields("TG03", Txtdutyen.Text)

    strSQL = sqlCV.Text
    '---------------------------------------------------------
    '信息非必要，只有增加操作員困擾，你可以參考ERP，他們讓操作員很舒服
    'MsgBox("物料保存成功", MsgBoxStyle.OkOnly, BIG2GB("提示"))
  End Sub
#End Region
#Region "更改"
  Private Sub dt_Frm_UpdateM(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles clsdt.Frm_UpdateM
    Dim sqlCV As New APSQL.SQLCNV
    'If MsgBox("該物料已存在是否保存", MsgBoxStyle.OkCancel, "修改提示") = MsgBoxResult.Ok Then
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_update, "SFIS_TG")
    sqlCV.Where("TG01", "=", Txtdutycode.Text.Trim)
    sqlCV.SqlFields("TG02", Txtdutych.Text.Trim)
    sqlCV.SqlFields("TG03", Txtdutyen.Text)

    strSQL = sqlCV.Text
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
  Private Sub dgblzr_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgblzr.RowPostPaint
    Dim Rectangle As System.Drawing.Rectangle = New System.Drawing.Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dgblzr.RowHeadersWidth - 4, e.RowBounds.Height)
    TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dgblzr.RowHeadersDefaultCellStyle.Font, Rectangle, dgblzr.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter & TextFormatFlags.Right)
  End Sub
  ''' <summary>
  ''' 加入這段可以讓輸入txtdutycode判斷是否已存在料號
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub txtdutycode_Validated(ByVal sender As Object, ByVal e As EventArgs) Handles Txtdutycode.Validated
    For Each r As DataGridViewRow In dgblzr.Rows
      If Txtdutycode.Text.Trim = r.Cells(0).Value.ToString Then
        dt_DVSelect(Nothing, r)
        dgblzr.CurrentCell = r.Cells(0)
        Exit For
      End If
    Next
  End Sub
End Class