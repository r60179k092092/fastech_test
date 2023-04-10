Public Class Frm0510
    Private xls As XLS_FILE = New XLS_FILE
    Private TD As DataTable = Nothing
    Private dtData As DataTable = Nothing '自定义Table
    Private clsDIA As clsDieSpec = Nothing
    Private clsLAB As clsLabSpec = Nothing
    Private intI As Integer '自增序号
    Private pageIndex As Integer = 1 '当前页
    Private totalPage As Integer = 0 '总页数
    Private Gonxu As New Dictionary(Of String, String) '工序
    Private Sub Frm0510_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        TuiCK(Me)
    End Sub
    '关闭
    Private Sub Leave_Click(sender As Object, e As EventArgs) Handles Leave.Click
        Me.Close()
    End Sub
    '清空
    Private Sub Clear_Click(sender As Object, e As EventArgs) Handles Clear.Click
        DTP1.Value = Now
        DTP2.Value = Now
        TextMO.Text = ""
        DG.DataSource = Nothing
        ProgressBar.Value = 0
        Tips.Text = String.Empty
        intI = 0
        Page.Text = pageIndex
        LabelTJTimeSUM.Text = 0
        LabelTDSum.Text = 0
        LabelCSum.Text = 0
        LabelSJSum.Text = 0
        LabelSJTimeSum.Text = 0
    End Sub
    Private Function TACellFormatting(str As String) As String
        Try
            Return Gonxu.Item(str)
        Catch ex As Exception
            Return str
        End Try
    End Function
    Public Sub Selectgonxu()
        Dim sqlcv As New APSQL.SQLCNV
        sqlcv.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TA")
        sqlcv.SqlFields("*")
        Dim sql As String = sqlcv.Text
        Dim dt As DataTable = DB.RsSQL(sqlcv.Text, "TA")
        For Each dr As DataRow In dt.Rows
            Gonxu.Add(dr!TA01.ToString.Trim, dr!TA02.ToString.Trim)
        Next
    End Sub

    Private Sub Frm0510_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Clear_Click(Nothing, Nothing)
        GetData()
        Enable()
        Selectgonxu()
        '绑定机台
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TJ")
        sqlCV.SqlFields("TJ01")
        sqlCV.SqlFields("TJ02")
        Dim dt2 As DataTable = DB.RsSQL(sqlCV.Text, "TJ")
        ComboBox1.DataSource = dt2
        ComboBox1.DisplayMember = "TJ01"
        '绑定人员
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_User")
        sqlCV.SqlFields("*")
        Dim dt1 As DataTable = DB.RsSQL(sqlCV.Text, "User")
        ComboBox2.DataSource = dt1
        ComboBox2.DisplayMember = "UserName"
        '绑定工序
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TA")
        sqlCV.SqlFields("TA01")
        sqlCV.SqlFields("TA02")
        Dim dt3 As DataTable = DB.RsSQL(sqlCV.Text, "TA")
        ComboBox3.DataSource = dt3
        ComboBox3.DisplayMember = "TA02"
        ComboBox3.ValueMember = "TA01"
    End Sub

    '自定义表头
    Private Sub GetData()
        dtData = New DataTable()
        dtData.Columns.Add(BIG2GB("序号")) '0
        dtData.Columns.Add(BIG2GB("姓名")) '1
        dtData.Columns.Add(BIG2GB("机台")) '2
        dtData.Columns.Add(BIG2GB("工序")) '3
        dtData.Columns.Add(BIG2GB("制令单号")) '4
        dtData.Columns.Add(BIG2GB("客户名称")) '5
        dtData.Columns.Add(BIG2GB("贴纸代码")) '6
        dtData.Columns.Add(BIG2GB("规格材质")) '7
        dtData.Columns.Add(BIG2GB("订单数量")) '8
        dtData.Columns.Add(BIG2GB("跳距")) '9
        dtData.Columns.Add(BIG2GB("订单总车数")) '10
        dtData.Columns.Add(BIG2GB("开始时间")) '11
        dtData.Columns.Add(BIG2GB("结束时间")) '12
        dtData.Columns.Add(BIG2GB("标准车数(效率标准表)分钟")) '13
        dtData.Columns.Add(BIG2GB("标准时间(分钟)")) '14
        dtData.Columns.Add(BIG2GB("调机时间(分钟)")) '15
        dtData.Columns.Add(BIG2GB("洗机时间")) '16
        dtData.Columns.Add(BIG2GB("换单时间(分钟)")) '17
        dtData.Columns.Add(BIG2GB("已完成车数")) '18
        dtData.Columns.Add(BIG2GB("实际完成时间(分钟)")) '19
        dtData.Columns.Add(BIG2GB("油墨性质  颜色")) '20
        dtData.Columns.Add(BIG2GB("完成状态")) '21
        dtData.Columns.Add(BIG2GB("延误完成原因")) '22
        dtData.Columns.Add(BIG2GB("备注")) '23

    End Sub
    Private Sub GetSearch(Optional MO As String = "")
        If CK1.Checked Or CK2.Checked Or CK3.Checked Or CK4.Checked Or CK5.Checked Then
        Else
            MsgBox("请输入查询信息")
            Return
        End If
        intI = 0 '自增序号
        DG.DataSource = Nothing
        dtData.Clear()
        Dim sqlCV As SQLCNV = New APSQL.SQLCNV
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_distinc, "SFIS_TD") '0
        sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TN", "TN02", "=", "^0.TD01") '1   工单对应
        sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TM", "TM01", "=", "^1.TN01") '2  PPID对应
        sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "WMSA", "SA01", "=", "^0.TD02") '3     料号对应
        sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_User", "UserCode", "=", "^2.TM03") '4 操作者对应
        sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "ATSQ_MA", "MA03", "=", "^0.TD01") '5 工单对应
        sqlCV.Where("^1.TN03", "=", "TM02")
        If CK5.Checked Then
            sqlCV.Where("^0.TD08", ">=", DTP1.Value.ToString("yyyy-MM-dd"))
            sqlCV.Where("^0.TD08", "<=", DTP2.Value.ToString("yyyy-MM-dd"))
        End If
        If CK1.Checked Then
            If TextMO.Text = "" Then
                MsgBox("请输入工单进行查询")
                Return
            End If
            sqlCV.Where("^0.TD01", "=", TextMO.Text)
        End If
        If CK2.Checked Then
            sqlCV.Where("^2.TM04", "=", ComboBox1.Text)
        End If
        If CK3.Checked Then
            sqlCV.Where("^4.UserName", "=", ComboBox2.Text)
        End If
        If CK4.Checked Then
            sqlCV.Where("^2.TM02", "=", ComboBox3.SelectedValue)
        End If
        sqlCV.SqlFields("^4.UserName") '姓名
        sqlCV.SqlFields("^4.UserCode") '账号
        sqlCV.SqlFields("^2.TM04") '机台
        sqlCV.SqlFields("^0.TD01") '制令单号
        sqlCV.SqlFields("^0.TD08") '生产时间
        sqlCV.SqlFields("^0.TD28") '客户名称
        sqlCV.SqlFields("^3.SA01") '贴纸代码
        sqlCV.SqlFields("^3.SA03") '材质规格
        sqlCV.SqlFields("^0.TD07") '订单数量
        sqlCV.SqlFields("^0.TD12") '完成状态
        sqlCV.SqlFields("^5.MA01") '机台
        sqlCV.SqlFields("^5.MA03") '工单
        sqlCV.SqlFields("^5.MA18") '调机时间
        sqlCV.SqlFields("^2.TM02") '工序
        sqlCV.SqlFields("max(^1.TN01)", "TN01") 'PPID
        sqlCV.SqlFields("min(^1.TN04)", "TN04") '开始时间
        sqlCV.sqlOrder("^0.TD01", SQLCNV.intOrder.Order_Asc)
        sqlCV.sqlOrder("^2.TM02", SQLCNV.intOrder.Order_Asc)
        sqlCV.sqlGroup("UserName,UserCode,TM04,TD01,TD08,TD28,SA01,SA03,TD07,TD12,MA01,MA03,MA18,TM02")
        Dim sql As String = sqlCV.Text.Replace("N'TM02'", "TM02")
        TD = DB.RsSQL(sql, "RT")
        If TD.Rows.Count = 0 Then
            DG.DataSource = Nothing
            Tips.Text = BIG2GB("该区间无任何资料")
            Return
        End If
        ProgressBar.Value = 0
        ProgressBar.Minimum = 0
        ProgressBar.Maximum = TD.Rows.Count
        Tips.Text = BIG2GB("正在查询...")
        Dim TDSum As Integer = 0 '订单数
        Dim CSum As Integer = 0 '总车数
        Dim TJTimeSum As Integer = 0 '调机时间
        Dim SJSum As Integer = 0 '实际完成数量
        Dim SJTimeSum As Integer = 0 '实际完成时间
        Dim TDstr As String = ""
        For Each dr As DataRow In TD.Rows
            intI += 1 '自增序号
            ProgressBar.Value += 1
            Application.DoEvents()
            Dim TD12 As String = CellFormatting(dr!TD12.ToString.Trim) '工单状态
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "WMSA")
            sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TC", "TC02", "=", "^0.SA01")
            sqlCV.Where("TC01", "=", dr("SA01").ToString()) '贴纸代码找对应刀模
            sqlCV.Where("SA04", "IN", "'1010','1011'", intFMode.msfld_field)
            sqlCV.SqlFields("SA01") '刀模编号
            sqlCV.SqlFields("SA14") '刀模资料
            Dim WMSA As DataTable = DB.RsSQL(sqlCV.Text, "WMSA")
            Dim SA14 As String = ""
            For Each dr2 As DataRow In WMSA.Rows
                SA14 = dr2("SA14").ToString() '资料
            Next
            '获取模数，跳距
            clsDIA = New clsDieSpec
            clsDIA.DieDecode(SA14)
            Dim JUMP = clsDIA.JumpLength '跳距
            Dim MODS = clsDIA.GetPU '模数
            Dim PCS = clsDIA.GetPcs
            Dim StartTime As New DateTime '开始时间
            Dim EndTime As New DateTime '结束时间
            '到TM表中去查询
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TM")
            sqlCV.Where("TM01", "=", dr!TN01.ToString.Trim)
            sqlCV.SqlFields("MAX(TM06)", "ENDTime") '结束时间
            Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "tm")

            If dt.Rows.Count > 0 Then
                StartTime = CDate(dr!TN04.ToString.Trim) '开始时间
            End If

            Dim TJAB03 = "", TDC11 = 1, MA01 = dr!MA01.ToString.Trim, MA03 = dr!MA03.ToString.Trim, MA18 = dr!MA18.ToString.Trim, TM02 = dr!TM02.ToString '取值
            Dim StanTime As String = "", CountC As String = "", EndC As String = "", TJTime As String = "", SJTime As String = ""
            If dt.Rows.Count = 1 Then
                EndTime = DateTime.Parse(dt(0)!ENDTime.ToString.Trim) '结束时间
            End If
            CountC = Math.Floor((Integer.Parse(dr!TD07.ToString) / PCS) * MODS) '订单总车数
            CSum = CSum + Integer.Parse(CountC) '汇总总车数

            Dim sstr As String = dr!TM04.ToString()
            Dim tjstr As String = EsClass.PaperHeader(dr!TM04.ToString(), MODS.ToString, JUMP.ToString)

            TJTime = SecToMin(MA18) '调机时间
            If TJTime <> "" Then
                TJTimeSum += Integer.Parse(TJTime)
            End If
            TJAB03 = tjstr 'HourToMin(TJAB03) '标准速率
            '从TDC表中取实际完成实际和实际完成数量
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TDC")
            sqlCV.Where("TDC01", "=", dr!TD01.ToString())
            sqlCV.Where("TDC05", "=", dr!TM02.ToString())
            'sqlCV.Where("TDC06", "!=", "0")
            sqlCV.Where("TDC13", "=", dr!UserCode.ToString())
            sqlCV.SqlFields("SUM(TDC11)", "SJTime")
            sqlCV.SqlFields("SUM(TDC06)", "endc")
            Dim dt2 As DataTable = DB.RsSQL(sqlCV.Text, "TDC")
            If dt2.Rows.Count <> 0 Then
                SJTime = SecToMin(dt2(0)!SJTime.ToString.Trim) '实际完成时间（TDC取值）
                If SJTime <> "" Then
                    SJTimeSum += Integer.Parse(SJTime)
                End If
                If dt2(0)!endc.ToString <> "" Then
                    EndC = Math.Floor(Integer.Parse(dt2(0)!endc.ToString) / PCS) '已完成车数
                    SJSum += Integer.Parse(EndC)
                End If
            End If
            'SJTime = DateDiff("n", StartTime, EndTime) '实际完成时间(计算)

            If TJAB03 <> "" Then
                If EndC <> "" Then
                    StanTime = Math.Round(Integer.Parse(EndC) / Integer.Parse(TJAB03), MidpointRounding.AwayFromZero) '标准时间
                End If
            End If

            If dr!TD01.ToString.Trim = MA03 And dr!TM04.ToString.Trim = MA01 Then '机台与工单对应ATSQ_MA，取出调机时间
                dtData.Rows.Add(intI, dr!UserName.ToString(), dr!TM04.ToString(), TACellFormatting(TM02), dr!TD01.ToString(), dr!TD28.ToString(), dr!SA01.ToString(), dr!SA03.ToString(), dr!TD07.ToString(), JUMP, CountC, StartTime, EndTime, TJAB03, StanTime, TJTime, "", "", EndC, SJTime, "", TD12, "", "")
            Else
                dtData.Rows.Add(intI, dr!UserName.ToString(), dr!TM04.ToString(), TACellFormatting(TM02), dr!TD01.ToString(), dr!TD28.ToString(), dr!SA01.ToString(), dr!SA03.ToString(), dr!TD07.ToString(), JUMP, CountC, StartTime, EndTime, TJAB03, StanTime, "", "", "", EndC, SJTime, "", TD12, "", "")
            End If
            '计算汇总
            If TDstr <> dr!TD01.ToString.Trim Then
                TDSum += 1
                TDstr = dr!TD01.ToString.Trim
            End If
        Next
        If ProgressBar.Value = TD.Rows.Count Then
            Tips.Text = ""
            tip3.Text = BIG2GB("共" & TD.Rows.Count & "条记录")
            PageNum(TD.Rows.Count)
            tip2.Text = BIG2GB(pageIndex & vbTab & "/" & vbTab & totalPage)
            DG.DataSource = GetPagedTable(dtData, pageIndex, PageRow.Text)
        End If
        LabelTJTimeSUM.Text = TJTimeSum '总调机完成时间
        LabelTDSum.Text = TDSum '总单数
        LabelCSum.Text = CSum '总订单数量
        LabelSJSum.Text = SJSum '总实际完成数量
        LabelSJTimeSum.Text = SJTimeSum '总实际完成时间
    End Sub
    '查询
    Private Sub Search_Click(sender As Object, e As EventArgs) Handles Search.Click
        GetSearch()
        Enable()
    End Sub
    Private Sub MO_KeyPress(sender As Object, e As KeyPressEventArgs) 'Handles MO.KeyPress
        If e.KeyChar = vbLf Or e.KeyChar = vbCr Then
            e.Handled = True
            My.Computer.Keyboard.SendKeys(vbTab)
        End If
    End Sub
    '工单查询 
    Private Sub MO_LostFocus(sender As Object, e As EventArgs) 'Handles TextMO.LostFocus
        GetSearch(TextMO.Text.Trim)
        Enable()
    End Sub

    '秒->分钟换算
    Private Function SecToMin(second As String) As String
        If String.IsNullOrEmpty(second) Then Return ""
        Dim min As Integer
        If Int64.Parse(second) < 0 Then second = "0"
        'min = Int64.Parse(second) Mod 60
        min = Int64.Parse(second) / 60
        Return min.ToString
    End Function
    '小时->分钟换算
    Private Function HourToMin(hour As String) As String '
        If String.IsNullOrEmpty(hour) Then Return ""
        Dim min As String
        If Int64.Parse(hour) < 0 Then hour = "0"
        min = Int64.Parse(hour) * 60
        Return min
    End Function

    ''' <summary>
    ''' DataTable分页
    ''' </summary>
    ''' <param name="dt">需要被分页处理的DataTable</param>
    ''' <param name="pageIndex">表示第几页</param>
    ''' <param name="pageSize">表示展示每页的记录</param>
    ''' <returns></returns>
    Private Function GetPagedTable(dt As DataTable, pageIndex As Integer, pageSize As Integer) As DataTable
        If pageIndex = 0 Then Return dt '0页代表每页数据，直接返回
        Dim newdt As DataTable = dt.Copy()
        newdt.Clear()
        Dim rowbegin As Integer = (pageIndex - 1) * pageSize
        Dim rowend As Integer = pageIndex * pageSize
        If rowbegin >= dt.Rows.Count Then Return newdt  '源数据记录数小于等于要显示的记录，直接返回dt
        If rowend > dt.Rows.Count Then rowend = dt.Rows.Count
        For i As Integer = rowbegin To rowend - 1
            Dim newdr As DataRow = newdt.NewRow()
            Dim dr As DataRow = dt.Rows(i)
            For Each column As DataColumn In dt.Columns
                newdr(column.ColumnName) = dr(column.ColumnName)
            Next
            newdt.Rows.Add(newdr)
        Next
        Return newdt
    End Function

    Private Function CellFormatting(TD12 As String) As String
        Select Case TD12
            Case "0"
                TD12 = BIG2GB("未开工")
            Case "1"
                TD12 = BIG2GB("生产中")
            Case "2"
                TD12 = BIG2GB("完工")
            Case "3"
                TD12 = BIG2GB("暂停生产")
            Case "8"
                TD12 = BIG2GB("作废")
        End Select
        Return TD12
    End Function

    'Excel导出
    Private Sub ExcelOutFile_Click(sender As Object, e As EventArgs) Handles ExcelOutFile.Click
        If DG.Rows.Count <> 0 Then
            Dim OFL As New SaveFileDialog
            OFL.InitialDirectory = Environment.SpecialFolder.MyDocuments
            OFL.DefaultExt = "Xlsx"
            OFL.Filter = BIG2GB("Excel檔案|*.Xlsx|所有檔案|*.*")
            OFL.FileName = IO.Path.GetFileName("生产订单与工时统计表" + Date.Now.ToString("yyyyMMdd"))
            OFL.Title = BIG2GB("請選擇檔案")
            If OFL.ShowDialog = Windows.Forms.DialogResult.OK Then
                Tips.Text = BIG2GB("正在导出...")
                SetExcelFile()
                xls.Free2XLS(True)
                xls.Close(OFL.FileName)
                xls.Quit()
            End If
            Tips.Text = ""
        Else
            MessageBox.Show("导出资料不得为空！")
            Return
        End If
    End Sub

    Private Sub SetExcelFile()
        xls = New XLS_FILE
        xls.SetNewSheet("生产订单与工时统计")
        With xls
            Dim intC As Integer = 0
            Dim intR As Integer = 0
            Dim intX As Integer = 0
            .AddCell(1, 21, BIG2GB("深圳市技德印刷有限公司"))
            .CombineCells(0, 1, 20, 1)
            .AddCell(2, 21, BIG2GB("生产订单与工时统计"))
            .CombineCells(0, 2, 20, 2)
            For Each c As DataColumn In dtData.Columns
                intC += 1
                .AddCell(3, intC, c.ColumnName)
            Next
            For Each r As DataRow In dtData.Rows
                intX = intR + 4
                .AddCell(intX, 1, r(0))
                .AddCell(intX, 2, r(1))
                .AddCell(intX, 3, r(2))
                .AddCell(intX, 4, r(3))
                .AddCell(intX, 5, r(4))
                .AddCell(intX, 6, r(5))
                .AddCell(intX, 7, r(6))
                .AddCell(intX, 8, r(7))
                .AddCell(intX, 9, r(8))
                .AddCell(intX, 10, r(9))
                .AddCell(intX, 11, r(10))
                .AddCell(intX, 12, r(11))
                .AddCell(intX, 13, r(12))
                .AddCell(intX, 14, r(13))
                .AddCell(intX, 15, r(14))
                .AddCell(intX, 16, r(15))
                .AddCell(intX, 17, r(16))
                .AddCell(intX, 18, r(17))
                .AddCell(intX, 19, r(18))
                .AddCell(intX, 20, r(19))
                .AddCell(intX, 21, r(20))
                .AddCell(intX, 22, r(21))
                .AddCell(intX, 23, r(22))
                intR += 1
            Next
            '.AddCell(intX + 1, 1, BIG2GB("总时间："))
            '.AddCell(intX + 1, 5, BIG2GB("加班时间："))
            '.AddCell(intX + 1, 10, BIG2GB("调机/换单时间："))
            '.AddCell(intX + 1, 14, BIG2GB("开机时间："))
            '.AddCell(intX + 1, 18, BIG2GB("总车数："))
            .AddCell(intX + 1, 1, BIG2GB("订单数：" + LabelTDSum.Text))
            .AddCell(intX + 1, 5, BIG2GB("总车数：" + LabelCSum.Text))
            .AddCell(intX + 1, 10, BIG2GB("调机时间：" + LabelTJTimeSUM.Text + " 分钟"))
            .AddCell(intX + 1, 14, BIG2GB("完成车数：" + LabelSJSum.Text))
            .AddCell(intX + 1, 18, BIG2GB("实际完成时间：" + LabelSJTimeSum.Text + " 分钟"))
            .AddBorder(0, 3, dtData.Columns.Count - 1, dtData.Rows.Count + 3, BorderType.ALLLines, ExcelPara.xlThin)
        End With
        Tips.Text = BIG2GB("导出完成")
    End Sub

    Private Sub Enable()
        If pageIndex = 1 And totalPage = 1 Then
            For Each btn As Button In Panel5.Controls
                btn.Enabled = False
            Next
            Return
        End If
        Select Case pageIndex
            Case 1
                TopPage.Enabled = False
                NextPage.Enabled = True
            Case totalPage
                NextPage.Enabled = False
                TopPage.Enabled = True
            Case Else
                TopPage.Enabled = True
                NextPage.Enabled = True
        End Select
    End Sub

    ''' <summary>
    ''' 总页数
    ''' </summary>
    ''' <param name="num">总数据量</param>
    Private Sub PageNum(num As Integer)
        Dim CountPage = num / Integer.Parse(PageRow.Text)
        Dim ys = num Mod Integer.Parse(PageRow.Text)
        If ys > 0 Then
            totalPage = CInt(CountPage) + 1
        Else
            totalPage = CountPage
        End If
    End Sub

    Private Sub PageRow_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PageRow.KeyPress
        If e.KeyChar = vbLf Or e.KeyChar = vbCr Then
            e.Handled = True
            My.Computer.Keyboard.SendKeys(vbTab)
            DG.DataSource = GetPagedTable(dtData, 1, PageRow.Text)
            PageNum(TD.Rows.Count)
            tip2.Text = BIG2GB(pageIndex & vbTab & "/" & vbTab & totalPage)
        End If
    End Sub

    Private Sub FirstPage_Click(sender As Object, e As EventArgs) Handles FirstPage.Click
        pageIndex = 1
        NextPage.Enabled = True
        TopPage.Enabled = False
        tip2.Text = BIG2GB(pageIndex & vbTab & "/" & vbTab & totalPage)
        DG.DataSource = GetPagedTable(dtData, pageIndex, PageRow.Text)
    End Sub

    Private Sub TopPage_Click(sender As Object, e As EventArgs) Handles TopPage.Click
        pageIndex -= 1
        Enable()
        tip2.Text = BIG2GB(pageIndex & vbTab & "/" & vbTab & totalPage)
        DG.DataSource = GetPagedTable(dtData, pageIndex, PageRow.Text)
    End Sub

    Private Sub NextPage_Click(sender As Object, e As EventArgs) Handles NextPage.Click
        pageIndex += 1
        Enable()
        tip2.Text = BIG2GB(pageIndex & vbTab & "/" & vbTab & totalPage)
        DG.DataSource = GetPagedTable(dtData, pageIndex, PageRow.Text)
    End Sub

    Private Sub LastPage_Click(sender As Object, e As EventArgs) Handles LastPage.Click
        pageIndex = totalPage
        NextPage.Enabled = False
        TopPage.Enabled = True
        tip2.Text = BIG2GB(pageIndex & vbTab & "/" & vbTab & totalPage)
        DG.DataSource = GetPagedTable(dtData, totalPage, PageRow.Text)
    End Sub

    Private Sub HREF_Click(sender As Object, e As EventArgs) Handles HREF.Click
        pageIndex = Integer.Parse(Page.Text.Trim)
        If Integer.Parse(Page.Text.Trim) < 1 Then
            pageIndex = 1
            Page.Text = pageIndex.ToString()
        ElseIf Page.Text.Trim >= totalPage.ToString() Then
            Page.Text = totalPage.ToString()
            pageIndex = totalPage
            DG.DataSource = GetPagedTable(dtData, totalPage, PageRow.Text)
        End If
        Enable()
        DG.DataSource = GetPagedTable(dtData, Integer.Parse(Page.Text), PageRow.Text)
        tip2.Text = BIG2GB(pageIndex & vbTab & "/" & vbTab & totalPage)

    End Sub

    Private Sub Page_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Page.KeyPress
        If e.KeyChar = vbLf Or e.KeyChar = vbCr Then
            e.Handled = True
            My.Computer.Keyboard.SendKeys(vbTab)
            HREF_Click(Nothing, Nothing)
        End If
    End Sub

End Class