<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLabEdit
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLabEdit))
    Me.PB2 = New System.Windows.Forms.PictureBox()
    Me.PB1 = New System.Windows.Forms.PictureBox()
    Me.PL = New System.Windows.Forms.Panel()
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.FNDATA = New FDGV.FDataGridView()
    Me.Panel4 = New System.Windows.Forms.Panel()
    Me.Button4 = New System.Windows.Forms.Button()
    Me.Button3 = New System.Windows.Forms.Button()
    Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
    Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
    Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
    Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
    Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
    Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
    Me.ToolStripButton9 = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
    Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
    Me.TSCB1 = New System.Windows.Forms.ToolStripComboBox()
    Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
    Me.TSSB1 = New System.Windows.Forms.ToolStripDropDownButton()
    Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
    Me.EXITS = New System.Windows.Forms.ToolStripButton()
    Me.DGV = New FDGV.FDataGridView()
    Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
    Me.msg = New System.Windows.Forms.ListBox()
    Me.Panel2 = New System.Windows.Forms.Panel()
    Me.LName = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.ComboBox2 = New System.Windows.Forms.ComboBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.LDesc = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.ComboBox1 = New System.Windows.Forms.ComboBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.CB1 = New System.Windows.Forms.ComboBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.FD = New System.Windows.Forms.FontDialog()
    Me.OFD = New System.Windows.Forms.OpenFileDialog()
    Me.Panel3 = New System.Windows.Forms.Panel()
    Me.TEV = New System.Windows.Forms.TextBox()
    CType(Me.PB2, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.PB1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.PL.SuspendLayout()
    Me.Panel1.SuspendLayout()
    CType(Me.FNDATA, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Panel4.SuspendLayout()
    Me.ToolStrip1.SuspendLayout()
    CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.TableLayoutPanel1.SuspendLayout()
    Me.Panel2.SuspendLayout()
    Me.Panel3.SuspendLayout()
    Me.SuspendLayout()
    '
    'PB2
    '
    Me.PB2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.PB2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.PB2.Location = New System.Drawing.Point(0, 30)
    Me.PB2.Margin = New System.Windows.Forms.Padding(0)
    Me.PB2.Name = "PB2"
    Me.PB2.Size = New System.Drawing.Size(30, 581)
    Me.PB2.TabIndex = 2
    Me.PB2.TabStop = False
    '
    'PB1
    '
    Me.PB1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.PB1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.PB1.Location = New System.Drawing.Point(30, 0)
    Me.PB1.Margin = New System.Windows.Forms.Padding(0)
    Me.PB1.Name = "PB1"
    Me.PB1.Size = New System.Drawing.Size(666, 30)
    Me.PB1.TabIndex = 1
    Me.PB1.TabStop = False
    '
    'PL
    '
    Me.PL.AutoScroll = True
    Me.PL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.PL.Controls.Add(Me.Panel1)
    Me.PL.Dock = System.Windows.Forms.DockStyle.Fill
    Me.PL.Location = New System.Drawing.Point(30, 30)
    Me.PL.Margin = New System.Windows.Forms.Padding(0)
    Me.PL.Name = "PL"
    Me.PL.Size = New System.Drawing.Size(666, 581)
    Me.PL.TabIndex = 0
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.FNDATA)
    Me.Panel1.Controls.Add(Me.Panel4)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Panel1.Font = New System.Drawing.Font("細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(664, 579)
    Me.Panel1.TabIndex = 0
    Me.Panel1.Visible = False
    '
    'FNDATA
    '
    Me.FNDATA.AllowUserToAddRows = False
    Me.FNDATA.AllowUserToDeleteRows = False
    Me.FNDATA.AllowUserToResizeRows = False
    Me.FNDATA.Append = False
    Me.FNDATA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.FNDATA.Dock = System.Windows.Forms.DockStyle.Fill
    Me.FNDATA.Location = New System.Drawing.Point(0, 42)
    Me.FNDATA.Name = "FNDATA"
    Me.FNDATA.ReadOnly = True
    Me.FNDATA.RowTemplate.Height = 24
    Me.FNDATA.RowWise = False
    Me.FNDATA.SaveSetting = ""
    Me.FNDATA.Size = New System.Drawing.Size(664, 537)
    Me.FNDATA.TabIndex = 1
    '
    'Panel4
    '
    Me.Panel4.Controls.Add(Me.Button4)
    Me.Panel4.Controls.Add(Me.Button3)
    Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel4.Font = New System.Drawing.Font("細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Panel4.Location = New System.Drawing.Point(0, 0)
    Me.Panel4.Name = "Panel4"
    Me.Panel4.Size = New System.Drawing.Size(664, 42)
    Me.Panel4.TabIndex = 0
    '
    'Button4
    '
    Me.Button4.Location = New System.Drawing.Point(117, 5)
    Me.Button4.Name = "Button4"
    Me.Button4.Size = New System.Drawing.Size(94, 32)
    Me.Button4.TabIndex = 22
    Me.Button4.Text = "取消"
    Me.Button4.UseVisualStyleBackColor = True
    '
    'Button3
    '
    Me.Button3.Location = New System.Drawing.Point(18, 5)
    Me.Button3.Name = "Button3"
    Me.Button3.Size = New System.Drawing.Size(94, 32)
    Me.Button3.TabIndex = 21
    Me.Button3.Text = "開啟"
    Me.Button3.UseVisualStyleBackColor = True
    '
    'ToolStrip1
    '
    Me.ToolStrip1.Font = New System.Drawing.Font("細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripSeparator1, Me.ToolStripButton7, Me.ToolStripSeparator3, Me.ToolStripButton2, Me.ToolStripSeparator9, Me.ToolStripButton8, Me.ToolStripSeparator4, Me.ToolStripButton4, Me.ToolStripSeparator8, Me.ToolStripButton9, Me.ToolStripSeparator6, Me.ToolStripButton3, Me.ToolStripSeparator2, Me.TSCB1, Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripSeparator5, Me.TSSB1, Me.ToolStripSeparator7, Me.EXITS})
    Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
    Me.ToolStrip1.Name = "ToolStrip1"
    Me.ToolStrip1.Size = New System.Drawing.Size(992, 25)
    Me.ToolStrip1.TabIndex = 2
    Me.ToolStrip1.Text = "ToolStrip1"
    '
    'ToolStripButton1
    '
    Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
    Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
    Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton1.Name = "ToolStripButton1"
    Me.ToolStripButton1.Size = New System.Drawing.Size(63, 22)
    Me.ToolStripButton1.Text = "新格式"
    '
    'ToolStripSeparator1
    '
    Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
    Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
    '
    'ToolStripButton7
    '
    Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
    Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
    Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton7.Name = "ToolStripButton7"
    Me.ToolStripButton7.Size = New System.Drawing.Size(80, 22)
    Me.ToolStripButton7.Text = "儲存格式"
    '
    'ToolStripSeparator3
    '
    Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
    Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
    '
    'ToolStripButton2
    '
    Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
    Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
    Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton2.Name = "ToolStripButton2"
    Me.ToolStripButton2.Size = New System.Drawing.Size(80, 22)
    Me.ToolStripButton2.Text = "刪除格式"
    '
    'ToolStripSeparator9
    '
    Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
    Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
    '
    'ToolStripButton8
    '
    Me.ToolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
    Me.ToolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton8.Name = "ToolStripButton8"
    Me.ToolStripButton8.Size = New System.Drawing.Size(80, 22)
    Me.ToolStripButton8.Text = "測試打印"
    '
    'ToolStripSeparator4
    '
    Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
    Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
    '
    'ToolStripButton4
    '
    Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
    Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
    Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton4.Name = "ToolStripButton4"
    Me.ToolStripButton4.Size = New System.Drawing.Size(97, 22)
    Me.ToolStripButton4.Text = "開啟文字檔"
    '
    'ToolStripSeparator8
    '
    Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
    Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
    '
    'ToolStripButton9
    '
    Me.ToolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
    Me.ToolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton9.Name = "ToolStripButton9"
    Me.ToolStripButton9.Size = New System.Drawing.Size(97, 22)
    Me.ToolStripButton9.Text = "另存文字檔"
    '
    'ToolStripSeparator6
    '
    Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
    Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
    '
    'ToolStripButton3
    '
    Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
    Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
    Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton3.Name = "ToolStripButton3"
    Me.ToolStripButton3.Size = New System.Drawing.Size(80, 22)
    Me.ToolStripButton3.Text = "紙張設定"
    Me.ToolStripButton3.ToolTipText = "紙張設定"
    '
    'ToolStripSeparator2
    '
    Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
    Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
    '
    'TSCB1
    '
    Me.TSCB1.Items.AddRange(New Object() {"200%", "150%", "100%", "75%", "50%"})
    Me.TSCB1.Name = "TSCB1"
    Me.TSCB1.Size = New System.Drawing.Size(75, 25)
    '
    'ToolStripButton5
    '
    Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
    Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
    Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton5.Name = "ToolStripButton5"
    Me.ToolStripButton5.Size = New System.Drawing.Size(46, 22)
    Me.ToolStripButton5.Text = "放大"
    '
    'ToolStripButton6
    '
    Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
    Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
    Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton6.Name = "ToolStripButton6"
    Me.ToolStripButton6.Size = New System.Drawing.Size(46, 22)
    Me.ToolStripButton6.Text = "縮小"
    '
    'ToolStripSeparator5
    '
    Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
    Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
    '
    'TSSB1
    '
    Me.TSSB1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
    Me.TSSB1.Image = CType(resources.GetObject("TSSB1.Image"), System.Drawing.Image)
    Me.TSSB1.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.TSSB1.Name = "TSSB1"
    Me.TSSB1.Size = New System.Drawing.Size(89, 22)
    Me.TSSB1.Text = "元件列表"
    '
    'ToolStripSeparator7
    '
    Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
    Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
    '
    'EXITS
    '
    Me.EXITS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
    Me.EXITS.Image = CType(resources.GetObject("EXITS.Image"), System.Drawing.Image)
    Me.EXITS.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.EXITS.Name = "EXITS"
    Me.EXITS.Size = New System.Drawing.Size(46, 22)
    Me.EXITS.Text = "離開"
    Me.EXITS.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
    '
    'DGV
    '
    Me.DGV.AllowUserToAddRows = False
    Me.DGV.AllowUserToDeleteRows = False
    Me.DGV.AllowUserToResizeRows = False
    Me.DGV.Append = False
    Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DGV.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DGV.Location = New System.Drawing.Point(0, 159)
    Me.DGV.Name = "DGV"
    Me.DGV.RowTemplate.Height = 24
    Me.DGV.RowWise = False
    Me.DGV.SaveSetting = ""
    Me.DGV.Size = New System.Drawing.Size(296, 512)
    Me.DGV.TabIndex = 0
    '
    'TableLayoutPanel1
    '
    Me.TableLayoutPanel1.ColumnCount = 2
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanel1.Controls.Add(Me.PB2, 0, 1)
    Me.TableLayoutPanel1.Controls.Add(Me.PB1, 1, 0)
    Me.TableLayoutPanel1.Controls.Add(Me.PL, 1, 1)
    Me.TableLayoutPanel1.Controls.Add(Me.msg, 1, 2)
    Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(296, 25)
    Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 3
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(696, 671)
    Me.TableLayoutPanel1.TabIndex = 5
    '
    'msg
    '
    Me.msg.Dock = System.Windows.Forms.DockStyle.Fill
    Me.msg.Font = New System.Drawing.Font("細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.msg.ForeColor = System.Drawing.Color.Red
    Me.msg.FormattingEnabled = True
    Me.msg.ItemHeight = 16
    Me.msg.Location = New System.Drawing.Point(33, 614)
    Me.msg.Name = "msg"
    Me.msg.Size = New System.Drawing.Size(660, 54)
    Me.msg.TabIndex = 3
    '
    'Panel2
    '
    Me.Panel2.Controls.Add(Me.LName)
    Me.Panel2.Controls.Add(Me.Label5)
    Me.Panel2.Controls.Add(Me.Button2)
    Me.Panel2.Controls.Add(Me.ComboBox2)
    Me.Panel2.Controls.Add(Me.Label3)
    Me.Panel2.Controls.Add(Me.LDesc)
    Me.Panel2.Controls.Add(Me.Label2)
    Me.Panel2.Controls.Add(Me.Button1)
    Me.Panel2.Controls.Add(Me.ComboBox1)
    Me.Panel2.Controls.Add(Me.Label4)
    Me.Panel2.Controls.Add(Me.CB1)
    Me.Panel2.Controls.Add(Me.Label1)
    Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel2.Font = New System.Drawing.Font("細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Panel2.Location = New System.Drawing.Point(0, 0)
    Me.Panel2.Name = "Panel2"
    Me.Panel2.Size = New System.Drawing.Size(296, 159)
    Me.Panel2.TabIndex = 2
    '
    'LName
    '
    Me.LName.Location = New System.Drawing.Point(96, 64)
    Me.LName.Name = "LName"
    Me.LName.Size = New System.Drawing.Size(197, 27)
    Me.LName.TabIndex = 27
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(35, 69)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(59, 16)
    Me.Label5.TabIndex = 26
    Me.Label5.Text = "名稱："
    '
    'Button2
    '
    Me.Button2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Button2.Location = New System.Drawing.Point(260, 3)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(31, 24)
    Me.Button2.TabIndex = 25
    Me.Button2.Text = "..."
    Me.Button2.UseVisualStyleBackColor = True
    '
    'ComboBox2
    '
    Me.ComboBox2.FormattingEnabled = True
    Me.ComboBox2.Location = New System.Drawing.Point(96, 3)
    Me.ComboBox2.Name = "ComboBox2"
    Me.ComboBox2.Size = New System.Drawing.Size(158, 24)
    Me.ComboBox2.TabIndex = 24
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(35, 7)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(59, 16)
    Me.Label3.TabIndex = 23
    Me.Label3.Text = "類別："
    '
    'LDesc
    '
    Me.LDesc.Location = New System.Drawing.Point(96, 95)
    Me.LDesc.Name = "LDesc"
    Me.LDesc.Size = New System.Drawing.Size(197, 27)
    Me.LDesc.TabIndex = 22
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(35, 100)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(59, 16)
    Me.Label2.TabIndex = 21
    Me.Label2.Text = "說明："
    '
    'Button1
    '
    Me.Button1.Enabled = False
    Me.Button1.Location = New System.Drawing.Point(231, 127)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(62, 24)
    Me.Button1.TabIndex = 20
    Me.Button1.Text = "新增"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'ComboBox1
    '
    Me.ComboBox1.FormattingEnabled = True
    Me.ComboBox1.Location = New System.Drawing.Point(96, 34)
    Me.ComboBox1.Name = "ComboBox1"
    Me.ComboBox1.Size = New System.Drawing.Size(197, 24)
    Me.ComboBox1.TabIndex = 19
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(18, 38)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(76, 16)
    Me.Label4.TabIndex = 9
    Me.Label4.Text = "格式名："
    '
    'CB1
    '
    Me.CB1.FormattingEnabled = True
    Me.CB1.Location = New System.Drawing.Point(96, 127)
    Me.CB1.Name = "CB1"
    Me.CB1.Size = New System.Drawing.Size(129, 24)
    Me.CB1.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(1, 131)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(93, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "選擇元件："
    '
    'FD
    '
    Me.FD.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '
    'OFD
    '
    Me.OFD.FileName = "OpenFileDialog1"
    '
    'Panel3
    '
    Me.Panel3.Controls.Add(Me.TEV)
    Me.Panel3.Controls.Add(Me.DGV)
    Me.Panel3.Controls.Add(Me.Panel2)
    Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
    Me.Panel3.Font = New System.Drawing.Font("細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Panel3.Location = New System.Drawing.Point(0, 25)
    Me.Panel3.Name = "Panel3"
    Me.Panel3.Size = New System.Drawing.Size(296, 671)
    Me.Panel3.TabIndex = 7
    '
    'TEV
    '
    Me.TEV.Location = New System.Drawing.Point(3, 333)
    Me.TEV.Multiline = True
    Me.TEV.Name = "TEV"
    Me.TEV.ScrollBars = System.Windows.Forms.ScrollBars.Both
    Me.TEV.Size = New System.Drawing.Size(566, 93)
    Me.TEV.TabIndex = 3
    Me.TEV.Visible = False
    '
    'FrmLabEdit
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.BackColor = System.Drawing.SystemColors.Control
    Me.ClientSize = New System.Drawing.Size(992, 696)
    Me.Controls.Add(Me.TableLayoutPanel1)
    Me.Controls.Add(Me.Panel3)
    Me.Controls.Add(Me.ToolStrip1)
    Me.Name = "FrmLabEdit"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "標籤設計預覽列印"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    CType(Me.PB2, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PB1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.PL.ResumeLayout(False)
    Me.Panel1.ResumeLayout(False)
    CType(Me.FNDATA, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Panel4.ResumeLayout(False)
    Me.ToolStrip1.ResumeLayout(False)
    Me.ToolStrip1.PerformLayout()
    CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
    Me.TableLayoutPanel1.ResumeLayout(False)
    Me.Panel2.ResumeLayout(False)
    Me.Panel2.PerformLayout()
    Me.Panel3.ResumeLayout(False)
    Me.Panel3.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents PB2 As System.Windows.Forms.PictureBox
  Friend WithEvents PB1 As System.Windows.Forms.PictureBox
  Friend WithEvents PL As System.Windows.Forms.Panel
  Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
  Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
  Friend WithEvents DGV As FDGV.FDataGridView
  Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents TSCB1 As System.Windows.Forms.ToolStripComboBox
  Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
  Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
  Friend WithEvents FD As System.Windows.Forms.FontDialog
  Friend WithEvents CB1 As System.Windows.Forms.ComboBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents OFD As System.Windows.Forms.OpenFileDialog
  Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents TSSB1 As System.Windows.Forms.ToolStripDropDownButton
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
  Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents msg As System.Windows.Forms.ListBox
  Friend WithEvents ToolStripButton9 As System.Windows.Forms.ToolStripButton
  Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents Panel2 As System.Windows.Forms.Panel
  Friend WithEvents Panel3 As System.Windows.Forms.Panel
  Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
  Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
  Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
  Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents EXITS As System.Windows.Forms.ToolStripButton
  Friend WithEvents LDesc As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents FNDATA As FDGV.FDataGridView
  Friend WithEvents Panel4 As System.Windows.Forms.Panel
  Friend WithEvents Button4 As System.Windows.Forms.Button
  Friend WithEvents Button3 As System.Windows.Forms.Button
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
  Friend WithEvents LName As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents TEV As System.Windows.Forms.TextBox

End Class
