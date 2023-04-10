<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSetting
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
    Me.Button4 = New System.Windows.Forms.Button()
    Me.BtnSave = New System.Windows.Forms.Button()
    Me.BtnCancel = New System.Windows.Forms.Button()
    Me.BtnModify = New System.Windows.Forms.Button()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.ComboBox1 = New System.Windows.Forms.ComboBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TextBox5 = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TextBox4 = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TextBox3 = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TextBox2 = New System.Windows.Forms.TextBox()
    Me.ComboBox2 = New System.Windows.Forms.ComboBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Panel1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.Button4)
    Me.Panel1.Controls.Add(Me.BtnSave)
    Me.Panel1.Controls.Add(Me.BtnCancel)
    Me.Panel1.Controls.Add(Me.BtnModify)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(460, 60)
    Me.Panel1.TabIndex = 1
    '
    'Button4
    '
    Me.Button4.Location = New System.Drawing.Point(329, 8)
    Me.Button4.Name = "Button4"
    Me.Button4.Size = New System.Drawing.Size(106, 43)
    Me.Button4.TabIndex = 3
    Me.Button4.Text = "離開"
    Me.Button4.UseVisualStyleBackColor = True
    '
    'BtnSave
    '
    Me.BtnSave.Location = New System.Drawing.Point(8, 8)
    Me.BtnSave.Name = "BtnSave"
    Me.BtnSave.Size = New System.Drawing.Size(106, 43)
    Me.BtnSave.TabIndex = 2
    Me.BtnSave.Text = "存檔"
    Me.BtnSave.UseVisualStyleBackColor = True
    '
    'BtnCancel
    '
    Me.BtnCancel.Location = New System.Drawing.Point(221, 8)
    Me.BtnCancel.Name = "BtnCancel"
    Me.BtnCancel.Size = New System.Drawing.Size(106, 43)
    Me.BtnCancel.TabIndex = 1
    Me.BtnCancel.Text = "取消修改"
    Me.BtnCancel.UseVisualStyleBackColor = True
    '
    'BtnModify
    '
    Me.BtnModify.Location = New System.Drawing.Point(115, 8)
    Me.BtnModify.Name = "BtnModify"
    Me.BtnModify.Size = New System.Drawing.Size(106, 43)
    Me.BtnModify.TabIndex = 0
    Me.BtnModify.Text = "修改"
    Me.BtnModify.UseVisualStyleBackColor = True
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.ComboBox1)
    Me.GroupBox2.Controls.Add(Me.Label1)
    Me.GroupBox2.Controls.Add(Me.TextBox5)
    Me.GroupBox2.Controls.Add(Me.Label6)
    Me.GroupBox2.Controls.Add(Me.TextBox4)
    Me.GroupBox2.Controls.Add(Me.Label5)
    Me.GroupBox2.Controls.Add(Me.TextBox3)
    Me.GroupBox2.Controls.Add(Me.Label2)
    Me.GroupBox2.Controls.Add(Me.TextBox2)
    Me.GroupBox2.Controls.Add(Me.ComboBox2)
    Me.GroupBox2.Controls.Add(Me.Label3)
    Me.GroupBox2.Controls.Add(Me.Label4)
    Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
    Me.GroupBox2.Location = New System.Drawing.Point(0, 60)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(460, 173)
    Me.GroupBox2.TabIndex = 2
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "磅砰"
    '
    'ComboBox1
    '
    Me.ComboBox1.FormattingEnabled = True
    Me.ComboBox1.Location = New System.Drawing.Point(66, 140)
    Me.ComboBox1.Name = "ComboBox1"
    Me.ComboBox1.Size = New System.Drawing.Size(390, 24)
    Me.ComboBox1.TabIndex = 14
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(5, 144)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(56, 16)
    Me.Label1.TabIndex = 13
    Me.Label1.Text = "標籤機"
    '
    'TextBox5
    '
    Me.TextBox5.Location = New System.Drawing.Point(341, 81)
    Me.TextBox5.Name = "TextBox5"
    Me.TextBox5.Size = New System.Drawing.Size(115, 26)
    Me.TextBox5.TabIndex = 12
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(239, 86)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(104, 16)
    Me.Label6.TabIndex = 11
    Me.Label6.Text = "KG  穩定次數"
    '
    'TextBox4
    '
    Me.TextBox4.Location = New System.Drawing.Point(66, 81)
    Me.TextBox4.Name = "TextBox4"
    Me.TextBox4.Size = New System.Drawing.Size(166, 26)
    Me.TextBox4.TabIndex = 10
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(21, 86)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(40, 16)
    Me.Label5.TabIndex = 9
    Me.Label5.Text = "穩定"
    '
    'TextBox3
    '
    Me.TextBox3.Location = New System.Drawing.Point(66, 110)
    Me.TextBox3.Name = "TextBox3"
    Me.TextBox3.Size = New System.Drawing.Size(166, 26)
    Me.TextBox3.TabIndex = 8
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(21, 115)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(40, 16)
    Me.Label2.TabIndex = 7
    Me.Label2.Text = "空磅"
    '
    'TextBox2
    '
    Me.TextBox2.Location = New System.Drawing.Point(66, 52)
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(390, 26)
    Me.TextBox2.TabIndex = 3
    '
    'ComboBox2
    '
    Me.ComboBox2.FormattingEnabled = True
    Me.ComboBox2.Location = New System.Drawing.Point(66, 24)
    Me.ComboBox2.Name = "ComboBox2"
    Me.ComboBox2.Size = New System.Drawing.Size(390, 24)
    Me.ComboBox2.TabIndex = 2
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(5, 28)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(56, 16)
    Me.Label3.TabIndex = 1
    Me.Label3.Text = "連接埠"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(5, 57)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(56, 16)
    Me.Label4.TabIndex = 0
    Me.Label4.Text = "參數值"
    '
    'FrmSetting
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(460, 232)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.Panel1)
    Me.Font = New System.Drawing.Font("SimHei", 12.0!)
    Me.Margin = New System.Windows.Forms.Padding(4)
    Me.Name = "FrmSetting"
    Me.Text = "參數設定"
    Me.Panel1.ResumeLayout(False)
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents BtnModify As System.Windows.Forms.Button
  Friend WithEvents Button4 As System.Windows.Forms.Button
  Friend WithEvents BtnSave As System.Windows.Forms.Button
  Friend WithEvents BtnCancel As System.Windows.Forms.Button
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
