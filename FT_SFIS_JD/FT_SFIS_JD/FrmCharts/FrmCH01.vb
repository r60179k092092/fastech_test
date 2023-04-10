Public Class FrmCH01
  Private aryVal As New ArrayList
  Private bolF As Boolean = False
  Private bolLock As Boolean = False
  Private strLAST As String = ""
  Private strNow As String = ""
  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()
    languagechange(Me)
    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

  End Sub
  ''' <summary>
  ''' 取得列舉資料以DataTable的方式匯出
  ''' </summary>
  ''' <param name="T">列舉類別</param>
  ''' <param name="strName">DataTable的名稱</param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function EnumToDataTable(T As System.Type, strName As String, Optional strVM As String = "ID", Optional strDM As String = "DTS") As DataTable
    Try
      Dim rs As New DataTable
      rs.Columns.Add(strDM)
      rs.Columns.Add(strVM)
      rs.TableName = strName
      Dim values() = CType([Enum].GetValues(T), Integer())
      For Each v In values
        rs.Rows.Add([Enum].GetName(T, v), v)
      Next
      Return rs
    Catch ex As Exception
      MsgBox("Get Enum Error , " & ex.ToString)
      Return Nothing
    End Try
  End Function
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

  'Private Sub FrmCH01_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
  '  If bolF Then Return
  '  If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
  '    e.Handled = True
  '    My.Computer.Keyboard.SendKeys(vbTab)
  '  End If
  'End Sub
  Private Sub InitForm()
    FDG.Rows.Clear()
    FDG.Columns.Clear()
    Dim sqlcv As New APSQL.SQLCNV
    sqlcv.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlcv.Where("QTN01", "=", "CHARTAREA")
    sqlcv.SqlFields("QTN02", "ID")
    sqlcv.SqlFields("QTN03", "DTS")
    Dim rs2 As DataTable = DB.RsSQL(sqlcv.Text, "RS2")
    If rs2.Rows.Count = 0 Then
      rs2.Rows.Add("0", BIG2GB("主要區間"))
    End If
    sqlcv.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlcv.Where("QTN01", "=", "SPC.COL1")
    sqlcv.SqlFields("QTN02", "ID")
    sqlcv.SqlFields("QTN03", "DTS")
    Dim rs3 As DataTable = DB.RsSQL(sqlcv.Text, "RS3")
    Dim r As DataRow = rs3.NewRow
    r.Item(0) = "0"
    r.Item(1) = BIG2GB("任意數列")
    rs3.Rows.InsertAt(r, 0)
    Dim rs6 As New DataTable
    rs6.Columns.Add("ID")
    rs6.Columns.Add("DTS")
    rs6.Rows.Add("0", BIG2GB("不排序"))
    rs6.Rows.Add("1", BIG2GB("遞增"))
    rs6.Rows.Add("2", BIG2GB("遞減"))
    AddTextColumn(FDG, "JID", BIG2GB("編號"))
    AddTextColumn(FDG, "JNAME", BIG2GB("識別名稱"))
    AddComboboxColumn(FDG, "JSTYPE", BIG2GB("顯示類型"), EnumToDataTable(GetType(DataVisualization.Charting.SeriesChartType), "RS"))
    AddComboboxColumn(FDG, "JCHARTAREA", BIG2GB("管制區域"), rs2) 'series's chartarea
    AddComboboxColumn(FDG, "JCONTENT", BIG2GB("資料內容"), rs3)
    FDG.Columns(AddTextColumn(FDG, "JCOLOR", BIG2GB("顏色"))).ReadOnly = True
    AddCheckboxColumn(FDG, "JSHOWVALUE", BIG2GB("顯示數值"))
    AddComboboxColumn(FDG, "JSORT", BIG2GB("排序"), rs6)
    AddTextColumn(FDG, "JWIDTH", BIG2GB("線寬度"))
    Dim x As DataTable = EnumToDataTable(GetType(DataVisualization.Charting.Docking), "LGDOCK")
    LGDOCK.DisplayMember = "DTS"
    LGDOCK.ValueMember = "ID"
    LGDOCK.DataSource = x
    x = EnumToDataTable(GetType(DataVisualization.Charting.LegendStyle), "LGLAYOUT")
    LGLAYOUT.DisplayMember = "DTS"
    LGLAYOUT.ValueMember = "ID"
    LGLAYOUT.DataSource = x
    x = EnumToDataTable(GetType(StringAlignment), "LGALI")
    LGALI.DisplayMember = "DTS"
    LGALI.ValueMember = "ID"
    LGALI.DataSource = x
    'FDG.Columns(0).ReadOnly = True
    FDG.AppendBegin()
  End Sub

  Private Sub FrmCH01_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    TuiCK(Me)
  End Sub
  Private Sub FrmCH01_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    InitForm()
    SetComBo()
  End Sub
  Private Sub Clear()
    JSCHT.Text = ""
    TextBox1.Text = ""
    ReChartPara("")
  End Sub
  Private Sub SetComBo()
    Dim sqlCV As New APSQL.SQLCNV
    Dim strB As String = ""
    If ComboBox1.SelectedValue IsNot Nothing Then
      strB = ComboBox1.SelectedValue.ToString.Trim
    End If
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", "@CHARTS")
    sqlCV.SqlFields("QTN02", "KEYS")
    sqlCV.SqlFields("QTN02+' '+QTN03", "DATAS")
    sqlCV.SqlFields("QTN03")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RCH")
    ComboBox1.DisplayMember = "DATAS"
    ComboBox1.ValueMember = "KEYS"
    ComboBox1.DataSource = rs
    ComboBox1.SelectedValue = strB
    If rs.Rows.Count > 0 And ComboBox1.SelectedValue Is Nothing Then
      ComboBox1.SelectedValue = rs.Rows(0)!KEYS.ToString.Trim
    End If
    ComboBox1_Validated(Nothing, Nothing)
  End Sub
  Private strBEdit As String = ""
  Private Sub FDG_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles FDG.CellBeginEdit
    strBEdit = ""
    Try
      If e.ColumnIndex = 0 Then
        strBEdit = GCell(FDG.Rows(e.RowIndex).Cells(e.ColumnIndex))
      End If
    Catch ex As Exception
    End Try
  End Sub

  Private Sub FDG_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles FDG.CellEndEdit
    Try
      If e.ColumnIndex = 0 Then
        Dim strV As String = GCell(FDG.Rows(e.RowIndex).Cells(e.ColumnIndex))
        If strV = "" Then Return
        For Each r As DataGridViewRow In FDG.Rows
          If r.Index = e.RowIndex Then Continue For
          If strV = GCell(r.Cells(e.ColumnIndex)) Then
            MsgBox(BIG2GB("編號不可重複"))
            FDG.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = strBEdit
            strBEdit = ""
          End If
        Next
      End If
    Catch ex As Exception

    End Try
  End Sub

  Private Sub FDG_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles FDG.DataError

  End Sub

  Private Sub FDG_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles FDG.CellDoubleClick
    If e.RowIndex < 0 OrElse e.RowIndex > FDG.RowCount - 1 Then Return
    If e.ColumnIndex < 0 OrElse e.ColumnIndex > FDG.ColumnCount - 1 Then Return
    Dim strV As String = GCell(FDG.Rows(e.RowIndex).Cells(e.ColumnIndex))
    Dim strCN As String = FDG.Columns(e.ColumnIndex).Name
    Select Case strCN
      Case "JCOLOR"
        Dim c As New ColorDialog
        If strV.Trim <> "" Then
          c.Color = Color.FromArgb(Val(strV))
        End If
        If c.ShowDialog = Windows.Forms.DialogResult.Cancel Then
          FDG.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = ""
          FDG.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = FDG.DefaultCellStyle.BackColor
          FDG.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = FDG.DefaultCellStyle.ForeColor
        Else
          FDG.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = c.Color.ToArgb
          FDG.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = c.Color
          FDG.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.FromArgb(c.Color.R Xor 255, c.Color.G Xor 255, c.Color.B Xor 255)
        End If
        FDG.MoveNext(e.ColumnIndex + 1)
        FDG.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
        bolLock = True
    End Select
  End Sub

  Private Function AddTextColumn(D As DataGridView, strName As String, strText As String) As Integer
    Dim c As New DataGridViewTextBoxColumn
    c.Name = strName
    c.HeaderText = strText
    c.SortMode = DataGridViewColumnSortMode.NotSortable
    Return D.Columns.Add(c)
  End Function

  Private Function AddComboboxColumn(D As DataGridView, strName As String, strText As String, rs As DataTable, Optional strVM As String = "ID", Optional strDM As String = "DTS") As Integer
    Dim c As New DataGridViewComboBoxColumn
    c.HeaderText = strText
    c.Name = strName
    c.DataSource = rs
    c.DisplayMember = strDM
    c.ValueMember = strVM
    c.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
    c.FlatStyle = FlatStyle.Popup
    c.SortMode = DataGridViewColumnSortMode.NotSortable
    Return D.Columns.Add(c)
  End Function

  Private Function AddCheckboxColumn(D As DataGridView, strName As String, strText As String) As Integer
    Dim c As New DataGridViewCheckBoxColumn
    c.HeaderText = strText
    c.Name = strName
    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    c.FalseValue = ""
    Return D.Columns.Add(c)
  End Function

  Private Sub BRef_Click(sender As Object, e As EventArgs) Handles BRef.Click
    Dim clsJC As New JSONCHART(GetJSON)
    strNow = ""
    JSCHT.Text = clsJC.ToString
    clsJC.JChart = Chart1
    clsJC.Init()
    Dim intC As Integer = 0
    For Each r As DataGridViewRow In FDG.Rows
      If GCell(r.Cells(0)) = "" Then Continue For
      intC += 1
    Next
    If intC > aryVal.Count Then
      For intII As Integer = 0 To intC - aryVal.Count
        Dim aryT As New ArrayList
        For intI As Integer = 0 To 10
          aryT.Add(GetRnd(1, 10, 2))
        Next
        aryVal.Add(aryT)
      Next
    End If
    Dim intIDX As Integer = 0
    For Each r As DataGridViewRow In FDG.Rows
      If GCell(r.Cells(0)).Trim = "" Or GCell(r.Cells(1)) = "" Then Continue For
      Dim e1 As JSONCHART.JSeriesElement = CType(clsJC.GetElement(GCell(r.Cells(0))), JSONCHART.JSeriesElement)
      Dim aryT As ArrayList = aryVal(intIDX)
      Dim bolC As Boolean = False
      For intI As Integer = 0 To aryT.Count - 1
        Select Case e1.JName.Trim.ToUpper
          Case "CL"
            clsJC.AddYValue(GCell(r.Cells(0)), 5, "L" & intI.ToString("00"))
          Case "UCL"
            clsJC.AddYValue(GCell(r.Cells(0)), aryT(intI) * 0.1 + 9, "L" & intI.ToString("00"))
          Case "LCL"
            clsJC.AddYValue(GCell(r.Cells(0)), aryT(intI) * 0.1 + 1, "L" & intI.ToString("00"))
          Case Else
            clsJC.AddYValue(GCell(r.Cells(0)), aryT(intI), "L" & intI.ToString("00"))
            bolC = True
        End Select
      Next
      clsJC.SetSeries(GCell(r.Cells(0)))
      If bolC Then
        Dim c(aryT.Count - 1) As Color
        For intJ As Integer = 0 To c.GetUpperBound(0)
          c(intJ) = Color.Black
        Next
        clsJC.SetSerialMark(GCell(r.Cells(0)), DataVisualization.Charting.MarkerStyle.Circle, c)
      End If
      intIDX += 1
    Next
    bolLock = False
  End Sub

  Private Function GetJSON() As JSON
    '順序務必遵造以下
    '設定數列(series)
    '設定管制圖(chart)
    If strNow <> "" Then
      Return New JSON(strNow)
    End If
    Dim clsJS As New JSON("")
    For Each r As DataGridViewRow In FDG.Rows
      If GCell(r.Cells("JID")).Trim = "" Or GCell(r.Cells(1)) = "" Then Continue For
      Dim J As New JSON("")
      For intI As Integer = 0 To FDG.ColumnCount - 1
        J.Add(FDG.Columns(intI).Name, GCell(r.Cells(intI)))
      Next
      clsJS.Add(GCell(r.Cells("JID")), J)
    Next
    Dim c1 As New JSON("")
    Dim strK1 As String = ""
    If ComboBox1.SelectedValue Is Nothing Then
      Dim strK As String = ComboBox1.Text.Trim
      If strK <> "" Then
        Dim intP As Integer = strK.IndexOf(" ")
        If intP < 0 Then
          strK1 = strK
        End If
      Else
        strK1 = "*"
      End If
    Else
      strK1 = ComboBox1.SelectedValue.ToString.Trim
    End If
    c1.Add("JID", strK1)
    c1.Add("JNAME", TextBox1.Text.Trim)
    c1.Add("JS3D", IIf(CheckBox1.Checked, "1", "0"))
    c1.Add("J3DX", TBNum1.Value)
    c1.Add("J3DY", TBNum2.Value)
    c1.Add("JANGLE", TBNum3.Value)
    c1.Add("JSHOWLEGEND", IIf(CheckBox2.Checked, "1", "0"))
    c1.Add("JSSHOWTITLE", IIf(CheckBox5.Checked, "1", "0"))
    c1.Add("JSGLX", IIf(CheckBox3.Checked, "1", "0"))
    c1.Add("JSGLY", IIf(CheckBox4.Checked, "1", "0"))
    c1.Add("JSXINTERVAL", XIntVal.Text.Trim)
    c1.Add("JSYINTERVAL", YintVal.Text.Trim)
    c1.Add("LGDOCK", LGDOCK.SelectedIndex)
    c1.Add("LGALIGN", LGALI.SelectedIndex)
    c1.Add("LGTYPE", LGLAYOUT.SelectedIndex)
    c1.Add("LGINAREA", CheckBox6.Checked)
    c1.Add("XBEGIN", XBG.Text.Trim)
    c1.Add("XENDING", XED.Text.Trim)
    c1.Add("YBEGIN", YBG.Text.Trim)
    c1.Add("YENDING", YED.Text.Trim)
    c1.Add("ISSHAPEA", SHPA.Checked)
    c1.Add("ISSHAPED", SHPD.Checked)
    If Button4.Tag IsNot Nothing Then
      c1.Add("MAINFONT", Button4.Tag.ToString)
    Else
      c1.Add("MAINFONT", "")
    End If
    If Button5.Tag IsNot Nothing Then
      c1.Add("LEGENDFONT", Button5.Tag.ToString)
    Else
      c1.Add("LEGENDFONT", "")
    End If
    If Button6.Tag IsNot Nothing Then
      c1.Add("TITLEFONT", Button6.Tag.ToString)
    Else
      c1.Add("TITLEFONT", "")
    End If
    If Button7.Tag IsNot Nothing Then
      c1.Add("SERIESFONT", Button7.Tag.ToString)
    Else
      c1.Add("SERIESFONT", "")
    End If
    clsJS.Add("*00", c1)
    Return clsJS
  End Function

  Private Sub CheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged, _
    CheckBox2.CheckedChanged, CheckBox3.CheckedChanged, CheckBox4.CheckedChanged, CheckBox5.CheckedChanged, _
    CheckBox6.CheckedChanged, SHPA.CheckedChanged, SHPD.CheckedChanged
    bolLock = True
    Select Case CType(sender, CheckBox).Name
      Case "CheckBox1"
        Panel5.Enabled = CType(sender, CheckBox).Checked
      Case "CheckBox2"
        Panel6.Enabled = CType(sender, CheckBox).Checked
    End Select
  End Sub

  Private Sub TBNum_ValueChanged(sender As Object, e As EventArgs) Handles TBNum1.ValueChanged, TBNum2.ValueChanged, TBNum3.ValueChanged
    bolLock = True
  End Sub

  Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
    If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
      e.Handled = True
      My.Computer.Keyboard.SendKeys(vbTab)
    End If
  End Sub

  Private Sub ComboBox1_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBox1.SelectionChangeCommitted
    My.Computer.Keyboard.SendKeys(vbTab)
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    Me.DialogResult = Windows.Forms.DialogResult.Cancel
    Me.Close()
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    Dim sqlCV As New APSQL.SQLCNV
    If ComboBox1.Text.Trim = "" Then Return
    Dim cjs As JSON = GetJSON()
    If cjs.ToString = "" Then Return
    Dim strK As String = cjs.Item("*00^JID")
    Dim strJC As String = cjs.ToString
    Dim bytV() As Byte = System.Text.Encoding.UTF8.GetBytes(strJC)
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", "@CHARTS")
    sqlCV.Where("QTN02", "=", strK)
    sqlCV.SqlFields("QTN03", TextBox1.Text.Trim)
    sqlCV.SqlFields("QTN05", bytV)
    Dim intL As Integer = DB.RsSQL(sqlCV.Text, sqlCV.GetImgs)
    If intL = 0 Then
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_QTN")
      sqlCV.SqlFields("QTN01", "@CHARTS")
      sqlCV.SqlFields("QTN02", strK)
      sqlCV.SqlFields("QTN03", TextBox1.Text.Trim)
      sqlCV.SqlFields("QTN05", bytV)
      DB.RsSQL(sqlCV.Text, sqlCV.GetImgs)
    End If
    SetComBo()
  End Sub

  Private Sub FDG_EditingAppendRow(s As Object, ByRef strV() As Object) Handles FDG.EditingAppendRow
    Dim intI As Integer = 0
    If FDG.Rows.Count > 0 Then
      For Each r As DataGridViewRow In FDG.Rows
        If GCell(r.Cells(0)) = "" Then Continue For
        Dim intL As Integer = Val(GCell(r.Cells(0)))
        If intI < intL Then intI = intL
      Next
    End If
    strV(0) = (intI + 1).ToString("000")
    strV(3) = "0"
    strV(4) = "0"
    strV(6) = "0"
    strV(7) = "0"
    strV(8) = 1
  End Sub

  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    If FDG.CurrentRow Is Nothing Then
      Return
    End If
    FDG.Rows.Remove(FDG.CurrentRow)
    'Dim intI As Integer = 0
    'For Each r As DataGridViewRow In FDG.Rows
    '  intI += 1
    '  r.Cells(0).Value = intI.ToString("000")
    'Next
    bolLock = True
  End Sub

  Private Sub FDG_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles FDG.RowLeave
    FDG.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
    bolLock = True
  End Sub

  Private Sub XIntVal_Validated(sender As Object, e As EventArgs) Handles XIntVal.Validated, YintVal.Validated, _
    XBG.Validated, YBG.Validated, XED.Validated, YED.Validated
    bolLock = True
  End Sub

  Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click, Button5.Click, Button6.Click, Button7.Click
    Dim fnd As New FontDialog
    Dim s As Button = sender
    If s.Tag IsNot Nothing AndAlso s.Tag <> "" Then
      Dim strV() As String = s.Tag.ToString.Split(",")
      fnd.Font = New Font(strV(0), CType(Val(strV(1)), Single), CType(Val(strV(2)), FontStyle))
      fnd.Color = Color.FromArgb(Val(strV(3)))
    End If
    fnd.ShowColor = True
    If fnd.ShowDialog = Windows.Forms.DialogResult.OK Then
      Dim intI As Integer = fnd.Font.Style
      Dim strM As String = fnd.Font.Name & "," & fnd.Font.SizeInPoints.ToString("0.00") & "," & intI.ToString & "," & fnd.Color.ToArgb
      s.Tag = strM
    Else
      s.Tag = ""
    End If
    bolLock = True
  End Sub

  Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    If bolLock = True Then
      BRef_Click(Nothing, Nothing)
    End If
  End Sub

  Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
    My.Computer.Clipboard.SetText(JSCHT.Text)
  End Sub

  Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
    strLAST = JSCHT.Text
    JSCHT.Text = My.Computer.Clipboard.GetText
    strNow = JSCHT.Text
    ReChartPara(strNow)
    BRef_Click(Nothing, Nothing)
  End Sub
  Private Sub ReChartPara(strV As String)
    Dim clsJS As New JSON(strV)
    Dim aryT As Dictionary(Of String, Object) = clsJS.GetAll
    FDG.Rows.Clear()
    Chart1.Series.Clear()
    Chart1.Legends(0).DockedToChartArea = ""
    For Each s1 As String In aryT.Keys
      Dim clsJ As JSON = aryT(s1)
      Dim aryT2 As Dictionary(Of String, Object) = clsJ.GetAll
      If s1.StartsWith("*") = False Then
        Dim intNew As Integer = FDG.Rows.Add()
        For Each s2 As String In aryT2.Keys
          If FDG.Columns.Contains(s2) Then
            FDG.Rows(intNew).Cells(s2).Value = aryT2(s2)
            If s2 = "JCOLOR" Then
              If aryT2(s2) <> "" Then
                FDG.Rows(intNew).Cells(s2).Style.BackColor = Color.FromArgb(aryT2(s2))
              End If
            End If
          End If
        Next
      Else
        Dim e1 As New JSONCHART.JChartElement(clsJ)
        CheckBox1.Checked = e1.IsJ3D
        TBNum1.Value = e1.J3DX
        TBNum2.Value = e1.J3DY
        TBNum3.Value = e1.Angel
        CheckBox2.Checked = e1.IsJShowLegend
        CheckBox3.Checked = e1.IsShowGridLineX
        CheckBox4.Checked = e1.IsShowGridLineY
        CheckBox5.Checked = e1.isShowTitle
        CheckBox6.Checked = e1.isLGInArea
        LGALI.SelectedIndex = e1.LGAlign
        LGLAYOUT.SelectedIndex = e1.LGType
        LGDOCK.SelectedIndex = e1.LGDock
        SHPA.Checked = e1.isShapeArea
        SHPD.Checked = e1.isShapeDraw
        XBG.Text = e1.XBegin
        YBG.Text = e1.YBegin
        XED.Text = e1.XEnding
        YED.Text = e1.YEnding
        XIntVal.Text = e1.XInterval
        YintVal.Text = e1.YInterval
        Button4.Tag = e1.GetMainFont
        Button5.Tag = e1.GetLEGENDFont
        Button6.Tag = e1.GetTITLEFont
        Button7.Tag = e1.GetSeriesFont
      End If
    Next
    FDG.AppendBegin()

  End Sub
  Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
    If strLAST <> "" Then
      strNow = strLAST
      JSCHT.Text = strLAST
      strLAST = ""
      ReChartPara(strNow)
      BRef_Click(Nothing, Nothing)
    End If
  End Sub

  Private Sub LGALI_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles LGALI.SelectionChangeCommitted, _
    LGDOCK.SelectionChangeCommitted, LGLAYOUT.SelectionChangeCommitted
    bolLock = True
  End Sub

  Private Sub ComboBox1_Validated(sender As Object, e As EventArgs) Handles ComboBox1.Validated
    Dim r As DataRowView = ComboBox1.SelectedItem
    Dim strKEY As String = ""
    If r Is Nothing Then
      strKEY = ComboBox1.Text.Trim.Split(" ")(0)
    Else
      strKEY = r!KEYS.ToString.Trim
    End If
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", "@CHARTS")
    sqlCV.Where("QTN02", "=", strKEY)
    sqlCV.SqlFields("QTN03")
    sqlCV.SqlFields("QTN05")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count = 0 Then
      Clear()
      Return
    End If
    If rs.Rows(0)!QTN05.GetType Is GetType(DBNull) Then
      Clear()
      TextBox1.Text = rs.Rows(0)!QTN03.ToString.Trim
      Return
    End If
    Dim bytV() As Byte = rs.Rows(0)!QTN05
    If bytV Is Nothing OrElse bytV.Length = 0 Then
      Clear()
      TextBox1.Text = rs.Rows(0)!QTN03.ToString.Trim
      Return
    End If
    TextBox1.Text = rs.Rows(0)!QTN03.ToString.Trim
    Dim strJ As String = System.Text.Encoding.UTF8.GetString(bytV)
    ReChartPara(strJ)
    bolLock = True
  End Sub
End Class
