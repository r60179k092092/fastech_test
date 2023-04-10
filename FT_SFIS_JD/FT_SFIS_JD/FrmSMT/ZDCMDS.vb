Public Enum ZDAttbs As Integer
  Scan = 0
  Func = 1
  ToSet = 2
  Mark = 3
End Enum
Public Class ZDCMDS
  Private ZDS() As ZDCMD = {
    New ZDCMD("A", BIG2GB("刷員工號"), ZDAttbs.Scan),
    New ZDCMD("C", BIG2GB("刷料卷新料號"), ZDAttbs.Scan),
    New ZDCMD("D", BIG2GB("刷Date Code"), ZDAttbs.Scan),
    New ZDCMD("E", BIG2GB("刷Reel ID"), ZDAttbs.Scan),
    New ZDCMD("F", BIG2GB("刷規格"), ZDAttbs.Scan),
    New ZDCMD("G", BIG2GB("刷Lot No."), ZDAttbs.Scan),
    New ZDCMD("H", BIG2GB("刷FEEDER ID"), ZDAttbs.Scan),
    New ZDCMD("I", BIG2GB("刷料站ID"), ZDAttbs.Scan),
    New ZDCMD("J", BIG2GB("刷確認員工號"), ZDAttbs.Scan),
    New ZDCMD("K", BIG2GB("刷IPQC員工號"), ZDAttbs.Scan),
    New ZDCMD("L", BIG2GB("刷FEEDER舊料號"), ZDAttbs.Scan),
    New ZDCMD("M", BIG2GB("檢驗FEEDER為空"), ZDAttbs.Func),
    New ZDCMD("N", BIG2GB("檢驗FEEDER綁料站"), ZDAttbs.Func),
    New ZDCMD("O", BIG2GB("FEEDER綁定料號"), ZDAttbs.Func),
    New ZDCMD("P", BIG2GB("FEEDER綁定料站"), ZDAttbs.Func),
    New ZDCMD("Q", BIG2GB("FEEDER料站更換新料卷"), ZDAttbs.Func),
    New ZDCMD("R", BIG2GB("驗證掛料全部符合"), ZDAttbs.Func),
    New ZDCMD("R1", BIG2GB("是否全部掛料完成"), ZDAttbs.Func),
    New ZDCMD("R2", BIG2GB("BOM表驗料並存檔"), ZDAttbs.Func),
    New ZDCMD("S0", BIG2GB("啟動SMT"), ZDAttbs.Func),
    New ZDCMD("S1", BIG2GB("停止SMT"), ZDAttbs.Func),
    New ZDCMD("S2", BIG2GB("啟動Alarm"), ZDAttbs.Func),
    New ZDCMD("S3", BIG2GB("停止Alarm"), ZDAttbs.Func),
    New ZDCMD("T", BIG2GB("復驗料站Feeder單站符合"), ZDAttbs.Func),
    New ZDCMD("U", BIG2GB("複驗FEEDER綁料號已完成"), ZDAttbs.Func),
    New ZDCMD("U1", BIG2GB("檢驗料號符合料站表"), ZDAttbs.Func),
    New ZDCMD("V1", BIG2GB("清除FEEDER綁定料號及料站"), ZDAttbs.Func),
    New ZDCMD("V2", BIG2GB("清除暫存區紀錄"), ZDAttbs.Func),
    New ZDCMD("V3", BIG2GB("全部復驗所有料站"), ZDAttbs.Func),
    New ZDCMD("W", BIG2GB("反復到標志"), ZDAttbs.Mark),
    New ZDCMD("X", BIG2GB("設定標志位置"), ZDAttbs.Mark),
    New ZDCMD("X0", BIG2GB("設定下一區段"), ZDAttbs.Mark),
    New ZDCMD("Y", BIG2GB("刷入OK條碼"), ZDAttbs.Scan),
    New ZDCMD("Z0", BIG2GB("設定為下崗模式(機器停車)"), ZDAttbs.ToSet),
    New ZDCMD("Z1", BIG2GB("設定為上崗掛料運行模式"), ZDAttbs.ToSet),
    New ZDCMD("Z2", BIG2GB("設定為上崗FEEDER管理模式"), ZDAttbs.ToSet),
    New ZDCMD("Z3", BIG2GB("設定為上崗QC驗料模式"), ZDAttbs.ToSet),
    New ZDCMD("Z4", BIG2GB("設定暫停使用防錯料模式"), ZDAttbs.ToSet),
    New ZDCMD("Z1ON", BIG2GB("取得上崗掛料運行模式"), ZDAttbs.ToSet),
    New ZDCMD("Z2ON", BIG2GB("取得上崗FEEDER管理模式"), ZDAttbs.ToSet),
    New ZDCMD("Z3ON", BIG2GB("取得上崗QC驗料模式"), ZDAttbs.ToSet)
   }
  'New ZDCMD("B", BIG2GB("刷工單號"), ZDAttbs.Scan),
  'New ZDCMD("V2", BIG2GB("清除料站所有掛料"), ZDAttbs.Func),
  Private aryC As New Dictionary(Of String, ZDCMD)
  Public Function GetCMD(strC As String) As ZDCMD
    If aryC.Count = 0 Then
      For Each c As ZDCMD In ZDS
        aryC.Add(c.Name, c)
      Next
    End If
    If aryC.ContainsKey(strC) = True Then
      Return aryC(strC)
    End If
    Return Nothing
  End Function
  Public Function GetAllCmd() As DataTable
    Dim rs As New DataTable
    rs.TableName = "ZDCMDS"
    rs.Columns.Add(BIG2GB("代碼"), GetType(String))
    rs.Columns.Add(BIG2GB("說明"), GetType(String))
    rs.Columns.Add(BIG2GB("類別"), GetType(String))
    For Each c As ZDCMD In ZDS
      rs.Rows.Add(c.Name, c.Desc, c.Attribute.ToString)
    Next
    Return rs
  End Function
