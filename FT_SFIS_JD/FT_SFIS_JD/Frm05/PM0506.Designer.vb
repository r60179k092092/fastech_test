<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PM0506
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
    Me.DTP1 = New System.Windows.Forms.DateTimePicker()
    Me.DG = New System.Windows.Forms.DataGridView()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.DTP2 = New System.Windows.Forms.DateTimePicker()
    Me.CheckBox1 = New System.Windows.Forms.CheckBox()
    Me.Button3 = New System.Windows.Forms.Button()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'DTP1
    '
    Me.DTP1.CustomFormat = "yyyy/MM/dd"
    Me.DTP1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
    Me.DTP1.Location = New System.Drawing.Point(58, 17)
    Me.DTP1.Name = "DTP1"
    Me.DTP1.Size = New System.Drawing.Size(112, 26)
    Me.DTP1.TabIndex = 40
    '
    'DG
    '
    Me.DG.AllowUserToAddRows = False
    Me.DG.AllowUserToDeleteRows = False
    Me.DG.AllowUserToResizeRows = False
    DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.DG.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
    Me.DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DG.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DG.Location = New System.Drawing.Point(0, 51)
    Me.DG.MultiSelect = False
    Me.DG.Name = "DG"
    Me.DG.ReadOnly = True
    Me.DG.RowTemplate.Height = 23
    Me.DG.Size = New System.Drawing.Size(1350, 391)
    Me.DG.TabIndex = 41
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.Label3)
    Me.GroupBox1.Controls.Add(Me.DTP2)
    Me.GroupBox1.Controls.Add(Me.CheckBox1)
    Me.GroupBox1.Controls.Add(Me.Button3)
    Me.GroupBox1.Controls.Add(Me.TextBox1)
    Me.GroupBox1.Controls.Add(Me.Label2)
    Me.GroupBox1.Controls.Add(Me.Button2)
    Me.GroupBox1.Controls.Add(Me.Button1)
    Me.GroupBox1.Controls.Add(Me.DTP1)
    Me.GroupBox1.Controls.Add(Me.Label1)
    Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
    Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(1350, 51)
    Me.GroupBox1.TabIndex = 42
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "查詢條件"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(172, 22)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(16, 16)
    Me.Label3.TabIndex = 52
    Me.Label3.Text = "-"
    '
    'DTP2
    '
    Me.DTP2.CustomFormat = "yyyy/MM/dd"
    Me.DTP2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
    Me.DTP2.Location = New System.Drawing.Point(190, 17)
    Me.DTP2.Name = "DTP2"
    Me.DTP2.Size = New System.Drawing.Size(112, 26)
    Me.DTP2.TabIndex = 51
    '
    'CheckBox1
    '
    Me.CheckBox1.AutoSize = True
    Me.CheckBox1.Location = New System.Drawing.Point(309, 20)
    Me.CheckBox1.Name = "CheckBox1"
    Me.CheckBox1.Size = New System.Drawing.Size(91, 20)
    Me.CheckBox1.TabIndex = 50
    Me.CheckBox1.Text = "刷新區間"
    Me.CheckBox1.UseVisualStyleBackColor = True
    '
    'Button3
    '
    Me.Button3.Location = New System.Drawing.Point(1159, 14)
    Me.Button3.Name = "Button3"
    Me.Button3.Size = New System.Drawing.Size(64, 33)
    Me.Button3.TabIndex = 49
    Me.Button3.Text = "離開"
    Me.Button3.UseVisualStyleBackColor = True
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(713, 17)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(440, 26)
    Me.TextBox1.TabIndex = 48
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(664, 22)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(56, 16)
    Me.Label2.TabIndex = 47
    Me.Label2.Text = "檔名："
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(526, 14)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(132, 33)
    Me.Button2.TabIndex = 46
    Me.Button2.Text = "產生Excel報表"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(405, 14)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(115, 33)
    Me.Button1.TabIndex = 45
    Me.Button1.Text = "計算生產統計"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(6, 22)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(56, 16)
    Me.Label1.TabIndex = 44
    Me.Label1.Text = "日期："
    '
    'PM0506
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(1350, 442)
    Me.Controls.Add(Me.DG)
    Me.Controls.Add(Me.GroupBox1)
    Me.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Name = "PM0506"
    Me.Text = "生產日報0506"
    CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents DTP1 As System.Windows.Forms.DateTimePicker
  Friend WithEvents DG As System.Windows.Forms.DataGridView
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
  Friend WithEvents Button3 As System.Windows.Forms.Button
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents DTP2 As System.Windows.Forms.DateTimePicker
End Class
