Public Class SampleQty
  Private arySQ() As Integer = {8, 15, 25, 50, 90, 150, 280, 500, 1200, 3200, 10000, 35000, 150000, 500000, 999999999}
  Private arySC() As String = {"S-1", "AAAABBBBCCCCDDD", _
                               "S-2", "AAABBBCCCDDDEEE", _
                               "S-3", "AABBCCDDEEFFGGH", _
                               "S-4", "AABCCDEEFGGHJJK", _
                               "L-1", "AABCCDEFGHJKLMN", _
                               "L-2", "ABCDFFGHJKLMNPO", _
                               "L-3", "BCDEGGHJKLMNPQR", _
                               "S1", "AAAABBBBCCCCDDD", _
                               "S2", "AAABBBCCCDDDEEE", _
                               "S3", "AABBCCDDEEFFGGH", _
                               "S4", "AABCCDEEFGGHJJK", _
                               "L1", "AABCCDEFGHJKLMN", _
                               "L2", "ABCDFFGHJKLMNPO", _
                               "L3", "BCDEGGHJKLMNPQR", _
                               "Level I", "AABCCDEFGHJKLMN", _
                               "Level II", "ABCDFFGHJKLMNPO", _
                               "Level III", "BCDEGGHJKLMNPQR", _
                               "FreeMode", "ABCDFFGHJKLMNPO"}
  Private intLotQty As Integer = 0
  Private strLevel As String = ""
  Public Property LotQty() As Integer
    Get
      Return intLotQty
    End Get
    Set(ByVal value As Integer)
      intLotQty = value
    End Set
  End Property
  Public Property Level() As String
    Get
      Return strLevel
    End Get
    Set(ByVal value As String)
      strLevel = value
    End Set
  End Property
  Public Overloads Function GetID() As String
    For intI As Integer = 0 To arySC.GetUpperBound(0) Step 2
      If strLevel.ToUpper = arySC(intI).ToUpper Then
        For intJ As Integer = 0 To arySQ.GetUpperBound(0)
          If intLotQty <= arySQ(intJ) Then
            Return arySC(intI + 1).Substring(intJ, 1)
          End If
        Next
      End If
    Next
    Return ""
  End Function
  Public Overloads Function GetID(ByVal strL As String, ByVal intLQ As Integer)
    Level = strL
    LotQty = intLQ
    Return GetID()
  End Function
  Public Function GetLevels() As String()
    Return New String() {"S1", "S2", "S3", "S4", "L1", "L2", "L3", "S-1", _
                         "S-2", "S-3", "S-4", "Level I", _
                         "Level II", "Level III", "FreeMode"}
  End Function
End Class
Public Class AcRe
  Private strName As String = ""
  Private strAQL As String = ""
  Private intAc As Integer = 0
  Private intRe As Integer = 0
  Private intLotQty As Integer = 0
  Private intSmpQty As Integer = 0
  Private strLevel As String = ""
  Private intMode As Integer = 0
  Sub New(ByVal strC As String, ByVal AQL As String, ByVal Ac As Integer, ByVal Re As Integer)
    strName = strC
    strAQL = AQL
    intAc = Ac
    intRe = Re
  End Sub
  Public Property Name() As String
    Get
      Return strName
    End Get
    Set(ByVal value As String)
      strName = value
    End Set
  End Property
  Public Property AQL() As String
    Get
      Return strAQL
    End Get
    Set(ByVal value As String)
      strAQL = value
    End Set
  End Property
  Public Property Ac() As Integer
    Get
      Return intAc
    End Get
    Set(ByVal value As Integer)
      intAc = value
    End Set
  End Property
  Public Property Re() As Integer
    Get
      Return intRe
    End Get
    Set(ByVal value As Integer)
      intRe = value
    End Set
  End Property
  Public Property Level() As String
    Get
      Return strLevel
    End Get
    Set(ByVal value As String)
      strLevel = value
    End Set
  End Property
  Public Property LotQty() As Integer
    Get
      Return intLotQty
    End Get
    Set(ByVal value As Integer)
      intLotQty = value
    End Set
  End Property
  Public Property SmpQty() As Integer
    Get
      If intLotQty < intSmpQty Then
        Return intLotQty
      Else
        Return intSmpQty
      End If
    End Get
    Set(ByVal value As Integer)
      intSmpQty = value
    End Set
  End Property
  Public Property Mode() As Integer
    Get
      Return intMode
    End Get
    Set(ByVal value As Integer)
      intMode = value
    End Set
  End Property
