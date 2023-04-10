Public Class WMS0302A
  Private bmpx As Bitmap = Nothing
  Public Sub SetImage(b As Bitmap)
    bmpx = b
  End Sub
  Private Sub WMS0302A_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Me.BackgroundImage = bmpx
  End Sub
End Class