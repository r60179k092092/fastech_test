<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PM0312
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
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.DG = New System.Windows.Forms.DataGridView()
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.Labrole = New System.Windows.Forms.Label()
    Me.TextBox3 = New System.Windows.Forms.TextBox()
    Me.TextBox2 = New System.Windows.Forms.TextBox()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.Labpwd = New System.Windows.Forms.Label()
    Me.Labusername = New System.Windows.Forms.Label()
    Me.Labuserid = New System.Windows.Forms.Label()
    Me.CLB = New System.Windows.Forms.CheckedListBox()
    CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Panel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'DG
    '
    Me.DG.AllowUserToAddRows = False
    Me.DG.AllowUserToDeleteRows = False
    DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.DG.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
    Me.DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DG.Dock = System.Windows.Forms.DockStyle.Left
    Me.DG.Location = New System.Drawing.Point(0, 0)
    Me.DG.Name = "DG"
    Me.DG.RowTemplate.Height = 24
    Me.DG.Size = New System.Drawing.Size(399, 364)
    Me.DG.TabIndex = 0
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.Labrole)
    Me.Panel1.Controls.Add(Me.TextBox3)
    Me.Panel1.Controls.Add(Me.TextBox2)
    Me.Panel1.Controls.Add(Me.TextBox1)
    Me.Panel1.Controls.Add(Me.Labpwd)
    Me.Panel1.Controls.Add(Me.Labusername)
    Me.Panel1.Controls.Add(Me.Labuserid)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Location = New System.Drawing.Point(399, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(564, 91)
    Me.Panel1.TabIndex = 1
    '
    'Labrole
    '
    Me.Labrole.AutoSize = True
    Me.Labrole.Location = New System.Drawing.Point(6, 69)
    Me.Labrole.Name = "Labrole"
    Me.Labrole.Size = New System.Drawing.Size(88, 16)
    Me.Labrole.TabIndex = 12
    Me.Labrole.Text = "所屬角色："
    Me.Labrole.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TextBox3
    '
    Me.TextBox3.BackColor = System.Drawing.Color.AntiqueWhite
    Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.TextBox3.Font = New System.Drawing.Font("黑体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox3.Location = New System.Drawing.Point(400, 3)
    Me.TextBox3.Name = "TextBox3"
    Me.TextBox3.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.TextBox3.Size = New System.Drawing.Size(230, 26)
    Me.TextBox3.TabIndex = 13
    Me.TextBox3.UseSystemPasswordChar = True
    '
    'TextBox2
    '
    Me.TextBox2.BackColor = System.Drawing.Color.AntiqueWhite
    Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.TextBox2.Font = New System.Drawing.Font("黑体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox2.Location = New System.Drawing.Point(81, 34)
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(158, 26)
    Me.TextBox2.TabIndex = 11
    '
    'TextBox1
    '
    Me.TextBox1.BackColor = System.Drawing.Color.AntiqueWhite
    Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.TextBox1.Font = New System.Drawing.Font("黑体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox1.Location = New System.Drawing.Point(81, 3)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(158, 26)
    Me.TextBox1.TabIndex = 10
    '
    'Labpwd
    '
    Me.Labpwd.AutoSize = True
    Me.Labpwd.Location = New System.Drawing.Point(323, 8)
    Me.Labpwd.Name = "Labpwd"
    Me.Labpwd.Size = New System.Drawing.Size(72, 16)
    Me.Labpwd.TabIndex = 9
    Me.Labpwd.Text = "用戶密碼"
    Me.Labpwd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Labusername
    '
    Me.Labusername.AutoSize = True
    Me.Labusername.Location = New System.Drawing.Point(6, 39)
    Me.Labusername.Name = "Labusername"
    Me.Labusername.Size = New System.Drawing.Size(72, 16)
    Me.Labusername.TabIndex = 8
    Me.Labusername.Text = "用戶姓名"
    Me.Labusername.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Labuserid
    '
    Me.Labuserid.AutoSize = True
    Me.Labuserid.Location = New System.Drawing.Point(6, 8)
    Me.Labuserid.Name = "Labuserid"
    Me.Labuserid.Size = New System.Drawing.Size(72, 16)
    Me.Labuserid.TabIndex = 7
    Me.Labuserid.Text = "用戶編號"
    Me.Labuserid.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'CLB
    '
    Me.CLB.Dock = System.Windows.Forms.DockStyle.Fill
    Me.CLB.Font = New System.Drawing.Font("黑体", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
    Me.CLB.FormattingEnabled = True
    Me.CLB.Location = New System.Drawing.Point(399, 91)
    Me.CLB.Name = "CLB"
    Me.CLB.Size = New System.Drawing.Size(564, 273)
    Me.CLB.TabIndex = 2
    '
    'PM0312
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(963, 364)
    Me.Controls.Add(Me.CLB)
    Me.Controls.Add(Me.Panel1)
    Me.Controls.Add(Me.DG)
    Me.Font = New System.Drawing.Font("黑体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Margin = New System.Windows.Forms.Padding(4)
    Me.Name = "PM0312"
    Me.Text = "用戶資料編輯0312"
    CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents DG As System.Windows.Forms.DataGridView
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Labrole As System.Windows.Forms.Label
  Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Labpwd As System.Windows.Forms.Label
  Friend WithEvents Labusername As System.Windows.Forms.Label
  Friend WithEvents Labuserid As System.Windows.Forms.Label
  Friend WithEvents CLB As System.Windows.Forms.CheckedListBox
End Class
