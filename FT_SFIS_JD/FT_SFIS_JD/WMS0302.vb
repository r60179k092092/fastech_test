Imports FT_SPEC

Public Class WMS0302
    Private Declare Function GetActiveWindow Lib "user32" () As Int32
    Private Declare Function FindWindowExA Lib "user32" _
          (ByVal hWnd1 As Int32, ByVal hWnd2 As Int32, _
           ByVal lpsz1 As String, ByVal lpsz2 As String) As Int32
    Private Declare Function SendMessageA Lib "user32" _
           (ByVal hwnd As Int32, ByVal wMsg As Int32, _
            ByVal wParam As Int32, ByVal lParam As Int32) As Int32
    Private WithEvents tmr As Timer ' 宣告 Timer 
    Private WithEvents cs As clsEDIT2012.clsEDITx2013
    Private aryDT As New Dictionary(Of String, Boolean)
    Private aryDM As New ArrayList
    Private bolOKDM As Boolean = False
    Private strDEL As String = ""
    Private strFile As String = ""
    Private strXPSFILE As String = ""
    Private bolPICPV As Boolean = False
    Private bolUpdate1 As Boolean = True
    Private bolUpdate2 As Boolean = True
    Private intPro As Integer = 0
    Private bol001 As Boolean = False
    Private bol003 As Boolean = False
    Private bol004 As Boolean = False
#If WMS <> 1 Then
  Dim Dliucheng As FrmDialog
