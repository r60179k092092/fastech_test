Public Class Frm0606
  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()
    languagechange(Me)
    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

  End Sub
  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_distinc, "SFIS_SA")
    If CheckBox4.Checked Then
      sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_SD", "SD02", "=", "^0.SA01")
    End If
    sqlCV.SqlJoin(APSQL.SQLCNV.intJoinMode.msJoin_Left, "SFIS_TD", "TD01", "=", "SFIS_SA.SA05")
    If CheckBox1.Checked And ComboBox1.SelectedValue IsNot Nothing Then
      sqlCV.Where("SA05", "=", ComboBox1.SelectedValue.ToString)
    End If
    If CheckBox2.Checked And ComboBox2.SelectedValue IsNot Nothing Then
      sqlCV.Where("SA02", "=", ComboBox2.SelectedValue.ToString)
    End If
    If CheckBox3.Checked Then
      sqlCV.Where("Convert(Varchar(10),SA08,111)", ">=", DTP1.Value.ToString("yyyy\/MM\/dd"))
      sqlCV.Where("Convert(Varchar(10),SA08,111)", "<=", DTP2.Value.ToString("yyyy\/MM\/dd"))
    End If
    'sqlCV.Where("SA09", "=", "1")
    sqlCV.SqlFields("SA02", "機臺", , , True)
    sqlCV.SqlFields("SA05", "工單", , , True)
    sqlCV.SqlFields("SA08", "操作時間", , , True)
    sqlCV.SqlFields("TD02", "機種料號")
    sqlCV.SqlFields("TD07", "數量")
    sqlCV.SqlFields("SA07", "指令")
    sqlCV.SqlFields("SA04", "操作員")
    sqlCV.SqlFields("SA10", "確認者")
    sqlCV.SqlFields("SA11", "QC操作員")
    sqlCV.SqlFields("SA09", "狀態")
    sqlCV.SqlFields("SA01")
    Dim rs As DataTable = DB.RsSQL(BIG2GB(sqlCV.Text), "SAM")
    DG.DataSource = rs
    DG.Columns("SA01").Visible = False
    If CheckBox1.Checked And ComboBox1.SelectedValue IsNot Nothing Then
      ReListDG2()
    End If
  End Sub

  Private Sub ReListDG2()
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_SD")
    Dim w As APSQL.SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_SA", "SA01", "=", "^0.SD02")
    w.Add("SFIS_SA.SA05", "=", "'" & ComboBox1.SelectedValue.ToString.Trim & "'")
    sqlCV.Where("^0.SD18", "=", 0)
    sqlCV.Where("ISNULL(^0.SD08,'')", "<>", "")
    sqlCV.SqlFields("^1.SA05", "工單", , True, True)
    sqlCV.SqlFields("^0.SD09", "物料編號", , True, True)
    sqlCV.SqlFields("^0.SD12", "品名", , True)
    sqlCV.SqlFields("^0.SD10", "批號", , True, True)
    sqlCV.SqlFields("('')", "廠商編號")
    sqlCV.SqlFields("^0.SD11", "其他資訊", , True)
    sqlCV.SqlFields("^0.SD13", "單位用量", , True)
    sqlCV.SqlFields("Count(*)", "操作次數")
    sqlCV.SqlFields("count(distinct ^1.SA04)", "操作人數")
    'sqlCV.SqlFields("^0.SD03", "操作時間")
    Dim rs As DataTable = DB.RsSQL(BIG2GB(sqlCV.Text), "DG2")
    For Each r As DataRow In rs.Rows
      Dim strM() As String = r.Item(3).ToString.Trim.Split("_")
      r.Item(3) = strM(0).Trim
      If strM.Length > 1 Then
        r.Item(4) = strM(1).Trim
      End If
    Next
    DG2.DataSource = rs
  End Sub

  Private Sub Frm0606_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    TuiCK(Me)
  End Sub

  Private Sub FrmSA01_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TJ")
    sqlCV.SqlFields("TJ01", "KEYS", , , True)
    sqlCV.SqlFields("TJ01 + ' ' + TJ02", "DATAS")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "TVL")
    ComboBox2.DisplayMember = "DATAS"
    ComboBox2.ValueMember = "KEYS"
    ComboBox2.DataSource = rs
    If rs.Rows.Count > 0 Then
      ComboBox2.SelectedValue = rs.Rows(0)!KEYS.ToString.Trim
    End If
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_distinc, "SFIS_SA")
    sqlCV.SqlFields("SA05", "KEYS", , , True)
    rs = DB.RsSQL(sqlCV.Text, "SAL")
    ComboBox1.DisplayMember = "KEYS"
    ComboBox1.ValueMember = "KEYS"
    ComboBox1.DataSource = rs
    If rs.Rows.Count > 0 Then
      ComboBox1.SelectedValue = rs.Rows(0)!KEYS.ToString.Trim
    End If
    dgdaochu(DG)
    dgdaochu(DG1)
    dgdaochu(DG2)
  End Sub

  Private Sub DG_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG.CellDoubleClick
    If e.RowIndex < 0 Or e.RowIndex >= DG.Rows.Count Then Return
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_SD")
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_SA", "SA01", "=", "^0.SD02")
    sqlCV.Where("SD02", "=", GCell(DG.Rows(e.RowIndex).Cells("SA01")), APSQL.intFMode.msfld_num)
    sqlCV.SqlFields("SD03", "操作時間")
    sqlCV.SqlFields("SD08", "料站編號")
    sqlCV.SqlFields("SA07", "指令")
    sqlCV.SqlFields("SD09", "料號")
    sqlCV.SqlFields("SD05", "FEEDER")
    sqlCV.SqlFields("SD12", "品名")
    sqlCV.SqlFields("SD10", "LotNo")
    sqlCV.SqlFields("('')", "廠商編號")
    sqlCV.SqlFields("SD11", "DateCode")
    sqlCV.SqlFields("SD13", "用量")
    sqlCV.SqlFields("SD14", "錯誤信息")
    sqlCV.SqlFields("SD18", "狀態")
    Dim rs As DataTable = DB.RsSQL(BIG2GB(sqlCV.Text), "SDM")
    For Each r As DataRow In rs.Rows
      Dim strM() As String = r.Item(5).ToString.Trim.Split("_")
      r.Item(5) = strM(0).Trim
      If strM.Length > 1 Then
        r.Item(6) = strM(1).Trim
      End If
    Next
    DG1.DataSource = rs
    If rs.Rows.Count = 0 Then
      MsgBox(BIG2GB("沒有上料或下料紀錄"))
      Return
    End If
    TabControl1.SelectedIndex = 1
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    Me.Close()
  End Sub

  Private Sub DG_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DG.CellFormatting
    If e.ColumnIndex = 9 Then
      Dim strM As String = GCell(DG.Rows(e.RowIndex).Cells(e.ColumnIndex))
      Select Case strM
        Case "0"
          e.Value = "執行未完成"
        Case "1"
          e.Value = "完成"
      End Select
    End If
  End Sub
End Class
