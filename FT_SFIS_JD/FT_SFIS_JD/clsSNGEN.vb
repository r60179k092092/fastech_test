Public Class clsSNGEN
  Public Class SNPair
    Public strFrom As String = ""
    Public strTo As String = ""
    Public intBegin As Integer = 0
    Private intCount As Integer = 0
    Private sno As APSQL.SerialID = Nothing
    Public Property Count As Integer
      Get
        Return intCount
      End Get
      Set(value As Integer)
        intCount = value
        If sno Is Nothing Then Return
        strTo = sno.GetID(intBegin + intCount)
      End Set
    End Property
    Public Property SN As APSQL.SerialID
      Get
        Return sno
      End Get
      Set(value As APSQL.SerialID)
        sno = value
      End Set
    End Property
    Public Function GetSNs() As ArrayList
      Dim aryL As New ArrayList
      If sno Is Nothing Then Return aryL
      For intI As Integer = 1 To intCount
        aryL.Add(sno.GetID(intBegin + intI - 1))
      Next
      Return aryL
    End Function
  End Class
  Public strPerfx As String = ""
  Public strSurfx As String = ""
  Public strSNC As String = ""
  Protected intBegin As Integer = 0
  Protected intMaxV As Integer = 0
  Private bolSNC As Boolean = False
  Protected sno As New APSQL.SerialID
  Sub New()
    sno.IDMAP = "0123456789ABCDEFGHJKLMNPQRSTUVWYZ"
  End Sub
  Public Function GetSNC() As String
    If bolSNC Then
      Return intMaxV.ToString(New String("0", strSNC.Length))
    Else
      Return strSNC & "=" & intMaxV.ToString("0")
    End If
  End Function
  Public Sub SetConcat(strP As String, strN As String, strS As String)
    strPerfx = strP
    strSurfx = strS
    Dim strV() As String = strN.Split("=")
    If strV.Length > 1 Then
      intBegin = Val(strV(1))
      strSNC = strV(0)
    Else
      Dim bolM As Boolean = False, bolT As Boolean = False
      For Each c As Char In strV(0).ToCharArray
        If Char.IsDigit(c) Then
          If c <> "9"c Then
            bolT = True
          End If
        Else
          bolM = True
        End If
      Next
      If bolM = False Then
        bolSNC = True
      Else
        bolSNC = False
      End If
      If bolT And bolM = False Then
        strSNC = New String("9", strV(0).Length)
        intBegin = Val(strV(0))
      Else
        strSNC = strV(0)
      End If
    End If
    sno.ClearRule()
    If strSNC = "" Then Return
    sno.ConcatID(strPerfx & "," & strSNC & "," & strSurfx)
  End Sub
  Public Function GetMaxNo() As Integer
    Return intMaxV
  End Function

  Public Function SetBegin(strV As String) As Integer
    If sno.BeginID = "" Then
      intBegin = 0
    Else
      intBegin = sno.Diff(strV)
    End If
    Return intBegin
  End Function
  Public Function GetID(intI As Integer) As String
    Return sno.GetID(intI + intBegin)
  End Function
  Public Function GetDiff(strV As Integer) As Integer
    Return sno.Diff(strV) - intBegin
  End Function
  Public Function GetPair(intC As Integer) As SNPair
    Dim s As New SNPair
    s.strFrom = sno.GetID(intBegin)
    s.strTo = sno.GetID(intBegin + intC - 1)
    s.Count = intC
    s.intBegin = intBegin
    s.SN = sno
    Return s
  End Function
  Public Overridable Function GetMax() As String
    If strSNC = "" Then Return ""
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
    sqlCV.Where("TN01", "Like", strPerfx & New String("_", strSNC.Length) & strSurfx)
    sqlCV.SqlFields("MAX(TN01)", "MAXV")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count = 0 Then
      intMaxV = 1
    Else
      Dim strM As String = rs.Rows(0)!MAXV.ToString.Trim
      If strM = "" Then
        intMaxV = 1
      Else
        intMaxV = sno.Diff(strM) + 1
      End If
    End If
    DB.CloseRs(rs)
    Return sno.GetID(intMaxV)
  End Function
  Public Overridable Function GetRange(strF As String, strV As String) As SNPair
    If strSNC = "" Then Return Nothing
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
    sqlCV.Where("TN01", "Like", strPerfx & New String("_", strSNC.Length) & strSurfx)
    sqlCV.Where(strF, "=", strV)
    sqlCV.SqlFields("MAX(TN01)", "MAXV")
    sqlCV.SqlFields("MIN(TN01)", "MINV")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count = 0 Then
      Return Nothing
    Else
      If rs.Rows(0)!MINV.ToString.Trim = "" Or rs.Rows(0)!MAXV.ToString.Trim = "" Then Return Nothing
      Dim s As New SNPair
      s.strFrom = rs.Rows(0)!MINV.ToString.Trim
      s.strTo = rs.Rows(0)!MAXV.ToString.Trim
      s.intBegin = sno.Diff(s.strFrom)
      s.Count = sno.Diff(s.strFrom, s.strTo)
      s.SN = sno
      Return s
    End If
  End Function
End Class
