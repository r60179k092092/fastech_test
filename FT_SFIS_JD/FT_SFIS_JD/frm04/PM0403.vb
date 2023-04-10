Public Class PM0403
  Private strItem As String = ""
  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()

    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    languagechange(Me)

  End Sub

  Private Sub PM0403_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    TuiCK(Me)
  End Sub
  Private Sub PM0403_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TD")
    sqlCV.SqlFields("TD01", "KEYS")
    sqlCV.SqlFields("TD01 + ' ' +  TD02", "DATAS")
    sqlCV.SqlFields("TD02")
    sqlCV.sqlOrder("TD01", APSQL.SQLCNV.intOrder.Order_Dsc)
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "TD1")
    ComboBox1.DisplayMember = "DATAS"
    ComboBox1.ValueMember = "KEYS"
    ComboBox1.DataSource = rs
    ComboBox1.SelectedValue = ""
    rs = DB.RsSQL(sqlCV.Text, "TD2")
    ComboBox2.DisplayMember = "DATAS"
    ComboBox2.ValueMember = "KEYS"
    ComboBox2.DataSource = rs
    ComboBox2.SelectedValue = ""
    TextBox1.Focus()
  End Sub
  Private Sub ReRow(r As DataRow)
    Dim strPPID As String = ""
    Dim strP As String = "'" & r.Item(1).ToString.Trim & "'"
    Dim sqlCV As New APSQL.SQLCNV
    While -1
      If r.Item(3).ToString.Trim = "" Then Exit While
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
      sqlCV.Where("TN07", "IN", strP, intFMode.msfld_field)
      sqlCV.SqlFields("TN01")
      Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
      If rs.Rows.Count = 0 Then
        Exit While
      End If
      strPPID &= "=>"
      strP = ""
      For Each r1 As DataRow In rs.Rows
        strPPID &= r1!TN01.ToString.Trim & ","
        strP &= "'" & r1!TN01.ToString.Trim & "',"
      Next
      strPPID = strPPID.Trim(",")
      strP = strP.Trim(",")
    End While
    r.Item(8) = strPPID
  End Sub
  Private Sub ComboBox1_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBox1.SelectionChangeCommitted
    If ComboBox1.SelectedValue Is Nothing Then Return
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TDA")
    Dim w As SqlWhere = sqlCV.SqlJoin(APSQL.SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TA", "TA01", "=", "^0.TDA03")
    w.Add("SFIS_TA.TA04", "<>", "'STS'")
    sqlCV.Where("^0.TDA01", "=", ComboBox1.SelectedValue.ToString.Trim)
    sqlCV.SqlFields("^0.TDA02", , , , True)
    sqlCV.SqlFields("^0.TDA03", "KEYS")
    sqlCV.SqlFields("^0.TDA03+' '+^1.TA02", "DATAS")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "TDA")
    ComboBox3.ValueMember = "KEYS"
    ComboBox3.DisplayMember = "DATAS"
    ComboBox3.DataSource = rs
    strItem = CType(ComboBox1.SelectedItem, DataRowView)!TD02.ToString.Trim
    'sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TN")
    'sqlCV.Where("TN02", "=", ComboBox1.SelectedValue.ToString.Trim)
    'sqlCV.SqlFields("Convert(Bit,0)", "返工")
    'sqlCV.SqlFields("TN01", "PPID")
    'sqlCV.SqlFields("TN02", "工單號")
    'sqlCV.SqlFields("TN03", "工序")
    'sqlCV.SqlFields("TN05", "返工工序")
    'sqlCV.SqlFields("TN04", "時間")
    'sqlCV.SqlFields("TN06", "狀態")
    'sqlCV.SqlFields("TN07", "下層PPID")
    'sqlCV.SqlFields("('')", "上層PPID")
    'rs = DB.RsSQL(sqlCV.Text, "TL")
    'For Each r As DataRow In rs.Rows
    '  ReRow(r)
    'Next
    'DG.DataSource = rs
    'For intI As Integer = 1 To DG.ColumnCount - 1
    '  DG.Columns(intI).ReadOnly = True
    'Next
    'For Each r As DataGridViewRow In DG.Rows
    '  If "0123".Contains(GCell(r.Cells(6))) = False Or GCell(r.Cells(3)) = "" Then
    '    r.DefaultCellStyle.BackColor = Color.Gray
    '    r.ReadOnly = True
    '  End If
    'Next
    My.Computer.Keyboard.SendKeys(vbTab)
  End Sub

  Private Sub ComboBox2_LostFocus(sender As Object, e As EventArgs) Handles ComboBox2.LostFocus, ComboBox1.LostFocus, ComboBox3.LostFocus
    TextBox1.Text = ""
    TextBox1.Focus()
  End Sub

  Private Sub ComboBox2_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBox2.SelectionChangeCommitted
    If ComboBox2.SelectedValue Is Nothing Then Return
    If ComboBox1.SelectedItem Is Nothing Then
      ComboBox1.SelectedValue = ComboBox2.SelectedValue
      ComboBox1_SelectionChangeCommitted(Nothing, Nothing)
    End If
    If strItem <> CType(ComboBox2.SelectedItem, DataRowView)!TD02.ToString.Trim Then
      MsgBox(BIG2GB("返工工單料號與投入工單料號不同，無法返工"))
      Return
    End If
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TN")
    sqlCV.Where("TN02", "=", ComboBox2.SelectedValue.ToString.Trim)
    sqlCV.SqlFields("Convert(Bit,0)", "返工")
    sqlCV.SqlFields("TN01", "PPID")
    sqlCV.SqlFields("TN02", "工單號")
    sqlCV.SqlFields("TN03", "工序")
    sqlCV.SqlFields("TN05", "返工工序")
    sqlCV.SqlFields("TN04", "時間")
    sqlCV.SqlFields("TN06", "狀態")
    sqlCV.SqlFields("TN07", "下層PPID")
    sqlCV.SqlFields("('')", "上層PPID")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "TL")
    For Each r As DataRow In rs.Rows
      ReRow(r)
    Next
    DG.DataSource = rs
    For intI As Integer = 1 To DG.ColumnCount - 1
      DG.Columns(intI).ReadOnly = True
    Next
    For Each r As DataGridViewRow In DG.Rows
      If "0123".Contains(GCell(r.Cells(6))) = False Or GCell(r.Cells(3)) = "" Then
        r.DefaultCellStyle.BackColor = Color.Gray
        r.ReadOnly = True
      End If
    Next
    My.Computer.Keyboard.SendKeys(vbTab)
  End Sub

  Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
    If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
      e.Handled = True
      My.Computer.Keyboard.SendKeys(vbTab)
    End If
  End Sub

  Private Sub ComboBox3_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBox3.SelectionChangeCommitted
    My.Computer.Keyboard.SendKeys(vbTab)
  End Sub

  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    For Each r As DataGridViewRow In DG.Rows
      If r.ReadOnly = True Then Continue For
      r.Cells(0).Value = True
    Next
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    For Each r As DataGridViewRow In DG.Rows
      If r.ReadOnly = True Then Continue For
      r.Cells(0).Value = False
    Next
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    If ComboBox1.SelectedValue Is Nothing Or ComboBox3.SelectedValue Is Nothing Then Return
    If DG.Rows.Count = 0 Then Return
    Dim sqlCV As New APSQL.SQLCNV
    Dim intQ As Integer = 0
    Dim strMO As String = ComboBox1.SelectedValue.ToString.Trim
    Dim strGrp As String = ComboBox3.SelectedValue.ToString.Trim
    For Each r As DataGridViewRow In DG.Rows
      If r.Cells(0).Value = True Then
        intQ += 1
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_update, "SFIS_TN")
        sqlCV.Where("TN01", "=", GCell(r.Cells(1)))
        sqlCV.SqlFields("TN02", strMO)
        sqlCV.SqlFields("TN03", strGrp)
        sqlCV.SqlFields("TN05", strGrp)
        sqlCV.SqlFields("TN06", 2, APSQL.intFMode.msfld_num)
        If CheckBox1.Checked Then
          sqlCV.SqlFields("TN12", "NULL", intFMode.msfld_field)
          sqlCV.SqlFields("TN14", "NULL", intFMode.msfld_field)
          sqlCV.SqlFields("TN15", "NULL", intFMode.msfld_field)
        End If
        DB.RsSQL(sqlCV.Text)
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "SFIS_TM")
        sqlCV.SqlFields("TM01", GCell(r.Cells(1)))
        sqlCV.SqlFields("TM02", GCell(r.Cells(3)))
        sqlCV.SqlFields("TM03", lgncode)
        sqlCV.SqlFields("TM04", My.Computer.Name.Trim)
        sqlCV.SqlFields("TM05", "")
        sqlCV.SqlFields("TM06", Now, APSQL.intFMode.msfld_datetime)
        sqlCV.SqlFields("TM07", "")
        sqlCV.SqlFields("TM08", 4, APSQL.intFMode.msfld_num)
        sqlCV.SqlFields("TM09", "RW:" & GCell(r.Cells(2)) & ":" & GCell(r.Cells(3)) & ":" & GCell(r.Cells(6)))
        DB.RsSQL(sqlCV.Text)
        If CheckBox2.Checked Then
          sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TS")
          sqlCV.Where("TS01", "=", GCell(r.Cells(1)))
          sqlCV.SqlFields("TS02")
          sqlCV.SqlFields("TS03")
          Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
          Dim strSN As String = "", strMAC As String = ""
          For Each r1 As DataRow In rs.Rows
            If r1!TS03.ToString.Trim Like "SN*" Then
              strSN = r1!TS02.ToString.Trim
            End If
            If r1!TS03.ToString.Trim Like "MAC*" Then
              strMAC = r1!TS02.ToString.Trim
            End If
          Next
          For Each r1 As DataRow In rs.Rows
            If strSN = r1!TS02.ToString.Trim Then
              sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_TS")
              sqlCV.Where("TS01", "=", GCell(r.Cells(1)))
              sqlCV.Where("TS02", "=", r1!TS02.ToString.Trim)
              sqlCV.SqlFields("TS01", strSN)
              sqlCV.SqlFields("TS03", GCell(r.Cells(2)) & vbTab & r1!TS03.ToString.Trim)
              DB.RsSQL(sqlCV.Text)
            Else
              sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_TS")
              sqlCV.Where("TS01", "=", GCell(r.Cells(1)))
              sqlCV.Where("TS02", "=", r1!TS02.ToString.Trim)
              sqlCV.SqlFields("TS01", strMAC)
              sqlCV.SqlFields("TS03", GCell(r.Cells(2)) & vbTab & r1!TS03.ToString.Trim)
              DB.RsSQL(sqlCV.Text)
            End If
          Next
        End If
        If CheckBox3.Checked Then
          sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_TN")
          sqlCV.Where("TN07", "=", GCell(r.Cells(1)))
          sqlCV.Where("TN06", "=", 7, intFMode.msfld_num)
          sqlCV.SqlFields("TN07", "NULL", intFMode.msfld_field)
          sqlCV.SqlFields("TN06", "4", intFMode.msfld_num)
          DB.RsSQL(sqlCV.Text)
          sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_TE")
          sqlCV.Where("TE14", "=", GCell(r.Cells(1)))
          sqlCV.SqlFields("TE14", "NULL", intFMode.msfld_field)
          sqlCV.SqlFields("TE04", 1, intFMode.msfld_num)
          sqlCV.SqlFields("TE05", 0, intFMode.msfld_num)
          sqlCV.SqlFields("TE07", 1, intFMode.msfld_num)
          sqlCV.SqlFields("TE09", 1, intFMode.msfld_num)
          DB.RsSQL(sqlCV.Text)
        End If
      End If
    Next
    MsgBox(BIG2GB("重工設置完成一共設定" & intQ & "筆 ID"))
    ComboBox2_SelectionChangeCommitted(Nothing, Nothing)
  End Sub

  Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    Me.Close()
  End Sub

  Private Sub DG_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DG.CellFormatting
    If e.ColumnIndex = 6 Then
      Dim intV As Integer = Val(GCell(DG.Rows(e.RowIndex).Cells(e.ColumnIndex)))
      Select Case intV
        Case 0
          e.Value = BIG2GB("正常")
        Case 1
          e.Value = BIG2GB("送修")
        Case 2
          e.Value = BIG2GB("返工")
        Case 3
          e.Value = BIG2GB("暫停")
        Case 4
          e.Value = BIG2GB("完工")
        Case 5
          e.Value = BIG2GB("出貨")
        Case 7
          e.Value = BIG2GB("下層綁定")
        Case 8
          e.Value = BIG2GB("報廢")
        Case 100
          e.Value = BIG2GB("底面ID")
      End Select
    End If
  End Sub

  Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles TextBox1.LostFocus
    If TextBox1.Text.Trim = "" Then Return
    If ComboBox1.SelectedValue Is Nothing Then
      ComboBox1.Focus()
      MsgBox(BIG2GB("返工工單沒有設置無法設定PPID"))
      Return
    End If
    Dim strM() As String = TextBox1.Text.Trim.Split("|/\".ToCharArray)
    Dim sqlCV As New APSQL.SQLCNV
    Select Case strM.Length
      Case 1
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TS")
        sqlCV.Where("TS02", "=", strM(0))
        sqlCV.SqlFields("TS01")
        Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        If rs.Rows.Count > 0 Then
          strM(0) = rs.Rows(0)!TS01.ToString.Trim
        End If
        Do
          sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
          sqlCV.Where("TN01", "=", strM(0))
          sqlCV.SqlFields("TN01")
          sqlCV.SqlFields("TN02")
          sqlCV.SqlFields("TN03")
          sqlCV.SqlFields("TN06")
          sqlCV.SqlFields("TN07")
          rs = DB.RsSQL(sqlCV.Text, "RT")
          If rs.Rows.Count = 0 Then
            TextBox1.Text = ""
            TextBox1.Focus()
            MsgBox(BIG2GB("無法找到這個PPID :" & strM(0)))
            Return
          End If
          If rs.Rows(0)!TN06.ToString.Trim = "7" Or rs.Rows(0)!TN06.ToString.Trim = "100" Then
            strM(0) = rs.Rows(0)!TN07.ToString.Trim
            Continue Do
          ElseIf "0123".Contains(rs.Rows(0)!TN06.ToString.Trim) = False Or rs.Rows(0)!TN03.ToString.Trim = "" Then
            TextBox1.Text = ""
            TextBox1.Focus()
            MsgBox(BIG2GB("無法重工已經完工或未曾生產的PPID"))
            Return
          Else
            TextBox1.Text = strM(0).Trim
            Exit Do
          End If
        Loop
      Case 4, 5, 6, 7, 8, 9
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TE")
        sqlCV.Where("TE01", "=", strM(0))
        sqlCV.Where("TE02", "=", strM(0) & "_" & strM(1))
        sqlCV.Where("TE03", "=", strM(3))
        sqlCV.SqlFields("TE14")
        Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        If rs.Rows.Count > 0 Then
          TextBox1.Text = rs.Rows(0)!TE14.ToString.Trim
        Else
          MsgBox(BIG2GB("無法找到半成品SN :" & TextBox1.Text))
          TextBox1.Text = ""
          TextBox1.Focus()
          Return
        End If
        DB.CloseRs(rs)
    End Select
    Dim strK As String = TextBox1.Text.Trim
    For Each r As DataGridViewRow In DG.Rows
      If GCell(r.Cells(1)) = strK Then
        r.Cells(0).Value = True
        DG.CurrentCell = r.Cells(0)
        TextBox1.Text = ""
        TextBox1.Focus()
        Return
      End If
    Next
    Dim rs1 As DataTable = Nothing
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TN")
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TD", "TD01", "=", "^0.TN02")
    sqlCV.Where("TN01", "=", strK)
    sqlCV.SqlFields("TN01")
    sqlCV.SqlFields("TN02")
    sqlCV.SqlFields("TN03")
    sqlCV.SqlFields("TN05")
    sqlCV.SqlFields("TN04")
    sqlCV.SqlFields("TN06")
    sqlCV.SqlFields("TN07")
    sqlCV.SqlFields("TD03")
    rs1 = DB.RsSQL(sqlCV.Text, "RT")
    If rs1.Rows.Count = 0 Then
      MsgBox(BIG2GB("無法找到這個PPID :" & strK))
      TextBox1.Text = ""
      TextBox1.Focus()
      Return
    End If
    If rs1.Rows(0)!TD03.ToString.Trim <> strItem Then
      TextBox1.Text = ""
      TextBox1.Focus()
      MsgBox(BIG2GB("無法返工與返工工單不同料號的PPID"))
      Return
    End If
    Dim rs2 As DataTable = DG.DataSource
    If rs2 Is Nothing Then
      TextBox1.Text = ""
      TextBox1.Focus()
      MsgBox(BIG2GB("未選擇任何工單"))
      Return
    End If
    For Each r As DataRow In rs2.Rows
      If rs1.Rows(0).Item(0).ToString.Trim = r.Item(1).ToString.Trim Then
        r.Item(0) = 1
        TextBox1.Text = ""
        TextBox1.Focus()
        Return
      End If
    Next
    Dim r1 As DataRow = rs2.NewRow()
    r1.Item(0) = 1
    For intI As Integer = 1 To rs1.Columns.Count - 1
      r1.Item(intI) = rs1.Rows(0).Item(intI - 1)
    Next
    ReRow(r1)
    rs2.Rows.Add(r1)
    TextBox1.Text = ""
    TextBox1.Focus()
  End Sub

  Private Sub DG_SortCompare(sender As Object, e As DataGridViewSortCompareEventArgs) Handles DG.SortCompare
    For Each r As DataGridViewRow In DG.Rows
      If r.ReadOnly = True Then
        r.DefaultCellStyle.BackColor = Color.Gray
      End If
    Next
  End Sub
End Class