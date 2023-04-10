<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
  Inherits System.Windows.Forms.Form

  'Form 重寫 Dispose，以清理組件列表。
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing AndAlso components IsNot Nothing Then
      components.Dispose()
    End If
    MyBase.Dispose(disposing)
  End Sub

  'Windows 窗體設計器所必需的
  Private components As System.ComponentModel.IContainer

  '注意: 以下過程是 Windows 窗體設計器所必需的
  '可以使用 Windows 窗體設計器修改它。
  '不要使用代碼編輯器修改它。
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
    Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
    Me.FrmBd = New System.Windows.Forms.Label()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TabPage1 = New System.Windows.Forms.TabPage()
    Me.Panel2 = New System.Windows.Forms.Panel()
    Me.TreeView1 = New System.Windows.Forms.TreeView()
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.Panel3 = New System.Windows.Forms.Panel()
    Me.Panel4 = New System.Windows.Forms.Panel()
    Me.Lablogininfor = New System.Windows.Forms.Label()
    Me.Panel13 = New System.Windows.Forms.Panel()
    Me.PictureBox5 = New System.Windows.Forms.PictureBox()
    Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
    Me.TSSLgs = New System.Windows.Forms.ToolStripStatusLabel()
    Me.TSSlgs1 = New System.Windows.Forms.ToolStripStatusLabel()
    Me.Labeljt = New System.Windows.Forms.ToolStripStatusLabel()
    Me.Label19 = New System.Windows.Forms.ToolStripStatusLabel()
    Me.TabControl1.SuspendLayout()
    Me.TabPage1.SuspendLayout()
    Me.Panel1.SuspendLayout()
    Me.Panel3.SuspendLayout()
    Me.Panel4.SuspendLayout()
    CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.StatusStrip1.SuspendLayout()
    Me.SuspendLayout()
    '
    'Timer1
    '
    Me.Timer1.Enabled = True
    Me.Timer1.Interval = 1000
    '
    'FrmBd
    '
    Me.FrmBd.AutoSize = True
    Me.FrmBd.Cursor = System.Windows.Forms.Cursors.Hand
    Me.FrmBd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FrmBd.ForeColor = System.Drawing.Color.SaddleBrown
    Me.FrmBd.Location = New System.Drawing.Point(58, 35)
    Me.FrmBd.Name = "FrmBd"
    Me.FrmBd.Size = New System.Drawing.Size(79, 15)
    Me.FrmBd.TabIndex = 18
    Me.FrmBd.Text = "LED包裝打印"
    '
    'TabControl1
    '
    Me.TabControl1.Controls.Add(Me.TabPage1)
    Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TabControl1.Location = New System.Drawing.Point(3, 0)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.ShowToolTips = True
    Me.TabControl1.Size = New System.Drawing.Size(919, 503)
    Me.TabControl1.TabIndex = 19
    '
    'TabPage1
    '
    Me.TabPage1.Controls.Add(Me.Panel2)
    Me.TabPage1.Controls.Add(Me.TreeView1)
    Me.TabPage1.Controls.Add(Me.Panel1)
    Me.TabPage1.Location = New System.Drawing.Point(4, 26)
    Me.TabPage1.Name = "TabPage1"
    Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage1.Size = New System.Drawing.Size(911, 473)
    Me.TabPage1.TabIndex = 0
    Me.TabPage1.Text = "主功能表"
    Me.TabPage1.UseVisualStyleBackColor = True
    '
    'Panel2
    '
    Me.Panel2.AutoScroll = True
    Me.Panel2.BackColor = System.Drawing.Color.Transparent
    Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Panel2.Location = New System.Drawing.Point(319, 51)
    Me.Panel2.Name = "Panel2"
    Me.Panel2.Size = New System.Drawing.Size(589, 419)
    Me.Panel2.TabIndex = 7
    '
    'TreeView1
    '
    Me.TreeView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
    Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Left
    Me.TreeView1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText
    Me.TreeView1.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TreeView1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.TreeView1.HideSelection = False
    Me.TreeView1.ItemHeight = 40
    Me.TreeView1.LineColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TreeView1.Location = New System.Drawing.Point(3, 51)
    Me.TreeView1.Name = "TreeView1"
    Me.TreeView1.Size = New System.Drawing.Size(316, 419)
    Me.TreeView1.TabIndex = 8
    '
    'Panel1
    '
    Me.Panel1.BackColor = System.Drawing.Color.Transparent
    Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
    Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.Panel1.Controls.Add(Me.Panel3)
    Me.Panel1.Controls.Add(Me.Panel13)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Location = New System.Drawing.Point(3, 3)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(905, 48)
    Me.Panel1.TabIndex = 9
    '
    'Panel3
    '
    Me.Panel3.Controls.Add(Me.Panel4)
    Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
    Me.Panel3.Location = New System.Drawing.Point(559, 0)
    Me.Panel3.Name = "Panel3"
    Me.Panel3.Size = New System.Drawing.Size(346, 48)
    Me.Panel3.TabIndex = 3
    '
    'Panel4
    '
    Me.Panel4.BackgroundImage = CType(resources.GetObject("Panel4.BackgroundImage"), System.Drawing.Image)
    Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.Panel4.Controls.Add(Me.Lablogininfor)
    Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
    Me.Panel4.Location = New System.Drawing.Point(0, 15)
    Me.Panel4.Name = "Panel4"
    Me.Panel4.Size = New System.Drawing.Size(346, 33)
    Me.Panel4.TabIndex = 0
    '
    'Lablogininfor
    '
    Me.Lablogininfor.AutoSize = True
    Me.Lablogininfor.BackColor = System.Drawing.Color.Transparent
    Me.Lablogininfor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Lablogininfor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.Lablogininfor.Location = New System.Drawing.Point(40, 13)
    Me.Lablogininfor.Name = "Lablogininfor"
    Me.Lablogininfor.Size = New System.Drawing.Size(192, 16)
    Me.Lablogininfor.TabIndex = 2
    Me.Lablogininfor.Text = "系統已成功登陸! 登陸時間"
    Me.Lablogininfor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Panel13
    '
    Me.Panel13.BackColor = System.Drawing.Color.Transparent
    Me.Panel13.BackgroundImage = CType(resources.GetObject("Panel13.BackgroundImage"), System.Drawing.Image)
    Me.Panel13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
    Me.Panel13.Location = New System.Drawing.Point(0, 0)
    Me.Panel13.Name = "Panel13"
    Me.Panel13.Size = New System.Drawing.Size(431, 48)
    Me.Panel13.TabIndex = 0
    '
    'PictureBox5
    '
    Me.PictureBox5.Dock = System.Windows.Forms.DockStyle.Left
    Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
    Me.PictureBox5.Location = New System.Drawing.Point(0, 0)
    Me.PictureBox5.Name = "PictureBox5"
    Me.PictureBox5.Size = New System.Drawing.Size(3, 503)
    Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.PictureBox5.TabIndex = 0
    Me.PictureBox5.TabStop = False
    '
    'StatusStrip1
    '
    Me.StatusStrip1.BackgroundImage = CType(resources.GetObject("StatusStrip1.BackgroundImage"), System.Drawing.Image)
    Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSSLgs, Me.TSSlgs1, Me.Labeljt, Me.Label19})
    Me.StatusStrip1.Location = New System.Drawing.Point(0, 503)
    Me.StatusStrip1.Name = "StatusStrip1"
    Me.StatusStrip1.Size = New System.Drawing.Size(922, 22)
    Me.StatusStrip1.TabIndex = 17
    Me.StatusStrip1.Text = "StatusStrip1"
    '
    'TSSLgs
    '
    Me.TSSLgs.BackColor = System.Drawing.Color.Transparent
    Me.TSSLgs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TSSLgs.ForeColor = System.Drawing.SystemColors.ButtonHighlight
    Me.TSSLgs.Name = "TSSLgs"
    Me.TSSLgs.Size = New System.Drawing.Size(361, 17)
    Me.TSSLgs.Text = "(C) 2017 深圳市永卓欣科技有限公司 0755-88841678       版本號："
    Me.TSSLgs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TSSlgs1
    '
    Me.TSSlgs1.BackColor = System.Drawing.Color.Transparent
    Me.TSSlgs1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
    Me.TSSlgs1.Name = "TSSlgs1"
    Me.TSSlgs1.Size = New System.Drawing.Size(0, 17)
    '
    'Labeljt
    '
    Me.Labeljt.BackColor = System.Drawing.Color.Transparent
    Me.Labeljt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Labeljt.ForeColor = System.Drawing.SystemColors.ButtonHighlight
    Me.Labeljt.Name = "Labeljt"
    Me.Labeljt.Size = New System.Drawing.Size(0, 17)
    '
    'Label19
    '
    Me.Label19.BackColor = System.Drawing.Color.Transparent
    Me.Label19.Font = New System.Drawing.Font("Microsoft JhengHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label19.ForeColor = System.Drawing.SystemColors.ButtonHighlight
    Me.Label19.Margin = New System.Windows.Forms.Padding(0, 3, 5, 2)
    Me.Label19.MergeAction = System.Windows.Forms.MergeAction.Remove
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(541, 17)
    Me.Label19.Spring = True
    Me.Label19.Text = "   32262"
    Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.Label19.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
    '
    'FrmMain
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.BackColor = System.Drawing.Color.WhiteSmoke
    Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
    Me.ClientSize = New System.Drawing.Size(922, 525)
    Me.Controls.Add(Me.TabControl1)
    Me.Controls.Add(Me.PictureBox5)
    Me.Controls.Add(Me.StatusStrip1)
    Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.IsMdiContainer = True
    Me.Name = "FrmMain"
    Me.Text = "fastech生產即時管控系統"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    Me.TabControl1.ResumeLayout(False)
    Me.TabPage1.ResumeLayout(False)
    Me.Panel1.ResumeLayout(False)
    Me.Panel3.ResumeLayout(False)
    Me.Panel4.ResumeLayout(False)
    Me.Panel4.PerformLayout()
    CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
    Me.StatusStrip1.ResumeLayout(False)
    Me.StatusStrip1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
  Friend WithEvents Timer1 As System.Windows.Forms.Timer
  Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents TSSLgs As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Labeljt As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label19 As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents FrmBd As System.Windows.Forms.Label
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
  Friend WithEvents Panel2 As System.Windows.Forms.Panel
  Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Lablogininfor As System.Windows.Forms.Label
  Friend WithEvents Panel13 As System.Windows.Forms.Panel
  Friend WithEvents Panel3 As System.Windows.Forms.Panel
  Friend WithEvents Panel4 As System.Windows.Forms.Panel
  Friend WithEvents TSSlgs1 As System.Windows.Forms.ToolStripStatusLabel


End Class
