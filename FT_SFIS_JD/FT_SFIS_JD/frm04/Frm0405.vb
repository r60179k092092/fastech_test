Public Class Frm0405
  Dim rsPPID As New DataTable
  Dim rsBox As New DataTable
  Dim strMO As String = ""

  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()
    languagechange(Me)
    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

  End Sub

  Private Sub Frm0405_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    TuiCK(Me)
  End Sub
  Private Sub Frm0405_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", "@REWORK")
    sqlCV.SqlFields("QTN02", , , , True)
    sqlCV.SqlFields("QTN02+' '+QTN03", "DATAS")
    sqlCV.SqlFields("QTN05")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "REWK")
    ComboBox1.DisplayMember = "DATAS"
    ComboBox1.ValueMember = "QTN02"
    ComboBox1.DataSource = rs
    If rs.Rows.Count > 0 Then
      ComboBox1.SelectedValue = rs.Rows(0)!QTN02.ToString.Trim
      strMO = "'" & rs.Rows(0)!QTN02.ToString.Trim.Split("_")(0) & "'"
    End If
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TA")
    sqlCV.Where("TA04", "<>", "STS")
    sqlCV.SqlFields("TA01", , , , True)
    sqlCV.SqlFields("TA01 + ' ' + TA02", "DATAS")
    rs = DB.RsSQL(sqlCV.Text, "TAS")
    ComboBox2.DisplayMember = "DATAS"
    ComboBox2.ValueMember = "TA01"
    ComboBox2.DataSource = rs
    rsPPID.Columns.Add("PPID", GetType(String))
    rsPPID.Columns.Add("SN", GetType(String))
    rsPPID.Columns.Add("外箱號", GetType(String))
    rsPPID.Columns.Add("中包號", GetType(String))
    rsPPID.Columns.Add("連接號", GetType(String))
    rsBox.Columns.Add("選擇", GetType(Boolean))
    rsBox.Columns.Add("類型", GetType(String))
    rsBox.Columns.Add("箱號", GetType(String))
  End Sub

  Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    Me.Close()
  End Sub

  Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
    ComboBox1.Enabled = Not CheckBox1.Checked
    Panel4.Visible = CheckBox1.Checked
  End Sub

  Private Sub ComboBox1_LostFocus(sender As Object, e As EventArgs) Handles ComboBox1.LostFocus
    strMO = ""
    If ComboBox1.SelectedItem Is Nothing Then Return
    Dim r As DataRowView = ComboBox1.SelectedItem
    If r!QTN05.GetType Is GetType(DBNull) Then
      Return
    End If
    strMO = "'" & r!QTN02.ToString.Trim.Split("_")(0) & "'"
    Dim bytV() As Byte = r!QTN05
    If bytV Is Nothing OrElse bytV.Length = 0 Then Return
    Dim strM As String = System.Text.Encoding.UTF8.GetString(bytV)
    Dim strV() As String = strM.Split(vbCrLf.ToCharArray)
    Dim aryBS As New ArrayList
    rsPPID.Rows.Clear()
    rsBox.Rows.Clear()
    For Each strK As String In strV
      If strK.Trim = "" Then Continue For
      Dim strA() As String = strK.Split(",")
      If strA(0).Length < 5 Then Continue For
      If strA.Length > 2 AndAlso strA(2).Trim <> "" Then
        Dim strK1 As String = "1" & vbTab & strA(2).Trim
        If aryBS.Contains(strK1) = False Then aryBS.Add(strK1)
      End If
      If strA.Length > 3 AndAlso strA(3).Trim <> "" Then
        Dim strK1 As String = "2" & vbTab & strA(3).Trim
        If aryBS.Contains(strK1) = False Then aryBS.Add(strK1)
      End If
      If strA.Length > 4 AndAlso strA(4).Trim <> "" Then
        Dim strK1 As String = "3" & vbTab & strA(4).Trim
        If aryBS.Contains(strK1) = False Then aryBS.Add(strK1)
      End If
      rsPPID.Rows.Add(strA)
    Next
    aryBS.Sort()
    For Each strK As String In aryBS
      Dim strA() As String = strK.Split(vbTab)
      rsBox.Rows.Add(False, strA(0), strA(1))
    Next
    DG.DataSource = rsPPID
    DG1.DataSource = rsBox
    DG1.Columns(0).ReadOnly = False
    DG1.Columns(1).ReadOnly = True
    DG1.Columns(2).ReadOnly = True
  End Sub

  Private Sub ComboBox1_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBox1.SelectionChangeCommitted
    My.Computer.Keyboard.SendKeys(vbTab)
  End Sub

  Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
    If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
      e.Handled = True
      My.Computer.Keyboard.SendKeys(vbTab)
    End If
  End Sub

  Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles TextBox1.LostFocus
    If TextBox1.Text.Trim = "" Then Return
    rsBox.Rows.Clear()
    rsPPID.Rows.Clear()
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TS")
    sqlCV.Where("TS01", "=", TextBox1.Text.Trim)
    sqlCV.Where("TS02", "=", TextBox1.Text.Trim, , , "OR")
    sqlCV.SqlFields("TS01")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    Dim strK As String = "'" & TextBox1.Text.Trim & "',"
    If rs.Rows.Count > 0 Then
      If rs.Rows(0)!TS01.ToString.Trim <> TextBox1.Text.Trim Then
        strK &= "'" & rs.Rows(0)!TS01.ToString.Trim & "'"
      End If
    End If
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
    sqlCV.Where("TN01", "IN", strK.Trim(","), intFMode.msfld_field)
    sqlCV.SqlFields("TN01")
    sqlCV.SqlFields("TN12")
    sqlCV.SqlFields("TN14")
    sqlCV.SqlFields("TN15")
    rs = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count = 0 Then Return
    strK = ""
    Dim aryBs As New ArrayList
    For Each r As DataRow In rs.Rows
      If r!TN12.ToString.Trim <> "" Then
        Dim strK1 As String = "1" & vbTab & r!TN12.ToString.Trim
        If aryBs.Contains(strK1) = False Then aryBs.Add(strK1)
      End If
      If r!TN14.ToString.Trim <> "" Then
        Dim strK1 As String = "2" & vbTab & r!TN14.ToString.Trim
        If aryBs.Contains(strK1) = False Then aryBs.Add(strK1)
      End If
      If r!TN15.ToString.Trim <> "" Then
        Dim strK1 As String = "3" & vbTab & r!TN15.ToString.Trim
        If aryBs.Contains(strK1) = False Then aryBs.Add(strK1)
      End If
      strK &= "'" & r!TN01.ToString.Trim & "',"
    Next
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
    Dim w As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TS", "TS01", "=", "^0.TN01")
    w.Add("SFIS_TS.TS03", "Like", "'SN%'")
    If aryBs.Count > 0 Then
      strK = ""
      For Each strK1 As String In aryBs
        If strK1.StartsWith("1") Then
          strK &= "'" & strK1.Split(vbTab)(1) & "',"
        End If
      Next
      If strK <> "" Then sqlCV.Where("TN12", "IN", strK.Trim(","), intFMode.msfld_field)
      strK = ""
      For Each strK1 As String In aryBs
        If strK1.StartsWith("2") Then
          strK &= "'" & strK1.Split(vbTab)(1) & "',"
        End If
      Next
      If strK <> "" Then sqlCV.Where("TN14", "IN", strK.Trim(","), intFMode.msfld_field)
      strK = ""
      For Each strK1 As String In aryBs
        If strK1.StartsWith("3") Then
          strK &= "'" & strK1.Split(vbTab)(1) & "',"
        End If
      Next
      If strK <> "" Then sqlCV.Where("TN15", "IN", strK.Trim(","), intFMode.msfld_field)
    Else
      If strK <> "" Then sqlCV.Where("TN01", "IN", strK.Trim(","), intFMode.msfld_field)
    End If
    sqlCV.SqlFields("^0.TN01")
    sqlCV.SqlFields("^1.TS02", , , , True)
    sqlCV.SqlFields("^0.TN12")
    sqlCV.SqlFields("^0.TN14")
    sqlCV.SqlFields("^0.TN15")
    sqlCV.SqlFields("^0.TN02")
    rs = DB.RsSQL(sqlCV.Text, "RT")
    aryBs.Clear()
    strMO = ""
    Dim aryMO As New ArrayList
    For Each r As DataRow In rs.Rows
      If aryMO.Contains(r!TN02.ToString.Trim) = False Then
        aryMO.Add(r!TN02.ToString.Trim)
        strMO &= "'" & r!TN02.ToString.Trim & "',"
      End If
      If r!TN12.ToString.Trim <> "" Then
        Dim strK1 As String = "1" & vbTab & r!TN12.ToString.Trim
        If aryBs.Contains(strK1) = False Then aryBs.Add(strK1)
      End If
      If r!TN14.ToString.Trim <> "" Then
        Dim strK1 As String = "2" & vbTab & r!TN14.ToString.Trim
        If aryBs.Contains(strK1) = False Then aryBs.Add(strK1)
      End If
      If r!TN15.ToString.Trim <> "" Then
        Dim strK1 As String = "3" & vbTab & r!TN15.ToString.Trim
        If aryBs.Contains(strK1) = False Then aryBs.Add(strK1)
      End If
      rsPPID.Rows.Add(r!TN01.ToString.Trim, r!TS02.ToString.Trim, r!TN12.ToString.Trim, r!TN14.ToString.Trim, r!TN15.ToString.Trim)
    Next
    aryBs.Sort()
    For Each strK In aryBs
      Dim strA() As String = strK.Split(vbTab)
      rsBox.Rows.Add(False, strA(0), strA(1))
    Next
    DG.DataSource = rsPPID
    DG1.DataSource = rsBox
    DG1.Columns(0).ReadOnly = False
    DG1.Columns(1).ReadOnly = True
    DG1.Columns(2).ReadOnly = True
  End Sub

  Private Sub DG1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DG1.CellFormatting
    If e.ColumnIndex = 1 Then
      Select Case e.Value
        Case "1"
          e.Value = "外箱號"
        Case "2"
          e.Value = "中包號"
        Case "3"
          e.Value = "連接號"
      End Select
    End If
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    For Each r As DataGridViewRow In DG1.Rows
      r.Cells(0).Value = True
    Next
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    For Each r As DataGridViewRow In DG1.Rows
      r.Cells(0).Value = False
    Next
  End Sub

  Private Sub DG1_LostFocus(sender As Object, e As EventArgs) Handles DG1.LostFocus
    DG1.CommitEdit(DataGridViewDataErrorContexts.Commit)
  End Sub

  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    If ComboBox2.SelectedItem Is Nothing Then Return
    Dim r1 As DataRowView = ComboBox2.SelectedItem
    Dim strGrp As String = r1!TA01.ToString.Trim
    Dim aryBS As New ArrayList
    For Each r As DataGridViewRow In DG1.Rows
      If r.Cells(0).Value = True Then
        Dim strK1 As String = GCell(r.Cells(1)) & vbTab & GCell(r.Cells(2))
        If aryBS.Contains(strK1) = False Then aryBS.Add(strK1)
      End If
    Next
    If aryBS.Count = 0 Then Return
    Dim strK As String = ""
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
    Dim w As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TS", "TS01", "=", "^0.TN01")
    w.Add("SFIS_TS.TS03", "Like", "'SN%'")
    strK = ""
    For Each strK1 As String In aryBS
      If strK1.StartsWith("1") Then
        strK &= "'" & strK1.Split(vbTab)(1) & "',"
      End If
    Next
    If strK <> "" Then sqlCV.Where("TN12", "IN", strK.Trim(","), intFMode.msfld_field)
    strK = ""
    For Each strK1 As String In aryBS
      If strK1.StartsWith("2") Then
        strK &= "'" & strK1.Split(vbTab)(1) & "',"
      End If
    Next
    If strK <> "" Then sqlCV.Where("TN14", "IN", strK.Trim(","), intFMode.msfld_field)
    strK = ""
    For Each strK1 As String In aryBS
      If strK1.StartsWith("3") Then
        strK &= "'" & strK1.Split(vbTab)(1) & "',"
      End If
    Next
    If strK <> "" Then sqlCV.Where("TN15", "IN", strK.Trim(","), intFMode.msfld_field)
    sqlCV.SqlFields("^0.TN01")
    sqlCV.SqlFields("^1.TS02", , , , True)
    sqlCV.SqlFields("^0.TN02")
    sqlCV.SqlFields("^0.TN06")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count = 0 Then
      MsgBox(BIG2GB("已經清除所有包裝箱不需要再次清除"))
      Return
    End If
    strK = ""
    Dim strM As String = ""
    aryBS.Clear()
    For Each r As DataRow In rs.Rows
      If r!TN06.ToString.Trim <> "0" And r!TN06.ToString.Trim <> "4" Then
        strK &= r!TN01.ToString.Trim & "," & r!TS02.ToString.Trim & vbCrLf
      End If
      If aryBS.Contains(r!TN02.ToString.Trim) = False Then
        aryBS.Add(r!TN02.ToString.Trim)
      End If
    Next
    Dim strMS As String = ""
    aryBS.Sort()
    If aryBS.Count > 1 Then
      For Each strK1 As String In aryBS
        strM &= strK1 & ","
      Next
      strMS &= BIG2GB("請注意！！這幾個箱號包含多個工單的成品：" & strM.Trim(",")) & vbCrLf
    End If
    If strK <> "" Then
      strMS &= BIG2GB("*** 有部分成品編號並非良品，繼續作業將導致某些序號留下" & vbCrLf) & strK.Trim(vbCrLf.ToCharArray)
    End If
    If strMS <> "" Then
      MsgBox(strMS.Trim(vbCrLf.ToCharArray))
    End If
    strM = ""
    For Each strk1 As String In aryBS
      strM &= "'" & strk1 & "',"
    Next
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TDA")
    sqlCV.Where("TDA01", "IN", strM.Trim(","), intFMode.msfld_field)
    sqlCV.Where("TDA03", "=", strGrp)
    sqlCV.SqlFields("TDA01", , , , True)
    sqlCV.SqlFields("TDA02")
    Dim rs1 As DataTable = DB.RsSQL(sqlCV.Text, "RC")
    strK = ""
    For Each r As DataRow In rs1.Rows
      If strK.Contains(r!TDA01.ToString.Trim) = False Then strK &= "'" & r!TDA01.ToString.Trim & "',"
    Next
    If strK <> strM Then
      MsgBox(BIG2GB("工單號不存在這個工序"))
      Return
    End If
    If MsgBox(BIG2GB("將會再清除" & rs.Rows.Count & "筆資料" & vbCrLf & "是否繼續返工?"), vbYesNo) = MsgBoxResult.No Then Return
    strK = ""
    For Each r As DataRow In rs.Rows
      If r!TN06.ToString.Trim <> "0" And r!TN06.ToString.Trim <> "4" Then Continue For
      strK &= "'" & r!TN01.ToString.Trim & "',"
    Next
    If strK <> "" Then
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_TN")
      sqlCV.SqlFields("TN03", strGrp)
      sqlCV.SqlFields("TN06", "0")
      sqlCV.SqlFields("TN12", "NULL", intFMode.msfld_field)
      sqlCV.SqlFields("TN14", "NULL", intFMode.msfld_field)
      sqlCV.SqlFields("TN15", "NULL", intFMode.msfld_field)
      sqlCV.Where("TN01", "IN", strK.Trim(","), intFMode.msfld_field)
      DB.RsSQL(sqlCV.Text)
    End If
    If CheckBox2.Checked Then
      For Each strMO As String In aryBS
        strK = ""
        For Each r As DataRow In rs.Rows
          If r!TN02.ToString.Trim = strMO And (r!TN06.ToString.Trim = "0" Or r!TN06.ToString.Trim = "4") Then
            strK &= "'" & r!TN01.ToString.Trim & "',"
          End If
        Next
        If strK <> "" Then
          sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_TS")
          sqlCV.Where("TS01", "IN", strK.Trim(","), intFMode.msfld_field)
          sqlCV.Where("TS03", "Like", "SN%")
          sqlCV.SqlFields("TS01", "TS02", intFMode.msfld_field)
          sqlCV.SqlFields("TS03", "'" & strMO & vbTab & "'+TS03", intFMode.msfld_field)
          DB.RsSQL(sqlCV.Text)
        End If
      Next
    End If
  End Sub

  Private Sub CheckBox2_GotFocus(sender As Object, e As EventArgs) Handles CheckBox2.GotFocus
    If strMO = "" Then
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TA")
      sqlCV.Where("TA04", "<>", "STS")
      sqlCV.SqlFields("TA01", , , , True)
      sqlCV.SqlFields("TA01 + ' ' + TA02", "DATAS")
      Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "TAS")
      ComboBox2.DisplayMember = "DATAS"
      ComboBox2.ValueMember = "TA01"
      ComboBox2.DataSource = rs
    Else '
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_distinc, "SFIS_TDA")
      sqlCV.Where("TDA01", "IN", strMO.Trim(","), intFMode.msfld_field)
      Dim w As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TA", "TA01", "=", "^0.TDA03")
      w.Add("SFIS_TA.TA04", "<>", "'STS'")
      sqlCV.SqlFields("^1.TA01", , , , True)
      sqlCV.SqlFields("^1.TA01 + ' ' + ^1.TA02", "DATAS")
      Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "TAS")
      ComboBox2.DisplayMember = "DATAS"
      ComboBox2.ValueMember = "TA01"
      ComboBox2.DataSource = rs
    End If
  End Sub
End Class