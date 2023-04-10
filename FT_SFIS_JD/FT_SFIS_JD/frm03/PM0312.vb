Public Class PM0312
  Private WithEvents cs As clsEDIT2012.clsEDITx2013
  Private strMask As String = ""
  Private bolSingle As Boolean = False
  Private bolLock As Boolean = False
  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()

    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    languagechange(Me)
  End Sub
  Private Sub DownLoad()
    Dim OFL As New OpenFileDialog
    OFL.Title = BIG2GB("請選擇導入檔案")
    If My.Settings.XLSPATH = "" Then
      OFL.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
    Else
      OFL.InitialDirectory = IO.Path.GetDirectoryName(My.Settings.XLSPATH)
    End If
    OFL.Filter = "Excel檔案|*.xls;*.xlsx|所有檔案|*.*"
    OFL.FileName = ""
    If OFL.ShowDialog = Windows.Forms.DialogResult.OK Then
      Try
        Dim xs As New XLS_FILE(OFL.FileName)
        Dim sqlCV As New APSQL.SQLCNV
        Dim intNew As Integer = 0
        Dim rs As DataTable = xs.XLS2Rs(0)
        xs.Quit()
        If rs.Rows.Count = 0 Then Return
        For Each r As DataRow In rs.Rows
          sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_User")
          sqlCV.Where("UserCode", "=", r.Item(0).ToString.Trim)
          sqlCV.SqlFields("*")
          Dim rs1 As DataTable = DB.RsSQL(sqlCV.Text, "RT")
          If rs1.Rows.Count = 0 Then
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_User")
            sqlCV.SqlFields("UserCode", r.Item(0).ToString.Trim)
            sqlCV.SqlFields("UserName", r.Item(1).ToString.Trim)
            sqlCV.SqlFields("Juese", r.Item(2).ToString.Trim.Split("^")(0))
            sqlCV.SqlFields("Access", r.Item(2).ToString.Trim)
            sqlCV.SqlFields("PassWord", r.Item(0).ToString.Trim)
            DB.RsSQL(sqlCV.Text)
          Else
            If r.Item(1).ToString.Trim <> rs1.Rows(0)!UserName.ToString.Trim Or
              r.Item(2).ToString.Trim <> rs1.Rows(0)!Access.ToString.Trim Then
              If intNew = 0 Then
                If MsgBox(BIG2GB("資料重複是否要複寫？"), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                  intNew = 1
                Else
                  intNew = -1
                End If
              End If
              If intNew = 1 Then
                sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_update, "SFIS_User")
                sqlCV.Where("UserCode", "=", r.Item(0).ToString.Trim)
                sqlCV.SqlFields("UserName", r.Item(1).ToString.Trim)
                sqlCV.SqlFields("Juese", r.Item(2).ToString.Trim.Split("^")(0))
                sqlCV.SqlFields("Access", r.Item(2).ToString.Trim)
                DB.RsSQL(sqlCV.Text)
              End If
            End If
          End If
        Next
      Catch ex As Exception
        MsgBox(ex.Message)
      End Try
    End If
    cs.Updated = True
    cs.Clean()
    MsgBox(BIG2GB("導入完成"))
  End Sub
  Private Sub PM0312_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    TuiCK(Me)
  End Sub

  Private Sub PM0312_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    strMask = Me.Tag
    bolSingle = clsRTS.GetRight(strMask & "/004")
    cs = New clsEDIT2012.clsEDITx2013(DG, DB, language)
    cs.AddToolsItem("導入Excel", My.Resources.XDOWN, AddressOf DownLoad)
    cs.ShowSearch = True
    cs.Clean()
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_JueSe")
    sqlCV.SqlFields("JueSeCode + ' ' + JueSeName", "DATAS")
    sqlCV.SqlFields("JueSeCode", "KEYS", , , True)
    sqlCV.SqlFields("Access")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "JueSe")
    CLB.Items.Clear()
    For Each r As DataRow In rs.Rows
      CLB.Items.Add(r!DATAS.ToString)
    Next
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

  Private Sub Tw_AfterCheck(sender As Object, e As TreeViewEventArgs)
    If e.Node.Name.StartsWith("00") = False Then
      ReNodes(e.Node.Parent)
    End If
  End Sub

  Private Sub cs_DVSelect(s As clsEDIT2012.clsEDITx2013, r As DataGridViewRow) Handles cs.DVSelect
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_User")
    sqlCV.Where("UserCode", "=", GCell(r.Cells(0)))
    sqlCV.SqlFields("*")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count = 0 Then
      Return
    Else
      TextBox1.Text = rs.Rows(0)!UserCode.ToString.Trim
      TextBox2.Text = rs.Rows(0)!UserName.ToString.Trim
      TextBox3.Text = rs.Rows(0)!PassWord.ToString.Trim
      Dim strV() As String = rs.Rows(0)!Access.ToString.Trim.Split("^")
      Dim aryT As New ArrayList
      aryT.AddRange(strV)
      For intI As Integer = 0 To CLB.Items.Count - 1
        Dim strK() As String = CLB.Items(intI).ToString.Split(" ")
        If aryT.Contains(strK(0)) Or strV(0).ToUpper = "ALL" Then
          CLB.SetItemChecked(intI, True)
        Else
          CLB.SetItemChecked(intI, False)
        End If
      Next
    End If
  End Sub

  Private Sub cs_DVTable(s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles cs.DVTable
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_User")
    If bolSingle = False Then
      sqlCV.Where("UserCode", "=", lgncode)
      TextBox1.Enabled = False
      CLB.Enabled = False
    Else
      TextBox1.Enabled = True
      CLB.Enabled = True
    End If
    sqlCV.SqlFields("UserCode", "用戶編號")
    sqlCV.SqlFields("UserName", "用戶姓名")
    sqlCV.SqlFields("Access", "角色編號")
    strSQL = BIG2GB(sqlCV.Text)
  End Sub

  Private Sub cs_Frm_CheckDup(s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles cs.Frm_CheckDup
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_User")
    sqlCV.Where("UserCode", "=", TextBox1.Text)
    sqlCV.SqlFields("UserCode")
    strSQL = sqlCV.Text
  End Sub

  Private Sub cs_Frm_Clear(s As clsEDIT2012.clsEDITx2013) Handles cs.Frm_Clear
    TextBox1.Text = ""
    TextBox2.Text = ""
    TextBox3.Text = ""
    For intI As Integer = 0 To CLB.Items.Count - 1
      CLB.SetItemChecked(intI, False)
    Next
  End Sub

  Private Sub cs_Frm_Delete(s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String, ByRef bolOK As Boolean) Handles cs.Frm_Delete
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TM")
    sqlCV.Where("TM03", "Like", "%" & TextBox1.Text.Trim & "%")
    sqlCV.SqlFields("*")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count > 0 Then
      MsgBox(BIG2GB("用戶已經被指派無法刪除"), , Me.Text)
      Return
    End If
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TMA")
    sqlCV.Where("TMA07", "Like", "%" & TextBox1.Text.Trim & "%")
    sqlCV.SqlFields("*")
    rs = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count > 0 Then
      MsgBox(BIG2GB("用戶已經被指派無法刪除"), , Me.Text)
      Return
    End If
    If MsgBox(BIG2GB("是否刪除這個用戶"), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Return
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_delete, "SFIS_User")
    sqlCV.Where("UserCode", "=", TextBox1.Text)
    strSQL = sqlCV.Text
    bolOK = True
  End Sub
  Private Function GetAccess() As String
    Dim strM As String = ""
    For Each strK As String In CLB.CheckedItems
      Dim strV() As String = strK.Split(" ")
      strM &= strV(0) & "^"
    Next
    Return strM.Trim("^")
  End Function
  Private Sub cs_Frm_InsertM(s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles cs.Frm_InsertM
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "SFIS_User")
    sqlCV.SqlFields("UserCode", TextBox1.Text.Trim)
    sqlCV.SqlFields("UserName", TextBox2.Text.Trim)
    sqlCV.SqlFields("PassWord", TextBox3.Text.Trim)
    Dim strM As String = GetAccess()
    sqlCV.SqlFields("Juese", strM.Split("^")(0))
    sqlCV.SqlFields("Access", strM)
    strSQL = sqlCV.Text
  End Sub

  Private Sub cs_Frm_UpdateM(s As clsEDIT2012.clsEDITx2013, ByRef strSQL As String) Handles cs.Frm_UpdateM
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_update, "SFIS_User")
    sqlCV.Where("UserCode", "=", TextBox1.Text.Trim)
    sqlCV.SqlFields("UserName", TextBox2.Text.Trim)
    sqlCV.SqlFields("PassWord", TextBox3.Text.Trim)
    Dim strM As String = GetAccess()
    sqlCV.SqlFields("Juese", strM.Split("^")(0))
    sqlCV.SqlFields("Access", strM)
    strSQL = sqlCV.Text
  End Sub

  Private Sub cs_isDataValid(s As clsEDIT2012.clsEDITx2013, ByRef bolOK As Boolean) Handles cs.isDataValid
    If TextBox1.Text.Trim = "" Then
      MsgBox(BIG2GB("用戶編號不得空白"))
      Return
    End If
    If CLB.CheckedItems.Count = 0 Then
      MsgBox(BIG2GB("角色不得空白"))
    End If
    bolOK = True
  End Sub

  Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress, TextBox2.KeyPress, TextBox3.KeyPress
    If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
      e.Handled = True
      My.Computer.Keyboard.SendKeys(vbTab)
    End If
  End Sub

  Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles TextBox1.LostFocus
    For Each r As DataGridViewRow In DG.Rows
      If GCell(r.Cells(0)) = TextBox1.Text.Trim Then
        cs_DVSelect(cs, r)
        Return
      End If
    Next
  End Sub
End Class