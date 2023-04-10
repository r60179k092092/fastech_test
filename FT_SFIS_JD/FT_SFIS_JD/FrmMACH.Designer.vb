<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMACH
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
  '請勿使用程式碼編輯器進行修改。
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.DG = New System.Windows.Forms.DataGridView()
    Me.Panel1.SuspendLayout()
    CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.Label1)
    Me.Panel1.Controls.Add(Me.TextBox1)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(333, 38)
    Me.Panel1.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(6, 10)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(49, 19)
    Me.Label1.TabIndex = 1
    Me.Label1.Text = "查詢"
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(61, 4)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(229, 30)
    Me.TextBox1.TabIndex = 0
    '
    'DG
    '
    Me.DG.AllowUserToAddRows = False
    Me.DG.AllowUserToDeleteRows = False
    Me.DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DG.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
    Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DG.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DG.Location = New System.Drawing.Point(0, 38)
    Me.DG.Name = "DG"
    Me.DG.RowTemplate.Height = 24
    Me.DG.Size = New System.Drawing.Size(333, 412)
    Me.DG.TabIndex = 1
    '
    'FrmMACH
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(333, 450)
    Me.Controls.Add(Me.DG)
    Me.Controls.Add(Me.Panel1)
    Me.Font = New System.Drawing.Font("細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Name = "FrmMACH"
    Me.Text = "機台選擇"
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents Panel1 As Panel
  Friend WithEvents DG As DataGridView
  Friend WithEvents Label1 As Label
  Friend WithEvents TextBox1 As TextBox
End Class
