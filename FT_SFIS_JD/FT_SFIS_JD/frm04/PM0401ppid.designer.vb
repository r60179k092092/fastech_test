<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PM0401ppid
    Inherits System.Windows.Forms.Form

    'Form 重寫 Dispose，以清理組件列表。
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

    'Windows 窗體設計器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下過程是 Windows 窗體設計器所必需的
    '可以使用 Windows 窗體設計器修改它。
    '不要使用代碼編輯器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Rbtfu = New System.Windows.Forms.RadioButton()
    Me.rbtzhu = New System.Windows.Forms.RadioButton()
    Me.Btnppidconfirm = New System.Windows.Forms.Button()
    Me.PQTY = New System.Windows.Forms.TextBox()
    Me.Button3 = New System.Windows.Forms.Button()
    Me.SmpQTy = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.PB = New System.Windows.Forms.ProgressBar()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.PRTBG = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.IDED = New System.Windows.Forms.Label()
    Me.IDBG = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.SNED = New System.Windows.Forms.Label()
    Me.SNBG = New System.Windows.Forms.Label()
    Me.MOQTY = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.MO = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.ListBox1 = New System.Windows.Forms.ListBox()
    Me.Panel2 = New System.Windows.Forms.Panel()
    Me.Panel4 = New System.Windows.Forms.Panel()
    Me.Panel6 = New System.Windows.Forms.Panel()
    Me.YOFF = New System.Windows.Forms.TextBox()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.XOFF = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.TMP = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.PTYPE = New System.Windows.Forms.ComboBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.PRT = New System.Windows.Forms.ComboBox()
    Me.Label19 = New System.Windows.Forms.Label()
    Me.LBFID = New System.Windows.Forms.ComboBox()
    Me.Label23 = New System.Windows.Forms.Label()
    Me.Button5 = New System.Windows.Forms.Button()
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.Panel2.SuspendLayout()
    Me.Panel6.SuspendLayout()
    Me.Panel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(335, 189)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(89, 20)
    Me.Label6.TabIndex = 96
    Me.Label6.Text = "序號數量："
    Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Rbtfu
    '
    Me.Rbtfu.AutoSize = True
    Me.Rbtfu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Rbtfu.Location = New System.Drawing.Point(11, 156)
    Me.Rbtfu.Name = "Rbtfu"
    Me.Rbtfu.Size = New System.Drawing.Size(112, 24)
    Me.Rbtfu.TabIndex = 94
    Me.Rbtfu.Text = "料件PPID："
    Me.Rbtfu.UseVisualStyleBackColor = True
    '
    'rbtzhu
    '
    Me.rbtzhu.AutoSize = True
    Me.rbtzhu.Checked = True
    Me.rbtzhu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.rbtzhu.Location = New System.Drawing.Point(22, 123)
    Me.rbtzhu.Name = "rbtzhu"
    Me.rbtzhu.Size = New System.Drawing.Size(101, 24)
    Me.rbtzhu.TabIndex = 94
    Me.rbtzhu.TabStop = True
    Me.rbtzhu.Text = "產品S/N："
    Me.rbtzhu.UseVisualStyleBackColor = True
    '
    'Btnppidconfirm
    '
    Me.Btnppidconfirm.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
    Me.Btnppidconfirm.Location = New System.Drawing.Point(630, 6)
    Me.Btnppidconfirm.Name = "Btnppidconfirm"
    Me.Btnppidconfirm.Size = New System.Drawing.Size(99, 27)
    Me.Btnppidconfirm.TabIndex = 2
    Me.Btnppidconfirm.Text = "打印"
    Me.Btnppidconfirm.UseVisualStyleBackColor = True
    '
    'PQTY
    '
    Me.PQTY.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.PQTY.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.PQTY.Location = New System.Drawing.Point(420, 186)
    Me.PQTY.Name = "PQTY"
    Me.PQTY.Size = New System.Drawing.Size(60, 26)
    Me.PQTY.TabIndex = 1
    '
    'Button3
    '
    Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
    Me.Button3.Location = New System.Drawing.Point(324, 6)
    Me.Button3.Name = "Button3"
    Me.Button3.Size = New System.Drawing.Size(99, 27)
    Me.Button3.TabIndex = 115
    Me.Button3.TabStop = False
    Me.Button3.Text = "導入序號"
    Me.Button3.UseVisualStyleBackColor = True
    '
    'SmpQTy
    '
    Me.SmpQTy.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.SmpQTy.Location = New System.Drawing.Point(527, 94)
    Me.SmpQTy.Name = "SmpQTy"
    Me.SmpQTy.Size = New System.Drawing.Size(47, 20)
    Me.SmpQTy.TabIndex = 114
    Me.SmpQTy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label8.Location = New System.Drawing.Point(478, 94)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(57, 20)
    Me.Label8.TabIndex = 113
    Me.Label8.Text = "樣品："
    Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'PB
    '
    Me.PB.Location = New System.Drawing.Point(6, 8)
    Me.PB.Name = "PB"
    Me.PB.Size = New System.Drawing.Size(312, 23)
    Me.PB.TabIndex = 112
    '
    'Button2
    '
    Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
    Me.Button2.Location = New System.Drawing.Point(426, 6)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(99, 27)
    Me.Button2.TabIndex = 111
    Me.Button2.TabStop = False
    Me.Button2.Text = "產生序號"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'PRTBG
    '
    Me.PRTBG.Location = New System.Drawing.Point(119, 186)
    Me.PRTBG.Name = "PRTBG"
    Me.PRTBG.Size = New System.Drawing.Size(213, 26)
    Me.PRTBG.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label1.Location = New System.Drawing.Point(50, 189)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(73, 20)
    Me.Label1.TabIndex = 109
    Me.Label1.Text = "從序號："
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label7.Location = New System.Drawing.Point(335, 158)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(25, 20)
    Me.Label7.TabIndex = 108
    Me.Label7.Text = "至"
    Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'IDED
    '
    Me.IDED.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.IDED.Location = New System.Drawing.Point(361, 158)
    Me.IDED.Name = "IDED"
    Me.IDED.Size = New System.Drawing.Size(213, 20)
    Me.IDED.TabIndex = 107
    Me.IDED.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'IDBG
    '
    Me.IDBG.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.IDBG.Location = New System.Drawing.Point(119, 158)
    Me.IDBG.Name = "IDBG"
    Me.IDBG.Size = New System.Drawing.Size(213, 20)
    Me.IDBG.TabIndex = 106
    Me.IDBG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label4.Location = New System.Drawing.Point(335, 125)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(25, 20)
    Me.Label4.TabIndex = 105
    Me.Label4.Text = "至"
    Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'SNED
    '
    Me.SNED.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.SNED.Location = New System.Drawing.Point(361, 125)
    Me.SNED.Name = "SNED"
    Me.SNED.Size = New System.Drawing.Size(213, 20)
    Me.SNED.TabIndex = 104
    Me.SNED.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'SNBG
    '
    Me.SNBG.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.SNBG.Location = New System.Drawing.Point(119, 125)
    Me.SNBG.Name = "SNBG"
    Me.SNBG.Size = New System.Drawing.Size(213, 20)
    Me.SNBG.TabIndex = 103
    Me.SNBG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'MOQTY
    '
    Me.MOQTY.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.MOQTY.Location = New System.Drawing.Point(414, 94)
    Me.MOQTY.Name = "MOQTY"
    Me.MOQTY.Size = New System.Drawing.Size(62, 20)
    Me.MOQTY.TabIndex = 102
    Me.MOQTY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label5.Location = New System.Drawing.Point(335, 94)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(89, 20)
    Me.Label5.TabIndex = 101
    Me.Label5.Text = "工單數量："
    Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'MO
    '
    Me.MO.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.MO.Location = New System.Drawing.Point(119, 94)
    Me.MO.Name = "MO"
    Me.MO.Size = New System.Drawing.Size(213, 20)
    Me.MO.TabIndex = 100
    Me.MO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label3.Location = New System.Drawing.Point(34, 94)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(89, 20)
    Me.Label3.TabIndex = 99
    Me.Label3.Text = "工單編號："
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Button1
    '
    Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
    Me.Button1.Location = New System.Drawing.Point(528, 6)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(99, 27)
    Me.Button1.TabIndex = 98
    Me.Button1.TabStop = False
    Me.Button1.Text = "重新檢驗"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'ListBox1
    '
    Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ListBox1.ForeColor = System.Drawing.Color.Red
    Me.ListBox1.FormattingEnabled = True
    Me.ListBox1.ItemHeight = 24
    Me.ListBox1.Location = New System.Drawing.Point(0, 258)
    Me.ListBox1.Name = "ListBox1"
    Me.ListBox1.Size = New System.Drawing.Size(840, 231)
    Me.ListBox1.TabIndex = 98
    Me.ListBox1.TabStop = False
    '
    'Panel2
    '
    Me.Panel2.Controls.Add(Me.Panel4)
    Me.Panel2.Controls.Add(Me.Panel6)
    Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel2.Location = New System.Drawing.Point(0, 0)
    Me.Panel2.Name = "Panel2"
    Me.Panel2.Size = New System.Drawing.Size(840, 221)
    Me.Panel2.TabIndex = 99
    '
    'Panel4
    '
    Me.Panel4.BackColor = System.Drawing.Color.Black
    Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
    Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Panel4.Location = New System.Drawing.Point(580, 0)
    Me.Panel4.Name = "Panel4"
    Me.Panel4.Size = New System.Drawing.Size(260, 221)
    Me.Panel4.TabIndex = 100
    '
    'Panel6
    '
    Me.Panel6.Controls.Add(Me.YOFF)
    Me.Panel6.Controls.Add(Me.Label13)
    Me.Panel6.Controls.Add(Me.XOFF)
    Me.Panel6.Controls.Add(Me.Label12)
    Me.Panel6.Controls.Add(Me.TMP)
    Me.Panel6.Controls.Add(Me.Label11)
    Me.Panel6.Controls.Add(Me.Label10)
    Me.Panel6.Controls.Add(Me.Label2)
    Me.Panel6.Controls.Add(Me.TextBox1)
    Me.Panel6.Controls.Add(Me.SNBG)
    Me.Panel6.Controls.Add(Me.PQTY)
    Me.Panel6.Controls.Add(Me.PTYPE)
    Me.Panel6.Controls.Add(Me.SmpQTy)
    Me.Panel6.Controls.Add(Me.Label9)
    Me.Panel6.Controls.Add(Me.Label8)
    Me.Panel6.Controls.Add(Me.PRT)
    Me.Panel6.Controls.Add(Me.PRTBG)
    Me.Panel6.Controls.Add(Me.Label19)
    Me.Panel6.Controls.Add(Me.Label1)
    Me.Panel6.Controls.Add(Me.LBFID)
    Me.Panel6.Controls.Add(Me.Label7)
    Me.Panel6.Controls.Add(Me.Label23)
    Me.Panel6.Controls.Add(Me.IDED)
    Me.Panel6.Controls.Add(Me.SNED)
    Me.Panel6.Controls.Add(Me.IDBG)
    Me.Panel6.Controls.Add(Me.rbtzhu)
    Me.Panel6.Controls.Add(Me.Label4)
    Me.Panel6.Controls.Add(Me.Rbtfu)
    Me.Panel6.Controls.Add(Me.Label6)
    Me.Panel6.Controls.Add(Me.MOQTY)
    Me.Panel6.Controls.Add(Me.Label5)
    Me.Panel6.Controls.Add(Me.MO)
    Me.Panel6.Controls.Add(Me.Label3)
    Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
    Me.Panel6.Location = New System.Drawing.Point(0, 0)
    Me.Panel6.Name = "Panel6"
    Me.Panel6.Size = New System.Drawing.Size(580, 221)
    Me.Panel6.TabIndex = 9
    '
    'YOFF
    '
    Me.YOFF.Location = New System.Drawing.Point(488, 62)
    Me.YOFF.Name = "YOFF"
    Me.YOFF.Size = New System.Drawing.Size(50, 26)
    Me.YOFF.TabIndex = 123
    '
    'Label13
    '
    Me.Label13.AutoSize = True
    Me.Label13.Location = New System.Drawing.Point(416, 65)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(68, 20)
    Me.Label13.TabIndex = 122
    Me.Label13.Text = "YOFF："
    '
    'XOFF
    '
    Me.XOFF.Location = New System.Drawing.Point(488, 33)
    Me.XOFF.Name = "XOFF"
    Me.XOFF.Size = New System.Drawing.Size(50, 26)
    Me.XOFF.TabIndex = 121
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.Location = New System.Drawing.Point(416, 36)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(68, 20)
    Me.Label12.TabIndex = 120
    Me.Label12.Text = "XOFF："
    '
    'TMP
    '
    Me.TMP.Location = New System.Drawing.Point(488, 4)
    Me.TMP.Name = "TMP"
    Me.TMP.Size = New System.Drawing.Size(50, 26)
    Me.TMP.TabIndex = 119
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(427, 7)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(57, 20)
    Me.Label11.TabIndex = 118
    Me.Label11.Text = "溫度："
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.Location = New System.Drawing.Point(486, 189)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(13, 20)
    Me.Label10.TabIndex = 117
    Me.Label10.Text = "/"
    Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(543, 189)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(25, 20)
    Me.Label2.TabIndex = 116
    Me.Label2.Text = "排"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TextBox1
    '
    Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox1.Location = New System.Drawing.Point(502, 186)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(39, 26)
    Me.TextBox1.TabIndex = 115
    Me.TextBox1.Text = "1"
    '
    'PTYPE
    '
    Me.PTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.PTYPE.FormattingEnabled = True
    Me.PTYPE.Location = New System.Drawing.Point(119, 3)
    Me.PTYPE.Name = "PTYPE"
    Me.PTYPE.Size = New System.Drawing.Size(291, 28)
    Me.PTYPE.TabIndex = 32
    Me.PTYPE.TabStop = False
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(18, 7)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(105, 20)
    Me.Label9.TabIndex = 31
    Me.Label9.Text = "打印機類型："
    '
    'PRT
    '
    Me.PRT.FormattingEnabled = True
    Me.PRT.Location = New System.Drawing.Point(119, 32)
    Me.PRT.Name = "PRT"
    Me.PRT.Size = New System.Drawing.Size(291, 28)
    Me.PRT.TabIndex = 8
    Me.PRT.TabStop = False
    '
    'Label19
    '
    Me.Label19.AutoSize = True
    Me.Label19.Location = New System.Drawing.Point(18, 36)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(105, 20)
    Me.Label19.TabIndex = 7
    Me.Label19.Text = "打印機名稱："
    '
    'LBFID
    '
    Me.LBFID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.LBFID.FormattingEnabled = True
    Me.LBFID.Location = New System.Drawing.Point(119, 61)
    Me.LBFID.Name = "LBFID"
    Me.LBFID.Size = New System.Drawing.Size(291, 28)
    Me.LBFID.TabIndex = 6
    Me.LBFID.TabStop = False
    '
    'Label23
    '
    Me.Label23.AutoSize = True
    Me.Label23.Location = New System.Drawing.Point(2, 65)
    Me.Label23.Name = "Label23"
    Me.Label23.Size = New System.Drawing.Size(121, 20)
    Me.Label23.TabIndex = 5
    Me.Label23.Text = "標籤格式編號："
    '
    'Button5
    '
    Me.Button5.Location = New System.Drawing.Point(732, 6)
    Me.Button5.Name = "Button5"
    Me.Button5.Size = New System.Drawing.Size(99, 27)
    Me.Button5.TabIndex = 35
    Me.Button5.Text = "離開"
    Me.Button5.UseVisualStyleBackColor = True
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.Button5)
    Me.Panel1.Controls.Add(Me.Button3)
    Me.Panel1.Controls.Add(Me.Button1)
    Me.Panel1.Controls.Add(Me.Btnppidconfirm)
    Me.Panel1.Controls.Add(Me.Button2)
    Me.Panel1.Controls.Add(Me.PB)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Location = New System.Drawing.Point(0, 221)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(840, 37)
    Me.Panel1.TabIndex = 100
    '
    'PM0401ppid
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(840, 489)
    Me.ControlBox = False
    Me.Controls.Add(Me.ListBox1)
    Me.Controls.Add(Me.Panel1)
    Me.Controls.Add(Me.Panel2)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
    Me.Name = "PM0401ppid"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "產品序號管理"
    Me.Panel2.ResumeLayout(False)
    Me.Panel6.ResumeLayout(False)
    Me.Panel6.PerformLayout()
    Me.Panel1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Rbtfu As System.Windows.Forms.RadioButton
  Friend WithEvents rbtzhu As System.Windows.Forms.RadioButton
  Friend WithEvents Btnppidconfirm As System.Windows.Forms.Button
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents PQTY As System.Windows.Forms.TextBox
  Friend WithEvents PB As System.Windows.Forms.ProgressBar
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents PRTBG As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents IDED As System.Windows.Forms.Label
  Friend WithEvents IDBG As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents SNED As System.Windows.Forms.Label
  Friend WithEvents SNBG As System.Windows.Forms.Label
  Friend WithEvents MOQTY As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents MO As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
  Friend WithEvents SmpQTy As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents Button3 As System.Windows.Forms.Button
  Friend WithEvents Panel2 As System.Windows.Forms.Panel
  Friend WithEvents Panel6 As System.Windows.Forms.Panel
  Friend WithEvents PTYPE As System.Windows.Forms.ComboBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents PRT As System.Windows.Forms.ComboBox
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents LBFID As System.Windows.Forms.ComboBox
  Friend WithEvents Label23 As System.Windows.Forms.Label
  Friend WithEvents Panel4 As System.Windows.Forms.Panel
  Friend WithEvents Button5 As System.Windows.Forms.Button
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents YOFF As System.Windows.Forms.TextBox
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents XOFF As System.Windows.Forms.TextBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents TMP As System.Windows.Forms.TextBox
  Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
