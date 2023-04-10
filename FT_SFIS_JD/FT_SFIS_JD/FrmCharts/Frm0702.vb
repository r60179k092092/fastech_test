Public Class Frm0702
  Private WithEvents clsE As clsEDITx2013
  Private aryCH As New Dictionary(Of String, String)
  Private bolLockChk As Boolean = False
  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()
    languagechange(Me)
    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

  End Sub

  Private Sub Frm0702_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    TuiCK(Me)
  End Sub

  Private Sub Frm0702_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    clsE = New clsEDIT2012.clsEDITx2013(DG, DB, language)
    Me.KeyPreview = True
    clsE.Clean()
    '-------------------------------------------------------------
    '自動定位到這一個編輯清單，讓操作者更方便運作數據
    clsE.GetToolsItem("Delete").Enabled = clsRTS.GetRight(Me.Tag & "/003")
    clsE.GetToolsItem("save").Enabled = clsRTS.GetRight(Me.Tag & "/001")
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", "LINE")
    sqlCV.SqlFields("QTN02", , , , True)
    sqlCV.SqlFields("QTN02 + ' ' + QTN03", "DATAS")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RTJ03")
    Dim r As DataRow = rs.NewRow
    r.Item(0) = "any"
    r.Item(1) = BIG2GB("any 全部線別")
    rs.Rows.InsertAt(r, 0)
    LINEID.Items.Clear()
    For Each r In rs.Rows
      LINEID.Items.Add(r!DATAS.ToString.Trim)
    Next
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TD")
    sqlCV.Where("TD12", "IN", "0,1", intFMode.msfld_field)
    sqlCV.SqlFields("TD01", , , , True)
    rs = DB.RsSQL(sqlCV.Text, "RTDS")
    r = rs.NewRow
    r.Item(0) = "any"
    rs.Rows.InsertAt(r, 0)
    MOID.Items.Clear()
    For Each r In rs.Rows
      MOID.Items.Add(r!TD01.ToString.Trim)
    Next
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_distinc, "SFIS_TD")
    sqlCV.Where("TD12", "IN", "0,1", intFMode.msfld_field)
    sqlCV.SqlFields("TD19", , , , True)
    rs = DB.RsSQL(sqlCV.Text, "RTDS")
    r = rs.NewRow
    r.Item(0) = "any"
    rs.Rows.InsertAt(r, 0)
    MODEL.DisplayMember = "TD19"
    MODEL.ValueMember = "TD19"
    MODEL.DataSource = rs
    MODEL.SelectedValue = "any"
    MOID.SelectedValue = "any"
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", "@CHARTS")
    sqlCV.SqlFields("QTN02", "KEYS", , , True)
    sqlCV.SqlFields("QTN02+' '+QTN03", "DATAS")
    sqlCV.SqlFields("QTN03")
    sqlCV.SqlFields("QTN05")
    rs = DB.RsSQL(sqlCV.Text, "RCHS")
    ComboBox1.DisplayMember = "DATAS"
    ComboBox1.ValueMember = "KEYS"
    ComboBox1.DataSource = rs
    If rs.Rows.Count > 0 Then
      ComboBox1.SelectedValue = rs.Rows(0)!KEYS.ToString.Trim
      aryCH.Clear()
      For Each r In rs.Rows
        aryCH.Add(r!KEYS.ToString.Trim, r!QTN03.ToString.Trim)
      Next
    End If
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TA")
    sqlCV.SqlFields("TA01", "KEYS", , , True)
    sqlCV.SqlFields("TA01+' '+TA02", "DATAS")
    rs = DB.RsSQL(sqlCV.Text, "RTA")
    CLST3.Items.Clear()
    CLST3.Items.Add(BIG2GB("any 所有工序"))
    For Each r In rs.Rows
      CLST3.Items.Add(r!DATAS.ToString.Trim)
    Next
  End Sub
  Private Sub SetList(s As CheckedListBox, strKey As String)
    Dim strV() As String = strKey.Split(",")
    For Each intI As Integer In s.CheckedIndices
      s.SetItemChecked(intI, False)
    Next
    Dim aryL As New ArrayList
    aryL.AddRange(strV)
    If aryL.Contains("any") Then
      If s.Items.Count > 0 Then s.SetItemChecked(0, True)
      Return
    End If
    For intI As Integer = 1 To s.Items.Count - 1
      Dim strV1 As String = s.Items(intI).Split(" ")(0)
      If aryL.Contains(strV1) Then
        s.SetItemChecked(intI, True)
      End If
    Next
  End Sub
  Private Sub GetDatas(strK As String)
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", "#KBPROFILE")
    sqlCV.Where("QTN02", "=", strK)
    sqlCV.SqlFields("QTN03")
    sqlCV.SqlFields("QTN04")
    sqlCV.SqlFields("QTN05")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count = 0 Then
      clsE_Frm_Clear(clsE)
      STNID.Text = strK
      STNID.Enabled = False
      Return
    End If
    STNID.Enabled = False
    STNID.Text = strK
    STNNA.Text = rs.Rows(0)!QTN03.ToString.Trim
    KBTYPE.SelectedIndex = Val(rs.Rows(0)!QTN04.ToString.Trim)
    If rs.Rows(0)!QTN05.GetType Is GetType(DBNull) Then
      Return
    End If
    Dim bytV() As Byte = rs.Rows(0)!QTN05
    If bytV Is Nothing OrElse bytV.Length = 0 Then Return
    Dim strJ As String = System.Text.Encoding.UTF8.GetString(bytV)
    Dim j As New JSON(strJ)
    DATES.Text = j.ItemNull("DATES")
    PERIOD.Text = j.ItemNull("PERIOD")
    PAGESCAN.Text = j.ItemNull("PAGESCAN")
    SetList(LINEID, j.ItemNull("LINEID"))
    PAGES.SelectedIndex = Val(j.ItemNull("PAGES"))
    MODEL.Text = j.ItemNull("MODEL")
    SetList(MOID, j.ItemNull("MOID"))
    Dim strV() As String = j.ItemNull("CHARTS").ToString.Split(",")
    SetList(CLST3, j.ItemNull("GRPID"))
    DG1.Rows.Clear()
    Dim strLK As String = ""
    For Each strM As String In strV
      If strM.Trim = "" Then Continue For
      strLK = strM
      If aryCH.ContainsKey(strM.Trim) Then
        DG1.Rows.Add(strM.Trim, aryCH(strM.Trim))
      Else
        DG1.Rows.Add(strM.Trim, strM.Trim)
      End If
    Next
    ComboBox1.SelectedValue = strLK
    ComboBox1_SelectionChangeCommitted(Nothing, Nothing)
  End Sub
  Private Sub clsE_DVSelect(s As clsEDITx2013, r As DataGridViewRow) Handles clsE.DVSelect
    GetDatas(GCell(r.Cells(0)))
  End Sub

  Private Sub clsE_DVTable(s As clsEDITx2013, ByRef strSQL As String) Handles clsE.DVTable
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", "#KBPROFILE")
    sqlCV.SqlFields("QTN02", "看板編號")
    sqlCV.SqlFields("QTN03", "看板名稱及位置")
    sqlCV.SqlFields("QTN04", "看板種類")
    strSQL = BIG2GB(sqlCV.Text)
  End Sub

  Private Sub clsE_Frm_CheckDup(s As clsEDITx2013, ByRef strSQL As String) Handles clsE.Frm_CheckDup
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", "#KBPROFILE")
    sqlCV.Where("QTN02", "=", STNID.Text.Trim)
    sqlCV.SqlFields("QTN02")
    strSQL = sqlCV.Text
  End Sub

  Private Sub clsE_Frm_Clear(s As clsEDITx2013) Handles clsE.Frm_Clear
    DG1.Rows.Clear()
    DATES.Text = ""
    STNNA.Text = ""
    STNID.Text = ""
    PERIOD.Text = ""
    PAGESCAN.Text = ""
    SetList(LINEID, "any")
    PAGES.Text = ""
    MODEL.Text = ""
    SetList(MOID, "any")
    SetList(CLST3, "any")
    KBTYPE.SelectedIndex = 0
    STNID.Enabled = True
  End Sub

  Private Sub clsE_Frm_Delete(s As clsEDITx2013, ByRef strSQL As String, ByRef bolOK As Boolean) Handles clsE.Frm_Delete
    If MsgBox(BIG2GB("確定要刪除這個看板站台設定值？"), MsgBoxStyle.YesNo, Me.Text) Then Return
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_delete, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", "#KBPROFILE")
    sqlCV.Where("QTN02", "=", STNID.Text.Trim)
    strSQL = sqlCV.Text
    bolOK = True
  End Sub
  Private Function DeList(s As CheckedListBox) As String
    If s.Items.Count = s.SelectedItems.Count Then
      Return "any"
    End If
    Dim strM As String = ""
    For Each strV As String In s.CheckedItems
      Dim strV1 As String = strV.Split(" ")(0)
      If strV1 = "any" Then
        Return "any"
      End If
      strM &= strV1 & ","
    Next
    Return strM.Trim(",")
  End Function
  Private Sub clsE_Frm_InsertM(s As clsEDITx2013, ByRef strSQL As String) Handles clsE.Frm_InsertM
    Dim sqlCV As New APSQL.SQLCNV
    Dim j As New JSON("")
    j.Add("DATES", DATES.Text.Trim)
    j.Add("PERIOD", PERIOD.Text.Trim)
    j.Add("PAGESCAN", PAGESCAN.Text.Trim)
    j.Add("LINEID", DeList(LINEID))
    j.Add("PAGES", PAGES.Text.Trim)
    j.Add("MODEL", MODEL.Text.Trim)
    j.Add("MOID", DeList(MOID))
    j.Add("ISPAGES", True)
    j.Add("GRPID", DeList(CLST3))
    Dim strM As String = ""
    For Each r As DataGridViewRow In DG1.Rows
      If GCell(r.Cells(0)) = "" Then Continue For
      strM &= GCell(r.Cells(0)) & ","
    Next
    j.Add("CHARTS", strM.Trim(","))
    Dim bytV() As Byte = System.Text.Encoding.UTF8.GetBytes(j.ToString)
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_QTN")
    sqlCV.SqlFields("QTN01", "#KBPROFILE")
    sqlCV.SqlFields("QTN02", STNID.Text.Trim)
    sqlCV.SqlFields("QTN03", STNNA.Text.Trim)
    sqlCV.SqlFields("QTN04", KBTYPE.SelectedIndex)
    sqlCV.SqlFields("QTN05", bytV)
    DB.RsSQL(sqlCV.Text, sqlCV.GetImgs)
    strSQL = ""
    s.Updated = True
    s.Clean()
  End Sub

  Private Sub clsE_Frm_UpdateM(s As clsEDITx2013, ByRef strSQL As String) Handles clsE.Frm_UpdateM
    Dim sqlCV As New APSQL.SQLCNV
    Dim j As New JSON("")
    j.Add("DATES", DATES.Text.Trim)
    j.Add("PERIOD", PERIOD.Text.Trim)
    j.Add("PAGESCAN", PAGESCAN.Text.Trim)
    j.Add("LINEID", DeList(LINEID))
    j.Add("PAGES", PAGES.Text.Trim)
    j.Add("MODEL", MODEL.Text.Trim)
    j.Add("MOID", DeList(MOID))
    j.Add("ISPAGES", True)
    j.Add("GRPID", DeList(CLST3))
    Dim strM As String = ""
    For Each r As DataGridViewRow In DG1.Rows
      If GCell(r.Cells(0)) = "" Then Continue For
      strM &= GCell(r.Cells(0)) & ","
    Next
    j.Add("CHARTS", strM.Trim(","))
    Dim bytV() As Byte = System.Text.Encoding.UTF8.GetBytes(j.ToString)
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", "#KBPROFILE")
    sqlCV.Where("QTN02", "=", STNID.Text.Trim)
    sqlCV.SqlFields("QTN03", STNNA.Text.Trim)
    sqlCV.SqlFields("QTN04", KBTYPE.SelectedIndex)
    sqlCV.SqlFields("QTN05", bytV)
    DB.RsSQL(sqlCV.Text, sqlCV.GetImgs)
    strSQL = ""
    s.Updated = True
    s.Clean()
  End Sub

  Private Sub clsE_isDataValid(s As clsEDITx2013, ByRef bolOK As Boolean) Handles clsE.isDataValid
    If STNID.Text.Trim = "" Then
      Return
    End If
    If KBTYPE.SelectedIndex = 1 And LINEID.SelectedValue Is Nothing Then
      LINEID.SelectedValue = "any"
    End If
    bolOK = True
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    Dim r As DataRowView = ComboBox1.SelectedItem
    If r Is Nothing Then Return
    DG1.Rows.Add(r!KEYS.ToString.Trim, r!QTN03.ToString.Trim)
    Dim intI As Integer = 1
    For Each r1 As DataGridViewRow In DG1.Rows
      r1.HeaderCell.Value = intI.ToString("0")
      intI += 1
    Next
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    If DG1.CurrentRow Is Nothing Then Return
    DG1.Rows.Remove(DG1.CurrentRow)
    Dim intI As Integer = 1
    For Each r1 As DataGridViewRow In DG1.Rows
      r1.HeaderCell.Value = intI.ToString("0")
      intI += 1
    Next
  End Sub

  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    Dim strA As String = "", strB As String = "", intI As Integer = DG1.CurrentRow.Index - 1
    If intI < 0 Then
      Return
    End If
    strA = GCell(DG1.CurrentRow.Cells(0))
    strB = GCell(DG1.CurrentRow.Cells(1))
    DG1.CurrentRow.Cells(0).Value = GCell(DG1.Rows(intI).Cells(0))
    DG1.CurrentRow.Cells(1).Value = GCell(DG1.Rows(intI).Cells(1))
    DG1.Rows(intI).Cells(0).Value = strA
    DG1.Rows(intI).Cells(1).Value = strB
  End Sub

  Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    Dim strA As String = "", strB As String = "", intI As Integer = DG1.CurrentRow.Index + 1
    If intI >= DG1.Rows.Count Then
      Return
    End If
    strA = GCell(DG1.CurrentRow.Cells(0))
    strB = GCell(DG1.CurrentRow.Cells(1))
    DG1.CurrentRow.Cells(0).Value = GCell(DG1.Rows(intI).Cells(0))
    DG1.CurrentRow.Cells(1).Value = GCell(DG1.Rows(intI).Cells(1))
    DG1.Rows(intI).Cells(0).Value = strA
    DG1.Rows(intI).Cells(1).Value = strB
  End Sub

  Private Sub STNID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles STNID.KeyPress, STNNA.KeyPress, _
     PAGES.KeyPress, PAGESCAN.KeyPress, PERIOD.KeyPress, KBTYPE.KeyPress, _
    MODEL.KeyPress, DATES.KeyPress
    If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
      e.Handled = True
      My.Computer.Keyboard.SendKeys(vbTab)
    End If
  End Sub

  Private Sub STNID_LostFocus(sender As Object, e As EventArgs) Handles STNID.LostFocus
    If STNID.Text.Trim = "" Then Return
    GetDatas(STNID.Text.Trim)
  End Sub
  ''' <summary>
  ''' 取得隨機亂數
  ''' </summary>
  ''' <param name="sngMin">最小值</param>
  ''' <param name="sngMax">最大值</param>
  ''' <param name="intL">小數位數</param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function GetRnd(sngMin As Double, sngMax As Double, Optional intL As Integer = 2) As Double
    Randomize()
    Return Math.Round((Rnd() * (sngMax - sngMin + 1) + sngMin), intL)
  End Function

  Private Sub ComboBox1_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBox1.SelectionChangeCommitted
    Dim r As DataRowView = ComboBox1.SelectedItem
    If r Is Nothing Then Return
    If r!QTN05.GetType Is GetType(DBNull) Then Return
    Dim bytV() As Byte = r!QTN05
    If bytV Is Nothing OrElse bytV.Length = 0 Then Return
    Dim strJ As String = System.Text.Encoding.UTF8.GetString(bytV)
    Dim s1 As New JSONCHART(strJ)
    s1.JChart = CH1
    s1.Init()
    Dim aryTE As Dictionary(Of String, Object) = s1.GetElements
    For Each strK As String In aryTE.Keys
      If aryTE(strK).GetType Is GetType(JSONCHART.JSeriesElement) Then
        Dim e1 As JSONCHART.JSeriesElement = aryTE(strK)
        For intI As Integer = 0 To 10
          Select Case e1.JName.Trim.ToUpper
            Case "CL"
              s1.AddYValue(strK, 5, "L" & intI.ToString("00"))
            Case "UCL"
              s1.AddYValue(strK, GetRnd(9, 10, 2), "L" & intI.ToString("00"))
            Case "LCL"
              s1.AddYValue(strK, GetRnd(1, 2, 2), "L" & intI.ToString("00"))
            Case Else
              s1.AddYValue(strK, GetRnd(1, 10, 2), "L" & intI.ToString("00"))
          End Select
         Next
        s1.SetSeries(strK)
      End If
    Next
  End Sub

  Private Sub DG_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DG.CellFormatting
    If e.ColumnIndex = 2 Then
      If e.Value.ToString.Length = 1 Then e.Value = KBTYPE.Items(Val(e.Value))
    End If
  End Sub

  Private Sub DG1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG1.CellContentClick
    If e.RowIndex < 0 Or e.RowIndex >= DG1.Rows.Count Then Return
    Dim strV As String = GCell(DG1.Rows(e.RowIndex).Cells(0))
    If strV <> ComboBox1.SelectedValue.ToString.Trim And strV <> "" Then
      ComboBox1.SelectedValue = strV
      ComboBox1_SelectionChangeCommitted(Nothing, Nothing)
    End If
  End Sub
End Class