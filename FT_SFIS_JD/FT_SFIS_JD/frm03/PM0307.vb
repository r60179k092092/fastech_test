Imports APSQL
Public Class PM0307
  Dim WithEvents clsdt As clsEDIT2012.clsEDITx2013
#Region "load  and close"
  Sub New()
    ' 此調用是設計器所必需的。
    InitializeComponent()
    ' 在 InitializeComponent() 調用之后添加任何初始化。
    languagechange(Me)
    dgdaochu(DGXM)
  End Sub
  Private Sub DownExcel()
    Dim OFL As New OpenFileDialog
    Dim sqlCV As New SQLCNV
    OFL.Title = BIG2GB("請選擇一個導入Excel資料")
    OFL.Filter = BIG2GB("Excel|*.xls;*.xlsx|所有檔案|*.*")
    OFL.FileName = ""
    If OFL.ShowDialog = Windows.Forms.DialogResult.OK Then
      Dim xlsF As New XLS_FILE(OFL.FileName)
      Dim rs As DataTable = xlsF.XLS2Rs(0)
      If rs.Columns.Count = 6 Then
        For Each r As DataRow In rs.Rows
          sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_TF")
          sqlCV.Where("TF01", "=", r.Item(0).ToString.Trim)
          sqlCV.SqlFields("TF02", r.Item(1).ToString.Trim)
          sqlCV.SqlFields("TF03", r.Item(2).ToString.Trim)
          sqlCV.SqlFields("TF04", r.Item(3).ToString.Trim)
          Dim strK() As String = r.Item(4).ToString.Trim.Split((vbTab & vbCrLf).ToCharArray)
          Dim strM As String = ""
          For Each strS As String In strK
            If strS.Trim = "" Then Continue For
            strM &= strS.Trim & "^"
          Next
          sqlCV.SqlFields("TF05", strM.Trim("^"))
          sqlCV.SqlFields("TF06", r.Item(5).ToString.Trim)
          Dim intL As Integer = DB.RsSQL(sqlCV.Text)
          If intL = 0 Then
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_TF")
            sqlCV.SqlFields("TF01", r.Item(0).ToString.Trim)
            sqlCV.SqlFields("TF02", r.Item(1).ToString.Trim)
            sqlCV.SqlFields("TF03", r.Item(2).ToString.Trim)
            sqlCV.SqlFields("TF04", r.Item(3).ToString.Trim)
            sqlCV.SqlFields("TF05", strM.Trim("^"))
            sqlCV.SqlFields("TF06", r.Item(5).ToString.Trim)
            DB.RsSQL(sqlCV.Text)
          End If
        Next
      End If
      xlsF.Quit()
      MsgBox(BIG2GB("導入成功"))
      clsdt.Updated = True
      clsdt.Clean()
    End If
  End Sub

  Private Sub PM0307_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
    If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
      If Me.ActiveControl.Name = "TextBox2" Then Return
      e.Handled = True
      My.Computer.Keyboard.SendKeys(vbTab)
    End If
  End Sub
  '' load
  Private Sub FrmJCwuliao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.WindowState = FormWindowState.Maximized
    clsdt = New clsEDIT2012.clsEDITx2013(DGXM, DB, language)
    clsdt.InsertToolsItem(3, BIG2GB("Excel導入"), My.Resources.XDOWN, AddressOf DownExcel)
    Me.KeyPreview = True
    DGXM.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlLight
    clsdt.Clean()
    '-------------------------------------------------------------
    '自動定位到這一個編輯清單，讓操作者更方便運作數據
    clsdt.AddKeyColumns(BIG2GB("不良現象代碼")) ''保存后自動定位到 dg
    clsdt.GetToolsItem("Delete").Enabled = clsRTS.GetRight(Me.Tag & "/003")
    clsdt.GetToolsItem("save").Enabled = clsRTS.GetRight(Me.Tag & "/001")
  End Sub

  Private Sub FrmJCwuliao_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
    TuiCK(Me)
  End Sub
#End Region


#Region "選擇 dg"
  Private Sub dt_DVSelect(ByVal s As clsEDIT2012.clsEDITx2013, ByVal r As System.Windows.Forms.DataGridViewRow) Handles clsdt.DVSelect
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TF")
    sqlCV.Where("TF01", "=", GCell(r.Cells(0)))
    sqlCV.SqlFields("*")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count = 0 Then Return
    Dim r1 As DataRow = rs.Rows(0)
    txtreasoncode.Text = r1!TF01.ToString.Trim
    Txtreasonch.Text = r1!TF02.ToString.Trim
    Txtreasonen.Text = r1!TF03.ToString.Trim
    'IIf(r.Cells(3).Value.ToString = "MA", RbtMA.Checked = True, RbtMI.Checked = True)
    For intI As Integer = 0 To ComboBox1.Items.Count - 1
      If ComboBox1.Items(intI).ToString.StartsWith(r1!TF04.ToString.Trim) = True Then
        ComboBox1.SelectedIndex = intI
        Exit For
      End If
    Next
    TextBox1.Text = r1!TF06.ToString.Trim
    TextBox2.Text = r1!TF05.ToString.Trim.Replace("^", vbCrLf)
    '------------------------------------------------
    '這一行加入可以確保編號不被覆蓋
    txtreasoncode.Enabled = False
    '-------------------------------------------------
  End Sub
