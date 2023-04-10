Imports System.Data
#Const EP1 = 2
Public Class PM0304
  Private WithEvents s1 As clsEDIT2012.clsEDIT2012
  Private Dwuliao As FrmDialog
  Private dtC As New DataGridViewComboBoxColumn
  Private aryTA As New Dictionary(Of String, String)
  Private aryTB As New Dictionary(Of String, String)
  Private bolFRS As Boolean = False
  Private bolModf As Boolean = False
  Private bolLock As Boolean = False
  Private strGRP As String = ""
  'Dim dbom As New PM030401
  Sub New()
    ' 此調用是設計器所必需的。
    InitializeComponent()
    ' 在 InitializeComponent() 調用之后添加任何初始化。
    languagechange(Me)
    dgdaochu(DG1)
  End Sub
  Private Class M1
    Public strIT As String = ""
    Public strFD As String = ""
    Public strPT As String = ""
    Public strRIT As String = ""
    Public intQTY As Integer = 1
  End Class
  Private Function GetFixPT(strP As String) As String
    Dim strM() As String = strP.Split("-")
    Dim strL As String = ""
    For intI As Integer = 0 To strM.GetUpperBound(0)
      If intI = 2 Then
        strL &= Val(strM(intI)).ToString("00") & "-"
      Else
        strL &= strM(intI).Trim & "-"
      End If
    Next
    Return strL.TrimEnd("-")
  End Function
#If K3 = 2 Or k3 = 3 Then
  Private Function LoadMTab(xlsf As XLS_FILE, strN As String) As Boolean
    Dim sqlCV As New APSQL.SQLCNV
    Dim rs As DataTable = xlsf.XLS2Rs(strN, 1, 2, True)
    If rs Is Nothing OrElse rs.Rows.Count = 0 Then
      Return False
    End If
    Dim aryD As New Dictionary(Of String, ArrayList)
    Dim strM As String = rs.Rows(1).Item(1).ToString.Trim
    Dim strM1 As String = rs.Rows(0).Item(1).ToString.Trim
    Dim strP As String = rs.Rows(1).Item(2).ToString.Trim
    Dim strV As String = rs.Rows(1).Item(3).ToString.Trim
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TBB")
    sqlCV.Where("TBB03", "=", strM)
    sqlCV.Where("TBB04", "=", strM, , , "OR")
    sqlCV.SqlFields("TBB03")
    sqlCV.SqlFields("TBB04")
    sqlCV.SqlFields("TBB01")
    sqlCV.SqlFields("TBB02")
    rs = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count = 0 Then
      MsgBox(BIG2GB("所指定的物料編碼或型號不存在"))
      Return False
    End If
    aryD.Clear()
    Dim strMSG As String = "", r As DataRow = Nothing
    For Each r1 As DataRow In rs.Rows
      If r1!TBB03.ToString.Trim = strM Then
        If r1!TBB04.ToString.Trim <> "" And strM1 <> "" And strM1 <> r1!TBB04.ToString.Trim Then
          If MsgBox(BIG2GB("一個PCB編號有二種型號，只能有一個料站表" & vbCrLf & _
                           "原型號=" & r1!TBB04.ToString.Trim & "  新型號=" & strM1 & _
                           vbCrLf & "是否繼續導入？"), MsgBoxStyle.YesNo, _
                           BIG2GB("導入Excel錯誤")) = MsgBoxResult.No Then
            Return False
          End If
        End If
        If strM1 = "" Then strM1 = r1!TBB04.ToString.Trim
        r = r1
        Exit For
      End If
    Next
    If r Is Nothing Then
      For Each r1 As DataRow In rs.Rows
        If r1!TBB04.ToString.Trim = strM Then
          strM1 = ""
          r = r1
          Exit For
        End If
      Next
    End If
    If r Is Nothing Then Return False
    Dim strV1 As String = r!TBB01.ToString.Trim & "-" & r!TBB02.ToString.Trim
    If strV1 = "-" Then
      strMSG &= "物料編碼：" & r!TBB03.ToString.Trim & " 未設定流程無法導入料站表" & vbCrLf
    End If
    If aryD.ContainsKey(strV1) = False Then
      aryD.Add(strV1, Nothing)
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TBA")
      sqlCV.Where("TBA01", "=", r!TBB01.ToString.Trim)
      sqlCV.Where("TBA02", "=", r!TBB02.ToString.Trim)
      sqlCV.Where("TBA04", "=", strP)
      sqlCV.SqlFields("TBA01")
      Dim rs2 As DataTable = DB.RsSQL(sqlCV.Text, "RT1")
      If rs2.Rows.Count = 0 Then
        strMSG &= "物料編碼：" & r!TBB03.ToString.Trim & " 流程[" & strV1 & "]未設定工序[" & strP & "]" & vbCrLf
      End If
    End If
    If strMSG <> "" Then
      MsgBox(BIG2GB(strMSG))
      Return False
    End If
    aryD.Clear()
    rs = xlsf.XLS2Rs(0, 3, 0)
    Dim aryEQ As New ArrayList
    Dim strEQ As String = ""
    For Each r1 As DataRow In rs.Rows
      Dim s As New M1
      s.strIT = r1.Item(1).ToString.Trim
      s.strPT = GetFixPT(r1.Item(0).ToString.Trim & "-" & r1.Item(3).ToString.Trim)
      s.strFD = r1.Item(4).ToString.Trim
      s.strRIT = r1.Item(5).ToString.Trim
      If aryD.ContainsKey(s.strIT) = False Then
        aryD.Add(s.strIT, New ArrayList)
      End If
      aryD(s.strIT).Add(s)
      Dim strV2() As String = (s.strPT & "---").Split("-")
      If aryEQ.Contains(strV2(0)) = False Then
        aryEQ.Add(strV2(0))
        strEQ &= strV2(0) & ","
      End If
    Next
    strEQ = strEQ.Trim(",")
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TC")
    sqlCV.Where("TC01", "=", strM)
    sqlCV.Where("TC10", "=", strV)
    sqlCV.Where("TC04", "=", 3, intFMode.msfld_num)
    sqlCV.Where("TC03", "=", strP)
    sqlCV.SqlFields("*")
    Dim rs1 As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If rs1.Rows.Count > 0 Then
      If MsgBox(BIG2GB("這個料站表：" & strV & "已經存在是否覆蓋"), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
        Return False
      End If
    End If
    Dim aryKIT As New Dictionary(Of String, String)
    For Each r1 As DataRow In rs1.Rows
      If aryKIT.ContainsKey(r1!TC02.ToString.Trim) = False Then
        aryKIT.Add(r1!TC02.ToString.Trim, r1!TC08.ToString.Trim)
      End If
    Next
    For Each s As ArrayList In aryD.Values
      For Each s1 As M1 In s
        If s1.strRIT = "" Then Continue For
        If aryKIT.ContainsKey(s1.strIT) = True Then
          Dim strR() As String = (aryKIT(s1.strIT) & "," & s1.strRIT).Split(",")
          Dim strMM As String = ""
          For Each s2 As String In strR
            If s2.Trim <> "" Then
              strMM &= s2.Trim & ","
            End If
          Next
          aryKIT(s1.strIT) = strMM.Trim(",")
        Else
          aryKIT.Add(s1.strIT, s1.strRIT)
        End If
      Next

    Next
    If rs1.Rows.Count > 0 Then
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_delete, "SFIS_TC")
      sqlCV.Where("TC01", "=", strM)
      sqlCV.Where("TC10", "=", strV)
      sqlCV.Where("TC04", "=", 3, intFMode.msfld_num)
      sqlCV.Where("TC03", "=", strP)
      DB.RsSQL(sqlCV.Text)
    End If
    For Each strK As String In aryD.Keys
      Dim s As ArrayList = aryD(strK)
      Dim intQ As Integer = 0
      Dim intQ1 As Integer = 0
      Dim strST As String = ""
      Dim strFD As String = ""
      For Each s1 As M1 In s
        If s1.strPT.EndsWith("*") Then
          If s.Count > 1 Then
            intQ1 += s1.intQTY
            strST &= s1.strPT.TrimEnd("*") & "*" & s1.intQTY & ","
          Else
            intQ1 = s1.intQTY
            strST = s1.strPT.TrimEnd("*")
          End If
        Else
          intQ = s1.intQTY
          strST &= s1.strPT & ","
        End If
        If strFD = "" Then
          If s1.strFD.Trim.ToUpper = "XX" Then
            strFD = "XX"
          ElseIf s1.strFD.StartsWith("*") Or Val(s1.strFD) = 0 Then
            strFD = ""
          Else
            If s1.strFD Like "*[xX]#" Then
              Dim strL1() As String = s1.strFD.Split("xX".ToCharArray)
              strFD = "FD" & Val(strL1(0)).ToString("00") & "X" & strL1(1)
            ElseIf s1.strFD Like "#*" Then
              strFD = "FD" & Val(s1.strFD).ToString("00")
            Else
              strFD = s1.strFD
            End If
          End If
        End If
      Next
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_TC")
      sqlCV.SqlFields("TC01", strM)
      sqlCV.SqlFields("TC02", strK)
      sqlCV.SqlFields("TC03", strP)
      sqlCV.SqlFields("TC04", 3, intFMode.msfld_num)
      sqlCV.SqlFields("TC05", strFD)
      sqlCV.SqlFields("TC06", intQ + intQ1, intFMode.msfld_num)
      sqlCV.SqlFields("TC07", strST.Trim(","))
      If aryKIT.ContainsKey(strK) = True Then
        sqlCV.SqlFields("TC08", aryKIT(strK))
      Else
        sqlCV.SqlFields("TC08", "")
      End If
      sqlCV.SqlFields("TC09", strEQ)
      sqlCV.SqlFields("TC10", strV)
      DB.RsSQL(sqlCV.Text)
    Next
    MsgBox(BIG2GB("導入料站表完成"))
    s1.Updated = True
    s1.Clean()
    TBC.SelectedIndex = TBC.TabCount - 1
    My.Application.DoEvents()
    For Each r2 As DataGridViewRow In s1.GetDGV.Rows
      If strM = GCell(r2.Cells(0)) And strV = GCell(r2.Cells(1)) Then
        s1_DVSelect(s1, r2)
        Exit For
      End If
    Next
    TBC.SelectedIndex = 0
    Return True
  End Function
