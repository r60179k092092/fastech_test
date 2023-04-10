''' <summary>
''' 單一權限功能類別
''' strKey 功能表路徑使用/分隔
''' strName 功能項目說明
''' strSubRight 本功能之次選項授權
''' strAvlRight 本功能可以選擇之授權選項
''' strAvlName 本功能可以選擇之授權選項說明
''' bolT 本功能可以執行
''' 術語表：
''' 功能表：一組功能項目的集合，對應每個功能項目可以執行個別功能程式。比如:MenuStrip
''' 功能項目：一個功能項目可以執行功能程式的指標。比如 mnuF00 品號資料編輯作業
''' 可選授權選項：一個功能項目可以選擇的所有授權選項。它有選項編號及選項說明
'''             如：01&amp;編輯^02&amp;刪除^03&amp;列印^04&amp;查詢
''' 授權選項：一個功能項目下允許的授權選項。如: 01^03 表示可以編輯、列印，不能刪除、查詢
''' 授權字串：紀錄每個權限群組的允許授權之字串，它是由每一個strKey+授權選項由^號間隔字串
'''         如：MNUFILE\MNUF00^MNUFILE\MNUF00\01^MNUFILE\MNUF00\03^MNUFILE\MNUF01^...
'''         授權字串為ALL表示完全授權，任意功能都能執行
''' </summary>
''' <remarks></remarks>
Public Class clsRight
  Public strKey As String = ""
  Public strName As String = ""
  Public strSubRight As String = ""
  Public strAvlRight As String = ""
  Public strAvlName As String = ""
  Public bolT As Boolean = False
  ''' <summary>
  ''' 初始一個clsRight類別物件
  ''' </summary>
  ''' <param name="strK">功能項目路徑</param>
  ''' <param name="strN">功能項目說明</param>
  ''' <remarks></remarks>
  Sub New(strK As String, strN As String)
    strKey = strK
    strName = strN
  End Sub
  ''' <summary>
  ''' 加入可選授權選項
  ''' </summary>
  ''' <param name="strR">授權選項表 格式:項目編號&amp;說明^ 例:01&amp;編輯^02&amp;刪除^03&amp;查詢</param>
  ''' <remarks></remarks>
  Public Sub AddAvlRights(strR As String)
    Dim strV() As String = BIG2GB(strR).Split("^")
    Dim strM() As String = strSubRight.Split("^")
    Dim aryU As New ArrayList
    For Each strK As String In strV
      Dim strM1() As String = strK.Split("|&".ToCharArray)
      If aryU.Contains(strM1(0)) = True Then Continue For
      strAvlRight &= strM1(0) & "^"
      If strM1.Length > 1 Then
        strAvlName &= strM1(1) & "^"
      Else
        strAvlName &= strM1(0) & "^"
      End If
    Next
  End Sub
  ''' <summary>
  ''' 加入允許授權選項
  ''' </summary>
  ''' <param name="strR">授權選項表，必須是可選授權選項才能賦予權限</param>
  ''' <remarks></remarks>
  Public Sub AddSubRights(strR As String)
    Dim strV() As String = BIG2GB(strR).Split("^")
    Dim strM() As String = strSubRight.Split("^")
    Dim aryU As New ArrayList
    aryU.AddRange(strM)
    strM = strAvlRight.Split("^")
    Dim aryA As New ArrayList
    aryA.AddRange(strM)
    For Each strK As String In strV
      If aryA.Contains(strK) = False Then Continue For
      If aryU.Contains(strK) = True Then Continue For
      strSubRight &= strK & "^"
    Next
  End Sub
  ''' <summary>
  ''' 取得授權選項是否允許
  ''' </summary>
  ''' <param name="strR">授權選項表，可以多選只要滿足其一就可以授權</param>
  ''' <returns>True表示允許授權，False表示不允許授權</returns>
  ''' <remarks></remarks>
  Public Function HasRight(strR As String) As Boolean
    If bolT = False Then Return False
    If strSubRight = "ALL" Then Return True
    Dim strV() As String = strR.Split("^")
    Dim strM() As String = strSubRight.Split("^")
    Dim aryU As New ArrayList
    aryU.AddRange(strM)
    For Each strK As String In strV
      If aryU.Contains(strK) = True Then
        Return True
      End If
    Next
    Return False
  End Function
End Class
''' <summary>
''' 系統授權管理類別，經由這個類別可以管理編輯權限
''' 請注意：一個系統僅需要一個授權表，當使用者登錄後自取其授權字串設定權限選項
''' 全權字串可以由多個不同授權集合聯集使用，比如一個使用者屬於多個群組，每個群組都有一些
''' 授權選項，但整個使用者的權限就是這些群組權限的集合。
''' 應用本物件類別，首先使用MakeMenu方法建構全面性權限類別物件
''' 如果要使用簡易型授權選項(只有保存、刪除、確定及執行三個選項)請用LoadNew代替MakeMenu
'''     註：LoadNew只適合使用TreeView作為功能表的專案
''' 第二步將使用者授權限串透過InitRights方法授權
''' 第三步透過SetRight方法啟用整個功能表
''' </summary>
''' <remarks></remarks>
Public Class clsRights
  Const strQtn As String = "SFIS_QTN"
  Private strName As String = "AURTS"
  Private strExc As String = "WIN"
  Private aryRights As New Dictionary(Of String, clsRight)
  ''' <summary>
  ''' 權限字典的名稱
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
  ''' 部分功能表允許無條件授權
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property Exclued As String
    Get
      Return strExc
    End Get
    Set(value As String)
      strExc = value
    End Set
  End Property
  Private Overloads Sub LookNext(strR As String, s As ToolStripMenuItem, bolT As Boolean)
    For Each s1 As ToolStripItem In s.DropDownItems
      If s1.GetType Is GetType(ToolStripMenuItem) Then
        If s1.Name.ToUpper.StartsWith(strExc) Then Continue For
        If bolT Then s1.Text = BIG2GB(s1.Text)
        Dim sr As New clsRight(strR & "/" & s1.Name.ToUpper, s1.Text)
        aryRights.Add(sr.strKey, sr)
        LookNext(sr.strKey, s1, bolT)
      End If
    Next
  End Sub
  ''' <summary>
  ''' 多載 取得功能表組織上所有功能項目的權限設定
  ''' 功能表目前有二個類別：MenuStrip及TreeView
  ''' 所有功能項目包含:功能表類別及QTN字典中@AURTS段落中QTN02項目。
  ''' </summary>
  ''' <param name="s">MenuStrip</param>
  ''' <param name="bolT">是否重新載入字段改中文為繁體或簡體</param>
  ''' <remarks></remarks>
  Public Overloads Sub MakeMenu(s As MenuStrip, Optional bolT As Boolean = False)
    aryRights.Clear()
    For Each s1 As ToolStripMenuItem In s.Items
      If s1.Name.ToUpper.StartsWith(strExc) Then Continue For
      If bolT Then s1.Text = BIG2GB(s1.Text)
      Dim sr As New clsRight(s1.Name.ToUpper, s1.Text)
      aryRights.Add(sr.strKey, sr)
      LookNext(sr.strKey, s1, bolT)
    Next
    ReQtn()
  End Sub
  Private Overloads Sub LookNext(strR As String, s As TreeNode, bolT As Boolean)
    For Each s1 As TreeNode In s.Nodes
      If s1.Name.ToUpper.StartsWith(strExc) Then Continue For
      If bolT Then s1.Text = BIG2GB(s1.Text)
      Dim sr As New clsRight(strR & "/" & s1.Name.ToUpper, s1.Text)
      aryRights.Add(sr.strKey, sr)
      LookNext(sr.strKey, s1, bolT)
    Next
  End Sub
  ''' <summary>
  ''' 多載 取得功能表組織上所有功能項目的權限設定
  ''' 功能表目前有二個類別：MenuStrip及TreeView
  ''' 所有功能項目包含:功能表類別及QTN字典中@AURTS段落中QTN02項目。
  ''' </summary>
  ''' <param name="s">TreeView</param>
  ''' <param name="bolT">是否重新載入字段改中文為繁體或簡體</param>
  ''' <remarks></remarks>
  Public Overloads Sub MakeMenu(s As TreeView, Optional bolT As Boolean = False)
    aryRights.Clear()
    For Each s1 As TreeNode In s.Nodes
      If s1.Name.ToUpper.StartsWith(strExc) Then Continue For
      If bolT Then s1.Text = BIG2GB(s1.Text)
      Dim sr As New clsRight(s1.Name.ToUpper, s1.Text)
      aryRights.Add(sr.strKey, sr)
      LookNext(sr.strKey, s1, bolT)
    Next
    ReQtn()
  End Sub
  ''' <summary>
  ''' 合併所有QTN字典與功能項目
  ''' </summary>
  ''' <remarks></remarks>
  Private Sub ReQtn()
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, strQtn)
    sqlCV.Where("QTN01", "=", "@" & strName)
    sqlCV.SqlFields("*")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    Dim a As New ArrayList
    For Each r As DataRow In rs.Rows
      a.Add(r!QTN02.ToString.Trim.ToUpper)
      If aryRights.ContainsKey(r!QTN02.ToString.Trim.ToUpper) Then Continue For
      Dim sr As New clsRight(r!QTN02.ToString.ToUpper.ToUpper, BIG2GB(r!QTN03.ToString.Trim))
      aryRights.Add(sr.strKey, sr)
    Next
    For Each strK As String In aryRights.Keys
      If a.Contains(strK) Then Continue For
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, strQtn)
      sqlCV.SqlFields("QTN01", "@" & strName)
      sqlCV.SqlFields("QTN02", strK)
      sqlCV.SqlFields("QTN03", aryRights(strK).strName)
      DB.RsSQL(sqlCV.Text)
    Next
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, strQtn)
    sqlCV.Where("QTN01", "LIKE", "#@" & strName & "||%")
    sqlCV.SqlFields("*")
    sqlCV.sqlOrder("QTN01")
    sqlCV.sqlOrder("QTN02")
    rs = DB.RsSQL(sqlCV.Text, "RT")
    For Each r As DataRow In rs.Rows
      If r!QTN03.ToString.Trim <> "1" And r!QTN03.ToString.Trim.ToUpper.StartsWith("T") = False Then Continue For
      Dim strV As String = r!QTN01.ToString.Trim
      Dim strM As String = r!QTN02.ToString.Trim
      If aryRights.ContainsKey(strM) = False Then Continue For
      Dim intI As Integer = strV.IndexOf("||")
      If intI > 0 Then strV = BIG2GB(strV.Substring(intI + 2))
      aryRights(strM).AddAvlRights(strV)
    Next
  End Sub
  ''' <summary>
  ''' 取得這個功能項目是否允許授權
  ''' </summary>
  ''' <param name="strKey">功能項目字串(這個字串可以連接授權選項一起查詢)</param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function GetRight(strKey As String) As Boolean
    If aryRights.ContainsKey(strKey) = False Then
      Dim intI As Integer = strKey.LastIndexOf("/")
      If intI > 0 Then
        Dim strK As String = strKey.Substring(0, intI)
        Dim strM As String = strKey.Substring(intI + 1)
        If aryRights.ContainsKey(strK) = False Then
          Return False
        Else
          Return aryRights(strK).HasRight(strM)
        End If
      End If
      Return False
    End If
    Return aryRights(strKey).bolT
  End Function
  Public Overloads Function GetRights(tn As ToolStripMenuItem) As clsRight
    Dim strK As String = ""
    strK = tn.Name
    While tn.OwnerItem IsNot Nothing
      strK = "/" & strK
      tn = tn.OwnerItem
      strK = tn.Name & strK
    End While
    Return GetRights(strK)
  End Function
  Public Overloads Function GetRights(tn As TreeNode) As clsRight
    Dim strK As String = ""
    strK = tn.Name
    While tn.Parent IsNot Nothing
      strK = "/" & strK
      tn = tn.Parent
      strK = tn.Name & strK
    End While
    Return GetRights(strK)
  End Function
  Public Overloads Function GetRights(strK As String) As clsRight
    If aryRights.ContainsKey(strK) = True Then
      Return aryRights(strK)
    Else
      Dim s As New clsRight(strK, "")
      Return s
    End If
  End Function
  ''' <summary>
  ''' 單純大陸使用TreeView並且使用自動可選授權選項
  ''' </summary>
  ''' <param name="tw">TreeView
  ''' 功能表最後一級Name為P起頭者代表自動生成可選授權選項</param>
  ''' <param name="bolFrst">初始所有功能項目中文化</param>
  ''' <remarks></remarks>
  Public Sub LoadNew(tw As TreeView, Optional bolFrst As Boolean = False)
    MakeMenu(tw, bolFrst)
    For Each strK As String In aryRights.Keys
      If strK.Contains("/P") Then
        aryRights(strK).AddAvlRights(BIG2GB("001&保存^003&刪除^004&確定及執行"))
      End If
    Next
  End Sub
  ''' <summary>
  ''' 設定授權選項表，這個函數可以載入多個授權字串，並加以聯集
  ''' </summary>
  ''' <param name="strP">授權字串</param>
  ''' <param name="bolT">是否清空重新授權？預設不清空，True代表先清空遺留授權選項</param>
  ''' <remarks></remarks>
  Public Sub InitRights(strP As String, Optional bolT As Boolean = False)
    If bolT = True Then
      For Each s As clsRight In aryRights.Values
        s.bolT = False
        s.strSubRight = ""
      Next
    End If
    If strP.Trim.ToUpper = "ALL" Then
      For Each s As clsRight In aryRights.Values
        s.bolT = True
        s.strSubRight = "ALL"
      Next
      Return
    End If
    Dim strV() As String = strP.Split("^")
    For Each strK As String In strV
      If strK.Trim = "" Then Continue For
      If aryRights.ContainsKey(strK) Then
        aryRights(strK).bolT = True
      Else
        Dim intI As Integer = strK.LastIndexOf("/")
        If intI > 0 Then
          Dim strM1 As String = strK.Substring(0, intI)
          If aryRights.ContainsKey(strM1) = True Then
            aryRights(strM1).AddSubRights(strK.Substring(intI + 1))
          End If
        End If
      End If
    Next
  End Sub
  Public Sub InitRightsALL(strP As String)
    If strP.Trim.ToUpper = "ALL" Then
      If aryRights.Count = 0 Then
        Dim s1 As New clsRight("ALL", "ALL")
        aryRights.Add(s1.strKey, s1)
      End If
      For Each s As clsRight In aryRights.Values
        s.bolT = True
        s.strSubRight = "ALL"
      Next
      Return
    End If
    Dim strV() As String = strP.Split("^")
    For Each strK As String In strV
      If strK.Trim = "" Then Continue For
      If aryRights.ContainsKey(strK) Then
        aryRights(strK).bolT = True
      Else
        Dim intI As Integer = strK.LastIndexOf("/")
        If intI > 0 Then
          Dim strM1 As String = strK.Substring(0, intI)
          If aryRights.ContainsKey(strM1) = False Then
            aryRights.Add(strM1, New clsRight(strM1, strM1))
          End If
          aryRights(strM1).AddAvlRights(BIG2GB("001&保存^003&刪除^004&確定及執行"))
          aryRights(strM1).AddSubRights(strK.Substring(intI + 1))
          aryRights(strM1).bolT = True
        Else
          If aryRights.ContainsKey(strK) = False Then
            aryRights.Add(strK, New clsRight(strK, strK))
          End If
          aryRights(strK).bolT = True
        End If
      End If
    Next
  End Sub

  ''' <summary>
  ''' 讀取授權表轉成授權字串，通常是使用InitRights後取得所聯集的事項。
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function ReadRights() As String
    Dim strV As String = ""
    For Each s As clsRight In aryRights.Values
      If s.bolT = True Then
        strV &= s.strKey & "^"
        Dim strM() As String = s.strSubRight.Split("^")
        For Each strK As String In strM
          If strK <> "" Then
            strV &= s.strKey & "/" & strK & "^"
          End If
        Next
      End If
    Next
    Return strV.Trim("^ ".ToCharArray)
  End Function
  Private Overloads Sub ReRights(tn As TreeNode, strPATH As String, aryR As ArrayList)
    If strPATH = "" Then
      strPATH = tn.Name
    Else
      strPATH &= "/" & tn.Name
    End If
    If aryR.Contains(strPATH) = True Or aryR(0) = "ALL" Then
      tn.ForeColor = Color.Black
      tn.Tag = ""
    Else
      If aryRights.ContainsKey(strPATH) = False Then
        tn.ForeColor = Color.Black
        tn.Tag = ""
      Else
        tn.ForeColor = Color.Gray
        tn.Tag = "L"
      End If
    End If
    If tn.Nodes.Count = 0 Then Return
    For Each tn1 As TreeNode In tn.Nodes
      ReRights(tn1, strPATH, aryR)
    Next
  End Sub
  Private Overloads Sub ReRights(sn As ToolStripItem, strPATH As String, aryR As ArrayList)
    If sn.GetType IsNot GetType(ToolStripMenuItem) Then
      Return
    End If
    If strPATH = "" Then
      strPATH = sn.Name
    Else
      strPATH &= "/" & sn.Name
    End If
    If aryR.Contains(strPATH) = True Or aryR(0) = "ALL" Then
      sn.Enabled = True
    Else
      If aryRights.ContainsKey(strPATH) = False Then
        sn.Enabled = True
      Else
        sn.Enabled = False
      End If
    End If
    If aryRights.ContainsKey(strPATH) Then
      aryRights(strPATH).bolT = sn.Enabled
    End If
    With CType(sn, ToolStripMenuItem)
      If .DropDownItems.Count = 0 Then Return
      For Each tn1 As ToolStripItem In .DropDownItems
        ReRights(tn1, strPATH, aryR)
      Next
    End With
  End Sub
  ''' <summary>
  ''' 多載：以授權字串決定MenuStrip或TreeView之功能項目不能啟用
  ''' </summary>
  ''' <param name="ms">MenuStrip</param>
  ''' <param name="strR">授權字串，如果空白授權就表示使用InitRights所建構權限表</param>
  ''' <remarks></remarks>
  Public Overloads Sub SetRight(ms As MenuStrip, Optional strR As String = "")
    If strR <> "" Then
      InitRights(strR, True)
    End If
    strR = ReadRights()
    Dim strV() As String = strR.Split("^")
    Dim s1 As New ArrayList
    s1.AddRange(strV)
    For Each tn As ToolStripItem In ms.Items
      ReRights(tn, "", s1)
    Next
  End Sub
  ''' <summary>
  ''' 多載：以授權字串決定MenuStrip或TreeView之功能項目不能啟用
  ''' </summary>
  ''' <param name="tw">TreeView</param>
  ''' <param name="strR">授權字串，如果空白授權就表示使用InitRights所建構權限表</param>
  ''' <remarks></remarks>
  Public Overloads Sub SetRight(tw As TreeView, Optional strR As String = "")
    If strR <> "" Then
      InitRights(strR, True)
    End If
    strR = ReadRights()
    Dim strV() As String = strR.Split("^")
    Dim s1 As New ArrayList
    s1.AddRange(strV)
    For Each tn As TreeNode In tw.Nodes
      ReRights(tn, "", s1)
    Next
  End Sub
  Private Sub ReCheck(tn As TreeNode, strPATH As String, aryR As ArrayList)
    If strPATH = "" Then
      strPATH = tn.Name
    Else
      strPATH &= "/" & tn.Name
    End If
    If aryR.Contains(strPATH) = True Or aryR(0) = "ALL" Then
      tn.Checked = True
    Else
      tn.Checked = False
    End If
    If tn.Nodes.Count = 0 Then Return
    For Each tn1 As TreeNode In tn.Nodes
      ReCheck(tn1, strPATH, aryR)
    Next
  End Sub
  ''' <summary>
  ''' 將授權字串勾選一個TreeView編輯授權選項物件
  ''' </summary>
  ''' <param name="tw">TreeView</param>
  ''' <param name="strR">授權字串</param>
  ''' <remarks></remarks>
  Public Sub MakeChecked(tw As TreeView, strR As String)
    Dim strL() As String = strR.Split("^")
    Dim aryL As New ArrayList
    aryL.AddRange(strL)
    For Each tn As TreeNode In tw.Nodes
      ReCheck(tn, "", aryL)
    Next
  End Sub
  ''' <summary>
  ''' 根據權限表clsRights可選授權項目產生新的TreeView
  ''' </summary>
  ''' <param name="tw">TreeView</param>
  ''' <remarks></remarks>
  Public Sub MakeTree(tw As TreeView)
    tw.Nodes.Clear()
    For Each strK As String In aryRights.Keys
      Dim strV() As String = strK.Split("/")
      Dim clsR As clsRight = aryRights(strK)
      Dim tn As TreeNode = Nothing, strPath As String = ""
      For Each strM As String In strV
        If tn Is Nothing Then
          If tw.Nodes.ContainsKey(strM) = False Then
            tn = tw.Nodes.Add(strM, "")
          Else
            tn = tw.Nodes(strM)
          End If
          strPath = tn.Name
        Else
          If tn.Nodes.ContainsKey(strM) = False Then
            tn = tn.Nodes.Add(strM, "")
          Else
            tn = tn.Nodes(strM)
          End If
          strPath &= "/" & tn.Name
        End If
      Next
      If tn IsNot Nothing AndAlso strPath = strK Then
        tn.Text = clsR.strName
        Dim strN() As String = clsR.strAvlRight.Split("^")
        Dim strL() As String = clsR.strAvlName.Split("^")
        For intI As Integer = 0 To strN.GetUpperBound(0)
          If strN(intI).Trim = "" Then Continue For
          tn.Nodes.Add(strN(intI).Trim, strL(intI).Trim)
        Next
      End If
    Next
  End Sub
  Private Function ReadNodeChk(tn As TreeNode, strPath As String) As String
    Dim strR As String = ""
    If strPath = "" Then
      strPath = tn.Name
    Else
      strPath &= "/" & tn.Name
    End If
    If tn.Checked = True Then strR &= strPath & "^"
    If tn.Nodes.Count = 0 Then Return strR.Trim("^")
    For Each tn1 As TreeNode In tn.Nodes
      strR &= ReadNodeChk(tn1, strPath) & "^"
    Next
    Return strR.Trim("^")
  End Function
  ''' <summary>
  ''' 讀取TreeView勾選，建立授權字串
  ''' </summary>
  ''' <param name="tw">TreeView</param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function ReadChecked(tw As TreeView) As String
    Dim strR As String = ""
    For Each tn As TreeNode In tw.Nodes
      strR &= ReadNodeChk(tn, "") & "^"
    Next
    Return strR.Trim("^")
  End Function
End Class