#End If


    Sub New()

        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        languagechange(Me)

    End Sub
    Private Sub DMS0302_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        TuiCK(Me)
    End Sub
    Private Sub XFDown1()
        Dim sqlCV As New APSQL.SQLCNV
        If DBERP Is Nothing OrElse DBERP.Active = False Then Return
        Dim aryM As New Dictionary(Of String, String)
        Dim bolTR As Boolean = False
        Try
            sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "WMSA")
            sqlCV.Where("SA04", "IN", "'1001','1002','1012','1013','1014'", intFMode.msfld_field)
            sqlCV.SqlFields("SA01")
            sqlCV.SqlFields("SA02")
            sqlCV.SqlFields("SA04")
            Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
            Dim aryL As New ArrayList
            For Each r As DataRow In rs.Rows
                aryL.Add(r!SA01.ToString.Trim)
            Next
            Dim aryIQ As New Dictionary(Of String, String)
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
            sqlCV.Where("QTN01", "Like", "#ICLASS||03%")
            sqlCV.SqlFields("QTN02")
            sqlCV.SqlFields("QTN03")
            rs = DB.RsSQL(sqlCV.Text, "RT")
            For Each r As DataRow In rs.Rows
                aryIQ.Add(r!QTN02.ToString.Trim, r!QTN03.ToString.Trim)
            Next
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "t_ICItem")
            sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "t_MeasureUnit", "FMeasureUnitID", "=", "^0.FUnitID")
            sqlCV.SqlFields("^0.FNumber")
            sqlCV.SqlFields("^0.FName")
            sqlCV.SqlFields("^0.FModel")
            sqlCV.SqlFields("^0.F_102", "VEND")
            sqlCV.SqlFields("^0.F_113", "ITVND")
            sqlCV.SqlFields("^0.F_109", "SUBSPEC")
            sqlCV.SqlFields("^0.F_111", "COLOR")
            sqlCV.SqlFields("^0.F_112", "RMK")
            sqlCV.SqlFields("^1.FName", "UNIT")
            rs = DBERP.RsSQL(sqlCV.Text, "RT")
            PB.Minimum = 0
            PB.Value = 0
            PB.Maximum = rs.Rows.Count
            PBS.Text = "0/" & rs.Rows.Count
            Dim intLS As Integer = 0
            For Each r As DataRow In rs.Rows
                intLS += 1
                If intLS >= 10 Then
                    intLS = 0
                    PB.Value += 10
                    PBS.Text = PB.Value.ToString & " / " & PB.Maximum.ToString
                    Panel1.Refresh()
                End If
                Dim strIT As String = r!FNumber.ToString.Trim
                If aryL.Contains(strIT) = True Then Continue For
                Dim strV() As String = strIT.Split(".")
                If strV.Length >= 3 Then
                    Select Case strV(2).Substring(0, 1).ToUpper
                        Case "Y"
                            If strIT.StartsWith("01.03") Then
                                strV(0) = "1002"
                            Else
                                strV(0) = "1001"
                            End If
                        Case "R"
                            strV(0) = "1002"
                        Case "P"
                            strV(0) = "1012"
                        Case "F"
                            strV(0) = "1013"
                        Case "S"
                            strV(0) = "1014"
                        Case Else
                            strV(0) = ""
                    End Select
                    If strV(0) = "" Then Continue For
                    DB.BeginTransaction("FNumber")
                    bolTR = True
                    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "WMSA")
                    sqlCV.SqlFields("SA01", r!FNumber.ToString.Trim)
                    sqlCV.SqlFields("SA02", r!FName.ToString.Trim)
                    sqlCV.SqlFields("SA03", r!FModel.ToString.Trim)
                    sqlCV.SqlFields("SA04", strV(0))
                    sqlCV.SqlFields("SA05", r!UNIT.ToString.Trim)
                    sqlCV.SqlFields("SA06", 0, intFMode.msfld_num)
                    sqlCV.SqlFields("SA07", 0, intFMode.msfld_num)
                    sqlCV.SqlFields("SA08", 0, intFMode.msfld_num)
                    sqlCV.SqlFields("SA09", 0, intFMode.msfld_num)
                    sqlCV.SqlFields("SA10", 1, intFMode.msfld_num)
                    Dim strI() As String = r!FModel.ToString.Trim.Split("*Xx".ToCharArray)
                    If strI(0).ToUpper.EndsWith("MM") Then
                        sqlCV.SqlFields("SA15", strI(0).ToLower & " " & r!ITVND.ToString.Trim)
                    Else
                        sqlCV.SqlFields("SA15", r!ITVND.ToString.Trim)
                    End If
                    sqlCV.SqlFields("SA16", r!ITVND.ToString.Trim)
                    sqlCV.SqlFields("SA19", r!VEND.ToString.Trim)
                    DB.RsSQL(sqlCV.Text)
                    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "WMSAA")
                    sqlCV.SqlFields("SAA01", r!FNumber.ToString.Trim)
                    sqlCV.SqlFields("SAA02", "01")
                    If r!UNIT.ToString.Trim.ToUpper = "M2" Or r!UNIT.ToString.Trim = "平方米" Then
                        Dim strU() As String = r!FModel.ToString.Trim.Split("*xX".ToCharArray)
                        If strU.Length > 1 AndAlso strU(1).Trim.ToUpper.EndsWith("M") Then
                            sqlCV.SqlFields("SAA03", Val(strU(0)) * Val(strU(1)) * 0.001, intFMode.msfld_num)
                        Else
                            sqlCV.SqlFields("SAA03", "1")
                        End If
                    Else
                        sqlCV.SqlFields("SAA03", "1")
                    End If
                    sqlCV.SqlFields("SAA05", "*")
                    If aryIQ.ContainsKey(strV(0)) Then
                        sqlCV.SqlFields("SAA08", aryIQ(strV(0)))
                    Else
                        sqlCV.SqlFields("SAA08", "")
                    End If
                    DB.RsSQL(sqlCV.Text)
                    DB.CommitTransaction()
                    bolTR = False
                End If
            Next
            cs.Updated = True
            cs.Clean()
            PB.Value = PB.Minimum
            MsgBox(BIG2GB("導入完成"))
        Catch ex As Exception
            If bolTR Then DB.AbortTransaction()
        End Try
    End Sub
    Private Sub XFDFiLm(rs As DataTable, str08 As String, aryL As ArrayList)
        Dim bolTR As Boolean = False
        Dim intLS As Integer = 0
        Try
            Dim sqlCV As New APSQL.SQLCNV
            For intI As Integer = 1 To rs.Rows.Count - 1
                intLS += 1
                If intLS >= 10 Then
                    intLS = 0
                    PB.Value += 10
                    PBS.Text = PB.Value.ToString & " / " & PB.Maximum.ToString
                    Panel1.Refresh()
                End If
                Dim r As DataRow = rs.Rows(intI)
                Dim strIT As String = r.Item(7).ToString.Trim
                Dim strDY As String = r.Item(6).ToString.Trim
                Dim strLB As String = r.Item(2).ToString.Trim
                If strIT.Trim = "" Or strDY = "" Or strLB = "" Then Continue For
                Dim strCD As String = ""
                Dim strC1 As String = ""
                For intJ As Integer = strIT.Length - 1 To 0 Step -1
                    If (strIT(intJ) < "0"c Or strIT(intJ) > "9"c) And strIT(intJ) <> "-" Then
                        strCD = strIT.Substring(0, intJ + 1)
                        strC1 = strIT.Substring(intJ + 1)
                        Dim strV() As String = (strC1 & "-1").Split("-")
                        strC1 = Val(strV(0)).ToString("00000") & "-" & Val(strV(1)).ToString("00")
                        strIT = "5S" & strCD & strC1
                    End If
                Next
                If aryL.Contains(strIT) Then Continue For
                Dim strDYS() As String = strDY.Split("/")
                Dim strDYM As String = ""
                For Each strDM As String In strDYS
                    strDY = strDM
                    For intJ As Integer = strDY.Length - 1 To 0 Step -1
                        If strDY(intJ) < "0"c Or strDY(intJ) > "9"c Then
                            strCD = strDY.Substring(0, intJ + 1)
                            strC1 = strDY.Substring(intJ + 1)
                            strC1 = Val(strC1).ToString("00000")
                            strDY = "5S" & strCD & strC1
                        End If
                    Next
                    strDYM &= strDY & "/"
                Next
                strDY = strDYM.Trim("/")
                strDYS = strDY.Split("/")
                For intJ As Integer = strLB.Length - 1 To 0 Step -1
                    If strLB(intJ) < "0"c Or strLB(intJ) > "9"c Then
                        strCD = strLB.Substring(0, intJ + 1)
                        strC1 = strLB.Substring(intJ + 1)
                        strC1 = Val(strC1).ToString("00000")
                        strLB = "1" & strCD & strC1
                    End If
                Next
                Dim strSA03 As String = ""
                Dim strSA15 As String = ""
                DB.BeginTransaction("XFDFilm")
                bolTR = True
                sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "WMSA")
                sqlCV.Where("SA01", "=", strLB)
                sqlCV.SqlFields("SA03")
                sqlCV.SqlFields("SA15")
                Dim rs1 As DataTable = DB.RsSQL(sqlCV.Text, "RT")
                If rs1.Rows.Count = 0 Then
                    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "WMSA")
                    sqlCV.Where("SA01", "=", strDYS(0))
                    sqlCV.SqlFields("SA03")
                    sqlCV.SqlFields("SA15")
                    rs1 = DB.RsSQL(sqlCV.Text, "RT")
                Else
                    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "WMSA")
                    sqlCV.Where("SA01", "=", strLB)
                    sqlCV.SqlFields("SA12", r.Item(3).ToString.Trim)
                    sqlCV.SqlFields("SA13", r.Item(4).ToString.Trim)
                    DB.RsSQL(sqlCV.Text)
                End If
                strSA03 = BIG2GB("貼紙=" & strLB & ",刀模=" & strDYM)
                If rs1.Rows.Count > 0 Then
                    strSA03 = rs1.Rows(0)!SA03.ToString.Trim & " " & strSA03
                    strSA15 = rs1.Rows(0)!SA15.ToString.Trim
                End If
                sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "WMSA")
                sqlCV.SqlFields("SA01", strIT)
                Dim strMM() As String = r.Item(9).ToString.Trim.Split((" ," & vbTab & vbCrLf).ToCharArray)
                Dim strM1 As String = ""
                For Each strK As String In strMM
                    If strK = "" Then Continue For
                    strM1 &= strK & " "
                Next
                strM1 &= r.Item(10).ToString.Trim
                strMM = r.Item(8).ToString.Trim.Split((" ,." & vbTab & vbCrLf).ToCharArray)
                Dim strM2 As String = ""
                For Each strK As String In strMM
                    If strK = "" Then Continue For
                    strM2 &= strK & ","
                Next
                sqlCV.SqlFields("SA02", strM1.Trim)
                sqlCV.SqlFields("SA03", strSA03)
                sqlCV.SqlFields("SA04", "1011A")
                sqlCV.SqlFields("SA05", "PCS")
                sqlCV.SqlFields("SA06", 1, intFMode.msfld_num)
                sqlCV.SqlFields("SA07", 1, intFMode.msfld_num)
                sqlCV.SqlFields("SA08", 0, intFMode.msfld_num)
                sqlCV.SqlFields("SA09", 0, intFMode.msfld_num)
                sqlCV.SqlFields("SA10", 0, intFMode.msfld_num)
                sqlCV.SqlFields("SA15", strSA15)
                sqlCV.SqlFields("SA19", r.Item(1).ToString.Trim)
                sqlCV.SqlFields("SA17", strM2.Trim(","))
                sqlCV.SqlFields("SA18", r.Item(11).ToString.Trim)
                DB.RsSQL(sqlCV.Text)
                sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "WMSAA")
                sqlCV.SqlFields("SAA01", strIT)
                sqlCV.SqlFields("SAA02", "01")
                sqlCV.SqlFields("SAA03", 1, intFMode.msfld_num)
                sqlCV.SqlFields("SAA04", "")
                sqlCV.SqlFields("SAA05", "*")
                sqlCV.SqlFields("SAA06", "")
                sqlCV.SqlFields("SAA07", "")
                sqlCV.SqlFields("SAA08", str08)
                sqlCV.SqlFields("SAA09", "")
                DB.RsSQL(sqlCV.Text)
                aryL.Add(strIT)
                strDYS = (strIT & "/" & strDYM).Split("/")
                For Each strDY In strDYS
                    If strDY = "" Then Continue For
                    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TC")
                    sqlCV.Where("TC01", "=", strLB)
                    sqlCV.Where("TC02", "=", strDY)
                    sqlCV.SqlFields("TC01")
                    Dim rs2 As DataTable = DB.RsSQL(sqlCV.Text, "TC")
                    If rs2.Rows.Count = 0 Then
                        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_TC")
                        sqlCV.SqlFields("TC01", strLB)
                        sqlCV.SqlFields("TC02", strDY)
                        sqlCV.SqlFields("TC03", r.Item(5).ToString.Trim)
                        sqlCV.SqlFields("TC04", "0", intFMode.msfld_num)
                        sqlCV.SqlFields("TC05", "205")
                        sqlCV.SqlFields("TC06", "1")
                        sqlCV.SqlFields("TC07", "")
                        sqlCV.SqlFields("TC08", "")
                        sqlCV.SqlFields("TC09", "")
                        sqlCV.SqlFields("TC10", "1.0")
                        DB.RsSQL(sqlCV.Text)
                    End If
                Next
                DB.CommitTransaction()
                bolTR = False
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
            If bolTR Then DB.AbortTransaction()
            Return
        End Try
        MsgBox(BIG2GB("Excel 轉檔完成"))
        PB.Value = 0
        PBS.Text = ""
        cs.Updated = True
        cs.Clean()
    End Sub
    Private Sub XFDown()
        Dim sqlCV As New APSQL.SQLCNV
        Dim xls As XLS_FILE = Nothing
        Dim aryM As New Dictionary(Of String, String)
        Dim aryA As New Dictionary(Of String, String)
        Dim OFL As New OpenFileDialog
        OFL.DefaultExt = "XLS"
        OFL.InitialDirectory = "D:"
        OFL.Filter = "Excel檔案|*.xls|所有檔案|*.*"
        If OFL.ShowDialog <> Windows.Forms.DialogResult.OK Then Return
        Try
            sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "WMSA")
            sqlCV.SqlFields("SA01")
            sqlCV.SqlFields("SA02")
            sqlCV.SqlFields("SA04")
            sqlCV.SqlFields("SA14")
            sqlCV.SqlFields("SA20")
            Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
            Dim aryL As New ArrayList
            Dim intLS As Integer = 0
            PB.Maximum = rs.Rows.Count
            PB.Minimum = 0
            PB.Value = 0
            PBS.Text = "0/" & rs.Rows.Count
            Dim str04 As String = ""
            Dim str20 As String = ""
            For Each r As DataRow In rs.Rows
                intLS += 1
                If intLS >= 10 Then
                    intLS = 0
                    PB.Value += 10
                    PBS.Text = PB.Value.ToString & " / " & PB.Maximum.ToString
                    Panel1.Refresh()
                    My.Application.DoEvents()
                End If
                str04 = r!SA04.ToString.Trim
                str20 = r!SA20.ToString.Trim
                If str04 = "1003" Or str04 = "1004" Or str04 = "1008" Or str04 = "1009" Then
                    If str20 = "" Then
                        Dim slab As New clsLabSpec
                        slab.LSDecode(r!SA14.ToString.Trim)
                        str20 = slab.GetWider
                        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "WMSA")
                        sqlCV.Where("SA01", "=", r!SA01.ToString.Trim)
                        sqlCV.SqlFields("SA20", str20)
                        DB.RsSQL(sqlCV.Text)
                    End If
                    If aryA.ContainsKey(str20) = False Then
                        aryA.Add(str20, r!SA01.ToString.Trim)
                    End If
                End If
                aryL.Add(r!SA01.ToString.Trim)
                If r!SA01.ToString.Trim.StartsWith("$") Then
                    aryM.Add(r!SA02.ToString.Trim, r!SA01.ToString.Trim)
                End If
            Next
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
            sqlCV.Where("QTN01", "Like", "#ICLASS||03%")
            sqlCV.SqlFields("QTN02")
            sqlCV.SqlFields("QTN03")
            rs = DB.RsSQL(sqlCV.Text, "RT")
            For Each r As DataRow In rs.Rows
                aryM.Add(r!QTN02.ToString.Trim, r!QTN03.ToString.Trim)
            Next
            xls = New XLS_FILE(OFL.FileName)
            rs = xls.XLS2Rs(0, 2, , True)
            xls.Quit()
            PB.Minimum = 0
            PB.Value = 0
            PB.Maximum = rs.Rows.Count
            PBS.Text = "0/" & rs.Rows.Count
            If rs.Columns.Count = 12 And rs.Columns(1).ColumnName = "F2" Then
                If aryM.ContainsKey("1011A") Then
                    XFDFiLm(rs, aryM("1011A"), aryL)
                Else
                    XFDFiLm(rs, "", aryL)
                End If
                Return
            End If
            intLS = 0
            If IO.File.Exists("D:\DIE_WARN.TXT") = True Then
                IO.File.Delete("D:\DIE_WARN.TXT")
            End If
            If IO.File.Exists("D:\DIE_WARN_M.TXT") = True Then
                IO.File.Delete("D:\DIE_WARN_M.TXT")
            End If
            Dim intCS As Integer = 0
            For Each r As DataRow In rs.Rows
                intLS += 1
                intCS += 1
                If intLS >= 10 Then
                    intLS = 0
                    PB.Value += 10
                    PBS.Text = PB.Value.ToString & " / " & PB.Maximum.ToString
                    Panel1.Refresh()
                    My.Application.DoEvents()
                End If
                Dim strIT As String = r.Item(0).ToString.Trim
                Dim strCD As String = strIT.Substring(0, 1)
                Dim strC1 As String = strIT.Substring(1)
                Dim strType As String = ""
                If strCD = "L" Then
                    If strCD.StartsWith("1") = False Then strCD = "1" & strCD
                    strC1 = Val(strC1).ToString("00000")
                    strIT = strCD & strC1
                    strType = "1003"
                ElseIf strCD = "G" Then
                    If strCD.StartsWith("1") = False Then strCD = "1" & strCD
                    strC1 = Val(strC1).ToString("00000")
                    strType = "1008"
                    strIT = strCD & strC1
                ElseIf strCD = "D" Then
                    strCD &= strC1.Substring(0, 1)
                    If strCD.StartsWith("5S") = False Then strCD = "5S" & strCD
                    strC1 = Val(strC1.Substring(1)).ToString("00000")
                    If strCD = "5SDM" Then
                        strType = "1010"
                    ElseIf strCD = "5SDY" Then
                        strType = "1011"
                    End If
                    strIT = strCD & strC1
                Else
                    strCD = ""
                    strIT = ""
                End If
                If strIT = "" Then Continue For
                Try
                    DB.BeginTransaction("WMS0302")
                    Dim bolHas As Boolean = aryL.Contains(strIT)
                    Select Case strCD
                        Case "1L"
                            If bolHas Then Exit Select
                            sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "WMSA")
                            sqlCV.SqlFields("SA01", strIT)
                            sqlCV.SqlFields("SA02", r.Item(12).ToString.Trim)
                            sqlCV.SqlFields("SA03", r.Item(10).ToString.Trim)
                            sqlCV.SqlFields("SA04", strType)
                            sqlCV.SqlFields("SA05", r.Item(11).ToString.Trim)
                            sqlCV.SqlFields("SA06", 0, APSQL.intFMode.msfld_num)
                            sqlCV.SqlFields("SA07", 0, APSQL.intFMode.msfld_num)
                            sqlCV.SqlFields("SA08", 0, APSQL.intFMode.msfld_num)
                            sqlCV.SqlFields("SA09", "0")
                            sqlCV.SqlFields("SA10", 1, APSQL.intFMode.msfld_num)
                            Dim clsLAB As New clsLabSpec
                            clsLAB.Width = Val(r.Item(1).ToString)
                            clsLAB.Height = Val(r.Item(3).ToString)
                            clsLAB.MultiX = Val(r.Item(2).ToString)
                            clsLAB.MultiY = Val(r.Item(4).ToString)
                            Select Case r.Item(8).ToString.Trim
                                Case "圓", "橢圓形"
                                    clsLAB.LabelShape = TpofLabelShape.LSOct
                                Case "切角"
                                    clsLAB.LabelShape = TpofLabelShape.LSTriRect
                                Case "特殊角"
                                    clsLAB.LabelShape = TpofLabelShape.LSOther
                                Case Else
                                    clsLAB.LabelShape = TpofLabelShape.LSRect
                            End Select
                            clsLAB.Radius = Val(r.Item(9).ToString)
                            clsLAB.PaperType = "B"
                            clsLAB.Remark = r.Item(13).ToString.Trim
                            clsLAB.TextColor = ""
                            Dim bolA As Boolean = False
                            Dim strM As String = r.Item(5).ToString.Trim & " " & r.Item(7).ToString.Trim
                            If aryM.ContainsKey(strM.ToUpper) Then
                                clsLAB.PaparSource = aryM(strM.ToUpper)
                            Else
                                clsLAB.PaparSource = "$" & (aryM.Count + 1).ToString("0000000")
                                aryM.Add(strM.ToUpper, clsLAB.PaparSource)
                                bolA = True
                            End If
                            sqlCV.SqlFields("SA14", clsLAB.ToString)
                            sqlCV.SqlFields("SA15", clsLAB.GetMainSpecEx)
                            sqlCV.SqlFields("SA20", clsLAB.GetWider)
                            DB.RsSQL(sqlCV.Text)
                            If bolA Then
                                sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "WMSA")
                                sqlCV.SqlFields("SA01", clsLAB.PaparSource)
                                sqlCV.SqlFields("SA02", strM)
                                sqlCV.SqlFields("SA03", "")
                                sqlCV.SqlFields("SA04", "1001")
                                sqlCV.SqlFields("SA05", "PCS")
                                sqlCV.SqlFields("SA06", 0, APSQL.intFMode.msfld_num)
                                sqlCV.SqlFields("SA07", 0, APSQL.intFMode.msfld_num)
                                sqlCV.SqlFields("SA08", 0, APSQL.intFMode.msfld_num)
                                sqlCV.SqlFields("SA09", "0")
                                sqlCV.SqlFields("SA10", 1, APSQL.intFMode.msfld_num)
                                DB.RsSQL(sqlCV.Text)
                            End If
                            sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "WMSAA")
                            sqlCV.SqlFields("SAA01", strIT)
                            sqlCV.SqlFields("SAA02", "01")
                            sqlCV.SqlFields("SAA03", 1, APSQL.intFMode.msfld_num)
                            sqlCV.SqlFields("SAA04", "")
                            sqlCV.SqlFields("SAA05", "*")
                            sqlCV.SqlFields("SAA06", "")
                            sqlCV.SqlFields("SAA07", "")
                            If aryM.ContainsKey(strType) Then
                                sqlCV.SqlFields("SAA08", aryM(strType))
                            Else
                                sqlCV.SqlFields("SAA08", "")
                            End If
                            sqlCV.SqlFields("SAA09", "")
                            DB.RsSQL(sqlCV.Text)
                        Case "1G"
                            If bolHas Then Exit Select
                            sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "WMSA")
                            sqlCV.SqlFields("SA01", strIT)
                            sqlCV.SqlFields("SA02", r.Item(19).ToString.Trim)
                            sqlCV.SqlFields("SA03", r.Item(18).ToString.Trim)
                            sqlCV.SqlFields("SA04", strType)
                            sqlCV.SqlFields("SA05", r.Item(20).ToString.Trim)
                            sqlCV.SqlFields("SA06", 0, APSQL.intFMode.msfld_num)
                            sqlCV.SqlFields("SA07", 0, APSQL.intFMode.msfld_num)
                            sqlCV.SqlFields("SA08", 0, APSQL.intFMode.msfld_num)
                            sqlCV.SqlFields("SA09", "0")
                            sqlCV.SqlFields("SA10", 1, APSQL.intFMode.msfld_num)
                            Dim clsLAB As New clsLabSpec
                            clsLAB.Width = Val(r.Item(1).ToString)
                            clsLAB.Height = Val(r.Item(3).ToString)
                            clsLAB.MultiX = Val(r.Item(2).ToString)
                            clsLAB.MultiY = Val(r.Item(4).ToString)
                            Select Case r.Item(5).ToString.Trim
                                Case "圓", "橢圓形"
                                    clsLAB.LabelShape = TpofLabelShape.LSOct
                                Case "切角"
                                    clsLAB.LabelShape = TpofLabelShape.LSTriRect
                                Case "特殊角"
                                    clsLAB.LabelShape = TpofLabelShape.LSOther
                                Case Else
                                    clsLAB.LabelShape = TpofLabelShape.LSRect
                            End Select
                            clsLAB.Radius = Val(r.Item(6).ToString)
                            clsLAB.PaperType = "P"
                            clsLAB.Remark = r.Item(22).ToString.Trim.Replace(vbCrLf, " ")
                            clsLAB.TextColor = r.Item(7).ToString.Trim
                            Dim bolA As Boolean = False
                            Dim strM As String = r.Item(8).ToString.Trim & BIG2GB(" 本色")
                            If aryM.ContainsKey(strM.ToUpper) Then
                                clsLAB.PaparSource = aryM(strM.ToUpper)
                            Else
                                clsLAB.PaparSource = "$" & (aryM.Count + 1).ToString("0000000")
                                aryM.Add(strM.ToUpper, clsLAB.PaparSource)
                                bolA = True
                            End If
                            sqlCV.SqlFields("SA14", clsLAB.ToString)
                            sqlCV.SqlFields("SA15", clsLAB.GetMainSpecEx)
                            sqlCV.SqlFields("SA20", clsLAB.GetWider)
                            DB.RsSQL(sqlCV.Text)
                            If bolA Then
                                sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "WMSA")
                                sqlCV.SqlFields("SA01", clsLAB.PaparSource)
                                sqlCV.SqlFields("SA02", strM)
                                sqlCV.SqlFields("SA03", "")
                                sqlCV.SqlFields("SA04", "1001")
                                sqlCV.SqlFields("SA05", "PCS")
                                sqlCV.SqlFields("SA06", 0, APSQL.intFMode.msfld_num)
                                sqlCV.SqlFields("SA07", 0, APSQL.intFMode.msfld_num)
                                sqlCV.SqlFields("SA08", 0, APSQL.intFMode.msfld_num)
                                sqlCV.SqlFields("SA09", "0")
                                sqlCV.SqlFields("SA10", 1, APSQL.intFMode.msfld_num)
                                DB.RsSQL(sqlCV.Text)
                            End If
                            sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "WMSAA")
                            sqlCV.SqlFields("SAA01", strIT)
                            sqlCV.SqlFields("SAA02", "01")
                            sqlCV.SqlFields("SAA03", 1, APSQL.intFMode.msfld_num)
                            sqlCV.SqlFields("SAA04", "")
                            sqlCV.SqlFields("SAA05", "*")
                            sqlCV.SqlFields("SAA06", "")
                            sqlCV.SqlFields("SAA07", "")
                            If aryM.ContainsKey(strType) Then
                                sqlCV.SqlFields("SAA08", aryM(strType))
                            Else
                                sqlCV.SqlFields("SAA08", "")
                            End If
                            sqlCV.SqlFields("SAA09", "")
                            DB.RsSQL(sqlCV.Text)

                        Case "5SDM", "5SDY"

                            Dim clsDia As New clsDieSpec
                            Dim clsLab As clsLabSpec = clsDia.DieLabelSpec
                            clsLab.Width = Val(r.Item(1).ToString)
                            clsLab.Height = Val(r.Item(3).ToString)
                            clsLab.MultiX = Val(r.Item(2).ToString)
                            clsLab.MultiY = Val(r.Item(4).ToString)
                            Dim intMods As Integer = Val(r.Item(5).ToString)
                            Dim intJump As Double = Val(r.Item(6).ToString)
                            Dim sngPaper As Double = Val(r.Item(12).ToString)
                            clsDia.ModGapY = Val(r.Item(7).ToString)
                            clsDia.ModGapX = Val(r.Item(8).ToString)
                            clsLab.CutDotLine = Val(r.Item(9).ToString)
                            clsDia.ModX = Val(r.Item(11).ToString)
                            clsDia.ModY = Val(r.Item(10).ToString)
                            Dim strRM As String = r.Item(13).ToString.Replace(vbCrLf, " ")
                            If strRM.StartsWith("圓") Or strRM.StartsWith("橢圓") Then
                                clsLab.LabelShape = TpofLabelShape.LSOct
                            ElseIf strRM.Contains("R=") Then
                                Dim intX As Integer = strRM.IndexOf("R=")
                                clsLab.LabelShape = TpofLabelShape.LSRect
                                clsLab.Radius = Val(strRM.Substring(intX + 2))
                            ElseIf strRM.StartsWith("R") Then
                                clsLab.LabelShape = TpofLabelShape.LSRect
                                clsLab.Radius = Val(strRM.Substring(1))
                            Else
                                clsLab.LabelShape = TpofLabelShape.LSRect
                            End If
                            'clsLab.Radius = Val(r.Item(10).ToString)
                            If r.Item(1).ToString.Trim.ToUpper.StartsWith("5SDY") Then
                                clsLab.PaparSource = "P"
                            Else
                                clsLab.PaperType = "B"
                            End If
                            clsDia.Remark = strRM
                            clsDia.ExtraPaperWidth = 0
                            If intMods <> clsLab.MultiX * clsLab.MultiY * clsDia.ModX * clsDia.ModY Then
                                If clsDia.JumpLength > intJump Then
                                    clsDia.ModY = Math.Floor((intJump + 0.01) / (clsLab.GetLableHeight + clsDia.ModGapY))
                                    If clsDia.JumpLength <> intJump Then
                                        clsDia.ModY *= clsLab.MultiY
                                        clsLab.MultiY = 1
                                    End If
                                ElseIf clsDia.JumpLength < intJump Then
                                    If Math.Abs(clsDia.JumpLength - intJump + (clsLab.MultiY - 1) * clsDia.ModGapY) < 0.0001 Then
                                        clsDia.ModY *= clsLab.MultiY
                                        clsLab.MultiY = 1
                                    Else
                                        clsDia.ModY *= Math.Floor((intJump + 0.01) / clsDia.JumpLength)
                                    End If
                                End If
                                If clsDia.PaperWidth < sngPaper Then
                                    If clsDia.ModGapX <= 2 Then
                                        clsLab.MultiGapX = clsDia.ModGapX
                                        clsDia.ModGapX *= 2
                                    Else
                                        clsDia.ModX *= clsLab.MultiX
                                        clsLab.MultiX = 1
                                    End If
                                End If
                                If clsDia.PaperWidth > sngPaper * 1.9 Then
                                    clsDia.ModX = Math.Floor(sngPaper / clsLab.GetPaperWidth)
                                End If
                            Else
                                If clsDia.JumpLength < intJump Then
                                    If Math.Abs(clsDia.JumpLength - intJump + (clsLab.MultiY - 1) * clsDia.ModGapY) < 0.0001 Then
                                        clsDia.ModY *= clsLab.MultiY
                                        clsLab.MultiY = 1
                                    End If
                                End If
                                If clsDia.PaperWidth < sngPaper Then
                                    clsDia.ModX = intMods / (clsLab.MultiY * clsDia.ModY)
                                    If clsDia.ModGapX <= 2 Then
                                        clsLab.MultiGapX = clsDia.ModGapX
                                        clsDia.ModGapX *= 2
                                    Else
                                        clsDia.ModX *= clsLab.MultiX
                                        clsLab.MultiX = 1
                                    End If
                                End If
                                If clsDia.PaperWidth > sngPaper * 1.9 Then
                                    clsDia.ModX = Math.Floor(sngPaper / clsLab.GetPaperWidth)
                                End If
                            End If
                            If clsDia.JumpLength <> intJump Then
                                If Math.Abs(clsDia.JumpLength + (clsDia.ModY * (clsLab.MultiY - 1) * clsDia.ModGapY) - intJump) < 0.01 Then
                                    clsDia.ModY *= clsLab.MultiY
                                    clsLab.MultiY = 1
                                Else
                                    IO.File.AppendAllText("D:\DIE_WARN.TXT", intCS.ToString("0000") & ":" & BIG2GB("無法找到匹配跳距") & " " & strIT & " " & clsLab.GetMainSpecEx & " J=" & intJump & "," & clsDia.JumpLength & vbCrLf, System.Text.Encoding.UTF8)
                                End If
                            End If
                            clsDia.ExtraPaperWidth = sngPaper - clsDia.PaperWidth
                            If clsDia.ExtraPaperWidth < 4 Then
                                clsLab.MultiGapX = 0
                                clsDia.ExtraPaperWidth = sngPaper - clsDia.PaperWidth
                                If clsDia.ExtraPaperWidth < 0 Then clsDia.ExtraPaperWidth = 0
                            End If
                            Dim strSP As String = clsLab.GetMainSpec
                            If aryA.ContainsKey(clsLab.GetWider) = False Then
                                IO.File.AppendAllText("D:\DIE_WARN_M.TXT", intCS.ToString("0000") & ":" & BIG2GB("無法找到匹配貼紙規格") & " " & strIT & " " & clsLab.GetMainSpecEx & " " & clsLab.GetWider & vbCrLf, System.Text.Encoding.UTF8)
                            End If
                            If bolHas Then
                                sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "WMSA")
                                sqlCV.Where("SA01", "=", strIT)
                            Else
                                sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "WMSA")
                                sqlCV.SqlFields("SA01", strIT)
                            End If
                            sqlCV.SqlFields("SA14", clsDia.ToString)
                            sqlCV.SqlFields("SA15", clsLab.GetMainSpecEx)
                            sqlCV.SqlFields("SA20", clsLab.GetWider)
                            If r.Item(1).ToString.Trim.ToUpper.StartsWith("5SDY") Then
                                sqlCV.SqlFields("SA02", BIG2GB("印刷刀模"))
                            Else
                                sqlCV.SqlFields("SA02", BIG2GB("貼紙刀模"))
                            End If
                            sqlCV.SqlFields("SA03", strSP)
                            sqlCV.SqlFields("SA04", strType)
                            sqlCV.SqlFields("SA05", "PCS")
                            sqlCV.SqlFields("SA06", 0, APSQL.intFMode.msfld_num)
                            sqlCV.SqlFields("SA07", 0, APSQL.intFMode.msfld_num)
                            sqlCV.SqlFields("SA08", 0, APSQL.intFMode.msfld_num)
                            sqlCV.SqlFields("SA09", "0")
                            sqlCV.SqlFields("SA10", 1, APSQL.intFMode.msfld_num)
                            DB.RsSQL(sqlCV.Text)
                            If bolHas Then Exit Select
                            sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "WMSAA")
                            sqlCV.SqlFields("SAA01", strIT)
                            sqlCV.SqlFields("SAA02", "01")
                            sqlCV.SqlFields("SAA03", 1, APSQL.intFMode.msfld_num)
                            sqlCV.SqlFields("SAA04", "")
                            sqlCV.SqlFields("SAA05", "*")
                            sqlCV.SqlFields("SAA06", "")
                            sqlCV.SqlFields("SAA07", "")
                            If aryM.ContainsKey(strType) Then
                                sqlCV.SqlFields("SAA08", aryM(strType))
                            Else
                                sqlCV.SqlFields("SAA08", "")
                            End If
                            sqlCV.SqlFields("SAA09", "")
                            DB.RsSQL(sqlCV.Text)
                    End Select
                    DB.CommitTransaction()
                Catch ex As Exception
                    DB.AbortTransaction()
                End Try
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try
        MsgBox(BIG2GB("Excel 轉檔完成"))
        PB.Value = 0
        PBS.Text = ""
        cs.Updated = True
        cs.Clean()
    End Sub
    Private Sub SOPDown()
        Dim OFL As New FolderBrowserDialog
        OFL.Description = BIG2GB("請選擇XPS所在資料夾")
        OFL.RootFolder = Environment.SpecialFolder.MyComputer
        OFL.SelectedPath = ""
        If OFL.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim strV() As String = IO.Directory.GetFiles(OFL.SelectedPath, "*XPS", IO.SearchOption.TopDirectoryOnly)
            If strV Is Nothing OrElse strV.Length = 0 Then Return
            Dim sqlCV As New APSQL.SQLCNV
            For Each strK As String In strV
                Dim strF As String = IO.Path.GetFileNameWithoutExtension(strK)
                sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "WMSA")
                sqlCV.SqlFields("WMSA", strK, intFMode.msfld_Image)
                DB.RsSQL(sqlCV.Text, sqlCV.GetImgs)
            Next
        End If
    End Sub
    Private Sub FrmSA01_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bol001 = clsRTS.GetRight(Me.Tag & "/001")
        bol003 = clsRTS.GetRight(Me.Tag & "/003")
        bol004 = clsRTS.GetRight(Me.Tag & "/004")
        ReICLASS()
        ReUnit()
        cs = New clsEDIT2012.clsEDITx2013(DG, DB, My.Settings.language)
        cs.ShowSearch = True
        cs.UnVisibles("SA14")
        cs.GetToolsItem("SAVE").Enabled = bol001
        cs.GetToolsItem("DELETE").Enabled = bol003
        If bol004 Then
            cs.AddToolsItem(BIG2GB("批次導入SOP"), My.Resources.XDOWN, AddressOf SOPDown)
            cs.AddToolsItem(BIG2GB("Excel轉入"), My.Resources.XDOWN, AddressOf XFDown)
            cs.AddToolsItem(BIG2GB("K3 ERP轉入"), My.Resources.XDOWN, AddressOf XFDown1)
            Button2.Enabled = True
        Else
            Button2.Enabled = False
        End If
        If FDG.ColumnCount = 0 Then
            FDG.Columns.Add(BIG2GB("包裝方式"), BIG2GB("包裝方式"))
            FDG.Columns.Add(BIG2GB("包裝數量"), BIG2GB("包裝數量"))
            FDG.Columns.Add(BIG2GB("識別條碼"), BIG2GB("識別條碼"))
            FDG.Columns.Add(BIG2GB("容積"), BIG2GB("容積"))
            FDG.Columns.Add(BIG2GB("重量"), BIG2GB("重量"))
            FDG.Columns.Add(BIG2GB("上層包裝"), BIG2GB("上層包裝"))
            FDG.Columns.Add(BIG2GB("標籤格式"), BIG2GB("標籤格式"))
            FDG.Columns.Add(BIG2GB("容量標示"), BIG2GB("容量標示"))
            FDG.Columns.Add(BIG2GB("客戶料號"), BIG2GB("客戶料號"))
            FDG.Columns.Add(BIG2GB("備註"), BIG2GB("備註"))
        End If
        For Each c As DataGridViewColumn In FDG.Columns
            c.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Next
