Public Class Frm0324
  Private strTG001 As String = ""
  Private strMQ002 As String = ""
  Private strMQ003 As String = ""
  Private intTPage As Integer = 0
  Private intCPage As Integer = 0
  Private rsT As DataTable = Nothing
  Private rsD As DataTable = Nothing
  Private aryTKD As New ArrayList
  Private LBT As clsLBPRT = Nothing
  Private s1 As New LABTRANx64.Labtran.QRCODE

  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()
    languagechange(Me)
    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

  End Sub

  Private Sub Frm0324_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    TuiCK(Me)
  End Sub
  Private Sub Frm0324_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim sqlCV As New APSQL.SQLCNV, rs As DataTable = Nothing
    If DBERP Is Nothing OrElse DBERP.Active = False Then
    Else
#If K3 = 1 Then
#ElseIf K3 = 2 Then
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "CMSMQ")
    sqlCV.Where("MQ003", "Like", "3%")
    sqlCV.Where("MQ003", "Like", "5%", , , "OR")
    sqlCV.SqlFields("MQ001", "KEYS", , , True)
    sqlCV.SqlFields("RTRIM(MQ001) + '-' + RTRIM(MQ002)", "DATAS")
    sqlCV.SqlFields("MQ002")
    sqlCV.SqlFields("MQ003")
    rs = DBERP.RsSQL(sqlCV.Text, "RMQ")
#End If
    End If
    TG001.DisplayMember = "DATAS"
    TG001.ValueMember = "KEYS"
    TG001.DataSource = rs
    If rs IsNot Nothing OrElse rs.Rows.Count > 0 Then
      TG001.SelectedValue = rs.Rows(0)!KEYS.ToString
    End If
    ComboBox2.Items.Clear()
    ComboBox2.Items.Add("none")
        For Each strV As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            ComboBox2.Items.Add(strV)
        Next
    ComboBox2.SelectedIndex = ComboBox2.Items.IndexOf(My.Settings.PRINTER)
    If ComboBox2.SelectedIndex < 0 Then ComboBox2.SelectedIndex = 0
  End Sub

  Private Sub TG002_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TG002.KeyPress, TK1.KeyPress, TK2.KeyPress
    If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
      e.Handled = True
      My.Computer.Keyboard.SendKeys(vbTab)
    End If
  End Sub

  Private Sub TG002_LostFocus(sender As Object, e As EventArgs) Handles TG002.LostFocus
    Button1_Click(Nothing, Nothing)
  End Sub
  Private Sub GetTicket(strID As String)
    rsT = Nothing
    rsD = Nothing
    Dim r1 As DataRowView = TG001.SelectedItem
    If strID.Trim = "" Or r1 Is Nothing Then Return
    If DBERP Is Nothing OrElse DBERP.Active = False Then Return
    Dim sqlCV As New APSQL.SQLCNV
