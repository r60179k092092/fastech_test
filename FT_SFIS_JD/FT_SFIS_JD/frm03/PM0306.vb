Imports APSQL

Public Class PM0306
  Dim Dwuliao As FrmDialog
  Private sqlCV As New APSQL.SQLCNV
  Private WithEvents s1 As clsEDIT2012.clsEDIT2012
  Private aryTB As New Dictionary(Of String, String)
  Private bolLock As Boolean = False
  Sub New()
    ' 此調用是設計器所必需的。
    InitializeComponent()
    ' 在 InitializeComponent() 調用之后添加任何初始化。
    languagechange(Me)
    TBC1.TabPages(0).Text = BIG2GB(TBC1.TabPages(0).Text)
    dgdaochu(DGXM)
  End Sub

  Private Sub PM0306_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    TuiCK(Me)
  End Sub

  Private Sub PM0306_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    s1 = New clsEDIT2012.clsEDIT2012(TBC1, DB, language, False, "SFIS_QJB")
    ''讀取 參照文件編號 放入combobox2中
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QJ")
    sqlCV.SqlFields("QJ01", "SDGSDG")
    ComboBox2.DataSource = DB.RsSQL(sqlCV.Text, "DFSD")
    ComboBox2.DisplayMember = "SDGSDG"
    bolLock = True
    'sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TA")
    'sqlCV.SqlFields("TA01", "工序編號")
    'dggxcolumns.DataSource = DB.RsSQL(sqlCV.Text, "SFIS_TA")
    'dggxcolumns.DisplayMember = "工序編號"
    'dggxcolumns.HeaderText = "工序編號"
    Dwuliao = getwuliao(" ISNULL(TBB01,'') <> ''")
    s1.Clean()
    'sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TBB")
    'sqlCV.SqlFields("TBB03", , , , True)
    'sqlCV.SqlFields("TBB05+' '+TBB06", "V1")
    'Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    'For Each r As DataRow In rs.Rows
    '  aryTB.Add(r!TBB03.ToString.Trim, r!V1.ToString.Trim)
    'Next

    s1.GetToolsItem("Delete").Enabled = clsRTS.GetRight(Me.Tag & "/003")
    s1.GetToolsItem("save").Enabled = clsRTS.GetRight(Me.Tag & "/001")
  End Sub
  Private Sub Load_Data(strK1 As String, strK2 As String)
    If strK1 = "" Then
      Dim rg As DataTable = DGXM.DataSource
      If rg IsNot Nothing Then
        rg.Rows.Clear()
        DGXM.DataSource = rg
        Return
      End If
      ComboBox2.Text = ""
      TextBox1.Text = ""
      SPEC.Text = ""
      DGXM.Enabled = False
      Return
    End If
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QJA")
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "SFIS_TA", "TA01", "=", "SFIS_QJA.QJA12")
    sqlCV.Where("^0.QJA01", "=", strK1)
    sqlCV.SqlFields("Convert(Bit,0)", "選擇")
    sqlCV.SqlFields("^0.QJA02", "項次編號", , , True)
    sqlCV.SqlFields("^0.QJA03", "中文說明")
    sqlCV.SqlFields("^0.QJA05", "量測工具")
    sqlCV.SqlFields("^0.QJA06", "量測單位")
    sqlCV.SqlFields("^1.TA01 +'|'+^1.TA02", "工序")
    sqlCV.SqlFields("('')", "標準值")
    sqlCV.SqlFields("('')", "誤差上限")
    sqlCV.SqlFields("('')", "誤差下限")
    sqlCV.SqlFields("('')", "報表顯示")
    sqlCV.SqlFields("('')", "螢幕顯示")
    Dim rs As DataTable = DB.RsSQL(BIG2GB(sqlCV.Text), "QJB")
    Dim aryL1 As New ArrayList
    If strK2.Trim <> "" Then
      Dim aryL As New Dictionary(Of String, DataRow)
      For Each r As DataRow In rs.Rows
        aryL.Add(r.Item(1).ToString.Trim, r)
      Next
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QJB")
      sqlCV.Where("QJB01", "=", strK1)
      sqlCV.Where("QJB02", "=", strK2)
      sqlCV.SqlFields("*")
      Dim rs1 As DataTable = DB.RsSQL(sqlCV.Text, "RT")
      For Each r As DataRow In rs1.Rows
        Dim strK As String = r!QJB04.ToString.Trim
        If aryL.ContainsKey(strK) Then
          With aryL(strK)
            .Item(0) = True
            .Item(6) = r!QJB05.ToString.Trim
            .Item(7) = r!QJB06.ToString.Trim
            .Item(8) = r!QJB07.ToString.Trim
            .Item(9) = r!QJB08.ToString.Trim
            .Item(10) = r!QJB09.ToString.Trim
          End With
        End If
      Next
      If CheckBox1.Checked = True Then
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_distinc, "SFIS_TBB")
        sqlCV.Where("TBB03", "=", strK2)
        Dim w As APSQL.SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TBA", "TBA01", "=", "SFIS_TBB.TBB01")
        w.Add("SFIS_TBA.TBA02", "=", "SFIS_TBB.TBB02")
        sqlCV.SqlFields("^1.TBA04")
        rs1 = DB.RsSQL(sqlCV.Text, "RT")
        For Each r As DataRow In rs1.Rows
          aryL1.Add(r!TBA04.ToString.Trim)
        Next
      End If
    End If
    DGXM.DataSource = rs
    ComboBox2.Text = strK1
    TextBox1.Text = strK2
    If aryTB.ContainsKey(strK2) = True Then
      SPEC.Text = aryTB(strK2)
    Else
      SPEC.Text = ""
    End If
    For i As Integer = 0 To DGXM.ColumnCount - 1
      DGXM.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
    Next
    DGXM.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    DGXM.Refresh()
    DGXM.Columns(1).ReadOnly = True
    DGXM.Columns(2).ReadOnly = True
    DGXM.Columns(3).ReadOnly = True
    DGXM.Columns(4).ReadOnly = True
    DGXM.Columns(5).ReadOnly = True
    DGXM.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
    'DGXM.Columns(1).DefaultCellStyle.ForeColor = Color.Red
    'DGXM.Columns(2).DefaultCellStyle.ForeColor = Color.Red
    'DGXM.Columns(3).DefaultCellStyle.ForeColor = Color.Red
    'DGXM.Columns(4).DefaultCellStyle.ForeColor = Color.Red
    'DGXM.Columns(5).DefaultCellStyle.ForeColor = Color.Red
    For Each r As DataGridViewRow In DGXM.Rows
      If aryL1.Count > 0 Then
        Dim strV() As String = GCell(r.Cells(5)).Split("|")
        If aryL1.Contains(strV(0)) = False Then
          r.Cells(0).Value = False
          r.DefaultCellStyle.ForeColor = Color.LightGray
          r.ReadOnly = True
        End If
      End If
      If r.Cells(0).Value = True Then
        r.DefaultCellStyle.BackColor = Color.LightGreen
      End If
    Next
    DGXM.Refresh()
    If strK1 <> "" And strK2 <> "" Then
      DGXM.Enabled = True
    Else
      DGXM.Enabled = False
    End If
    DGXM.AppendBegin()
  End Sub
  ''選擇 tab 2
  Private Sub s1_DVSelect(ByVal s As clsEDIT2012.clsEDIT2012, ByVal r As System.Windows.Forms.DataGridViewRow) Handles s1.DVSelect
    Load_Data(GCell(r.Cells(0)), GCell(r.Cells(1)))
  End Sub
  ''顯示 tab 2 數據
  Private Sub s1_DVTable(ByVal s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String) Handles s1.DVTable
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_distinc, "SFIS_QJB")
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "SFIS_TBB", "TBB03", "=", "SFIS_QJB.QJB02")
    sqlCV.SqlFields("^0.QJB01", "檢驗類型")
    sqlCV.SqlFields("^0.QJB02", "物料編號")
    sqlCV.SqlFields("^1.TBB05+' '+^1.TBB06", "品名規格")
    sqlCV.SqlFields("^1.TBB01", "流程編號")
    sqlCV.SqlFields("^1.TBB02", "流程版次")
    If CheckBox1.Checked = True Then
      s1.Querys = "ISNULL(" & BIG2GB("流程編號") & ",'')<>''"
    Else
      s1.Querys = ""
    End If
    strSQL = BIG2GB(sqlCV.Text)
  End Sub
  '' 保存檢驗數據
  Private Sub s1_isDataValid(ByVal s As clsEDIT2012.clsEDIT2012, ByRef bolOK As Boolean) Handles s1.isDataValid
    DGXM.EndEdit()
    If TextBox1.Text = "" Then
      MsgBox(BIG2GB("物料編號不得空白"), MsgBoxStyle.OkOnly, BIG2GB("提示"))
      TextBox1.Focus()
      bolOK = False
      Exit Sub
    End If

    'If ComboBox2.Text.Substring(0, 2) <> "PE" Then
    '    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "inventory")
    '    sqlCV.Where("cinvccode", "like", "04%")
    '    sqlCV.Where("cinvcode", "like", TextBox2.Text & "%")
    '    sqlCV.Where("cinvname", "=", TextBox1.Text)
    '    sqlCV.SqlFields("count(*)")
    '    Dim dt As DataTable = DB1.RsSQL(sqlCV.Text, "sdf")
    '    If dt.Rows(0).Item(0).ToString = "0" Then
    '        MsgBox("內部編號或型號有誤請檢查,保存失敗", MsgBoxStyle.OkOnly, BIG2GB("提示"))
    '        bolOK = False
    '        TextBox2.Focus()
    '        TextBox2.SelectAll()
    '        Exit Sub
    '    End If
    'End If
    bolOK = True
  End Sub
  ''保存 檢驗數據是否存在
  Private Sub s1_Frm_CheckDup(ByVal s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String) Handles s1.Frm_CheckDup
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_distinc, "SFIS_QJB")
    sqlCV.Where("QJB01", "=", ComboBox2.Text)
    sqlCV.Where("QJB02", "=", TextBox1.Text)
    sqlCV.SqlFields("QJB02")
    strSQL = sqlCV.Text
  End Sub
  ''保存 存在 更新數據
  Private Sub s1_Frm_UpdateM(ByVal s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String, ByRef intR As Integer) Handles s1.Frm_UpdateM
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_delete, "SFIS_QJB")
    sqlCV.Where("QJB01", "=", ComboBox2.Text)
    sqlCV.Where("QJB02", "=", TextBox1.Text)
    DB.RsSQL(sqlCV.Text)
    JIA()
  End Sub
  ''保存 不存在 保存數據
  Private Sub s1_Frm_InsertM(ByVal s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String, ByRef intR As Integer) Handles s1.Frm_InsertM
    JIA()
  End Sub
  Private Sub JIA()
    For Each dgr As DataGridViewRow In DGXM.Rows
      If isCellNull(dgr.Cells(0)) = False AndAlso dgr.Cells(0).Value = True Then
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_QJB")
        sqlCV.SqlFields("QJB01", ComboBox2.Text)
        sqlCV.SqlFields("QJB02", TextBox1.Text)
        sqlCV.SqlFields("QJB03", "")
        sqlCV.SqlFields("QJB04", GCell(dgr.Cells(1)))
        sqlCV.SqlFields("QJB05", GCell(dgr.Cells(6)))
        sqlCV.SqlFields("QJB06", GCell(dgr.Cells(7)))
        sqlCV.SqlFields("QJB07", GCell(dgr.Cells(8)))
        sqlCV.SqlFields("QJB08", GCell(dgr.Cells(9)))
        sqlCV.SqlFields("QJB09", GCell(dgr.Cells(10)))
        DB.RsSQL(sqlCV.Text, "RTE")
      End If
    Next
    s1.Updated = True
  End Sub
  ''刪除
  Private Sub s1_Frm_Delete(ByVal s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String, ByRef bolOK As Boolean) Handles s1.Frm_Delete
    If MsgBox(BIG2GB("是否刪除數據"), MsgBoxStyle.OkCancel, BIG2GB("提示")) = MsgBoxResult.Ok Then
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_delete, "SFIS_QJB")
      sqlCV.Where("QJB01", "=", ComboBox2.Text)
      sqlCV.Where("QJB02", "=", TextBox1.Text)
      strSQL = sqlCV.Text
      bolOK = True
    End If
  End Sub
  ''清空
  Private Sub s1_Frm_Clear(ByVal s As clsEDIT2012.clsEDIT2012) Handles s1.Frm_Clear
    Load_Data("", "")
  End Sub

  Private Sub dg_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGXM.CellEndEdit
    Select Case e.ColumnIndex
      Case 0
        If DGXM.CurrentRow Is Nothing Then Return
        If DGXM.CurrentRow.Cells(0).Value = True Then
          DGXM.CurrentRow.DefaultCellStyle.BackColor = Color.LightGreen
        Else
          DGXM.CurrentRow.DefaultCellStyle.BackColor = Color.White
        End If
      Case 6
        Dim strM As String = GCell(DGXM.Rows(e.RowIndex).Cells(e.ColumnIndex))
        strM = strM.Replace("-+", "±").Replace("+-", "±")
        DGXM.CurrentCell.Value = strM
    End Select
  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    If Dwuliao.ShowDialog = DialogResult.OK Then
      TextBox1.Text = Dwuliao.rw.Cells(0).Value
      If aryTB.ContainsKey(TextBox1.Text.Trim) = True Then
        SPEC.Text = aryTB(TextBox1.Text.Trim)
      Else
        SPEC.Text = ""
      End If
      Load_Data(ComboBox2.Text.Trim, TextBox1.Text.Trim)
    End If
  End Sub

  Private Sub ComboBox2_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBox2.SelectionChangeCommitted
    Load_Data(ComboBox2.Text, TextBox1.Text.Trim)
  End Sub

  Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
    If s1 Is Nothing Or bolLock = False Then Return
    If CheckBox1.Checked = True Then
      Dwuliao = getwuliao(" isnull(tbb01,'') <> ''")
      s1.Querys = "ISNULL(" & BIG2GB("流程編號") & ",'')<>''"
    Else
      Dwuliao = getwuliao("")
      s1.Querys = ""
    End If
  End Sub

  Private Sub DGXM_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGXM.CellContentClick

  End Sub
End Class