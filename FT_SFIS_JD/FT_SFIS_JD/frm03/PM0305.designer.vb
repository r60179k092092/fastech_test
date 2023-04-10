<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PM0305
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
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.TBC1 = New System.Windows.Forms.TabControl()
    Me.TabPage1 = New System.Windows.Forms.TabPage()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.DGXM = New FDGV.FDataGridView()
    Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Column6 = New System.Windows.Forms.DataGridViewComboBoxColumn()
    Me.Column7 = New System.Windows.Forms.DataGridViewComboBoxColumn()
    Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Column8 = New System.Windows.Forms.DataGridViewComboBoxColumn()
    Me.Column9 = New System.Windows.Forms.DataGridViewComboBoxColumn()
    Me.Column10 = New System.Windows.Forms.DataGridViewComboBoxColumn()
    Me.Column11 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.cbAQL = New System.Windows.Forms.ComboBox()
    Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.Labwenjian = New System.Windows.Forms.Label()
    Me.Labpohuailv = New System.Windows.Forms.Label()
    Me.Labbiaozhun = New System.Windows.Forms.Label()
    Me.TBC1.SuspendLayout()
    Me.TabPage1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    CType(Me.DGXM, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
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
    Me.TBC1.Size = New System.Drawing.Size(980, 569)
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
    Me.TabPage1.Size = New System.Drawing.Size(972, 536)
    Me.TabPage1.TabIndex = 0
    Me.TabPage1.Text = "檢驗項目"
    Me.TabPage1.UseVisualStyleBackColor = True
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.DGXM)
    Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(3, 54)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(966, 479)
    Me.GroupBox2.TabIndex = 25
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "檢驗項目"
    '
    'DGXM
    '
    Me.DGXM.AllowUserToAddRows = False
    Me.DGXM.AllowUserToDeleteRows = False
    DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.DGXM.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
    Me.DGXM.Append = True
    Me.DGXM.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
    Me.DGXM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DGXM.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column12, Me.Column8, Me.Column9, Me.Column10, Me.Column11})
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
    DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.DGXM.RowsDefaultCellStyle = DataGridViewCellStyle3
    Me.DGXM.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.DGXM.RowTemplate.Height = 23
    Me.DGXM.RowWise = False
    Me.DGXM.SaveSetting = ""
    Me.DGXM.Size = New System.Drawing.Size(960, 454)
    Me.DGXM.TabIndex = 1
    '
    'Column1
    '
    Me.Column1.Frozen = True
    Me.Column1.HeaderText = "項次編號"
    Me.Column1.Name = "Column1"
    Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
    Me.Column1.Width = 78
    '
    'Column2
    '
    Me.Column2.Frozen = True
    Me.Column2.HeaderText = "中文說明"
    Me.Column2.Name = "Column2"
    Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
    Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
    Me.Column2.Width = 78
    '
    'Column3
    '
    Me.Column3.HeaderText = "英文說明"
    Me.Column3.Name = "Column3"
    Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
    Me.Column3.Width = 78
    '
    'Column4
    '
    Me.Column4.HeaderText = "量測工具"
    Me.Column4.Name = "Column4"
    Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
    Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
    Me.Column4.Width = 78
    '
    'Column5
    '
    Me.Column5.HeaderText = "量測單位"
    Me.Column5.Name = "Column5"
    Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
    Me.Column5.Width = 78
    '
    'Column6
    '
    Me.Column6.HeaderText = "誤差范圍"
    Me.Column6.Items.AddRange(New Object() {"實際值", "百分比"})
    Me.Column6.Name = "Column6"
    Me.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
    Me.Column6.Width = 78
    '
    'Column7
    '
    Me.Column7.HeaderText = "填寫方式"
    Me.Column7.Items.AddRange(New Object() {"輸入", "勾選", "磅秤", "刷碼", "標題"})
    Me.Column7.Name = "Column7"
    Me.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
    Me.Column7.Width = 78
    '
    'Column12
    '
    Me.Column12.HeaderText = "描述字段"
    Me.Column12.Name = "Column12"
    Me.Column12.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
    Me.Column12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
    Me.Column12.Width = 78
    '
    'Column8
    '
    Me.Column8.HeaderText = "不良判斷模式"
    Me.Column8.Items.AddRange(New Object() {"CR", "MA", "MI"})
    Me.Column8.Name = "Column8"
    Me.Column8.Width = 110
    '
    'Column9
    '
    Me.Column9.HeaderText = "抽樣水準"
    Me.Column9.Items.AddRange(New Object() {"L1", "L2", "L3", "S1", "S2", "S3", "S4", "STS", "100%", "INSP"})
    Me.Column9.Name = "Column9"
    Me.Column9.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
    Me.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
    Me.Column9.Width = 97
    '
    'Column10
    '
    Me.Column10.HeaderText = "工序編號"
    Me.Column10.Name = "Column10"
    Me.Column10.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
    Me.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
    Me.Column10.Width = 97
    '
    'Column11
    '
    Me.Column11.HeaderText = "破壞試驗"
    Me.Column11.Name = "Column11"
    Me.Column11.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
    Me.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
    Me.Column11.Width = 97
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.cbAQL)
    Me.GroupBox1.Controls.Add(Me.NumericUpDown1)
    Me.GroupBox1.Controls.Add(Me.TextBox1)
    Me.GroupBox1.Controls.Add(Me.Labwenjian)
    Me.GroupBox1.Controls.Add(Me.Labpohuailv)
    Me.GroupBox1.Controls.Add(Me.Labbiaozhun)
    Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(966, 51)
    Me.GroupBox1.TabIndex = 24
    Me.GroupBox1.TabStop = False
    '
    'cbAQL
    '
    Me.cbAQL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cbAQL.FormattingEnabled = True
    Me.cbAQL.Location = New System.Drawing.Point(532, 17)
    Me.cbAQL.Name = "cbAQL"
    Me.cbAQL.Size = New System.Drawing.Size(93, 28)
    Me.cbAQL.TabIndex = 10
    '
    'NumericUpDown1
    '
    Me.NumericUpDown1.DecimalPlaces = 2
    Me.NumericUpDown1.Location = New System.Drawing.Point(843, 16)
    Me.NumericUpDown1.Name = "NumericUpDown1"
    Me.NumericUpDown1.Size = New System.Drawing.Size(76, 26)
    Me.NumericUpDown1.TabIndex = 9
    '
    'TextBox1
    '
    Me.TextBox1.BackColor = System.Drawing.Color.AntiqueWhite
    Me.TextBox1.Location = New System.Drawing.Point(157, 16)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(112, 26)
    Me.TextBox1.TabIndex = 8
    '
    'Labwenjian
    '
    Me.Labwenjian.AutoSize = True
    Me.Labwenjian.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Labwenjian.Location = New System.Drawing.Point(79, 21)
    Me.Labwenjian.Name = "Labwenjian"
    Me.Labwenjian.Size = New System.Drawing.Size(73, 20)
    Me.Labwenjian.TabIndex = 4
    Me.Labwenjian.Text = "檢驗類型"
    Me.Labwenjian.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Labpohuailv
    '
    Me.Labpohuailv.AutoSize = True
    Me.Labpohuailv.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Labpohuailv.Location = New System.Drawing.Point(720, 21)
    Me.Labpohuailv.Name = "Labpohuailv"
    Me.Labpohuailv.Size = New System.Drawing.Size(121, 20)
    Me.Labpohuailv.TabIndex = 7
    Me.Labpohuailv.Text = "破壞性測試比率"
    Me.Labpohuailv.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Labbiaozhun
    '
    Me.Labbiaozhun.AutoSize = True
    Me.Labbiaozhun.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Labbiaozhun.Location = New System.Drawing.Point(389, 21)
    Me.Labbiaozhun.Name = "Labbiaozhun"
    Me.Labbiaozhun.Size = New System.Drawing.Size(146, 20)
    Me.Labbiaozhun.TabIndex = 0
    Me.Labbiaozhun.Text = "品管抽樣標準 AQL-"
    Me.Labbiaozhun.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'PM0305
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(980, 569)
    Me.Controls.Add(Me.TBC1)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Name = "PM0305"
    Me.Text = "檢驗項目清單建檔0305"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    Me.TBC1.ResumeLayout(False)
    Me.TabPage1.ResumeLayout(False)
    Me.GroupBox2.ResumeLayout(False)
    CType(Me.DGXM, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
    Friend WithEvents TBC1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents Labwenjian As System.Windows.Forms.Label
    Friend WithEvents Labpohuailv As System.Windows.Forms.Label
    Friend WithEvents Labbiaozhun As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents DGXM As FDGV.FDataGridView
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
  Friend WithEvents cbAQL As System.Windows.Forms.ComboBox
  Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Column6 As System.Windows.Forms.DataGridViewComboBoxColumn
  Friend WithEvents Column7 As System.Windows.Forms.DataGridViewComboBoxColumn
  Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Column8 As System.Windows.Forms.DataGridViewComboBoxColumn
  Friend WithEvents Column9 As System.Windows.Forms.DataGridViewComboBoxColumn
  Friend WithEvents Column10 As System.Windows.Forms.DataGridViewComboBoxColumn
  Friend WithEvents Column11 As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