#If WMS = 1 Then
        Button3.Visible = False
#Else
    Button3.Visible = True
    lod()
#End If
        cs.Clean()
        C1003.DB = DB
        C1010.DB = DB
        TabControl1.SelectedIndex = 2
    End Sub
    Private Sub ReICLASS()
        If bolUpdate1 = False Then Return
        Dim sqlCV As New APSQL.SQLCNV
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QTN")
        sqlCV.Where("QTN01", "=", "ICLASS")
        sqlCV.SqlFields("QTN02")
        sqlCV.SqlFields("QTN03")
        ComboBox1.DisplayMember = "QTN03"
        ComboBox1.ValueMember = "QTN02"
        ComboBox1.DataSource = DB.RsSQL(sqlCV.Text, "ICLASS")
        bolUpdate1 = False
    End Sub
    Private Sub ReUnit()
        If bolUpdate2 = False Then Return
        Dim sqlCV As New APSQL.SQLCNV
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QTN")
        sqlCV.Where("QTN01", "=", "UNIT")
        sqlCV.SqlFields("QTN02")
        sqlCV.SqlFields("QTN03")
        ComboBox2.DisplayMember = "QTN03"
        ComboBox2.ValueMember = "QTN02"
        ComboBox2.DataSource = DB.RsSQL(sqlCV.Text, "Unit")
        bolUpdate2 = False
    End Sub
    Private Sub cs_DVSelect(s As clsEDIT2012.clsEDITx2013, r As DataGridViewRow) Handles cs.DVSelect
        If r Is Nothing Then Return
        Label20.Text = ""
        My.Settings.X402 = ""
        My.Settings.X402NUM = 0
        My.Settings.Save()
        If GCell(r.Cells(BIG2GB("品號"))).Trim = "" Then Return
        TabControl1.SelectedIndex = 0
        Dim sqlcv As New APSQL.SQLCNV
        sqlcv.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "WMSA")
        sqlcv.Where("SA01", "=", GCell(r.Cells(BIG2GB("品號"))))
        sqlcv.SqlFields("*")
        sqlcv.sqlOrder("SA01")
        Dim rs As DataTable = DB.RsSQL(sqlcv.Text, "RS")
        If rs.Rows.Count <= 0 Then
            MsgBox(BIG2GB("查無此品號，" & GCell(r.Cells(BIG2GB("品號")))))
            cs.Clean()
        Else
            FDG.Rows.Clear()
            aryDT.Clear()
            For Each r1 As DataRow In rs.Rows
                ITNO.Text = r1!SA01.ToString.Trim
                ITNA.Text = r1!SA02.ToString.Trim
                ITSPEC.Text = r1!SA03.ToString.Trim
                ComboBox1.SelectedValue = r1!SA04.ToString.Trim
                If ComboBox1.SelectedValue Is Nothing Then ComboBox1.Text = r1!SA04.ToString.Trim
                ComboBox2.SelectedValue = r1!SA05.ToString.Trim
                If ComboBox2.SelectedValue Is Nothing Then ComboBox2.Text = r1!SA05.ToString.Trim
                STDAY.Text = r1!SA08.ToString.Trim
                ComboBox3.SelectedIndex = Val(r1!SA09.ToString.Trim)
                FIFOR.Text = r1!SA10.ToString.Trim
                SQTY.Text = r1!SA06.ToString.Trim
                Dim strL As String = r1!SA14.ToString.Trim
                ITVND.Text = r1!SA16.ToString.Trim
                ITENA.Text = r1!SA17.ToString.Trim
                RMK.Text = r1!SA18.ToString.Trim
                VEND.Text = r1!SA19.ToString.Trim
                Label16.Text = r1!SA12.ToString.Trim & " " & r1!SA13.ToString.Trim
                C1003.Visible = False
                C1010.Visible = False
                Panel6.Visible = False
                bolPICPV = False
                PIC1.BackgroundImage = Nothing
                PIC1.Tag = ""
                If strL <> "" Then
                    Select Case r1!SA04.ToString.Trim
                        Case "1003", "1004", "1008", "1009"
                            C1003.Visible = True
                            Panel6.Visible = True
                            C1003.SetLabSpec(ITNO.Text.Trim, ITNA.Text.Trim, strL)
                            Panel7.BackgroundImage = C1003.GetBmp
                            PIC1.BackgroundImage = C1003.GetBmp
                            MDL.ReadOnly = True
                        Case "1010", "1011"
                            C1010.Visible = True
                            Panel6.Visible = True
                            C1010.SetLabSpec(ITNO.Text.Trim, ITNA.Text.Trim, strL)
                            Panel7.BackgroundImage = C1010.GetBmp
                            PIC1.BackgroundImage = C1010.GetBmp
                            MDL.ReadOnly = True
                        Case Else
                            MDL.ReadOnly = False
                    End Select
                End If
                MDL.Text = r1!SA15.ToString.Trim
                If r1!SA11.GetType IsNot GetType(DBNull) Then
                    Dim bytV() As Byte = r1!SA11
                    Dim ms As New IO.MemoryStream
                    ms.Write(bytV, 0, bytV.Length)
                    PIC1.BackgroundImage = New Bitmap(ms)
                    PIC1.Tag = "1"
                    bolPICPV = True
                    ms.Close()
                    ms.Dispose()
                End If
            Next
            sqlcv.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "WMSAA")
            sqlcv.Where("SAA01", "=", GCell(r.Cells(BIG2GB("品號"))))
            sqlcv.SqlFields("*")
            sqlcv.sqlOrder("SAA02")
            rs = DB.RsSQL(sqlcv.Text, "RT")
            For Each r1 As DataRow In rs.Rows
                aryDT.Add(r1!SAA02.ToString.Trim, True)
                FDG.Rows.Add(r1!SAA02.ToString.Trim, Val(r1!SAA03.ToString), _
                             r1!SAA05.ToString.Trim, r1!SAA06.ToString.Trim, _
                             r1!SAA07.ToString.Trim, r1!SAA04.ToString.Trim, _
                             r1!SAA08.ToString.Trim, r1!SAA09.ToString.Trim, _
                             r1!SAA10.ToString.Trim, ClsX0401.ClsX40.GetX402str(r1!SAA11.ToString.Trim))
            Next
            FDG.AppendBegin()
        End If
    End Sub

    Private Sub cs_DVTable(s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles cs.DVTable
        Dim sqlcv As New APSQL.SQLCNV
        sqlcv.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "WMSA")
        sqlcv.Where("SA01", "NOT Like", "$%")
        sqlcv.SqlFields("SA04", "類別", , , True)
        sqlcv.SqlFields("SA01", "品號", , , True)
        sqlcv.SqlFields("SA02", "品名")
        sqlcv.SqlFields("SA03", "規格")
        sqlcv.SqlFields("SA05", "單位")
        sqlcv.SqlFields("SA14")
        strSQL = BIG2GB(sqlcv.Text)
    End Sub

    Private Sub cs_Frm_CheckDup(s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles cs.Frm_CheckDup
        Dim strKey As String = ITNO.Text.Trim
        Dim sqlcv As New APSQL.SQLCNV
        sqlcv.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "WMSA")
        sqlcv.Where("SA01", "=", strKey)
        sqlcv.SqlFields("*")
        strSQL = sqlcv.Text
    End Sub

    Private Sub cs_Frm_Clear(s As clsEDIT2012.clsEDITx2013) Handles cs.Frm_Clear
        If s Is Nothing Then
            TabControl1.SelectedIndex = 0
        Else
            TabControl1.SelectedIndex = 2
        End If
        ITNO.Text = ""
        ITNA.Text = ""
        ITSPEC.Text = ""
        STDAY.Text = "0"
        FIFOR.Text = "0"
        SQTY.Text = "0"
        MDL.Text = ""
        ITENA.Text = ""
        ITVND.Text = ""
        VEND.Text = ""
        RMK.Text = ""
        Label16.Text = ""
        MDL.ReadOnly = False
        If ComboBox1.Items.Count > 0 Then ComboBox1.SelectedIndex = 0
        If ComboBox2.Items.Count > 0 Then ComboBox2.SelectedIndex = 0
        ComboBox3.SelectedIndex = 0
        FDG.Rows.Clear()
        aryDT.Clear()
        C1010.Clear()
        C1003.Clear()
        PIC1.BackgroundImage = Nothing
        Panel7.BackgroundImage = Nothing
        FDG.AppendBegin()
    End Sub

    Private Sub cs_Frm_Delete(s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String, ByRef bolOK As Boolean) Handles cs.Frm_Delete
        Dim sqlCV As New APSQL.SQLCNV
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "WMSDA")
        sqlCV.Where("SDA01", "=", ITNO.Text.Trim)
        sqlCV.SqlFields("SDA01")
        Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        If rs.Rows.Count > 0 Then
            MsgBox(BIG2GB("這個品號已經開始使用於儲位規劃，無法刪除品號"))
            Return
        End If
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "WMSEA")
        sqlCV.Where("SEA04", "=", ITNO.Text.Trim)
        sqlCV.SqlFields("SEA04")
        rs = DB.RsSQL(sqlCV.Text, "RT")
        If rs.Rows.Count > 0 Then
            MsgBox(BIG2GB("這個品號已經開始使用於存取單據，無法刪除品號"))
            Return
        End If
        If MsgBox(BIG2GB("是否刪除品號:" & ITNO.Text & " 的相關資訊？請確定"), MsgBoxStyle.YesNo) = MsgBoxResult.No Then Return
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_delete, "WMSAA")
        sqlCV.Where("SAA01", "=", ITNO.Text.Trim)
        DB.RsSQL(sqlCV.Text)
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_delete, "WMSAB")
        sqlCV.Where("SAB02", "=", ITNO.Text.Trim)
        DB.RsSQL(sqlCV.Text)
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_delete, "WMSA")
        sqlCV.Where("SA01", "=", ITNO.Text)
        strSQL = sqlCV.Text
        bolOK = True
        cs.Clean()
    End Sub

    Private Sub cs_Frm_InsertM(s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles cs.Frm_InsertM
        Dim sqlcv As New APSQL.SQLCNV
        strSQL = ""
        UpdDtl()
        sqlcv.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "WMSA")
        sqlcv.SqlFields("SA01", ITNO.Text.Trim)
        sqlcv.SqlFields("SA02", ITNA.Text.Trim)
        sqlcv.SqlFields("SA03", ITSPEC.Text.Trim)
        sqlcv.SqlFields("SA04", ComboBox1.SelectedValue.ToString.Trim)
        sqlcv.SqlFields("SA05", ComboBox2.SelectedValue.ToString.Trim)
        sqlcv.SqlFields("SA06", SQTY.Text.Trim)
        sqlcv.SqlFields("SA08", STDAY.Text.Trim)
        sqlcv.SqlFields("SA09", ComboBox3.Text.Trim.Substring(0, 1))
        sqlcv.SqlFields("SA10", FIFOR.Text.Trim)
