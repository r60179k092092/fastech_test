<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WMS1403
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
    Me.DG1 = New System.Windows.Forms.DataGridView()
    Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.txtCUST = New System.Windows.Forms.Label()
    Me.Button4 = New System.Windows.Forms.Button()
    Me.ComboBox2 = New System.Windows.Forms.ComboBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.txtNum = New System.Windows.Forms.Label()
    Me.txtmachine = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.Btnproduct = New System.Windows.Forms.Button()
    Me.Txtworkcode = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Panel2 = New System.Windows.Forms.Panel()
    Me.TextBox6 = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.TextBox5 = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TextBox4 = New System.Windows.Forms.TextBox()
    Me.TextBox3 = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TextBox2 = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TextBox7 = New System.Windows.Forms.TextBox()
    Me.TextBox8 = New System.Windows.Forms.TextBox()
    CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Panel1.SuspendLayout()
    Me.Panel2.SuspendLayout()
    Me.SuspendLayout()
    '
    'DG1
    '
    Me.DG1.AllowUserToAddRows = False
    Me.DG1.AllowUserToDeleteRows = False
    Me.DG1.AllowUserToResizeRows = False
    DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.DG1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
    Me.DG1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DG1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column15, Me.Column9, Me.Column1, Me.Column3, Me.Column4, Me.Column16, Me.Column2, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column10, Me.Column11, Me.Column13, Me.Column14, Me.Column12})
    Me.DG1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DG1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
    Me.DG1.Location = New System.Drawing.Point(0, 122)
    Me.DG1.MultiSelect = False
    Me.DG1.Name = "DG1"
    Me.DG1.ReadOnly = True
    Me.DG1.RowHeadersVisible = False
    Me.DG1.RowTemplate.Height = 23
    Me.DG1.Size = New System.Drawing.Size(1035, 356)
    Me.DG1.TabIndex = 62
    '
    'Column15
    '
    Me.Column15.HeaderText = "NO"
    Me.Column15.Name = "Column15"
    Me.Column15.ReadOnly = True
    Me.Column15.Width = 57
    '
    'Column9
    '
    Me.Column9.HeaderText = "加工序"
    Me.Column9.Name = "Column9"
    Me.Column9.ReadOnly = True
    Me.Column9.Width = 82
    '
    'Column1
    '
    Me.Column1.HeaderText = "物料编号"
    Me.Column1.Name = "Column1"
    Me.Column1.ReadOnly = True
    Me.Column1.Width = 98
    '
    'Column3
    '
    Me.Column3.HeaderText = "规格"
    Me.Column3.Name = "Column3"
    Me.Column3.ReadOnly = True
    Me.Column3.Width = 66
    '
    'Column4
    '
    Me.Column4.HeaderText = "用量A"
    Me.Column4.Name = "Column4"
    Me.Column4.ReadOnly = True
    Me.Column4.Width = 77
    '
    'Column16
    '
    Me.Column16.HeaderText = "用量B"
    Me.Column16.Name = "Column16"
    Me.Column16.ReadOnly = True
    Me.Column16.Width = 77
    '
    'Column2
    '
    Me.Column2.HeaderText = "需求数"
    Me.Column2.Name = "Column2"
    Me.Column2.ReadOnly = True
    Me.Column2.Width = 82
    '
    'Column5
    '
    Me.Column5.HeaderText = "发料数"
    Me.Column5.Name = "Column5"
    Me.Column5.ReadOnly = True
    Me.Column5.Width = 82
    '
    'Column6
    '
    Me.Column6.HeaderText = "料盘数"
    Me.Column6.Name = "Column6"
    Me.Column6.ReadOnly = True
    Me.Column6.Width = 82
    '
    'Column7
    '
    Me.Column7.HeaderText = "确认"
    Me.Column7.Name = "Column7"
    Me.Column7.ReadOnly = True
    Me.Column7.Width = 66
    '
    'Column8
    '
    Me.Column8.HeaderText = "应退数"
    Me.Column8.Name = "Column8"
    Me.Column8.ReadOnly = True
    Me.Column8.Width = 82
    '
    'Column10
    '
    Me.Column10.HeaderText = "实退数"
    Me.Column10.Name = "Column10"
    Me.Column10.ReadOnly = True
    Me.Column10.Width = 82
    '
    'Column11
    '
    Me.Column11.HeaderText = "差异"
    Me.Column11.Name = "Column11"
    Me.Column11.ReadOnly = True
    Me.Column11.Width = 66
    '
    'Column13
    '
    Me.Column13.HeaderText = "RoHS确认"
    Me.Column13.Name = "Column13"
    Me.Column13.ReadOnly = True
    Me.Column13.Width = 110
    '
    'Column14
    '
    Me.Column14.HeaderText = "IQC确认"
    Me.Column14.Name = "Column14"
    Me.Column14.ReadOnly = True
    Me.Column14.Width = 94
    '
    'Column12
    '
    Me.Column12.HeaderText = "备注"
    Me.Column12.Name = "Column12"
    Me.Column12.ReadOnly = True
    Me.Column12.Width = 66
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.txtCUST)
    Me.Panel1.Controls.Add(Me.Button4)
    Me.Panel1.Controls.Add(Me.ComboBox2)
    Me.Panel1.Controls.Add(Me.Label7)
    Me.Panel1.Controls.Add(Me.txtNum)
    Me.Panel1.Controls.Add(Me.txtmachine)
    Me.Panel1.Controls.Add(Me.Label3)
    Me.Panel1.Controls.Add(Me.Button2)
    Me.Panel1.Controls.Add(Me.Button1)
    Me.Panel1.Controls.Add(Me.Btnproduct)
    Me.Panel1.Controls.Add(Me.Txtworkcode)
    Me.Panel1.Controls.Add(Me.Label6)
    Me.Panel1.Controls.Add(Me.Label2)
    Me.Panel1.Controls.Add(Me.Label1)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(1035, 122)
    Me.Panel1.TabIndex = 61
    '
    'txtCUST
    '
    Me.txtCUST.AutoSize = True
    Me.txtCUST.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.txtCUST.Location = New System.Drawing.Point(383, 16)
    Me.txtCUST.Name = "txtCUST"
    Me.txtCUST.Size = New System.Drawing.Size(0, 20)
    Me.txtCUST.TabIndex = 124
    '
    'Button4
    '
    Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Button4.Location = New System.Drawing.Point(684, 17)
    Me.Button4.Name = "Button4"
    Me.Button4.Size = New System.Drawing.Size(98, 70)
    Me.Button4.TabIndex = 123
    Me.Button4.Text = "产生清单"
    Me.Button4.UseVisualStyleBackColor = True
    '
    'ComboBox2
    '
    Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ComboBox2.FormattingEnabled = True
    Me.ComboBox2.Items.AddRange(New Object() {"贵材仓", "线边仓"})
    Me.ComboBox2.Location = New System.Drawing.Point(383, 49)
    Me.ComboBox2.Name = "ComboBox2"
    Me.ComboBox2.Size = New System.Drawing.Size(119, 28)
    Me.ComboBox2.TabIndex = 119
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(336, 52)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(41, 20)
    Me.Label7.TabIndex = 118
    Me.Label7.Text = "仓别"
    '
    'txtNum
    '
    Me.txtNum.AutoSize = True
    Me.txtNum.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.txtNum.Location = New System.Drawing.Point(92, 84)
    Me.txtNum.Name = "txtNum"
    Me.txtNum.Size = New System.Drawing.Size(0, 20)
    Me.txtNum.TabIndex = 117
    '
    'txtmachine
    '
    Me.txtmachine.AutoSize = True
    Me.txtmachine.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.txtmachine.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
    Me.txtmachine.Location = New System.Drawing.Point(92, 52)
    Me.txtmachine.Name = "txtmachine"
    Me.txtmachine.Size = New System.Drawing.Size(0, 20)
    Me.txtmachine.TabIndex = 116
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(336, 16)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(41, 20)
    Me.Label3.TabIndex = 114
    Me.Label3.Text = "客戶"
    '
    'Button2
    '
    Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Button2.Location = New System.Drawing.Point(798, 16)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(98, 70)
    Me.Button2.TabIndex = 112
    Me.Button2.Text = "离开"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'Button1
    '
    Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Button1.Location = New System.Drawing.Point(566, 16)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(98, 70)
    Me.Button1.TabIndex = 111
    Me.Button1.Text = "查询"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'Btnproduct
    '
    Me.Btnproduct.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Btnproduct.Location = New System.Drawing.Point(274, 18)
    Me.Btnproduct.Margin = New System.Windows.Forms.Padding(0)
    Me.Btnproduct.Name = "Btnproduct"
    Me.Btnproduct.Size = New System.Drawing.Size(30, 23)
    Me.Btnproduct.TabIndex = 1
    Me.Btnproduct.TabStop = False
    Me.Btnproduct.Text = "..."
    Me.Btnproduct.UseVisualStyleBackColor = True
    '
    'Txtworkcode
    '
    Me.Txtworkcode.BackColor = System.Drawing.Color.AntiqueWhite
    Me.Txtworkcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.Txtworkcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
    Me.Txtworkcode.Location = New System.Drawing.Point(92, 16)
    Me.Txtworkcode.Name = "Txtworkcode"
    Me.Txtworkcode.Size = New System.Drawing.Size(179, 26)
    Me.Txtworkcode.TabIndex = 0
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(45, 84)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(41, 20)
    Me.Label6.TabIndex = 25
    Me.Label6.Text = "批量"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(45, 52)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(41, 20)
    Me.Label2.TabIndex = 31
    Me.Label2.Text = "机种"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(13, 19)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(73, 20)
    Me.Label1.TabIndex = 32
    Me.Label1.Text = "工单编号"
    '
    'Panel2
    '
    Me.Panel2.BackColor = System.Drawing.SystemColors.ControlLight
    Me.Panel2.Controls.Add(Me.TextBox7)
    Me.Panel2.Controls.Add(Me.TextBox8)
    Me.Panel2.Controls.Add(Me.TextBox6)
    Me.Panel2.Controls.Add(Me.Label11)
    Me.Panel2.Controls.Add(Me.Label9)
    Me.Panel2.Controls.Add(Me.TextBox1)
    Me.Panel2.Controls.Add(Me.Label10)
    Me.Panel2.Controls.Add(Me.TextBox5)
    Me.Panel2.Controls.Add(Me.Label4)
    Me.Panel2.Controls.Add(Me.TextBox4)
    Me.Panel2.Controls.Add(Me.TextBox3)
    Me.Panel2.Controls.Add(Me.Label5)
    Me.Panel2.Controls.Add(Me.TextBox2)
    Me.Panel2.Controls.Add(Me.Label8)
    Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
    Me.Panel2.Location = New System.Drawing.Point(0, 478)
    Me.Panel2.Name = "Panel2"
    Me.Panel2.Size = New System.Drawing.Size(1035, 67)
    Me.Panel2.TabIndex = 66
    '
    'TextBox6
    '
    Me.TextBox6.Location = New System.Drawing.Point(825, 5)
    Me.TextBox6.Name = "TextBox6"
    Me.TextBox6.Size = New System.Drawing.Size(166, 26)
    Me.TextBox6.TabIndex = 11
    Me.TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(758, 8)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(61, 20)
    Me.Label11.TabIndex = 10
    Me.Label11.Text = "收料人:"
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(452, 39)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(73, 20)
    Me.Label9.TabIndex = 9
    Me.Label9.Text = "IQC确认:"
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(531, 5)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(166, 26)
    Me.TextBox1.TabIndex = 8
    Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Location = New System.Drawing.Point(448, 8)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(77, 20)
    Me.Label10.TabIndex = 7
    Me.Label10.Text = "单位主管:"
    '
    'TextBox5
    '
    Me.TextBox5.Location = New System.Drawing.Point(825, 36)
    Me.TextBox5.Name = "TextBox5"
    Me.TextBox5.Size = New System.Drawing.Size(166, 26)
    Me.TextBox5.TabIndex = 6
    Me.TextBox5.Text = "AP-YR-12B"
    Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(774, 39)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(45, 20)
    Me.Label4.TabIndex = 5
    Me.Label4.Text = "编码:"
    '
    'TextBox4
    '
    Me.TextBox4.Location = New System.Drawing.Point(531, 36)
    Me.TextBox4.Name = "TextBox4"
    Me.TextBox4.Size = New System.Drawing.Size(166, 26)
    Me.TextBox4.TabIndex = 4
    Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'TextBox3
    '
    Me.TextBox3.Location = New System.Drawing.Point(91, 36)
    Me.TextBox3.Name = "TextBox3"
    Me.TextBox3.Size = New System.Drawing.Size(147, 26)
    Me.TextBox3.TabIndex = 3
    Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(24, 39)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(61, 20)
    Me.Label5.TabIndex = 2
    Me.Label5.Text = "制表人:"
    '
    'TextBox2
    '
    Me.TextBox2.Location = New System.Drawing.Point(91, 5)
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(147, 26)
    Me.TextBox2.TabIndex = 1
    Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(24, 8)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(61, 20)
    Me.Label8.TabIndex = 0
    Me.Label8.Text = "发料人:"
    '
    'TextBox7
    '
    Me.TextBox7.Location = New System.Drawing.Point(244, 36)
    Me.TextBox7.Name = "TextBox7"
    Me.TextBox7.Size = New System.Drawing.Size(151, 26)
    Me.TextBox7.TabIndex = 13
    Me.TextBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'TextBox8
    '
    Me.TextBox8.Location = New System.Drawing.Point(244, 5)
    Me.TextBox8.Name = "TextBox8"
    Me.TextBox8.Size = New System.Drawing.Size(151, 26)
    Me.TextBox8.TabIndex = 12
    Me.TextBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'WMS1403
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(1035, 545)
    Me.Controls.Add(Me.DG1)
    Me.Controls.Add(Me.Panel2)
    Me.Controls.Add(Me.Panel1)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
    Me.Margin = New System.Windows.Forms.Padding(4)
    Me.Name = "WMS1403"
    Me.Text = "来料清单"
    CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.Panel2.ResumeLayout(False)
    Me.Panel2.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents DG1 As System.Windows.Forms.DataGridView
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents txtNum As System.Windows.Forms.Label
  Friend WithEvents txtmachine As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents Btnproduct As System.Windows.Forms.Button
  Friend WithEvents Txtworkcode As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Button4 As System.Windows.Forms.Button
  Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents txtCUST As System.Windows.Forms.Label
  Friend WithEvents Panel2 As System.Windows.Forms.Panel
  Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
  Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
  Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
End Class
