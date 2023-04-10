Public Class frmViewBmp
  Private bmpX As Bitmap = Nothing
  Private strGet As String = ""
  Private bolMode As Boolean = False
  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()
    languagechange(Me)
    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

  End Sub
  Public Property Bmps As Bitmap
    Get
      Return bmpX
    End Get
    Set(value As Bitmap)
      bmpX = value
      Panel2.BackgroundImage = bmpX
      If bmpX Is Nothing Then
        bolMode = False
      Else
        DG.Visible = False
        bolMode = True
      End If
    End Set
  End Property
  Public Property DGText As String
    Get
      Return strGet
    End Get
    Set(value As String)
      strGet = value
      bolMode = False
    End Set
  End Property
  Private Sub ShowDG()
    DG.Rows.Clear()
    DG.Columns.Clear()
    DG.Visible = False
    If strGet = "" Then Return
    DG.Visible = True
    Dim strV() As String = strGet.Split(vbCrLf.ToCharArray)
    For Each strK As String In strV
      If strK.Trim = "" Then Continue For
      Dim strM() As String = strK.Split(",")
      If DG.Columns.Count = 0 Then
        For intI As Integer = 0 To strM.GetUpperBound(0)
          DG.Columns.Add("C" & intI, strM(intI))
        Next
      Else
        DG.Rows.Add(strM)
      End If
    Next
  End Sub
  Private Sub frmViewBmp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    TextBox1.Text = My.Settings.ViewPath
    If bolMode = False Or bmpX Is Nothing Then
      ShowDG()
    Else
      Panel2.BackgroundImage = bmpX
    End If
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    Me.Close()
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    Dim OFL As New SaveFileDialog
    If bolMode = True Then
      OFL.DefaultExt = "JPG"
      OFL.Filter = BIG2GB("JPG圖檔|*.JPG|所有檔案|*.*")
      OFL.CheckFileExists = False
      If TextBox1.Text.Trim = "" Then
        OFL.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyPictures
        OFL.FileName = ""
      Else
        OFL.InitialDirectory = IO.Path.GetDirectoryName(TextBox1.Text.Trim)
        OFL.FileName = IO.Path.GetFileName(TextBox1.Text.Trim)
      End If
      If OFL.ShowDialog = Windows.Forms.DialogResult.OK Then
        bmpX.Save(OFL.FileName)
        My.Settings.ViewPath = OFL.FileName
        Me.Close()
      End If
    Else
      OFL.DefaultExt = "Txt"
      OFL.Filter = BIG2GB("文字檔|*.Txt|所有檔案|*.*")
      OFL.CheckFileExists = False
      If TextBox1.Text.Trim = "" Then
        OFL.InitialDirectory = 0
        OFL.FileName = ""
      Else
        OFL.InitialDirectory = IO.Path.GetDirectoryName(TextBox1.Text.Trim)
        OFL.FileName = IO.Path.GetFileName(TextBox1.Text.Trim)
      End If
      If OFL.ShowDialog = Windows.Forms.DialogResult.OK Then
        If IO.File.Exists(OFL.FileName) = True Then IO.File.Delete(OFL.FileName)
        IO.File.AppendText(OFL.FileName)
        My.Settings.ViewPath = OFL.FileName
        Me.Close()
      End If
    End If
  End Sub
End Class