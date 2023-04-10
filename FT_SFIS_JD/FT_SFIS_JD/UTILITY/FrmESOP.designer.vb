<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmESOP
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
    Me.components = New System.ComponentModel.Container()
    Me.Panel2 = New System.Windows.Forms.Panel()
    Me.PIC = New System.Windows.Forms.PictureBox()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.Button3 = New System.Windows.Forms.Button()
    Me.Button4 = New System.Windows.Forms.Button()
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.Button5 = New System.Windows.Forms.Button()
    Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
    Me.Panel2.SuspendLayout()
    CType(Me.PIC, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Panel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'Panel2
    '
    Me.Panel2.AllowDrop = True
    Me.Panel2.AutoScroll = True
    Me.Panel2.BackColor = System.Drawing.Color.Silver
    Me.Panel2.Controls.Add(Me.PIC)
    Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Panel2.Location = New System.Drawing.Point(0, 0)
    Me.Panel2.Name = "Panel2"
    Me.Panel2.Size = New System.Drawing.Size(770, 278)
    Me.Panel2.TabIndex = 1
    '
    'PIC
    '
    Me.PIC.Location = New System.Drawing.Point(202, 50)
    Me.PIC.Name = "PIC"
    Me.PIC.Size = New System.Drawing.Size(192, 146)
    Me.PIC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
    Me.PIC.TabIndex = 0
    Me.PIC.TabStop = False
    '
    'Button1
    '
    Me.Button1.Font = New System.Drawing.Font("Wingdings", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
    Me.Button1.Location = New System.Drawing.Point(98, 6)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(37, 32)
    Me.Button1.TabIndex = 0
    Me.Button1.Text = "è"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(46, 14)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(35, 16)
    Me.Label1.TabIndex = 1
    Me.Label1.Text = "1/1"
    '
    'Button2
    '
    Me.Button2.Font = New System.Drawing.Font("Wingdings", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
    Me.Button2.Location = New System.Drawing.Point(3, 6)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(37, 32)
    Me.Button2.TabIndex = 2
    Me.Button2.Text = ""
    Me.Button2.UseVisualStyleBackColor = True
    '
    'Button3
    '
    Me.Button3.Font = New System.Drawing.Font("Wingdings 2", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
    Me.Button3.Location = New System.Drawing.Point(141, 6)
    Me.Button3.Name = "Button3"
    Me.Button3.Size = New System.Drawing.Size(37, 32)
    Me.Button3.TabIndex = 3
    Me.Button3.Text = "Ì"
    Me.Button3.UseVisualStyleBackColor = True
    '
    'Button4
    '
    Me.Button4.Font = New System.Drawing.Font("Gill Sans Ultra Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Button4.Location = New System.Drawing.Point(184, 6)
    Me.Button4.Name = "Button4"
    Me.Button4.Size = New System.Drawing.Size(37, 32)
    Me.Button4.TabIndex = 1
    Me.Button4.Text = "-"
    Me.Button4.UseVisualStyleBackColor = True
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.Button5)
    Me.Panel1.Controls.Add(Me.Button4)
    Me.Panel1.Controls.Add(Me.Button3)
    Me.Panel1.Controls.Add(Me.Button2)
    Me.Panel1.Controls.Add(Me.Label1)
    Me.Panel1.Controls.Add(Me.Button1)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
    Me.Panel1.Location = New System.Drawing.Point(0, 278)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(770, 44)
    Me.Panel1.TabIndex = 0
    '
    'Button5
    '
    Me.Button5.Font = New System.Drawing.Font("Gill Sans Ultra Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Button5.Location = New System.Drawing.Point(227, 6)
    Me.Button5.Name = "Button5"
    Me.Button5.Size = New System.Drawing.Size(37, 32)
    Me.Button5.TabIndex = 4
    Me.Button5.Text = "X"
    Me.Button5.UseVisualStyleBackColor = True
    '
    'Timer1
    '
    Me.Timer1.Enabled = True
    '
    'frmESOP
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
    Me.ClientSize = New System.Drawing.Size(770, 322)
    Me.Controls.Add(Me.Panel2)
    Me.Controls.Add(Me.Panel1)
    Me.Font = New System.Drawing.Font("細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.Name = "frmESOP"
    Me.Text = "ESOP V1.0"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    Me.Panel2.ResumeLayout(False)
    CType(Me.PIC, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Panel2 As System.Windows.Forms.Panel
  Friend WithEvents PIC As System.Windows.Forms.PictureBox
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents Button3 As System.Windows.Forms.Button
  Friend WithEvents Button4 As System.Windows.Forms.Button
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Button5 As System.Windows.Forms.Button
  Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
