Public Class clsSNDTL
  Public strPPID As String = ""
  Public intSMode As Integer = 0
  Public strJS As String = ","
  Private aryMSN As New Dictionary(Of String, ArrayList)
  Sub New(strID As String, strN() As String)
    strPPID = strID
    For Each strK As String In strN
      aryMSN.Add(strK, New ArrayList)
    Next
  End Sub
  Public Sub Add(strN As String, strK As String)
    If aryMSN.ContainsKey(strN) = False Then
      aryMSN.Add(strN, New ArrayList)
    End If
    aryMSN(strN).Add(strK)
  End Sub
  Public Function GetKeys() As String()
    Dim strM() As String = aryMSN.Keys.ToArray
    Return strM
  End Function
  Public Sub ToDataTable(rs As DataTable)
    For Each strK As String In aryMSN.Keys
      If rs.Columns.Contains(strK) = False Then
        rs.Columns.Add(strK, GetType(String))
      End If
    Next
    Dim r As DataRow = rs.NewRow
    r("PPID") = strPPID
    For Each strK As String In aryMSN.Keys
      Dim strV() As String = aryMSN(strK).ToArray(GetType(String))
      Dim strM As String = ""
      For Each strK1 As String In strV
        If strK1.Trim = "" Then Continue For
        strM &= strK1.Trim & strJS
      Next
      r(strK) = strM.Trim(strJS.ToCharArray)
    Next
    rs.Rows.Add(r)
  End Sub
End Class
Public Class clsSNDTLS
  Public strMO As String = ""
  Public intSMode As Integer = 1
  Private aryPPID As New Dictionary(Of String, clsSNDTL)
  Sub New(strM As String)
    strMO = strM
  End Sub
  Public Function MakeTable() As DataTable
    Dim rs As New DataTable
    rs.TableName = strMO
    rs.Columns.Add("PPID", GetType(String))
    For Each s As clsSNDTL In aryPPID.Values
      s.ToDataTable(rs)
    Next
    Return rs
  End Function
  Public Sub CalMo()
    Clear()
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
    sqlCV.Where("TN02", "=", strMO)
    sqlCV.Where("TN06", "IN", "0,1,2,4,5,7", intFMode.msfld_field)
    sqlCV.SqlFields("TN01")
    Dim strQ As String = sqlCV.Text
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TS")
    sqlCV.Where("TS01", "IN", strQ, intFMode.msfld_field)
    sqlCV.SqlFields("TS01")
    sqlCV.SqlFields("TS02")
    sqlCV.SqlFields("TS03")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    Dim aryL As New ArrayList
    For Each r As DataRow In rs.Rows
      If aryL.Contains(r!TS03.ToString.Trim) = False Then
        aryL.Add(r!TS03.ToString.Trim)
      End If
    Next
    aryL.Sort()
    Dim strN() As String = aryL.ToArray(GetType(String))
    For Each r As DataRow In rs.Rows
      Dim strK As String = r!TS01.ToString.Trim
      If aryPPID.ContainsKey(strK) = False Then
        aryPPID.Add(strK, New clsSNDTL(strK, strN))
      End If
      aryPPID(strK).Add(r!TS03.ToString.Trim, r!TS02.ToString.Trim)
    Next
    If intSMode = 0 Then Return
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
    sqlCV.Where("TN06", "=", 7, intFMode.msfld_num)
    sqlCV.Where("TN07", "IN", strQ, intFMode.msfld_field)
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TD", "TD01", "=", "^0.TN02")
    sqlCV.SqlFields("TN01")
    sqlCV.SqlFields("TN07")
    sqlCV.SqlFields("^1.TD02")
    rs = DB.RsSQL(sqlCV.Text, "RT")
    For Each r As DataRow In rs.Rows
      Dim strK As String = r!TN07.ToString.Trim
      If aryPPID.ContainsKey(strK) = False Then
        aryPPID.Add(strK, New clsSNDTL(strK, r!TD02.ToString.Trim.Split(vbCr)))
      End If
      aryPPID(strK).Add(r!TD02.ToString.Trim, r!TN01.ToString.Trim)
    Next
    If intSMode = 1 Then Return
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TE")
    sqlCV.Where("TE14", "IN", strQ, intFMode.msfld_field)
    sqlCV.SqlFields("TE14")
    sqlCV.SqlFields("TE02")
    sqlCV.SqlFields("TE03")
    sqlCV.SqlFields("TE01")
    rs = DB.RsSQL(sqlCV.Text, "RT")
    For Each r As DataRow In rs.Rows
      Dim strK As String = r!TE14.ToString.Trim
      If aryPPID.ContainsKey(strK) = False Then
        aryPPID.Add(strK, New clsSNDTL(strK, r!TE01.ToString.Trim.Split(vbCr)))
      End If
      Dim strMM() As String = (r!TE02.ToString.Trim & "$").Split("$")
      aryPPID(strK).Add(r!TE01.ToString.Trim, strMM(1).Trim & "_" & r!TE03.ToString.Trim)
    Next
  End Sub
  Private Sub Clear()
    aryPPID.Clear()
  End Sub
End Class
