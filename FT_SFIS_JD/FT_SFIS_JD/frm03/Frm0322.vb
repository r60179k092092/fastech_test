Public Class Frm0322
  Private WithEvents s1 As clsEDIT2012.clsEDITx2013
  Private intUSEQ As Integer = -1

  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()
    languagechange(Me)
    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

  End Sub
  Private Sub DownLoad()
    Dim OFL As New OpenFileDialog
    OFL.Title = BIG2GB("請選擇一個導入Excel資料")
    OFL.Filter = BIG2GB("Excel|*.xls;*.xlsx|所有檔案|*.*")
    OFL.FileName = ""
    If OFL.ShowDialog = Windows.Forms.DialogResult.OK Then
      s1_Frm_Clear(s1)
      Dim xlsF As New XLS_FILE(OFL.FileName)
      Dim rs As DataTable = xlsF.XLS2Rs(0)
      For Each r As DataRow In rs.Rows
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_IE")
        sqlCV.Where("IE01", "=", r.Item(0).ToString.Trim)
        sqlCV.Where("IE03", "=", r.Item(2).ToString.Trim)
        sqlCV.SqlFields("IE02", r.Item(1).ToString.Trim)
        sqlCV.SqlFields("IE04", r.Item(3).ToString.Trim)
        sqlCV.SqlFields("IE05", r.Item(4).ToString.Trim)
        sqlCV.SqlFields("IE06", r.Item(5).ToString.Trim)
        sqlCV.SqlFields("IE07", r.Item(6).ToString.Trim)
        sqlCV.SqlFields("IE08", r.Item(7).ToString.Trim)
        sqlCV.SqlFields("IE09", r.Item(8).ToString.Trim)
        If r.ItemArray.Count > 9 Then
          sqlCV.SqlFields("IE10", r.Item(9).ToString.Trim)
        End If
        Dim intL As Integer = DB.RsSQL(sqlCV.Text)
        If intL = 0 Then
          sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_IE")
          sqlCV.SqlFields("IE01", r.Item(0).ToString.Trim)
          sqlCV.SqlFields("IE03", r.Item(2).ToString.Trim)
          sqlCV.SqlFields("IE02", r.Item(1).ToString.Trim)
          sqlCV.SqlFields("IE04", r.Item(3).ToString.Trim)
          sqlCV.SqlFields("IE05", r.Item(4).ToString.Trim)
          sqlCV.SqlFields("IE06", r.Item(5).ToString.Trim)
          sqlCV.SqlFields("IE07", r.Item(6).ToString.Trim)
          sqlCV.SqlFields("IE08", r.Item(7).ToString.Trim)
          sqlCV.SqlFields("IE09", r.Item(8).ToString.Trim)
          If r.ItemArray.Count > 9 Then
            sqlCV.SqlFields("IE10", r.Item(9).ToString.Trim)
          End If
          DB.RsSQL(sqlCV.Text)
        End If
      Next
      xlsF.Quit()
      s1.Updated = True
      s1.Clean()
      MsgBox(BIG2GB("導入成功"))
    End If
  End Sub

  Private Sub Frm0322_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    TuiCK(Me)
  End Sub

  Private Sub Frm0322_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    s1 = New clsEDIT2012.clsEDITx2013(DG, DB, language) ', False, "SLSFIS_TBB")
    s1.Clean()
    s1.ShowSearch = True
    s1.InsertToolsItem(3, "-", Nothing, Nothing)
    s1.InsertToolsItem(3, BIG2GB("Excel導入"), My.Resources.XDOWN, AddressOf DownLoad)
    s1.GetToolsItem("Delete").Enabled = clsRTS.GetRight(Me.Tag & "/003")
    s1.GetToolsItem("save").Enabled = clsRTS.GetRight(Me.Tag & "/001")
  End Sub

  Private Sub s1_DVSelect(s As clsEDITx2013, r As DataGridViewRow) Handles s1.DVSelect
    intUSEQ = GCell(r.Cells("USEQ"))
    IE01.Text = GCell(r.Cells(0))
    IE02.Text = GCell(r.Cells(1))
    IE03.Text = GCell(r.Cells(2))
    IE04.Text = GCell(r.Cells(3))
    IE05.Text = GCell(r.Cells(4))
    IE06.Text = GCell(r.Cells(5))
    IE07.Text = GCell(r.Cells(6))
    IE08.Text = GCell(r.Cells(7))
    IE09.Text = GCell(r.Cells(8))
    TextBox1.Text = GCell(r.Cells(9))
    IE01.Enabled = False
    IE03.Enabled = False
  End Sub

  Private Sub s1_DVTable(s As clsEDITx2013, ByRef strSQL As String) Handles s1.DVTable
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_IE")
    sqlCV.SqlFields("IE01", "產品名稱")
    sqlCV.SqlFields("IE02", "產品型號")
    sqlCV.SqlFields("IE03", "工程代號")
    sqlCV.SqlFields("IE04", "硬件版本")
    sqlCV.SqlFields("IE05", "軟件版本")
    sqlCV.SqlFields("IE06", "配置版本")
    sqlCV.SqlFields("IE07", "客戶名稱")
    sqlCV.SqlFields("IE08", "客戶料號")
    sqlCV.SqlFields("IE09", "備註")
    sqlCV.SqlFields("IE10", "分件料號")
    sqlCV.SqlFields("USEQ")
    strSQL = sqlCV.Text
    s1.UnVisibles("USEQ")
  End Sub

  Private Sub s1_Frm_CheckDup(s As clsEDITx2013, ByRef strSQL As String) Handles s1.Frm_CheckDup
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_IE")
    If intUSEQ >= 0 Then
      sqlCV.Where("USEQ", "=", intUSEQ, intFMode.msfld_num)
    Else
      sqlCV.Where("IE01", "=", IE01.Text.Trim)
      sqlCV.Where("IE03", "=", IE03.Text.Trim)
    End If
    sqlCV.SqlFields("USEQ")
    strSQL = sqlCV.Text
  End Sub

  Private Sub s1_Frm_Clear(s As clsEDITx2013) Handles s1.Frm_Clear
    intUSEQ = -1
    IE01.Enabled = True
    IE03.Enabled = True
    IE01.Text = ""
    IE02.Text = ""
    IE03.Text = ""
    IE04.Text = ""
    IE05.Text = ""
    IE06.Text = ""
    IE07.Text = ""
    IE08.Text = ""
    IE09.Text = ""
    TextBox1.Text = ""
  End Sub

  Private Sub s1_Frm_Delete(s As clsEDITx2013, ByRef strSQL As String, ByRef bolOK As Boolean) Handles s1.Frm_Delete
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_delete, "SFIS_IE")
    If intUSEQ >= 0 Then
      sqlCV.Where("USEQ", "=", intUSEQ, intFMode.msfld_num)
    Else
      sqlCV.Where("IE01", "=", IE01.Text.Trim)
      sqlCV.Where("IE03", "=", IE03.Text.Trim)
    End If
    strSQL = sqlCV.Text
    bolOK = True
  End Sub

  Private Sub s1_Frm_InsertM(s As clsEDITx2013, ByRef strSQL As String) Handles s1.Frm_InsertM
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_IE")
    sqlCV.SqlFields("IE01", IE01.Text.Trim)
    sqlCV.SqlFields("IE02", IE02.Text.Trim)
    sqlCV.SqlFields("IE03", IE03.Text.Trim)
    sqlCV.SqlFields("IE04", IE04.Text.Trim)
    sqlCV.SqlFields("IE05", IE05.Text.Trim)
    sqlCV.SqlFields("IE06", IE06.Text.Trim)
    sqlCV.SqlFields("IE07", IE07.Text.Trim)
    sqlCV.SqlFields("IE08", IE08.Text.Trim)
    sqlCV.SqlFields("IE09", IE09.Text.Trim)
    sqlCV.SqlFields("IE10", TextBox1.Text.Trim)
    strSQL = sqlCV.Text
  End Sub

  Private Sub s1_Frm_UpdateM(s As clsEDITx2013, ByRef strSQL As String) Handles s1.Frm_UpdateM
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_IE")
    If intUSEQ >= 0 Then
      sqlCV.Where("USEQ", "=", intUSEQ, intFMode.msfld_num)
      sqlCV.SqlFields("IE01", IE01.Text.Trim)
      sqlCV.SqlFields("IE03", IE03.Text.Trim)
    Else
      sqlCV.Where("IE01", "=", IE01.Text.Trim)
      sqlCV.Where("IE03", "=", IE03.Text.Trim)
    End If
    sqlCV.SqlFields("IE02", IE02.Text.Trim)
    sqlCV.SqlFields("IE04", IE04.Text.Trim)
    sqlCV.SqlFields("IE05", IE05.Text.Trim)
    sqlCV.SqlFields("IE06", IE06.Text.Trim)
    sqlCV.SqlFields("IE07", IE07.Text.Trim)
    sqlCV.SqlFields("IE08", IE08.Text.Trim)
    sqlCV.SqlFields("IE09", IE09.Text.Trim)
    sqlCV.SqlFields("IE10", TextBox1.Text.Trim)
    strSQL = sqlCV.Text
  End Sub

  Private Sub s1_isDataValid(s As clsEDITx2013, ByRef bolOK As Boolean) Handles s1.isDataValid
    If IE01.Text.Trim = "" Or IE03.Text.Trim = "" Then
      MsgBox(BIG2GB("客戶名稱或工程代號不得空白"))
      Return
    End If
    bolOK = True
  End Sub

  Private Sub IE01_KeyPress(sender As Object, e As KeyPressEventArgs) Handles IE01.KeyPress, IE02.KeyPress, IE03.KeyPress, _
    IE04.KeyPress, IE05.KeyPress, IE06.KeyPress, IE07.KeyPress, IE08.KeyPress, IE09.KeyPress
    If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
      e.Handled = True
      My.Computer.Keyboard.SendKeys(vbTab)
    End If
  End Sub

  Private Sub IE01_LostFocus(sender As Object, e As EventArgs) Handles IE01.LostFocus, IE03.LostFocus
    If IE01.Text.Trim <> "" And IE03.Text.Trim <> "" Then
      For Each r As DataGridViewRow In DG.Rows
        If GCell(r.Cells(0)) = IE01.Text.Trim And GCell(r.Cells(2)) = IE03.Text.Trim Then
          s1_DVSelect(s1, r)
          Return
        End If
      Next
      IE01.Enabled = False
      IE03.Enabled = False
      intUSEQ = -1
    End If
  End Sub

  Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    Dim Dwuliao As FrmDialog = getwuliao(" ISNULL(TBB01,'') = ''")
    If Dwuliao.ShowDialog = DialogResult.OK Then
      TextBox1.Text = GCell(Dwuliao.rw.Cells(0))
    End If
  End Sub
End Class