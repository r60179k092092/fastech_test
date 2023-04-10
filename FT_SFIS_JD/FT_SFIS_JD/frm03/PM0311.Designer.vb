<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PM0311
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
    Me.Labbadratell = New System.Windows.Forms.Label()
    Me.LabAccumulationll = New System.Windows.Forms.Label()
    Me.LabUltralowerlimit = New System.Windows.Forms.Label()
    Me.Labbadrateull = New System.Windows.Forms.Label()
    Me.DGjt = New System.Windows.Forms.DataGridView()
    Me.LabAccumulationull = New System.Windows.Forms.Label()
    Me.Lablowerlimit = New System.Windows.Forms.Label()
    Me.LabProductivity = New System.Windows.Forms.Label()
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.SPEC = New System.Windows.Forms.Label()
    Me.Label38 = New System.Windows.Forms.Label()
    Me.Btnproduct = New System.Windows.Forms.Button()
    Me.Txtwuliao = New System.Windows.Forms.TextBox()
    Me.numdjx = New System.Windows.Forms.NumericUpDown()
    Me.numgongshix = New System.Windows.Forms.NumericUpDown()
    Me.numgongshicx = New System.Windows.Forms.NumericUpDown()
    Me.numdjcx = New System.Windows.Forms.NumericUpDown()
    Me.Numblx = New System.Windows.Forms.NumericUpDown()
    Me.Numblcx = New System.Windows.Forms.NumericUpDown()
    Me.cmbgx = New System.Windows.Forms.ComboBox()
    Me.numgongshi = New System.Windows.Forms.NumericUpDown()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.LabProcess = New System.Windows.Forms.Label()
    Me.LabMaterial = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TJAB10 = New System.Windows.Forms.NumericUpDown()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    CType(Me.DGjt, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Panel1.SuspendLayout()
    CType(Me.numdjx, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.numgongshix, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.numgongshicx, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.numdjcx, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.Numblx, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.Numblcx, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.numgongshi, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.TJAB10, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Labbadratell
    '
    Me.Labbadratell.AutoSize = True
    Me.Labbadratell.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Labbadratell.Location = New System.Drawing.Point(405, 102)
    Me.Labbadratell.Name = "Labbadratell"
    Me.Labbadratell.Size = New System.Drawing.Size(89, 20)
    Me.Labbadratell.TabIndex = 52
    Me.Labbadratell.Text = "不良率下限"
    Me.Labbadratell.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LabAccumulationll
    '
    Me.LabAccumulationll.AutoSize = True
    Me.LabAccumulationll.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabAccumulationll.Location = New System.Drawing.Point(645, 102)
    Me.LabAccumulationll.Name = "LabAccumulationll"
    Me.LabAccumulationll.Size = New System.Drawing.Size(71, 20)
    Me.LabAccumulationll.TabIndex = 61
    Me.LabAccumulationll.Text = "WIP下限"
    Me.LabAccumulationll.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LabUltralowerlimit
    '
    Me.LabUltralowerlimit.AutoSize = True
    Me.LabUltralowerlimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabUltralowerlimit.Location = New System.Drawing.Point(219, 72)
    Me.LabUltralowerlimit.Name = "LabUltralowerlimit"
    Me.LabUltralowerlimit.Size = New System.Drawing.Size(57, 20)
    Me.LabUltralowerlimit.TabIndex = 59
    Me.LabUltralowerlimit.Text = "超下限"
    Me.LabUltralowerlimit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Labbadrateull
    '
    Me.Labbadrateull.AutoSize = True
    Me.Labbadrateull.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Labbadrateull.Location = New System.Drawing.Point(389, 72)
    Me.Labbadrateull.Name = "Labbadrateull"
    Me.Labbadrateull.Size = New System.Drawing.Size(105, 20)
    Me.Labbadrateull.TabIndex = 54
    Me.Labbadrateull.Text = "不良率超下限"
    Me.Labbadrateull.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'DGjt
    '
    Me.DGjt.AllowUserToAddRows = False
    Me.DGjt.AllowUserToDeleteRows = False
    Me.DGjt.AllowUserToOrderColumns = True
    Me.DGjt.AllowUserToResizeRows = False
    DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.DGjt.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
    Me.DGjt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DGjt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DGjt.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DGjt.Location = New System.Drawing.Point(0, 135)
    Me.DGjt.MultiSelect = False
    Me.DGjt.Name = "DGjt"
    Me.DGjt.ReadOnly = True
    Me.DGjt.RowTemplate.Height = 23
    Me.DGjt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DGjt.Size = New System.Drawing.Size(895, 346)
    Me.DGjt.TabIndex = 5
    '
    'LabAccumulationull
    '
    Me.LabAccumulationull.AutoSize = True
    Me.LabAccumulationull.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabAccumulationull.Location = New System.Drawing.Point(629, 72)
    Me.LabAccumulationull.Name = "LabAccumulationull"
    Me.LabAccumulationull.Size = New System.Drawing.Size(87, 20)
    Me.LabAccumulationull.TabIndex = 43
    Me.LabAccumulationull.Text = "WIP超下限"
    Me.LabAccumulationull.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Lablowerlimit
    '
    Me.Lablowerlimit.AutoSize = True
    Me.Lablowerlimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Lablowerlimit.Location = New System.Drawing.Point(235, 102)
    Me.Lablowerlimit.Name = "Lablowerlimit"
    Me.Lablowerlimit.Size = New System.Drawing.Size(41, 20)
    Me.Lablowerlimit.TabIndex = 41
    Me.Lablowerlimit.Text = "下限"
    Me.Lablowerlimit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LabProductivity
    '
    Me.LabProductivity.AutoSize = True
    Me.LabProductivity.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabProductivity.Location = New System.Drawing.Point(33, 72)
    Me.LabProductivity.Name = "LabProductivity"
    Me.LabProductivity.Size = New System.Drawing.Size(73, 20)
    Me.LabProductivity.TabIndex = 2
    Me.LabProductivity.Text = "產能標準"
    Me.LabProductivity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.Label7)
    Me.Panel1.Controls.Add(Me.Label6)
    Me.Panel1.Controls.Add(Me.Label5)
    Me.Panel1.Controls.Add(Me.Label4)
    Me.Panel1.Controls.Add(Me.TJAB10)
    Me.Panel1.Controls.Add(Me.Label3)
    Me.Panel1.Controls.Add(Me.SPEC)
    Me.Panel1.Controls.Add(Me.Label38)
    Me.Panel1.Controls.Add(Me.Btnproduct)
    Me.Panel1.Controls.Add(Me.Txtwuliao)
    Me.Panel1.Controls.Add(Me.numdjx)
    Me.Panel1.Controls.Add(Me.numgongshix)
    Me.Panel1.Controls.Add(Me.numgongshicx)
    Me.Panel1.Controls.Add(Me.numdjcx)
    Me.Panel1.Controls.Add(Me.Numblx)
    Me.Panel1.Controls.Add(Me.Numblcx)
    Me.Panel1.Controls.Add(Me.Labbadratell)
    Me.Panel1.Controls.Add(Me.cmbgx)
    Me.Panel1.Controls.Add(Me.LabUltralowerlimit)
    Me.Panel1.Controls.Add(Me.LabProductivity)
    Me.Panel1.Controls.Add(Me.numgongshi)
    Me.Panel1.Controls.Add(Me.Labbadrateull)
    Me.Panel1.Controls.Add(Me.Label1)
    Me.Panel1.Controls.Add(Me.Lablowerlimit)
    Me.Panel1.Controls.Add(Me.LabProcess)
    Me.Panel1.Controls.Add(Me.LabMaterial)
    Me.Panel1.Controls.Add(Me.Label2)
    Me.Panel1.Controls.Add(Me.LabAccumulationll)
    Me.Panel1.Controls.Add(Me.LabAccumulationull)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(895, 135)
    Me.Panel1.TabIndex = 4
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(576, 102)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(23, 20)
    Me.Label3.TabIndex = 67
    Me.Label3.Text = "%"
    '
    'SPEC
    '
    Me.SPEC.AutoSize = True
    Me.SPEC.Location = New System.Drawing.Point(106, 40)
    Me.SPEC.Name = "SPEC"
    Me.SPEC.Size = New System.Drawing.Size(0, 20)
    Me.SPEC.TabIndex = 66
    '
    'Label38
    '
    Me.Label38.AutoSize = True
    Me.Label38.Location = New System.Drawing.Point(65, 40)
    Me.Label38.Name = "Label38"
    Me.Label38.Size = New System.Drawing.Size(41, 20)
    Me.Label38.TabIndex = 65
    Me.Label38.Text = "說明"
    '
    'Btnproduct
    '
    Me.Btnproduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Btnproduct.Location = New System.Drawing.Point(280, 11)
    Me.Btnproduct.Name = "Btnproduct"
    Me.Btnproduct.Size = New System.Drawing.Size(32, 23)
    Me.Btnproduct.TabIndex = 64
    Me.Btnproduct.Text = "..."
    Me.Btnproduct.UseVisualStyleBackColor = True
    '
    'Txtwuliao
    '
    Me.Txtwuliao.BackColor = System.Drawing.Color.AntiqueWhite
    Me.Txtwuliao.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Txtwuliao.Location = New System.Drawing.Point(111, 9)
    Me.Txtwuliao.Name = "Txtwuliao"
    Me.Txtwuliao.Size = New System.Drawing.Size(168, 26)
    Me.Txtwuliao.TabIndex = 63
    '
    'numdjx
    '
    Me.numdjx.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.numdjx.Location = New System.Drawing.Point(723, 99)
    Me.numdjx.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
    Me.numdjx.Name = "numdjx"
    Me.numdjx.Size = New System.Drawing.Size(70, 26)
    Me.numdjx.TabIndex = 8
    '
    'numgongshix
    '
    Me.numgongshix.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.numgongshix.Location = New System.Drawing.Point(280, 99)
    Me.numgongshix.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
    Me.numgongshix.Name = "numgongshix"
    Me.numgongshix.Size = New System.Drawing.Size(68, 26)
    Me.numgongshix.TabIndex = 4
    '
    'numgongshicx
    '
    Me.numgongshicx.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.numgongshicx.Location = New System.Drawing.Point(280, 69)
    Me.numgongshicx.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
    Me.numgongshicx.Name = "numgongshicx"
    Me.numgongshicx.Size = New System.Drawing.Size(68, 26)
    Me.numgongshicx.TabIndex = 3
    '
    'numdjcx
    '
    Me.numdjcx.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.numdjcx.Location = New System.Drawing.Point(723, 69)
    Me.numdjcx.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
    Me.numdjcx.Name = "numdjcx"
    Me.numdjcx.Size = New System.Drawing.Size(70, 26)
    Me.numdjcx.TabIndex = 7
    '
    'Numblx
    '
    Me.Numblx.DecimalPlaces = 2
    Me.Numblx.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Numblx.Location = New System.Drawing.Point(503, 99)
    Me.Numblx.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
    Me.Numblx.Name = "Numblx"
    Me.Numblx.Size = New System.Drawing.Size(67, 26)
    Me.Numblx.TabIndex = 6
    '
    'Numblcx
    '
    Me.Numblcx.DecimalPlaces = 2
    Me.Numblcx.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Numblcx.Location = New System.Drawing.Point(503, 69)
    Me.Numblcx.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
    Me.Numblcx.Name = "Numblcx"
    Me.Numblcx.Size = New System.Drawing.Size(67, 26)
    Me.Numblcx.TabIndex = 5
    '
    'cmbgx
    '
    Me.cmbgx.BackColor = System.Drawing.Color.AntiqueWhite
    Me.cmbgx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cmbgx.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cmbgx.FormattingEnabled = True
    Me.cmbgx.Items.AddRange(New Object() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "W"})
    Me.cmbgx.Location = New System.Drawing.Point(386, 8)
    Me.cmbgx.Name = "cmbgx"
    Me.cmbgx.Size = New System.Drawing.Size(406, 28)
    Me.cmbgx.TabIndex = 1
    '
    'numgongshi
    '
    Me.numgongshi.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.numgongshi.Location = New System.Drawing.Point(111, 69)
    Me.numgongshi.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
    Me.numgongshi.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
    Me.numgongshi.Name = "numgongshi"
    Me.numgongshi.Size = New System.Drawing.Size(58, 26)
    Me.numgongshi.TabIndex = 2
    Me.numgongshi.Value = New Decimal(New Integer() {1, 0, 0, 0})
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(167, 72)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(25, 20)
    Me.Label1.TabIndex = 62
    Me.Label1.Text = "/H"
    '
    'LabProcess
    '
    Me.LabProcess.AutoSize = True
    Me.LabProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabProcess.Location = New System.Drawing.Point(343, 12)
    Me.LabProcess.Name = "LabProcess"
    Me.LabProcess.Size = New System.Drawing.Size(41, 20)
    Me.LabProcess.TabIndex = 44
    Me.LabProcess.Text = "工序"
    Me.LabProcess.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LabMaterial
    '
    Me.LabMaterial.AutoSize = True
    Me.LabMaterial.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabMaterial.Location = New System.Drawing.Point(33, 12)
    Me.LabMaterial.Name = "LabMaterial"
    Me.LabMaterial.Size = New System.Drawing.Size(73, 20)
    Me.LabMaterial.TabIndex = 44
    Me.LabMaterial.Text = "物料編號"
    Me.LabMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(576, 72)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(23, 20)
    Me.Label2.TabIndex = 62
    Me.Label2.Text = "%"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(33, 102)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(73, 20)
    Me.Label4.TabIndex = 68
    Me.Label4.Text = "標準編制"
    Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TJAB10
    '
    Me.TJAB10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TJAB10.Location = New System.Drawing.Point(111, 99)
    Me.TJAB10.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
    Me.TJAB10.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
    Me.TJAB10.Name = "TJAB10"
    Me.TJAB10.Size = New System.Drawing.Size(58, 26)
    Me.TJAB10.TabIndex = 69
    Me.TJAB10.Value = New Decimal(New Integer() {1, 0, 0, 0})
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(167, 102)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(25, 20)
    Me.Label5.TabIndex = 70
    Me.Label5.Text = "人"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(347, 72)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(25, 20)
    Me.Label6.TabIndex = 71
    Me.Label6.Text = "/H"
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(347, 102)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(25, 20)
    Me.Label7.TabIndex = 72
    Me.Label7.Text = "/H"
    '
    'PM0311
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(895, 481)
    Me.ControlBox = False
    Me.Controls.Add(Me.DGjt)
    Me.Controls.Add(Me.Panel1)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Name = "PM0311"
    Me.Text = "工序效能設定0311"
    Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
    CType(Me.DGjt, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    CType(Me.numdjx, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.numgongshix, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.numgongshicx, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.numdjcx, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.Numblx, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.Numblcx, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.numgongshi, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.TJAB10, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Labbadratell As System.Windows.Forms.Label
  Friend WithEvents LabAccumulationll As System.Windows.Forms.Label
  Friend WithEvents LabUltralowerlimit As System.Windows.Forms.Label
  Friend WithEvents Labbadrateull As System.Windows.Forms.Label
  Friend WithEvents DGjt As System.Windows.Forms.DataGridView
  Friend WithEvents LabAccumulationull As System.Windows.Forms.Label
  Friend WithEvents Lablowerlimit As System.Windows.Forms.Label
  Friend WithEvents LabProductivity As System.Windows.Forms.Label
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents LabMaterial As System.Windows.Forms.Label
  Friend WithEvents cmbgx As System.Windows.Forms.ComboBox
  Friend WithEvents LabProcess As System.Windows.Forms.Label
  Friend WithEvents Numblcx As System.Windows.Forms.NumericUpDown
  Friend WithEvents numdjx As System.Windows.Forms.NumericUpDown
  Friend WithEvents numdjcx As System.Windows.Forms.NumericUpDown
  Friend WithEvents Numblx As System.Windows.Forms.NumericUpDown
  Friend WithEvents numgongshicx As System.Windows.Forms.NumericUpDown
  Friend WithEvents numgongshi As System.Windows.Forms.NumericUpDown
  Friend WithEvents numgongshix As System.Windows.Forms.NumericUpDown
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Txtwuliao As System.Windows.Forms.TextBox
  Friend WithEvents Btnproduct As System.Windows.Forms.Button
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents SPEC As System.Windows.Forms.Label
  Friend WithEvents Label38 As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TJAB10 As System.Windows.Forms.NumericUpDown
End Class
