Public Class clsPRODKB
  Public Class QryText
    Public strBGDate As String = ""
    Public strEDDate As String = ""
    Public strMoid As String = "any"
    Public strLineId As String = "any"
    Public strModel As String = "any"
    Public strPN As String = "any"
    Public intMode As Integer = 0
    Public strGrp As String = ""
  End Class
  Public Class PChartStic
    Public strMODEL As String = ""
    Public strGRP As String = ""
    Public rs As DataTable = Nothing
    Private aryD As New Dictionary(Of String, DataRow)
    Private aryMO As New ArrayList
    Sub New(MDL As String, GRP As String)
      strMODEL = MDL
      strGRP = GRP
      rs = New DataTable
      rs.TableName = "CalcuPChart"
      rs.Columns.Add("DATEV", GetType(String))
      rs.Columns.Add("QTY", GetType(Integer))
      rs.Columns.Add("NGQTY", GetType(Integer))
      rs.Columns.Add("DFRATE", GetType(Double))
    End Sub
    Public Function KEYV() As String
      Return strMODEL & vbTab & strGRP
    End Function
    Public Function MOS() As String
      Dim strMO As String = ""
      For Each strK As String In aryMO
        If strK.Trim = "" Then Continue For
        strMO &= "'" & strK.Trim & "',"
      Next
      Return strMO.Trim(",")
    End Function
    Public Sub Add(r As DataRow)
      If strGRP <> r!TDC05.ToString.Trim Or strMODEL <> r!TBB04.ToString.Trim Then Return
      If aryMO.Contains(r!TDC01.ToString.Trim) = False Then
        aryMO.Add(r!TDC01.ToString.Trim)
      End If
      Dim r1 As DataRow = rs.NewRow
      If aryD.ContainsKey(r!TDC03.ToString.Trim) = False Then
        r1!DATEV = r!TDC03.ToString.Trim
        rs.Rows.Add(r1)
      Else
        r1 = aryD(r!TDC03.ToString.Trim)
      End If
      r1!QTY = Val(r1!QTY.ToString) + Val(r!Q1.ToString)
      r1!NGQTY = Val(r1!NGQTY.ToString) + Val(r!DQ.ToString)
      If Val(r1!QTY.ToString) = 0 Then
        r1!DFRATE = 0
      Else
        r1!DFRATE = Val(r1!NGQTY.ToString) / Val(r1!QTY.ToString)
      End If
    End Sub
  End Class
  Private DB As APSQL.SQLDB = Nothing
  Private aryTJ As New Dictionary(Of String, String)
  Private aryTK As New Dictionary(Of String, String)
  Private aryPCht As New Dictionary(Of String, PChartStic)
  Sub New(DBS As APSQL.SQLDB)
    DB = DBS
  End Sub
  Private Sub ReList()
    'Dim dt As Date = DTP1.Value
  End Sub
  Private Sub CalTS(strMO As String, sQ As QryText)
    Dim sqlCV As New APSQL.SQLCNV
    aryTK.Clear()
    aryTJ.Clear()
    If strMO.Trim = "" Then Return
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TJ")
    sqlCV.SqlFields("TJ01")
    sqlCV.SqlFields("TJ03")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    For Each r As DataRow In rs.Rows
      If aryTJ.ContainsKey(r!TJ01.ToString.Trim) = False Then
        aryTJ.Add(r!TJ01.ToString.Trim, r!TJ03.ToString.Trim)
      End If
    Next
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_distinc, "SFIS_TM")
    sqlCV.Where("^0.TM06", ">=", sQ.strBGDate, intFMode.msfld_date)
    sqlCV.Where("^0.TM06", "<=", sQ.strEDDate, intFMode.msfld_date)
    Dim w As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TN", "TN01", "=", "^0.TM01")
    w.Add("SFIS_TN.TN02", "IN", "(" & strMO.Trim(",") & ")")
    sqlCV.SqlFields("Convert(Varchar(10),TM06,111)", "DATV", , , True)
    sqlCV.SqlFields("^0.TM03")
    sqlCV.SqlFields("^1.TN02", , , , True)
    sqlCV.SqlFields("^0.TM04")
    rs = DB.RsSQL(sqlCV.Text, "RT")
    For Each r As DataRow In rs.Rows
      Dim strV() As String = r!TM04.ToString.Trim.Split(",")
      If aryTJ.ContainsKey(strV(0)) Then
        r!TM04 = aryTJ(strV(0))
      Else
        r!TM04 = ""
      End If
    Next
    Dim rv As DataView = rs.DefaultView
    rv.Sort = "DATV ASC,TM04 ASC,TN02 ASC"
    Dim strK As String = "", aryE As New ArrayList
    For Each r As DataRowView In rv
      Dim strV1 As String = r!DATV.ToString.Trim & vbTab & r!TM04.ToString.Trim & vbTab & r!TN02.ToString.Trim
      If strK <> strV1 Then
        If strK <> "" Then
          Dim strMx As String = ""
          For Each strK1 As String In aryE
            strMx &= strK1 & ","
          Next
          aryTK.Add(strK, strMx.Trim(","))
          aryE.Clear()
        End If
        strK = strV1
      End If
      Dim strV() As String = r!TM03.ToString.Trim.Split(",")
      For Each strK1 As String In strV
        If strK1.Trim = "" Or aryE.Contains(strK1) Then Continue For
        aryE.Add(strK1)
      Next
    Next
    Dim strM As String = ""
    For Each strK1 As String In aryE
      strM &= strK1 & ","
    Next
    aryTK.Add(strK, strM.Trim(","))
  End Sub

  Public Function CaluProdQty(sQ As QryText) As DataTable '第一張圖
    If sQ.strBGDate = "" Then sQ.strBGDate = Now.ToString("yyyy\/MM\/dd")
    If sQ.strEDDate = "" Then sQ.strEDDate = Now.ToString("yyyy\/MM\/dd")
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TDC")
    sqlCV.Where("^0.TDC03", ">=", sQ.strBGDate)
    sqlCV.Where("^0.TDC03", "<=", sQ.strEDDate)
    If sQ.strLineId <> "any" Then
      sqlCV.Where("^0.TDC02", "=", sQ.strLineId)
    End If
    Dim w As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TD", "TD01", "=", "^0.TDC01")
    If sQ.strMoid <> "any" Then
      w.Add("SFIS_TD.TD01", "=", "'" & sQ.strMoid & "'")
    End If
    If sQ.strPN <> "any" Then
      w.Add("SFIS_TD.TD02", "=", "'" & sQ.strPN & "'")
    End If
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TBB", "TBB03", "=", "^1.TD02")
    If sQ.strModel <> "any" Then
      sqlCV.Where("^2.TBB04", "=", sQ.strModel)
    End If
    w = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TB", "TB01", "=", "^2.TBB01")
    w.Add("SFIS_TB.TB02", "=", "SFIS_TBB.TBB02")
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TJAB", "TJAB01", "=", "'@'+^3.TB01+'-'+^3.TB02")
    sqlCV.SqlFields("^0.TDC02", "線號", , True, True)
    sqlCV.SqlFields("^2.TBB04", "機種名稱", , True, True)
    sqlCV.SqlFields("^1.TD05+'-'+^1.TD06", "訂單編號", , True)
    sqlCV.SqlFields("^1.TD01", "工單單號", , True, True)
    sqlCV.SqlFields("^1.TD02", "產品品號", , True)
    sqlCV.SqlFields("^1.TD07", "工單數量", , True) '5
    sqlCV.SqlFields("(0)", "累計產量")
    sqlCV.SqlFields("(1.000*^4.TJAB03/CASE WHEN ISNULL(^4.TJAB10,1) =0 then 1 else isnull(^4.TJAB10,1) END)", "目標產量", , True)
    sqlCV.SqlFields("(0)", "投入數")   ' 8
    sqlCV.SqlFields("(0)", "產出數")
    sqlCV.SqlFields("SUM(^0.TDC08)", "不良數")
    sqlCV.SqlFields("('')", "[不良率]")
    sqlCV.SqlFields("(0)", "人數")
    sqlCV.SqlFields("^0.TDC03", , , True)
    Dim rs As DataTable = DB.RsSQL(BIG2GB(sqlCV.Text), "RV")
    Dim aryPID As New Dictionary(Of String, DataRow)
    Dim aryMO As New Dictionary(Of String, Integer)
    Dim intI As Integer = 0, strMO As String = ""
    For Each r As DataRow In rs.Rows
      If aryMO.ContainsKey(r.Item(3).ToString.Trim) = False Then
        strMO &= "'" & r.Item(3).ToString.Trim & "',"
        aryMO.Add(r.Item(3).ToString.Trim, 0)
      End If
      aryPID.Add(r.Item(13).ToString.Trim & vbTab & r.Item(0).ToString.Trim & vbTab & r.Item(3).ToString.Trim, r)
    Next
    'CalTS(strMO)
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TDC")
    sqlCV.Where("^0.TDC03", ">=", sQ.strBGDate)
    sqlCV.Where("^0.TDC03", "<=", sQ.strEDDate)
    If sQ.strLineId <> "any" Then
      sqlCV.Where("^0.TDC02", "=", sQ.strLineId)
    End If
    w = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TD", "TD01", "=", "^0.TDC01")
    If sQ.strMoid <> "any" Then
      w.Add("SFIS_TD.TD01", "=", "'" & sQ.strMoid & "'")
    End If
    If sQ.strPN <> "any" Then
      w.Add("SFIS_TD.TD02", "=", "'" & sQ.strPN & "'")
    End If
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TBB", "TBB03", "=", "^1.TD02")
    If sQ.strModel <> "any" Then
      sqlCV.Where("^2.TBB04", "=", sQ.strModel)
    End If
    w = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TDA", "TDA01", "=", "^0.TDC01")
    w.Add("SFIS_TDA.TDA03", "=", "SFIS_TDC.TDC05")
    sqlCV.SqlFields("^0.USEQ")
    sqlCV.SqlFields("^0.TDC03", , , , True)
    sqlCV.SqlFields("^0.TDC02", , , , True)
    sqlCV.SqlFields("^0.TDC01", , , , True)
    sqlCV.SqlFields("^3.TDA02", , , , True)
    sqlCV.SqlFields("^0.TDC06", "T6")
    sqlCV.SqlFields("^0.TDC07", "T7")
    sqlCV.SqlFields("^0.TDC08", "T8")
    sqlCV.SqlFields("^0.TDC09", "T9")
    sqlCV.SqlFields("^0.TDC10", "T10")
    sqlCV.SqlFields("^0.TDC11", "T11")
    sqlCV.SqlFields("^0.TDC12", "T12")
    sqlCV.SqlFields("^0.TDC13")
    sqlCV.SqlFields("^0.TDC14")
    sqlCV.SqlFields("^0.TDC15")
    Dim rs1 As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    Dim strKV As String = "", intT As Integer = 0
    Dim aryLists As New ArrayList, strK14 As String = "", strK15 As String = ""
    Dim intT2 As Integer = 0
    Dim intT7B As Integer = 0, intT7E As Integer = 0, intT7R As Integer = 0, intT7L As Integer = 0
    For Each r As DataRow In rs1.Rows
      If r!TDC13.ToString.Trim = "" Then
        CalTS(strMO, sQ)
        Exit For
      End If
    Next
    For Each r As DataRow In rs1.Rows
      Dim strK As String = r!TDC03.ToString.Trim & vbTab & r!TDC02.ToString.Trim & vbTab & r!TDC01.ToString.Trim
      If strKV <> strK Then
        If strKV <> "" Then
          If aryPID.ContainsKey(strKV) = True Then
            With aryPID(strKV)
              .Item(8) = intT7B
              .Item(9) = intT7E
              .Item(7) = (Val(.Item(7)) * intT / 3600.0 * aryLists.Count).ToString("0")
              .Item(12) = aryLists.Count
              If Val(.Item(9).ToString.Trim) > 0 Then
                .Item(11) = (Val(.Item(10).ToString) / Val(.Item(9).ToString) * 100).ToString("0.00") & "%"
              End If
            End With
          End If
        End If
        aryLists.Clear()
        If aryTK.ContainsKey(strK) Then
          Dim strVEM() As String = aryTK(strK).Split(",")
          aryLists.AddRange(strVEM)
        End If
        strKV = strK
        strK14 = ""
        strK15 = ""
        intT = 0
        intT7E = 0
        intT7B = 0
        intT7R = Val(r!TDA02.ToString.Trim)
        intT7L = intT7R
        intT2 = 0
      End If
      intT += (Val(r!T11.ToString) * Val(r!T10.ToString))
      If Val(r!TDA02.ToString) = intT7R Then
        intT7B += Val(r!T7.ToString)
        intT7E = intT7B
        intT2 = Val(r!T11.ToString)
      ElseIf intT7L <> Val(r!TDA02.ToString) Then
        intT7L = Val(r!TDA02.ToString)
        intT2 = Val(r!T11.ToString)
        intT7E = Val(r!T7.ToString.Trim)
      Else
        intT2 += Val(r!T11.ToString)
        intT7E += Val(r!T7.ToString.Trim)
      End If
      If sQ.intMode = 1 Then
        intT = intT2 * aryLists.Count
      End If
      If r!TDC13.ToString.Trim <> "" Then
        Dim strVEM() As String = r!TDC13.ToString.Trim.Split(",")
        For Each strVES As String In strVEM
          If strVES.Trim = "" Or aryLists.Contains(strVES) = True Then Continue For
          aryLists.Add(strVES)
        Next
      End If
    Next
    If strKV <> "" Then
      If aryPID.ContainsKey(strKV) = True Then
        With aryPID(strKV)
          .Item(8) = intT7B
          .Item(9) = intT7E
          .Item(7) = (Val(.Item(7)) * intT / 3600.0 * aryLists.Count).ToString("0")
          .Item(12) = aryLists.Count
          If Val(.Item(9).ToString.Trim) > 0 Then
            .Item(11) = (Val(.Item(10).ToString) / Val(.Item(9).ToString) * 100).ToString("0.00") & "%"
          End If
        End With
      End If
    End If
    If strMO <> "" Then
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
      sqlCV.Where("TN06", "IN", "(4,5,7)", intFMode.msfld_field)
      sqlCV.Where("TN02", "IN", strMO.Trim(","), intFMode.msfld_field)
      sqlCV.SqlFields("TN02", , , True, True)
      sqlCV.SqlFields("COUNT(*)", "Q")
      rs1 = DB.RsSQL(sqlCV.Text, "RT")
      For Each r As DataRow In rs1.Rows
        If aryMO.ContainsKey(r!TN02.ToString.Trim) = True Then
          aryMO(r!TN02.ToString.Trim) = Val(r!Q.ToString)
        End If
      Next
      For Each r As DataRow In rs.Rows
        If aryMO.ContainsKey(r.Item(3).ToString.Trim) = True Then
          r.Item(6) = aryMO(r.Item(3).ToString.Trim)
        End If
      Next
    End If
    Return rs
  End Function
  Public Function CaluGrpQTY(r As DataRow, sQ As QryText) As DataTable '第二張圖
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TDC")
    sqlCV.Where("^0.TDC03", ">=", sQ.strBGDate)
    sqlCV.Where("^0.TDC03", "<=", sQ.strEDDate)
    sqlCV.Where("^0.TDC02", "=", r.Item(0).ToString.Trim)
    sqlCV.Where("^0.TDC01", "=", r.Item(3).ToString.Trim)
    'MsgBox(r.Item(3).ToString)
    'MsgBox(sqlCV.Text)
    Dim w As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TDA", "TDA01", "=", "^0.TDC01")
    w.Add("SFIS_TDA.TDA03", "=", "SFIS_TDC.TDC05")
    sqlCV.SqlJoin("SFIS_TA", "TA01", "=", "^0.TDC05")
    sqlCV.SqlFields("^1.TDA02", , , True, True)
    sqlCV.SqlFields("^0.TDC05", , , True)
    sqlCV.SqlFields("^2.TA02", , , True)
    sqlCV.SqlFields("SUM(^0.TDC06)", "PDQTY")
    sqlCV.SqlFields("SUM(^0.TDC08)", "TDQTY")
    sqlCV.SqlFields("(0.0)", "DFRATE")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "R1")
    For Each r1 As DataRow In rs.Rows
      If Val(r1!PDQTY.ToString) = 0 Then
        r1!DERATE = 0.0
      Else
        r1!DERATE = Val((Val(r1!TDQTY.ToString) / Val(r1!PDQTY.ToString) * 100).ToString("0.00"))
      End If
    Next
    Return rs
  End Function
  Public Sub CalcuPChart(sQ As QryText)
    If sQ.strBGDate = "" Then sQ.strBGDate = Now.ToString("yyyy\/MM\/dd")
    If sQ.strEDDate = "" Then sQ.strEDDate = Now.ToString("yyyy\/MM\/dd")
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TDC")
    sqlCV.Where("^0.TDC03", ">=", sQ.strBGDate)
    sqlCV.Where("^0.TDC03", "<=", sQ.strEDDate)
    If sQ.strLineId <> "any" Then
      sqlCV.Where("^0.TDC02", "=", sQ.strLineId)
    End If
    Dim w As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TD", "TD01", "=", "^0.TDC01")
    If sQ.strMoid <> "any" Then
      w.Add("SFIS_TD.TD01", "=", "'" & sQ.strMoid & "'")
    End If
    If sQ.strPN <> "any" Then
      w.Add("SFIS_TD.TD02", "=", "'" & sQ.strPN & "'")
    End If
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TBB", "TBB03", "=", "^1.TD02")
    If sQ.strModel <> "any" Then
      sqlCV.Where("^2.TBB04", "=", sQ.strModel)
    End If
    If sQ.strGrp <> "" Then
      sqlCV.Where("^0.TDC05", "=", sQ.strGrp)
    End If
    w = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TDA", "TDA01", "=", "^1.TD01")
    w.Add("SFIS_TDA.TDA03", "=", "SFIS_TDC.TDC05")
    sqlCV.SqlFields("^2.TBB04", , , True, True)
    sqlCV.SqlFields("^3.TDA02", , , True, True)
    sqlCV.SqlFields("^0.TDC05", , , True)
    sqlCV.SqlFields("^0.TDC03", , , True, True)
    'sqlCV.SqlFields("^1.TD02", "產品品號", , True)
    'sqlCV.SqlFields("^0.TD07", "工單數量", , True) '5
    'sqlCV.SqlFields("(0)", "累計產量")
    'sqlCV.SqlFields("(1.000*^4.TJAB03/CASE WHEN ISNULL(^4.TJAB10,1) =0 then 1 else isnull(^4.TJAB10,1) END)", "目標產量", , True)
    'sqlCV.SqlFields("(0)", "投入數")   ' 8
    'sqlCV.SqlFields("(0)", "產出數")
    sqlCV.SqlFields("SUM(^0.TDC06)", "Q1")
    sqlCV.SqlFields("SUM(^0.TDC09)", "DQ")
    sqlCV.SqlFields("^0.TDC01", , , True)
    Dim rs As DataTable = DB.RsSQL(BIG2GB(sqlCV.Text), "RT")
    aryPCht.Clear()
    For Each r As DataRow In rs.Rows
      Dim strK As String = r!TBB04.ToString.Trim & vbTab & r!TDC05.ToString.Trim
      Dim s As PChartStic = Nothing
      If aryPCht.ContainsKey(strK) = False Then
        s = New PChartStic(r!TBB04.ToString.Trim, r!TDC05.ToString.Trim)
        aryPCht.Add(s.KEYV, s)
      Else
        s = aryPCht(strK)
      End If
      s.Add(r)
    Next
  End Sub
  Public Function GetPChart() As PChartStic()
    If aryPCht.Count = 0 Then Return Nothing
    Dim s(aryPCht.Count - 1) As PChartStic
    aryPCht.Values.CopyTo(s, 0)
    Return s
  End Function
  Public Function GetNGCodes(s As PChartStic, sQ As QryText) As DataTable
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TM")
    sqlCV.Where("TM02", "=", s.strGRP)
    sqlCV.Where("TM08", "IN", "1,2", intFMode.msfld_field)
    sqlCV.Where("TM06", ">=", sQ.strBGDate, intFMode.msfld_datetime)
    sqlCV.Where("TM06", "<=", sQ.strEDDate, intFMode.msfld_datetime)
    Dim w As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TN", "TN01", "=", "^0.TM01")
    w.Add("SFIS_TN.TN02", "IN", "'" & s.MOS & "'")
    sqlCV.SqlFields("TM09")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    Dim aryDQ As New Dictionary(Of String, Integer)
    For Each r As DataRow In rs.Rows
      Dim strV() As String = r!TM09.ToString.Trim.Split(vbTab)
      For Each strK As String In strV
        If strK.Trim = "" Then Continue For
        Dim strC As String = strK.Trim.Split("^")(0)
        If aryDQ.ContainsKey(strC) = False Then
          aryDQ.Add(strC, 1)
        Else
          aryDQ(strC) += 1
        End If
      Next
    Next
    rs = New DataTable
    rs.TableName = "DQV"
    rs.Columns.Add("A1", GetType(String))
    rs.Columns.Add("A2", GetType(Double))
    For Each strk In aryDQ.Keys
      rs.Rows.Add(strk, aryDQ(strk))
    Next
    Return rs
  End Function
End Class