#End Region
#Region "dvtable"
  Private Sub dt_DVTable(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles clsdt.DVTable
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TF")
    sqlCV.SqlFields("TF01", BIG2GB("不良現象代碼"))
    sqlCV.SqlFields("TF02", BIG2GB("不良現象中文"))
    sqlCV.SqlFields("TF03", BIG2GB("不良現象英文"))
    sqlCV.SqlFields("TF04", BIG2GB("缺陷程度"))
    sqlCV.SqlFields("TF05", BIG2GB("詳細不良明細"))
    sqlCV.SqlFields("TF06", BIG2GB("備註"))
    strSQL = sqlCV.Text
  End Sub
#End Region
#Region "清空"
  Private Sub dt_Frm_Clear(ByVal s As clsEDIT2012.clsEDITx2013) Handles clsdt.Frm_Clear
    For Each ct In GroupBox1.Controls
      If TypeOf (ct) Is TextBox Then ct.text = ""
    Next
    ComboBox1.SelectedIndex = 0
    '-------------------------------------------------
    '這一行加入讓新增能夠運行
    txtreasoncode.Enabled = True
  End Sub
#End Region
#Region "刪除"
  Private Sub dt_Frm_Delete(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String, ByRef bolOK As Boolean) Handles clsdt.Frm_Delete
    If MsgBox(BIG2GB("是否刪除數據：") & txtreasoncode.Text, MsgBoxStyle.OkCancel, BIG2GB("提示")) = MsgBoxResult.Ok Then
      Dim sqlCV As New APSQL.SQLCNV
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_delete, "SFIS_TF")
      sqlCV.Where("TF01", "=", txtreasoncode.Text)
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
    If txtreasoncode.TextLength < 2 Then
      MsgBox(BIG2GB("請輸入不良現象代碼"), MsgBoxStyle.OkOnly, BIG2GB("提示"))
      txtreasoncode.Focus()
      Return
    End If
    '物料型號非必要
    If Txtreasonch.Text.Trim.Length = 0 Then
      MsgBox(BIG2GB("請輸入不良現象中文名稱，不良現象中文名稱不能為空"), MsgBoxStyle.OkOnly, BIG2GB("提示"))
      Txtreasonch.Focus()
      Return
    End If

    bolOK = True
  End Sub
#End Region
#Region "dt_Frm_CheckDup保存檢驗數據是否存在"
  '’保存檢驗數據是否存在
  Private Sub dt_Frm_CheckDup(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles clsdt.Frm_CheckDup
    strSQL = "select *  from SFIS_TF where TF01='" & txtreasoncode.Text & "'"
  End Sub
#End Region
#Region "添加"
  Private Sub dt_Frm_InsertM(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles clsdt.Frm_InsertM
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_TF")
    sqlCV.SqlFields("TF01", txtreasoncode.Text.Trim)
    sqlCV.SqlFields("TF02", Txtreasonch.Text.Trim)
    sqlCV.SqlFields("TF03", Txtreasonen.Text)
    sqlCV.SqlFields("TF04", ComboBox1.Text.ToString.Split(" ")(0))
    sqlCV.SqlFields("TF05", TextBox2.Text.Trim(vbCrLf.ToCharArray).Replace(vbCrLf, "^"))
    sqlCV.SqlFields("TF06", TextBox1.Text.Trim)
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
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_TF")
    sqlCV.Where("TF01", "=", txtreasoncode.Text.Trim)
    sqlCV.SqlFields("TF02", Txtreasonch.Text.Trim)
    sqlCV.SqlFields("TF03", Txtreasonen.Text)
    sqlCV.SqlFields("TF04", ComboBox1.Text.ToString.Split(" ")(0))
    sqlCV.SqlFields("TF05", TextBox2.Text.Trim(vbCrLf.ToCharArray).Replace(vbCrLf, "^"))
    sqlCV.SqlFields("TF06", TextBox1.Text.Trim)
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
  Private Sub dgblzr_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGXM.RowPostPaint

  End Sub
  ''' <summary>
  ''' 加入這段可以讓輸入txtREASONcode判斷是否已存在料號
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub txtREASONcode_Validated(ByVal sender As Object, ByVal e As EventArgs) Handles txtreasoncode.Validated
    For Each r As DataGridViewRow In DGXM.Rows
      If txtreasoncode.Text.Trim = r.Cells(0).Value.ToString Then
        dt_DVSelect(Nothing, r)
        DGXM.CurrentCell = r.Cells(0)
        Exit For
      End If
    Next
  End Sub
End Class