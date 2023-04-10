Public Class PM0313
  Dim WithEvents cs As clsEDIT2012.clsEDITx2013

  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()

    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    languagechange(Me)
  End Sub
  Private Sub PM0313_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    TuiCK(Me)
  End Sub

  Private Sub Frm030902_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    If clsRTS IsNot Nothing Then
      clsRTS.MakeTree(Tw)
    End If
    cs = New clsEDIT2012.clsEDITx2013(DG, DB, language)
    cs.Clean()
  End Sub
  Private Sub ReNodes(tn As TreeNode)
    If tn Is Nothing OrElse tn.Nodes.Count = 0 Then Return
    Dim bolT As Boolean = False
    For Each tn1 As TreeNode In tn.Nodes
      bolT = bolT Or tn1.Checked
    Next
    tn.Checked = bolT
    ReNodes(tn.Parent)
  End Sub

  Private Sub Tw_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles Tw.AfterCheck
    If e.Node.Name.StartsWith("00") = False Then
      ReNodes(e.Node.Parent)
    End If
  End Sub
  Private Sub ShowData(strKey As String)
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_JueSe")
    sqlCV.Where("JueSeCode", "=", strKey)
    sqlCV.SqlFields("*")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count = 0 Then
      Return
    End If
    If rs.Rows(0)!Yuliul.ToString.Trim <> "SFC" Then
      MsgBox(BIG2GB("這個權限代碼已經被WMS使用"))
      cs_Frm_Clear(Nothing)
    Else
      TextBox1.Text = rs.Rows(0)!JueSeCode.ToString.Trim
      TextBox2.Text = rs.Rows(0)!JueSeName.ToString.Trim
      TextBox1.Enabled = False
      clsRTS.MakeChecked(Tw, rs.Rows(0)!Access.ToString.Trim)
    End If
  End Sub
  Private Sub cs_DVSelect(s As clsEDIT2012.clsEDITx2013, r As DataGridViewRow) Handles cs.DVSelect
    ShowData(GCell(r.Cells(0)))
  End Sub

  Private Sub cs_DVTable(s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles cs.DVTable
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_JueSe")
    sqlCV.Where("Yuliul", "=", "SFC")
    sqlCV.SqlFields("JueSeCode", "角色編號")
    sqlCV.SqlFields("JueSeName", "角色名稱")
    strSQL = BIG2GB(sqlCV.Text)
  End Sub

  Private Sub cs_Frm_CheckDup(s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles cs.Frm_CheckDup
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_JueSe")
    sqlCV.Where("JueSeCode", "=", TextBox1.Text)
    sqlCV.SqlFields("JueSeCode")
    strSQL = sqlCV.Text
  End Sub

  Private Sub cs_Frm_Clear(s As clsEDIT2012.clsEDITx2013) Handles cs.Frm_Clear
    TextBox1.Text = ""
    TextBox2.Text = ""
    TextBox1.Enabled = True
    TextBox2.Enabled = True
    clsRTS.MakeChecked(Tw, "")
  End Sub

  Private Sub cs_Frm_Delete(s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String, ByRef bolOK As Boolean) Handles cs.Frm_Delete
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_User")
    sqlCV.Where("JueSe", "=", TextBox1.Text.Trim)
    sqlCV.SqlFields("*")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count > 0 Then
      MsgBox(BIG2GB("角色已經被指派無法刪除"), , Me.Text)
      Return
    End If
    If MsgBox(BIG2GB("是否刪除這個角色"), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Return
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_delete, "SFIS_JueSe")
    sqlCV.Where("JueSeCode", "=", TextBox1.Text)
    strSQL = sqlCV.Text
    bolOK = True
  End Sub

  Private Sub cs_Frm_InsertM(s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles cs.Frm_InsertM
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "SFIS_JueSe")
    sqlCV.SqlFields("JueSeCode", TextBox1.Text.Trim)
    sqlCV.SqlFields("JueSeName", TextBox2.Text.Trim)
    sqlCV.SqlFields("Access", clsRTS.ReadChecked(Tw))
    sqlCV.SqlFields("Yuliul", "SFC")
    strSQL = sqlCV.Text
  End Sub

  Private Sub cs_Frm_UpdateM(s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles cs.Frm_UpdateM
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_update, "SFIS_JueSe")
    sqlCV.Where("JueSeCode", "=", TextBox1.Text.Trim)
    sqlCV.SqlFields("JueSeName", TextBox2.Text.Trim)
    sqlCV.SqlFields("Access", clsRTS.ReadChecked(Tw))
    sqlCV.SqlFields("Yuliul", "SFC")
    strSQL = sqlCV.Text
  End Sub

  Private Sub cs_isDataValid(s As clsEDIT2012.clsEDITx2013, ByRef bolOK As Boolean) Handles cs.isDataValid
    If TextBox1.Text.Trim = "" Then
      MsgBox(BIG2GB("角色編號不得空白"))
      Return
    End If
    bolOK = True
  End Sub

  Private Sub TextBox1_Validated(sender As Object, e As EventArgs) Handles TextBox1.Validated
    If TextBox1.Text.Trim <> "" Then
      ShowData(TextBox1.Text.Trim)
    End If
  End Sub
End Class