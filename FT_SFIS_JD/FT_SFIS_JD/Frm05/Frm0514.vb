Public Class Frm0514


  Private Sub Frm0514_Load(sender As Object, e As EventArgs) Handles MyBase.Load

  End Sub

  Private Sub Frm0514_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    TuiCK(Me)
  End Sub
  Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
    Me.Close()
  End Sub
End Class