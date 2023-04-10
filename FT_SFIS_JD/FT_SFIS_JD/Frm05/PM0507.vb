Imports APSQL
Public Class PM0507
  Dim wuliaochaxun As New DataTable
  Dim t3, t4 As Boolean '標識是否使用二次選擇
  Dim intDMode As Integer = 0 '標識是否為MO工單
  Dim MOgd As String = ""
  Private MOmateral As String = ""  '標識當前選擇的工單號
  Dim MOnum As Int64 = 0 '選擇工單的生產數量
  Dim MOjianyanxiangmu As New Dictionary(Of String, String)
  Dim wuliaoName As New Dictionary(Of String, String)
  Private aryIDs As String = ""
  Private clsXLS As XLS_FILE = Nothing
  Private aryCName As New Dictionary(Of String, String) 'CustID ,CustName
  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()

    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    languagechange(Me)
  End Sub
  Private Sub FrmChanPinZhuiZong_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    WindowState = FormWindowState.Maximized
  End Sub

  Private Sub PM0507_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    TuiCK(Me)
  End Sub
  '‘load
  Private Sub PM0601_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    WindowState = FormWindowState.Maximized
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_distinc, "SFIS_TD")
    sqlCV.Where("TD12", "IN", "1,2,3", intFMode.msfld_field)
    sqlCV.SqlFields("TD01", "DATAS")
    sqlCV.sqlOrder("TD01", SQLCNV.intOrder.Order_Dsc)
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "D1")
    ComboBox3.DisplayMember = "DATAS"
    ComboBox3.ValueMember = "DATAS"
    ComboBox3.DataSource = rs
    ComboBox3.SelectedIndex = -1
    wuliaochaxun.Columns.Add("DataColumn1")   '層次
    wuliaochaxun.Columns.Add("DataColumn2")  '單據類項
    wuliaochaxun.Columns.Add("DataColumn3")  '物料
    wuliaochaxun.Columns.Add("DataColumn4")  '批次
    wuliaochaxun.Columns.Add("DataColumn5")   '批序號
    wuliaochaxun.Columns.Add("DataColumn6")  '製造日期
    wuliaochaxun.Columns.Add("DataColumn7")  '備註
    wuliaochaxun.Columns.Add("DataColumn8")  '供應商
    wuliaochaxun.Columns.Add("DataColumn9")  '物料名字
    wuliaochaxun.Columns.Add("DataColumn10") '物料類別
    wuliaochaxun.Columns.Add("DataColumn11") '原批號
    wuliaochaxun.Columns.Add("DataColumn12") '驗收日期
    dgdaochu(DGblfx)
    dgdaochu(dggd)
    dgdaochu(dggdbom)
    dgdaochu(Dggdfl)
    dgdaochu(Dggdmx)
    dgdaochu(dgqcjl)
    dgdaochu(dgscjl)
    dgdaochu(dgyljl)
    dgdaochu(fqcjl)
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TBB")
    sqlCV.SqlFields("TBB03", , , , True)
    sqlCV.SqlFields("TBB05")
    sqlCV.SqlFields("TBB06")
    Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    wuliaoName.Clear()
    For Each r As DataRow In dt.Rows
      wuliaoName.Add(r!TBB03.ToString.Trim, r!TBB05.ToString.Trim & " " & r!TBB06.ToString.Trim)
    Next
    DB.CloseRs(dt)
    aryCName.Clear()
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TS")
    sqlCV.Where("TS01", "=", "INV_SUP")
    sqlCV.SqlFields("*")
    Dim rsV As DataTable = DB.RsSQL(sqlCV.Text, "RS")
    For Each r As DataRow In rsV.Rows
      aryCName.Add(r!TS02.ToString, r!TS03.ToString)
    Next
  End Sub
  '‘關閉
  Private Sub ToolStripButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton10.Click
    Me.Close()
  End Sub

#Region "狀態 formatting"
  ''生產PPID明細
  Private Sub dggdmx_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles Dggdmx.CellFormatting
    Select Case intDMode
      Case 0
        If e.ColumnIndex = 8 Then
          Select Case e.Value
            Case 0
              If ",1,2,3,8,".Contains("," & GCell(Dggdmx.Rows(e.RowIndex).Cells(7)) & ",") = False Then
                e.Value = BIG2GB("合格")
              Else
                e.Value = BIG2GB("未檢")
              End If
            Case 1
              e.Value = BIG2GB("合格")
            Case 2
              e.Value = BIG2GB("不良")
            Case 3
              e.Value = BIG2GB("返工")
            Case 4
              e.Value = BIG2GB("特采")
            Case 8
              e.Value = BIG2GB("報廢")
          End Select
        End If
        If e.ColumnIndex = 7 Then
          Select Case Val(e.Value.ToString)
            Case 0
              e.Value = BIG2GB("正常")
            Case 1
              e.Value = BIG2GB("送修")
            Case 2
              e.Value = BIG2GB("返工")
            Case 3
              e.Value = BIG2GB("暫停")
            Case 4
              e.Value = BIG2GB("完工")
            Case 5
              e.Value = BIG2GB("出貨")
            Case 7
              e.Value = BIG2GB("下層綁定")
            Case 8
              e.Value = BIG2GB("報廢")
            Case 100
              e.Value = BIG2GB("底面ID")
            Case Else
          End Select
        End If
      Case 1
        If e.ColumnIndex = 8 Then
          Select Case e.Value
            Case 0
              If Dggdmx.Rows(e.RowIndex).Cells(7).Value.ToString.Length = 0 Then
                e.Value = BIG2GB("生產")
              Else
                e.Value = "IPQC"
              End If
            Case 2
              e.Value = BIG2GB("生產")
            Case 3
              e.Value = "FQC"
            Case 4
              e.Value = BIG2GB("返工")
            Case 6
              e.Value = BIG2GB("已入庫")
          End Select
        End If
    End Select
  End Sub
  '’工單狀態
  Private Sub dgfrmat(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles dggd.CellFormatting
    If e.ColumnIndex = 2 Then
      Select Case e.Value
        Case 0
          e.Value = "NEW"
        Case 1
          e.Value = BIG2GB("生產中")
        Case 2
          e.Value = BIG2GB("完工")
        Case 3
          e.Value = BIG2GB("暫停")
        Case 8
          e.Value = BIG2GB("作廢")
      End Select
    End If
  End Sub
  '’生產記錄
  Private Sub dgscj(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles dgscjl.CellFormatting
    Select Case intDMode
      Case 0
        If e.ColumnIndex = 5 Then
          Dim intI As Integer = Val(GCell(dgscjl.Rows(e.RowIndex).Cells(e.ColumnIndex)))
          Select Case intI
            Case 0
              e.Value = BIG2GB("正常")
            Case 1
              e.Value = BIG2GB("IPQC不良")
            Case 2
              e.Value = BIG2GB("不良")
            Case 3
              e.Value = BIG2GB("FQA")
            Case 4
              e.Value = BIG2GB("返工")
            Case 5
              e.Value = BIG2GB("FQA不良")
            Case 6
              e.Value = BIG2GB("入庫")
            Case 8
              e.Value = BIG2GB("維修換料")
          End Select
        End If
    End Select
  End Sub
  '’QC及FQC記錄
  Private Sub dgqcj(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles dgqcjl.CellFormatting, fqcjl.CellFormatting
    Select Case intDMode
      Case 1
        If e.ColumnIndex = 3 Then
          Select Case e.Value
            Case "0"
              e.Value = BIG2GB("良品")
            Case "1"
              e.Value = BIG2GB("IPQC不良")
            Case "2"
              e.Value = BIG2GB("自檢不良")
            Case "3"
              e.Value = BIG2GB("FQC檢驗")
            Case "4"
              e.Value = BIG2GB("返工")
            Case "6"
              e.Value = BIG2GB("入庫")
          End Select
        End If
    End Select
  End Sub
#End Region
#Region "行號 "
  ''行號顯示
  Private Sub dggd_(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dggd.RowPostPaint
    Dim Rectangle As System.Drawing.Rectangle = New System.Drawing.Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dggd.RowHeadersWidth - 4, e.RowBounds.Height)
    TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dggd.RowHeadersDefaultCellStyle.Font, Rectangle, dggd.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter & TextFormatFlags.Right)
  End Sub
  ''行號顯示
  Private Sub dggdmx_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles Dggdmx.RowPostPaint
    Dim Rectangle As System.Drawing.Rectangle = New System.Drawing.Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, Dggdmx.RowHeadersWidth - 4, e.RowBounds.Height)
    TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), Dggdmx.RowHeadersDefaultCellStyle.Font, Rectangle, Dggdmx.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter & TextFormatFlags.Right)
  End Sub
