Imports APSQL
Public Class FrmSeTD
    Private strtd1 As DataGridViewRow = Nothing
    Public Property StrTd As DataGridViewRow
        Get
            Return strtd1
        End Get
        Set(value As DataGridViewRow)
            strtd1 = value
        End Set
    End Property
    Private Sub FrmSeTD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TD")
        sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "SFIS_TBB", "TBB03", "=", "SFIS_TD.TD02")
        'sqlCV.Where("TD12", "IN", "0,1,2,3", intFMode.msfld_field)
        sqlCV.Where("TD12", "IN", "0", intFMode.msfld_field)
        'sqlCV.Where("TD12", "=", "2", , 1, "OR")
        sqlCV.SqlFields("TD01", "工单编号")
        sqlCV.SqlFields("TD02", "物料编号")
        sqlCV.SqlFields("^1.TBB05+' '+^1.TBB06", "品名規格")
        sqlCV.SqlFields("TD07", "订单数量")
        sqlCV.SqlFields("TD28", "客户名称")
        sqlCV.SqlFields("TD12", "工单状态")
        sqlCV.SqlFields("Convert(Varchar(10),TD08,111)", "日期")
        sqlCV.sqlOrder("TD08", SQLCNV.intOrder.Order_Dsc)
        Dim sql As String = sqlCV.Text
        DG.DataSource = DB.RsSQL(sqlCV.Text, "TD")
    End Sub
    Private Sub DG_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DG.CellFormatting
        If DG.Rows.Count = 0 Or DG Is Nothing Then Return
        Select Case e.ColumnIndex
            Case 5
                Select Case e.Value
                    Case 0
                        e.Value = "未开工"
                    Case 1
                        e.Value = "生产中"
                    Case 2
                        e.Value = "完工"
                    Case 3
                        e.Value = "暂停生产"
                    Case 4
                        e.Value = "作废"
                End Select
        End Select
    End Sub

    Private Sub DG_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG.CellDoubleClick
        strtd1 = DG.Rows(e.RowIndex)
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
End Class
