<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm0405
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
    Me.Panel4 = New System.Windows.Forms.Panel()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.CheckBox1 = New System.Windows.Forms.CheckBox()
    Me.ComboBox2 = New System.Windows.Forms.ComboBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Button4 = New System.Windows.Forms.Button()
    Me.ComboBox1 = New System.Windows.Forms.ComboBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.CheckBox2 = New System.Windows.Forms.CheckBox()
    Me.Button3 = New System.Windows.Forms.Button()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.DG = New System.Windows.Forms.DataGridView()
    Me.Panel2 = New System.Windows.Forms.Panel()
    Me.DG1 = New System.Windows.Forms.DataGridView()
    Me.Panel3 = New System.Windows.Forms.Panel()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Panel1.SuspendLayout()
    Me.Panel4.SuspendLayout()
    CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Panel2.SuspendLayout()
    CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Panel3.SuspendLayout()
    Me.SuspendLayout()
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.Panel4)
    Me.Panel1.Controls.Add(Me.CheckBox1)
    Me.Panel1.Controls.Add(Me.ComboBox2)
    Me.Panel1.Controls.Add(Me.Label3)
    Me.Panel1.Controls.Add(Me.Button4)
    Me.Panel1.Controls.Add(Me.ComboBox1)
    Me.Panel1.Controls.Add(Me.Label1)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(1051, 115)
    Me.Panel1.TabIndex = 0
    '
    'Panel4
    '
    Me.Panel4.Controls.Add(Me.TextBox1)
    Me.Panel4.Location = New System.Drawing.Point(242, 67)
    Me.Panel4.Name = "Panel4"
    Me.Panel4.Size = New System.Drawing.Size(401, 44)
    Me.Panel4.TabIndex = 12
    Me.Panel4.Visible = False
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(3, 7)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(291, 30)
    Me.TextBox1.TabIndex = 9
    '
    'CheckBox1
    '
    Me.CheckBox1.AutoSize = True
    Me.CheckBox1.Location = New System.Drawing.Point(7, 77)
    Me.CheckBox1.Name = "CheckBox1"
    Me.CheckBox1.Size = New System.Drawing.Size(241, 23)
    Me.CheckBox1.TabIndex = 8
    Me.CheckBox1.Text = "輸入SN或PPID搜尋整箱"
    Me.CheckBox1.UseVisualStyleBackColor = True
    '
    'ComboBox2
    '
    Me.ComboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
    Me.ComboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
    Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ComboBox2.FormattingEnabled = True
    Me.ComboBox2.Location = New System.Drawing.Point(245, 38)
    Me.ComboBox2.Name = "ComboBox2"
    Me.ComboBox2.Size = New System.Drawing.Size(398, 27)
    Me.ComboBox2.TabIndex = 7
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(29, 41)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(219, 19)
    Me.Label3.TabIndex = 6
    Me.Label3.Text = "解綁箱號後返回工序："
    '
    'Button4
    '
    Me.Button4.Location = New System.Drawing.Point(861, 38)
    Me.Button4.Name = "Button4"
    Me.Button4.Size = New System.Drawing.Size(81, 70)
    Me.Button4.TabIndex = 5
    Me.Button4.Text = "離開"
    Me.Button4.UseVisualStyleBackColor = True
    '
    'ComboBox1
    '
    Me.ComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
    Me.ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
    Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ComboBox1.FormattingEnabled = True
    Me.ComboBox1.Location = New System.Drawing.Point(245, 5)
    Me.ComboBox1.Name = "ComboBox1"
    Me.ComboBox1.Size = New System.Drawing.Size(697, 27)
    Me.ComboBox1.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(92, 9)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(156, 19)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "返工批次編號："
    '
    'CheckBox2
    '
    Me.CheckBox2.AutoSize = True
    Me.CheckBox2.Location = New System.Drawing.Point(6, 43)
    Me.CheckBox2.Name = "CheckBox2"
    Me.CheckBox2.Size = New System.Drawing.Size(239, 23)
    Me.CheckBox2.TabIndex = 10
    Me.CheckBox2.Text = "解綁箱號時一併解綁SN"
    Me.CheckBox2.UseVisualStyleBackColor = True
    '
    'Button3
    '
    Me.Button3.Location = New System.Drawing.Point(256, 74)
    Me.Button3.Name = "Button3"
    Me.Button3.Size = New System.Drawing.Size(116, 38)
    Me.Button3.TabIndex = 4
    Me.Button3.Text = "解綁箱號"
    Me.Button3.UseVisualStyleBackColor = True
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(134, 74)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(116, 38)
    Me.Button2.TabIndex = 3
    Me.Button2.Text = "全不選"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(6, 74)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(116, 38)
    Me.Button1.TabIndex = 2
    Me.Button1.Text = "全選"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'DG
    '
    Me.DG.AllowUserToAddRows = False
    Me.DG.AllowUserToDeleteRows = False
    Me.DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DG.Dock = System.Windows.Forms.DockStyle.Left
    Me.DG.Location = New System.Drawing.Point(0, 115)
    Me.DG.Name = "DG"
    Me.DG.ReadOnly = True
    Me.DG.RowTemplate.Height = 24
    Me.DG.Size = New System.Drawing.Size(691, 388)
    Me.DG.TabIndex = 1
    '
    'Panel2
    '
    Me.Panel2.Controls.Add(Me.DG1)
    Me.Panel2.Controls.Add(Me.Panel3)
    Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Panel2.Location = New System.Drawing.Point(691, 115)
    Me.Panel2.Name = "Panel2"
    Me.Panel2.Padding = New System.Windows.Forms.Padding(5)
    Me.Panel2.Size = New System.Drawing.Size(360, 388)
    Me.Panel2.TabIndex = 2
    '
    'DG1
    '
    Me.DG1.AllowUserToAddRows = False
    Me.DG1.AllowUserToDeleteRows = False
    Me.DG1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DG1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DG1.Location = New System.Drawing.Point(5, 123)
    Me.DG1.Name = "DG1"
    Me.DG1.RowTemplate.Height = 24
    Me.DG1.Size = New System.Drawing.Size(350, 260)
    Me.DG1.TabIndex = 2
    '
    'Panel3
    '
    Me.Panel3.Controls.Add(Me.Button3)
    Me.Panel3.Controls.Add(Me.CheckBox2)
    Me.Panel3.Controls.Add(Me.Button1)
    Me.Panel3.Controls.Add(Me.Button2)
    Me.Panel3.Controls.Add(Me.Label2)
    Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel3.Location = New System.Drawing.Point(5, 5)
    Me.Panel3.Name = "Panel3"
    Me.Panel3.Size = New System.Drawing.Size(350, 118)
    Me.Panel3.TabIndex = 3
    '
    'Label2
    '
    Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
    Me.Label2.Location = New System.Drawing.Point(0, 0)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(350, 37)
    Me.Label2.TabIndex = 0
    Me.Label2.Text = "查詢時所有包含的箱號清單如下"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Frm0405
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(1051, 503)
    Me.Controls.Add(Me.Panel2)
    Me.Controls.Add(Me.DG)
    Me.Controls.Add(Me.Panel1)
    Me.Font = New System.Drawing.Font("細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Name = "Frm0405"
    Me.Text = "SN返工清單"
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.Panel4.ResumeLayout(False)
    Me.Panel4.PerformLayout()
    CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Panel2.ResumeLayout(False)
    CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Panel3.ResumeLayout(False)
    Me.Panel3.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Button4 As System.Windows.Forms.Button
  Friend WithEvents Button3 As System.Windows.Forms.Button
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Panel4 As System.Windows.Forms.Panel
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
  Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
  Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents DG As System.Windows.Forms.DataGridView
  Friend WithEvents Panel2 As System.Windows.Forms.Panel
  Friend WithEvents DG1 As System.Windows.Forms.DataGridView
  Friend WithEvents Panel3 As System.Windows.Forms.Panel
  Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
