Public Class JSON
  Private Elements As New Dictionary(Of String, Object)
  Private strJSON As String = ""
  Private intDe As Integer = 0
  Sub New(ByVal strJ As String)
    strJSON = strJ
    DecodeJSON(strJ)
  End Sub
  Public Property JSON() As String
    Get
      Return strJSON
    End Get
    Set(ByVal value As String)
      strJSON = value
    End Set
  End Property
  Public Sub Clear()
    Elements.Clear()
  End Sub
  Public Sub Add(ByVal strN As String, ByVal strV As Object)
    If strN.Trim = "" OrElse strV Is Nothing Then Return
    If Elements.ContainsKey(strN) = False Then
      Elements.Add(strN, strV)
    Else
      Elements(strN) = strV
    End If
  End Sub
  Public Sub Add(strN As String, rs As DataTable)
    If rs Is Nothing OrElse rs.Rows.Count = 0 Then
      If strN.Trim <> "" Then
        Add(strN.Trim, CType(Nothing, Object))
      End If
    End If
    Dim o As JSON = Me
    If strN.Trim <> "" Then
      o = New JSON("")
      Add(strN.Trim, o)
    End If
    Dim strP As String = ""
    Dim aryL As New ArrayList
    For Each r As DataRow In rs.Rows
      Dim s As New JSON("")
      For Each c As DataColumn In rs.Columns
        If r.Item(c).GetType Is GetType(DBNull) Then
          s.Add(c.ColumnName, CType(Nothing, Object))
        Else
          Select Case c.DataType.Name
            Case "Byte[]"
              Dim bytV() As Byte = r.Item(c)
              s.Add(c.ColumnName, Convert.ToBase64String(bytV))
            Case "Decimal", "Double", "Single"
              s.Add(c.ColumnName, Val(r.Item(c).ToString))
            Case "Byte", "Int32", "Int64", "Int16"
              s.Add(c.ColumnName, Convert.ToInt64(r.Item(c).ToString))
            Case "UInt16", "UInt32", "UInt64"
              s.Add(c.ColumnName, Convert.ToUInt64(r.Item(c).ToString))
            Case "Boolean"
              s.Add(c.ColumnName, r.Item(c))
            Case Else
              s.Add(c.ColumnName, r.Item(c).ToString)
          End Select
        End If
      Next
      aryL.Add(s)
    Next
    o.Add(aryL)
  End Sub
  Public Sub Add(ByVal aryL As ArrayList)
    If aryL Is Nothing OrElse aryL.Count = 0 Then Return
    If Elements.ContainsKey("$$ARY$$") = False Then
      Elements.Add("$$ARY$$", aryL)
    Else
      CType(Elements("$$ARY$$"), ArrayList).AddRange(aryL.ToArray)
    End If
  End Sub
  Private Function ConArray(ByVal aryL As ArrayList) As String
    Dim strM As String = ""
    If aryL.Count > 0 Then
      strM &= "["
      For Each o As Object In aryL
        If o.GetType Is GetType(JSON) Then
          strM &= CType(o, JSON).ToString & ","
        ElseIf o.GetType Is GetType(ArrayList) Then
          strM &= ConArray(o) & ","
        ElseIf o.GetType Is GetType(String) Then
          strM &= """" & o.ToString.Replace(vbCrLf, "\n").Replace(vbTab, "\t") & ""","
        ElseIf o.GetType Is GetType(Double) Then
          Dim strA As String = o.ToString
          If strA.IndexOf(".") < 1 Then strA &= ".0"
          strM &= strA & ","
        ElseIf o IsNot Nothing Then
          strM &= o.ToString & ","
        Else
          strM &= "null,"
        End If
      Next
      strM = strM.TrimEnd(",") & "]"
    End If
    Return strM
  End Function
  Public Overrides Function ToString() As String
    Dim bolAryonly As Boolean = False
    Dim strM As String = ""
    For Each strK As String In Elements.Keys
      If strK = "$$ARY$$" Then
        Dim aryL As ArrayList = Elements(strK)
        strM &= ConArray(aryL) & ","
      Else
        Dim o As Object = Elements(strK)
        If o.GetType Is GetType(String) Then
          strM &= """" & strK & """:""" & CType(o, String).Replace(vbCrLf, "\n").Replace(vbTab, "\t") & ""","
        ElseIf o.GetType Is GetType(Double) Then
          Dim strA As String = o.ToString
          If strA.IndexOf(".") < 1 Then strA &= ".0"
          strM &= """" & strK & """:" & strA & ","
        Else
          strM &= """" & strK & """:" & o.ToString & ","
        End If
        bolAryonly = True
      End If
    Next
    If bolAryonly = True Then
      Return "{" & strM.TrimEnd(",") & "}"
    Else
      Return strM.TrimEnd(",")
    End If
    Return strM
  End Function
  Private Sub JSONArray(ByVal strV As String)
    Dim strIG As String = "", bolCL As Boolean = False, intI2 As Integer = 0, intI3 As Integer = 0
    Dim aryL As New ArrayList
    If strV = "" Then Return
    Dim intI As Integer = 0
    While intI < strV.Length
      If bolCL And strV(intI) <> """"c Then
        intI += 1
        Continue While
      End If
      Select Case strV(intI)
        Case """"c
          bolCL = Not bolCL
        Case "{"c
          intI2 += 1
        Case "["c
          intI3 += 1
        Case "}"c
          intI2 -= 1
        Case "]"c
          intI3 -= 1
        Case ","c
          If bolCL = False And intI2 = 0 And intI3 = 0 Then
            Dim strR As String = strV.Substring(0, intI)
            strV = strV.Substring(intI + 1)
            If strR.StartsWith("""") Then
              strR = strR.Substring(1, strR - 2)
              aryL.Add(strR)
            ElseIf strR.StartsWith("[") Or strR.StartsWith("{") Then
              aryL.Add(New JSON(strR))
            Else
              aryL.Add(strR)
            End If
            intI = 0
            Continue While
          End If
      End Select
      intI += 1
    End While
    If bolCL = False And intI2 = 0 And intI3 = 0 Then
      Dim strR As String = strV
      strV = ""
      If strR.StartsWith("""") Then
        strR = strR.Substring(1, strR - 2)
        aryL.Add(strR)
      ElseIf strR.StartsWith("[") Or strR.StartsWith("{") Then
        aryL.Add(New JSON(strR))
      Else
        aryL.Add(strR)
      End If
    Else
      strV = ""
    End If
    Elements.Add("$$ARY$$", aryL)
  End Sub
  Public Function ItemNull(strKey As String) As Object
    Dim o As Object = Item(strKey)
    If o Is Nothing Then Return ""
    Return o
  End Function

  Public Function Item(strKey As String) As Object
    If strKey Is Nothing Then Return Nothing
    Dim o As Object = Me
    Dim strV() As String
    If strKey.IndexOf("^") > 0 Then
      strV = strKey.Split("^")
    ElseIf strKey.IndexOf("|") > 0 Then
      strV = strKey.Split("|")
    Else
      strV = strKey.Split(",")
    End If
    For Each strK As String In strV
      If o Is Nothing Then Return Nothing
      If o Is Me Then
        If Elements.ContainsKey(strK) Then
          o = Elements(strK)
          Continue For
        ElseIf Elements.Count = 1 And Elements.ContainsKey("$$ARY$$") Then
          o = Elements("$$ARY$$")
        Else
          Return Nothing
        End If
      End If
      If o.GetType Is GetType(JSON) Then
        o = CType(o, JSON).Item(strK)
      ElseIf o.GetType Is GetType(ArrayList) Then
        With CType(o, ArrayList)
          If IsNumeric(strK) Then
            If .Count > Val(strK) Then
              o = .Item(Val(strK))
            Else
              o = Nothing
            End If
          Else
            If .Count = 1 And .Item(0).GetType Is GetType(JSON) Then
              o = CType(.Item(0), JSON).Item(strK)
            End If
          End If
        End With
      End If
    Next
    Return o
  End Function
  Public Function ContainsKey(strKey) As Boolean
    Return Elements.ContainsKey(strKey)
  End Function
  Public Function GetAll() As Dictionary(Of String, Object)
    Return Elements
  End Function
  Private Sub SubDecode(ByVal strV As String)
    intDe = 0
    Dim intJ As Integer = 0
    While strV.Length > 0
      intDe = 0
      Dim strN As String = GetName(strV)
      If strV.Length > intDe Then
        strV = strV.Substring(intDe)
      Else
        strV = ""
      End If
      Dim strVa As String = GetValue(strV)
      If strVa.StartsWith("{") Or strVa.StartsWith("[") Then
        If Elements.ContainsKey(strN) = False Then
          Elements.Add(strN, New JSON(strVa))
        End If
      Else
        If Elements.ContainsKey(strN) = False Then
          Elements.Add(strN, GetFormatValue(strVa))
        End If
      End If
    End While
  End Sub
  Private Function GetFormatValue(strV As String) As Object
    strV = strV.Replace("\n", vbCrLf)
    strV = strV.Replace("\r", vbCrLf)
    strV = strV.Replace("\t", vbTab)
    If strV.StartsWith("""") And strV.EndsWith("""") Then
      Return strV.Substring(1, strV.Length - 2)
    ElseIf strV.Trim.ToUpper = "TRUE" Then
      Return True
    ElseIf strV.Trim.ToUpper = "FALSE" Then
      Return False
    ElseIf strV.Trim.ToUpper = "NULL" Then
      Return Nothing
    ElseIf IsNumeric(strV) Then
      If strV.IndexOf(".") > 0 Then
        Return Val(strV)
      Else
        If Val(strV) <= Int32.MaxValue And Val(strV) >= Int32.MinValue Then
          Return CInt(strV)
        ElseIf Val(strV) <= Int64.MaxValue And Val(strV) >= Int64.MinValue Then
          Return CLng(strV)
        Else
          Return Convert.ToUInt64(strV)
        End If
      End If
    End If
    If IsDate(strV) = True Then
      Return CDate(strV)
    Else
      Return strV
    End If
  End Function
  Private Function GetValue(ByRef strV As String) As String
    Dim strIG As String = "", bolCL As Boolean = False, intI2 As Integer = 0, intI3 As Integer = 0
    strV = strV.Trim
    If strV.StartsWith(":") Then
      strV = strV.Substring(1).Trim
      intDe = 0
      For intI As Integer = 0 To strV.Length - 1
        'If strV(intI) = "\"c Then
        '  intI += 1
        '  Continue For
        'End If
        If bolCL And strV(intI) <> """"c Then
          Continue For
        End If
        Select Case strV(intI)
          Case """"c
            bolCL = Not bolCL
          Case "{"c
            intI2 += 1
          Case "["c
            intI3 += 1
          Case "}"
            intI2 -= 1
          Case "]"c
            intI3 -= 1
          Case ","c
            If bolCL = False And intI2 = 0 And intI3 = 0 Then
              Dim strR As String = strV.Substring(0, intI)
              strV = strV.Substring(intI + 1)
              Return strR
            End If
        End Select
      Next
    End If
    If bolCL = False And intI2 = 0 And intI3 = 0 Then
      Dim strR As String = strV
      strV = ""
      Return strR
    Else
      strV = ""
      Return ""
    End If
  End Function
  Private Function GetName(ByVal strV As String) As String
    If strV.StartsWith("""") Then
      For intI As Integer = 1 To strV.Length - 1
        'If strV(intI) = "\" Then
        '  intI += 1
        '  Continue For
        'End If
        If strV(intI) = """" Then
          intDe = intI + 1
          Return strV.Substring(1, intI - 1)
        End If
      Next
    End If
    Return ""
  End Function
  Public Sub DecodeJSON(ByVal strV As String)
    Elements.Clear()
    strV = strV.Trim(" ,".ToCharArray)
    If strV.Trim = "" Then Return
    If strV.StartsWith("{") And strV.EndsWith("}") Then
      SubDecode(strV.Substring(1, strV.Length - 2))
    ElseIf strV.StartsWith("[") And strV.EndsWith("]") Then
      JSONArray(strV.Substring(1, strV.Length - 2))
    End If
  End Sub
End Class
