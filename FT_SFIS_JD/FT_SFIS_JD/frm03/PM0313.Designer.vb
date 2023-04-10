<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PM0313
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
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.TextBox2 = New System.Windows.Forms.TextBox()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.Labrolename = New System.Windows.Forms.Label()
    Me.Labroleid = New System.Windows.Forms.Label()
    Me.DG = New System.Windows.Forms.DataGridView()
    Me.Tw = New System.Windows.Forms.TreeView()
    Me.Panel1.SuspendLayout()
    CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.TextBox2)
    Me.Panel1.Controls.Add(Me.TextBox1)
    Me.Panel1.Controls.Add(Me.Labrolename)
    Me.Panel1.Controls.Add(Me.Labroleid)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Location = New System.Drawing.Point(376, 0)
    Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(612, 35)
    Me.Panel1.TabIndex = 0
    '
    'TextBox2
    '
    Me.TextBox2.BackColor = System.Drawing.Color.AntiqueWhite
    Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.TextBox2.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox2.Location = New System.Drawing.Point(287, 4)
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(310, 26)
    Me.TextBox2.TabIndex = 8
    '
    'TextBox1
    '
    Me.TextBox1.BackColor = System.Drawing.Color.AntiqueWhite
    Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.TextBox1.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox1.Location = New System.Drawing.Point(85, 4)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(102, 26)
    Me.TextBox1.TabIndex = 7
    '
    'Labrolename
    '
    Me.Labrolename.AutoSize = True
    Me.Labrolename.Location = New System.Drawing.Point(209, 9)
    Me.Labrolename.Name = "Labrolename"
    Me.Labrolename.Size = New System.Drawing.Size(72, 16)
    Me.Labrolename.TabIndex = 6
    Me.Labrolename.Text = "角色名稱"
    Me.Labrolename.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Labroleid
    '
    Me.Labroleid.AutoSize = True
    Me.Labroleid.Location = New System.Drawing.Point(7, 9)
    Me.Labroleid.Name = "Labroleid"
    Me.Labroleid.Size = New System.Drawing.Size(72, 16)
    Me.Labroleid.TabIndex = 5
    Me.Labroleid.Text = "角色編號"
    Me.Labroleid.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'DG
    '
    Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DG.Dock = System.Windows.Forms.DockStyle.Left
    Me.DG.Location = New System.Drawing.Point(0, 0)
    Me.DG.Margin = New System.Windows.Forms.Padding(4)
    Me.DG.Name = "DG"
    Me.DG.RowTemplate.Height = 24
    Me.DG.Size = New System.Drawing.Size(376, 364)
    Me.DG.TabIndex = 1
    '
    'Tw
    '
    Me.Tw.CheckBoxes = True
    Me.Tw.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Tw.Location = New System.Drawing.Point(376, 35)
    Me.Tw.Margin = New System.Windows.Forms.Padding(4)
    Me.Tw.Name = "Tw"
    Me.Tw.Size = New System.Drawing.Size(612, 329)
    Me.Tw.TabIndex = 2
    '
    'PM0313
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(988, 364)
    Me.Controls.Add(Me.Tw)
    Me.Controls.Add(Me.Panel1)
    Me.Controls.Add(Me.DG)
    Me.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Margin = New System.Windows.Forms.Padding(4)
    Me.Name = "PM0313"
    Me.Text = "角色編輯0313"
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents DG As System.Windows.Forms.DataGridView
  Friend WithEvents Tw As System.Windows.Forms.TreeView
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Labrolename As System.Windows.Forms.Label
  Friend WithEvents Labroleid As System.Windows.Forms.Label
End Class
