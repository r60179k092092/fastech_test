Public Class EachUnit

End Class
Public Class clsProductTable
  Private strBeginDate As String = ""
  Private strEndDate As String = ""
  Sub New(strB As String, strE As String)
    strBeginDate = strB
    strEndDate = strE
  End Sub
  Public Function GetData() As DataTable
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TD")
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TC", "TC01", "=", "^0.TD02")
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "WMSA", "SA01", "=", "^1.TC02")
    sqlCV.Where("^2.SA04", "IN", "1010,1011", intFMode.msfld_field)
    sqlCV.SqlFields("^0.TD01")
    sqlCV.SqlFields("^0.TD02")
    sqlCV.SqlFields("^")
  End Function
End Class
