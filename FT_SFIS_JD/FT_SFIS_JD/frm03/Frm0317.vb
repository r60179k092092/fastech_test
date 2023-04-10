Public Class Frm0317
  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()
    languagechange(Me)
    dgdaochu(DG)
    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

  End Sub

  Private Sub frm0317_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    TuiCK(Me)
  End Sub
  Private Sub frm0317_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim sqlCV As New SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_distinc, "SFIS_SK")
    sqlCV.SqlFields("SK01")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RSK01")
    Dim r As DataRow = rs.NewRow
    r.Item(0) = "ALL"
    rs.Rows.InsertAt(r, 0)
    ComboBox1.DisplayMember = "SK01"
    ComboBox1.ValueMember = "SK01"
    ComboBox1.DataSource = rs
    ComboBox1.SelectedIndex = 0
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_distinc, "SFIS_SK")
    sqlCV.SqlFields("SK02")
    rs = DB.RsSQL(sqlCV.Text, "RSK02")
    r = rs.NewRow
    r.Item(0) = "ALL"
    rs.Rows.InsertAt(r, 0)
    ComboBox2.DisplayMember = "SK02"
    ComboBox2.ValueMember = "SK02"
    ComboBox2.DataSource = rs
    ComboBox2.SelectedIndex = 0
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_distinc, "SFIS_SK")
    sqlCV.SqlFields("SK03")
    rs = DB.RsSQL(sqlCV.Text, "RSK03")
    r = rs.NewRow
    r.Item(0) = "ALL"
    rs.Rows.InsertAt(r, 0)
    ComboBox3.DisplayMember = "SK03"
    ComboBox3.ValueMember = "SK03"
    ComboBox3.DataSource = rs
    ComboBox3.SelectedIndex = 0
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_distinc, "SFIS_SK")
    sqlCV.SqlFields("SK06")
    rs = DB.RsSQL(sqlCV.Text, "RSK06")
    r = rs.NewRow
    r.Item(0) = "ALL"
    rs.Rows.InsertAt(r, 0)
    ComboBox4.DisplayMember = "SK06"
    ComboBox4.ValueMember = "SK06"
    ComboBox4.DataSource = rs
    ComboBox4.SelectedIndex = 0
    DTP1.Value = Now.AddDays(-15).Date
    DTP2.Value = Now.Date
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    Dim sqlCV As New SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_SK")
    sqlCV.Where("Convert(varchar(10),SK04,111)", ">=", DTP1.Value.ToString("yyyy\/MM\/dd"))
    sqlCV.Where("Convert(varchar(10),SK04,111)", "<=", DTP2.Value.ToString("yyyy\/MM\/dd"))
    If ComboBox1.Text <> "ALL" Then
      sqlCV.Where("SK01", "=", ComboBox1.Text)
    End If
    If ComboBox2.Text <> "ALL" Then
      sqlCV.Where("SK02", "=", ComboBox2.Text)
    End If
    If ComboBox3.Text <> "ALL" Then
      sqlCV.Where("SK03", "=", ComboBox3.Text)
    End If
    If ComboBox4.Text <> "ALL" Then
      sqlCV.Where("SK06", "=", ComboBox4.Text)
    End If
    sqlCV.SqlFields("SK04", "日期時間", , , True)
    sqlCV.SqlFields("SK08", "操作別")
    sqlCV.SqlFields("SK01", "鋼網編號")
    sqlCV.SqlFields("SK13", "使用次")
    sqlCV.SqlFields("SK16", "訂單量")
    sqlCV.SqlFields("SK10", "掛載日")
    sqlCV.SqlFields("SK02", "刮刀一編號")
    sqlCV.SqlFields("SK14", "使用次1")
    sqlCV.SqlFields("SK17", "訂單量1")
    sqlCV.SqlFields("SK11", "掛載日1")
    sqlCV.SqlFields("SK03", "刮刀二編號")
    sqlCV.SqlFields("SK15", "使用次2")
    sqlCV.SqlFields("SK18", "訂單量2")
    sqlCV.SqlFields("SK12", "掛載日2")
    sqlCV.SqlFields("SK06", "工單號")
    sqlCV.SqlFields("SK07", "工序")
    sqlCV.SqlFields("SK05", "操作員")
    sqlCV.SqlFields("SK09", "機台")
    Dim rs As DataTable = DB.RsSQL(BIG2GB(sqlCV.Text), "DGSK")
    DG.DataSource = rs
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    Me.Close()
  End Sub

  Private Sub DG_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DG.CellFormatting
    If e.ColumnIndex = 1 Then
      Select Case GCell(DG.Rows(e.RowIndex).Cells(e.ColumnIndex))
        Case "0"
          e.Value = BIG2GB("啟動作業")
        Case "1"
          e.Value = BIG2GB("更換刮刀片1")
        Case "2"
          e.Value = BIG2GB("更換刮刀片2")
        Case "3"
          e.Value = BIG2GB("停止作業")
      End Select
    End If
  End Sub
End Class