#End Region
#Region "工單查詢"
  '‘啟用日期查詢
  Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
    DateTimePicker1.Enabled = CheckBox1.Checked
    DateTimePicker2.Enabled = CheckBox1.Checked
  End Sub
  '‘顯示隱藏查詢條件
  Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
    Panel1.Visible = Not Panel1.Visible
  End Sub
  Private Sub ComboBox3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox3.KeyDown
    If e.KeyCode = Keys.Enter Then
      Btn_Find_Click(Nothing, Nothing)
    End If
  End Sub
  Private Sub ReIDs(rs As DataTable, aryID As ArrayList, aryMO As ArrayList, Optional bolM As Boolean = False)
    Dim sqlCV As New SQLCNV
    Dim strM1 As String = ""
    Dim strM2 As String = ""
    Dim bolT As Boolean = False
    For Each r As DataRow In rs.Rows
      If aryID.Contains(r!TN01.ToString.Trim) = False Then
        aryID.Add(r!TN01.ToString.Trim)
        If bolM = True Then
          strM1 &= "'" & r!TN01.ToString.Trim & "',"
          bolT = True
        End If
      End If
      If aryMO.Contains(r!TN02.ToString.Trim) = False Then
        aryMO.Add(r!TN02.ToString.Trim)
      End If
      If (r!TN06.ToString.Trim = "7" Or r!TN06.ToString.Trim = "100") And _
          r!TN07.ToString.Trim <> "" Then
        If aryID.Contains(r!TN07.ToString.Trim) = False Then
          strM2 &= "'" & r!TN07.ToString.Trim & "',"
          bolT = True
        End If
      End If
    Next
    If bolT = False Then Return
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
    If strM1 <> "" Then sqlCV.Where("TN07", "IN", strM1.Trim(","), intFMode.msfld_field)
    If strM2 <> "" Then sqlCV.Where("TN01", "IN", strM2.Trim(","), intFMode.msfld_field, , "OR")
    sqlCV.SqlFields("TN01")
    sqlCV.SqlFields("TN02")
    sqlCV.SqlFields("TN06")
    sqlCV.SqlFields("TN07")
    Dim rs1 As DataTable = DB.RsSQL(sqlCV.Text, "T2")
    ReIDs(rs1, aryID, aryMO, True)
  End Sub
  ''查詢
  Private Sub Btn_Find_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Find.Click
    Try
      dggd.DataSource = Nothing
      dggdbom.DataSource = Nothing
      Dggdmx.DataSource = Nothing
      dgqcjl.DataSource = Nothing
      dgscjl.DataSource = Nothing
      'Dgwxjl.DataSource = Nothing
      dgyljl.DataSource = Nothing
      Dggdfl.DataSource = Nothing
      dggdbom.DataSource = Nothing
      DgOp.DataSource = Nothing '0314
      dgqcjl.Columns.Clear()
      dgqcjl.Rows.Clear()
      fqcjl.Columns.Clear()
      fqcjl.Rows.Clear()
    Catch ex As Exception

    End Try
    Dim sqlCV As New SQLCNV
    Dim aryT As New ArrayList
    Dim aryT1 As New ArrayList
    Dim bolH1 As Boolean = False
    Dim strMat As String = ""
    If Txtwuliao.Text.Trim <> "" Then
      If Txtwuliao.Text.Trim.Length >= 32 Then
        Dim strW() As String = Txtwuliao.Text.Trim.Split("/|".ToCharArray)
        If strW.Length >= 4 Then
          sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TE")
          sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TN", "TN01", "=", "^0.TE14")
          sqlCV.Where("^0.TE01", "=", strW(0))
          sqlCV.Where("^0.TE02", "=", strW(0) & "_" & strW(1))
          sqlCV.Where("^0.TE03", "=", strW(3))
          sqlCV.SqlFields("^1.TN01")
          Dim rsW As DataTable = DB.RsSQL(sqlCV.Text, "RT")
          If rsW.Rows.Count = 0 Then
            MsgBox(BIG2GB("所用的物料序號找不到"))
            Return
          End If
          For Each r As DataRow In rsW.Rows
            strMat &= "'" & rsW.Rows(0)!TN01.ToString.Trim & "',"
          Next
        Else
          MsgBox(BIG2GB("所用的物料序號找不到"))
          Return
        End If
      Else
#If EP = 0 Then
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
        sqlCV.Where("TN01", "=", Txtwuliao.Text.Trim)
        sqlCV.SqlFields("TN12")
        sqlCV.SqlFields("TN02")
        Dim rsw As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        If rsw.Rows.Count = 0 Then
          MsgBox(BIG2GB("所用的物料序號找不到"))
          Return
        Else
          If CheckBox2.Checked Then
            ComboBox3.Text = rsw.Rows(0)!TN02.ToString.Trim
          Else
            Txtboxno.Text = rsw.Rows(0)!TN12.ToString.Trim
            aryIDs = Txtwuliao.Text.Trim
          End If
        End If
#End If
      End If
      strMat = "'" & Txtwuliao.Text.Trim & "'"
    End If
    If txtppida1.Text.Trim <> "" Or txtppida2.Text.Trim <> "" Then
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TS")
      If txtppida1.Text.Trim <> "" And txtppida2.Text.Trim <> "" Then
        sqlCV.Where("TS02", ">=", txtppida1.Text.Trim)
        sqlCV.Where("TS02", "<=", txtppida2.Text.Trim)
      Else
        If txtppida1.Text.Trim <> "" Then sqlCV.Where("TS02", "=", txtppida1.Text.Trim)
        If txtppida2.Text.Trim <> "" Then sqlCV.Where("TS02", "=", txtppida2.Text.Trim)
      End If
      sqlCV.SqlFields("TS01")
      Dim rsx1 As DataTable = DB.RsSQL(sqlCV.Text, "RT")
      For Each r As DataRow In rsx1.Rows
        strMat &= "'" & r!TS01.ToString.Trim & "',"
      Next
    End If
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
    If strMat <> "" Then
      sqlCV.Where("TN01", "IN", strMat.Trim(","), intFMode.msfld_field)
      bolH1 = True
    Else
      If txtppida1.Text.Trim <> "" And txtppida2.Text.Trim <> "" Then
        sqlCV.Where("TN01", ">=", txtppida1.Text.Trim)
        sqlCV.Where("TN01", "<=", txtppida2.Text.Trim)
        bolH1 = True
      ElseIf txtppida1.Text.Trim <> "" Then
        sqlCV.Where("TN01", "=", txtppida1.Text.Trim)
        bolH1 = True
      ElseIf txtppida2.Text.Trim <> "" Then
        sqlCV.Where("TN01", "=", txtppida2.Text.Trim)
        bolH1 = True
      End If
    End If
    If Txtboxno.TextLength <> 0 Then
      sqlCV.Where("SFIS_TN.TN12", "=", Txtboxno.Text.Trim)
      bolH1 = True
    End If
    If ComboBox3.Text <> "" Then
      Dim w As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TD", "TD01", "=", "^0.TN02")
      w.Add("SFIS_TD.TD01", "=", "'" & ComboBox3.Text.Trim & "'") 'CHA GONG DAN 
      bolH1 = True
    End If
    If CheckBox1.Checked = True Then
      Dim w As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TM", "TM01", "=", "^0.TN01")
#If EP = 0 Then
      'w.Add("SFIS_TM.TM01", "=", "SFIS_TD.TD01", , "OR")
