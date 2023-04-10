<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm0331
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
    Me.CheckBox1 = New System.Windows.Forms.CheckBox()
    Me.TextBox2 = New System.Windows.Forms.TextBox()
    Me.ComboBox1 = New System.Windows.Forms.ComboBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.BARID = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.btnQuit = New System.Windows.Forms.Button()
    Me.btnSearch = New System.Windows.Forms.Button()
    Me.DTP2 = New System.Windows.Forms.DateTimePicker()
    Me.DTP1 = New System.Windows.Forms.DateTimePicker()
    Me.cbUser = New System.Windows.Forms.ComboBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Button1 = New System.Windows.Forms.Button()
    CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Panel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'DG
    '
    Me.DG.AllowUserToAddRows = False
    Me.DG.AllowUserToDeleteRows = False
    DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.DG.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
    Me.DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DG.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
    Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DG.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DG.Location = New System.Drawing.Point(0, 122)
    Me.DG.Name = "DG"
    Me.DG.ReadOnly = True
    Me.DG.RowTemplate.Height = 24
    Me.DG.Size = New System.Drawing.Size(968, 467)
    Me.DG.TabIndex = 0
    Me.DG.TabStop = False
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.Button1)
    Me.Panel1.Controls.Add(Me.CheckBox1)
    Me.Panel1.Controls.Add(Me.TextBox2)
    Me.Panel1.Controls.Add(Me.ComboBox1)
    Me.Panel1.Controls.Add(Me.Label9)
    Me.Panel1.Controls.Add(Me.BARID)
    Me.Panel1.Controls.Add(Me.Label7)
    Me.Panel1.Controls.Add(Me.btnQuit)
    Me.Panel1.Controls.Add(Me.btnSearch)
    Me.Panel1.Controls.Add(Me.DTP2)
    Me.Panel1.Controls.Add(Me.DTP1)
    Me.Panel1.Controls.Add(Me.cbUser)
    Me.Panel1.Controls.Add(Me.Label5)
    Me.Panel1.Controls.Add(Me.Label2)
    Me.Panel1.Controls.Add(Me.Label4)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(968, 122)
    Me.Panel1.TabIndex = 0
    '
    'CheckBox1
    '
    Me.CheckBox1.AutoSize = True
    Me.CheckBox1.Location = New System.Drawing.Point(465, 10)
    Me.CheckBox1.Name = "CheckBox1"
    Me.CheckBox1.Size = New System.Drawing.Size(112, 23)
    Me.CheckBox1.TabIndex = 68
    Me.CheckBox1.Text = "導入期間"
    Me.CheckBox1.UseVisualStyleBackColor = True
    '
    'TextBox2
    '
    Me.TextBox2.Location = New System.Drawing.Point(583, 41)
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(340, 30)
    Me.TextBox2.TabIndex = 67
    Me.TextBox2.TabStop = False
    '
    'ComboBox1
    '
    Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ComboBox1.FormattingEnabled = True
    Me.ComboBox1.Items.AddRange(New Object() {"Any", "OK", "NG", "NA"})
    Me.ComboBox1.Location = New System.Drawing.Point(104, 43)
    Me.ComboBox1.Name = "ComboBox1"
    Me.ComboBox1.Size = New System.Drawing.Size(111, 27)
    Me.ComboBox1.TabIndex = 3
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(40, 47)
    Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(64, 19)
    Me.Label9.TabIndex = 65
    Me.Label9.Text = "OK/NG"
    '
    'BARID
    '
    Me.BARID.Location = New System.Drawing.Point(104, 6)
    Me.BARID.Name = "BARID"
    Me.BARID.Size = New System.Drawing.Size(340, 30)
    Me.BARID.TabIndex = 0
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(719, 12)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(30, 19)
    Me.Label7.TabIndex = 61
    Me.Label7.Text = "至"
    '
    'btnQuit
    '
    Me.btnQuit.Location = New System.Drawing.Point(318, 76)
    Me.btnQuit.Name = "btnQuit"
    Me.btnQuit.Size = New System.Drawing.Size(126, 40)
    Me.btnQuit.TabIndex = 25
    Me.btnQuit.TabStop = False
    Me.btnQuit.Text = "離開"
    Me.btnQuit.UseVisualStyleBackColor = True
    '
    'btnSearch
    '
    Me.btnSearch.Location = New System.Drawing.Point(12, 76)
    Me.btnSearch.Name = "btnSearch"
    Me.btnSearch.Size = New System.Drawing.Size(126, 40)
    Me.btnSearch.TabIndex = 24
    Me.btnSearch.TabStop = False
    Me.btnSearch.Text = "搜尋"
    Me.btnSearch.UseVisualStyleBackColor = True
    '
    'DTP2
    '
    Me.DTP2.CustomFormat = "yyyy/MM/dd"
    Me.DTP2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
    Me.DTP2.Location = New System.Drawing.Point(749, 6)
    Me.DTP2.Name = "DTP2"
    Me.DTP2.Size = New System.Drawing.Size(136, 30)
    Me.DTP2.TabIndex = 2
    '
    'DTP1
    '
    Me.DTP1.CustomFormat = "yyyy/MM/dd"
    Me.DTP1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
    Me.DTP1.Location = New System.Drawing.Point(583, 6)
    Me.DTP1.Name = "DTP1"
    Me.DTP1.Size = New System.Drawing.Size(136, 30)
    Me.DTP1.TabIndex = 1
    '
    'cbUser
    '
    Me.cbUser.BackColor = System.Drawing.SystemColors.Window
    Me.cbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cbUser.FormattingEnabled = True
    Me.cbUser.Location = New System.Drawing.Point(301, 43)
    Me.cbUser.Name = "cbUser"
    Me.cbUser.Size = New System.Drawing.Size(143, 27)
    Me.cbUser.TabIndex = 4
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(226, 47)
    Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(72, 19)
    Me.Label5.TabIndex = 16
    Me.Label5.Text = "操作員"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(532, 47)
    Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(51, 19)
    Me.Label2.TabIndex = 12
    Me.Label2.Text = "搜尋"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(11, 12)
    Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(93, 19)
    Me.Label4.TabIndex = 8
    Me.Label4.Text = "物料條碼"
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(165, 76)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(126, 40)
    Me.Button1.TabIndex = 69
    Me.Button1.TabStop = False
    Me.Button1.Text = "導出原始檔"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'frm0331
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(968, 589)
    Me.Controls.Add(Me.DG)
    Me.Controls.Add(Me.Panel1)
    Me.Font = New System.Drawing.Font("細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Name = "frm0331"
    Me.Text = "IQC來料檢驗查詢0331"
    CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents DG As System.Windows.Forms.DataGridView
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents cbUser As System.Windows.Forms.ComboBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents DTP2 As System.Windows.Forms.DateTimePicker
  Friend WithEvents DTP1 As System.Windows.Forms.DateTimePicker
  Friend WithEvents btnQuit As System.Windows.Forms.Button
  Friend WithEvents btnSearch As System.Windows.Forms.Button
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents BARID As System.Windows.Forms.TextBox
  Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
  Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
