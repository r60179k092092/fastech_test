Public Class Frm0506A
  Private XLSMA As XLS_FILE = Nothing
  Private aryTJ As New Dictionary(Of String, String)
  Private aryTK As New Dictionary(Of String, String)
  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()

    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    languagechange(Me)
  End Sub
  Private Sub CalTS(strMO As String)
    Dim sqlCV As New APSQL.SQLCNV
    aryTK.Clear()
    aryTJ.Clear()
    If strMO.Trim = "" Then Return
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TJ")
    sqlCV.SqlFields("TJ01")
    sqlCV.SqlFields("TJ03")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    For Each r As DataRow In rs.Rows
      If aryTJ.ContainsKey(r!TJ01.ToString.Trim) = False Then
        aryTJ.Add(r!TJ01.ToString.Trim, r!TJ03.ToString.Trim)
      End If
    Next
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_distinc, "SFIS_TM")
    sqlCV.Where("^0.TM06", ">=", DTP1.Value.ToString("yyyy\/MM\/dd"), intFMode.msfld_date)
    sqlCV.Where("^0.TM06", "<=", DTP2.Value.ToString("yyyy\/MM\/dd"), intFMode.msfld_date)
    Dim w As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TN", "TN01", "=", "^0.TM01")
    w.Add("SFIS_TN.TN02", "IN", "(" & strMO.Trim(",") & ")")
    sqlCV.SqlFields("Convert(Varchar(10),TM06,111)", "DATV", , , True)
    sqlCV.SqlFields("^0.TM03")
    sqlCV.SqlFields("^1.TN02", , , , True)
    sqlCV.SqlFields("^0.TM04")
    rs = DB.RsSQL(sqlCV.Text, "RT")
    For Each r As DataRow In rs.Rows
      Dim strV() As String = r!TM04.ToString.Trim.Split(",")
      If aryTJ.ContainsKey(strV(0)) Then
        r!TM04 = aryTJ(strV(0))
      Else
        r!TM04 = ""
      End If
    Next
    Dim rv As DataView = rs.DefaultView
    rv.Sort = "DATV ASC,TM04 ASC,TN02 ASC"
    Dim strK As String = "", aryE As New ArrayList
    For Each r As DataRowView In rv
      Dim strV1 As String = r!DATV.ToString.Trim & vbTab & r!TM04.ToString.Trim & vbTab & r!TN02.ToString.Trim
      If strK <> strV1 Then
        If strK <> "" Then
          Dim strMx As String = ""
          For Each strK1 As String In aryE
            strMx &= strK1 & ","
          Next
          aryTK.Add(strK, strMx.Trim(","))
          aryE.Clear()
        End If
        strK = strV1
      End If
      Dim strV() As String = r!TM03.ToString.Trim.Split(",")
      For Each strK1 As String In strV
        If strK1.Trim = "" Or aryE.Contains(strK1) Then Continue For
        aryE.Add(strK1)
      Next
    Next
    Dim strM As String = ""
    For Each strK1 As String In aryE
      strM &= strK1 & ","
    Next
    aryTK.Add(strK, strM.Trim(","))
  End Sub
  Private Sub ReList()
    'Dim dt As Date = DTP1.Value
    Dim strDBG As String = DTP1.Value.ToString("yyyy\/MM\/dd")
    Dim strDED As String = DTP2.Value.ToString("yyyy\/MM\/dd")
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TDC")
    sqlCV.Where("^0.TDC03", ">=", strDBG)
    sqlCV.Where("^0.TDC03", "<=", strDED)
    If isTDC02.Checked And TDC02.Text.Trim <> "" Then
      sqlCV.Where("^0.TDC02", "=", TDC02.Text.Trim)
    End If
    Dim w As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TD", "TD01", "=", "^0.TDC01")
    If isTD01.Checked Then
      If TD01.SelectedValue IsNot Nothing Then
        w.Add("SFIS_TD.TD01", "=", "'" & TD01.SelectedValue.ToString.Trim & "'")
      ElseIf TD01.Text.Trim <> "" Then
        w.Add("SFIS_TD.TD01", "=", "'" & TD01.Text.Trim & "'")
      End If
    End If
    If isTBB03.Checked Then
      If TBB03.SelectedValue IsNot Nothing Then
        w.Add("SFIS_TD.TD02", "=", "'" & TBB03.SelectedValue.ToString.Trim & "'")
      ElseIf TBB03.Text.Trim <> "" Then
        w.Add("SFIS_TD.TD02", "=", "'" & TBB03.Text.Trim & "'")
      End If
    End If
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TBB", "TBB03", "=", "^1.TD02")
    If isTBB04.Checked Then
      If TBB04.Text.Trim <> "" Then
        sqlCV.Where("^2.TBB04", "=", TBB04.Text.Trim)
      End If
    End If
    w = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TB", "TB01", "=", "^2.TBB01")
    w.Add("SFIS_TB.TB02", "=", "SFIS_TBB.TBB02")
    w = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TJAB", "TJAB01", "=", "'@'+^3.TB01+'-'+^3.TB02")
    w.Add("SFIS_TJAB.TJAB02", "=", "SFIS_TBB.TBB03")
    sqlCV.SqlFields("(0)", "[No.]")
    sqlCV.SqlFields("^0.TDC03", "日期", , True, True)
    sqlCV.SqlFields("^0.TDC02", "線別", , True, True)
    sqlCV.SqlFields("^2.TBB04", "機種名稱", , True, True)
    sqlCV.SqlFields("^1.TD05+'-'+^1.TD06", "訂單編號", , True)
    sqlCV.SqlFields("^1.TD01", "工單單號", , True, True) '5
    sqlCV.SqlFields("^1.TD07", "工單數量", , True)
    sqlCV.SqlFields("^3.TB03", "工程段", , True)
    sqlCV.SqlFields("^2.TBB05", "代碼", , True)           '8
    sqlCV.SqlFields("^1.TD02", "產品品號", , True)
    sqlCV.SqlFields("(0)", "累計產量")
    sqlCV.SqlFields("(0)", "投入數")   ' 11
    sqlCV.SqlFields("(0)", "產出數")
    sqlCV.SqlFields("SUM(^0.TDC08)", "不良數")
    sqlCV.SqlFields("('')", "[良率(%)]")
    sqlCV.SqlFields("('')", "作業人數")
    sqlCV.SqlFields("('')", "[生產工時(小時)]") '16
    sqlCV.SqlFields("(1.000*^4.TJAB10/^4.TJAB03)", "平均工時", , True)
    sqlCV.SqlFields("('')", "[標準工時(小時)]")
    sqlCV.SqlFields("('')", "損失工時")
    sqlCV.SqlFields("('')", "[效率(%)]")
    sqlCV.SqlFields("('')", "[備註/說明]")
    Dim rs As DataTable = DB.RsSQL(BIG2GB(sqlCV.Text), "RV")
    Dim aryPID As New Dictionary(Of String, DataRow)
    Dim aryMO As New Dictionary(Of String, Integer)
    Dim intI As Integer = 0, strMO As String = ""
    For Each r As DataRow In rs.Rows
      intI += 1
      r.Item(0) = intI
      If aryMO.ContainsKey(r.Item(5).ToString.Trim) = False Then
        strMO &= "'" & r.Item(5).ToString.Trim & "',"
        aryMO.Add(r.Item(5).ToString.Trim, 0)
      End If
      aryPID.Add(r.Item(1).ToString.Trim & vbTab & r.Item(2).ToString.Trim & vbTab & r.Item(5).ToString.Trim, r)
    Next
    'CalTS(strMO)
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TDC")
    sqlCV.Where("^0.TDC03", ">=", strDBG)
    sqlCV.Where("^0.TDC03", "<=", strDED)
    If isTDC02.Checked And TDC02.Text.Trim <> "" Then
      sqlCV.Where("^0.TDC02", "=", TDC02.Text.Trim)
    End If
    w = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TD", "TD01", "=", "^0.TDC01")
    If isTD01.Checked Then
      If TD01.SelectedValue IsNot Nothing Then
        w.Add("SFIS_TD.TD01", "=", "'" & TD01.SelectedValue.ToString.Trim & "'")
      ElseIf TD01.Text.Trim <> "" Then
        w.Add("SFIS_TD.TD01", "=", "'" & TD01.Text.Trim & "'")
      End If
    End If
    If isTBB03.Checked Then
      If TBB03.SelectedValue IsNot Nothing Then
        w.Add("SFIS_TD.TD02", "=", "'" & TBB03.SelectedValue.ToString.Trim & "'")
      ElseIf TBB03.Text.Trim <> "" Then
        w.Add("SFIS_TD.TD02", "=", "'" & TBB03.Text.Trim & "'")
      End If
    End If
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TBB", "TBB03", "=", "^1.TD02")
    If isTBB04.Checked Then
      If TBB04.Text.Trim <> "" Then
        sqlCV.Where("^2.TBB04", "=", TBB04.Text.Trim)
      End If
    End If
    w = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TDA", "TDA01", "=", "^0.TDC01")
    w.Add("SFIS_TDA.TDA03", "=", "SFIS_TDC.TDC05")
    sqlCV.SqlFields("^0.USEQ")
    sqlCV.SqlFields("^0.TDC03", , , , True)
    sqlCV.SqlFields("^0.TDC02", , , , True)
    sqlCV.SqlFields("^0.TDC01", , , , True)
    sqlCV.SqlFields("^3.TDA02", , , , True)
    sqlCV.SqlFields("^0.TDC06", "T6")
    sqlCV.SqlFields("^0.TDC07", "T7")
    sqlCV.SqlFields("^0.TDC08", "T8")
    sqlCV.SqlFields("^0.TDC09", "T9")
    sqlCV.SqlFields("^0.TDC10", "T10")
    sqlCV.SqlFields("^0.TDC11", "T11")
    sqlCV.SqlFields("^0.TDC12", "T12")
    sqlCV.SqlFields("^0.TDC13")
    sqlCV.SqlFields("^0.TDC14")
    sqlCV.SqlFields("^0.TDC15")
    Dim rs1 As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    Dim strKV As String = "", intT As Integer = 0
    Dim aryLists As New ArrayList, strK14 As String = "", strK15 As String = ""
    Dim intT2 As Integer = 0
    Dim intT7B As Integer = 0, intT7E As Integer = 0, intT7R As Integer = 0, intT7L As Integer = 0
    For Each r As DataRow In rs1.Rows
      If r!TDC13.ToString.Trim = "" Then
        CalTS(strMO)
        Exit For
      End If
    Next
    For Each r As DataRow In rs1.Rows
      Dim strK As String = r!TDC03.ToString.Trim & vbTab & r!TDC02.ToString.Trim & vbTab & r!TDC01.ToString.Trim
      If strKV <> strK Then
        If strKV <> "" Then
          If aryPID.ContainsKey(strKV) = True Then
            With aryPID(strKV)
              .Item(11) = intT7B
              .Item(15) = aryLists.Count.ToString("0")
              .Item(12) = intT7E
              .Item(16) = (intT / 3600.0).ToString("0.00")
              .Item(19) = strK14
              .Item(21) = strK15
              If Val(.Item(11).ToString.Trim) > 0 Then
                .Item(14) = (Val(.Item(12).ToString) / Val(.Item(11).ToString) * 100).ToString("0.0") & "%"
                .Item(18) = (Val(.Item(11).ToString) * Val(.Item(17).ToString)).ToString("0.000")
              End If
            End With
          End If
        End If
        aryLists.Clear()
        If aryTK.ContainsKey(strK) Then
          Dim strVEM() As String = aryTK(strK).Split(",")
          aryLists.AddRange(strVEM)
        End If
        strKV = strK
        strK14 = ""
        strK15 = ""
        intT = 0
        intT7E = 0
        intT7B = 0
        intT7R = Val(r!TDA02.ToString.Trim)
        intT7L = intT7R
        intT2 = 0
      End If
      intT += (Val(r!T11.ToString) * Val(r!T10.ToString))
      If Val(r!TDA02.ToString) = intT7R Then
        intT7B += Val(r!T7.ToString)
        intT7E = intT7B
        intT2 = Val(r!T11.ToString)
      ElseIf intT7L <> Val(r!TDA02.ToString) Then
        intT7L = Val(r!TDA02.ToString)
        intT2 = Val(r!T11.ToString)
        intT7E = Val(r!T7.ToString.Trim)
      Else
        intT2 += Val(r!T11.ToString)
        intT7E += Val(r!T7.ToString.Trim)
      End If
      If CheckBox3.Checked Then
        intT = intT2 * aryLists.Count
      End If
      If r!TDC13.ToString.Trim <> "" Then
        Dim strVEM() As String = r!TDC13.ToString.Trim.Split(",")
        For Each strVES As String In strVEM
          If strVES.Trim = "" Or aryLists.Contains(strVES) = True Then Continue For
          aryLists.Add(strVES)
        Next
      End If
      If r!TDC14.ToString.Trim <> "" Then strK14 = r!TDC14.ToString.Trim
      If r!TDC15.ToString.Trim <> "" Then strK15 = r!TDC15.ToString.Trim
    Next
    If strKV <> "" Then
      If aryPID.ContainsKey(strKV) = True Then
        With aryPID(strKV)
          .Item(11) = intT7B
          .Item(15) = aryLists.Count.ToString("0")
          .Item(12) = intT7E
          .Item(16) = (intT / 3600.0).ToString("0.00")
          .Item(19) = strK14
          .Item(21) = strK15
          If Val(.Item(11).ToString.Trim) > 0 Then
            .Item(14) = (Val(.Item(12).ToString) / Val(.Item(11).ToString) * 100).ToString("0.0") & "%"
            .Item(18) = (Val(.Item(11).ToString) * Val(.Item(17).ToString)).ToString("0.000")
          End If
        End With
      End If
    End If
    If strMO <> "" Then
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
      sqlCV.Where("TN06", "IN", "(4,5,7)", intFMode.msfld_field)
      sqlCV.Where("TN02", "IN", strMO.Trim(","), intFMode.msfld_field)
      sqlCV.SqlFields("TN02", , , True, True)
      sqlCV.SqlFields("COUNT(*)", "Q")
      rs1 = DB.RsSQL(sqlCV.Text, "RT")
      For Each r As DataRow In rs1.Rows
        If aryMO.ContainsKey(r!TN02.ToString.Trim) = True Then
          aryMO(r!TN02.ToString.Trim) = Val(r!Q.ToString)
        End If
      Next
      For Each r As DataRow In rs.Rows
        If aryMO.ContainsKey(r.Item(5).ToString.Trim) = True Then
          r.Item(10) = aryMO(r.Item(5).ToString.Trim)
        End If
      Next
    End If
    DG.DataSource = rs
    For Each c As DataGridViewColumn In DG.Columns
      If c.HeaderText <> BIG2GB("損失工時") And c.HeaderText <> BIG2GB("備註/說明") Then
        c.ReadOnly = True
      Else
        c.ReadOnly = False
      End If
      c.SortMode = DataGridViewColumnSortMode.NotSortable
    Next
  End Sub

  Private Sub Frm0506A_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    Try
      If XLSMA IsNot Nothing Then
        XLSMA.Close("")
        XLSMA.Quit()
      End If
    Catch ex As Exception

    End Try
    GC.Collect()
    TuiCK(Me)
  End Sub

  Private Sub Frm0506A_Load(sender As Object, e As EventArgs) Handles Me.Load
    DTP1.Value = Now.AddDays(-1).Date
    DTP2.Value = Now.Date
    TextBox1.Text = My.Settings.XLS0506
  End Sub

  Private Sub DG_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DG.CellFormatting
    If e.ColumnIndex = 20 Then
      Dim sngV As Double = Val(GCell(DG.Rows(e.RowIndex).Cells(16))) - Val(GCell(DG.Rows(e.RowIndex).Cells(19)))
      If sngV > 0 Then
        e.Value = (Val(GCell(DG.Rows(e.RowIndex).Cells(18))) / sngV * 100).ToString("0.00") & "%"
      Else
        e.Value = 0
      End If
    ElseIf e.ColumnIndex = 17 Then
      e.Value = Val(e.Value).ToString("0.000")
    End If
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    Dim OFL As New SaveFileDialog
    If TextBox1.Text.Trim = "" Then
      OFL.InitialDirectory = Environment.SpecialFolder.MyDocuments
    Else
      OFL.InitialDirectory = IO.Path.GetDirectoryName(TextBox1.Text)
    End If
    OFL.DefaultExt = "Xlsx"
    OFL.Filter = BIG2GB("Excel檔案|*.Xlsx|所有檔案|*.*")
    OFL.FileName = IO.Path.GetFileName(TextBox1.Text)
    OFL.Title = BIG2GB("請選擇檔案")
    If OFL.ShowDialog = Windows.Forms.DialogResult.OK Then
      TextBox1.Text = OFL.FileName
      My.Settings.XLS0506 = TextBox1.Text.Trim
      XLSMA = New XLS_FILE
      XLSMA.DG2XLS(DG, "REP0506", "", "0111110111")
      XLSMA.Close(OFL.FileName)
    End If
  End Sub

  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    Me.Close()
  End Sub

  Private Sub isTD01_CheckedChanged(sender As Object, e As EventArgs) Handles isTD01.CheckedChanged
    TD01.Enabled = isTD01.Checked
    If isTD01.Checked Then
      TD01.Focus()
    Else
      isTBB03.Enabled = True
      isTBB04.Enabled = True
    End If
  End Sub

  Private Sub isTBB04_CheckedChanged(sender As Object, e As EventArgs) Handles isTBB04.CheckedChanged
    TBB04.Enabled = isTBB04.Checked
    If isTBB04.Checked Then
      TBB04.Focus()
    End If
  End Sub

  Private Sub isTBB03_CheckedChanged(sender As Object, e As EventArgs) Handles isTBB03.CheckedChanged
    TBB03.Enabled = isTBB03.Checked
    If isTBB03.Checked Then
      TBB03.Focus()
    End If
  End Sub

  Private Sub isTDC02_CheckedChanged(sender As Object, e As EventArgs) Handles isTDC02.CheckedChanged
    TDC02.Enabled = isTDC02.Checked
    If isTDC02.Checked Then
      TDC02.Focus()
    End If
  End Sub

  Private Sub TD01_GotFocus(sender As Object, e As EventArgs) Handles TD01.GotFocus
    Dim sqlCV As New APSQL.SQLCNV, strKV As String = ""
    If TD01.SelectedValue IsNot Nothing Then
      strKV = TD01.SelectedValue.ToString.Trim
    End If
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_distinc, "SFIS_TDC")
    sqlCV.Where("^0.TDC03", "<=", DTP2.Value.ToString("yyyy\/MM\/dd"))
    sqlCV.Where("^0.TDC03", ">=", DTP1.Value.ToString("yyyy\/MM\/dd"))
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TD", "TD01", "=", "^0.TDC01")
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TBB", "TBB03", "=", "^1.TD02")
    If isTBB03.Checked And TBB03.SelectedValue IsNot Nothing Then
      sqlCV.Where("^2.TBB03", "=", TBB03.SelectedValue.ToString.Trim)
    End If
    If isTBB04.Checked And TBB04.Text.Trim <> "" Then
      sqlCV.Where("^2.TBB04", "=", TBB04.Text.Trim)
    End If
    sqlCV.SqlFields("^0.TDC01", , , , True)
    sqlCV.SqlFields("^1.TD02")
    sqlCV.SqlFields("^2.TBB04")
    sqlCV.SqlFields("^2.TBB05")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RMO")
    TD01.DisplayMember = "TDC01"
    TD01.ValueMember = "TDC01"
    TD01.DataSource = rs
    TD01.SelectedValue = strKV
    If rs.Rows.Count > 0 And TD01.SelectedValue Is Nothing Then
      TD01.SelectedValue = rs.Rows(0)!TDC01.ToString.Trim
    End If
    isTBB03.Checked = False
    isTBB04.Checked = False
    isTBB03.Enabled = False
    isTBB04.Enabled = False
  End Sub

  Private Sub TD01_LostFocus(sender As Object, e As EventArgs) Handles TD01.LostFocus
    Dim r As DataRowView = TD01.SelectedItem
    If r Is Nothing Then Return
    If isTBB03.Checked Then
      TBB03.SelectedValue = r!TD02.ToString.Trim
      If TBB03.SelectedValue Is Nothing Then
        TBB03.Text = r!TD02.ToString.Trim
      End If
    Else
      TBB03.Text = r!TD02.ToString.Trim
    End If
    TBB04.Text = r!TBB04.ToString.Trim
  End Sub

  Private Sub TBB03_GotFocus(sender As Object, e As EventArgs) Handles TBB03.GotFocus
    If isTD01.Checked Then
      Return
    End If
    Dim strKV As String = "", sqlCV As New APSQL.SQLCNV
    If TBB03.SelectedValue IsNot Nothing Then
      strKV = TBB03.SelectedValue.ToString.Trim
    End If
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TBB")
    sqlCV.Where("ISNULL(TBB01,'')", "<>", "")
    sqlCV.Where("ISNULL(TBB02,'')", "<>", "")
    If isTBB04.Checked And TBB04.Text.Trim <> "" Then
      sqlCV.Where("TBB04", "=", TBB04.Text.Trim)
    End If
    sqlCV.SqlFields("TBB03")
    sqlCV.SqlFields("TBB04")
    sqlCV.SqlFields("TBB05")
    sqlCV.SqlFields("TBB06")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RTBB")
    TBB03.DisplayMember = "TBB03"
    TBB03.ValueMember = "TBB03"
    TBB03.DataSource = rs
    If rs.Rows.Count = 0 Then
      TBB03.Text = strKV
    Else
      TBB03.SelectedValue = strKV
      If TBB03.SelectedValue Is Nothing Then
        TBB03.SelectedValue = rs.Rows(0)!TBB03.ToString.Trim
      End If
    End If
  End Sub

  Private Sub TBB03_LostFocus(sender As Object, e As EventArgs) Handles TBB03.LostFocus
    Dim r As DataRowView = TBB03.SelectedItem
    If r Is Nothing Then Return
    TBB04.Text = r!TBB04.ToString.Trim
    TD01.Text = ""
  End Sub

  Private Sub TD01_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles TD01.SelectionChangeCommitted
    My.Computer.Keyboard.SendKeys(vbTab)
  End Sub

  Private Sub TBB03_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles TBB03.SelectionChangeCommitted
    My.Computer.Keyboard.SendKeys(vbTab)
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    ReList()
  End Sub

  Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    If MsgBox(BIG2GB("是否存入損耗工時及備註？存入後將覆蓋原備註"), MsgBoxStyle.YesNo) = MsgBoxResult.No Then Return
    Dim sqlCV As New APSQL.SQLCNV
    For Each r As DataGridViewRow In DG.Rows
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_TDC")
      sqlCV.Where("TDC01", "=", GCell(r.Cells(5)))
      sqlCV.Where("TDC02", "=", GCell(r.Cells(2)))
      sqlCV.Where("TDC03", "=", GCell(r.Cells(1)))
      sqlCV.SqlFields("TDC14", GCell(r.Cells(19)))
      sqlCV.SqlFields("TDC15", GCell(r.Cells(21)))
      DB.RsSQL(sqlCV.Text)
    Next
  End Sub
End Class