#End If
      sqlCV.Where("TM06", ">=", DateTimePicker1.Value.ToString("yyyy\/MM\/dd HH") & ":00:00", intFMode.msfld_datetime)
      sqlCV.Where("TM06", "<=", DateTimePicker2.Value.ToString("yyyy\/MM\/dd HH") & ":59:59", intFMode.msfld_datetime)
      bolH1 = True
    End If
    sqlCV.SqlFields("TN01")
    sqlCV.SqlFields("TN02")
    sqlCV.SqlFields("TN06")
    sqlCV.SqlFields("TN07")
    If bolH1 = False Then
      MsgBox(BIG2GB("除了物料序號外沒有設定其他條件"))
      Return
    End If
    Dim rsx As DataTable = DB.RsSQL(sqlCV.Text, "TT")
    ReIDs(rsx, aryT, aryT1)
    If aryT.Count = 0 Then
      MsgBox(BIG2GB("設定的條件沒有資料符合"))
      Return
    End If
    aryIDs = ""
    For Each strK As String In aryT
      aryIDs &= "'" & strK & "',"
    Next
    aryIDs = aryIDs.Trim(",")
    Dim strMO As String = ""
    For Each strK As String In aryT1
      strMO &= "'" & strK & "',"
    Next
    If strMO = "" Then Return
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_distinc, "SFIS_TD")
    sqlCV.Where("TD01", "IN", strMO.Trim(","), intFMode.msfld_field)
    sqlCV.SqlFields("^0.TD01", "工單編號")
    sqlCV.SqlFields("^0.TD05+'-'+^0.TD06", "銷售訂單")
    sqlCV.SqlFields("^0.TD12", "工單狀態")
    sqlCV.SqlFields("^0.TD02", "物料編號")
    sqlCV.SqlFields("^0.TD19", "產品型號")
    sqlCV.SqlFields("^0.TD07", "工單數量")
    sqlCV.SqlFields("^0.TD13", "已完成")
    sqlCV.SqlFields("^0.TD18", "完工日期")
    sqlCV.SqlFields("^0.TD16", "主標識A")
    sqlCV.SqlFields("^0.TD17", "主標識B")
    sqlCV.SqlFields("^0.TD10", "副標識A")
    sqlCV.SqlFields("^0.TD11", "副標識B")
    sqlCV.SqlFields("^0.TD20+'-'+^0.TD21", "生產流程")
    dggd.DataSource = DB.RsSQL(BIG2GB(sqlCV.Text), "25")
    Panel1.Visible = False
    ' ''PPId,不良CheckBox2.Checked Or CheckBox1.Checked = True Or 
    If dggd.RowCount > 0 Then 'rbtall.Checked = False AndAlso
      Dim d As New DataGridViewCellEventArgs(0, 0)
      dggd_CellDoubleClick(Nothing, d)
      TabControl2.SelectedIndex = 1
    Else
      TabControl2.SelectedIndex = 0
      MOgd = ""
      MOmateral = ""
    End If
    t3 = False
    t4 = False
  End Sub
  ''選擇工單
  Private Sub dggd_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dggd.CellDoubleClick
    If e.RowIndex = -1 Then Return
    MOgd = dggd.Rows(e.RowIndex).Cells(BIG2GB("工單編號")).Value
    MOnum = dggd.Rows(e.RowIndex).Cells(BIG2GB("工單數量")).Value
    MOmateral = dggd.Rows(e.RowIndex).Cells(BIG2GB("物料編號")).Value
    '獲取對應工單的生產物料名稱
    Try
      dgqcjl.DataSource = Nothing
      dgscjl.DataSource = Nothing
      'Dgwxjl.DataSource = Nothing
      dgyljl.DataSource = Nothing
      dgqcjl.Columns.Clear()
      dgqcjl.Rows.Clear()
      fqcjl.Columns.Clear()
      fqcjl.Rows.Clear()
    Catch ex As Exception
    End Try
    ' ''沖壓注塑
    'sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "sfis_tm")
    'sqlCV.Where("tm01", "=", MOgd)
    'sqlCV.Where("tm10", "<>", "FQA OK")  '取消FQA檢驗數據信息
    'If rbtall.Checked = False Then
    '  ''不良
    '  ''生產時間查詢
    '  If CheckBox1.Checked Then
    '    sqlCV.Where(" datediff(d,SFIS_TN.TN04,'" & DateTimePicker1.Value, "')>=", 0, intFMode.msfld_num)
    '    sqlCV.Where(" datediff(d,'" & DateTimePicker2.Value & "',SFIS_TN.TN04)", ">=", 0, intFMode.msfld_num)
    '  End If
    'End If
    'gongdanMO = True
    'sqlCV.SqlFields("Tm02", "工序")
    'sqlCV.SqlFields("Tm04", "機臺")
    'sqlCV.SqlFields("Tm05", "填報序號")
    'sqlCV.SqlFields("Tm06", "填報時間")
    'sqlCV.SqlFields("Tm12", "批量數")
    'sqlCV.SqlFields("Tm13", "不良總數")
    'sqlCV.SqlFields("Tm14", "工時")
    'sqlCV.SqlFields("Tm10", "處理方式")
    'sqlCV.SqlFields("Tm08", "操作")
    'sqlCV.sqlOrder("tm06")
    'Dggdmx.DataSource = DB.RsSQL(BIG2GB(sqlCV.Text), "sfis_tn")
    'If Dggdmx.RowCount <> 0 Then
    '  gongdanMO = True
    'Else
    '’組裝
    intDMode = 0
    ''查檢驗項目
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "sfis_qjb")
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "sfis_qja", "qja01", "=", "sfis_qjb.qjb01 and sfis_qjb.qjb04=sfis_qja.qja02")
    sqlCV.Where("sfis_qjb.qjb02", "=", MOmateral)
    sqlCV.SqlFields("sfis_qjb.qjb04") '項次編號
    sqlCV.SqlFields("sfis_qja.qja03") '中文說明
    sqlCV.SqlFields("isnull(sfis_qjb.qjb09,'-')") '螢幕顯示
    sqlCV.SqlFields("sfis_qjb.qjb05") '標準
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    MOjianyanxiangmu.Clear()
    dgqcjl.Columns.Add(BIG2GB("工序"), BIG2GB("工序"))
    dgqcjl.Columns.Add(BIG2GB("工序說明"), BIG2GB("工序說明"))
    dgqcjl.Columns.Add(BIG2GB("時間"), BIG2GB("時間"))
    dgqcjl.Columns.Add(BIG2GB("結果"), BIG2GB("結果"))
    dgqcjl.Columns.Add(BIG2GB("項次"), BIG2GB("項次"))
    dgqcjl.Columns.Add(BIG2GB("中文說明"), BIG2GB("中文說明"))
    dgqcjl.Columns.Add(BIG2GB("標準"), BIG2GB("標準"))
    dgqcjl.Columns.Add("Value", BIG2GB("數值"))
    For Each clm As DataGridViewColumn In dgqcjl.Columns
      clm.SortMode = DataGridViewColumnSortMode.NotSortable
    Next
    fqcjl.Columns.Add(BIG2GB("工序"), BIG2GB("工序"))
    fqcjl.Columns.Add(BIG2GB("工序說明"), BIG2GB("工序說明"))
    fqcjl.Columns.Add(BIG2GB("時間"), BIG2GB("時間"))
    fqcjl.Columns.Add(BIG2GB("結果"), BIG2GB("結果"))
    fqcjl.Columns.Add(BIG2GB("項次"), BIG2GB("項次"))
    fqcjl.Columns.Add(BIG2GB("中文說明"), BIG2GB("中文說明"))
    fqcjl.Columns.Add(BIG2GB("標準"), BIG2GB("標準"))
    fqcjl.Columns.Add("Value", BIG2GB("數值"))
    For Each clm As DataGridViewColumn In fqcjl.Columns
      clm.SortMode = DataGridViewColumnSortMode.NotSortable
    Next
    If rs.Rows.Count = 0 Then
      TabControl3.TabPages.Add(TabPage3)
      TabControl3.TabPages.Add(TabPage4)
      TabPage3.Hide()
      TabPage4.Hide()
    Else
      If TabControl1.TabPages.ContainsKey("TabPage3") = False Then
        TabControl1.TabPages.Add(TabPage3)
      End If
      If TabControl1.TabPages.ContainsKey("TabPage4") = False Then
        TabControl1.TabPages.Add(TabPage4)
      End If
      TabPage3.Show()
      TabPage4.Show()
      For Each row As DataRow In DB.RsSQL(sqlCV.Text, "sfis_tn").Rows
        If MOjianyanxiangmu.ContainsKey(row.Item(0).ToString.Trim) = False Then
          MOjianyanxiangmu.Add(row.Item(0), row.Item(1) & "^" & row.Item(3))
          Dim str() As String = Split(row.Item(2).ToString.Trim, "||")
          For Each st As String In str
            If st.Trim = "" Then Continue For
            If dgqcjl.Columns.Contains(st) = False Then
              dgqcjl.Columns.Add(st, st)
              dgqcjl.Columns(st).SortMode = DataGridViewColumnSortMode.NotSortable
              fqcjl.Columns.Add(st, st)
              fqcjl.Columns(st).SortMode = DataGridViewColumnSortMode.NotSortable
            End If
          Next
        End If
      Next
    End If
    ''讀取工單明細數據
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_distinc, "SFIS_TN")
    If aryIDs <> "" And CheckBox2.Checked = False Then
      sqlCV.Where("^0.TN01", "IN", aryIDs, intFMode.msfld_field)
    End If
    If rbtall.Checked = False Then
      sqlCV.Where("^0.TN02", "=", MOgd)
    End If
    'If rbtall.Checked = False Then
    '  ''ppid
    '  If txtppida1.Text.Trim.Length > 0 And txtppida2.Text.Trim.Length > 0 Then
    '    sqlCV.Where("^0.TN01", ">=", txtppida1.Text.Trim)
    '    sqlCV.Where("^0.TN01", "<=", txtppida2.Text.Trim)
    '  Else
    '    If txtppida1.Text.Trim.Length > 0 Then
    '      sqlCV.Where("^0.TN01", "LIKE", txtppida1.Text.Trim)
    '    End If
    '  End If
    '  '’包裝id查詢
    '  If Txtboxno.TextLength <> 0 Then sqlCV.Where("TN12", "=", Txtboxno.Text.Trim)
    '  ''生產時間查詢
    '  If CheckBox1.Checked Then
    '    sqlCV.Where(" datediff(d,SFIS_TN.TN04,'" & DateTimePicker1.Value, "')>=", 0, intFMode.msfld_num)
    '    sqlCV.Where(" datediff(d,'" & DateTimePicker2.Value & "',SFIS_TN.TN04)", ">=", 0, intFMode.msfld_num)
    '  End If
    'End If
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TM", "TM01", "=", "SFIS_TN.TN01")
    Dim w1 As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "SFIS_TN", "S2.TN07", "=", "^0.TN01")
    w1.Add("S2.TN06", "=", "100")
    'w1.Add("S2.TN02", "=", "SFIS_TN.TN02")
    sqlCV.SqlFields("^0.TN01", "PPID")
    sqlCV.SqlFields("^0.TN02", "工單")
    sqlCV.SqlFields("ISNULL(^0.TN12,'')", "包裝箱號")
    sqlCV.SqlFields("^0.TN08", "維修次數")
    sqlCV.SqlFields("^0.TN09", "不良次數")
    sqlCV.SqlFields("^0.TN03", "目前工序")
    sqlCV.SqlFields("^0.TN05", "返回工序")
    sqlCV.SqlFields("ISNULL(^0.TN06,0)", "產品狀態")
    sqlCV.SqlFields("ISNULL(^0.TN10,0)", "檢驗狀態")
    sqlCV.SqlFields("^0.TN07", "副標識")
    sqlCV.SqlFields("^2.TN01", "反面ID")
    sqlCV.SqlFields("^0.TN04", "時間")
    sqlCV.SqlFields("ISNULL(^0.TN11,'')", "Invoice")
    rs = DB.RsSQL(BIG2GB(sqlCV.Text), "SFIS_TN")
    If rs.Rows.Count = 0 Then
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
      If Txtboxno.Text.Trim <> "" And CheckBox2.Checked = False Then
        sqlCV.Where("TN12", "=", Txtboxno.Text)
      End If
      sqlCV.Where("TN02", "=", MOgd)
      sqlCV.SqlFields("TN12", "箱號", , True, True)
      sqlCV.SqlFields("TN16", "重量", , True)
      sqlCV.SqlFields("Count(*)", "數量")
      rs = DB.RsSQL(BIG2GB(sqlCV.Text), "SFIS_TN1")
      If rs.Rows.Count > 0 Then
        intDMode = 2
        Dggdmx.DataSource = rs
      End If
    Else
      Dggdmx.DataSource = rs
    End If

    t3 = False
    t4 = False
    TabControl2.SelectedIndex = 1
    RelistDgOp(MOgd) '0314
  End Sub
  ''選擇PPID明細
  Private Sub Dggdmx_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dggdmx.RowEnter
    'End Sub
    'Private Sub Dggdmx_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dggdmx.CellContentClick
    'Private Sub Dggdmx_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dggdmx.CellDoubleClick
    If e.RowIndex = -1 Then Return
    dgscjl.DataSource = Nothing
    'Dgwxjl.DataSource = Nothing
    dgyljl.DataSource = Nothing
    dgqcjl.DataSource = Nothing
    fqcjl.DataSource = Nothing
    'If gongdanMO = True Then
    'Else
    Select Case intDMode
      Case 0
        gongdanw(GCell(Dggdmx.Rows(e.RowIndex).Cells(0)))
      Case 1
        '  gongdanm(Dggdmx.Rows(e.RowIndex).Cells(BIG2GB("填報序號")).Value)
      Case 2
        Dim sqlCV As New APSQL.SQLCNV
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
        sqlCV.Where("TN12", "=", GCell(Dggdmx.Rows(e.RowIndex).Cells(0)))
        sqlCV.SqlFields("TN12", "箱號")
        sqlCV.SqlFields("TN01", "[產品S/N]")
        dgscjl.DataSource = DB.RsSQL(BIG2GB(sqlCV.Text), "SFIS_TN2")
    End Select
    'End If
  End Sub
  Dim dttz As DataTable
  Dim dttzgx As String = ""
  '組裝工單從PPID抓取製程信息
  Sub gongdanw(ByVal ppid As String)
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TM")
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "SFIS_TA", "TA01", "=", "SFIS_TM.TM02")
    sqlCV.NomalNtext = False
    sqlCV.Where("TM01", "=", ppid)
    sqlCV.Where("TM05", "NOT IN", "'P','P1','P2'", intFMode.msfld_field)
    sqlCV.SqlFields("SFIS_TM.TM02", "工序")
    sqlCV.SqlFields("SFIS_TA.TA02", "工序說明")
    sqlCV.SqlFields("SFIS_TM.TM03", "員工號")
    sqlCV.SqlFields("SFIS_TM.TM04", "機臺")
    sqlCV.SqlFields("SFIS_TM.TM06", "生產時間")
    sqlCV.SqlFields("SFIS_TM.TM07", "用料檢驗")
    sqlCV.SqlFields("SFIS_TM.TM08", "結果")
    sqlCV.SqlFields("SFIS_TM.TM09", "不良代碼")
    sqlCV.SqlFields("SFIS_TM.TM15")
    sqlCV.SqlFields("^0.USEQ")
    dttz = DB.RsSQL(BIG2GB(sqlCV.Text), "25")
    ''生產主記錄表
    'dgscjl.DataSource = dtt
    'dgscjl.Columns("用料檢驗").Visible = False
    Dim scjl As New DataTable
    scjl.Columns.Add(BIG2GB("工序"), GetType(String))
    scjl.Columns.Add(BIG2GB("工序說明"), GetType(String))
    scjl.Columns.Add(BIG2GB("員工"), GetType(String))
    scjl.Columns.Add(BIG2GB("機臺"), GetType(String))
    scjl.Columns.Add(BIG2GB("生產時間"), GetType(String))
    scjl.Columns.Add(BIG2GB("結果"), GetType(String))
    scjl.Columns.Add(BIG2GB("不良代碼"), GetType(String))
    scjl.Columns.Add(BIG2GB("截圖檔"), GetType(Bitmap))
    scjl.Columns.Add("UID")
    dgqcjl.Rows.Clear()
    fqcjl.Rows.Clear()

    ''用料記錄表
    Dim yongliao As New DataTable
    yongliao.Columns.Add(BIG2GB("工序"))
    yongliao.Columns.Add(BIG2GB("工序說明"))
    yongliao.Columns.Add(BIG2GB("料號"))
    yongliao.Columns.Add(BIG2GB("批序號"))
    yongliao.Columns.Add(BIG2GB("使用量"))
    yongliao.Columns.Add(BIG2GB("用料時間"))
    yongliao.Columns.Add(BIG2GB("操作員工"))

    For Each dtrow As DataRow In dttz.Rows
      With dtrow
        Dim user As String = GetUser(dtrow.Item(BIG2GB("員工號")).ToString.TrimEnd(","))
        Dim bmpx As Bitmap = Nothing
        Dim bmpY As New Bitmap(64, 17)
        If dtrow!TM15.GetType IsNot GetType(DBNull) Then
          Dim fs As New IO.MemoryStream
          Dim bytV() As Byte = dtrow!TM15
          If bytV IsNot Nothing AndAlso bytV.Length > 0 Then
            Dim bolMode As Boolean = False
            For intS As Integer = 0 To 15
              If bytV.GetUpperBound(0) > intS Then
                If bytV(intS) > 127 Then bolMode = True
                Exit For
              End If
            Next
            If bolMode = False Then
              bmpx = Nothing
              Dim gr As Graphics = Graphics.FromImage(bmpY)
              gr.Clear(Color.White)
              gr.DrawString("Text", New Font("Arial", 10), Brushes.Black, 1, 1)
            Else
              fs.Write(bytV, 0, bytV.Length)
              Try
                bmpx = New Bitmap(fs)
                fs.Close()
                fs.Dispose()
              Catch ex As Exception
                bmpx = Nothing
              End Try
              bmpY = New Bitmap(64, 48)
              Dim gr As Graphics = Graphics.FromImage(bmpY)
              gr.Clear(Color.Gray)
              gr.DrawImage(bmpx, 0, 0, 64, 48)
            End If
          Else
            Dim gr As Graphics = Graphics.FromImage(bmpY)
            gr.Clear(Color.White)
          End If
        Else
          Dim gr As Graphics = Graphics.FromImage(bmpY)
          gr.Clear(Color.White)
        End If
        scjl.Rows.Add(New Object() {.Item(BIG2GB("工序")).ToString, .Item(BIG2GB("工序說明")).ToString, _
                                    user, getmachine(dtrow.Item(BIG2GB("機臺")).ToString.TrimEnd(",")), _
                                      .Item(BIG2GB("生產時間")).ToString, .Item(BIG2GB("結果")).ToString, _
                                      GetErrCode(dtrow.Item(BIG2GB("不良代碼")).ToString.TrimEnd(",")), bmpY, !USEQ.ToString.Trim})
        Dim TM07() As String = .Item(BIG2GB("用料檢驗")).ToString.Trim.Split("^")
        Dim first As Boolean = True, intI As Integer = 0
        Dim strI As String = "", strL As String = "", strQ As String = ""
        Dim aryD As New Dictionary(Of String, String())
        For Each strK As String In TM07
          intI += 1
          If strK.Trim = "" Then Continue For
          If intI = 1 Then
            Dim strM() As String = strK.Replace("$|", "$").Split(",")
            For Each strP As String In strM
              If strP.Trim = "" Then Continue For
              Dim str1() As String = strP.Split("|=".ToCharArray)
              Select Case str1.Length
                Case 1
                  Continue For
                Case 2
                  strI = str1(0)
                  strL = ""
                  strQ = str1(1).TrimEnd("0").TrimEnd(".")
                Case Else
                  strI = str1(0)
                  strL = str1(1)
                  strQ = str1(2).TrimEnd("0").TrimEnd(".")
              End Select
              If wuliaoName.ContainsKey(strI) Then
                strI = strI & " " & wuliaoName(strI)
              End If
              If strL.Contains("$") Then
                strL = strL.Split("$")(1)
              End If
              yongliao.Rows.Add(.Item(BIG2GB("工序")).ToString.Trim, .Item(BIG2GB("工序說明")).ToString.Trim, _
                                strI, strL, strQ, .Item(BIG2GB("生產時間")).ToString, user)
            Next
          Else
            first = False
            Dim strM() As String = strK.Split("|=".ToArray)
            If aryD.ContainsKey(strM(0)) = False Then
              Dim strVS(fqcjl.Columns.Count - 1) As String
              For intJ As Integer = 0 To strVS.GetUpperBound(0)
                strVS(intJ) = ""
              Next
              aryD.Add(strM(0), strVS)
            End If
            Dim strVO() As String = aryD(strM(0))
            If strM.Length = 2 Then
              strVO(4) = strM(0)
              strVO(7) &= strM(1) & ","
            ElseIf strM.Length >= 3 Then
              strVO(4) = strM(0)
              If fqcjl.Columns.Contains(strM(1)) Then
                strVO(fqcjl.Columns(strM(1)).Index) = strM(2)
              Else
                strVO(7) &= strM(1) & "=" & strM(2) & ","
              End If
            End If
          End If
        Next
        If aryD.Count > 0 Then
          For Each strK As String In aryD.Keys
            Dim strVO() As String = aryD(strK)
            Dim strN() As String
            If MOjianyanxiangmu.ContainsKey(strVO(4)) Then  '' 判斷是否為合格的檢驗項目
              strN = MOjianyanxiangmu(strVO(4)).Split("^")
              strVO(5) = strN(0)
              strVO(6) = strN(1)
            End If
            strVO(0) = .Item(BIG2GB("工序")).ToString.Trim
            strVO(1) = .Item(BIG2GB("工序說明")).ToString.Trim
            strVO(2) = .Item(BIG2GB("生產時間")).ToString.Trim
            strVO(3) = .Item(BIG2GB("結果")).ToString.Trim
            strVO(7) = strVO(7).ToString.Trim(",")
            If strVO(3) = "3" Then
              fqcjl.Rows.Add(strVO)
            Else
              dgqcjl.Rows.Add(strVO)
            End If
          Next
        End If
      End With
    Next
    dgyljl.DataSource = yongliao
    dgscjl.DataSource = scjl
    dgscjl.Columns("UID").Visible = False
    'dgscjl.Columns(5).SortMode = DataGridViewColumnSortMode.Programmatic
    dgscjl.Sort(dgscjl.Columns(4), System.ComponentModel.ListSortDirection.Ascending)
    xianshi()
  End Sub
  ''‘’組裝工單 的用料明細
  Private Sub dgscjl_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgscjl.CellMouseDown
    If e.RowIndex < 0 Or intDMode = 1 Or intDMode = 2 Then Return
    dttzgx = dgscjl.CurrentRow.Cells(0).Value
    xianshi(dgscjl.CurrentRow.Cells(4).Value)
  End Sub
  ''‘’組裝工單 顯示工序
  Sub xianshi(Optional ByVal time As String = "")
  End Sub
  ''‘’‘’‘’‘’沖壓注塑工單
  Sub gongdanm(ByVal tianbaoxuhao As String)
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "sfis_tm")
    sqlCV.Where("tm05", "=", tianbaoxuhao)
    sqlCV.SqlFields("Tm03", "員工")
    sqlCV.SqlFields("Tm07", "用料及報廢")
    sqlCV.SqlFields("Tm08", "種類")
    sqlCV.SqlFields("Tm09", "記錄明細")
    sqlCV.SqlFields("Tm13", "不良數")
    sqlCV.SqlFields("Tm04", "機臺")
    sqlCV.SqlFields("Tm02", "工序")
    sqlCV.SqlFields("Tm06", "生產時間")
    sqlCV.SqlFields("Tm10", "處理方式")
    Dim dt As DataTable = DB.RsSQL(BIG2GB(sqlCV.Text), "tm")
    Dim scjl As New DataTable
    scjl.Columns.Add(BIG2GB("工序"))
    scjl.Columns.Add(BIG2GB("工序說明"))
    scjl.Columns.Add(BIG2GB("員工"))
    scjl.Columns.Add(BIG2GB("機臺"))
    scjl.Columns.Add(BIG2GB("生產時間"))
    scjl.Columns.Add(BIG2GB("不良數"))
    Dim yongliao As New DataTable
    yongliao.Columns.Add(BIG2GB("料號"))
    yongliao.Columns.Add(BIG2GB("單位+名稱"))
    yongliao.Columns.Add(BIG2GB("批序號"))
    yongliao.Columns.Add(BIG2GB("耗用量"))
    yongliao.Columns.Add(BIG2GB("頭尾損耗"))
    yongliao.Columns.Add(BIG2GB("下腳損耗"))
    yongliao.Columns.Add(BIG2GB("不良報廢"))
    Dim buliang As New DataTable
    buliang.Columns.Add(BIG2GB("類型"))
    buliang.Columns.Add(BIG2GB("員工號"))
    buliang.Columns.Add(BIG2GB("數量"))
    buliang.Columns.Add(BIG2GB("不良代碼"))
    buliang.Columns.Add(BIG2GB("責任"))
    buliang.Columns.Add(BIG2GB("不良原因"))
    Dim fqc As Boolean = False
    For Each dtrow As DataRow In dt.Rows
      With dtrow
        Dim user As String = getuser(.Item(BIG2GB("員工")).ToString.TrimEnd(","))
        scjl.Rows.Add(New Object() {.Item(BIG2GB("工序")).ToString, _
        getgx(.Item(BIG2GB("工序")).ToString), user, getmachine(dtrow.Item(BIG2GB("機臺")).ToString.TrimEnd(",")), _
        .Item(BIG2GB("生產時間")).ToString, .Item(BIG2GB("不良數")).ToString})
        Dim str() As String = .Item("用料及報廢").ToString.Split("@")
        For i As Byte = 0 To str.GetLength(0) - 1
          If i = 0 Then
            ''生產用料
            '1000-0000000001|R00000000005=50,1000-0000000002|R00000000004=25,@R00000000005,10,,@R00000000004,10
            Dim yl() As String = str(i).Split("|=,".ToCharArray)
            If yl.Length = 1 Then Continue For
            For b As Byte = 0 To yl.GetLength(0) - 2 Step 3
              yongliao.Rows.Add(New Object() {yl(b), wuliaoName(yl(b)).ToString, yl(b + 1), yl(b + 2), 0, 0, 0})
            Next
          Else
            ''生產損耗
            Dim bf() As String = str(i).Split(",")
            For Each rw As DataRow In yongliao.Rows
              If rw.Item(1).ToString = bf(0) Then
                Try
                  rw.Item(3) = Val(bf(1))
                  rw.Item(4) = Val(bf(2))
                  rw.Item(5) = Val(bf(3))
                Catch ex As Exception
                End Try
                Exit For
              End If
            Next
          End If
        Next
        dgyljl.DataSource = yongliao
        If .Item(2).ToString = 2 Then
          ''生產

          ''員工自檢
          '8,I0105,Z01NN,不良05|2,I0105,Z01NN,不良05|
          str = .Item(BIG2GB("記錄明細")).ToString.Trim("|").Split(",|".ToCharArray)
          If str.Length = 1 Then Continue For
          For i As Byte = 1 To str.GetLength(0) - 1 Step 5
            buliang.Rows.Add(New Object() {BIG2GB("自檢"), user, str(i), str(i + 1), _
                            str(i + 2), str(i + 3)})
          Next
        ElseIf .Item(2).ToString = 0 Then
          'IPQC
          '20|1,I0105,Z01NN,不良05|
          str = .Item(BIG2GB("記錄明細")).ToString.Trim("|").Split(",|".ToCharArray)
          If str.Length = 0 Then Continue For
          buliang.Rows.Add(New Object() {IIf(.Item(8).ToString.Length = 0, BIG2GB("自檢"), "IPQC"), _
                         BIG2GB("抽樣數"), str(0), "", "", ""})
          If str.Length = 1 Then Continue For
          For i As Byte = 1 To str.GetLength(0) - 1 Step 5
            buliang.Rows.Add(New Object() {IIf(.Item(8).ToString.Length = 0, BIG2GB("自檢"), "IPQC"), _
                                           user, str(i), str(i + 1), str(i + 2), str(i + 3)})
          Next
        ElseIf .Item(2).ToString = 4 Then '返工生產
          str = .Item(BIG2GB("記錄明細")).ToString.Split(",|".ToCharArray)
          If str.Length = 0 Then Continue For
          buliang.Rows.Add(New Object() {BIG2GB("返工"), BIG2GB("抽樣數"), str(0), "", "", ""})
          If str.Length = 1 Then Continue For
          For i As Byte = 1 To str.GetLength(0) - 2 Step 4
            buliang.Rows.Add(New Object() {BIG2GB("返工"), user, str(i), str(i + 1), _
                            str(i + 2), str(i + 3)})
          Next
        Else
          ''FQC3.6
          fqc = True
          str = .Item(BIG2GB("記錄明細")).ToString.Trim("|").Split(",|".ToCharArray)
          buliang.Rows.Add(New Object() {"FQC", BIG2GB("抽樣數"), str(0), "", "", ""})
          If str.Length = 1 Then Continue For
          For i As Byte = 1 To str.GetLength(0) - 1 Step 5
            buliang.Rows.Add(New Object() {"FQC", user, str(i), str(i + 1), str(i + 2), str(i + 3)})
          Next
        End If
      End With
    Next
    If fqc = True Then
      fqcjl.DataSource = buliang
      If TabControl1.SelectedIndex = 2 Then TabControl1.SelectedIndex = 3
    Else
      dgqcjl.DataSource = buliang
      If TabControl1.SelectedIndex = 3 Then TabControl1.SelectedIndex = 2
    End If

    dgscjl.DataSource = scjl 'dt
    dgscjl.Sort(dgscjl.Columns(4), System.ComponentModel.ListSortDirection.Ascending)

    'dgscjl.Columns(1).Visible = False
    ''dgscjl.Columns(2).Visible = False
    'dgscjl.Columns(3).Visible = False
  End Sub
  '’工單對應其他信息
  Private Sub TabControl2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl2.SelectedIndexChanged
    ''使用物料
    If TabControl2.SelectedIndex = 2 AndAlso t3 = False Then
      t3 = True
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TDB")
      sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TBB", "TBB03", "=", "^0.TDB03")
      sqlCV.Where("TDB01", "=", MOgd)
      sqlCV.Where("TDB08+ISNULL(TDB09,0)+ISNULL(TDB17,0)+ISNULL(TDB11,0)", ">", 0.01, intFMode.msfld_num)
      sqlCV.SqlFields("TDB02", "工序編號", , True, True)
      sqlCV.SqlFields("TDB04", "[物料編號_批號]", , True, True)
      sqlCV.SqlFields("TBB05 + ' ' +TBB06", "品名規格", , True)
      sqlCV.SqlFields("TDB24", "供應商", , True)
      sqlCV.SqlFields("TDB07", "單位用量", , True)
      sqlCV.SqlFields("SUM(TDB08)", "使用量")
      sqlCV.SqlFields("TBB07", "單位", , True)
      dggdbom.DataSource = DB.RsSQL(BIG2GB(sqlCV.Text), "bom")
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "sfis_TDB")
      sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TBB", "TBB03", "=", "^0.TDB03")
      sqlCV.Where("TDB01", "=", MOgd)
      sqlCV.SqlFields("TDB03", "物料編號", , True, True)
      sqlCV.SqlFields("TBB05 + ' ' +TBB06", "品名規格", , True)
      sqlCV.SqlFields("TDB24", "供應商", , True, True)
      sqlCV.SqlFields("SUM(TDB08)", "用量")
      sqlCV.SqlFields("SUM(TDB09)", "報廢一")
      sqlCV.SqlFields("SUM(TDB17)", "報廢二")
      sqlCV.SqlFields("SUM(TDB11)", "維修報廢")
      sqlCV.SqlFields("SUM(TDB08+ISNULL(TDB09,0)+ISNULL(TDB17,0)+ISNULL(TDB11,0))", "總用量")
      Dggdfl.DataSource = DB.RsSQL(BIG2GB(sqlCV.Text), "tdb")
      'For Each dtr As DataGridViewRow In Dggdfl.Rows
      '  For Each gdr As DataGridViewRow In dggdbom.Rows
      '    If dtr.Cells(0).Value = gdr.Cells(0).Value AndAlso dtr.Cells(1).Value = gdr.Cells(1).Value Then
      '      gdr.Cells(6).Value += dtr.Cells(4).Value
      '      gdr.Cells(7).Value += dtr.Cells(5).Value
      '      Exit For
      '    End If
      '  Next
      'Next
      'For Each dtr As DataGridViewRow In Dggdfl.Rows
      '  If gongdanMO = True Then
      '    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "sfis_tm")
      '    sqlCV.Where("tm01", "=", MOgd)
      '    sqlCV.Where("tm02", "=", dtr.Cells(0).Value.ToString)
      '    sqlCV.Where("tm07", "like", "%" & dtr.Cells(1).Value.ToString & "|" & dtr.Cells(3).Value.ToString & "%")
      '    sqlCV.SqlFields("sum(sfis_tm.tm12)")
      '  Else
      '    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "sfis_tn")
      '    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "sfis_tm", "tm01", "=", "^0.tn01")
      '    sqlCV.Where("^0.tn02", "=", MOgd)
      '    sqlCV.Where("^1.tm02", "=", dtr.Cells(0).Value.ToString)
      '    sqlCV.Where("^1.tm07", "like", "%" & dtr.Cells(1).Value.ToString & "|" & dtr.Cells(3).Value.ToString & "%")
      '    sqlCV.SqlFields("count(sfis_tm.tm01)")
      '  End If
      '  dtr.Cells(11).Value = DB.ExecuteScalar(sqlCV.Text)
      'Next
    End If
    '不良分析
    If TabControl2.SelectedIndex = 3 AndAlso t4 = False Then
      t4 = True
      Dim sqlCV As New APSQL.SQLCNV
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_distinc, "SFIS_TN")
      sqlCV.Where("TN02", "=", MOgd)
      Dim w As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TM", "TM01", "=", "SFIS_TN.TN01")
      w.Add("ISNULL(SFIS_TM.TM09,'')", "<>", "''")
      sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "SFIS_TMA", "TMA02", "=", "SFIS_TM.USEQ")
      sqlCV.SqlFields("^0.TN01", "PPID")
      sqlCV.SqlFields("^1.TM09", "不良現象")
      sqlCV.SqlFields("^1.TM03", "檢驗員工")
      sqlCV.SqlFields("^1.TM06", "檢驗時間")
      sqlCV.SqlFields("^2.TMA05", "不良原因")
      sqlCV.SqlFields("^2.TMA06", "責任")
      sqlCV.SqlFields("^2.TMA07", "維修員工")
      sqlCV.SqlFields("^2.TMA10", "維修時間")
      sqlCV.SqlFields("^2.TMA11", "維修說明")
      sqlCV.SqlFields("^2.TMA12", "維修結果")
      DGblfx.DataSource = DB.RsSQL(BIG2GB(sqlCV.Text), "tmb")
    End If
  End Sub
  '‘清空查詢條件，及結果
  Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
    For Each ct In Panel1.Controls
      If TypeOf (ct) Is TextBox Then ct.text = ""
    Next
    ComboBox3.Text = ""
    CheckBox1.Checked = False
    dggd.DataSource = Nothing
    dggdbom.DataSource = Nothing
    Dggdmx.DataSource = Nothing
    dgqcjl.DataSource = Nothing
    dgscjl.DataSource = Nothing
    'Dgwxjl.DataSource = Nothing
    dgyljl.DataSource = Nothing
    dggdbom.DataSource = Nothing
    Dggdfl.DataSource = Nothing
    dgqcjl.Columns.Clear()
    dgqcjl.Rows.Clear()
    fqcjl.Columns.Clear()
    fqcjl.Rows.Clear()
    Panel1.Visible = True
  End Sub
