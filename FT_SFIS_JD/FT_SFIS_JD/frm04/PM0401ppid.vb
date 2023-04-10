Imports APSQL

Public Class PM0401ppid
  Dim gd As String
  Dim firstgx As String
  Private strGD As String = ""
  Private intQTY As Integer = 0
  Private strItem As String = ""
  Private bolErr As Boolean = False
  Private bolWar As Boolean = False
  Private intCT As Integer = 0
  Private sno1 As New SerialID
  Private sno2 As New SerialID
  Private bolCancel As Boolean = False
  Private WithEvents clsLBT As LABTRANx64.LabRunX64 = Nothing
  Private aryLE As New ArrayList
  Private aryPE As New ArrayList
  Private aryTag As New Dictionary(Of String, String)
  Sub New(ByVal gd As String, ByVal gx1 As String)
    ' 此調用是設計器所必需的。
    InitializeComponent()
    Me.gd = gd
    firstgx = gx1
    languagechange(Me)
    Me.Text &= "-" & gd
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TD")
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TBB", "TBB03", "=", "^0.TD02")
    sqlCV.Where("^0.TD01", "=", gd)
    sqlCV.SqlFields("^0.*")
    sqlCV.SqlFields("^1.TBB05")
    sqlCV.SqlFields("^1.TBB04")
    sqlCV.SqlFields("^1.TBB06")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    aryTag.Clear()
    If rs.Rows.Count > 0 Then
      strItem = rs.Rows(0)!TD02.ToString.Trim
      intQTY = Val(rs.Rows(0)!TD07.ToString.Trim)
      MOQTY.Text = intQTY
      SmpQTy.Text = Val(rs.Rows(0)!TD30.ToString.Trim)
      intQTY += Val(SmpQTy.Text)
      MO.Text = gd
      strGD = rs.Rows(0)!TD25.ToString.Trim & "^^^^^"
      aryTag.Add("MOID", rs.Rows(0)!TD35.ToString.Trim)
      aryTag.Add("MODEL", rs.Rows(0)!TBB04.ToString.Trim)
      aryTag.Add("PNAME", rs.Rows(0)!TBB05.ToString.Trim)
      aryTag.Add("SPEC", rs.Rows(0)!TBB06.ToString.Trim)
      aryTag.Add("PCBA", rs.Rows(0)!TD31.ToString.Trim)
      aryTag.Add("BIOS", rs.Rows(0)!TD32.ToString.Trim)
      aryTag.Add("PN", rs.Rows(0)!TD02.ToString.Trim)
      aryTag.Add("VER", rs.Rows(0)!TD33.ToString.Trim)
      '--------------------------------------------------
      aryTag.Add("ITEMNAME", rs.Rows(0)!TD38.ToString.Trim)
      aryTag.Add("MODELID", rs.Rows(0)!TD19.ToString.Trim)
      aryTag.Add("ENGID", rs.Rows(0)!TD35.ToString.Trim)
      aryTag.Add("HVER", rs.Rows(0)!TD39.ToString.Trim)
      aryTag.Add("SVER", rs.Rows(0)!TD32.ToString.Trim)
      aryTag.Add("AVER", rs.Rows(0)!TD33.ToString.Trim)
      aryTag.Add("CUST", rs.Rows(0)!TD28.ToString.Trim)
      aryTag.Add("CSTPN", rs.Rows(0)!TD34.ToString.Trim)
      '---------------------------------------------------
      aryTag.Add("MBAR", "")
      aryTag.Add("BARTEXT", "")
      aryTag.Add("AUXLOT", "")
      aryTag.Add("FD00", "1")
    End If
  End Sub

  Private Sub PM0401ppid_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    If clsLBT IsNot Nothing Then
      clsLBT.ClosePrinter()
      clsLBT = Nothing
    End If
  End Sub
  Private Sub PM0401ppid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim sqlCV As New SQLCNV
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
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", "#LABELS")
    sqlCV.Where("QTN04", "=", "ID")
    sqlCV.SqlFields("QTN02")
    sqlCV.SqlFields("QTN03")
    sqlCV.SqlFields("QTN05")
    rs = DB.RsSQL(sqlCV.Text, "LBFX")
    LBFID.DisplayMember = "QTN03"
    LBFID.ValueMember = "QTN02"
    LBFID.DataSource = rs
    If rs.Rows.Count > 0 Then LBFID.SelectedValue = rs.Rows(0)!QTN02.ToString.Trim
    LBFID_SelectionChangeCommitted(Nothing, Nothing)
    PRT.Items.Clear()
    PRT.Items.Add("(none)")
    For Each strK As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
      PRT.Items.Add(strK)
    Next
    PRT.SelectedIndex = 0
    Dim strV() As String = strGD.Split("^")
    Dim intStart As Integer = Val(strV(1))
    Dim strFmt As String = New String("9", strV(1).Length)
    If strV(1).Contains("=") Then
      Dim strV1() As String = strV(1).Split("=")
      strFmt = strV1(0)
      intStart = Val(strV1(1))
    Else
      If IsNumeric(strV(1)) = False Then
        intStart = 1
        strFmt = strV(1)
      Else
        If strFmt = strV(1) Then
          intStart = 1
        End If
      End If
    End If
    If strV(1).Length = 0 Then
      SNED.Text = ""
      SNED.Tag = ""
      rbtzhu.Enabled = False
    Else
      sno1.IDMAP = "0123456789ABCDEFGHJKLMNPQRSTUVWYZ"
      sno1.ClearRule()
      sno1.ConcatID(IIf(strV(0).Trim = "", "", strV(0) & ",") & _
                    strFmt & IIf(strV(2).Trim = "", "", "," & strV(2)))
      SNBG.Text = sno1.GetID(intStart)
      sno1.BeginID = SNBG.Text
      SNED.Text = sno1.GetID(intQTY - 1) 'strV(0) & (Val(strV(1)) + intQTY - 1).ToString(New String("0", strV(1).Length)) & strV(2)
      SNED.Tag = strV(0).Trim & "}" & strV(1).Trim & "}" & strV(2).Trim
      rbtzhu.Enabled = True
    End If
    intStart = Val(strV(4))
    strFmt = New String("9", strV(4).Length)
    If strV(4).Contains("=") Then
      Dim strV1() As String = strV(4).Split("=")
      strFmt = strV1(0)
      intStart = Val(strV1(1))
    Else
      If IsNumeric(strV(4)) = False Then
        intStart = 1
        strFmt = strV(4)
      Else
        If strFmt = strV(4) Then
          intStart = 1
        End If
      End If
    End If
    If strV(4).Length = 0 Then
      IDBG.Text = ""
      IDBG.Text = ""
      IDED.Tag = ""
      Rbtfu.Enabled = False
    Else
      sno2.IDMAP = "0123456789ABCDEFGHJKLMNPQRSTUVWYZ"
      sno2.ClearRule()
      sno2.ConcatID(IIf(strV(3).Trim = "", "", strV(3) & ",") & _
                    strFmt & IIf(strV(5).Trim = "", "", "," & strV(5)))
      IDBG.Text = sno2.GetID(intStart)
      sno2.BeginID = IDBG.Text
      IDED.Text = sno2.GetID(intQTY - 1) 'strV(0) & (Val(strV(1)) + intQTY - 1).ToString(New String("0", strV(1).Length)) & strV(2)
      IDED.Tag = strV(3).Trim & "}" & strV(4).Trim & "}" & strV(5).Trim
      Rbtfu.Enabled = True
    End If
    If IDED.Text.Trim <> "" Then
      Rbtfu.Checked = True
      PRTBG.Text = IDBG.Text
      PQTY.Text = intQTY
    Else
      rbtzhu.Checked = True
      PRTBG.Text = SNBG.Text
      PQTY.Text = intQTY
    End If
    TMP.Text = My.Settings.TEMP
    XOFF.Text = My.Settings.XOFF
    YOFF.Text = My.Settings.YOFF
    CheckCode()
  End Sub
  Private Sub CheckCode()
    Dim sqlCV As New APSQL.SQLCNV
    Dim rs As DataTable = Nothing
    bolErr = False
    bolWar = False
    aryLE.Clear()
    aryPE.Clear()
    ListBox1.Items.Clear()
    If SNBG.Text.Trim <> "" Then
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
      sqlCV.Where("TN02", "<>", gd.Trim)
      sqlCV.Where("LEN(TN01)", "=", SNBG.Text.Trim.Length, intFMode.msfld_num)
      sqlCV.Where("TN01", ">=", SNBG.Text)
      sqlCV.Where("TN01", "<=", SNED.Text)
      sqlCV.SqlFields("Count(*)", "QTY")
      sqlCV.SqlFields("MIN(TN01)", "MVAL")
      sqlCV.SqlFields("MAX(TN01)", "XVAL")
      rs = DB.RsSQL(sqlCV.Text, "RT")
      If rs.Rows.Count > 0 Then
        If Val(rs.Rows(0)!QTY.ToString) > 0 Then
          ListBox1.Items.Add(BIG2GB("SN序號重複：") & rs.Rows(0)!QTY.ToString & BIG2GB("筆 從") & rs.Rows(0)!MVAL.ToString.Trim & BIG2GB("至") & rs.Rows(0)!XVAL.ToString.Trim)
          bolErr = True
        End If
      End If
    End If
    If IDBG.Text.Trim <> "" Then
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
      sqlCV.Where("TN02", "<>", gd.Trim)
      sqlCV.Where("LEN(TN01)", "=", IDBG.Text.Trim.Length, intFMode.msfld_num)
      sqlCV.Where("TN01", ">=", IDBG.Text)
      sqlCV.Where("TN01", "<=", IDED.Text)
      sqlCV.SqlFields("Count(*)", "QTY")
      sqlCV.SqlFields("MIN(TN01)", "MVAL")
      sqlCV.SqlFields("MAX(TN01)", "XVAL")
      rs = DB.RsSQL(sqlCV.Text, "RT")
      If rs.Rows.Count > 0 Then
        If Val(rs.Rows(0)!QTY.ToString) > 0 Then
          ListBox1.Items.Add(BIG2GB("PPID序號重複：") & rs.Rows(0)!QTY.ToString & BIG2GB("筆 從") & rs.Rows(0)!MVAL.ToString.Trim & BIG2GB("至") & rs.Rows(0)!XVAL.ToString.Trim)
          bolErr = True
        End If
      End If
    End If
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
    sqlCV.Where("TN02", "=", gd)
    sqlCV.SqlFields("TN01", , , , True)
    rs = DB.RsSQL(sqlCV.Text, "RT")
    Dim strBG As String = "", strED As String = ""
    For Each r As DataRow In rs.Rows
      Dim strM As String = r!TN01.ToString.Trim
      If (strM.Length <> SNBG.Text.Trim.Length Or strM < SNBG.Text.Trim Or strM > SNED.Text.Trim) And _
         (strM.Length <> IDBG.Text.Trim.Length Or strM < IDBG.Text.Trim Or strM > IDED.Text.Trim) Then
        bolWar = True
        If strBG = "" Then
          strBG = strM
          strED = strM
        Else
          strED = strM
        End If
      Else
        aryPE.Add(strM)
        If strBG <> "" Then
          ListBox1.Items.Add(BIG2GB("已存在的工單序號超出設定範圍：") & strBG & BIG2GB("至") & strED)
          aryLE.Add(strBG & "," & strED)
          strBG = ""
          strED = ""
        End If
      End If
    Next
    If strBG <> "" Then
      ListBox1.Items.Add(BIG2GB("已存在的工單序號超出設定範圍：") & strBG & BIG2GB("至") & strED)
      aryLE.Add(strBG & "," & strED)
      strBG = ""
      strED = ""
    End If
    If bolErr = False And bolWar = False Then
      ListBox1.Items.Add(BIG2GB("新增序號沒有錯誤"))
    Else
      ListBox1.Items.Add(BIG2GB("檢查結果有錯誤發生，可能無法正確執行"))
    End If
  End Sub

  Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
    CheckCode()
  End Sub

  Private Sub PRTBG_GotFocus(sender As Object, e As EventArgs) Handles PRTBG.GotFocus
    PRTBG.SelectionStart = 0
    PRTBG.SelectionLength = PRTBG.Text.Length
  End Sub

  Private Sub PRTBG_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PRTBG.KeyPress
    If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
      e.Handled = True
      My.Computer.Keyboard.SendKeys(vbTab)
    End If
  End Sub

  Private Sub PRTBG_Validated(sender As Object, e As EventArgs) Handles PRTBG.Validated
    If rbtzhu.Checked = True Then
      If SNED.Tag = "" Then Return
      If PRTBG.Text.Trim <> "" AndAlso sno1.isIDValid(PRTBG.Text.Trim) Then
        PQTY.Text = sno1.Diff(PRTBG.Text, SNED.Text).ToString("0") + 1
        If Val(PQTY.Text) < 1 Then
          PQTY.Text = 1
          PRTBG.Text = SNED.Text
        ElseIf Val(PQTY.Text) > intQTY Then
          PQTY.Text = intQTY
          PRTBG.Text = SNBG.Text
        End If
      Else
        PRTBG.Text = SNBG.Text
        PQTY.Text = intQTY
      End If
    Else
      If IDED.Tag = "" Then Return
      If PRTBG.Text.Trim <> "" AndAlso sno2.isIDValid(PRTBG.Text.Trim) Then
        PQTY.Text = sno2.Diff(PRTBG.Text, IDED.Text).ToString("0") + 1
        If Val(PQTY.Text) < 1 Then
          PQTY.Text = 1
          PRTBG.Text = IDED.Text
        ElseIf Val(PQTY.Text) > intQTY Then
          PQTY.Text = intQTY
          PRTBG.Text = IDBG.Text
        End If
      Else
        PRTBG.Text = IDBG.Text
        PQTY.Text = intQTY
      End If
    End If
  End Sub

  Private Sub Rbtfu_CheckedChanged(sender As Object, e As EventArgs) Handles Rbtfu.CheckedChanged
    If Rbtfu.Checked = True Then
      PRTBG.Text = IDBG.Text.Trim
      If PRTBG.Text = "" Then rbtzhu.Checked = True
    Else
      PRTBG.Text = SNBG.Text.Trim
      If PRTBG.Text = "" Then Rbtfu.Checked = True
    End If
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    If bolErr = True Then Return
    If bolWar = True Then
      If MsgBox(BIG2GB("部分序號超出設定範圍，如果刪除可能導致部分資料遺失" & vbCrLf & "是否需要刪除"), MsgBoxStyle.YesNo, BIG2GB("提示")) = MsgBoxResult.Yes Then
        For Each strK As String In aryLE
          Dim strV() As String = strK.Split(",")
          sqlCV.sqlMAKE(SQLCNV.intMode.mssql_delete, "SFIS_TN")
          sqlCV.Where("TN02", "=", gd)
          sqlCV.Where("TN01", ">=", strV(0))
          sqlCV.Where("TN01", "<=", strV(1))
          DB.RsSQL(sqlCV.Text)
        Next
      End If
    End If
    Dim intP As Integer = Val(PQTY.Text)
    Dim bolTN As Boolean = False
    If intP = 0 Then
      intP = intQTY
    Else
      bolTN = True
    End If
    PB.Minimum = 0
    PB.Maximum = intP * 2
    PB.Value = 0
    If SNED.Tag <> "" Then
      If PRTBG.Text <> "" Then sno1.BeginID = PRTBG.Text
      For intI As Integer = 0 To intP - 1
        Dim strM As String = sno1.GetID(intI)
        If aryPE.Contains(strM) = False Then
          sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_TN")
          sqlCV.SqlFields("TN01", strM)
          sqlCV.SqlFields("TN02", gd)
          sqlCV.SqlFields("TN06", 0)
          DB.RsSQL(sqlCV.Text)
          aryPE.Add(strM)
        End If
        If (intI Mod 10) = 0 Then
          PB.Value = intI
          PB.Refresh()
        End If
      Next
      PB.Value = intP
      PB.Refresh()
      sno1.BeginID = SNBG.Text
    End If
    If IDED.Tag <> "" Then
      If PRTBG.Text <> "" Then sno2.BeginID = PRTBG.Text
      For intI As Integer = 0 To intP - 1
        Dim strM As String = sno2.GetID(intI)
        If aryPE.Contains(strM) = False Then
          sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_TN")
          sqlCV.SqlFields("TN01", strM)
          sqlCV.SqlFields("TN02", gd)
          'sqlCV.SqlFields("TN03", firstgx)
          sqlCV.SqlFields("TN06", 0)
          DB.RsSQL(sqlCV.Text)
          aryPE.Add(strM)
        End If
        If (intI Mod 10) = 0 Then
          PB.Value = intI + intP
          PB.Refresh()
        End If
      Next
      sno2.BeginID = IDBG.Text
    End If
    PB.Value = PB.Maximum
    PB.Refresh()
  End Sub
  ''' <summary>
  ''' 讀取或設定標籤初始檔
  ''' </summary>
  ''' <param name="strK">標籤標題</param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function GetLBFmt(strK As String) As String
    Dim strV As String = "", sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", "#LBFX")
    sqlCV.Where("QTN02", "=", strK)
    sqlCV.SqlFields("QTN05")
    Dim rs As DataTable = db.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count = 0 Then
      Return ""
    Else
      If IsDBNull(rs.Rows(0)!QTN05) Then Return ""
      Dim bytV() As Byte = rs.Rows(0)!QTN05
      strV = System.Text.Encoding.UTF8.GetString(bytV)
      Return strV
    End If
  End Function

  ''' <summary>
  ''' 打印
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub Btnppidconfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnppidconfirm.Click
    Dim intQ As Integer = Val(PQTY.Text)
    Dim intCol As Integer = Val(TextBox1.Text)
    Dim intColCnt As Integer = 0
    If intCol < 1 Then intCol = 1
    TextBox1.Text = intCol
    If PRTBG.Text.Trim = "" Or intQ = 0 Then Return
    Dim selR1 As DataRowView = PTYPE.SelectedItem
    If selR1 Is Nothing Then
      MsgBox(BIG2GB("尚未選擇打印機型號"))
      Return
    End If
    Dim selR2 As DataRowView = LBFID.SelectedItem
    If selR2 Is Nothing Then
      MsgBox(BIG2GB("尚未選擇標籤格式或未設定標籤格式"))
      Return
    End If
    Dim strPrt As String = PRT.Text.Trim
    If strPrt = "" Or strPrt.ToUpper.Contains("NONE") Then
      strPrt = "D:\TEST.TXT"
    End If
    Dim strSrc As String = GetLBFmt(LBFID.SelectedValue.ToString.Trim)
    If strSrc.Trim = "" Then
      MsgBox(BIG2GB("尚未選擇列印格式"))
      Return
    End If
    Panel6.Enabled = False
    strPrt &= "," & selR1!QTN03.ToString.Trim
    clsLBT = New LABTRANx64.LabRunX64(strPrt, strSrc)
    My.Settings.TEMP = Val(TMP.Text)
    My.Settings.XOFF = Val(XOFF.Text)
    My.Settings.YOFF = Val(YOFF.Text)
    My.Settings.Save()
    clsLBT.Darkness = My.Settings.TEMP
    clsLBT.OffsetX = My.Settings.XOFF
    clsLBT.OffsetY = My.Settings.YOFF
    Dim strLast As String = ""
    Dim intCT As Integer = 0
    My.Settings.LABPRT = PRT.Text.Trim
    My.Settings.LABPTYPE = PTYPE.SelectedValue.ToString.Trim
    Dim intPR As Integer = 0, strMB As String = ""
    If rbtzhu.Checked Then
      If SNED.Tag = "" Then Return
      intPR = sno1.Diff(PRTBG.Text.Trim)
    Else
      If IDED.Tag = "" Then Return
      intPR = sno2.Diff(PRTBG.Text.Trim)
    End If
    Dim bolLab As Boolean = True
    For intI As Integer = 1 To intQ
      If rbtzhu.Checked Then
        If SNED.Tag = "" Then Return
        strMB = sno1.GetID(intI + intPR - 1)
      Else
        If IDED.Tag = "" Then Return
        strMB = sno2.GetID(intI + intPR - 1)
      End If
      If intColCnt = 0 Then
        For intH As Integer = 1 To intCol - 1
          aryTag("MBAR" & intH) = ""
          aryTag("BARTEXT" & intH) = ""
          aryTag("AUXLOT" & intH) = ""
        Next
        ' 列印標籤
        aryTag("MBAR") = strMB
        aryTag("BARTEXT") = strMB.Substring(0, 9)
        aryTag("AUXLOT") = strMB.Substring(9)
        intColCnt += 1
        If intColCnt >= intCol Then
          intColCnt = 0
        Else
          Continue For
        End If
      Else
        aryTag("MBAR" & intColCnt) = strMB
        aryTag("BARTEXT" & intColCnt) = strMB.Substring(0, 9)
        aryTag("AUXLOT" & intColCnt) = strMB.Substring(9)
        intColCnt += 1
        If intColCnt >= intCol Or intI >= intQ Then
          intColCnt = 0
        Else
          Continue For
        End If
      End If
      If bolLab Then
        clsLBT.OpenPrinter()
        bolLab = False
      End If
      Dim intTMS As Integer = 100
      While clsLBT.Ready = False And bolCancel = False And intTMS > 0
        System.Threading.Thread.Sleep(100)
        My.Application.DoEvents()
        intTMS -= 1
      End While
      If bolCancel Then
        bolCancel = False
        clsLBT.Cancel = True
        Exit For
      End If
      If clsLBT.Ready = False Then
        MsgBox(BIG2GB("印表機尚未就緒"))
        Exit For
      End If
      clsLBT.PrintLabel()
      intCT += 1
      If intCT >= 20 Then
        clsLBT.ClosePrinter()
        bolLab = True
        intCT = 0
      End If
    Next
    clsLBT.ClosePrinter()
    clsLBT = Nothing
    Panel6.Enabled = True
  End Sub

  Private Sub clsLBT_ErrorSet(sender As LABTRANx64.LabRunX64, obj As LabPrinter, strV As String) Handles clsLBT.ErrorSet
    MsgBox(BIG2GB(strV))
  End Sub

  Private Sub clsLBT_GetData(sender As LABTRANx64.LabRunX64, obj As LabPrinter, strFMT As String, ByRef strData As Object, intX As Integer, intY As Integer) Handles clsLBT.GetData
    strData = GetFmtName(strFMT)
    Debug.Print(strFMT & "," & strData)
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
        If aryTag.ContainsKey(strK) = True Then
          strOut &= aryTag(strK)
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

  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    Dim OFD As New OpenFileDialog    'EXCEL的序號導入
    OFD.Filter = BIG2GB("EXCEL檔案|*.XLS;*.XLSX")
    OFD.Multiselect = False
    If OFD.ShowDialog = Windows.Forms.DialogResult.Cancel Then Return
    Dim strPath As String = OFD.FileName
    Try
      Dim bolT As Boolean = False 'true表示有重覆資料不可存檔
      Dim aryT As New Dictionary(Of String, String)
      Dim app As New XLS_FILE(strPath)
      Dim rsA As DataTable = app.XLS2Rs(0)


      Dim aryT1 As New Dictionary(Of String, ArrayList)
      Dim aryT2 As New ArrayList
      For Each r As DataRow In rsA.Rows
        Dim strMo As String = r.Item(0).ToString
        Dim strSN As String = r.Item(1).ToString ' r.Cells(1).Value.ToString
        Dim strIMEI As String = r.Item(2).ToString
        Dim strKey As String = strSN & "," & strIMEI
        If strMo <> Label6.Text Then
          ListBox1.Items.Add(BIG2GB("工單格式不符。"))
        End If
        If aryT2.Contains(strKey) Then
          Continue For
        Else
          aryT2.Add(strKey)
          If aryT1.ContainsKey(strSN) = False Then aryT1.Add(strSN, New ArrayList)
          aryT1(strSN).Add(strIMEI)
        End If
      Next
      Dim rsB As New DataTable
      rsA.Columns.Add("SN")
      rsA.Columns.Add("IMEI-1")
      rsA.Columns.Add("IMEI-2")
      rsA.Columns.Add("IMEI-3")
      For Each s As String In aryT1.Keys
        Dim intC As Integer = aryT1(s).Count
        Select Case intC
          Case 1
            rsB.Rows.Add(s, aryT1(s)(0))
          Case 2
            rsB.Rows.Add(s, aryT1(s)(0), aryT1(s)(1))
          Case 3
            rsA.Rows.Add(s, aryT1(s)(0), aryT1(s)(1), aryT1(s)(2))
        End Select
      Next


      For Each r As DataRow In rsA.Rows
        If aryT.ContainsKey(r.Item(0)) = True Then
          bolT = True
          Exit For
        Else
          aryT.Add(r.Item(0), r.Item(1))
        End If
      Next
      If bolT Then
        ListBox1.Items.Add(Now.ToString("hh:mm:ss") & "," & BIG2GB("導入失敗,S/N資料不可重覆"))
        Return
      End If
      Dim strSQL As String = ""
      Dim sqlcv As New APSQL.SQLCNV
      For Each r As DataRow In rsA.Rows
        sqlcv.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_TS")
        sqlcv.SqlFields("TS01", r.Item(0).ToString)
        sqlcv.SqlFields("TS02", r.Item(1).ToString)
        sqlcv.SqlFields("TS03", MO.Text.Trim)
        strSQL &= sqlcv.Text & ";"
        If strSQL.Length > 5000 Then
          DB.RsSQL(strSQL)
          strSQL = ""
        End If
      Next
      If strSQL.Length > 0 Then
        DB.RsSQL(strSQL)
        strSQL = ""
      End If
      ListBox1.Items.Add(Now.ToString("hh:mm:ss") & BIG2GB("導入完成,"))
    Catch ex As Exception
      ListBox1.Items.Add(Now.ToString("hh:mm:ss") & BIG2GB("導入失敗,") & ex.Message)
    End Try
  End Sub

  Private Sub ImportExcel(rsA As DataTable)
    If rsA Is Nothing Then Return
    Dim strKeyMO As String = MO.Text.Trim
    Dim aryExc As New ArrayList
    Dim aryErr As New ArrayList
    For Each R As DataRow In rsA.Rows
      Dim strSN As String = R.Item(0).ToString
      Dim strIMEI As String = R.Item(1).ToString
      Dim strMO As String = R.Item(2).ToString
      Dim strKey As String = strSN & "," & strIMEI
      If strMO <> strKeyMO Then
        ListBox1.Items.Add(BIG2GB("工單號碼不一致，" & strMO))
        aryErr.Add(R.ItemArray)
        Continue For
      End If
      If aryExc.Contains(strKey) Then
        ListBox1.Items.Add(BIG2GB("加入相同索引"))
        aryErr.Add(R.ItemArray)
        Continue For
      End If
    Next
    Dim aryT1 As New Dictionary(Of String, ArrayList)
    Dim aryT2 As New ArrayList
    For Each r As DataRow In rsA.Rows
      Dim strMo As String = r.Item(3).ToString
      Dim strSN As String = r.Item(1).ToString ' r.Cells(1).Value.ToString
      Dim strIMEI As String = r.Item(2).ToString ' r.Cells(2).Value.ToString
      Dim strKey As String = strSN & "," & strIMEI
      If MO.Text <> strMo Then
        ListBox1.Items.Add(BIG2GB("工單號碼錯誤，" & strMo.ToString))
        Continue For
      End If
      If aryT2.Contains(strKey) Then
        ListBox1.Items.Add(BIG2GB("加入重覆索引值，S/N：" & strSN & ", IMEI條碼：" & strIMEI))
        Continue For
      Else
        aryT2.Add(strKey)
        If aryT1.ContainsKey(strSN) = False Then aryT1.Add(strSN, New ArrayList)
        aryT1(strSN).Add(strIMEI)
      End If
    Next
    Dim rsB As New DataTable
    rsB.Columns.Add("SN")
    rsB.Columns.Add("IMEI-1")
    rsB.Columns.Add("IMEI-2")
    rsB.Columns.Add("IMEI-3")
    For Each s As String In aryT1.Keys
      Dim intC As Integer = aryT1(s).Count
      Select Case intC
        Case 1
          rsB.Rows.Add(s, aryT1(s)(0))
        Case 2
          rsB.Rows.Add(s, aryT1(s)(0), aryT1(s)(1))
        Case 3
          rsB.Rows.Add(s, aryT1(s)(0), aryT1(s)(1), aryT1(s)(2))
      End Select
    Next
    Dim sqlcv As New APSQL.SQLCNV
    For Each R As DataRow In rsB.Rows
      'sqlcv.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_TN")
      'sqlcv.Where("TN02", "=", MO.Text)
      'sqlcv.Where("TN01", "=", R.Item(0).ToString)

    Next
  End Sub
  Private Sub LBFID_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles LBFID.SelectionChangeCommitted
    Dim r As DataRowView = LBFID.SelectedItem
    If r Is Nothing Then Return
    Dim bytV() As Byte = r!QTN05
    Dim fm As New IO.MemoryStream
    fm.Write(bytV, 0, bytV.Length)
    Panel4.BackgroundImage = New Bitmap(fm)
    fm.Close()
    fm.Dispose()
  End Sub

  Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
    Me.Close()
  End Sub

  Private Sub Panel4_Click(sender As Object, e As EventArgs) Handles Panel4.Click
    bolCancel = True
  End Sub
End Class