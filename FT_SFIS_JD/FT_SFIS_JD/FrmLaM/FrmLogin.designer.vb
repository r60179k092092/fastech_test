<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLogin
    Inherits System.Windows.Forms.Form

    'Form 閲嶅啓 Dispose錛屼互娓呯悊緇勪歡鍒楄〃銆?
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows 紿椾綋璁捐鍣ㄦ墍蹇呴渶鐨?
    Private components As System.ComponentModel.IContainer

    '娉ㄦ剰: 浠ヤ笅榪囩▼鏄?Windows 紿椾綋璁捐鍣ㄦ墍蹇呴渶鐨?
    '鍙互浣跨敤 Windows 紿椾綋璁捐鍣ㄤ慨鏀瑰畠銆?
    '涓嶈浣跨敤浠ｇ爜緙栬緫鍣ㄤ慨鏀瑰畠銆?
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLogin))
    Me.BtnUpate = New System.Windows.Forms.Button()
    Me.Btnconfirm = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.btncancel = New System.Windows.Forms.Button()
    Me.txtusercode = New System.Windows.Forms.TextBox()
    Me.txtpwd = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.ComboBox1 = New System.Windows.Forms.ComboBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'BtnUpate
    '
    Me.BtnUpate.BackColor = System.Drawing.Color.Transparent
    Me.BtnUpate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnUpate.ForeColor = System.Drawing.Color.Navy
    Me.BtnUpate.Image = My.Resources.Resources.cog_edit_1_1
    Me.BtnUpate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.BtnUpate.Location = New System.Drawing.Point(36, 182)
    Me.BtnUpate.Name = "BtnUpate"
    Me.BtnUpate.Size = New System.Drawing.Size(90, 38)
    Me.BtnUpate.TabIndex = 3
    Me.BtnUpate.Text = "更 新"
    Me.BtnUpate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.BtnUpate.UseVisualStyleBackColor = False
    '
    'Btnconfirm
    '
    Me.Btnconfirm.BackColor = System.Drawing.Color.Transparent
    Me.Btnconfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
    Me.Btnconfirm.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Btnconfirm.ForeColor = System.Drawing.Color.Navy
    Me.Btnconfirm.Image = CType(resources.GetObject("Btnconfirm.Image"), System.Drawing.Image)
    Me.Btnconfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.Btnconfirm.Location = New System.Drawing.Point(146, 182)
    Me.Btnconfirm.Name = "Btnconfirm"
    Me.Btnconfirm.Size = New System.Drawing.Size(90, 38)
    Me.Btnconfirm.TabIndex = 2
    Me.Btnconfirm.Text = "登 錄"
    Me.Btnconfirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.Btnconfirm.UseVisualStyleBackColor = False
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.BackColor = System.Drawing.Color.Transparent
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(4, 240)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(42, 20)
    Me.Label1.TabIndex = 18
    Me.Label1.Text = "Ver:"
    '
    'btncancel
    '
    Me.btncancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.btncancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
    Me.btncancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btncancel.ForeColor = System.Drawing.Color.Navy
    Me.btncancel.Image = CType(resources.GetObject("btncancel.Image"), System.Drawing.Image)
    Me.btncancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.btncancel.Location = New System.Drawing.Point(256, 182)
    Me.btncancel.Name = "btncancel"
    Me.btncancel.Size = New System.Drawing.Size(90, 38)
    Me.btncancel.TabIndex = 5
    Me.btncancel.Text = "取 消"
    Me.btncancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.btncancel.UseVisualStyleBackColor = False
    '
    'txtusercode
    '
    Me.txtusercode.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
    Me.txtusercode.ForeColor = System.Drawing.SystemColors.ControlText
    Me.txtusercode.ImeMode = System.Windows.Forms.ImeMode.Disable
    Me.txtusercode.Location = New System.Drawing.Point(109, 112)
    Me.txtusercode.Name = "txtusercode"
    Me.txtusercode.Size = New System.Drawing.Size(197, 26)
    Me.txtusercode.TabIndex = 0
    '
    'txtpwd
    '
    Me.txtpwd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
    Me.txtpwd.ForeColor = System.Drawing.Color.Red
    Me.txtpwd.ImeMode = System.Windows.Forms.ImeMode.Disable
    Me.txtpwd.Location = New System.Drawing.Point(109, 144)
    Me.txtpwd.Name = "txtpwd"
    Me.txtpwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.txtpwd.Size = New System.Drawing.Size(197, 26)
    Me.txtpwd.TabIndex = 1
    Me.txtpwd.UseSystemPasswordChar = True
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.BackColor = System.Drawing.Color.Transparent
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(112, 240)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(38, 20)
    Me.Label2.TabIndex = 18
    Me.Label2.Text = "Ver:"
    '
    'Label5
    '
    Me.Label5.BackColor = System.Drawing.Color.Transparent
    Me.Label5.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
    Me.Label5.Location = New System.Drawing.Point(25, 83)
    Me.Label5.Name = "Label5"
    Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.Label5.Size = New System.Drawing.Size(84, 23)
    Me.Label5.TabIndex = 23
    Me.Label5.Text = "語言"
    Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'ComboBox1
    '
    Me.ComboBox1.BackColor = System.Drawing.SystemColors.Control
    Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ComboBox1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
    Me.ComboBox1.FormattingEnabled = True
    Me.ComboBox1.Items.AddRange(New Object() {"中文繁體", "中文簡體", "English"})
    Me.ComboBox1.Location = New System.Drawing.Point(109, 82)
    Me.ComboBox1.Name = "ComboBox1"
    Me.ComboBox1.Size = New System.Drawing.Size(197, 24)
    Me.ComboBox1.TabIndex = 22
    '
    'Label3
    '
    Me.Label3.BackColor = System.Drawing.Color.Transparent
    Me.Label3.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
    Me.Label3.Location = New System.Drawing.Point(25, 114)
    Me.Label3.Name = "Label3"
    Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.Label3.Size = New System.Drawing.Size(84, 23)
    Me.Label3.TabIndex = 23
    Me.Label3.Text = "帳號"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label4
    '
    Me.Label4.BackColor = System.Drawing.Color.Transparent
    Me.Label4.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
    Me.Label4.Location = New System.Drawing.Point(25, 146)
    Me.Label4.Name = "Label4"
    Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.Label4.Size = New System.Drawing.Size(84, 23)
    Me.Label4.TabIndex = 23
    Me.Label4.Text = "密碼"
    Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'FrmLogin
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
    Me.ClientSize = New System.Drawing.Size(376, 268)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.ComboBox1)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.BtnUpate)
    Me.Controls.Add(Me.btncancel)
    Me.Controls.Add(Me.Btnconfirm)
    Me.Controls.Add(Me.txtusercode)
    Me.Controls.Add(Me.txtpwd)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmLogin"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "登錄Login"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
    Friend WithEvents BtnUpate As System.Windows.Forms.Button
  Friend WithEvents Btnconfirm As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btncancel As System.Windows.Forms.Button
    Friend WithEvents txtusercode As System.Windows.Forms.TextBox
    Friend WithEvents txtpwd As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
