''' <summary>
''' 工單ERP抓取
''' </summary>
''' <remarks></remarks>
Public Class FrmERP_DLG
  Private intMode As Integer = 0
  Private rs As DataTable = Nothing
  Private strKey As String = ""
  Private rp As DataGridViewRow = Nothing
  Public Property KeyValue As String
    Get
      Return strKey
    End Get
    Set(value As String)
      strKey = value
    End Set
  End Property
  Public Function GetSelect() As DataGridViewRow
    Return rp
  End Function
  Public Property Mode As Integer
    Get
      Return intMode
    End Get
    Set(value As Integer)
      Dim sqlCV As New APSQL.SQLCNV
      intMode = value
      Select Case intMode
        Case 0
#If k3 = 1 Then
          sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "ICMO")
          sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "t_ICItem", "FItemID", "=", "^0.FItemID")
          sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "SEOrder", "FInterID", "=", "^0.FOrderInterID")
          If strKey <> "" Then sqlCV.Where("^0.FBillNO", "Like", strKey & "%")
          sqlCV.Where("^0.FStatus", "IN", "0,1", intFMode.msfld_field)
          sqlCV.SqlFields("^0.FBillNO", "工單編號")
          sqlCV.SqlFields("^1.FNumber", "物料編號")
          sqlCV.SqlFields("^1.FName", "品名")
          sqlCV.SqlFields("^0.FQTY", "數量")
          sqlCV.SqlFields("^2.FBillNO", "銷售訂單")
          sqlCV.SqlFields("^1.FModel", "型號規格")
          sqlCV.SqlFields("^0.FPlanCommitDate", "開工日期")
          sqlCV.SqlFields("^0.FPlanFinishDate", "完工日期")
          sqlCV.SqlFields("^0.FStatus", "狀態")
          sqlCV.SqlFields("^0.FNote", "備註")
#ElseIf K3 = 2 Then
          sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "MOCTA", , "TOP 200")
          If strKey <> "" Then
            Dim strV() As String = strKey.Split("-")
            sqlCV.Where("^0.TA001", "=", strV(0).Trim)
            If strV.Length > 1 AndAlso strV(1).Trim <> "" Then
              sqlCV.Where("^0.TA002", "Like", strV(1).Trim & "%")
            End If
          End If
          sqlCV.Where("^0.TA011", "NOT IN", "'y','Y'", intFMode.msfld_field)
          sqlCV.SqlFields("RTRIM(^0.TA001)+'-'+RTRIM(^0.TA002)", "工單編號")
          sqlCV.SqlFields("^0.TA006", "物料編號")
          sqlCV.SqlFields("RTRIM(^0.TA034)+' '+RTRIM(^0.TA035)", "品名")
          sqlCV.SqlFields("^0.TA015", "數量")
          sqlCV.SqlFields("RTRIM(^0.TA026)+'-'+RTRIM(^0.TA027)+'-'+RTRIM(^0.TA028)", "銷售訂單")
          sqlCV.SqlFields("^0.TA009", "預計開工")
          sqlCV.SqlFields("^0.TA010", "預計完工")
          sqlCV.SqlFields("^0.TA011", "狀態")
          sqlCV.SqlFields("^0.TA029", "備註")
          sqlCV.sqlOrder("TA002", SQLCNV.intOrder.Order_Dsc)
#ElseIf K3 = 3 Then
          sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "MF_MO", , "TOP 200")
          If strKey <> "" Then
            sqlCV.Where("^0.MO_NO", "Like", strKey.Trim & "%")
          End If
          'sqlCV.Where("^0.CLOSE_ID", "NOT IN", "'t','T'", intFMode.msfld_field)
          sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "PRDT", "PRD_NO", "=", "^0.MRP_NO")
          sqlCV.SqlFields("^0.MO_NO", "工單編號")
          sqlCV.SqlFields("^0.MRP_NO", "製品編號")
          sqlCV.SqlFields("^1.NAME", "品名")
          sqlCV.SqlFields("^1.SPC", "規格")
          sqlCV.SqlFields("^0.QTY", "數量")
          sqlCV.SqlFields("^0.BIL_NO", "來源單號")
          sqlCV.SqlFields("^0.STA_DD", "預計開工")
          sqlCV.SqlFields("^0.END_DD", "預計完工")
          sqlCV.SqlFields("^0.CLOSE_ID", "狀態")
          sqlCV.SqlFields("^0.REM", "備註")
          sqlCV.sqlOrder("^0.MO_NO", SQLCNV.intOrder.Order_Dsc)
#End If
          Dim rs As DataTable = DBERP.RsSQL(BIG2GB(sqlCV.Text), "ERPRT")
          DG.DataSource = rs
        Case 1

      End Select
    End Set
  End Property

  Private Sub DG_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG.CellContentClick
    If e.RowIndex < 0 Or e.RowIndex > DG.Rows.Count Then Return
    Me.DialogResult = Windows.Forms.DialogResult.OK
    rp = DG.Rows(e.RowIndex)
    Me.Close()
  End Sub

  Private Sub DG_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DG.CellFormatting
    Select Case intMode
      Case 0
        Select Case e.ColumnIndex
          Case 3
            e.Value = GCell(DG.Rows(e.RowIndex).Cells(e.ColumnIndex)).TrimEnd("0").TrimEnd(".")
#If K3 = 1 Then
          Case 8
            Select Case GCell(DG.Rows(e.RowIndex).Cells(e.ColumnIndex))
              Case "0"
                e.Value = "未開工"
              Case "1"
                e.Value = "已生產"
            End Select
#ElseIf K3 = 2 Then
          Case 7
            Select Case GCell(DG.Rows(e.RowIndex).Cells(e.ColumnIndex))
              Case "1"
                e.Value = "未開工"
              Case "2"
                e.Value = "已發料"
              Case "3"
                e.Value = "已生產"
              Case "Y", "y"
                e.Value = "完工"
            End Select
#End If
        End Select
    End Select
  End Sub

  Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
    If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
      e.Handled = True
      My.Computer.Keyboard.SendKeys(vbTab)
    End If
  End Sub

  Private Sub TextBox1_Validated(sender As Object, e As EventArgs) Handles TextBox1.Validated
    If TextBox1.Text.Trim = "" Then Return
    If DBERP Is Nothing OrElse DBERP.Active = False Then Return
    rs = DBERP.GetRs("ERPRT", "??" & TextBox1.Text.Trim)
    DG.DataSource = rs
  End Sub

  Private Sub FrmERP_DLG_Load(sender As Object, e As EventArgs) Handles MyBase.Load

  End Sub
End Class