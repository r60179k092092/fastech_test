Public Class Frm0325
  Private strTA001 As String = ""
  Private strMQ002 As String = ""
  Private intTPage As Integer = 0
  Private intCPage As Integer = 0
  Private rsT As DataTable = Nothing
  Private aryTID As New ArrayList
  Private LBT As clsLBPRT = Nothing
  Private s1 As New LABTRANx64.Labtran.QRCODE
  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()
    languagechange(Me)
    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

  End Sub

  Private Sub Frm0325_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    TuiCK(Me)
  End Sub
  Private Sub Frm0325_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim sqlCV As New APSQL.SQLCNV, rs As DataTable = Nothing, rs1 As DataTable = Nothing
    If DBERP IsNot Nothing AndAlso DBERP.Active = True Then
#If K3 = 1 Then
#ElseIf K3 = 2 Then
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "CMSMQ")
    sqlCV.Where("MQ003", "Like", "5%")
    sqlCV.SqlFields("MQ001", "KEYS", , , True)
    sqlCV.SqlFields("RTRIM(MQ001) + '-' + RTRIM(MQ002)", "DATAS")
    sqlCV.SqlFields("MQ002")
    rs = DBERP.RsSQL(sqlCV.Text, "RMQ")
#End If
    End If
    TA001.DisplayMember = "DATAS"
    TA001.ValueMember = "KEYS"
    TA001.DataSource = rs
    If rs IsNot Nothing AndAlso rs.Rows.Count > 0 Then
      TA001.SelectedValue = rs.Rows(0)!KEYS.ToString
    End If
    ComboBox2.Items.Clear()
    ComboBox2.Items.Add("none")
        For Each strV As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            ComboBox2.Items.Add(strV)
        Next
    ComboBox2.SelectedIndex = ComboBox2.Items.IndexOf(My.Settings.PRINTER)
    If ComboBox2.SelectedIndex < 0 Then ComboBox2.SelectedIndex = 0
    If DBERP IsNot Nothing AndAlso DBERP.Active = True Then
#If K3 = 1 Then
#ElseIf K3 = 2 Then
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_distinc, "CMSMK")
    Dim w As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "CMSMJ", "MJ001", "=", "^0.MK001")
    w.Add("CMSMJ.MJ002", "IN", "('1','2','7','9','F')")
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "CMSMV", "MV001", "=", "^0.MK002")
    sqlCV.SqlFields("RTRIM(^2.MV002)", "DATAS", , , True)
    sqlCV.SqlFields("^2.MV001", , , , True)
    SaveLog(sqlCV.Text)
    rs = DBERP.RsSQL(sqlCV.Text, "RSMV")
    rs1 = DBERP.RsSQL(sqlCV.Text, "RSMV1")
#End If
    End If
    ComboBox1.DisplayMember = "DATAS"
    ComboBox1.ValueMember = "MV001"
    ComboBox1.DataSource = rs
    ComboBox3.DisplayMember = "DATAS"
    ComboBox3.ValueMember = "MV001"
    ComboBox3.DataSource = rs1
  End Sub

  Private Sub TA002_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TA002.KeyPress
    If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
      e.Handled = True
      My.Computer.Keyboard.SendKeys(vbTab)
    End If
  End Sub
  Private Sub GetTickets(strID As String)
    rsT = Nothing
    strTA001 = ""
    strMQ002 = ""
    If TA001.SelectedValue Is Nothing Then Return
    Dim r As DataRowView = TA001.SelectedItem
    If r Is Nothing Or (CheckBox1.Checked = True And CheckBox2.Checked = True) Then Return
    If DBERP Is Nothing OrElse DBERP.Active = False Then Return
    Dim sqlCV As New APSQL.SQLCNV
#If K3 = 1 Then
#ElseIf K3 = 2 Then
    strTA001 = r!MQ001.ToString.Trim
    strMQ002 = r!MQ002.ToString.Trim
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "MOCTA")
    sqlCV.Where("^0.TA001", "=", strTA001)
    sqlCV.Where("^0.TA002", "=", strID.Trim)
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "CMSMC", "MC001", "=", "^0.TA020")
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "CMSMD", "MD001", "=", "^0.TA021")
    Dim w As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "COPTC", "TC001", "=", "^0.TA026")
    w.Add("COPTC.TC002", "=", "MOCTA.TA027")
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "COPMA", "MA001", "=", "^3.TC004")
    sqlCV.SqlFields("^0.TA001")
    sqlCV.SqlFields("^0.TA002")
    sqlCV.SqlFields("^0.TA003")
    sqlCV.SqlFields("^0.TA006")
    sqlCV.SqlFields("^0.TA009")
    sqlCV.SqlFields("^0.TA010")
    sqlCV.SqlFields("^0.TA015")
    sqlCV.SqlFields("^0.TA020")
    sqlCV.SqlFields("^0.TA021")
    sqlCV.SqlFields("^1.MC002")
    sqlCV.SqlFields("^2.MD002")
    sqlCV.SqlFields("^0.TA034")
    sqlCV.SqlFields("^0.TA035")
    sqlCV.SqlFields("^0.TA026")
    sqlCV.SqlFields("^0.TA027")
    sqlCV.SqlFields("^0.TA028")
    sqlCV.SqlFields("^0.TA029")
    sqlCV.SqlFields("^3.TC004")
    sqlCV.SqlFields("^3.TC012")
    sqlCV.SqlFields("^4.MA002")
    rsT = DBERP.RsSQL(sqlCV.Text, "RTB")