#End Region
  'Sub liaopi(ByVal wl As String, ByVal pc As String, ByVal pn As String, Optional ByVal space As Integer = 0)
  '  space += 1
  '  Try
  '    Select Case pn.Substring(0, 1).ToUpper
  '      Case "R"  ''進料
  '        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "sfis_te")
  '        sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "sfis_tca", "tca03", "=", "sfis_te.te21")
  '        sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "sfis_tbb", "tbb03", "=", "sfis_te.te01")

  '        sqlCV.Where("sfis_te.te01", "=", wl)
  '        sqlCV.Where("sfis_te.te02", "=", pc)
  '        sqlCV.Where("sfis_te.te03", "=", pn)
  '        sqlCV.SqlFields("isnull(sfis_tca.tca03+':'+sfis_tca.tca02,'')")
  '        sqlCV.SqlFields("sfis_te.te23") '備註
  '        sqlCV.SqlFields("sfis_te.te16") '製造日期
  '        sqlCV.SqlFields("^2.tbb05+'|'+sfis_tbb.tbb10") '名稱
  '        sqlCV.SqlFields("^2.tbb08") '原料
  '        sqlCV.SqlFields("sfis_te.te14") '原批號
  '        sqlCV.SqlFields("sfis_te.te22") '驗收日期
  '        'sqlCV.SqlFields("str(year(sfis_te.te22),4)+'-'+str( month(sfis_te.te22),2)+'-'+str( day(sfis_te.te22),2)") '驗收日期
  '        Dim dt = DB.RsSQL(sqlCV.Text, "12")
  '        If dt.Rows.Count = 0 Then
  '          wuliaochaxun.Rows.Add(New Object() {space, BIG2GB("採購單"), wl, pc, pn, BIG2GB("無採購信息..."), "", "", "", "", "", ""})
  '        Else
  '          wuliaochaxun.Rows.Add(New Object() {space, BIG2GB("採購單"), wl, pc, pn, dt.Rows(0).Item(2).ToString, _
  '                                          dt.Rows(0).Item(1).ToString, dt.Rows(0).Item(0).ToString, _
  '                                          dt.Rows(0).Item(3).ToString, dt.Rows(0).Item(4).ToString, _
  '                                          dt.Rows(0).Item(5).ToString, FormatDateTime(dt.Rows(0).Item(6).ToString, _
  '                                                                                DateFormat.ShortDate)})
  '        End If
  '      Case "M"  '工單
  '        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "sfis_tdb")
  '        'sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "sfis_tbb", "tbb03", "=", "^0.tdb03")
  '        sqlCV.Where("tdb01", "=", pc)
  '        sqlCV.SqlFields("tdb03")
  '        sqlCV.SqlFields("tdb04")
  '        sqlCV.SqlFields("tdb05")
  '        'sqlCV.SqlFields("^1.tbb05") '名稱
  '        'sqlCV.SqlFields("^1.tbb08") '名稱
  '        Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "tdb_wf")
  '        If dt.Rows.Count = 0 Then
  '          wuliaochaxun.Rows.Add(New Object() {space, BIG2GB("加工單"), wl, pc, pn, BIG2GB("無用料信息..."), "", "", "", "", "", ""})
  '        Else
  '          wuliaochaxun.Rows.Add(New Object() {space, BIG2GB("加工單"), wl, pc, pn, "", "", "", "", "", "", ""}) ', dt.Rows(0).Item(3).ToString, dt.Rows(0).Item(4).ToString, ""})
  '          Dim I As Byte = 0
  '          For Each row As DataRow In dt.Rows
  '            liaopi(row.Item(0), row.Item(1), row.Item(2), space & I)
  '            I += 1
  '          Next
  '        End If
  '      Case "F"  '‘外發單
  '        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "sfis_te")
  '        sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "sfis_tca", "tca03", "=", "sfis_te.te21")
  '        sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "sfis_tbb", "tbb03", "=", "sfis_te.te01")
  '        sqlCV.Where("sfis_te.te01", "=", wl)
  '        sqlCV.Where("sfis_te.te02", "=", pc)
  '        sqlCV.Where("sfis_te.te03", "=", pn)
  '        sqlCV.SqlFields("sfis_tca.tca02+'('+sfis_tca.tca03+')'")
  '        sqlCV.SqlFields("sfis_te.te23") '備註
  '        sqlCV.SqlFields("sfis_te.te16") '製造日期
  '        sqlCV.SqlFields("^2.tbb05+'|'+sfis_tbb.tbb10") '名稱
  '        sqlCV.SqlFields("^2.tbb08") '種類
  '        sqlCV.SqlFields("sfis_te.te14") '原批號
  '        sqlCV.SqlFields("sfis_te.te22") '驗收日期
  '        Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "dd")
  '        If dt.Rows.Count = 0 Then
  '          wuliaochaxun.Rows.Add(New Object() {space, BIG2GB("外發單"), wl, pc, pn, "", "", "", "", "", "", ""})
  '        Else
  '          wuliaochaxun.Rows.Add(New Object() {space, BIG2GB("外發單"), wl, pc, pn, dt.Rows(0).Item(2).ToString, dt.Rows(0).Item(1).ToString, dt.Rows(0).Item(0).ToString, dt.Rows(0).Item(3).ToString, dt.Rows(0).Item(4).ToString, dt.Rows(0).Item(5).ToString, FormatDateTime(dt.Rows(0).Item(6).ToString, DateFormat.ShortDate)})
  '        End If
  '        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "sfis_tdb")
  '        sqlCV.Where("tdb01", "=", pc)
  '        sqlCV.SqlFields("tdb03")
  '        sqlCV.SqlFields("tdb04")
  '        sqlCV.SqlFields("tdb05")
  '        dt = DB.RsSQL(sqlCV.Text, "tdb_wf")
  '        If dt.Rows.Count = 0 Then
  '          'wuliaochaxun.Rows.Add(New Object() {space & 0, "外發單", wl, pc, pn, "", "", ""})
  '        Else
  '          Dim I As Byte = 0
  '          For Each row As DataRow In dt.Rows
  '            liaopi(row.Item(0), row.Item(1), row.Item(2), space & I)
  '            I += 1
  '          Next
  '        End If
  '    End Select
  '  Catch ex As Exception
  '    MsgBox(ex.Message, MsgBoxStyle.OkOnly, BIG2GB("提示"))
  '  End Try
  'End Sub
  ''打開不良分析文件
  'Private Sub DGblfx_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGblfx.CellDoubleClick
  '  If e.RowIndex > -1 Then
  '    Try
  '      Dim dt As DataTable = DB.RsSQL("select TMB05 from sfis_tmb where NO='" & DGblfx.Rows(e.RowIndex).Cells(0).Value & "'", "safd")
  '      Dim path As String = strAPATH & "\file\" & DGblfx.Rows(e.RowIndex).Cells(1).Value
  '      Dim by() As Byte = dt.Rows(0).Item(0)
  '      If IO.Directory.Exists(strAPATH & "\file") = False Then
  '        IO.Directory.CreateDirectory(strAPATH & "\file")
  '      End If
  '      IO.File.WriteAllBytes(path, by)
  '      Process.Start(path)
  '    Catch ex As Exception
  '      MsgBox(ex.Message, MsgBoxStyle.OkOnly, BIG2GB("提示"))
  '    End Try
  '  End If
  'End Sub

  'Private Sub dgyljl_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgyljl.CellContentClick
  '  If e.RowIndex = -1 Then Return
  '  Dim str As String = liaopistr(dgyljl.Rows(e.RowIndex).Cells(BIG2GB("料號")).Value, "", dgyljl.Rows(e.RowIndex).Cells(BIG2GB("批序號")).Value)
  '  MsgBox(str, MsgBoxStyle.OkOnly, BIG2GB("料批追朔   物料:") & dgyljl.Rows(e.RowIndex).Cells(BIG2GB("料號")).Value & _
  '         BIG2GB("批序號:") & dgyljl.Rows(e.RowIndex).Cells(BIG2GB("批序號")).Value)
  'End Sub
  'Function liaopistr(ByVal wl As String, ByVal pc As String, ByVal pn As String, Optional ByVal space As Integer = -4)
  '  Dim Str As String = ""
  '  space += 4
  '  Select Case pn.Substring(0, 1)
  '    Case "R"  ''進料
  '      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "sfis_te")
  '      sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "sfis_tca", "tca03", "=", "sfis_te.te21")
  '      sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "sfis_tbb", "tbb03", "=", "sfis_te.te01")

  '      sqlCV.Where("sfis_te.te01", "=", wl)
  '      sqlCV.Where("sfis_te.te03", "=", pn)
  '      sqlCV.SqlFields("isnull(sfis_tca.tca03+':'+sfis_tca.tca02,'')")
  '      sqlCV.SqlFields("sfis_te.te23") '備註
  '      sqlCV.SqlFields("sfis_te.te16") '製造日期
  '      sqlCV.SqlFields("^2.tbb05+'|'+sfis_tbb.tbb10") '名稱
  '      sqlCV.SqlFields("^2.tbb08") '名稱
  '      sqlCV.SqlFields("sfis_te.te14") '原批號
  '      Dim dt = DB.RsSQL(sqlCV.Text, "12")
  '      Str = "".PadRight(space) & BIG2GB("來自採購單：物料編號《" & wl & "》收料單《" & pc & _
  '            "》SFIS批序號《" & pn & "》物料類別" & dt.Rows(0).Item(4).ToString & _
  '            " 原批號" & dt.Rows(0).Item(5).ToString & "備註" & _
  '            dt.Rows(0).Item(1).ToString & "供應商" & dt.Rows(0).Item(0).ToString & _
  '            "物料名字" & dt.Rows(0).Item(3).ToString & " 製造日期：" & _
  '            dt.Rows(0).Item(2).ToString)
  '    Case "M"  '工單
  '      If pc = "" Then
  '        pc = DB.ExecuteScalar("select te02 from sfis_te where te03='" & pn & "' and te01='" & wl & "'")
  '      End If
  '      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "sfis_tdb")
  '      sqlCV.Where("tdb01", "=", pc)
  '      sqlCV.SqlFields("tdb03")
  '      sqlCV.SqlFields("tdb04")
  '      sqlCV.SqlFields("tdb05")
  '      Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "tdb_wf")
  '      If dt.Rows.Count = 0 Then Return "".PadRight(space) & BIG2GB("來自加工單：" & pc & " 沒有找到發料信息")
  '      Str &= "".PadRight(space) & BIG2GB("來自加工單:" & pc & " 信息  ") & vbCrLf
  '      For Each row As DataRow In dt.Rows
  '        Str &= liaopistr(row.Item(0), row.Item(1), row.Item(2), space) & vbCrLf
  '      Next
  '    Case "F"  '‘外發單
  '      If pc = "" Then
  '        pc = DB.ExecuteScalar("select te02 from sfis_te where te03='" & pn & "' and te01='" & wl & "'")
  '      End If
  '      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "sfis_te")
  '      sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "sfis_tca", "tca03", "=", "sfis_te.te21")
  '      sqlCV.Where("sfis_te.te01", "=", wl)
  '      sqlCV.Where("sfis_te.te02", "=", pc)
  '      sqlCV.Where("sfis_te.te03", "=", pn)
  '      sqlCV.SqlFields("sfis_tca.tca02+'('+sfis_tca.tca03+')'")
  '      Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "dd")
  '      Dim wfchangshang As String
  '      If dt.Rows.Count = 0 Then
  '        wfchangshang = BIG2GB("無記錄")
  '      Else
  '        wfchangshang = dt.Rows(0).Item(0).ToString
  '      End If
  '      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "sfis_tdb")
  '      sqlCV.Where("tdb01", "=", pc)
  '      sqlCV.SqlFields("tdb03")
  '      sqlCV.SqlFields("tdb04")
  '      sqlCV.SqlFields("tdb05")
  '      dt = DB.RsSQL(sqlCV.Text, "tdb_wf")
  '      If dt.Rows.Count = 0 Then Return "".PadRight(space) & BIG2GB("來自外發單：" & pc & " 沒有找到發料信息, " & _
  '        " 外發廠商:" & wfchangshang)
  '      Str &= "".PadRight(space) & BIG2GB("來自外發單:" & pc & "   外發廠商:" & wfchangshang) & vbCrLf
  '      For Each row As DataRow In dt.Rows
  '        Str &= liaopistr(row.Item(0), row.Item(1), row.Item(2), space) & vbCrLf
  '      Next
  '  End Select
  '  Return Str
  'End Function
  Private Sub GetTMTab(strM As String, strT As String, rs As DataTable, aryc As Dictionary(Of String, DataColumn), aryR As Dictionary(Of String, DataRow))
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TM")
    sqlCV.Where("TM01", "IN", strM.Trim(","), intFMode.msfld_field)
    sqlCV.Where("TM02", "=", strT)
    sqlCV.SqlFields("*")
    sqlCV.sqlOrder("TM01", SQLCNV.intOrder.Order_Asc)
    sqlCV.sqlOrder("TM06", SQLCNV.intOrder.Order_Dsc)
    Dim rsTM As DataTable = DB.RsSQL(sqlCV.Text, "RTM")
    For Each r As DataRow In rsTM.Rows
      Dim r1 As DataRow = aryR(r!TM01.ToString.Trim)
      Dim strK() As String = r!TM07.ToString.Trim.Split("@")
      Dim intI As Integer = strK(0).IndexOf("^")
      Dim strG() As String
      Dim strI() As String
      If intI >= 0 Then
        strG = strK(0).Substring(intI + 1).Split("^")
        If intI = 0 Then
          strI = strK(0).Split(",")
        Else
          strI = strK(0).Substring(0, intI).Split(",")
        End If
      Else
        strI = strK(0).Split(",")
        strG = "".Split("^")
      End If
      For Each strIT As String In strI
        If strIT.Trim = "" Then Continue For
        Dim strIS() As String = strIT.Split("|=".ToCharArray)
        If aryc.ContainsKey(strIS(0)) = True Then
          Dim strGI As String = r1.Item(aryc(strIS(0)).ColumnName).ToString.Trim
          If strGI.Contains(strIS(1)) = False Then
            r1.Item(aryc(strIS(0)).ColumnName) = (strGI & "," & strIS(1)).Trim(",")
          End If
        End If
      Next
      For Each strGT As String In strG
        If strGT.Trim = "" Then Continue For
        Dim strIS() As String = strGT.Split("|=".ToCharArray)
        Dim strGK As String = ""
        Dim strGV As String = ""
        If strIS.Length = 2 Then
          strGK = strIS(0).Trim
          strGV = strIS(1).Trim
        ElseIf strIS.Length = 3 Then
          strGK = (strIS(0).Trim & "_" & strIS(1).Trim).Trim("_")
          strGV = strIS(2).Trim
        End If
        If aryc.ContainsKey(strGK) = True Then
          Dim strGI As String = r1.Item(aryc(strGK).ColumnName).ToString.Trim
          If strGI = "" Then
            r1.Item(aryc(strGK).ColumnName) = strGV
          End If
        End If
      Next
    Next
  End Sub
  Private Function SetByDGTab(Dgs As DataGridView, strT As String, strMat As String, aryID As ArrayList) As DataTable
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QJB")
    sqlCV.Where("QJB02", "=", strMat)
    Dim w As APSQL.SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_QJA", "QJA01", "=", "SFIS_QJB.QJB01")
    w.Add("SFIS_QJA.QJA02", "=", "SFIS_QJB.QJB04")
    w.Add("SFIS_QJA.QJA12", "=", "'" & strT & "'")
    sqlCV.SqlFields("^0.QJB04", , , , True)
    sqlCV.SqlFields("^1.QJA03")
    sqlCV.SqlFields("^0.QJB06")
    sqlCV.SqlFields("^0.QJB07")
    sqlCV.SqlFields("^0.QJB08")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RQB")
    Dim rst As New DataTable
    Dim aryC As New Dictionary(Of String, DataColumn)
    rst.TableName = strT
    rst.Columns.Add(BIG2GB("序號"), GetType(String))
    For Each r As DataRow In rs.Rows
      Dim strV As String = r!QJB08.ToString.Trim
      If strV <> "" Then
        Dim strS() As String = Split(strV, "||")
        For Each strSK As String In strS
          If strSK.Trim = "" Then Continue For
          aryC.Add(r!QJB04.ToString.Trim & "_" & strSK.Trim, rst.Columns.Add(r!QJB04.ToString.Trim & "_" & strSK.Trim, GetType(String)))
        Next
      Else
        aryC.Add(r!QJB04.ToString.Trim, rst.Columns.Add(r!QJA03.ToString.Trim, GetType(String)))
      End If
    Next
    If CheckBox3.Checked Then
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_distinc, "SFIS_TDB")
      sqlCV.Where("TDB01", "=", MOgd)
      sqlCV.Where("TDB02", "=", strT)
      sqlCV.SqlFields("TDB03", , , , True)
      rs = DB.RsSQL(sqlCV.Text, "RQB")
      For Each r As DataRow In rs.Rows
        aryC.Add(r!TDB03.ToString.Trim, rst.Columns.Add(r!TDB03.ToString.Trim, GetType(String)))
      Next
      DB.CloseRs(rs)
    End If
    Dim aryR As New Dictionary(Of String, DataRow)
    Dim strM As String = ""
    For Each strID As String In aryID
      aryR.Add(strID, rst.Rows.Add(strID))
      strM &= "'" & strID.Trim & "',"
      If strM.Length > 1024 Then
        GetTMTab(strM, strT, rst, aryC, aryR)
        strM = ""
      End If
    Next
    If strM <> "" Then
      GetTMTab(strM, strT, rst, aryC, aryR)
    End If
    Dgs.DataSource = rst
    Return rst
  End Function
  Private Sub TabPage9_Enter(sender As Object, e As EventArgs) Handles TabPage9.Enter
    If TabPage9.Tag = MOgd Then
      SeekDGTab(aryIDs)
      Return
    End If
    TextBox1.Text = My.Settings.XLSPATH
    TabPage9.Tag = MOgd
    While TCINSP.TabPages.Count > 1
      TCINSP.TabPages.RemoveAt(1)
    End While
    TCINSP.TabPages(0).Text = ""
    Dim strN As String = "DG" & TCINSP.TabPages(0).Name
    Dim D As DataGridView = TCINSP.TabPages(0).Controls(strN)
    D.DataSource = Nothing
    If MOgd.Trim = "" Then Return
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TD")
    sqlCV.Where("TD01", "=", MOgd.Trim)
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TDA", "TDA01", "=", "^0.TD01")
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TA", "TA01", "=", "SFIS_TDA.TDA03")
    sqlCV.SqlFields("^1.TDA02", , , , True)
    sqlCV.SqlFields("^1.TDA03")
    sqlCV.SqlFields("^2.TA02")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count = 0 Then
      Return
    End If
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
    sqlCV.Where("^0.TN02", "=", MOgd)
    sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TD", "TD01", "=", "SFIS_TN.TN02")
    sqlCV.SqlFields("^0.TN01", , , , True)
    sqlCV.SqlFields("^1.TD02")
    Dim rs1 As DataTable = DB.RsSQL(sqlCV.Text, "RTN")
    Dim aryL As New ArrayList, strMat As String = ""
    If rs1.Rows.Count = 0 Then Return
    strMat = rs1.Rows(0)!TD02.ToString.Trim
    For Each r As DataRow In rs1.Rows
      aryL.Add(r!TN01.ToString.Trim)
    Next
    DB.CloseRs(rs1)
    For intI As Integer = 0 To rs.Rows.Count - 1
      If intI > 0 Then
        TCINSP.TabPages.Add("T" & intI.ToString("0"), rs.Rows(intI)!TDA03.ToString.Trim & " " & rs.Rows(intI)!TA02.ToString.Trim)
        Dim DGs As New DataGridView
        DGs.Visible = True
        DGs.Name = "DGT" & intI.ToString("0")
        TCINSP.TabPages(intI).Controls.Add(DGs)
        DGs.AlternatingRowsDefaultCellStyle = DGB.AlternatingRowsDefaultCellStyle
        DGs.Dock = DockStyle.Fill
        DGs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        SetByDGTab(DGs, rs.Rows(intI)!TDA03.ToString.Trim, strMat, aryL)
      Else
        TCINSP.TabPages(0).Text = rs.Rows(intI)!TDA03.ToString.Trim & " " & rs.Rows(intI)!TA02.ToString.Trim
        SetByDGTab(DGB, rs.Rows(intI)!TDA03.ToString.Trim, strMat, aryL)
      End If
    Next
    SeekDGTab(aryIDs)
  End Sub

  Private Sub SeekDGTab(strKey As String)
    If strKey = "" Then Return
    For Each tp As TabPage In TCINSP.TabPages
      For Each c As Control In tp.Controls
        If c.GetType Is GetType(DataGridView) Then
          Dim DG As DataGridView = c
          For Each r As DataGridViewRow In DG.Rows
            If GCell(r.Cells(0)) = strKey Then
              DG.CurrentCell = r.Cells(0)
              Exit For
            End If
          Next
          Exit For
        End If
      Next
    Next
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    Dim OFL As New FolderBrowserDialog
    TextBox1.Text = My.Settings.XLSPATH
    OFL.SelectedPath = TextBox1.Text
    OFL.RootFolder = Environment.SpecialFolder.MyComputer
    OFL.Description = "Select a Excel File Path"
    If OFL.ShowDialog = Windows.Forms.DialogResult.OK Then
      TextBox1.Text = OFL.SelectedPath
      My.Settings.XLSPATH = OFL.SelectedPath
      My.Settings.Save()
      Dim clsxls = New XLS_FILE
      For Each T As TabPage In TCINSP.TabPages
        For Each c As Control In T.Controls
          If c.GetType Is GetType(DataGridView) Then
            Dim rs As DataTable = CType(c, DataGridView).DataSource
            clsxls.Rs2XLS(rs, T.Text, MOgd, "1111111111111111")
          End If
        Next
      Next
      clsxls.Close(TextBox1.Text.Trim(" \".ToCharArray) & "\" & MOgd)
      clsxls = Nothing
    End If
  End Sub

  Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
    TabPage9.Tag = ""
    TabPage9_Enter(Nothing, Nothing)
  End Sub

  Private Sub DGblfx_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGblfx.CellFormatting
    Select Case e.ColumnIndex
      Case 1
        Dim strM As String = GCell(DGblfx.Rows(e.RowIndex).Cells(e.ColumnIndex))
        e.Value = GetErrCode(strM, , False)
      Case 2, 6
        Dim strM As String = GCell(DGblfx.Rows(e.RowIndex).Cells(e.ColumnIndex))
        e.Value = GetUser(strM)
      Case 4
        Dim strM As String = GCell(DGblfx.Rows(e.RowIndex).Cells(e.ColumnIndex))
        e.Value = GetErrCode(strM, "TG", False)
      Case 5
        Dim strM As String = GCell(DGblfx.Rows(e.RowIndex).Cells(e.ColumnIndex))
        e.Value = GetErrCode(strM, "TH", False)
      Case 9
        Dim strM As String = GCell(DGblfx.Rows(e.RowIndex).Cells(e.ColumnIndex))
        Select Case strM
          Case "-1"
            e.Value = "待修"
          Case "0"
            e.Value = "完修"
          Case "1"
            e.Value = "換人維修"
          Case "8"
            e.Value = "報廢"
        End Select
    End Select
  End Sub


  Private Sub txtppida1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtppida1.KeyPress, _
    txtppida2.KeyPress, Txtwuliao.KeyPress, Txtpo.KeyPress, Txtboxno.KeyPress, TxtCsaleid.KeyPress, _
    Txtcustomerid.KeyPress, ComboBox3.KeyPress, DateTimePicker1.KeyPress, DateTimePicker2.KeyPress
    If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
      e.Handled = True
      My.Computer.Keyboard.SendKeys(vbTab)
    End If
  End Sub

  Private Sub txtppida1_Validated(sender As Object, e As EventArgs) Handles txtppida1.Validated, _
    txtppida2.Validated, Txtwuliao.Validated
    Dim t As TextBox = sender
    If t.Text.Trim.Length > 60 Then
      t.Text = t.Text.Trim.Split("|")(0).Trim
    End If
  End Sub

  Private Sub dggdbom_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dggdbom.CellFormatting
    Dim strV As String = GCell(dggdbom.Rows(e.RowIndex).Cells(e.ColumnIndex))
    Dim strCN As String = dggdbom.Columns(e.ColumnIndex).Name
    Select Case strCN
      Case BIG2GB("供應商")
        If aryCName.ContainsKey(strV) = True Then
          e.Value = strV & "," & aryCName(strV)
        End If
    End Select
  End Sub

  Private Sub RelistDgOp(strOp As String)
Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_SD")
    Dim w As APSQL.SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_SA", "SA01", "=", "^0.SD02")
    w.Add("SFIS_SA.SA05", "=", "'" & strOp & "'")
    sqlCV.Where("^0.SD18", "=", 0)
    sqlCV.Where("ISNULL(^0.SD08,'')", "<>", "")
    sqlCV.SqlFields("^1.SA05", "工單", , True, True)
    sqlCV.SqlFields("^0.SD09", "物料編號", , True, True)
    sqlCV.SqlFields("^0.SD12", "品名", , True)
    sqlCV.SqlFields("^0.SD10", "批號", , True, True)
    sqlCV.SqlFields("('')", "廠商編號")
    sqlCV.SqlFields("^0.SD11", "其他資訊", , True)
    sqlCV.SqlFields("^0.SD13", "單位用量", , True)
    sqlCV.SqlFields("Count(*)", "操作次數")
    sqlCV.SqlFields("count(distinct ^1.SA04)", "操作人數")
    'sqlCV.SqlFields("^0.SD03", "操作時間")
    Dim rs As DataTable = DB.RsSQL(BIG2GB(sqlCV.Text), "DG2")
    For Each r As DataRow In rs.Rows
      Dim strM() As String = r.Item(3).ToString.Trim.Split("_")
      r.Item(3) = strM(0).Trim
      If strM.Length > 1 Then
        r.Item(4) = strM(1).Trim
      End If
    Next
    DgOp.DataSource = rs
  End Sub

  Private Sub dggd_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dggd.DataBindingComplete
    dggd.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
  End Sub
  Private Sub dggd_Scroll(sender As Object, e As ScrollEventArgs) Handles dggd.Scroll
    dggd.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
  End Sub


  Private Sub DGB_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DGB.DataBindingComplete
    DGB.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
  End Sub

  Private Sub DGB_Scroll(sender As Object, e As ScrollEventArgs) Handles DGB.Scroll
    DGB.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
  End Sub

  Private Sub DGblfx_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DGblfx.DataBindingComplete
    DGblfx.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
  End Sub

  Private Sub DGblfx_Scroll(sender As Object, e As ScrollEventArgs) Handles DGblfx.Scroll
    DGblfx.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
  End Sub

  Private Sub dggdbom_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dggdbom.DataBindingComplete
    dggdbom.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
  End Sub

  Private Sub dggdbom_Scroll(sender As Object, e As ScrollEventArgs) Handles dggdbom.Scroll
    dggdbom.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
  End Sub

  Private Sub Dggdfl_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles Dggdfl.DataBindingComplete
    Dggdfl.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
  End Sub

  Private Sub Dggdfl_Scroll(sender As Object, e As ScrollEventArgs) Handles Dggdfl.Scroll
    Dggdfl.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
  End Sub

  Private Sub Dggdmx_Scroll(sender As Object, e As ScrollEventArgs) Handles Dggdmx.Scroll
    Dggdmx.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
  End Sub

  Private Sub Dggdmx_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles Dggdmx.DataBindingComplete
    Dggdmx.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
  End Sub

  Private Sub DgOp_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DgOp.DataBindingComplete
    DgOp.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
  End Sub

  Private Sub DgOp_Scroll(sender As Object, e As ScrollEventArgs) Handles DgOp.Scroll
    DgOp.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
  End Sub

  Private Sub dgqcjl_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgqcjl.DataBindingComplete
    dgqcjl.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
  End Sub

  Private Sub dgqcjl_Scroll(sender As Object, e As ScrollEventArgs) Handles dgqcjl.Scroll
    dgqcjl.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
  End Sub

  Private Sub dgscjl_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgscjl.DataBindingComplete
    dgscjl.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
  End Sub

  Private Sub dgscjl_Scroll(sender As Object, e As ScrollEventArgs) Handles dgscjl.Scroll
    dgscjl.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
  End Sub

  Private Sub dgyljl_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgyljl.DataBindingComplete
    dgyljl.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
  End Sub

  Private Sub dgyljl_Scroll(sender As Object, e As ScrollEventArgs) Handles dgyljl.Scroll
    dgyljl.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
  End Sub

  Private Sub fqcjl_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles fqcjl.DataBindingComplete
    fqcjl.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
  End Sub

  Private Sub fqcjl_Scroll(sender As Object, e As ScrollEventArgs) Handles fqcjl.Scroll
    fqcjl.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
  End Sub

  Private Sub dgscjl_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgscjl.CellContentClick
    If e.RowIndex < 0 Or e.RowIndex >= dgscjl.Rows.Count Then Return
    If e.ColumnIndex = dgscjl.Columns.Count - 2 Then
      Dim bolMode As Boolean = False
      Dim intV As Integer = Val(GCell(dgscjl.Rows(e.RowIndex).Cells("UID")))
      Dim sqlCV As New APSQL.SQLCNV
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TM")
      sqlCV.Where("USEQ", "=", intV, intFMode.msfld_num)
      sqlCV.SqlFields("TM15")
      Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
      If rs.Rows.Count = 0 Then Return
      If rs.Rows(0)!TM15.GetType Is GetType(DBNull) Then Return
      Dim bytV() As Byte = rs.Rows(0)!TM15
      If bytV Is Nothing OrElse bytV.Length = 0 Then Return
      For intI As Integer = 0 To 15
        If bytV.GetUpperBound(0) > intI Then
          If bytV(intI) > 127 Then bolMode = True
          Exit For
        End If
      Next
      Dim strG As String = ""
      Dim fs As New IO.MemoryStream
      Dim bmpX As Bitmap = Nothing
      If bolMode = False Then
        strG = System.Text.Encoding.UTF8.GetString(bytV)
      Else
        Try
          fs.Write(bytV, 0, bytV.Length)
          bmpX = New Bitmap(fs)
        Catch ex As Exception
          fs.Close()
          fs.Dispose()
          DB.CloseRs(rs)
          fs = Nothing
          bmpX = Nothing
          bolMode = False
          Return
        End Try
      End If
      Dim frm1 As New frmViewBmp
      If bolMode Then
        frm1.Bmps = bmpX
      Else
        frm1.DGText = strG
      End If
      frm1.ShowDialog()
      fs.Close()
      fs.Dispose()
      If bmpX IsNot Nothing Then bmpX.Dispose()
      bmpX = Nothing
      fs = Nothing
      DB.CloseRs(rs)
    End If
  End Sub

  Private Sub TabPage13_Enter(sender As Object, e As EventArgs) Handles TabPage13.Enter
    ComboBox1.SelectedIndex = My.Settings.intSNType
    Button1_Click(Nothing, Nothing)
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    DGSNT.DataSource = Nothing
    If ComboBox1.Text.Trim = "" Then
      MsgBox(BIG2GB("必須先選擇工單號"))
      Return
    End If
    Dim s As New clsSNDTLS(ComboBox3.Text.Trim)
    s.intSMode = ComboBox1.SelectedIndex
    s.CalMo()
    DGSNT.DataSource = s.MakeTable
    If DGSNT.Rows.Count > 0 Then My.Settings.intSNType = ComboBox1.SelectedIndex
  End Sub

  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    Dim OFL As New SaveFileDialog
    If My.Settings.XLSPATH = "" Then
      OFL.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
    Else
      OFL.InitialDirectory = My.Settings.XLSPATH
    End If
    OFL.Filter = "Excel Files|*.xls;*.xlsx|所有檔案|*.*"
    OFL.OverwritePrompt = True
    OFL.DefaultExt = "xlsx"
    If OFL.ShowDialog = Windows.Forms.DialogResult.OK Then
      My.Settings.XLSPATH = IO.Path.GetDirectoryName(OFL.FileName)
      My.Settings.Save()
      Dim clsxls = New XLS_FILE
      Dim rs As DataTable = CType(DGSNT, DataGridView).DataSource
      clsxls.Rs2XLS(rs, rs.TableName, "", "11111111111111111111")
      clsxls.Close(OFL.FileName)
      clsxls = Nothing
    End If
  End Sub
End Class

