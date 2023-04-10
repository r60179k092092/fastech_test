Public Class PM0501
  'Dim dt As New DataTable
  'Dim gx As New Dictionary(Of String, String)
  Private errorcode As New Dictionary(Of String, String)
  Private Class ErrCount
    Public strID As String = ""
    Public intPcs As Integer = 0
    Public intCount As Integer = 0
    Public strRng As String = ""
  End Class
  Private Class ErrCode
    Public strID As String = ""
    Public strName As String = ""
    Public intCount As Integer = 0
    Public intPcs As Integer = 0
    Public aryList As New ArrayList
    Public intMode As Integer = 0
    Public aryRng As New Dictionary(Of String, ErrCount)
    Public Sub Add(r As DataRow)
      Dim intP As Integer = 0
      If aryList.Contains(r!TM01.ToString.Trim) = False Then
        intP = 1
        aryList.Add(r!TM01.ToString.Trim)
      End If
      intPcs += intP
      intCount += 1
      Dim s As ErrCount
      Select Case intMode
        Case 0
          Dim strV As String = r!TN02.ToString.Trim
          If aryRng.ContainsKey(strV) = False Then
            s = New ErrCount
            s.strID = strID
            s.strRng = strV
            aryRng.Add(strV, s)
          Else
            s = aryRng(strV)
          End If
          s.intCount += 1
          s.intPcs += intP
        Case 1
          Dim strV As String = CDate(r!TM06.ToString).ToString("yyyy\/MM\/dd")
          If aryRng.ContainsKey(strV) = False Then
            s = New ErrCount
            s.strID = strID
            s.strRng = strV
            aryRng.Add(strV, s)
          Else
            s = aryRng(strV)
          End If
          s.intCount += 1
          s.intPcs += intP
        Case 2
          Dim strV As String = CDate(r!TM06.ToString).ToString("yyyy\/MM\/dd HH")
          If aryRng.ContainsKey(strV) = False Then
            s = New ErrCount
            s.strID = strID
            s.strRng = strV
            aryRng.Add(strV, s)
          Else
            s = aryRng(strV)
          End If
          s.intCount += 1
          s.intPcs += intP
        Case 3
          Dim strV As String = "合計"
          If aryRng.ContainsKey(strV) = False Then
            s = New ErrCount
            s.strID = strID
            s.strRng = strV
            aryRng.Add(strV, s)
          Else
            s = aryRng(strV)
          End If
          s.intCount += 1
          s.intPcs += intP
        Case 4
          Dim strV As String = r!TM02.ToString.Trim
          If strV = "" Then strV = "UNKNOW"
          If aryRng.ContainsKey(strV) = False Then
            s = New ErrCount
            s.strID = strID
            s.strRng = strV
            aryRng.Add(strV, s)
          Else
            s = aryRng(strV)
          End If
          s.intCount += 1
          s.intPcs += intP
        Case 5
          Dim strV As String = r!TM03.ToString.Trim
          If strV = "" Then strV = "UNKNOW"
          If aryRng.ContainsKey(strV) = False Then
            s = New ErrCount
            s.strID = strID
            s.strRng = strV
            aryRng.Add(strV, s)
          Else
            s = aryRng(strV)
          End If
          s.intCount += 1
          s.intPcs += intP
        Case 6
          Dim strV As String = r!TM04.ToString.Trim
          If strV = "" Then strV = "UNKNOW"
          If aryRng.ContainsKey(strV) = False Then
            s = New ErrCount
            s.strID = strID
            s.strRng = strV
            aryRng.Add(strV, s)
          Else
            s = aryRng(strV)
          End If
          s.intCount += 1
          s.intPcs += intP
      End Select
    End Sub
  End Class
  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()

    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    languagechange(Me)

  End Sub

  Private Sub PM0501_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    TuiCK(Me)
  End Sub
  Private Sub PM0501_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    getdictionary(errorcode, "select tf01,tf01+' '+ISNULL(tf02,'')+' '+ISNULL(tf03,'') from sfis_tf")
    Button1_Click(Nothing, Nothing)
    dgdaochu(DG)
  End Sub

  Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
    DTP2.Enabled = CheckBox1.Checked
    DTP1.Enabled = CheckBox1.Checked
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    Dim aryC As New Dictionary(Of String, ErrCode)
    Dim intM As Integer = Val(ComboBox1.Text)
    Dim strM As String = ""
    If TextBox1.Text.Trim <> "" Or TextBox2.Text.Trim <> "" Or TextBox5.Text.Trim <> "" Or TextBox3.Text.Trim <> "" Then
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TD")
      If TextBox1.Text.Trim <> "" Then
        sqlCV.Where("TD01", "LIKE", TextBox1.Text.Trim & "%")
      End If
      If TextBox2.Text.Trim <> "" Then
        sqlCV.Where("TD05", "LIKE", TextBox2.Text.Trim & "%")
      End If
      If TextBox5.Text.Trim <> "" Then
        sqlCV.Where("TD03", "LIKE", TextBox5.Text.Trim & "%")
      End If
      If TextBox3.Text.Trim <> "" Then '增加製令單號顯示by yang 180911 - Begin
        sqlCV.Where("TD23", "LIKE", TextBox3.Text.Trim & "%")
      End If                           '增加製令單號顯示by yang 180911 - End
      sqlCV.SqlFields("TD01", , , , True)
      Dim rs1 As DataTable = DB.RsSQL(sqlCV.Text, "RT")
      If rs1.Rows.Count = 0 Then Return
      For Each r As DataRow In rs1.Rows
        strM &= "'" & r!TD01.ToString.Trim & "',"
      Next
    End If
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TM")
    If CheckBox1.Checked Then
      sqlCV.Where("^0.TM06", ">=", DTP1.Value.ToString("yyyy\/MM\/dd") & " 00:00:00", APSQL.intFMode.msfld_datetime)
      sqlCV.Where("^0.TM06", "<=", DTP2.Value.ToString("yyyy\/MM\/dd") & " 23:59:59", APSQL.intFMode.msfld_datetime)
    End If
    sqlCV.Where("ISNULL(TM09,'')", "<>", "")
    sqlCV.SqlJoin(APSQL.SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TN", "TN01", "=", "^0.TM01")
    If strM <> "" Then
      sqlCV.Where("^1.TN02", "IN", strM.Trim(","), APSQL.intFMode.msfld_field)
    End If
    sqlCV.SqlFields("^0.TM01")
    sqlCV.SqlFields("^0.TM06", , , , True)
    sqlCV.SqlFields("^1.TN02")  '工單
    sqlCV.SqlFields("^0.TM02")  '工序
    sqlCV.SqlFields("^0.TM03")  '員工
    sqlCV.SqlFields("^0.TM04")  '機臺
    sqlCV.SqlFields("^0.TM09")  '不良原因 
    Dim dt1 As DataTable = DB.RsSQL(sqlCV.Text, "RT"), s1 As ErrCode
    For Each r As DataRow In dt1.Rows
      Dim strV1() As String = r!TM09.ToString.Trim.Split(("|" & strERSPLIT).ToCharArray)
      For Each strK As String In strV1
        If errorcode.ContainsKey(strK) = True Then
          If aryC.ContainsKey(strK) = False Then
            s1 = New ErrCode
            s1.intMode = intM
            s1.strID = strK
            s1.strName = errorcode(strK).Trim
            aryC.Add(strK, s1)
          Else
            s1 = aryC(strK)
          End If
          s1.Add(r)
        End If
      Next
    Next
    Dim aryL As New ArrayList
    Dim strL(aryC.Count - 1) As String
    aryC.Keys.CopyTo(strL, 0)
    aryL.AddRange(strL)
    aryL.Sort()
    Dim aryT As New ArrayList
    For Each s1 In aryC.Values
      For Each strR As String In s1.aryRng.Keys
        If aryT.Contains(strR) = False Then
          aryT.Add(strR)
        End If
      Next
    Next
    aryT.Sort()
    Dim rs As New DataTable
    rs.TableName = "ARYLIST"
    rs.Columns.Add("不良代碼", GetType(String))
    rs.Columns.Add("名稱", GetType(String))
    For Each strR As String In aryT
      rs.Columns.Add(strR, GetType(String))
    Next
    If intM <> 3 Then
      rs.Columns.Add("合計", GetType(String))
    End If
    For Each strK As String In aryL
      Dim s2 As ErrCode = aryC(strK)
      Dim rw As DataRow = rs.NewRow
      rw.Item(0) = strK
      rw.Item(1) = s2.strName
      If intM <> 3 Then
        For Each s3 As ErrCount In s2.aryRng.Values
          rw.Item(s3.strRng) = s3.intCount.ToString("0") & "次" & s3.intPcs.ToString("0") & "Pcs"
        Next
      End If
      rw.Item("合計") = s2.intCount.ToString("0") & "次" & s2.intPcs.ToString("0") & "Pcs"
      rs.Rows.Add(rw)
    Next
    DG.Columns.Clear()
    DG.DataSource = rs
    For intI As Integer = 2 To DG.Columns.Count - 1
      DG.Columns(intI).SortMode = DataGridViewColumnSortMode.NotSortable
    Next
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    TextBox1.Text = ""
    TextBox2.Text = ""
    TextBox3.Text = ""
    TextBox5.Text = ""
    DTP1.Value = Now
    DTP2.Value = Now
    ComboBox1.SelectedIndex = 0
    GroupBox1.Visible = True
  End Sub

  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    Me.Close()
  End Sub
End Class