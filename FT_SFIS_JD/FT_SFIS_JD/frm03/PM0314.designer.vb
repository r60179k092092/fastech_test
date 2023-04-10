<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PM0314
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
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.Cmblevel = New System.Windows.Forms.ComboBox()
    Me.Txtcode = New System.Windows.Forms.TextBox()
    Me.Txtaddress = New System.Windows.Forms.TextBox()
    Me.Txtcontacts = New System.Windows.Forms.TextBox()
    Me.Txtfax = New System.Windows.Forms.TextBox()
    Me.Txtphone = New System.Windows.Forms.TextBox()
    Me.Txtallname = New System.Windows.Forms.TextBox()
    Me.Txtname = New System.Windows.Forms.TextBox()
    Me.Labchecklevel = New System.Windows.Forms.Label()
    Me.Labaddress = New System.Windows.Forms.Label()
    Me.Txtshortname = New System.Windows.Forms.TextBox()
    Me.Labsupplierren = New System.Windows.Forms.Label()
    Me.Labsuppliername = New System.Windows.Forms.Label()
    Me.Labfax = New System.Windows.Forms.Label()
    Me.Labtelephone = New System.Windows.Forms.Label()
    Me.Labsupplierallname = New System.Windows.Forms.Label()
    Me.Labsupplierid = New System.Windows.Forms.Label()
    Me.LabSuppliercode = New System.Windows.Forms.Label()
    Me.DGgys = New System.Windows.Forms.DataGridView()
    Me.Panel1.SuspendLayout()
    CType(Me.DGgys, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.Cmblevel)
    Me.Panel1.Controls.Add(Me.Txtcode)
    Me.Panel1.Controls.Add(Me.Txtaddress)
    Me.Panel1.Controls.Add(Me.Txtcontacts)
    Me.Panel1.Controls.Add(Me.Txtfax)
    Me.Panel1.Controls.Add(Me.Txtphone)
    Me.Panel1.Controls.Add(Me.Txtallname)
    Me.Panel1.Controls.Add(Me.Txtname)
    Me.Panel1.Controls.Add(Me.Labchecklevel)
    Me.Panel1.Controls.Add(Me.Labaddress)
    Me.Panel1.Controls.Add(Me.Txtshortname)
    Me.Panel1.Controls.Add(Me.Labsupplierren)
    Me.Panel1.Controls.Add(Me.Labsuppliername)
    Me.Panel1.Controls.Add(Me.Labfax)
    Me.Panel1.Controls.Add(Me.Labtelephone)
    Me.Panel1.Controls.Add(Me.Labsupplierallname)
    Me.Panel1.Controls.Add(Me.Labsupplierid)
    Me.Panel1.Controls.Add(Me.LabSuppliercode)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(1192, 129)
    Me.Panel1.TabIndex = 1
    '
    'Cmblevel
    '
    Me.Cmblevel.BackColor = System.Drawing.Color.AntiqueWhite
    Me.Cmblevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.Cmblevel.ForeColor = System.Drawing.Color.Red
    Me.Cmblevel.FormattingEnabled = True
    Me.Cmblevel.Items.AddRange(New Object() {"減量", "標準", "加嚴", "免檢"})
    Me.Cmblevel.Location = New System.Drawing.Point(706, 65)
    Me.Cmblevel.Name = "Cmblevel"
    Me.Cmblevel.Size = New System.Drawing.Size(182, 24)
    Me.Cmblevel.TabIndex = 9
    '
    'Txtcode
    '
    Me.Txtcode.BackColor = System.Drawing.Color.AntiqueWhite
    Me.Txtcode.ForeColor = System.Drawing.Color.Red
    Me.Txtcode.Location = New System.Drawing.Point(706, 4)
    Me.Txtcode.MaxLength = 1
    Me.Txtcode.Name = "Txtcode"
    Me.Txtcode.Size = New System.Drawing.Size(182, 26)
    Me.Txtcode.TabIndex = 3
    '
    'Txtaddress
    '
    Me.Txtaddress.BackColor = System.Drawing.SystemColors.ControlLightLight
    Me.Txtaddress.Location = New System.Drawing.Point(95, 94)
    Me.Txtaddress.MaxLength = 100
    Me.Txtaddress.Name = "Txtaddress"
    Me.Txtaddress.Size = New System.Drawing.Size(793, 26)
    Me.Txtaddress.TabIndex = 8
    '
    'Txtcontacts
    '
    Me.Txtcontacts.BackColor = System.Drawing.SystemColors.ControlLightLight
    Me.Txtcontacts.Location = New System.Drawing.Point(95, 34)
    Me.Txtcontacts.MaxLength = 50
    Me.Txtcontacts.Name = "Txtcontacts"
    Me.Txtcontacts.Size = New System.Drawing.Size(182, 26)
    Me.Txtcontacts.TabIndex = 4
    '
    'Txtfax
    '
    Me.Txtfax.BackColor = System.Drawing.SystemColors.ControlLightLight
    Me.Txtfax.Location = New System.Drawing.Point(706, 34)
    Me.Txtfax.MaxLength = 50
    Me.Txtfax.Name = "Txtfax"
    Me.Txtfax.Size = New System.Drawing.Size(182, 26)
    Me.Txtfax.TabIndex = 6
    '
    'Txtphone
    '
    Me.Txtphone.BackColor = System.Drawing.SystemColors.ControlLightLight
    Me.Txtphone.Location = New System.Drawing.Point(391, 34)
    Me.Txtphone.MaxLength = 50
    Me.Txtphone.Name = "Txtphone"
    Me.Txtphone.Size = New System.Drawing.Size(197, 26)
    Me.Txtphone.TabIndex = 5
    '
    'Txtallname
    '
    Me.Txtallname.BackColor = System.Drawing.Color.AntiqueWhite
    Me.Txtallname.ForeColor = System.Drawing.Color.Red
    Me.Txtallname.Location = New System.Drawing.Point(95, 64)
    Me.Txtallname.MaxLength = 100
    Me.Txtallname.Name = "Txtallname"
    Me.Txtallname.Size = New System.Drawing.Size(493, 26)
    Me.Txtallname.TabIndex = 7
    '
    'Txtname
    '
    Me.Txtname.BackColor = System.Drawing.Color.AntiqueWhite
    Me.Txtname.ForeColor = System.Drawing.Color.Red
    Me.Txtname.Location = New System.Drawing.Point(96, 4)
    Me.Txtname.MaxLength = 8
    Me.Txtname.Name = "Txtname"
    Me.Txtname.Size = New System.Drawing.Size(182, 26)
    Me.Txtname.TabIndex = 1
    '
    'Labchecklevel
    '
    Me.Labchecklevel.AutoSize = True
    Me.Labchecklevel.Location = New System.Drawing.Point(628, 69)
    Me.Labchecklevel.Name = "Labchecklevel"
    Me.Labchecklevel.Size = New System.Drawing.Size(72, 16)
    Me.Labchecklevel.TabIndex = 6
    Me.Labchecklevel.Text = "檢驗等級"
    Me.Labchecklevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Labaddress
    '
    Me.Labaddress.AutoSize = True
    Me.Labaddress.Location = New System.Drawing.Point(51, 99)
    Me.Labaddress.Name = "Labaddress"
    Me.Labaddress.Size = New System.Drawing.Size(40, 16)
    Me.Labaddress.TabIndex = 6
    Me.Labaddress.Text = "地址"
    Me.Labaddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Txtshortname
    '
    Me.Txtshortname.BackColor = System.Drawing.SystemColors.ControlLightLight
    Me.Txtshortname.Location = New System.Drawing.Point(391, 4)
    Me.Txtshortname.MaxLength = 20
    Me.Txtshortname.Name = "Txtshortname"
    Me.Txtshortname.Size = New System.Drawing.Size(197, 26)
    Me.Txtshortname.TabIndex = 2
    '
    'Labsupplierren
    '
    Me.Labsupplierren.AutoSize = True
    Me.Labsupplierren.Location = New System.Drawing.Point(35, 39)
    Me.Labsupplierren.Name = "Labsupplierren"
    Me.Labsupplierren.Size = New System.Drawing.Size(56, 16)
    Me.Labsupplierren.TabIndex = 6
    Me.Labsupplierren.Text = "聯系人"
    Me.Labsupplierren.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Labsuppliername
    '
    Me.Labsuppliername.AutoSize = True
    Me.Labsuppliername.Location = New System.Drawing.Point(297, 9)
    Me.Labsuppliername.Name = "Labsuppliername"
    Me.Labsuppliername.Size = New System.Drawing.Size(88, 16)
    Me.Labsuppliername.TabIndex = 8
    Me.Labsuppliername.Text = "供應商簡稱"
    Me.Labsuppliername.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Labfax
    '
    Me.Labfax.AutoSize = True
    Me.Labfax.Location = New System.Drawing.Point(660, 39)
    Me.Labfax.Name = "Labfax"
    Me.Labfax.Size = New System.Drawing.Size(40, 16)
    Me.Labfax.TabIndex = 6
    Me.Labfax.Text = "傳真"
    Me.Labfax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Labtelephone
    '
    Me.Labtelephone.AutoSize = True
    Me.Labtelephone.Location = New System.Drawing.Point(345, 39)
    Me.Labtelephone.Name = "Labtelephone"
    Me.Labtelephone.Size = New System.Drawing.Size(40, 16)
    Me.Labtelephone.TabIndex = 6
    Me.Labtelephone.Text = "電話"
    Me.Labtelephone.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Labsupplierallname
    '
    Me.Labsupplierallname.AutoSize = True
    Me.Labsupplierallname.Location = New System.Drawing.Point(3, 69)
    Me.Labsupplierallname.Name = "Labsupplierallname"
    Me.Labsupplierallname.Size = New System.Drawing.Size(88, 16)
    Me.Labsupplierallname.TabIndex = 6
    Me.Labsupplierallname.Text = "供應商全名"
    Me.Labsupplierallname.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Labsupplierid
    '
    Me.Labsupplierid.AutoSize = True
    Me.Labsupplierid.Location = New System.Drawing.Point(3, 9)
    Me.Labsupplierid.Name = "Labsupplierid"
    Me.Labsupplierid.Size = New System.Drawing.Size(88, 16)
    Me.Labsupplierid.TabIndex = 6
    Me.Labsupplierid.Text = "供應商編號"
    Me.Labsupplierid.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LabSuppliercode
    '
    Me.LabSuppliercode.AutoSize = True
    Me.LabSuppliercode.Location = New System.Drawing.Point(596, 9)
    Me.LabSuppliercode.Name = "LabSuppliercode"
    Me.LabSuppliercode.Size = New System.Drawing.Size(104, 16)
    Me.LabSuppliercode.TabIndex = 6
    Me.LabSuppliercode.Text = "供應物料分類"
    Me.LabSuppliercode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'DGgys
    '
    Me.DGgys.AllowUserToAddRows = False
    Me.DGgys.AllowUserToDeleteRows = False
    Me.DGgys.AllowUserToOrderColumns = True
    Me.DGgys.AllowUserToResizeRows = False
    Me.DGgys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DGgys.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DGgys.Location = New System.Drawing.Point(0, 129)
    Me.DGgys.MultiSelect = False
    Me.DGgys.Name = "DGgys"
    Me.DGgys.ReadOnly = True
    Me.DGgys.RowTemplate.Height = 23
    Me.DGgys.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DGgys.Size = New System.Drawing.Size(1192, 436)
    Me.DGgys.TabIndex = 2
    '
    'PM0314
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(1192, 565)
    Me.Controls.Add(Me.DGgys)
    Me.Controls.Add(Me.Panel1)
    Me.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.KeyPreview = True
    Me.Name = "PM0314"
    Me.Text = "供應商管理0311"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    CType(Me.DGgys, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Txtcode As System.Windows.Forms.TextBox
  Friend WithEvents Txtaddress As System.Windows.Forms.TextBox
  Friend WithEvents Txtcontacts As System.Windows.Forms.TextBox
  Friend WithEvents Txtfax As System.Windows.Forms.TextBox
  Friend WithEvents Txtphone As System.Windows.Forms.TextBox
  Friend WithEvents Txtallname As System.Windows.Forms.TextBox
  Friend WithEvents Txtname As System.Windows.Forms.TextBox
  Friend WithEvents Labchecklevel As System.Windows.Forms.Label
  Friend WithEvents Labaddress As System.Windows.Forms.Label
  Friend WithEvents Txtshortname As System.Windows.Forms.TextBox
  Friend WithEvents Labsupplierren As System.Windows.Forms.Label
  Friend WithEvents Labsuppliername As System.Windows.Forms.Label
  Friend WithEvents Labfax As System.Windows.Forms.Label
  Friend WithEvents Labtelephone As System.Windows.Forms.Label
  Friend WithEvents Labsupplierallname As System.Windows.Forms.Label
  Friend WithEvents Labsupplierid As System.Windows.Forms.Label
  Friend WithEvents LabSuppliercode As System.Windows.Forms.Label
  Friend WithEvents DGgys As System.Windows.Forms.DataGridView
  Friend WithEvents Cmblevel As System.Windows.Forms.ComboBox
End Class
