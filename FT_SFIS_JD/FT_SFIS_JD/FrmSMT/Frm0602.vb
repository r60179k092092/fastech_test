Public Class Frm0602
  Private bolLOCK As Boolean = False

  Private Sub Frm0602_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    TuiCK(Me)
  End Sub
  Private Sub frmC2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    DG_RELIST()
    dgdaochu(DG)
    dgdaochu(DG2)
    dgdaochu(DG3)
  End Sub
  Private Sub DG_RELIST(Optional ByVal strID As String = "")
    Dim sqlCV As New APSQL.SQLCNV, strCD As String = ""
    If Ck1.Checked = True Then strCD &= "'0',"
    If Ck2.Checked = True Then strCD &= "'1',"
    If Ck3.Checked = True Then strCD &= "'2',"
    If Ck4.Checked = True Then strCD &= "'3',"
    If Ck5.Checked = True Then strCD &= "'4',"
    If Ck7.Checked = True Then strCD &= "'9',"
    If strCD.Trim(" ,".ToCharArray) = "" Then Return
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_SB")
    Dim w As SqlWhere = sqlCV.SqlJoin(SQLCNV.intJoinMode.msJoin_Left, "SFIS_SD", "SD05", "=", "^0.SB01")
    w.Add("SFIS_SB.SB02", "=", "SFIS_SD.SD02")
    If Ck3.Checked = True And MACH.Checked = True Then
      w.Add("SFIS_SD.SD07", "=", "'" & MACHID.Text.Trim & "'")
    End If
    sqlCV.SqlFields("SB01", "FEEDER編號", , , True)
    sqlCV.SqlFields("SB04", "料號")
    sqlCV.SqlFields("CASE WHEN SB09=2 THEN SD07+'.'+SD08 ELSE '' END", "機台站號")
    sqlCV.SqlFields("SB09", "狀態")
    sqlCV.SqlFields("SB10", "保養日期")
    sqlCV.SqlFields("SB13", "使用次數")
    sqlCV.SqlFields("SB22", "次數上限")
    sqlCV.SqlFields("SB12", "保養逾期日")
    sqlCV.SqlFields("SB17", "總保養次數")
    sqlCV.SqlFields("SB15", "總維修次數")
    sqlCV.SqlFields("SB16", "總上料次數")
    sqlCV.SqlFields("SB23", "總次數上限")
    sqlCV.SqlFields("SB18", "首用日期")
    sqlCV.SqlFields("SB19", "使用者")
    sqlCV.SqlFields("SB20", "保養者")
    sqlCV.SqlFields("SB21", "維修者")
    sqlCV.SqlFields("SB11", "下次保養日期")
    sqlCV.Where("SB09", "IN", strCD.Trim(" ,".ToCharArray), APSQL.intFMode.msfld_field)
    If strID.Trim.Length > 0 Then
      sqlCV.Where("SB01", "=", strID, , , "OR")
    End If
    Dim rs1 As DataTable = DB.RsSQL(BIG2GB(sqlCV.Text), "DG2_T")
    DG.DataSource = rs1
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_SB")
    sqlCV.SqlFields("SB09", , , True, True)
    sqlCV.SqlFields("COUNT(*)", "QTY")
    Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "RS")
    Label25.Text = ""
    Label3.Text = ""
    Label2.Text = ""
    Label1.Text = ""
    Label4.Text = ""
    Label27.Text = ""
    Dim intQ As Integer = 0
    For Each r As DataRow In dt.Rows
      Select Case r("SB09").ToString
        Case "0"
          Label25.Text = r("QTY").ToString
          intQ += r("QTY").ToString
        Case "1"
          Label3.Text = r("QTY").ToString
          intQ += r("QTY").ToString
        Case "2"
          Label2.Text = r("QTY").ToString
          intQ += r("QTY").ToString
        Case "3"
          Label1.Text = r("QTY").ToString
          intQ += r("QTY").ToString
        Case "9"
          Label4.Text = r("QTY").ToString
          intQ += r("QTY").ToString
        Case "4"
          Label27.Text = r("QTY").ToString
          intQ += r("QTY").ToString
      End Select
    Next
    Label7.Text = intQ
    If strID.Trim.Length > 0 Then
      For Each r As DataGridViewRow In DG.Rows
        If r.Cells(0).Value.ToString.Trim = strID.Trim Then
          DG.CurrentCell = r.Cells(0)
        End If
      Next
    End If
  End Sub
  Private Sub getFORSF(ByVal strSF As String)
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_SF")
    sqlCV.Where("SF01", "=", strSF)
    'sqlCV.SqlFields("SF01", "FEEDER編號")
    sqlCV.SqlFields("SF02", "保養日期")
    sqlCV.SqlFields("SF03", "保養員")
    sqlCV.SqlFields("SF05", "處理別")
    sqlCV.SqlFields("SF06", "處理序")
    sqlCV.SqlFields("SF07", "維修狀態")
    sqlCV.SqlFields("SF08", "FEEDER評估")
    sqlCV.sqlOrder("SF01", APSQL.SQLCNV.intOrder.Order_Dsc)
    Dim rs As DataTable = DB.RsSQL(BIG2GB(sqlCV.Text), "FORSF")
    DG2.DataSource = rs
    'If rs.Rows.Count = 0 Then
    '  'MsgBox("無保養維修記錄")
    '  Me.MSGID.Enabled = True
    '  Me.MSGID.Text = "無此保養紀錄"
    '  Me.DG2.DataSource = ""
    'Else
    '  Me.MSGID.Enabled = False
    '  Me.DG2.DataSource = rs
    'End If
  End Sub
  Private Sub getUSEFER(ByVal strUSE As String, ByVal intPA As Integer)
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_SD")
    sqlCV.SqlJoin(APSQL.SQLCNV.intJoinMode.msJoin_Inner, "SFIS_SA", "SA01", "=", "SD02")
    If intPA = 1 Then    '上料
      sqlCV.Where("SD04", "IN", "('%-M3','%-M6')", APSQL.intFMode.msfld_field)
      sqlCV.Where("SD05", "=", strUSE)
    End If
    'sqlCV.SqlFields("SD05", "FEEDER編號")
    sqlCV.SqlFields("SD03", "登入時間")
    sqlCV.SqlFields("SD07", "機臺編號")
    sqlCV.SqlFields("SD08", "料站編號")
    sqlCV.SqlFields("SD04", "操作指令")
    sqlCV.SqlFields("SA04", "刷碼工員")
    sqlCV.SqlFields("SA05", "執行工單")
    sqlCV.sqlOrder("SD03", APSQL.SQLCNV.intOrder.Order_Dsc)
    Dim rs As DataTable = DB.RsSQL(BIG2GB(sqlCV.Text), "USERFER")
    Me.DG3.DataSource = rs
  End Sub
  Private Sub Ck3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ck3.CheckedChanged, Ck1.CheckedChanged, Ck2.CheckedChanged, Ck4.CheckedChanged, Ck5.CheckedChanged, Ck7.CheckedChanged, MACH.CheckedChanged
    DG_RELIST()
    If sender.name = "Ck3" Then
      MACH.Enabled = Ck3.Checked
      MACHID.Enabled = Ck3.Checked
    End If
  End Sub

  Private Sub DG2_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DG2.CellFormatting
    If Me.DG2.Columns(e.ColumnIndex).Name = BIG2GB("維修狀態") Then
      If e.Value.ToString = "0" Then
        e.Value = BIG2GB("完修")
      ElseIf e.Value.ToString = "1" Then
        e.Value = BIG2GB("換員維修")
      ElseIf e.Value.ToString = "2" Then
        e.Value = BIG2GB("不修報廢")
      ElseIf e.Value.ToString = "3" Then
        e.Value = BIG2GB("誤判退還")
      ElseIf e.Value.ToString = "4" Then
        e.Value = BIG2GB("送外修")
      ElseIf e.Value.ToString = "5" Then
        e.Value = BIG2GB("外修回廠")
      Else
        e.Value = BIG2GB("外修報廢")
      End If
    End If
    If Me.DG2.Columns(e.ColumnIndex).Name = BIG2GB("處理別") Then
      If e.Value.ToString = "0" Then
        e.Value = BIG2GB("維修")
      ElseIf e.Value.ToString = "1" Then
        e.Value = BIG2GB("保養")
      ElseIf e.Value.ToString = "2" Then
        e.Value = BIG2GB("退回")
      Else
        e.Value = BIG2GB("外修")
      End If
    End If
  End Sub

  Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
    If e.KeyChar = vbCr Then
      Label9.Text = TextBox1.Text
      bolLOCK = True
      DG_RELIST(TextBox1.Text)
      getFORSF(TextBox1.Text)
      getUSEFER(TextBox1.Text, 1)
      My.Application.DoEvents()
      bolLOCK = False
      e.Handled = True
    Else
    End If
  End Sub

  Private Sub DG_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DG.CellFormatting
    Select Case e.ColumnIndex
      Case 3
        Dim strV As String = ""
        Select Case GCell(DG.Rows(e.RowIndex).Cells(e.ColumnIndex))
          Case "0"
            strV = "空盤"
          Case "1"
            strV = "綁定料號"
          Case "2"
            strV = "掛料站"
          Case "3"
            strV = "待保養"
          Case "4"
            strV = "不良待修"
          Case "5"
            strV = "已報廢"
          Case Else
            strV = "未啟用"
        End Select
        e.Value = BIG2GB(strV)
    End Select
  End Sub

  Private Sub DG_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.RowEnter
    If e.RowIndex < 0 Or bolLOCK Then Return
    Label9.Text = DG.Rows(e.RowIndex).Cells(0).Value.ToString
    Me.getFORSF(Label9.Text)
    Me.getUSEFER(Label9.Text, 1)
  End Sub

  Private Sub MACHID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MACHID.KeyPress
    If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
      e.Handled = True
      My.Computer.Keyboard.SendKeys(vbTab)
    End If
  End Sub

  Private Sub MACHID_Validated(sender As Object, e As EventArgs) Handles MACHID.Validated
    DG_RELIST()
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    Me.Close()
  End Sub

  Public Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()
    languagechange(Me)
    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

  End Sub
End Class
