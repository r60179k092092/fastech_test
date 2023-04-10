Public Class Frm0332
  Private WithEvents s1 As clsEDIT2012.clsEDIT2012
  Private aryTBE05 As New Dictionary(Of String, String)

  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()
    languagechange(Me)
    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

  End Sub

  Private Sub Frm0332_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    TuiCK(Me)
  End Sub
  Private Sub Frm0332_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TB")
    sqlCV.SqlFields("TB01")
    sqlCV.SqlFields("TB02")
    sqlCV.SqlFields("TB03")
    sqlCV.SqlFields("TB01+' '+TB02", "KEYS")
    sqlCV.SqlFields("TB01+' '+TB02+' '+TB03", "DATAS")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RTB")
    ComboBox1.ValueMember = "KEYS"
    ComboBox1.DisplayMember = "DATAS"
    ComboBox1.DataSource = rs
    If rs.Rows.Count > 0 Then
      ComboBox1.SelectedValue = rs.Rows(0)!KEYS.ToString.Trim
    End If
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", "TBE04")
    sqlCV.SqlFields("QTN02", , , , True)
    sqlCV.SqlFields("QTN03")
    sqlCV.SqlFields("QTN04")
    rs = DB.RsSQL(sqlCV.Text, "RTN1")
    ComboBox4.ValueMember = "QTN02"
    ComboBox4.DisplayMember = "QTN03"
    ComboBox4.DataSource = rs
    If rs.Rows.Count > 0 Then
      ComboBox4.SelectedValue = rs.Rows(0)!QTN02.ToString.Trim
    End If
  End Sub
  Private Sub SetCMB3()
    If ComboBox4.SelectedValue Is Nothing Then Return
    Dim strK As String = ComboBox4.SelectedValue.ToString.Trim
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", "TBE05")
    sqlCV.Where("QTN02", "Like", strK & "%")
    sqlCV.SqlFields("QTN02", , , , True)
    sqlCV.SqlFields("QTN03")
    sqlCV.SqlFields("QTN02 + ' ' + QTN03", "DATAS")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT5")
    ComboBox3.ValueMember = "QTN02"
    ComboBox3.DisplayMember = "DATAS"
    ComboBox3.DataSource = rs
    aryTBE05.Clear()
    For Each r As DataRow In rs.Rows
      aryTBE05.Add(r!QTN02.ToString.Trim, r!DATAS.ToString.Trim)
    Next
  End Sub
  Private Sub ShowTable(str1 As String, str2 As String, str3 As String, str4 As String)
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TBE")
    sqlCV.Where("TBE01", "=", str1)
    sqlCV.Where("TBE02", "=", str2)
    sqlCV.Where("TBE03", "=", str3)
    sqlCV.Where("TBE04", "=", str4)
    sqlCV.SqlFields("*")
    sqlCV.sqlOrder("TBE01", SQLCNV.intOrder.Order_Asc)
    sqlCV.sqlOrder("TBE02", SQLCNV.intOrder.Order_Asc)
    sqlCV.sqlOrder("TBE03", SQLCNV.intOrder.Order_Asc)
    sqlCV.sqlOrder("TBE04", SQLCNV.intOrder.Order_Asc)
    sqlCV.sqlOrder("TBE05", SQLCNV.intOrder.Order_Asc)
    sqlCV.sqlOrder("TBE06", SQLCNV.intOrder.Order_Asc)
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    DG1.Rows.Clear()
    DG1.Columns.Clear()
    If rs.Rows.Count > 0 Then
      Dim strK As String = rs.Rows(0)!TBE01.ToString.Trim & " " & rs.Rows(0)!TBE02.ToString.Trim
      ComboBox1.SelectedValue = strK
      ComboBox4.SelectedValue = rs.Rows(0)!TBE04.ToString.Trim
    End If
    Dim r1 As DataRowView = ComboBox4.SelectedItem
    If r1 Is Nothing OrElse ComboBox1.SelectedValue Is Nothing Then Return
    SetCMB3()
    Dim strF() As String = r1!QTN04.ToString.Trim.Split("^")
    DG1.Columns.Add("C1", BIG2GB("工藝難度"))
    Dim aryFLD As New Dictionary(Of String, String)
    For Each strK1 As String In strF
      Dim strM() As String = strK1.Split("|")
      For Each strK2 As String In strM
        Dim strF1 As String = "C" & DG1.ColumnCount
        aryFLD.Add(BIG2GB(strK2), strF1)
        DG1.Columns.Add(strF1, BIG2GB(strK2))
      Next
    Next
    DG1.Columns.Add("RMK", BIG2GB("備註"))
    If rs.Rows.Count > 0 Then
      DG1.Rows.Add(rs.Rows.Count)
      For intI As Integer = 0 To rs.Rows.Count - 1
        Dim r As DataRow = rs.Rows(intI)
        Dim r2 As DataGridViewRow = DG1.Rows(intI)
        If aryTBE05.ContainsKey(r!TBE05.ToString) Then
          r2.Cells("C1").Value = aryTBE05(r!TBE05.ToString.Trim)
        End If
        r2.Cells("C2").Value = r!TBE06.ToString.Trim
        Dim strM() As String = r!TBE07.ToString.Trim.Split(",")
        For Each strMM As String In strM
          Dim strM2() As String = strMM.Split("=")
          If strM2.Length <> 2 Then Continue For
          If aryFLD.ContainsKey(strM2(0)) Then
            r2.Cells(aryFLD(strM2(0))).Value = strM2(1)
          End If
        Next
        r2.Cells("RMK").Value = r!TBE10.ToString.Trim
      Next
    Else
      Dim rs1 As DataTable = ComboBox3.DataSource
      DG1.Rows.Add(rs1.Rows.Count)
      For intI As Integer = 0 To rs1.Rows.Count - 1
        DG1.Rows(0).Cells(0).Value = rs1.Rows(0)!DATAS.ToString.Trim
      Next
    End If
  End Sub
  Private Sub s1_DVSelect(s As clsEDIT2012.clsEDIT2012, r As DataGridViewRow) Handles s1.DVSelect
    If r Is Nothing Then Return

  End Sub

  Private Sub s1_DVTable(s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String) Handles s1.DVTable
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TBE")
    Dim w As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Inner, "SFIS_TB", "TB01", "=", "^0.TBE01")
    w.Add("SFIS_TB.TB02", "=", "SFIS_TBE.TBE02")
    sqlCV.Where("^0.TBE11", "<>", "9")
    sqlCV.SqlFields("^0.TBE01", "流程編號", , True, True)
    sqlCV.SqlFields("^0.TBE02", "流程版次", , True, True)
    sqlCV.SqlFields("^0.TB03", "流程說明", , True)
    sqlCV.SqlFields("^0.TBE03", "工序", , True, True)
    sqlCV.SqlFields("^0.TBE04", "類型", , True, True)
    sqlCV.SqlFields("COUNT(^0.*)", "筆數")
    sqlCV.SqlFields("MAX(^0.TBE12)", "最後編輯日期")
    strSQL = BIG2GB(sqlCV.Text)
  End Sub

  Private Sub s1_Frm_CheckDup(s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String) Handles s1.Frm_CheckDup

  End Sub

  Private Sub s1_Frm_Clear(s As clsEDIT2012.clsEDIT2012) Handles s1.Frm_Clear

  End Sub

  Private Sub s1_Frm_Delete(s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String, ByRef bolOK As Boolean) Handles s1.Frm_Delete

  End Sub

  Private Sub s1_Frm_InsertD(s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String, intL As Integer) Handles s1.Frm_InsertD

  End Sub

  Private Sub s1_Frm_InsertM(s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String, ByRef intR As Integer) Handles s1.Frm_InsertM

  End Sub

  Private Sub s1_Frm_UpdateClear(s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String) Handles s1.Frm_UpdateClear

  End Sub

  Private Sub s1_Frm_UpdateM(s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String, ByRef intR As Integer) Handles s1.Frm_UpdateM

  End Sub

  Private Sub s1_isDataValid(s As clsEDIT2012.clsEDIT2012, ByRef bolOK As Boolean) Handles s1.isDataValid

  End Sub
End Class