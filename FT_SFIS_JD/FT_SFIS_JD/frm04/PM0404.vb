Public Class PM0404
  Private strMO As String = ""
  Private strID As String = ""
  Private intU As Integer = 0
  Private strEL As String = ""
  Private strGRP As String = ""
  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()

    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    languagechange(Me)

  End Sub
  Private Sub ReList()
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TN")
    If CheckBox1.Checked Then
      sqlCV.Where("TN06", "IN", "1,2", APSQL.intFMode.msfld_field)
    Else
      sqlCV.Where("TN06", "=", "1", intFMode.msfld_num)
    End If
    sqlCV.SqlFields("TN02", "工單編號", , , True)
    sqlCV.SqlFields("TN01", "製造ID", , , True)
    sqlCV.SqlFields("TN03", "目前工序")
    sqlCV.SqlFields("TN04", "時間")
    sqlCV.SqlFields("TN09", "不良次數")
    sqlCV.SqlFields("TN08", "維修次數")
    Dim rs As DataTable = DB.RsSQL(BIG2GB(sqlCV.Text), "TN1")
    DG.DataSource = rs
  End Sub

  Private Sub PM0404_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    TuiCK(Me)
  End Sub
  Private Sub PM0404_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    CheckBox1.Checked = My.Settings.RmaCheck
    ReList()
  End Sub

  Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
    If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
      e.Handled = True
      MSG.Text = ""
      Dim sqlCV As New APSQL.SQLCNV
      Dim strK As String = TextBox1.Text.Trim
      If strK.Length > 60 Then
        strK = strK.Split("|")(0)
        TextBox1.Text = strK
      End If
      If strK.Length > 32 Then
        Dim strM() As String = strK.Split("|/".ToCharArray)
        If strM.Length = 4 Then
          sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TE")
          sqlCV.Where("TE01", "=", strM(0))
          sqlCV.Where("TE02", "=", strM(0) & "_" & strM(1))
          sqlCV.Where("TE03", "=", strM(3))
          sqlCV.SqlFields("TE14")
          Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
          If rs.Rows.Count > 0 Then
            strK = rs.Rows(0)!TE14.ToString.Trim
          End If
          DB.CloseRs(rs)
        End If
      End If
      Dim rs1 As DataTable = Nothing
      While -1
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TN")
        sqlCV.Where("TN01", "=", strK)
        sqlCV.SqlFields("TN01")
        sqlCV.SqlFields("TN02")
        sqlCV.SqlFields("TN03")
        sqlCV.SqlFields("TN06")
        sqlCV.SqlFields("TN07")
        rs1 = DB.RsSQL(sqlCV.Text, "RT")
        If rs1.Rows.Count = 0 Then Exit While
        If rs1.Rows(0)!TN06.ToString.Trim = "7" Or rs1.Rows(0)!TN06.ToString.Trim = "100" Then
          strK = rs1.Rows(0)!TN07.ToString.Trim
        Else
          Exit While
        End If
      End While
      If rs1.Rows.Count = 0 Then
        TextBox1.Text = ""
        TextBox1.Focus()
        MSG.Text = BIG2GB("所刷條碼沒有登錄生產過")
        Return
      Else
        strMO = rs1.Rows(0)!TN02.ToString.Trim
        strID = strK
        TextBox1.Text = strID
        strGRP = rs1.Rows(0)!TN03.ToString.Trim
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TDA")
        Dim w As SqlWhere = sqlCV.SqlJoin(APSQL.SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TA", "TA01", "=", "^0.TDA03")
        w.Add("SFIS_TA.TA04", "<>", "'STS'")
        sqlCV.Where("^0.TDA01", "=", strMO)
        sqlCV.Where("^0.TDA04", "=", 0, APSQL.intFMode.msfld_num)
        sqlCV.SqlFields("^0.TDA03", "KEYS")
        sqlCV.SqlFields("^1.TA01+' '+^1.TA02", "DATAS")
        sqlCV.sqlOrder("^0.TDA02", APSQL.SQLCNV.intOrder.Order_Asc)
        ComboBox1.DisplayMember = "DATAS"
        ComboBox1.ValueMember = "KEYS"
        ComboBox1.DataSource = DB.RsSQL(sqlCV.Text, "TDA")
        ComboBox1.SelectedValue = rs1.Rows(0)!TN03.ToString.Trim
        If rs1.Rows(0)!TN06.ToString.Trim = "1" Then 'Or rs1.Rows(0)!TN06.ToString.Trim = "2" Then
          sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TM")
          sqlCV.Where("TM01", "=", strK)
          sqlCV.SqlFields("TM02", "工序")
          sqlCV.SqlFields("TM06", "時間")
          sqlCV.SqlFields("TM09", "不良碼")
          sqlCV.SqlFields("TM07")
          sqlCV.SqlFields("USEQ", , , , True)
          rs1 = DB.RsSQL(BIG2GB(sqlCV.Text), "TM1")
          Dim strV As String = ""
          intU = 0
          For Each r As DataRow In rs1.Rows
            Dim strM() As String = r!TM07.ToString.Trim.Split("^")
            strV &= strM(0) & ","
            If r.Item(2).ToString.Trim <> "" Then
              intU = Val(r!USEQ.ToString)
              strEL = MakeErrCode(r.Item(2).ToString.Trim)
            End If
          Next
          rs1.Columns.Remove("TM07")
          rs1.Columns.Remove("USEQ")
          DG1.DataSource = rs1
          Dim strK3() As String = strV.Split(",")
          Dim rs2 As New DataTable
          rs2.TableName = "Material"
          rs2.Columns.Add(BIG2GB("換料"), GetType(Boolean))
          rs2.Columns.Add(BIG2GB("回收"), GetType(Boolean))
          rs2.Columns.Add(BIG2GB("料號"), GetType(String))
          rs2.Columns.Add(BIG2GB("料批"), GetType(String))
          rs2.Columns.Add(BIG2GB("用量"), GetType(String))
          rs2.Columns.Add(BIG2GB("更換料號序號"), GetType(String))
          rs2.Columns.Add(BIG2GB("可用料號"), GetType(String))
          rs2.Columns.Add(BIG2GB("用料類"), GetType(String))
          sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TC")
          w = sqlCV.SqlJoin(APSQL.SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TD", "TD02", "=", "^0.TC01")
          w.Add("SFIS_TD.TD01", "=", "'" & strMO & "'")
          sqlCV.SqlFields("TC02")
          sqlCV.SqlFields("TC08")
          sqlCV.SqlFields("TC05")
          rs1 = DB.RsSQL(sqlCV.Text, "RT")
          For Each r As DataRow In rs1.Rows
            rs2.Rows.Add(False, False, r!TC02.ToString.Trim, "", "", "", (r!TC02.ToString.Trim & "," & r!TC08.ToString.Trim).Trim(","), r!TC05.ToString.Trim)
          Next
          DG2.DataSource = rs2
          For intC As Integer = 0 To DG2.Columns.Count - 1
            If intC > 1 Then
              DG2.Columns(intC).ReadOnly = True
            Else
              DG2.Columns(intC).ReadOnly = False
            End If
            DG2.Columns(intC).SortMode = DataGridViewColumnSortMode.NotSortable
          Next
          For Each strK4 As String In strK3
            If strK4.Trim = "" Then Continue For
            Dim strK5() As String = strK4.Split("|=".ToCharArray)
            For Each r As DataGridViewRow In DG2.Rows
              Dim strM1() As String = GCell(r.Cells(6)).Split(",")
              Dim strM2 As String = GCell(r.Cells(7))
              Dim aryS As New ArrayList
              aryS.AddRange(strM1)
              If aryS.Contains(strK5(0)) = True Then
                r.Cells(2).Value = strK5(0)
                r.Cells(3).Value = strK5(1)
                r.Cells(4).Value = strK5(2)
                Exit For
              End If
            Next
          Next
        Else
          TextBox1.Text = ""
          TextBox1.Focus()
          MSG.Text = BIG2GB("此ID沒有不良無須維修")
          strID = ""
          strMO = ""
          strGRP = ""
          Return
        End If
      End If
    End If
  End Sub
  Private Function ToSetMat(strKey As String) As Boolean
    Dim bolT As Boolean = False
    Dim strK5() As String = strKey.Split("|/".ToCharArray)
    If strK5.Length = 4 Then
      Dim sqlCV As New APSQL.SQLCNV
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TE")
      sqlCV.Where("TE01", "=", strK5(0))
      sqlCV.Where("TE02", "=", strK5(0) & "_" & strK5(1))
      sqlCV.Where("TE03", "=", strK5(3))
      sqlCV.SqlFields("TE14")
      Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
      If rs.Rows.Count > 0 Then
        If rs.Rows(0)!TE14.ToString.Trim <> "" Then
          MSG.Text = BIG2GB("料件ID已經使用過")
          Return bolT
        End If
      End If
    End If
    If strK5.Length < 3 Then
      MSG.Text = BIG2GB("料件ID無法辨識")
      Return bolT
    End If
    For Each r As DataGridViewRow In DG2.Rows
      Dim strM1() As String = GCell(r.Cells(6)).Split(",")
      Dim strM2 As String = GCell(r.Cells(7))
      Dim aryS As New ArrayList
      aryS.AddRange(strM1)
      If aryS.Contains(strK5(0)) = True Then
        If strM2.StartsWith("4") And strM2.Length = 3 And strK5.Length <> 4 Then
          MSG.Text = BIG2GB("料件ID必須是獨立序號")
          Return bolT
        End If
        r.Cells(5).Value = strKey
        r.Cells(0).Value = True
        bolT = True
        MSG.Text = ""
        Return bolT
      End If
    Next
    MSG.Text = BIG2GB("料件ID無法符合料站表")
    Return bolT
  End Function

  Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
    If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
      e.Handled = True
      ToSetMat(TextBox5.Text.Trim)
      TextBox5.Text = ""
      TextBox5.Focus()
    End If
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    DG1.DataSource = Nothing
    DG2.DataSource = Nothing
    ReList()
    TextBox1.Text = ""
    TextBox2.Text = ""
    TextBox3.Text = ""
    TextBox4.Text = ""
    TextBox5.Text = ""
    TextBox1.Focus()
    R2.Checked = True
    MSG.Text = ""
    strMO = ""
    strID = ""
  End Sub
  Private Function UpdateA(strKey As String, strMode As String, intUQ As Integer, strO As String) As Boolean
    Dim strV() As String = strKey.Split("/|".ToCharArray)
    Dim strO1() As String = strO.Split(",")
    Dim strC As String = ""
    Dim strI As String = ""
    Dim strD As String = ""
    Dim strS As String = ""
    Dim intQ As Integer = 0
    If strV.Length = 3 Then
      strC = ""
      strI = strV(0).Trim
      strD = strV(0).Trim & "$" & strV(1).Trim
      strS = "00001"
      intQ = Val(strV(2))
    ElseIf strV.Length = 4 Then
      strC = strV(2).Trim
      strI = strV(0).Trim
      strD = strV(0).Trim & "$" & strV(1).Trim
      strS = strV(3).Trim
      intQ = 1
    ElseIf strV.Length = 5 Then
      strC = strV(2).Trim
      strI = strV(0).Trim
      strD = strV(0).Trim & "$" & strV(1).Trim
      strS = strV(3).Trim
      If strS = "" Then strS = "00001"
      intQ = Val(strV(4))
    Else
      Return False
    End If
    Dim intPICK As Integer = 0
    If strMode.StartsWith("4") And strMode.Length = 3 Then
      intPICK = 1
    ElseIf strMode.StartsWith("1") And strMode.Length = 3 Then
      intPICK = 2
    ElseIf strMode.StartsWith("2") And strMode.Length = 3 Then
      intPICK = 4
    Else
      intPICK = 4
    End If
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TE")
    sqlCV.Where("TE01", "=", strI)
    sqlCV.Where("TE02", "=", strD)
    sqlCV.Where("TE03", "=", strS)
    sqlCV.SqlFields("USEQ")
    sqlCV.SqlFields("TE14")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count = 0 Then
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "SFIS_TE")
      sqlCV.SqlFields("TE01", strI)
      sqlCV.SqlFields("TE02", strD)
      sqlCV.SqlFields("TE03", strS)
      sqlCV.SqlFields("TE04", intQ, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TE05", intQ, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TE06", 0, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TE07", 0, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TE08", 1, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TE09", 1, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TE15", strMode)
      If intPICK = 1 Then sqlCV.SqlFields("TE14", strID)
      sqlCV.SqlFields("TE21", strC)
      sqlCV.SqlFields("TE22", Now.ToString("yyyy\/MM\/dd"), APSQL.intFMode.msfld_date)
      DB.RsSQL(sqlCV.Text)
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "SFIS_TDB")
      sqlCV.SqlFields("TDB01", strMO)
      sqlCV.SqlFields("TDB02", strGRP)
      sqlCV.SqlFields("TDB03", strI)
      sqlCV.SqlFields("TDB04", strD)
      sqlCV.SqlFields("TDB05", strS)
      sqlCV.SqlFields("TDB06", intUQ)
      sqlCV.SqlFields("TDB07", intUQ)
      sqlCV.SqlFields("TDB08", intUQ, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TDB09", 0, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TDB10", 0, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TDB11", 0, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TDB12", intQ - intUQ, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TDB13", intPICK, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TDB14", 0, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TDB15", 0, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TDB16", 0, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TDB17", 0, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TDB18", 0, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TDB19", strO1(0))
      sqlCV.SqlFields("TDB22", intPICK)
      sqlCV.SqlFields("TDB23", "RWSTN")
      sqlCV.SqlFields("TDB24", strC)
      DB.RsSQL(sqlCV.Text)
    Else
      If intPICK = 1 Then
        For Each r As DataRow In rs.Rows
          If r!TE14.ToString.Trim = "" Then
            sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_update, "SFIS_TE")
            sqlCV.Where("USEQ", "=", r!USEQ.ToString, APSQL.intFMode.msfld_num)
            sqlCV.SqlFields("TE14", strID)
            DB.RsSQL(sqlCV.Text)
          End If
        Next
      End If
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "SFIS_TDB")
      sqlCV.SqlFields("TDB01", strMO)
      sqlCV.SqlFields("TDB02", strGRP)
      sqlCV.SqlFields("TDB03", strI)
      sqlCV.SqlFields("TDB04", strD)
      sqlCV.SqlFields("TDB05", strS)
      sqlCV.SqlFields("TDB06", intUQ)
      sqlCV.SqlFields("TDB07", intUQ)
      sqlCV.SqlFields("TDB08", intUQ, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TDB09", 0, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TDB10", 0, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TDB11", 0, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TDB12", 0, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TDB13", intPICK, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TDB14", 0, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TDB15", 0, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TDB16", 0, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TDB17", 0, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TDB18", 0, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TDB19", strO1(0))
      sqlCV.SqlFields("TDB22", intPICK)
      sqlCV.SqlFields("TDB23", "RWSTN")
      sqlCV.SqlFields("TDB24", strC)
      DB.RsSQL(sqlCV.Text)
    End If
    Return True
  End Function
  Private Sub ReMat()
    Dim sqlCV As New APSQL.SQLCNV
    For Each r As DataGridViewRow In DG2.Rows
      If r.Cells(0).Value = False Then Continue For
      Dim strMID As String = GCell(r.Cells(5))
      If strMID.Trim = "" Then Continue For
      UpdateA(strMID, GCell(r.Cells(7)), Val(GCell(r.Cells(4))), GCell(r.Cells(6)))
      If r.Cells(1).Value = False Then Continue For
      strMID = GCell(r.Cells(3))
      If strMID.Trim = "" Then Continue For
      Dim strMV() As String = strMID.Split("_")
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_update, "SFIS_TE")
      sqlCV.Where("TE01", "=", strMV(0))
      sqlCV.Where("TE02", "=", strMV(0) & "_" & strMV(1))
      sqlCV.Where("TE03", "=", strMV(2))
      sqlCV.SqlFields("TE14", "")
      DB.RsSQL(sqlCV.Text)
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_update, "SFIS_TDB")
      sqlCV.Where("TDB01", "=", strMO)
      sqlCV.Where("TDB03", "=", strMV(0))
      sqlCV.Where("TDB04", "=", strMV(0) & "_" & strMV(1))
      sqlCV.Where("TDB05", "=", strMV(2))
      sqlCV.SqlFields("TDB08", "ISNULL(TDB08,0)-" & GCell(r.Cells(4)), APSQL.intFMode.msfld_field)
      sqlCV.SqlFields("TDB12", "ISNULL(TDB12,0)+" & GCell(r.Cells(4)), APSQL.intFMode.msfld_field)
      DB.RsSQL(sqlCV.Text)
    Next
  End Sub
  Private Sub Update_Mat(strTM07 As String)
    Dim sqlCV As New APSQL.SQLCNV
    If strTM07.Trim(", ".ToCharArray) = "" Then Return
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "SFIS_TM")
    sqlCV.SqlFields("TM01", strID)
    sqlCV.SqlFields("TM02", strGRP)
    sqlCV.SqlFields("TM03", lgncode)
    sqlCV.SqlFields("TM04", My.Computer.Name)
    sqlCV.SqlFields("TM05", "")
    sqlCV.SqlFields("TM06", Now, APSQL.intFMode.msfld_datetime)
    sqlCV.SqlFields("TM07", strTM07.Trim(", ".ToCharArray))
    sqlCV.SqlFields("TM08", 8, APSQL.intFMode.msfld_num)
    DB.RsSQL(sqlCV.Text)
  End Sub
  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    Dim sqlCV As New APSQL.SQLCNV
    If strID = "" Then Return
    If R1.Checked = True Then
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_update, "SFIS_TN")
      sqlCV.Where("TN01", "=", strID)
      sqlCV.SqlFields("TN06", 0, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TN05", "")
      DB.RsSQL(sqlCV.Text)
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_TDA")
      sqlCV.Where("TDA01", "=", strMO)
      sqlCV.Where("TDA03", "=", strGRP)
      sqlCV.SqlFields("TDA06", "ISNULL(TDA06,1)-1", intFMode.msfld_field)
      DB.RsSQL(sqlCV.Text)
    ElseIf R2.Checked = True Then
      If TextBox2.Text.Trim = "" Then
        MSG.Text = BIG2GB("不良事項不得空白")
        Return
      End If
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "SFIS_TMA")
      sqlCV.SqlFields("TMA01", strID)
      sqlCV.SqlFields("TMA02", intU)
      sqlCV.SqlFields("TMA03", strGRP)
      sqlCV.SqlFields("TMA04", strEL)
      sqlCV.SqlFields("TMA05", MakeErrCode(TextBox2.Text.Trim))
      sqlCV.SqlFields("TMA06", MakeErrCode(TextBox3.Text.Trim))
      sqlCV.SqlFields("TMA07", lgncode)
      sqlCV.SqlFields("TMA08", My.Computer.Name)
      Dim strTMA09 As String = ""
      For Each r As DataGridViewRow In DG2.Rows
        If r.Cells(0).Value = True Then
          Dim strM1() As String = GCell(r.Cells(5)).Split("/|".ToCharArray)
          If strM1.Length = 4 Then
            strTMA09 &= strM1(0) & "|" & strM1(0) & "_" & strM1(1) & "_" & strM1(3) & "=1.00,"
          ElseIf strM1.Length >= 2 Then
            strTMA09 &= strM1(0) & "|" & strM1(0) & "_" & strM1(1) & "_00001=1.00,"
          End If
        End If
      Next
      sqlCV.SqlFields("TMA09", strTMA09.Trim(","))
      sqlCV.SqlFields("TMA10", Now, APSQL.intFMode.msfld_datetime)
      sqlCV.SqlFields("TMA11", TextBox4.Text.Trim)
      sqlCV.SqlFields("TMA12", 0, APSQL.intFMode.msfld_num)
      DB.RsSQL(sqlCV.Text)
      Update_Mat(strTMA09)
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_update, "SFIS_TN")
      sqlCV.Where("TN01", "=", strID)
      sqlCV.SqlFields("TN06", 2, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TN05", ComboBox1.SelectedValue.ToString.Trim)
      sqlCV.SqlFields("TN04", Now, APSQL.intFMode.msfld_datetime)
      sqlCV.SqlFields("TN08", "ISNULL(TN08,0)+1", APSQL.intFMode.msfld_field)
      DB.RsSQL(sqlCV.Text)
      If strTMA09.Trim(" ,".ToCharArray) <> "" Then
        ReMat()
      End If
    ElseIf R3.Checked = True Then
      If TextBox2.Text.Trim = "" Then
        MSG.Text = BIG2GB("不良事項不得空白")
        Return
      End If
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "SFIS_TMA")
      sqlCV.SqlFields("TMA01", strID)
      sqlCV.SqlFields("TMA02", intU)
      sqlCV.SqlFields("TMA03", strGRP)
      sqlCV.SqlFields("TMA04", strEL)
      sqlCV.SqlFields("TMA05", MakeErrCode(TextBox2.Text.Trim))
      sqlCV.SqlFields("TMA06", MakeErrCode(TextBox3.Text.Trim))
      sqlCV.SqlFields("TMA07", lgncode)
      sqlCV.SqlFields("TMA08", My.Computer.Name)
      Dim strTMA09 As String = ""
      For Each r As DataGridViewRow In DG2.Rows
        If r.Cells(0).Value = True Then
          Dim strM1() As String = GCell(r.Cells(5)).Split("/|".ToCharArray)
          If strM1.Length = 4 Then
            strTMA09 &= strM1(0) & "|" & strM1(0) & "_" & strM1(1) & "_" & strM1(3) & "=1.00,"
          ElseIf strM1.Length >= 2 Then
            strTMA09 &= strM1(0) & "|" & strM1(0) & "_" & strM1(1) & "_00001=1.00,"
          End If
        End If
      Next
      sqlCV.SqlFields("TMA09", strTMA09.Trim(","))
      sqlCV.SqlFields("TMA10", Now, APSQL.intFMode.msfld_datetime)
      sqlCV.SqlFields("TMA11", TextBox4.Text.Trim)
      sqlCV.SqlFields("TMA12", 1, APSQL.intFMode.msfld_num)
      DB.RsSQL(sqlCV.Text)
      Update_Mat(strTMA09)
      If strTMA09.Trim(" ,".ToCharArray) <> "" Then
        ReMat()
      End If
    Else
      If TextBox2.Text.Trim = "" Then
        MSG.Text = BIG2GB("不良事項不得空白")
        Return
      End If
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "SFIS_TMA")
      sqlCV.SqlFields("TMA01", strID)
      sqlCV.SqlFields("TMA02", intU)
      sqlCV.SqlFields("TMA03", strGRP)
      sqlCV.SqlFields("TMA04", strEL)
      sqlCV.SqlFields("TMA05", MakeErrCode(TextBox2.Text.Trim))
      sqlCV.SqlFields("TMA06", MakeErrCode(TextBox3.Text.Trim))
      sqlCV.SqlFields("TMA07", lgncode)
      sqlCV.SqlFields("TMA08", My.Computer.Name)
      sqlCV.SqlFields("TMA09", "")
      sqlCV.SqlFields("TMA10", Now, APSQL.intFMode.msfld_datetime)
      sqlCV.SqlFields("TMA11", TextBox4.Text.Trim)
      sqlCV.SqlFields("TMA12", 8, APSQL.intFMode.msfld_num)
      DB.RsSQL(sqlCV.Text)
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_update, "SFIS_TN")
      sqlCV.Where("TN01", "=", strID)
      sqlCV.SqlFields("TN06", 8, APSQL.intFMode.msfld_num)
      sqlCV.SqlFields("TN05", "")
      sqlCV.SqlFields("TN04", Now, APSQL.intFMode.msfld_datetime)
      sqlCV.SqlFields("TN08", "ISNULL(TN08,0)+1", APSQL.intFMode.msfld_field)
      sqlCV.SqlFields("TN10", 8, APSQL.intFMode.msfld_num)
      DB.RsSQL(sqlCV.Text)
    End If
    Button2_Click(Nothing, Nothing)
    MSG.Text = BIG2GB("存檔完成")
  End Sub

  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    My.Settings.RmaCheck = CheckBox1.Checked
    Me.Close()
  End Sub

  Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    Dim frm As New FrmSelect
    frm.TableName = "TG"
    frm.Title = "請選擇不良原因"
    frm.Codes = TextBox2.Text
    If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
      TextBox2.Text = frm.Codes
    End If
  End Sub

  Private Sub DG1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DG1.CellFormatting
    Select Case e.ColumnIndex
      Case 0
        Dim strM As String = GCell(DG1.Rows(e.RowIndex).Cells(e.ColumnIndex))
        e.Value = strM & " " & getgx(strM).Trim(" |".ToCharArray)
      Case 2
        Dim strM As String = GCell(DG1.Rows(e.RowIndex).Cells(e.ColumnIndex))
        e.Value = GetErrCode(strM, , False)
    End Select
  End Sub

  Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
    Dim frm As New FrmSelect
    frm.TableName = "TH"
    frm.Title = "請選擇責任代碼"
    frm.Codes = TextBox3.Text
    If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
      TextBox3.Text = frm.Codes
    End If
  End Sub

  Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
    ReList()
  End Sub
End Class