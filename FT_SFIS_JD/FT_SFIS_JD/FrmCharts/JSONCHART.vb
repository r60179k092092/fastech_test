Imports System.Windows.Forms.DataVisualization.Charting
Public Class JSONCHART
  Public Class DesSort
    Implements IComparer
    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
       Implements IComparer.Compare
      Return New CaseInsensitiveComparer().Compare(y, x)
    End Function
  End Class
  Class JChartElement
    Private strJID As String = ""
    Property JID As String
      Get
        Return strJID
      End Get
      Set(value As String)
        strJID = value
      End Set
    End Property
    Private strJName As String = ""
    Property JNAME As String
      Get
        Return strJName
      End Get
      Set(value As String)
        strJName = value
      End Set
    End Property
    Private bolJ3D As Boolean = False
    ''' <summary>
    ''' 設定或取得是否3D化
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IsJ3D As Boolean
      Get
        Return bolJ3D
      End Get
      Set(value As Boolean)
        bolJ3D = value
      End Set
    End Property
    Private intJ3DX As Integer = 200
    ''' <summary>
    ''' 取得或設定3D的X軸向深度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property J3DX As Integer
      Get
        Return intJ3DX
      End Get
      Set(value As Integer)
        intJ3DX = value
      End Set
    End Property
    Private intJ3DY As Integer = 200
    ''' <summary>
    ''' 取得或設定3D的Y軸深度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property J3DY As Integer
      Get
        Return intJ3DY
      End Get
      Set(value As Integer)
        intJ3DY = value
      End Set
    End Property

    Private bolJSLegend As Boolean = False
    ''' <summary>
    ''' 設定或取得是否顯示圖示
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IsJShowLegend As Boolean
      Get
        Return bolJSLegend
      End Get
      Set(value As Boolean)
        bolJSLegend = value
      End Set
    End Property
    Private intAngle As Integer = 0
    ''' <summary>
    ''' 取得或設定3D化深度的角度變換
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Angel As Integer
      Get
        Return intAngle
      End Get
      Set(value As Integer)
        intAngle = value
      End Set
    End Property
    'Private bolJSGridLine As Boolean = False
    'Property IsJShowGridLine As Boolean
    '  Get
    '    Return bolJSGridLine
    '  End Get
    '  Set(value As Boolean)
    '    bolJSGridLine = value
    '  End Set
    'End Property
    Private bolJShowGridLineX As Boolean = False
    Property IsShowGridLineX As Boolean
      Get
        Return bolJShowGridLineX
      End Get
      Set(value As Boolean)
        bolJShowGridLineX = value
      End Set
    End Property
    Private bolJShowGridLineY As Boolean = False
    Property IsShowGridLineY As Boolean
      Get
        Return bolJShowGridLineY
      End Get
      Set(value As Boolean)
        bolJShowGridLineY = value
      End Set
    End Property
    Private bolShowTitle As Boolean = False
    Public Property isShowTitle As Boolean
      Get
        Return bolShowTitle
      End Get
      Set(value As Boolean)
        bolShowTitle = value
      End Set
    End Property
    Private sngXIntVal As Double = 0
    Private sngXBegin As Double = 0
    Private sngXEnding As Double = 0
    Public Property XInterval As Double
      Get
        Return sngXIntVal
      End Get
      Set(value As Double)
        sngXIntVal = value
      End Set
    End Property
    Public Property XBegin As Double
      Get
        Return sngXBegin
      End Get
      Set(value As Double)
        sngXBegin = value
      End Set
    End Property
    Public Property XEnding As Double
      Get
        Return sngXEnding
      End Get
      Set(value As Double)
        sngXEnding = value
      End Set
    End Property
    Private sngYIntVal As Double = 0
    Private sngYBegin As Double = 0
    Private sngYEnding As Double = 0
    Public Property YInterval As Double
      Get
        Return sngYIntVal
      End Get
      Set(value As Double)
        sngYIntVal = value
      End Set
    End Property
    Public Property YBegin As Double
      Get
        Return sngYBegin
      End Get
      Set(value As Double)
        sngYBegin = value
      End Set
    End Property
    Public Property YEnding As Double
      Get
        Return sngYEnding
      End Get
      Set(value As Double)
        sngYEnding = value
      End Set
    End Property
    Private bolIsLGinAear As Boolean = False
    Private intLGDock As Integer = 0
    Private intLGAlign As Integer = 0
    Private intLGType As Integer = 0
    Public Property isLGInArea As Boolean
      Get
        Return bolIsLGinAear
      End Get
      Set(value As Boolean)
        bolIsLGinAear = value
      End Set
    End Property
    Public Property LGDock As Integer
      Get
        Return intLGDock
      End Get
      Set(value As Integer)
        intLGDock = value
      End Set
    End Property
    Public Property LGAlign As Integer
      Get
        Return intLGAlign
      End Get
      Set(value As Integer)
        intLGAlign = value
      End Set
    End Property
    Public Property LGType As Integer
      Get
        Return intLGType
      End Get
      Set(value As Integer)
        intLGType = value
      End Set
    End Property
    Private bolisShapeArea As Boolean = False
    Private bolisShapeDraw As Boolean = False
    Public Property isShapeArea As Boolean
      Get
        Return bolisShapeArea
      End Get
      Set(value As Boolean)
        bolisShapeArea = value
      End Set
    End Property
    Public Property isShapeDraw As Boolean
      Get
        Return bolisShapeDraw
      End Get
      Set(value As Boolean)
        bolisShapeDraw = value
      End Set
    End Property
    Private fntMain As Font = Nothing
    Private intMainC As Color = Color.Black
    Public Property MainFont As Font
      Get
        Return fntMain
      End Get
      Set(value As Font)
        fntMain = value
      End Set
    End Property
    Public Property MainColor As Color
      Get
        Return intMainC
      End Get
      Set(value As Color)
        intMainC = value
      End Set
    End Property
    Public Function GetMainFont() As String
      Return GetFonts(fntMain, intMainC)
    End Function
    Private Function GetFonts(fnt As Font, col As Color) As String
      If fnt Is Nothing Then Return ""
      Dim intI As Integer = fnt.Style
      Return fnt.Name & "," & fnt.SizeInPoints.ToString("0.00") & "," & intI & "," & col.ToArgb.ToString
    End Function
    Private fntLEGEND As Font = Nothing
    Private intLEGENDC As Color = Color.Black
    Property LEGENDFont As Font
      Get
        Return fntLEGEND
      End Get
      Set(value As Font)
        fntLEGEND = value
      End Set
    End Property
    Public Function GetLEGENDFont() As String
      Return GetFonts(fntLEGEND, intLEGENDC)
    End Function
    Public Property LEGENDColor As Color
      Get
        Return intLEGENDC
      End Get
      Set(value As Color)
        intLEGENDC = value
      End Set
    End Property
    Private fntTITLE As Font = Nothing
    Private intTITLEC As Color = Color.Black
    Public Property TITLEFont As Font
      Get
        Return fntTITLE
      End Get
      Set(value As Font)
        fntTITLE = value
      End Set
    End Property
    Public Function GetTITLEFont() As String
      Return GetFonts(fntTITLE, intTITLEC)
    End Function
    Public Property TITLEColor As Color
      Get
        Return intTITLEC
      End Get
      Set(value As Color)
        intTITLEC = value
      End Set
    End Property
    Private fntSERIES As Font = Nothing
    Private intSERIESC As Color = Color.Black
    Public Property SeriesFont As Font
      Get
        Return fntSERIES
      End Get
      Set(value As Font)
        fntSERIES = value
      End Set
    End Property
    Public Function GetSeriesFont() As String
      Return GetFonts(fntSERIES, intSERIESC)
    End Function
    Public Property SeriesColor As Color
      Get
        Return intSERIESC
      End Get
      Set(value As Color)
        intSERIESC = value
      End Set
    End Property
    Sub New(J As JSON)
      If J.Item("JID") IsNot Nothing Then strJID = J.Item("JID").ToString
      If J.Item("JNAME") IsNot Nothing Then strJName = J.Item("JNAME").ToString
      bolJ3D = False
      If J.Item("JS3D") IsNot Nothing Then
        If J.Item("JS3D").ToString.ToUpper = "TRUE" OrElse J.Item("JS3D").ToString.ToUpper = "1" Then
          bolJ3D = True
        End If
      End If
      If J.Item("J3DX") Is Nothing Then
        intJ3DX = 0
      Else
        intJ3DX = Val(J.Item("J3DX").ToString)
      End If
      If J.Item("J3DY") Is Nothing Then
        intJ3DY = 0
      Else
        intJ3DY = Val(J.Item("J3DY").ToString)
      End If
      bolJSLegend = False
      If J.Item("JSHOWLEGEND") IsNot Nothing Then
        If J.Item("JSHOWLEGEND").ToString.ToUpper = "TRUE" OrElse J.Item("JSHOWLEGEND").ToString.ToUpper = "1" Then
          bolJSLegend = True
        End If
      End If
      bolJShowGridLineX = False
      If J.Item("JSGLX") IsNot Nothing Then
        If J.Item("JSGLX").ToString.ToUpper = "TRUE" OrElse J.Item("JSGLX").ToString.ToUpper = "1" Then
          bolJShowGridLineX = True
        End If
      End If
      bolJShowGridLineY = False
      If J.Item("JSGLY") IsNot Nothing Then
        If J.Item("JSGLY").ToString.ToUpper = "TRUE" OrElse J.Item("JSGLY").ToString.ToUpper = "1" Then
          bolJShowGridLineY = True
        End If
      End If
      bolShowTitle = False
      If J.Item("JSSHOWTITLE") IsNot Nothing Then
        If J.Item("JSSHOWTITLE") = "1" OrElse J.Item("JSSHOWTITLE").ToString.ToUpper = "TRUE" Then bolShowTitle = True
      End If
      sngXIntVal = 0
      If J.Item("JSXINTERVAL") IsNot Nothing Then
        sngXIntVal = Val(J.Item("JSXINTERVAL"))
      End If
      sngYIntVal = 0
      If J.Item("JSYINTERVAL") IsNot Nothing Then
        sngYIntVal = Val(J.Item("JSYINTERVAL"))
      End If
      If J.Item("JANGLE") IsNot Nothing Then
        intAngle = Val(J.Item("JANGLE").ToString)
        If intAngle >= 180 Then
          intAngle = 179
        End If
        If intAngle <= -179 Then
          intAngle = -179
        End If
      End If
      If J.Item("LGINAREA") IsNot Nothing Then isLGInArea = J.Item("LGINAREA")
      If J.Item("ISSHAPEA") IsNot Nothing Then isShapeArea = J.Item("ISSHAPEA")
      If J.Item("ISSHAPED") IsNot Nothing Then isShapeDraw = J.Item("ISSHAPED")
      LGType = Val(J.ItemNull("LGTYPE"))
      LGAlign = Val(J.ItemNull("LGALIGN"))
      LGDock = Val(J.ItemNull("LGDOCK"))
      XBegin = Val(J.ItemNull("XBEGIN"))
      YBegin = Val(J.ItemNull("YBEGIN"))
      XEnding = Val(J.ItemNull("XENDING"))
      YEnding = Val(J.ItemNull("YENDING"))
      MainFont = Nothing
      MainColor = Color.Black
      If J.Item("MAINFONT") IsNot Nothing Then
        Dim strV() As String = J.Item("MAINFONT").ToString.Split(",")
        If strV.Length >= 4 Then
          MainFont = New Font(strV(0), CType(Val(strV(1)), Single), CType(Val(strV(2)), FontStyle))
          MainColor = Color.FromArgb(Val(strV(3)))
        End If
      End If
      LEGENDFont = Nothing
      LEGENDColor = Color.Black
      If J.Item("LEGENDFONT") IsNot Nothing Then
        Dim strV() As String = J.Item("LEGENDFONT").ToString.Split(",")
        If strV.Length >= 4 Then
          LEGENDFont = New Font(strV(0), CType(Val(strV(1)), Single), CType(Val(strV(2)), FontStyle))
          LEGENDColor = Color.FromArgb(Val(strV(3)))
        End If
      End If
      TITLEFont = Nothing
      TITLEColor = Color.Black
      If J.Item("TITLEFONT") IsNot Nothing Then
        Dim strV() As String = J.Item("TITLEFONT").ToString.Split(",")
        If strV.Length >= 4 Then
          TITLEFont = New Font(strV(0), CType(Val(strV(1)), Single), CType(Val(strV(2)), FontStyle))
          TITLEColor = Color.FromArgb(Val(strV(3)))
        End If
      End If
      SeriesFont = Nothing
      SeriesColor = Color.Black
      If J.Item("SERIESFONT") IsNot Nothing Then
        Dim strV() As String = J.Item("SERIESFONT").ToString.Split(",")
        If strV.Length >= 4 Then
          SeriesFont = New Font(strV(0), CType(Val(strV(1)), Single), CType(Val(strV(2)), FontStyle))
          SeriesColor = Color.FromArgb(Val(strV(3)))
        End If
      End If
    End Sub
  End Class
  Class JSeriesElement
    Enum jsorts As Integer
      None = 0
      ASC = 1
      DES = 2
    End Enum
    Private strJID As String = ""
    Property JID As String
      Get
        Return strJID
      End Get
      Set(value As String)
        strJID = value
      End Set
    End Property
    Private strJNAME As String = ""
    Property JName As String
      Get
        Return strJNAME
      End Get
      Set(value As String)
        strJNAME = value
      End Set
    End Property
    Private intJSTYPE As SeriesChartType = SeriesChartType.Point
    Property JSType As Integer
      Get
        Return intJSTYPE
      End Get
      Set(value As Integer)
        intJSTYPE = value
      End Set
    End Property
    Private strJCHARTAREA As String = ""
    Property JChartArea As String
      Get
        Return strJCHARTAREA
      End Get
      Set(value As String)
        strJCHARTAREA = value
      End Set
    End Property
    Private strJCONTENT As String = ""
    Property JCONTENT As String
      Get
        Return strJCONTENT
      End Get
      Set(value As String)
        strJCONTENT = value
      End Set
    End Property
    Private intJCOLOR As Integer = Color.Black.ToArgb
    Property JColor As Integer
      Get
        Return intJCOLOR
      End Get
      Set(value As Integer)
        intJCOLOR = value
      End Set
    End Property
    Private bolSHOWVALUE As Boolean = False
    Property IsShowValue As Boolean
      Get
        Return bolSHOWVALUE
      End Get
      Set(value As Boolean)
        bolSHOWVALUE = value
      End Set
    End Property
    Private intWidth As Integer = 3
    Property Width As Integer
      Get
        Return intWidth
      End Get
      Set(value As Integer)
        intWidth = value
        If intWidth <= 0 Then
          intWidth = 3
        End If
      End Set
    End Property
    Private intSort As jsorts = jsorts.None
    Property Sort As jsorts
      Get
        Return intSort
      End Get
      Set(value As jsorts)
        intSort = value
      End Set
    End Property
    Sub New(J As JSON)
      If J.Item("JID") IsNot Nothing Then strJID = J.Item("JID").ToString
      If J.Item("JNAME") IsNot Nothing Then strJNAME = J.Item("JNAME").ToString
      If J.Item("JSTYPE") IsNot Nothing Then intJSTYPE = Val(J.Item("JSTYPE").ToString)
      If J.Item("JCHARTAREA") IsNot Nothing Then strJCHARTAREA = J.Item("JCHARTAREA").ToString
      If J.Item("JCONTENT") IsNot Nothing Then strJCONTENT = J.Item("JCONTENT").ToString
      If J.Item("JCOLOR") IsNot Nothing Then
        If J.Item("JCOLOR").ToString <> "" Then
          intJCOLOR = Val(J.Item("JCOLOR").ToString)
        End If
      End If
      bolSHOWVALUE = False
      If J.Item("JSHOWVALUE") IsNot Nothing Then
        If J.Item("JSHOWVALUE") = "1" OrElse J.Item("JSHOWVALUE").ToString.ToUpper = "TRUE" Then
          bolSHOWVALUE = True
        End If
      End If
      If J.Item("JWIDTH") IsNot Nothing AndAlso J.Item("JWIDTH").ToString.Trim <> "" Then
        intWidth = Val(J.Item("JWIDTH").ToString)
      End If
      If J.Item("JSORT") IsNot Nothing Then
        Dim s As String = J.Item("JSORT").ToString.ToUpper
        If s = "0" Then
          intSort = jsorts.None
        ElseIf s = "1" Then
          intSort = jsorts.ASC
        ElseIf s = "2" Then
          intSort = jsorts.DES
        Else
          intSort = jsorts.None
        End If
      End If
    End Sub
  End Class
  Private clsJS As JSON
  Private nodes As New Dictionary(Of String, Object)
  Private clsJC As JSON 'For Chart本身的設定
  Private ctlChart As Chart
  Private aryPoint As New Dictionary(Of String, DataTable)
  Property JChart As Chart
    Get
      Return ctlChart
    End Get
    Set(value As Chart)
      ctlChart = value
    End Set
  End Property
  Sub New(strF As String)
    clsJS = New JSON(strF)
  End Sub
  Sub New(J As JSON)
    clsJS = J
  End Sub
  Public Overrides Function ToString() As String
    Return clsJS.ToString
  End Function
  Public Sub Init()
    nodes.Clear()
    If clsJS.GetAll.Count = 0 Then Return
    Dim aryT As Dictionary(Of String, Object) = clsJS.GetAll
    For Each s As String In aryT.Keys
      If s.StartsWith("*") Then
        nodes.Add(s, New JChartElement(aryT(s)))
      Else
        nodes.Add(s, New JSeriesElement(aryT(s)))
      End If
    Next
    SetToChart()
  End Sub
  Private Sub SetToChart()
    If ctlChart Is Nothing OrElse clsJS Is Nothing Then Return
    ctlChart.Series.Clear()
    ctlChart.ChartAreas.Clear()
    Dim fnts As Font = Nothing
    Dim fntC As Color = Color.Black
    For Each s As String In nodes.Keys
      If s.StartsWith("*") Then
        Dim e As JChartElement = CType(nodes(s), JChartElement)
        ctlChart.Name = e.JID
        ctlChart.Text = e.JNAME
        'ctlChart.Titles.Add("THIS").Text = e.JNAME

        For Each c As ChartArea In ctlChart.ChartAreas
          SetChartAreaGridLine(c.Name, e.IsShowGridLineX, e.IsShowGridLineY)
          If e.IsJ3D Then
            c.Area3DStyle.Enable3D = True
            c.Area3DStyle.PointDepth = e.J3DX
            c.Area3DStyle.PointGapDepth = e.J3DY
            c.Area3DStyle.Rotation = e.Angel
          Else
            c.Area3DStyle.Enable3D = False
            'c.Area3DStyle.PointDepth = e.J3DX
            'c.Area3DStyle.PointGapDepth = e.J3DY
            'c.Area3DStyle.Rotation = e.Angel
          End If
          c.AxisX.Interval = e.XInterval
          'If e.XInterval <> 0 Then
          '  'c.AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount
          'Else
          '  c.AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount
          'End If
          'If e.YInterval <> 0 Then
          c.AxisY.Interval = e.YInterval
          If e.XEnding <> 0 Or e.XBegin <> 0 Then
            c.AxisX.Maximum = e.XEnding
            c.AxisX.Minimum = e.XBegin
          End If
          If e.YEnding <> 0 Or e.YBegin <> 0 Then
            c.AxisY.Minimum = e.YBegin
            c.AxisY.Maximum = e.YEnding
          End If
          'c.AxisY.IntervalAutoMode = IntervalAutoMode.FixedCount
          'Else
          'c.AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount
          'End If
          If e.MainFont IsNot Nothing Then
            c.AxisX.LineColor = e.MainColor
            c.AxisX.LabelStyle.Font = e.MainFont
            c.AxisX.LabelStyle.ForeColor = e.MainColor
            c.AxisY.LineColor = e.MainColor
            c.AxisY.LabelStyle.Font = e.MainFont
            c.AxisY.LabelStyle.ForeColor = e.MainColor
            c.AxisX.MajorGrid.LineColor = e.MainColor
            c.AxisY.MajorGrid.LineColor = e.MainColor
          End If
        Next
        ctlChart.Titles.Clear()
        If e.isShowTitle Then
          With ctlChart.Titles.Add(e.JID)
            .Text = e.JNAME
            If e.TITLEFont IsNot Nothing Then
              .Font = e.TITLEFont
              .ForeColor = e.TITLEColor
            End If
          End With
        End If

        For Each l As Legend In ctlChart.Legends
          l.Enabled = e.IsJShowLegend
          If e.LEGENDFont IsNot Nothing Then
            l.Font = e.LEGENDFont
            l.ForeColor = e.LEGENDColor
          End If
        Next
      Else
        Dim e1 As JChartElement = CType(nodes("*00"), JChartElement)
        fnts = e1.SeriesFont
        fntC = e1.SeriesColor
        Dim e As JSeriesElement = CType(nodes(s), JSeriesElement)
        If ctlChart.ChartAreas.FindByName(e.JChartArea) Is Nothing Then
          ctlChart.ChartAreas.Add(e.JChartArea)
          If e1.isShapeArea Then
            ctlChart.ChartAreas(e.JChartArea).ShadowOffset = 5
          End If
          If e1.isLGInArea Then
            ctlChart.Legends(0).DockedToChartArea = e.JChartArea
          Else
            ctlChart.Legends(0).DockedToChartArea = ""
          End If
          ctlChart.Legends(0).Docking = e1.LGDock
          ctlChart.Legends(0).LegendStyle = e1.LGType
          ctlChart.Legends(0).Alignment = e1.LGAlign
        End If
        If ctlChart.Series.FindByName(e.JID) Is Nothing Then
          With ctlChart.Series.Add(e.JID)
            If e1.isShapeDraw Then
              ctlChart.Series(e.JID).ShadowOffset = 5
            End If
            .IsValueShownAsLabel = e.IsShowValue
            .LegendText = e.JName
            .LabelForeColor = fntC
            If fnts IsNot Nothing Then .Font = fnts
            .Color = Color.FromArgb(e.JColor)
            .ChartType = e.JSType
            .ChartArea = e.JChartArea
            .BorderWidth = e.Width
            .MarkerStyle = MarkerStyle.Circle
          End With
        End If
        End If
    Next
  End Sub
  Public Function AddSeries(strSID As String) As Series
    If ctlChart Is Nothing Then Return Nothing
    Dim s As Series = ctlChart.Series.FindByName(strSID)
    s.MarkerStyle = MarkerStyle.None
    If s IsNot Nothing Then Return s
    Return ctlChart.Series.Add(strSID)
  End Function
  Public Sub ClearSeries(strSID As String)
    Dim s As Series = AddSeries(strSID)
    If s Is Nothing Then Return
    s.Points.Clear()
    If aryPoint.ContainsKey(strSID) Then
      aryPoint(strSID).Rows.Clear()
    End If
  End Sub
  Public Sub SetSeries(strSID As String)
    If aryPoint.ContainsKey(strSID) = False Then
      Return
    End If
    Dim rs As DataTable = aryPoint(strSID)
    Dim s As Series = AddSeries(strSID)
    Dim e As JSeriesElement = CType(nodes(strSID), JSeriesElement)
    Dim dv As DataView = New DataView(rs)
    Select Case e.Sort
      Case JSeriesElement.jsorts.ASC
        dv.Sort = "ID ASC"
      Case JSeriesElement.jsorts.DES
        dv.Sort = "ID DESC"
    End Select
    For Each r As DataRowView In dv
      If r!XV.ToString.Trim = "" Then
        s.Points.AddY(Val(r!ID.ToString))
      Else
        s.Points.AddXY(r!XV.ToString.Trim, r!ID.ToString.Trim)
      End If
    Next
  End Sub
  Public Sub SetSerialMark(strSID As String, mark As System.Windows.Forms.DataVisualization.Charting.MarkerStyle, cs() As Color)
    Dim s As Series = ctlChart.Series.FindByName(strSID)
    For intI As Integer = 0 To cs.GetUpperBound(0)
      If intI >= s.Points.Count Then
        Exit For
      End If
      s.Points(intI).MarkerStyle = mark
      s.Points(intI).MarkerColor = cs(intI)
    Next
  End Sub
  Public Sub AddYValue(strSID As String, sngV As Double, Optional XL As String = "")
    Dim s As Series = AddSeries(strSID)
    If s Is Nothing Then Return
    Dim rs As DataTable = Nothing
    If aryPoint.ContainsKey(strSID) Then
      rs = aryPoint(strSID)
    Else
      rs = New DataTable
      rs.TableName = strSID
      rs.Columns.Add("ID", GetType(Double))
      rs.Columns.Add("XV")
      rs.Columns.Add("MARK")
      aryPoint.Add(strSID, rs)
    End If
    If XL = "" Then
      rs.Rows.Add(sngV)
    Else
      rs.Rows.Add(sngV, XL)
    End If
  End Sub

  Public Sub AddYValue(strID As String, src As DataTable, strN As String)
    If ctlChart.Series.FindByName(strID) Is Nothing Then Return
    Dim e As JSeriesElement = CType(nodes(strID), JSeriesElement)
    Dim dv As DataView = New DataView(src)
    Select Case e.Sort
      Case JSeriesElement.jsorts.ASC
        dv.Sort = strN & " " & "ASC"
      Case JSeriesElement.jsorts.DES
        dv.Sort = strN & " " & "DESC"
      Case JSeriesElement.jsorts.None
        dv.Sort = ""
    End Select
    ctlChart.Series(strID).Points.DataBindY(dv, strN)
  End Sub

  Public Sub SetChartAreaGridLine(strN As String, bolX As Boolean, bolY As Boolean)
    If bolX = False Then
      SetChartAreaGridLine(strN, 0, ctlChart.ChartAreas(strN).AxisY.MajorGrid.LineWidth)
    Else
      SetChartAreaGridLine(strN, 1, ctlChart.ChartAreas(strN).AxisY.MajorGrid.LineWidth)
    End If
    If bolY = False Then
      SetChartAreaGridLine(strN, ctlChart.ChartAreas(strN).AxisX.MajorGrid.LineWidth, 0)
    Else
      SetChartAreaGridLine(strN, ctlChart.ChartAreas(strN).AxisX.MajorGrid.LineWidth, 1)
    End If
  End Sub
  Public Sub SetChartAreaGridLine(strN As String, intX As Integer, intY As Integer)
    If ctlChart.ChartAreas.FindByName(strN) Is Nothing Then Return
    With ctlChart.ChartAreas(strN)
      .AxisX.MajorGrid.LineWidth = intX
      .AxisY.MajorGrid.LineWidth = intY
    End With
  End Sub

  Public Function GetElements() As Dictionary(Of String, Object)
    Return nodes
  End Function

  Public Function GetElement(strID As String) As Object
    If nodes.ContainsKey(strID) Then
      Return nodes(strID)
    Else
      Return Nothing
    End If
  End Function
End Class