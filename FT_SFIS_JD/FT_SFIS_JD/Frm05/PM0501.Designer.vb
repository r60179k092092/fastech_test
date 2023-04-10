<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PM0501
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
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.DG = New System.Windows.Forms.DataGridView()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.Button3 = New System.Windows.Forms.Button()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.ComboBox1 = New System.Windows.Forms.ComboBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.DTP1 = New System.Windows.Forms.DateTimePicker()
    Me.DTP2 = New System.Windows.Forms.DateTimePicker()
    Me.TextBox5 = New System.Windows.Forms.TextBox()
    Me.CheckBox1 = New System.Windows.Forms.CheckBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TextBox2 = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TextBox3 = New System.Windows.Forms.TextBox()
    Me.Panel1.SuspendLayout()
    CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.DG)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Panel1.Location = New System.Drawing.Point(0, 103)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(1088, 303)
    Me.Panel1.TabIndex = 48
    '
    'DG
    '
    Me.DG.AllowUserToAddRows = False
    Me.DG.AllowUserToDeleteRows = False
    DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.DG.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
    Me.DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DG.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DG.Location = New System.Drawing.Point(0, 0)
    Me.DG.Name = "DG"
    Me.DG.ReadOnly = True
    Me.DG.RowTemplate.Height = 24
    Me.DG.Size = New System.Drawing.Size(1088, 303)
    Me.DG.TabIndex = 0
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.Label4)
    Me.GroupBox1.Controls.Add(Me.TextBox3)
    Me.GroupBox1.Controls.Add(Me.Button3)
    Me.GroupBox1.Controls.Add(Me.Button2)
    Me.GroupBox1.Controls.Add(Me.Button1)
    Me.GroupBox1.Controls.Add(Me.ComboBox1)
    Me.GroupBox1.Controls.Add(Me.Label3)
    Me.GroupBox1.Controls.Add(Me.DTP1)
    Me.GroupBox1.Controls.Add(Me.DTP2)
    Me.GroupBox1.Controls.Add(Me.TextBox5)
    Me.GroupBox1.Controls.Add(Me.CheckBox1)
    Me.GroupBox1.Controls.Add(Me.Label5)
    Me.GroupBox1.Controls.Add(Me.Label1)
    Me.GroupBox1.Controls.Add(Me.TextBox1)
    Me.GroupBox1.Controls.Add(Me.Label2)
    Me.GroupBox1.Controls.Add(Me.TextBox2)
    Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
    Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(1088, 103)
    Me.GroupBox1.TabIndex = 52
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "查詢條件"
    '
    'Button3
    '
    Me.Button3.Location = New System.Drawing.Point(997, 53)
    Me.Button3.Name = "Button3"
    Me.Button3.Size = New System.Drawing.Size(85, 47)
    Me.Button3.TabIndex = 69
    Me.Button3.Text = "離開"
    Me.Button3.UseVisualStyleBackColor = True
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(883, 53)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(108, 47)
    Me.Button2.TabIndex = 68
    Me.Button2.Text = "查詢"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(997, 15)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(85, 32)
    Me.Button1.TabIndex = 67
    Me.Button1.Text = "清空"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'ComboBox1
    '
    Me.ComboBox1.FormattingEnabled = True
    Me.ComboBox1.Items.AddRange(New Object() {"0 依工單", "1 每日統計", "2 每小時統計", "3 總和統計", "4 依工序分類", "5 依員工分類", "6 依工作站分類"})
    Me.ComboBox1.Location = New System.Drawing.Point(756, 53)
    Me.ComboBox1.Name = "ComboBox1"
    Me.ComboBox1.Size = New System.Drawing.Size(121, 28)
    Me.ComboBox1.TabIndex = 56
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(674, 57)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(89, 20)
    Me.Label3.TabIndex = 66
    Me.Label3.Text = "彙總方式："
    '
    'DTP1
    '
    Me.DTP1.CustomFormat = "yyyy/MM/dd"
    Me.DTP1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
    Me.DTP1.Location = New System.Drawing.Point(100, 18)
    Me.DTP1.Name = "DTP1"
    Me.DTP1.Size = New System.Drawing.Size(103, 26)
    Me.DTP1.TabIndex = 57
    '
    'DTP2
    '
    Me.DTP2.CustomFormat = "yyyy/MM/dd"
    Me.DTP2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
    Me.DTP2.Location = New System.Drawing.Point(223, 18)
    Me.DTP2.Name = "DTP2"
    Me.DTP2.Size = New System.Drawing.Size(103, 26)
    Me.DTP2.TabIndex = 58
    '
    'TextBox5
    '
    Me.TextBox5.Location = New System.Drawing.Point(437, 54)
    Me.TextBox5.Name = "TextBox5"
    Me.TextBox5.Size = New System.Drawing.Size(220, 26)
    Me.TextBox5.TabIndex = 63
    '
    'CheckBox1
    '
    Me.CheckBox1.AutoSize = True
    Me.CheckBox1.Checked = True
    Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
    Me.CheckBox1.Location = New System.Drawing.Point(7, 19)
    Me.CheckBox1.Name = "CheckBox1"
    Me.CheckBox1.Size = New System.Drawing.Size(92, 24)
    Me.CheckBox1.TabIndex = 59
    Me.CheckBox1.Text = "時間範圍"
    Me.CheckBox1.UseVisualStyleBackColor = True
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(362, 57)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(73, 20)
    Me.Label5.TabIndex = 60
    Me.Label5.Text = "專案代碼"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(681, 21)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(73, 20)
    Me.Label1.TabIndex = 61
    Me.Label1.Text = "工單號碼"
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(756, 18)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(220, 26)
    Me.TextBox1.TabIndex = 64
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(26, 57)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(73, 20)
    Me.Label2.TabIndex = 62
    Me.Label2.Text = "銷售訂單"
    '
    'TextBox2
    '
    Me.TextBox2.Location = New System.Drawing.Point(100, 54)
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(226, 26)
    Me.TextBox2.TabIndex = 65
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(362, 21)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(73, 20)
    Me.Label4.TabIndex = 70
    Me.Label4.Text = "製令單號"
    '
    'TextBox3
    '
    Me.TextBox3.Location = New System.Drawing.Point(437, 18)
    Me.TextBox3.Name = "TextBox3"
    Me.TextBox3.Size = New System.Drawing.Size(220, 26)
    Me.TextBox3.TabIndex = 71
    '
    'PM0501
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(1088, 406)
    Me.Controls.Add(Me.Panel1)
    Me.Controls.Add(Me.GroupBox1)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Name = "PM0501"
    Me.Text = "不良原因統計0501"
    Me.Panel1.ResumeLayout(False)
    CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents DG As System.Windows.Forms.DataGridView
  Friend WithEvents Button3 As System.Windows.Forms.Button
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents DTP1 As System.Windows.Forms.DateTimePicker
  Friend WithEvents DTP2 As System.Windows.Forms.DateTimePicker
  Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
  Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
End Class
