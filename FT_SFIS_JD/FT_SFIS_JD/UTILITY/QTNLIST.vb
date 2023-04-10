''' <summary>
''' 字典類別
''' </summary>
''' <remarks></remarks>
Public Class QTNLIST
  Public Enum lang
    tw = 0
    ch = 1
    en = 2
  End Enum
  Private strName As String = ""
  Private strKey As String
  Private intlang As lang
  Private nodes As New Dictionary(Of String, Object)
  Private dgNodes As New Dictionary(Of String, QTNLIST)
  Private Function BIG2GB(strV As String) As String
    Select Case intlang
      Case lang.ch
        Return StrConv(strV, VbStrConv.SimplifiedChinese, &H804)
    End Select
    Return strV
  End Function

  ''' <summary>
  ''' 設定或取得類別名稱
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
  ''' <summary>
  ''' 設定或取得字典區段名
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property Key() As String
    Get
      Return strKey
    End Get
    Set(ByVal value As String)
      strKey = value
    End Set
  End Property
  ''' <summary>
  ''' 取得或設定字典使用英文
  ''' </summary>
  ''' <value>True:英文 False:中文</value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property Language() As lang
    Get
      Return intlang
    End Get
    Set(ByVal value As lang)
      intlang = value
    End Set
  End Property
  ''' <summary>
  ''' 新建一個空字典
  ''' </summary>
  ''' <param name="strK">字典區段名</param>
  ''' <param name="intE">使用中文(False) 英文(True)</param>
  ''' <remarks></remarks>
  Sub New(ByVal strK As String, Optional ByVal intE As lang = lang.tw)
    strKey = strK
    strName = strK
    intlang = intE
  End Sub
  ''' <summary>
  ''' 多載新建物件
  ''' </summary>
  ''' <param name="rs">資料表QTN DataTable</param>
  ''' <param name="intE">使用中文(False) 英文(True)</param>
  ''' <remarks></remarks>
  Sub New(ByVal rs As DataTable, Optional ByVal intE As lang = lang.tw)
    strKey = "$$Main"
    strName = "$$Main"
    intlang = intE
    Dim strSeg As String = "", s1 As QTNLIST = Nothing
    For Each r As DataRow In rs.Rows
      If strSeg <> r.Item(0).ToString.Trim Then
        strSeg = BIG2GB(r.Item(0).ToString.Trim)
        If nodes.ContainsKey(strSeg) = True Then
          s1 = nodes(strSeg)
        Else
          s1 = New QTNLIST(strSeg, intE)
          nodes.Add(strSeg, s1)
        End If
      End If
      If s1 Is Nothing Then Continue For
      Dim strD(r.ItemArray.Length - 1) As String
      For intI As Integer = 0 To r.ItemArray.Length - 1
        If r.ItemArray(intI).GetType Is GetType(DBNull) Then
          strD(intI) = ""
        Else
          strD(intI) = BIG2GB(r.ItemArray(intI))
        End If
      Next
      s1.Add(BIG2GB(r.Item(1).ToString.Trim), strD)
    Next
  End Sub
  ''' <summary>
  ''' 加入一個單一字典區段
  ''' </summary>
  ''' <param name="strKV">字典項目</param>
  ''' <param name="strDS">字典字串英文或中文</param>
  ''' <remarks></remarks>
  Public Overloads Sub Add(ByVal strKV As String, ByVal strDS As Object)
    If strKV.Trim.Length = 0 Then Return
    strKV = BIG2GB(strKV)
    If nodes.ContainsKey(strKV) = False Then
      nodes.Add(strKV.Trim, strDS)
    End If
  End Sub
  ''' <summary>
  ''' 加入單一個字典區段
  ''' </summary>
  ''' <param name="strKV"></param>
  ''' <param name="strDS"></param>
  ''' <remarks></remarks>
  Public Overloads Sub Add(strKV As String, strDS As String)
    If strKV.Trim.Length = 0 Then Return
    Dim strV(3) As String
    If strDS.Trim = "" Then strDS = "Undefinded"
    If intlang = lang.en Then
      strV(3) = strDS
      strV(2) = ""
    Else
      strV(2) = BIG2GB(strDS)
      strV(3) = ""
    End If
    strV(1) = BIG2GB(strKV)
    If nodes.ContainsKey(strKV) = False Then
      nodes.Add(strKV.Trim, strV)
    End If
  End Sub
  ''' <summary>
  ''' 取出一個區段字典物件
  ''' </summary>
  ''' <param name="strK">字典區段名</param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function GetQTN(ByVal strK As String) As QTNLIST
    If strKey <> "$$Main" Then Return Nothing
    If nodes.ContainsKey(strK) = False Then Return Nothing
    If nodes(strK).GetType Is GetType(QTNLIST) Then
      Return nodes(strK)
    Else
      Return Nothing
    End If
  End Function
  ''' <summary>
  ''' 取出一個字典項目
  ''' </summary>
  ''' <param name="strK">字典項目</param>
  ''' <returns>字典字串中文或英文</returns>
  ''' <remarks></remarks>
  Public Function GetVal(ByVal strK As String) As String
    If nodes.ContainsKey(strK) = False Then Return ""
    If nodes(strK).GetType Is GetType(QTNLIST) Then
      Return ""
    Else
      If intlang = lang.en Then
        Return nodes(strK)(3).ToString.Trim
      Else
        Return BIG2GB(nodes(strK)(2).ToString.Trim)
      End If
    End If
  End Function
  ''' <summary>
  ''' 取出一段字典定義By 區段名
  ''' </summary>
  ''' <param name="strK">區段名</param>
  ''' <returns>空數據表==>無此區段</returns>
  ''' <remarks></remarks>
  Public Overloads Function GetRs(ByVal strK As String, Optional ByVal TypN As Type = Nothing) As DataTable
    Dim rs As New DataTable
    rs.TableName = strK
    If TypN Is Nothing Then TypN = GetType(String)
    rs.Columns.Add("KEYS", TypN)
    rs.Columns.Add("DATAS", GetType(String))
    Dim s1 As QTNLIST = GetQTN(strK)
    If s1 Is Nothing Then Return rs
    Return s1.GetRs(TypN)
  End Function
  ''' <summary>
  ''' 取出這一個區段字典定義
  ''' </summary>
  ''' <returns>回傳這一段數據表</returns>
  ''' <remarks></remarks>
  Public Overloads Function GetRs(Optional ByVal typN As Type = Nothing) As DataTable
    Dim rs As New DataTable
    rs.TableName = Name
    If typN Is Nothing Then typN = GetType(String)
    rs.Columns.Add("KEYS", typN)
    rs.Columns.Add("DATAS", GetType(String))
    For Each s1 As String In nodes.Keys
      If nodes(s1).GetType IsNot GetType(QTNLIST) Then
        If intlang = lang.en Then
          rs.Rows.Add(s1, nodes(s1)(3).ToString.Trim)
        Else
          rs.Rows.Add(s1, nodes(s1)(2).ToString.Trim)
        End If
      End If
    Next
    Return rs
  End Function
  Public Overloads Function ReBind(strK As String) As DataTable
    Dim rs As New DataTable
    rs.TableName = strK
    rs.Columns.Add("ID", GetType(String))
    rs.Columns.Add("CNAME", GetType(String))
    rs.Columns.Add("ENAME", GetType(String))
    If nodes.ContainsKey(strK) = False Then Return rs
    If nodes(strK).GetType Is GetType(QTNLIST) Then
      Dim QT As QTNLIST = nodes(strK)
      Dim aryS As New Dictionary(Of String, DataRow)
      For Each i() As Object In QT.nodes.Values
        aryS.Add(i(1).ToString.Trim, rs.Rows.Add(i(1).ToString.Trim, i(2).ToString.Trim, i(3).ToString.Trim))
      Next
      For Each strP As String In nodes.Keys
        If strP.StartsWith("#" & strK & "||") = True Then
          Dim strV() As String = Split(strP, "||"), c As DataColumn
          strV(1) = strV(1).Substring(2)
          If rs.Columns.Contains(strV(1)) = False Then
            c = rs.Columns.Add(strV(1), GetType(String))
          Else
            c = rs.Columns(strV(1))
          End If
          QT = nodes(strP)
          For Each i() As Object In QT.nodes.Values
            If aryS.ContainsKey(i(1).ToString.Trim) = True Then
              aryS(i(1).ToString.Trim).Item(c) = i(2).ToString.Trim
            Else
              Dim r1 As DataRow = rs.Rows.Add(i(1).ToString.Trim)
              aryS.Add(i(1).ToString.Trim, r1)
              r1.Item(c) = i(2).ToString.Trim
            End If
          Next
        End If
      Next
    End If
    Return rs
  End Function
  ''' <summary>
  ''' 產生一個多維字典表
  ''' </summary>
  ''' <param name="rs1">第一個資料表</param>
  ''' <param name="strK">第二個資料表</param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Overloads Function ReBind(rs1 As DataTable, strK As String) As DataTable
    Dim rs2 As DataTable = GetRs(strK, rs1.Columns(0).DataType)
    Return ReBind(rs1, rs2, strK)
  End Function
  ''' <summary>
  ''' 多載多維字典表
  ''' </summary>
  ''' <param name="rs1">第一個資料表</param>
  ''' <param name="rs2">第二個資料表</param>
  ''' <param name="strT">標題欄位名</param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Overloads Function ReBind(rs1 As DataTable, rs2 As DataTable, strT As String) As DataTable
    Dim rs As DataTable = rs1.Clone, aryS As New Dictionary(Of String, DataRow)
    Dim c As DataColumn = rs.Columns.Add(strT, GetType(String))
    For Each r1 As DataRow In rs1.Rows
      Dim r As DataRow = rs.Rows.Add(r1.ItemArray)
      aryS.Add(r1.Item(0).ToString.Trim, r)
    Next
    For Each r As DataRow In rs2.Rows
      If aryS.ContainsKey(r.Item(0).ToString.Trim) Then
        aryS(r.Item(0).ToString.Trim).Item(c) = r.Item(1)
      Else
        Dim r1 As DataRow = rs.Rows.Add(r.Item(0))
        r1.Item(c) = r.Item(1)
        aryS.Add(r1.Item(0).ToString.Trim, r1)
      End If
    Next
    Return rs
  End Function
  ''' <summary>
  ''' 字典清除
  ''' </summary>
  ''' <remarks></remarks>
  Public Sub Clear()
    nodes.Clear()
  End Sub

