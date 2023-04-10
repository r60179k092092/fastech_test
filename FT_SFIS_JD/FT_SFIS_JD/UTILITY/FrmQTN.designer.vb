<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQTN
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
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TabPage1 = New System.Windows.Forms.TabPage()
    Me.DV1 = New FDGV.FDataGridView()
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.Button4 = New System.Windows.Forms.Button()
    Me.TextBox3 = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Button3 = New System.Windows.Forms.Button()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.TextBox2 = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.sfd1 = New System.Windows.Forms.SaveFileDialog()
    Me.TabControl1.SuspendLayout()
    Me.TabPage1.SuspendLayout()
    CType(Me.DV1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Panel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabControl1
    '
    Me.TabControl1.Controls.Add(Me.TabPage1)
    Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TabControl1.Font = New System.Drawing.Font("細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.TabControl1.Location = New System.Drawing.Point(0, 0)
    Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(1143, 741)
    Me.TabControl1.TabIndex = 0
    '
    'TabPage1
    '
    Me.TabPage1.Controls.Add(Me.DV1)
    Me.TabPage1.Controls.Add(Me.Panel1)
    Me.TabPage1.Location = New System.Drawing.Point(4, 26)
    Me.TabPage1.Margin = New System.Windows.Forms.Padding(4)
    Me.TabPage1.Name = "TabPage1"
    Me.TabPage1.Padding = New System.Windows.Forms.Padding(4)
    Me.TabPage1.Size = New System.Drawing.Size(1135, 711)
    Me.TabPage1.TabIndex = 0
    Me.TabPage1.Text = "組件編輯"
    Me.TabPage1.UseVisualStyleBackColor = True
    '
    'DV1
    '
    Me.DV1.AllowUserToAddRows = False
    Me.DV1.AllowUserToResizeColumns = False
    Me.DV1.AllowUserToResizeRows = False
    DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.DV1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
    Me.DV1.Append = True
    Me.DV1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DV1.ColumnHeadersHeight = 27
    Me.DV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
    Me.DV1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DV1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
    Me.DV1.Location = New System.Drawing.Point(4, 69)
    Me.DV1.Margin = New System.Windows.Forms.Padding(4)
    Me.DV1.Name = "DV1"
    Me.DV1.RowTemplate.Height = 24
    Me.DV1.Size = New System.Drawing.Size(1127, 638)
    Me.DV1.TabIndex = 1
    Me.DV1.TabStop = False
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.Button4)
    Me.Panel1.Controls.Add(Me.TextBox3)
    Me.Panel1.Controls.Add(Me.Label3)
    Me.Panel1.Controls.Add(Me.Button3)
    Me.Panel1.Controls.Add(Me.Button2)
    Me.Panel1.Controls.Add(Me.TextBox2)
    Me.Panel1.Controls.Add(Me.Label2)
    Me.Panel1.Controls.Add(Me.Button1)
    Me.Panel1.Controls.Add(Me.TextBox1)
    Me.Panel1.Controls.Add(Me.Label1)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Location = New System.Drawing.Point(4, 4)
    Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(1127, 65)
    Me.Panel1.TabIndex = 0
    '
    'Button4
    '
    Me.Button4.BackColor = System.Drawing.Color.Yellow
    Me.Button4.Location = New System.Drawing.Point(724, 3)
    Me.Button4.Name = "Button4"
    Me.Button4.Size = New System.Drawing.Size(180, 59)
    Me.Button4.TabIndex = 10
    Me.Button4.TabStop = False
    Me.Button4.Text = "系統更新支援" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "批次導入"
    Me.Button4.UseVisualStyleBackColor = False
    '
    'TextBox3
    '
    Me.TextBox3.Location = New System.Drawing.Point(295, 3)
    Me.TextBox3.Margin = New System.Windows.Forms.Padding(4)
    Me.TextBox3.Name = "TextBox3"
    Me.TextBox3.Size = New System.Drawing.Size(128, 27)
    Me.TextBox3.TabIndex = 7
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label3.Location = New System.Drawing.Point(187, 8)
    Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(110, 16)
    Me.Label3.TabIndex = 9
    Me.Label3.Text = "增加欄位名："
    '
    'Button3
    '
    Me.Button3.BackColor = System.Drawing.Color.Yellow
    Me.Button3.Location = New System.Drawing.Point(538, 3)
    Me.Button3.Name = "Button3"
    Me.Button3.Size = New System.Drawing.Size(180, 59)
    Me.Button3.TabIndex = 8
    Me.Button3.TabStop = False
    Me.Button3.Text = "導入母檔範本格式" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "或圖檔路徑"
    Me.Button3.UseVisualStyleBackColor = False
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(424, 2)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(92, 28)
    Me.Button2.TabIndex = 6
    Me.Button2.TabStop = False
    Me.Button2.Text = "字典加欄"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'TextBox2
    '
    Me.TextBox2.Location = New System.Drawing.Point(50, 35)
    Me.TextBox2.Margin = New System.Windows.Forms.Padding(4)
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(373, 27)
    Me.TextBox2.TabIndex = 2
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label2.Location = New System.Drawing.Point(5, 40)
    Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(42, 16)
    Me.Label2.TabIndex = 5
    Me.Label2.Text = "說明"
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(424, 34)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(92, 28)
    Me.Button1.TabIndex = 4
    Me.Button1.TabStop = False
    Me.Button1.Text = "刪除此行"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'TextBox1
    '
    Me.TextBox1.Enabled = False
    Me.TextBox1.Location = New System.Drawing.Point(50, 3)
    Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(128, 27)
    Me.TextBox1.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label1.Location = New System.Drawing.Point(5, 8)
    Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(42, 16)
    Me.Label1.TabIndex = 2
    Me.Label1.Text = "組件"
    '
    'FrmQTN
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(1143, 741)
    Me.Controls.Add(Me.TabControl1)
    Me.Font = New System.Drawing.Font("細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Margin = New System.Windows.Forms.Padding(4)
    Me.Name = "FrmQTN"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "字典編輯管理"
    Me.TabControl1.ResumeLayout(False)
    Me.TabPage1.ResumeLayout(False)
    CType(Me.DV1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents DV1 As FDGV.FDataGridView
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents sfd1 As System.Windows.Forms.SaveFileDialog
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents Button3 As System.Windows.Forms.Button
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Button4 As System.Windows.Forms.Button

End Class