#If WMS <> 1 Then
    Dim str16() As String = (Label16.Text & " ").Split(" ")
    sqlcv.SqlFields("SA12", str16(0))
    sqlcv.SqlFields("SA13", str16(1))
#End If
        sqlcv.SqlFields("SA16", ITVND.Text.Trim)
        sqlcv.SqlFields("SA17", ITENA.Text.Trim)
        sqlcv.SqlFields("SA18", RMK.Text.Trim)
        sqlcv.SqlFields("SA19", VEND.Text.Trim)
        Select Case ComboBox1.SelectedValue.ToString.Trim
            Case "1003", "1004", "1008", "1009"
                'If C1003.Remark.Contains("**") = False Then
                '  C1003.Remark &= " **"
                'End If
                C1003.MakeSpec()
                sqlcv.SqlFields("SA14", C1003.ToString)
                sqlcv.SqlFields("SA15", C1003.GetLabelMaster)
                sqlcv.SqlFields("SA20", C1003.GetWider)
            Case "1010", "1011"
                'If C1010.RMK.Contains("**") = False Then
                '  C1010.RMK &= " **"
                'End If
                C1010.MakeSpec()
                sqlcv.SqlFields("SA14", C1010.ToString)
                sqlcv.SqlFields("SA15", C1010.GetLabelMaster)
                sqlcv.SqlFields("SA20", C1010.GetWider)
            Case Else
                sqlcv.SqlFields("SA15", MDL.Text)
                sqlcv.SqlFields("SA20", "NULL", intFMode.msfld_field)
                sqlcv.SqlFields("SA14", "NULL", intFMode.msfld_field)
        End Select
        If strFile <> "" Or strXPSFILE <> "" Then
            Dim bolTS As Boolean = False
            If strFile <> "*" And strFile <> "" And IO.File.Exists(strFile) = True Then
                sqlcv.SqlFields("SA11", strFile, APSQL.intFMode.msfld_Image)
                Dim a As String = sqlcv.Text
                bolTS = True
            End If
            If strXPSFILE <> "*" And strXPSFILE <> "" And IO.File.Exists(strXPSFILE) = True Then
                sqlcv.SqlFields("SA21", strXPSFILE, APSQL.intFMode.msfld_Image)
                bolTS = True
            End If
            If bolTS Then
                DB.RsSQL(sqlcv.Text, sqlcv.GetImgs)
                cs.Updated = True
                cs.Clean()
                Return
            End If
        End If
        If strFile = "*" Then
            strFile = ""
            sqlcv.SqlFields("SA11", "NULL", intFMode.msfld_field)
        End If
        If strXPSFILE = "*" Then
            strXPSFILE = ""
            sqlcv.SqlFields("SA21", "NULL", intFMode.msfld_field)
        End If
        DB.RsSQL(sqlcv.Text)
        cs.Updated = True
        cs.Clean()
    End Sub
    Private Sub UpdDtl()
        Dim sqlcv As New APSQL.SQLCNV
        'sqlcv.NomalNtext = False
        If strDEL <> "" Then
            sqlcv.sqlMAKE(APSQL.SQLCNV.intMode.mssql_delete, "WMSAA")
            sqlcv.Where("SAA02", "IN", strDEL.Trim(","), APSQL.intFMode.msfld_field)
            DB.RsSQL(sqlcv.Text)
            strDEL = ""
        End If
        aryDT.Clear()
        For Each r As DataGridViewRow In FDG.Rows
            Dim strK As String = GCell(r.Cells(BIG2GB("包裝方式"))).Trim
            If strK = "" Or aryDT.ContainsKey(strK) = True Then Continue For
            aryDT.Add(strK, True)
            sqlcv.sqlMAKE(APSQL.SQLCNV.intMode.mssql_update, "WMSAA")
            sqlcv.Where("SAA01", "=", ITNO.Text.Trim)
            sqlcv.Where("SAA02", "=", strK)
            sqlcv.SqlFields("SAA03", GCell(r.Cells(BIG2GB("包裝數量"))))
            sqlcv.SqlFields("SAA04", GCell(r.Cells(BIG2GB("上層包裝"))))
            sqlcv.SqlFields("SAA05", GCell(r.Cells(BIG2GB("識別條碼"))))
            sqlcv.SqlFields("SAA06", GCell(r.Cells(BIG2GB("容積"))))
            sqlcv.SqlFields("SAA07", GCell(r.Cells(BIG2GB("重量"))))
            sqlcv.SqlFields("SAA08", GCell(r.Cells(BIG2GB("標籤格式"))))
            sqlcv.SqlFields("SAA09", GCell(r.Cells(BIG2GB("容量標示"))))
            sqlcv.SqlFields("SAA10", GCell(r.Cells(BIG2GB("客戶料號"))))
            Dim strA() As String = My.Settings.X402.Split(";")
            If My.Settings.X402 <> "" Then '20220729新增
                sqlcv.SqlFields("SAA11", strA(5))
            End If
            Dim intL As Integer = DB.RsSQL(sqlcv.Text)
            If intL = 0 Then
                sqlcv.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "WMSAA")
                sqlcv.SqlFields("SAA01", ITNO.Text.Trim)
                sqlcv.SqlFields("SAA02", strK)
                sqlcv.SqlFields("SAA03", GCell(r.Cells(BIG2GB("包裝數量"))))
                sqlcv.SqlFields("SAA04", GCell(r.Cells(BIG2GB("上層包裝"))))
                sqlcv.SqlFields("SAA05", GCell(r.Cells(BIG2GB("識別條碼"))))
                sqlcv.SqlFields("SAA06", GCell(r.Cells(BIG2GB("容積"))))
                sqlcv.SqlFields("SAA07", GCell(r.Cells(BIG2GB("重量"))))
                sqlcv.SqlFields("SAA08", GCell(r.Cells(BIG2GB("標籤格式"))))
                sqlcv.SqlFields("SAA09", GCell(r.Cells(BIG2GB("容量標示"))))
                sqlcv.SqlFields("SAA10", GCell(r.Cells(BIG2GB("客戶料號"))))

                sqlcv.SqlFields("SAA11", ClsX0401.ClsX40.GetX402(GCell(r.Cells(BIG2GB("備註")))))
                DB.RsSQL(sqlcv.Text)
            End If
        Next
    End Sub
    Private Sub cs_Frm_UpdateM(s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles cs.Frm_UpdateM
        Dim sqlcv As New APSQL.SQLCNV
        strSQL = ""
        UpdDtl()
        sqlcv.sqlMAKE(APSQL.SQLCNV.intMode.mssql_update, "WMSA")
        sqlcv.Where("SA01", "=", ITNO.Text.Trim)
        sqlcv.SqlFields("SA02", ITNA.Text.Trim)
        sqlcv.SqlFields("SA03", ITSPEC.Text.Trim)
        sqlcv.SqlFields("SA04", ComboBox1.SelectedValue.ToString.Trim)
        sqlcv.SqlFields("SA05", ComboBox2.SelectedValue.ToString.Trim)
        sqlcv.SqlFields("SA06", SQTY.Text.Trim)
        sqlcv.SqlFields("SA08", STDAY.Text.Trim)
        sqlcv.SqlFields("SA09", ComboBox3.Text.Trim.Substring(0, 1))
        sqlcv.SqlFields("SA10", FIFOR.Text.Trim)
#If WMS <> 1 Then
    Dim str16() As String = (Label16.Text & " ").Split(" ")
    sqlcv.SqlFields("SA12", str16(0))
    sqlcv.SqlFields("SA13", str16(1))
#End If
        sqlcv.SqlFields("SA16", ITVND.Text.Trim)
        sqlcv.SqlFields("SA17", ITENA.Text.Trim)
        sqlcv.SqlFields("SA18", RMK.Text.Trim)
        sqlcv.SqlFields("SA19", VEND.Text.Trim)
        Select Case ComboBox1.SelectedValue.ToString.Trim
            Case "1003", "1004", "1008", "1009"
                'If C1003.Remark.Contains("**") = False Then
                '  C1003.Remark &= " **"
                'End If
                C1003.MakeSpec()
                sqlcv.SqlFields("SA14", C1003.ToString)
                sqlcv.SqlFields("SA15", C1003.GetLabelMaster)
                sqlcv.SqlFields("SA20", C1003.GetWider)
            Case "1010", "1011"
                'If C1010.RMK.Contains("**") = False Then
                '  C1010.RMK &= " **"
                'End If
                C1010.MakeSpec()
                sqlcv.SqlFields("SA14", C1010.ToString)
                sqlcv.SqlFields("SA15", C1010.GetLabelMaster)
                sqlcv.SqlFields("SA20", C1010.GetWider)
            Case Else
                sqlcv.SqlFields("SA15", MDL.Text.Trim)
                sqlcv.SqlFields("SA20", "NULL", intFMode.msfld_field)
                sqlcv.SqlFields("SA14", "NULL", intFMode.msfld_field)
        End Select
        If strFile <> "" Or strXPSFILE <> "" Then
            Dim bolTS As Boolean = False
            If strFile <> "*" And strFile <> "" And IO.File.Exists(strFile) = True Then
                sqlcv.SqlFields("SA11", strFile, APSQL.intFMode.msfld_Image)
                bolTS = True
            End If
            If strXPSFILE <> "*" And strXPSFILE <> "" And IO.File.Exists(strXPSFILE) = True Then
                sqlcv.SqlFields("SA21", strXPSFILE, APSQL.intFMode.msfld_Image)
                bolTS = True
            End If
            If bolTS Then
                Dim a As String = sqlcv.Text
                DB.RsSQL(sqlcv.Text, sqlcv.GetImgs)
                cs.Updated = True
                cs.Clean()
                Return
            End If
        End If
        If strFile = "*" Then
            strFile = ""
            sqlcv.SqlFields("SA11", "NULL", intFMode.msfld_field)
        End If
        If strXPSFILE = "*" Then
            strXPSFILE = ""
            sqlcv.SqlFields("SA21", "NULL", intFMode.msfld_field)
        End If
        Dim b As String = sqlcv.Text
        DB.RsSQL(sqlcv.Text)
        cs.Updated = True
        cs.Clean()
    End Sub

    Private Sub cs_isDataValid(s As clsEDIT2012.clsEDITx2013, ByRef bolOK As Boolean) Handles cs.isDataValid
        FDG.CommitEdit(DataGridViewDataErrorContexts.Commit)
        If FDG.RowCount = 0 Then
            MsgBox(BIG2GB("沒有填寫任何識別條碼"))
            Return
        End If
        If ComboBox1.SelectedValue Is Nothing OrElse ComboBox1.SelectedValue.ToString.Trim = "" Then
            MsgBox(BIG2GB("沒有選擇分類代碼，並且代碼不得空白"))
            Return
        End If
        If ComboBox2.SelectedValue Is Nothing OrElse ComboBox2.SelectedValue.ToString.Trim = "" Then
            MsgBox(BIG2GB("沒有選擇單位，並且不得空白"))
            Return
        End If
        Select Case ComboBox1.SelectedValue.ToString.Trim
            Case "1003", "1004", "1008", "1009"
                C1003.MakeSpec()
                If Val(C1003.PapHeight) < 1 Or Val(C1003.PapLength) < 1 Then
                    MsgBox(BIG2GB("沒有設置紙張規格"))
                    TabControl1.SelectedIndex = 1
                    Return
                End If
            Case "1010", "1011"
                C1010.MakeSpec()
                If Val(C1010.PapHeight) < 1 Or Val(C1010.PapLength) < 1 Then
                    MsgBox(BIG2GB("沒有設置紙張規格"))
                    TabControl1.SelectedIndex = 1
                    Return
                End If
        End Select
        Dim strM As String = "", bolHas As Boolean = False
        For Each r As DataGridViewRow In FDG.Rows
            Dim strK As String = GCell(r.Cells(0)).Trim
            If strK = "" Or GCell(r.Cells(BIG2GB("識別條碼"))).Trim = "" Then Continue For
            If GCell(r.Cells(BIG2GB("識別條碼"))).Trim.Contains(",") = False Then
                strM &= "'" & GCell(r.Cells(BIG2GB("識別條碼"))).Trim & "'," '條碼是一個固定編號
            End If
            bolHas = True
            If aryDT.ContainsKey(strK) = True Then aryDT(strK) = False
        Next
        strDEL = ""
        If bolHas = False Then
            FDG.Rows(0).Cells(0).Value = "01"
            FDG.Rows(0).Cells(1).Value = 1
            FDG.Rows(0).Cells(2).Value = "*"
            'MsgBox(BIG2GB("沒有填寫任何包裝方式及識別條碼"))
            'Return
        End If
        For Each strP As String In aryDT.Keys
            If aryDT(strP) = True Then
                strDEL = "'" & strP & "',"
            End If
        Next
        Dim sqlCV As New APSQL.SQLCNV
        'sqlCV.NomalNtext = False
        If strDEL <> "" Then
            sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_distinc, "WMSF")
            sqlCV.Where("SF01", "=", ITNO.Text.Trim)
            sqlCV.Where("SF19", "IN", strDEL.Trim(","), APSQL.intFMode.msfld_field)
            sqlCV.SqlFields("SF19")
            Dim rs1 As DataTable = DB.RsSQL(sqlCV.Text, "RT")
            If rs1.Rows.Count > 0 Then
                MsgBox(BIG2GB("這個包裝方式已經有存貨，不可以刪除：" & strDEL.Trim(",")))
                Return
            End If
        End If
        'If strM.Trim(",") <> "" Then
        '  sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "WMSAA")
        '  sqlCV.Where("SAA01", "<>", TextBox1.Text.Trim)
        '  sqlCV.Where("SAA05", "IN", strM.Trim(","), APSQL.intFMode.msfld_field)
        '  sqlCV.SqlFields("SAA05")
        '  sqlCV.SqlFields("SAA01")
        '  sqlCV.SqlFields("SAA02")
        '  Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        '  If rs.Rows.Count > 0 Then
        '    strM = ""
        '    For Each r As DataRow In rs.Rows
        '      strM &= r!SAA05.ToString.Trim & "=" & r!SAA01.ToString.Trim & "-" & r!SAA02.ToString.Trim & vbCrLf
        '    Next
        '    MsgBox(BIG2GB("條碼編號重複使用" & vbCrLf & strM))
        '    Return
        '  End If
        'End If
        bolOK = True
    End Sub

    Private Sub DG_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DG.DataBindingComplete
        bolOKDM = False
        aryDM.Clear()
        For Each r As DataGridViewRow In DG.Rows
            If GCell(r.Cells("SA14")).Contains("**") Then
                If aryDM.Contains(r.Index) = False Then
                    aryDM.Add(r.Index)
                End If
            End If
        Next
        bolOKDM = True
        DG.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
    End Sub

    Private Sub DG_Scroll(sender As Object, e As ScrollEventArgs) Handles DG.Scroll
        aryDM.Clear()
        DG.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
    End Sub

    Private Sub FDG_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs)
        FDG.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
    End Sub

    Private Sub FDG_Scroll(sender As Object, e As ScrollEventArgs)
        FDG.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
    End Sub

    Private Sub ComboBox1_GotFocus(sender As Object, e As EventArgs) Handles ComboBox1.GotFocus
        ReICLASS()
    End Sub

    Private Sub ComboBox2_GotFocus(sender As Object, e As EventArgs) Handles ComboBox2.GotFocus
        ReUnit()
    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress, ComboBox2.KeyPress
        If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
            e.Handled = True
            My.Computer.Keyboard.SendKeys(vbTab)
        End If
    End Sub

    Private Sub ComboBox1_LostFocus(sender As Object, e As EventArgs) Handles ComboBox1.LostFocus
        Dim strM As String = ""
        If ComboBox1.SelectedValue IsNot Nothing Then
            strM = ComboBox1.SelectedValue.ToString.Trim
        End If
        ComboBox1.SelectedValue = strM
        MDL.ReadOnly = False
        Select Case strM
            Case "1003", "1004", "1010", "1008", "1009", "1011"
                MDL.ReadOnly = True
        End Select
    End Sub

    Private Sub ComboBox2_LostFocus(sender As Object, e As EventArgs) Handles ComboBox2.LostFocus
        Dim strM As String = ComboBox2.Text.Trim
        If strM = "" Then
            Return
        End If
        For Each r As DataRowView In ComboBox2.Items
            If strM = r!QTN03.ToString.Trim Then
                ComboBox2.SelectedValue = r!QTN02.ToString
                Return
            End If
        Next
        If MsgBox(BIG2GB("新增單位[" & strM & "]，請確定"), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
            Dim sqlCV As New APSQL.SQLCNV
            sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "SFIS_QTN")
            sqlCV.SqlFields("QTN01", "UNIT")
            sqlCV.SqlFields("QTN02", strM)
            sqlCV.SqlFields("QTN03", strM)
            sqlCV.SqlFields("QTN04", strM)
            DB.RsSQL(sqlCV.Text)
            bolUpdate2 = True
            ReUnit()
            ComboBox2.SelectedValue = strM
        Else
            ComboBox2.Text = ""
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ITNO.KeyPress, ITNA.KeyPress, ITSPEC.KeyPress, TextBox1.KeyPress
        If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
            e.Handled = True
            My.Computer.Keyboard.SendKeys(vbTab)
        End If
    End Sub

    Private Sub ITNO_Validated(sender As Object, e As EventArgs) Handles ITNO.Validated
        If ITNO.Text.Trim = "" Then Return
        For Each r As DataGridViewRow In DG.Rows
            If GCell(r.Cells(BIG2GB("品號"))).Trim = ITNO.Text.Trim Then
                cs_DVSelect(cs, r)
                Return
            End If
        Next
        Dim strK As String = ITNO.Text.Trim
        cs_Frm_Clear(Nothing)
        ITNO.Text = strK
    End Sub
    '用來將openfiledialog自動選取縮圖
    Private Sub tmr_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmr.Tick
        ' 取得 Dialog 視窗 handle  
        Dim hwnd As Int32 = FindWindowExA(GetActiveWindow, 0, "SHELLDLL_DefView", vbNullString)
        If hwnd > 0 Then
            SendMessageA(hwnd, &H111, 28717, 0) ' 傳訊息 VIEW_THUMBNAIL  
            tmr.Stop() ' 停止 Timer  
        End If
    End Sub
    Private Function AutoLoads() As Boolean
        Dim sqlCV As New APSQL.SQLCNV, bolT As Boolean = False
        If ComboBox1.SelectedValue Is Nothing Then Return False
        If DBFERP Is Nothing OrElse DBFERP.Active = False Then Return False
        Dim strC As String = ComboBox1.SelectedValue.ToString.Trim
        If strC <> "1008" And strC <> "1009" And strC <> "1011A" Then Return False
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
        sqlCV.Where("QTN01", "=", "@UPDATEQ")
        sqlCV.Where("QTN02", "=", "WM302_" & strC)
        sqlCV.SqlFields("QTN03")
        Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        If rs.Rows.Count = 0 OrElse rs.Rows(0)!QTN03.ToString.Trim <> "1" Then
            If rs.Rows.Count = 0 Then
                sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_QTN")
                sqlCV.SqlFields("QTN01", "@UPDATEQ")
                sqlCV.SqlFields("QTN02", "WM302_" & strC)
                sqlCV.SqlFields("QTN03", "1")
            Else
                sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_QTN")
                sqlCV.Where("QTN01", "=", "@UPDATEQ")
                sqlCV.Where("QTN02", "=", "WM302_" & strC)
                sqlCV.SqlFields("QTN03", "1")
            End If
            DB.RsSQL(sqlCV.Text)
            PBS.Text = BIG2GB("資料讀取中")
            Panel5.Refresh()
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "WMSA")
            sqlCV.Where("SA04", "=", strC)
            sqlCV.Where("SA11", "IS", "NULL", intFMode.msfld_field)
            sqlCV.SqlFields("SA01")
            rs = DB.RsSQL(sqlCV.Text, "RT")
            Dim aryL As New ArrayList, aryL1 As New ArrayList
            For Each r As DataRow In rs.Rows
                aryL.Add(r!SA01.ToString.Trim)
            Next
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "WMSA")
            sqlCV.Where("SA04", "=", strC)
            sqlCV.Where("SA11", "IS NOT", "NULL", intFMode.msfld_field)
            sqlCV.SqlFields("SA01")
            rs = DB.RsSQL(sqlCV.Text, "RT")
            For Each r As DataRow In rs.Rows
                aryL1.Add(r!SA01.ToString.Trim)
            Next
            If strC = "1011A" Then
                sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "BM_ysdm_fn")
                sqlCV.Where("t", "IS NOT", "NULL", intFMode.msfld_field)
                sqlCV.SqlFields("fndh")
                sqlCV.SqlFields("dmdh")
                sqlCV.SqlFields("t")
                Dim rs1 As DataTable = DBFERP.RsSQL(sqlCV.Text, "RT")
                PB.Maximum = rs1.Rows.Count
                PB.Value = 0
                PB.Minimum = 0
                PBS.Text = "0/" & rs1.Rows.Count
                For Each r As DataRow In rs1.Rows
                    PB.Value += 1
                    PBS.Text = PB.Value & "/" & rs1.Rows.Count
                    Panel5.Refresh()
                    Dim strI As String = "5S" & r!fndh.ToString.Trim
                    If aryL.Contains(strI) Then
                        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "WMSA")
                        sqlCV.Where("SA01", "=", strI)
                        Dim bytV() As Byte = r!t
                        sqlCV.SqlFields("SA11", bytV)
                        DB.RsSQL(sqlCV.Text, sqlCV.GetImgs)
                        bolT = True
                    Else
                        If aryL1.Contains(strI) Then Continue For
                        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "WMSA")
                        sqlCV.Where("SA01", "=", "5S" & r!dmdh.ToString.Trim)
                        sqlCV.SqlFields("SA01")
                        sqlCV.SqlFields("SA03")
                        sqlCV.SqlFields("SA15")
                        rs = DB.RsSQL(sqlCV.Text, "RT")
                        If rs.Rows.Count = 0 Then Continue For
                        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "WMSA")
                        sqlCV.SqlFields("SA01", strI)
                        sqlCV.SqlFields("SA02", BIG2GB("印刷菲林"))
                        sqlCV.SqlFields("SA03", rs.Rows(0)!SA03.ToString.Trim & BIG2GB(" 刀模=") & rs.Rows(0)!SA01.ToString.Trim)
                        sqlCV.SqlFields("SA04", strC)
                        sqlCV.SqlFields("SA15", rs.Rows(0)!SA15.ToString.Trim)
                        Dim bytV() As Byte = r!t
                        sqlCV.SqlFields("SA11", bytV)
                        DB.RsSQL(sqlCV.Text, sqlCV.GetImgs)
                        bolT = True
                    End If
                Next
            Else
                sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "BM_ysdhb")
                sqlCV.Where("t", "IS NOT", "NULL", intFMode.msfld_field)
                sqlCV.SqlFields("dh")
                sqlCV.SqlFields("t")
                Dim rs1 As DataTable = DBFERP.RsSQL(sqlCV.Text, "RT")
                PB.Maximum = rs1.Rows.Count
                PB.Value = 0
                PB.Minimum = 0
                PBS.Text = "0/" & rs1.Rows.Count
                For Each r As DataRow In rs1.Rows
                    PB.Value += 1
                    PBS.Text = PB.Value & "/" & rs1.Rows.Count
                    Panel5.Refresh()
                    Dim strI As String = "1" & r!dh.ToString.Trim
                    If aryL.Contains(strI) Then
                        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "WMSA")
                        sqlCV.Where("SA01", "=", strI)
                        Dim bytV() As Byte = r!t
                        sqlCV.SqlFields("SA11", bytV)
                        DB.RsSQL(sqlCV.Text, sqlCV.GetImgs)
                        bolT = True
                    End If
                Next
            End If
        End If
        Return bolT
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If AutoLoads() = True Then
            MsgBox(BIG2GB("更新圖檔完成"))
            Return
        End If
        Dim OFD As New OpenFileDialog
        Dim strFS As String = strFile
        If strFS = "" Then strFS = My.Settings.ImgPATH
        If strFS = "" Then strFS = My.Computer.FileSystem.SpecialDirectories.MyPictures
        With OFD
            .Title = "選取圖檔"
            .InitialDirectory = strFS
            .FileName = IO.Path.GetFileName(strFile)
            .Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*"
            '--用來將openfiledialog自動選取縮圖
            tmr = New Timer
            tmr.Interval = 100
            tmr.Start()
            '--
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                If IO.File.Exists(.FileName) = False Then
                    PIC1.BackgroundImage = Nothing
                    strFile = ""
                    PIC1.Tag = ""
                    bolPICPV = False
                Else
                    strFile = .FileName
                    PIC1.BackgroundImage = Image.FromFile(.FileName)
                    PIC1.Tag = "1"
                    bolPICPV = True
                End If
            End If
        End With
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Panel3.Visible = CheckBox1.Checked
        If Panel3.Visible Then Panel3.Width = PIC1.Width
    End Sub

    Private Sub FDG_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles FDG.CellDoubleClick
        If e.RowIndex < 0 Or e.RowIndex >= FDG.Rows.Count Then Return
        If GCell(FDG.Rows(e.RowIndex).Cells(0)) = "" Then Return
        If e.ColumnIndex = 6 Then
            Dim frm As New WMSLABFORM
            frm.ID = GCell(FDG.Rows(e.RowIndex).Cells(e.ColumnIndex))
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                FDG.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = frm.ID
                ShowIMG(FDG.CurrentRow)
            End If
        End If
    End Sub
    Private Sub ShowIMG(r As DataGridViewRow)
        If r Is Nothing Or CheckBox1.Checked = False Then Return
        Dim sqlCV As New APSQL.SQLCNV
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QTN")
        sqlCV.Where("QTN01", "=", "#LABELS")
        sqlCV.Where("QTN02", "=", GCell(r.Cells(6)))
        sqlCV.SqlFields("QTN05")
        Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        If rs.Rows.Count = 0 Then
            Panel3.BackgroundImage = Nothing
        Else
            If rs.Rows(0)!QTN05.GetType Is GetType(DBNull) Then
                Panel3.BackgroundImage = Nothing
            Else
                Dim bytV() As Byte = rs.Rows(0)!QTN05
                Dim ms As New IO.MemoryStream
                ms.Write(bytV, 0, bytV.Length)
                Panel3.BackgroundImage = New Bitmap(ms)
                ms.Close()
                ms.Dispose()
            End If
        End If
    End Sub
    Private Sub FDG_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles FDG.RowEnter
        If e.RowIndex < 0 Or e.RowIndex >= FDG.Rows.Count Then Return
        ShowIMG(FDG.Rows(e.RowIndex))
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DBERP Is Nothing OrElse DBERP.Active = False Then Return
        Dim sqlCV As New APSQL.SQLCNV
