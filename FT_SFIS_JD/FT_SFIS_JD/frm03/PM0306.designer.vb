<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PM0306
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
    Me.components = New System.ComponentModel.Container()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.TBC1 = New System.Windows.Forms.TabControl()
    Me.TabPage1 = New System.Windows.Forms.TabPage()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.DGXM = New FDGV.FDataGridView()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.CheckBox1 = New System.Windows.Forms.CheckBox()
    Me.SPEC = New System.Windows.Forms.Label()
    Me.Label38 = New System.Windows.Forms.Label()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.Labmaterial = New System.Windows.Forms.Label()
    Me.ComboBox2 = New System.Windows.Forms.ComboBox()
    Me.Labwenjian = New System.Windows.Forms.Label()
    Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
    Me.TBC1.SuspendLayout()
    Me.TabPage1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    CType(Me.DGXM, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'TBC1
    '
    Me.TBC1.Controls.Add(Me.TabPage1)
    Me.TBC1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TBC1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TBC1.Location = New System.Drawing.Point(0, 0)
    Me.TBC1.Name = "TBC1"
    Me.TBC1.SelectedIndex = 0
    Me.TBC1.Size = New System.Drawing.Size(917, 586)
    Me.TBC1.TabIndex = 0
    '
    'TabPage1
    '
    Me.TabPage1.Controls.Add(Me.GroupBox2)
    Me.TabPage1.Controls.Add(Me.GroupBox1)
    Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TabPage1.Location = New System.Drawing.Point(4, 29)
    Me.TabPage1.Name = "TabPage1"
    Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage1.Size = New System.Drawing.Size(909, 553)
    Me.TabPage1.TabIndex = 0
    Me.TabPage1.Text = "檢驗規范標準"
    Me.TabPage1.UseVisualStyleBackColor = True
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.DGXM)
    Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(3, 73)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(903, 477)
    Me.GroupBox2.TabIndex = 28
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "檢驗項目"
    '
    'DGXM
    '
    Me.DGXM.AllowUserToAddRows = False
    Me.DGXM.AllowUserToDeleteRows = False
    Me.DGXM.AllowUserToResizeRows = False
    DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.DGXM.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
    Me.DGXM.Append = True
    Me.DGXM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DGXM.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
    Me.DGXM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.DGXM.DefaultCellStyle = DataGridViewCellStyle2
    Me.DGXM.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DGXM.Location = New System.Drawing.Point(3, 22)
    Me.DGXM.MultiSelect = False
    Me.DGXM.Name = "DGXM"
    Me.DGXM.RowHeadersVisible = False
    Me.DGXM.RowTemplate.Height = 23
    Me.DGXM.RowWise = True
    Me.DGXM.SaveSetting = ""
    Me.DGXM.Size = New System.Drawing.Size(897, 452)
    Me.DGXM.TabIndex = 1
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.CheckBox1)
    Me.GroupBox1.Controls.Add(Me.SPEC)
    Me.GroupBox1.Controls.Add(Me.Label38)
    Me.GroupBox1.Controls.Add(Me.Button1)
    Me.GroupBox1.Controls.Add(Me.TextBox1)
    Me.GroupBox1.Controls.Add(Me.Labmaterial)
    Me.GroupBox1.Controls.Add(Me.ComboBox2)
    Me.GroupBox1.Controls.Add(Me.Labwenjian)
    Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(903, 70)
    Me.GroupBox1.TabIndex = 27
    Me.GroupBox1.TabStop = False
    '
    'CheckBox1
    '
    Me.CheckBox1.AutoSize = True
    Me.CheckBox1.Checked = True
    Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
    Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CheckBox1.Location = New System.Drawing.Point(558, 15)
    Me.CheckBox1.Name = "CheckBox1"
    Me.CheckBox1.Size = New System.Drawing.Size(236, 24)
    Me.CheckBox1.TabIndex = 58
    Me.CheckBox1.Text = "只有成品與半成品之檢驗規範"
    Me.CheckBox1.UseVisualStyleBackColor = True
    '
    'SPEC
    '
    Me.SPEC.AutoSize = True
    Me.SPEC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.SPEC.Location = New System.Drawing.Point(71, 47)
    Me.SPEC.Name = "SPEC"
    Me.SPEC.Size = New System.Drawing.Size(0, 20)
    Me.SPEC.TabIndex = 57
    '
    'Label38
    '
    Me.Label38.AutoSize = True
    Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label38.Location = New System.Drawing.Point(21, 47)
    Me.Label38.Name = "Label38"
    Me.Label38.Size = New System.Drawing.Size(45, 20)
    Me.Label38.TabIndex = 56
    Me.Label38.Text = "說明:"
    '
    'Button1
    '
    Me.Button1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Button1.Location = New System.Drawing.Point(508, 14)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(29, 23)
    Me.Button1.TabIndex = 12
    Me.Button1.Text = "..."
    Me.Button1.UseVisualStyleBackColor = True
    '
    'TextBox1
    '
    Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
    Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox1.Location = New System.Drawing.Point(348, 12)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(159, 26)
    Me.TextBox1.TabIndex = 10
    '
    'Labmaterial
    '
    Me.Labmaterial.AutoSize = True
    Me.Labmaterial.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Labmaterial.Location = New System.Drawing.Point(275, 17)
    Me.Labmaterial.Name = "Labmaterial"
    Me.Labmaterial.Size = New System.Drawing.Size(73, 20)
    Me.Labmaterial.TabIndex = 4
    Me.Labmaterial.Text = "物料編號"
    Me.Labmaterial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'ComboBox2
    '
    Me.ComboBox2.BackColor = System.Drawing.Color.AntiqueWhite
    Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ComboBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ComboBox2.FormattingEnabled = True
    Me.ComboBox2.Location = New System.Drawing.Point(95, 13)
    Me.ComboBox2.Name = "ComboBox2"
    Me.ComboBox2.Size = New System.Drawing.Size(163, 28)
    Me.ComboBox2.TabIndex = 8
    '
    'Labwenjian
    '
    Me.Labwenjian.AutoSize = True
    Me.Labwenjian.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Labwenjian.Location = New System.Drawing.Point(21, 17)
    Me.Labwenjian.Name = "Labwenjian"
    Me.Labwenjian.Size = New System.Drawing.Size(73, 20)
    Me.Labwenjian.TabIndex = 7
    Me.Labwenjian.Text = "檢驗類型"
    Me.Labwenjian.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'PM0306
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(917, 586)
    Me.Controls.Add(Me.TBC1)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Name = "PM0306"
    Me.Text = "檢驗規范標準設定0306"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    Me.TBC1.ResumeLayout(False)
    Me.TabPage1.ResumeLayout(False)
    Me.GroupBox2.ResumeLayout(False)
    CType(Me.DGXM, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents TBC1 As System.Windows.Forms.TabControl
  Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
  Friend WithEvents Labmaterial As System.Windows.Forms.Label
  Friend WithEvents Labwenjian As System.Windows.Forms.Label
  Friend WithEvents Timer1 As System.Windows.Forms.Timer
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents DGXM As FDGV.FDataGridView
  Friend WithEvents SPEC As System.Windows.Forms.Label
  Friend WithEvents Label38 As System.Windows.Forms.Label
  Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class
