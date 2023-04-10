Public Class Frm0605
  Private WithEvents cs As clsEDIT2012.clsEDITx2013
  Dim ZD As ZDCMDS = Nothing
  Dim ZDT As ZDCMDTable = Nothing
  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()
    languagechange(Me)
    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

  End Sub

  Private Sub FrmTG00_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    TuiCK(Me)
  End Sub
  Private Sub FrmTG00_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    ZD = New ZDCMDS
    ZDT = New ZDCMDTable
    ZDT.DGS = DG2
    ZDT.CMDS = ZD
    cs = New clsEDIT2012.clsEDITx2013(DG, DB, language)
    cs.Clean()
    DG1.DataSource = ZD.GetAllCmd
    DG1.Columns(0).Visible = False
    DG1.Columns(2).Visible = False
  End Sub
  Private Sub cs_DVSelect(s As clsEDIT2012.clsEDITx2013, r As DataGridViewRow) Handles cs.DVSelect
    Dim sqlcv As New APSQL.SQLCNV
    sqlcv.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlcv.Where("QTN01", "=", "#SMTCMDS")
    sqlcv.Where("QTN02", "=", GCell(r.Cells(0)))
    sqlcv.SqlFields("QTN02")
    sqlcv.SqlFields("QTN03")
    sqlcv.SqlFields("QTN04")
    Dim rs As DataTable = DB.RsSQL(sqlcv.Text, "RT")
    If rs.Rows.Count = 0 Then
      TextBox1.Text = GCell(r.Cells(0))
      TextBox6.Text = GCell(r.Cells(1))
      TextBox5.Text = ""
    Else
      TextBox1.Text = rs.Rows(0)!QTN02.ToString.Trim
      TextBox6.Text = rs.Rows(0)!QTN03.ToString.Trim
      TextBox5.Text = rs.Rows(0)!QTN04.ToString.Trim
    End If
    ZDT.SetCmds(TextBox5.Text)
  End Sub

  Private Sub cs_DVTable(s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles cs.DVTable
    Dim sqlcv As New APSQL.SQLCNV
    sqlcv.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlcv.Where("QTN01", "=", "#SMTCMDS")
    sqlcv.SqlFields("QTN02", "指令代碼", , , True)
    sqlcv.SqlFields("QTN03", "指令說明")
    strSQL = BIG2GB(sqlcv.Text)
  End Sub

  Private Sub cs_Frm_CheckDup(s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles cs.Frm_CheckDup
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", "#SMTCMDS")
    sqlCV.Where("QTN02", "=", TextBox1.Text.Trim)
    sqlCV.SqlFields("*")
    strSQL = sqlCV.Text
  End Sub

  Private Sub cs_Frm_Clear(s As clsEDIT2012.clsEDITx2013) Handles cs.Frm_Clear
    TextBox1.Text = ""
    TextBox6.Text = ""
    TextBox5.Text = ""
    ZDT.SetCmds("")
  End Sub

  Private Sub cs_Frm_Delete(s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String, ByRef bolOK As Boolean) Handles cs.Frm_Delete
    If MsgBox(BIG2GB("是否刪除 " & TextBox1.Text.Trim & " 之資料，將會影響所有的指令表"), MsgBoxStyle.YesNo) = MsgBoxResult.No Then Return
    Dim sqlcv As New APSQL.SQLCNV
    sqlcv.sqlMAKE(APSQL.SQLCNV.intMode.mssql_delete, "SFIS_QTN")
    sqlcv.Where("QTN01", "=", "#SMTCMDS")
    sqlcv.Where("QTN02", "=", TextBox1.Text.Trim)
    strSQL = sqlcv.Text
    bolOK = True
  End Sub

  Private Sub cs_Frm_InsertM(s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles cs.Frm_InsertM
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "SFIS_QTN")
    TextBox5.Text = ZDT.ToString
    sqlCV.SqlFields("QTN01", "#SMTCMDS")
    sqlCV.SqlFields("QTN02", TextBox1.Text.Trim)
    sqlCV.SqlFields("QTN03", TextBox6.Text.Trim)
    sqlCV.SqlFields("QTN04", TextBox5.Text.Trim)
    strSQL = sqlCV.Text
  End Sub

  Private Sub cs_Frm_UpdateM(s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles cs.Frm_UpdateM
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_update, "SFIS_QTN")
    TextBox5.Text = ZDT.ToString
    sqlCV.Where("QTN01", "=", "#SMTCMDS")
    sqlCV.Where("QTN02", "=", TextBox1.Text.Trim)
    sqlCV.SqlFields("QTN03", TextBox6.Text.Trim)
    sqlCV.SqlFields("QTN04", TextBox5.Text.Trim)
    strSQL = sqlCV.Text
  End Sub

  Private Sub cs_isDataValid(s As clsEDIT2012.clsEDITx2013, ByRef bolOK As Boolean) Handles cs.isDataValid
    If TextBox1.Text.Trim = "" Or TextBox6.Text.Trim = "" Then
      MsgBox(BIG2GB("指令代碼及指令說明不可以是空白"))
      bolOK = False
      Return
    End If
    TextBox5.Text = ZDT.ToString
    If TextBox5.Text.Trim = "" Then
      MsgBox(BIG2GB("空指令將無法做任何操作"))
      bolOK = False
      Return
    End If
    bolOK = True
  End Sub

  Private Sub DG1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG1.CellDoubleClick
    Button9_Click(Nothing, Nothing)
  End Sub

  Private Sub DG1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DG1.CellFormatting
    If e.RowIndex < 0 Or e.RowIndex >= DG1.Rows.Count Then Return
    If e.ColumnIndex = 1 Then
      Dim strM As String = DG1.Rows(e.RowIndex).Cells(BIG2GB("類別")).Value.ToString.ToUpper
      Select Case strM
        Case "SCAN"
          DG1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Black
          DG1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
        Case "FUNC"
          DG1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
          DG1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
        Case "MARK"
          DG1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Blue
          DG1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
        Case "TOSET"
          DG1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Black
          DG1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightGreen
      End Select
    End If

  End Sub

  Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", "#SMTCMDS")
    sqlCV.SqlFields("*")
    sqlCV.sqlOrder("QTN02")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    Dim FDL As New SaveFileDialog
    FDL.InitialDirectory = "C:\"
    FDL.DefaultExt = "SQL"
    FDL.Filter = "SQL 指令檔|*.SQL|所有檔案|*.*"
    If FDL.ShowDialog = Windows.Forms.DialogResult.OK Then
      For Each r As DataRow In rs.Rows
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "SFIS_QTN")
        sqlCV.SqlFields("QTN01", "#SMTCMDS")
        sqlCV.SqlFields("QTN02", r!QTN02.ToString.Trim)
        sqlCV.SqlFields("QTN03", r!QTN03.ToString.Trim)
        sqlCV.SqlFields("QTN04", r!QTN04.ToString.Trim)
        IO.File.AppendAllText(FDL.FileName, sqlCV.Text & vbCrLf, System.Text.Encoding.Unicode)
      Next
    End If
  End Sub
  Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
    If DG1.CurrentRow Is Nothing Then Return
    ZDT.Add(GCell(DG1.CurrentRow.Cells(0)))
    'ZDC.ZDCTL.Add(DG1.CurrentRow.Cells(0).Value.ToString.Trim)
    'TextBox5.Text = ZDC.ZDCTL.ToString
    TextBox5.Text = ZDT.ToString
  End Sub

  Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
    If DG2.CurrentRow Is Nothing Then Return
    DG2.Rows.Remove(DG2.CurrentRow)
    TextBox5.Text = ZDT.ToString
  End Sub

  Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
    If DG2.CurrentRow Is Nothing Then Return
    If DG2.CurrentRow.Index = 0 Then Return
    Dim strM As String = ""
    Dim intG As Integer = DG2.CurrentRow.Index - 1
    With DG2.Rows(intG + 1)
      For intI As Integer = 0 To DG2.Columns.Count - 1
        strM = GCell(DG2.Rows(intG).Cells(intI))
        DG2.Rows(intG).Cells(intI).Value = GCell(.Cells(intI))
        .Cells(intI).Value = strM
      Next
    End With
    DG2.CurrentCell = DG2.Rows(intG).Cells(0)
    TextBox5.Text = ZDT.ToString
  End Sub

  Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
    If DG2.CurrentRow Is Nothing Then Return
    If DG2.CurrentRow.Index = DG2.Rows.Count - 1 Then Return
    Dim strM As String = ""
    Dim intG As Integer = DG2.CurrentRow.Index
    With DG2.Rows(intG + 1)
      For intI As Integer = 0 To DG2.Columns.Count - 1
        strM = GCell(DG2.Rows(intG).Cells(intI))
        DG2.Rows(intG).Cells(intI).Value = GCell(.Cells(intI))
        .Cells(intI).Value = strM
      Next
    End With
    DG2.CurrentCell = DG2.Rows(intG + 1).Cells(0)
    TextBox5.Text = ZDT.ToString
  End Sub

  Private Sub TextBox5_GotFocus(sender As Object, e As EventArgs) Handles TextBox5.GotFocus
    TextBox5.Text = ZDT.ToString
  End Sub

  Private Sub TextBox5_LostFocus(sender As Object, e As EventArgs) Handles TextBox5.LostFocus
    ZDT.SetCmds(TextBox5.Text.Trim)
  End Sub
End Class