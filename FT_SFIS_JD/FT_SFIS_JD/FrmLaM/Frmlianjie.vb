Public Class Frmlianjie
    Private Sub Frmlianjie_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BackgroundWorker1.RunWorkerAsync()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value >= ProgressBar1.Maximum Then
            ProgressBar1.Value = 0
        End If
        ProgressBar1.Value += 2
    End Sub
    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        'DB = New SQLDB(My.Settings.server, My.Settings.db, My.Settings.uid, My.Settings.pwd)
    DB = New lgjTSQL("data source =" & My.Settings.server & ";initial catalog = " & My.Settings.db & ";password=" & My.Settings.pwd & ";user id=" & My.Settings.uid)
    If My.Settings.ODBC_SOURCE.Trim <> "" And My.Settings.ODBC_DB.Trim <> "" Then
      DBERP = New APSQL.SQLDB(My.Settings.ODBC_SOURCE, My.Settings.ODBC_DB, My.Settings.ODBC_UID, My.Settings.ODBC_PWD)
    End If
    If My.Settings.FTSVR.Trim <> "" And My.Settings.FTDB.Trim <> "" Then
      DBFERP = New APSQL.SQLDB(My.Settings.FTSVR, My.Settings.FTDB, My.Settings.FTUSER, My.Settings.FTPWD)
    End If
  End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Timer1.Enabled = False
        ProgressBar1.Value = ProgressBar1.Maximum
        If DB.Active = False Then
            Panel1.Show()
        Else
            Me.Close()
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

End Class