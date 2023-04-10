Public Class FrmLogin
    Private intCnt As Integer = 0
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnconfirm.Click
        If DB Is Nothing OrElse DB.Active = False Then dbopen()
        If DB Is Nothing OrElse DB.Active = False Then
            Return
        End If
        'test.ShowDialog()
        If txtusercode.Text.Trim.Length = 0 Then
            If language = lang.en Then
                MsgBox("Please enter your user account, the account can not be empty", MsgBoxStyle.OkOnly, "Prompt！")
            ElseIf language = lang.ch Then
                MsgBox("請輸入用戶帳號，帳號不能為空！", MsgBoxStyle.OkOnly, "提示！")
            Else
                MsgBox("請輸入用戶帳號,帳號不能為空", MsgBoxStyle.OkOnly, "提示！")
            End If
            Return
        End If
        If txtpwd.Text.Trim.Length = 0 Then
            If language = lang.en Then
                MsgBox("Please enter the password, the password can not be empty", MsgBoxStyle.OkOnly, "Prompt！")
            ElseIf language = lang.ch Then
                MsgBox("請輸入密碼，密碼不能為空", MsgBoxStyle.OkOnly, "提示！")
            Else
                MsgBox("請輸入密碼，密碼不能為空", MsgBoxStyle.OkOnly, "提示！")
            End If
            Return
        End If
        If login(txtusercode.Text.Trim, txtpwd.Text.Trim) Then
            Me.Close()
            Return
        End If
        intCnt += 1
        If intCnt > 3 Then
            If language = lang.en Then
                MessageBox.Show("The user account and password input error more than three times, the system will exit!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            ElseIf language = lang.ch Then
                MessageBox.Show("用戶帳號及密碼輸入錯誤超過三次，系統將退出!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                MessageBox.Show("用戶帳號及密碼輸入錯誤超過三次，系統將退出!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
            lgncode = ""
            lgnname = ""
            lgnaccess = ""
            lgnpwd = ""
            lgnaccess = ""
            Me.Close()
            Return
        Else
            If language = lang.en Then
                MessageBox.Show("The user account and password input error, please input again!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            ElseIf language = lang.ch Then
                MessageBox.Show("用戶帳號及密碼輸入錯誤，請重新輸入!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                MessageBox.Show("用戶帳號及密碼輸入錯誤，請重新輸入!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
            txtusercode.SelectAll()
            txtusercode.Focus()
            Return
        End If
    End Sub
    Sub New()

        ' 此調用是設計器所必需的。
        InitializeComponent()
        ' 在 InitializeComponent() 調用之后添加任何初始化。
        language = My.Settings.language
        ComboBox1.SelectedIndex = My.Settings.language
        languagechange(Me)
    End Sub

    Private Sub Login_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Text &= My.Application.Info.Version.ToString
        Label2.Text = My.Settings.FTPIP.Split(";")(0)
        If Label2.Text = "" Then
            Label2.Text = BIG2GB("請雙擊這裡輸入同步地址")
        End If
        strAPATH = System.Windows.Forms.Application.StartupPath
        Me.Text = BIG2GB(Me.Text)
        If IO.Directory.Exists(strAPATH & "\bin\Debug") = True Then
            strAPATH &= "\bin\Debug"
        End If
    End Sub

    ''更新
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpate.Click
        If IO.File.Exists(strAPATH & "\config.PM") = True Then
            IO.File.Delete(strAPATH & "\config.PM")
        End If
        Btnconfirm.Enabled = False
        BtnUpate.Enabled = False
        Dim strV() As String = (My.Settings.FTPIP & ";;").Split(";")
        If Label2.Text.Trim.StartsWith("\\") Then
            IO.File.Copy(Label2.Text.Trim & "\config.PM", strAPATH & "\config.PM", True)
        Else
            My.Computer.Network.DownloadFile("ftp://" & Label2.Text.Trim & "/config.PM", strAPATH & "\config.PM", strV(1), strV(2))
        End If
        If My.Application.IsNetworkDeployed Then
            My.Application.Deployment.UpdateAsync()
        End If
        Dim strP As String = IO.File.ReadAllText(strAPATH & "\config.PM")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\FASTECH", SYSID, strP)
        Btnconfirm.Enabled = True
        BtnUpate.Enabled = True
        If DB IsNot Nothing AndAlso DB.Active = True Then DB.CloseDB()
        DB = Nothing
    End Sub

    Private Sub txtusercode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtusercode.KeyPress
        If e.KeyChar = Chr(13) And txtusercode.Text.Trim.Length <> 0 Then
            e.Handled = True
            txtpwd.Text = ""
            txtpwd.Focus()
        End If
    End Sub
    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpwd.KeyPress
        If e.KeyChar = Chr(13) AndAlso txtpwd.Text.Trim.Length <> 0 Then
            e.Handled = True
            Btnconfirm.PerformClick()
        End If
    End Sub
    '’切換賬戶中的取消
    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        lgncode = ""
        lgnname = ""
        lgnpwd = ""
        lgnjuese = ""
        lgnaccess = ""
        Me.Close()
    End Sub

    Private Sub Label1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label2.DoubleClick
        Dim strM As String = InputBox(BIG2GB("請輸入FTP位址:"), Me.Text, My.Settings.FTPIP)
        If strM <> "" Then
            My.Settings.FTPIP = strM
            Label2.Text = strM.Split(";")(0)
            If Label2.Text = "" Then
                Label2.Text = BIG2GB("請雙擊這裡輸入同步地址")
            End If
            My.Settings.Save()
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        language = ComboBox1.SelectedIndex
        My.Settings.language = language
        My.Settings.Save()
        languagechange(Me)
    End Sub
End Class

