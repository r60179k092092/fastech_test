Public Class PM0505
  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()

    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    languagechange(Me)

  End Sub
  Dim time As Short = 0
  Dim t As Short = 0
  Dim GD As String = "", WL As String = ""
  Dim gdnum As Double = 0
  Dim gdaszz As Boolean = False  ''組裝工單 
  ''退出

  Private Sub TSBexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBexit.Click
    Me.Close()
  End Sub

  Private Sub PM0505_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    TuiCK(Me)
  End Sub

  ''load
  Private Sub PM0506_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Timer1.Enabled = True
    time = My.Settings.refresh
    Trefresh()
    dgdaochu(DataGridView1)
    dgdaochu(DataGridView2)
  End Sub
  ''時間設置
  Private Sub ToolStripSeparator4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSeparator4.Click
    Dim d As String = InputBox("請輸入每次更新時間，單位秒", "更新時間設定", time)
    If d <> "" And Val(d) <> 0 Then
      time = Val(d)
    End If
    t = 0
    Trefresh()
  End Sub
  ''計時器
  Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    t += 1
    If t > time Then
      t = 0
      Trefresh()
    End If
  End Sub
  '’刷新工單
  Sub Trefresh()
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TD")
    sqlCV.SqlJoin(APSQL.SQLCNV.intJoinMode.msJoin_Left, "SFIS_TDA", "TDA01", "=", "^0.TD01")
    sqlCV.SqlJoin(APSQL.SQLCNV.intJoinMode.msJoin_Left, "SFIS_TBB", "TBB03", "=", "^0.TD02")
    Dim w As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TA", "TA01", "=", "^1.TDA03")
    w.Add("SFIS_TA.TA04", "Like", "'100[%]%'")
    sqlCV.NomalNtext = True
    sqlCV.Where("^0.TD12", "=", 1, APSQL.intFMode.msfld_num)
    sqlCV.SqlFields("^0.TD23", "製令單號", , True) '增加製令單號顯示by yang 180911 
    sqlCV.SqlFields("^0.TD01", "工單編號", , True)
    sqlCV.SqlFields("^0.TD02", "物料編號", , True)
    sqlCV.SqlFields("^2.TBB05+' '+^2.TBB06", "品名規格", , True)
    sqlCV.SqlFields("^0.TD07", "數量", , True)
    sqlCV.SqlFields("^2.TBB07", "單位", , True)
    sqlCV.SqlFields("MIN(^1.TDA05)", "已完成")
    sqlCV.SqlFields("^0.TD07-min(^1.TDA05)", "在制品")
    sqlCV.SqlFields("SUM(^1.TDA06)", "現存不良")
    sqlCV.SqlFields("SUM(^1.TDA08)", "報廢")
    sqlCV.SqlFields("SUM(^1.TDA09)", "特采")
    sqlCV.SqlFields("^0.TD03+'-'+ ^0.TD04", "專案代號", , True)
    sqlCV.SqlFields("^0.TD05+'-'+ ^0.TD06", "銷售訂單", , True)
    DataGridView1.DataSource = DB.RsSQL(BIG2GB(sqlCV.Text), "td")
    For Each c As DataGridViewColumn In DataGridView1.Columns
      c.SortMode = DataGridViewColumnSortMode.NotSortable
    Next
    If GD.Trim <> "" Then
      For Each r As DataGridViewRow In DataGridView1.Rows
        'If GD = GCell(r.Cells(0)) Then
        '  DataGridView1.CurrentCell = r.Cells(0)
        '  DataGridView1.CurrentRow.Selected = True
        'End If
        If GD = GCell(r.Cells(1)) Then  '增加製令單號顯示by yang 180911 - Begin
          DataGridView1.CurrentCell = r.Cells(1)
          DataGridView1.CurrentRow.Selected = True
        End If                         '增加製令單號顯示by yang 180911 - End
      Next
    End If
    Trefresh2()
  End Sub
  '’選擇工單
  Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
    If e.RowIndex > -1 Then
      'GD = GCell(DataGridView1.Rows(e.RowIndex).Cells(0))
      'WL = GCell(DataGridView1.Rows(e.RowIndex).Cells(1))
      'gdnum = Val(GCell(DataGridView1.Rows(e.RowIndex).Cells(3)))
      GD = GCell(DataGridView1.Rows(e.RowIndex).Cells(1)) '增加製令單號顯示by yang 180911 - Begin
      WL = GCell(DataGridView1.Rows(e.RowIndex).Cells(2))
      gdnum = Val(GCell(DataGridView1.Rows(e.RowIndex).Cells(4))) '增加製令單號顯示by yang 180911 - End
      DataGridView1.Rows(e.RowIndex).Selected = True
      Trefresh2()
    End If
  End Sub
  '刷新工單明細
  Sub Trefresh2()
    If GD = "" Then Return
    wobijiao()
  End Sub
  '’‘’‘’組裝工單
  Sub wobijiao()
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TDA")
    sqlCV.SqlJoin(APSQL.SQLCNV.intJoinMode.msJoin_Left, "SFIS_TA", "TA01", "=", "^0.TDA03")
    sqlCV.NomalNtext = True
    sqlCV.Where("^0.TDA01", "=", GD)
    sqlCV.SqlFields("^0.TDA02", "順序", , , True)
    sqlCV.SqlFields("^0.TDA03", "工序")
    sqlCV.SqlFields("^1.TA02+'|'+^1.TA03", "工序說明")
    sqlCV.SqlFields("^0.TDA04", "工序狀態")
    sqlCV.SqlFields(gdnum & "-ISNULL(^0.TDA05,0)", "待制品量")
    sqlCV.SqlFields("ISNULL(^0.TDA05,0)", "已生產量")
    sqlCV.SqlFields("''", "在制品量")
    sqlCV.SqlFields("ISNULL(^0.TDA06,0)", "現存不良")
    sqlCV.SqlFields("ISNULL(^0.TDA11,0)", "直通量")
    sqlCV.SqlFields("'0'", "不良個數") 'ISNULL(^1.TDA05,0)-ISNULL(^1.TDA11,0)
    sqlCV.SqlFields("ISNULL(^0.TDA12,0)", "不良次數")
    sqlCV.SqlFields("ISNULL(^0.TDA07,0)", "[刷碼次數/返工]")
    sqlCV.SqlFields("ISNULL(^0.TDA09,0)", "特采")
    sqlCV.SqlFields("ISNULL(^0.TDA08,0)", "報廢")
    sqlCV.SqlFields("ISNULL(^0.TDA10,0)", "累計上崗")
    sqlCV.SqlFields("''", "直通率")
    sqlCV.SqlFields("''", "不良率")
    sqlCV.SqlFields("''", "平均產能")
    sqlCV.SqlFields("'0'", "標準產能")
    sqlCV.SqlFields("''", "工作效率")
    sqlCV.SqlFields("'*'", "超下限")
    sqlCV.SqlFields("'*'", "下限")
    sqlCV.SqlFields("'*'", "超不良率下限")
    sqlCV.SqlFields("'*'", "不良率下限")
    sqlCV.SqlFields("'*'", "在制品超下限")
    sqlCV.SqlFields("'*'", "在制品下限")
    sqlCV.SqlFields("^1.TA04")
    DataGridView2.DataSource = DB.RsSQL(BIG2GB(sqlCV.Text), "df")
    DataGridView2.Columns("TA04").Visible = False
    Dim intPack As Integer = Val(GCell(DataGridView2.Rows(DataGridView2.Rows.Count - 1).Cells(0)))
    If yin = True Then
      For Each clm As DataGridViewColumn In DataGridView2.Columns
        If clm.Index > 19 Then
          clm.Visible = False
        End If
      Next
    End If
    For Each clm As DataGridViewColumn In DataGridView2.Columns
      clm.SortMode = DataGridViewColumnSortMode.NotSortable
    Next
    Dim i As Double
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_TJAB")
    sqlCV.Where("'" & WL & "'", "LIKE", "TJAB02+'%'", APSQL.intFMode.msfld_field)
    sqlCV.SqlFields("*")
    sqlCV.sqlOrder("TJAB02", APSQL.SQLCNV.intOrder.Order_Dsc)
    Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "xn")
    Dim arySTD As New Dictionary(Of String, DataRow)
    For Each r As DataRow In dt.Rows
      Dim strG As String = r!TJAB01.ToString.Trim
      If arySTD.ContainsKey(strG) = False Then
        arySTD.Add(strG, r)
      End If
    Next
    Dim intRow As Integer = 0, sngL As Double = 0, bolFRow As Boolean = True
    For Each row As DataGridViewRow In DataGridView2.Rows
      'WL = DB.ExecuteScalar("select top 1 * from sfis_tjab where '" & WL & "'  like  tjab02+'%'  order by tjab02 desc")
      Dim strG As String = GCell(row.Cells(1))
      If arySTD.ContainsKey(strG) Then
        Dim r As DataRow = arySTD(strG)
        row.Cells(BIG2GB("標準產能")).Value = r!TJAB03.ToString.Trim
        row.Cells(BIG2GB("超下限")).Value = r!TJAB04.ToString.Trim
        row.Cells(BIG2GB("下限")).Value = r!TJAB05.ToString.Trim
        row.Cells(BIG2GB("超不良率下限")).Value = r!TJAB06.ToString.Trim
        row.Cells(BIG2GB("不良率下限")).Value = r!TJAB07.ToString.Trim
        row.Cells(BIG2GB("在制品超下限")).Value = r!TJAB08.ToString.Trim
        row.Cells(BIG2GB("在制品下限")).Value = r!TJAB09.ToString.Trim
      End If
      row.Cells(BIG2GB("工序說明")).Value = row.Cells(BIG2GB("工序說明")).Value.ToString.Trim("| ".ToCharArray)
      Dim sngV As Double = Val(GCell(row.Cells(BIG2GB("累計上崗"))))
      If sngV <> 0 Then
        Dim sngT As Double = Val(GCell(row.Cells(BIG2GB("已生產量")))) / sngV * 60
        Dim sngS As Double = Val(GCell(row.Cells(BIG2GB("標準產能"))))
        row.Cells(BIG2GB("平均產能")).Value = sngT.ToString("0.00")
        If sngS <> 0 Then
          row.Cells(BIG2GB("工作效率")).Value = (sngT / sngS * 100).ToString("0.00")
        Else
          row.Cells(BIG2GB("工作效率")).Value = "-"
        End If
        If GCell(row.Cells(BIG2GB("超下限"))) <> "*" And sngT < Val(GCell(row.Cells(BIG2GB("超下限")))) Then
          row.Cells(BIG2GB("平均產能")).Style.BackColor = Color.Red
          row.Cells(BIG2GB("平均產能")).Style.ForeColor = Color.White
        ElseIf GCell(row.Cells(BIG2GB("下限"))) <> "*" And sngT < Val(GCell(row.Cells(BIG2GB("下限")))) Then
          row.Cells(BIG2GB("平均產能")).Style.BackColor = Color.LightYellow
          row.Cells(BIG2GB("平均產能")).Style.ForeColor = Color.Red
        End If
      End If
      row.Cells(BIG2GB("不良個數")).Value = Val(GCell(row.Cells(BIG2GB("已生產量")))) - Val(GCell(row.Cells(BIG2GB("直通量"))))
      sngV = Val(GCell(row.Cells(BIG2GB("已生產量"))))
      If sngV <> 0 Then
        i = Val(GCell(row.Cells(BIG2GB("不良個數")))) / sngV * 100
        row.Cells(BIG2GB("不良率")).Value = i.ToString("0.00")
        row.Cells(BIG2GB("直通率")).Value = (Val(GCell(row.Cells(BIG2GB("直通量")))) / sngV * 100).ToString("0.00")
        If GCell(row.Cells(BIG2GB("超不良率下限"))) <> "*" And i > Val(GCell(row.Cells(BIG2GB("超不良率下限")))) Then
          row.Cells(BIG2GB("不良率")).Style.BackColor = Color.Red
          row.Cells(BIG2GB("不良率")).Style.ForeColor = Color.White
        ElseIf GCell(row.Cells(BIG2GB("不良率下限"))) <> "*" And i > Val(GCell(row.Cells(BIG2GB("不良率下限")))) Then
          row.Cells(BIG2GB("不良率")).Style.BackColor = Color.LightYellow
          row.Cells(BIG2GB("不良率")).Style.ForeColor = Color.Red
        End If
      End If
      'row.DefaultCellStyle.BackColor = Color.FromArg
      'row.DefaultCellStyle.ForeColor = Color.Black
      If GCell(row.Cells("TA04")).StartsWith("100%") = True Then
        If bolFRow = True Then
          sngL = Val(GCell(row.Cells(BIG2GB("已生產量")))) - Val(GCell(row.Cells(BIG2GB("現存不良"))))
          bolFRow = False
          Continue For
        Else
          i = sngL - Val(GCell(row.Cells(BIG2GB("已生產量"))))
          sngL = Val(GCell(row.Cells(BIG2GB("已生產量")))) - Val(GCell(row.Cells(BIG2GB("現存不良"))))
        End If
        row.Cells(BIG2GB("在制品量")).Value = i
      Else
        row.Cells(BIG2GB("在制品量")).Value = sngL
      End If
      If GCell(row.Cells(BIG2GB("在制品超下限"))) <> "*" And i > Val(GCell(row.Cells(BIG2GB("在制品超下限")))) Then
        row.Cells(BIG2GB("在制品量")).Style.BackColor = Color.Red
        row.Cells(BIG2GB("在制品量")).Style.ForeColor = Color.White
      ElseIf GCell(row.Cells(BIG2GB("在制品下限"))) <> "*" And i > Val(GCell(row.Cells(BIG2GB("在制品下限")))) Then
        row.Cells(BIG2GB("在制品量")).Style.BackColor = Color.LightYellow
        row.Cells(BIG2GB("在制品量")).Style.ForeColor = Color.Red
      End If
    Next
    DataGridView2.Columns(1).Frozen = True
  End Sub

  '’工序狀態formatting
  Private Sub DataGridView2_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView2.CellFormatting
    If e.ColumnIndex = 3 Then
      Select Case e.Value
        Case 0
          e.Value = BIG2GB("使用")
        Case 1
          e.Value = BIG2GB("停用")
        Case 2
          e.Value = BIG2GB("鎖住")
      End Select
    End If
  End Sub
  Dim yin As Boolean = True
  Private Sub HideSTD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideSTD.Click
    ToolStripDropDownButton1.Text = BIG2GB("隱藏標準")
    HideSTD.Checked = True
    SHOWSTD.Checked = False
    yin = True
    For Each clm As DataGridViewColumn In DataGridView2.Columns
      If gdaszz = True Then
        If clm.Index > 19 Then
          clm.Visible = False
        End If
      Else
        If clm.Index > 13 Then
          clm.Visible = False
        End If
      End If
    Next
  End Sub
  Private Sub ShowSTD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SHOWSTD.Click
    ToolStripDropDownButton1.Text = BIG2GB("顯示標準")
    HideSTD.Checked = False
    SHOWSTD.Checked = True
    yin = False
    For Each clm As DataGridViewColumn In DataGridView2.Columns
      clm.Visible = True
    Next
  End Sub
  Private Sub GroupBox2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox2.DoubleClick
    If DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells Then
      DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
    Else
      DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End If
  End Sub

  Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
    If GD.Trim = "" Then
      MsgBox(BIG2GB("沒有選擇顯示工單"))
      Return
    End If
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TN")
    sqlCV.Where("TN02", "=", GD)
    sqlCV.Where("ISNULL(TN09,0)", ">", 0)
    sqlCV.SqlFields("TN01")
    Dim strT As String = sqlCV.Text
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TM")
    sqlCV.Where("TM01", "IN", strT, intFMode.msfld_field)
    sqlCV.Where("TM08", "IN", "1,2", intFMode.msfld_field)
    sqlCV.SqlFields("TM02", , , True, True)
    sqlCV.SqlFields("COUNT(DISTINCT TM01)", "QTY")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    Dim aryP As New Dictionary(Of String, Integer)
    For Each r As DataRow In rs.Rows
      aryP.Add(r!TM02.ToString.Trim, Val(r!QTY.ToString))
    Next
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TM")
    Dim w As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TN", "TN01", "=", "^0.TM01")
    w.Add("SFIS_TN.TN02", "=", "'" & GD & "'")
    sqlCV.SqlFields("TM02", , , True, True)
    sqlCV.SqlFields("COUNT(DISTINCT TM01)", "QTY")
    sqlCV.SqlFields("COUNT(*)", "CQTY")
    rs = DB.RsSQL(sqlCV.Text, "RT")
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_TDA")
    sqlCV.Where("TDA01", "=", GD)
    sqlCV.SqlFields("TDA05", 0, intFMode.msfld_num)
    sqlCV.SqlFields("TDA07", 0, intFMode.msfld_num)
    sqlCV.SqlFields("TDA11", 0, intFMode.msfld_num)
    DB.RsSQL(sqlCV.Text)
    For Each r As DataRow In rs.Rows
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_TDA")
      sqlCV.Where("TDA01", "=", GD)
      sqlCV.Where("TDA03", "=", r!TM02.ToString.Trim)
      sqlCV.SqlFields("TDA05", r!QTY.ToString.Trim, intFMode.msfld_num)
      sqlCV.SqlFields("TDA07", r!CQTY.ToString.Trim, intFMode.msfld_num)
      If aryP.ContainsKey(r!TM02.ToString.Trim) = True Then
        sqlCV.SqlFields("TDA11", Val(r!QTY.ToString.Trim) - aryP(r!TM02.ToString.Trim), intFMode.msfld_num)
      Else
        sqlCV.SqlFields("TDA11", r!QTY.ToString.Trim, intFMode.msfld_num)
      End If
      DB.RsSQL(sqlCV.Text)
    Next
    wobijiao()
  End Sub

  Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

  End Sub
End Class