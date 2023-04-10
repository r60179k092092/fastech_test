<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LBFTPRT
  Inherits System.Windows.Forms.Form

  'Form 覆寫 Dispose 以清除元件清單。
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  '為 Windows Form 設計工具的必要項
  Private components As System.ComponentModel.IContainer

  '注意: 以下為 Windows Form 設計工具所需的程序
  '可以使用 Windows Form 設計工具進行修改。
  '請不要使用程式碼編輯器進行修改。
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.Button4 = New System.Windows.Forms.Button()
    Me.OFD = New System.Windows.Forms.OpenFileDialog()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Button5 = New System.Windows.Forms.Button()
    Me.CB1 = New System.Windows.Forms.ComboBox()
    Me.PD1 = New System.Windows.Forms.PrintDialog()
    Me.CB2 = New System.Windows.Forms.ComboBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.TextBox2 = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TextBox3 = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'Button2
    '
    Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Button2.Location = New System.Drawing.Point(314, 133)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(129, 28)
    Me.Button2.TabIndex = 12
    Me.Button2.Text = "關閉"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'Button4
    '
    Me.Button4.Location = New System.Drawing.Point(161, 133)
    Me.Button4.Name = "Button4"
    Me.Button4.Size = New System.Drawing.Size(129, 28)
    Me.Button4.TabIndex = 18
    Me.Button4.Text = "轉存圖形"
    Me.Button4.UseVisualStyleBackColor = True
    '
    'OFD
    '
    Me.OFD.DefaultExt = "PNG"
    Me.OFD.FileName = "OpenFileDialog1"
    Me.OFD.Filter = "單色微縮圖(*.PNG)|*.PNG|單色點陣圖(*.BMP)|*.BMP|所有檔案|*.*"
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(18, 7)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(129, 19)
    Me.Label5.TabIndex = 19
    Me.Label5.Text = "標籤機類型："
    '
    'Button5
    '
    Me.Button5.Location = New System.Drawing.Point(8, 133)
    Me.Button5.Name = "Button5"
    Me.Button5.Size = New System.Drawing.Size(129, 28)
    Me.Button5.TabIndex = 20
    Me.Button5.Text = "測試列印"
    Me.Button5.UseVisualStyleBackColor = True
    '
    'CB1
    '
    Me.CB1.FormattingEnabled = True
    Me.CB1.Location = New System.Drawing.Point(139, 3)
    Me.CB1.Name = "CB1"
    Me.CB1.Size = New System.Drawing.Size(308, 27)
    Me.CB1.TabIndex = 21
    '
    'PD1
    '
    Me.PD1.UseEXDialog = True
    '
    'CB2
    '
    Me.CB2.FormattingEnabled = True
    Me.CB2.Location = New System.Drawing.Point(139, 32)
    Me.CB2.Name = "CB2"
    Me.CB2.Size = New System.Drawing.Size(308, 27)
    Me.CB2.TabIndex = 23
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(38, 36)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(109, 19)
    Me.Label6.TabIndex = 22
    Me.Label6.Text = "印表機名："
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(78, 68)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(69, 19)
    Me.Label1.TabIndex = 24
    Me.Label1.Text = "溫度："
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(139, 63)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(64, 29)
    Me.TextBox1.TabIndex = 25
    Me.TextBox1.Text = "60"
    '
    'TextBox2
    '
    Me.TextBox2.Location = New System.Drawing.Point(306, 63)
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(64, 29)
    Me.TextBox2.TabIndex = 27
    Me.TextBox2.Text = "0"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(238, 68)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(73, 19)
    Me.Label2.TabIndex = 26
    Me.Label2.Text = "XOFF："
    '
    'TextBox3
    '
    Me.TextBox3.Location = New System.Drawing.Point(306, 97)
    Me.TextBox3.Name = "TextBox3"
    Me.TextBox3.Size = New System.Drawing.Size(64, 29)
    Me.TextBox3.TabIndex = 29
    Me.TextBox3.Text = "0"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(238, 102)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(73, 19)
    Me.Label3.TabIndex = 28
    Me.Label3.Text = "YOFF："
    '
    'LBFTPRT
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(449, 163)
    Me.ControlBox = False
    Me.Controls.Add(Me.TextBox3)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TextBox2)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TextBox1)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.CB2)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.CB1)
    Me.Controls.Add(Me.Button5)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Button4)
    Me.Controls.Add(Me.Button2)
    Me.Font = New System.Drawing.Font("SimSun", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "LBFTPRT"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "測試列印標籤格式"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents Button4 As System.Windows.Forms.Button
  Friend WithEvents OFD As System.Windows.Forms.OpenFileDialog
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Button5 As System.Windows.Forms.Button
  Friend WithEvents CB1 As System.Windows.Forms.ComboBox
  Friend WithEvents PD1 As System.Windows.Forms.PrintDialog
  Friend WithEvents CB2 As System.Windows.Forms.ComboBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