#If K3 = 1 Then
#ElseIf K3 = 2 Then
    strMQ003 = r1!MQ003.ToString.Trim
    If strMQ003.StartsWith("5") Then
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "MOCTH")
      sqlCV.Where("^0.TH001", "=", r1!MQ001.ToString.Trim)
      sqlCV.Where("^0.TH002", "=", strID.Trim)
      sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "CMSMQ", "MQ001", "=", "^0.TH001")
      sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "PURMA", "MA001", "=", "^0.TH005")
      sqlCV.SqlFields("^0.TH001")
      sqlCV.SqlFields("^1.MQ002")
      sqlCV.SqlFields("^0.TH002")
      sqlCV.SqlFields("^0.TH005")
      sqlCV.SqlFields("^2.MA002")
      sqlCV.SqlFields("^0.TH003")
      sqlCV.SqlFields("^0.TH010")
      rsT = DBERP.RsSQL(sqlCV.Text, "RT")
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "MOCTI")
      sqlCV.Where("^0.TI001", "=", r1!MQ001.ToString.Trim)
      sqlCV.Where("^0.TI002", "=", strID.Trim)
      sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "CMSMC", "MC001", "=", "^0.TI009")
      Dim w As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "INVMC", "MC001", "=", "^0.TI004")
      w.Add("INVMC.MC002", "=", "MOCTI.TI009")
      sqlCV.SqlFields("^0.TI003", "序號")
      sqlCV.SqlFields("RTRIM(^0.TI013)+'-'+RTRIM(^0.TI014)", "工單編號")
      sqlCV.SqlFields("^0.TI004", "品號")
      sqlCV.SqlFields("^0.TI005", "品名")
      sqlCV.SqlFields("^0.TI006", "規格")
      sqlCV.SqlFields("^0.TI018", "驗收日期")
      sqlCV.SqlFields("^0.TI007", "進貨數量")
      sqlCV.SqlFields("^0.TI008", "單位")
      sqlCV.SqlFields("^0.TI019", "驗收數量")
      sqlCV.SqlFields("^0.TI022", "驗退數量")
      sqlCV.SqlFields("RTRIM(^0.TI009)+' '+ISNULL(^1.MC002,'')", "倉別")
      sqlCV.SqlFields("^2.MC003", "庫位")
      rsD = DBERP.RsSQL(BIG2GB(sqlCV.Text), "RTH")
    Else
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "PURTG")
      sqlCV.Where("^0.TG001", "=", r1!MQ001.ToString.Trim)
      sqlCV.Where("^0.TG002", "=", strID)
      sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "CMSMQ", "MQ001", "=", "^0.TG001")
      sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "PURMA", "MA001", "=", "^0.TG005")
      sqlCV.SqlFields("^0.TG001")
      sqlCV.SqlFields("^1.MQ002")
      sqlCV.SqlFields("^0.TG002")
      sqlCV.SqlFields("^0.TG005")
      sqlCV.SqlFields("^2.MA002")
      sqlCV.SqlFields("^0.TG014")
      sqlCV.SqlFields("^0.TG016")
      rsT = DBERP.RsSQL(sqlCV.Text, "RT")
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "PURTH")
      sqlCV.Where("^0.TH001", "=", r1!MQ001.ToString.Trim)
      sqlCV.Where("^0.TH002", "=", strID)
      sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "CMSMC", "MC001", "=", "^0.TH009")
      Dim w As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "INVMC", "MC001", "=", "^0.TH004")
      w.Add("INVMC.MC002", "=", "PURTH.TH009")
      sqlCV.SqlFields("^0.TH003", "序號")
      sqlCV.SqlFields("RTRIM(^0.TH011)+'-'+RTRIM(^0.TH012)", "採購單號")
      sqlCV.SqlFields("^0.TH004", "品號")
      sqlCV.SqlFields("^0.TH005", "品名")
      sqlCV.SqlFields("^0.TH006", "規格")
      sqlCV.SqlFields("^0.TH014", "驗收日期")
      sqlCV.SqlFields("^0.TH007", "進貨數量")
      sqlCV.SqlFields("^0.TH008", "單位")
      sqlCV.SqlFields("^0.TH015", "驗收數量")
      sqlCV.SqlFields("^0.TH017", "驗退數量")
      sqlCV.SqlFields("RTRIM(^0.TH009)+' '+ISNULL(^1.MC002,'')", "倉別")
      sqlCV.SqlFields("^2.MC003", "庫位")
      rsD = DBERP.RsSQL(BIG2GB(sqlCV.Text), "RTH")
    End If
