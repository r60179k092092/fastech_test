<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm0702
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
    Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
    Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
    Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.PAGESCAN = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.PAGES = New System.Windows.Forms.ComboBox()
    Me.MODEL = New System.Windows.Forms.ComboBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.KBTYPE = New System.Windows.Forms.ComboBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.PERIOD = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.DATES = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.STNNA = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.STNID = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Panel2 = New System.Windows.Forms.Panel()
    Me.CH1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
    Me.Panel3 = New System.Windows.Forms.Panel()
    Me.DG1 = New System.Windows.Forms.DataGridView()
    Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Button4 = New System.Windows.Forms.Button()
    Me.Button3 = New System.Windows.Forms.Button()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.ComboBox1 = New System.Windows.Forms.ComboBox()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.DG = New System.Windows.Forms.DataGridView()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.LINEID = New System.Windows.Forms.CheckedListBox()
    Me.MOID = New System.Windows.Forms.CheckedListBox()
    Me.CLST3 = New System.Windows.Forms.CheckedListBox()
    Me.Panel1.SuspendLayout()
    Me.Panel2.SuspendLayout()
    CType(Me.CH1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Panel3.SuspendLayout()
    CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Panel1
    '
    Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.Panel1.Controls.Add(Me.CLST3)
    Me.Panel1.Controls.Add(Me.MOID)
    Me.Panel1.Controls.Add(Me.Label14)
    Me.Panel1.Controls.Add(Me.LINEID)
    Me.Panel1.Controls.Add(Me.PAGES)
    Me.Panel1.Controls.Add(Me.Label15)
    Me.Panel1.Controls.Add(Me.Label11)
    Me.Panel1.Controls.Add(Me.MODEL)
    Me.Panel1.Controls.Add(Me.Label8)
    Me.Panel1.Controls.Add(Me.PAGESCAN)
    Me.Panel1.Controls.Add(Me.Label12)
    Me.Panel1.Controls.Add(Me.Label4)
    Me.Panel1.Controls.Add(Me.KBTYPE)
    Me.Panel1.Controls.Add(Me.Label9)
    Me.Panel1.Controls.Add(Me.Label10)
    Me.Panel1.Controls.Add(Me.Label7)
    Me.Panel1.Controls.Add(Me.PERIOD)
    Me.Panel1.Controls.Add(Me.Label6)
    Me.Panel1.Controls.Add(Me.Label5)
    Me.Panel1.Controls.Add(Me.DATES)
    Me.Panel1.Controls.Add(Me.Label3)
    Me.Panel1.Controls.Add(Me.STNNA)
    Me.Panel1.Controls.Add(Me.Label2)
    Me.Panel1.Controls.Add(Me.STNID)
    Me.Panel1.Controls.Add(Me.Label1)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Padding = New System.Windows.Forms.Padding(3)
    Me.Panel1.Size = New System.Drawing.Size(1075, 239)
    Me.Panel1.TabIndex = 0
    '
    'Label14
    '
    Me.Label14.AutoSize = True
    Me.Label14.Font = New System.Drawing.Font("細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label14.Location = New System.Drawing.Point(650, 45)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(93, 16)
    Me.Label14.TabIndex = 20
    Me.Label14.Text = "選擇工序："
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Font = New System.Drawing.Font("細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label11.Location = New System.Drawing.Point(229, 171)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(25, 16)
    Me.Label11.TabIndex = 23
    Me.Label11.Text = "秒"
    '
    'PAGESCAN
    '
    Me.PAGESCAN.Location = New System.Drawing.Point(143, 166)
    Me.PAGESCAN.Name = "PAGESCAN"
    Me.PAGESCAN.Size = New System.Drawing.Size(83, 27)
    Me.PAGESCAN.TabIndex = 5
    Me.PAGESCAN.Text = "10"
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.Font = New System.Drawing.Font("細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label12.Location = New System.Drawing.Point(48, 171)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(93, 16)
    Me.Label12.TabIndex = 21
    Me.Label12.Text = "翻頁頻率："
    '
    'PAGES
    '
    Me.PAGES.FormattingEnabled = True
    Me.PAGES.ItemHeight = 16
    Me.PAGES.Items.AddRange(New Object() {"0:依照線別翻頁", "1:依照工單翻頁", "2:依照清單翻頁"})
    Me.PAGES.Location = New System.Drawing.Point(143, 199)
    Me.PAGES.Name = "PAGES"
    Me.PAGES.Size = New System.Drawing.Size(189, 24)
    Me.PAGES.TabIndex = 10
    '
    'MODEL
    '
    Me.MODEL.FormattingEnabled = True
    Me.MODEL.ItemHeight = 16
    Me.MODEL.Location = New System.Drawing.Point(143, 103)
    Me.MODEL.Name = "MODEL"
    Me.MODEL.Size = New System.Drawing.Size(189, 24)
    Me.MODEL.TabIndex = 8
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label4.Location = New System.Drawing.Point(336, 45)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(93, 16)
    Me.Label4.TabIndex = 12
    Me.Label4.Text = "選擇線別："
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Font = New System.Drawing.Font("細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label8.Location = New System.Drawing.Point(17, 107)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(127, 16)
    Me.Label8.TabIndex = 14
    Me.Label8.Text = "選擇顯示機種："
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Font = New System.Drawing.Font("細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label9.Location = New System.Drawing.Point(461, 45)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(110, 16)
    Me.Label9.TabIndex = 16
    Me.Label9.Text = "選擇工單號："
    '
    'KBTYPE
    '
    Me.KBTYPE.FormattingEnabled = True
    Me.KBTYPE.ItemHeight = 16
    Me.KBTYPE.Items.AddRange(New Object() {"0: 生產日報表看板", "1: 產線電子看板", "2: 不良率P-管制圖"})
    Me.KBTYPE.Location = New System.Drawing.Point(143, 73)
    Me.KBTYPE.Name = "KBTYPE"
    Me.KBTYPE.Size = New System.Drawing.Size(189, 24)
    Me.KBTYPE.TabIndex = 6
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Font = New System.Drawing.Font("細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label10.Location = New System.Drawing.Point(51, 77)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(93, 16)
    Me.Label10.TabIndex = 18
    Me.Label10.Text = "看板類型："
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Font = New System.Drawing.Font("細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label7.Location = New System.Drawing.Point(229, 138)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(25, 16)
    Me.Label7.TabIndex = 11
    Me.Label7.Text = "秒"
    '
    'PERIOD
    '
    Me.PERIOD.Location = New System.Drawing.Point(143, 133)
    Me.PERIOD.Name = "PERIOD"
    Me.PERIOD.Size = New System.Drawing.Size(83, 27)
    Me.PERIOD.TabIndex = 4
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Font = New System.Drawing.Font("細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label6.Location = New System.Drawing.Point(48, 138)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(93, 16)
    Me.Label6.TabIndex = 9
    Me.Label6.Text = "刷新頻率："
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Font = New System.Drawing.Font("細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label5.Location = New System.Drawing.Point(184, 45)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(25, 16)
    Me.Label5.TabIndex = 8
    Me.Label5.Text = "日"
    '
    'DATES
    '
    Me.DATES.Location = New System.Drawing.Point(143, 40)
    Me.DATES.Name = "DATES"
    Me.DATES.Size = New System.Drawing.Size(35, 27)
    Me.DATES.TabIndex = 3
    Me.DATES.Tag = ""
    Me.DATES.Text = "1"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Font = New System.Drawing.Font("細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label3.Location = New System.Drawing.Point(34, 45)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(110, 16)
    Me.Label3.TabIndex = 4
    Me.Label3.Text = "顯示本日前："
    '
    'STNNA
    '
    Me.STNNA.Location = New System.Drawing.Point(443, 7)
    Me.STNNA.Name = "STNNA"
    Me.STNNA.Size = New System.Drawing.Size(496, 27)
    Me.STNNA.TabIndex = 2
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label2.Location = New System.Drawing.Point(297, 12)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(144, 16)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "看板名稱及位置："
    '
    'STNID
    '
    Me.STNID.Location = New System.Drawing.Point(143, 7)
    Me.STNID.Name = "STNID"
    Me.STNID.Size = New System.Drawing.Size(129, 27)
    Me.STNID.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label1.Location = New System.Drawing.Point(17, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(127, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "看板站台編號："
    '
    'Panel2
    '
    Me.Panel2.Controls.Add(Me.CH1)
    Me.Panel2.Controls.Add(Me.Panel3)
    Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Panel2.Location = New System.Drawing.Point(585, 239)
    Me.Panel2.Name = "Panel2"
    Me.Panel2.Size = New System.Drawing.Size(490, 276)
    Me.Panel2.TabIndex = 1
    '
    'CH1
    '
    ChartArea1.Name = "ChartArea1"
    Me.CH1.ChartAreas.Add(ChartArea1)
    Me.CH1.Dock = System.Windows.Forms.DockStyle.Fill
    Legend1.Name = "Legend1"
    Me.CH1.Legends.Add(Legend1)
    Me.CH1.Location = New System.Drawing.Point(0, 245)
    Me.CH1.Name = "CH1"
    Series1.ChartArea = "ChartArea1"
    Series1.Legend = "Legend1"
    Series1.Name = "Series1"
    Me.CH1.Series.Add(Series1)
    Me.CH1.Size = New System.Drawing.Size(490, 31)
    Me.CH1.TabIndex = 1
    Me.CH1.Text = "Chart1"
    '
    'Panel3
    '
    Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.Panel3.Controls.Add(Me.DG1)
    Me.Panel3.Controls.Add(Me.Button4)
    Me.Panel3.Controls.Add(Me.Button3)
    Me.Panel3.Controls.Add(Me.Button2)
    Me.Panel3.Controls.Add(Me.Button1)
    Me.Panel3.Controls.Add(Me.ComboBox1)
    Me.Panel3.Controls.Add(Me.Label13)
    Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel3.Location = New System.Drawing.Point(0, 0)
    Me.Panel3.Name = "Panel3"
    Me.Panel3.Padding = New System.Windows.Forms.Padding(3)
    Me.Panel3.Size = New System.Drawing.Size(490, 245)
    Me.Panel3.TabIndex = 0
    '
    'DG1
    '
    Me.DG1.AllowUserToAddRows = False
    Me.DG1.AllowUserToDeleteRows = False
    DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.DG1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
    Me.DG1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
    Me.DG1.Dock = System.Windows.Forms.DockStyle.Bottom
    Me.DG1.Location = New System.Drawing.Point(3, 84)
    Me.DG1.Name = "DG1"
    Me.DG1.ReadOnly = True
    Me.DG1.RowHeadersWidth = 60
    Me.DG1.RowTemplate.Height = 24
    Me.DG1.Size = New System.Drawing.Size(480, 154)
    Me.DG1.TabIndex = 19
    '
    'Column1
    '
    Me.Column1.HeaderText = "編號"
    Me.Column1.Name = "Column1"
    Me.Column1.ReadOnly = True
    Me.Column1.Width = 65
    '
    'Column2
    '
    Me.Column2.HeaderText = "說明"
    Me.Column2.Name = "Column2"
    Me.Column2.ReadOnly = True
    Me.Column2.Width = 65
    '
    'Button4
    '
    Me.Button4.Location = New System.Drawing.Point(250, 53)
    Me.Button4.Name = "Button4"
    Me.Button4.Size = New System.Drawing.Size(75, 25)
    Me.Button4.TabIndex = 18
    Me.Button4.TabStop = False
    Me.Button4.Text = "下移"
    Me.Button4.UseVisualStyleBackColor = True
    '
    'Button3
    '
    Me.Button3.Location = New System.Drawing.Point(169, 53)
    Me.Button3.Name = "Button3"
    Me.Button3.Size = New System.Drawing.Size(75, 25)
    Me.Button3.TabIndex = 17
    Me.Button3.TabStop = False
    Me.Button3.Text = "上移"
    Me.Button3.UseVisualStyleBackColor = True
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(88, 53)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(75, 25)
    Me.Button2.TabIndex = 16
    Me.Button2.TabStop = False
    Me.Button2.Text = "移除"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(7, 53)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(75, 25)
    Me.Button1.TabIndex = 15
    Me.Button1.TabStop = False
    Me.Button1.Text = "加入"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'ComboBox1
    '
    Me.ComboBox1.FormattingEnabled = True
    Me.ComboBox1.Location = New System.Drawing.Point(7, 23)
    Me.ComboBox1.Name = "ComboBox1"
    Me.ComboBox1.Size = New System.Drawing.Size(380, 24)
    Me.ComboBox1.TabIndex = 14
    Me.ComboBox1.TabStop = False
    '
    'Label13
    '
    Me.Label13.AutoSize = True
    Me.Label13.Location = New System.Drawing.Point(4, 4)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(120, 16)
    Me.Label13.TabIndex = 0
    Me.Label13.Text = "選擇圖表類型："
    '
    'DG
    '
    Me.DG.AllowUserToAddRows = False
    Me.DG.AllowUserToDeleteRows = False
    DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.DG.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
    Me.DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DG.Dock = System.Windows.Forms.DockStyle.Left
    Me.DG.Location = New System.Drawing.Point(0, 239)
    Me.DG.Name = "DG"
    Me.DG.RowHeadersWidth = 60
    Me.DG.RowTemplate.Height = 24
    Me.DG.Size = New System.Drawing.Size(585, 276)
    Me.DG.TabIndex = 1
    '
    'Label15
    '
    Me.Label15.AutoSize = True
    Me.Label15.Font = New System.Drawing.Font("細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label15.Location = New System.Drawing.Point(17, 203)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(127, 16)
    Me.Label15.TabIndex = 25
    Me.Label15.Text = "自動翻頁順序："
    '
    'LINEID
    '
    Me.LINEID.Font = New System.Drawing.Font("細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.LINEID.FormattingEnabled = True
    Me.LINEID.Location = New System.Drawing.Point(338, 73)
    Me.LINEID.Name = "LINEID"
    Me.LINEID.Size = New System.Drawing.Size(113, 158)
    Me.LINEID.TabIndex = 26
    '
    'MOID
    '
    Me.MOID.Font = New System.Drawing.Font("細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.MOID.FormattingEnabled = True
    Me.MOID.Location = New System.Drawing.Point(457, 73)
    Me.MOID.Name = "MOID"
    Me.MOID.Size = New System.Drawing.Size(184, 158)
    Me.MOID.TabIndex = 27
    '
    'CLST3
    '
    Me.CLST3.Font = New System.Drawing.Font("細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.CLST3.FormattingEnabled = True
    Me.CLST3.Location = New System.Drawing.Point(647, 73)
    Me.CLST3.Name = "CLST3"
    Me.CLST3.Size = New System.Drawing.Size(184, 158)
    Me.CLST3.TabIndex = 28
    '
    'Frm0702
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(1075, 515)
    Me.Controls.Add(Me.Panel2)
    Me.Controls.Add(Me.DG)
    Me.Controls.Add(Me.Panel1)
    Me.Font = New System.Drawing.Font("細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Name = "Frm0702"
    Me.Text = "Frm0702"
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.Panel2.ResumeLayout(False)
    CType(Me.CH1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Panel3.ResumeLayout(False)
    Me.Panel3.PerformLayout()
    CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Panel2 As System.Windows.Forms.Panel
  Friend WithEvents DG As System.Windows.Forms.DataGridView
  Friend WithEvents CH1 As System.Windows.Forms.DataVisualization.Charting.Chart
  Friend WithEvents Panel3 As System.Windows.Forms.Panel
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents MODEL As System.Windows.Forms.ComboBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents PERIOD As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents DATES As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents STNNA As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents STNID As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents PAGES As System.Windows.Forms.ComboBox
  Friend WithEvents KBTYPE As System.Windows.Forms.ComboBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents PAGESCAN As System.Windows.Forms.TextBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents DG1 As System.Windows.Forms.DataGridView
  Friend WithEvents Button4 As System.Windows.Forms.Button
  Friend WithEvents Button3 As System.Windows.Forms.Button
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents CLST3 As System.Windows.Forms.CheckedListBox
  Friend WithEvents MOID As System.Windows.Forms.CheckedListBox
  Friend WithEvents LINEID As System.Windows.Forms.CheckedListBox
  Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
