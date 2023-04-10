Public Class FrmDialog

  Dim bt As String
  Dim xz As Boolean
  Dim rsql(,) As String
  Dim dt As New DataTable
  Public rw As DataGridViewRow
  Public rws() As DataGridViewRow
  Private bolRUNOK As Boolean = False
  Private strCMD As String = ""
  Private strPL As String = ""
  ''' <summary>
  ''' new
  ''' </summary>
  ''' <param name="biaoti">名稱</param>
  ''' <param name="sqlcmd">sql語句</param>
  ''' <remarks></remarks>
  Sub New(ByVal biaoti As String, ByRef sqlcmd As String)
    InitializeComponent()
    ' languagechange(Me)
    bt = biaoti
    'Tshuru = shuru
    Me.Text = biaoti & BIG2GB("選擇")
    languagechange(Me)
    Dim strK() As String = Split(sqlcmd, "$^$")
    strCMD = strK(0)
    strPL = strK(1).Trim
    DoRun()
  End Sub
  Private Sub DoRun()
    Dim strQ As String = strCMD
    If strCMD.ToUpper.StartsWith("SELECT TOP") = True Then
      If strPL <> "" Then
        strQ &= " WHERE (" & strPL & ")"
        If GD.Text.Trim <> "" Then
          strQ &= " AND ( TBB03+ISNULL(TBB05,'')+ISNULL(TBB06,'') Like '%" & GD.Text & "%' )"
        End If
      Else
        If GD.Text.Trim <> "" Then
          strQ &= " WHERE ( TBB03+ISNULL(TBB05,'')+ISNULL(TBB06,'') Like '%" & GD.Text & "%' )"
        End If
      End If
      dg.DataSource = DB.RsSQL(strQ, Me.Text)
    Else
      If dg.DataSource Is Nothing Then
        dg.DataSource = DB.RsSQL(strQ, Me.Text)
      End If
      If GD.Text.Trim <> "" Then
        dg.DataSource = DB.GetRs(Me.Text, "??" & GD.Text.Trim)
      Else
        dg.DataSource = DB.GetRs(Me.Text)
      End If
    End If
  End Sub
  Private Sub Frmgongdanselect_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
    If e.KeyChar = Chr(13) Then
      e.Handled = True
      Button1.PerformClick()
    End If
  End Sub

  Private Sub Frmgongdanselect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.WindowState = FormWindowState.Maximized
    Button2.DialogResult = DialogResult.No
    Me.KeyPreview = True
    'GD.Text = ""
    GD.SelectAll()
    GD.Focus()
    dgdaochu(dg)
  End Sub
  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    DoRun()
    GD.SelectAll()
    GD.Focus()
  End Sub
  Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    Me.Close()
  End Sub

  Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellDoubleClick
    If e.RowIndex > -1 Then
      rw = dg.Rows(e.RowIndex)
      Me.DialogResult = DialogResult.OK
      Me.Close()
    End If
  End Sub

  Public Function RtnWuliao() As DataTable
    Return dg.DataSource
  End Function

  Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    If dg.SelectedRows.Count = 0 Then
      MsgBox(BIG2GB("必須至少選擇一個項目"))
      Return
    End If
    Me.DialogResult = DialogResult.OK
    rw = Nothing
    Dim rs(dg.SelectedRows.Count - 1) As DataGridViewRow
    dg.SelectedRows.CopyTo(rs, 0)
    rws = rs
    Me.Close()
  End Sub
End Class