#If K3 = 1 Then
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "t_ICItem")
        sqlCV.Where("^0.FNumber", "=", ITNO.Text.Trim)
        sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "t_MeasureUnit", "FMeasureUnitID", "=", "^0.FUnitID")
        sqlCV.SqlFields("^0.FNumber", "item_no")
        sqlCV.SqlFields("^0.FFullName", "part_name")
        sqlCV.SqlFields("^0.FModel", "part_spec")
        sqlCV.SqlFields("^1.FName", "base_name")
        sqlCV.SqlFields("^0.F_102", "ITVND")
        sqlCV.SqlFields("^0.F_113", "VEND")
#ElseIf K3 = 4 Then
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "obas_part")
    sqlCV.SqlJoin(APSQL.SQLCNV.intJoinMode.msJoin_Inner, "obas_part1", "part_no", "=", "^0.part_no")
    sqlCV.SqlJoin(APSQL.SQLCNV.intJoinMode.msJoin_Left, "obas_base_code", "base_code", "=", "^1.unit_no")
    sqlCV.SqlJoin(APSQL.SQLCNV.intJoinMode.msJoin_Left, "obas_part_type", "type_no", "=", "^1.part_type")
    sqlCV.Where("^0.item_no", "=", ITNO.Text.Trim)
    sqlCV.SqlFields("^0.item_no")
    sqlCV.SqlFields("^0.part_name")
    sqlCV.SqlFields("^0.part_spec")
    sqlCV.SqlFields("^2.base_name")
    sqlCV.SqlFields("^1.part_type")
    sqlCV.SqlFields("^3.type_name")