End Class
Public Class AQL
  Private strName As String = ""
  Private aryAcRe As New Dictionary(Of String, AcRe)
  Sub New(ByVal strN As String)
    strName = strN
  End Sub
  Public Sub Add(ByVal strCode As String, ByVal Ac As Integer, ByVal Re As Integer)
    For Each c As Char In strCode.ToCharArray
      aryAcRe.Add(c, New AcRe(c, strName, Ac, Re))
    Next
  End Sub
  Public Function GetAQLID(ByVal strID As String) As AcRe
    If aryAcRe.ContainsKey(strID) = False Then Return Nothing
    Return aryAcRe(strID)
  End Function
End Class
Public Class NORMAL
  Protected strCode As String = "ABCDEFGHJKLMNPQR"
  Protected intSmpQty() As Integer = {2, 3, 5, 8, 13, 20, 32, 50, 80, 125, 200, 315, 500, 800, 1250, 2000}
  Protected intMode As Integer = 0
  Protected aryAQL As New Dictionary(Of String, AQL)
  Protected strAQL As String = ""
  Protected intLotQty As Integer = 0
  Protected strLevel As String = ""
  Protected strID As String = ""
  Protected clsSQTY As New SampleQty
  Sub New()
    aryAQL.Add("0.010", New AQL("0.010"))
    aryAQL.Add("0.015", New AQL("0.015"))
    aryAQL.Add("0.025", New AQL("0.025"))
    aryAQL.Add("0.040", New AQL("0.040"))
    aryAQL.Add("0.065", New AQL("0.065"))
    aryAQL.Add("0.10", New AQL("0.10"))
    aryAQL.Add("0.15", New AQL("0.15"))
    aryAQL.Add("0.25", New AQL("0.25"))
    aryAQL.Add("0.40", New AQL("0.40"))
    aryAQL.Add("0.65", New AQL("0.65"))
    aryAQL.Add("1.0", New AQL("1.0"))
    aryAQL.Add("1.5", New AQL("1.5"))
    aryAQL.Add("2.5", New AQL("2.5"))
    aryAQL.Add("4.0", New AQL("4.0"))
    aryAQL.Add("6.5", New AQL("6.5"))
    aryAQL("0.010").Add(strCode, 0, 1)
    aryAQL("0.015").Add(strCode, 0, 1)
    aryAQL("0.025").Add("ABCDEFGHJKLMNP", 0, 1)
    aryAQL("0.025").Add("QR", 1, 2)
    aryAQL("0.040").Add("ABCDEFGHJKLMN", 0, 1)
    aryAQL("0.040").Add("PQ", 1, 2)
    aryAQL("0.040").Add("R", 2, 3)
    aryAQL("0.065").Add("ABCDEFGHJKLM", 0, 1)
    aryAQL("0.065").Add("NP", 1, 2)
    aryAQL("0.065").Add("Q", 2, 3)
    aryAQL("0.065").Add("R", 3, 4)
    aryAQL("0.10").Add("ABCDEFGHJKL", 0, 1)
    aryAQL("0.10").Add("MN", 1, 2)
    aryAQL("0.10").Add("P", 2, 3)
    aryAQL("0.10").Add("Q", 3, 4)
    aryAQL("0.10").Add("R", 5, 6)
    aryAQL("0.15").Add("ABCDEFGHJK", 0, 1)
    aryAQL("0.15").Add("LM", 1, 2)
    aryAQL("0.15").Add("N", 2, 3)
    aryAQL("0.15").Add("P", 3, 4)
    aryAQL("0.15").Add("Q", 5, 6)
    aryAQL("0.15").Add("R", 7, 8)
    aryAQL("0.25").Add("ABCDEFGHJ", 0, 1)
    aryAQL("0.25").Add("KL", 1, 2)
    aryAQL("0.25").Add("M", 2, 3)
    aryAQL("0.25").Add("N", 3, 4)
    aryAQL("0.25").Add("P", 5, 6)
    aryAQL("0.25").Add("Q", 7, 8)
    aryAQL("0.25").Add("R", 10, 11)
    aryAQL("0.40").Add("ABCDEFGH", 0, 1)
    aryAQL("0.40").Add("JK", 1, 2)
    aryAQL("0.40").Add("L", 2, 3)
    aryAQL("0.40").Add("M", 3, 4)
    aryAQL("0.40").Add("N", 5, 6)
    aryAQL("0.40").Add("P", 7, 8)
    aryAQL("0.40").Add("Q", 10, 11)
    aryAQL("0.40").Add("R", 14, 15)
    aryAQL("0.65").Add("ABCDEFG", 0, 1)
    aryAQL("0.65").Add("HJ", 1, 2)
    aryAQL("0.65").Add("K", 2, 3)
    aryAQL("0.65").Add("L", 3, 4)
    aryAQL("0.65").Add("M", 5, 6)
    aryAQL("0.65").Add("N", 7, 8)
    aryAQL("0.65").Add("P", 10, 11)
    aryAQL("0.65").Add("Q", 14, 15)
    aryAQL("0.65").Add("R", 21, 22)
    aryAQL("1.0").Add("ABCDEF", 0, 1)
    aryAQL("1.0").Add("GH", 1, 2)
    aryAQL("1.0").Add("J", 2, 3)
    aryAQL("1.0").Add("K", 3, 4)
    aryAQL("1.0").Add("L", 5, 6)
    aryAQL("1.0").Add("M", 7, 8)
    aryAQL("1.0").Add("N", 10, 11)
    aryAQL("1.0").Add("P", 14, 15)
    aryAQL("1.0").Add("QR", 21, 22)
    aryAQL("1.5").Add("ABCDE", 0, 1)
    aryAQL("1.5").Add("FG", 1, 2)
    aryAQL("1.5").Add("H", 2, 3)
    aryAQL("1.5").Add("J", 3, 4)
    aryAQL("1.5").Add("K", 5, 6)
    aryAQL("1.5").Add("L", 7, 8)
    aryAQL("1.5").Add("M", 10, 11)
    aryAQL("1.5").Add("N", 14, 15)
    aryAQL("1.5").Add("PQR", 21, 22)
    aryAQL("2.5").Add("ABCD", 0, 1)
    aryAQL("2.5").Add("EF", 1, 2)
    aryAQL("2.5").Add("G", 2, 3)
    aryAQL("2.5").Add("H", 3, 4)
    aryAQL("2.5").Add("J", 5, 6)
    aryAQL("2.5").Add("K", 7, 8)
    aryAQL("2.5").Add("L", 10, 11)
    aryAQL("2.5").Add("M", 14, 15)
    aryAQL("2.5").Add("NPQR", 21, 22)
    aryAQL("4.0").Add("ABC", 0, 1)
    aryAQL("4.0").Add("DE", 1, 2)
    aryAQL("4.0").Add("F", 2, 3)
    aryAQL("4.0").Add("G", 3, 4)
    aryAQL("4.0").Add("H", 5, 6)
    aryAQL("4.0").Add("J", 7, 8)
    aryAQL("4.0").Add("K", 10, 11)
    aryAQL("4.0").Add("L", 14, 15)
    aryAQL("4.0").Add("MNPQR", 21, 22)
    aryAQL("6.5").Add("AB", 0, 1)
    aryAQL("6.5").Add("CD", 1, 2)
    aryAQL("6.5").Add("E", 2, 3)
    aryAQL("6.5").Add("F", 3, 4)
    aryAQL("6.5").Add("G", 5, 6)
    aryAQL("6.5").Add("H", 7, 8)
    aryAQL("6.5").Add("J", 10, 11)
    aryAQL("6.5").Add("K", 14, 15)
    aryAQL("6.5").Add("LMNPQR", 21, 22)
  End Sub
  Public Property AQL() As String
    Get
      Return strAQL
    End Get
    Set(ByVal value As String)
      strAQL = value
    End Set
  End Property
  Public Property LotQty() As Integer
    Get
      Return intLotQty
    End Get
    Set(ByVal value As Integer)
      intLotQty = value
    End Set
  End Property
  Public Property Level() As String
    Get
      Return strLevel
    End Get
    Set(ByVal value As String)
      strLevel = value
    End Set
  End Property
  Public Function GetID() As String
    Return clsSQTY.GetID(Level, LotQty)
  End Function
  Public Overloads Function GetAcRe() As AcRe
    Dim strID As String = GetID()
    If strID = "" Or aryAQL.ContainsKey(strAQL) = False Then Return Nothing
    Dim clsAQL As AQL = aryAQL(strAQL)
    Dim clsA As AcRe = clsAQL.GetAQLID(strID)
    If clsA IsNot Nothing Then
      clsA.LotQty = intLotQty
      clsA.Level = strLevel
      clsA.Mode = intMode
      If strLevel.ToUpper.Trim = "FREEMODE" Then
        clsA.SmpQty = IIf(intLotQty > 1000, 1000, intLotQty)
        clsA.Re = clsA.SmpQty
      Else
        clsA.SmpQty = intSmpQty(strCode.IndexOf(strID))
        If clsA.SmpQty > intLotQty Then clsA.SmpQty = intLotQty
      End If
    End If
    Return clsA
  End Function
  Public Overloads Function GetAcRe(ByVal strA As String, ByVal strL As String, ByVal intQ As Integer) As AcRe
    If strL = "100%" Then
      Dim a As New AcRe("100%", strA, 1, 0)
      a.SmpQty = intLotQty
      Return a
    End If
    AQL = strA
    Level = strL
    LotQty = intQ
    Return GetAcRe()
  End Function
  Public Function GetLevels() As String()
    Return clsSQTY.GetLevels()
  End Function
  Public Function GetAQLs() As String()
    Return New String() {"0.010", "0.015", "0.025", "0.040", "0.065", "0.10", "0.15", "0.25", "0.40", "0.65", "1.0", "1.5", "2.5", "4.0", "6.5"}
  End Function