#End If
#If K3 = 1 Then
   Private Function LoadMtabX(xlsf As XLS_FILE, strM As String, strV As String) As Boolean
    Dim aryD As New Dictionary(Of String, ArrayList)
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TBB")
    sqlCV.Where("TBB03", "=", strM)
    sqlCV.Where("TBB04", "=", strM, , , "OR")
    sqlCV.SqlFields("TBB03")
    sqlCV.SqlFields("TBB01")
    sqlCV.SqlFields("TBB02")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count = 0 Then
      MsgBox(BIG2GB("所指定的物料編碼或型號不存在"))
      Return False
    End If
    aryD.Clear()
    Dim strMSG As String = ""
    For Each r As DataRow In rs.Rows
      Dim strV1 As String = r!TBB01.ToString.Trim & "-" & r!TBB02.ToString.Trim
      If strV1 = "-" Then
        strMSG &= "物料編碼：" & r!TBB03.ToString.Trim & " 未設定流程無法導入料站表" & vbCrLf
        Continue For
      End If
    Next
    If strMSG <> "" Then
      MsgBox(BIG2GB(strMSG))
      Return False
    End If
    aryD.Clear()
    rs = xlsf.XLS2Rs(0, 2, 0)
    Dim aryEQ As New ArrayList
    Dim strEQ As String = ""
    For Each r As DataRow In rs.Rows
      Dim s As New M1
      s.strIT = r.Item(1).ToString.Trim
      s.strPT = "any"
      s.strFD = "any"
      s.intQTY = Val(r.Item(4).ToString)
      If aryD.ContainsKey(s.strIT) = False Then
        aryD.Add(s.strIT, New ArrayList)
      End If
      aryD(s.strIT).Add(s)
    Next
    strEQ = strEQ.Trim(",")
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_distinc, "SFIS_TC")
    sqlCV.Where("TC01", "=", strM)
    sqlCV.Where("TC04", "=", 3, intFMode.msfld_num)
    sqlCV.Where("TC03", "=", "any")
    sqlCV.SqlFields("TC10")
    Dim rs1 As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If rs1.Rows.Count > 0 Then
      Dim strMx As String = ""
      For Each r As DataRow In rs1.Rows
        If r!TC10.ToString.Trim = strV Then
          If MsgBox(BIG2GB("這個料站表：" & strM & "-" & strV & "已經存在是否覆蓋"), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
            Return False
          End If
        Else
          strMx &= "'" & r!TC10.ToString.Trim & "',"
        End If
      Next
      If strMx <> "" Then
        If MsgBox(BIG2GB("這個料站表：" & strM & "已經存在不同版本是否覆蓋"), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
          Return False
        End If
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_TC")
        sqlCV.Where("TC01", "=", strM)
        sqlCV.Where("TC04", "=", 3, intFMode.msfld_num)
        sqlCV.Where("TC03", "=", "any")
        sqlCV.Where("TC10", "IN", strMx.Trim(","), intFMode.msfld_field)
        sqlCV.SqlFields("TC04", "4")
        DB.RsSQL(sqlCV.Text)
      End If
    End If
    Dim aryKIT As New Dictionary(Of String, String)
    For Each r As DataRow In rs1.Rows
      If aryKIT.ContainsKey(r!TC02.ToString.Trim) = False Then
        aryKIT.Add(r!TC02.ToString.Trim, r!TC08.ToString.Trim)
      End If
    Next
    If rs1.Rows.Count > 0 Then
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_delete, "SFIS_TC")
      sqlCV.Where("TC01", "=", strM)
      sqlCV.Where("TC10", "=", strV)
      sqlCV.Where("TC04", "=", 3, intFMode.msfld_num)
      sqlCV.Where("TC03", "=", "any")
      DB.RsSQL(sqlCV.Text)
    End If
    For Each strK As String In aryD.Keys
      Dim s As ArrayList = aryD(strK)
      Dim intQ1 As Integer = 0
      For Each s1 As M1 In s
        intQ1 += s1.intQTY
      Next
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_TC")
      sqlCV.SqlFields("TC01", strM)
      sqlCV.SqlFields("TC02", strK)
      sqlCV.SqlFields("TC03", "any")
      sqlCV.SqlFields("TC04", 3, intFMode.msfld_num)
      sqlCV.SqlFields("TC05", "any")
      sqlCV.SqlFields("TC06", intQ1, intFMode.msfld_num)
      sqlCV.SqlFields("TC07", "any")
      sqlCV.SqlFields("TC08", "")
      sqlCV.SqlFields("TC09", "")
      sqlCV.SqlFields("TC10", strV)
      DB.RsSQL(sqlCV.Text)
    Next
    MsgBox(BIG2GB("導入料站表完成"))
    s1.Updated = True
    s1.Clean()
    TBC.SelectedIndex = TBC.TabCount - 1
    My.Application.DoEvents()
    For Each r As DataGridViewRow In s1.GetDGV.Rows
      If strM = GCell(r.Cells(0)) And strV = GCell(r.Cells(1)) Then
        s1_DVSelect(s1, r)
        Exit For
      End If
    Next
    TBC.SelectedIndex = 0
    Return True
  End Function
  Private Function LoadMTab(xlsf As XLS_FILE, strN As String) As Boolean 
    Dim sqlCV As New APSQL.SQLCNV
    Dim rsx As DataTable = xlsf.XLS2Rs(0, 1, 2)
    If rsx Is Nothing Then Return False
    If rsx.Columns.Count > 0 Then
      Dim strVx() As String = rsx.Columns(0).ColumnName.ToString.Split("-")
      If strVx.Length >= 3 Then
        If strN = "TOP" Then Return LoadMtabX(xlsf, strVx(1), strVx(2))
        Return False
      End If
    End If
    Dim rs As DataTable = xlsf.XLS2Rs(strN, 1, 2)
    If rs Is Nothing OrElse rs.Rows.Count = 0 Then
      Return False
    End If
    Dim aryD As New Dictionary(Of String, ArrayList)
    Dim strM As String = rs.Rows(0).Item(0).ToString.Trim
    Dim strP As String = rs.Rows(0).Item(1).ToString.Trim
    Dim strV As String = rs.Rows(0).Item(2).ToString.Trim
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TBB")
    sqlCV.Where("TBB03", "=", strM)
    sqlCV.Where("TBB04", "=", strM, , , "OR")
    sqlCV.SqlFields("TBB03")
    sqlCV.SqlFields("TBB01")
    sqlCV.SqlFields("TBB02")
    rs = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count = 0 Then
      MsgBox(BIG2GB("所指定的物料編碼或型號不存在"))
      Return False
    End If
    aryD.Clear()
    Dim strMSG As String = ""
    For Each r As DataRow In rs.Rows
      Dim strV1 As String = r!TBB01.ToString.Trim & "-" & r!TBB02.ToString.Trim
      If strV1 = "-" Then
        strMSG &= "物料編碼：" & r!TBB03.ToString.Trim & " 未設定流程無法導入料站表" & vbCrLf
        Continue For
      End If
      If aryD.ContainsKey(strV1) = False Then
        aryD.Add(strV1, Nothing)
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TBA")
        sqlCV.Where("TBA01", "=", r!TBB01.ToString.Trim)
        sqlCV.Where("TBA02", "=", r!TBB02.ToString.Trim)
        sqlCV.Where("TBA04", "=", strP)
        sqlCV.SqlFields("TBA01")
        Dim rs2 As DataTable = DB.RsSQL(sqlCV.Text, "RT1")
        If rs2.Rows.Count = 0 Then
          strMSG &= "物料編碼：" & r!TBB03.ToString.Trim & " 流程[" & strV1 & "]未設定工序[" & strP & "]" & vbCrLf
          Continue For
        End If
      End If
    Next
    If strMSG <> "" Then
      MsgBox(BIG2GB(strMSG))
      Return False
    End If
    aryD.Clear()
    rs = xlsf.XLS2Rs(strN, 3, 0)
    Dim aryEQ As New ArrayList
    Dim strEQ As String = ""
    For Each r As DataRow In rs.Rows
      Dim s As New M1
      s.strIT = r.Item(3).ToString.Trim
      s.strPT = GetFixPT(r.Item(0).ToString.Trim)
      s.strFD = r.Item(2).ToString.Trim
      s.intQTY = Val(r.Item(4).ToString)
      If aryD.ContainsKey(s.strIT) = False Then
        aryD.Add(s.strIT, New ArrayList)
      End If
      aryD(s.strIT).Add(s)
      Dim strV1() As String = (s.strPT & "---").Split("-")
      's.strPT = strV1(0).Trim & "-" & strV1(1).Trim & "-" & Val(strV1(2)).ToString("00")
      'If strV1(3).Trim <> "" Then s.strPT &= "-" & strV1(3)
      If aryEQ.Contains(strV1(0)) = False Then
        aryEQ.Add(strV1(0))
        strEQ &= strV1(0) & ","
      End If
    Next
    strEQ = strEQ.Trim(",")
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TC")
    sqlCV.Where("TC01", "=", strM)
    sqlCV.Where("TC10", "=", strV)
    sqlCV.Where("TC04", "=", 3, intFMode.msfld_num)
    sqlCV.Where("TC03", "=", strP)
    sqlCV.SqlFields("*")
    Dim rs1 As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If rs1.Rows.Count > 0 Then
      If MsgBox(BIG2GB("這個料站表：" & strV & "已經存在是否覆蓋"), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
        Return False
      End If
    End If
    Dim aryKIT As New Dictionary(Of String, String)
    For Each r As DataRow In rs1.Rows
      If aryKIT.ContainsKey(r!TC02.ToString.Trim) = False Then
        aryKIT.Add(r!TC02.ToString.Trim, r!TC08.ToString.Trim)
      End If
    Next
    If rs1.Rows.Count > 0 Then
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_delete, "SFIS_TC")
      sqlCV.Where("TC01", "=", strM)
      sqlCV.Where("TC10", "=", strV)
      sqlCV.Where("TC04", "=", 3, intFMode.msfld_num)
      sqlCV.Where("TC03", "=", strP)
      DB.RsSQL(sqlCV.Text)
    End If
    For Each strK As String In aryD.Keys
      Dim s As ArrayList = aryD(strK)
      Dim intQ As Integer = 0
      Dim intQ1 As Integer = 0
      Dim strST As String = ""
      Dim strFD As String = ""
      For Each s1 As M1 In s
        'Modify by Lin 2015/8/14
        'No allow alter Posi
#If EP1 = 1 Then
        If s.Count > 1 Then
          intQ1 += s1.intQTY
          strST &= s1.strPT.TrimEnd("*") & "*" & s1.intQTY & ","
        Else
          intQ1 = s1.intQTY
          strST = s1.strPT.TrimEnd("*")
        End If
#Else
        If s1.strPT.EndsWith("*") Then
          If s.Count > 1 Then
            intQ1 += s1.intQTY
            strST &= s1.strPT.TrimEnd("*") & "*" & s1.intQTY & ","
          Else
            intQ1 = s1.intQTY
            strST = s1.strPT.TrimEnd("*")
          End If
        Else
          intQ = s1.intQTY
          strST &= s1.strPT & ","
        End If
#End If
        If strFD = "" Then
          If s1.strFD.StartsWith("*") Or Val(s1.strFD) = 0 Then
            strFD = ""
          Else
            If s1.strFD Like "*[xX]#" Then
              Dim strL1() As String = s1.strFD.Split("xX".ToCharArray)
              strFD = "FD" & Val(strL1(0)).ToString("00") & "X" & strL1(1)
            ElseIf s1.strFD Like "#*" Then
              strFD = "FD" & Val(s1.strFD).ToString("00")
            Else
              strFD = s1.strFD
            End If
          End If
        End If
      Next
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_TC")
      sqlCV.SqlFields("TC01", strM)
      sqlCV.SqlFields("TC02", strK)
      sqlCV.SqlFields("TC03", strP)
      sqlCV.SqlFields("TC04", 3, intFMode.msfld_num)
      sqlCV.SqlFields("TC05", strFD)
      sqlCV.SqlFields("TC06", intQ + intQ1, intFMode.msfld_num)
      sqlCV.SqlFields("TC07", strST.Trim(","))
      If aryKIT.ContainsKey(strK) = True Then
        sqlCV.SqlFields("TC08", aryKIT(strK))
      Else
        sqlCV.SqlFields("TC08", "")
      End If
      sqlCV.SqlFields("TC09", strEQ)
      sqlCV.SqlFields("TC10", strV)
      DB.RsSQL(sqlCV.Text)
    Next
    MsgBox(BIG2GB("導入料站表完成"))
    s1.Updated = True
    s1.Clean()
    TBC.SelectedIndex = TBC.TabCount - 1
    My.Application.DoEvents()
    For Each r As DataGridViewRow In s1.GetDGV.Rows
      If strM = GCell(r.Cells(0)) And strV = GCell(r.Cells(1)) Then
        s1_DVSelect(s1, r)
        Exit For
      End If
    Next
    TBC.SelectedIndex = 0
    Return True
  End Function
#End If
  Private Sub DownLoad()
    Dim OFL As New OpenFileDialog
    OFL.Title = BIG2GB("請選擇一個導入Excel資料")
    OFL.Filter = BIG2GB("Excel|*.xls;*.xlsx|所有檔案|*.*")
    OFL.FileName = ""
    If OFL.ShowDialog = Windows.Forms.DialogResult.OK Then
      s1_Frm_Clear(s1)
      Dim xlsF As New XLS_FILE(OFL.FileName)
#If K3 = 2 Or k3 = 3 Then
      Dim bolTD As Boolean = False
      If LoadMTab(xlsF, "TOP") Then bolTD = True
      If LoadMTab(xlsF, "BOT") Then bolTD = True
      xlsF.Quit()
      If bolTD = True Then
        s1.Updated = True
        s1.Clean()
        MsgBox(BIG2GB("導入成功"))
      End If
#ElseIf K3 = 0 Then
      If LoadMTab(xlsF, "TOP") = False Then
        xlsF.Quit()
        Return
      End If
      If LoadMTab(xlsF, "BOT") = False Then
        xlsF.Quit()
      Else
        xlsF.Quit()
        s1.Updated = True
        s1.Clean()
        MsgBox(BIG2GB("導入成功"))
      End If
#End If
    End If
  End Sub

  Private Sub PM0304_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    TuiCK(Me)
  End Sub
  Private Sub FrmGongXu2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    s1 = New clsEDIT2012.clsEDIT2012(TBC, DB, language) ', False, "SLSFIS_TBB")
    s1.Clean()
    s1.ShowSearch = True
    Dwuliao = getwuliao("")
    s1.InsertToolsItem(3, "-", Nothing, Nothing)
    s1.InsertToolsItem(3, BIG2GB("導入料站表"), My.Resources.XDOWN, AddressOf DownLoad)
    s1.GetToolsItem("Delete").Enabled = clsRTS.GetRight(Me.Tag & "/003")
    s1.GetToolsItem("save").Enabled = clsRTS.GetRight(Me.Tag & "/001")
    aryTB.Clear()
    'Dim sqlCV As New APSQL.SQLCNV
    'sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TA")
    'sqlCV.SqlFields("TA01", , , , True)
    'sqlCV.SqlFields("TA02")
    'Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    'For Each r As DataRow In rs.Rows
    '  aryTA.Add(r!TA01.ToString.Trim, r!TA02.ToString.Trim)
    'Next
    'sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TBB")
    'sqlCV.SqlFields("TBB03", , , , True)
    'sqlCV.SqlFields("TBB05+' '+TBB06", "V1")
    'rs = DB.RsSQL(sqlCV.Text, "RT")
    'For Each r As DataRow In rs.Rows
    '  aryTB.Add(r!TBB03.ToString.Trim, r!V1.ToString.Trim)
    'Next
  End Sub

  Private Sub GONGXUSETUP(ByVal WULIAO As String)
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TBB")
    sqlCV.Where("TBB03", "=", WULIAO)
    Dim w As APSQL.SqlWhere = sqlCV.SqlJoin(APSQL.SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TBA", "TBA01", "=", "SFIS_TBB.TBB01")
    w.Add("SFIS_TBA.TBA02", "=", "SFIS_TBB.TBB02")
    sqlCV.SqlFields("^1.TBA03", , , , True)
    sqlCV.SqlFields("^1.TBA04", "KEYS")
    sqlCV.SqlJoin(APSQL.SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TA", "TA01", "=", "SFIS_TBA.TBA04")
    sqlCV.SqlFields("^1.TBA04 +'|' + ^2.TA02", "DATAS")
    dtC.DisplayMember = "DATAS"
    dtC.ValueMember = "KEYS"
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "DTC")
    rs.Rows.Add(9999, "any", "any")
    dtC.DataSource = rs
    strGRP = rs.Rows(0)!KEYS.ToString.Trim
  End Sub

  '‘  選擇生產料號
  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    s1_Frm_Clear(s1)
    Dim Frm As New FrmQrySA
    Frm.QRY = TextBox1.Text.Trim
    If Frm.ShowDialog = Windows.Forms.DialogResult.OK Then
      Dim strV() As String = Frm.Item
      If strV Is Nothing OrElse strV.Length = 0 Then Return
      TextBox1.Text = strV(0)
      ShowData(TextBox1.Text, "")
    End If
    'Dim Dwuliao As FrmDialog = getwuliao(" ISNULL(TBB01,'') <> ''")
    'If Dwuliao.ShowDialog = DialogResult.OK Then
    '  TextBox1.Text = GCell(Dwuliao.rw.Cells(0))
    '  TextBox1_Validated(Nothing, Nothing)
    'End If
  End Sub
  Private Sub GetDetail()
    aryTB.Clear()
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TC")
    sqlCV.Where("SFIS_TC.TC01", "=", TextBox1.Text.Trim)
    sqlCV.Where("TC10", "=", ComboBox1.Text.Trim)
    sqlCV.SqlFields("TC04", "用料類型")
    sqlCV.SqlFields("TC03", "工序", , , True)
    sqlCV.SqlFields("TC07", "料站號", , , True)
    sqlCV.SqlFields("TC02", "原料料號", , , True)
    sqlCV.SqlFields("('')", "規格")
    sqlCV.SqlFields("TC06", "單位用量")
    sqlCV.SqlFields("TC05", "扣料模式")
    sqlCV.SqlFields("TC08", "替代料號")
    Dim rs As DataTable = DB.RsSQL(BIG2GB(sqlCV.Text), "RTA")
    Dim strB As String = ""
    Button2.Enabled = True
    For Each r As DataRow In rs.Rows
      If r.Item(2).ToString.Trim = "any" And r.Item(6).ToString.Trim >= "3" Then
        Button2.Enabled = False
      End If
      Dim strM As String = r.Item(3).ToString.Trim
      If aryTB.ContainsKey(strM) = False Then
        strB &= "'" & strM & "',"
      End If
    Next
    If strB <> "" Then
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TBB")
      sqlCV.Where("TBB03", "IN", strB.Trim(","), intFMode.msfld_field)
      sqlCV.SqlFields("TBB03")
      sqlCV.SqlFields("TBB05+' '+TBB06", "INA")
      sqlCV.SqlFields("SA14")
      sqlCV.SqlFields("TBB08")
      Dim rs1 As DataTable = DB.RsSQL(sqlCV.Text, "RT")
      Label4.Text = ""
      For Each r As DataRow In rs1.Rows
        aryTB.Add(r!TBB03.ToString.Trim, r!INA.ToString.Trim)
        If r!TBB08.ToString.Trim = "1010" Or r!TBB08.ToString.Trim = "1011" Then
          Dim ss As New clsDieSpec
          ss.DieDecode(r!SA14.ToString.Trim)
          Label4.Text = ss.PaperWidth.ToString("0.0").TrimEnd("0").TrimEnd(".") & "mm " & (ss.JumpLength * ss.PaperWidth / ss.ModX / ss.ModY * 0.000001).ToString("0.0000") & BIG2GB(" 平方米")
        End If
      Next
    End If
    DG1.DataSource = rs
    If bolFRS = False Then
      bolFRS = True
      With DG1.Columns(1)
        dtC.Name = .Name
        dtC.CellTemplate.ValueType = .CellTemplate.ValueType
        dtC.CellTemplate.Style = .CellTemplate.Style
        dtC.DataPropertyName = .DataPropertyName
        dtC.DefaultCellStyle = .DefaultCellStyle
        dtC.HeaderText = .HeaderText
        dtC.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
        dtC.ValueType = .ValueType
      End With
      DG1.Columns.RemoveAt(1)
      DG1.Columns.Insert(1, dtC)
    Else
      dtC = DG1.Columns(1)
    End If
    GONGXUSETUP(TextBox1.Text)
    For Each c As DataGridViewColumn In DG1.Columns
      c.SortMode = DataGridViewColumnSortMode.NotSortable
    Next
    DG1.Columns(4).ReadOnly = True
    For Each r As DataGridViewRow In DG1.Rows
      If GCell(r.Cells(0)) = "3" Then
        r.Cells(2).ReadOnly = False
        CheckBox1.Checked = True
      Else
        r.Cells(2).ReadOnly = True
      End If
    Next
    If CheckBox1.Checked = True Then
      DG1.Columns(2).Visible = True
    Else
      DG1.Columns(2).Visible = False
    End If
    If DG1.Rows.Count = 0 Then
      DG1.AppendBegin()
    End If

  End Sub
  ''選擇原料
  Private Sub DG1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellDoubleClick
    Select Case e.ColumnIndex
      Case 3
        Dim Frms As New FrmQrySA
        If Label4.Text = "" Then
          Frms.QRY = TextBox2.Text.Trim
          Frms.CLASSV = "1010"
        End If
        If Frms.ShowDialog = Windows.Forms.DialogResult.OK Then
          Dim strV() As String = Frms.Item
          If strV Is Nothing OrElse strV.Length = 0 Then Return
          DG1.EndEdit()
          If aryTB.ContainsKey(strV(0)) = False Then
            Dim sqlCV As New APSQL.SQLCNV
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TBB")
            sqlCV.Where("TBB03", "=", strV(0))
            sqlCV.SqlFields("TBB03")
            sqlCV.SqlFields("TBB05+' '+TBB06", "INA")
            sqlCV.SqlFields("TBB08")
            sqlCV.SqlFields("SA14")
            Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
            If rs.Rows.Count > 0 Then
              aryTB.Add(rs.Rows(0)!TBB03.ToString.Trim, rs.Rows(0)!INA.ToString.Trim)
              If rs.Rows(0)!TBB08.ToString.Trim = "1010" Or rs.Rows(0)!TBB08.ToString.Trim = "1011" Then
                Dim ss As New clsDieSpec
                ss.DieDecode(rs.Rows(0)!SA14.ToString.Trim)
                Label4.Text = ss.PaperWidth.ToString("0.0").TrimEnd("0").TrimEnd(".") & "mm " & (ss.JumpLength * ss.PaperWidth / ss.ModX / ss.ModY * 0.000001).ToString("0.0000") & BIG2GB(" 平方米")
              End If
            End If
            DB.CloseRs(rs)
          End If
          DG1.CurrentRow.Cells(3).Value = strV(0)
        End If
      Case 7
        Dim Frms As New FrmQrySA
        Frms.QRY = TextBox2.Text.Trim
        If Frms.ShowDialog = Windows.Forms.DialogResult.OK Then
          Dim strV() As String = Frms.Item
          If strV Is Nothing OrElse strV.Length = 0 Then Return
          Dim strK As String = ""
          For Each strM As String In strV
            strK &= strM & ","
          Next
          DG1.EndEdit()
          DG1.CurrentRow.Cells(7).Value = strK.Trim(",")
        End If
    End Select
  End Sub

  Private Sub DG1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DG1.CellEndEdit
    Select Case e.ColumnIndex
      Case 0
        Dim strM As String = GCell(DG1.Rows(e.RowIndex).Cells(e.ColumnIndex))
        DG1.Rows(e.RowIndex).Cells(2).ReadOnly = (strM <> "3")
      Case 3
        Dim strM As String = GCell(DG1.Rows(e.RowIndex).Cells(3))
        If aryTB.ContainsKey(strM) = False Then
          Dim sqlCV As New APSQL.SQLCNV
          sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TBB")
          sqlCV.Where("TBB03", "=", strM)
          sqlCV.SqlFields("TBB03")
          sqlCV.SqlFields("TBB05+' '+TBB06", "INA")
          sqlCV.SqlFields("TBB08")
          sqlCV.SqlFields("SA14")
          Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
          If rs.Rows.Count > 0 Then
            aryTB.Add(rs.Rows(0)!TBB03.ToString.Trim, rs.Rows(0)!INA.ToString.Trim)
            If rs.Rows(0)!TBB08.ToString.Trim = "1010" Or rs.Rows(0)!TBB08.ToString.Trim = "1011" Then
              Dim ss As New clsDieSpec
              ss.DieDecode(rs.Rows(0)!SA14.ToString.Trim)
              Label4.Text = ss.PaperWidth.ToString("0.0").TrimEnd("0").TrimEnd(".") & "mm " & (ss.JumpLength * ss.PaperWidth / ss.ModX / ss.ModY * 0.000001).ToString("0.0000") & BIG2GB(" 平方米")
            End If
          End If
          DB.CloseRs(rs)
        End If
    End Select
  End Sub

  Private Sub DG1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DG1.CellFormatting
    Select Case e.ColumnIndex
      Case 4
        Dim strM As String = GCell(DG1.Rows(e.RowIndex).Cells(3))
        If aryTB.ContainsKey(strM) Then
          e.Value = aryTB(strM)
        Else
          If strM <> "" Then
            e.Value = "Unknow"
          End If
        End If
      Case 0
        Dim strM As String = GCell(DG1.Rows(e.RowIndex).Cells(e.ColumnIndex))
        Select Case strM
          Case "0"
            e.Value = BIG2GB("0 主料")
          Case "1"
            e.Value = BIG2GB("1 副料")
          Case "2"
            e.Value = BIG2GB("2 不控管")
          Case "3"
            e.Value = BIG2GB("3 SMT用料")
          Case "4"
            e.Value = BIG2GB("4 舊BOM表")
        End Select
      Case 6
          Dim strM As String = GCell(DG1.Rows(e.RowIndex).Cells(e.ColumnIndex))
        Dim strK As String = GCell(DG1.Rows(e.RowIndex).Cells(0))
          If strM.Length = 3 Then
            Select Case strM.Substring(0, 1)
              Case "1"
                e.Value = strM & BIG2GB(" 批號扣量")
              Case "2"
                e.Value = strM & BIG2GB(" 批號不扣量")
              Case "4"
                e.Value = strM & BIG2GB(" 序號扣料")
              Case "5"
                e.Value = strM & BIG2GB(" 半成品投料")
              Case Else
                If strK <> "3" Then
                  If strM.Trim <> "" Then
                    e.Value = strM & " 錯誤"
                  End If
                Else
                e.Value = strM
                End If
            End Select
          Else
            If strK <> "3" Then
              If strM.Trim <> "" Then
                e.Value = strM & " 錯誤"
              End If
            Else
            e.Value = strM
            End If
          End If
    End Select
  End Sub
  Private Sub DG1_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DG1.CurrentCellDirtyStateChanged
    DG1.CommitEdit(DataGridViewDataErrorContexts.Commit)
  End Sub

  Private Sub s1_DVTable(ByVal s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String) Handles s1.DVTable
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TC")
    sqlCV.SqlJoin(APSQL.SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TBB", "SFIS_TBB.TBB03", "=", "SFIS_TC.TC01")
    sqlCV.Where("^0.TC10", "NOT LIKE", "@%")
    sqlCV.SqlFields("^0.TC01", "物料編號", , True, True)
    sqlCV.SqlFields("^0.TC10", "料站表版本號", , True, True)
    sqlCV.SqlFields("^1.TBB04", "型號", , True)
    sqlCV.SqlFields("^1.TBB05+' '+^1.TBB06", "料號說明", , True)
    sqlCV.SqlFields("^1.TBB01", "流程編號", , True)
    sqlCV.SqlFields("^1.TBB02", "流程版本", , True)
    sqlCV.SqlFields("^0.TC09", "SMT機台表", , True)
    sqlCV.SqlFields("COUNT(*)", "料站筆數")
    strSQL = BIG2GB(sqlCV.Text)
  End Sub
  Private Sub ShowData(strV As String, strTC10 As String)
    Dim sqlCV As New APSQL.SQLCNV
    Label4.Text = ""
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_distinc, "SFIS_TBB")
    sqlCV.SqlJoin(APSQL.SQLCNV.intJoinMode.msJoin_Left, "SFIS_TC", "TC01", "=", "^0.TBB03")
    sqlCV.Where("^0.TBB03", "=", strV)
    sqlCV.Where("ISNULL(^1.TC10,'')", "NOT LIKE", "@%")
    sqlCV.Where("ISNULL(^0.TBB01,'')", "<>", "")
    sqlCV.Where("ISNULL(^0.TBB02,'')", "<>", "")
    If strTC10 <> "" Then
      sqlCV.Where("^1.TC10", "=", strTC10)
    End If
    sqlCV.SqlFields("^1.TC10")
    sqlCV.SqlFields("^1.TC09")
    sqlCV.SqlFields("^0.TBB01")
    sqlCV.SqlFields("^0.TBB02")
    sqlCV.SqlFields("^0.TBB03")
    sqlCV.SqlFields("^0.TBB04")
    sqlCV.SqlFields("^0.TBB05")
    sqlCV.SqlFields("^0.TBB06")
    sqlCV.SqlFields("^0.SA20")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count = 0 Then
      MsgBox(BIG2GB("料號資料不正確無法設定料站表"))
      Return
    End If
    TextBox1.Text = rs.Rows(0)!TBB03.ToString.Trim
    TextBox2.Text = rs.Rows(0)!TBB04.ToString.Trim
    TextBox2.Tag = rs.Rows(0)!SA20.ToString.Trim
    TextBox3.Text = rs.Rows(0)!TBB01.ToString.Trim
    TextBox4.Text = rs.Rows(0)!TBB02.ToString.Trim
    SPEC.Text = rs.Rows(0)!TBB05.ToString.Trim & " " & rs.Rows(0)!TBB06.ToString.Trim
    TextBox6.Text = rs.Rows(0)!TC09.ToString.Trim
    ComboBox1.Items.Clear()
    For Each r As DataRow In rs.Rows
      ComboBox1.Items.Add(r!TC10.ToString.Trim)
    Next
    If strTC10 <> "" Then
      ComboBox1.Text = strTC10
      ComboBox1.Enabled = False
    Else
      ComboBox1.Text = rs.Rows(0)!TC10.ToString.Trim
    End If
    GetDetail()
    TextBox1.Enabled = False
    Button1.Enabled = False
  End Sub
  Private Sub s1_DVSelect(ByVal s As clsEDIT2012.clsEDIT2012, ByVal r As System.Windows.Forms.DataGridViewRow) Handles s1.DVSelect
    ShowData(GCell(r.Cells(0)), GCell(r.Cells(1)))
  End Sub
  Private Sub s1_Frm_CheckDup(ByVal s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String) Handles s1.Frm_CheckDup
    DG1.EndEdit()
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TC")
    sqlCV.Where("TC01", "=", TextBox1.Text.Trim)
    sqlCV.Where("TC10", "=", ComboBox1.Text.Trim)
    sqlCV.SqlFields("TC02")
    strSQL = sqlCV.Text
  End Sub
  Private Sub s1_Frm_Clear(ByVal s As clsEDIT2012.clsEDIT2012) Handles s1.Frm_Clear
    For Each ct In Panel1.Controls
      If TypeOf (ct) Is TextBox Or TypeOf (ct) Is ComboBox Then ct.text = ""
    Next
    Label4.Text = ""
    SPEC.Text = ""
    Dim rs As DataTable = DG1.DataSource
    If rs IsNot Nothing Then
      rs.Rows.Clear()
      DG1.DataSource = rs
    End If
    Button1.Enabled = True
    TextBox1.Enabled = True
    ComboBox1.Enabled = True
  End Sub
  Private Sub s1_Frm_Delete(ByVal s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String, ByRef bolOK As Boolean) Handles s1.Frm_Delete
    If MsgBox(BIG2GB("是否刪除這一個料站表"), MsgBoxStyle.OkCancel, Me.Text) = MsgBoxResult.Ok Then
      Dim sqlCV As New APSQL.SQLCNV
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_delete, "SFIS_TC")
      sqlCV.Where("TC01", "=", TextBox1.Text.Trim)
      sqlCV.Where("TC10", "=", ComboBox1.Text.Trim)
      strSQL = sqlCV.Text
      bolOK = True
    End If
  End Sub
  Private Sub s1_Frm_InsertM(ByVal s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String, ByRef intR As Integer) Handles s1.Frm_InsertM
    add()
  End Sub

  Private Sub s1_Frm_UpdateM(ByVal s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String, ByRef intR As Integer) Handles s1.Frm_UpdateM
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_delete, "SFIS_TC")
    sqlCV.Where("TC01", "=", TextBox1.Text.Trim)
    sqlCV.Where("TC10", "=", ComboBox1.Text.Trim)
    DB.RsSQL(sqlCV.Text)
    add()
  End Sub
  Sub add()
    For Each rw As DataGridViewRow In DG1.Rows
      With rw
        If GCell(.Cells(1)) = "" Or GCell(.Cells(3)) = "" Or _
           Val(GCell(.Cells(5))) <= 0 Or GCell(.Cells(6)) = "" Then Continue For
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "SFIS_TC")
        sqlCV.SqlFields("TC01", TextBox1.Text)
        sqlCV.SqlFields("TC02", GCell(.Cells(3)))
        sqlCV.SqlFields("TC07", GCell(.Cells(2)))
        sqlCV.SqlFields("TC03", GCell(.Cells(1)))
        sqlCV.SqlFields("TC04", Val(GCell(.Cells(0))), APSQL.intFMode.msfld_num)
        sqlCV.SqlFields("TC05", GCell(.Cells(6)))
        sqlCV.SqlFields("TC06", GCell(.Cells(5)), APSQL.intFMode.msfld_num)
        sqlCV.SqlFields("TC08", GCell(.Cells(7)))
        sqlCV.SqlFields("TC09", TextBox6.Text.Trim)
        sqlCV.SqlFields("TC10", ComboBox1.Text.Trim)
        DB.RsSQL(sqlCV.Text)
      End With
    Next
    'MsgBox("保存成功", MsgBoxStyle.OkOnly, BIG2GB("提示"))
    s1.Updated = True
    s1_Frm_Clear(s1)
  End Sub

  Private Sub s1_isDataValid(ByVal s As clsEDIT2012.clsEDIT2012, ByRef bolOK As Boolean) Handles s1.isDataValid
    DG1.EndEdit()
    DG1.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange)
    If TextBox1.Text = "" Then Return
    bolOK = True
  End Sub

  Private Sub DG1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DG1.DataError

  End Sub

  Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress, ComboBox1.KeyPress, TextBox6.KeyPress
    If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
      e.Handled = True
      My.Computer.Keyboard.SendKeys(vbTab)
    End If
  End Sub

  Private Sub TextBox1_Validated(sender As Object, e As EventArgs) Handles TextBox1.Validated
    If TextBox1.Text.Trim <> "" Then
      ShowData(TextBox1.Text.Trim, "")

      ''AndAlso aryTB.ContainsKey(TextBox1.Text.Trim) = True Then
      'If ComboBox1.Text.Trim <> "" Then
      '  For Each r As DataGridViewRow In s1.GetDGV.Rows
      '    If TextBox1.Text.Trim = GCell(r.Cells(0)) And ComboBox1.Text.Trim = GCell(r.Cells(1)) Then
      '      s1_DVSelect(Nothing, r)
      '      Return
      '    End If
      '  Next
      'End If
      'Dim sqlCV As New APSQL.SQLCNV
      'sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TBB")
      'sqlCV.Where("TBB03", "=", TextBox1.Text.Trim)
      'sqlCV.SqlFields("TBB01")
      'sqlCV.SqlFields("TBB02")
      'sqlCV.SqlFields("TBB03")
      'sqlCV.SqlFields("TBB04")
      'sqlCV.SqlFields("TBB05")
      'sqlCV.SqlFields("TBB06")
      'Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
      'If rs.Rows.Count = 0 Then
      '  MsgBox(BIG2GB("料號資料不正確"))
      '  Return
      'End If
      'If rs.Rows(0)!TBB01.ToString.Trim = "" Then
      '  MsgBox(BIG2GB("料號沒有設定流程，無法設定料站表"))
      '  Return
      'End If
      'TextBox1.Text = rs.Rows(0)!TBB03.ToString.Trim
      'TextBox2.Text = rs.Rows(0)!TBB04.ToString.Trim
      'TextBox3.Text = rs.Rows(0)!TBB01.ToString.Trim
      'TextBox4.Text = rs.Rows(0)!TBB02.ToString.Trim
      'SPEC.Text = rs.Rows(0)!TBB05.ToString.Trim & " " & rs.Rows(0)!TBB06.ToString.Trim
    End If
  End Sub

  Private Sub ComboBox1_GotFocus(sender As Object, e As EventArgs) Handles ComboBox1.GotFocus
    Dim strM As String = ComboBox1.Text.Trim
    If TextBox1.Text.Trim = "" Then Return
    bolLock = True
    ComboBox1.Items.Clear()
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_distinc, "SFIS_TC")
    sqlCV.Where("TC10", "NOT Like", "@%")
    sqlCV.Where("TC01", "=", TextBox1.Text.Trim)
    sqlCV.SqlFields("TC10")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    For Each r As DataRow In rs.Rows
      ComboBox1.Items.Add(r!TC10.ToString.Trim)
    Next
    ComboBox1.Text = strM
    My.Application.DoEvents()
    bolLock = False
  End Sub

  Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
    If bolLock Then Return
    ComboBox1_Validated(Nothing, Nothing)
  End Sub

  Private Sub ComboBox1_Validated(sender As Object, e As EventArgs) Handles ComboBox1.Validated
    If bolModf = True Then
      Dim sqlcv As New APSQL.SQLCNV
      sqlcv.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TC")
      sqlcv.Where("TC01", "=", TextBox1.Text.Trim)
      sqlcv.Where("TC10", "=", ComboBox1.Text.Trim)
      sqlcv.SqlFields("TC02")
      Dim rs As DataTable = DB.RsSQL(sqlcv.Text, "RT")
      If rs.Rows.Count = 0 Then
        ComboBox1.Enabled = False
        Button1.Enabled = False
        TextBox1.Enabled = False
        Return
      End If
    End If
    If sender IsNot Nothing Then ShowData(TextBox1.Text, ComboBox1.Text.Trim)
    'If TextBox3.Text.Trim <> "" And TextBox1.Text.Trim <> "" Then
    '  For Each r As DataGridViewRow In s1.GetDGV.Rows
    '    If TextBox1.Text.Trim = GCell(r.Cells(0)) And ComboBox1.Text.Trim = GCell(r.Cells(1)) Then
    '      s1_DVSelect(Nothing, r)
    '      Return
    '    End If
    '  Next
    '  GetDetail()
    '  TextBox1.Enabled = False
    '  ComboBox1.Enabled = False
    '  Button1.Enabled = False
    'End If
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    ComboBox1.Enabled = True
    bolModf = True
    ComboBox1.Focus()
  End Sub

  Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
    If DG1.Columns.Count > 6 Then DG1.Columns(2).Visible = CheckBox1.Checked
  End Sub

  Private Sub DG1_Scroll(sender As Object, e As ScrollEventArgs) Handles DG1.Scroll
    DG1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
  End Sub

  Private Sub DG1_DataSourceChanged(sender As Object, e As EventArgs) Handles DG1.DataSourceChanged
    DG1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
  End Sub

  Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
    If Label4.Text.Trim = "" Then Return
    Dim strV() As String = Label4.Text.Split(" ")
    Dim Frm As New FrmQrySA
    Frm.QRY = strV(0)
    Frm.CLASSV = "1001"
    If Frm.ShowDialog = Windows.Forms.DialogResult.OK Then
      Dim strM() As String = Frm.Item
      If strM Is Nothing OrElse strM.Length = 0 Then Return
      If aryTB.ContainsKey(strM(0)) = False Then
        Dim sqlCV As New APSQL.SQLCNV
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TBB")
        sqlCV.Where("TBB03", "=", strM(0))
        sqlCV.SqlFields("TBB03")
        sqlCV.SqlFields("TBB05+' '+TBB06", "INA")
        sqlCV.SqlFields("TBB08")
        sqlCV.SqlFields("SA14")
        Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        If rs.Rows.Count > 0 Then
          aryTB.Add(rs.Rows(0)!TBB03.ToString.Trim, rs.Rows(0)!INA.ToString.Trim)
          If rs.Rows(0)!TBB08.ToString.Trim = "1001" Then
            Dim rs1 As DataTable = DG1.DataSource
            If rs1.Rows.Count = 0 Then Return
            Dim strJ As String = rs1.Rows(rs1.Rows.Count - 1).Item(1).ToString.Trim
            rs1.Rows.Add("0", strJ, "", rs.Rows(0)!TBB03.ToString.Trim, rs.Rows(0)!INA.ToString.Trim, strV(1), "200")
          End If
        End If
        DB.CloseRs(rs)
      End If
    End If
  End Sub

  Private Sub TextBox2_Click(sender As Object, e As EventArgs) Handles TextBox2.Click
    If TextBox2.Text.Trim = "" Or TextBox1.Text.Trim = "" Then Return
    Dim Frms As New FrmQrySA
    If TextBox2.Tag IsNot Nothing Then
      If TextBox2.Tag = "" Then
        Frms.QRY = TextBox2.Text.Trim
      Else
        Frms.NQRY = TextBox2.Tag.ToString.Trim
      End If
    Else
      Frms.QRY = TextBox2.Text.Trim
    End If
    If TextBox1.Text.Trim.StartsWith("1L") Then
      Frms.CLASSV = "1010"
    ElseIf TextBox1.Text.Trim.StartsWith("1G") Then
      Frms.CLASSV = "1011"
    End If
    If Frms.ShowDialog = Windows.Forms.DialogResult.OK Then
      Dim strV() As String = Frms.Item
      If strV Is Nothing OrElse strV.Length = 0 Then Return
      If aryTB.ContainsKey(strV(0)) = False Then
        Dim sqlCV As New APSQL.SQLCNV
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TBB")
        sqlCV.Where("TBB03", "=", strV(0))
        sqlCV.SqlFields("TBB03")
        sqlCV.SqlFields("TBB05+' '+TBB06", "INA")
        sqlCV.SqlFields("TBB08")
        sqlCV.SqlFields("SA14")
        sqlCV.SqlFields("SA20")
        Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        If rs.Rows.Count > 0 Then
          aryTB.Add(rs.Rows(0)!TBB03.ToString.Trim, rs.Rows(0)!INA.ToString.Trim)
          If rs.Rows(0)!TBB08.ToString.Trim = "1010" Or rs.Rows(0)!TBB08.ToString.Trim = "1011" Then
            Dim rs1 As DataTable = DG1.DataSource
            If rs1.Rows.Count = 0 Then Return
            Dim strJ As String = rs1.Rows(rs1.Rows.Count - 1).Item(1).ToString.Trim
            If strJ = "" Then
              strJ = strGRP
              If rs1.Rows.Count = 1 Then rs1.Rows.Clear()
            End If
            rs1.Rows.Add("0", strJ, "", rs.Rows(0)!TBB03.ToString.Trim, rs.Rows(0)!INA.ToString.Trim, "1", "200")
            Dim ss As New clsDieSpec
            ss.DieDecode(rs.Rows(0)!SA14.ToString.Trim)
            Label4.Text = ss.PaperWidth.ToString("0.0").TrimEnd("0").TrimEnd(".") & "mm " & (ss.JumpLength * ss.PaperWidth / ss.ModX / ss.ModY * 0.000001).ToString("0.0000") & BIG2GB(" 平方米")
          End If
        End If
        DB.CloseRs(rs)
      End If
    End If
  End Sub

  Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

  End Sub
End Class