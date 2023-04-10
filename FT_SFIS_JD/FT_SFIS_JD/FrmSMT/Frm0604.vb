Public Class Frm0604
  Private intSA01 As Integer = 0
  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()
    languagechange(Me)
    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

  End Sub
  Private Sub ShowIt()
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_SB")
    sqlCV.Where("SB01", "=", TextBox1.Text.Trim)
    'sqlCV.Where("SB01", "Like", TextBox1.Text.Trim & "[-.][0123456789]", , , "OR")
    sqlCV.SqlJoin(APSQL.SQLCNV.intJoinMode.msJoin_Left, "SFIS_SA", "SA01", "=", "SFIS_SB.SB02")
    sqlCV.SqlFields("SB02")
    sqlCV.SqlFields("SB03")
    sqlCV.SqlFields("SB09")
    sqlCV.SqlFields("SA02")
    sqlCV.SqlFields("SA04")
    sqlCV.SqlFields("SA07")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count = 0 Then
      Label3.Text = BIG2GB("無法找到這個FEEDER號")
      Label4.Text = ""
      Label6.Text = ""
      intSA01 = 0
    Else
      Label4.Text = rs.Rows(0)!SB03.ToString.Trim
      Label6.Text = (rs.Rows(0)!SA02.ToString.Trim & "," & rs.Rows(0)!SA04.ToString.Trim & "," & rs.Rows(0)!SA07.ToString.Trim).Trim(",")
      intSA01 = Val(rs.Rows(0)!SB02.ToString.Trim)
      Select Case rs.Rows(0)!SB09.ToString.Trim
        Case "0"
          Label3.Text = BIG2GB("0 已經空盤無需解鎖")
          Button1.Enabled = False
        Case "1"
          Label3.Text = BIG2GB("1 已綁料號")
          Button1.Enabled = True
        Case "2"
          Label3.Text = BIG2GB("2 已在料站")
          Button1.Enabled = True
        Case "9"
          Label3.Text = BIG2GB("9 未啟用")
          Button1.Enabled = True
        Case Else
          Label3.Text = BIG2GB("FEEDER維修或不堪使用")
          Button1.Enabled = False
      End Select
    End If
  End Sub
  Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
    If e.KeyChar = vbCr Then
      e.Handled = True
      ShowIt()
    End If
  End Sub

  Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles TextBox1.LostFocus
    ShowIt()
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    Dim sqlCV As New APSQL.SQLCNV
    Dim strG As String = TextBox1.Text.Trim
    If strG Like "*[-.]#" Then
      strG = strG.Substring(0, strG.Length - 2)
    End If
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_update, "SFIS_SB")
    sqlCV.Where("SB01", "=", strG)
    sqlCV.Where("SB01", "Like", strG & "[-.][0123456789]", , , "OR")
    sqlCV.SqlFields("SB02", 0, APSQL.intFMode.msfld_num)
    sqlCV.SqlFields("SB04", "")
    sqlCV.SqlFields("SB05", "")
    sqlCV.SqlFields("SB06", "")
    sqlCV.SqlFields("SB07", "")
    sqlCV.SqlFields("SB08", "")
    sqlCV.SqlFields("SB09", "0")
    DB.RsSQL(sqlCV.Text)
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_SC")
    sqlCV.Where("SC04+','+SC11", "like", "%" & strG & "%")
    sqlCV.Where("SC12", "<>", "9")
    sqlCV.SqlFields("*")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    Dim bolC As Boolean = False
    For Each r As DataRow In rs.Rows
      Dim sc04 As String = ""
      bolC = False
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_update, "SFIS_SC")
      sqlCV.Where("SC01", "=", r!SC01.ToString.Trim)
      sqlCV.Where("SC02", "=", r!SC02.ToString.Trim)
      sqlCV.Where("SC03", "=", r!SC03.ToString.Trim, APSQL.intFMode.msfld_num)
      sc04 = r!SC04.ToString.Trim
      If sc04 = strG Or sc04 Like strG & "[-.]#" Then
        sqlCV.SqlFields("SC04", "")
        sqlCV.SqlFields("SC16", "")
        sc04 = ""
        bolC = True
      End If
      Dim sc11 As String = r!SC11.ToString.Trim
      Dim sc17 As String = ""
      Dim strM1() As String = sc11.Split(",")
      Dim strM2() As String = (r!SC17.ToString.Trim & ",,,,,,,,,,").Split(",")
      sc11 = ""
      For intI As Integer = 0 To strM1.GetUpperBound(0)
        Dim strk = strM1(intI)
        If strK = strG Or strK Like strG & "[-.]#" Then
          sc11 &= ","
          sc17 &= ","
          bolC = True
        Else
          sc11 &= strk & ","
          sc17 &= strM2(intI) & ","
        End If
      Next
      If bolC Then
        sc11 = sc11.TrimEnd(",")
        sc17 = sc17.TrimEnd(",")
        sqlCV.SqlFields("SC11", sc11)
        sqlCV.SqlFields("SC17", sc17)
        If sc11 <> "" Then
          If sc04 <> "" Then
            sqlCV.SqlFields("SC12", "3")
          Else
            sqlCV.SqlFields("SC12", "2")
          End If
        Else
          If sc04 <> "" Then
            sqlCV.SqlFields("SC12", "2")
          Else
            sqlCV.SqlFields("SC12", "0")
          End If
        End If
        DB.RsSQL(sqlCV.Text)
      End If
    Next
    Label3.Text = BIG2GB("解綁完成")
    Label4.Text = ""
    Label6.Text = ""
    TextBox1.Text = ""
    TextBox1.Focus()
  End Sub
End Class
