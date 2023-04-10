Public Class IMGLIST
  Private strID As String = ""
  Private strName As String = ""
  Public Function GetID() As String
    Return strID
  End Function
  Public Function GetDesc() As String
    Return strID & " " & strName
  End Function
  Public Sub ShowMap(r As DataRow)
    strID = r!QTN02.ToString.Trim
    strName = r!QTN03.ToString.Trim
    Label1.Text = strID & vbCrLf & strName
    ' Me.TTP.SetToolTip(Label1, strID & " " & strName)
    If r!QTN05.GetType IsNot GetType(DBNull) Then
      Dim bytV() As Byte = r!QTN05
      Dim ms As New IO.MemoryStream
      ms.Write(bytV, 0, bytV.Length)
      Me.BackgroundImage = New Bitmap(ms)
      ms.Close()
      ms.Dispose()
    Else
      Me.BackgroundImage = Nothing
    End If
  End Sub

  Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
    OnClick(e)
  End Sub

  Private Sub Label1_DoubleClick(sender As Object, e As EventArgs) Handles Label1.DoubleClick
    OnDoubleClick(e)
  End Sub
End Class