End Class
Public Class QCStrict
  Inherits NORMAL
  Sub New()
    strCode = "ABCDEFGHJKLMNPQRS"
    intSmpQty = New Integer() {2, 3, 5, 8, 13, 20, 32, 50, 80, 125, 200, 315, 500, 800, 1250, 2000, 3150}
    intMode = 1
    aryAQL.Clear()
    aryAQL.Add("0.010", New AQL("0.010"))
    aryAQL.Add("0.015", New AQL("0.015"))
    aryAQL.Add("0.025", New AQL("0.025"))
    aryAQL.Add("0.040", New AQL("0.040"))
    aryAQL.Add("0.065", New AQL("0.065"))
    aryAQL.Add("0.10", New AQL("0.10"))
    aryAQL.Add("0.15", New AQL("0.15"))
    aryAQL.Add("0.25", New AQL("0.25"))
    aryAQL.Add("0.40", New AQL("0.40"))
    aryAQL.Add("0.65", New AQL("0.65"))
    aryAQL.Add("1.0", New AQL("1.0"))
    aryAQL.Add("1.5", New AQL("1.5"))
    aryAQL.Add("2.5", New AQL("2.5"))
    aryAQL.Add("4.0", New AQL("4.0"))
    aryAQL.Add("6.5", New AQL("6.5"))
    aryAQL("0.010").Add(strCode, 0, 1)
    aryAQL("0.015").Add(strCode, 0, 1)
    aryAQL("0.025").Add("ABCDEFGHJKLMNPQR", 0, 1)
    aryAQL("0.025").Add("S", 1, 2)
    aryAQL("0.040").Add("ABCDEFGHJKLMN", 0, 1)
    aryAQL("0.040").Add("PQR", 1, 2)
    aryAQL("0.065").Add("ABCDEFGHJKLM", 0, 1)
    aryAQL("0.065").Add("NPQ", 1, 2)
    aryAQL("0.065").Add("R", 2, 3)
    aryAQL("0.10").Add("ABCDEFGHJKL", 0, 1)
    aryAQL("0.10").Add("MNP", 1, 2)
    aryAQL("0.10").Add("Q", 2, 3)
    aryAQL("0.10").Add("R", 3, 4)
    aryAQL("0.15").Add("ABCDEFGHJK", 0, 1)
    aryAQL("0.15").Add("LMN", 1, 2)
    aryAQL("0.15").Add("P", 2, 3)
    aryAQL("0.15").Add("Q", 3, 4)
    aryAQL("0.15").Add("R", 5, 6)
    aryAQL("0.25").Add("ABCDEFGHJ", 0, 1)
    aryAQL("0.25").Add("KLM", 1, 2)
    aryAQL("0.25").Add("N", 2, 3)
    aryAQL("0.25").Add("P", 3, 4)
    aryAQL("0.25").Add("Q", 5, 6)
    aryAQL("0.25").Add("R", 8, 9)
    aryAQL("0.40").Add("ABCDEFGH", 0, 1)
    aryAQL("0.40").Add("JKL", 1, 2)
    aryAQL("0.40").Add("M", 2, 3)
    aryAQL("0.40").Add("N", 3, 4)
    aryAQL("0.40").Add("P", 5, 6)
    aryAQL("0.40").Add("Q", 8, 9)
    aryAQL("0.40").Add("R", 12, 13)
    aryAQL("0.65").Add("ABCDEFG", 0, 1)
    aryAQL("0.65").Add("HJK", 1, 2)
    aryAQL("0.65").Add("L", 2, 3)
    aryAQL("0.65").Add("M", 3, 4)
    aryAQL("0.65").Add("N", 5, 6)
    aryAQL("0.65").Add("P", 8, 9)
    aryAQL("0.65").Add("Q", 12, 13)
    aryAQL("0.65").Add("R", 18, 19)
    aryAQL("1.0").Add("ABCDEF", 0, 1)
    aryAQL("1.0").Add("GHJ", 1, 2)
    aryAQL("1.0").Add("K", 2, 3)
    aryAQL("1.0").Add("L", 3, 4)
    aryAQL("1.0").Add("M", 5, 6)
    aryAQL("1.0").Add("N", 8, 9)
    aryAQL("1.0").Add("P", 12, 13)
    aryAQL("1.0").Add("QR", 18, 19)
    aryAQL("1.5").Add("ABCDE", 0, 1)
    aryAQL("1.5").Add("FGH", 1, 2)
    aryAQL("1.5").Add("J", 2, 3)
    aryAQL("1.5").Add("K", 3, 4)
    aryAQL("1.5").Add("L", 5, 6)
    aryAQL("1.5").Add("M", 8, 9)
    aryAQL("1.5").Add("N", 12, 13)
    aryAQL("1.5").Add("PQR", 18, 19)
    aryAQL("2.5").Add("ABCD", 0, 1)
    aryAQL("2.5").Add("EFG", 1, 2)
    aryAQL("2.5").Add("H", 2, 3)
    aryAQL("2.5").Add("J", 3, 4)
    aryAQL("2.5").Add("K", 5, 6)
    aryAQL("2.5").Add("L", 8, 9)
    aryAQL("2.5").Add("M", 12, 13)
    aryAQL("2.5").Add("NPQR", 18, 19)
    aryAQL("4.0").Add("ABC", 0, 1)
    aryAQL("4.0").Add("DEF", 1, 2)
    aryAQL("4.0").Add("G", 2, 3)
    aryAQL("4.0").Add("H", 3, 4)
    aryAQL("4.0").Add("J", 5, 6)
    aryAQL("4.0").Add("K", 8, 9)
    aryAQL("4.0").Add("L", 12, 13)
    aryAQL("4.0").Add("MNPQR", 18, 19)
    aryAQL("6.5").Add("AB", 0, 1)
    aryAQL("6.5").Add("CDE", 1, 2)
    aryAQL("6.5").Add("F", 2, 3)
    aryAQL("6.5").Add("G", 3, 4)
    aryAQL("6.5").Add("H", 5, 6)
    aryAQL("6.5").Add("J", 8, 9)
    aryAQL("6.5").Add("K", 12, 13)
    aryAQL("6.5").Add("LMNPQR", 18, 19)
  End Sub
