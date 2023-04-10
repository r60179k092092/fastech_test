Imports APSQL
Public Class Frm0603
  Private ar09 As New Dictionary(Of String, String)
  Private strFD As String = "", strC05 As String = "", strC07 As String = ""
  Private strC08 As String = ""
  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()
    languagechange(Me)
    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

  End Sub
  Private Sub ShowUser()
    Dim sqlV As New SQLCNV
    Label23.Text = ""
    If TextBox4.Text.Trim = "" Then TextBox4.Text = lgncode
    sqlV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_User")
    sqlV.Where("UserCode", "=", TextBox4.Text.Trim)
    sqlV.SqlFields("UserName")
    Dim rs As DataTable = DB.RsSQL(sqlV.Text, "RT")
    If rs.Rows.Count = 0 Then
      Label23.Text = BIG2GB("無此員工號")
      Label23.ForeColor = Color.Red
      Return
    End If
    Label23.ForeColor = Color.Black
    Label23.Text = rs.Rows(0)!UserName.ToString.Trim
  End Sub

  Private Sub DG2_RELIST()
    Dim sqlCV As New SQLCNV, strCD As String = ""
    If CheckBox1.Checked = True Then strCD &= "'0',"
    If CheckBox2.Checked = True Then strCD &= "'4',"
    If CheckBox3.Checked = True Then strCD &= "'3',"
    If strCD.Trim(" ,".ToCharArray) = "" Then Return
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_SB")
    sqlCV.SqlFields("SB01", "[FEEDER ID]")
    sqlCV.SqlFields("SB09", "狀態")
    sqlCV.SqlFields("SB14", "不良原因")
    sqlCV.SqlFields("SB11", "保養日期")
    sqlCV.Where("SB09", "IN", strCD.Trim(" ,".ToCharArray), intFMode.msfld_field)
    DG2.DataSource = DB.RsSQL(BIG2GB(sqlCV.Text), "DG2_T")
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_SB")
    sqlCV.SqlFields("SB09", , , True, True)
    sqlCV.SqlFields("COUNT(*)", "QTY")
    Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "RS")
    Label25.Text = ""
    Label26.Text = ""
    Label27.Text = ""
    For Each r As DataRow In dt.Rows
      Select Case r("SB09").ToString
        Case "0"
          Label25.Text = r("QTY").ToString
        Case "3"
          Label27.Text = r("QTY").ToString
        Case "4"
          Label26.Text = r("QTY").ToString
      End Select
    Next
  End Sub

  Private Function ListR(Optional ByVal strCD As String = "") As Boolean
    Select Case strCD
      Case "0"
        R1.Checked = True
        R1.Enabled = True
        R2.Enabled = True
        R3.Enabled = True
        R4.Enabled = True
      Case "1", "2", "5", "6", "9"
        MsgBox(BIG2GB("這個維修站無法接受這個FEEDER"))
        Button1.Enabled = False
        TextBox1.Text = ""
        TextBox1.Focus()
        Return False
      Case "3"
        R1.Checked = True
        R1.Enabled = True
        R2.Enabled = True
        R3.Enabled = True
        R4.Enabled = True
      Case "4"
        R2.Checked = True
        R1.Enabled = True
        R2.Enabled = True
        R3.Enabled = True
        R4.Enabled = True
    End Select
    If R1.Checked = True Then
      TextBox2.Visible = True
      Label20.Visible = True
    Else
      TextBox2.Visible = False
      Label20.Visible = False
    End If
    If R2.Checked = True Then
      ComboBox1.Visible = True
      ComboBox1.SelectedIndex = 0
    Else
      ComboBox1.Visible = False
    End If
    Button1.Enabled = True
    TextBox1.Focus()
    Return True
  End Function

  Private Sub Frm0603_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    TuiCK(Me)
  End Sub

  Private Sub frmM31_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    DG2_RELIST()
    ListR()
    ar09.Add("0", BIG2GB("空盤"))
    ar09.Add("1", BIG2GB("綁定料號"))
    ar09.Add("2", BIG2GB("掛料站"))
    ar09.Add("3", BIG2GB("待保養"))
    ar09.Add("4", BIG2GB("不良品待修"))
    ar09.Add("5", BIG2GB("不良品報廢"))
    ShowUser()
  End Sub

  Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged, CheckBox2.CheckedChanged, CheckBox3.CheckedChanged
    DG2_RELIST()
  End Sub

  Private Sub TP_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles TP.Resize
    DG2.Width = TP.ClientSize.Width - DG2.Left
  End Sub

  Private Sub ShowID(Optional ByVal bolMD As Boolean = False)
    Dim sqlV As New SQLCNV
    sqlV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_SB")
    sqlV.SqlFields("*")
    sqlV.Where("SB01", "=", TextBox1.Text.Trim)
    Dim dt As DataTable = DB.RsSQL(sqlV.Text, "RT")
    If dt.Rows.Count = 0 Then
      MSGID.Visible = True
    Else
      MSGID.Visible = False
    End If
    If dt.Rows.Count = 1 Then
      If ListR(dt.Rows(0)("SB09").ToString) = False Then
        Return
      End If
      strFD = TextBox1.Text
      With dt.Rows(0)
        Label8.Text = .Item("SB03").ToString
        Label9.Text = .Item("SB12").ToString
        Label10.Text = .Item("SB10").ToString
        If IsDate(Label9.Text) = True And IsDate(Label10.Text) = True Then
          TextBox2.Text = Format((CDate(Label9.Text) - CDate(Label10.Text)).TotalDays, "0")
        Else
          TextBox2.Text = "60"
        End If
        Label11.Text = ""
        If ar09.ContainsKey(.Item("SB09").ToString) Then
          Label12.Text = ar09(.Item("SB09").ToString)
        End If
        Label13.Text = .Item("SB14").ToString
        Label17.Text = .Item("SB13").ToString
        Label18.Text = .Item("SB17").ToString
        Label19.Text = .Item("SB15").ToString
      End With
    End If
    sqlV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_SF")
    sqlV.Where("SF01", "=", TextBox1.Text)
    sqlV.SqlFields("SF02", "保養維修日期")
    sqlV.SqlFields("SF03", "維修員")
    sqlV.SqlFields("SF04", "維修事項")
    sqlV.SqlFields("SF06", "維修序")
    sqlV.SqlFields("SF07", "維修狀態")
    sqlV.SqlFields("SF05")
    sqlV.sqlOrder("SF02", SQLCNV.intOrder.Order_Dsc)
    dt = DB.RsSQL(BIG2GB(sqlV.Text), "RT")
    If dt.Rows.Count > 0 Then
      For Each r As DataRow In dt.Rows
        If r("SF05").ToString = "0" Or r("SF05").ToString = "3" Then
          Label11.Text = r(0).ToString
          Exit For
        End If
      Next
    End If
    DG.DataSource = dt
    DG.Columns("SF05").Visible = False
    TextBox1.Focus()
    TextBox1.SelectAll()
    If bolMD = False Then TextBox3.Text = ""
  End Sub

  Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
    If e.KeyChar = vbCr Then
      ShowID()
      e.Handled = True
    End If
  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    Dim sqlV As New SQLCNV, intM4 As Integer = 0, intM3 As Integer = 0
    If strFD.Trim.Length = 0 Then Return
    sqlV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_SF")
    sqlV.Where("SF01", "=", strFD)
    sqlV.SqlFields("SF05", , , True)
    sqlV.SqlFields("MAX(SF06)", "MAXV")
    Dim dt As DataTable = DB.RsSQL(sqlV.Text, "RS"), strD As String = Format(Now, "yyyy\/MM\/dd HH\:mm\:ss")
    For Each r As DataRow In dt.Rows
      Select Case r("SF05").ToString
        Case "0", "3"
          If intM4 < Val(r("MAXV").ToString) Then
            intM4 = Val(r("MAXV").ToString)
          End If
        Case "1"
          If intM3 < Val(r("MAXV").ToString) Then
            intM3 = Val(r("MAXV").ToString)
          End If
      End Select
    Next
    sqlV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_SF")
    sqlV.SqlFields("SF01", strFD)
    sqlV.SqlFields("SF02", strD)
    sqlV.SqlFields("SF03", TextBox4.Text)
    sqlV.SqlFields("SF04", TextBox3.Text)
    If R1.Checked = True Then
      strC05 = "1"
      strC07 = "0"
      strC08 = "0"
    ElseIf R2.Checked = True Then
      Select Case ComboBox1.Text.Trim.Substring(0, 1)
        Case "1", "4"
          strC08 = "3"
          strC05 = "0"
          strC07 = ComboBox1.Text.Trim.Substring(0, 1)
        Case "0"
          strC08 = "0"
          strC05 = "0"
          strC07 = ComboBox1.Text.Trim.Substring(0, 1)
        Case "5"
          strC05 = "3"
          strC08 = "0"
          strC07 = ComboBox1.Text.Trim.Substring(0, 1)
      End Select
    ElseIf R3.Checked = True Then
      strC05 = "2"
      strC08 = "0"
      strC07 = "3"
    Else
      strC05 = "0"
      strC08 = "1"
      strC07 = "2"
    End If
    sqlV.SqlFields("SF05", strC05)
    sqlV.SqlFields("SF07", strC07)
    sqlV.SqlFields("SF08", strC08)
    If strC05 = "1" Then
      sqlV.SqlFields("SF06", intM3 + 1, intFMode.msfld_num)
    ElseIf strC05 = "2" Then
      sqlV.SqlFields("SF06", 0, intFMode.msfld_num)
    Else
      sqlV.SqlFields("SF06", intM4 + 1, intFMode.msfld_num)
    End If
    DB.RsSQL(sqlV.Text)
    sqlV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_SB")
    sqlV.Where("SB01", "=", strFD)
    If strC07 = "2" Then '報廢
      sqlV.SqlFields("SB09", "5")
      sqlV.SqlFields("SB21", TextBox4.Text)
    ElseIf strC05 = "1" Then '保養
      sqlV.SqlFields("SB09", "0")
      sqlV.SqlFields("SB13", 0, intFMode.msfld_num)
      sqlV.SqlFields("SB17", intM3 + 1)
      sqlV.SqlFields("SB14", "")
      sqlV.SqlFields("SB10", strD.Substring(0, 10))
      sqlV.SqlFields("SB11", Format(Now.AddDays(Val(TextBox2.Text) - 3), "yyyy\/MM\/dd"))
      sqlV.SqlFields("SB12", Format(Now.AddDays(Val(TextBox2.Text)), "yyyy\/MM\/dd"))
      sqlV.SqlFields("SB20", TextBox4.Text)
    ElseIf strC05 = "2" Then '誤判
      sqlV.SqlFields("SB09", "0")
      sqlV.SqlFields("SB21", TextBox4.Text)
      sqlV.SqlFields("SB14", "")
    Else '維修
      sqlV.SqlFields("SB15", intM4 + 1, intFMode.msfld_num)
      sqlV.SqlFields("SB21", TextBox4.Text)
      If strC07 = "0" Or strC07 = "5" Then
        sqlV.SqlFields("SB14", "")
        sqlV.SqlFields("SB09", "0")
      Else
        sqlV.SqlFields("SB09", "4")
      End If
    End If
    DB.RsSQL(sqlV.Text)
    Button1.Enabled = False
    strFD = ""
    DG2_RELIST()
    ListR()
    ShowID(True)
  End Sub

  Private Sub R1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles R1.CheckedChanged, R2.CheckedChanged, R3.CheckedChanged, R4.CheckedChanged
    ListR()
  End Sub

  Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    Dim sqlV As New SQLCNV
    sqlV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_SB")
    sqlV.SqlFields("SB01", "[FEEDER ID]")
    sqlV.SqlFields("SB09", "狀態")
    sqlV.SqlFields("SB14", "不良原因")
    sqlV.SqlFields("SB11", "保養日期")
    sqlV.Where("SB09", "=", "0")
    sqlV.Where("SB12", "<", Format(Now, "yyyy\/MM\/dd"), , 1)
    sqlV.Where("SB13", ">", "ISNULL(SB22,0)", intFMode.msfld_field, 1, "OR")
    sqlV.Where("ISNULL(SB22,0)", ">", 0, intFMode.msfld_num, -1)
    DG2.DataSource = DB.RsSQL(BIG2GB(sqlV.Text), "DG2_T")
    Button3.Visible = True
  End Sub

  Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
    Dim sqlV As New SQLCNV
    sqlV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_SB")
    sqlV.SqlFields("SB09", "3")
    sqlV.SqlFields("SB14", BIG2GB("效期超過"))
    sqlV.Where("SB09", "=", "0")
    sqlV.Where("SB12", "<", Format(Now, "yyyy\/MM\/dd"))
    DB.RsSQL(sqlV.Text)
    sqlV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_SB")
    sqlV.SqlFields("SB09", "3")
    sqlV.SqlFields("SB14", BIG2GB("使用次數超過"))
    sqlV.Where("SB09", "=", "0")
    sqlV.Where("SB13", ">", "ISNULL(SB22,0)", intFMode.msfld_field)
    sqlV.Where("ISNULL(SB22,0)", ">", 0, intFMode.msfld_num)
    DB.RsSQL(sqlV.Text)
    Button3.Visible = False
    DG2_RELIST()
  End Sub

  Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
    If e.KeyChar = vbCr Then
      ShowUser()
      e.Handled = True
    End If
  End Sub

  Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    Me.Close()
  End Sub
End Class
