<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQrySA
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
    Me.Label1 = New System.Windows.Forms.Label()
    Me.ComboBox1 = New System.Windows.Forms.ComboBox()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.CheckBox2 = New System.Windows.Forms.CheckBox()
    Me.Button3 = New System.Windows.Forms.Button()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.DG = New System.Windows.Forms.DataGridView()
    Me.Panel1.SuspendLayout()
    CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.Label1)
    Me.Panel1.Controls.Add(Me.ComboBox1)
    Me.Panel1.Controls.Add(Me.TextBox1)
    Me.Panel1.Controls.Add(Me.CheckBox2)
    Me.Panel1.Controls.Add(Me.Button3)
    Me.Panel1.Controls.Add(Me.Button2)
    Me.Panel1.Controls.Add(Me.Button1)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(1008, 44)
    Me.Panel1.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(3, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(89, 19)
    Me.Label1.TabIndex = 7
    Me.Label1.Text = "部分規格"
    '
    'ComboBox1
    '
    Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ComboBox1.FormattingEnabled = True
    Me.ComboBox1.Location = New System.Drawing.Point(474, 8)
    Me.ComboBox1.Name = "ComboBox1"
    Me.ComboBox1.Size = New System.Drawing.Size(178, 27)
    Me.ComboBox1.TabIndex = 6
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(98, 6)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(298, 30)
    Me.TextBox1.TabIndex = 5
    '
    'CheckBox2
    '
    Me.CheckBox2.AutoSize = True
    Me.CheckBox2.Location = New System.Drawing.Point(402, 10)
    Me.CheckBox2.Name = "CheckBox2"
    Me.CheckBox2.Size = New System.Drawing.Size(68, 23)
    Me.CheckBox2.TabIndex = 4
    Me.CheckBox2.Text = "類別"
    Me.CheckBox2.UseVisualStyleBackColor = True
    '
    'Button3
    '
    Me.Button3.Location = New System.Drawing.Point(656, 3)
    Me.Button3.Name = "Button3"
    Me.Button3.Size = New System.Drawing.Size(69, 37)
    Me.Button3.TabIndex = 2
    Me.Button3.Text = "查詢"
    Me.Button3.UseVisualStyleBackColor = True
    '
    'Button2
    '
    Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Button2.Location = New System.Drawing.Point(850, 3)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(93, 37)
    Me.Button2.TabIndex = 1
    Me.Button2.Text = "取消"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(729, 3)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(117, 37)
    Me.Button1.TabIndex = 0
    Me.Button1.Text = "多選確認"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'DG
    '
    Me.DG.AllowUserToAddRows = False
    Me.DG.AllowUserToDeleteRows = False
    Me.DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DG.ColumnHeadersHeight = 30
    Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
    Me.DG.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DG.Location = New System.Drawing.Point(0, 44)
    Me.DG.Name = "DG"
    Me.DG.ReadOnly = True
    Me.DG.RowTemplate.Height = 24
    Me.DG.Size = New System.Drawing.Size(1008, 517)
    Me.DG.TabIndex = 1
    '
    'FrmQrySA
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 19.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1008, 561)
    Me.ControlBox = False
    Me.Controls.Add(Me.DG)
    Me.Controls.Add(Me.Panel1)
    Me.Font = New System.Drawing.Font("細明體", 14.0!)
    Me.Margin = New System.Windows.Forms.Padding(5)
    Me.Name = "FrmQrySA"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "搜尋品號"
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents DG As System.Windows.Forms.DataGridView
  Friend WithEvents Button3 As System.Windows.Forms.Button
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
