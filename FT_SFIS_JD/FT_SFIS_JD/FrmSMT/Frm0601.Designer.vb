<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm0601
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
    Me.TP = New System.Windows.Forms.TableLayoutPanel()
    Me.DG = New System.Windows.Forms.DataGridView()
    Me.gp_FeederData = New System.Windows.Forms.GroupBox()
    Me.gp_FeederState = New System.Windows.Forms.GroupBox()
    Me.txt_sb10 = New System.Windows.Forms.TextBox()
    Me.txt_sb18 = New System.Windows.Forms.TextBox()
    Me.txt_sb21 = New System.Windows.Forms.TextBox()
    Me.txt_sb20 = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.txt_sb19 = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.txt_sb15 = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.txt_sb17 = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.txt_sb16 = New System.Windows.Forms.TextBox()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.DIV = New System.Windows.Forms.TextBox()
    Me.txt_sb1 = New System.Windows.Forms.TextBox()
    Me.Label19 = New System.Windows.Forms.Label()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.txt_sb22 = New System.Windows.Forms.TextBox()
    Me.txt_sb23 = New System.Windows.Forms.TextBox()
    Me.cb_sb9 = New System.Windows.Forms.ComboBox()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.MSGID = New System.Windows.Forms.Label()
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.btn_insert = New System.Windows.Forms.Button()
    Me.btn_Save = New System.Windows.Forms.Button()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.dt_sb11 = New System.Windows.Forms.DateTimePicker()
    Me.dt_sb12 = New System.Windows.Forms.DateTimePicker()
    Me.gp_Search = New System.Windows.Forms.GroupBox()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.CheckBox2 = New System.Windows.Forms.CheckBox()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.TextBox2 = New System.Windows.Forms.TextBox()
    Me.CheckBox1 = New System.Windows.Forms.CheckBox()
    Me.cb_shSb09 = New System.Windows.Forms.ComboBox()
    Me.dt_shDate = New System.Windows.Forms.DateTimePicker()
    Me.btn_SearchFD = New System.Windows.Forms.Button()
    Me.SFD = New System.Windows.Forms.SaveFileDialog()
    Me.TP.SuspendLayout()
    CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.gp_FeederData.SuspendLayout()
    Me.gp_FeederState.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.Panel1.SuspendLayout()
    Me.gp_Search.SuspendLayout()
    Me.SuspendLayout()
    '
    'TP
    '
    Me.TP.ColumnCount = 1
    Me.TP.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TP.Controls.Add(Me.DG, 0, 1)
    Me.TP.Controls.Add(Me.gp_FeederData, 0, 0)
    Me.TP.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TP.Location = New System.Drawing.Point(0, 0)
    Me.TP.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.TP.Name = "TP"
    Me.TP.RowCount = 2
    Me.TP.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 295.0!))
    Me.TP.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TP.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    Me.TP.Size = New System.Drawing.Size(1087, 733)
    Me.TP.TabIndex = 0
    '
    'DG
    '
    Me.DG.AllowUserToAddRows = False
    Me.DG.AllowUserToDeleteRows = False
    Me.DG.AllowUserToResizeColumns = False
    Me.DG.AllowUserToResizeRows = False
    Me.DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
    Me.DG.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DG.Location = New System.Drawing.Point(3, 297)
    Me.DG.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.DG.Name = "DG"
    Me.DG.ReadOnly = True
    Me.DG.RowTemplate.Height = 24
    Me.DG.Size = New System.Drawing.Size(1081, 434)
    Me.DG.TabIndex = 25
    '
    'gp_FeederData
    '
    Me.gp_FeederData.BackColor = System.Drawing.SystemColors.Control
    Me.gp_FeederData.Controls.Add(Me.gp_FeederState)
    Me.gp_FeederData.Controls.Add(Me.GroupBox1)
    Me.gp_FeederData.Controls.Add(Me.gp_Search)
    Me.gp_FeederData.Dock = System.Windows.Forms.DockStyle.Fill
    Me.gp_FeederData.Location = New System.Drawing.Point(3, 2)
    Me.gp_FeederData.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.gp_FeederData.Name = "gp_FeederData"
    Me.gp_FeederData.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.gp_FeederData.Size = New System.Drawing.Size(1081, 291)
    Me.gp_FeederData.TabIndex = 24
    Me.gp_FeederData.TabStop = False
    '
    'gp_FeederState
    '
    Me.gp_FeederState.BackColor = System.Drawing.SystemColors.Control
    Me.gp_FeederState.Controls.Add(Me.txt_sb10)
    Me.gp_FeederState.Controls.Add(Me.txt_sb18)
    Me.gp_FeederState.Controls.Add(Me.txt_sb21)
    Me.gp_FeederState.Controls.Add(Me.txt_sb20)
    Me.gp_FeederState.Controls.Add(Me.Label9)
    Me.gp_FeederState.Controls.Add(Me.txt_sb19)
    Me.gp_FeederState.Controls.Add(Me.Label7)
    Me.gp_FeederState.Controls.Add(Me.txt_sb15)
    Me.gp_FeederState.Controls.Add(Me.Label10)
    Me.gp_FeederState.Controls.Add(Me.Label8)
    Me.gp_FeederState.Controls.Add(Me.Label11)
    Me.gp_FeederState.Controls.Add(Me.txt_sb17)
    Me.gp_FeederState.Controls.Add(Me.Label12)
    Me.gp_FeederState.Controls.Add(Me.txt_sb16)
    Me.gp_FeederState.Controls.Add(Me.Label13)
    Me.gp_FeederState.Controls.Add(Me.Label17)
    Me.gp_FeederState.Location = New System.Drawing.Point(741, 16)
    Me.gp_FeederState.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.gp_FeederState.Name = "gp_FeederState"
    Me.gp_FeederState.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.gp_FeederState.Size = New System.Drawing.Size(334, 270)
    Me.gp_FeederState.TabIndex = 60
    Me.gp_FeederState.TabStop = False
    Me.gp_FeederState.Text = "FEEDER狀態"
    '
    'txt_sb10
    '
    Me.txt_sb10.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.txt_sb10.Enabled = False
    Me.txt_sb10.Location = New System.Drawing.Point(160, 50)
    Me.txt_sb10.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
    Me.txt_sb10.Name = "txt_sb10"
    Me.txt_sb10.Size = New System.Drawing.Size(168, 26)
    Me.txt_sb10.TabIndex = 65
    Me.txt_sb10.TabStop = False
    '
    'txt_sb18
    '
    Me.txt_sb18.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.txt_sb18.Enabled = False
    Me.txt_sb18.Location = New System.Drawing.Point(160, 19)
    Me.txt_sb18.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
    Me.txt_sb18.Name = "txt_sb18"
    Me.txt_sb18.Size = New System.Drawing.Size(168, 26)
    Me.txt_sb18.TabIndex = 64
    Me.txt_sb18.TabStop = False
    '
    'txt_sb21
    '
    Me.txt_sb21.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.txt_sb21.Enabled = False
    Me.txt_sb21.Location = New System.Drawing.Point(160, 236)
    Me.txt_sb21.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
    Me.txt_sb21.Name = "txt_sb21"
    Me.txt_sb21.Size = New System.Drawing.Size(168, 26)
    Me.txt_sb21.TabIndex = 63
    Me.txt_sb21.TabStop = False
    '
    'txt_sb20
    '
    Me.txt_sb20.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.txt_sb20.Enabled = False
    Me.txt_sb20.Location = New System.Drawing.Point(160, 205)
    Me.txt_sb20.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
    Me.txt_sb20.Name = "txt_sb20"
    Me.txt_sb20.Size = New System.Drawing.Size(168, 26)
    Me.txt_sb20.TabIndex = 62
    Me.txt_sb20.TabStop = False
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(19, 24)
    Me.Label9.Margin = New System.Windows.Forms.Padding(0, 11, 0, 0)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(144, 16)
    Me.Label9.TabIndex = 52
    Me.Label9.Text = "第一次使用日期："
    '
    'txt_sb19
    '
    Me.txt_sb19.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.txt_sb19.Enabled = False
    Me.txt_sb19.Location = New System.Drawing.Point(160, 174)
    Me.txt_sb19.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
    Me.txt_sb19.Name = "txt_sb19"
    Me.txt_sb19.Size = New System.Drawing.Size(168, 26)
    Me.txt_sb19.TabIndex = 61
    Me.txt_sb19.TabStop = False
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(53, 86)
    Me.Label7.Margin = New System.Windows.Forms.Padding(27, 11, 0, 0)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(110, 16)
    Me.Label7.TabIndex = 54
    Me.Label7.Text = "總上料次數："
    '
    'txt_sb15
    '
    Me.txt_sb15.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.txt_sb15.Enabled = False
    Me.txt_sb15.Location = New System.Drawing.Point(160, 143)
    Me.txt_sb15.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.txt_sb15.Name = "txt_sb15"
    Me.txt_sb15.Size = New System.Drawing.Size(168, 26)
    Me.txt_sb15.TabIndex = 60
    Me.txt_sb15.TabStop = False
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Location = New System.Drawing.Point(19, 241)
    Me.Label10.Margin = New System.Windows.Forms.Padding(3, 11, 3, 0)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(144, 16)
    Me.Label10.TabIndex = 53
    Me.Label10.Text = "最后一次維修者："
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(53, 117)
    Me.Label8.Margin = New System.Windows.Forms.Padding(27, 11, 0, 0)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(110, 16)
    Me.Label8.TabIndex = 50
    Me.Label8.Text = "總保養次數："
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(36, 55)
    Me.Label11.Margin = New System.Windows.Forms.Padding(17, 11, 3, 0)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(127, 16)
    Me.Label11.TabIndex = 48
    Me.Label11.Text = "上次保養日期："
    '
    'txt_sb17
    '
    Me.txt_sb17.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.txt_sb17.Enabled = False
    Me.txt_sb17.Location = New System.Drawing.Point(160, 112)
    Me.txt_sb17.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.txt_sb17.Name = "txt_sb17"
    Me.txt_sb17.Size = New System.Drawing.Size(168, 26)
    Me.txt_sb17.TabIndex = 58
    Me.txt_sb17.TabStop = False
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.Location = New System.Drawing.Point(53, 148)
    Me.Label12.Margin = New System.Windows.Forms.Padding(27, 11, 0, 0)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(110, 16)
    Me.Label12.TabIndex = 49
    Me.Label12.Text = "總維修次數："
    '
    'txt_sb16
    '
    Me.txt_sb16.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.txt_sb16.Enabled = False
    Me.txt_sb16.Location = New System.Drawing.Point(160, 81)
    Me.txt_sb16.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.txt_sb16.Name = "txt_sb16"
    Me.txt_sb16.Size = New System.Drawing.Size(168, 26)
    Me.txt_sb16.TabIndex = 59
    Me.txt_sb16.TabStop = False
    '
    'Label13
    '
    Me.Label13.AutoSize = True
    Me.Label13.Location = New System.Drawing.Point(19, 179)
    Me.Label13.Margin = New System.Windows.Forms.Padding(3, 11, 3, 0)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(144, 16)
    Me.Label13.TabIndex = 51
    Me.Label13.Text = "最后一次保養者："
    '
    'Label17
    '
    Me.Label17.AutoSize = True
    Me.Label17.Location = New System.Drawing.Point(19, 210)
    Me.Label17.Margin = New System.Windows.Forms.Padding(3, 11, 3, 0)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(144, 16)
    Me.Label17.TabIndex = 55
    Me.Label17.Text = "最后一次使用者："
    '
    'GroupBox1
    '
    Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
    Me.GroupBox1.Controls.Add(Me.DIV)
    Me.GroupBox1.Controls.Add(Me.txt_sb1)
    Me.GroupBox1.Controls.Add(Me.Label19)
    Me.GroupBox1.Controls.Add(Me.TextBox1)
    Me.GroupBox1.Controls.Add(Me.txt_sb22)
    Me.GroupBox1.Controls.Add(Me.txt_sb23)
    Me.GroupBox1.Controls.Add(Me.cb_sb9)
    Me.GroupBox1.Controls.Add(Me.Label14)
    Me.GroupBox1.Controls.Add(Me.MSGID)
    Me.GroupBox1.Controls.Add(Me.Panel1)
    Me.GroupBox1.Controls.Add(Me.Label6)
    Me.GroupBox1.Controls.Add(Me.Label4)
    Me.GroupBox1.Controls.Add(Me.Label3)
    Me.GroupBox1.Controls.Add(Me.Label2)
    Me.GroupBox1.Controls.Add(Me.Label5)
    Me.GroupBox1.Controls.Add(Me.Label1)
    Me.GroupBox1.Controls.Add(Me.dt_sb11)
    Me.GroupBox1.Controls.Add(Me.dt_sb12)
    Me.GroupBox1.Location = New System.Drawing.Point(328, 18)
    Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.GroupBox1.Size = New System.Drawing.Size(407, 270)
    Me.GroupBox1.TabIndex = 59
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "基本資料"
    '
    'DIV
    '
    Me.DIV.BackColor = System.Drawing.Color.LightCyan
    Me.DIV.ImeMode = System.Windows.Forms.ImeMode.Disable
    Me.DIV.Location = New System.Drawing.Point(296, 23)
    Me.DIV.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
    Me.DIV.Name = "DIV"
    Me.DIV.Size = New System.Drawing.Size(21, 26)
    Me.DIV.TabIndex = 69
    Me.DIV.TabStop = False
    '
    'txt_sb1
    '
    Me.txt_sb1.BackColor = System.Drawing.Color.LightCyan
    Me.txt_sb1.ImeMode = System.Windows.Forms.ImeMode.Disable
    Me.txt_sb1.Location = New System.Drawing.Point(143, 23)
    Me.txt_sb1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
    Me.txt_sb1.Name = "txt_sb1"
    Me.txt_sb1.Size = New System.Drawing.Size(136, 26)
    Me.txt_sb1.TabIndex = 0
    '
    'Label19
    '
    Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.Label19.AutoSize = True
    Me.Label19.Location = New System.Drawing.Point(281, 28)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(17, 16)
    Me.Label19.TabIndex = 70
    Me.Label19.Text = "X"
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(143, 143)
    Me.TextBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(47, 26)
    Me.TextBox1.TabIndex = 4
    '
    'txt_sb22
    '
    Me.txt_sb22.BackColor = System.Drawing.Color.White
    Me.txt_sb22.Location = New System.Drawing.Point(143, 113)
    Me.txt_sb22.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
    Me.txt_sb22.Name = "txt_sb22"
    Me.txt_sb22.Size = New System.Drawing.Size(77, 26)
    Me.txt_sb22.TabIndex = 3
    '
    'txt_sb23
    '
    Me.txt_sb23.BackColor = System.Drawing.Color.White
    Me.txt_sb23.Location = New System.Drawing.Point(143, 83)
    Me.txt_sb23.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
    Me.txt_sb23.Name = "txt_sb23"
    Me.txt_sb23.Size = New System.Drawing.Size(77, 26)
    Me.txt_sb23.TabIndex = 2
    '
    'cb_sb9
    '
    Me.cb_sb9.Enabled = False
    Me.cb_sb9.FormattingEnabled = True
    Me.cb_sb9.Location = New System.Drawing.Point(143, 54)
    Me.cb_sb9.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
    Me.cb_sb9.Name = "cb_sb9"
    Me.cb_sb9.Size = New System.Drawing.Size(136, 24)
    Me.cb_sb9.TabIndex = 1
    Me.cb_sb9.Text = "0:良品空盤"
    '
    'Label14
    '
    Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.Label14.AutoSize = True
    Me.Label14.Location = New System.Drawing.Point(194, 148)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(25, 16)
    Me.Label14.TabIndex = 68
    Me.Label14.Text = "天"
    '
    'MSGID
    '
    Me.MSGID.BackColor = System.Drawing.SystemColors.Control
    Me.MSGID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.MSGID.ForeColor = System.Drawing.Color.Red
    Me.MSGID.Location = New System.Drawing.Point(323, 25)
    Me.MSGID.Name = "MSGID"
    Me.MSGID.Size = New System.Drawing.Size(83, 22)
    Me.MSGID.TabIndex = 66
    Me.MSGID.Text = "新增模式"
    Me.MSGID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.MSGID.Visible = False
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.btn_insert)
    Me.Panel1.Controls.Add(Me.btn_Save)
    Me.Panel1.Location = New System.Drawing.Point(14, 208)
    Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(189, 49)
    Me.Panel1.TabIndex = 65
    '
    'btn_insert
    '
    Me.btn_insert.Location = New System.Drawing.Point(4, 5)
    Me.btn_insert.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.btn_insert.Name = "btn_insert"
    Me.btn_insert.Size = New System.Drawing.Size(84, 38)
    Me.btn_insert.TabIndex = 53
    Me.btn_insert.TabStop = False
    Me.btn_insert.Text = "清空"
    Me.btn_insert.UseVisualStyleBackColor = True
    '
    'btn_Save
    '
    Me.btn_Save.Location = New System.Drawing.Point(94, 5)
    Me.btn_Save.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.btn_Save.Name = "btn_Save"
    Me.btn_Save.Size = New System.Drawing.Size(84, 38)
    Me.btn_Save.TabIndex = 56
    Me.btn_Save.TabStop = False
    Me.btn_Save.Text = "儲存"
    Me.btn_Save.UseVisualStyleBackColor = True
    '
    'Label6
    '
    Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(40, 28)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(106, 16)
    Me.Label6.TabIndex = 63
    Me.Label6.Text = "FEEDER ID："
    '
    'Label4
    '
    Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(36, 88)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(110, 16)
    Me.Label4.TabIndex = 62
    Me.Label4.Text = "總次數上限："
    '
    'Label3
    '
    Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(2, 118)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(144, 16)
    Me.Label3.TabIndex = 59
    Me.Label3.Text = "維修后次數上限："
    '
    'Label2
    '
    Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(36, 148)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(110, 16)
    Me.Label2.TabIndex = 61
    Me.Label2.Text = "保養逾期日："
    '
    'Label5
    '
    Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(19, 178)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(127, 16)
    Me.Label5.TabIndex = 64
    Me.Label5.Text = "下次保養日期："
    '
    'Label1
    '
    Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(87, 58)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(59, 16)
    Me.Label1.TabIndex = 60
    Me.Label1.Text = "狀態："
    '
    'dt_sb11
    '
    Me.dt_sb11.CustomFormat = "yyyy/MM/dd"
    Me.dt_sb11.Format = System.Windows.Forms.DateTimePickerFormat.Custom
    Me.dt_sb11.Location = New System.Drawing.Point(228, 173)
    Me.dt_sb11.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
    Me.dt_sb11.Name = "dt_sb11"
    Me.dt_sb11.Size = New System.Drawing.Size(120, 26)
    Me.dt_sb11.TabIndex = 6
    '
    'dt_sb12
    '
    Me.dt_sb12.CustomFormat = "yyyy/MM/dd"
    Me.dt_sb12.Format = System.Windows.Forms.DateTimePickerFormat.Custom
    Me.dt_sb12.Location = New System.Drawing.Point(228, 143)
    Me.dt_sb12.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
    Me.dt_sb12.Name = "dt_sb12"
    Me.dt_sb12.Size = New System.Drawing.Size(120, 26)
    Me.dt_sb12.TabIndex = 5
    '
    'gp_Search
    '
    Me.gp_Search.BackColor = System.Drawing.SystemColors.Control
    Me.gp_Search.Controls.Add(Me.Button2)
    Me.gp_Search.Controls.Add(Me.Label18)
    Me.gp_Search.Controls.Add(Me.Label16)
    Me.gp_Search.Controls.Add(Me.CheckBox2)
    Me.gp_Search.Controls.Add(Me.Label15)
    Me.gp_Search.Controls.Add(Me.TextBox2)
    Me.gp_Search.Controls.Add(Me.CheckBox1)
    Me.gp_Search.Controls.Add(Me.cb_shSb09)
    Me.gp_Search.Controls.Add(Me.dt_shDate)
    Me.gp_Search.Controls.Add(Me.btn_SearchFD)
    Me.gp_Search.Font = New System.Drawing.Font("黑体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.gp_Search.Location = New System.Drawing.Point(9, 18)
    Me.gp_Search.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.gp_Search.Name = "gp_Search"
    Me.gp_Search.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.gp_Search.Size = New System.Drawing.Size(313, 269)
    Me.gp_Search.TabIndex = 58
    Me.gp_Search.TabStop = False
    Me.gp_Search.Text = "查詢選單"
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(148, 26)
    Me.Button2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(112, 41)
    Me.Button2.TabIndex = 74
    Me.Button2.TabStop = False
    Me.Button2.Text = "離開"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'Label18
    '
    Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.Label18.AutoSize = True
    Me.Label18.Location = New System.Drawing.Point(261, 152)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(42, 16)
    Me.Label18.TabIndex = 72
    Me.Label18.Text = "以前"
    '
    'Label16
    '
    Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.Label16.AutoSize = True
    Me.Label16.Location = New System.Drawing.Point(10, 82)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(110, 16)
    Me.Label16.TabIndex = 71
    Me.Label16.Text = "顯示狀態類型"
    '
    'CheckBox2
    '
    Me.CheckBox2.AutoSize = True
    Me.CheckBox2.Location = New System.Drawing.Point(10, 150)
    Me.CheckBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.CheckBox2.Name = "CheckBox2"
    Me.CheckBox2.Size = New System.Drawing.Size(132, 20)
    Me.CheckBox2.TabIndex = 70
    Me.CheckBox2.TabStop = False
    Me.CheckBox2.Text = "FEEDER保養日"
    Me.CheckBox2.UseVisualStyleBackColor = True
    '
    'Label15
    '
    Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.Label15.AutoSize = True
    Me.Label15.Location = New System.Drawing.Point(277, 116)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(25, 16)
    Me.Label15.TabIndex = 69
    Me.Label15.Text = "天"
    '
    'TextBox2
    '
    Me.TextBox2.Location = New System.Drawing.Point(179, 111)
    Me.TextBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(75, 26)
    Me.TextBox2.TabIndex = 37
    Me.TextBox2.TabStop = False
    Me.TextBox2.Text = "30"
    Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'CheckBox1
    '
    Me.CheckBox1.AutoSize = True
    Me.CheckBox1.Location = New System.Drawing.Point(10, 114)
    Me.CheckBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.CheckBox1.Name = "CheckBox1"
    Me.CheckBox1.Size = New System.Drawing.Size(166, 20)
    Me.CheckBox1.TabIndex = 36
    Me.CheckBox1.TabStop = False
    Me.CheckBox1.Text = "FEEDER未使用日數"
    Me.CheckBox1.UseVisualStyleBackColor = True
    '
    'cb_shSb09
    '
    Me.cb_shSb09.FormattingEnabled = True
    Me.cb_shSb09.Location = New System.Drawing.Point(120, 78)
    Me.cb_shSb09.Margin = New System.Windows.Forms.Padding(3, 5, 3, 2)
    Me.cb_shSb09.Name = "cb_shSb09"
    Me.cb_shSb09.Size = New System.Drawing.Size(181, 24)
    Me.cb_shSb09.TabIndex = 35
    Me.cb_shSb09.TabStop = False
    Me.cb_shSb09.Text = "0:良品空盤"
    '
    'dt_shDate
    '
    Me.dt_shDate.CustomFormat = "yyyy/MM/dd"
    Me.dt_shDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
    Me.dt_shDate.Location = New System.Drawing.Point(140, 148)
    Me.dt_shDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.dt_shDate.Name = "dt_shDate"
    Me.dt_shDate.Size = New System.Drawing.Size(115, 26)
    Me.dt_shDate.TabIndex = 34
    Me.dt_shDate.TabStop = False
    '
    'btn_SearchFD
    '
    Me.btn_SearchFD.Location = New System.Drawing.Point(14, 26)
    Me.btn_SearchFD.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
    Me.btn_SearchFD.Name = "btn_SearchFD"
    Me.btn_SearchFD.Size = New System.Drawing.Size(112, 41)
    Me.btn_SearchFD.TabIndex = 31
    Me.btn_SearchFD.TabStop = False
    Me.btn_SearchFD.Text = "查詢重現"
    Me.btn_SearchFD.UseVisualStyleBackColor = True
    '
    'SFD
    '
    Me.SFD.DefaultExt = "CSV"
    Me.SFD.Filter = "CSV檔案格式|*.CSV|所有檔案|*.*;"
    Me.SFD.Title = "請輸入要存檔的檔名"
    '
    'Frm0601
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(1087, 733)
    Me.Controls.Add(Me.TP)
    Me.Font = New System.Drawing.Font("黑体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ImeMode = System.Windows.Forms.ImeMode.Disable
    Me.Margin = New System.Windows.Forms.Padding(4)
    Me.Name = "Frm0601"
    Me.Text = "FEEDER 基本資料建檔"
    Me.TP.ResumeLayout(False)
    CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
    Me.gp_FeederData.ResumeLayout(False)
    Me.gp_FeederState.ResumeLayout(False)
    Me.gp_FeederState.PerformLayout()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.Panel1.ResumeLayout(False)
    Me.gp_Search.ResumeLayout(False)
    Me.gp_Search.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents TP As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents gp_FeederData As System.Windows.Forms.GroupBox
  Friend WithEvents DG As System.Windows.Forms.DataGridView
  Friend WithEvents btn_Save As System.Windows.Forms.Button
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents txt_sb1 As System.Windows.Forms.TextBox
  Friend WithEvents dt_sb11 As System.Windows.Forms.DateTimePicker
  Friend WithEvents txt_sb23 As System.Windows.Forms.TextBox
  Friend WithEvents cb_sb9 As System.Windows.Forms.ComboBox
  Friend WithEvents txt_sb22 As System.Windows.Forms.TextBox
  Friend WithEvents dt_sb12 As System.Windows.Forms.DateTimePicker
  Friend WithEvents gp_Search As System.Windows.Forms.GroupBox
  Friend WithEvents cb_shSb09 As System.Windows.Forms.ComboBox
  Friend WithEvents dt_shDate As System.Windows.Forms.DateTimePicker
  Friend WithEvents btn_SearchFD As System.Windows.Forms.Button
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents btn_insert As System.Windows.Forms.Button
  Friend WithEvents MSGID As System.Windows.Forms.Label
  Friend WithEvents gp_FeederState As System.Windows.Forms.GroupBox
  Friend WithEvents txt_sb21 As System.Windows.Forms.TextBox
  Friend WithEvents txt_sb20 As System.Windows.Forms.TextBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents txt_sb19 As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents txt_sb15 As System.Windows.Forms.TextBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents txt_sb17 As System.Windows.Forms.TextBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents txt_sb16 As System.Windows.Forms.TextBox
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents txt_sb10 As System.Windows.Forms.TextBox
  Friend WithEvents txt_sb18 As System.Windows.Forms.TextBox
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  Friend WithEvents SFD As System.Windows.Forms.SaveFileDialog
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents DIV As System.Windows.Forms.TextBox
  Friend WithEvents Label19 As System.Windows.Forms.Label
End Class
