Public Class EsClass
    Public Shared Function PaperHeader(strV As String, strX As String, strY As String) As String '生产效率标准
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QTN")
        sqlCV.Where("QTN01", "=", "@EFRATE")
        sqlCV.Where("QTN02", "=", strV)
        sqlCV.SqlFields("QTN04")
        Dim str As String = ""
        Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "RTH")
        If dt.Rows.Count = 0 Then
            Return ""
        End If
        Dim js As New JSON(dt.Rows(0)!QTN04.ToString.Trim)
        Dim strA As String = js.ItemNull("EFRATEHeader")
        Dim strB() As String = strA.Split(",")
        Dim intA As Integer = 0
        For Each strC As String In strB
            If strC = "模數" Then
                intA += 1
                Continue For
            End If
            If intA > 1 Then
                If intA = strB.Length - 1 Then
                    If Val(strX) >= Val(strC) Then
                        Exit For
                    Else
                        intA += 1
                        Continue For
                    End If
                Else
                    If Val(strB(intA - 1)) < Val(strX) And Val(strX) <= Val(strC) Then
                        Exit For
                    Else
                        intA += 1
                        Continue For
                    End If
                End If
            Else
                If Val(strX) <= Val(strC) Then
                    Exit For
                Else
                    intA += 1
                    Continue For
                End If
            End If
        Next

        Dim strM As String = js.ItemNull("EFRATEROW")
        Dim strR() As String = strM.Split(vbCr)
        Dim intB As Integer = 0
        For Each strK As String In strR
            Dim strF() As String = strK.Split(vbTab)
            If Val(strY) < Val(strF(0)) Then
                str = strF(intA)
                Exit For
            Else
                Continue For
            End If
        Next
        Return str.ToString()
    End Function
    Public Shared Function AUNEHeader(strV As String, strX As String, strY As String) As String '调机效率标准
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QTN")
        sqlCV.Where("QTN01", "=", "@EFTUNE")
        sqlCV.Where("QTN02", "=", strV)
        sqlCV.SqlFields("QTN04")
        Dim str As String = ""
        Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "RTH")
        If dt.Rows.Count = 0 Then
            Return ""
        End If
        Dim js As New JSON(dt.Rows(0)!QTN04.ToString.Trim)
        Dim strA As String = js.ItemNull("EFTUNEHeader")
        Dim strB() As String = strA.Split(",")
        Dim intA As Integer = 0
        For Each strC As String In strB
            If strC = "模數" Then
                intA += 1
                Continue For
            End If
            If intA > 1 Then
                If intA = strB.Length - 1 Then
                    If Val(strX) >= Val(strC) Then
                        Exit For
                    Else
                        intA += 1
                        Continue For
                    End If
                Else
                    If Val(strB(intA - 1)) < Val(strX) And Val(strX) <= Val(strC) Then
                        Exit For
                    Else
                        intA += 1
                        Continue For
                    End If
                End If
            Else
                If Val(strX) <= Val(strC) Then
                    Exit For
                Else
                    intA += 1
                    Continue For
                End If
            End If
        Next

        Dim strM As String = js.ItemNull("EFTUNEROW")
        Dim strR() As String = strM.Split(vbCr)
        Dim intB As Integer = 0
        For Each strK As String In strR
            Dim strF() As String = strK.Split(vbTab)
            If Val(strY) < Val(strF(0)) Then
                str = strF(intA)
                Exit For
            Else
                Continue For
            End If
        Next
        Return str.ToString()
    End Function

    Public Shared Function HPaperHeader(strV As String, strX As String) As String
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QTN")
        sqlCV.Where("QTN01", "=", "@EFRATEH")
        sqlCV.Where("QTN02", "=", strV)
        sqlCV.SqlFields("QTN04")
        Dim str As String = ""
        Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "RTH")
        If dt.Rows.Count = 0 Then
            Return ""
        End If
        Dim js As New JSON(dt.Rows(0)!QTN04.ToString.Trim)
        Dim strA As String = js.ItemNull("HeatHeader")
        Dim strB() As String = strA.Split(",")
        Dim intA As Integer = 0
        For Each strC As String In strB
            If intA > 0 Then
                If Val(strB(intA - 1)) < Val(strX) And Val(strX) <= Val(strC) Then
                    Exit For
                Else
                    intA += 1
                    Continue For
                End If
            Else
                If Val(strX) <= Val(strC) Then
                    Exit For
                Else
                    intA += 1
                    Continue For
                End If
            End If
        Next

        Dim strM As String = js.ItemNull("EFRATEHROW")
        Dim strR() As String = strM.Split(vbCr)
        For Each strK As String In strR
            Dim strF() As String = strK.Split(vbTab)
            str = strF(intA)
            Exit For
        Next
        Return str.ToString()
    End Function

    Public Shared Function PRINTING(strV As String, strX As String, strY As String)
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QTN")
        sqlCV.Where("QTN01", "=", "@PRINTING")
        sqlCV.Where("QTN02", "=", strV)
        sqlCV.SqlFields("QTN04")
        Dim str As String = ""
        Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "RTH")
        If dt.Rows.Count = 0 Then
            Return ""
        End If
        Dim js As New JSON(dt.Rows(0)!QTN04.ToString.Trim)
        Dim strA As String = js.ItemNull("PRINTINGHeader")
        Dim strB() As String = strA.Split(",")
        Dim intA As Integer = 0
        Select Case strX
            Case "跳距"
                intA = 0
            Case "印刷"
                intA = 1
            Case "二度"
                intA = 2
            Case "打底色"
                intA = 3
        End Select

        Dim strM As String = js.ItemNull("EFRATEROW")
        Dim strR() As String = strM.Split(vbCr)
        Dim intB As Integer = 0
        For Each strK As String In strR
            Dim strF() As String = strK.Split(vbTab)
            If Val(strY) <= Val(strF(0)) Then
                str = strF(intA)
                Exit For
            Else
                Continue For
            End If
        Next
        Return str.ToString()
    End Function

    Public Shared Function AMTIME(strV As String, strX As String, strY As String)
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QTN")
        sqlCV.Where("QTN01", "=", "@AMTIME")
        sqlCV.Where("QTN02", "=", strV)
        sqlCV.SqlFields("QTN04")
        Dim str As String = ""
        Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "RTH")
        If dt.Rows.Count = 0 Then
            Return ""
        End If
        Dim js As New JSON(dt.Rows(0)!QTN04.ToString.Trim)
        Dim strA As String = js.ItemNull("AMTIMEHeader")
        Dim strB() As String = strA.Split(",")
        Dim intA As Integer = 0
        Select Case strX
            Case "颜色"
                intA = 0
            Case "普通墨"
                intA = 1
            Case "UV墨"
                intA = 2
            Case "压色"
                intA = 3
        End Select

        Dim strM As String = js.ItemNull("EFRATEHROW")
        Dim strR() As String = strM.Split(vbCr)
        Dim intB As Integer = 0
        For Each strK As String In strR
            Dim strF() As String = strK.Split(vbTab)
            If strY = strF(0) Then
                str = strF(intA)
                Exit For
            Else
                Continue For
            End If
        Next
        Return str.ToString()
    End Function
End Class
