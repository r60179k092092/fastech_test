Imports System.Windows.Xps.Packaging
Imports System.IO
Imports System.IO.Packaging
Imports System.Windows.Documents
Imports System.Windows.Media.Imaging
Imports System.Drawing.Imaging

Public Class Frm0333

    Dim bytV() As Byte
    Dim temPath As String

    Public Sub data()
        Dim sqlCV As APSQL.SQLCNV = New APSQL.SQLCNV()
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QTN")
        sqlCV.Where("QTN01", "LIKE", "@SOP%")
        sqlCV.SqlFields("QTN01")
        Dim dt As DataTable = DB.RsSQL(sqlCV.Text().Trim(), "RT")
        comboBox1.DataSource = dt
        comboBox1.ValueMember = "QTN01"
        comboBox1.DisplayMember = "QTN01"
        comboBox1.SelectedIndex = -1
        comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems
        comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Private Sub Frm0333_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        data()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If System.IO.File.Exists(temPath) = True Then
            File.Delete(temPath)
        End If
        If textBox1.Text <> "" And comboBox1.Text <> "" Then
            Dim sqlCV As APSQL.SQLCNV = New APSQL.SQLCNV()
            sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, "SFIS_QTN")
            sqlCV.SqlFields("QTN01", "@MAC")
            sqlCV.SqlFields("QTN02", textBox1.Text)
            sqlCV.SqlFields("QTN03", comboBox1.Text)
            sqlCV.SqlFields("QTN05", bytV)
            DB.RsSQL(sqlCV.Text, sqlCV.GetImgs)
            Me.DialogResult = DialogResult.OK
        End If
    End Sub

    Private Sub comboBox1_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles comboBox1.SelectionChangeCommitted
        Dim sqlCV As New APSQL.SQLCNV
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
        sqlCV.Where("QTN01", "=", comboBox1.SelectedValue.ToString.Trim)
        sqlCV.SqlFields("QTN03")
        sqlCV.SqlFields("QTN05")
        Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        For Each r As DataRow In rs.Rows
            If r!QTN05.GetType Is GetType(DBNull) Then Continue For
            Dim bytV() As Byte = r!QTN05
            temPath = Path.GetTempFileName() & ".xps"
            Dim fm As New IO.FileStream(temPath, IO.FileMode.Create)
            fm.Write(bytV, 0, bytV.Length)
            fm.Close()
            fm.Dispose()
            Process.Start(temPath)
        Next
    End Sub

    Private Sub comboBox1_DropDown(sender As Object, e As EventArgs) Handles comboBox1.DropDown
        If System.IO.File.Exists(temPath) = True Then
            File.Delete(temPath)
        End If
    End Sub
End Class