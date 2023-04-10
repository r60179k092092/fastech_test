<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PM0403
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
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.CheckBox2 = New System.Windows.Forms.CheckBox()
    Me.CheckBox1 = New System.Windows.Forms.CheckBox()
    Me.ComboBox2 = New System.Windows.Forms.ComboBox()
    Me.Button4 = New System.Windows.Forms.Button()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Button3 = New System.Windows.Forms.Button()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.ComboBox3 = New System.Windows.Forms.ComboBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.ComboBox1 = New System.Windows.Forms.ComboBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.DG = New System.Windows.Forms.DataGridView()
    Me.CheckBox3 = New System.Windows.Forms.CheckBox()
    Me.Panel1.SuspendLayout()
    CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.CheckBox3)
    Me.Panel1.Controls.Add(Me.CheckBox2)
    Me.Panel1.Controls.Add(Me.CheckBox1)
    Me.Panel1.Controls.Add(Me.ComboBox2)
    Me.Panel1.Controls.Add(Me.Button4)
    Me.Panel1.Controls.Add(Me.Label3)
    Me.Panel1.Controls.Add(Me.Button3)
    Me.Panel1.Controls.Add(Me.Button2)
    Me.Panel1.Controls.Add(Me.Button1)
    Me.Panel1.Controls.Add(Me.TextBox1)
    Me.Panel1.Controls.Add(Me.Label4)
    Me.Panel1.Controls.Add(Me.ComboBox3)
    Me.Panel1.Controls.Add(Me.Label2)
    Me.Panel1.Controls.Add(Me.ComboBox1)
    Me.Panel1.Controls.Add(Me.Label1)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(983, 125)
    Me.Panel1.TabIndex = 0
    '
    'CheckBox2
    '
    Me.CheckBox2.AutoSize = True
    Me.CheckBox2.Location = New System.Drawing.Point(498, 69)
    Me.CheckBox2.Name = "CheckBox2"
    Me.CheckBox2.Size = New System.Drawing.Size(194, 24)
    Me.CheckBox2.TabIndex = 13
    Me.CheckBox2.Text = "返回工序一併解綁SN號"
    Me.CheckBox2.UseVisualStyleBackColor = True
    '
    'CheckBox1
    '
    Me.CheckBox1.AutoSize = True
    Me.CheckBox1.Checked = True
    Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
    Me.CheckBox1.Location = New System.Drawing.Point(498, 38)
    Me.CheckBox1.Name = "CheckBox1"
    Me.CheckBox1.Size = New System.Drawing.Size(188, 24)
    Me.CheckBox1.TabIndex = 12
    Me.CheckBox1.Text = "如果有箱號先解綁箱號"
    Me.CheckBox1.UseVisualStyleBackColor = True
    '
    'ComboBox2
    '
    Me.ComboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
    Me.ComboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
    Me.ComboBox2.FormattingEnabled = True
    Me.ComboBox2.Location = New System.Drawing.Point(594, 5)
    Me.ComboBox2.Name = "ComboBox2"
    Me.ComboBox2.Size = New System.Drawing.Size(386, 28)
    Me.ComboBox2.TabIndex = 3
    '
    'Button4
    '
    Me.Button4.Location = New System.Drawing.Point(878, 40)
    Me.Button4.Name = "Button4"
    Me.Button4.Size = New System.Drawing.Size(101, 36)
    Me.Button4.TabIndex = 11
    Me.Button4.Text = "離開"
    Me.Button4.UseVisualStyleBackColor = True
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(494, 9)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(105, 20)
    Me.Label3.TabIndex = 4
    Me.Label3.Text = "原始工單號："
    '
    'Button3
    '
    Me.Button3.Location = New System.Drawing.Point(878, 84)
    Me.Button3.Name = "Button3"
    Me.Button3.Size = New System.Drawing.Size(101, 36)
    Me.Button3.TabIndex = 10
    Me.Button3.Text = "清單全選"
    Me.Button3.UseVisualStyleBackColor = True
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(771, 84)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(101, 36)
    Me.Button2.TabIndex = 9
    Me.Button2.Text = "清單清除"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(771, 39)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(101, 36)
    Me.Button1.TabIndex = 8
    Me.Button1.Text = "加入重工"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(104, 68)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(386, 26)
    Me.TextBox1.TabIndex = 7
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(15, 71)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(94, 20)
    Me.Label4.TabIndex = 6
    Me.Label4.Text = "PPID序號："
    '
    'ComboBox3
    '
    Me.ComboBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
    Me.ComboBox3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
    Me.ComboBox3.FormattingEnabled = True
    Me.ComboBox3.Location = New System.Drawing.Point(104, 36)
    Me.ComboBox3.Name = "ComboBox3"
    Me.ComboBox3.Size = New System.Drawing.Size(386, 28)
    Me.ComboBox3.TabIndex = 5
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(20, 40)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(89, 20)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "重工工序："
    '
    'ComboBox1
    '
    Me.ComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
    Me.ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
    Me.ComboBox1.FormattingEnabled = True
    Me.ComboBox1.Location = New System.Drawing.Point(104, 5)
    Me.ComboBox1.Name = "ComboBox1"
    Me.ComboBox1.Size = New System.Drawing.Size(386, 28)
    Me.ComboBox1.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(4, 9)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(105, 20)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "重工工單號："
    '
    'DG
    '
    Me.DG.AllowUserToAddRows = False
    Me.DG.AllowUserToDeleteRows = False
    DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.DG.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
    Me.DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DG.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DG.Location = New System.Drawing.Point(0, 125)
    Me.DG.Name = "DG"
    Me.DG.RowTemplate.Height = 24
    Me.DG.Size = New System.Drawing.Size(983, 264)
    Me.DG.TabIndex = 1
    '
    'CheckBox3
    '
    Me.CheckBox3.AutoSize = True
    Me.CheckBox3.Location = New System.Drawing.Point(498, 97)
    Me.CheckBox3.Name = "CheckBox3"
    Me.CheckBox3.Size = New System.Drawing.Size(257, 24)
    Me.CheckBox3.TabIndex = 14
    Me.CheckBox3.Text = "返回工序一併解綁半成品PPID號"
    Me.CheckBox3.UseVisualStyleBackColor = True
    '
    'PM0403
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(983, 389)
    Me.Controls.Add(Me.DG)
    Me.Controls.Add(Me.Panel1)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
    Me.Name = "PM0403"
    Me.Text = "重工設定管理"
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Button3 As System.Windows.Forms.Button
  Friend WithEvents DG As System.Windows.Forms.DataGridView
  Friend WithEvents Button4 As System.Windows.Forms.Button
  Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
  Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
  Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
End Class
