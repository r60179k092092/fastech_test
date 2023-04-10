Public Class Frm0406
    Private clsDIA As clsDieSpec = Nothing
    Private dtData As DataTable = Nothing '自定义Table
    Private dtData2 As DataTable = Nothing '自定义Table
    Private aryTJ As New Dictionary(Of String, String)
    Private JUMP As Int32 = Nothing '跳距
    Private MODS As Int32 = Nothing '模数
    Private dataRows As DataGridViewRow = Nothing
    Private xls As XLS_FILE = New XLS_FILE
    Private WithEvents cs As clsEDIT2012.clsEDITx2013
  'Dim DtSelectd As Boolean = False '不需要這個
  Sub New()
        ' 此為設計工具所需的呼叫。
        InitializeComponent()
        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        languagechange(Me)
    End Sub
    ''' <summary>
    ''' 自定义表头
    ''' </summary>
    Private Sub GetData1()
        dtData = New DataTable()
        dtData.Columns.Add(BIG2GB("工单号")) '0
        dtData.Columns.Add(BIG2GB("机种")) '1
        dtData.Columns.Add(BIG2GB("料号")) '2
        dtData.Columns.Add(BIG2GB("规格")) '3
        dtData.Columns.Add(BIG2GB("生产数量")) '4
        dtData.Columns.Add(BIG2GB("调机时间(分)")) '5
        dtData.Columns.Add(BIG2GB("时产能")) '6
        dtData.Columns.Add(BIG2GB("操机人数")) '7
        dtData.Columns.Add(BIG2GB("上机日期")) '8
        dtData.Columns.Add(BIG2GB("上机时间")) '9
        dtData.Columns.Add(BIG2GB("负荷(分)")) '10
        dtData.Columns.Add(BIG2GB("下机日期")) '11
        dtData.Columns.Add(BIG2GB("下机时间")) '12
    End Sub

    Private Sub GetData2()
        dtData2 = New DataTable()
        dtData2.Columns.Add(BIG2GB("工单号")) '0
        dtData2.Columns.Add(BIG2GB("机种")) '1
        dtData2.Columns.Add(BIG2GB("料号")) '2
        dtData2.Columns.Add(BIG2GB("规格")) '3
        dtData2.Columns.Add(BIG2GB("生产数量（车）")) '4
        dtData2.Columns.Add(BIG2GB("调机时间(分)")) '5
        dtData2.Columns.Add(BIG2GB("时产能")) '6
        dtData2.Columns.Add(BIG2GB("操机人数")) '7
        dtData2.Columns.Add(BIG2GB("上机日期")) '8
        dtData2.Columns.Add(BIG2GB("上机时间")) '9
        dtData2.Columns.Add(BIG2GB("负荷(分)")) '10
        dtData2.Columns.Add(BIG2GB("下机日期")) '11
        dtData2.Columns.Add(BIG2GB("下机时间")) '12
    End Sub
    Private Sub Frm0805_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetData1()
        GetData2()
        cs = New clsEDIT2012.clsEDITx2013(DG2, DB, language)
        cs.Clean()
        '绑定机台
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TJ")
        sqlCV.SqlFields("TJ01")
        sqlCV.SqlFields("TJ02")
        Dim dt2 As DataTable = DB.RsSQL(sqlCV.Text, "TJ")
        ComboBox1.DataSource = dt2
        ComboBox1.DisplayMember = "TJ01"
        For Each dr As DataRow In dt2.Rows
            aryTJ.Add(dr!TJ01.ToString.Trim, dr!TJ02.ToString.Trim)
        Next
        '绑定机台
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TJ")
        sqlCV.SqlFields("TJ01")
        ComboTJ01.DataSource = dt2
        ComboTJ01.DisplayMember = "TJ01"
    End Sub

    Private Sub Frm0805_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
    TuiCK(Me) 'Application.Exit()
  End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DG.DataSource = Nothing
        dtData.Rows.Clear()
        If CK1.Checked Then
            If TextBox1.Text = "" Then
                CK1.Checked = False
            End If
        End If
        If CK3.Checked Then
            If TextBox2.Text = "" Then
                CK3.Checked = False
            End If
        End If
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TD") '^0 工单主表
        sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TN", "TN02", "=", "^0.TD01") '^1 生产填报资料单(三)生产管制表
        sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TM", "TM01", "=", "^1.TN01") '^2 生产填报资料单(二)生产主纪录表
        sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "WMSA", "SA01", "=", "^0.TD02") '^3 物料明细
        sqlCV.Where("^1.TN03", "=", "JD01") '条件，工序为模切
        sqlCV.Where("TM06", ">=", DP1.Value.ToString("yyyy-MM-dd")) '条件，开始时间
        sqlCV.Where("TM06", "<=", DP2.Value.ToString("yyyy-MM-dd")) '条件，结束时间
        sqlCV.Where("^2.TM02", "=", "JD01")
        sqlCV.SqlFields("^0.TD01",,,, True) '工单号
        sqlCV.SqlFields("^0.TD02") '成品料号
        sqlCV.SqlFields("^3.SA15") '规格
        sqlCV.SqlFields("^2.TM04") '机种
        sqlCV.SqlFields("min(^2.TM06)", "MinTM06",,, True) '操机时间
        sqlCV.SqlFields("max(^2.TM06)", "MaxTM06") '下机时间
        sqlCV.sqlGroup("^0.TD01")
        sqlCV.sqlGroup("^0.TD02")
        sqlCV.sqlGroup("^3.SA15")
        sqlCV.sqlGroup("^2.TM04")
        If CK1.Checked Then
            sqlCV.Where("^0.TD01", "=", TextBox1.Text) '条件，工单
        End If
        If CK2.Checked Then
            sqlCV.Where("^2.TM04", "=", ComboBox1.Text)
        End If
        If CK3.Checked Then
            sqlCV.Where("^0.TD02", "=", TextBox2.Text)
        End If
        Dim sql As String = sqlCV.Text
        Dim dt1 As DataTable = DB.RsSQL(sqlCV.Text, "dt1")
        If dt1.Rows.Count = 0 Then
            MsgBox("该区间无资料!")
            Button2_Click(Nothing, Nothing)
            Return
        End If
        For Each r1 As DataRow In dt1.Rows
            '查询生产数量
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TDC")
            sqlCV.SqlFields("SUM(TDC06)", "TDC06")
            sqlCV.SqlFields("SUM(TDC11)", "TDC11")
            sqlCV.Where("TDC01", "=", r1!TD01.ToString)
            sqlCV.Where("TDC05", "=", "JD01")
            Dim dt2 As DataTable = DB.RsSQL(sqlCV.Text, "TDC")
            Dim MinDatetime As DateTime = CDate(r1!MinTM06)
            Dim MaxDateTime As DateTime = CDate(r1!MaxTM06)

            Dim SCSum As String = Nothing '生产数量
            Dim TJsum As String = Nothing '调机时间
            Dim Capacity As String = Nothing '时产能
            Dim RenSum As String = Nothing '操机人数
            Dim FH As String = Nothing '负荷
            RenSum = CJRsum(r1!TD01.ToString, r1!TM04.ToString)

            FH = SecToMin(dt2.Rows(0)!TDC11.ToString)
            Dim timeSum As String = Nothing
            TJsum = CTJTiem(r1!TD01.ToString, r1!TM04.ToString)
            If dt2.Rows.Count > 0 Then
                SCSum = dt2.Rows(0)!TDC06.ToString
                Capacity = Ccapacity(dt2.Rows(0)!TDC11.ToString, SCSum)
            End If

            dtData.Rows.Add(r1!TD01.ToString, r1!TM04.ToString, r1!TD02.ToString, r1!SA15.ToString, SCSum, TJsum, Capacity, RenSum, MinDatetime.ToString("yyyy/MM/dd"), MinDatetime.ToString("H:mm"), FH, MaxDateTime.ToString("yyyy/MM/dd"), MaxDateTime.ToString("H:mm"))
        Next
        DG.DataSource = dtData
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click, Button6.Click
        Close()
    End Sub
    Private Function Ccapacity(str As String, scsum As String) As String
        If String.IsNullOrEmpty(str) Then Return ""
        If String.IsNullOrEmpty(scsum) Then Return ""
        Dim time As Integer = CInt(str)
        Dim sum As Integer = CInt(scsum)
        Dim sumtiem As Double = Nothing
        If time < 0 Or sum < 0 Then Return ""
        Dim retu As Double
        retu = Math.Round((sum / (time / 3600)), MidpointRounding.AwayFromZero)
        Return retu.ToString
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        CK1.Checked = False
        CK2.Checked = False
        CK3.Checked = False
        DG.DataSource = Nothing
        dtData.Rows.Clear()
    End Sub
    '计算操机人数
    Private Function CJRsum(strGd As String, strTj As String) As String
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_distinc, "SFIS_TM")
        sqlCV.Where("TM01", "IN", "$$")
        sqlCV.Where("TM04", "=", strTj)
        sqlCV.SqlFields("TM03")
        sqlCV.SqlFields("TM04")
        Dim sql As String = sqlCV.Text.Replace("(N'$$')", $"(select TN01 From SFIS_TN WHERE TN02='{strGd}' and TN03='JD01')")
        Dim dt As DataTable = DB.RsSQL(sql, "SFIS_TM")
        If dt.Rows.Count > 0 Then
            Return dt.Rows.Count
        End If
        Return ""
    End Function
    '计算调机时间
    Private Function CTJTiem(TDstr As String, Tjstr As String) As String
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TM")
        sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "SFIS_TN", "TN01", "=", "TM01")
        sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "SFIS_TD", "TD01", "=", "TN02")
        sqlCV.SqlFields("sum(TM14)", "TM14")
        sqlCV.Where("TD01", "=", TDstr)
        sqlCV.Where("TM04", "=", Tjstr)
        sqlCV.Where("TN03", "=", "JD01")
        'sqlCV.Where("TM08", "=", "-1")
        sqlCV.Where("TM10", "IN", "'2','4','5'", intFMode.msfld_field)
        Dim sql As String = sqlCV.Text
        Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "TM")
        If dt.Rows.Count = 0 Then
            Return ""
        End If
        Return dt.Rows(0)!TM14.ToString
    End Function
    Private Function SecToMin(second As String) As String
        If String.IsNullOrEmpty(second) Then Return ""
        Dim min As Integer
        If Int64.Parse(second) < 0 Then second = "0"
        min = Int64.Parse(second) / 60
        Return min.ToString
    End Function
    Private Sub DG_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DG.CellFormatting
        If DG.Rows.Count = 0 Or DG Is Nothing Then Return
        Select Case e.ColumnIndex
            Case 1
                e.Value = aryTJ.Item(e.Value)
        End Select
    End Sub
    '选择工单
    Private Sub BtnSTD_Click(sender As Object, e As EventArgs) Handles BtnSTD.Click
        Dim frm As New FrmSeTD
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            ShowData(frm.StrTd)
        End If
    End Sub
    Public Sub ShowData(r As DataGridViewRow)
        TextTD01.Text = r.Cells(0).Value
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TD") '工单主表^0
        sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TC", "TC01", "=", "^0.TD02") '料站主表^1
        sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "WMSA", "SA01", "=", "^1.TC02") '物料明细表^2
        sqlCV.Where("TD01", "=", r.Cells(0).Value) '贴纸代码找对应刀模
        sqlCV.Where("SA04", "IN", "'1010','1011'", intFMode.msfld_field)
        sqlCV.SqlFields("SA01") '刀模编号
        sqlCV.SqlFields("SA14") '刀模资料
        Dim ss As String = sqlCV.Text
        Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "TDTCSA")
        Dim SA14 As String = ""
        For Each dr2 As DataRow In dt.Rows
            SA14 = dr2("SA14").ToString() '资料
        Next
        '获取模数，跳距,PCS
        clsDIA = New clsDieSpec
        clsDIA.DieDecode(SA14)
        JUMP = clsDIA.JumpLength '跳距
        MODS = clsDIA.GetPU '模数
        Dim PCS = clsDIA.GetPcs 'PCS
        Dim Cnum As String = Math.Floor((Integer.Parse(r.Cells(3).Value) / PCS) * MODS) '订单总车数
        NumericUpDown2.Value = Cnum.ToString()
        dataRows = r
    End Sub
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        If TextTD01.Text = "" Then
            MsgBox("未选择工单！")
            Return
        End If
        If NumericUpDown2.Value <= 0 Then
            MsgBox("车数需要大于0！")
            Return
        End If
        If DG1.Rows.Count > 0 Then
            For Each dr As DataRow In dtData2.Rows
                If dr!工单号.ToString = TextTD01.Text Then
                    MsgBox("该工单已在排程中！")
                    Button5_Click(Nothing, Nothing)
                    Return
                End If
            Next
        End If
        DP3.Enabled = False
        ComboTJ01.Enabled = False
        '获取生产标准效率
        Dim SJtiem As String
        SJtiem = EsClass.PaperHeader(ComboTJ01.Text, MODS.ToString, JUMP.ToString)
        '获取调机标准时间
        Dim TJtime As String
        TJtime = EsClass.AUNEHeader(ComboTJ01.Text, MODS.ToString, JUMP.ToString)
        Dim SjiDate As Date = Nothing '上机日期
        Dim Sjitiem As Date = Nothing '上机时间
        Dim Fh As Double = 0 '负荷
        Dim XjiDate As Date = Nothing '上机日期
        Dim Xjitiem As Date = Nothing '上机时间
        If dtData2.Rows.Count = 0 Then
            SjiDate = DP3.Value.Date
            Sjitiem = "08:00:00"
        Else
            SjiDate = dtData2.Rows(dtData2.Rows.Count - 1)!下机日期.ToString()
            Sjitiem = dtData2.Rows(dtData2.Rows.Count - 1)!下机时间.ToString()
        End If
        If SJtiem IsNot Nothing Then
            Fh = FormatNumber(NumericUpDown2.Value / SJtiem, 1)
        End If
        XjiDate = SjiDate
        Xjitiem = Sjitiem.AddMinutes(Fh)
        If TJtime IsNot Nothing And TJtime IsNot "" Then
            Xjitiem = Xjitiem.AddMinutes(TJtime)
        End If
        Dim dateyz As Date = "12:00:00"
        Dim dateyz2 As Date = "23:59:59"
        If Xjitiem > dateyz Then
            Xjitiem = Xjitiem.AddMinutes(90)
        End If
        If Xjitiem > dateyz2 Then
            XjiDate = XjiDate.AddDays(1)
            Xjitiem = Xjitiem.AddMinutes(480)
            dateyz2.AddDays(1)
            dateyz.AddDays(1)
        End If

        dtData2.Rows.Add(TextTD01.Text, ComboTJ01.Text, dataRows.Cells(1).Value, dataRows.Cells(2).Value, NumericUpDown2.Text, TJtime, SJtiem * 60, NumericUpDown1.Value, SjiDate.ToShortDateString.ToString, Sjitiem.ToLongTimeString.ToString, Fh, XjiDate.ToShortDateString.ToString, Xjitiem.ToLongTimeString.ToString)
        DG1.DataSource = dtData2
        CfuHe()
    End Sub
  '總負荷
  Private Sub CfuHe()
        Dim fh As Double = 0
        If DG1.Rows.Count > 0 Then
            For Each dr As DataRow In dtData2.Rows
                fh += dr.Item(10).ToString
            Next
        End If
        Label7.Text = fh
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    'DtSelectd = False
    DP3.Enabled = True
        ComboTJ01.Enabled = True
        DG1.DataSource = Nothing
        dtData2.Rows.Clear()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextTD01.Text = ""
        NumericUpDown1.Value = 1
        NumericUpDown2.Value = 0
    End Sub

    Private Sub BtnRemove_Click(sender As Object, e As EventArgs) Handles BtnRemove.Click
    If DG1.Rows.Count = 0 Then
      Return
    End If

    dtData2.Rows(DG1.CurrentRow.Index).Delete()
        DG1.DataSource = dtData2
        If DG1.Rows.Count = 0 Then
            Button4_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If DG1.Rows.Count <= 1 Then
            Return
        End If
        If DG1.CurrentRow.Index = 0 Then
            Return
        End If
        Dim index As Integer = DG1.CurrentRow.Index
        Dim dr As DataRow = dtData2.Rows(index)
        Dim ddr As DataRow = Nothing
        ddr = dtData2.NewRow
        ddr("工单号") = dr.Item(0)
        ddr("机种") = dr.Item(1)
        ddr("料号") = dr.Item(2)
        ddr("规格") = dr.Item(3)
        ddr("生产数量(车)") = dr.Item(4)
        ddr("调机时间(分)") = dr.Item(5)
        ddr("时产能") = dr.Item(6)
        ddr("操机人数") = dr.Item(7)
        ddr("上机日期") = dr.Item(8)
        ddr("上机时间") = dr.Item(9)
        ddr("负荷(分)") = dr.Item(10)
        ddr("下机日期") = dr.Item(11)
        ddr("下机时间") = dr.Item(12)
        dtData2.Rows.RemoveAt(index)
        dtData2.Rows.InsertAt(ddr, index - 1)
        DG1.DataSource = dtData2
        DG1.Rows(index - 1).Selected = True
        DG1.CurrentCell = DG1.Rows(index - 1).Cells(0)
        Csj()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If DG1.Rows.Count <= 1 Then
            Return
        End If
        If DG1.CurrentRow.Index = DG1.Rows.Count - 1 Then
            Return
        End If
        Dim index As Integer = DG1.CurrentRow.Index
        Dim dr As DataRow = dtData2.Rows(index)
        Dim ddr As DataRow = Nothing
        ddr = dtData2.NewRow
        ddr("工单号") = dr.Item(0)
        ddr("机种") = dr.Item(1)
        ddr("料号") = dr.Item(2)
        ddr("规格") = dr.Item(3)
        ddr("生产数量(车)") = dr.Item(4)
        ddr("调机时间(分)") = dr.Item(5)
        ddr("时产能") = dr.Item(6)
        ddr("操机人数") = dr.Item(7)
        ddr("上机日期") = dr.Item(8)
        ddr("上机时间") = dr.Item(9)
        ddr("负荷(分)") = dr.Item(10)
        ddr("下机日期") = dr.Item(11)
        ddr("下机时间") = dr.Item(12)
        dtData2.Rows.RemoveAt(index)
        dtData2.Rows.InsertAt(ddr, index + 1)
        DG1.DataSource = dtData2
        DG1.Rows(index + 1).Selected = True
        DG1.CurrentCell = DG1.Rows(index + 1).Cells(0)
        Csj()
    End Sub
    Private Sub Csj()
        Dim SjiDate As Date = Nothing '上机日期
        Dim Sjitiem As Date = Nothing '上机时间
        Dim XjiDate As Date = Nothing '上机日期
        Dim Xjitiem As Date = Nothing '上机时间
        SjiDate = DP3.Value.Date
        Sjitiem = "08:00:00"
        For index = 0 To dtData2.Rows.Count - 1
            If index = 0 Then
                SjiDate = DP3.Value.Date
                Sjitiem = "08:00:00"
            Else
                SjiDate = dtData2.Rows(index - 1)!下机日期.ToString()
                Sjitiem = dtData2.Rows(index - 1)!下机时间.ToString()
            End If
            XjiDate = SjiDate
            Xjitiem = Sjitiem.AddMinutes(dtData2.Rows(index).Item(10))
            If dtData2.Rows(index).Item(5) IsNot Nothing And dtData2.Rows(index).Item(5) IsNot "" Then
                Xjitiem = Xjitiem.AddMinutes(dtData2.Rows(index).Item(5))
            End If
            Dim dateyz As Date = "12:00:00"
            Dim dateyz2 As Date = "23:59:59"
            If Xjitiem > dateyz Then
                Xjitiem = Xjitiem.AddMinutes(90)
            End If
            If Xjitiem > dateyz2 Then
                XjiDate = XjiDate.AddDays(1)
                dateyz2.AddDays(1)
                dateyz.AddDays(1)
            End If
            dtData2.Rows(index).Item(8) = SjiDate.ToShortDateString.ToString
            dtData2.Rows(index).Item(9) = Sjitiem.ToLongTimeString.ToString
            dtData2.Rows(index).Item(11) = XjiDate.ToShortDateString.ToString
            dtData2.Rows(index).Item(12) = Xjitiem.ToLongTimeString.ToString
        Next

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If DG1.Rows.Count <> 0 Then
            Dim OFL As New SaveFileDialog
            OFL.InitialDirectory = Environment.SpecialFolder.MyDocuments
            OFL.DefaultExt = "Xlsx"
            OFL.Filter = BIG2GB("Excel档案|*.Xlsx|所有档案|*.*")
            OFL.FileName = IO.Path.GetFileName("简单生产排程" + Date.Now.ToString("yyyyMMdd"))
            OFL.Title = BIG2GB("请选择档案")
            If OFL.ShowDialog = Windows.Forms.DialogResult.OK Then
                SetExcelFile()
                xls.Free2XLS(True)
                xls.Close(OFL.FileName)
                xls.Quit()
            End If
        Else
            MessageBox.Show("导出资料不得为空！")
            Return
        End If
    End Sub
    Private Sub SetExcelFile()
        xls = New XLS_FILE
        xls.SetNewSheet("简单生产排程计")
        With xls
            Dim intC As Integer = 0
            Dim intR As Integer = 0
            Dim intX As Integer = 0
            .AddCell(1, 13, BIG2GB("深圳市技德印刷有限公司"))
            .CombineCells(0, 1, 13, 1)
            .AddCell(2, 13, BIG2GB("生产排程"))
            .CombineCells(0, 2, 13, 2)
            For Each c As DataColumn In dtData2.Columns
                intC += 1
                .AddCell(3, intC, c.ColumnName)
            Next
            For Each r As DataRow In dtData2.Rows
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
                intR += 1
            Next
            .AddCell(intX + 1, 1, BIG2GB("总负荷：" + Label7.Text))
            .AddBorder(0, 3, dtData2.Columns.Count - 1, dtData2.Rows.Count + 3, BorderType.ALLLines, ExcelPara.xlThin)
        End With
    End Sub

  Private Sub cs_DVSelect(s As clsEDITx2013, r As DataGridViewRow) Handles cs.DVSelect
    'DtSelectd = True
    DG1.DataSource = Nothing
    dtData2.Rows.Clear()
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TDF")
    sqlCV.Where("TDF01", "=", r.Cells(0).Value)
    sqlCV.SqlFields("*")
    Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "tdf")
    Dim strdate As String = r.Cells(0).Value.Substring(0, 8)
    DP3.Value = CDate(Format(CInt(strdate), "0000-00-00"))
    ComboTJ01.SelectedItem = r.Cells(0).ToString.Substring(7, 4)
    DP3.Enabled = False
    ComboTJ01.Enabled = False
    For Each r1 As DataRow In dt.Rows
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "WMSA")
      sqlCV.Where("SA01", "=", r1(4))
      sqlCV.SqlFields("SA02")
      sqlCV.SqlFields("SA03")
      Dim dt2 As DataTable = DB.RsSQL(sqlCV.Text, "wmsa")
      Dim Guige As String = Nothing
      If dt2.Rows.Count > 0 Then
        Guige = dt2.Rows(0).Item(0) + dt2.Rows(0).Item(1).ToString.Trim
      End If

      dtData2.Rows.Add(r1(2).ToString.Trim, r1(3).ToString.Trim, r1(4).ToString.Trim, Guige, r1(5).ToString.Trim, r1(6).ToString.Trim, r1(7).ToString.Trim, r1(8).ToString.Trim, r1(9).ToString.Trim, r1(10).ToString.Trim, r1(11).ToString.Trim, r1(12).ToString.Trim, r1(13).ToString.Trim)
    Next
    DG1.DataSource = dtData2
    tabcontor1.SelectedIndex = 1
  End Sub

  Private Sub cs_DVTable(s As clsEDITx2013, ByRef strSQL As String) Handles cs.DVTable
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TDF")
        sqlCV.Where("TDF02", "=", "001")
        sqlCV.SqlFields("TDF01", "单据编号")
        sqlCV.SqlFields("TDF04", "机台编号")
        sqlCV.SqlFields("TDF10", "上机日期")
        sqlCV.SqlFields("TDF11", "上机时间")
        strSQL = sqlCV.Text
    End Sub

    Private Sub cs_Frm_CheckDup(s As clsEDITx2013, ByRef strSQL As String) Handles cs.Frm_CheckDup
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TDF")
        sqlCV.Where("TDF01", "=", DP3.Value.ToString("yyyyMMdd") + ComboTJ01.Text)
        sqlCV.SqlFields("*")
        'Dim sql As String = sqlCV.Text
        strSQL = sqlCV.Text
    End Sub

    Private Sub cs_Frm_Clear(s As clsEDITx2013) Handles cs.Frm_Clear
        Button4_Click(Nothing, Nothing)
        Button5_Click(Nothing, Nothing)
    End Sub

    Private Sub cs_Frm_Delete(s As clsEDITx2013, ByRef strSQL As String, ByRef bolOK As Boolean) Handles cs.Frm_Delete
    'If Not DtSelectd Then
    '    MsgBox("未选择排程！")
    '    Return
    'End If
    If MsgBox(BIG2GB("是否刪除排程:" & DP3.Value.ToString("yyyyMMdd") + ComboTJ01.Text & " 的相关咨迅？请确定"), MsgBoxStyle.YesNo) = MsgBoxResult.No Then Return
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_delete, "SFIS_TDF")
        sqlCV.Where("TDF01", "=", DP3.Value.ToString("yyyyMMdd") + ComboTJ01.Text)
        strSQL = sqlCV.Text
        bolOK = True
    End Sub

    Private Sub cs_Frm_InsertM(s As clsEDITx2013, ByRef strSQL As String) Handles cs.Frm_InsertM
        Dim i As Integer = 1
        For Each r As DataRow In dtData2.Rows
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_TDF")
            sqlCV.SqlFields("TDF01", DP3.Value.ToString("yyyyMMdd") + ComboTJ01.Text)
            sqlCV.SqlFields("TDF02", Format(i, "000"))
            sqlCV.SqlFields("TDF03", r(0))
            sqlCV.SqlFields("TDF04", r(1))
            sqlCV.SqlFields("TDF05", r(2))
            sqlCV.SqlFields("TDF06", r(4))
            sqlCV.SqlFields("TDF07", r(5))
            sqlCV.SqlFields("TDF08", r(6))
            sqlCV.SqlFields("TDF09", r(7))
            sqlCV.SqlFields("TDF10", r(8))
            sqlCV.SqlFields("TDF11", r(9))
            sqlCV.SqlFields("TDF12", r(10))
            sqlCV.SqlFields("TDF13", r(11))
            sqlCV.SqlFields("TDF14", r(12))
            DB.RsSQL(sqlCV.Text)
            i = i + 1
        Next
    'DtSelectd = True
    'MsgBox("添加成功！")
    cs.Updated = True
    cs_Frm_Clear(cs)
  End Sub

    Private Sub cs_Frm_Update_Errror(s As clsEDITx2013, strMsg As String, strSql As String) Handles cs.Frm_Update_Errror
        MsgBox("出错了！请重新尝试")
    End Sub

  Private Sub cs_Frm_UpdateM(s As clsEDITx2013, ByRef strSQL As String) Handles cs.Frm_UpdateM
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_delete, "SFIS_TDF")
    sqlCV.Where("TDF01", "=", DP3.Value.ToString("yyyyMMdd") + ComboTJ01.Text)
    DB.RsSQL(sqlCV.Text)
    Dim i As Integer = 1
    For Each r As DataRow In dtData2.Rows
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_TDF")
      sqlCV.SqlFields("TDF01", DP3.Value.ToString("yyyyMMdd") + ComboTJ01.Text)
      sqlCV.SqlFields("TDF02", Format(i, "000"))
      '兩種寫法都可以，不過要注意一下型態
      sqlCV.SqlFields("TDF03", r.Item(0).ToString.Trim) '型態要注意，要習慣後面都加上ToString.Trim
      sqlCV.SqlFields("TDF04", r(1).ToString.Trim) '型態要注意，要習慣後面都加上ToString.Trim
      sqlCV.SqlFields("TDF05", r(2))
      sqlCV.SqlFields("TDF06", r(4))
      sqlCV.SqlFields("TDF07", r(5))
      sqlCV.SqlFields("TDF08", r(6))
      sqlCV.SqlFields("TDF09", r(7), intFMode.msfld_num)
      sqlCV.SqlFields("TDF10", r(8))
      sqlCV.SqlFields("TDF11", r(9))
      sqlCV.SqlFields("TDF12", r(10), intFMode.msfld_num)
      sqlCV.SqlFields("TDF13", r(11))
      sqlCV.SqlFields("TDF14", r(12))
      DB.RsSQL(sqlCV.Text)
      i = i + 1
    Next
    'DtSelectd = True
    'MsgBox("修改成功！")
    cs.Updated = True
    cs_Frm_Clear(cs)
  End Sub

  Private Sub cs_isDataValid(s As clsEDITx2013, ByRef bolOK As Boolean) Handles cs.isDataValid
        If dtData2.Rows.Count = 0 Then
      MsgBox("排程为空，无法存档")
      TextTD01.Focus()
      Return
        End If
        bolOK = True
    End Sub
End Class