End Class

Public Class ZDCMDTable
  Private intPGCnt As Integer = 0
  Private zdC As ZDCMDS = Nothing
  Private WithEvents DG As DataGridView = Nothing
  Private intHideMode As Integer = 0
  Private strName As String = ""
  Private strCmdID As String = ""
  Private strDesc As String = ""
  Private bolRuning As Boolean = False
  Private bolHdl As Boolean = False
  Private Ths1 As System.Threading.Thread
  Private aryCmd As New ArrayList
  Private strRunMode As String = ""
  Private bolKey As Boolean = False
  Private bolOk As Boolean = False
  Private bolHalt As Boolean = False
  Private csContl As Control = Nothing
  Private bolExit As Boolean = False
  Private strInput As String = ""
  Event ExecScanBegin(s As ZDCMDTable, intPG As Integer, strCode As String, ByRef cs As Control)
  Event ExecScanEnd(s As ZDCMDTable, intPG As Integer, strCode As String, ByRef bolOK As Boolean)
  Event ExecCommand(s As ZDCMDTable, intPG As Integer, strCode As String, ByRef bolOK As Boolean)
  Event ExecEnd(s As ZDCMDTable, strE As String)
  Event ExecFunckey(s As ZDCMDTable, intFKey As Integer)
  Sub New()
  End Sub
  Sub New(strV As String)
    SetCmds(strV)
  End Sub
  ''' <summary>
  ''' 設定或取得類別物件名稱
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property Name As String
    Get
      Return strName
    End Get
    Set(value As String)
      strName = value
    End Set
  End Property
  ''' <summary>
  ''' 設定或取得指令碼
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property CommandID As String
    Get
      Return strCmdID
    End Get
    Set(value As String)
      strCmdID = value
    End Set
  End Property
  ''' <summary>
  ''' 設定或取得指令說明
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property Description As String
    Get
      Return strDesc
    End Get
    Set(value As String)
      strDesc = value
    End Set
  End Property
  ''' <summary>
  ''' 設定或取得一個DataGridView作為本系統明確介面
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property DGS As DataGridView
    Get
      Return DG
    End Get
    Set(value As DataGridView)
      DG = value
    End Set
  End Property
  ''' <summary>
  ''' 設定或取得一個ZDCMDS物件(必要)
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property CMDS As ZDCMDS
    Get
      Return zdC
    End Get
    Set(value As ZDCMDS)
      zdC = value
    End Set
  End Property
  ''' <summary>
  ''' 設定或取得隱藏模式 0:標準三欄 1:執行模式一欄 2:全現模式
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property HideMode As Integer
    Get
      Return intHideMode
    End Get
    Set(value As Integer)
      intHideMode = value
    End Set
  End Property
  ''' <summary>
  ''' 設定或取得程序執行位置
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property ProgCnt As Integer
    Get
      Return intPGCnt
    End Get
    Set(value As Integer)
      intPGCnt = value
    End Set
  End Property
  ''' <summary>
  ''' 設定或取得啟動程式執行中
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property ProgRuning As Boolean
    Get
      Return bolRuning
    End Get
    Set(value As Boolean)
      bolRuning = value
    End Set
  End Property
  ''' <summary>
  ''' 從頭啟動程式
  ''' </summary>
  ''' <remarks></remarks>
  Public Sub Start()
    'Debug.Print(Now & " Start , " & bolHalt.ToString & "," & bolRuning.ToString)
    intPGCnt = 0
    aryCmd.Clear()
    For Each r As DataGridViewRow In DG.Rows
      Dim intM As ZDAttbs
      Select Case GCell(r.Cells("C6")).ToUpper
        Case "SCAN"
          intM = ZDAttbs.Scan
        Case "FUNC"
          intM = ZDAttbs.Func
        Case "MARK"
          intM = ZDAttbs.Mark
        Case "TOSET"
          intM = ZDAttbs.ToSet
      End Select
      Dim c As New ZDCMD(GCell(r.Cells("C4")), GCell(r.Cells("C1")), intM)
      c.Yes = GCell(r.Cells("C3"))
      c.No = GCell(r.Cells("C2"))
      aryCmd.Add(c)
    Next
    strRunMode = ""
    While bolExit = True
      bolRuning = False
      System.Threading.Thread.Sleep(20)
    End While
    Ths1 = New System.Threading.Thread(AddressOf Working)
    intPGCnt = 0
    bolHalt = True
    Ths1.Start()
    'Debug.Print(Now & " Start")
  End Sub
  Public Property Halt As Boolean
    Get
      Return bolHalt
    End Get
    Set(value As Boolean)
      bolHalt = value
    End Set
  End Property
  Private Function isCellNull(c As DataGridViewCell) As Boolean
    If c Is Nothing OrElse c.Value Is Nothing OrElse c.Value Is DBNull.Value Then Return True
    Return False
  End Function
  Private Function GCell(c As DataGridViewCell) As String
    If isCellNull(c) = True Then Return ""
    Return c.Value.ToString.Trim
  End Function
  Private Function LookPG(strC) As Integer
    If strC = "" Then Return intPGCnt + 1
    Dim intI As Integer = 0
    For intI = intPGCnt + 1 To aryCmd.Count - 1
      With CType(aryCmd(intI), ZDCMD)
        If .Name = "X" Then
          If .Yes = strC Or .No = strC Then
            Return intI
          End If
        End If
      End With
    Next
    For intI = 0 To intPGCnt - 1
      With CType(aryCmd(intI), ZDCMD)
        If .Name = "X" Then
          If .Yes = strC Or .No = strC Then
            Return intI
          End If
        End If
      End With
    Next
    Return intPGCnt + 1
  End Function
  Private Sub ToCmdWork(strC As String)
    Select Case strC.Trim.ToUpper
      Case "$%OK"
        Dim intI As Integer = 0
        For intI = intPGCnt + 1 To aryCmd.Count - 1
          With CType(aryCmd(intI), ZDCMD)
            If .Name = "X0" Then
              intPGCnt = intI
              Return
            End If
          End With
        Next
        For intI = 0 To intPGCnt - 1
          With CType(aryCmd(intI), ZDCMD)
            If .Name = "X0" Then
              intPGCnt = intI
              Return
            End If
          End With
        Next
        bolRuning = False
    End Select
  End Sub
  Private Sub Working()
    Dim bolT As Boolean = False
    bolRuning = True
    bolExit = True
    'Debug.Print(Now & " " & bolHalt.ToString & " RUN," & intPGCnt & "," & aryCmd.Count)
    While bolRuning And intPGCnt < aryCmd.Count And intPGCnt >= 0
      'Debug.Print("T" & intPGCnt & "," & bolHalt)
      If bolHalt Then Continue While
      Dim c As ZDCMD = aryCmd(intPGCnt)
      bolT = False
      Select Case c.Attribute
        Case ZDAttbs.Func
          RaiseEvent ExecCommand(Me, intPGCnt, c.Name, bolT)
          If bolT = True Then
            If c.Yes <> "" Then
              intPGCnt = LookPG(c.Yes)
            Else
              intPGCnt += 1
            End If
          Else
            If c.No <> "" Then
              intPGCnt = LookPG(c.No)
            Else
              intPGCnt += 1
            End If
          End If
        Case ZDAttbs.Scan
          strInput = ""
          RaiseEvent ExecScanBegin(Me, intPGCnt, c.Name, csContl)
          If csContl Is Nothing Then
            intPGCnt += 1
            Continue While
          End If
          bolOk = False
          bolKey = True
          While bolOk = False And bolRuning
            'Debug.Print("T" & intPGCnt & "," & bolHalt)
            System.Threading.Thread.Sleep(20)
          End While
          bolKey = False
          If bolOk = False Or bolRuning = False Then
            Continue While
          Else
            If csContl.Text.Trim.StartsWith("$%") Then
              ToCmdWork(csContl.Text.Trim)
              bolT = False
            Else
              RaiseEvent ExecScanEnd(Me, intPGCnt, c.Name, bolT)
            End If
          End If
          If bolT = True Then
            intPGCnt += 1
          End If
        Case ZDAttbs.Mark
          If c.Name = "W" Then '無條件跳位
            intPGCnt = LookPG(c.No)
          ElseIf c.Name = "X" Then
            intPGCnt += 1
          Else
            intPGCnt += 1
          End If
        Case ZDAttbs.ToSet
          RaiseEvent ExecCommand(Me, intPGCnt, c.Name, bolT)
          If bolT = True Then
            intPGCnt = LookPG(c.Yes)
          Else
            intPGCnt = LookPG(c.No)
          End If
          strRunMode = c.Name
      End Select
    End While
    RaiseEvent ExecEnd(Me, "Run End " & strName)
    'Debug.Print(Now & " END")
    bolRuning = False
    bolExit = False
  End Sub
  Public Sub SetCmds(strV As String)
    Dim strV1() As String = strV.Split("^")
    If DG Is Nothing Then Return
    If DG.Columns.Count = 0 Then
      DG.Columns.Add("C1", BIG2GB("指令說明"))
      DG.Columns.Add("C2", BIG2GB("NG退回"))
      DG.Columns.Add("C3", BIG2GB("OK下一步"))
      DG.Columns.Add("C4", BIG2GB("代碼"))
      DG.Columns.Add("C5", BIG2GB("OKNG"))
      DG.Columns.Add("C6", BIG2GB("屬性"))
    End If
    Select Case intHideMode
      Case 0
        DG.Columns("C2").Visible = True
        DG.Columns("C3").Visible = True
        DG.Columns("C4").Visible = False
        DG.Columns("C5").Visible = False
        DG.Columns("C6").Visible = False
        DG.Columns("C1").ReadOnly = True
        DG.Columns("C2").ReadOnly = False
        DG.Columns("C3").ReadOnly = False
      Case 1, 3
        DG.Columns("C2").Visible = False
        DG.Columns("C3").Visible = False
        DG.Columns("C4").Visible = False
        DG.Columns("C5").Visible = False
        DG.Columns("C6").Visible = False
        DG.Columns("C1").ReadOnly = True
    End Select
    DG.Rows.Clear()
    For Each c As DataGridViewColumn In DG.Columns
      c.SortMode = DataGridViewColumnSortMode.NotSortable
    Next
    For Each strM As String In strV1
      If strM.Trim.Length = 0 Then Continue For
      Add(strM)
    Next
    For Each r As DataGridViewRow In DG.Rows
      Select Case intHideMode
        Case 1
          If GCell(r.Cells("C6")).ToUpper = "MARK" Then
            r.Visible = False
          End If
        Case 3
          If GCell(r.Cells("C6")).ToUpper <> "SCAN" Then
            r.Visible = False
          End If
      End Select
    Next
  End Sub
  Public Overrides Function ToString() As String
    Dim strM As String = ""
    For Each r As DataGridViewRow In DG.Rows
      strM &= GCell(r.Cells("C4")) & ";" & GCell(r.Cells("C3")) & ";" & GCell(r.Cells("C2")) & "^"
    Next
    Return strM.Trim("^")
  End Function
  Public Sub SetFormKey(s As Form)
    AddHandler s.KeyDown, AddressOf KeyPreview
    bolHdl = True
  End Sub
  Public Sub RemoveKeydown(s As Form)
    If bolHdl = False Then Return
    RemoveHandler s.KeyDown, AddressOf KeyPreview
    bolHdl = False
  End Sub
  Public Sub KeyPreview(sender As Object, e As KeyEventArgs)
    If e.KeyData >= Keys.F1 And e.KeyData <= Keys.F12 Then
      RaiseEvent ExecFunckey(Me, e.KeyData - Keys.F1 + 1)
      e.Handled = True
      e.SuppressKeyPress = True
    Else
      If csContl IsNot Nothing And bolKey = True Then
        e.Handled = True
        e.SuppressKeyPress = True
        If e.Shift And (e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9) Then
          strInput &= ")!@#$%^&*(".Substring((e.KeyCode And &HF), 1)
        ElseIf (e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9) Or _
        (e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9) Then
          strInput &= "0123456789".Substring((e.KeyCode And &HF), 1)
        ElseIf e.KeyCode >= Keys.A And e.KeyCode <= Keys.Z Then
          strInput &= "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Substring((e.KeyCode - Keys.A), 1)
        ElseIf e.KeyCode = Keys.Back Or e.KeyCode = Keys.Delete Then
          If strInput.Length < 1 Then
            strInput = ""
          Else
            strInput = strInput.Substring(0, strInput.Length - 1)
          End If
        ElseIf e.KeyCode = Keys.Enter Then
          If strInput.Length > 0 Then
            bolKey = False
            bolOk = True
          Else
            strInput = ""
          End If
        Else
          Dim strKD As String = ""
          If e.Shift Then
            Select Case e.KeyCode
              Case Keys.Add, Keys.Oemplus
                strKD = "+"
              Case Keys.Subtract, Keys.OemMinus
                strKD = "_"
              Case Keys.Oemcomma
                strKD = "<"
              Case Keys.OemPeriod
                strKD = ">"
            End Select
          Else
            Select Case e.KeyCode
              Case Keys.Add, Keys.Oemplus
                strKD = "="
              Case Keys.Subtract, Keys.OemMinus
                strKD = "-"
              Case Keys.Oemcomma
                strKD = ","
              Case Keys.OemPeriod
                strKD = "."
            End Select
          End If
          If strKD <> "" Then
            strInput &= strKD
          End If
        End If
      End If
    End If
    If csContl IsNot Nothing Then csContl.Text = strInput
  End Sub

  Public Overloads Sub Add(strC As String)
    Dim strV() As String = (strC & ";;").Split(";")
    Add(strV(0), strV(1), strV(2))
  End Sub
  Public Overloads Sub Add(strN As String, strY As String, strF As String)
    If zdC Is Nothing OrElse DG Is Nothing Then Return
    Dim c As ZDCMD = zdC.GetCMD(strN)
    If c Is Nothing Then Return
    c.Yes = strY
    c.No = strF
    DG.Rows.Add(c.Desc, c.No, c.Yes, c.Name, c.ToSet.ToString, c.Attribute.ToString)
  End Sub

  Private Sub DG_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DG.CellFormatting
    If e.RowIndex < 0 Or e.RowIndex >= DG.Rows.Count Then Return
    If e.ColumnIndex = 0 Then
      Dim strM As String = GCell(DG.Rows(e.RowIndex).Cells("C6")).ToUpper
      Select Case strM
        Case "SCAN"
          DG.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Black
          DG.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
        Case "FUNC"
          DG.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
          DG.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
        Case "MARK"
          DG.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Blue
          DG.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
        Case "TOSET"
          DG.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Black
          DG.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightGreen
      End Select
    End If
  End Sub
