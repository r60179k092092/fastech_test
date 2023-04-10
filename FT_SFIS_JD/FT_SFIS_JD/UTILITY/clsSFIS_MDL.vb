Public Enum frmStartMode
    none = 0
    Active = 1
    ActiveAsNew = 2
    ShowFrm = 3
    ShowFrmAsNew = 4
    ShowDialog = 10
    ShowDiaLogAsNew = 11
    ShowLogin = 12
    Floder = 20
    CloseALL = 90
    ExitWin = 99
End Enum
Public Class clsSFIS_MDL
    Private strName As String = ""
    Private strHead As String = ""
    Private strFrmN As String = ""
    Private bolRights As Boolean = False
    Private bolActive As Boolean = False
    Private strPATH As String = ""
    Private intStartMode As frmStartMode = frmStartMode.none
    Sub New(strN As String, strH As String, frmV As String, Mode As frmStartMode)
        strName = strN
        strHead = strH
        strFrmN = frmV
        intStartMode = Mode
    End Sub
    Public Property PATH As String
        Get
            Return strPATH
        End Get
        Set(value As String)
            strPATH = value
        End Set
    End Property
    Public Property Name As String
        Get
            Return strName
        End Get
        Set(value As String)
            strName = value
        End Set
    End Property
    Public Property Head As String
        Get
            Return strHead
        End Get
        Set(value As String)
            strHead = value
        End Set
    End Property
    Public Property FormName As String
        Get
            Return strFrmN
        End Get
        Set(value As String)
            strFrmN = value
        End Set
    End Property
    Public Property StartMode As frmStartMode
        Get
            Return intStartMode
        End Get
        Set(value As frmStartMode)
            intStartMode = value
        End Set
    End Property
    Public Property HasRight As Boolean
        Get
            Return bolRights
        End Get
        Set(value As Boolean)
            bolRights = value
            If bolRights = False And bolActive = True Then
                Close()
            End If
        End Set
    End Property
    Public Sub Start()
        bolActive = True
    End Sub
    Public Sub Close()
        bolActive = False
    End Sub
End Class
Public Class clsSFIS_PGS
    Inherits clsSFIS_MDL
    Private aryNode As New Dictionary(Of String, clsSFIS_PGS)
    Private bolExpanded As Boolean = False
    Public Property Expanded As Boolean
        Get
            Return bolExpanded
        End Get
        Set(value As Boolean)
            bolExpanded = value
        End Set
    End Property
    Sub New(strN As String, strH As String, frmV As String, intM As frmStartMode)
        MyBase.New(strN, strH, frmV, intM)
    End Sub
    Public Function AddItem(strN As String, strH As String, frmV As String, intM As frmStartMode)
        Dim s As New clsSFIS_PGS(strN, BIG2GB(strH), frmV, intM)
        s.PATH = (Me.PATH & "/" & strN).Trim("/")
        aryNode.Add(strN, s)
        Return s
    End Function
    Public Function GetNode(strN As String) As clsSFIS_PGS
        If aryNode.ContainsKey(strN) = False Then
            Return Nothing
        Else
            Return aryNode(strN)
        End If
    End Function
    Public Function isHasNode(strN As String) As Boolean
        Return aryNode.ContainsKey(strN)
    End Function
    Public Sub Clear()
        aryNode.Clear()
    End Sub
    Public Sub BulidMenu(tw As TreeNode)
        tw.Nodes.Clear()
        For Each strK As String In aryNode.Keys
            aryNode(strK).BulidMenu(tw.Nodes.Add(strK, aryNode(strK).Head))
        Next
    End Sub
    Public Function GetID(strN As String) As clsSFIS_MDL
        If strN = Name Then
            Return Me
        ElseIf aryNode.ContainsKey(strN) Then
            Return aryNode(strN)
        Else
            For Each n As clsSFIS_PGS In aryNode.Values
                Dim x As clsSFIS_PGS = n.GetID(strN)
                If x IsNot Nothing Then Return x
            Next
            Return Nothing
        End If
    End Function
End Class
Public Class FormsV(Of t As New)
    Private f As t = Nothing
    Private strNmae As String
    Sub New(strN As String)
        strNmae = strN
    End Sub
    Public Function Name() As String
        Return strNmae
    End Function
    Public Function GetForm() As t
        f = New t
        Return f
    End Function
