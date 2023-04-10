Public Class PM0402
  Private bolAdmin As Boolean = False
  Private strBPrf As String = ""
  Private strValue As String = ""
  Private strSurf As String = ""
  Private intTBOX As Integer = 0
  Private intQTY As Integer = 0
  Private intCTN As Integer = 0
  Private strLOG(15) As String
  Private aryItems As New ArrayList
  Private aryGRPs As New ArrayList
  Private bolLock As Boolean = False
  Private bolFinish As Boolean = False
  Private intTDA02 As Integer = 0
  Private intTDA05 As Integer = 0
  Private strMO As String = ""
  Private intCurIdx As Integer = 0 '當前刷碼的ppid數
  Private aryST As New Dictionary(Of String, String)
  Private aryID As New Dictionary(Of String, String)
  Private WithEvents clsLBT As LABTRANx64.LabRunX64 = Nothing
  Sub New()
    ' 此為設計工具所需的呼叫。
    InitializeComponent()
    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    languagechange(Me)
    dgdaochu(FDG)
  End Sub
  Private Sub PM0402_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    If clsLBT IsNot Nothing Then
      clsLBT.ClosePrinter()
      clsLBT = Nothing
    End If
    TuiCK(Me)
  End Sub

  Private Sub PM0402_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", "PRINTERS")
    sqlCV.SqlFields("QTN02", , , , True)
    sqlCV.SqlFields("QTN03")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "PTYPE")
    PTYPE.DisplayMember = "QTN02"
    PTYPE.ValueMember = "QTN02"
    PTYPE.DataSource = rs
    If rs.Rows.Count > 0 Then
      PTYPE.SelectedValue = rs.Rows(rs.Rows.Count - 1)!QTN02.ToString.Trim
    End If
    PRT.Items.Clear()
    PRT.Items.Add("(none)")
    For Each strK As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
      PRT.Items.Add(strK)
    Next
    PRT.SelectedIndex = 0
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TA")
    sqlCV.Where("TA04", "=", "100%xWG")
    sqlCV.SqlFields("TA01")
    rs = DB.RsSQL(sqlCV.Text, "RT")
    Dim strM As String = ""
    For Each r As DataRow In rs.Rows
      strM &= "'" & r!TA01.ToString.Trim & "',"
    Next
    strM = strM.Trim(",")
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_distinc, "SFIS_TD")
    If strM <> "" Then
      Dim w As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TDA", "TDA01", "=", "^0.TD01")
      w.Add("SFIS_TDA.TDA03", "IN", strM)
    End If
    sqlCV.SqlFields("^0.TD01", "KEYS")
    sqlCV.SqlFields("^0.TD01 + ' ' +  ^0.TD02", "DATAS")
    sqlCV.sqlOrder("^0.TD01", APSQL.SQLCNV.intOrder.Order_Dsc)
    rs = DB.RsSQL(sqlCV.Text, "TD1")
    ComboBox2.DisplayMember = "DATAS"
    ComboBox2.ValueMember = "KEYS"
    ComboBox2.DataSource = rs
    'Dim rsA As DataTable = clsQTN.ReBind("#LABELS")
    'ComboBox1.DataSource = rsA
    'ComboBox1.DisplayMember = "CNAME"
    'ComboBox1.ValueMember = "ID"
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", "#LABELS")
    sqlCV.Where("QTN04", "LIKE", "PK%")
    sqlCV.SqlFields("*")
    Dim rsB As DataTable = DB.RsSQL(sqlCV.Text, "LABELS")
    ComboBox1.DataSource = rsB
    ComboBox1.ValueMember = "QTN02"
    ComboBox1.DisplayMember = "QTN03"
    Button4_Click(Nothing, Nothing) 'Clear
  End Sub

  Private Sub PrtLBL(Optional bolP As Boolean = False)
    Dim sqlCV As New SQLCNV
    If bolP = False Then
      If ComboBox2.SelectedValue Is Nothing Then Return
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TD")
      sqlCV.Where("TD01", "=", ComboBox2.SelectedValue.ToString.Trim)
      sqlCV.SqlFields("*")
      Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
      If rs.Rows.Count = 0 Then Return
      aryST.Clear()
      aryST.Add("ISUDATE", CDate(rs.Rows(0)!TD09.ToString).ToString("yyyy\/MM\/dd"))
      aryST.Add("ISUID", rs.Rows(0)!TD36.ToString.Trim)
      aryST.Add("CSTNA", rs.Rows(0)!TD28.ToString.Trim)
      aryST.Add("CSTNO", rs.Rows(0)!TD27.ToString.Trim)
      aryST.Add("CSTORD", rs.Rows(0)!TD26.ToString.Trim)
      aryST.Add("BOXNO", Label16.Text.Trim)
      aryST.Add("PCLSNA", BIG2GB("主板"))
      aryST.Add("PCLSNA3", BIG2GB("從板"))
      aryST.Add("PCLSNA2", BIG2GB("分流板"))
      Dim intI1 As Integer = 0, intI2 As Integer = 0, intI3 As Integer = 0
      For Each r As DataGridViewRow In DGC.Rows
        If r.Cells.Count > 2 Then
          If GCell(r.Cells(1)) <> "" Then intI1 += 1
          If GCell(r.Cells(2)) <> "" Then intI2 += 1
          If r.Cells.Count > 3 AndAlso GCell(r.Cells(3)) <> "" Then intI3 += 1
          If r.Cells.Count > 4 AndAlso GCell(r.Cells(4)) <> "" Then intI3 += 1
          If r.Cells.Count > 5 AndAlso GCell(r.Cells(5)) <> "" Then intI3 += 1
          aryST.Add("SN" & (r.Index + 1).ToString("00"), GCell(r.Cells(1)))
          aryST.Add("SN" & (r.Index + 21).ToString("00"), GCell(r.Cells(2)))
          If r.Cells.Count > 3 Then aryST.Add("SN" & ((r.Index Mod 2) + 1).ToString("0") & "-" & ((r.Index \ 2) * 3 + 1).ToString("0"), GCell(r.Cells(3)))
          If r.Cells.Count > 4 Then aryST.Add("SN" & ((r.Index Mod 2) + 1).ToString("0") & "-" & ((r.Index \ 2) * 3 + 2).ToString("0"), GCell(r.Cells(4)))
          If r.Cells.Count > 5 Then aryST.Add("SN" & ((r.Index Mod 2) + 1).ToString("0") & "-" & ((r.Index \ 2) * 3 + 3).ToString("0"), GCell(r.Cells(5)))
        Else
          If GCell(r.Cells(1)) <> "" Then intI1 += 1
          aryST.Add("SN" & (r.Index + 1).ToString("00"), GCell(r.Cells(1)))
        End If
        For intJ As Integer = 1 To DGC.ColumnCount - 1
          r.Cells(intJ).Value = ""
        Next
      Next
      aryST.Add("QTY", intI1.ToString)
      aryST.Add("QTY2", intI2.ToString)
      aryST.Add("QTY3", intI3.ToString)
      aryST.Add("FD00", "1")
      aryID.Clear()
    End If
    Dim strPrt As String = "D:\PM0402.TXT"
    If PRT.Text.Trim <> "" And PRT.Text.Trim <> "(none)" Then
      strPrt = PRT.Text.Trim
    End If
    If PTYPE.SelectedItem Is Nothing Then
      MsgBox(BIG2GB("沒有選擇打印機類型"))
      Return
    End If
    Dim r1 As DataRowView = PTYPE.SelectedItem
    Dim strPPm As String = r1!QTN03.ToString.Trim
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlcv.Where("QTN01", "=", "#LBFX")
    sqlcv.Where("QTN02", "=", ComboBox1.SelectedValue)
    sqlcv.SqlFields("QTN05")
    Dim rsA As DataTable = DB.RsSQL(sqlcv.Text, "LBFX")
    If rsA.Rows.Count = 0 Then Return
    Dim b() As Byte = rsA.Rows(0)!QTN05
    DB.CloseRs(rsA)
    Dim strFmt As String = System.Text.Encoding.UTF8.GetString(b)
    clsLBT = New LABTRANx64.LabRunX64(strPrt & "," & strPPm, strFmt)
    Dim intW As Integer = 0
    clsLBT.OpenPrinter()
    While clsLBT.Ready = False And intW < 20
      System.Threading.Thread.Sleep(100)
      intW += 1
      My.Application.DoEvents()
    End While
    If clsLBT.Ready = False Then
      MsgBox(BIG2GB("標籤機尚未就緒"))
      clsLBT.ClosePrinter()
      clsLBT = Nothing
      Return
    End If
    clsLBT.PrintLabel()
    clsLBT.ClosePrinter()
    clsLBT = Nothing
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    If ComboBox2.SelectedValue Is Nothing Then
      Label14.Text = BIG2GB("尚未選擇工單")
    End If
    Dim bolT As Boolean = False
    If DGC.RowCount = 0 Then
      Label14.Text = BIG2GB("不可空箱")
      Return
    End If

    'For intR As Integer = 0 To intCurIdx - 1
    '  If GCell(DGC.Rows(intR).Cells(1)).Trim = "" Then
    '    Label14.Text = BIG2GB("未滿箱不可通過")
    '    Return
    '  End If
    '  bolT = True
    'Next
    Button1.Enabled = False
    SaveToTN()
    TD2TN_Link(ComboBox2.SelectedValue.ToString.Trim)
  End Sub

  Private Function GetNewBox() As String
    Dim sqlCV As New APSQL.SQLCNV
    Dim strM As String = Now.ToString("yyyyMMdd")
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", "#SEQID")
    sqlCV.Where("QTN02", "=", strM)
    sqlCV.SqlFields("QTN03")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "TT")
    If rs.Rows.Count > 0 Then
      strM = rs.Rows(0)!QTN03.ToString.Trim
      strM = strM.Substring(0, 8) & (Val(strM.Substring(8)) + 1).ToString("00000")
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_QTN")
      sqlCV.Where("QTN01", "=", "#SEQID")
      sqlCV.Where("QTN02", "=", strM.Substring(0, 8))
    Else
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_QTN")
      sqlCV.SqlFields("QTN01", "#SEQID")
      sqlCV.SqlFields("QTN02", strM.Substring(0, 8))
      strM &= "00001"
    End If
    sqlCV.SqlFields("QTN03", strM)
    DB.RsSQL(sqlCV.Text)
    DB.CloseRs(rs)
    Return strM
  End Function

  Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    If bolFinish Then
      bolFinish = False
      Button1.Enabled = True
    End If
  End Sub
  Private Function GetTN01(ByRef strD As String, strKB As String) As Integer
    Dim strV() As String = strD.Split(",")
    Dim strM As String = ""
    Dim intC As Integer = 0
    For Each strK As String In strV
      If strK = "" Then Continue For
      intC += 1
      strM &= "'" & strK & "',"
    Next
    If intC > 1 Then Return intC
    Dim sqlCV As New SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TD", "TD01", "=", "^0.TN02")
    sqlCV.Where("^0.TN01", "<>", strM.TrimEnd(","), intFMode.msfld_field)
    sqlCV.Where("^0.TN07", "=", strM.TrimEnd(","), intFMode.msfld_field)
    sqlCV.Where("^0.TN12", "=", strKB)
    sqlCV.SqlFields("^1.TD02", , , , True)
    sqlCV.SqlFields("^0.TN01", , , , True)
    sqlCV.SqlFields("^0.TN20")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    strM = ""
    strV = GCell(DGP.Rows(0).Cells(0)).Split(",")
    Dim aryC As New ArrayList
    aryC.AddRange(strV)
    intC = 0
    For Each r As DataRow In rs.Rows
      strM &= r!TN01.ToString.Trim & ","
      Dim strITNO As String = r!TD02.ToString.Trim
      If r!TN20.ToString.Trim <> "" Then strITNO = r!TN20.ToString.Trim
      If aryC.Contains(strITNO) = True Then
        intC += 1
      End If
    Next
    strD = strM.Trim(",")
    Return intC
  End Function
  ''' <summary>
  ''' 工單取得填報掃瞄資訊
  ''' </summary>
  ''' <param name="strTN02">工單號碼</param>
  ''' <remarks></remarks>
  Private Sub TD2TN_Link(strTN02 As String)
    If strTN02.Trim = "" Then Return
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TN")
    sqlCV.Where("^0.TN02", "=", strTN02)
    sqlCV.Where("ISNULL(^0.TN12,'')", "<>", "")
    sqlCV.SqlFields("^0.TN12")
    Dim strW As String = "(" & sqlCV.Text & ")"
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
    sqlCV.Where("TN12", "IN", strW, intFMode.msfld_field)
    sqlCV.SqlFields("^0.TN12", , , , True)
    sqlCV.SqlFields("^0.TN01", , , , True)
    sqlCV.SqlFields("^0.TN11")
    sqlCV.SqlFields("^0.TN14")
    Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "RS")
    FDG.Rows.Clear()
    intQTY = 0
    Dim strM As String = ""
    Dim strID As String = ""
    Dim strKB As String = ""
    Dim intC As Integer = 0
    Dim intB As Integer = 0
    Dim strKG As String = ""
    For Each r As DataRow In dt.Rows
      If strKB <> r!TN12.ToString.Trim Then
        If intC > 0 Then
          If aryGRPs.Count > 0 And DGP.Rows.Count = 0 Then
            FDG.Rows.Add(strTN02, strKB, intC.ToString("0"), strKG, strID.Trim(","))
          Else
            intC = GetTN01(strID, strKB)
            FDG.Rows.Add(strTN02, strKB, intC.ToString("0"), strKG, strID)
          End If
          intQTY += intC
        End If
        intC = 0
        strKB = r!TN12.ToString.Trim
        strID = ""
        If strM < strKB Then strM = strKB
        intB += 1
        strKG = r!TN11.ToString.Trim
      End If
      intC += 1
      If r!TN14.ToString.Trim = "" Then
        strID &= r!TN01.ToString.Trim & ","
      Else
        strID &= r!TN14.ToString.Trim & ","
      End If
    Next
    If intC > 0 Then
      If aryGRPs.Count > 0 And DGP.Rows.Count = 0 Then
        FDG.Rows.Add(strTN02, strKB, intC.ToString("0"), strKG, strID.Trim(","))
      Else
        intC = GetTN01(strID, strKB)
        FDG.Rows.Add(strTN02, strKB, intC.ToString("0"), strKG, strID)
      End If
      intQTY += intC
    End If
    Label15.Text = intB & "箱 / " & intQTY & "Pcs"
    Label16.Text = GetNewBox()
    If intQTY >= Val(TextBox8.Text) Then
      Label14.Text = BIG2GB("工單已經足量")
    End If
    intCurIdx = 0
  End Sub
  Public Function GetNewTN01(strMO As String) As String
#If EP = 1 Then
    If strMO = "" Then Return ""
    Dim TK As String = ""
    Dim chrV() As Char = strMO.ToCharArray
    For intI As Integer = chrV.GetUpperBound(0) To 0 Step -1
      If Char.IsNumber(chrV(intI)) Then
        TK = chrV(intI) & TK
      End If
      If TK.Length = 9 Then Exit For
    Next
    If TK.Length < 9 Then
      TK = New String("0", 9 - TK.Length) & TK
    End If
    TK &= Now.ToString("yyyyMMdd").Substring(2)
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
    sqlCV.Where("TN01", "Like", TK & "%")
    sqlCV.SqlFields("MAX(TN01)", "MVAL")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RTNS")
    If rs.Rows.Count = 0 OrElse rs.Rows(0)!MVAL.ToString.Trim.Length < 17 Then
      Return TK & "00001"
    Else
      Dim strM As String = rs.Rows(0)!MVAL.ToString.Trim.Substring(15)
      Return TK & (Val(strM) + 1).ToString("00000")
    End If
#Else
    return ""
#End If
  End Function

  Private Sub SaveToTN()
    If ComboBox2.SelectedValue Is Nothing Then Return
    Dim strM1 As String = "", strM2 As String = ""
    For Each r As DataGridViewRow In DGC.Rows
      For intI As Integer = 1 To DGC.ColumnCount - 1
        If GCell(r.Cells(intI)) <> "" Then
          If aryID.ContainsKey(GCell(r.Cells(intI))) = False Then
            strM1 &= "'" & GCell(r.Cells(intI)) & "',"
          Else
            strM1 &= "'" & aryID(GCell(r.Cells(intI))) & "',"
          End If
        End If
      Next
    Next
    strM2 = strM1
    Dim sqlCV As New SQLCNV
    Dim strTM As String = Now.ToString("yyyy\/MM\/dd HH:mm:ss")
    Dim strPPID As String = ""
    '先更新同一個工單資料
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_TN")
    sqlCV.Where("TN02", "=", ComboBox2.SelectedValue.ToString.Trim)
    sqlCV.Where("TN01", "IN", strM1.Trim(","), intFMode.msfld_field)
    sqlCV.SqlFields("TN03", TextBox1.Text.Trim.Split(" ")(0))
    sqlCV.SqlFields("TN12", Label16.Text.Trim)
    sqlCV.SqlFields("TN04", strTM)
    sqlCV.SqlFields("TN11", "")
    sqlCV.SqlFields("TN16", 0, intFMode.msfld_num)
    Dim intL As Integer = DB.RsSQL(sqlCV.Text)
    intTDA05 += intL
    If intL = 0 Then
      '如果無法更新所選工單則新增一個序號
      strPPID = GetNewTN01(ComboBox2.SelectedValue.ToString.Trim)
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_TN")
      sqlCV.SqlFields("TN01", strPPID)
      sqlCV.SqlFields("TN02", ComboBox2.SelectedValue.ToString.Trim)
      sqlCV.SqlFields("TN03", TextBox1.Text.Trim.Split(" ")(0))
      sqlCV.SqlFields("TN04", strTM)
      sqlCV.SqlFields("TN12", Label16.Text.Trim)
      sqlCV.SqlFields("TN11", "")
      sqlCV.SqlFields("TN06", "0", intFMode.msfld_num)
      sqlCV.SqlFields("TN07", "")
      sqlCV.SqlFields("TN08", 0, intFMode.msfld_num)
      sqlCV.SqlFields("TN09", 0, intFMode.msfld_num)
      'sqlCV.SqlFields("TN10", 0, intFMode.msfld_num)
      sqlCV.SqlFields("TN16", 0, intFMode.msfld_num)
      DB.RsSQL(sqlCV.Text)
      strM2 &= "'" & strPPID & "',"
      intTDA05 += 1
    Else
      '如果有更新到一筆序號，則以此序號作為代表號
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
      sqlCV.Where("TN02", "=", ComboBox2.SelectedValue.ToString.Trim)
      sqlCV.Where("TN01", "IN", strM1.Trim(","), intFMode.msfld_field)
      sqlCV.SqlFields("TN01", , , , True)
      Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
      If rs.Rows.Count = 0 Then
        MsgBox(BIG2GB("資料庫錯誤"))
        Return
      End If
      strPPID = rs.Rows(0)!TN01.ToString.Trim
    End If
    '將其他工單的序號綁定到這個序號
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_TN")
    sqlCV.Where("TN02", "<>", ComboBox2.SelectedValue.ToString.Trim)
    sqlCV.Where("TN01", "IN", strM1.Trim(","), intFMode.msfld_field)
    sqlCV.SqlFields("TN12", Label16.Text.Trim)
    sqlCV.SqlFields("TN04", strTM)
    sqlCV.SqlFields("TN11", "")
    sqlCV.SqlFields("TN16", 0, intFMode.msfld_num)
    sqlCV.SqlFields("TN07", strPPID)
    DB.RsSQL(sqlCV.Text)
    For Each strK As String In aryID.Keys
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_TN")
      sqlCV.Where("TN01", "=", aryID(strK))
      sqlCV.SqlFields("TN14", strK)
      DB.RsSQL(sqlCV.Text)
      strM2 &= "'" & aryID(strK) & "',"
    Next
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_TM")
    sqlCV.SqlFields("TM01", strPPID)
    sqlCV.SqlFields("TM02", TextBox1.Text.Trim.Split(" ")(0))
    sqlCV.SqlFields("TM03", lgncode)
    sqlCV.SqlFields("TM04", My.Computer.Name)
    sqlCV.SqlFields("TM05", "P")
    sqlCV.SqlFields("TM06", Now, APSQL.intFMode.msfld_datetime)
    sqlCV.SqlFields("TM07", "")
    sqlCV.SqlFields("TM08", 0, APSQL.intFMode.msfld_num)
    DB.RsSQL(sqlCV.Text)
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_TN")
    sqlCV.Where("TN01", "IN", strM2.Trim(","))
    sqlCV.SqlFields("TN17", DB.intUSEQ, intFMode.msfld_num)
    DB.RsSQL(sqlCV.Text)
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_TDA")
    sqlCV.Where("TDA01", "=", strMO)
    sqlCV.Where("TDA02", "=", intTDA02, intFMode.msfld_num)
    sqlCV.SqlFields("TDA05", "ISNULL(TDA05,0)+" & intTDA05.ToString, intFMode.msfld_field)
    sqlCV.SqlFields("TDA07", "ISNULL(TDA07,0)+" & intTDA05.ToString, intFMode.msfld_field)
    DB.RsSQL(sqlCV.Text)
    PrtLBL()
  End Sub

  Private Sub ComboBox1_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBox1.SelectionChangeCommitted
    If ComboBox1.SelectedValue Is Nothing Then Return
    Dim sqlcv As New APSQL.SQLCNV
    sqlcv.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlcv.Where("QTN01", "=", "#LABELS")
    sqlcv.Where("QTN02", "=", ComboBox1.SelectedValue)
    sqlcv.SqlFields("QTN05")
    Dim rsB As DataTable = DB.RsSQL(sqlcv.Text, "RS")
    If rsB.Rows.Count > 0 Then
      If rsB.Rows(0)!QTN05.GetType Is GetType(DBNull) Then
        PictureBox1.BackgroundImage = Nothing
      Else
        Dim bytV As Byte() = rsB.Rows(0)!QTN05
        Dim fs As New IO.MemoryStream
        Try
          fs.Write(bytV, 0, bytV.Length)
          PictureBox1.BackgroundImage = New Bitmap(fs)
        Catch ex As Exception
          PictureBox1.BackgroundImage = Nothing
        End Try
        fs.Close()
      End If
    Else
      PictureBox1.BackgroundImage = Nothing
    End If
    sqlcv.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlcv.Where("QTN01", "LIKE", "##LABELS||%")
    sqlcv.Where("QTN02", "=", ComboBox1.SelectedValue)
    sqlcv.SqlFields("QTN01")
    sqlcv.SqlFields("QTN03")
    Dim rs As DataTable = DB.RsSQL(sqlcv.Text, "RTS")
    If rs.Rows.Count = 0 Then Return
    Dim strMode As String = "", intC As Integer = 1
    For Each r As DataRow In rs.Rows
      If r!QTN01.ToString.Trim.ToUpper.EndsWith("PAPER") = True Then
        Label3.Text = r!QTN03.ToString.Trim
      ElseIf r!QTN01.ToString.Trim.ToUpper.EndsWith("QTY") = True Then
        intCTN = Val(r!QTN03.ToString.Trim)
      ElseIf r!QTN01.ToString.Trim.ToUpper.EndsWith("MODE") = True Then
        strMode = r!QTN03.ToString.Trim
      End If
    Next
    DGC.Columns.Clear()
    DGC.Rows.Clear()
    aryID.Clear()
    DGC.Columns.Add("C0", "No.")
    DGC.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
    If strMode.Contains(":") Then
      Label19.Text = intCTN.ToString & "Set"
      intC = intCTN
      Dim strV() As String = strMode.Split(":")
      Dim intJ As Integer = 1
      For Each strK As String In strV
        Dim intC1 As Integer = Val(strK)
        For intI As Integer = 1 To intC1
          If intC1 > 1 Then
            DGC.Columns.Add("C" & DGC.Columns.Count, BIG2GB("序號" & intJ) & "_" & intI)
          Else
            DGC.Columns.Add("C" & DGC.Columns.Count, BIG2GB("序號" & intJ))
          End If
          With DGC.Columns(DGC.Columns.Count - 1)
            .SortMode = DataGridViewColumnSortMode.NotSortable
          End With
        Next
        intJ += 1
      Next
    Else
      Label19.Text = intCTN.ToString & "Pcs"
      intC = intCTN
      DGC.Columns.Add("C" & DGC.Columns.Count, BIG2GB("序號"))
    End If
    If intCTN = 0 Then Return
    DGC.Rows.Add(intCTN)
    For Each r1 As DataGridViewRow In DGC.Rows
      r1.Cells(0).Value = r1.Index + 1
    Next
    Dim intTQty As Integer = Val(TextBox8.Text)
    intTBOX = IIf(intCTN = 0, 0, Int((intTQty + intCTN - 1) / intCTN))
    Label9.Text = intTBOX.ToString("0") & BIG2GB("箱")
  End Sub

  Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    For Each c As Control In Panel2.Controls
      If c.GetType Is GetType(TextBox) Then
        c.Text = ""
        c.Enabled = True
      End If
    Next
    Label19.Text = ""
    Label3.Text = ""
    Label9.Text = ""
    Label14.Text = ""
    Label15.Text = ""
    Label16.Text = ""
    intCurIdx = 0
    ComboBox2.Enabled = True
    PictureBox1.BackgroundImage = Nothing
    If FDG.ColumnCount > 0 Then FDG.Rows.Clear()
    DGC.Rows.Clear()
    aryID.Clear()
  End Sub
  Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
    PrtLBL(True)
  End Sub

  ''' <summary>
  ''' 掃瞄PPID進入表單中
  ''' </summary>
  ''' <param name="strPPID"></param>
  ''' <remarks></remarks>
  Private Function Scanner(strPPID As String, sngWgt As Double) As Boolean
    If ComboBox2.SelectedValue Is Nothing Then
      Label14.Text = BIG2GB("沒有選擇工單")
      Return False
    End If
    If TextBox1.Text = "" Then
      MsgBox(BIG2GB("沒有包裝工序，無法啟動包裝"))
      Return False
    End If
    If DGC.RowCount = 0 Then
      Label14.Text = BIG2GB("請先選擇標籤格式")
      Return False
    End If
    If intCurIdx >= DGC.RowCount Then
      Label14.Text = BIG2GB("此箱已滿，不可再刷碼")
      Return False
    End If
    If intQTY + intCurIdx >= Val(TextBox8.Text) Then
      Label14.Text = BIG2GB("工單已滿")
      Return False
    End If
    Dim sqlCV As New APSQL.SQLCNV, rs As DataTable = Nothing
    If strPPID.Length > 40 Then
      strPPID = strPPID.Split("|")(0)
      TextBox2.Text = strPPID
    End If
    Dim strPOLD As String = strPPID
    While -1
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
      sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TD", "TD01", "=", "^0.TN02")
      sqlCV.Where("^0.TN01", "=", strPPID)
      sqlCV.SqlFields("^0.TN06")
      sqlCV.SqlFields("^0.TN01")
      sqlCV.SqlFields("^0.TN02")
      sqlCV.SqlFields("^0.TN03")
      sqlCV.SqlFields("^0.TN07")
      sqlCV.SqlFields("^0.TN10")
      sqlCV.SqlFields("^0.TN12")
      sqlCV.SqlFields("^0.TN20")
      sqlCV.SqlFields("^1.TD02")
      rs = DB.RsSQL(sqlCV.Text, "RT")
      If rs.Rows.Count = 0 Then
        MsgBox(BIG2GB("PPID找不到無法使用[" & strPPID & "]"))
        Return False
      End If
      If rs.Rows(0)!TN12.ToString.Trim <> "" Then
        MsgBox(BIG2GB("這個PPID已經包裝在其他箱" & rs.Rows(0)!TN12.ToString.Trim))
        Return False
      End If
      Dim intTN06 As Integer = Val(rs.Rows(0)!TN06.ToString.Trim)
      If (intTN06 = 7 Or intTN06 = 100) And rs.Rows(0)!TN07.ToString.Trim <> "" Then
        strPPID = rs.Rows(0)!TN07.ToString.Trim
        If intTN06 = 100 Then strPOLD = strPPID
        Continue While
      End If
      Dim strITNO As String = rs.Rows(0)!TD02.ToString.Trim
      If rs.Rows(0)!TN20.ToString.Trim <> "" Then
        strITNO = rs.Rows(0)!TN20.ToString.Trim
      End If
      If intTN06 = 4 Then
        If aryItems.Contains(strITNO) Then Exit While
        MsgBox(BIG2GB("這個料號" & strITNO & "不在包裝料表中"))
        Return False
      Else
        If intTN06 = 0 Then
          If rs.Rows(0)!TN10.ToString.Trim = "10" Then
            MsgBox(BIG2GB("這個PPID在抽驗清單中尚未抽驗完成"))
            Return False
          Else
            If aryGRPs.Contains(rs.Rows(0)!TN03.ToString) = True And rs.Rows(0)!TN02.ToString.Trim = ComboBox2.SelectedValue.ToString.Trim Then
              '同工單處理
              Exit While
            End If
          End If
        End If
        Select Case intTN06
          Case 0
            MsgBox(BIG2GB("這個PPID無法進入包裝，跨序"))
          Case 1, 2, 3
            MsgBox(BIG2GB("這個PPID不良品或待修反工"))
          Case 5
            MsgBox(BIG2GB("這個PPID已經出貨無法包裝"))
          Case 8
            MsgBox(BIG2GB("這個PPID已經報廢"))
        End Select
        Return False
      End If
      MsgBox(BIG2GB("未知錯誤"))
      Return False
    End While
    If rs Is Nothing OrElse rs.Rows.Count = 0 Then Return False
    '1 找尋是否已有加入清單表列中
    '2 找尋TN表，條件如下(是否有所屬箱號，是否有所屬工單)
    '  若都不在以上條件內則加入(包含TN表未增建立此PPID)。
    If aryID.ContainsKey(strPOLD) = True Then
      MsgBox(BIG2GB("ID條碼已在清單之中:") & strPOLD & "-->" & strPPID)
      Return False
    Else
      aryID.Add(strPOLD, strPPID)
    End If
    'For Each r As DataGridViewRow In DGC.Rows
    '  For Each c As DataGridViewCell In r.Cells
    '    If GCell(c) = strPOLD Then
    '      Return False
    '    End If
    '  Next
    'Next
    If rs.Rows(0)!TN02.ToString.Trim = ComboBox2.SelectedValue.ToString.Trim Then
      DGC.Rows(intCurIdx).Cells(1).Value = strPOLD
      intCurIdx += 1
      If intCurIdx = DGC.RowCount Then
        Label14.Text = BIG2GB("滿箱")
        bolFinish = True
      End If
      If (intQTY + intCurIdx) >= Val(TextBox8.Text) Then
        Label14.Text = BIG2GB("最後一件")
        bolFinish = True
      End If
      Return True
    End If
    Dim intI As Integer = 0, intL As Integer = Val(TextBox8.Text) - intQTY
    Dim strITNO1 As String = rs.Rows(0)!TD02.ToString.Trim
    If rs.Rows(0)!TN20.ToString.Trim <> "" Then strITNO1 = rs.Rows(0)!TN20.ToString.Trim
    For Each r As DataGridViewRow In DGP.Rows
      Dim intM As Integer = Val(GCell(r.Cells(1)))
      Dim strV() As String = GCell(r.Cells(0)).Split(",")
      Dim strM As String = strITNO1
      Dim bolMatch As Boolean = False
      For Each strK As String In strV
        If strK = strM Then
          bolMatch = True
          For Each r1 As DataGridViewRow In DGC.Rows
            For intK As Integer = 1 To intM
              If GCell(r1.Cells(intI + intK)) = "" Then
                r1.Cells(intI + intK).Value = strPOLD
                strM = ""
                Exit For
              End If
            Next
            If strM = "" Then Exit For
          Next
          Exit For
        End If
      Next
      If bolMatch = True Then
        If strM <> "" Then
          MsgBox(BIG2GB("這箱所需" & strM & "已經滿箱"))
          Return False
        Else
          Exit For
        End If
      End If
      intI += Val(GCell(r.Cells(1)))
    Next
    For Each r As DataGridViewRow In DGC.Rows
      If r.Index >= intL Then Exit For
      For intJ As Integer = 1 To DGC.ColumnCount - 1
        If GCell(r.Cells(intJ)) = "" Then Return True
      Next
    Next
    If intL < DGC.Rows.Count Then
      Label14.Text = BIG2GB("最後一件")
      bolFinish = True
    Else
      Label14.Text = BIG2GB("滿箱")
      bolFinish = True
    End If
    Return True
  End Function

  Private Sub Button6_Click(sender As Object, e As EventArgs)
    FrmSetting.ShowDialog()
    MsgBox(BIG2GB("參數設定後請重啟程序"))
    Me.Close()
  End Sub

  Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
    If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
      e.Handled = True
      If TextBox2.Text.Trim <> "" Then Scanner(TextBox2.Text, 0)
      TextBox2.Text = ""
      TextBox2.Focus()
    End If
  End Sub

  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    Me.Close()
  End Sub

  Private Sub ComboBox2_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedValueChanged
    If bolLock Then
      bolLock = False
      ComboBox2.Enabled = False
    End If
  End Sub

  Private Sub ComboBox2_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBox2.SelectionChangeCommitted
    If ComboBox2.SelectedValue Is Nothing Then Return
    intTDA02 = -1
    intTDA05 = 0
    strMO = ""
    Dim strKey As String = ComboBox2.SelectedValue.ToString.Trim
    Dim sqlcv As New APSQL.SQLCNV
    sqlcv.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TD")
    sqlcv.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TBB", "TBB03", "=", "^0.TD02")
    sqlcv.Where("TD01", "=", strKey)
    sqlcv.Where("TD12", "IN", "'0','1'", APSQL.intFMode.msfld_field)
    sqlcv.SqlFields("^0.*")
    sqlcv.SqlFields("^1.TBB05")
    sqlcv.SqlFields("^1.TBB06")
    Dim dt As DataTable = DB.RsSQL(sqlcv.Text, "RR")
    If dt.Rows.Count = 0 Then Return '找不到工單
    Dim r As DataRow = dt.Rows(0)
    Dim strIT As String = r!TD02.ToString.Trim
    TextBox10.Text = r!TD02.ToString    'PartNo: TD02
    TextBox9.Text = r!TBB05.ToString.Trim & " " & r!TBB06.ToString.Trim      'Model : TD19
    TextBox8.Text = Val(r!TD07.ToString) + Val(r!TD30.ToString)    'Qty   : TD07
    ComboBox1.SelectedValue = r!TD24.ToString.Trim
    If ComboBox1.SelectedValue IsNot Nothing Then
      ComboBox1_SelectionChangeCommitted(Nothing, Nothing)
    End If
    Dim strV1() As String = r!TD25.ToString.Trim.Split("^")
    strBPrf = strV1(0).Trim
    strValue = strV1(1).Trim
    strSurf = strV1(2).Trim
    Dim intTQty As Integer = Val(TextBox8.Text)
    intTBOX = IIf(intCTN = 0, 0, Int((intTQty + intCTN - 1) / intCTN))
    Label9.Text = intTBOX.ToString("0") & BIG2GB("箱")
    TD2TN_Link(strKey)
    bolLock = True
    sqlcv.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TDA")
    sqlcv.Where("TDA01", "=", strKey)
    sqlcv.Where("TDA04", "IN", 0, intFMode.msfld_num)
    sqlcv.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TA", "TA01", "=", "^0.TDA03")
    sqlcv.SqlFields("TDA02", , , , True)
    sqlcv.SqlFields("TDA03")
    sqlcv.SqlFields("TDA05")
    sqlcv.SqlFields("TDA11")
    sqlcv.SqlFields("TDA13")
    sqlcv.SqlFields("TDA14")
    sqlcv.SqlFields("TDA15")
    sqlcv.SqlFields("^1.TA02")
    sqlcv.SqlFields("^1.TA04")
    Dim rs As DataTable = DB.RsSQL(sqlcv.Text, "RT")
    TextBox1.Tag = ""
    TextBox1.Text = ""
    For Each r1 As DataRow In rs.Rows
      If r1!TA04.ToString.Trim.ToUpper = "100%XWG" Then
        TextBox1.Text = r1!TDA03.ToString.Trim & " " & r1!TA02.ToString.Trim
        TextBox1.Tag = r1!TDA03.ToString.Trim
        intTDA02 = Val(r1!TDA02.ToString.Trim)
        strMO = strKey
        Exit For
      End If
      If Val(r1!TDA13.ToString) > 0 Then
        If Val(r1!TDA13.ToString) <= Val(r1!TDA05.ToString) Then
          If Val(r1!TDA15.ToString) <= (Val(r1!TDA05.ToString) - Val(r1!TDA11.ToString)) Then
            MsgBox(BIG2GB("工單抽檢工序[" & r1!TDA03.ToString & " " & r1!TA04.ToString.Trim & "]判定不良，無法啟動包裝"))
            DGC.Rows.Clear()
            TextBox1.Text = ""
            TextBox1.Tag = ""
            aryGRPs.Clear()
            aryItems.Clear()
            DGP.Rows.Clear()
            intTDA02 = -1
            strMO = ""
            Return
          End If
          'Else
          '  MsgBox(BIG2GB("工單抽檢工序[" & r1!TDA03.ToString & " " & r1!TA04.ToString.Trim & "]尚未完工，無法啟動包裝"))
          '  DGC.Rows.Clear()
          '  TextBox1.Text = ""
          '  TextBox1.Tag = ""
          '  aryGRPs.Clear()
          '  aryItems.Clear()
          '  DGP.Rows.Clear()
          '  Return
        End If
      End If
      Dim N As New NORMAL
      If r1!TA04.ToString.Trim.StartsWith("100%") = True Or N.GetLevels.Contains(r1!TA04.ToString.Trim) = True Then
        aryGRPs.Clear()
      End If
      aryGRPs.Add(r1!TDA03.ToString.Trim)
    Next
    If TextBox1.Text = "" Then
      MsgBox(BIG2GB("工單沒有包裝工序，無法啟動包裝"))
      DGC.Rows.Clear()
      TextBox1.Text = ""
      TextBox1.Tag = ""
      aryGRPs.Clear()
      aryItems.Clear()
      DGP.Rows.Clear()
      intTDA02 = -1
      strMO = ""
      Return
    End If
    aryItems.Clear()
    aryItems.Add(TextBox10.Text)
    sqlcv.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TC")
    sqlcv.Where("TC01", "=", strIT)
    sqlcv.Where("TC03", "=", TextBox1.Tag)
    sqlcv.SqlFields("TC02")
    sqlcv.SqlFields("TC06")
    sqlcv.SqlFields("TC08")
    sqlcv.sqlOrder("TC05", SQLCNV.intOrder.Order_Asc)
    rs = DB.RsSQL(sqlcv.Text, "RT")
    DGP.Rows.Clear()
    For Each r1 As DataRow In rs.Rows
      Dim strG As String = (r1!TC02.ToString.Trim & "," & r1!TC08.ToString.Trim).Trim(",")
      DGP.Rows.Add(strG, r1!TC06.ToString)
      Dim strV() As String = strG.Split(",")
      For Each strK As String In strV
        If strK <> "" Then
          aryItems.Add(strK)
        End If
      Next
    Next
    'ComboBox2.Enabled = False
  End Sub

  Private Sub clsLBT_ErrorSet(sender As LABTRANx64.LabRunX64, obj As LabPrinter, strV As String) Handles clsLBT.ErrorSet
    MsgBox(strV)
  End Sub

  Private Sub clsLBT_GetData(sender As LABTRANx64.LabRunX64, obj As LabPrinter, strFMT As String, ByRef strData As Object, intX As Integer, intY As Integer) Handles clsLBT.GetData
    strData = GetFmtName(strFMT)
  End Sub

  ''' <summary>
  ''' 取得格式化完的名稱
  ''' </summary>
  ''' <param name="strFmtName"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Private Function GetFmtName(strFmtName As String) As String
    Dim s As String = strFmtName, strOut As String = ""
    s = s.Replace("\[", "&*").Replace("\]", "*&")
    While True
      Dim intB As Integer = s.IndexOf("[")
      Dim intE As Integer = s.IndexOf("]")
      If intB < 0 Or intE < 0 Then
        strOut &= s
        Return strOut.Replace("&*", "[").Replace("*&", "]")
      Else
        If intB > 0 Then
          strOut &= s.Substring(0, intB)
        End If
        Dim strK As String = s.Substring(intB + 1, intE - intB - 1)
        If aryST.ContainsKey(strK) = True Then
          strOut &= aryST(strK)
        End If
        If s.Length <= intE + 1 Then
          s = ""
        Else
          s = s.Substring(intE + 1)
        End If
      End If
    End While
    Return ""
  End Function

  Private Sub FDG_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles FDG.CellContentClick

  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    If MsgBox(BIG2GB("未滿箱，是否要以殘箱結束"), vbYesNo, Me.Text) = MsgBoxResult.Yes Then
      Button1_Click(Nothing, Nothing)
    End If
  End Sub
End Class