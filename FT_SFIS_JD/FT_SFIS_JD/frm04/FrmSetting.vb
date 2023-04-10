Public Class FrmSetting
  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()

    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    languagechange(Me)

  End Sub
  Private Sub FrmSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    BtnSave.Enabled = False
    BtnModify.Enabled = True
    BtnCancel.Enabled = False
    For Each c As Control In GroupBox2.Controls
      c.Enabled = False
    Next
    Dim intI As Integer = 0, intJ As Integer = 0
    ComboBox2.Items.Clear()
    For Each strM As String In My.Computer.Ports.SerialPortNames
      intI = ComboBox2.Items.Add(strM)                '將電腦內部port加入text的item項
      If strM.ToUpper = My.Settings.strScale.ToUpper Then
        intJ = intI
      End If
    Next
    ComboBox2.Items.Add("none")
    ComboBox2.SelectedIndex = intJ
    ComboBox1.Items.Clear()
    ComboBox1.Items.Add("Default")
    For Each strM As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
      ComboBox1.Items.Add(strM)
    Next
    If My.Settings.strScalP.Trim = "" Then
      TextBox2.Text = "9600,8,N,1"
    Else
      TextBox2.Text = My.Settings.strScalP
    End If
    TextBox3.Text = My.Settings.NP
    TextBox4.Text = My.Settings.SW
    TextBox5.Text = My.Settings.STime
    ComboBox1.SelectedIndex = 0
    For intU As Integer = 0 To ComboBox1.Items.Count - 1
      If My.Settings.PRINTER = ComboBox1.Items(intU) Then
        ComboBox1.SelectedIndex = intU
      End If
    Next
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnModify.Click
    BtnSave.Enabled = True
    BtnModify.Enabled = False
    BtnCancel.Enabled = True
    For Each c As Control In GroupBox2.Controls
      c.Enabled = True
    Next
  End Sub

  Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
    BtnSave.Enabled = False
    BtnModify.Enabled = True
    BtnCancel.Enabled = False
    For Each c As Control In GroupBox2.Controls
      c.Enabled = False
    Next
    My.Settings.strScale = ComboBox2.Text
    My.Settings.strScalP = TextBox2.Text
    My.Settings.bolAUTO = False
    My.Settings.SW = Val(TextBox4.Text)
    My.Settings.NP = Val(TextBox3.Text)
    My.Settings.STime = Val(TextBox5.Text)
    If ComboBox1.Text.Trim = "Default" Then
      My.Settings.PRINTER = ""
    Else
      My.Settings.PRINTER = ComboBox1.Text.Trim
    End If
    My.Settings.Save()
  End Sub

  Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
    BtnSave.Enabled = False
    BtnModify.Enabled = True
    BtnCancel.Enabled = False
    For Each c As Control In GroupBox2.Controls
      c.Enabled = False
    Next
    ComboBox2.SelectedItem = My.Settings.strScale
    TextBox2.Text = My.Settings.strScalP
    TextBox4.Text = My.Settings.SW
    TextBox3.Text = My.Settings.NP
    TextBox5.Text = My.Settings.STime
    ComboBox1.SelectedIndex = 0
    For intU As Integer = 0 To ComboBox1.Items.Count - 1
      If My.Settings.PRINTER = ComboBox1.Items(intU) Then
        ComboBox1.SelectedIndex = intU
      End If
    Next
  End Sub

  Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    Me.Close()
  End Sub
End Class