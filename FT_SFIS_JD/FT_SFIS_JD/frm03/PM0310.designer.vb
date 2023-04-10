<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PM0310
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
        Me.DGwl = New System.Windows.Forms.DataGridView()
        Me.PBCNT = New System.Windows.Forms.Label()
        Me.PB = New System.Windows.Forms.ProgressBar()
        Me.txtDw = New System.Windows.Forms.ComboBox()
        Me.txtZL = New System.Windows.Forms.ComboBox()
        Me.Txtxh = New System.Windows.Forms.TextBox()
        Me.LabExplain = New System.Windows.Forms.Label()
        Me.Labch = New System.Windows.Forms.Label()
        Me.Txtwl = New System.Windows.Forms.TextBox()
        Me.Lablcbb = New System.Windows.Forms.Label()
        Me.Lablcbh = New System.Windows.Forms.Label()
        Me.BtnSelectflow = New System.Windows.Forms.Button()
        Me.Labflowversion = New System.Windows.Forms.Label()
        Me.Labunit = New System.Windows.Forms.Label()
        Me.Txtch = New System.Windows.Forms.TextBox()
        Me.Labsort = New System.Windows.Forms.Label()
        Me.Txtsm = New System.Windows.Forms.TextBox()
        Me.Labmodel = New System.Windows.Forms.Label()
        Me.Labmaterialcode = New System.Windows.Forms.Label()
        Me.Labflowcode = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.C1010 = New FT_SPEC.ctlDIASPEC()
        Me.C1003 = New FT_SPEC.ctlLABSPEC()
        CType(Me.DGwl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGwl
        '
        Me.DGwl.AllowUserToAddRows = False
        Me.DGwl.AllowUserToDeleteRows = False
        Me.DGwl.AllowUserToOrderColumns = True
        Me.DGwl.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGwl.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGwl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DGwl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGwl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGwl.Location = New System.Drawing.Point(0, 253)
        Me.DGwl.MultiSelect = False
        Me.DGwl.Name = "DGwl"
        Me.DGwl.ReadOnly = True
        Me.DGwl.RowTemplate.Height = 23
        Me.DGwl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGwl.Size = New System.Drawing.Size(898, 247)
        Me.DGwl.TabIndex = 0
        Me.DGwl.TabStop = False
        Me.DGwl.VirtualMode = True
        '
        'PBCNT
        '
        Me.PBCNT.AutoSize = True
        Me.PBCNT.Location = New System.Drawing.Point(604, 120)
        Me.PBCNT.Name = "PBCNT"
        Me.PBCNT.Size = New System.Drawing.Size(0, 16)
        Me.PBCNT.TabIndex = 10
        Me.PBCNT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PB
        '
        Me.PB.Location = New System.Drawing.Point(22, 177)
        Me.PB.Name = "PB"
        Me.PB.Size = New System.Drawing.Size(666, 23)
        Me.PB.TabIndex = 9
        '
        'txtDw
        '
        Me.txtDw.BackColor = System.Drawing.Color.AntiqueWhite
        Me.txtDw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtDw.FormattingEnabled = True
        Me.txtDw.Location = New System.Drawing.Point(105, 38)
        Me.txtDw.Name = "txtDw"
        Me.txtDw.Size = New System.Drawing.Size(105, 24)
        Me.txtDw.TabIndex = 2
        '
        'txtZL
        '
        Me.txtZL.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtZL.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.txtZL.BackColor = System.Drawing.Color.AntiqueWhite
        Me.txtZL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtZL.FormattingEnabled = True
        Me.txtZL.Location = New System.Drawing.Point(354, 38)
        Me.txtZL.Name = "txtZL"
        Me.txtZL.Size = New System.Drawing.Size(160, 24)
        Me.txtZL.TabIndex = 3
        '
        'Txtxh
        '
        Me.Txtxh.BackColor = System.Drawing.Color.White
        Me.Txtxh.Location = New System.Drawing.Point(105, 70)
        Me.Txtxh.Name = "Txtxh"
        Me.Txtxh.Size = New System.Drawing.Size(409, 26)
        Me.Txtxh.TabIndex = 4
        '
        'LabExplain
        '
        Me.LabExplain.Location = New System.Drawing.Point(5, 108)
        Me.LabExplain.Name = "LabExplain"
        Me.LabExplain.Size = New System.Drawing.Size(87, 16)
        Me.LabExplain.TabIndex = 1
        Me.LabExplain.Text = "說明"
        Me.LabExplain.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Labch
        '
        Me.Labch.Location = New System.Drawing.Point(5, 141)
        Me.Labch.Name = "Labch"
        Me.Labch.Size = New System.Drawing.Size(87, 16)
        Me.Labch.TabIndex = 1
        Me.Labch.Text = "規格"
        Me.Labch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Txtwl
        '
        Me.Txtwl.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Txtwl.Location = New System.Drawing.Point(105, 4)
        Me.Txtwl.Name = "Txtwl"
        Me.Txtwl.Size = New System.Drawing.Size(188, 26)
        Me.Txtwl.TabIndex = 1
        '
        'Lablcbb
        '
        Me.Lablcbb.AutoSize = True
        Me.Lablcbb.Font = New System.Drawing.Font("黑体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lablcbb.ForeColor = System.Drawing.Color.Red
        Me.Lablcbb.Location = New System.Drawing.Point(646, 42)
        Me.Lablcbb.Name = "Lablcbb"
        Me.Lablcbb.Size = New System.Drawing.Size(0, 16)
        Me.Lablcbb.TabIndex = 4
        '
        'Lablcbh
        '
        Me.Lablcbh.AutoSize = True
        Me.Lablcbh.Font = New System.Drawing.Font("黑体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lablcbh.ForeColor = System.Drawing.Color.Red
        Me.Lablcbh.Location = New System.Drawing.Point(646, 9)
        Me.Lablcbh.Name = "Lablcbh"
        Me.Lablcbh.Size = New System.Drawing.Size(0, 16)
        Me.Lablcbh.TabIndex = 3
        '
        'BtnSelectflow
        '
        Me.BtnSelectflow.Location = New System.Drawing.Point(560, 108)
        Me.BtnSelectflow.Name = "BtnSelectflow"
        Me.BtnSelectflow.Size = New System.Drawing.Size(128, 54)
        Me.BtnSelectflow.TabIndex = 6
        Me.BtnSelectflow.TabStop = False
        Me.BtnSelectflow.Text = "選擇流程"
        Me.BtnSelectflow.UseVisualStyleBackColor = True
        '
        'Labflowversion
        '
        Me.Labflowversion.Location = New System.Drawing.Point(520, 40)
        Me.Labflowversion.Name = "Labflowversion"
        Me.Labflowversion.Size = New System.Drawing.Size(111, 21)
        Me.Labflowversion.TabIndex = 1
        Me.Labflowversion.Text = "流程版本"
        Me.Labflowversion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Labunit
        '
        Me.Labunit.Location = New System.Drawing.Point(5, 42)
        Me.Labunit.Name = "Labunit"
        Me.Labunit.Size = New System.Drawing.Size(87, 16)
        Me.Labunit.TabIndex = 1
        Me.Labunit.Text = "單位"
        Me.Labunit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Txtch
        '
        Me.Txtch.Location = New System.Drawing.Point(105, 136)
        Me.Txtch.Name = "Txtch"
        Me.Txtch.Size = New System.Drawing.Size(409, 26)
        Me.Txtch.TabIndex = 6
        '
        'Labsort
        '
        Me.Labsort.Location = New System.Drawing.Point(245, 40)
        Me.Labsort.Name = "Labsort"
        Me.Labsort.Size = New System.Drawing.Size(106, 20)
        Me.Labsort.TabIndex = 1
        Me.Labsort.Text = "種類"
        Me.Labsort.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Txtsm
        '
        Me.Txtsm.Location = New System.Drawing.Point(105, 103)
        Me.Txtsm.Name = "Txtsm"
        Me.Txtsm.Size = New System.Drawing.Size(409, 26)
        Me.Txtsm.TabIndex = 5
        '
        'Labmodel
        '
        Me.Labmodel.Location = New System.Drawing.Point(5, 75)
        Me.Labmodel.Name = "Labmodel"
        Me.Labmodel.Size = New System.Drawing.Size(87, 16)
        Me.Labmodel.TabIndex = 1
        Me.Labmodel.Text = "型號"
        Me.Labmodel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Labmaterialcode
        '
        Me.Labmaterialcode.Location = New System.Drawing.Point(5, 9)
        Me.Labmaterialcode.Name = "Labmaterialcode"
        Me.Labmaterialcode.Size = New System.Drawing.Size(87, 16)
        Me.Labmaterialcode.TabIndex = 1
        Me.Labmaterialcode.Text = "物料編號"
        Me.Labmaterialcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Labflowcode
        '
        Me.Labflowcode.Location = New System.Drawing.Point(520, 7)
        Me.Labflowcode.Name = "Labflowcode"
        Me.Labflowcode.Size = New System.Drawing.Size(111, 21)
        Me.Labflowcode.TabIndex = 1
        Me.Labflowcode.Text = "流程編號"
        Me.Labflowcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(898, 253)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(890, 223)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "基本資料"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PBCNT)
        Me.Panel1.Controls.Add(Me.Labmaterialcode)
        Me.Panel1.Controls.Add(Me.PB)
        Me.Panel1.Controls.Add(Me.Labflowcode)
        Me.Panel1.Controls.Add(Me.txtDw)
        Me.Panel1.Controls.Add(Me.Labmodel)
        Me.Panel1.Controls.Add(Me.txtZL)
        Me.Panel1.Controls.Add(Me.Txtsm)
        Me.Panel1.Controls.Add(Me.Txtxh)
        Me.Panel1.Controls.Add(Me.Labsort)
        Me.Panel1.Controls.Add(Me.LabExplain)
        Me.Panel1.Controls.Add(Me.Txtch)
        Me.Panel1.Controls.Add(Me.Labch)
        Me.Panel1.Controls.Add(Me.Labunit)
        Me.Panel1.Controls.Add(Me.Txtwl)
        Me.Panel1.Controls.Add(Me.Labflowversion)
        Me.Panel1.Controls.Add(Me.Lablcbb)
        Me.Panel1.Controls.Add(Me.BtnSelectflow)
        Me.Panel1.Controls.Add(Me.Lablcbh)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(884, 217)
        Me.Panel1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel3)
        Me.TabPage2.Controls.Add(Me.Panel2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 26)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(890, 223)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "詳細資料"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Black
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(635, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(249, 217)
        Me.Panel3.TabIndex = 1
        Me.Panel3.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.C1010)
        Me.Panel2.Controls.Add(Me.C1003)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(632, 217)
        Me.Panel2.TabIndex = 0
        '
        'C1010
        '
        Me.C1010.AngleNum = ""
        Me.C1010.AngleType = ""
        Me.C1010.ColumnNum = ""
        Me.C1010.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1010.Enabled = False
        Me.C1010.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.C1010.ID = ""
        Me.C1010.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.C1010.Info = ""
        Me.C1010.Location = New System.Drawing.Point(0, 220)
        Me.C1010.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.C1010.Name = "C1010"
        Me.C1010.PapHeight = ""
        Me.C1010.PapLength = ""
        Me.C1010.RMK = ""
        Me.C1010.RowNum = ""
        Me.C1010.Size = New System.Drawing.Size(632, 194)
        Me.C1010.TabIndex = 0
        Me.C1010.Visible = False
        '
        'C1003
        '
        Me.C1003.AngleNum = ""
        Me.C1003.AngleType = ""
        Me.C1003.ColumnNum = ""
        Me.C1003.CraftNo = ""
        Me.C1003.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1003.Enabled = False
        Me.C1003.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.C1003.FontColor = ""
        Me.C1003.ID = ""
        Me.C1003.Info = ""
        Me.C1003.Location = New System.Drawing.Point(0, 0)
        Me.C1003.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.C1003.Material1 = ""
        Me.C1003.Name = "C1003"
        Me.C1003.PapHeight = ""
        Me.C1003.PapLength = ""
        Me.C1003.Remark = ""
        Me.C1003.RowNum = ""
        Me.C1003.Size = New System.Drawing.Size(632, 220)
        Me.C1003.TabIndex = 1
        Me.C1003.Type = ""
        Me.C1003.Visible = False
        '
        'PM0310
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(898, 500)
        Me.Controls.Add(Me.DGwl)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("黑体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "PM0310"
        Me.Text = "物料管理0310"
        CType(Me.DGwl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
  Friend WithEvents DGwl As System.Windows.Forms.DataGridView
  Friend WithEvents Labunit As System.Windows.Forms.Label
  Friend WithEvents Labsort As System.Windows.Forms.Label
  Friend WithEvents Txtsm As System.Windows.Forms.TextBox
  Friend WithEvents Labmodel As System.Windows.Forms.Label
  Friend WithEvents Txtxh As System.Windows.Forms.TextBox
  Friend WithEvents Labmaterialcode As System.Windows.Forms.Label
  Friend WithEvents Labflowversion As System.Windows.Forms.Label
  Friend WithEvents Labflowcode As System.Windows.Forms.Label
  Friend WithEvents LabExplain As System.Windows.Forms.Label
  Friend WithEvents BtnSelectflow As System.Windows.Forms.Button
  Friend WithEvents Lablcbb As System.Windows.Forms.Label
  Friend WithEvents Lablcbh As System.Windows.Forms.Label
  Friend WithEvents Txtwl As System.Windows.Forms.TextBox
  Friend WithEvents Labch As System.Windows.Forms.Label
  Friend WithEvents Txtch As System.Windows.Forms.TextBox
  Friend WithEvents txtDw As System.Windows.Forms.ComboBox
  Friend WithEvents txtZL As System.Windows.Forms.ComboBox
  Friend WithEvents PBCNT As System.Windows.Forms.Label
  Friend WithEvents PB As System.Windows.Forms.ProgressBar
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
  Friend WithEvents Panel2 As System.Windows.Forms.Panel
  Friend WithEvents C1010 As FT_SPEC.ctlDIASPEC
  Friend WithEvents Panel3 As System.Windows.Forms.Panel
  Friend WithEvents C1003 As FT_SPEC.ctlLABSPEC
End Class
