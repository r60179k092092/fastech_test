<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WMSLABFORM
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
    Me.FP = New System.Windows.Forms.FlowLayoutPanel()
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.ComboBox1 = New System.Windows.Forms.ComboBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.Panel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'FP
    '
    Me.FP.BackColor = System.Drawing.Color.White
    Me.FP.Dock = System.Windows.Forms.DockStyle.Fill
    Me.FP.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
    Me.FP.Location = New System.Drawing.Point(0, 32)
    Me.FP.Name = "FP"
    Me.FP.Size = New System.Drawing.Size(1013, 485)
    Me.FP.TabIndex = 0
    '
    'Panel1
    '
    Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.Panel1.Controls.Add(Me.Button2)
    Me.Panel1.Controls.Add(Me.Button1)
    Me.Panel1.Controls.Add(Me.Label2)
    Me.Panel1.Controls.Add(Me.ComboBox1)
    Me.Panel1.Controls.Add(Me.Label1)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Font = New System.Drawing.Font("細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(1013, 32)
    Me.Panel1.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(3, 6)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(135, 19)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "標籤格式分類"
    '
    'ComboBox1
    '
    Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ComboBox1.FormattingEnabled = True
    Me.ComboBox1.Location = New System.Drawing.Point(147, 2)
    Me.ComboBox1.Name = "ComboBox1"
    Me.ComboBox1.Size = New System.Drawing.Size(208, 27)
    Me.ComboBox1.TabIndex = 1
    '
    'Label2
    '
    Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.Label2.Location = New System.Drawing.Point(361, 4)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(499, 22)
    Me.Label2.TabIndex = 2
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Button1
    '
    Me.Button1.BackColor = System.Drawing.SystemColors.Control
    Me.Button1.Location = New System.Drawing.Point(869, 3)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(60, 25)
    Me.Button1.TabIndex = 3
    Me.Button1.Text = "選取"
    Me.Button1.UseVisualStyleBackColor = False
    '
    'Button2
    '
    Me.Button2.BackColor = System.Drawing.SystemColors.Control
    Me.Button2.Location = New System.Drawing.Point(938, 3)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(60, 25)
    Me.Button2.TabIndex = 4
    Me.Button2.Text = "離開"
    Me.Button2.UseVisualStyleBackColor = False
    '
    'WMSLABFORM
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1013, 517)
    Me.ControlBox = False
    Me.Controls.Add(Me.FP)
    Me.Controls.Add(Me.Panel1)
    Me.Name = "WMSLABFORM"
    Me.Text = "請選擇一個標籤格式"
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents FP As System.Windows.Forms.FlowLayoutPanel
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
