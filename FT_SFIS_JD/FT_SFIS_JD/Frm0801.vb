Public Class Frm0801
    Dim xls As XLS_FILE = New XLS_FILE
    Dim dt1 As DataTable = Nothing

    Private Sub Frm0801_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        TuiCK(Me)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DTP1.Value = Now
        DTP2.Value = Now
        DG.DataSource = Nothing
    End Sub

    Private Sub Frm0801_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1_Click(Nothing, Nothing)
        datatable()
    End Sub

    Private Sub datatable()
        dt1 = New DataTable
        dt1.Columns.Add("项次")
        dt1.Columns.Add("订单类型")
        dt1.Columns.Add("日期")
        dt1.Columns.Add("姓名/机台号")
        dt1.Columns.Add("总时间(小时)")
        dt1.Columns.Add("加班时间(小时)")
        dt1.Columns.Add("工单号")
        dt1.Columns.Add("客户")
        dt1.Columns.Add("贴纸代号")
        dt1.Columns.Add("总订单数")
        dt1.Columns.Add("标准产能（车）")
        dt1.Columns.Add("实际产能（车/分）")
        dt1.Columns.Add("达成率")
        dt1.Columns.Add("当月订单总笔数")
        dt1.Columns.Add("未完成原因")
        dt1.Columns.Add("是否上系统")
        dt1.Columns.Add("备注")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim a As String = EsClass.HPaperHeader("0001", "75")
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "TCA_PF")
        sqlCV.Where("PF03", ">=", DTP1.Value.ToString("yyyy-MM-dd"))
        sqlCV.Where("PF03", "<=", DTP2.Value.ToString("yyyy-MM-dd"))
        sqlCV.Where("PF05", "<>", "0006")
        sqlCV.Where("PF05", "<>", "0007")
        sqlCV.Where("PF05", "<>", "0008")
        sqlCV.Where("PF05", "<>", "0009")
        sqlCV.Where("PF05", "<>", "0010")
        sqlCV.Where("PF05", "<>", "0011")
        sqlCV.SqlFields("PF02") '工单号
        sqlCV.SqlFields("PF03") '日期
        sqlCV.SqlFields("PF08") '员工编号
        sqlCV.SqlFields("PF05") '机台号
        sqlCV.SqlFields("SUM(PF10)", "Zgs") '总工时
        sqlCV.SqlFields("cast(cast(sum(case when PF04>='18' and PF04<='8' then PF10 else 0 end) as decimal(10,3))/60 as decimal(10,3))", "Jbsj") '加班时间
        sqlCV.SqlFields("sum(PF06)", "Zsl") '生产数量/PCS
        sqlCV.sqlGroup("PF02")
        sqlCV.sqlGroup("PF03")
        sqlCV.sqlGroup("PF08")
        sqlCV.sqlGroup("PF05")
        sqlCV.sqlOrder("PF03", SQLCNV.intOrder.Order_Asc)
        Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "RT")

        For i As Integer = 0 To dt.Rows.Count - 1
            sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_distinc, "SFIS_TD")
            sqlCV.SqlJoin(APSQL.SQLCNV.intJoinMode.msJoin_Right, "SFIS_TC", "TC01", "=", "^0.TD02")
            sqlCV.SqlJoin(APSQL.SQLCNV.intJoinMode.msJoin_Right, "SFIS_TA", "TA01", "=", "^1.TC03")
            sqlCV.SqlJoin(APSQL.SQLCNV.intJoinMode.msJoin_Right, "WMSA", "SA01", "=", "^1.TC02")
            'sqlCV.SqlJoin(APSQL.SQLCNV.intJoinMode.msJoin_Right, "SFIS_TJAB", "TJAB02", "=", "^0.TD02")
            sqlCV.Where("^0.TD01", "=", dt.Rows(i)("PF02").ToString())
            sqlCV.SqlFields("^2.TA02") '订单类型
            sqlCV.SqlFields("^0.TD28") '客户
            sqlCV.SqlFields("^0.TD02") '贴纸代号
            sqlCV.SqlFields("^0.TD07") '总订单数
            sqlCV.SqlFields("^3.SA14") '贴纸规格
            'sqlCV.SqlFields("^4.TJAB03") '标准产能
            sqlCV.sqlOrder("^3.SA14", SQLCNV.intOrder.Order_Dsc)
            Dim dt2 As DataTable = DB.RsSQL(sqlCV.Text, "RT")

            Dim userID As String = dt.Rows(i)("PF08").ToString()
            Dim user() As String = userID.Split(",")
            Dim name As String = ""
            For index As Integer = 0 To user.Length - 1
                If (user(index) = "") Then
                    Continue For
                End If
                sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_USER")
                sqlCV.Where("usercode", "=", user(index).ToString())
                sqlCV.SqlFields("username")
                Dim dt3 As DataTable = DB.RsSQL(sqlCV.Text(), "RT")
                name += dt3.Rows(0)("username").ToString() + ","
            Next

            Dim str As clsDieSpec = New clsDieSpec()
            str.DieDecode(dt2.Rows(0)("SA14").ToString())
            'If dt2.Rows(0)("TJAB03").ToString() = "" Then
            dt1.Rows.Add(i + 1, dt2.Rows(0)("TA02").ToString(), dt.Rows(i)("PF03").ToString(), name + "/" + dt.Rows(i)("PF05").ToString(), Convert.ToDouble(dt.Rows(i)("Zgs").ToString() / 60).ToString("0.000"), dt.Rows(i)("Jbsj").ToString(), dt.Rows(i)("PF02").ToString(), dt2.Rows(0)("TD28").ToString(), dt2.Rows(0)("TD02").ToString(), dt2.Rows(0)("TD07").ToString(), "", (Convert.ToDouble(dt.Rows(i)("Zsl").ToString()) / Convert.ToDouble(str.GetPcs) / Convert.ToDouble(dt.Rows(i)("Zgs").ToString())).ToString("0.0"), "", "", "", "", "")
            'Else
            '    dt1.Rows.Add(i + 1, dt2.Rows(0)("TA02").ToString(), dt.Rows(i)("PF03").ToString(), name + "/" + dt.Rows(i)("PF05").ToString(), dt.Rows(i)("Zgs").ToString(), dt.Rows(i)("Jbsj").ToString(), dt.Rows(i)("PF02").ToString(), dt2.Rows(0)("TD28").ToString(), dt2.Rows(0)("TD02").ToString(), dt2.Rows(0)("TD07").ToString(), "", Convert.ToDouble(dt.Rows(i)("Zsl").ToString()) / Convert.ToDouble(str.GetPcs), Convert.ToDouble(dt2.Rows(0)("TJAB03").ToString()) / Convert.ToDouble(dt.Rows(i)("Zsl").ToString()), "", "", "", "")
            'End If
        Next
        DG.DataSource = dt1
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If DG.Rows.Count <> 0 Then
            setExcelFile()
            Dim OFL As New SaveFileDialog
            OFL.InitialDirectory = Environment.SpecialFolder.MyDocuments
            OFL.DefaultExt = "Xlsx"
            OFL.Filter = BIG2GB("Excel檔案|*.Xlsx|所有檔案|*.*")
            OFL.FileName = IO.Path.GetFileName("系统订单对比分析" + Date.Now.ToString("yyyyMMdd"))
            OFL.Title = BIG2GB("請選擇檔案")
            If OFL.ShowDialog = Windows.Forms.DialogResult.OK Then
                xls.Free2XLS(True)
                xls.Close(OFL.FileName)
                xls.Quit()
            End If
        Else
            MessageBox.Show("导出资料不得为空！")
            Return
        End If
    End Sub

    Private Sub setExcelFile()
        xls = New XLS_FILE
        xls.SetNewSheet("NEWSHEET")
        With xls
            Dim intC As Integer = 0
            Dim intR As Integer = 0
            Dim intX As Integer = 0
            .AddCell(1, 17, BIG2GB("深圳市技德印刷有限公司"))
            .CombineCells(0, 1, 16, 1)

            .AddCell(2, 17, BIG2GB("系统订单对比分析"))
            .CombineCells(0, 2, 16, 2)
            '.AddBorder(0, 2, 5, 2, BorderType.ALL, ExcelPara.xlThin)
            For Each c As DataGridViewColumn In DG.Columns
                intC += 1
                .AddCell(3, intC, c.HeaderText)
            Next

            For Each r As DataGridViewRow In DG.Rows
                intX = intR + 4
                .AddCell(intX, 1, GCell(r.Cells(0)))
                .AddCell(intX, 2, GCell(r.Cells(1)))
                .AddCell(intX, 3, GCell(r.Cells(2)))
                .AddCell(intX, 4, GCell(r.Cells(3)))
                .AddCell(intX, 5, GCell(r.Cells(4)))
                .AddCell(intX, 6, GCell(r.Cells(5)))
                .AddCell(intX, 7, GCell(r.Cells(6)))
                .AddCell(intX, 8, GCell(r.Cells(7)))
                .AddCell(intX, 9, GCell(r.Cells(8)))
                .AddCell(intX, 10, GCell(r.Cells(9)))
                .AddCell(intX, 11, GCell(r.Cells(10)))
                .AddCell(intX, 12, GCell(r.Cells(11)))
                .AddCell(intX, 13, GCell(r.Cells(12)))
                .AddCell(intX, 14, GCell(r.Cells(13)))
                .AddCell(intX, 15, GCell(r.Cells(14)))
                .AddCell(intX, 16, GCell(r.Cells(15)))
                .AddCell(intX, 17, GCell(r.Cells(16)))
                intR += 1
            Next
            .AddBorder(0, 3, DG.ColumnCount - 1, DG.RowCount + 3, BorderType.ALLLines, ExcelPara.xlThin)
        End With
    End Sub
End Class