﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PM0504
  Inherits System.Windows.Forms.Form

  'Form 重寫 Dispose，以清理組件列表。
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

  'Windows 窗體設計器所必需的
  Private components As System.ComponentModel.IContainer

  '注意: 以下過程是 Windows 窗體設計器所必需的
  '可以使用 Windows 窗體設計器修改它。
  '不要使用代碼編輯器修改它。
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.Button4 = New System.Windows.Forms.Button()
    Me.CheckBox2 = New System.Windows.Forms.CheckBox()
    Me.ComboBox2 = New System.Windows.Forms.ComboBox()
    Me.Button3 = New System.Windows.Forms.Button()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.DTP1 = New System.Windows.Forms.DateTimePicker()
    Me.DTP2 = New System.Windows.Forms.DateTimePicker()
    Me.TextBox5 = New System.Windows.Forms.TextBox()
    Me.CheckBox1 = New System.Windows.Forms.CheckBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TextBox2 = New System.Windows.Forms.TextBox()
    Me.DG = New System.Windows.Forms.DataGridView()
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.DG1 = New System.Windows.Forms.DataGridView()
    Me.CheckBox3 = New System.Windows.Forms.CheckBox()
    Me.GroupBox1.SuspendLayout()
    CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.CheckBox3)
    Me.GroupBox1.Controls.Add(Me.Button4)
    Me.GroupBox1.Controls.Add(Me.CheckBox2)
    Me.GroupBox1.Controls.Add(Me.ComboBox2)
    Me.GroupBox1.Controls.Add(Me.Button3)
    Me.GroupBox1.Controls.Add(Me.Button2)
    Me.GroupBox1.Controls.Add(Me.Button1)
    Me.GroupBox1.Controls.Add(Me.DTP1)
    Me.GroupBox1.Controls.Add(Me.DTP2)
    Me.GroupBox1.Controls.Add(Me.TextBox5)
    Me.GroupBox1.Controls.Add(Me.CheckBox1)
    Me.GroupBox1.Controls.Add(Me.Label5)
    Me.GroupBox1.Controls.Add(Me.Label2)
    Me.GroupBox1.Controls.Add(Me.TextBox2)
    Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
    Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
    Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
    Me.GroupBox1.Size = New System.Drawing.Size(1140, 80)
    Me.GroupBox1.TabIndex = 55
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "查詢條件"
    '
    'Button4
    '
    Me.Button4.Location = New System.Drawing.Point(968, 17)
    Me.Button4.Name = "Button4"
    Me.Button4.Size = New System.Drawing.Size(85, 58)
    Me.Button4.TabIndex = 72
    Me.Button4.Text = "打印"
    Me.Button4.UseVisualStyleBackColor = True
    Me.Button4.Visible = False
    '
    'CheckBox2
    '
    Me.CheckBox2.AutoSize = True
    Me.CheckBox2.Checked = True
    Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
    Me.CheckBox2.Location = New System.Drawing.Point(329, 21)
    Me.CheckBox2.Name = "CheckBox2"
    Me.CheckBox2.Size = New System.Drawing.Size(108, 24)
    Me.CheckBox2.TabIndex = 71
    Me.CheckBox2.Text = "包裝工單號"
    Me.CheckBox2.UseVisualStyleBackColor = True
    '
    'ComboBox2
    '
    Me.ComboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
    Me.ComboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
    Me.ComboBox2.FormattingEnabled = True
    Me.ComboBox2.Location = New System.Drawing.Point(437, 19)
    Me.ComboBox2.Name = "ComboBox2"
    Me.ComboBox2.Size = New System.Drawing.Size(440, 28)
    Me.ComboBox2.TabIndex = 70
    '
    'Button3
    '
    Me.Button3.Location = New System.Drawing.Point(1053, 17)
    Me.Button3.Name = "Button3"
    Me.Button3.Size = New System.Drawing.Size(85, 58)
    Me.Button3.TabIndex = 69
    Me.Button3.Text = "離開"
    Me.Button3.UseVisualStyleBackColor = True
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(883, 17)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(85, 58)
    Me.Button2.TabIndex = 68
    Me.Button2.Text = "查詢"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(793, 49)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(84, 26)
    Me.Button1.TabIndex = 67
    Me.Button1.Text = "清空"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'DTP1
    '
    Me.DTP1.CustomFormat = "yyyy/MM/dd"
    Me.DTP1.Enabled = False
    Me.DTP1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
    Me.DTP1.Location = New System.Drawing.Point(100, 20)
    Me.DTP1.Name = "DTP1"
    Me.DTP1.Size = New System.Drawing.Size(103, 26)
    Me.DTP1.TabIndex = 57
    '
    'DTP2
    '
    Me.DTP2.CustomFormat = "yyyy/MM/dd"
    Me.DTP2.Enabled = False
    Me.DTP2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
    Me.DTP2.Location = New System.Drawing.Point(223, 20)
    Me.DTP2.Name = "DTP2"
    Me.DTP2.Size = New System.Drawing.Size(103, 26)
    Me.DTP2.TabIndex = 58
    '
    'TextBox5
    '
    Me.TextBox5.Location = New System.Drawing.Point(437, 49)
    Me.TextBox5.Name = "TextBox5"
    Me.TextBox5.Size = New System.Drawing.Size(220, 26)
    Me.TextBox5.TabIndex = 63
    '
    'CheckBox1
    '
    Me.CheckBox1.AutoSize = True
    Me.CheckBox1.Location = New System.Drawing.Point(7, 21)
    Me.CheckBox1.Name = "CheckBox1"
    Me.CheckBox1.Size = New System.Drawing.Size(92, 24)
    Me.CheckBox1.TabIndex = 59
    Me.CheckBox1.Text = "時間範圍"
    Me.CheckBox1.UseVisualStyleBackColor = True
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(362, 52)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(73, 20)
    Me.Label5.TabIndex = 60
    Me.Label5.Text = "專案代碼"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(26, 52)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(73, 20)
    Me.Label2.TabIndex = 62
    Me.Label2.Text = "銷售訂單"
    '
    'TextBox2
    '
    Me.TextBox2.Location = New System.Drawing.Point(100, 49)
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(226, 26)
    Me.TextBox2.TabIndex = 65
    '
    'DG
    '
    Me.DG.AllowUserToAddRows = False
    Me.DG.AllowUserToDeleteRows = False
    DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.DG.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
    Me.DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DG.Dock = System.Windows.Forms.DockStyle.Left
    Me.DG.Location = New System.Drawing.Point(0, 80)
    Me.DG.Name = "DG"
    Me.DG.ReadOnly = True
    Me.DG.RowTemplate.Height = 24
    Me.DG.Size = New System.Drawing.Size(761, 403)
    Me.DG.TabIndex = 56
    '
    'Panel1
    '
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
    Me.Panel1.Location = New System.Drawing.Point(761, 80)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(10, 403)
    Me.Panel1.TabIndex = 57
    '
    'DG1
    '
    Me.DG1.AllowUserToAddRows = False
    Me.DG1.AllowUserToDeleteRows = False
    DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.DG1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
    Me.DG1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DG1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DG1.Location = New System.Drawing.Point(771, 80)
    Me.DG1.Name = "DG1"
    Me.DG1.ReadOnly = True
    Me.DG1.RowTemplate.Height = 24
    Me.DG1.Size = New System.Drawing.Size(369, 403)
    Me.DG1.TabIndex = 58
    '
    'CheckBox3
    '
    Me.CheckBox3.AutoSize = True
    Me.CheckBox3.Location = New System.Drawing.Point(669, 50)
    Me.CheckBox3.Name = "CheckBox3"
    Me.CheckBox3.Size = New System.Drawing.Size(108, 24)
    Me.CheckBox3.TabIndex = 73
    Me.CheckBox3.Text = "顯示中包號"
    Me.CheckBox3.UseVisualStyleBackColor = True
    '
    'PM0504
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(1140, 483)
    Me.Controls.Add(Me.DG1)
    Me.Controls.Add(Me.Panel1)
    Me.Controls.Add(Me.DG)
    Me.Controls.Add(Me.GroupBox1)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Name = "PM0504"
    Me.Text = "包裝明細表 0504"
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents Button4 As System.Windows.Forms.Button
  Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
  Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
  Friend WithEvents Button3 As System.Windows.Forms.Button
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents DTP1 As System.Windows.Forms.DateTimePicker
  Friend WithEvents DTP2 As System.Windows.Forms.DateTimePicker
  Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
  Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  Friend WithEvents DG As System.Windows.Forms.DataGridView
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents DG1 As System.Windows.Forms.DataGridView
  Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
End Class
