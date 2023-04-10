Imports System.ComponentModel
Public Class clsSCALEAUTO

  Implements IDisposable

  Private disposed As Boolean = False        ' To detect redundant calls

  ' IDisposable
  Protected Overridable Sub Dispose(ByVal disposing As Boolean)
    If Not Me.disposed Then
      If disposing Then
        ' TODO: free unmanaged resources when explicitly called
        RaiseEvent Closing(Me)
      End If
      tim2.Stop()
      tim2.Close()
      bolCloseing = True
      System.Threading.Thread.Sleep(1000)
      If sCCom.IsOpen Then
        sCCom.RtsEnable = False
        sCCom.Close()
      End If
      If sPCOM.IsOpen Then sPCOM.Close()
      tim2.Dispose()
      ' TODO: free shared unmanaged resources
    End If
    Me.disposed = True
  End Sub

#Region " IDisposable Support "
  ' This code added by Visual Basic to correctly implement the disposable pattern.
  Public Sub Dispose() Implements IDisposable.Dispose
    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    Dispose(True)
    GC.SuppressFinalize(Me)
  End Sub

  Protected Overrides Sub Finalize()
    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    Dispose(False)
    MyBase.Finalize()
  End Sub
#End Region

  Event Log(ByVal s As clsSCALEAUTO, ByVal strM As String)
  Event TouchSW(ByVal s As clsSCALEAUTO, ByVal intI As Integer)
  Event Closing(ByVal s As clsSCALEAUTO)
  Private sPCOM As New IO.Ports.SerialPort()
  Private sCCom As New IO.Ports.SerialPort
  Protected strCOMVAL As String = ""
  Protected dblCWGT As Double = 0
  Protected dblLWGT As Double = 0
  Protected intSTBC As Integer = 0
  Protected dblSWGT As Double = 0
  Protected dblNZero As Double = 0
  Protected intRunState As Integer = 0
  Protected bolRun As Boolean = False
  Protected bolHalt As Boolean = False
  Protected bolNZero As Boolean = False
  Protected bolHasWgt As Boolean = False
  Protected bolAutoGoBack As Boolean = True
  Protected intAutoMode As Integer = 0
  Private tim2 As New System.Timers.Timer
  Private bolCloseing As Boolean = False
  Private strLFatch As String = ""
  Private intLFatch As Integer = 0
  Private intComReOpen As Integer = 0
  Private intComActive As Integer = 0
  Private intStab As Integer = 0
  Private dblStab As Double = 0
  Private strName As String = ""
  Private bolNZTime As Boolean = False
  Private intNZTime As Integer = 0
  Private intNZSet As Integer = 2
  Private bolChgSw As Boolean = False
  Private intBoxDelay As Integer = 0
  Private intWgtType As WgtType = WgtType.TpZero Or WgtType.TpAutoByComm
  Private dblAttch As Double = 0
  Private strLine As String = "1"
  Private strLog As String = ""
  Private bolLog As Boolean = False
  Event OnScale(s As Object, bolTouch As Boolean)

  Public Property LogSave As Boolean
    Get
      Return bolLog
    End Get
    Set(value As Boolean)
      bolLog = value
    End Set
  End Property
  Public Enum WgtType
    TpZero = 0            '標準模式
    TpSmoothZero = 1      '以上次穩定值*0.4為歸零點
    TpAttach = 2          '無須歸零，但請特別注意一定要放在磅秤上穩定才能按鈕或刷碼
    TpAutoByComm = 16     '使用另外一個COMM PORT控制進入出去
  End Enum
  ''' <summary>
  ''' 過磅模式狀態
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property WeightingType As WgtType
    Get
      Return intWgtType
    End Get
    Set(value As WgtType)
      intWgtType = value
    End Set
  End Property
  ''' <summary>
  ''' 上磅後自動結算時間，ScaleMode=4 只會出現一次。
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property NearZeroDelay As Integer
    Get
      Return intNZSet
    End Get
    Set(value As Integer)
      intNZSet = value
    End Set
  End Property
  ''' <summary>
  ''' 取得或設定自動過磅方式 1:標準，2:屠體
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property AutoMode As Integer
    Get
      Return intAutoMode
    End Get
    Set(value As Integer)
      intAutoMode = value
    End Set
  End Property
  Sub New()
    tim2.Interval = 200
    tim2.AutoReset = False
    AddHandler tim2.Elapsed, AddressOf TimeSCALE
  End Sub
  ''' <summary>
  ''' 是否自動回復觸發信號
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property AutoGoBack() As Boolean
    Get
      Return bolAutoGoBack
    End Get
    Set(ByVal value As Boolean)
      bolAutoGoBack = value
    End Set
  End Property
  ''' <summary>
  ''' 設定或取得磅秤名
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property Name() As String
    Get
      Return strName
    End Get
    Set(ByVal value As String)
      strName = value
    End Set
  End Property
  Public Function Version() As String
    Return "clsSCALEAUTO V1.2 2014/3/6 for YS"
  End Function
  ''' <summary>
  ''' 接近歸零點位置
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property NearZero() As Double
    Get
      Return dblNZero
    End Get
    Set(ByVal value As Double)
      dblNZero = value
    End Set
  End Property
  ''' <summary>
  ''' 二箱間的延遲時間限制
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property BoxDelay() As Double
    Get
      Return intBoxDelay * tim2.Interval / 1000
    End Get
    Set(ByVal value As Double)
      intBoxDelay = value * 1000 / tim2.Interval
    End Set
  End Property
  ''' <summary>
  ''' 設定或取得線別
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property Line() As String
    Get
      Return strLine
    End Get
    Set(ByVal value As String)
      strLine = value
    End Set
  End Property
  ''' <summary>
  ''' 取得磅秤傳送最後字串
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public ReadOnly Property LastFacth() As String
    Get
      Return strLFatch
    End Get
  End Property
  ''' <summary>
  ''' 主磅秤抓取穩定值容許誤差
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property Stabile() As Double
    Get
      Return dblStab
    End Get
    Set(ByVal value As Double)
      dblStab = value
    End Set
  End Property
  ''' <summary>
  ''' 主磅秤抓取穩定次數
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property StabileTime() As Integer
    Get
      Return intStab
    End Get
    Set(ByVal value As Integer)
      intStab = value
    End Set
  End Property
  ''' <summary>
  ''' 設定或取得控制線名
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property ControlPort() As String
    Get
      Return sCCom.PortName
    End Get
    Set(ByVal value As String)
      If value <> "" And (intWgtType And WgtType.TpAutoByComm) <> 0 Then
        sCCom.PortName = value
      End If
    End Set
  End Property
  ''' <summary>
  ''' 設定或取得主磅秤COMM PORT 名
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property ComPort() As String
    Get
      Return sPCOM.PortName
    End Get
    Set(ByVal value As String)
      If value = "" Then Return
      sPCOM.PortName = value
    End Set
  End Property
  ''' <summary>
  ''' 設定或取得主磅秤COMM 設定值
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property Setting() As String
    Get
      Dim strV As String = sPCOM.BaudRate & "," & sPCOM.DataBits & ","
      Select Case sPCOM.Parity
        Case IO.Ports.Parity.Even
          strV &= "E,"
        Case IO.Ports.Parity.Mark
          strV &= "M,"
        Case IO.Ports.Parity.None
          strV &= "N,"
        Case IO.Ports.Parity.Odd
          strV &= "O,"
        Case IO.Ports.Parity.Space
          strV &= "S,"
      End Select
      Select Case sPCOM.StopBits
        Case IO.Ports.StopBits.None
          strV &= "0"
        Case IO.Ports.StopBits.One
          strV &= "1"
        Case IO.Ports.StopBits.OnePointFive
          strV &= "1.5"
        Case IO.Ports.StopBits.Two
          strV &= "2"
      End Select
      Return strV
    End Get
    Set(ByVal value As String)
      Dim strv() As String = value.Split(",")
      sPCOM.BaudRate = Val(strv(0))
      sPCOM.DataBits = Val(strv(1))
      Select Case strv(2).ToUpper.Trim
        Case "E"
          sPCOM.Parity = IO.Ports.Parity.Even
        Case "O"
          sPCOM.Parity = IO.Ports.Parity.Odd
        Case "M"
          sPCOM.Parity = IO.Ports.Parity.Mark
        Case "S"
          sPCOM.Parity = IO.Ports.Parity.Space
        Case Else
          sPCOM.Parity = IO.Ports.Parity.None
      End Select
      Select Case strv(3).ToString.Trim
        Case "0"
          sPCOM.StopBits = IO.Ports.StopBits.None
        Case "1"
          sPCOM.StopBits = IO.Ports.StopBits.One
        Case "1.5"
          sPCOM.StopBits = IO.Ports.StopBits.OnePointFive
        Case "2"
          sPCOM.StopBits = IO.Ports.StopBits.Two
      End Select
      sPCOM.Handshake = IO.Ports.Handshake.None
      'sPCOM.DtrEnable = True
    End Set
  End Property
  ''' <summary>
  ''' 設定或取得主磅秤COMM 設定值
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property ctlSetting() As String
    Get
      Dim strV As String = sCCom.BaudRate & "," & sPCOM.DataBits & ","
      Select Case sCCom.Parity
        Case IO.Ports.Parity.Even
          strV &= "E,"
        Case IO.Ports.Parity.Mark
          strV &= "M,"
        Case IO.Ports.Parity.None
          strV &= "N,"
        Case IO.Ports.Parity.Odd
          strV &= "O,"
        Case IO.Ports.Parity.Space
          strV &= "S,"
      End Select
      Select Case sCCom.StopBits
        Case IO.Ports.StopBits.None
          strV &= "0"
        Case IO.Ports.StopBits.One
          strV &= "1"
        Case IO.Ports.StopBits.OnePointFive
          strV &= "1.5"
        Case IO.Ports.StopBits.Two
          strV &= "2"
      End Select
      Return strV
    End Get
    Set(ByVal value As String)
      If (intWgtType And WgtType.TpAutoByComm) = 0 Then Return
      Dim strv() As String = value.Split(",")
      sCCom.BaudRate = Val(strv(0))
      sCCom.DataBits = Val(strv(1))
      Select Case strv(2).ToUpper.Trim
        Case "E"
          sCCom.Parity = IO.Ports.Parity.Even
        Case "O"
          sCCom.Parity = IO.Ports.Parity.Odd
        Case "M"
          sCCom.Parity = IO.Ports.Parity.Mark
        Case "S"
          sCCom.Parity = IO.Ports.Parity.Space
        Case Else
          sCCom.Parity = IO.Ports.Parity.None
      End Select
      Select Case strv(3).ToString.Trim
        Case "0"
          sCCom.StopBits = IO.Ports.StopBits.None
        Case "1"
          sCCom.StopBits = IO.Ports.StopBits.One
        Case "1.5"
          sCCom.StopBits = IO.Ports.StopBits.OnePointFive
        Case "2"
          sCCom.StopBits = IO.Ports.StopBits.Two
      End Select
      sCCom.Handshake = IO.Ports.Handshake.None
      'sCCom.DtrEnable = True
    End Set
  End Property
  ''' <summary>
  ''' 這一箱已經磅好了
  ''' </summary>
  ''' <remarks></remarks>
  Public Sub Go()
    bolHasWgt = False
    If sCCom.IsOpen = True Then
      If intAutoMode = 1 Then
        sCCom.RtsEnable = True
      ElseIf AutoMode = 2 Then
        sCCom.Write("#010003" & vbCr)
      End If
    End If
  End Sub
  Public Sub GoBack()
    If sCCom.IsOpen = True Then
      If AutoMode = 1 Then
        sCCom.RtsEnable = False
      ElseIf AutoMode = 2 Then
        sCCom.Write("#010000" & vbCr)
      End If
    End If
  End Sub
  ''' <summary>
  ''' 取得目前可靠主磅秤值，有物件時回報穩定重，變動中回報即時重，將近零則回報0
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public ReadOnly Property GetWGT() As Double      '這部分抓取磅秤資料
    Get
      If bolHasWgt Then
        Return dblSWGT
      ElseIf bolNZero And dblCWGT <= dblNZero Then
        Return 0
      Else
        Return dblCWGT
      End If
    End Get
  End Property
  ''' <summary>
  ''' 取得是否已經歸零?
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public ReadOnly Property isZero() As Boolean
    Get
      Return bolNZero
    End Get
  End Property
  ''' <summary>
  ''' 磅秤狀態
  ''' </summary>
  ''' <value></value>
  ''' <returns>
  ''' 0:實際磅秤是在零點
  ''' 1:磅秤從零點往上增加
  ''' 2:磅秤已經穩定取重
  ''' 3:磅秤還在移出中
  ''' </returns>
  ''' <remarks></remarks>
  Public Overridable ReadOnly Property ScaleMode() As Integer
    Get
      If bolNZero = True And dblCWGT <= dblNZero Then    '磅秤已經為0
        Return 0
      ElseIf bolNZero = True And dblCWGT > dblNZero Then '磅秤曾經歸零還在載重中
        bolNZTime = False
        intNZTime = intNZSet
        Return 1
      ElseIf bolNZTime = True Then
        bolNZTime = False
        intNZTime = 0
        Return 4
      ElseIf bolNZero = False And bolHasWgt = False Then '磅秤移出中尚未移出
        Return 3
      ElseIf (intWgtType And 15) = WgtType.TpAttach And bolHasWgt = False Then
        bolNZTime = False
        intNZTime = intNZSet
        Return 1
      Else
        If intNZTime > 0 Then
          intNZTime = 0
          bolNZTime = False
          RaiseEvent OnScale(Me, False)
          Return 4
        End If
        Return 2                                         '磅秤重量已經穩定在磅秤上
      End If
    End Get
  End Property
  Public Function isReady() As Boolean
    Return sPCOM.IsOpen
  End Function
  ''' <summary>
  ''' 啟動磅秤擷取
  ''' </summary>
  ''' <remarks></remarks>
  Public Sub StartComm()
    If sPCOM.PortName = "" Or sPCOM.PortName.ToUpper = "NONE" Then Return
    If sPCOM.IsOpen Then sPCOM.Close()
    If (intWgtType And WgtType.TpAutoByComm) <> 0 Then
      If sCCom.PortName <> "" Then
        If sCCom.IsOpen Then sCCom.Close()
      End If
    End If
    If sPCOM.IsOpen = False Then sPCOM.Open()
    If (intWgtType And WgtType.TpAutoByComm) <> 0 Then
      Try
        If sCCom.IsOpen = False Then
          sCCom.Open()
          sCCom.RtsEnable = False
        End If
      Catch ex As Exception
        MsgBox("連接埠連結錯誤：" & ex.Message)
      End Try
    End If
    tim2.Start()
  End Sub
  Private Sub TimeSCALE(ByVal s As Object, ByVal e As System.Timers.ElapsedEventArgs)
    If sCCom.IsOpen = True Then
      Dim strV1 As String = sCCom.ReadExisting
    End If
    If sPCOM.IsOpen = False Then
      strLFatch = "ERROR"
      Return
    End If
    If sPCOM.BytesToRead = 0 Then
      tim2.Start()
      Return
    End If
    strCOMVAL &= sPCOM.ReadExisting
    Dim strV() As String = strCOMVAL.Split(vbCrLf.ToCharArray)
    If bolLog Then
      strLog &= "T:" & Now.ToString & "," & strCOMVAL
      If strLog.Length > 5000 Then
        RaiseEvent Log(Me, strLog)
        strLog = ""
      End If
    End If
    strCOMVAL = strV(strV.GetUpperBound(0))
    For intI As Integer = 0 To strV.GetUpperBound(0) - 1
      If strV(intI).Trim.Length = 0 Then Continue For
      strLFatch = strV(intI)
      'Dim strK() As String = strV(intI).Split(",")
      Dim strM As String = strV(intI)
      If strM.Length >= 7 Then
        dblCWGT = Val(strM)
      Else
        Continue For
      End If
      If dblCWGT < dblNZero Or dblCWGT < dblAttch Then
        intSTBC = 0
        If dblAttch > dblNZero Then
          bolNZTime = False
          intNZTime = intNZSet
        End If
        dblAttch = 0
        bolHasWgt = False
        bolNZero = True
        If bolAutoGoBack Then
          GoBack()
        End If
      Else
        If Math.Abs(dblCWGT - dblLWGT) <= dblStab Then
          intSTBC += 1
          If intSTBC >= intStab Then
            intSTBC = intStab
            dblSWGT = dblCWGT
            If (intWgtType And 15) = WgtType.TpSmoothZero Then
              dblAttch = dblSWGT * 0.4
            Else
              dblAttch = 0
            End If
            If bolNZero And bolHalt = False Then
              bolHasWgt = True
              If (intWgtType And 15) = WgtType.TpAttach Then
                bolNZero = True
              Else
                bolNZero = False
              End If
            End If
          End If
        Else
          intSTBC = 0
          If (intWgtType And 15) = WgtType.TpAttach And Math.Abs(dblCWGT - dblLWGT) > 0.2 Then
            bolHasWgt = False
          End If
        End If
      End If
      If intNZTime > 0 Then
        If dblLWGT < (dblCWGT - 0.5) Then
          intNZTime -= 1
          If intNZTime = 0 Then
            bolNZTime = True
            RaiseEvent OnScale(Me, True)
          End If
        ElseIf (dblLWGT - 0.1) > dblCWGT Then
          intNZTime = intNZSet
        End If
      End If
      dblLWGT = dblCWGT
    Next
    tim2.Start()
  End Sub
  ''' <summary>
  ''' 取得主磅秤目前重量值
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public ReadOnly Property CurWgt() As Double
    Get
      Return dblCWGT
    End Get
  End Property
  ''' <summary>
  ''' 取得最新的穩定重量值
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public ReadOnly Property StabWgt() As Double
    Get
      Return dblSWGT
    End Get
  End Property
End Class
