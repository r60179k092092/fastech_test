Public Class frmESOP
  Private sngW As Single = 1
  Private bolN As Boolean = True
  Private sngB As Single = 1
  Private bX As Integer = 0
  Private bY As Integer = 0
  Private bolD As Boolean = False
  Private intPIC As Integer = 0
  Private aryBMP As New ArrayList
  Private strFile As String = ""
  Private WithEvents Proc As System.Diagnostics.Process = Nothing
  Private bolProc As Boolean = False
  Public Sub LoadBmp(rs As DataTable)
    aryBMP.Clear()
    For Each r As DataRow In rs.Rows
      If r!QTN05.GetType Is GetType(DBNull) Then
        Continue For
      End If
      Dim bytV() As Byte = r!QTN05
      If bytV Is Nothing OrElse bytV.Length = 0 Then Continue For
      If IO.Path.GetExtension(r!QTN03.ToString.Trim).ToUpper.EndsWith("XPS") = False Then
        Dim fs As New IO.MemoryStream
        fs.Write(bytV, 0, bytV.Length)
        Dim bmp As New Bitmap(fs)
        aryBMP.Add(bmp)
        fs.Close()
        fs.Dispose()
      Else
        aryBMP.Add(bytV)
      End If
    Next
    intPIC = 0
    ShowPic()
    My.Application.DoEvents()
    bolN = True
  End Sub
  Public Sub Clear()
    aryBMP.Clear()
  End Sub
  Public Sub Add(bmpx As Bitmap)
    If bmpx IsNot Nothing Then
      aryBMP.Add(bmpx)
    End If
    intPIC = aryBMP.Count - 1
    showPic()
  End Sub
  Private Sub ShowPic()
    If aryBMP.Count = 0 Then
      PIC.Image = Nothing
      Label1.Text = "None"
      Return
    End If
    If intPIC < 0 Then intPIC = 0
    If intPIC >= aryBMP.Count Then
      intPIC = 0
    End If
    If bolProc And aryBMP.Count = 1 Then
      Me.Close()
      Return
    End If
    Label1.Text = intPIC + 1 & " / " & aryBMP.Count
    If aryBMP(intPIC).GetType Is GetType(Bitmap) Then
      PIC.Image = aryBMP(intPIC)
      bolN = True
      Button4_Click(Nothing, Nothing)
    Else
      If Proc IsNot Nothing Then
        Proc.Close()
        System.Threading.Thread.Sleep(1000)
        Proc = Nothing
      End If
      If strFile = "" Then strFile = IO.Path.GetTempFileName
      strFile = IO.Path.GetDirectoryName(strFile) & "\" & IO.Path.GetFileNameWithoutExtension(strFile) & ".XPS"
      IO.File.WriteAllBytes(strFile, aryBMP(intPIC))
      Proc = System.Diagnostics.Process.Start(strFile)
      bolProc = True
    End If
  End Sub

  Private Sub frmESOP_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    If Proc IsNot Nothing Then
      Proc.Close()
      System.Threading.Thread.Sleep(1000)
      Proc = Nothing
      IO.File.Delete(strFile)
    End If
    If strFile <> "" Then
      strFile = IO.Path.GetDirectoryName(strFile) & "\" & IO.Path.GetFileNameWithoutExtension(strFile) & ".Tmp"
      IO.File.Delete(strFile)
    End If
  End Sub
  Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    If strFile = "" Then strFile = IO.Path.GetTempFileName
  End Sub

  Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
    PIC.SetBounds(0, 0, Panel2.ClientSize.Width, Panel2.ClientSize.Height)
  End Sub

  Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    If PIC.Image Is Nothing Then Return
    If bolN Then
      sngW = Panel2.ClientSize.Width / PIC.Image.Width
      If Panel2.ClientSize.Height / PIC.Image.Height < sngW Then
        sngW = Panel2.ClientSize.Height / PIC.Image.Height
      End If
      sngB = sngW
      bolN = False
    End If
    sngW /= 1.1
    If sngW < sngB Then
      sngW = sngB
      If PIC.Width < Panel2.ClientSize.Width Then PIC.Width = Panel2.ClientSize.Width
      If PIC.Height < Panel2.ClientSize.Height Then PIC.Height = Panel2.ClientSize.Height
      PIC.Left = 0
      PIC.Top = 0
      Return
    End If
    PIC.Width = PIC.Image.Width * sngW
    PIC.Height = PIC.Image.Height * sngW
    Dim x As Integer = Panel2.HorizontalScroll.Value / 1.1
    Dim y As Integer = Panel2.VerticalScroll.Value / 1.1
    If PIC.Width < Panel2.ClientSize.Width Then
      x = 0
      PIC.Width = Panel2.ClientSize.Width
    End If
    If PIC.Height < Panel2.ClientSize.Height Then
      y = 0
      PIC.Height = Panel2.ClientSize.Height
    End If
    Panel2.AutoScrollPosition = New Point(x, y)
  End Sub

  Private Sub PIC_MouseDown(sender As Object, e As MouseEventArgs) Handles PIC.MouseDown
    bX = e.X
    bY = e.Y
    bolD = True
  End Sub

  Private Sub PIC_MouseMove(sender As Object, e As MouseEventArgs) Handles PIC.MouseMove
    If bolD Then
      Dim y As Integer = Panel2.VerticalScroll.Value - e.Y + bY
      Dim x As Integer = Panel2.HorizontalScroll.Value - e.X + bX
      If y < Panel2.VerticalScroll.Minimum Then y = Panel2.VerticalScroll.Minimum
      If y > Panel2.VerticalScroll.Maximum Then y = Panel2.VerticalScroll.Maximum
      If x < Panel2.HorizontalScroll.Minimum Then x = Panel2.HorizontalScroll.Minimum
      If x > Panel2.HorizontalScroll.Maximum Then x = Panel2.HorizontalScroll.Maximum
      Panel2.AutoScrollPosition = New Point(x, y)
    End If
  End Sub

  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    If PIC.Image Is Nothing Then Return
    If bolN Then
      sngW = Panel2.ClientSize.Width / PIC.Image.Width
      If Panel2.ClientSize.Height / PIC.Image.Height < sngW Then
        sngW = Panel2.ClientSize.Height / PIC.Image.Height
      End If
      sngB = sngW
      bolN = False
    End If
    sngW *= 1.1
    PIC.Width = PIC.Image.Width * sngW
    PIC.Height = PIC.Image.Height * sngW
    Dim x As Integer = Panel2.HorizontalScroll.Value * 1.1
    Dim y As Integer = Panel2.VerticalScroll.Value * 1.1
    If PIC.Width < Panel2.ClientSize.Width Then
      PIC.Width = Panel2.ClientSize.Width
      x = 0
    End If
    If PIC.Height < Panel2.ClientSize.Height Then
      PIC.Height = Panel2.ClientSize.Height
      y = 0
    End If
    Panel2.AutoScrollPosition = New Point(x, y)
    'PIC.Left = -(PIC.Width - Panel2.ClientSize.Width) / 2
    'PIC.Top = -(PIC.Height - Panel2.ClientSize.Height) / 2
  End Sub

  Private Sub PIC_MouseUp(sender As Object, e As MouseEventArgs) Handles PIC.MouseUp
    bolD = False
  End Sub

  Private Sub Panel2_Scroll(sender As Object, e As ScrollEventArgs) Handles Panel2.Scroll
    Panel2.ScrollControlIntoView(PIC)
  End Sub

  Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
    Me.DialogResult = Windows.Forms.DialogResult.OK
    Me.Close()
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    intPIC -= 1
    ShowPic()
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    intPIC += 1
    ShowPic()
  End Sub

  Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    If Proc IsNot Nothing Then
      If Proc.HasExited Then
        Proc = Nothing
        IO.File.Delete(strFile)
        intPIC += 1
        ShowPic()
      End If
    End If
  End Sub
End Class
