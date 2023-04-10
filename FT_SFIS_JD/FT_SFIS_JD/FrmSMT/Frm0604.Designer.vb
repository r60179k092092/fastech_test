<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm0604
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
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(2, 10)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(174, 20)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "請輸入FEEDER ID："
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(178, 5)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(203, 26)
    Me.TextBox1.TabIndex = 1
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(30, 48)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(94, 20)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "目前狀態："
    '
    'Label3
    '
    Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.Label3.Location = New System.Drawing.Point(121, 42)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(260, 29)
    Me.Label3.TabIndex = 3
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label4
    '
    Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.Label4.Location = New System.Drawing.Point(121, 80)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(260, 29)
    Me.Label4.TabIndex = 5
    Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(30, 86)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(94, 20)
    Me.Label5.TabIndex = 4
    Me.Label5.Text = "最后日期："
    '
    'Label6
    '
    Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.Label6.Location = New System.Drawing.Point(121, 118)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(260, 29)
    Me.Label6.TabIndex = 7
    Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(30, 124)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(94, 20)
    Me.Label7.TabIndex = 6
    Me.Label7.Text = "操作狀態："
    '
    'Button1
    '
    Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Button1.Location = New System.Drawing.Point(21, 159)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(341, 53)
    Me.Button1.TabIndex = 8
    Me.Button1.TabStop = False
    Me.Button1.Text = "FEEDER解綁"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'Frm0604
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(383, 217)
    Me.Controls.Add(Me.Button1)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TextBox1)
    Me.Controls.Add(Me.Label1)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Margin = New System.Windows.Forms.Padding(4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "Frm0604"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "FEEDER 解綁"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Button1 As System.Windows.Forms.Button
End Class