#End If
        Dim rs As DataTable = DBERP.RsSQL(sqlCV.Text, "RT")
        If rs.Rows.Count = 0 Then
            MsgBox(BIG2GB("ERP無此料品編號資料"))
            Return
        End If
        ITNA.Text = rs.Rows(0)!part_name.ToString.Trim
        ITSPEC.Text = rs.Rows(0)!part_spec.ToString.Trim
#If K3 = 1 Then
        VEND.Text = rs.Rows(0)!VEND.ToString.Trim
        ITVND.Text = rs.Rows(0)!ITVND.ToString.Trim
        ComboBox2.SelectedValue = rs.Rows(0)!base_name.ToString.Trim
        If ComboBox2.SelectedValue Is Nothing Then
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_QTN")
            sqlCV.SqlFields("QTN01", "UNIT")
            sqlCV.SqlFields("QTN02", rs.Rows(0)!base_name.ToString.Trim)
            sqlCV.SqlFields("QTN03", rs.Rows(0)!base_name.ToString.Trim)
            DB.RsSQL(sqlCV.Text)
            ReUnit()
            ComboBox2.SelectedValue = rs.Rows(0)!base_name.ToString.Trim
        End If
#ElseIf K3 = 4 Then
    ComboBox1.SelectedValue = rs.Rows(0)!part_type.ToString.Trim
    If ComboBox1.SelectedValue Is Nothing Then
      ComboBox1.Text = rs.Rows(0)!part_type.ToString.Trim
      ComboBox1_LostFocus(Nothing, Nothing)
    End If
    ComboBox2.SelectedValue = rs.Rows(0)!base_name.ToString.Trim
    If ComboBox2.SelectedValue Is Nothing Then
      ComboBox2.Text = rs.Rows(0)!base_name.ToString.Trim
      ComboBox2_LostFocus(Nothing, Nothing)
    End If
