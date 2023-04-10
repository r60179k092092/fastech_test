<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PM0304
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
    Me.TabPage1 = New System.Windows.Forms.TabPage()
    Me.Panel3 = New System.Windows.Forms.Panel()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.DG1 = New FDGV.FDataGridView()
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.CheckBox1 = New System.Windows.Forms.CheckBox()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.ComboBox1 = New System.Windows.Forms.ComboBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TextBox6 = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.SPEC = New System.Windows.Forms.Label()
    Me.TextBox2 = New System.Windows.Forms.TextBox()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.Labmateial = New System.Windows.Forms.Label()
    Me.Label38 = New System.Windows.Forms.Label()
    Me.TextBox4 = New System.Windows.Forms.TextBox()
    Me.TextBox3 = New System.Windows.Forms.TextBox()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.LabModel = New System.Windows.Forms.Label()
    Me.Labflowversion = New System.Windows.Forms.Label()
    Me.LabFlowcode = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TBC = New System.Windows.Forms.TabControl()
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.TabPage1.SuspendLayout()
    Me.Panel3.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Panel1.SuspendLayout()
    Me.TBC.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabPage1
    '
    Me.TabPage1.Controls.Add(Me.Panel3)
    Me.TabPage1.Controls.Add(Me.Panel1)
    Me.TabPage1.Font = New System.Drawing.Font("黑体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TabPage1.Location = New System.Drawing.Point(4, 26)
    Me.TabPage1.Name = "TabPage1"
    Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage1.Size = New System.Drawing.Size(1280, 462)
    Me.TabPage1.TabIndex = 0
    Me.TabPage1.Text = "料站表信息"
    Me.TabPage1.UseVisualStyleBackColor = True
    '
    'Panel3
    '
    Me.Panel3.Controls.Add(Me.GroupBox1)
    Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Panel3.Location = New System.Drawing.Point(3, 123)
    Me.Panel3.Name = "Panel3"
    Me.Panel3.Size = New System.Drawing.Size(1274, 336)
    Me.Panel3.TabIndex = 1
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.DG1)
    Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(1274, 336)
    Me.GroupBox1.TabIndex = 0
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "生產物料信息（BOM）"
    '
    'DG1
    '
    Me.DG1.AllowUserToAddRows = False
    Me.DG1.AllowUserToDeleteRows = False
    Me.DG1.AllowUserToResizeColumns = False
    Me.DG1.AllowUserToResizeRows = False
    DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.DG1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
    Me.DG1.Append = True
    Me.DG1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
    Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DG1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DG1.Location = New System.Drawing.Point(3, 22)
    Me.DG1.MultiSelect = False
    Me.DG1.Name = "DG1"
    Me.DG1.RowTemplate.Height = 23
    Me.DG1.RowWise = False
    Me.DG1.SaveSetting = ""
    Me.DG1.Size = New System.Drawing.Size(1268, 311)
    Me.DG1.TabIndex = 0
    Me.DG1.TabStop = False
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.Label4)
    Me.Panel1.Controls.Add(Me.Label6)
    Me.Panel1.Controls.Add(Me.CheckBox1)
    Me.Panel1.Controls.Add(Me.Button2)
    Me.Panel1.Controls.Add(Me.ComboBox1)
    Me.Panel1.Controls.Add(Me.Label5)
    Me.Panel1.Controls.Add(Me.TextBox6)
    Me.Panel1.Controls.Add(Me.Label3)
    Me.Panel1.Controls.Add(Me.Label2)
    Me.Panel1.Controls.Add(Me.SPEC)
    Me.Panel1.Controls.Add(Me.TextBox2)
    Me.Panel1.Controls.Add(Me.Button1)
    Me.Panel1.Controls.Add(Me.Labmateial)
    Me.Panel1.Controls.Add(Me.Label38)
    Me.Panel1.Controls.Add(Me.TextBox4)
    Me.Panel1.Controls.Add(Me.TextBox3)
    Me.Panel1.Controls.Add(Me.TextBox1)
    Me.Panel1.Controls.Add(Me.LabModel)
    Me.Panel1.Controls.Add(Me.Labflowversion)
    Me.Panel1.Controls.Add(Me.LabFlowcode)
    Me.Panel1.Controls.Add(Me.Label1)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Font = New System.Drawing.Font("黑体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Panel1.Location = New System.Drawing.Point(3, 3)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(1274, 120)
    Me.Panel1.TabIndex = 0
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(755, 68)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(0, 16)
    Me.Label4.TabIndex = 65
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(680, 68)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(72, 16)
    Me.Label6.TabIndex = 64
    Me.Label6.Text = "原材寬度"
    '
    'CheckBox1
    '
    Me.CheckBox1.AutoSize = True
    Me.CheckBox1.Location = New System.Drawing.Point(776, 8)
    Me.CheckBox1.Name = "CheckBox1"
    Me.CheckBox1.Size = New System.Drawing.Size(115, 20)
    Me.CheckBox1.TabIndex = 63
    Me.CheckBox1.Text = "SMT使用機台"
    Me.CheckBox1.UseVisualStyleBackColor = True
    '
    'Button2
    '
    Me.Button2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Button2.Location = New System.Drawing.Point(677, 4)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(85, 28)
    Me.Button2.TabIndex = 62
    Me.Button2.TabStop = False
    Me.Button2.Text = "修改版本"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'ComboBox1
    '
    Me.ComboBox1.BackColor = System.Drawing.Color.AntiqueWhite
    Me.ComboBox1.FormattingEnabled = True
    Me.ComboBox1.Location = New System.Drawing.Point(406, 6)
    Me.ComboBox1.Name = "ComboBox1"
    Me.ComboBox1.Size = New System.Drawing.Size(265, 24)
    Me.ComboBox1.TabIndex = 1
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.Label5.ForeColor = System.Drawing.Color.Navy
    Me.Label5.Location = New System.Drawing.Point(892, 41)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(256, 16)
    Me.Label5.TabIndex = 61
    Me.Label5.Text = "SMT機台如果空白表示所有機台適用" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
    '
    'TextBox6
    '
    Me.TextBox6.BackColor = System.Drawing.Color.AntiqueWhite
    Me.TextBox6.Font = New System.Drawing.Font("黑体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox6.ForeColor = System.Drawing.Color.Red
    Me.TextBox6.Location = New System.Drawing.Point(892, 5)
    Me.TextBox6.Name = "TextBox6"
    Me.TextBox6.Size = New System.Drawing.Size(308, 26)
    Me.TextBox6.TabIndex = 2
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Font = New System.Drawing.Font("黑体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(331, 10)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(72, 16)
    Me.Label3.TabIndex = 58
    Me.Label3.Text = "料站版本"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.Label2.ForeColor = System.Drawing.Color.Navy
    Me.Label2.Location = New System.Drawing.Point(51, 96)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(368, 16)
    Me.Label2.TabIndex = 56
    Me.Label2.Text = "用料類型：0 主料，1 副料，2 不控管，3 SMT用料"
    '
    'SPEC
    '
    Me.SPEC.AutoSize = True
    Me.SPEC.Location = New System.Drawing.Point(94, 68)
    Me.SPEC.Name = "SPEC"
    Me.SPEC.Size = New System.Drawing.Size(0, 16)
    Me.SPEC.TabIndex = 55
    '
    'TextBox2
    '
    Me.TextBox2.BackColor = System.Drawing.SystemColors.Control
    Me.TextBox2.Font = New System.Drawing.Font("黑体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox2.Location = New System.Drawing.Point(94, 36)
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.ReadOnly = True
    Me.TextBox2.Size = New System.Drawing.Size(195, 26)
    Me.TextBox2.TabIndex = 30
    '
    'Button1
    '
    Me.Button1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Button1.Location = New System.Drawing.Point(291, 7)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(31, 24)
    Me.Button1.TabIndex = 29
    Me.Button1.TabStop = False
    Me.Button1.Text = "..."
    Me.Button1.UseVisualStyleBackColor = True
    '
    'Labmateial
    '
    Me.Labmateial.AutoSize = True
    Me.Labmateial.Font = New System.Drawing.Font("黑体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Labmateial.Location = New System.Drawing.Point(19, 11)
    Me.Labmateial.Name = "Labmateial"
    Me.Labmateial.Size = New System.Drawing.Size(72, 16)
    Me.Labmateial.TabIndex = 28
    Me.Labmateial.Text = "物料編號"
    Me.Labmateial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label38
    '
    Me.Label38.AutoSize = True
    Me.Label38.Location = New System.Drawing.Point(51, 68)
    Me.Label38.Name = "Label38"
    Me.Label38.Size = New System.Drawing.Size(40, 16)
    Me.Label38.TabIndex = 47
    Me.Label38.Text = "說明"
    '
    'TextBox4
    '
    Me.TextBox4.Font = New System.Drawing.Font("黑体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox4.Location = New System.Drawing.Point(755, 36)
    Me.TextBox4.Name = "TextBox4"
    Me.TextBox4.ReadOnly = True
    Me.TextBox4.Size = New System.Drawing.Size(131, 26)
    Me.TextBox4.TabIndex = 27
    '
    'TextBox3
    '
    Me.TextBox3.Font = New System.Drawing.Font("黑体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox3.ForeColor = System.Drawing.Color.Red
    Me.TextBox3.Location = New System.Drawing.Point(406, 36)
    Me.TextBox3.Name = "TextBox3"
    Me.TextBox3.ReadOnly = True
    Me.TextBox3.Size = New System.Drawing.Size(265, 26)
    Me.TextBox3.TabIndex = 26
    '
    'TextBox1
    '
    Me.TextBox1.BackColor = System.Drawing.Color.AntiqueWhite
    Me.TextBox1.Font = New System.Drawing.Font("黑体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox1.ForeColor = System.Drawing.Color.Red
    Me.TextBox1.Location = New System.Drawing.Point(94, 6)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.ReadOnly = True
    Me.TextBox1.Size = New System.Drawing.Size(195, 26)
    Me.TextBox1.TabIndex = 0
    '
    'LabModel
    '
    Me.LabModel.AutoSize = True
    Me.LabModel.Font = New System.Drawing.Font("黑体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabModel.Location = New System.Drawing.Point(51, 41)
    Me.LabModel.Name = "LabModel"
    Me.LabModel.Size = New System.Drawing.Size(40, 16)
    Me.LabModel.TabIndex = 24
    Me.LabModel.Text = "型號"
    Me.LabModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Labflowversion
    '
    Me.Labflowversion.AutoSize = True
    Me.Labflowversion.Font = New System.Drawing.Font("黑体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Labflowversion.Location = New System.Drawing.Point(680, 41)
    Me.Labflowversion.Name = "Labflowversion"
    Me.Labflowversion.Size = New System.Drawing.Size(72, 16)
    Me.Labflowversion.TabIndex = 22
    Me.Labflowversion.Text = "流程版本"
    Me.Labflowversion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LabFlowcode
    '
    Me.LabFlowcode.AutoSize = True
    Me.LabFlowcode.Font = New System.Drawing.Font("黑体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabFlowcode.Location = New System.Drawing.Point(331, 41)
    Me.LabFlowcode.Name = "LabFlowcode"
    Me.LabFlowcode.Size = New System.Drawing.Size(72, 16)
    Me.LabFlowcode.TabIndex = 23
    Me.LabFlowcode.Text = "流程編號"
    Me.LabFlowcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.Label1.ForeColor = System.Drawing.Color.Navy
    Me.Label1.Location = New System.Drawing.Point(489, 96)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(720, 16)
    Me.Label1.TabIndex = 54
    Me.Label1.Text = "扣料模式：1xx批序號扣數量，2xx批號不管數量，4xx單一序號, 5xx 半成品投料，其他：FEEDER格式"
    '
    'TBC
    '
    Me.TBC.Controls.Add(Me.TabPage1)
    Me.TBC.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TBC.Font = New System.Drawing.Font("黑体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TBC.Location = New System.Drawing.Point(0, 0)
    Me.TBC.Name = "TBC"
    Me.TBC.SelectedIndex = 0
    Me.TBC.Size = New System.Drawing.Size(1288, 492)
    Me.TBC.TabIndex = 1
    Me.TBC.TabStop = False
    '
    'OpenFileDialog1
    '
    Me.OpenFileDialog1.FileName = "OpenFileDialog1"
    Me.OpenFileDialog1.Filter = "Excel|*.XLS"
    '
    'PM0304
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(1288, 492)
    Me.Controls.Add(Me.TBC)
    Me.Font = New System.Drawing.Font("黑体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Name = "PM0304"
    Me.Text = "料站表0304"
    Me.TabPage1.ResumeLayout(False)
    Me.Panel3.ResumeLayout(False)
    Me.GroupBox1.ResumeLayout(False)
    CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.TBC.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
  Friend WithEvents Panel3 As System.Windows.Forms.Panel
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents TBC As System.Windows.Forms.TabControl
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents Labmateial As System.Windows.Forms.Label
  Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
  Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents LabModel As System.Windows.Forms.Label
  Friend WithEvents Labflowversion As System.Windows.Forms.Label
  Friend WithEvents LabFlowcode As System.Windows.Forms.Label
  Friend WithEvents Label38 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents SPEC As System.Windows.Forms.Label
  Friend WithEvents DG1 As FDGV.FDataGridView
  Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
