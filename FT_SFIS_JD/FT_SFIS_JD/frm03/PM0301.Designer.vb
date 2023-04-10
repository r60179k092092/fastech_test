<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PM0301
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
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.TJ18 = New System.Windows.Forms.DateTimePicker()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.TJ17 = New System.Windows.Forms.DateTimePicker()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.TJ16 = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.txtPNG = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.txtSCAN = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.txtEXT = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.BtnOFL = New System.Windows.Forms.Button()
    Me.cmbTYPE = New System.Windows.Forms.ComboBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.txtPATH = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.BT = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Cmbmachinestate = New System.Windows.Forms.ComboBox()
    Me.Txtcurrentwork = New System.Windows.Forms.TextBox()
    Me.Labcurrentjobno = New System.Windows.Forms.Label()
    Me.Labmachinestate = New System.Windows.Forms.Label()
    Me.Datnextmaintain = New System.Windows.Forms.DateTimePicker()
    Me.Datlastmaintain = New System.Windows.Forms.DateTimePicker()
    Me.Labnextdate = New System.Windows.Forms.Label()
    Me.Cmbline = New System.Windows.Forms.ComboBox()
    Me.Labline = New System.Windows.Forms.Label()
    Me.Txtlastusedate = New System.Windows.Forms.TextBox()
    Me.Lablastusedate = New System.Windows.Forms.Label()
    Me.Txtmanage = New System.Windows.Forms.TextBox()
    Me.Labmanager = New System.Windows.Forms.Label()
    Me.Txtmaintenance = New System.Windows.Forms.TextBox()
    Me.Txtmachinename = New System.Windows.Forms.TextBox()
    Me.Txtmachinecode = New System.Windows.Forms.TextBox()
    Me.Lablastdate = New System.Windows.Forms.Label()
    Me.LabProtecter = New System.Windows.Forms.Label()
    Me.Labchname = New System.Windows.Forms.Label()
    Me.Labmachinecode = New System.Windows.Forms.Label()
    Me.DGjt = New System.Windows.Forms.DataGridView()
    Me.Panel1.SuspendLayout()
    CType(Me.DGjt, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.TJ18)
    Me.Panel1.Controls.Add(Me.Label10)
    Me.Panel1.Controls.Add(Me.TJ17)
    Me.Panel1.Controls.Add(Me.Label9)
    Me.Panel1.Controls.Add(Me.TJ16)
    Me.Panel1.Controls.Add(Me.Label8)
    Me.Panel1.Controls.Add(Me.Button1)
    Me.Panel1.Controls.Add(Me.txtPNG)
    Me.Panel1.Controls.Add(Me.Label7)
    Me.Panel1.Controls.Add(Me.Label6)
    Me.Panel1.Controls.Add(Me.txtSCAN)
    Me.Panel1.Controls.Add(Me.Label5)
    Me.Panel1.Controls.Add(Me.txtEXT)
    Me.Panel1.Controls.Add(Me.Label4)
    Me.Panel1.Controls.Add(Me.BtnOFL)
    Me.Panel1.Controls.Add(Me.cmbTYPE)
    Me.Panel1.Controls.Add(Me.Label3)
    Me.Panel1.Controls.Add(Me.txtPATH)
    Me.Panel1.Controls.Add(Me.Label2)
    Me.Panel1.Controls.Add(Me.BT)
    Me.Panel1.Controls.Add(Me.Label1)
    Me.Panel1.Controls.Add(Me.Cmbmachinestate)
    Me.Panel1.Controls.Add(Me.Txtcurrentwork)
    Me.Panel1.Controls.Add(Me.Labcurrentjobno)
    Me.Panel1.Controls.Add(Me.Labmachinestate)
    Me.Panel1.Controls.Add(Me.Datnextmaintain)
    Me.Panel1.Controls.Add(Me.Datlastmaintain)
    Me.Panel1.Controls.Add(Me.Labnextdate)
    Me.Panel1.Controls.Add(Me.Cmbline)
    Me.Panel1.Controls.Add(Me.Labline)
    Me.Panel1.Controls.Add(Me.Txtlastusedate)
    Me.Panel1.Controls.Add(Me.Lablastusedate)
    Me.Panel1.Controls.Add(Me.Txtmanage)
    Me.Panel1.Controls.Add(Me.Labmanager)
    Me.Panel1.Controls.Add(Me.Txtmaintenance)
    Me.Panel1.Controls.Add(Me.Txtmachinename)
    Me.Panel1.Controls.Add(Me.Txtmachinecode)
    Me.Panel1.Controls.Add(Me.Lablastdate)
    Me.Panel1.Controls.Add(Me.LabProtecter)
    Me.Panel1.Controls.Add(Me.Labchname)
    Me.Panel1.Controls.Add(Me.Labmachinecode)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(947, 254)
    Me.Panel1.TabIndex = 2
    '
    'TJ18
    '
    Me.TJ18.CalendarFont = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
    Me.TJ18.CustomFormat = "yyyy/MM/dd"
    Me.TJ18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TJ18.Format = System.Windows.Forms.DateTimePickerFormat.Custom
    Me.TJ18.Location = New System.Drawing.Point(407, 222)
    Me.TJ18.Name = "TJ18"
    Me.TJ18.Size = New System.Drawing.Size(132, 26)
    Me.TJ18.TabIndex = 16
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.Label10.Location = New System.Drawing.Point(296, 227)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(105, 20)
    Me.Label10.TabIndex = 82
    Me.Label10.Text = "下次外校日期"
    Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TJ17
    '
    Me.TJ17.CalendarFont = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
    Me.TJ17.CustomFormat = "yyyy/MM/dd"
    Me.TJ17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TJ17.Format = System.Windows.Forms.DateTimePickerFormat.Custom
    Me.TJ17.Location = New System.Drawing.Point(122, 221)
    Me.TJ17.Name = "TJ17"
    Me.TJ17.Size = New System.Drawing.Size(132, 26)
    Me.TJ17.TabIndex = 15
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.Label9.Location = New System.Drawing.Point(11, 226)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(105, 20)
    Me.Label9.TabIndex = 80
    Me.Label9.Text = "下次內校日期"
    Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TJ16
    '
    Me.TJ16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TJ16.Location = New System.Drawing.Point(668, 191)
    Me.TJ16.Name = "TJ16"
    Me.TJ16.Size = New System.Drawing.Size(121, 26)
    Me.TJ16.TabIndex = 14
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.Location = New System.Drawing.Point(560, 196)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(105, 20)
    Me.Label8.TabIndex = 78
    Me.Label8.Text = "連結機台序號"
    Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Button1
    '
    Me.Button1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Button1.Location = New System.Drawing.Point(767, 163)
    Me.Button1.Margin = New System.Windows.Forms.Padding(0)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(30, 23)
    Me.Button1.TabIndex = 76
    Me.Button1.TabStop = False
    Me.Button1.Text = "..."
    Me.Button1.UseVisualStyleBackColor = True
    '
    'txtPNG
    '
    Me.txtPNG.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtPNG.Location = New System.Drawing.Point(122, 161)
    Me.txtPNG.Name = "txtPNG"
    Me.txtPNG.Size = New System.Drawing.Size(642, 26)
    Me.txtPNG.TabIndex = 11
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(27, 166)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(97, 20)
    Me.Label7.TabIndex = 75
    Me.Label7.Text = "NG轉檔路徑"
    Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(480, 196)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(25, 20)
    Me.Label6.TabIndex = 73
    Me.Label6.Text = "秒"
    Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtSCAN
    '
    Me.txtSCAN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtSCAN.Location = New System.Drawing.Point(407, 191)
    Me.txtSCAN.Name = "txtSCAN"
    Me.txtSCAN.Size = New System.Drawing.Size(67, 26)
    Me.txtSCAN.TabIndex = 13
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(328, 196)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(73, 20)
    Me.Label5.TabIndex = 72
    Me.Label5.Text = "轉檔間隔"
    Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtEXT
    '
    Me.txtEXT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtEXT.Location = New System.Drawing.Point(122, 191)
    Me.txtEXT.Name = "txtEXT"
    Me.txtEXT.Size = New System.Drawing.Size(121, 26)
    Me.txtEXT.TabIndex = 12
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(27, 196)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(89, 20)
    Me.Label4.TabIndex = 70
    Me.Label4.Text = "轉檔副檔名"
    Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'BtnOFL
    '
    Me.BtnOFL.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnOFL.Location = New System.Drawing.Point(767, 132)
    Me.BtnOFL.Margin = New System.Windows.Forms.Padding(0)
    Me.BtnOFL.Name = "BtnOFL"
    Me.BtnOFL.Size = New System.Drawing.Size(30, 23)
    Me.BtnOFL.TabIndex = 68
    Me.BtnOFL.TabStop = False
    Me.BtnOFL.Text = "..."
    Me.BtnOFL.UseVisualStyleBackColor = True
    '
    'cmbTYPE
    '
    Me.cmbTYPE.BackColor = System.Drawing.Color.White
    Me.cmbTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cmbTYPE.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.cmbTYPE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cmbTYPE.FormattingEnabled = True
    Me.cmbTYPE.Items.AddRange(New Object() {"0: 無", "1: 川普", "2: 庫卡"})
    Me.cmbTYPE.Location = New System.Drawing.Point(668, 100)
    Me.cmbTYPE.Name = "cmbTYPE"
    Me.cmbTYPE.Size = New System.Drawing.Size(129, 28)
    Me.cmbTYPE.TabIndex = 9
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(560, 104)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(105, 20)
    Me.Label3.TabIndex = 67
    Me.Label3.Text = "轉檔格式類型"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtPATH
    '
    Me.txtPATH.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtPATH.Location = New System.Drawing.Point(122, 130)
    Me.txtPATH.Name = "txtPATH"
    Me.txtPATH.Size = New System.Drawing.Size(642, 26)
    Me.txtPATH.TabIndex = 10
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(43, 135)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(73, 20)
    Me.Label2.TabIndex = 65
    Me.Label2.Text = "轉檔路徑"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'BT
    '
    Me.BT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BT.Location = New System.Drawing.Point(668, 68)
    Me.BT.Name = "BT"
    Me.BT.Size = New System.Drawing.Size(129, 26)
    Me.BT.TabIndex = 8
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.Label1.Location = New System.Drawing.Point(552, 73)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(123, 20)
    Me.Label1.TabIndex = 63
    Me.Label1.Text = "SMT控制藍芽ID"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Cmbmachinestate
    '
    Me.Cmbmachinestate.BackColor = System.Drawing.Color.AntiqueWhite
    Me.Cmbmachinestate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.Cmbmachinestate.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.Cmbmachinestate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Cmbmachinestate.FormattingEnabled = True
    Me.Cmbmachinestate.Items.AddRange(New Object() {"0.正常", "1.保養維修中", "2.暫停使用中", "3.外修中"})
    Me.Cmbmachinestate.Location = New System.Drawing.Point(668, 7)
    Me.Cmbmachinestate.Name = "Cmbmachinestate"
    Me.Cmbmachinestate.Size = New System.Drawing.Size(129, 28)
    Me.Cmbmachinestate.TabIndex = 2
    '
    'Txtcurrentwork
    '
    Me.Txtcurrentwork.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Txtcurrentwork.Location = New System.Drawing.Point(407, 99)
    Me.Txtcurrentwork.Name = "Txtcurrentwork"
    Me.Txtcurrentwork.ReadOnly = True
    Me.Txtcurrentwork.Size = New System.Drawing.Size(132, 26)
    Me.Txtcurrentwork.TabIndex = 48
    '
    'Labcurrentjobno
    '
    Me.Labcurrentjobno.AutoSize = True
    Me.Labcurrentjobno.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Labcurrentjobno.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.Labcurrentjobno.Location = New System.Drawing.Point(296, 104)
    Me.Labcurrentjobno.Name = "Labcurrentjobno"
    Me.Labcurrentjobno.Size = New System.Drawing.Size(105, 20)
    Me.Labcurrentjobno.TabIndex = 46
    Me.Labcurrentjobno.Text = "目前工單編號"
    Me.Labcurrentjobno.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Labmachinestate
    '
    Me.Labmachinestate.AutoSize = True
    Me.Labmachinestate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Labmachinestate.Location = New System.Drawing.Point(592, 11)
    Me.Labmachinestate.Name = "Labmachinestate"
    Me.Labmachinestate.Size = New System.Drawing.Size(73, 20)
    Me.Labmachinestate.TabIndex = 52
    Me.Labmachinestate.Text = "機臺狀態"
    Me.Labmachinestate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Datnextmaintain
    '
    Me.Datnextmaintain.CalendarFont = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
    Me.Datnextmaintain.CustomFormat = "yyyy/MM/dd"
    Me.Datnextmaintain.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Datnextmaintain.Format = System.Windows.Forms.DateTimePickerFormat.Custom
    Me.Datnextmaintain.Location = New System.Drawing.Point(407, 68)
    Me.Datnextmaintain.Name = "Datnextmaintain"
    Me.Datnextmaintain.Size = New System.Drawing.Size(132, 26)
    Me.Datnextmaintain.TabIndex = 7
    '
    'Datlastmaintain
    '
    Me.Datlastmaintain.CalendarFont = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
    Me.Datlastmaintain.CustomFormat = "yyyy/MM/dd"
    Me.Datlastmaintain.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Datlastmaintain.Format = System.Windows.Forms.DateTimePickerFormat.Custom
    Me.Datlastmaintain.Location = New System.Drawing.Point(122, 68)
    Me.Datlastmaintain.Name = "Datlastmaintain"
    Me.Datlastmaintain.Size = New System.Drawing.Size(121, 26)
    Me.Datlastmaintain.TabIndex = 6
    '
    'Labnextdate
    '
    Me.Labnextdate.AutoSize = True
    Me.Labnextdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Labnextdate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.Labnextdate.Location = New System.Drawing.Point(296, 73)
    Me.Labnextdate.Name = "Labnextdate"
    Me.Labnextdate.Size = New System.Drawing.Size(105, 20)
    Me.Labnextdate.TabIndex = 61
    Me.Labnextdate.Text = "下次保養日期"
    Me.Labnextdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Cmbline
    '
    Me.Cmbline.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.Cmbline.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Cmbline.FormattingEnabled = True
    Me.Cmbline.Location = New System.Drawing.Point(668, 38)
    Me.Cmbline.Name = "Cmbline"
    Me.Cmbline.Size = New System.Drawing.Size(129, 28)
    Me.Cmbline.TabIndex = 5
    '
    'Labline
    '
    Me.Labline.AutoSize = True
    Me.Labline.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Labline.Location = New System.Drawing.Point(624, 42)
    Me.Labline.Name = "Labline"
    Me.Labline.Size = New System.Drawing.Size(41, 20)
    Me.Labline.TabIndex = 59
    Me.Labline.Text = "線別"
    Me.Labline.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Txtlastusedate
    '
    Me.Txtlastusedate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Txtlastusedate.Location = New System.Drawing.Point(122, 99)
    Me.Txtlastusedate.Name = "Txtlastusedate"
    Me.Txtlastusedate.ReadOnly = True
    Me.Txtlastusedate.Size = New System.Drawing.Size(121, 26)
    Me.Txtlastusedate.TabIndex = 58
    '
    'Lablastusedate
    '
    Me.Lablastusedate.AutoSize = True
    Me.Lablastusedate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Lablastusedate.Location = New System.Drawing.Point(11, 104)
    Me.Lablastusedate.Name = "Lablastusedate"
    Me.Lablastusedate.Size = New System.Drawing.Size(105, 20)
    Me.Lablastusedate.TabIndex = 57
    Me.Lablastusedate.Text = "最后使用日期"
    Me.Lablastusedate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Txtmanage
    '
    Me.Txtmanage.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Txtmanage.Location = New System.Drawing.Point(407, 37)
    Me.Txtmanage.Name = "Txtmanage"
    Me.Txtmanage.Size = New System.Drawing.Size(132, 26)
    Me.Txtmanage.TabIndex = 4
    '
    'Labmanager
    '
    Me.Labmanager.AutoSize = True
    Me.Labmanager.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Labmanager.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.Labmanager.Location = New System.Drawing.Point(312, 42)
    Me.Labmanager.Name = "Labmanager"
    Me.Labmanager.Size = New System.Drawing.Size(89, 20)
    Me.Labmanager.TabIndex = 54
    Me.Labmanager.Text = "管理責任人"
    Me.Labmanager.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Txtmaintenance
    '
    Me.Txtmaintenance.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Txtmaintenance.Location = New System.Drawing.Point(122, 37)
    Me.Txtmaintenance.Name = "Txtmaintenance"
    Me.Txtmaintenance.Size = New System.Drawing.Size(121, 26)
    Me.Txtmaintenance.TabIndex = 3
    '
    'Txtmachinename
    '
    Me.Txtmachinename.BackColor = System.Drawing.Color.AntiqueWhite
    Me.Txtmachinename.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Txtmachinename.Location = New System.Drawing.Point(407, 6)
    Me.Txtmachinename.Name = "Txtmachinename"
    Me.Txtmachinename.Size = New System.Drawing.Size(132, 26)
    Me.Txtmachinename.TabIndex = 1
    '
    'Txtmachinecode
    '
    Me.Txtmachinecode.BackColor = System.Drawing.Color.AntiqueWhite
    Me.Txtmachinecode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Txtmachinecode.Location = New System.Drawing.Point(122, 6)
    Me.Txtmachinecode.Name = "Txtmachinecode"
    Me.Txtmachinecode.Size = New System.Drawing.Size(121, 26)
    Me.Txtmachinecode.TabIndex = 0
    '
    'Lablastdate
    '
    Me.Lablastdate.AutoSize = True
    Me.Lablastdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Lablastdate.Location = New System.Drawing.Point(11, 73)
    Me.Lablastdate.Name = "Lablastdate"
    Me.Lablastdate.Size = New System.Drawing.Size(105, 20)
    Me.Lablastdate.TabIndex = 43
    Me.Lablastdate.Text = "最后保養日期"
    Me.Lablastdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LabProtecter
    '
    Me.LabProtecter.AutoSize = True
    Me.LabProtecter.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabProtecter.Location = New System.Drawing.Point(27, 42)
    Me.LabProtecter.Name = "LabProtecter"
    Me.LabProtecter.Size = New System.Drawing.Size(89, 20)
    Me.LabProtecter.TabIndex = 41
    Me.LabProtecter.Text = "保養責任人"
    Me.LabProtecter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Labchname
    '
    Me.Labchname.AutoSize = True
    Me.Labchname.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Labchname.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.Labchname.Location = New System.Drawing.Point(328, 11)
    Me.Labchname.Name = "Labchname"
    Me.Labchname.Size = New System.Drawing.Size(73, 20)
    Me.Labchname.TabIndex = 45
    Me.Labchname.Text = "機臺名稱"
    Me.Labchname.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Labmachinecode
    '
    Me.Labmachinecode.AutoSize = True
    Me.Labmachinecode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Labmachinecode.Location = New System.Drawing.Point(43, 11)
    Me.Labmachinecode.Name = "Labmachinecode"
    Me.Labmachinecode.Size = New System.Drawing.Size(73, 20)
    Me.Labmachinecode.TabIndex = 44
    Me.Labmachinecode.Text = "機臺編號"
    Me.Labmachinecode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'DGjt
    '
    Me.DGjt.AllowUserToAddRows = False
    Me.DGjt.AllowUserToDeleteRows = False
    Me.DGjt.AllowUserToOrderColumns = True
    Me.DGjt.AllowUserToResizeRows = False
    DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.DGjt.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
    Me.DGjt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DGjt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DGjt.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DGjt.Location = New System.Drawing.Point(0, 254)
    Me.DGjt.MultiSelect = False
    Me.DGjt.Name = "DGjt"
    Me.DGjt.ReadOnly = True
    Me.DGjt.RowTemplate.Height = 23
    Me.DGjt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DGjt.Size = New System.Drawing.Size(947, 311)
    Me.DGjt.TabIndex = 3
    '
    'PM0301
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(947, 565)
    Me.Controls.Add(Me.DGjt)
    Me.Controls.Add(Me.Panel1)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Name = "PM0301"
    Me.Text = "機臺0301"
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    CType(Me.DGjt, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Labcurrentjobno As System.Windows.Forms.Label
  Friend WithEvents Labmachinestate As System.Windows.Forms.Label
  Friend WithEvents Txtcurrentwork As System.Windows.Forms.TextBox
  Friend WithEvents Datnextmaintain As System.Windows.Forms.DateTimePicker
  Friend WithEvents Datlastmaintain As System.Windows.Forms.DateTimePicker
  Friend WithEvents Labnextdate As System.Windows.Forms.Label
  Friend WithEvents Cmbline As System.Windows.Forms.ComboBox
  Friend WithEvents Labline As System.Windows.Forms.Label
  Friend WithEvents Txtlastusedate As System.Windows.Forms.TextBox
  Friend WithEvents Lablastusedate As System.Windows.Forms.Label
  Friend WithEvents Txtmanage As System.Windows.Forms.TextBox
  Friend WithEvents Labmanager As System.Windows.Forms.Label
  Friend WithEvents Cmbmachinestate As System.Windows.Forms.ComboBox
  Friend WithEvents Txtmaintenance As System.Windows.Forms.TextBox
  Friend WithEvents Txtmachinename As System.Windows.Forms.TextBox
  Friend WithEvents Txtmachinecode As System.Windows.Forms.TextBox
  Friend WithEvents Lablastdate As System.Windows.Forms.Label
  Friend WithEvents LabProtecter As System.Windows.Forms.Label
  Friend WithEvents Labchname As System.Windows.Forms.Label
  Friend WithEvents Labmachinecode As System.Windows.Forms.Label
  Friend WithEvents DGjt As System.Windows.Forms.DataGridView
  Friend WithEvents BT As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents cmbTYPE As System.Windows.Forms.ComboBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents txtPATH As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents txtSCAN As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents txtEXT As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents BtnOFL As System.Windows.Forms.Button
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents txtPNG As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents TJ18 As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents TJ17 As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents TJ16 As System.Windows.Forms.TextBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
