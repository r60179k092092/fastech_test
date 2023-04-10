Public Class FrmMACH
  Private strMach As String = ""
  Sub New()

    ' 設計工具需要此呼叫。
    InitializeComponent()
    languagechange(Me)
    ' 在 InitializeComponent() 呼叫之後加入所有初始設定。

  End Sub
  Public Property MachNo As String
    Get
      Return strMach
    End Get
    Set(value As String)
      strMach = value
    End Set
  End Property

  Private Sub DG_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG.CellContentDoubleClick
    If e.RowIndex < 0 Or e.RowIndex > DG.RowCount Then Return
    If DG.Rows(e.RowIndex).Cells(0).Value = "" Then
      MsgBox(BIG2GB("不可選擇空白編號"), MsgBoxStyle.Information, Me.Text)
      Return
    End If
    MachNo = DG.Rows(e.RowIndex).Cells(0).Value
    Me.DialogResult = DialogResult.OK
    Me.Close()
  End Sub

  Private Sub FrmMACH_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    ShowMach()
  End Sub
  Private Sub ShowMach(Optional strV As String = "")
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TJ")
    If strV <> "" Then
      sqlCV.Where("TJ01", "=", strV,,, "OR")
      sqlCV.Where("TJ02", "=", strV,,, "OR")
    End If
    sqlCV.SqlFields("TJ01", "機台編號")
    sqlCV.SqlFields("TJ02", "機台名稱")
    Dim rs As DataTable = DB.RsSQL(BIG2GB(sqlCV.Text), "RT")
    DG.DataSource = rs
  End Sub

  Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
    If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
      e.Handled = True
      My.Computer.Keyboard.SendKeys(vbTab)
    End If
  End Sub

  Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles TextBox1.LostFocus
    If TextBox1.Text = "" Then
      ShowMach()
    Else
      ShowMach(TextBox1.Text.Trim)
    End If
  End Sub
End Class