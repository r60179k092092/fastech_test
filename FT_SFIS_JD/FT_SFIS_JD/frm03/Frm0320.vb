Public Class Frm0320
  Private aryTK As New Dictionary(Of String, String)
#If SAP <> 0 Then
  Private SapL As New SAPFunc.SapFunc(New SAPFunc.SAPLink)
#End If
  Private rLog As DataTable = Nothing
  Private WithEvents clsLBT As LABTRANx64.LabRunX64 = Nothing
  Private aryST As New Dictionary(Of String, String)
  Private rsLOG As DataTable = Nothing
  Private bolCancel As Boolean = False
  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()
    languagechange(Me)
    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

  End Sub

  Private Sub Frm0320_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    If clsLBT IsNot Nothing Then
      clsLBT.ClosePrinter()
      clsLBT = Nothing
    End If
    TuiCK(Me)
  End Sub
  Private Function GetLot(Optional strI As String = "", Optional strD As String = "") As String
    If strI = "" Then strI = ITNO.Text.Trim
    If strD = "" Then
      strD = MDATE.Value.ToString("yyyyMMdd")
    Else
      strD = CDate(strD).ToString("yyyyMMdd")
    End If
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TE")
    sqlCV.Where("TE01", "=", strI)
    sqlCV.Where("TE02", "Like", strI & "$" & strD & "%")
    sqlCV.SqlFields("TE02")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count = 0 Then
      Return strD & "001"
    Else
      Dim strL As String = rs.Rows(0)!TE02.ToString.Trim
      Dim intI As Integer = Val(strL.Substring(strL.Length - 3)) + 1
      Return strD & intI.ToString("000")
    End If
  End Function

  Private Sub Frm0320_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", "#LABELS")
    sqlCV.Where("QTN04", "=", "INV")
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
    For Each strV As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
      PRT.Items.Add(strV)
    Next
    PRT.SelectedIndex = 0
    rLog = New DataTable
    rLog.TableName = "PrintDL"
    rLog.Columns.Add(BIG2GB("補印"), GetType(Boolean))
    rLog.Columns.Add(BIG2GB("單據編號"), GetType(String))
    rLog.Columns.Add(BIG2GB("物料編號"), GetType(String))
    rLog.Columns.Add(BIG2GB("品名"), GetType(String))
    rLog.Columns.Add(BIG2GB("規格型號"), GetType(String))
    rLog.Columns.Add(BIG2GB("入庫數量"), GetType(String)) '5
    rLog.Columns.Add(BIG2GB("入庫日期"), GetType(String))
    rLog.Columns.Add(BIG2GB("入庫批次"), GetType(String))
    rLog.Columns.Add(BIG2GB("包裝數量"), GetType(String))
    rLog.Columns.Add(BIG2GB("打印張數"), GetType(String))
    rLog.Columns.Add(BIG2GB("單位"), GetType(String)) '10
    rLog.Columns.Add(BIG2GB("供應商"), GetType(String))
    rLog.Columns.Add(BIG2GB("採購單號"), GetType(String))
    rLog.Columns.Add(BIG2GB("原廠料號"), GetType(String))
    rLog.Columns.Add(BIG2GB("備註"), GetType(String))
    rLog.Columns.Add(BIG2GB("包裝型態"), GetType(String)) '14
    DG.DataSource = rLog
    For intI As Integer = 0 To DG.ColumnCount - 1
      If intI = 0 Or intI = 9 Then
        DG.Columns(intI).ReadOnly = False
      Else
        DG.Columns(intI).ReadOnly = True
      End If
    Next
    TMP.Text = My.Settings.TEMP
    XOFF.Text = My.Settings.XOFF
    YOFF.Text = My.Settings.YOFF
  End Sub

  Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
    Me.Close()
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    Dim strO As String = PKG.Text.Trim
    If TKID.Text.Trim = "" Then Return
    Dim TKIDS As String = TKID.Text.Trim & "-" & Val(TKSID.Text.Trim.Split(" ")(0)).ToString("000")
    If sender IsNot Nothing Then PKG_LostFocus(Nothing, Nothing)
    Dim strP() As String = PKG.Text.Trim.Split(",")
    Dim aryL As New ArrayList
    For Each r As DataRow In rLog.Rows
      If r.Item(1).ToString.Trim = TKIDS Then
        aryL.Add(r)
      End If
    Next
    For Each r As DataRow In aryL
      rLog.Rows.Remove(r)
    Next
    For Each strK As String In strP
      Dim strM() As String = (strK & "*1").Split("*")
      If strM.Length >= 2 Then
        rLog.Rows.Add(False, TKIDS, ITNO.Text.ToString.Trim, ITNA.Text.Trim, _
                      SPEC.Text.Trim, QTY.Text, MDATE.Value.ToString("yyyy\/MM\/dd"), LOT.Text.Trim, _
                      strM(0), strM(1), UNIT.Text.Trim, SUP.Text.Trim, _
                      SUPITNO.Text.Trim, RMK.Text.Trim, PKG.Text.Trim)
      End If
    Next
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    If rLog.Rows.Count > 0 Then
      rLog.Rows.Clear()
    Else
      TKID.Text = ""
      TKSID.Text = ""
      TKSID.DataSource = Nothing
      ITNO.Text = ""
      ITNA.Text = ""
      SPEC.Text = ""
      QTY.Text = ""
      LOT.Text = ""
      UNIT.Text = ""
      SUP.Text = ""
      SUPITNO.Text = ""
      RMK.Text = ""
      PKG.Text = ""
    End If
  End Sub

  Private Sub PKG_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PKG.KeyPress
    If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
      e.Handled = True
      My.Computer.Keyboard.SendKeys(vbTab)
    End If
  End Sub

  Private Sub PKG_LostFocus(sender As Object, e As EventArgs) Handles PKG.LostFocus
    If CheckBox1.Checked = False Then
      If PKG.Text = "" Then PKG.Text = QTY.Text & "*1"
      Return
    End If
    'If PKG.Text.Trim = "" Then Return
    Dim strP() As String = PKG.Text.Trim.Split(",")
    Dim intQ As Integer = Val(QTY.Text), intG As Integer = 0
    If strP.Length = 1 Then
      Dim strM() As String = strP(0).Split("*")
      Dim intP As Integer = Val(strM(0))
      If strM.Length = 1 Then
        If intP = 0 Or intP > intQ Then
          PKG.Text = intQ.ToString("0") & "*1"
        Else
          PKG.Text = intP.ToString("0") & "*" & (intQ \ intP).ToString("0")
          If (intQ Mod intP) > 0 Then
            PKG.Text &= "," & (intQ Mod intP).ToString("0") & "*1"
          End If
        End If
      Else
        Dim intB As Integer = Val(strM(1))
        If intP * intB > intQ Then
          PKG.Text = intP.ToString("0") & "*" & (intQ \ intP).ToString("0")
          If (intQ Mod intP) = 0 Then
            PKG.Text &= "," & (intQ Mod intP).ToString("0") & "*1"
          End If
        Else
          PKG.Text = intP.ToString("0") & "*" & intB.ToString("0")
          If intQ > intP * intB Then
            PKG.Text &= "," & (intQ - intP * intB).ToString("0") & "*1"
          End If
        End If
      End If
      If sender IsNot Nothing Then Button1_Click(Nothing, Nothing)
      Return
    End If
    PKG.Text = ""
    Dim intF As Integer = intQ
    For Each strK As String In strP
      If strK.Trim = "" Then Continue For
      If intF = 0 Then Continue For
      Dim strM() As String = strK.Split("*")
      Dim intP As Integer = Val(strM(0))
      If intP = 0 Then Continue For
      If strM.Length = 1 Then
        If intF > intP Then
          PKG.Text &= intP.ToString("0") & "*1,"
          intF -= intP
        Else
          PKG.Text &= intF.ToString("0") & "*1"
          intF = 0
        End If
      Else
        Dim intB As Integer = Val(strM(1))
        If intF > intP * intB Then
          PKG.Text &= intP.ToString("0") & "*" & intB & ","
          intF -= intP * intB
        Else
          If intP > intF Then
            PKG.Text &= intF & "*1,"
            intF = 0
          Else
            PKG.Text &= intP.ToString("0") & "*" & (intF \ intP).ToString("0") & ","
            intF = intF Mod intP
          End If
        End If
      End If
    Next
    If intF > 0 Then
      PKG.Text &= intF.ToString("0") & "*1"
    End If
    PKG.Text = PKG.Text.Trim(",")
    If sender IsNot Nothing Then Button1_Click(Nothing, Nothing)
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

  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
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
    Panel2.Enabled = False
    Panel5.Enabled = False
    strPrt &= "," & selR1!QTN03.ToString.Trim
    clsLBT = New LABTRANx64.LabRunX64(strPrt, strSrc)
    My.Settings.TEMP = Val(TMP.Text)
    My.Settings.XOFF = Val(XOFF.Text)
    My.Settings.YOFF = Val(YOFF.Text)
    My.Settings.Save()
    clsLBT.Darkness = My.Settings.TEMP
    clsLBT.OffsetX = My.Settings.XOFF
    clsLBT.OffsetY = My.Settings.YOFF
    Dim bolLab As Boolean = True
    Dim sqlCV As New APSQL.SQLCNV
    Dim strLast As String = ""
    Dim intCT As Integer = 0
    My.Settings.LABPRT = PRT.Text.Trim
    My.Settings.LABPTYPE = PTYPE.SelectedValue.ToString.Trim
    Dim aryENT As New ArrayList
    Dim aryLOTS As New Dictionary(Of String, String)
    Dim aryLists As New ArrayList

    For Each r As DataGridViewRow In DG.Rows
      Dim strMM() As String = GCell(r.Cells(11)).Split(" ")
      Dim strLot As String = GCell(r.Cells(7))
      Dim strK1 As String = GCell(r.Cells(2)) & vbTab & strLot & vbTab & strMM(0)
      If aryLists.Contains(strK1) = False Then
        aryLists.Add(strK1)
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TE")
        sqlCV.Where("TE01", "=", GCell(r.Cells(2)))
        sqlCV.Where("TE02", "=", GCell(r.Cells(2)) & "$" & strLot)
        sqlCV.Where("TE03", "=", "00001")
        sqlCV.SqlFields("*")
        Dim rs1 As DataTable = DB.RsSQL(sqlCV.Text, "RTE")
        If rs1.Rows.Count > 0 Then
          For Each r1 As DataRow In rs1.Rows
            If r1!TE21.ToString.Trim <> strMM(0) Then
              MsgBox(BIG2GB("同批號存在二個不同供應商，將會無法分辨" & strMM(0) & "," & r1!TE21.ToString.Trim & " 以新供應商存檔"))
              sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_TE")
              sqlCV.Where("TE01", "=", GCell(r.Cells(2)))
              sqlCV.Where("TE02", "=", GCell(r.Cells(2)) & "$" & strLot)
              sqlCV.Where("TE03", "=", "00001")
              sqlCV.SqlFields("TE14", strMM(1))
              sqlCV.SqlFields("TE21", strMM(0))
              DB.RsSQL(sqlCV.Text)
              Exit For
            End If
          Next
        Else
          sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_TE")
          sqlCV.SqlFields("TE01", GCell(r.Cells(2)))
          sqlCV.SqlFields("TE02", GCell(r.Cells(2)) & "$" & strLot)
          sqlCV.SqlFields("TE03", "00001")
          sqlCV.SqlFields("TE04", GCell(r.Cells(5)), intFMode.msfld_num)
          sqlCV.SqlFields("TE05", 0, intFMode.msfld_num)
          sqlCV.SqlFields("TE06", 0, intFMode.msfld_num)
          sqlCV.SqlFields("TE07", GCell(r.Cells(5)), intFMode.msfld_num)
          sqlCV.SqlFields("TE08", 1, intFMode.msfld_num)
          sqlCV.SqlFields("TE09", 1, intFMode.msfld_num)
          sqlCV.SqlFields("TE10", GCell(r.Cells(12)))
          sqlCV.SqlFields("TE12", GCell(r.Cells(1)))
          sqlCV.SqlFields("TE14", strMM(1))
          sqlCV.SqlFields("TE16", GCell(r.Cells(6)))
          sqlCV.SqlFields("TE21", strMM(0))
          sqlCV.SqlFields("TE22", Now, intFMode.msfld_datetime)
          sqlCV.SqlFields("TE23", GCell(r.Cells(13)))
          DB.RsSQL(sqlCV.Text)
        End If
      End If
      r.Cells(0).Value = True
      aryST.Clear()
      aryST.Add("PN", GCell(r.Cells(2)))
      aryST.Add("PNAME", GCell(r.Cells(3)))
      aryST.Add("MODEL", GCell(r.Cells(4)))
      aryST.Add("DATE/10", GCell(r.Cells(6)))
      r.Cells(7).Value = strLot
      aryST.Add("LOT", strLot)
      aryST.Add("QTY", GCell(r.Cells(8)))
      aryST.Add("UNIT", GCell(r.Cells(10)))
      aryST.Add("MBAR", GCell(r.Cells(2)) & "|" & GCell(r.Cells(7)) & "|" & strMM(0))
      aryST.Add("VEND", strMM(1))
      aryST.Add("VNDNO", strMM(0))
      aryST.Add("ORDNO", GCell(r.Cells(12)))
      aryST.Add("RMK", GCell(r.Cells(13)))
      aryST.Add("TICKET", GCell(r.Cells(1)))
      aryST.Add("FD00", GCell(r.Cells(9)))
      Dim intTMS As Integer = 100
      If bolLab = True Then
        clsLBT.OpenPrinter()
        bolLab = False
      End If
      ' 列印標籤
      While clsLBT.Ready = False And bolCancel = False And intTMS > 0
        System.Threading.Thread.Sleep(100)
        My.Application.DoEvents()
        intTMS -= 1
      End While
      If bolCancel Then
        bolCancel = False
        clsLBT.Cancel = True
        bolLab = False
        Exit For
      End If
      If clsLBT.Ready = False Then
        MsgBox(BIG2GB("印表機尚未就緒"))
        Exit For
      End If
      clsLBT.PrintLabel()
      intCT += Val(GCell(r.Cells(9)))
      If intCT >= 20 Then
        clsLBT.ClosePrinter()
        bolLab = True
        intCT = 0
      End If
    Next
    clsLBT.ClosePrinter()
    clsLBT = Nothing
    Panel2.Enabled = True
    Panel5.Enabled = True
    DG.CommitEdit(DataGridViewDataErrorContexts.Commit)
    DG.Refresh()
    If DG.Rows.Count > 0 Then
      DG.CurrentCell = DG.Rows(0).Cells(1)
    End If
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
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
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
  ''' 根據物料類別取得存儲週期。
  ''' </summary>
  ''' <param name="strNa">物料類別</param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Private Function GetStorageCycle(strNa As String) As String
    Dim sqlcv As New APSQL.SQLCNV
    sqlcv.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlcv.Where("QTN01", "=", "PERIOD")
    sqlcv.Where("QTN02", "=", strNa)
    sqlcv.SqlFields("QTN03")
    Dim rsA As DataTable = DB.RsSQL(sqlcv.Text, "PID")
    If rsA.Rows.Count > 0 Then
      Return rsA.Rows(0)!QTN03.ToString
    Else
      Return "6"
    End If
  End Function
  'Private Function PushLot(strI As String, strD As String) As String
  '  Dim sqlCV As New APSQL.SQLCNV
  '  Dim strL As String = GetLot(strI, strD)
  '  sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_QTN")
  '  sqlCV.Where("QTN01", "=", "#L0320")
  '  sqlCV.Where("QTN02", "=", strL.Substring(0, 8) & "_" & strI)
  '  sqlCV.SqlFields("QTN03", strL.Substring(8))
  '  Dim intL As Integer = DB.RsSQL(sqlCV.Text)
  '  If intL = 0 Then
  '    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_QTN")
  '    sqlCV.SqlFields("QTN01", "#L0320")
  '    sqlCV.SqlFields("QTN02", strL.Substring(0, 8) & "_" & strI)
  '    sqlCV.SqlFields("QTN03", strL.Substring(8))
  '    DB.RsSQL(sqlCV.Text)
  '  End If
  '  sqlCV.sqlMAKE(SQLCNV.intMode.mssql_delete, "SFIS_QTN")
  '  sqlCV.Where("QTN01", "=", "#L0320")
  '  sqlCV.Where("QTN02", "<", Now.AddYears(-1).ToString("yyyyMMdd"))
  '  DB.RsSQL(sqlCV.Text)
  '  Return strL
  'End Function
  Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
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
    Dim bolLab As Boolean = True
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
    Panel2.Enabled = False
    Panel5.Enabled = False
    For Each r As DataGridViewRow In DG.Rows
      If r.Cells(0).Value = False Then Continue For
      aryST.Clear()
      Dim strMM() As String = GCell(r.Cells(11)).Split(" ")
      aryST.Add("PN", GCell(r.Cells(2)))
      aryST.Add("PNAME", GCell(r.Cells(3)))
      aryST.Add("MODEL", GCell(r.Cells(4)))
      aryST.Add("DATE/10", GCell(r.Cells(6)))
      aryST.Add("LOT", GCell(r.Cells(7)))
      aryST.Add("QTY", GCell(r.Cells(8)))
      aryST.Add("UNIT", GCell(r.Cells(10)))
      aryST.Add("MBAR", GCell(r.Cells(2)) & "|" & GCell(r.Cells(7)) & "|" & strMM(0))
      aryST.Add("VEND", strMM(1))
      aryST.Add("VNDNO", strMM(0))
      aryST.Add("ORDNO", GCell(r.Cells(12)))
      aryST.Add("RMK", GCell(r.Cells(13)))
      aryST.Add("TICKET", GCell(r.Cells(1)))
      aryST.Add("FD00", GCell(r.Cells(9)))
      Dim intTMS As Integer = 100
      If bolLab Then
        clsLBT.OpenPrinter()
        bolLab = False
      End If
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
      intCT += Val(GCell(r.Cells(9)))
      If intCT >= 20 Then
        clsLBT.ClosePrinter()
        bolLab = True
        intCT = 0
      End If
    Next
    clsLBT.ClosePrinter()
    clsLBT = Nothing
    Panel2.Enabled = True
    Panel5.Enabled = True
  End Sub

  Private Sub clsLBT_ErrorSet(sender As LABTRANx64.LabRunX64, obj As LabPrinter, strV As String) Handles clsLBT.ErrorSet
    MsgBox(BIG2GB(strV))
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

  Private Sub Panel4_DoubleClick(sender As Object, e As EventArgs) Handles Panel4.DoubleClick
    bolCancel = True
  End Sub

  Private Sub DG_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DG.CellEndEdit
    If e.ColumnIndex = 0 And e.RowIndex >= 0 And e.RowIndex < DG.Rows.Count Then
      If GCell(DG.Rows(e.RowIndex).Cells(12)) = "" Then
        DG.Rows(e.RowIndex).Cells(0).Value = False
      End If
    End If
  End Sub

  Private Sub LOT_GotFocus(sender As Object, e As EventArgs) Handles LOT.GotFocus
    LOT.SelectionStart = 0
    LOT.SelectionLength = LOT.Text.Length
  End Sub

  Private Sub TKID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TKID.KeyPress, _
    TKSID.KeyPress, LOT.KeyPress, PKG.KeyPress
    If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
      e.Handled = True
      My.Computer.Keyboard.SendKeys(vbTab)
    End If
  End Sub
  Private Function LoadTKID(strT As String, strS As String) As DataTable
    If DBERP Is Nothing OrElse DBERP.Active = False Then
      Return Nothing
    End If
    If strT.Trim = "" Then Return Nothing
    Dim sqlCV As New APSQL.SQLCNV
#If K3 = 1 Then

#ElseIf K3 = 2 Then
#ElseIf K3 = 3 Then
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "TF_PSS")
    Dim w As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "MF_PSS", "PS_NO", "=", "^0.PS_NO")
    w.Add("MF_PSS.PS_ID", "=", "TF_PSS.PS_ID")
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "CUST", "CUS_NO", "=", "^1.CUS_NO")
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "PRDT", "PRD_NO", "=", "^0.PRD_NO")
    sqlCV.Where("^0.PS_NO", "=", TKID.Text.Trim)
    sqlCV.Where("^0.ITM", "=", strTKSID, intFMode.msfld_num)
    sqlCV.SqlFields("^0.OS_NO", "ORDNO")
    sqlCV.SqlFields("^0.PRD_NO", "ITNO")
    sqlCV.SqlFields("^0.PRD_NAME", "ITNA")
    sqlCV.SqlFields("^0.SPC", "SPEC")
    sqlCV.SqlFields("^0.UNIT", "UNIT")
    sqlCV.SqlFields("^0.QTY", "QTY")
    sqlCV.SqlFields("^1.CUS_NO", "SUP")
    sqlCV.SqlFields("^1.PS_DD", "DATEV")
    sqlCV.SqlFields("^2.NAME", "SUPNA")
    sqlCV.SqlFields("^3.UT", "SUNIT")
    sqlCV.SqlFields("^3.UT1", "SUNIT1")
#End If
    Dim rs As DataTable = DBERP.RsSQL(BIG2GB(sqlCV.Text), "RT")
    If rs.Rows.Count = 0 Then
      MsgBox(BIG2GB("無此單據號碼"))
      Return Nothing
    End If
    Return rs
  End Function

  Private Sub TKID_LostFocus(sender As Object, e As EventArgs) Handles TKID.LostFocus
    If TKID.Text.Trim.Contains(" ") = True Then
      Dim strV() As String = TKID.Text.Trim.Split(" ")
      TKID.Text = strV(0)
      If strV.Length = 3 Then
        TKSID_GotFocus(Nothing, Nothing)
        TKSID.SelectedValue = Val(strV(1))
        TKSID_LostFocus(Nothing, Nothing)
      End If
    End If
  End Sub

  Private Sub TKSID_LostFocus(sender As Object, e As EventArgs) Handles TKSID.LostFocus
    Dim strTKSID As Integer = 0
    strTKSID = Val(TKSID.Text.Trim.Split(" ")(0)).ToString("0")
    If TKID.Text.Trim = "" Then
      Return
    End If
    Dim rs As DataTable = LoadTKID(TKID.Text.Trim, strTKSID)
    If rs Is Nothing OrElse rs.Rows.Count = 0 Then Return
    SUP.Text = rs.Rows(0)!SUP.ToString.Trim & " " & rs.Rows(0)!SUPNA.ToString.Trim
    ITNO.Text = rs.Rows(0)!ITNO.ToString.Trim
    ITNA.Text = rs.Rows(0)!ITNA.ToString.Trim
    SPEC.Text = rs.Rows(0)!SPEC.ToString.Trim
    Dim intUnit As Integer = Val(rs.Rows(0)!UNIT.ToString)
    If intUnit = 1 Then
      UNIT.Text = rs.Rows(0)!SUNIT.ToString.Trim
    ElseIf intUnit > 1 Then
      UNIT.Text = rs.Rows(0)!SUNIT1.ToString.Trim
    Else
      UNIT.Text = rs.Rows(0)!UNIT.ToString.Trim
    End If
    QTY.Text = Val(rs.Rows(0)!QTY.ToString.Trim).ToString("0")
    SUPITNO.Text = rs.Rows(0)!ORDNO.ToString.Trim
    MDATE.Value = Now.Date
    If IsDate(rs.Rows(0)!DATEV.ToString.Trim) Then
      MDATE.Value = CDate(rs.Rows(0)!DATEV.ToString.Trim).Date
    End If
    PKG.Text = ""
    Dim TKIDS As String = TKID.Text.Trim & "-" & Val(TKSID.Text.Trim.Split(" ")(0)).ToString("000")
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TE")
    sqlCV.Where("TE01", "=", ITNO.Text.Trim)
    sqlCV.Where("TE12", "=", TKIDS)
    sqlCV.SqlFields("TE02")
    sqlCV.SqlFields("TE16")
    sqlCV.SqlFields("TE23")
    rs = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count > 0 Then
      LOT.Text = rs.Rows(0)!TE02.ToString.Trim.Split("$")(1)
      If IsDate(rs.Rows(0)!TE16.ToString) Then
        MDATE.Value = CDate(rs.Rows(0)!TE16.ToString)
      End If
      RMK.Text = rs.Rows(0)!TE23.ToString.Trim
    Else
      LOT.Text = GetLot()
      RMK.Text = ""
    End If
  End Sub
  Private Function GetSID(strT As String) As DataTable
    If DBERP Is Nothing OrElse DBERP.Active = False Then Return Nothing
    If strT = "" Then Return Nothing
    Dim sqlCV As New APSQL.SQLCNV
#If K3 = 1 Then
#ElseIf K3 = 2 Then
#ElseIf K3 = 3 Then
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "TF_PSS")
    sqlCV.Where("^0.PS_NO", "=",strt)
    sqlCV.SqlFields("^0.ITM", "KEYS")
    sqlCV.SqlFields("Convert(Varchar(3),^0.ITM) + ' '+^0.PRD_NO+ ' '+^0.PRD_NAME", "DATAS")
#End If
    Dim rs As DataTable = DBERP.RsSQL(sqlCV.Text, "THR")
    TKSID.DisplayMember = "DATAS"
    TKSID.ValueMember = "KEYS"
    TKSID.DataSource = rs
    Return rs
  End Function
  Private Sub TKSID_GotFocus(sender As Object, e As EventArgs) Handles TKSID.GotFocus
    If TKID.Text.Trim = "" Then
      TKID.Focus()
      Return
    End If
    Dim strK As String = TKSID.Text.ToString.Trim.Split(" ")(0)
    GetSID(TKID.Text.Trim)
    TKSID.SelectedValue = Val(strK)
    If TKSID.SelectedValue Is Nothing And TKSID.Items.Count > 0 Then
      TKSID.SelectedIndex = 0
      My.Computer.Keyboard.SendKeys(vbTab)
    End If
    TKSID.SelectionStart = 0
    TKSID.SelectionLength = 0
  End Sub

  Private Sub TKSID_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles TKSID.SelectionChangeCommitted
    My.Computer.Keyboard.SendKeys(vbTab)
  End Sub

  Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
    Button6.Enabled = False
    Panel4.Visible = False
    Panel6.Visible = True
    TextBox1.Text = ""
    TextBox2.Text = ""
    Label17.Text = ""
    Label19.Text = ""
    TextBox1.Focus()
    rsLOG = Nothing
  End Sub
  Private Function ToSubPack() As ArrayList
    Dim aryL As New ArrayList
    Dim strV() As String = TextBox2.Text.Trim.Split(",")
    For Each strK As String In strV
      If strK.Trim = "" Then Continue For
      If strK.Contains("*") = False Then
        If Val(strK) = 0 Then Continue For
        aryL.Add(strK & "*1")
      Else
        If Val(strK) = 0 Or Val(strK.Split("*")(1)) = 0 Then Continue For
        aryL.Add(strK)
      End If
    Next
    Return aryL
  End Function
  Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
    If rsLOG IsNot Nothing AndAlso rsLOG.Rows.Count > 0 Then
      Dim sngV1 As Double = 0
      Dim aryLL As ArrayList = ToSubPack()
      For Each strK As String In aryLL
        Dim strV2() As String = strK.Split("*")
        sngV1 += Val(strV2(0)) * Val(strV2(1))
      Next
      If Val(sngV1.ToString("0.000")) <> Val(Label17.Text) Then
        If MsgBox(BIG2GB("標籤數量不等於分包 " & TextBox2.Text.Trim & _
           "=" & sngV1.ToString("0.000").TrimEnd("0").TrimEnd(".") & " 但仍可繼續" & vbCrLf & "請確定這是正確的"), MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, BIG2GB("補印分包標籤")) = MsgBoxResult.No Then Return
      End If
      Dim r As DataRow = rsLOG.Rows(0)
      Dim strLL() As String = r!TE02.ToString.Trim.Split("$")
      If strLL.Length >= 2 Then strLL(0) = strLL(1)
      For Each strK As String In aryLL
        Dim strV2() As String = strK.Split("*")
        rLog.Rows.Add(True, r!TE12.ToString.Trim, r!TE01.ToString.Trim, r!TBB05.ToString.Trim, _
                      r!TBB06.ToString.Trim, r!TE04.ToString.Trim, r!TE16.ToString.Trim, _
                      strLL(0), Val(strV2(0)), Val(strV2(1)), r!TBB07.ToString.Trim, _
                      r!TE21.ToString.Trim & " " & r!TE14.ToString.Trim, r!TE10.ToString.Trim, _
                      r!TE23.ToString.Trim, "")
      Next
    End If
    Button6.Enabled = True
    Panel4.Visible = True
    Panel6.Visible = False
  End Sub

  Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
    Button6.Enabled = True
    Panel4.Visible = True
    Panel6.Visible = False
  End Sub

  Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress, TextBox2.KeyPress
    If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
      e.Handled = False
      My.Computer.Keyboard.SendKeys(vbTab)
    End If
  End Sub

  Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles TextBox1.LostFocus
    TextBox1.Text = TextBox1.Text.Trim.ToUpper
    Dim strM() As String = TextBox1.Text.Trim.ToUpper.Split("|")
    Dim strI As String = "", strD As String = "", strR As String = "", strV As String = ""
    Select Case strM.Length
      Case 3
        strI = strM(0)
        strD = strM(1)
        strR = "00001"
        Label17.Text = Val(strM(2))
      Case 4
        strI = strM(0)
        strD = strM(1)
        strV = strM(2)
        strR = "00001"
        Label17.Text = Val(strM(3))
      Case 5, 6, 7, 8, 9
        strI = strM(0)
        strD = strM(1)
        strV = strM(2)
        strR = strM(3)
        Label17.Text = Val(strM(4))
        If strR.Trim = "" Then strR = "00001"
    End Select
    TextBox2.Text = Label17.Text
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TE")
    sqlCV.Where("TE01", "=", strI)
    sqlCV.Where("TE02", "=", strI & "$" & strD)
    sqlCV.Where("TE03", "=", strR)
    If strV.Trim <> "" Then sqlCV.Where("TE21", "=", strV)
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "SFIS_TBB", "TBB03", "=", "^0.TE01")
    sqlCV.SqlFields("^0.*")
    sqlCV.SqlFields("^1.TBB05")
    sqlCV.SqlFields("^1.TBB06")
    sqlCV.SqlFields("^1.TBB07")
    rsLOG = DB.RsSQL(sqlCV.Text, "RTE1")
    If rsLOG.Rows.Count = 0 Then
      Label19.Text = "找不到這張標籤紀錄"
      Return
    Else
      Label19.Text = rsLOG.Rows(0)!TBB05.ToString.Trim
    End If
  End Sub

  Private Sub TKID_TextChanged(sender As Object, e As EventArgs) Handles TKID.TextChanged

  End Sub
End Class