#End If
  End Sub
  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    GetTickets(TA002.Text.Trim)
    If rsT Is Nothing OrElse rsT.Rows.Count = 0 Then Return
    Dim r As DataRow = rsT.Rows(0)
    TA002.Text = r!TA002.ToString.Trim
    TA003.Text = MakeDate(r!TA003.ToString)
    TA020.Text = r!TA020.ToString.Trim & " " & r!MC002.ToString.Trim
    TA021.Text = r!TA021.ToString.Trim & " " & r!MD002.ToString.Trim
    TA006.Text = r!TA006.ToString.Trim
    TA034.Text = r!TA034.ToString.Trim
    TA035.Text = r!TA035.ToString.Trim
    TA015.Text = r!TA015.ToString.Trim
    TA009.Text = r!TA009.ToString.Trim
    TA010.Text = r!TA010.ToString.Trim
    TA026.Text = r!TA026.ToString.Trim & " " & r!TA027.ToString.Trim & " " & r!TA028.ToString.Trim
    TC004.Text = r!MA002.ToString.Trim
    TC012.Text = r!TC012.ToString.Trim
    TA029.Text = r!TA029.ToString.Trim
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

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    If rsT Is Nothing Then Return
    aryTID.Clear()
    aryTID.Add(TA002.Text.Trim)
    ToPrint()
  End Sub

  Private Sub TA002_LostFocus(sender As Object, e As EventArgs) Handles TA002.LostFocus
    Button1_Click(Nothing, Nothing)
  End Sub

  Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    Me.Close()
  End Sub

  Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
    For Each r As DataGridViewRow In DG2.Rows
      r.Cells(0).Value = True
    Next
  End Sub

  Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
    For Each r As DataGridViewRow In DG2.Rows
      r.Cells(0).Value = False
    Next
  End Sub

  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    If TA001.SelectedValue Is Nothing Then Return
    Dim sqlCV As New APSQL.SQLCNV
    If DBERP Is Nothing OrElse DBERP.Active = False Then Return
#If K3 = 1 Then
#ElseIf K3 = 2 Then
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "MOCTA")
    sqlCV.Where("^0.TA001", "=", TA001.SelectedValue.ToString.Trim)
    If CheckBox1.Checked Then
      sqlCV.Where("^0.TA002", ">=", TK1.Text.Trim)
      sqlCV.Where("^0.TA002", "<=", TK2.Text.Trim)
    End If
    If CheckBox2.Checked Then
      sqlCV.Where("^0.TA003", ">=", DTP1.Value.ToString("yyyyMMdd"))
      sqlCV.Where("^0.TA003", "<=", DTP2.Value.ToString("yyyyMMdd"))
    End If
    sqlCV.SqlFields("Convert(Bit,0)", "打印")
    sqlCV.SqlFields("^0.TA002", "工單編號")
    sqlCV.SqlFields("^0.TA003", "開單日期")
    sqlCV.SqlFields("^0.TA006", "品號")
    sqlCV.SqlFields("RTRIM(^0.TA034)+' '+RTRIM(^0.TA035)", "品名規格")
    sqlCV.SqlFields("^0.TA015", "生產數量")
    sqlCV.SqlFields("^0.TA007", "單位")
    sqlCV.SqlFields("^0.TA009", "預計開工")
    sqlCV.SqlFields("^0.TA010", "預計完工")
    sqlCV.SqlFields("^0.TA011", "狀態")
    sqlCV.SqlFields("RTRIM(^0.TA026)+'-'+RTRIM(^0.TA027)+'-'+RTRIM(^0.TA028)", "訂單編號")
    Dim rs As DataTable = DBERP.RsSQL(sqlCV.Text, "RTA")
    DG2.DataSource = rs