#End If
        MsgBox(BIG2GB("已經與ERP同步"))
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Then
            If ComboBox1.SelectedValue Is Nothing Then Return
            Panel6.Visible = False
            C1003.Visible = False
            C1010.Visible = False
            Select Case ComboBox1.SelectedValue.ToString.Trim
                Case "1003", "1004", "1008", "1009"
                    C1003.Visible = True
                    Panel6.Visible = True
                    C1003.SetLabSpec(ITNO.Text, ITNA.Text, "")
                    C1003.ID = ITNO.Text.Trim
                    C1003.Info = ITNA.Text.Trim
                Case "1010", "1011"
                    C1010.Visible = True
                    Panel6.Visible = True
                    C1010.SetLabSpec(ITNO.Text, ITNA.Text, "")
                    C1010.ID = ITNO.Text.Trim
                    C1010.Info = ITNA.Text.Trim
            End Select
        End If
    End Sub

    Private Sub Panel7_Click(sender As Object, e As EventArgs) Handles Panel7.Click
        If C1003.Visible = True Then
            C1003.MakeSpec()
            Panel7.BackgroundImage = C1003.GetBmp
            If PIC1.Tag Is Nothing OrElse PIC1.Tag.ToString = "" Then PIC1.BackgroundImage = C1003.GetBmp
        ElseIf C1010.Visible = True Then
            C1010.MakeSpec()
            Panel7.BackgroundImage = C1010.GetBmp
            If PIC1.Tag Is Nothing OrElse PIC1.Tag.ToString = "" Then PIC1.BackgroundImage = C1010.GetBmp
        End If
    End Sub

    Private Sub Panel7_CursorChanged(sender As Object, e As EventArgs) Handles Panel7.CursorChanged

    End Sub

    Private Sub Panel7_DoubleClick(sender As Object, e As EventArgs) Handles Panel7.DoubleClick
        Dim frm As New WMS0302A
        frm.SetImage(PIC1.BackgroundImage)
        frm.ShowDialog()
    End Sub
