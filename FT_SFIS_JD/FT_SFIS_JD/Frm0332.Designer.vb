<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm0332
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
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.ComboBox4 = New System.Windows.Forms.ComboBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.ComboBox3 = New System.Windows.Forms.ComboBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.ComboBox2 = New System.Windows.Forms.ComboBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.ComboBox1 = New System.Windows.Forms.ComboBox()
    Me.LabFlowcode = New System.Windows.Forms.Label()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TabPage1 = New System.Windows.Forms.TabPage()
    Me.TabPage2 = New System.Windows.Forms.TabPage()
    Me.DG = New System.Windows.Forms.DataGridView()
    Me.DG1 = New System.Windows.Forms.DataGridView()
    Me.Panel2 = New System.Windows.Forms.Panel()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.Button3 = New System.Windows.Forms.Button()
    Me.Button4 = New System.Windows.Forms.Button()
    Me.Button5 = New System.Windows.Forms.Button()
    Me.Panel1.SuspendLayout()
    Me.TabControl1.SuspendLayout()
    Me.TabPage1.SuspendLayout()
    Me.TabPage2.SuspendLayout()
    CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.DG1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Panel2.SuspendLayout()
    Me.SuspendLayout()
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.Button1)
    Me.Panel1.Controls.Add(Me.ComboBox4)
    Me.Panel1.Controls.Add(Me.Label3)
    Me.Panel1.Controls.Add(Me.ComboBox2)
    Me.Panel1.Controls.Add(Me.Label1)
    Me.Panel1.Controls.Add(Me.ComboBox1)
    Me.Panel1.Controls.Add(Me.LabFlowcode)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Font = New System.Drawing.Font("細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Panel1.Location = New System.Drawing.Point(3, 3)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(989, 68)
    Me.Panel1.TabIndex = 1
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(879, 33)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(102, 32)
    Me.Button1.TabIndex = 25
    Me.Button1.Text = "編輯"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'ComboBox4
    '
    Me.ComboBox4.FormattingEnabled = True
    Me.ComboBox4.Location = New System.Drawing.Point(544, 36)
    Me.ComboBox4.Name = "ComboBox4"
    Me.ComboBox4.Size = New System.Drawing.Size(329, 27)
    Me.ComboBox4.TabIndex = 24
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Font = New System.Drawing.Font("細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(445, 40)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(93, 19)
    Me.Label3.TabIndex = 23
    Me.Label3.Text = "數據類型"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'ComboBox3
    '
    Me.ComboBox3.FormattingEnabled = True
    Me.ComboBox3.Location = New System.Drawing.Point(102, 9)
    Me.ComboBox3.Name = "ComboBox3"
    Me.ComboBox3.Size = New System.Drawing.Size(325, 27)
    Me.ComboBox3.TabIndex = 22
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(3, 13)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(93, 19)
    Me.Label2.TabIndex = 21
    Me.Label2.Text = "工藝難度"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'ComboBox2
    '
    Me.ComboBox2.FormattingEnabled = True
    Me.ComboBox2.Location = New System.Drawing.Point(102, 36)
    Me.ComboBox2.Name = "ComboBox2"
    Me.ComboBox2.Size = New System.Drawing.Size(329, 27)
    Me.ComboBox2.TabIndex = 20
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(45, 40)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(51, 19)
    Me.Label1.TabIndex = 19
    Me.Label1.Text = "工序"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'ComboBox1
    '
    Me.ComboBox1.FormattingEnabled = True
    Me.ComboBox1.Location = New System.Drawing.Point(102, 5)
    Me.ComboBox1.Name = "ComboBox1"
    Me.ComboBox1.Size = New System.Drawing.Size(889, 27)
    Me.ComboBox1.TabIndex = 18
    '
    'LabFlowcode
    '
    Me.LabFlowcode.AutoSize = True
    Me.LabFlowcode.Font = New System.Drawing.Font("細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabFlowcode.Location = New System.Drawing.Point(3, 9)
    Me.LabFlowcode.Name = "LabFlowcode"
    Me.LabFlowcode.Size = New System.Drawing.Size(93, 19)
    Me.LabFlowcode.TabIndex = 17
    Me.LabFlowcode.Text = "流程編號"
    Me.LabFlowcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TabControl1
    '
    Me.TabControl1.Controls.Add(Me.TabPage1)
    Me.TabControl1.Controls.Add(Me.TabPage2)
    Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TabControl1.Location = New System.Drawing.Point(0, 0)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(1003, 413)
    Me.TabControl1.TabIndex = 2
    '
    'TabPage1
    '
    Me.TabPage1.Controls.Add(Me.DG1)
    Me.TabPage1.Controls.Add(Me.Panel2)
    Me.TabPage1.Controls.Add(Me.Panel1)
    Me.TabPage1.Location = New System.Drawing.Point(4, 29)
    Me.TabPage1.Name = "TabPage1"
    Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage1.Size = New System.Drawing.Size(995, 380)
    Me.TabPage1.TabIndex = 0
    Me.TabPage1.Text = "效能及損耗編輯"
    Me.TabPage1.UseVisualStyleBackColor = True
    '
    'TabPage2
    '
    Me.TabPage2.Controls.Add(Me.DG)
    Me.TabPage2.Location = New System.Drawing.Point(4, 29)
    Me.TabPage2.Name = "TabPage2"
    Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage2.Size = New System.Drawing.Size(995, 380)
    Me.TabPage2.TabIndex = 1
    Me.TabPage2.Text = "資料清單"
    Me.TabPage2.UseVisualStyleBackColor = True
    '
    'DG
    '
    Me.DG.AllowUserToAddRows = False
    Me.DG.AllowUserToDeleteRows = False
    Me.DG.AllowUserToResizeColumns = False
    Me.DG.AllowUserToResizeRows = False
    DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.DG.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
    Me.DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
    Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DG.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DG.Location = New System.Drawing.Point(3, 3)
    Me.DG.Name = "DG"
    Me.DG.ReadOnly = True
    Me.DG.RowTemplate.Height = 24
    Me.DG.Size = New System.Drawing.Size(989, 374)
    Me.DG.TabIndex = 0
    '
    'DG1
    '
    Me.DG1.AllowUserToAddRows = False
    Me.DG1.AllowUserToDeleteRows = False
    Me.DG1.AllowUserToResizeColumns = False
    Me.DG1.AllowUserToResizeRows = False
    DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.DG1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
    Me.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DG1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DG1.Location = New System.Drawing.Point(3, 115)
    Me.DG1.Name = "DG1"
    Me.DG1.RowTemplate.Height = 24
    Me.DG1.Size = New System.Drawing.Size(989, 262)
    Me.DG1.TabIndex = 2
    '
    'Panel2
    '
    Me.Panel2.Controls.Add(Me.Button5)
    Me.Panel2.Controls.Add(Me.Button4)
    Me.Panel2.Controls.Add(Me.Button3)
    Me.Panel2.Controls.Add(Me.Button2)
    Me.Panel2.Controls.Add(Me.ComboBox3)
    Me.Panel2.Controls.Add(Me.Label2)
    Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel2.Location = New System.Drawing.Point(3, 71)
    Me.Panel2.Name = "Panel2"
    Me.Panel2.Size = New System.Drawing.Size(989, 44)
    Me.Panel2.TabIndex = 3
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(449, 6)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(102, 32)
    Me.Button2.TabIndex = 23
    Me.Button2.Text = "插入一筆"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'Button3
    '
    Me.Button3.Location = New System.Drawing.Point(557, 6)
    Me.Button3.Name = "Button3"
    Me.Button3.Size = New System.Drawing.Size(102, 32)
    Me.Button3.TabIndex = 24
    Me.Button3.Text = "刪除一筆"
    Me.Button3.UseVisualStyleBackColor = True
    '
    'Button4
    '
    Me.Button4.Location = New System.Drawing.Point(665, 6)
    Me.Button4.Name = "Button4"
    Me.Button4.Size = New System.Drawing.Size(102, 32)
    Me.Button4.TabIndex = 25
    Me.Button4.Text = "上移"
    Me.Button4.UseVisualStyleBackColor = True
    '
    'Button5
    '
    Me.Button5.Location = New System.Drawing.Point(773, 6)
    Me.Button5.Name = "Button5"
    Me.Button5.Size = New System.Drawing.Size(102, 32)
    Me.Button5.TabIndex = 26
    Me.Button5.Text = "下移"
    Me.Button5.UseVisualStyleBackColor = True
    '
    'Frm0332
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 19.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1003, 413)
    Me.Controls.Add(Me.TabControl1)
    Me.Font = New System.Drawing.Font("細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
    Me.Name = "Frm0332"
    Me.Text = "Frm0332"
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.TabControl1.ResumeLayout(False)
    Me.TabPage1.ResumeLayout(False)
    Me.TabPage2.ResumeLayout(False)
    CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.DG1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Panel2.ResumeLayout(False)
    Me.Panel2.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
  Friend WithEvents LabFlowcode As System.Windows.Forms.Label
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
  Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
  Friend WithEvents DG As System.Windows.Forms.DataGridView
  Friend WithEvents DG1 As System.Windows.Forms.DataGridView
  Friend WithEvents Panel2 As System.Windows.Forms.Panel
  Friend WithEvents Button5 As System.Windows.Forms.Button
  Friend WithEvents Button4 As System.Windows.Forms.Button
  Friend WithEvents Button3 As System.Windows.Forms.Button
  Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
