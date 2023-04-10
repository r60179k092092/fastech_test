Imports APSQL

Public Class PM0504
  Private sngX As Single = 1.5
  Private sngY As Single = 1
  Private clsLBP As New clsLBPRT
  Private strID As String = ""
  Private strOrd As String = ""
  Private strQTY As String = ""
  Private strDate As String = ""
  Private strOper As String = ""
  Private strDUTY As String = ""
  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()

    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    languagechange(Me)
  End Sub

  Private Sub PM0504_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    TuiCK(Me)
  End Sub

  Private Sub PM0504_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    DTP1.Value = Now
    DTP2.Value = Now
    Button1_Click(Nothing, Nothing)
    dgdaochu(DG)
    dgdaochu(DG1)
  End Sub

  Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
    DTP2.Enabled = CheckBox1.Checked
    DTP1.Enabled = CheckBox1.Checked
  End Sub

  Private Sub ComboBox2_GotFocus(sender As Object, e As EventArgs) Handles ComboBox2.GotFocus
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_distinc, "SFIS_TN")
    sqlCV.Where("ISNULL(TN12,'')", "<>", "")
    'sqlCV.Where("ISNULL(TN11,'')", "<>", "")
    sqlCV.SqlFields("TN02")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    Dim strM As String = ""
    For Each r As DataRow In rs.Rows
      strM &= "'" & r!TN02.ToString.Trim & "',"
    Next
    If strM = "" Then Return
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TD")
    sqlCV.Where("TD12", "IN", "0,1,2", APSQL.intFMode.msfld_field)
    sqlCV.Where("TD01", "IN", strM.Trim(","), intFMode.msfld_field)
    sqlCV.SqlFields("TD01", "KEYS", , , True)
    sqlCV.SqlFields("TD01 + ' ' + ISNULL(TD19,'') + ' ' + ISNULL(TD02,'')", "DATAS")
    sqlCV.SqlFields("TD19")
    sqlCV.SqlFields("TD02")
    sqlCV.SqlFields("TD03")
    sqlCV.SqlFields("TD04")
    sqlCV.SqlFields("TD05")
    sqlCV.SqlFields("TD06")
    sqlCV.SqlFields("TD07")
    sqlCV.SqlFields("TD26")
    sqlCV.SqlFields("TD27")
    sqlCV.SqlFields("TD28")
    ComboBox2.DisplayMember = "DATAS"
    ComboBox2.ValueMember = "KEYS"
    ComboBox2.DataSource = DB.RsSQL(sqlCV.Text, "TDS")
  End Sub
  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    ComboBox2.SelectedValue = ""
    TextBox2.Text = ""
    TextBox5.Text = ""
    DTP1.Value = Now
    DTP2.Value = Now
    GroupBox1.Visible = True
  End Sub

  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    Me.Close()
  End Sub

  Private Sub ComboBox2_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBox2.SelectionChangeCommitted
    CheckBox1.Checked = False
    CheckBox2.Checked = True
    If ComboBox2.SelectedItem Is Nothing Then Return
    Dim r As DataRowView = ComboBox2.SelectedItem
    TextBox2.Text = (r!TD05.ToString.Trim & "-" & r!TD06.ToString.Trim).Trim("-")
    TextBox5.Text = (r!TD03.ToString.Trim & "-" & r!TD04.ToString.Trim).Trim("-")
    Button2_Click(Nothing, Nothing)
  End Sub
  Private Sub Heading()
    If sngY <> 1.0 Then
      clsLBP.NewPage()
    End If
    sngX = 1.5
    sngY = 1.0
    clsLBP.ADD_PG("01", "")
    clsLBP.ADD_PG("04", strID)
    clsLBP.ADD_PG("05", strOrd)
    clsLBP.ADD_PG("06", strQTY)
    clsLBP.ADD_PG("07", strDate)
    clsLBP.ADD_PG("08", strOper)
    clsLBP.PrtLBL(sngX, sngY)
  End Sub
  Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    Dim strF As String = GetTextFile("0504")
    Dim sqlCV As New APSQL.SQLCNV
    Dim strKEY As String = ""
    sngX = 1.5
    sngY = 1
    clsLBP.InitLBL(strF)
    For Each r As DataGridViewRow In DG.Rows
      If GCell(r.Cells(0)) <> strKEY Then
        If strKEY <> "" Then
          If sngX <> 1.5 Then
            clsLBP.ADD_PG("20", "")
            sngX = 1.5
            clsLBP.PrtLBL(sngX, sngY)
            sngY += 0.6
            clsLBP.ADD_PG("09", "")
            clsLBP.PrtLBL(sngX, sngY)
          End If
        End If
        strKEY = GCell(r.Cells(0))
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TD")
        sqlCV.Where("TD01", "=", strKEY)
        sqlCV.SqlFields("*")
        Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        If rs.Rows.Count = 0 Then
          strOrd = strKEY
          strQTY = ""
          strID = ""
          strDUTY = ""
        Else
          strOrd = (rs.Rows(0)!TD05.ToString.Trim & "-" & rs.Rows(0)!TD06.ToString.Trim).Trim("-")
          If strOrd = "" Then strOrd = strKEY
          strQTY = Val(rs.Rows(0)!TD07.ToString).ToString("0")
          strID = rs.Rows(0)!TD19.ToString.Trim
          If strID = "" Then strID = rs.Rows(0)!TD02.ToString.Trim
          strDUTY = ""
        End If
        strOper = GetUser(GCell(r.Cells(4)))
        strDate = GCell(r.Cells(5))
        Heading()
      End If
      If sngX > 18 Then
        clsLBP.ADD_PG("20", "")
        sngX = 1.5
        clsLBP.PrtLBL(sngX, sngY)
        sngY += 0.6
      End If
      If sngY > 15 Then
        clsLBP.ADD_PG("09", "")
        clsLBP.PrtLBL(sngX, sngY)
        Heading()
      End If
      clsLBP.ADD_PG("11", GCell(r.Cells(1)))
      clsLBP.ADD_PG("12", GCell(r.Cells(3)))
      clsLBP.PrtLBL(sngX, sngY)
      sngX += 6
    Next
    If sngX > 1.5 Then
      clsLBP.ADD_PG("20", "")
      sngX = 1.5
      clsLBP.PrtLBL(sngX, sngY)
      sngY += 0.6
      clsLBP.ADD_PG("09", "")
      clsLBP.PrtLBL(sngX, sngY)
    End If
    Dim s As New System.Drawing.Printing.PrinterSettings
    clsLBP.PrinterName = s.DefaultPageSettings.PrinterSettings.PrinterName
    clsLBP.SelectPrt = True
    clsLBP.PrtDialog()
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    Dim sqlCV As New APSQL.SQLCNV
    Dim strM As String = ""
    If CheckBox2.Checked = True Or TextBox2.Text.Trim <> "" Or TextBox5.Text.Trim <> "" Then
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TD")
      If CheckBox2.Checked = True AndAlso ComboBox2.SelectedValue IsNot Nothing Then
        sqlCV.Where("TD01", "=", ComboBox2.SelectedValue.ToString.Trim)
      End If
      If TextBox2.Text.Trim <> "" Then
        sqlCV.Where("TD05+'-'+TD06", "LIKE", TextBox2.Text.Trim & "%")
      End If
      If TextBox5.Text.Trim <> "" Then
        sqlCV.Where("TD03+'-'+TD04", "LIKE", TextBox5.Text.Trim & "%")
      End If
      sqlCV.SqlFields("TD01", , , , True)
      Dim rs1 As DataTable = DB.RsSQL(sqlCV.Text, "RT")
      If rs1.Rows.Count = 0 Then Return
      For Each r As DataRow In rs1.Rows
        strM &= "'" & r!TD01.ToString.Trim & "',"
      Next
    End If
    If CheckBox1.Checked = False And strM = "" Then
      DG.DataSource = Nothing
      Return
    End If
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TN")
    If CheckBox1.Checked Then
      sqlCV.Where("TN04", ">=", DTP1.Value.ToString("yyyy\/MM\/dd") & " 00:00:00", APSQL.intFMode.msfld_datetime)
      sqlCV.Where("TN04", "<=", DTP2.Value.ToString("yyyy\/MM\/dd") & " 23:59:59", APSQL.intFMode.msfld_datetime)
    End If
    If strM <> "" Then
      sqlCV.Where("TN02", "IN", strM.Trim(","), APSQL.intFMode.msfld_field)
    End If
    sqlCV.Where("ISNULL(TN12,'')", "<>", "")
    sqlCV.SqlFields("TN12")
    Dim strMS As String = "(" & sqlCV.Text & ")"
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TM", "USEQ", "=", "SFIS_TN.TN17")
    sqlCV.Where("^0.TN12", "IN", strMS, intFMode.msfld_field)
    sqlCV.Where("ISNULL(^0.TN17,0)", "<>", 0, intFMode.msfld_num)
    sqlCV.SqlFields("^0.TN17")
    sqlCV.SqlFields("^0.TN02")
    sqlCV.SqlFields("^0.TN12")
    sqlCV.SqlFields("^1.*")
    Dim rs2 As DataTable = DB.RsSQL(sqlCV.Text, "TT")
    Dim aryT As New Dictionary(Of String, DataRow)
    For Each r As DataRow In rs2.Rows
      Dim strK1 As String = r!TN02.ToString.Trim & vbTab & r!TN12.ToString.Trim
      If aryT.ContainsKey(strK1) = False Then
        aryT.Add(strK1, r)
      End If
    Next
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
    sqlCV.Where("TN12", "IN", strMS, intFMode.msfld_field)
    Dim w As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "SFIS_TS", "TS01", "=", "^0.TN01")
    w.Add("SFIS_TS.TS03", "=", "'SN'")
    sqlCV.SqlFields("TN02", "工單號", , True, True)
    sqlCV.SqlFields("TN12", "外箱號", , True, True)
    If CheckBox3.Checked Then
      sqlCV.SqlFields("TN14", "中包號", , True, True)
    End If
    sqlCV.SqlFields("Count(*)", "數量")
    sqlCV.SqlFields("('')", "包裝員")
    sqlCV.SqlFields("('')", "包裝日期")
    sqlCV.SqlFields("MIN(^1.TS02) + '-' + MAX(^1.TS02)", "[S/N範圍]")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "PACK")
    For Each r As DataRow In rs.Rows
      Dim strK1 As String = r.Item(0).ToString.Trim & vbTab & r.Item(1).ToString.Trim
      If aryT.ContainsKey(strK1) = True Then
        If CheckBox3.Checked Then
          r.Item(4) = aryT(strK1)!TM03.ToString.Trim
          r.Item(5) = aryT(strK1)!TM06.ToString.Trim
        Else
          r.Item(3) = aryT(strK1)!TM03.ToString.Trim
          r.Item(4) = aryT(strK1)!TM06.ToString.Trim
        End If
      End If
    Next
    DG.DataSource = Nothing
    DG.Columns.Clear()
    DG.Rows.Clear()
    DG.DataSource = rs
  End Sub

  Private Sub DG_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG.CellClick
    If e.RowIndex < 0 Or e.RowIndex >= DG.Rows.Count Then Return
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
    Dim w As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "SFIS_TS", "TS01", "=", "^0.TN01")
    w.Add("SFIS_TS.TS03", "<>", "'SN'")
    sqlCV.Where("TN02", "=", GCell(DG.Rows(e.RowIndex).Cells(0)))
    If CheckBox3.Checked Then
      sqlCV.Where("TN14", "=", GCell(DG.Rows(e.RowIndex).Cells(2)))
    Else
      sqlCV.Where("TN12", "=", GCell(DG.Rows(e.RowIndex).Cells(1)))
    End If
    sqlCV.SqlFields("^1.TS01")
    sqlCV.SqlFields("^1.TS02")
    sqlCV.SqlFields("^1.TS03", , , , True)
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    Dim aryC As New ArrayList
    For Each r As DataRow In rs.Rows
      If aryC.Contains(r!TS03.ToString.Trim) = False Then
        aryC.Add(r!TS03.ToString.Trim)
      End If
    Next
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
    w = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "SFIS_TS", "TS01", "=", "^0.TN01")
    w.Add("SFIS_TS.TS03", "=", "'SN'")
    sqlCV.Where("TN02", "=", GCell(DG.Rows(e.RowIndex).Cells(0)))
    If CheckBox3.Checked Then
      sqlCV.Where("TN14", "=", GCell(DG.Rows(e.RowIndex).Cells(2)))
    Else
      sqlCV.Where("TN12", "=", GCell(DG.Rows(e.RowIndex).Cells(1)))
    End If
    sqlCV.SqlFields("^1.TS02", "[產品S/N]", , , True)
    sqlCV.SqlFields("^0.TN01", "[產品PPID]", , , True)
    For Each strC As String In aryC
      sqlCV.SqlFields("('')", "[" & strC & "]")
    Next
    sqlCV.SqlFields("TN12", "箱號", , , True)
    sqlCV.SqlFields("TN14", "中包號")
    Dim rs1 = DB.RsSQL(sqlCV.Text, "PACK1")
    Dim aryR As New Dictionary(Of String, DataRow)
    For Each r As DataRow In rs1.Rows
      aryR.Add(r.Item(1).ToString.Trim, r)
    Next
    For Each r As DataRow In rs.Rows
      Dim strK As String = r!TS01.ToString.Trim
      Dim strC As String = r!TS03.ToString.Trim
      If aryR.ContainsKey(strK) = True Then
        aryR(strK).Item(strC) = r!TS02.ToString.Trim
      End If
    Next
    DG1.DataSource = rs1
  End Sub

  Private Sub DG_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DG.CellFormatting
    If e.ColumnIndex = 4 Then
      Dim strM As String = GCell(DG.Rows(e.RowIndex).Cells(4))
      e.Value = GetUser(strM)
    End If
  End Sub
End Class