End Class
Public Class Reduce
  Inherits NORMAL
  Sub New()
    strCode = "ABCDEFGHJKLMNPQR"
    intMode = -1
    intSmpQty = New Integer() {2, 2, 2, 3, 5, 8, 13, 20, 32, 50, 80, 125, 200, 315, 500, 800}
    aryAQL.Clear()
    aryAQL.Add("0.010", New AQL("0.010"))
    aryAQL.Add("0.015", New AQL("0.015"))
    aryAQL.Add("0.025", New AQL("0.025"))
    aryAQL.Add("0.040", New AQL("0.040"))
    aryAQL.Add("0.065", New AQL("0.065"))
    aryAQL.Add("0.10", New AQL("0.10"))
    aryAQL.Add("0.15", New AQL("0.15"))
    aryAQL.Add("0.25", New AQL("0.25"))
    aryAQL.Add("0.40", New AQL("0.40"))
    aryAQL.Add("0.65", New AQL("0.65"))
    aryAQL.Add("1.0", New AQL("1.0"))
    aryAQL.Add("1.5", New AQL("1.5"))
    aryAQL.Add("2.5", New AQL("2.5"))
    aryAQL.Add("4.0", New AQL("4.0"))
    aryAQL.Add("6.5", New AQL("6.5"))
    aryAQL("0.010").Add(strCode, 0, 1)
    aryAQL("0.015").Add(strCode, 0, 1)
    aryAQL("0.025").Add(strCode, 0, 1)
    aryAQL("0.040").Add("ABCDEFGHJKLMNPQ", 0, 1)
    aryAQL("0.040").Add("R", 1, 2)
    aryAQL("0.065").Add("ABCDEFGHJKLMNP", 0, 1)
    aryAQL("0.065").Add("QR", 1, 2)
    aryAQL("0.10").Add("ABCDEFGHJKLMN", 0, 1)
    aryAQL("0.10").Add("PQ", 1, 2)
    aryAQL("0.10").Add("R", 2, 3)
    aryAQL("0.15").Add("ABCDEFGHJKLM", 0, 1)
    aryAQL("0.15").Add("NP", 1, 2)
    aryAQL("0.15").Add("Q", 2, 3)
    aryAQL("0.15").Add("R", 3, 4)
    aryAQL("0.25").Add("ABCDEFGHJKL", 0, 1)
    aryAQL("0.25").Add("MN", 1, 2)
    aryAQL("0.25").Add("P", 2, 3)
    aryAQL("0.25").Add("Q", 3, 4)
    aryAQL("0.25").Add("R", 5, 6)
    aryAQL("0.40").Add("ABCDEFGHJK", 0, 1)
    aryAQL("0.40").Add("LM", 1, 2)
    aryAQL("0.40").Add("N", 2, 3)
    aryAQL("0.40").Add("P", 3, 4)
    aryAQL("0.40").Add("Q", 5, 6)
    aryAQL("0.40").Add("R", 7, 8)
    aryAQL("0.65").Add("ABCDEFGHJ", 0, 1)
    aryAQL("0.65").Add("KL", 1, 2)
    aryAQL("0.65").Add("M", 2, 3)
    aryAQL("0.65").Add("N", 3, 4)
    aryAQL("0.65").Add("P", 5, 6)
    aryAQL("0.65").Add("Q", 7, 8)
    aryAQL("0.65").Add("R", 10, 11)
    aryAQL("1.0").Add("ABCDEFGH", 0, 1)
    aryAQL("1.0").Add("JK", 1, 2)
    aryAQL("1.0").Add("L", 2, 3)
    aryAQL("1.0").Add("M", 3, 4)
    aryAQL("1.0").Add("N", 5, 6)
    aryAQL("1.0").Add("P", 7, 8)
    aryAQL("1.0").Add("QR", 10, 11)
    aryAQL("1.5").Add("ABCDEFG", 0, 1)
    aryAQL("1.5").Add("HJ", 1, 2)
    aryAQL("1.5").Add("K", 2, 3)
    aryAQL("1.5").Add("L", 3, 4)
    aryAQL("1.5").Add("M", 5, 6)
    aryAQL("1.5").Add("N", 7, 8)
    aryAQL("1.5").Add("PQR", 10, 11)
    aryAQL("2.5").Add("ABCDEF", 0, 1)
    aryAQL("2.5").Add("GH", 1, 2)
    aryAQL("2.5").Add("J", 2, 3)
    aryAQL("2.5").Add("K", 3, 4)
    aryAQL("2.5").Add("L", 5, 6)
    aryAQL("2.5").Add("M", 7, 8)
    aryAQL("2.5").Add("NPQR", 10, 11)
    aryAQL("4.0").Add("ABCDE", 0, 1)
    aryAQL("4.0").Add("FG", 1, 2)
    aryAQL("4.0").Add("H", 2, 3)
    aryAQL("4.0").Add("J", 3, 4)
    aryAQL("4.0").Add("K", 5, 6)
    aryAQL("4.0").Add("L", 7, 8)
    aryAQL("4.0").Add("MNPQR", 10, 11)
    aryAQL("6.5").Add("ABCD", 0, 1)
    aryAQL("6.5").Add("EF", 1, 2)
    aryAQL("6.5").Add("G", 2, 3)
    aryAQL("6.5").Add("H", 3, 4)
    aryAQL("6.5").Add("J", 5, 6)
    aryAQL("6.5").Add("K", 7, 8)
    aryAQL("6.5").Add("LMNPQR", 10, 11)
  End Sub
End Class