End Class
Public Class myProjforms
    Private aryFormN As New Dictionary(Of String, clsSFIS_PGS)
    Private aryList As New ArrayList

    Sub New()
        aryList.Add(New FormsV(Of Frm0801)("Frm0801"))
        aryList.Add(New FormsV(Of Frm0802)("Frm0802"))
        aryList.Add(New FormsV(Of Frm0803)("Frm0803"))
        aryList.Add(New FormsV(Of PM0301)("PM0301"))
        aryList.Add(New FormsV(Of PM0302)("PM0302"))
        aryList.Add(New FormsV(Of PM0303)("PM0303"))
        aryList.Add(New FormsV(Of PM0304)("PM0304"))
        aryList.Add(New FormsV(Of PM0305)("PM0305"))
        aryList.Add(New FormsV(Of PM0306)("PM0306"))
        aryList.Add(New FormsV(Of PM0307)("PM0307"))
        aryList.Add(New FormsV(Of PM0308)("PM0308"))
        aryList.Add(New FormsV(Of PM0309)("PM0309"))
        aryList.Add(New FormsV(Of WMS0302)("PM0310"))
        aryList.Add(New FormsV(Of PM0311)("PM0311"))
        aryList.Add(New FormsV(Of PM0312)("PM0312"))
        aryList.Add(New FormsV(Of PM0313)("PM0313"))
        aryList.Add(New FormsV(Of PM0314)("PM0314"))
        aryList.Add(New FormsV(Of PM0315)("PM0315"))
        aryList.Add(New FormsV(Of PM0316)("PM0316"))
        aryList.Add(New FormsV(Of Frm0317)("Frm0317"))
        aryList.Add(New FormsV(Of Frm0320)("Frm0320"))
        aryList.Add(New FormsV(Of Frm0322)("Frm0322"))
        aryList.Add(New FormsV(Of Frm0324)("Frm0324"))
        aryList.Add(New FormsV(Of Frm0325)("Frm0325"))
        aryList.Add(New FormsV(Of Frm0326)("Frm0326"))
        aryList.Add(New FormsV(Of frm0330)("Frm0330"))
        aryList.Add(New FormsV(Of frm0331)("Frm0331"))
        aryList.Add(New FormsV(Of PM0401)("PM0401"))
        aryList.Add(New FormsV(Of PM0402)("PM0402"))
        aryList.Add(New FormsV(Of PM0403)("PM0403"))
        aryList.Add(New FormsV(Of PM0404)("PM0404"))
        aryList.Add(New FormsV(Of Frm0405)("Frm0405"))
        aryList.Add(New FormsV(Of PM0501)("PM0501"))
        aryList.Add(New FormsV(Of PM0502)("PM0502"))
        aryList.Add(New FormsV(Of PM0504)("PM0504"))
        aryList.Add(New FormsV(Of PM0505)("PM0505"))
        aryList.Add(New FormsV(Of PM0506)("PM0506"))
        aryList.Add(New FormsV(Of PM0507)("PM0507"))
        aryList.Add(New FormsV(Of Frm0509)("PM0509"))
        aryList.Add(New FormsV(Of Frm0510)("Frm0510"))
        aryList.Add(New FormsV(Of Frm0506A)("Frm0506A"))
        aryList.Add(New FormsV(Of Frm0504)("Frm0504"))
        aryList.Add(New FormsV(Of Frm0520)("Frm0520"))
        aryList.Add(New FormsV(Of Frm0514)("Frm0514"))
        aryList.Add(New FormsV(Of FrmCH01)("FrmCH01"))
        aryList.Add(New FormsV(Of Frm0702)("Frm0702"))
        aryList.Add(New FormsV(Of Frm0601)("Frm0601"))
        aryList.Add(New FormsV(Of Frm0602)("Frm0602"))
        aryList.Add(New FormsV(Of Frm0603)("Frm0603"))
        aryList.Add(New FormsV(Of Frm0604)("^Frm0604"))
        aryList.Add(New FormsV(Of Frm0605)("Frm0605"))
        aryList.Add(New FormsV(Of Frm0606)("Frm0606"))
        aryList.Add(New FormsV(Of FrmLabEdit)("FrmLabEdit"))
        aryList.Add(New FormsV(Of FrmLogin)("FrmLogin"))
        aryList.Add(New FormsV(Of FrmQTN)("FrmQTN"))
        aryList.Add(New FormsV(Of Frm0506A)("N506A"))
        aryList.Add(New FormsV(Of PM0510)("PM0510"))
        aryList.Add(New FormsV(Of Frm0406)("Frm0406"))
        aryList.Add(New FormsV(Of Frm0804)("Frm0804"))
    End Sub
    Public Function AddName(strN As String, strH As String, strF As String, intM As frmStartMode) As clsSFIS_PGS
        Dim s As clsSFIS_PGS
        s = New clsSFIS_PGS(strN, BIG2GB(strH), strF, intM)
        s.PATH = strN
        aryFormN.Add(strN, s)
        Return s
    End Function
    Public Function GetForm(strF As String) As Form
        For Each s As Object In aryList
            If s.Name.ToUpper = strF.Trim.ToUpper Then
                Return s.GetForm
            End If
        Next
        Return Nothing
    End Function
    Private Function GetStart(strF As String) As frmStartMode
        If strF = "" Then Return frmStartMode.Floder
        If strF.StartsWith("^") Then
            Return frmStartMode.ShowDialog
        End If
        Return frmStartMode.Active
    End Function
    Public Sub LoadMenu()
        Dim sqlCV As New APSQL.SQLCNV
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
        sqlCV.Where("QTN01", "=", "@AURTS_SFC")
        sqlCV.SqlFields("*")
        sqlCV.sqlOrder("QTN02")
        Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        Dim b As clsSFIS_PGS
        For Each r As DataRow In rs.Rows
            If r!QTN04.ToString.Trim = "*" Then Continue For
            Dim strK() As String = r!QTN02.ToString.Trim.Split("/")
            If strK(0).Trim = "" Then Continue For
            If aryFormN.ContainsKey(strK(0)) = True Then
                b = aryFormN(strK(0))
                For intI As Integer = 1 To strK.GetUpperBound(0)
                    If b.isHasNode(strK(intI)) Then
                        b = b.GetNode(strK(intI))
                    Else
                        If intI = strK.GetUpperBound(0) Then
                            If strK(intI).Trim = "PQTN" And r!QTN04.ToString.Trim = "" Then
                                b.AddItem(strK(intI), BIG2GB(r!QTN03.ToString.Trim), "FrmQTN", GetStart("FrmQTN"))
                            Else
                                b.AddItem(strK(intI), BIG2GB(r!QTN03.ToString.Trim), r!QTN04.ToString.Trim, GetStart(r!QTN04.ToString.Trim))
                            End If
                        Else
                            b.AddItem(strK(intI), BIG2GB(r!QTN03.ToString.Trim), "", frmStartMode.Floder)
                            b = b.GetNode(strK(intI))
                        End If
                    End If
                Next
            Else
                b = Nothing
                For intI As Integer = 0 To strK.GetUpperBound(0)
                    If intI = strK.GetUpperBound(0) Then
                        Dim strQ04 As String = r!QTN04.ToString.Trim
                        If strQ04 = "" And strK(intI) = "PQTN" Then
                            strQ04 = "FrmQTN"
                        End If
                        If b Is Nothing Then
                            AddName(strK(intI), BIG2GB(r!QTN03.ToString.Trim), strQ04, GetStart(strQ04))
                        Else
                            b.AddItem(strK(intI), BIG2GB(r!QTN03.ToString.Trim), strQ04, GetStart(strQ04))
                        End If
                    Else
                        If b Is Nothing Then
                            b = AddName(strK(intI), BIG2GB(r!QTN03.ToString.Trim), "", frmStartMode.Floder)
                        Else
                            b.AddItem(strK(intI), BIG2GB(r!QTN03.ToString.Trim), "", frmStartMode.Floder)
                            b = b.GetNode(strK(intI))
                        End If
                    End If
                Next
            End If
        Next
        If rs.Rows.Count = 0 Then
            AddName("PQTN", "字典編輯", "FrmQTN", frmStartMode.Active)
        End If
        AddName("WINRESET", BIG2GB("關閉所有窗口"), "", frmStartMode.CloseALL)
        AddName("WINLOGIN", BIG2GB("登出"), "FrmLOGIN", frmStartMode.ShowLogin)
        AddName("WINEXIT", BIG2GB("退出系統"), "", frmStartMode.ExitWin)
    End Sub
    Public Sub BulidMenu(tw As TreeView)
        tw.Nodes.Clear()
        For Each strK As String In aryFormN.Keys
            aryFormN(strK).BulidMenu(tw.Nodes.Add(strK, aryFormN(strK).Head))
        Next
    End Sub

    Public Function GetID(strN As String) As clsSFIS_MDL
        If aryFormN.ContainsKey(strN) Then
            Return aryFormN(strN)
        Else
            For Each n As clsSFIS_PGS In aryFormN.Values
                Dim x As clsSFIS_PGS = n.GetID(strN)
                If x IsNot Nothing Then Return x
            Next
            Return Nothing
        End If
    End Function
End Class