End Class

Public Class ZDCMD
  Private strName As String = ""
  Private strDesc As String = ""
  Private intAttb As ZDAttbs = 0
  Private strYes As String = ""
  Private strNo As String = ""
  Private intID As Integer = 0
  Private bolSet As Boolean = False
  Public Property Name As String
    Get
      Return strName
    End Get
    Set(value As String)
      strName = value
    End Set
  End Property
  Public Property Desc As String
    Get
      Return strDesc
    End Get
    Set(value As String)
      strDesc = value
    End Set
  End Property
  Public Property Attribute As ZDAttbs
    Get
      Return intAttb
    End Get
    Set(value As ZDAttbs)
      intAttb = value
    End Set
  End Property
  Public Property ToSet As Boolean
    Get
      Return bolSet
    End Get
    Set(value As Boolean)
      bolSet = value
    End Set
  End Property
  Sub New(sn As String, sd As String, intM As ZDAttbs)
    strName = sn
    strDesc = sd
    intAttb = intM
  End Sub
  Public Property Yes As String
    Get
      Return strYes
    End Get
    Set(value As String)
      strYes = value
    End Set
  End Property
  Public Property No As String
    Get
      Return strNo
    End Get
    Set(value As String)
      strNo = value
    End Set
  End Property
  Public Property ID As Integer
    Get
      Return intID
    End Get
    Set(value As Integer)
      intID = value
    End Set
  End Property
End Class
