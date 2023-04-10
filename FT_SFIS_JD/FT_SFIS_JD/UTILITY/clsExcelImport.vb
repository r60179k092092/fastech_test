Public Class clsExcelField
  Private strName As String
  Private strVer As String = "ExcelField V2013.1.0"
  Private strSheet As String = ""
  Private strRange As String = ""
  Private strAction As String = ""
  Private intFLDCNT As Integer = 0
  Private intFLDRng As Integer = 0
  Private strFormat As String = ""
  Private strLastR As String = ""
  Private strNewR As String = ""
  Private strNewF As String = ""
  Private strMerge As String = ""
  Private intBegin As Integer = 0
  Private intBeginX As Integer = 0
  Private intAddX As Integer = 0
  Private intAddY As Integer = 0
  ''' <summary>
  ''' 設定或取得欄位物件名稱
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
  '''  取得版本號
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public ReadOnly Property Version As String
    Get
      Return strVer
    End Get
  End Property
  ''' <summary>
  ''' 設定或取得欄位名稱的動作名
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property Action As String
    Get
      Return strAction
    End Get
    Set(value As String)
      strAction = value
    End Set
  End Property
  ''' <summary>
  ''' 取得或設定表單名稱
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property Sheet As String
    Get
      Return strSheet
    End Get
    Set(value As String)
      strSheet = value
    End Set
  End Property
  ''' <summary>
  ''' 取得或設定這個欄位設定的範圍字串
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property Range As String
    Get
      Return strRange
    End Get
    Set(value As String)
      strRange = value
      Dim strV() As String = strRange.Split(":")
      If strV.Length = 1 Then
        strNewR = strV(0)
      End If
    End Set
  End Property
  ''' <summary>
  ''' 設定或取得範圍物件中Column位置，從一開始
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property FieldCnt As Integer
    Get
      Return intFLDCNT
    End Get
    Set(value As Integer)
      intFLDCNT = value
    End Set
  End Property
  ''' <summary>
  ''' 取得或設定這一欄需要合併多少儲存格 0,1 表示不合併  2以上合併
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property FieldRng As Integer
    Get
      Return intFLDRng
    End Get
    Set(value As Integer)
      intFLDRng = value
    End Set
  End Property
  ''' <summary>
  ''' 取得或設定格式名
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property Format As String
    Get
      Return strFormat
    End Get
    Set(value As String)
      strFormat = value
    End Set
  End Property
  ''' <summary>
  ''' 取得或設定欄位使用後向右增量
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property AddX As Integer
    Get
      Return intAddX
    End Get
    Set(value As Integer)
      intAddX = value
    End Set
  End Property
  ''' <summary>
  ''' 取得或設定欄位使用後向下增量
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property AddY As Integer
    Get
      Return intAddY
    End Get
    Set(value As Integer)
      intAddY = value
    End Set
  End Property
  ''' <summary>
  ''' 取地目前欄位Row位置
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function GetBeginY() As Integer
    Return intBegin
  End Function
  ''' <summary>
  ''' 取得欄位Column位置
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function GetBeginX() As Integer
    Return intBeginX
  End Function
  Private Function GetNext(ByVal strN As String, ByVal intC As Integer) As String
    Dim intI As Integer = 0, strM As String = ""
    For intJ As Integer = 0 To strN.Length - 1
      intI += intI * 26 + "ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(strN.Substring(0, 1).ToUpper)
    Next
    intI += intC - 1
    If intI = 0 Then Return "A"
    While intI > 0
      strM = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Substring((intI Mod 26), 1) & strM
      intI = intI \ 26
    End While
    Return strM
  End Function
  ''' <summary>
  ''' 將欄位Row移動到相對位置並重置欄位範圍
  ''' </summary>
  ''' <param name="intY"></param>
  ''' <remarks></remarks>
  Public Overloads Sub Clear(intY As Integer)
    Dim strV() As String = strRange.Split(":")
    Dim intI As Integer = strV(0).IndexOfAny("0123456789".ToCharArray)
    If intI > 0 Then
      strNewR = strV(0).Substring(0, intI)
      intBegin = Val(strV(0).Substring(intI)) + intY
    End If
    If strV.Length = 2 Then
      strNewR = GetNext(strNewR, intFLDCNT)
      If intFLDRng > 1 Then strNewF = GetNext(strNewR, intFLDRng)
    End If
  End Sub
  ''' <summary>
  ''' 回復欄位原始位置設定
  ''' </summary>
  ''' <remarks></remarks>
  Public Overloads Sub Clear()
    Dim strV() As String = strRange.Split(":")
    Dim intI As Integer = strV(0).IndexOfAny("0123456789".ToCharArray)
    If intI > 0 Then
      strNewR = strV(0).Substring(0, intI)
      intBegin = Val(strV(0).Substring(intI))
    End If
    If strV.Length = 2 Then
      strNewR = GetNext(strNewR, intFLDCNT)
      If intFLDRng > 1 Then strNewF = GetNext(strNewR, intFLDRng)
    End If
  End Sub
  ''' <summary>
  ''' 取得移動Row後的Range範圍
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function DRange()
    Dim strV() As String = strRange.Split(":"), strM As String = "", intJ As Integer
    Dim intI As Integer = strV(0).IndexOfAny("0123456789".ToCharArray)
    If intI > 0 Then
      strM &= strV(0).Substring(0, intI) & intBegin.ToString("0")
      intJ = Val(strV(0).Substring(intI))
    End If
    If strV.Length > 1 Then
      strM &= ":"
      intI = strV(1).IndexOfAny("0123456789".ToCharArray)
      If intI > 0 Then
        strM &= strV(1).Substring(0, intI) & (Val(strV(1).Substring(intI)) - intJ + intBegin).ToString("0")
      End If
    End If
    Return strM
  End Function
  ''' <summary>
  ''' 取得目前位置之儲存格位置
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function GetCurrRange() As String
    Dim strM As String = strNewR & intBegin.ToString("0")
    strMerge = ""
    If intFLDRng > 0 Then
      strMerge = strM & ":" & strNewF & intBegin.ToString("0")
    End If
    intBegin += intAddY
    If intAddX > 0 Then
      intBeginX += intAddX
      strNewR = GetNext(strNewR, intAddX + 1)
      If intFLDRng > 1 Then strNewF = GetNext(strNewR, intFLDRng)
    End If
    strLastR = strM
    Return strM
  End Function
  Public Function GetRange(strK As String) As String
    Dim strV() As String = strRange.Split(":")
    If strV.Length = 1 Then Return strK
    Dim intI As Integer = strV(0).IndexOfAny("0123456789".ToCharArray)
    Dim intJ As Integer = strV(1).IndexOfAny("0123456789".ToCharArray)
    Dim intK As Integer = strK.IndexOfAny("0123456789".ToCharArray)
    Dim intM As Integer = Val(strK.Substring(intK)) - Val(strV(0).Substring(intI)) + Val(strV(1).Substring(intJ))
    Return strK & ":" & strV(1).Substring(0, intJ) & intM
  End Function
  Public Function GetLastRange() As String
    Return strLastR
  End Function
  ''' <summary>
  ''' 取得合併儲存格位置
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Overloads Function GetMerge() As String
    Return strMerge
  End Function
  ''' <summary>
  ''' 取得合併儲存格垂直與水平
  ''' </summary>
  ''' <param name="intEd">結束ROW</param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Overloads Function GetMerge(intEd As Integer) As String
    Dim strM As String = strLastR
    If intEd = 0 Then intEd = intBegin
    If intFLDRng > 0 Then
      strMerge = strM & ":" & strNewF & intEd.ToString("0")
    Else
      strMerge = strM & ":" & strNewR & intEd.ToString("0")
    End If
    Return strMerge
  End Function
  ''' <summary>
  ''' 初始一個欄位類型
  ''' </summary>
  ''' <param name="strN">欄位名</param>
  ''' <param name="strS">工作表名</param>
  ''' <param name="strR">欄位所屬範圍</param>
  ''' <param name="strA">欄位執行的指令</param>
  ''' <param name="strX">欄位Column自動增量</param>
  ''' <param name="strY">欄位Row自動增量</param>
  ''' <param name="strF1">欄位位置分號分隔後合併欄位</param>
  ''' <param name="strF">欄位輸出格式</param>
  ''' <remarks></remarks>
  Sub New(strN As String, strS As String, strR As String, strA As String, strX As String, strY As String, strF1 As String, strF As String)
    strName = strN
    strSheet = strS
    strRange = strR
    strAction = strA
    intAddX = Val(strX)
    intAddY = Val(strY)
    Dim strV() As String = strF1.Split(";")
    intFLDCNT = Val(strV(0))
    If strV.Length > 1 Then intFLDRng = Val(strV(1))
    strFormat = strF
    Clear()
  End Sub
