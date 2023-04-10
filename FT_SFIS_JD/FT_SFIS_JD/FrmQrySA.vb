Public Class FrmQrySA
  Private intSelRow As Integer = -1 ' As DataGridViewRow = Nothing
  Private strSelItem As String = ""
  Private strList As String = ""
  Private rs As DataTable = Nothing
  Private strClass As String = ""
  Private strNQRY As String = ""
  Private bolHasWF As Boolean = False
  Private aryT As New Dictionary(Of String, String)
  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()

    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    languagechange(Me)

  End Sub
  Public Property CLASSV As String
    Get
      If ComboBox1.SelectedValue Is Nothing Then
        Return ""
      Else
        Return ComboBox1.SelectedValue.ToString.Trim
      End If
    End Get
    Set(value As String)
      strClass = value
      ComboBox1.SelectedValue = value
      If ComboBox1.SelectedValue Is Nothing Then
        CheckBox2.Checked = False
      Else
        CheckBox2.Checked = True
      End If
    End Set
  End Property
  Public Property HasWF As Boolean
    Get
      Return bolHasWF
    End Get
    Set(value As Boolean)
      bolHasWF = value
    End Set
  End Property
  Public ReadOnly Property Item() As String()
    Get
      If strList = "" AndAlso intSelRow >= 0 Then strList = GCell(DG.Rows(intSelRow).Cells(0))
      Return strList.Split(vbCr)
    End Get
  End Property
  Public Property SelectOne As Boolean
    Get
      Return Not Button1.Enabled
    End Get
    Set(value As Boolean)
      Button1.Enabled = Not value
    End Set
  End Property
  Public Property NQRY As String
    Get
      Return strNQRY
    End Get
    Set(value As String)
      strNQRY = value
    End Set
  End Property
  Public Property QRY As String
    Get
      Return TextBox1.Text.Trim
    End Get
    Set(value As String)
      TextBox1.Text = value
    End Set
  End Property
  Private Sub FrmQrySA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    rs = clsQTN.ReBind("ICLASS")
    SourceControl(ComboBox1, "ICLASS")
    For Each r As DataRow In rs.Rows
      If aryT.ContainsKey(r!ID.ToString.Trim) = False Then
        aryT.Add(r!ID.ToString.Trim, r!CNAME.ToString.Trim)
      End If
    Next
    If strClass <> "" Then
      ComboBox1.SelectedValue = strClass
      If ComboBox1.SelectedValue IsNot Nothing Then
        CheckBox2.Checked = True
      Else
        CheckBox2.Checked = False
      End If
    End If
    'selRow = Nothing
    intSelRow = -1
    strList = ""
    Button3_Click(Nothing, Nothing)
  End Sub

  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    Dim sqlcv As New APSQL.SQLCNV
    sqlcv.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "WMSA", , "TOP 1000")
    If TextBox1.Text.Trim <> "" Then
      Dim strIT() As String = TextBox1.Text.Trim.Split("*Xx".ToCharArray)
      If strIT.Length = 1 Then
        If TextBox1.Text.Trim.ToUpper.Contains("MM") Then
          sqlcv.Where("SA15", "Like", TextBox1.Text.Trim & "%", , 1)
        Else
          sqlcv.Where("SA01", "Like", TextBox1.Text.Trim & "%", , 1)
        End If
      ElseIf strIT.Length = 2 Then
        sqlcv.Where("SA15", "Like", Val(strIT(0)).ToString("0.00") & "mm*" & Val(strIT(1)).ToString("0.00") & "mm%", , 1)
      ElseIf strIT.Length = 3 Then
        sqlcv.Where("SA15", "Like", Val(strIT(0)).ToString("0.00") & "mm*" & Val(strIT(2)).ToString("0.00") & "mmX(" & strIT(1).Trim("m") & "*1)%", , 1)
      Else
        sqlcv.Where("SA15", "Like", Val(strIT(0)).ToString("0.00") & "mm*" & Val(strIT(2)).ToString("0.00") & "mmX(" & strIT(1).Trim("m") & "*" & strIT(3).Trim("m") & ")%", , 1)
      End If
      sqlcv.Where("SA15", "Like", TextBox1.Text.Trim & "%", , -1, "OR")
      NQRY = ""
    End If
    If NQRY <> "" Then
      sqlcv.Where("SA20", "=", NQRY)
    End If
    If CheckBox2.Checked Then sqlcv.Where("SA04", "=", ComboBox1.SelectedValue.ToString.Trim)
    sqlcv.Where("SA01", "Not Like", "$%")
    If bolHasWF = True Then
      sqlcv.Where("ISNULL(SA12,'')+ISNULL(SA13,'')", "<>", "")
    End If
    sqlcv.SqlFields("SA01", "品號", , True, True)
    sqlcv.SqlFields("SA02", "品名", , True)
    sqlcv.SqlFields("SA03", "規格", , True)
    sqlcv.SqlFields("ISNULL(SA15,'')+' '+ISNULL(SA19,'')", "次規格", , True)
    sqlcv.SqlFields("SA04", "類別", , True)
    sqlcv.SqlFields("SA05", "單位", , True)
    If Button1.Enabled = True Then
      sqlcv.SqlFields("(0)", "可用儲位數")
    End If
    Dim rs As DataTable = DB.RsSQL(BIG2GB(sqlcv.Text), "RS")
    If Button1.Enabled = True Then
      sqlcv.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "WMSDA")
      Dim w As APSQL.SqlWhere = sqlcv.SqlJoin(APSQL.SQLCNV.intJoinMode.msJoin_Inner, "WMSD", "SD01", "=", "WMSDA.SDA02")
      w.Add("WMSD.SD02", "<>", "'2'")
      sqlcv.SqlFields("SDA01", , , True, True)
      sqlcv.SqlFields("COUNT(*)", "QTY")
      Dim rs1 As DataTable = DB.RsSQL(sqlcv.Text, "RT")
      Dim aryI As New Dictionary(Of String, Integer)
      For Each r As DataRow In rs1.Rows
        aryI.Add(r!SDA01.ToString.Trim, Val(r!QTY.ToString.Trim))
      Next
      For Each r As DataRow In rs.Rows
        Dim strK As String = r.Item(BIG2GB("品號")).ToString.Trim
        If aryI.ContainsKey(strK) Then
          r.Item(BIG2GB("可用儲位數")) = aryI(strK)
        End If
      Next
    End If
    DG.DataSource = rs
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    If DG.SelectedRows.Count = 0 Then Return
    strList = ""
    For Each r As DataGridViewRow In DG.SelectedRows
      strList &= GCell(r.Cells(0)) & vbCr
    Next
    strList = strList.Trim(vbCr)
    Me.DialogResult = Windows.Forms.DialogResult.OK
  End Sub

  Private Sub DG_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG.CellDoubleClick
    intSelRow = e.RowIndex
    Debug.Print(e.RowIndex)
    Me.DialogResult = Windows.Forms.DialogResult.OK
  End Sub

  Private Sub DG_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DG.CellFormatting
    If e.ColumnIndex = 3 Then
      Dim strK As String = GCell(DG.Rows(e.RowIndex).Cells(3))
      If aryT.ContainsKey(strK) = False Then Return
      e.Value = aryT(strK)
    End If
  End Sub

  Private Sub ComboBox1_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBox1.SelectionChangeCommitted
    CheckBox2.Checked = True
  End Sub

  Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
    If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
      e.Handled = True
      My.Computer.Keyboard.SendKeys(vbTab)
    End If
  End Sub

  Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles TextBox1.LostFocus
    If TextBox1.Text.Trim <> "" Then
      Button3_Click(Nothing, Nothing)
    End If
  End Sub

  'Private Sub DG_Scroll(sender As Object, e As ScrollEventArgs) Handles DG.Scroll
  '  DG.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
  '  DG.Refresh()
  'End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

  End Sub
End Class