End Class
''' <summary>
''' 一個DataGridView引用字典類別
''' </summary>
''' <remarks></remarks>
Public Class DGDic
  Private strName As String
  Private DG As DataGridView = Nothing
  Private QTN As QTNLIST = Nothing
  Private dgNodes As New Dictionary(Of Integer, QTNLIST)
  ''' <summary>
  ''' 創建一個新的字典引用類別
  ''' </summary>
  ''' <param name="DGV">DataGridView控件</param>
  ''' <param name="QTNV">QTNLIST字典類別</param>
  ''' <remarks></remarks>
  Sub New(ByVal DGV As DataGridView, ByVal QTNV As QTNLIST)
    DG = DGV
    QTN = QTNV
    strName = DG.Name
  End Sub
  ''' <summary>
  ''' 取得或設定類別名稱
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
  ''' <summary>
  ''' 取得DataGridView
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public ReadOnly Property DataGridView() As DataGridView
    Get
      Return DG
    End Get
  End Property
  ''' <summary>
  ''' 取得QTNLIST
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public ReadOnly Property QTNLIST() As QTNLIST
    Get
      Return QTN
    End Get
  End Property
  ''' <summary>
  ''' 清除Format引用項目(注:DataGridViewComboBoxCoumns無法清除)
  ''' </summary>
  ''' <remarks></remarks>
  Public Sub FormatClear()
    If dgNodes.Count > 0 Then
      RemoveHandler DG.CellFormatting, AddressOf DGFormat
    End If
    dgNodes.Clear()
  End Sub
  ''' <summary>
  ''' 取得是否已經使用Format功能
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function isFormating() As Boolean
    Return dgNodes.Count > 0
  End Function
  ''' <summary>
  ''' 設置一個DataGridView欄位成為DataGridViewComboBoxColumns
  ''' </summary>
  ''' <param name="strFLD">DataGridViewColumns資料欄名稱</param>
  ''' <param name="strDIC">字典名稱</param>
  ''' <param name="typN" >欄位資料類型例如:Gettype(Integer)，Gettype(String)...
  ''' 預設為Gettype(Int16)</param>
  ''' <returns>True完成，False錯誤</returns>
  ''' <remarks></remarks>
  Public Function SetDGCombo(ByVal strFLD As String, ByVal strDIC As String, Optional ByVal typN As Type = Nothing) As Boolean
    If DG Is Nothing Then Return False
    If QTN.GetQTN(strDIC) Is Nothing Then Return False
    Dim DGC As DataGridViewComboBoxColumn
    For intI As Integer = 0 To DG.ColumnCount - 1
      If DG.Columns(intI).DataPropertyName = strFLD Then
        If DG.Columns(intI).GetType Is GetType(DataGridViewComboBoxColumn) Then
          DGC = DG.Columns(intI)
        Else
          DGC = New DataGridViewComboBoxColumn
          With DG.Columns(intI)
            DGC.Name = .Name
            DGC.CellTemplate.ValueType = .CellTemplate.ValueType
            DGC.CellTemplate.Style = .CellTemplate.Style
            DGC.DataPropertyName = .DataPropertyName
            DGC.DisplayMember = "DATAS"
            DGC.ValueMember = "KEYS"
            DGC.DefaultCellStyle = .DefaultCellStyle
            DGC.HeaderText = .HeaderText
            DGC.Width = .Width
            DGC.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
            DG.Columns.RemoveAt(intI)
            DG.Columns.Insert(intI, DGC)
            DGC.ValueType = .ValueType
          End With
        End If
        If typN Is Nothing Then typN = GetType(Int16)
        Dim rs As DataTable = QTN.GetRs(strDIC, typN)
        Debug.Print(rs.Rows(0).Item(0) & "," & rs.Rows(0).Item(1))
        Debug.Print(rs.Rows(1).Item(0) & "," & rs.Rows(1).Item(1))
        Debug.Print(rs.Rows(2).Item(0) & "," & rs.Rows(2).Item(1))
        DGC.DataSource = rs
        Return True
      End If
    Next
    Return False
  End Function
  ''' <summary>
  ''' 設置這個DataGridView某一欄位為字典項目
  ''' </summary>
  ''' <param name="strFLD">DataGridViewColumns資料欄名稱</param>
  ''' <param name="strDIC">字典名稱</param>
  ''' <returns>True完成，False錯誤</returns>
  ''' <remarks></remarks>
  Public Function SetDGFormat(ByVal strFLD As String, ByVal strDIC As String) As Boolean
    If DG Is Nothing Then Return False
    If QTN.GetQTN(strDIC) Is Nothing Then Return False
    For intI As Integer = 0 To DG.ColumnCount - 1
      If DG.Columns(intI).DataPropertyName = strFLD Then
        If dgNodes.ContainsKey(intI) = False Then
          If dgNodes.Count = 0 Then
            AddHandler DG.CellFormatting, AddressOf DGFormat
          End If
          dgNodes.Add(intI, QTN.GetQTN(strDIC))
        End If
        Return True
      End If
    Next
    Return False
  End Function
  Private Sub DGFormat(ByVal s As Object, ByVal e As DataGridViewCellFormattingEventArgs)
    If dgNodes.ContainsKey(e.ColumnIndex) = True Then
      Try
        Dim strV As String = DG.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString
        e.Value = dgNodes(e.ColumnIndex).GetVal(strV)
        If e.Value = "" Then e.Value = "Undefinded"
      Catch ex As Exception
        e.Value = "NULL"
      End Try
    End If
  End Sub
End Class