#End If
  End Sub
  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    GetTicket(TG002.Text.Trim)
    If rsT Is Nothing Or rsD Is Nothing Then Return
    If rsT.Rows.Count = 0 Or rsD.Rows.Count = 0 Then Return
    Dim r As DataRow = rsT.Rows(0)
    strTG001 = r.Item(0).ToString.Trim
    strMQ002 = r.Item(1).ToString.Trim
    TG002.Text = r.Item(2).ToString.Trim
    TG014.Text = MakeDate(r.Item(5).ToString)
    TG005.Text = r.Item(3).ToString.Trim & " " & r.Item(4).ToString.Trim
    TG016.Text = r.Item(6).ToString.Trim
    DG.DataSource = rsD
  End Sub
  Private Function MakeDate(strV As String)
    If IsDate(strV) Then
      Return CDate(strV).ToString("yyyy\-MM\-dd")
    Else
      If strV.Trim.Length = 8 Then
        strV = strV.Trim
        Return strV.Substring(0, 4) & "-" & strV.Substring(4, 2) & "-" & strV.Substring(6, 2)
      Else
        Return strV.Trim
      End If
    End If
  End Function

  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    Me.Close()
  End Sub
  Private Sub Head()
    Dim r As DataRow = rsT.Rows(0)
    LBT.ADD_PG("01", "")
    LBT.ADD_PG("02", strTG001 & " " & r.Item(2).ToString.Trim)
    LBT.ADD_PG("03", strMQ002)
    LBT.ADD_PG("04", r.Item(5).ToString.Trim)
    LBT.ADD_PG("05", r.Item(3).ToString.Trim & " " & r.Item(4).ToString.Trim)
    LBT.ADD_PG("07", r.Item(6).ToString.Trim)
    LBT.ADD_PG("08", intCPage)
    LBT.ADD_PG("09", intTPage)
    LBT.ADD_PG("11", Now.ToString("yyyy\-MM\-dd"))
    LBT.ADD_PG("12", strMQ002)
    s1.Text = strTG001 & " " & r.Item(2).ToString.Trim
    s1.Resolution = 300
    s1.Quility = 2
    s1.Versize = 3
    s1.DrawFact = 0.3
    LBT.ADD_PG("10", s1.Draw)
    LBT.PrtLBL()
  End Sub
  Private Sub Items(r As DataRow)
    LBT.ADD_PG("20", r.Item(0).ToString.Trim)
    LBT.ADD_PG("21", r.Item(1).ToString.Trim)
    LBT.ADD_PG("22", r.Item(2).ToString.Trim)
    LBT.ADD_PG("23", r.Item(3).ToString.Trim)
    LBT.ADD_PG("25", r.Item(5).ToString.Trim)
    LBT.ADD_PG("26", Val(r.Item(6).ToString).ToString("#,##0"))
    LBT.ADD_PG("27", r.Item(7).ToString.Trim)
    LBT.ADD_PG("28", Val(r.Item(8).ToString).ToString("#,##0"))
    LBT.ADD_PG("29", Val(r.Item(9).ToString).ToString("#,##0"))
    LBT.ADD_PG("30", r.Item(10).ToString.Trim)
    LBT.PrtLBL()
    LBT.ADD_PG("32", "")
    LBT.ADD_PG("24", r.Item(4).ToString.Trim)
    LBT.ADD_PG("31", r.Item(11).ToString.Trim)
    LBT.PrtLBL()
  End Sub
  Private Sub ToPrint()
    If ComboBox2.Text.ToUpper.Trim("() ".ToCharArray) = "NONE" Or ComboBox2.Text.Trim = "" Then Return
    Dim r As DataRowView = TG001.SelectedItem
    If r Is Nothing Or aryTKD.Count = 0 Then Return
    strTG001 = r!MQ001.ToString.Trim
    strMQ002 = r!MQ002.ToString.Trim
    If strTG001.Trim = "" Or strMQ002.Trim = "" Then Return
    If My.Settings.PRINTER <> ComboBox2.Text.Trim Then
      My.Settings.PRINTER = ComboBox2.Text.Trim
      My.Settings.Save()
    End If
    LBT = New clsLBPRT
    LBT.PrinterName = ComboBox2.Text.Trim
    Dim strF As String = GetTextFile("0324")
    Dim intL As Integer = 0
    LBT.InitLBL(strF)
    For Each strV As String In aryTKD
      If strV.Trim = "" Then Continue For
      GetTicket(strV)
      If rsT Is Nothing Or rsD Is Nothing Then Continue For
      If rsT.Rows.Count = 0 Or rsD.Rows.Count = 0 Then Continue For
      intCPage = 1
      intTPage = (rsD.Rows.Count + 4) \ 5
      If intL > 0 Then
        LBT.NewPage()
      End If
      Head()
      intL = 0
      For Each r2 As DataRow In rsD.Rows
        If intL >= 5 Then
          intL = 0
          intCPage += 1
          LBT.NewPage()
          Head()
        End If
        Items(r2)
        intL += 1
      Next
    Next
    LBT.PrtDialog()
  End Sub
  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    If DG2.Rows.Count = 0 Then Return
    aryTKD.Clear()
    For Each r1 As DataGridViewRow In DG2.Rows
      If isCellNull(r1.Cells(0)) = False AndAlso r1.Cells(0).Value = True Then
        aryTKD.Add(GCell(r1.Cells(1)))
      End If
    Next
    ToPrint()
  End Sub

  Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
    Dim sqlCV As New APSQL.SQLCNV
    Dim r1 As DataRowView = TG001.SelectedItem
    If r1 Is Nothing Or (CheckBox1.Checked = True And CheckBox2.Checked = True) Then Return
    If DBERP Is Nothing OrElse DBERP.Active = False Then Return
