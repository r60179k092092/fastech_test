<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm0605
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
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.Panel2 = New System.Windows.Forms.Panel()
    Me.Button13 = New System.Windows.Forms.Button()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TextBox6 = New System.Windows.Forms.TextBox()
    Me.TextBox5 = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.DG2 = New System.Windows.Forms.DataGridView()
    Me.Panel3 = New System.Windows.Forms.Panel()
    Me.Button8 = New System.Windows.Forms.Button()
    Me.Button7 = New System.Windows.Forms.Button()
    Me.Button6 = New System.Windows.Forms.Button()
    Me.Button9 = New System.Windows.Forms.Button()
    Me.DG1 = New System.Windows.Forms.DataGridView()
    Me.DG = New System.Windows.Forms.DataGridView()
    Me.Panel2.SuspendLayout()
    CType(Me.DG2, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Panel3.SuspendLayout()
    CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Panel2
    '
    Me.Panel2.Controls.Add(Me.Button13)
    Me.Panel2.Controls.Add(Me.TextBox1)
    Me.Panel2.Controls.Add(Me.Label1)
    Me.Panel2.Controls.Add(Me.TextBox6)
    Me.Panel2.Controls.Add(Me.TextBox5)
    Me.Panel2.Controls.Add(Me.Label5)
    Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel2.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
    Me.Panel2.Location = New System.Drawing.Point(294, 0)
    Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
    Me.Panel2.Name = "Panel2"
    Me.Panel2.Size = New System.Drawing.Size(1076, 94)
    Me.Panel2.TabIndex = 2
    '
    'Button13
    '
    Me.Button13.Location = New System.Drawing.Point(463, 4)
    Me.Button13.Margin = New System.Windows.Forms.Padding(4)
    Me.Button13.Name = "Button13"
    Me.Button13.Size = New System.Drawing.Size(139, 54)
    Me.Button13.TabIndex = 10
    Me.Button13.TabStop = False
    Me.Button13.Text = "導出操作指令"
    Me.Button13.UseVisualStyleBackColor = True
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(92, 4)
    Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(150, 26)
    Me.TextBox1.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(8, 37)
    Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(72, 16)
    Me.Label1.TabIndex = 8
    Me.Label1.Text = "指令說明"
    '
    'TextBox6
    '
    Me.TextBox6.Location = New System.Drawing.Point(92, 32)
    Me.TextBox6.Margin = New System.Windows.Forms.Padding(4)
    Me.TextBox6.Name = "TextBox6"
    Me.TextBox6.Size = New System.Drawing.Size(363, 26)
    Me.TextBox6.TabIndex = 2
    '
    'TextBox5
    '
    Me.TextBox5.Location = New System.Drawing.Point(8, 60)
    Me.TextBox5.Margin = New System.Windows.Forms.Padding(4)
    Me.TextBox5.Name = "TextBox5"
    Me.TextBox5.Size = New System.Drawing.Size(1141, 26)
    Me.TextBox5.TabIndex = 3
    Me.TextBox5.TabStop = False
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(8, 9)
    Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(72, 16)
    Me.Label5.TabIndex = 0
    Me.Label5.Text = "指令代碼"
    '
    'DG2
    '
    Me.DG2.AllowUserToAddRows = False
    Me.DG2.AllowUserToDeleteRows = False
    DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
    Me.DG2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
    Me.DG2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DG2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DG2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DG2.Location = New System.Drawing.Point(584, 94)
    Me.DG2.Margin = New System.Windows.Forms.Padding(4)
    Me.DG2.Name = "DG2"
    Me.DG2.RowTemplate.Height = 24
    Me.DG2.Size = New System.Drawing.Size(786, 611)
    Me.DG2.TabIndex = 7
    Me.DG2.TabStop = False
    '
    'Panel3
    '
    Me.Panel3.Controls.Add(Me.Button8)
    Me.Panel3.Controls.Add(Me.Button7)
    Me.Panel3.Controls.Add(Me.Button6)
    Me.Panel3.Controls.Add(Me.Button9)
    Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
    Me.Panel3.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
    Me.Panel3.Location = New System.Drawing.Point(536, 94)
    Me.Panel3.Margin = New System.Windows.Forms.Padding(4)
    Me.Panel3.Name = "Panel3"
    Me.Panel3.Size = New System.Drawing.Size(48, 611)
    Me.Panel3.TabIndex = 6
    '
    'Button8
    '
    Me.Button8.Font = New System.Drawing.Font("SimHei", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Button8.Location = New System.Drawing.Point(5, 263)
    Me.Button8.Margin = New System.Windows.Forms.Padding(4)
    Me.Button8.Name = "Button8"
    Me.Button8.Size = New System.Drawing.Size(39, 47)
    Me.Button8.TabIndex = 7
    Me.Button8.TabStop = False
    Me.Button8.Text = "v"
    Me.Button8.UseVisualStyleBackColor = True
    '
    'Button7
    '
    Me.Button7.Font = New System.Drawing.Font("SimHei", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Button7.Location = New System.Drawing.Point(5, 208)
    Me.Button7.Margin = New System.Windows.Forms.Padding(4)
    Me.Button7.Name = "Button7"
    Me.Button7.Size = New System.Drawing.Size(39, 47)
    Me.Button7.TabIndex = 6
    Me.Button7.TabStop = False
    Me.Button7.Text = "^"
    Me.Button7.UseVisualStyleBackColor = True
    '
    'Button6
    '
    Me.Button6.Font = New System.Drawing.Font("SimHei", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Button6.Location = New System.Drawing.Point(5, 153)
    Me.Button6.Margin = New System.Windows.Forms.Padding(4)
    Me.Button6.Name = "Button6"
    Me.Button6.Size = New System.Drawing.Size(39, 47)
    Me.Button6.TabIndex = 5
    Me.Button6.TabStop = False
    Me.Button6.Text = "<"
    Me.Button6.UseVisualStyleBackColor = True
    '
    'Button9
    '
    Me.Button9.Font = New System.Drawing.Font("SimHei", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Button9.Location = New System.Drawing.Point(5, 99)
    Me.Button9.Margin = New System.Windows.Forms.Padding(4)
    Me.Button9.Name = "Button9"
    Me.Button9.Size = New System.Drawing.Size(39, 47)
    Me.Button9.TabIndex = 4
    Me.Button9.TabStop = False
    Me.Button9.Text = ">"
    Me.Button9.UseVisualStyleBackColor = True
    '
    'DG1
    '
    Me.DG1.AllowUserToAddRows = False
    Me.DG1.AllowUserToDeleteRows = False
    DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
    Me.DG1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
    Me.DG1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DG1.Dock = System.Windows.Forms.DockStyle.Left
    Me.DG1.Location = New System.Drawing.Point(294, 94)
    Me.DG1.Margin = New System.Windows.Forms.Padding(4)
    Me.DG1.Name = "DG1"
    Me.DG1.ReadOnly = True
    Me.DG1.RowTemplate.Height = 24
    Me.DG1.Size = New System.Drawing.Size(242, 611)
    Me.DG1.TabIndex = 5
    Me.DG1.TabStop = False
    '
    'DG
    '
    Me.DG.AllowUserToAddRows = False
    Me.DG.AllowUserToDeleteRows = False
    DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.DG.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
    Me.DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DG.Dock = System.Windows.Forms.DockStyle.Left
    Me.DG.Location = New System.Drawing.Point(0, 0)
    Me.DG.Margin = New System.Windows.Forms.Padding(4)
    Me.DG.Name = "DG"
    Me.DG.ReadOnly = True
    Me.DG.RowTemplate.Height = 24
    Me.DG.Size = New System.Drawing.Size(294, 705)
    Me.DG.TabIndex = 8
    Me.DG.TabStop = False
    '
    'FrmTG00
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1370, 705)
    Me.ControlBox = False
    Me.Controls.Add(Me.DG2)
    Me.Controls.Add(Me.Panel3)
    Me.Controls.Add(Me.DG1)
    Me.Controls.Add(Me.Panel2)
    Me.Controls.Add(Me.DG)
    Me.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Margin = New System.Windows.Forms.Padding(4)
    Me.Name = "Frm0605"
    Me.Text = "SMT操作指令編輯"
    Me.Panel2.ResumeLayout(False)
    Me.Panel2.PerformLayout()
    CType(Me.DG2, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Panel3.ResumeLayout(False)
    CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Panel2 As System.Windows.Forms.Panel
  Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
  Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents DG2 As System.Windows.Forms.DataGridView
  Friend WithEvents Panel3 As System.Windows.Forms.Panel
  Friend WithEvents Button8 As System.Windows.Forms.Button
  Friend WithEvents Button7 As System.Windows.Forms.Button
  Friend WithEvents Button6 As System.Windows.Forms.Button
  Friend WithEvents Button9 As System.Windows.Forms.Button
  Friend WithEvents DG1 As System.Windows.Forms.DataGridView
  Friend WithEvents DG As System.Windows.Forms.DataGridView
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Button13 As System.Windows.Forms.Button
End Class
