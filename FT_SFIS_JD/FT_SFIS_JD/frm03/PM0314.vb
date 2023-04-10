Imports APSQL
Public Class PM0314
  Dim WithEvents clsdt As clsEDIT2012.clsEDITx2013
#Region "load  and close"
  Sub New()
    ' 此调用是设计器所必需的。
    InitializeComponent()
    ' 在 InitializeComponent() 调用之后添加任何初始化。
    languagechange(Me)
  End Sub
  '' load
  Private Sub PM0314_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.WindowState = FormWindowState.Maximized
    clsdt = New clsEDIT2012.clsEDITx2013(DGgys, DB, language)
    DGgys.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlLight
    clsdt.Clean()
    clsdt.GetToolsItem("DELETE").Enabled = clsRTS.GetRight(Me.Tag & "/003")
    clsdt.GetToolsItem("SAVE").Enabled = clsRTS.GetRight(Me.Tag & "/001")
  End Sub
  '' close
  Private Sub PM0314_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
    TuiCK(Me)
  End Sub
  '’_KeyDown
  Private Sub PM0314_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    If e.KeyCode = 13 Then
      e.Handled = True
      Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End If
  End Sub
#End Region

  Private Sub dt_DVSelect(ByVal s As clsEDIT2012.clsEDITx2013, ByVal r As System.Windows.Forms.DataGridViewRow) Handles clsdt.DVSelect
    Txtname.Text = r.Cells(0).Value.ToString
    Txtshortname.Text = r.Cells(1).Value.ToString
    Txtcode.Text = r.Cells(2).Value.ToString
    Txtallname.Text = r.Cells(3).Value.ToString
    Txtcontacts.Text = r.Cells(4).Value.ToString
    Txtphone.Text = r.Cells(5).Value.ToString
    Txtfax.Text = r.Cells(6).Value.ToString
    Txtaddress.Text = r.Cells(7).Value.ToString
    Cmblevel.SelectedIndex = Cmblevel.Items.IndexOf(r.Cells(8).FormattedValue) '  MsgBox(r.Cells(8).FormattedValue, MsgBoxStyle.OkCancel, r.Cells(8).Value)
    Txtname.Enabled = False
  End Sub

  Private Sub dt_DVTable(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles clsdt.DVTable
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TCA")
    sqlCV.SqlFields("TCA01", "供應商編號")
    sqlCV.SqlFields("TCA02", "簡稱")
    sqlCV.SqlFields("TCA03", "分類")
    sqlCV.SqlFields("TCA04", "全名")
    sqlCV.SqlFields("TCA05", "聯絡人")
    sqlCV.SqlFields("TCA06", "電話")
    sqlCV.SqlFields("TCA07", "傳真")
    sqlCV.SqlFields("TCA08", "地址")
    sqlCV.SqlFields("TCA09", "檢驗等級")
    strSQL = BIG2GB(sqlCV.Text)
  End Sub

  Private Sub dt_Frm_Clear(ByVal s As clsEDIT2012.clsEDITx2013) Handles clsdt.Frm_Clear
    For Each ct In Panel1.Controls
      If TypeOf (ct) Is TextBox Then ct.text = ""
    Next
    Cmblevel.SelectedText = 0
    Txtname.Enabled = True
  End Sub
  Private Sub dt_Frm_Delete(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String, ByRef bolOK As Boolean) Handles clsdt.Frm_Delete
    If MsgBox(BIG2GB("是否刪除數據"), MsgBoxStyle.OkCancel, BIG2GB("提示")) = MsgBoxResult.Ok Then
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_delete, "SFIS_TCA")
      sqlCV.Where("TCA01", "=", Txtname.Text)
      strSQL = sqlCV.Text
      bolOK = True
    End If
  End Sub

  ''保存前檢驗是否合格 
  Private Sub dt_isDataValid(ByVal s As clsEDIT2012.clsEDITx2013, ByRef bolOK As Boolean) Handles clsdt.isDataValid
    If Txtname.Text.Trim.Length = 0 Then
      MsgBox(BIG2GB("供應商編號不得空白"), MsgBoxStyle.OkOnly, BIG2GB("提示"))
      Txtname.Focus()
      Return
    End If
    If Txtshortname.Text.Trim.Length = 0 Then
      MsgBox(BIG2GB("供應商簡稱不得空白"), MsgBoxStyle.OkOnly, BIG2GB("提示"))
      Txtshortname.Focus()
      Return
    End If
    bolOK = True
  End Sub
  '’保存檢驗數據是否存在
  Private Sub dt_Frm_CheckDup(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles clsdt.Frm_CheckDup
    strSQL = "select *  from sfis_TCA where TCA01='" & Txtname.Text.Trim & "'"
  End Sub
  Private Sub dt_Frm_InsertM(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles clsdt.Frm_InsertM
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "sfis_TCA")
    sqlCV.SqlFields("TCA01", Txtname.Text.Trim)
    sqlCV.SqlFields("TCA02", Txtshortname.Text.Trim)
    sqlCV.SqlFields("TCA03", Txtcode.Text.Trim)
    sqlCV.SqlFields("TCA04", Txtallname.Text.Trim)
    sqlCV.SqlFields("TCA05", Txtcontacts.Text.Trim)
    sqlCV.SqlFields("TCA06", Txtphone.Text.Trim)
    sqlCV.SqlFields("TCA07", Txtfax.Text.Trim)
    sqlCV.SqlFields("TCA08", Txtaddress.Text.Trim)
    sqlCV.SqlFields("TCA09", cmbdengji)
    strSQL = sqlCV.Text
  End Sub
  Private Sub dt_Frm_UpdateM(ByVal s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles clsdt.Frm_UpdateM
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "sfis_TCA")
    sqlCV.Where("TCA01", "=", Txtname.Text.Trim)
    sqlCV.SqlFields("TCA02", Txtshortname.Text.Trim)
    sqlCV.SqlFields("TCA03", Txtcode.Text.Trim)
    sqlCV.SqlFields("TCA04", Txtallname.Text.Trim)
    sqlCV.SqlFields("TCA05", Txtcontacts.Text.Trim)
    sqlCV.SqlFields("TCA06", Txtphone.Text.Trim)
    sqlCV.SqlFields("TCA07", Txtfax.Text.Trim)
    sqlCV.SqlFields("TCA08", Txtaddress.Text.Trim)
    sqlCV.SqlFields("TCA09", cmbdengji)
    strSQL = sqlCV.Text
  End Sub
#Region "dt_DV_HasError"
  Private Sub dt_DV_HasError(ByVal s As clsEDIT2012.clsEDITx2013, ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles clsdt.DV_HasError

  End Sub
#End Region
  Private Sub Txtwl_Validated(ByVal sender As Object, ByVal e As EventArgs) Handles Txtname.Validated
    For Each r As DataGridViewRow In DGgys.Rows
      If Txtname.Text.Trim = GCell(r.Cells(0)) Then
        dt_DVSelect(Nothing, r)
        DGgys.CurrentCell = r.Cells(0)
        Exit For
      End If
    Next
  End Sub

  ''行號顯示
  Private Sub DGwl_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGgys.RowPostPaint
    Dim Rectangle As System.Drawing.Rectangle = New System.Drawing.Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, DGgys.RowHeadersWidth - 4, e.RowBounds.Height)
    TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), DGgys.RowHeadersDefaultCellStyle.Font, Rectangle, DGgys.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter & TextFormatFlags.Right)
  End Sub

  ''檢驗等級轉換
  Function cmbdengji() As Int16
    Select Case Cmblevel.SelectedIndex
      Case 0
      Case 1 : Return -1
      Case 2 : Return 0
      Case 3 : Return 1
      Case 4 : Return 9
    End Select
    Return 0
  End Function
  Private Sub DGgys_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGgys.CellFormatting
    If e.ColumnIndex = 8 Then
      Select Case e.Value
        'Case -1
        '    e.Value = "減量"
        'Case 0
        '    e.Value = "標準"
        'Case 1
        '    e.Value = "加嚴"
        Case 9
          e.Value = Cmblevel.Items(3)
        Case Else
          e.Value = Cmblevel.Items(e.Value + 1)
      End Select
    End If
  End Sub

End Class