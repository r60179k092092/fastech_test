<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PM0302
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
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.TxtN = New System.Windows.Forms.TextBox()
    Me.Txtprocessen = New System.Windows.Forms.TextBox()
    Me.Cmbdispose = New System.Windows.Forms.ComboBox()
    Me.Txtprocessch = New System.Windows.Forms.TextBox()
    Me.Cmbclass = New System.Windows.Forms.ComboBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Txtprocesscode = New System.Windows.Forms.TextBox()
    Me.LabBadtreatment = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Labenname = New System.Windows.Forms.Label()
    Me.Labprocesscode = New System.Windows.Forms.Label()
    Me.Labchname = New System.Windows.Forms.Label()
    Me.LabTestcategory = New System.Windows.Forms.Label()
    Me.DGGX = New System.Windows.Forms.DataGridView()
    Me.Panel1.SuspendLayout()
    CType(Me.DGGX, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.TxtN)
    Me.Panel1.Controls.Add(Me.Txtprocessen)
    Me.Panel1.Controls.Add(Me.Cmbdispose)
    Me.Panel1.Controls.Add(Me.Txtprocessch)
    Me.Panel1.Controls.Add(Me.Cmbclass)
    Me.Panel1.Controls.Add(Me.Label4)
    Me.Panel1.Controls.Add(Me.Txtprocesscode)
    Me.Panel1.Controls.Add(Me.LabBadtreatment)
    Me.Panel1.Controls.Add(Me.Label7)
    Me.Panel1.Controls.Add(Me.Labenname)
    Me.Panel1.Controls.Add(Me.Labprocesscode)
    Me.Panel1.Controls.Add(Me.Labchname)
    Me.Panel1.Controls.Add(Me.LabTestcategory)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(865, 139)
    Me.Panel1.TabIndex = 1
    '
    'TxtN
    '
    Me.TxtN.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtN.Location = New System.Drawing.Point(344, 38)
    Me.TxtN.Name = "TxtN"
    Me.TxtN.Size = New System.Drawing.Size(41, 26)
    Me.TxtN.TabIndex = 4
    Me.TxtN.Text = "1"
    '
    'Txtprocessen
    '
    Me.Txtprocessen.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Txtprocessen.Location = New System.Drawing.Point(121, 105)
    Me.Txtprocessen.Name = "Txtprocessen"
    Me.Txtprocessen.Size = New System.Drawing.Size(447, 26)
    Me.Txtprocessen.TabIndex = 6
    '
    'Cmbdispose
    '
    Me.Cmbdispose.BackColor = System.Drawing.Color.AntiqueWhite
    Me.Cmbdispose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.Cmbdispose.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Cmbdispose.FormattingEnabled = True
    Me.Cmbdispose.Items.AddRange(New Object() {"整線返工", "整批返工", "退nPCS返工", "挑選返工", "退至上次檢驗良品"})
    Me.Cmbdispose.Location = New System.Drawing.Point(121, 39)
    Me.Cmbdispose.Name = "Cmbdispose"
    Me.Cmbdispose.Size = New System.Drawing.Size(146, 24)
    Me.Cmbdispose.TabIndex = 3
    '
    'Txtprocessch
    '
    Me.Txtprocessch.BackColor = System.Drawing.Color.AntiqueWhite
    Me.Txtprocessch.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Txtprocessch.Location = New System.Drawing.Point(121, 71)
    Me.Txtprocessch.Name = "Txtprocessch"
    Me.Txtprocessch.Size = New System.Drawing.Size(447, 26)
    Me.Txtprocessch.TabIndex = 5
    '
    'Cmbclass
    '
    Me.Cmbclass.AutoCompleteCustomSource.AddRange(New String() {"100%", "S1", "S2", "S3", "S4", "L1", "L2", "L3", "STS", "AFM"})
    Me.Cmbclass.BackColor = System.Drawing.Color.AntiqueWhite
    Me.Cmbclass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.Cmbclass.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Cmbclass.FormattingEnabled = True
    Me.Cmbclass.Items.AddRange(New Object() {"100%", "100%x2", "100%xWG", "100%xAUTO", "INSP", "S1", "S2", "S3", "S4", "L1", "L2", "L3", "FreeMode", "STS", "AFM"})
    Me.Cmbclass.Location = New System.Drawing.Point(344, 6)
    Me.Cmbclass.Name = "Cmbclass"
    Me.Cmbclass.Size = New System.Drawing.Size(118, 24)
    Me.Cmbclass.TabIndex = 1
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(386, 43)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(32, 16)
    Me.Label4.TabIndex = 39
    Me.Label4.Text = "PCS"
    '
    'Txtprocesscode
    '
    Me.Txtprocesscode.BackColor = System.Drawing.Color.AntiqueWhite
    Me.Txtprocesscode.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Txtprocesscode.Location = New System.Drawing.Point(121, 5)
    Me.Txtprocesscode.Name = "Txtprocesscode"
    Me.Txtprocesscode.Size = New System.Drawing.Size(90, 26)
    Me.Txtprocesscode.TabIndex = 0
    '
    'LabBadtreatment
    '
    Me.LabBadtreatment.AutoSize = True
    Me.LabBadtreatment.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabBadtreatment.Location = New System.Drawing.Point(47, 43)
    Me.LabBadtreatment.Name = "LabBadtreatment"
    Me.LabBadtreatment.Size = New System.Drawing.Size(72, 16)
    Me.LabBadtreatment.TabIndex = 35
    Me.LabBadtreatment.Text = "不良處理"
    Me.LabBadtreatment.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(313, 43)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(24, 16)
    Me.Label7.TabIndex = 37
    Me.Label7.Text = "N="
    '
    'Labenname
    '
    Me.Labenname.AutoSize = True
    Me.Labenname.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Labenname.Location = New System.Drawing.Point(47, 110)
    Me.Labenname.Name = "Labenname"
    Me.Labenname.Size = New System.Drawing.Size(72, 16)
    Me.Labenname.TabIndex = 13
    Me.Labenname.Text = "英文名稱"
    Me.Labenname.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Labprocesscode
    '
    Me.Labprocesscode.AutoSize = True
    Me.Labprocesscode.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Labprocesscode.Location = New System.Drawing.Point(47, 10)
    Me.Labprocesscode.Name = "Labprocesscode"
    Me.Labprocesscode.Size = New System.Drawing.Size(72, 16)
    Me.Labprocesscode.TabIndex = 9
    Me.Labprocesscode.Text = "工序編號"
    Me.Labprocesscode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Labchname
    '
    Me.Labchname.AutoSize = True
    Me.Labchname.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Labchname.Location = New System.Drawing.Point(47, 76)
    Me.Labchname.Name = "Labchname"
    Me.Labchname.Size = New System.Drawing.Size(72, 16)
    Me.Labchname.TabIndex = 8
    Me.Labchname.Text = "中文名稱"
    Me.Labchname.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LabTestcategory
    '
    Me.LabTestcategory.AutoSize = True
    Me.LabTestcategory.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabTestcategory.Location = New System.Drawing.Point(265, 10)
    Me.LabTestcategory.Name = "LabTestcategory"
    Me.LabTestcategory.Size = New System.Drawing.Size(72, 16)
    Me.LabTestcategory.TabIndex = 7
    Me.LabTestcategory.Text = "檢驗類別"
    Me.LabTestcategory.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'DGGX
    '
    Me.DGGX.AllowUserToAddRows = False
    Me.DGGX.AllowUserToDeleteRows = False
    Me.DGGX.AllowUserToOrderColumns = True
    Me.DGGX.AllowUserToResizeRows = False
    DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.DGGX.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
    Me.DGGX.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DGGX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DGGX.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DGGX.Location = New System.Drawing.Point(0, 139)
    Me.DGGX.MultiSelect = False
    Me.DGGX.Name = "DGGX"
    Me.DGGX.ReadOnly = True
    Me.DGGX.RowTemplate.Height = 23
    Me.DGGX.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DGGX.Size = New System.Drawing.Size(865, 425)
    Me.DGGX.TabIndex = 2
    '
    'PM0302
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(865, 564)
    Me.Controls.Add(Me.DGGX)
    Me.Controls.Add(Me.Panel1)
    Me.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Name = "PM0302"
    Me.Text = "工序資料信息0302"
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    CType(Me.DGGX, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtN As System.Windows.Forms.TextBox
    Friend WithEvents Txtprocessen As System.Windows.Forms.TextBox
    Friend WithEvents Cmbdispose As System.Windows.Forms.ComboBox
  Friend WithEvents Txtprocessch As System.Windows.Forms.TextBox
  Friend WithEvents Cmbclass As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Txtprocesscode As System.Windows.Forms.TextBox
    Friend WithEvents LabBadtreatment As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Labenname As System.Windows.Forms.Label
    Friend WithEvents Labprocesscode As System.Windows.Forms.Label
    Friend WithEvents Labchname As System.Windows.Forms.Label
    Friend WithEvents LabTestcategory As System.Windows.Forms.Label
    Friend WithEvents DGGX As System.Windows.Forms.DataGridView
End Class
