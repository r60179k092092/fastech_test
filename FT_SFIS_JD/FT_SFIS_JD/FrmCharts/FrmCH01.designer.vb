<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCH01
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
    Me.components = New System.ComponentModel.Container()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
    Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
    Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.FDG = New FDGV.FDataGridView()
    Me.Panel2 = New System.Windows.Forms.Panel()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.ComboBox1 = New System.Windows.Forms.ComboBox()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Button3 = New System.Windows.Forms.Button()
    Me.BRef = New System.Windows.Forms.Button()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TBNum3 = New System.Windows.Forms.NumericUpDown()
    Me.CheckBox4 = New System.Windows.Forms.CheckBox()
    Me.TBNum2 = New System.Windows.Forms.NumericUpDown()
    Me.TBNum1 = New System.Windows.Forms.NumericUpDown()
    Me.CheckBox1 = New System.Windows.Forms.CheckBox()
    Me.CheckBox3 = New System.Windows.Forms.CheckBox()
    Me.CheckBox2 = New System.Windows.Forms.CheckBox()
    Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
    Me.Panel3 = New System.Windows.Forms.Panel()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TabPage1 = New System.Windows.Forms.TabPage()
    Me.Panel4 = New System.Windows.Forms.Panel()
    Me.SHPD = New System.Windows.Forms.CheckBox()
    Me.SHPA = New System.Windows.Forms.CheckBox()
    Me.Panel7 = New System.Windows.Forms.Panel()
    Me.YED = New System.Windows.Forms.TextBox()
    Me.YBG = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.XED = New System.Windows.Forms.TextBox()
    Me.XBG = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.XIntVal = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.YintVal = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.Panel6 = New System.Windows.Forms.Panel()
    Me.LGALI = New System.Windows.Forms.ComboBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.LGLAYOUT = New System.Windows.Forms.ComboBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.LGDOCK = New System.Windows.Forms.ComboBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.CheckBox6 = New System.Windows.Forms.CheckBox()
    Me.Button5 = New System.Windows.Forms.Button()
    Me.Button7 = New System.Windows.Forms.Button()
    Me.Button6 = New System.Windows.Forms.Button()
    Me.Button4 = New System.Windows.Forms.Button()
    Me.Panel5 = New System.Windows.Forms.Panel()
    Me.CheckBox5 = New System.Windows.Forms.CheckBox()
    Me.TabPage2 = New System.Windows.Forms.TabPage()
    Me.Button10 = New System.Windows.Forms.Button()
    Me.Button9 = New System.Windows.Forms.Button()
    Me.Button8 = New System.Windows.Forms.Button()
    Me.JSCHT = New System.Windows.Forms.TextBox()
    Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
    Me.Panel1.SuspendLayout()
    CType(Me.FDG, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Panel2.SuspendLayout()
    CType(Me.TBNum3, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.TBNum2, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.TBNum1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Panel3.SuspendLayout()
    Me.TabControl1.SuspendLayout()
    Me.TabPage1.SuspendLayout()
    Me.Panel4.SuspendLayout()
    Me.Panel7.SuspendLayout()
    Me.Panel6.SuspendLayout()
    Me.Panel5.SuspendLayout()
    Me.TabPage2.SuspendLayout()
    Me.SuspendLayout()
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.FDG)
    Me.Panel1.Controls.Add(Me.Panel2)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Panel1.Location = New System.Drawing.Point(0, 361)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(1200, 196)
    Me.Panel1.TabIndex = 0
    '
    'FDG
    '
    Me.FDG.AllowUserToAddRows = False
    Me.FDG.AllowUserToDeleteRows = False
    DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.FDG.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
    Me.FDG.Append = True
    Me.FDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.FDG.Dock = System.Windows.Forms.DockStyle.Fill
    Me.FDG.Location = New System.Drawing.Point(0, 43)
    Me.FDG.Name = "FDG"
    Me.FDG.RowTemplate.Height = 24
    Me.FDG.RowWise = False
    Me.FDG.SaveSetting = ""
    Me.FDG.Size = New System.Drawing.Size(1200, 153)
    Me.FDG.TabIndex = 10
    Me.FDG.TabStop = False
    '
    'Panel2
    '
    Me.Panel2.Controls.Add(Me.TextBox1)
    Me.Panel2.Controls.Add(Me.ComboBox1)
    Me.Panel2.Controls.Add(Me.Button2)
    Me.Panel2.Controls.Add(Me.Button1)
    Me.Panel2.Controls.Add(Me.Label1)
    Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel2.Location = New System.Drawing.Point(0, 0)
    Me.Panel2.Name = "Panel2"
    Me.Panel2.Size = New System.Drawing.Size(1200, 43)
    Me.Panel2.TabIndex = 3
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(367, 6)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(410, 30)
    Me.TextBox1.TabIndex = 2
    '
    'ComboBox1
    '
    Me.ComboBox1.FormattingEnabled = True
    Me.ComboBox1.Location = New System.Drawing.Point(142, 8)
    Me.ComboBox1.Name = "ComboBox1"
    Me.ComboBox1.Size = New System.Drawing.Size(219, 27)
    Me.ComboBox1.TabIndex = 1
    '
    'Button2
    '
    Me.Button2.Font = New System.Drawing.Font("細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Button2.Location = New System.Drawing.Point(884, 8)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(85, 31)
    Me.Button2.TabIndex = 26
    Me.Button2.TabStop = False
    Me.Button2.Text = "離開"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'Button1
    '
    Me.Button1.Font = New System.Drawing.Font("細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Button1.Location = New System.Drawing.Point(793, 8)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(85, 31)
    Me.Button1.TabIndex = 25
    Me.Button1.TabStop = False
    Me.Button1.Text = "保存"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(7, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(129, 19)
    Me.Label1.TabIndex = 1
    Me.Label1.Text = "圖表格式代號"
    '
    'Button3
    '
    Me.Button3.Font = New System.Drawing.Font("細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Button3.Location = New System.Drawing.Point(4, 277)
    Me.Button3.Name = "Button3"
    Me.Button3.Size = New System.Drawing.Size(154, 38)
    Me.Button3.TabIndex = 29
    Me.Button3.TabStop = False
    Me.Button3.Text = "清除一行"
    Me.Button3.UseVisualStyleBackColor = True
    '
    'BRef
    '
    Me.BRef.Font = New System.Drawing.Font("細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BRef.Location = New System.Drawing.Point(176, 277)
    Me.BRef.Name = "BRef"
    Me.BRef.Size = New System.Drawing.Size(154, 38)
    Me.BRef.TabIndex = 24
    Me.BRef.TabStop = False
    Me.BRef.Text = "刷新"
    Me.BRef.UseVisualStyleBackColor = True
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(4, 82)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(69, 19)
    Me.Label5.TabIndex = 23
    Me.Label5.Text = "3D角度"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(4, 45)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(69, 19)
    Me.Label4.TabIndex = 22
    Me.Label4.Text = "3D間距"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(4, 8)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(69, 19)
    Me.Label3.TabIndex = 21
    Me.Label3.Text = "3D深度"
    '
    'TBNum3
    '
    Me.TBNum3.Location = New System.Drawing.Point(79, 76)
    Me.TBNum3.Maximum = New Decimal(New Integer() {179, 0, 0, 0})
    Me.TBNum3.Minimum = New Decimal(New Integer() {179, 0, 0, -2147483648})
    Me.TBNum3.Name = "TBNum3"
    Me.TBNum3.Size = New System.Drawing.Size(73, 30)
    Me.TBNum3.TabIndex = 6
    '
    'CheckBox4
    '
    Me.CheckBox4.AutoSize = True
    Me.CheckBox4.Location = New System.Drawing.Point(176, 216)
    Me.CheckBox4.Name = "CheckBox4"
    Me.CheckBox4.Size = New System.Drawing.Size(138, 23)
    Me.CheckBox4.TabIndex = 9
    Me.CheckBox4.Text = "顯示格線(Y)"
    Me.CheckBox4.UseVisualStyleBackColor = True
    '
    'TBNum2
    '
    Me.TBNum2.Location = New System.Drawing.Point(79, 39)
    Me.TBNum2.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
    Me.TBNum2.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
    Me.TBNum2.Name = "TBNum2"
    Me.TBNum2.Size = New System.Drawing.Size(73, 30)
    Me.TBNum2.TabIndex = 5
    Me.TBNum2.Value = New Decimal(New Integer() {200, 0, 0, 0})
    '
    'TBNum1
    '
    Me.TBNum1.Location = New System.Drawing.Point(79, 2)
    Me.TBNum1.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
    Me.TBNum1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
    Me.TBNum1.Name = "TBNum1"
    Me.TBNum1.Size = New System.Drawing.Size(73, 30)
    Me.TBNum1.TabIndex = 4
    Me.TBNum1.Value = New Decimal(New Integer() {200, 0, 0, 0})
    '
    'CheckBox1
    '
    Me.CheckBox1.AutoSize = True
    Me.CheckBox1.Location = New System.Drawing.Point(6, 3)
    Me.CheckBox1.Name = "CheckBox1"
    Me.CheckBox1.Size = New System.Drawing.Size(128, 23)
    Me.CheckBox1.TabIndex = 3
    Me.CheckBox1.Text = "管制圖3D化"
    Me.CheckBox1.UseVisualStyleBackColor = True
    '
    'CheckBox3
    '
    Me.CheckBox3.AutoSize = True
    Me.CheckBox3.Location = New System.Drawing.Point(176, 246)
    Me.CheckBox3.Name = "CheckBox3"
    Me.CheckBox3.Size = New System.Drawing.Size(138, 23)
    Me.CheckBox3.TabIndex = 8
    Me.CheckBox3.Text = "顯示格線(X)"
    Me.CheckBox3.UseVisualStyleBackColor = True
    '
    'CheckBox2
    '
    Me.CheckBox2.AutoSize = True
    Me.CheckBox2.Location = New System.Drawing.Point(176, 3)
    Me.CheckBox2.Name = "CheckBox2"
    Me.CheckBox2.Size = New System.Drawing.Size(108, 23)
    Me.CheckBox2.TabIndex = 7
    Me.CheckBox2.Text = "顯示圖例"
    Me.CheckBox2.UseVisualStyleBackColor = True
    '
    'Chart1
    '
    ChartArea1.Name = "ChartArea1"
    Me.Chart1.ChartAreas.Add(ChartArea1)
    Me.Chart1.Dock = System.Windows.Forms.DockStyle.Left
    Legend1.Name = "Legend1"
    Me.Chart1.Legends.Add(Legend1)
    Me.Chart1.Location = New System.Drawing.Point(0, 0)
    Me.Chart1.Name = "Chart1"
    Series1.ChartArea = "ChartArea1"
    Series1.Legend = "Legend1"
    Series1.Name = "Series1"
    Me.Chart1.Series.Add(Series1)
    Me.Chart1.Size = New System.Drawing.Size(629, 361)
    Me.Chart1.TabIndex = 5
    Me.Chart1.TabStop = False
    Me.Chart1.Text = "Chart2"
    '
    'Panel3
    '
    Me.Panel3.Controls.Add(Me.TabControl1)
    Me.Panel3.Controls.Add(Me.Chart1)
    Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel3.Location = New System.Drawing.Point(0, 0)
    Me.Panel3.Name = "Panel3"
    Me.Panel3.Size = New System.Drawing.Size(1200, 361)
    Me.Panel3.TabIndex = 1
    '
    'TabControl1
    '
    Me.TabControl1.Controls.Add(Me.TabPage1)
    Me.TabControl1.Controls.Add(Me.TabPage2)
    Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TabControl1.Location = New System.Drawing.Point(629, 0)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(571, 361)
    Me.TabControl1.TabIndex = 7
    '
    'TabPage1
    '
    Me.TabPage1.Controls.Add(Me.Panel4)
    Me.TabPage1.Location = New System.Drawing.Point(4, 29)
    Me.TabPage1.Name = "TabPage1"
    Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage1.Size = New System.Drawing.Size(563, 328)
    Me.TabPage1.TabIndex = 0
    Me.TabPage1.Text = "主參數設定"
    Me.TabPage1.UseVisualStyleBackColor = True
    '
    'Panel4
    '
    Me.Panel4.Controls.Add(Me.SHPD)
    Me.Panel4.Controls.Add(Me.SHPA)
    Me.Panel4.Controls.Add(Me.Panel7)
    Me.Panel4.Controls.Add(Me.Panel6)
    Me.Panel4.Controls.Add(Me.Button7)
    Me.Panel4.Controls.Add(Me.Button6)
    Me.Panel4.Controls.Add(Me.Button4)
    Me.Panel4.Controls.Add(Me.Panel5)
    Me.Panel4.Controls.Add(Me.CheckBox5)
    Me.Panel4.Controls.Add(Me.Button3)
    Me.Panel4.Controls.Add(Me.CheckBox2)
    Me.Panel4.Controls.Add(Me.CheckBox3)
    Me.Panel4.Controls.Add(Me.CheckBox1)
    Me.Panel4.Controls.Add(Me.BRef)
    Me.Panel4.Controls.Add(Me.CheckBox4)
    Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Panel4.Location = New System.Drawing.Point(3, 3)
    Me.Panel4.Name = "Panel4"
    Me.Panel4.Size = New System.Drawing.Size(557, 322)
    Me.Panel4.TabIndex = 6
    '
    'SHPD
    '
    Me.SHPD.AutoSize = True
    Me.SHPD.Location = New System.Drawing.Point(347, 216)
    Me.SHPD.Name = "SHPD"
    Me.SHPD.Size = New System.Drawing.Size(108, 23)
    Me.SHPD.TabIndex = 44
    Me.SHPD.Text = "圖案陰影"
    Me.SHPD.UseVisualStyleBackColor = True
    '
    'SHPA
    '
    Me.SHPA.AutoSize = True
    Me.SHPA.Location = New System.Drawing.Point(346, 186)
    Me.SHPA.Name = "SHPA"
    Me.SHPA.Size = New System.Drawing.Size(128, 23)
    Me.SHPA.TabIndex = 43
    Me.SHPA.Text = "繪圖區陰影"
    Me.SHPA.UseVisualStyleBackColor = True
    '
    'Panel7
    '
    Me.Panel7.Controls.Add(Me.YED)
    Me.Panel7.Controls.Add(Me.YBG)
    Me.Panel7.Controls.Add(Me.Label12)
    Me.Panel7.Controls.Add(Me.Label13)
    Me.Panel7.Controls.Add(Me.XED)
    Me.Panel7.Controls.Add(Me.XBG)
    Me.Panel7.Controls.Add(Me.Label10)
    Me.Panel7.Controls.Add(Me.XIntVal)
    Me.Panel7.Controls.Add(Me.Label2)
    Me.Panel7.Controls.Add(Me.Label6)
    Me.Panel7.Controls.Add(Me.YintVal)
    Me.Panel7.Controls.Add(Me.Label11)
    Me.Panel7.Location = New System.Drawing.Point(339, 0)
    Me.Panel7.Name = "Panel7"
    Me.Panel7.Size = New System.Drawing.Size(170, 135)
    Me.Panel7.TabIndex = 42
    '
    'YED
    '
    Me.YED.Location = New System.Drawing.Point(116, 100)
    Me.YED.Name = "YED"
    Me.YED.Size = New System.Drawing.Size(48, 30)
    Me.YED.TabIndex = 42
    Me.YED.Text = "0"
    '
    'YBG
    '
    Me.YBG.Location = New System.Drawing.Point(50, 100)
    Me.YBG.Name = "YBG"
    Me.YBG.Size = New System.Drawing.Size(48, 30)
    Me.YBG.TabIndex = 41
    Me.YBG.Text = "0"
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.Location = New System.Drawing.Point(4, 106)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(49, 19)
    Me.Label12.TabIndex = 40
    Me.Label12.Text = "範圍"
    '
    'Label13
    '
    Me.Label13.AutoSize = True
    Me.Label13.Location = New System.Drawing.Point(96, 106)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(19, 19)
    Me.Label13.TabIndex = 43
    Me.Label13.Text = "~"
    '
    'XED
    '
    Me.XED.Location = New System.Drawing.Point(116, 35)
    Me.XED.Name = "XED"
    Me.XED.Size = New System.Drawing.Size(48, 30)
    Me.XED.TabIndex = 38
    Me.XED.Text = "0"
    '
    'XBG
    '
    Me.XBG.Location = New System.Drawing.Point(50, 35)
    Me.XBG.Name = "XBG"
    Me.XBG.Size = New System.Drawing.Size(48, 30)
    Me.XBG.TabIndex = 37
    Me.XBG.Text = "0"
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Location = New System.Drawing.Point(4, 41)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(49, 19)
    Me.Label10.TabIndex = 36
    Me.Label10.Text = "範圍"
    '
    'XIntVal
    '
    Me.XIntVal.Location = New System.Drawing.Point(93, 4)
    Me.XIntVal.Name = "XIntVal"
    Me.XIntVal.Size = New System.Drawing.Size(48, 30)
    Me.XIntVal.TabIndex = 35
    Me.XIntVal.Text = "0"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(3, 10)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(79, 19)
    Me.Label2.TabIndex = 32
    Me.Label2.Text = "X軸間距"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(3, 73)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(79, 19)
    Me.Label6.TabIndex = 33
    Me.Label6.Text = "Y軸間距"
    '
    'YintVal
    '
    Me.YintVal.Location = New System.Drawing.Point(93, 67)
    Me.YintVal.Name = "YintVal"
    Me.YintVal.Size = New System.Drawing.Size(48, 30)
    Me.YintVal.TabIndex = 34
    Me.YintVal.Text = "0"
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(96, 41)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(19, 19)
    Me.Label11.TabIndex = 39
    Me.Label11.Text = "~"
    '
    'Panel6
    '
    Me.Panel6.Controls.Add(Me.LGALI)
    Me.Panel6.Controls.Add(Me.Label9)
    Me.Panel6.Controls.Add(Me.LGLAYOUT)
    Me.Panel6.Controls.Add(Me.Label8)
    Me.Panel6.Controls.Add(Me.LGDOCK)
    Me.Panel6.Controls.Add(Me.Label7)
    Me.Panel6.Controls.Add(Me.CheckBox6)
    Me.Panel6.Controls.Add(Me.Button5)
    Me.Panel6.Location = New System.Drawing.Point(173, 28)
    Me.Panel6.Name = "Panel6"
    Me.Panel6.Size = New System.Drawing.Size(164, 155)
    Me.Panel6.TabIndex = 41
    '
    'LGALI
    '
    Me.LGALI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.LGALI.FormattingEnabled = True
    Me.LGALI.Location = New System.Drawing.Point(89, 85)
    Me.LGALI.Name = "LGALI"
    Me.LGALI.Size = New System.Drawing.Size(72, 27)
    Me.LGALI.TabIndex = 42
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(2, 88)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(89, 19)
    Me.Label9.TabIndex = 41
    Me.Label9.Text = "圖例對齊"
    '
    'LGLAYOUT
    '
    Me.LGLAYOUT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.LGLAYOUT.FormattingEnabled = True
    Me.LGLAYOUT.Location = New System.Drawing.Point(89, 56)
    Me.LGLAYOUT.Name = "LGLAYOUT"
    Me.LGLAYOUT.Size = New System.Drawing.Size(72, 27)
    Me.LGLAYOUT.TabIndex = 40
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(2, 59)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(89, 19)
    Me.Label8.TabIndex = 39
    Me.Label8.Text = "圖例排列"
    '
    'LGDOCK
    '
    Me.LGDOCK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.LGDOCK.FormattingEnabled = True
    Me.LGDOCK.Location = New System.Drawing.Point(89, 27)
    Me.LGDOCK.Name = "LGDOCK"
    Me.LGDOCK.Size = New System.Drawing.Size(72, 27)
    Me.LGDOCK.TabIndex = 34
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(2, 30)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(89, 19)
    Me.Label7.TabIndex = 33
    Me.Label7.Text = "圖例位置"
    '
    'CheckBox6
    '
    Me.CheckBox6.AutoSize = True
    Me.CheckBox6.Location = New System.Drawing.Point(2, 4)
    Me.CheckBox6.Name = "CheckBox6"
    Me.CheckBox6.Size = New System.Drawing.Size(128, 23)
    Me.CheckBox6.TabIndex = 8
    Me.CheckBox6.Text = "在繪圖區內"
    Me.CheckBox6.UseVisualStyleBackColor = True
    '
    'Button5
    '
    Me.Button5.Location = New System.Drawing.Point(3, 114)
    Me.Button5.Name = "Button5"
    Me.Button5.Size = New System.Drawing.Size(154, 38)
    Me.Button5.TabIndex = 38
    Me.Button5.Text = "圖例字形"
    Me.Button5.UseVisualStyleBackColor = True
    '
    'Button7
    '
    Me.Button7.Location = New System.Drawing.Point(6, 233)
    Me.Button7.Name = "Button7"
    Me.Button7.Size = New System.Drawing.Size(154, 38)
    Me.Button7.TabIndex = 40
    Me.Button7.Text = "顯示數據字型"
    Me.Button7.UseVisualStyleBackColor = True
    '
    'Button6
    '
    Me.Button6.Location = New System.Drawing.Point(6, 189)
    Me.Button6.Name = "Button6"
    Me.Button6.Size = New System.Drawing.Size(154, 38)
    Me.Button6.TabIndex = 39
    Me.Button6.Text = "標題字形"
    Me.Button6.UseVisualStyleBackColor = True
    '
    'Button4
    '
    Me.Button4.Location = New System.Drawing.Point(6, 145)
    Me.Button4.Name = "Button4"
    Me.Button4.Size = New System.Drawing.Size(154, 38)
    Me.Button4.TabIndex = 37
    Me.Button4.Text = "整體字形"
    Me.Button4.UseVisualStyleBackColor = True
    '
    'Panel5
    '
    Me.Panel5.Controls.Add(Me.TBNum1)
    Me.Panel5.Controls.Add(Me.Label4)
    Me.Panel5.Controls.Add(Me.TBNum2)
    Me.Panel5.Controls.Add(Me.TBNum3)
    Me.Panel5.Controls.Add(Me.Label5)
    Me.Panel5.Controls.Add(Me.Label3)
    Me.Panel5.Location = New System.Drawing.Point(6, 28)
    Me.Panel5.Name = "Panel5"
    Me.Panel5.Size = New System.Drawing.Size(164, 111)
    Me.Panel5.TabIndex = 36
    '
    'CheckBox5
    '
    Me.CheckBox5.AutoSize = True
    Me.CheckBox5.Location = New System.Drawing.Point(176, 186)
    Me.CheckBox5.Name = "CheckBox5"
    Me.CheckBox5.Size = New System.Drawing.Size(108, 23)
    Me.CheckBox5.TabIndex = 30
    Me.CheckBox5.Text = "顯示標題"
    Me.CheckBox5.UseVisualStyleBackColor = True
    '
    'TabPage2
    '
    Me.TabPage2.Controls.Add(Me.Button10)
    Me.TabPage2.Controls.Add(Me.Button9)
    Me.TabPage2.Controls.Add(Me.Button8)
    Me.TabPage2.Controls.Add(Me.JSCHT)
    Me.TabPage2.Location = New System.Drawing.Point(4, 22)
    Me.TabPage2.Name = "TabPage2"
    Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage2.Size = New System.Drawing.Size(563, 335)
    Me.TabPage2.TabIndex = 1
    Me.TabPage2.Text = "參數指令"
    Me.TabPage2.UseVisualStyleBackColor = True
    '
    'Button10
    '
    Me.Button10.Location = New System.Drawing.Point(201, 290)
    Me.Button10.Name = "Button10"
    Me.Button10.Size = New System.Drawing.Size(75, 32)
    Me.Button10.TabIndex = 3
    Me.Button10.Text = "復原"
    Me.Button10.UseVisualStyleBackColor = True
    '
    'Button9
    '
    Me.Button9.Location = New System.Drawing.Point(84, 290)
    Me.Button9.Name = "Button9"
    Me.Button9.Size = New System.Drawing.Size(111, 32)
    Me.Button9.TabIndex = 2
    Me.Button9.Text = "貼上刷新"
    Me.Button9.UseVisualStyleBackColor = True
    '
    'Button8
    '
    Me.Button8.Location = New System.Drawing.Point(3, 290)
    Me.Button8.Name = "Button8"
    Me.Button8.Size = New System.Drawing.Size(75, 32)
    Me.Button8.TabIndex = 1
    Me.Button8.Text = "複製"
    Me.Button8.UseVisualStyleBackColor = True
    '
    'JSCHT
    '
    Me.JSCHT.Dock = System.Windows.Forms.DockStyle.Top
    Me.JSCHT.Location = New System.Drawing.Point(3, 3)
    Me.JSCHT.Multiline = True
    Me.JSCHT.Name = "JSCHT"
    Me.JSCHT.ReadOnly = True
    Me.JSCHT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.JSCHT.Size = New System.Drawing.Size(557, 281)
    Me.JSCHT.TabIndex = 0
    '
    'Timer1
    '
    Me.Timer1.Enabled = True
    '
    'FrmCH01
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(1200, 557)
    Me.ControlBox = False
    Me.Controls.Add(Me.Panel1)
    Me.Controls.Add(Me.Panel3)
    Me.Font = New System.Drawing.Font("細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
    Me.KeyPreview = True
    Me.Name = "FrmCH01"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "統計圖塊編輯"
    Me.Panel1.ResumeLayout(False)
    CType(Me.FDG, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Panel2.ResumeLayout(False)
    Me.Panel2.PerformLayout()
    CType(Me.TBNum3, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.TBNum2, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.TBNum1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Panel3.ResumeLayout(False)
    Me.TabControl1.ResumeLayout(False)
    Me.TabPage1.ResumeLayout(False)
    Me.Panel4.ResumeLayout(False)
    Me.Panel4.PerformLayout()
    Me.Panel7.ResumeLayout(False)
    Me.Panel7.PerformLayout()
    Me.Panel6.ResumeLayout(False)
    Me.Panel6.PerformLayout()
    Me.Panel5.ResumeLayout(False)
    Me.Panel5.PerformLayout()
    Me.TabPage2.ResumeLayout(False)
    Me.TabPage2.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Panel2 As System.Windows.Forms.Panel
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents BRef As System.Windows.Forms.Button
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TBNum3 As System.Windows.Forms.NumericUpDown
  Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
  Friend WithEvents TBNum2 As System.Windows.Forms.NumericUpDown
  Friend WithEvents TBNum1 As System.Windows.Forms.NumericUpDown
  Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
  Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
  Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
  Friend WithEvents FDG As FDGV.FDataGridView
  Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Button3 As System.Windows.Forms.Button
  Friend WithEvents Panel3 As System.Windows.Forms.Panel
  Friend WithEvents Panel4 As System.Windows.Forms.Panel
  Friend WithEvents XIntVal As System.Windows.Forms.TextBox
  Friend WithEvents YintVal As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
  Friend WithEvents Panel5 As System.Windows.Forms.Panel
  Friend WithEvents Button6 As System.Windows.Forms.Button
  Friend WithEvents Button5 As System.Windows.Forms.Button
  Friend WithEvents Button4 As System.Windows.Forms.Button
  Friend WithEvents Timer1 As System.Windows.Forms.Timer
  Friend WithEvents Button7 As System.Windows.Forms.Button
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
  Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
  Friend WithEvents Button9 As System.Windows.Forms.Button
  Friend WithEvents Button8 As System.Windows.Forms.Button
  Friend WithEvents JSCHT As System.Windows.Forms.TextBox
  Friend WithEvents Button10 As System.Windows.Forms.Button
  Friend WithEvents SHPD As System.Windows.Forms.CheckBox
  Friend WithEvents SHPA As System.Windows.Forms.CheckBox
  Friend WithEvents Panel7 As System.Windows.Forms.Panel
  Friend WithEvents YED As System.Windows.Forms.TextBox
  Friend WithEvents YBG As System.Windows.Forms.TextBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents XED As System.Windows.Forms.TextBox
  Friend WithEvents XBG As System.Windows.Forms.TextBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents Panel6 As System.Windows.Forms.Panel
  Friend WithEvents LGALI As System.Windows.Forms.ComboBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents LGLAYOUT As System.Windows.Forms.ComboBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents LGDOCK As System.Windows.Forms.ComboBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents CheckBox6 As System.Windows.Forms.CheckBox

End Class