#If WMS <> 1 Then
  Sub lod()
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TB")
    sqlCV.SqlFields("TB01", "流程編號")
    sqlCV.SqlFields("TB02", "流程版本")
    sqlCV.SqlFields("TB03", "流程說明")
    Dliucheng = New FrmDialog(BIG2GB("流程編號"), BIG2GB(sqlCV.Text) & "$^$")
  End Sub

  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    If Dliucheng.ShowDialog() = DialogResult.OK Then
      Label16.Text = Dliucheng.rw.Cells(0).Value.ToString & " " & Dliucheng.rw.Cells(1).Value.ToString
    Else
      Label16.Text = ""
    End If
  End Sub
#End If

    Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles TextBox1.LostFocus
        If TextBox1.Text.Trim = "" Then Return
        Dim frm As New FrmQrySA
        frm.QRY = TextBox1.Text.Trim
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim strV() As String = frm.Item
            If strV IsNot Nothing AndAlso strV.Length = 1 Then
                ITNO.Text = strV(0)
                ITNO_Validated(Nothing, Nothing)
                TextBox1.Text = ""
            End If
        Else
            TextBox1.Text = ""
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If ComboBox1.SelectedValue Is Nothing Then
            MsgBox(BIG2GB("請先選擇類別再點自動編碼"))
            Return
        End If
        If ComboBox1.SelectedValue.ToString.Trim = "1011" Then
            MsgBox(BIG2GB("菲林類別無法使用自動編碼"))
            Return
        End If
        Dim sqlCV As New APSQL.SQLCNV
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "WMSA")
        sqlCV.Where("SA04", "=", ComboBox1.SelectedValue.ToString.Trim)
        sqlCV.SqlFields("MAX(SA01)", "MAXV")
        Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        If rs.Rows.Count = 0 Then
            ITNO.Text = ""
            Return
        End If
        Dim strI As String = rs.Rows(0)!MAXV.ToString.Trim
        Dim strN As String = ""
        If strI.Trim = "" Then
            ITNO.Text = ""
            Return
        End If
        For intI As Integer = strI.Length - 1 To 0 Step -1
            If strI(intI) < "0"c Or strI(intI) > "9" Then
                strN = strI.Substring(intI + 1)
                strI = strI.Substring(0, intI + 1)
                Exit For
            End If
        Next
        If strN = "" Then
            ITNO.Text = ""
            Return
        End If
        Dim intS As Integer = ComboBox1.SelectedIndex
        cs_Frm_Clear(Nothing)
        If ComboBox1.SelectedValue.ToString.Trim = "1001" Then '20220729新增
            FDG.Rows(0).Cells(0).Value = "01"
            FDG.Rows(0).Cells(2).Value = "*"
            FDG.Rows(0).Cells(6).Value = "C01"
        End If
        ITNO.Text = strI & (Val(strN) + 1).ToString("00000")
        ComboBox1.SelectedIndex = intS
    End Sub

    Private Sub PIC1_DoubleClick(sender As Object, e As EventArgs) Handles PIC1.DoubleClick
        Dim frm As New WMS0302A
        frm.SetImage(PIC1.BackgroundImage)
        frm.ShowDialog()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim OFD As New OpenFileDialog
        Dim strFS As String = strFile
        If strFS = "" Then strFS = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        With OFD
            .Title = "選取SOP XPS"
            .InitialDirectory = strFS
            .FileName = IO.Path.GetFileName(strXPSFILE)
            .Filter = "XPS檔案|*.XPS;*.oxps|All files (*.*)|*.*"
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                strXPSFILE = .FileName
            End If
        End With

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        strFile = "*"
        If bolPICPV Then
            PIC1.BackgroundImage = Nothing
            PIC1.Tag = ""
            bolPICPV = False
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        strXPSFILE = "*"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim sqlCV As New APSQL.SQLCNV
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "WMSA")
        sqlCV.Where("SA01", "=", ITNO.Text.Trim)
        sqlCV.SqlFields("SA21")
        Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        If rs.Rows.Count = 0 Then Return
        If rs.Rows(0)!SA21.GetType Is GetType(DBNull) Then
            If strXPSFILE <> "" And strXPSFILE <> "" And IO.File.Exists(strXPSFILE) Then
                System.Diagnostics.Process.Start(strXPSFILE)
            End If
            Return
        End If
        Dim bytV() As Byte = rs.Rows(0)!SA21
        If bytV Is Nothing OrElse bytV.Length = 0 Then
            If strXPSFILE <> "" And strXPSFILE <> "" And IO.File.Exists(strXPSFILE) Then
                System.Diagnostics.Process.Start(strXPSFILE)
            End If
            Return
        End If
        IO.File.WriteAllBytes(strAPATH.Trim("\/".ToCharArray) & "\TEMP.XPS", bytV)
        Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start(strAPATH.Trim("\/".ToCharArray) & "\TEMP.XPS")
        intPro = p.Id
        System.Diagnostics.Process.GetProcessById(intPro)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If bolOKDM = True Then
            bolOKDM = False
            If aryDM.Count > 0 Then
                Dim intI() As Integer
                intI = aryDM.ToArray(GetType(Integer))
                aryDM.Clear()
                For Each intJ As Integer In intI
                    Dim r As DataGridViewRow = DG.Rows(intJ)
                    r.DefaultCellStyle.BackColor = Color.FromArgb(128, 255, 128)
                Next
            End If
        End If
    End Sub

    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs) Handles Panel7.Paint

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If ITNO.Enabled = False Then Return
        Dim sqlCV As New APSQL.SQLCNV
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "WMSAA")
        sqlCV.Where("SAA01", "=", ITNO.Text)
        sqlCV.SqlFields("SAA02")
        sqlCV.SqlFields("SAA09")
        sqlCV.SqlFields("SAA10")
        sqlCV.SqlFields("SAA08")
        sqlCV.SqlFields("SAA07")
        sqlCV.SqlFields("SAA11")
        Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        If dt.Rows.Count = 0 Then Return
        Dim strA(5) As String
        For i As Integer = 0 To dt.Columns.Count - 1
            strA(i) = dt.Rows(0)(i).ToString()
        Next
        If My.Settings.X402NUM = 0 Then
            ClsX0401.FrmX402.strV = strA
        Else
            ClsX0401.FrmX402.strV = My.Settings.X402.Split(";")
        End If
        Dim frm As ClsX0401.FrmX402 = New ClsX0401.FrmX402()
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            Dim str() As String = ClsX0401.FrmX402.Code.Split(";")
            FDG.Rows(0).Cells(4).Value = str(4).ToString()
            FDG.Rows(0).Cells(6).Value = str(3).ToString()
            FDG.Rows(0).Cells(7).Value = str(1).ToString()
            FDG.Rows(0).Cells(8).Value = str(2).ToString()
            Label20.Text = ""
            Dim strY() As String = ClsX0401.ClsX40.GetX402str(str(5).ToString()).Split(",")
            For i As Integer = 0 To strY.Length - 1
                If strY(i) = "" Then
                    Continue For
                End If
                Label20.Text += strY(i) + ":TRUE"
                If (i <> strY.Length - 1) Then
                    Label20.Text += ","
                End If
            Next
            FDG.Rows(0).Cells(9).Value = Label20.Text
            My.Settings.X402 = ClsX0401.FrmX402.Code
            My.Settings.X402NUM += 1
            My.Settings.Save()
        End If
    End Sub
End Class