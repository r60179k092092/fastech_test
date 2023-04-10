﻿Imports APSQL
Public Class PM0316
  Dim WithEvents cs As clsEDIT2012.clsEDITx2013
  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()

    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    ''languagechange(Me)
    dgdaochu(DG)
    dgdaochu(DG1)
  End Sub
  Private Sub ExcelDown()
    Dim OFL As New OpenFileDialog
    Dim sqlCV As New SQLCNV
    OFL.Title = BIG2GB("請選擇一個導入Excel資料")
    OFL.Filter = BIG2GB("Excel|*.xls;*.xlsx|所有檔案|*.*")
    OFL.FileName = ""
    If OFL.ShowDialog = Windows.Forms.DialogResult.OK Then
      Dim xlsF As New XLS_FILE(OFL.FileName)
      Dim rs As DataTable = xlsF.XLS2Rs(0)
      If rs.Columns.Count > 9 Then
        For Each r As DataRow In rs.Rows
          sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_SJ")
          sqlCV.Where("SJ01", "=", r.Item(1).ToString.Trim)
          sqlCV.SqlFields("SJ02", "")
          sqlCV.SqlFields("SJ03", "")
          sqlCV.SqlFields("SJ04", r.Item(2).ToString.Trim)
          sqlCV.SqlFields("SJ05", "")
          Dim strM As String = r.Item(6).ToString.Trim
          If IsDate(strM) Then
            strM = CDate(strM).ToString("yyyy\/MM\/dd")
          Else
            strM = Now.ToString("yyyy\/MM\/dd")
          End If
          sqlCV.SqlFields("SJ06", strM)
          sqlCV.SqlFields("SJ07", r.Item(3).ToString.Trim)
          sqlCV.SqlFields("SJ08", "")
          Dim strV As String = r.Item(8).ToString.Trim.ToUpper
          If strV = "NG" Then
            sqlCV.SqlFields("SJ09", "2")
          Else
            sqlCV.SqlFields("SJ09", "0")
          End If
          sqlCV.SqlFields("SJ12", r.Item(5).ToString.Trim, intFMode.msfld_num)
          sqlCV.SqlFields("SJ13", r.Item(5).ToString.Trim, intFMode.msfld_num)
          sqlCV.SqlFields("SJ14", r.Item(4).ToString.Trim, intFMode.msfld_num)
          sqlCV.SqlFields("SJ15", "1")
          Dim intL As Integer = DB.RsSQL(sqlCV.Text)
          If intL = 0 Then
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_SJ")
            sqlCV.SqlFields("SJ01", r.Item(1).ToString.Trim)
            sqlCV.SqlFields("SJ02", "")
            sqlCV.SqlFields("SJ03", "")
            sqlCV.SqlFields("SJ04", r.Item(2).ToString.Trim)
            sqlCV.SqlFields("SJ05", "")
            sqlCV.SqlFields("SJ06", strM)
            sqlCV.SqlFields("SJ07", r.Item(3).ToString.Trim)
            sqlCV.SqlFields("SJ08", "")
            If strV = "NG" Then
              sqlCV.SqlFields("SJ09", "2")
            Else
              sqlCV.SqlFields("SJ09", "0")
            End If
            sqlCV.SqlFields("SJ10", "")
            sqlCV.SqlFields("SJ11", "")
            sqlCV.SqlFields("SJ12", r.Item(5).ToString.Trim, intFMode.msfld_num)
            sqlCV.SqlFields("SJ13", r.Item(5).ToString.Trim, intFMode.msfld_num)
            sqlCV.SqlFields("SJ14", r.Item(4).ToString.Trim, intFMode.msfld_num)
            sqlCV.SqlFields("SJ15", "1")
            sqlCV.SqlFields("SJ16", "")
            DB.RsSQL(sqlCV.Text)
          End If
        Next
      End If
      xlsF.Quit()
      MsgBox(BIG2GB("導入成功"))
      cs.Updated = True
      cs.Clean()
    End If
  End Sub
  Private Sub PM0316_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    cs = New clsEDIT2012.clsEDITx2013(DG, DB, language)
    Me.KeyPreview = True
    cs.Clean()
    cs.AddToolsItem("導入", My.Resources.XDOWN, AddressOf ExcelDown)
    '-------------------------------------------------------------
    '自動定位到這一個編輯清單，讓操作者更方便運作數據
    'cs.AddKeyColumns(BIG2GB("機臺編號")) ''保存后自動定位到 dg
    cs.GetToolsItem("Delete").Enabled = clsRTS.GetRight(Me.Tag & "/003")
    cs.GetToolsItem("save").Enabled = clsRTS.GetRight(Me.Tag & "/001")
    Dim sqlCV As New SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_distinc, "SFIS_SJ")
    sqlCV.SqlFields("SJ04", , , , True)
    sqlCV.Where("SJ15", "=", "1")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    SJ04.Items.Clear()
    For Each r As DataRow In rs.Rows
      SJ04.Items.Add(r!SJ04.ToString.Trim)
    Next
  End Sub

  Private Sub PM0316_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
    TuiCK(Me)
  End Sub

  Private Sub cs_DV_HasError(s As clsEDITx2013, sender As Object, e As DataGridViewDataErrorEventArgs) Handles cs.DV_HasError

  End Sub

  Private Sub cs_DVSelect(s As clsEDITx2013, r As DataGridViewRow) Handles cs.DVSelect
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_SJ")
    sqlCV.Where("SJ01", "=", GCell(r.Cells(0)))
    sqlCV.SqlFields("*")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count = 0 Then Return
    With rs.Rows(0)
      SJ01.Text = !SJ01.ToString.Trim
      SJ04.Text = !SJ04.ToString.Trim
      SJ07.Text = !SJ07.ToString.Trim
      If IsDate(!SJ06.ToString.Trim) Then
        SJ06.Value = CDate(!SJ06.ToString.Trim)
      Else
        SJ06.Value = Now.Date
      End If
      Dim strM As String = !SJ09.ToString.Trim
      SJ09.SelectedIndex = 0
      For intI As Integer = 0 To SJ09.Items.Count - 1
        If SJ09.Items(intI).ToString.Substring(0, 1) = strM Then
          SJ09.SelectedIndex = intI
          Exit For
        End If
      Next
      SJ10.Text = !SJ10.ToString.Trim
      SJ11.Text = !SJ11.ToString.Trim
      SJ12.Text = !SJ12.ToString.Trim
      SJ13.Text = !SJ13.ToString.Trim
      SJ14.Text = !SJ14.ToString.Trim
      SJ01.Enabled = False
    End With
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_SJ", , "TOP 100")
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "SFIS_User", "UserCode", "=", "^0.SJ16")
    sqlCV.Where("^0.SJ15", "=", "2")
    sqlCV.Where("^0.SJ01", "LIKE", SJ01.Text & "|%")
    sqlCV.SqlFields("^0.SJ10", "掛載日期")
    sqlCV.SqlFields("^0.SJ11", "掛載機台")
    sqlCV.SqlFields("^1.UserName", "更換工員")
    sqlCV.SqlFields("^0.SJ12", "訂單累計量")
    sqlCV.SqlFields("^0.SJ13", "使用次數")
    sqlCV.SqlFields("^0.SJ14", "上限次數")
    sqlCV.sqlOrder("^0.SJ10", SQLCNV.intOrder.Order_Dsc)
    DG1.DataSource = DB.RsSQL(sqlCV.Text, "SJV")
  End Sub

  Private Sub cs_DVTable(s As clsEDITx2013, ByRef strSQL As String) Handles cs.DVTable
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_SJ")
    sqlCV.Where("SJ15", "=", "1")
    sqlCV.SqlFields("SJ01", "編號", , , True)
    sqlCV.SqlFields("SJ04", "機台型號")
    sqlCV.SqlFields("SJ07", "規格")
    sqlCV.SqlFields("SJ06", "入料日期")
    sqlCV.SqlFields("SJ14", "壽命上限")
    sqlCV.SqlFields("SJ09", "狀態")
    sqlCV.SqlFields("SJ12", "訂單數量")
    sqlCV.SqlFields("SJ13", "使用次數")
    sqlCV.SqlFields("SJ10", "掛載日期")
    sqlCV.SqlFields("SJ11", "掛載機台")
    strSQL = BIG2GB(sqlCV.Text)
  End Sub

  Private Sub cs_Frm_CheckDup(s As clsEDITx2013, ByRef strSQL As String) Handles cs.Frm_CheckDup
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_SJ")
    sqlCV.Where("SJ01", "=", SJ01.Text.Trim)
    sqlCV.SqlFields("SJ01")
    strSQL = sqlCV.Text
  End Sub

  Private Sub cs_Frm_Clear(s As clsEDITx2013) Handles cs.Frm_Clear
    SJ01.Text = ""
    SJ04.Text = ""
    SJ07.Text = ""
    SJ06.Value = Now.Date
    SJ09.SelectedIndex = 0
    SJ10.Text = ""
    SJ11.Text = ""
    SJ12.Text = ""
    SJ13.Text = ""
    SJ14.Text = ""
    SJ01.Enabled = True
  End Sub

  Private Sub cs_Frm_Delete(s As clsEDITx2013, ByRef strSQL As String, ByRef bolOK As Boolean) Handles cs.Frm_Delete
    If MsgBox(BIG2GB("是否刪除刮刀編號:") & SJ01.Text, MsgBoxStyle.OkCancel, BIG2GB("提示")) = MsgBoxResult.Ok Then
      Dim sqlCV As New APSQL.SQLCNV
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_delete, "SFIS_SJ")
      sqlCV.Where("SJ01", "=", SJ01.Text)
      sqlCV.Where("SJ15", "=", "1")
      strSQL = sqlCV.Text
      bolOK = True
    End If
  End Sub

  Private Sub cs_Frm_InsertM(s As clsEDITx2013, ByRef strSQL As String) Handles cs.Frm_InsertM
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_SJ")
    sqlCV.SqlFields("SJ15", "1")
    sqlCV.SqlFields("SJ01", SJ01.Text.Trim)
    sqlCV.SqlFields("SJ02", "")
    sqlCV.SqlFields("SJ03", "")
    sqlCV.SqlFields("SJ04", SJ04.Text.Trim)
    sqlCV.SqlFields("SJ05", "")
    sqlCV.SqlFields("SJ06", SJ06.Value.ToString("yyyy\/MM\/dd"))
    sqlCV.SqlFields("SJ07", SJ07.Text.Trim)
    sqlCV.SqlFields("SJ08", "")
    sqlCV.SqlFields("SJ09", SJ09.Text.Trim.Substring(0, 1))
    sqlCV.SqlFields("SJ10", "")
    sqlCV.SqlFields("SJ11", "")
    sqlCV.SqlFields("SJ12", 0, intFMode.msfld_num)
    sqlCV.SqlFields("SJ13", 0, intFMode.msfld_num)
    sqlCV.SqlFields("SJ14", SJ14.Text.Trim, intFMode.msfld_num)
    sqlCV.SqlFields("SJ16", "")
    strSQL = sqlCV.Text
    If SJ04.Items.IndexOf(SJ04.Text.Trim) < 0 Then
      SJ04.Items.Add(SJ04.Text.Trim)
    End If
  End Sub

  Private Sub cs_Frm_UpdateM(s As clsEDITx2013, ByRef strSQL As String) Handles cs.Frm_UpdateM
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_SJ")
    sqlCV.Where("SJ15", "=", "1")
    sqlCV.Where("SJ01", "=", SJ01.Text.Trim)
    sqlCV.SqlFields("SJ04", SJ04.Text.Trim)
    sqlCV.SqlFields("SJ07", SJ07.Text.Trim)
    sqlCV.SqlFields("SJ06", SJ06.Value.ToString("yyyy\/MM\/dd"))
    sqlCV.SqlFields("SJ09", SJ09.Text.Trim.Substring(0, 1))
    sqlCV.SqlFields("SJ14", SJ14.Text.Trim, intFMode.msfld_num)
    strSQL = sqlCV.Text
    If SJ04.Items.IndexOf(SJ04.Text.Trim) < 0 Then
      SJ04.Items.Add(SJ04.Text.Trim)
    End If
  End Sub

  Private Sub cs_isDataValid(s As clsEDITx2013, ByRef bolOK As Boolean) Handles cs.isDataValid
    If SJ01.Text.Trim = "" Then
      MsgBox(BIG2GB("刮刀編號不得空白"))
      Return
    End If
    If Val(SJ14.Text) < 1 Then
      MsgBox(BIG2GB("使用壽命必須設定"))
      Return
    End If
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_SJ")
    sqlCV.Where("SJ01", "=", SJ01.Text.Trim)
    sqlCV.SqlFields("SJ01")
    sqlCV.SqlFields("SJ15")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count > 0 Then
      If rs.Rows(0)!SJ15.ToString.Trim <> "1" Then
        MsgBox(BIG2GB("修改的位置不是刮刀編號"))
        Return
      End If
    End If
    bolOK = True
  End Sub

  Private Sub SJ01_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SJ01.KeyPress,
    SJ04.KeyPress, SJ07.KeyPress, SJ06.KeyPress, SJ09.KeyPress, SJ14.KeyPress
    If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
      e.Handled = True
      My.Computer.Keyboard.SendKeys(vbTab)
    End If
  End Sub

  Private Sub SJ01_LostFocus(sender As Object, e As EventArgs) Handles SJ01.LostFocus
    If SJ01.Text.Trim = "" Then
      Return
    End If
    For Each r As DataGridViewRow In DG.Rows
      If GCell(r.Cells(0)) = SJ01.Text.Trim Then
        DG.CurrentCell = r.Cells(0)
        cs_DVSelect(cs, r)
        Return
      End If
    Next
    Dim sqlCV As New SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_SJ")
    sqlCV.Where("SJ01", "=", SJ01.Text.Trim)
    sqlCV.SqlFields("SJ01")
    sqlCV.SqlFields("SJ15")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    SJ01.Enabled = False
    If rs.Rows.Count = 0 Then Return
    If rs.Rows(0)!SJ15.ToString.Trim <> "1" Then
      SJ01.Enabled = True
      SJ01.Text = ""
      MsgBox("輸入編號已經使用過")
      SJ01.Focus()
      Return
    End If
  End Sub

  Private Sub DG_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DG.CellFormatting
    If e.ColumnIndex = 5 Then
      Dim strM As String = GCell(DG.Rows(e.RowIndex).Cells(5))
      Select Case strM
        Case "0"
          e.Value = BIG2GB("正常")
        Case "1"
          e.Value = BIG2GB("掛載")
        Case "2"
          e.Value = BIG2GB("NG")
        Case "3"
          e.Value = BIG2GB("壽命超限")
        Case "9"
          e.Value = BIG2GB("報廢")
      End Select
    End If
  End Sub
End Class