Public Class Execlclass
    Public Shared ap As DataTable = Nothing
    Public Shared path As String = ""

    Public Shared Sub datatable()
        ap = New DataTable
        ap.Columns.Add("出廠")
        ap.Columns.Add("單據別")
        ap.Columns.Add("品名")
        ap.Columns.Add("客戶")
        ap.Columns.Add("貨運公司")
        ap.Columns.Add("車號")
        ap.Columns.Add("司機")
        ap.Columns.Add("淨重")
        ap.Columns.Add("總重")
        ap.Columns.Add("入廠")
    End Sub

    Public Shared Sub daochu(ByVal strY As String)
        path = "D:\过磅资料" + Date.Now.ToString("yyyyMMdd")
        If Dir(path, vbDirectory) = "" Then
            MkDir(path)
        End If
        Dim sqlCV As New APSQL.SQLCNV
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "CME_TICKET")
        sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "carddata", "cardno", "=", "^0.cardno")
        sqlCV.SqlFields("^0.sp_o_date+ ' ' +^0.sp_o_time", "出廠")
        sqlCV.SqlFields("'出庫'", "單據別")
        sqlCV.SqlFields("itemno", "品名")
        sqlCV.SqlFields("'奇美實業'", "客戶")
        sqlCV.SqlFields("^0.vendname", "貨運公司")
        sqlCV.SqlFields("^0.id_no", "車號")
        sqlCV.SqlFields("^1.dname", "司機")
        sqlCV.SqlFields("^0.net_wgt", "淨重")
        sqlCV.SqlFields("^0.gro_wgt", "總重")
        sqlCV.SqlFields("^0.sp_i_date+ ' ' +^0.sp_i_time", "入廠")
        sqlCV.Where("^0.sp_i_date", "=", "2022/01/11")
        sqlCV.Where("^0.sp_o_date", "=", "2022/01/11")
        'sqlCV.Where("^0.sp_i_date", "=", Date.Now.ToString("yyyy/MM/dd"))
        'sqlCV.Where("^0.sp_o_date", "=", Date.Now.ToString("yyyy/MM/dd"))
        sqlCV.Where("^0.cl_mark", "=", "1")
        sqlCV.Where("len(^0.qrcode)-len(replace(^0.qrcode,'|',''))", "=", "11")
        Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        setExcelFile(dt, "仁德過磅資料", "0")

        sqlCV.SqlFields("^0.QRcode")
        Dim dt1 As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        datatable()
        For intA As Integer = 0 To dt1.Rows.Count - 1
            Dim str() As String = dt1.Rows(intA)("QRcode").Split("|")
            ap.Rows.Add(str(9), "入庫", str(4), "奇美實業", dt1.Rows(intA)("貨運公司").ToString(), str(3), dt1.Rows(intA)("司機").ToString(), str(7), str(5), str(8))
        Next
        setExcelFile(ap, "安平過磅資料", "0")

        Dim strX() As String = strY.Split(",")
        If strX Is Nothing Then
            Return
        End If
        If strX.Length = 0 Then
            Return
        End If
        daochus(strX)
    End Sub

    Public Shared Function daochus(ByVal strY() As String)
        For intA As Integer = 0 To strY.Length - 1
            Dim sqlCV As New APSQL.SQLCNV
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "CME_TICKET")
            sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "carddata", "cardno", "=", "^0.cardno")
            sqlCV.SqlFields("^0.sp_o_date+ ' ' +^0.sp_o_time", "出廠")
            sqlCV.SqlFields("'出庫'", "單據別")
            sqlCV.SqlFields("itemno", "品名")
            sqlCV.SqlFields("'奇美實業'", "客戶")
            sqlCV.SqlFields("^0.vendname", "貨運公司")
            sqlCV.SqlFields("^0.id_no", "車號")
            sqlCV.SqlFields("^1.dname", "司機")
            sqlCV.SqlFields("^0.net_wgt", "淨重")
            sqlCV.SqlFields("^0.gro_wgt", "總重")
            sqlCV.SqlFields("^0.sp_i_date+ ' ' +^0.sp_i_time", "入廠")
            sqlCV.Where("^0.sp_i_date", "=", "2022/01/11")
            sqlCV.Where("^0.sp_o_date", "=", "2022/01/11")
            'sqlCV.Where("^0.sp_i_date", "=", Date.Now.ToString("yyyy/MM/dd"))
            'sqlCV.Where("^0.sp_o_date", "=", Date.Now.ToString("yyyy/MM/dd"))
            sqlCV.Where("^0.cl_mark", "=", "1")
            sqlCV.Where("len(^0.qrcode)-len(replace(^0.qrcode,'|',''))", "=", "11")
            sqlCV.Where("^0.vendname", "=", strY(intA))

            Dim a As String = sqlCV.Text
            Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "RT")
            setExcelFile(dt, strY(intA) + "過磅資料", "1")

            sqlCV.SqlFields("^0.QRcode")
            Dim dt1 As DataTable = DB.RsSQL(sqlCV.Text, "RT")
            datatable()
            For intB As Integer = 0 To dt1.Rows.Count - 1
                Dim str() As String = dt1.Rows(intB)("QRcode").Split("|")
                ap.Rows.Add(str(9), "入庫", str(4), "奇美實業", dt1.Rows(intB)("貨運公司").ToString(), str(3), dt1.Rows(intB)("司機").ToString(), str(7), str(5), str(8))
            Next
            setExcelFile(ap, strY(intA) + "安平過磅資料", "1")
        Next
    End Function

    Public Shared Sub setExcelFile(ByVal dt As DataTable, ByVal str As String, ByVal stry As String)
        If dt.Rows.Count <> 0 Then
            Dim xls As XLS_FILE = New XLS_FILE
            xls.Rs2XLS(dt, str, Now.ToString("yyyy/MM/dd"), "", "1111101001")
            xls.Close(path + "\" + str + Date.Now.ToString("yyyyMMdd"))
            xls.Quit()
            If (stry = "1") Then
                ClsX0401.execltopdf.ExcelToPdf(path + "\" + str + Date.Now.ToString("yyyyMMdd"), path + "\" + str + Date.Now.ToString("yyyyMMdd"))
            End If
        End If
    End Sub
End Class
