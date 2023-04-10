Imports APSQL
Public Class PM0305
  Private WithEvents s1 As clsEDIT2012.clsEDIT2012
  Dim dtC6, dtC7, dtC8 As DataGridViewComboBoxColumn
  Private aryTQ As New Dictionary(Of String, String)
  Sub New()
    ' 此調用是設計器所必需的。
    InitializeComponent()
    ' 在 InitializeComponent() 調用之后添加任何初始化。
    languagechange(Me)
    'setlanguageDG(Me, DGXM)
    TBC1.TabPages(0).Text = BIG2GB(TBC1.TabPages(0).Text)
    dtC6 = CType(DGXM.Columns("Column6"), DataGridViewComboBoxColumn)
    'dtC6.Items.Clear()
    'For Each a In getlanguagecmb(Me, "Column60")
    '  dtC6.Items.Add(a)
    'Next
    dtC7 = CType(DGXM.Columns("Column7"), DataGridViewComboBoxColumn)
    'dtC7.Items.Clear()
    'For Each a In getlanguagecmb(Me, "Column70")
    '  dtC7.Items.Add(a)
    'Next
    dtC8 = CType(DGXM.Columns("Column8"), DataGridViewComboBoxColumn)
    'For Each a In getlanguagecmb(Me, "Column80")
    '  dtC8.Items.Add(a)
    'Next
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
      Dim rs As DataTable = xlsF.XLS2Rs(0, 1, 2, False)
      If rs.Rows.Count = 0 Then Return
      Dim strID As String = rs.Rows(0).Item(0).ToString.Trim
      Dim strINSP As String = rs.Rows(0).Item(1).ToString.Trim
      Dim strIT As String = rs.Rows(0).Item(3).ToString.Trim
      Dim sngDF As Single = Val(rs.Rows(0).Item(2).ToString)
      If strIT <> "" Then
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TBB")
        sqlCV.Where("TBB03", "=", strIT)
        sqlCV.SqlFields("TBB03")
        rs = DB.RsSQL(sqlCV.Text, "RT")
        If rs.Rows.Count = 0 Then
          MsgBox(BIG2GB("無法找到這個貨號，將不會建立該貨號的檢驗標準"))
          strIT = ""
        End If
      End If
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_QJ")
      sqlCV.Where("QJ01", "=", strID)
      sqlCV.SqlFields("QJ02", strINSP)
      sqlCV.SqlFields("QJ03", sngDF, intFMode.msfld_num)
      Dim intI As Integer = DB.RsSQL(sqlCV.Text)
      If intI = 0 Then
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_QJ")
        sqlCV.SqlFields("QJ01", strID)
        sqlCV.SqlFields("QJ02", strINSP)
        sqlCV.SqlFields("QJ03", sngDF, intFMode.msfld_num)
        DB.RsSQL(sqlCV.Text)
      End If
      rs = xlsF.XLS2Rs(0, 3, 0)
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_delete, "SFIS_QJA")
      sqlCV.Where("QJA01", "=", strID)
      DB.RsSQL(sqlCV.Text)
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_delete, "SFIS_QJB")
      sqlCV.Where("QJB01", "=", strID)
      DB.RsSQL(sqlCV.Text)
      Dim aryL As New ArrayList
      For Each r As DataRow In rs.Rows
        Dim strPID As String = r.Item(0).ToString.Trim
        If aryL.Contains(strPID) Then
          MsgBox(BIG2GB("檢驗項目編號重複：") & strID & " " & strPID & " " & r.Item(1).ToString.Trim)
          Continue For
        End If
        aryL.Add(strPID)
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_QJA")
        sqlCV.SqlFields("QJA01", strID)
        sqlCV.SqlFields("QJA02", strPID)
        sqlCV.SqlFields("QJA03", r.Item(1).ToString.Trim)
        sqlCV.SqlFields("QJA04", r.Item(2).ToString.Trim)
        sqlCV.SqlFields("QJA05", r.Item(3).ToString.Trim)
        sqlCV.SqlFields("QJA06", r.Item(4).ToString.Trim)
        sqlCV.SqlFields("QJA07", 0, intFMode.msfld_num)
        Select Case (r.Item(5).ToString.Trim.ToUpper & " ").Substring(0, 1)
          Case "C", "1"
            sqlCV.SqlFields("QJA08", 1, intFMode.msfld_num)
          Case "V", "0"
            sqlCV.SqlFields("QJA08", 0, intFMode.msfld_num)
          Case "W", "2"
            sqlCV.SqlFields("QJA08", 2, intFMode.msfld_num)
          Case "S", "3"
            sqlCV.SqlFields("QJA08", 3, intFMode.msfld_num)
          Case "L", "4"
            sqlCV.SqlFields("QJA08", 4, intFMode.msfld_num)
          Case Else
            sqlCV.SqlFields("QJA08", 9, intFMode.msfld_num)
        End Select
        sqlCV.SqlFields("QJA09", "")
        sqlCV.SqlFields("QJA10", 1, intFMode.msfld_num)
        If strINSP = "INSP" Or strINSP = "100%" Then
          sqlCV.SqlFields("QJA11", "100%")
        Else
          sqlCV.SqlFields("QJA11", "S-3")
        End If
        sqlCV.SqlFields("QJA12", r.Item(6).ToString.Trim)
        sqlCV.SqlFields("QJA13", 0, intFMode.msfld_num)
        DB.RsSQL(sqlCV.Text)
        If strIT = "" Then Continue For
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_QJB")
        sqlCV.SqlFields("QJB01", strID)
        sqlCV.SqlFields("QJB02", strIT)
        sqlCV.SqlFields("QJB03", "")
        sqlCV.SqlFields("QJB04", strPID)
        sqlCV.SqlFields("QJB05", r.Item(7).ToString.Trim)
        sqlCV.SqlFields("QJB06", r.Item(9).ToString.Trim)
        sqlCV.SqlFields("QJB07", r.Item(8).ToString.Trim)
        sqlCV.SqlFields("QJB08", "")
        sqlCV.SqlFields("QJB09", "")
        DB.RsSQL(sqlCV.Text)
      Next
      xlsF.Quit()
      MsgBox(BIG2GB("導入成功"))
      s1.Updated = True
      s1.Clean()
    End If
  End Sub

  Private Sub PM0305_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    TuiCK(Me)
  End Sub
  Private Sub Frmjianyanxiangmu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    cbAQL.Items.Clear()
    cbAQL.Items.Add("")
    cbAQL.Items.Add("100%")
    cbAQL.Items.Add("INSP")
    Dim sp As New NORMAL
    For Each s As String In sp.GetAQLs
      cbAQL.Items.Add(s)
    Next
    cbAQL.SelectedIndex = 0
    s1 = New clsEDIT2012.clsEDIT2012(TBC1, DB, language, False, "SFIS_QJ")
    'TBC1.SelectTab(1)
    s1.InsertToolsItem(3, BIG2GB("Excel導入"), My.Resources.XDOWN, AddressOf DownExcel)
    s1.Clean()
    ''工序列綁定數據源
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TA")
    sqlCV.SqlFields("TA01+'|'+TA02+'|'+TA03", "DATAS") ', "工序編號")
    sqlCV.SqlFields("TA01")
    sqlCV.SqlFields("TA04")
    Dim dt As DataGridViewComboBoxColumn = CType(DGXM.Columns("Column10"), DataGridViewComboBoxColumn)
    Dim dtt As DataTable = DB.RsSQL(sqlCV.Text, "SFIS_TA")
    dtt.Rows.Add(BIG2GB("|(無工序)"), "", "INSP")
    dt.DataSource = dtt
    dt.DisplayMember = "DATAS" '工序編號"
    dt.ValueMember = "TA01"
    aryTQ.Clear()
    For Each r As DataRow In dtt.Rows
      aryTQ.Add(r!TA01.ToString.Trim, r!TA04.ToString.Trim)
    Next
    DGXM.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGreen

    s1.GetToolsItem("Delete").Enabled = clsRTS.GetRight(Me.Tag & "/003")
    s1.GetToolsItem("save").Enabled = clsRTS.GetRight(Me.Tag & "/001")
  End Sub
  ''在 tab2 中單擊
  Private Sub s1_DVSelect(ByVal s As clsEDIT2012.clsEDIT2012, ByVal r As System.Windows.Forms.DataGridViewRow) Handles s1.DVSelect
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QJ")
    sqlCV.Where("QJ01", "=", r.Cells(0).Value.ToString.Trim)
    sqlCV.SqlFields("*")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RTA")
    If rs.Rows.Count = 0 Then Return
    With rs.Rows(0)
      TextBox1.Text = !QJ01.ToString
      Dim intI As Integer = cbAQL.Items.IndexOf(!QJ02.ToString)
      If intI < 0 Then intI = 0
      cbAQL.SelectedIndex = intI
      NumericUpDown1.Text = !QJ03.ToString.Trim
    End With

    DGXM.Rows.Clear()
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QJA")
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "sfis_ta", "ta01", "=", "^0.qja12")
    sqlCV.Where("QJA01", "=", TextBox1.Text)
    sqlCV.SqlFields("qja01")
    sqlCV.SqlFields("qja02")
    sqlCV.SqlFields("qja03")
    sqlCV.SqlFields("qja04")
    sqlCV.SqlFields("qja05")
    sqlCV.SqlFields("qja06")
    sqlCV.SqlFields("qja07")
    sqlCV.SqlFields("qja08")
    sqlCV.SqlFields("qja09")
    sqlCV.SqlFields("qja10")
    sqlCV.SqlFields("QJA11")
    sqlCV.SqlFields("qja12") '+'|'+sfis_ta.ta02+'|'+sfis_ta.ta03")
    sqlCV.SqlFields("qja13")
    sqlCV.SqlFields("^1.TA04")
    rs = DB.RsSQL(sqlCV.Text, "RTA")
    For Each a As DataRow In rs.Rows
      Dim st(3) As String
      With a
        Select Case .Item("QJA07").ToString
          'Case "0"
          '    st(0) = "實際值"
          'Case "1"
          '    st(0) = "百分比"
          Case 9, -1
            st(0) = ""
          Case Else
            st(0) = dtC6.Items(.Item("QJA07"))
        End Select
        Select Case a.Item("QJA08")
          'Case "0"
          '    st(1) = "輸入"
          'Case "1"
          '    st(1) = "勾選"
          Case 9, -1
            st(1) = ""
          Case Else
            st(1) = dtC7.Items(.Item("QJA08"))
        End Select
        Select Case a.Item("QJA10")
          Case "0"
            st(2) = "CR"
          Case "1"
            st(2) = "MA"
          Case "2"
            st(2) = "MI"
          Case "9"
            st(2) = dtC8.Items(3) '"其他"
        End Select
        Dim strTQ As String = !TA04.ToString.Trim
        If strTQ.StartsWith("100%") Then
          strTQ = "100%"
        ElseIf strTQ = "INSP" Or strTQ = "AFM" Or strTQ = "" Then
          strTQ = !QJA11.ToString.Trim
        End If
        DGXM.Rows.Add(.Item(1), .Item(2), .Item(3), .Item(4), .Item(5), st(0), st(1), .Item(8), st(2), strTQ, .Item(11).ToString.Trim, .Item(12))
      End With
    Next
    DGXM.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    DGXM.Refresh()
    DGXM.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
    DGXM.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
    DGXM.AppendBegin()
  End Sub
  '選擇tab2 中顯示數據
  Private Sub s1_DVTable(ByVal s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String) Handles s1.DVTable
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QJ")
    sqlCV.SqlFields("QJ01", BIG2GB("檢驗類型"))
    sqlCV.SqlFields("QJ02", BIG2GB("抽樣標準"))
    sqlCV.SqlFields("QJ03", BIG2GB("破壞性試驗比率"))
    strSQL = sqlCV.Text
  End Sub
  ''清空
  Private Sub s1_Frm_Clear(ByVal s As clsEDIT2012.clsEDIT2012) Handles s1.Frm_Clear
    TextBox1.Text = Nothing
    cbAQL.SelectedIndex = 0
    NumericUpDown1.Text = 0
    DGXM.Rows.Clear()
    DGXM.AppendBegin()
  End Sub

  ''判斷是否為空
  Private Sub s1_isDataValid(ByVal s As clsEDIT2012.clsEDIT2012, ByRef bolOK As Boolean) Handles s1.isDataValid
    DGXM.EndEdit()
    If TextBox1.Text.Trim = "" Then
      MsgBox(BIG2GB("檢驗類型不能為空"), MsgBoxStyle.OkOnly, BIG2GB("提示"))
      bolOK = False
    Else
      For r As Integer = 0 To DGXM.RowCount - 2
        If DGXM.Rows.Item(r).Cells.Item(0).Value = "" Or DGXM.Rows.Item(r).Cells.Item(1).Value = "" Then
          MsgBox(BIG2GB("項次編號和中文說明不能為空"), MsgBoxStyle.OkOnly, BIG2GB("提示"))
          bolOK = False
          Exit Sub
        End If
      Next
      bolOK = True
    End If
  End Sub
  ''判斷數據庫中是否存在
  Private Sub s1_Frm_CheckDup(ByVal s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String) Handles s1.Frm_CheckDup
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QJ")
    sqlCV.Where("QJ01", "=", TextBox1.Text)
    sqlCV.SqlFields("QJ01")
    strSQL = sqlCV.Text
  End Sub
  ''不存在 添加
  Private Sub s1_Frm_InsertM(ByVal s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String, ByRef intR As Integer) Handles s1.Frm_InsertM
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "SFIS_QJ")
    sqlCV.SqlFields("QJ01", TextBox1.Text)
    sqlCV.SqlFields("QJ02", cbAQL.Text)
    sqlCV.SqlFields("QJ03", NumericUpDown1.Text)
    DB.RsSQL(sqlCV.Text)
    tijia()
  End Sub
  ''存在修改
  Private Sub s1_Frm_UpdateM(ByVal s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String, ByRef intR As Integer) Handles s1.Frm_UpdateM
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_update, "SFIS_QJ")
    sqlCV.Where("QJ01", "=", TextBox1.Text)
    sqlCV.SqlFields("QJ02", cbAQL.Text)
    sqlCV.SqlFields("QJ03", NumericUpDown1.Text)
    DB.RsSQL(sqlCV.Text)

    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_delete, "SFIS_QJA")
    sqlCV.Where("QJa01", "=", TextBox1.Text)
    DB.RsSQL(sqlCV.Text)
    tijia()
  End Sub
  ''刪除
  Private Sub s1_Frm_Delete(ByVal s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String, ByRef bolOK As Boolean) Handles s1.Frm_Delete
    'Try
    If MsgBox(BIG2GB("是否刪除數據"), MsgBoxStyle.OkCancel, BIG2GB("提示")) = MsgBoxResult.Ok Then
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_delete, "SFIS_QJ")
      sqlCV.Where("QJ01", "=", TextBox1.Text)
      DB.RsSQL(sqlCV.Text)
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_delete, "SFIS_QJA")
      sqlCV.Where("QJA01", "=", TextBox1.Text)
      strSQL = sqlCV.Text
      bolOK = True
    End If
    '    MsgBox("數據刪除成功", MsgBoxStyle.OkOnly, BIG2GB("提示"))
    '    s1.Updated = True
    'Catch ex As Exception
    '    MsgBox("數據刪除失敗", MsgBoxStyle.OkOnly, BIG2GB("提示"))
    'End Try
  End Sub
  Private Sub tijia()
    For Each r As DataGridViewRow In DGXM.Rows
      With r
        If GCell(.Cells(0)) = "" Or GCell(.Cells(1)) = "" Then Continue For
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "SFIS_QJA")
        sqlCV.SqlFields("QJA01", TextBox1.Text)
        sqlCV.SqlFields("QJA02", .Cells(0).Value)
        sqlCV.SqlFields("QJA03", .Cells(1).Value)
        sqlCV.SqlFields("QJA04", GCell(.Cells(2)))
        sqlCV.SqlFields("QJA05", GCell(.Cells(3)))
        sqlCV.SqlFields("QJA06", GCell(.Cells(4)))
        If GCell(.Cells(5)) = "" Then
          sqlCV.SqlFields("QJA07", 9)
        Else
          sqlCV.SqlFields("QJA07", dtC6.Items.IndexOf(.Cells(5).Value))
        End If
        If GCell(.Cells(6)) = "" Then
          sqlCV.SqlFields("QJA08", 9)
        Else
          sqlCV.SqlFields("QJA08", dtC7.Items.IndexOf(.Cells(6).Value))
        End If

        sqlCV.SqlFields("QJA09", GCell(.Cells(7)))

        Select Case GCell(.Cells(8))
          Case "CR"
            sqlCV.SqlFields("QJA10", 0)
          Case "MA"
            sqlCV.SqlFields("QJA10", 1)
          Case "MI"
            sqlCV.SqlFields("QJA10", 2)
          Case Else
            sqlCV.SqlFields("QJA10", 9)
        End Select
        sqlCV.SqlFields("QJA11", GCell(.Cells(9)))
        Try
          sqlCV.SqlFields("QJA12", GCell(.Cells(10)).Split("|")(0))
        Catch ex As Exception

        End Try
        If GCell(.Cells(11)).ToUpper <> "TRUE" Then
          sqlCV.SqlFields("QJA13", 0)
        Else
          sqlCV.SqlFields("QJA13", 1)
        End If

        DB.RsSQL(sqlCV.Text)
      End With
    Next
    'MsgBox("保存成功", MsgBoxStyle.OkOnly, BIG2GB("提示"))
    s1.Updated = True
  End Sub

  Private Sub DGXM_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGXM.CellEndEdit
    If e.ColumnIndex = 10 Then
      Dim strV As String = GCell(DGXM.Rows(e.RowIndex).Cells(e.ColumnIndex))
      If aryTQ.ContainsKey(strV) = True Then
        strV = aryTQ(strV)
        If strV.StartsWith("100%") Then
          DGXM.Rows(e.RowIndex).Cells(9).Value = "100%"
        ElseIf strV <> "INSP" And strV <> "AFM" Then
          DGXM.Rows(e.RowIndex).Cells(9).Value = strV
        End If
      End If
    End If
  End Sub

  Private Sub DGXM_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DGXM.DataError

  End Sub
End Class