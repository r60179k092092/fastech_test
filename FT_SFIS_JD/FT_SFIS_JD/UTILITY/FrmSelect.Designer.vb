<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelect
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
    Me.CLIST = New System.Windows.Forms.CheckedListBox()
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.Button3 = New System.Windows.Forms.Button()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.Panel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'CLIST
    '
    Me.CLIST.CheckOnClick = True
    Me.CLIST.Dock = System.Windows.Forms.DockStyle.Fill
    Me.CLIST.FormattingEnabled = True
    Me.CLIST.Location = New System.Drawing.Point(0, 101)
    Me.CLIST.Name = "CLIST"
    Me.CLIST.Size = New System.Drawing.Size(325, 415)
    Me.CLIST.TabIndex = 0
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.Button3)
    Me.Panel1.Controls.Add(Me.TextBox1)
    Me.Panel1.Controls.Add(Me.Button2)
    Me.Panel1.Controls.Add(Me.Button1)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(325, 101)
    Me.Panel1.TabIndex = 1
    '
    'Button3
    '
    Me.Button3.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Button3.Location = New System.Drawing.Point(160, 5)
    Me.Button3.Name = "Button3"
    Me.Button3.Size = New System.Drawing.Size(70, 33)
    Me.Button3.TabIndex = 3
    Me.Button3.Text = "取消"
    Me.Button3.UseVisualStyleBackColor = True
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(3, 42)
    Me.TextBox1.Multiline = True
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(319, 56)
    Me.TextBox1.TabIndex = 2
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(84, 5)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(70, 33)
    Me.Button2.TabIndex = 1
    Me.Button2.Text = "清除"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'Button1
    '
    Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.Button1.Location = New System.Drawing.Point(8, 5)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(70, 33)
    Me.Button1.TabIndex = 0
    Me.Button1.Text = "確認"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'FrmSelect
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(325, 516)
    Me.ControlBox = False
    Me.Controls.Add(Me.CLIST)
    Me.Controls.Add(Me.Panel1)
    Me.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Margin = New System.Windows.Forms.Padding(4)
    Me.Name = "FrmSelect"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "FrmSelect"
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents CLIST As System.Windows.Forms.CheckedListBox
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Button3 As System.Windows.Forms.Button
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
