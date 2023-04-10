Public Class FrmSelect
  Private strTB As String = "TF"
  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()

    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    languagechange(Me)

  End Sub
  Public Property TableName As String
    Get
      Return strTB
    End Get
    Set(value As String)
      strTB = value
    End Set
  End Property
  Public Property Title As String
    Get
      Return Me.Text
    End Get
    Set(value As String)
      Me.Text = BIG2GB(value)
    End Set
  End Property
  Public Property Codes As String
    Get
      Return TextBox1.Text
    End Get
    Set(value As String)
      TextBox1.Text = value
    End Set
  End Property
  Private Sub FrmSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_" & strTB)
    sqlCV.SqlFields(strTB & "01 +' '+ " & strTB & "02", "DATAS", , , True)
    sqlCV.SqlFields(strTB & "01")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, strTB)
    Dim strV() As String = MakeErrCode(Codes).Split(strERSPLIT)
    Dim aryL As New ArrayList
    aryL.AddRange(strV)
    For Each r As DataRow In rs.Rows
      Dim intI As Integer = CLIST.Items.Add(r.Item(0).ToString.Trim)
      If aryL.Contains(r.Item(1).ToString.Trim) Then
        CLIST.SetItemChecked(intI, True)
      End If
    Next
  End Sub
  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    For Each intI As Integer In CLIST.CheckedIndices
      CLIST.SetItemChecked(intI, False)
    Next
    TextBox1.Text = ""
  End Sub

  Private Sub CLIST_MouseUp(sender As Object, e As MouseEventArgs) Handles CLIST.MouseUp
    Dim strM As String = ""
    For Each s As String In CLIST.CheckedItems
      strM &= s & ","
    Next
    TextBox1.Text = strM.Trim(",")
  End Sub

  Private Sub CLIST_Validated(sender As Object, e As EventArgs) Handles CLIST.Validated
    Dim strM As String = ""
    For Each s As String In CLIST.CheckedItems
      strM &= s & ","
    Next
    TextBox1.Text = strM.Trim(",")
  End Sub
End Class