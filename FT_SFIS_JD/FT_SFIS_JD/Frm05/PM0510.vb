Public Class PM0510
    Private Sub PM0510_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTP1.Value = Now
        DTP2.Value = Now
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_distinc, "ATSQ_MAA")
        sqlCV.SqlFields("MAA07", "状态")
        sqlCV.SqlFields("Count(*)", "数量")
        sqlCV.sqlGroup("MAA07")
        Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        DG.DataSource = dt

        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_distinc, "ATSQ_MAA")
        sqlCV.SqlFields("MAA02", "KEYS")
        sqlCV.sqlOrder("MAA02")
        dt = DB.RsSQL(sqlCV.Text, "RT")
        ComboBox1.DisplayMember = "KEYS"
        ComboBox1.ValueMember = "KEYS"
        ComboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboBox1.AutoCompleteSource = AutoCompleteSource.ListItems
        ComboBox1.DataSource = dt

        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_distinc, "ATSQ_MAA")
        sqlCV.SqlFields("MAA01", "KEYS")
        sqlCV.sqlOrder("MAA01")
        dt = DB.RsSQL(sqlCV.Text, "RT")
        dt.Rows.Add("")
        dt.DefaultView.Sort = "KEYS ASC"
        dt = dt.DefaultView.ToTable()
        ComboBox2.DisplayMember = "KEYS"
        ComboBox2.ValueMember = "KEYS"
        ComboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboBox2.AutoCompleteSource = AutoCompleteSource.ListItems
        ComboBox2.DataSource = dt
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CH1.Checked = False
        CH2.Checked = False
        CH3.Checked = False
        DTP1.Value = Now
        DTP2.Value = Now
        ComboBox1.Text = ""
        ComboBox2.Text = ""

        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_distinc, "ATSQ_MAA")
        sqlCV.SqlFields("MAA07", "状态")
        sqlCV.SqlFields("Count(*)", "数量")
        sqlCV.sqlGroup("MAA07")
        Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        DG.DataSource = dt

        DG1.DataSource = Nothing
        DG1.Rows.Clear()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_distinc, "ATSQ_MAA")
        sqlCV.SqlFields("MAA07", "状态")
        sqlCV.SqlFields("Count(*)", "数量")
        sqlCV.sqlGroup("MAA07")
        If CH1.Checked = True Then
            sqlCV.Where("MAA03", ">=", DTP1.Value.ToString("yyyy-MM-dd"))
            sqlCV.Where("MAA03", "<=", DTP2.Value.ToString("yyyy-MM-dd"))
        End If
        If CH2.Checked = True Then
            sqlCV.Where("MAA02", "=", ComboBox1.Text.ToString().Trim())
        End If
        If CH3.Checked = True Then
            sqlCV.Where("MAA01", "=", ComboBox2.Text.ToString().Trim())
        End If
        Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        DG.DataSource = dt
    End Sub

    Private Sub DG_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG.CellDoubleClick
        If e.RowIndex > -1 Then
            sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_distinc, "ATSQ_MAA")
            sqlCV.SqlFields("MAA01", "机台")
            sqlCV.SqlFields("MAA02", "工单")
            sqlCV.SqlFields("MAA03", "开始时间")
            sqlCV.SqlFields("MAA04", "结束时间")
            sqlCV.SqlFields("MAA05", "累积工时")
            sqlCV.SqlFields("MAA06", "异常代码")
            sqlCV.SqlFields("MAA07", "异常名称")
            sqlCV.SqlFields("MAA08", "异常发生日期")
            sqlCV.SqlFields("MAA09", "异常发生开始时间")
            sqlCV.SqlFields("MAA10", "异常状态代码")
            sqlCV.SqlFields("MAA11", "异常状态名称")
            sqlCV.SqlFields("MAA13", "异常发生结束时间")
            sqlCV.Where("MAA07", "=", DG.Rows(e.RowIndex).Cells(0).Value.ToString())
            If CH1.Checked = True Then
                sqlCV.Where("MAA03", ">=", DTP1.Value.ToString("yyyy-MM-dd"))
                sqlCV.Where("MAA03", "<=", DTP2.Value.ToString("yyyy-MM-dd"))
            End If
            If CH2.Checked = True Then
                sqlCV.Where("MAA02", "=", ComboBox1.Text.ToString().Trim())
            End If
            If CH3.Checked = True Then
                sqlCV.Where("MAA01", "=", ComboBox2.Text.ToString().Trim())
            End If
            Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "RT")
            DG1.DataSource = dt
        End If
    End Sub

  Private Sub PM0510_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    TuiCK(Me)
  End Sub
End Class