#If K3 = 1 Then
#ElseIf K3 = 2 Then
    If r1!MQ003.ToString.Trim.StartsWith("5") Then
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "MOCTH")
      sqlCV.Where("^0.TH001", "=", TG001.SelectedValue.ToString.Trim)
      If CheckBox1.Checked = True Then
        sqlCV.Where("^0.TH002", ">=", TK1.Text.Trim)
        sqlCV.Where("^0.TH002", "<=", TK2.Text.Trim)
      End If
      If CheckBox2.Checked = True Then
        sqlCV.Where("^0.TH003", ">=", DTP1.Value.ToString("yyyyMMdd"))
        sqlCV.Where("^0.TH003", "<=", DTP2.Value.ToString("yyyyMMdd"))
      End If
      sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "PURMA", "MA001", "=", "^0.TH005")
      sqlCV.SqlFields("Convert(bit,0)", "打印")
      sqlCV.SqlFields("^0.TH002", "單號")
      sqlCV.SqlFields("^0.TH003", "單據日期")
      sqlCV.SqlFields("RTRIM(^0.TH005)+' '+RTRIM(^1.MA002)", "廠商")
      sqlCV.SqlFields("^0.TH010", "備註")
      Dim rs As DataTable = DBERP.RsSQL(sqlCV.Text, "RT")
      DG2.DataSource = rs
    Else
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "PURTG")
      sqlCV.Where("^0.TG001", "=", TG001.SelectedValue.ToString.Trim)
      If CheckBox1.Checked = True Then
        sqlCV.Where("^0.TG002", ">=", TK1.Text.Trim)
        sqlCV.Where("^0.TG002", "<=", TK2.Text.Trim)
      End If
      If CheckBox2.Checked = True Then
        sqlCV.Where("^0.TG014", ">=", DTP1.Value.ToString("yyyyMMdd"))
        sqlCV.Where("^0.TG014", "<=", DTP2.Value.ToString("yyyyMMdd"))
      End If
      sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "PURMA", "MA001", "=", "^0.TG005")
      sqlCV.SqlFields("Convert(bit,0)", "打印")
      sqlCV.SqlFields("^0.TG002", "單號")
      sqlCV.SqlFields("^0.TG014", "日期")
      sqlCV.SqlFields("RTRIM(^0.TG005) + ' ' + RTRIM(^1.MA002)", "廠商")
      sqlCV.SqlFields("^0.TG016", "備註")
    Dim rs As DataTable = DBERP.RsSQL(sqlCV.Text, "RT")
    DG2.DataSource = rs
    End If
#End If
    For Each c As DataGridViewColumn In DG2.Columns
      If c.Index = 0 Then
        c.ReadOnly = False
      Else
        c.ReadOnly = True
      End If
    Next
  End Sub

  Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
    For Each r As DataGridViewRow In DG2.Rows
      r.Cells(0).Value = True
    Next
    If DG2.Rows.Count > 0 Then DG2.CurrentCell = DG2.Rows(0).Cells(0)
  End Sub

  Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
    For Each r As DataGridViewRow In DG2.Rows
      r.Cells(0).Value = False
    Next
    If DG2.Rows.Count > 0 Then DG2.CurrentCell = DG2.Rows(0).Cells(0)
  End Sub

  Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    aryTKD.Clear()
    aryTKD.Add(TG002.Text.Trim)
    ToPrint()
  End Sub

  Private Sub DG2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG2.CellContentClick
    If e.RowIndex < 0 Or e.RowIndex >= DG2.Rows.Count Or e.ColumnIndex <> 1 Then Return
    TG002.Text = GCell(DG2.Rows(e.RowIndex).Cells(1))
    Button1_Click(Nothing, Nothing)
    TabControl1.SelectedIndex = 0
  End Sub

  Private Sub DG2_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DG2.CurrentCellDirtyStateChanged
    DG2.CommitEdit(DataGridViewDataErrorContexts.Commit)
  End Sub
End Class