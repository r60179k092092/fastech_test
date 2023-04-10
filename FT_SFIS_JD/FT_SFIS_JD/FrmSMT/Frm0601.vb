Public Class Frm0601
  Public sb09data() As String = New String() {"0:良品空盤", "1:已掛料", "2:上料站", "3:待保養", "4:不良待修", "5:不良報廢", "9:尚未啟用"}
  Private bolOPEN As Boolean = False
  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()
    languagechange(Me)
    For intI As Integer = 0 To sb09data.GetUpperBound(0)
      sb09data(intI) = BIG2GB(sb09data(intI))
    Next
    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

  End Sub

  Private Sub btn_insert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_insert.Click
    Me.clear()
  End Sub
  '清除所有欄位
  Private Sub clear()
    txt_sb1.Text = ""
    cb_sb9.SelectedIndex = 0
    txt_sb22.Text = "9999"
    txt_sb23.Text = "10"
    TextBox1.Text = 60
    dt_sb11.Value = Now.AddDays(Val(TextBox1.Text) - 3)
    dt_sb12.Text = Now.AddDays(Val(TextBox1.Text))
    cb_sb9.Text = Me.sb09data(0).ToString
    Me.txt_sb18.Text = ""
    Me.txt_sb10.Text = ""
    Me.txt_sb16.Text = ""
    Me.txt_sb17.Text = ""
    Me.txt_sb15.Text = ""
    Me.txt_sb19.Text = ""
    Me.txt_sb20.Text = ""
    Me.txt_sb21.Text = ""
    DIV.Text = ""
    DIV.Enabled = True
    Me.txt_sb22.Enabled = True
    Me.txt_sb23.Enabled = True
  End Sub

  Private Sub btn_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Save.Click
    Dim strSB9VAL As String = Me.cb_sb9.Text
    Dim sqlIn As New APSQL.SQLCNV
    If Me.txt_sb1.Text.Trim = "" Then
      MsgBox(BIG2GB("請輸入FEEDER編號"))
      Exit Sub
    Else
      Dim strG As String = txt_sb1.Text.Trim
      If strG Like "*[-.]#" Then
        strG = strG.Substring(0, strG.Length - 2)
      End If
      sqlIn.sqlMAKE(APSQL.SQLCNV.intMode.mssql_update, "SFIS_SB")
      If DIV.Text <> "" Then
        sqlIn.Where("SB01", "Like", strG & "[-.][0123456789]")
      Else
        sqlIn.Where("SB01", "=", txt_sb1.Text.Trim)
      End If
      sqlIn.SqlFields("SB11", dt_sb11.Value.ToString("yyyy\/MM\/dd"))
      sqlIn.SqlFields("SB12", dt_sb12.Value.ToString("yyyy\/MM\/dd"))
      sqlIn.SqlFields("SB22", txt_sb22.Text, APSQL.intFMode.msfld_num)
      sqlIn.SqlFields("SB23", txt_sb23.Text, APSQL.intFMode.msfld_num)
      Dim intL As Integer = DB.RsSQL(sqlIn.Text)
      If intL > 0 Then
        ShowID()
        MsgBox("更新完成")
        'Me.getFEDate(txt_sb1.Text.Trim)
        Return
      End If
      Dim intC As Integer = 1
      If DIV.Text <> "" Then
        intC = Val(DIV.Text)
        If intC = 0 Then intC = 1
      End If
      For intI As Integer = 1 To intC
        sqlIn.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "SFIS_SB")
        If DIV.Text = "" Then
          sqlIn.SqlFields("SB01", txt_sb1.Text.ToString)
        Else
          sqlIn.SqlFields("SB01", strG & "-" & intI.ToString("0"))
        End If
        sqlIn.SqlFields("SB02", 0, APSQL.intFMode.msfld_num)
        sqlIn.SqlFields("SB03", "")
        sqlIn.SqlFields("SB04", "")
        sqlIn.SqlFields("SB05", "")
        sqlIn.SqlFields("SB06", "")
        sqlIn.SqlFields("SB07", "")
        sqlIn.SqlFields("SB08", "")
        sqlIn.SqlFields("SB09", "0")
        sqlIn.SqlFields("SB10", DateTime.Now.ToString("yyyy\/MM\/dd"))
        sqlIn.SqlFields("SB11", dt_sb11.Value.ToString("yyyy\/MM\/dd"))
        sqlIn.SqlFields("SB12", dt_sb12.Value.ToString("yyyy\/MM\/dd"))
        sqlIn.SqlFields("SB13", 0, APSQL.intFMode.msfld_num)
        sqlIn.SqlFields("SB14", "")
        sqlIn.SqlFields("SB15", 0, APSQL.intFMode.msfld_num)
        sqlIn.SqlFields("SB16", 0, APSQL.intFMode.msfld_num)
        sqlIn.SqlFields("SB17", 0, APSQL.intFMode.msfld_num)
        sqlIn.SqlFields("SB18", DateTime.Now.ToString("yyyy\/MM\/dd"))
        sqlIn.SqlFields("SB19", lgncode)
        sqlIn.SqlFields("SB20", "")
        sqlIn.SqlFields("SB21", "")
        sqlIn.SqlFields("SB22", txt_sb22.Text, APSQL.intFMode.msfld_num)
        sqlIn.SqlFields("SB23", txt_sb23.Text, APSQL.intFMode.msfld_num)
        DB.RsSQL(sqlIn.Text)
      Next
      'Me.getFEDate(Me.txt_sb1.Text.Trim)
      ShowID()
      MSGID.Visible = False
      MsgBox(BIG2GB("新增完成"))
      Return
    End If
  End Sub

  Private Sub frmB01_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    TuiCK(Me)
  End Sub

  Private Sub frmB01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.cb_shSb09.Items.AddRange(sb09data)
    Me.cb_sb9.Items.AddRange(sb09data)
    Me.txt_sb1.Focus()
    txt_sb1.SelectAll()
    My.Application.DoEvents()
    bolOPEN = True
    dgdaochu(DG)
    'ReList()
  End Sub

  Private Sub ReList(Optional ByVal strID As String = "")
    Dim sqlSearch As New APSQL.SQLCNV
    If bolOPEN = False Then Return
    sqlSearch.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_SB")
    If strID.Length = 0 Then
      sqlSearch.Where("SB09", "=", Me.cb_shSb09.Text.Substring(0, 1), APSQL.intFMode.msfld_text)
      If CheckBox1.Checked Then
        sqlSearch.Where("SB03", ">", Format(Now.AddDays(-Val(TextBox2.Text)), "yyyy\/MM\/dd") & " 00:00:00")
      End If
      If CheckBox2.Checked Then
        sqlSearch.Where("SB12", "<", Format(dt_shDate.Value, "yyyy\/MM\/dd"))
      End If
    Else
      If strID Like "*[-.]#" Then
        strID = strID.Substring(0, strID.Length - 2)
      End If
      sqlSearch.Where("SB01", "Like", strID & "[-.][0123456789]")
      sqlSearch.Where("SB01", "=", strID, , , "OR")
    End If
    sqlSearch.SqlFields("SB01", "[FEEDER ID]", , , True)
    sqlSearch.SqlFields("SB09", "狀態")
    sqlSearch.SqlFields("SB10", "上次保養日期")
    sqlSearch.SqlFields("SB12", "保養逾期日")
    sqlSearch.SqlFields("SB13", "使用次數")
    sqlSearch.SqlFields("SB22", "次數上限")

    sqlSearch.SqlFields("SB15", "總維修次數")
    sqlSearch.SqlFields("SB17", "總保養次數")
    sqlSearch.SqlFields("SB16", "總上料次數")
    sqlSearch.SqlFields("SB23", "總次數上限")

    sqlSearch.SqlFields("SB03", "最近使用日")
    sqlSearch.SqlFields("SB18", "第一次使用日期")
    sqlSearch.SqlFields("SB11", "下次保養日期")
    sqlSearch.SqlFields("SB19", "最后一次使用者")
    sqlSearch.SqlFields("SB20", "最后一次保養者")
    sqlSearch.SqlFields("SB21", "最后一次維修者")
    Dim rs As DataTable = DB.RsSQL(BIG2GB(sqlSearch.Text), "SE0")
    Me.DG.DataSource = rs
  End Sub

  Private Sub btn_SearchFD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_SearchFD.Click
    ReList()
  End Sub

  Private Sub txt_sb1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_sb1.KeyPress
    'Dim s As String = Me.txt_sb1.Text.Trim
    'Me.getFEDate(s)
    If e.KeyChar = vbCr Then
      ShowID()
      e.Handled = True
    End If
  End Sub
  Private Sub ShowID(Optional ByVal bolMD As Boolean = False)
    Dim strID = txt_sb1.Text.Trim
    ReList(strID)
    DIV.Enabled = True
    If strID = "" Then Return
    Dim dt As DataTable = DB.GetRs("SE0")
    If dt.Rows.Count = 0 Then
      MSGID.Visible = True
      clear()
      txt_sb1.Text = strID
      DIV.Enabled = True
    Else
      MSGID.Visible = False
      Me.txt_sb1.Focus()
      Me.txt_sb1.SelectAll()
      Me.cb_sb9.Enabled = False
      DIV.Text = ""
      DIV.Enabled = False
      If strID Like "*[-.]#" Then
        strID = strID.Substring(0, strID.Length - 2)
      End If
      For Each r As DataRow In dt.Rows
        If r.Item(0).ToString.Trim <> strID Then
          Dim strG As String = r.Item(0).ToString.Trim.Substring(strID.Length + 1)
          If strG > DIV.Text Then DIV.Text = strG
        End If
      Next
      Me.txt_sb23.Text = dt.Rows(0).Item(BIG2GB("總次數上限")).ToString
      Me.txt_sb22.Text = dt.Rows(0).Item(BIG2GB("次數上限")).ToString
      If IsDate(dt.Rows(0).Item(BIG2GB("下次保養日期")).ToString.Trim) = False Then
        dt_sb11.Value = Now.AddDays(27)
      Else
        Me.dt_sb11.Value = DateTime.Parse(dt.Rows(0).Item(BIG2GB("下次保養日期")).ToString)
      End If
      If IsDate(dt.Rows(0).Item(BIG2GB("保養逾期日")).ToString.Trim) = False Then
        dt_sb12.Value = Now.AddDays(30)
      Else
        Me.dt_sb12.Value = DateTime.Parse(dt.Rows(0).Item(BIG2GB("保養逾期日")).ToString)
      End If
      Dim strD As String = dt.Rows(0).Item(BIG2GB("狀態")).ToString
      Dim intK As Integer = 0
      For Each strK As String In cb_sb9.Items
        If strK.StartsWith(strD) Then
          cb_sb9.SelectedIndex = intK
        End If
        intK += 1
      Next
      Me.txt_sb18.Text = dt.Rows(0).Item(BIG2GB("第一次使用日期")).ToString
      Me.txt_sb10.Text = dt.Rows(0).Item(BIG2GB("上次保養日期")).ToString
      Me.txt_sb16.Text = dt.Rows(0).Item(BIG2GB("總上料次數")).ToString
      Me.txt_sb17.Text = dt.Rows(0).Item(BIG2GB("總保養次數")).ToString
      Me.txt_sb15.Text = dt.Rows(0).Item(BIG2GB("總維修次數")).ToString
      Me.txt_sb19.Text = dt.Rows(0).Item(BIG2GB("最后一次使用者")).ToString
      Me.txt_sb20.Text = dt.Rows(0).Item(BIG2GB("最后一次保養者")).ToString
      Me.txt_sb21.Text = dt.Rows(0).Item(BIG2GB("最后一次維修者")).ToString
      If IsDate(txt_sb10.Text) = False Then
        TextBox1.Text = 30
      Else
        TextBox1.Text = (dt_sb12.Value.Date - CDate(txt_sb10.Text).Date).TotalDays.ToString
      End If
    End If
  End Sub

  Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
    If e.KeyChar = vbCr Then
      txt_sb1.Focus()
      e.Handled = True
    End If
  End Sub

  Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged, CheckBox2.CheckedChanged
    If bolOPEN Then ReList()
  End Sub

  Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
    If bolOPEN Then CheckBox1.Checked = True
  End Sub

  Private Sub dt_shDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dt_shDate.ValueChanged
    If bolOPEN Then CheckBox2.Checked = True
  End Sub

  Private Sub cb_shSb09_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_shSb09.SelectedIndexChanged
    If bolOPEN Then ReList()
  End Sub

  Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
    If MSGID.Visible = True Then
      dt_sb11.Value = Now.AddDays(Val(TextBox1.Text) - 3)
      dt_sb12.Value = Now.AddDays(Val(TextBox1.Text))
    End If
  End Sub

  Private Sub txt_sb23_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_sb23.KeyPress, txt_sb22.KeyPress
    If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
      e.Handled = True
      My.Computer.Keyboard.SendKeys(vbTab)
    End If
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    Me.Close()
  End Sub
End Class
