<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm0606
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
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.CheckBox4 = New System.Windows.Forms.CheckBox()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.DTP2 = New System.Windows.Forms.DateTimePicker()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.DTP1 = New System.Windows.Forms.DateTimePicker()
    Me.CheckBox3 = New System.Windows.Forms.CheckBox()
    Me.ComboBox2 = New System.Windows.Forms.ComboBox()
    Me.CheckBox2 = New System.Windows.Forms.CheckBox()
    Me.ComboBox1 = New System.Windows.Forms.ComboBox()
    Me.CheckBox1 = New System.Windows.Forms.CheckBox()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TabPage1 = New System.Windows.Forms.TabPage()
    Me.DG = New System.Windows.Forms.DataGridView()
    Me.TabPage2 = New System.Windows.Forms.TabPage()
    Me.DG1 = New System.Windows.Forms.DataGridView()
    Me.CheckBox5 = New System.Windows.Forms.CheckBox()
    Me.TabPage3 = New System.Windows.Forms.TabPage()
    Me.DG2 = New System.Windows.Forms.DataGridView()
    Me.Panel1.SuspendLayout()
    Me.TabControl1.SuspendLayout()
    Me.TabPage1.SuspendLayout()
    CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.TabPage2.SuspendLayout()
    CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.TabPage3.SuspendLayout()
    CType(Me.DG2, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.CheckBox5)
    Me.Panel1.Controls.Add(Me.Button2)
    Me.Panel1.Controls.Add(Me.CheckBox4)
    Me.Panel1.Controls.Add(Me.Button1)
    Me.Panel1.Controls.Add(Me.DTP2)
    Me.Panel1.Controls.Add(Me.Label1)
    Me.Panel1.Controls.Add(Me.DTP1)
    Me.Panel1.Controls.Add(Me.CheckBox3)
    Me.Panel1.Controls.Add(Me.ComboBox2)
    Me.Panel1.Controls.Add(Me.CheckBox2)
    Me.Panel1.Controls.Add(Me.ComboBox1)
    Me.Panel1.Controls.Add(Me.CheckBox1)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(1058, 68)
    Me.Panel1.TabIndex = 0
    '
    'Button2
    '
    Me.Button2.Font = New System.Drawing.Font("SimHei", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Button2.Location = New System.Drawing.Point(938, 5)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(108, 59)
    Me.Button2.TabIndex = 10
    Me.Button2.Text = "離開"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'CheckBox4
    '
    Me.CheckBox4.AutoSize = True
    Me.CheckBox4.Checked = True
    Me.CheckBox4.CheckState = System.Windows.Forms.CheckState.Checked
    Me.CheckBox4.Location = New System.Drawing.Point(417, 38)
    Me.CheckBox4.Name = "CheckBox4"
    Me.CheckBox4.Size = New System.Drawing.Size(214, 20)
    Me.CheckBox4.TabIndex = 9
    Me.CheckBox4.Text = "只顯示有上料資訊的紀錄"
    Me.CheckBox4.UseVisualStyleBackColor = True
    '
    'Button1
    '
    Me.Button1.Font = New System.Drawing.Font("SimHei", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Button1.Location = New System.Drawing.Point(824, 5)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(108, 59)
    Me.Button1.TabIndex = 8
    Me.Button1.Text = "查詢"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'DTP2
    '
    Me.DTP2.CustomFormat = "yyyy/MM/dd"
    Me.DTP2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
    Me.DTP2.Location = New System.Drawing.Point(283, 34)
    Me.DTP2.Name = "DTP2"
    Me.DTP2.Size = New System.Drawing.Size(125, 26)
    Me.DTP2.TabIndex = 7
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(245, 39)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(25, 16)
    Me.Label1.TabIndex = 6
    Me.Label1.Text = "至"
    '
    'DTP1
    '
    Me.DTP1.CustomFormat = "yyyy/MM/dd"
    Me.DTP1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
    Me.DTP1.Location = New System.Drawing.Point(116, 34)
    Me.DTP1.Name = "DTP1"
    Me.DTP1.Size = New System.Drawing.Size(125, 26)
    Me.DTP1.TabIndex = 5
    '
    'CheckBox3
    '
    Me.CheckBox3.AutoSize = True
    Me.CheckBox3.Location = New System.Drawing.Point(7, 37)
    Me.CheckBox3.Name = "CheckBox3"
    Me.CheckBox3.Size = New System.Drawing.Size(112, 20)
    Me.CheckBox3.TabIndex = 4
    Me.CheckBox3.Text = "日期起始："
    Me.CheckBox3.UseVisualStyleBackColor = True
    '
    'ComboBox2
    '
    Me.ComboBox2.FormattingEnabled = True
    Me.ComboBox2.Location = New System.Drawing.Point(417, 6)
    Me.ComboBox2.Name = "ComboBox2"
    Me.ComboBox2.Size = New System.Drawing.Size(209, 24)
    Me.ComboBox2.TabIndex = 3
    '
    'CheckBox2
    '
    Me.CheckBox2.AutoSize = True
    Me.CheckBox2.Location = New System.Drawing.Point(328, 8)
    Me.CheckBox2.Name = "CheckBox2"
    Me.CheckBox2.Size = New System.Drawing.Size(95, 20)
    Me.CheckBox2.TabIndex = 2
    Me.CheckBox2.Text = "機臺號："
    Me.CheckBox2.UseVisualStyleBackColor = True
    '
    'ComboBox1
    '
    Me.ComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
    Me.ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
    Me.ComboBox1.FormattingEnabled = True
    Me.ComboBox1.Location = New System.Drawing.Point(116, 6)
    Me.ComboBox1.Name = "ComboBox1"
    Me.ComboBox1.Size = New System.Drawing.Size(180, 24)
    Me.ComboBox1.TabIndex = 1
    '
    'CheckBox1
    '
    Me.CheckBox1.AutoSize = True
    Me.CheckBox1.Location = New System.Drawing.Point(41, 8)
    Me.CheckBox1.Name = "CheckBox1"
    Me.CheckBox1.Size = New System.Drawing.Size(78, 20)
    Me.CheckBox1.TabIndex = 0
    Me.CheckBox1.Text = "工單："
    Me.CheckBox1.UseVisualStyleBackColor = True
    '
    'TabControl1
    '
    Me.TabControl1.Controls.Add(Me.TabPage1)
    Me.TabControl1.Controls.Add(Me.TabPage2)
    Me.TabControl1.Controls.Add(Me.TabPage3)
    Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TabControl1.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TabControl1.Location = New System.Drawing.Point(0, 68)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(1058, 205)
    Me.TabControl1.TabIndex = 1
    '
    'TabPage1
    '
    Me.TabPage1.Controls.Add(Me.DG)
    Me.TabPage1.Location = New System.Drawing.Point(4, 26)
    Me.TabPage1.Name = "TabPage1"
    Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage1.Size = New System.Drawing.Size(1050, 175)
    Me.TabPage1.TabIndex = 0
    Me.TabPage1.Text = "操作紀錄明細"
    Me.TabPage1.UseVisualStyleBackColor = True
    '
    'DG
    '
    Me.DG.AllowUserToAddRows = False
    Me.DG.AllowUserToDeleteRows = False
    Me.DG.AllowUserToOrderColumns = True
    Me.DG.AllowUserToResizeRows = False
    DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.DG.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
    Me.DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DG.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DG.Location = New System.Drawing.Point(3, 3)
    Me.DG.Name = "DG"
    Me.DG.ReadOnly = True
    Me.DG.RowTemplate.Height = 24
    Me.DG.Size = New System.Drawing.Size(1044, 169)
    Me.DG.TabIndex = 0
    '
    'TabPage2
    '
    Me.TabPage2.Controls.Add(Me.DG1)
    Me.TabPage2.Location = New System.Drawing.Point(4, 26)
    Me.TabPage2.Name = "TabPage2"
    Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage2.Size = New System.Drawing.Size(1050, 175)
    Me.TabPage2.TabIndex = 1
    Me.TabPage2.Text = "上料資訊"
    Me.TabPage2.UseVisualStyleBackColor = True
    '
    'DG1
    '
    Me.DG1.AllowUserToAddRows = False
    Me.DG1.AllowUserToDeleteRows = False
    Me.DG1.AllowUserToOrderColumns = True
    Me.DG1.AllowUserToResizeRows = False
    DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.DG1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
    Me.DG1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DG1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DG1.Location = New System.Drawing.Point(3, 3)
    Me.DG1.Name = "DG1"
    Me.DG1.ReadOnly = True
    Me.DG1.RowTemplate.Height = 24
    Me.DG1.Size = New System.Drawing.Size(1044, 169)
    Me.DG1.TabIndex = 0
    '
    'CheckBox5
    '
    Me.CheckBox5.AutoSize = True
    Me.CheckBox5.Location = New System.Drawing.Point(632, 8)
    Me.CheckBox5.Name = "CheckBox5"
    Me.CheckBox5.Size = New System.Drawing.Size(163, 20)
    Me.CheckBox5.TabIndex = 11
    Me.CheckBox5.Text = "單純刷料登錄查詢"
    Me.CheckBox5.UseVisualStyleBackColor = True
    '
    'TabPage3
    '
    Me.TabPage3.Controls.Add(Me.DG2)
    Me.TabPage3.Location = New System.Drawing.Point(4, 26)
    Me.TabPage3.Name = "TabPage3"
    Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage3.Size = New System.Drawing.Size(1050, 175)
    Me.TabPage3.TabIndex = 2
    Me.TabPage3.Text = "工單用料查詢"
    Me.TabPage3.UseVisualStyleBackColor = True
    '
    'DG2
    '
    Me.DG2.AllowUserToAddRows = False
    Me.DG2.AllowUserToDeleteRows = False
    Me.DG2.AllowUserToOrderColumns = True
    Me.DG2.AllowUserToResizeRows = False
    DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.DG2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
    Me.DG2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DG2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DG2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DG2.Location = New System.Drawing.Point(3, 3)
    Me.DG2.Name = "DG2"
    Me.DG2.ReadOnly = True
    Me.DG2.RowTemplate.Height = 24
    Me.DG2.Size = New System.Drawing.Size(1044, 169)
    Me.DG2.TabIndex = 1
    '
    'Frm0606
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(1058, 273)
    Me.Controls.Add(Me.TabControl1)
    Me.Controls.Add(Me.Panel1)
    Me.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Name = "Frm0606"
    Me.Text = "SMT用料操作明細查詢"
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.TabControl1.ResumeLayout(False)
    Me.TabPage1.ResumeLayout(False)
    CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
    Me.TabPage2.ResumeLayout(False)
    CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.TabPage3.ResumeLayout(False)
    CType(Me.DG2, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents DTP2 As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents DTP1 As System.Windows.Forms.DateTimePicker
  Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
  Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
  Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
  Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
  Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
  Friend WithEvents DG As System.Windows.Forms.DataGridView
  Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
  Friend WithEvents DG1 As System.Windows.Forms.DataGridView
  Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
  Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
  Friend WithEvents DG2 As System.Windows.Forms.DataGridView
End Class

