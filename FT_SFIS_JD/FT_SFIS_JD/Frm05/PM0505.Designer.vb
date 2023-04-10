<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PM0505
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PM0505))
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.DataGridView1 = New System.Windows.Forms.DataGridView()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
    Me.TSBexit = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
    Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
    Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
    Me.HideSTD = New System.Windows.Forms.ToolStripMenuItem()
    Me.SHOWSTD = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.DataGridView2 = New System.Windows.Forms.DataGridView()
    Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
    Me.Splitter1 = New System.Windows.Forms.Splitter()
    CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.ToolStrip1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'DataGridView1
    '
    Me.DataGridView1.AllowUserToAddRows = False
    Me.DataGridView1.AllowUserToDeleteRows = False
    Me.DataGridView1.AllowUserToResizeRows = False
    DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
    Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DataGridView1.Location = New System.Drawing.Point(4, 23)
    Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
    Me.DataGridView1.MultiSelect = False
    Me.DataGridView1.Name = "DataGridView1"
    Me.DataGridView1.ReadOnly = True
    Me.DataGridView1.RowTemplate.Height = 23
    Me.DataGridView1.Size = New System.Drawing.Size(892, 195)
    Me.DataGridView1.TabIndex = 36
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.DataGridView1)
    Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
    Me.GroupBox1.Location = New System.Drawing.Point(0, 25)
    Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
    Me.GroupBox1.Size = New System.Drawing.Size(900, 222)
    Me.GroupBox1.TabIndex = 37
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "在制工單"
    '
    'ToolStrip1
    '
    Me.ToolStrip1.BackgroundImage = Global.FT_SFIS_JD.My.Resources.Resources._031
    Me.ToolStrip1.Font = New System.Drawing.Font("黑体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBexit, Me.ToolStripSeparator1, Me.ToolStripSeparator4, Me.ToolStripSeparator2, Me.ToolStripDropDownButton1, Me.ToolStripButton1})
    Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
    Me.ToolStrip1.Name = "ToolStrip1"
    Me.ToolStrip1.Size = New System.Drawing.Size(900, 25)
    Me.ToolStrip1.TabIndex = 35
    Me.ToolStrip1.Text = "ToolStrip1"
    '
    'TSBexit
    '
    Me.TSBexit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
    Me.TSBexit.Image = CType(resources.GetObject("TSBexit.Image"), System.Drawing.Image)
    Me.TSBexit.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.TSBexit.Name = "TSBexit"
    Me.TSBexit.Size = New System.Drawing.Size(44, 22)
    Me.TSBexit.Text = "離開"
    '
    'ToolStripSeparator1
    '
    Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
    Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
    '
    'ToolStripSeparator4
    '
    Me.ToolStripSeparator4.Image = Global.FT_SFIS_JD.My.Resources.Resources.Reflash
    Me.ToolStripSeparator4.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
    Me.ToolStripSeparator4.Size = New System.Drawing.Size(124, 22)
    Me.ToolStripSeparator4.Text = "更新時間設定"
    '
    'ToolStripSeparator2
    '
    Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
    Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
    '
    'ToolStripDropDownButton1
    '
    Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HideSTD, Me.SHOWSTD})
    Me.ToolStripDropDownButton1.Image = Global.FT_SFIS_JD.My.Resources.Resources.cog_edit_1_1
    Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
    Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(101, 22)
    Me.ToolStripDropDownButton1.Text = "隱藏標準"
    '
    'HideSTD
    '
    Me.HideSTD.Checked = True
    Me.HideSTD.CheckState = System.Windows.Forms.CheckState.Checked
    Me.HideSTD.Name = "HideSTD"
    Me.HideSTD.Size = New System.Drawing.Size(140, 22)
    Me.HideSTD.Text = "隱藏標準"
    '
    'SHOWSTD
    '
    Me.SHOWSTD.Name = "SHOWSTD"
    Me.SHOWSTD.Size = New System.Drawing.Size(140, 22)
    Me.SHOWSTD.Text = "顯示標準"
    '
    'ToolStripButton1
    '
    Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
    Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
    Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton1.Name = "ToolStripButton1"
    Me.ToolStripButton1.Size = New System.Drawing.Size(140, 22)
    Me.ToolStripButton1.Text = "刷新在製工單明細"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.DataGridView2)
    Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.GroupBox2.Location = New System.Drawing.Point(0, 252)
    Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
    Me.GroupBox2.Size = New System.Drawing.Size(900, 305)
    Me.GroupBox2.TabIndex = 38
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "在制工單明細—工序"
    '
    'DataGridView2
    '
    Me.DataGridView2.AllowUserToAddRows = False
    Me.DataGridView2.AllowUserToDeleteRows = False
    Me.DataGridView2.AllowUserToOrderColumns = True
    Me.DataGridView2.AllowUserToResizeRows = False
    DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.DataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
    Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DataGridView2.Location = New System.Drawing.Point(4, 23)
    Me.DataGridView2.Margin = New System.Windows.Forms.Padding(4)
    Me.DataGridView2.MultiSelect = False
    Me.DataGridView2.Name = "DataGridView2"
    Me.DataGridView2.ReadOnly = True
    Me.DataGridView2.RowTemplate.Height = 23
    Me.DataGridView2.Size = New System.Drawing.Size(892, 278)
    Me.DataGridView2.TabIndex = 37
    '
    'Timer1
    '
    Me.Timer1.Interval = 1000
    '
    'Splitter1
    '
    Me.Splitter1.BackColor = System.Drawing.Color.LightBlue
    Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Splitter1.Location = New System.Drawing.Point(0, 247)
    Me.Splitter1.Name = "Splitter1"
    Me.Splitter1.Size = New System.Drawing.Size(900, 5)
    Me.Splitter1.TabIndex = 38
    Me.Splitter1.TabStop = False
    '
    'PM0505
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(900, 557)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.Splitter1)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.ToolStrip1)
    Me.Font = New System.Drawing.Font("黑体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Margin = New System.Windows.Forms.Padding(4)
    Me.Name = "PM0505"
    Me.Text = "生產即時看板0505"
    CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.ToolStrip1.ResumeLayout(False)
    Me.ToolStrip1.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
  Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents TSBexit As System.Windows.Forms.ToolStripButton
  Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
  Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripButton
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents Timer1 As System.Windows.Forms.Timer
  Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
  Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
  Friend WithEvents HideSTD As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents SHOWSTD As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
  Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class
