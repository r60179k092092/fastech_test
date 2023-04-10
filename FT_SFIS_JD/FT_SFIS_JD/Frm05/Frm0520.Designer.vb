<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm0520
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
    Me.btnQuit = New System.Windows.Forms.Button()
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.btnClear = New System.Windows.Forms.Button()
    Me.btnSrch = New System.Windows.Forms.Button()
    Me.lbSPEC = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.lbMRP_NO = New System.Windows.Forms.Label()
    Me.lbMF_NO = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.txtMO_NO = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.cbGX = New System.Windows.Forms.ComboBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TabPage1 = New System.Windows.Forms.TabPage()
    Me.DG = New System.Windows.Forms.DataGridView()
    Me.TabPage2 = New System.Windows.Forms.TabPage()
    Me.DGMO = New System.Windows.Forms.DataGridView()
    Me.Panel2 = New System.Windows.Forms.Panel()
    Me.btnSrchMO = New System.Windows.Forms.Button()
    Me.txtSrchMO = New System.Windows.Forms.TextBox()
    Me.btnDCEXL = New System.Windows.Forms.Button()
    Me.Panel1.SuspendLayout()
    Me.TabControl1.SuspendLayout()
    Me.TabPage1.SuspendLayout()
    CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.TabPage2.SuspendLayout()
    CType(Me.DGMO, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Panel2.SuspendLayout()
    Me.SuspendLayout()
    '
    'btnQuit
    '
    Me.btnQuit.Location = New System.Drawing.Point(782, 3)
    Me.btnQuit.Name = "btnQuit"
    Me.btnQuit.Size = New System.Drawing.Size(126, 46)
    Me.btnQuit.TabIndex = 3
    Me.btnQuit.Text = "離開"
    Me.btnQuit.UseVisualStyleBackColor = True
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.btnDCEXL)
    Me.Panel1.Controls.Add(Me.btnClear)
    Me.Panel1.Controls.Add(Me.btnSrch)
    Me.Panel1.Controls.Add(Me.lbSPEC)
    Me.Panel1.Controls.Add(Me.Label6)
    Me.Panel1.Controls.Add(Me.lbMRP_NO)
    Me.Panel1.Controls.Add(Me.lbMF_NO)
    Me.Panel1.Controls.Add(Me.Label4)
    Me.Panel1.Controls.Add(Me.txtMO_NO)
    Me.Panel1.Controls.Add(Me.Label3)
    Me.Panel1.Controls.Add(Me.Label2)
    Me.Panel1.Controls.Add(Me.cbGX)
    Me.Panel1.Controls.Add(Me.Label1)
    Me.Panel1.Controls.Add(Me.btnQuit)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Location = New System.Drawing.Point(3, 3)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(954, 113)
    Me.Panel1.TabIndex = 28
    '
    'btnClear
    '
    Me.btnClear.Location = New System.Drawing.Point(602, 55)
    Me.btnClear.Name = "btnClear"
    Me.btnClear.Size = New System.Drawing.Size(126, 46)
    Me.btnClear.TabIndex = 40
    Me.btnClear.Text = "清空"
    Me.btnClear.UseVisualStyleBackColor = True
    '
    'btnSrch
    '
    Me.btnSrch.Location = New System.Drawing.Point(602, 3)
    Me.btnSrch.Name = "btnSrch"
    Me.btnSrch.Size = New System.Drawing.Size(126, 46)
    Me.btnSrch.TabIndex = 2
    Me.btnSrch.Text = "尋找"
    Me.btnSrch.UseVisualStyleBackColor = True
    '
    'lbSPEC
    '
    Me.lbSPEC.AutoSize = True
    Me.lbSPEC.BackColor = System.Drawing.Color.AntiqueWhite
    Me.lbSPEC.Location = New System.Drawing.Point(78, 81)
    Me.lbSPEC.Name = "lbSPEC"
    Me.lbSPEC.Size = New System.Drawing.Size(0, 16)
    Me.lbSPEC.TabIndex = 39
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(3, 80)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(72, 16)
    Me.Label6.TabIndex = 38
    Me.Label6.Text = "品名規格"
    '
    'lbMRP_NO
    '
    Me.lbMRP_NO.AutoSize = True
    Me.lbMRP_NO.BackColor = System.Drawing.Color.AntiqueWhite
    Me.lbMRP_NO.Location = New System.Drawing.Point(315, 48)
    Me.lbMRP_NO.Name = "lbMRP_NO"
    Me.lbMRP_NO.Size = New System.Drawing.Size(0, 16)
    Me.lbMRP_NO.TabIndex = 37
    '
    'lbMF_NO
    '
    Me.lbMF_NO.AutoSize = True
    Me.lbMF_NO.BackColor = System.Drawing.Color.AntiqueWhite
    Me.lbMF_NO.Location = New System.Drawing.Point(78, 48)
    Me.lbMF_NO.Name = "lbMF_NO"
    Me.lbMF_NO.Size = New System.Drawing.Size(0, 16)
    Me.lbMF_NO.TabIndex = 36
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(3, 48)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(72, 16)
    Me.Label4.TabIndex = 35
    Me.Label4.Text = "製令單號"
    '
    'txtMO_NO
    '
    Me.txtMO_NO.BackColor = System.Drawing.Color.WhiteSmoke
    Me.txtMO_NO.Location = New System.Drawing.Point(78, 11)
    Me.txtMO_NO.Name = "txtMO_NO"
    Me.txtMO_NO.Size = New System.Drawing.Size(160, 27)
    Me.txtMO_NO.TabIndex = 0
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(270, 48)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(40, 16)
    Me.Label3.TabIndex = 32
    Me.Label3.Text = "料號"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(3, 16)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(72, 16)
    Me.Label2.TabIndex = 30
    Me.Label2.Text = "工單編號"
    '
    'cbGX
    '
    Me.cbGX.BackColor = System.Drawing.Color.WhiteSmoke
    Me.cbGX.FormattingEnabled = True
    Me.cbGX.Location = New System.Drawing.Point(315, 12)
    Me.cbGX.Name = "cbGX"
    Me.cbGX.Size = New System.Drawing.Size(190, 24)
    Me.cbGX.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(270, 16)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(40, 16)
    Me.Label1.TabIndex = 28
    Me.Label1.Text = "工序"
    '
    'TabControl1
    '
    Me.TabControl1.Controls.Add(Me.TabPage1)
    Me.TabControl1.Controls.Add(Me.TabPage2)
    Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TabControl1.Location = New System.Drawing.Point(0, 0)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(968, 589)
    Me.TabControl1.TabIndex = 30
    '
    'TabPage1
    '
    Me.TabPage1.Controls.Add(Me.DG)
    Me.TabPage1.Controls.Add(Me.Panel1)
    Me.TabPage1.Location = New System.Drawing.Point(4, 26)
    Me.TabPage1.Name = "TabPage1"
    Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage1.Size = New System.Drawing.Size(960, 559)
    Me.TabPage1.TabIndex = 0
    Me.TabPage1.Text = "燈具測試數據表"
    Me.TabPage1.UseVisualStyleBackColor = True
    '
    'DG
    '
    Me.DG.AllowUserToAddRows = False
    Me.DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DG.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DG.Location = New System.Drawing.Point(3, 116)
    Me.DG.Name = "DG"
    Me.DG.ReadOnly = True
    Me.DG.RowTemplate.Height = 24
    Me.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DG.Size = New System.Drawing.Size(954, 440)
    Me.DG.TabIndex = 30
    '
    'TabPage2
    '
    Me.TabPage2.Controls.Add(Me.DGMO)
    Me.TabPage2.Controls.Add(Me.Panel2)
    Me.TabPage2.Location = New System.Drawing.Point(4, 26)
    Me.TabPage2.Name = "TabPage2"
    Me.TabPage2.Size = New System.Drawing.Size(960, 559)
    Me.TabPage2.TabIndex = 1
    Me.TabPage2.Text = "工單資料"
    Me.TabPage2.UseVisualStyleBackColor = True
    '
    'DGMO
    '
    Me.DGMO.AllowUserToAddRows = False
    Me.DGMO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DGMO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DGMO.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DGMO.Location = New System.Drawing.Point(0, 73)
    Me.DGMO.Name = "DGMO"
    Me.DGMO.ReadOnly = True
    Me.DGMO.RowTemplate.Height = 24
    Me.DGMO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DGMO.Size = New System.Drawing.Size(960, 486)
    Me.DGMO.TabIndex = 1
    '
    'Panel2
    '
    Me.Panel2.Controls.Add(Me.btnSrchMO)
    Me.Panel2.Controls.Add(Me.txtSrchMO)
    Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel2.Location = New System.Drawing.Point(0, 0)
    Me.Panel2.Name = "Panel2"
    Me.Panel2.Size = New System.Drawing.Size(960, 73)
    Me.Panel2.TabIndex = 0
    '
    'btnSrchMO
    '
    Me.btnSrchMO.Location = New System.Drawing.Point(284, 17)
    Me.btnSrchMO.Name = "btnSrchMO"
    Me.btnSrchMO.Size = New System.Drawing.Size(119, 43)
    Me.btnSrchMO.TabIndex = 1
    Me.btnSrchMO.Text = "工單尋找"
    Me.btnSrchMO.UseVisualStyleBackColor = True
    '
    'txtSrchMO
    '
    Me.txtSrchMO.BackColor = System.Drawing.Color.Beige
    Me.txtSrchMO.Location = New System.Drawing.Point(26, 27)
    Me.txtSrchMO.Name = "txtSrchMO"
    Me.txtSrchMO.Size = New System.Drawing.Size(231, 27)
    Me.txtSrchMO.TabIndex = 0
    '
    'btnDCEXL
    '
    Me.btnDCEXL.Location = New System.Drawing.Point(782, 55)
    Me.btnDCEXL.Name = "btnDCEXL"
    Me.btnDCEXL.Size = New System.Drawing.Size(126, 46)
    Me.btnDCEXL.TabIndex = 41
    Me.btnDCEXL.Text = "導出Excel檔案"
    Me.btnDCEXL.UseVisualStyleBackColor = True
    '
    'Frm0520
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(968, 589)
    Me.Controls.Add(Me.TabControl1)
    Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Name = "Frm0520"
    Me.Text = "燈具測試數據紀錄表"
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.TabControl1.ResumeLayout(False)
    Me.TabPage1.ResumeLayout(False)
    CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
    Me.TabPage2.ResumeLayout(False)
    CType(Me.DGMO, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Panel2.ResumeLayout(False)
    Me.Panel2.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents btnQuit As System.Windows.Forms.Button
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents cbGX As System.Windows.Forms.ComboBox
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents txtMO_NO As System.Windows.Forms.TextBox
  Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
  Friend WithEvents DGMO As System.Windows.Forms.DataGridView
  Friend WithEvents Panel2 As System.Windows.Forms.Panel
  Friend WithEvents btnSrchMO As System.Windows.Forms.Button
  Friend WithEvents txtSrchMO As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents lbSPEC As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents lbMRP_NO As System.Windows.Forms.Label
  Friend WithEvents lbMF_NO As System.Windows.Forms.Label
  Friend WithEvents btnSrch As System.Windows.Forms.Button
  Friend WithEvents btnClear As System.Windows.Forms.Button
  Friend WithEvents DG As System.Windows.Forms.DataGridView
  Friend WithEvents btnDCEXL As System.Windows.Forms.Button
End Class