#End If
    For Each c As DataGridViewColumn In DG2.Columns
      If c.Index = 0 Then
        c.ReadOnly = False
      Else
        c.ReadOnly = True
      End If
    Next
  End Sub

  Private Sub DG2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG2.CellContentClick
    If e.RowIndex < 0 Or e.RowIndex >= DG2.Rows.Count Or e.ColumnIndex <> 1 Then Return
    TA002.Text = GCell(DG2.Rows(e.RowIndex).Cells(1))
    Button1_Click(Nothing, Nothing)
    TabControl1.SelectedIndex = 0
  End Sub

  Private Sub DG2_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DG2.CellFormatting
    Select Case e.ColumnIndex
      Case 2
        e.Value = MakeDate(e.Value)
      Case 7
        Select Case GCell(DG2.Rows(e.RowIndex).Cells(e.ColumnIndex))
          Case "1"
            e.Value = "未開工"
          Case "2"
            e.Value = "已發料"
          Case "3"
            e.Value = "已生產"
          Case "y", "Y"
            e.Value = "完工"
        End Select
    End Select
  End Sub

  Private Sub DG2_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DG2.CurrentCellDirtyStateChanged
    DG2.CommitEdit(DataGridViewDataErrorContexts.Commit)
  End Sub
  Private Sub ToPrint()
    If aryTID.Count = 0 Then Return
    If ComboBox2.Text.ToUpper.Trim("() ".ToCharArray) = "NONE" Or ComboBox2.Text.Trim = "" Then Return
    If My.Settings.PRINTER <> ComboBox2.Text.Trim Then
      My.Settings.PRINTER = ComboBox2.Text.Trim
      My.Settings.Save()
    End If
    LBT = New clsLBPRT
    LBT.PrinterName = ComboBox2.Text.Trim
    Dim strF As String = GetTextFile("0325")
    LBT.InitLBL(strF)
    Dim intI As Integer = 0
    For Each strID As String In aryTID
      GetTickets(strID)
      If rsT Is Nothing Then Continue For
      If intI > 0 Then
        LBT.NewPage()
      End If
      Dim r As DataRow = rsT.Rows(0)
      intI += 1
      intCPage = 1
      intTPage = 1
      LBT.ADD_PG("01", "")
      LBT.ADD_PG("04", MakeDate(r!TA003.ToString.Trim))
      LBT.ADD_PG("11", Now.ToString("yyyy\-MM\-dd"))
      s1.Text = strTA001 & "-" & strID
      s1.Resolution = 300
      s1.Quility = 2
      s1.Versize = 3
      s1.DrawFact = 0.3
      LBT.ADD_PG("10", s1.Draw)
      LBT.PrtLBL()
      LBT.ADD_PG("21", "")
      LBT.ADD_PG("03", strTA001 & " " & strID)
      LBT.ADD_PG("09", r!TA020.ToString.Trim & " " & r!MC002.ToString.Trim)
      LBT.ADD_PG("20", r!TA021.ToString.Trim & " " & r!MD002.ToString.Trim)
      LBT.PrtLBL()
      LBT.ADD_PG("22", "")
      LBT.ADD_PG("05", r!TA006.ToString.Trim)
      LBT.ADD_PG("06", r!TA034.ToString.Trim)
      LBT.ADD_PG("07", r!TA035.ToString.Trim)
      LBT.PrtLBL()
      LBT.ADD_PG("23", "")
      LBT.ADD_PG("12", Val(r!TA015.ToString).ToString("#,##0"))
      LBT.ADD_PG("13", MakeDate(r!TA009.ToString.Trim))
      LBT.ADD_PG("14", MakeDate(r!TA010.ToString.Trim))
      LBT.PrtLBL()
      LBT.ADD_PG("24", "")
      LBT.ADD_PG("15", r!TA026.ToString.Trim & " " & r!TA027.ToString.Trim & " " & r!TA028.ToString.Trim)
      LBT.ADD_PG("16", r!MA002.ToString.Trim)
      LBT.ADD_PG("17", r!TC012.ToString.Trim)
      LBT.PrtLBL()
      LBT.ADD_PG("25", "")
      LBT.ADD_PG("02", r!TA029.ToString.Trim)
      LBT.PrtLBL()
      LBT.ADD_PG("26", "")
      LBT.ADD_PG("18", ComboBox1.Text.Trim)
      LBT.ADD_PG("19", ComboBox3.Text.Trim)
      LBT.PrtLBL()
    Next
    LBT.PrtDialog()
  End Sub
  Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
    aryTID.Clear()
    For Each r As DataGridViewRow In DG2.Rows
      If isCellNull(r.Cells(0)) = False AndAlso r.Cells(0).Value = True Then
        aryTID.Add(GCell(r.Cells(1)))
      End If
    Next
    ToPrint()
  End Sub
End Class