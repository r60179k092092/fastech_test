Imports System.Data
Imports APSQL

Public Class PM0303
  Private WithEvents s1 As clsEDIT2012.clsEDIT2012
  Private sqlCV As New APSQL.SQLCNV
  Private rsT As DataTable, rsM As DataTable
  Private aryTAM As New Dictionary(Of String, Integer)
  Private aryTJAA As New Dictionary(Of String, Integer)
  Private intERow As Integer = -1
  Private intRRow As Integer = -1
  Private strItems As String = ""
  Private intDoSeq As Integer = 0
  Private rsShow As DataTable = Nothing
  Private rsSel As DataTable = Nothing
  Private rsBegin As DataTable = Nothing
  Sub New()
    ' 此調用是設計器所必需的。
    InitializeComponent()
    ' 在 InitializeComponent() 調用之后添加任何初始化。
    languagechange(Me)
    TBC.TabPages(0).Text = BIG2GB(TBC.TabPages(0).Text)
  End Sub

  Private Sub PM0303_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    TuiCK(Me)
  End Sub

  Private Sub FrmLiuCheng2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    WindowState = FormWindowState.Maximized
    s1 = New clsEDIT2012.clsEDIT2012(TBC, DB, language, False, "SFIS_TB")
    s1.Clean()
    '查詢顯示工序編號
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TA")
    sqlCV.SqlFields("TA01", "工序編號")
    sqlCV.SqlFields("TA02", "工序名稱")
    sqlCV.SqlFields("TA03", "工序名稱")
    Dim rsShow As DataTable = DB.RsSQL(BIG2GB(sqlCV.Text), "SFIS_TA")
    DG1.DataSource = rsShow
    For i As Byte = 0 To DG1.ColumnCount - 1
      DG1.Columns(i).SortMode = SortOrder.None
    Next
    s1.GetToolsItem("Delete").Enabled = clsRTS.GetRight(Me.Tag & "/003")
    s1.GetToolsItem("save").Enabled = clsRTS.GetRight(Me.Tag & "/001")
  End Sub
  Private Sub s1_Frm_Clear(ByVal s As clsEDIT2012.clsEDIT2012) Handles s1.Frm_Clear
    TextBox1.Text = ""
    TextBox2.Text = ""
    TextBox3.Text = ""
    Button4.PerformClick()
  End Sub
  Private Sub s1_DVSelect(ByVal s As clsEDIT2012.clsEDIT2012, ByVal r As System.Windows.Forms.DataGridViewRow) Handles s1.DVSelect
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TB")
    sqlCV.Where("Tb01", "=", r.Cells(0).Value.ToString.Trim)
    sqlCV.SqlFields("*")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RTA")
    If rs.Rows.Count = 0 Then Return
    With rs.Rows(0)
      TextBox1.Text = !TB01.ToString
      TextBox3.Text = !TB02.ToString
      TextBox2.Text = !TB03.ToString.Trim
    End With
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TBA")
    sqlCV.Where("TBA01", "=", TextBox1.Text.Trim, APSQL.intFMode.msfld_Asciitext)
    sqlCV.Where("TBA02", "=", TextBox3.Text.Trim)
    sqlCV.SqlFields("TBA04", "工序編號")
    rs = DB.RsSQL(BIG2GB(sqlCV.Text), "RTAM")
    'DG2.DataSource = rs
    DG2.Rows.Clear()
    For Each rp As DataGridViewRow In DG1.Rows
      rp.DefaultCellStyle.ForeColor = Color.Black
      rp.DefaultCellStyle.BackColor = Color.White
    Next

    For i As Integer = 0 To rs.Rows.Count - 1
      For Each rp As DataGridViewRow In DG1.Rows
        If rp.Cells(0).Value = rs.Rows(i).Item(0).ToString Then
          rp.DefaultCellStyle.ForeColor = Color.Red
          rp.DefaultCellStyle.BackColor = Color.LightGray
          DG2.Rows.Add(rp.Cells(0).Value, rp.Cells(1).Value)
          Exit For
        End If
      Next
    Next
  End Sub
  Private Sub s1_Frm_InsertM(ByVal s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String, ByRef intR As Integer) Handles s1.Frm_InsertM
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "SFIS_TB")
    sqlCV.SqlFields("TB01", TextBox1.Text.Trim, APSQL.intFMode.msfld_Asciitext)
    sqlCV.SqlFields("TB02", TextBox3.Text.Trim)
    sqlCV.SqlFields("TB03", TextBox2.Text.Trim)
    sqlCV.SqlFields("UACT", lgnname)
    sqlCV.SqlFields("UDATE", "GETDATE()", intFMode.msfld_field)

    DB.RsSQL(sqlCV.Text)
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_delete, "SFIS_TBA")
    sqlCV.Where("TBA01", "=", TextBox1.Text.Trim, APSQL.intFMode.msfld_Asciitext)
    sqlCV.Where("TBA02", "=", TextBox3.Text.Trim)
    DB.RsSQL(sqlCV.Text)

    For Each r1 As DataGridViewRow In DG2.Rows
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "SFIS_TBA")
      sqlCV.SqlFields("TBA01", TextBox1.Text.Trim, APSQL.intFMode.msfld_Asciitext)
      sqlCV.SqlFields("TBA02", TextBox3.Text.Trim)
      sqlCV.SqlFields("TBA03", r1.Index)
      sqlCV.SqlFields("TBA04", r1.Cells(0).Value.ToString.Trim)
      DB.RsSQL(sqlCV.Text)
    Next

    s1.Updated = True
    'MsgBox("插入成功！")
    s1_Frm_Clear(Nothing)
  End Sub


  Private Sub s1_DVTable(ByVal s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String) Handles s1.DVTable
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TB")
    sqlCV.SqlFields("TB01", "流程編號")
    sqlCV.SqlFields("TB02", "流程版本")
    sqlCV.SqlFields("TB03", "流程說明")
    sqlCV.SqlFields("UACT", "修訂人")
    sqlCV.SqlFields("UDATE", "修訂時間")
    strSQL = BIG2GB(sqlCV.Text)
  End Sub

  Private Sub s1_Frm_CheckDup(ByVal s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String) Handles s1.Frm_CheckDup
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TB")
    sqlCV.Where("TB01", "=", TextBox1.Text)
    sqlCV.Where("TB02", "=", TextBox3.Text)
    sqlCV.SqlFields("TB01")
    strSQL = sqlCV.Text
  End Sub

  Private Sub s1_Frm_Delete(ByVal s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String, ByRef bolOK As Boolean) Handles s1.Frm_Delete
    If MsgBox(BIG2GB("是否刪除本筆流程設置?"), MsgBoxStyle.OkCancel, Me.Text) <> MsgBoxResult.Ok Then Return
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_delete, "SFIS_TB")
    sqlCV.Where("TB01", "=", TextBox1.Text.Trim, APSQL.intFMode.msfld_Asciitext)
    sqlCV.Where("TB02", "=", TextBox3.Text.Trim)
    DB.RsSQL(sqlCV.Text)
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_delete, "SFIS_TBA")
    sqlCV.Where("TBA01", "=", TextBox1.Text.Trim, APSQL.intFMode.msfld_Asciitext)
    sqlCV.Where("TBA02", "=", TextBox3.Text.Trim)
    DB.RsSQL(sqlCV.Text)

    bolOK = True
    s1.Updated = True
    'MsgBox("刪除成功！")
    s1_Frm_Clear(Nothing)
  End Sub


  Private Sub s1_Frm_UpdateM(ByVal s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String, ByRef intR As Integer) Handles s1.Frm_UpdateM
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_update, "SFIS_TB")
    sqlCV.Where("TB01", "=", TextBox1.Text)
    'sqlCV.SqlFields("TB01", TextBox1.Text.Trim, APSQL.intFMode.msfld_Asciitext)
    sqlCV.Where("TB02", "=", TextBox3.Text.Trim)
    sqlCV.SqlFields("TB03", TextBox2.Text.Trim)
    sqlCV.SqlFields("UACT", lgnname)
    sqlCV.SqlFields("UDATE", "GETDATE()", intFMode.msfld_field)

    DB.RsSQL(sqlCV.Text)
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_delete, "SFIS_TBA")
    sqlCV.Where("TBA01", "=", TextBox1.Text.Trim, APSQL.intFMode.msfld_Asciitext)
    sqlCV.Where("TBA02", "=", TextBox3.Text.Trim)
    DB.RsSQL(sqlCV.Text)

    For Each r1 As DataGridViewRow In DG2.Rows
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "SFIS_TBA")
      sqlCV.SqlFields("TBA01", TextBox1.Text.Trim, APSQL.intFMode.msfld_Asciitext)
      sqlCV.SqlFields("TBA02", TextBox3.Text.Trim)
      sqlCV.SqlFields("TBA03", r1.Index)
      sqlCV.SqlFields("TBA04", r1.Cells(0).Value.ToString.Trim)
      DB.RsSQL(sqlCV.Text)
    Next
    s1.Updated = True
    'MsgBox("更新成功！")
    s1_Frm_Clear(Nothing)
  End Sub

  Private Sub s1_isDataValid(ByVal s As clsEDIT2012.clsEDIT2012, ByRef bolOK As Boolean) Handles s1.isDataValid
    If TextBox1.Text.Trim = "" Then
      MsgBox(BIG2GB("流程編號不得空白"), MsgBoxStyle.OkOnly, Me.Text)
      bolOK = False
      TextBox1.Focus()
    End If
    If TextBox2.Text.Trim = "" Then
      bolOK = False
      TextBox2.Focus()
    End If
    If TextBox3.Text.Trim = "" Then
      bolOK = False
      TextBox3.Focus()
    End If
    bolOK = True
  End Sub

  Private Sub DG1_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DG1.CurrentCellDirtyStateChanged
    DG1.CommitEdit(DataGridViewDataErrorContexts.Commit)
  End Sub


  Private Sub DG2_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DG2.CurrentCellDirtyStateChanged
    DG2.CommitEdit(DataGridViewDataErrorContexts.Commit)
  End Sub
  Enum mode
    top = 0
    up = 1
    down = 2
    bottom = 3
  End Enum



  Private Sub DG2_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG2.CellEnter
    intRRow = e.RowIndex
  End Sub
  Private Sub DG1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellEnter
    intERow = e.RowIndex
  End Sub

  '添加
  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    If intERow < 0 Or intERow >= DG1.Rows.Count Then Return
    For Each row As DataGridViewRow In DG1.SelectedRows
      SetSelect(row)
    Next
  End Sub
  '全部添加
  Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    For Each row As DataGridViewRow In DG1.Rows
      SetSelect(row)
    Next
  End Sub
  Private Overloads Sub SetSelect(ByVal r As DataGridViewRow)
    For Each r1 As DataGridViewRow In DG2.Rows
      If r.Cells(0).Value.ToString.Trim = r1.Cells(0).Value.ToString.Trim Then Return
    Next
    DG2.Rows.Add(r.Cells(0).Value, r.Cells(1).Value, r.Cells(2).Value)
    r.DefaultCellStyle.ForeColor = Color.Red
    r.DefaultCellStyle.BackColor = Color.LightGray
  End Sub

  '移除
  Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
    If intRRow < 0 Or intRRow >= DG1.Rows.Count Then Return
    For Each row As DataGridViewRow In DG2.SelectedRows
      Setshanchu(row)
    Next
  End Sub
  '全部移除
  Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
    DG2.Rows.Clear()
    For Each r1 As DataGridViewRow In DG1.Rows
      r1.DefaultCellStyle.ForeColor = Color.Black
      r1.DefaultCellStyle.BackColor = Color.White
    Next
  End Sub
  Private Overloads Sub Setshanchu(ByVal r As DataGridViewRow)
    For Each r1 As DataGridViewRow In DG1.Rows
      If r.Cells(0).Value.ToString.Trim = r1.Cells(0).Value.ToString.Trim Then
        r1.DefaultCellStyle.ForeColor = Color.Black
        r1.DefaultCellStyle.BackColor = Color.White
        DG2.Rows.Remove(r)
        Return
      End If
    Next
  End Sub

  '下
  Private Sub btn_Down_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Down.Click
    Me.swapRows(mode.down, DG2)
  End Sub
  '上
  Private Sub btn_UP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_UP.Click
    Me.swapRows(mode.up, DG2)
  End Sub
  Private Sub swapRows(ByVal range As mode, ByVal DTG As DataGridView)
    Dim iSelectedRow As Integer = -1
    For iTmp As Integer = 0 To DTG.Rows.Count - 1
      If DTG.Rows(iTmp).Selected Then
        iSelectedRow = iTmp
        Exit For
      End If
    Next
    If iSelectedRow <> -1 Then
      Dim sTmp(3) As String
      For iTmp As Integer = 0 To DTG.Columns.Count - 1
        sTmp(iTmp) = GCell(DTG.Rows(iSelectedRow).Cells(iTmp))
      Next
      Dim iNewRow As Integer
      If range = mode.down Then
        iNewRow = iSelectedRow + 1
      ElseIf range = mode.up Then
        iNewRow = iSelectedRow - 1
      End If
      If range = mode.up Or range = mode.down Then
        For iTmp As Integer = 0 To DTG.Columns.Count - 1
          If iNewRow < 0 Or iNewRow > DTG.Rows.Count - 1 Then Return
          DTG.Rows(iSelectedRow).Cells(iTmp).Value = GCell(DG2.Rows(iNewRow).Cells(iTmp))
          DTG.Rows(iNewRow).Cells(iTmp).Value = sTmp(iTmp)
        Next
        DTG.Rows(iNewRow).Selected = True
        DTG.Rows(iSelectedRow).Selected = False
      End If
    End If
  End Sub


End Class