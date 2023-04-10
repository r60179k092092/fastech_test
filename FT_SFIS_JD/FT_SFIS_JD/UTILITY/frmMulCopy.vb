Public Class frmMulCopy
  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()

    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    languagechange(Me)
  End Sub

  Private Sub frmMulCopy_Load(sender As Object, e As EventArgs) Handles MyBase.Load

  End Sub

  Private Sub XStep_KeyPress(sender As Object, e As KeyPressEventArgs) Handles XStep.KeyPress, Ystep.KeyPress, Cols.KeyPress, Rows.KeyPress, AutoCode.KeyPress
    If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
      e.Handled = True
      My.Computer.Keyboard.SendKeys(vbTab)
    End If
  End Sub
End Class