End Class
Public Enum ExcelEnum As Integer
  xlShiftDown = -4121
  xlFormatFromLeftOrAbove = 0
  xlSolid = 1
  xlAutomatic = -4105
End Enum
''' <summary>
''' 導入Excel資料表
''' </summary>
''' <remarks></remarks>
Public Class clsExcelImport
  Private xlsAp As Object   '保留總表文件
  Private xlsBk As Object
  Private aryDic As New Dictionary(Of String, clsExcelField)
  Private aryShts As New Dictionary(Of String, Object)
  Private strPrt As String = ""
  Private strFileName As String = ""
  Private strExtra As String = ""
  Event AskFmt(s As clsExcelImport, strF As String, ByRef strD As String)
  ''' <summary>
  ''' 設定或取得Excel Appliction 物件
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property XLSAPP As Object
    Get
      Return xlsAp
    End Get
    Set(value As Object)
      xlsAp = value
    End Set
  End Property
  Public Property Extra As String
    Get
      Return strExtra
    End Get
    Set(value As String)
      strExtra = value
    End Set
  End Property
  ''' <summary>
  ''' 設定或取得印表機名稱
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property PrinterName() As String
    Get
      Return strPrt
    End Get
    Set(ByVal value As String)
      strPrt = value
    End Set
  End Property
  ''' <summary>
  ''' 設定或取得Excel檔名
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public ReadOnly Property FileName() As String
    Get
      Return strFileName
    End Get
  End Property
  ''' <summary>
  ''' 新增一個Excel物件
  ''' </summary>
  ''' <param name="xlsA"></param>
  ''' <param name="strTmpPath"></param>
  ''' <remarks></remarks>
  Sub New(ByVal xlsA As Object, ByVal strTmpPath As String)
    If xlsA Is Nothing Then xlsA = CreateObject("Excel.Application")
    If xlsA Is Nothing Then Return
    xlsAp = xlsA
    strFileName = strTmpPath
    xlsBk = xlsAp.Workbooks.Open(strTmpPath)
    xlsBk.CheckCompatibility = False
  End Sub
  Public Sub Quit(bolM As Boolean)
    'For Each strK As String In aryShts.Keys
    '  Try
    '    aryShts(strK) = Nothing
    '  Catch ex As Exception
    '    MsgBox(ex.Message)
    '  End Try
    'Next
    Try
      aryShts.Clear()
    Catch ex As Exception
      'MsgBox(ex.Message)
    End Try
    Try
      If xlsBk IsNot Nothing Then
        xlsBk.Close(False)
        xlsBk = Nothing
      End If
    Catch ex As Exception
      'MsgBox(ex.Message)
    End Try
    If bolM = True Then
      Try
        If xlsAp IsNot Nothing Then
          xlsAp.Quit()
          xlsAp = Nothing
          GC.Collect()
        End If
      Catch ex As Exception
        'MsgBox(ex.Message)
      End Try
    End If
  End Sub
  Public Function GetBook() As Object
    Return xlsBk
  End Function
  ''' <summary>
  ''' 保存Excel到檔案並且列印部分資料表
  ''' </summary>
  ''' <param name="strFile"></param>
  ''' <param name="strMatch"></param>
  ''' <remarks></remarks>
  Public Sub SaveXLS(Optional ByVal strFile As String = "", Optional ByVal strMatch As String = "")
    If xlsBk IsNot Nothing Then
      If strFile = "" Then
        xlsBk.Save()
      Else
        xlsBk.SaveAs(strFile)
        strFileName = strFile
      End If
      If strMatch <> "" And strPrt <> "" Then
        For Each xlsSR As Object In xlsBk.Sheets
          If xlsSR.Name Like strMatch Then
            xlsSR.PrintOut(, , , , strPrt)
          End If
        Next
      End If
    End If
  End Sub
  ''' <summary>
  ''' 讀取Excel指令表並打開Excel檔
  ''' </summary>
  ''' <param name="strData">指令所存表單名</param>
  ''' <remarks></remarks>
  Public Sub ReadXlt(Optional ByVal strData As String = "DATA")
    If xlsBk Is Nothing Then Return
    Dim es As Object, a(,) As Object
    Dim strV(7) As String
    For Each es In xlsBk.Sheets
      If aryShts.ContainsKey(es.Name.ToUpper.Trim) = False Then
        aryShts.Add(es.Name.ToUpper.Trim, es)
      End If
    Next
    aryDic.Clear()
    If aryShts.ContainsKey(strData.ToUpper.Trim) Then
      es = aryShts(strData.ToUpper.Trim)
      a = es.UsedRange.Value
      For intI As Integer = 1 To a.GetUpperBound(0)
        For intJ As Integer = 0 To 7
          strV(intJ) = ""
        Next
        If a(intI, 1) IsNot Nothing Then strV(0) = a(intI, 1).ToString.Trim
        If a(intI, 2) IsNot Nothing Then strV(1) = a(intI, 2).ToString.Trim.ToUpper
        If a(intI, 3) IsNot Nothing Then strV(2) = a(intI, 3).ToString.Trim
        If a(intI, 4) IsNot Nothing Then strV(3) = a(intI, 4).ToString.Trim.ToUpper
        If a(intI, 5) IsNot Nothing Then strV(4) = a(intI, 5).ToString.Trim
        If a(intI, 6) IsNot Nothing Then strV(5) = a(intI, 6).ToString.Trim
        If a(intI, 7) IsNot Nothing Then strV(6) = a(intI, 7).ToString.Trim
        If a(intI, 8) IsNot Nothing Then strV(7) = a(intI, 8).ToString.Trim
        If strV(0) = "ID" Or strV(1) = "" Or strV(2) = "" Or strV(3) = "" Or aryShts.ContainsKey(strV(1).ToUpper.Trim) = False Then Continue For
        If aryDic.ContainsKey(strV(0)) = False Then
          aryDic.Add(strV(0), New clsExcelField(strV(0), strV(1), strV(2), strV(3), strV(4), strV(5), strV(6), strV(7)))
        End If
      Next
    End If
    es = Nothing
  End Sub

  Public Sub SheetDelete(strN As String)
    If xlsBk Is Nothing Then Return
    xlsBk.Sheets(strN).Select()
    xlsAp.DisplayAlerts = False
    xlsAp.ActiveWindow.ActiveSheet.Delete()
    xlsAp.DisplayAlerts = True
  End Sub
  ''' <summary>
  ''' 取得每個Excel指令表
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function GetFields() As clsExcelField()
    Dim clsV(aryDic.Count - 1) As clsExcelField
    aryDic.Values.CopyTo(clsV, 0)
    Return clsV
  End Function
  ''' <summary>
  ''' 回填Excel指令表
  ''' </summary>
  ''' <param name="clsV"></param>
  ''' <remarks></remarks>
  Public Sub PutFields(clsV() As clsExcelField)
    aryDic.Clear()
    For Each clsM As clsExcelField In clsV
      aryDic.Add(clsM.Name, clsM)
    Next
  End Sub
  Private Function GetFormatData(wk As clsExcelField, strD As String)
    Dim strM As String = ""
    If wk.Format.Trim = "" Or wk.Format.StartsWith("*") Then
      strM = strD
    Else
      If strD = "" Then
        strM = wk.Format
      Else
        If wk.Format.Contains("[@]") Then
          strM = wk.Format.Replace("[@]", strD) 'wk.format="IPC:[@]-2013"
        Else
          If IsNumeric(strD) = True Then
            strM = Val(strD).ToString(wk.Format) 'wk.format="說明:0%KG-0002"
          Else
            strM = wk.Format
          End If
        End If
      End If
    End If
    Return strM
  End Function

  Private Function isNRange(ByVal strK1 As String, ByVal strK2 As String) As Boolean
    If strK1.ToString.ToUpper = strK2.ToString.ToUpper Then Return True
    Dim strV() As String = strK2.ToString.Split(":")
    Dim strV1() As String = (strK1.ToUpper & ":" & strK1.ToString).Split(":"), intJ As Integer = -1, intK As Integer = -1
    '計算擴充範圍行數
    Dim intI As Integer = strV(0).IndexOfAny("0123456789".ToCharArray)
    '如果本來就沒有行數就Return False
    If intI > 0 Then
      intJ = Val(strV(0).Substring(intI))
      strV(0) = strV(0).Substring(0, intI)
    ElseIf intI = 0 Then
      Return True
    Else
      Return False
    End If
    '計算被擴充行數
    intI = strV1(0).IndexOfAny("0123456789".ToCharArray)
    If intI > 0 Then
      intK = Val(strV1(0).Substring(intI))
    ElseIf intI = 0 Then
      Return True
    Else
      Return False
    End If
    '如果被擴充行比原擴充行大
    If intK > intJ Then
      '取Column 名
      strV1(0) = strV1(0).Substring(0, intI)
      intI = strV1(1).IndexOfAny("0123456789".ToCharArray)
      If intI > 0 Then strV1(1) = strV1(1).Substring(0, intI)
      '取擴充行次Column名
      If strV.Length > 1 Then
        intI = strV(1).IndexOfAny("0123456789".ToCharArray)
        If intI > 0 Then strV(1) = strV(1).Substring(0, intI)
        '比對如果被擴充超過擴充Columns
        If strV1(0) < strV(0) Or strV1(0) > strV(1) Then Return False
        If strV1(1) < strV(0) Or strV1(1) > strV(1) Then Return False
      Else
        '比對如果被擴充超過擴充Columns
        If strV1(0) <> strV(0) Or strV1(1) <> strV(0) Then Return False
      End If
      Return True
    Else
      Return False
    End If
  End Function
  ''' <summary>
  ''' 垂直合併儲存格，以上次使用儲存格到現在擴充行為止
  ''' 至於橫格合併則依然使用 F;C 欄位位置F ;總共合併幾欄
  ''' </summary>
  ''' <param name="strK">欄位名稱</param>
  ''' <remarks></remarks>
  Public Sub MergeCell(strK As String)
    Dim es As Object
    Dim wk As clsExcelField, bolM As Boolean = False
    If aryDic.ContainsKey(strK) = False Then Return
    wk = aryDic(strK)
    es = aryShts(wk.Sheet & strExtra)
    Select Case wk.Action
      Case "INSERT", "FILL", "APPEND"
        Dim r As Object = es.Range(wk.GetMerge(0))
        r.Merge()
    End Select
    es = Nothing
  End Sub
  Public Sub ClearMap()
    For Each s As clsExcelField In aryDic.Values
      If s.AddX > 0 Or s.AddY > 0 Then
        s.Clear()
      End If
    Next
  End Sub
  ''' <summary>
  ''' 將資訊放入Excel文件
  ''' </summary>
  ''' <param name="strK">欄位名稱，前綴@代表上一次的位置(只有APPEND,INSERT有效)</param>
  ''' <param name="strD">資料填入，FILL狀態填入^表示僅跳行不填字</param>
  ''' <remarks></remarks>
  Public Sub Add_Data(ByVal strK As String, ByVal strD As String, _
                      Optional cForeColor As Integer = -1, Optional cBackColor As Integer = -1)
    Dim es As Object
    Dim wk As clsExcelField, bolM As Boolean = False
    If aryDic.ContainsKey(strK) = False Then Return
    If strK.StartsWith("@") = True Then
      bolM = True
      strK = strK.Substring(1)
    End If
    wk = aryDic(strK)
    If aryShts.ContainsKey(wk.Sheet & strExtra) = False Then Return
    If strD = "?F" Then
      RaiseEvent AskFmt(Me, wk.Format, strD)
    End If
    es = aryShts(wk.Sheet & strExtra)
    Select Case wk.Action
      Case "COPYFILL"
        Dim strM() As String = wk.Range.Split(":")
        Dim intK As Integer = Val(strM(0).Substring(strM(0).IndexOfAny("1234567890".ToCharArray)))
        For Each wk1 As clsExcelField In aryDic.Values
          If wk.Range Is wk1.Range Then Continue For
          wk1.Clear(wk.GetBeginY - intK)
        Next
        Dim strRs As String = wk.GetCurrRange
        If strRs = strM(0) Then Return
        es.Range(wk.Range).Copy()
        es.Range(strRs).PasteSpecial()
        'es.Paste()
      Case "FILLBLANK"
        es.Range(wk.GetRange(wk.GetCurrRange)).ClearContents()
      Case "EXPAND"
        Dim intK As Integer = Val(strD) - Val(wk.FieldCnt)
        If intK <= 0 Then Exit Select
        For Each wk1 As clsExcelField In aryDic.Values
          If isNRange(wk1.Range, wk.Range) And wk1.Range <> wk.Range Then
            wk1.Clear(intK)
          End If
        Next
        Dim strM As String = wk.Format
        If strM = "" Then strM = wk.Range
        For intI As Integer = 1 To intK
          es.Range(strM).Insert(ExcelEnum.xlShiftDown, ExcelEnum.xlFormatFromLeftOrAbove)
          System.Threading.Thread.Sleep(100)
        Next intI
      Case "NEWROW"
        For Each wk1 As clsExcelField In aryDic.Values
          If isNRange(wk1.Range, wk.Range) Then
            wk1.Clear(Val(strD))
          End If
        Next
        If Val(strD) >= Val(wk.FieldCnt) Then
          es.Range(wk.DRange).Insert(ExcelEnum.xlShiftDown, ExcelEnum.xlFormatFromLeftOrAbove)
        End If
      Case "FILL"
        Dim strRs As String = wk.GetCurrRange
        If strD <> "^" Then
          es.Range(strRs).Value2 = GetFormatData(wk, strD)
          Dim strV1 As String = wk.GetMerge
          If strV1.Length > 0 Then
            es.Range(strV1).Merge()
            strRs = strV1
          End If
        End If
        If cBackColor <> -1 Then
          With es.Range(strRs).Interior
            .Pattern = ExcelEnum.xlSolid
            .PatternColorIndex = ExcelEnum.xlAutomatic
            .Color = cBackColor
            .TintAndShade = 0
            .PatternTintAndShade = 0
          End With
        End If
        If cForeColor <> -1 Then
          es.Range(strRs).Font.Color = cForeColor
        End If
      Case "INSERT"
        Dim r As Object
        Dim strRS As String = ""
        If bolM = True Then
          strRS = wk.GetLastRange
          r = es.Range(strRS)
        Else
          strRS = wk.GetCurrRange
          r = es.Range(strRS)
        End If
        Dim strV1 As String = ""
        If r.Value2 IsNot Nothing Then strV1 = r.Value2.ToString
        r.Value2 = GetFormatData(wk, strD) & strV1
        strV1 = wk.GetMerge
        If strV1.Length > 0 Then
          es.Range(strV1).Merge()
          strRS = strV1
        End If
        If cBackColor <> -1 Then
          With es.Range(strRS).Interior
            .Pattern = ExcelEnum.xlSolid
            .PatternColorIndex = ExcelEnum.xlAutomatic
            .Color = cBackColor
            .TintAndShade = 0
            .PatternTintAndShade = 0
          End With
        End If
        If cForeColor <> -1 Then
          es.Range(strRS).Font.Color = cForeColor
        End If
      Case "APPEND"
        Dim r As Object
        Dim strRS As String = ""
        If bolM = True Then
          strRS = wk.GetLastRange
          r = es.Range(strRS)
        Else
          strRS = wk.GetCurrRange
          r = es.Range(strRS)
        End If
        Dim strV1 As String = ""
        If r.Value2 IsNot Nothing Then strV1 = r.Value2.ToString
        r.Value2 = strV1 & GetFormatData(wk, strD)
        strV1 = wk.GetMerge
        If strV1.Length > 0 Then
          es.Range(strV1).Merge()
          strRS = strV1
        End If
        If cBackColor <> -1 Then
          With es.Range(strRS).Interior
            .Pattern = ExcelEnum.xlSolid
            .PatternColorIndex = ExcelEnum.xlAutomatic
            .Color = cBackColor
            .TintAndShade = 0
            .PatternTintAndShade = 0
          End With
        End If
        If cForeColor <> -1 Then
          es.Range(strRS).Font.Color = cForeColor
        End If
      Case "APPENDTRIM"
        Dim r As Object
        Dim strRS As String = ""
        If bolM = True Then
          strRS = wk.GetLastRange
          r = es.Range(strRS)
        Else
          strRS = wk.GetCurrRange
          r = es.Range(strRS)
        End If
        Dim strV1 As String = ""
        If r.Value2 IsNot Nothing Then strV1 = r.Value2.ToString
        Dim strV3() As String = strV1.Split(";；：:".ToCharArray)
        strV1 = strV3(0) & ":"
        r.Value2 = strV1 & GetFormatData(wk, strD)
        strV1 = wk.GetMerge
        If strV1.Length > 0 Then
          es.Range(strV1).Merge()
          strRS = strV1
        End If
        If cBackColor <> -1 Then
          With es.Range(strRS).Interior
            .Pattern = ExcelEnum.xlSolid
            .PatternColorIndex = ExcelEnum.xlAutomatic
            .Color = cBackColor
            .TintAndShade = 0
            .PatternTintAndShade = 0
          End With
        End If
        If cForeColor <> -1 Then
          es.Range(strRS).Font.Color = cForeColor
        End If
      Case "CHECKED"
        Dim r As Object = es.Range(wk.GetCurrRange)
        If strD = "^" Then Exit Select
        Dim strO() As String = r.Value2.ToString.Split(wk.Format.Substring(0, 1))
        Dim strM As String = ""
        If strD.StartsWith("*") Then
          For intI As Integer = 0 To strO.GetUpperBound(0) - 1
            If wk.Format.Length > intI + 2 Then
              If strD.IndexOf(wk.Format.Substring(intI + 2, 1)) > 0 Then
                strM &= strO(intI) & wk.Format.Substring(1, 1)
              Else
                strM &= strO(intI) & wk.Format.Substring(0, 1)
              End If
            Else
              strM &= strO(intI) & wk.Format.Substring(0, 1)
            End If
          Next
        Else
          For intI As Integer = 0 To strO.GetUpperBound(0) - 1
            If wk.Format.Length > intI + 2 Then
              If wk.Format.Substring(intI + 2, 1) = strD Then
                strM &= strO(intI) & wk.Format.Substring(1, 1)
              Else
                strM &= strO(intI) & wk.Format.Substring(0, 1)
              End If
            Else
              strM &= strO(intI) & wk.Format.Substring(0, 1)
            End If
          Next
        End If
        strM &= strO(strO.GetUpperBound(0))
        r.Value2 = strM
      Case "SHOW"
        xlsAp.Visible = True
        es.Activate()
      Case "PRINT"
        If strPrt <> "" Then es.PrintOut(, , , , strPrt)
    End Select
    es = Nothing
  End Sub
End Class
