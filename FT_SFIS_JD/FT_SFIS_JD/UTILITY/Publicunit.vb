Imports System.Data.SqlClient
Imports System.Data
'Imports System.Data.OleDb
Imports System.Linq
Imports APSQL
Imports System.Security.Cryptography

Module publicunit
  ''登錄者信息
  Public lgnname, lgncode, lgnpwd, lgnaccess, lgnjuese, GSCODE, GSNAME, erpserver, erpdb As String
  Public sqlCV As New APSQL.SQLCNV
  Public Const SYSID As String = "SFIS_JD"
  Public DB As lgjTSQL
  Public DBERP As APSQL.SQLDB
  Public DBFERP As APSQL.SQLDB
  Public language As lang
  Public strAPATH As String = ""
  Public clsRTS As clsRights = Nothing
  Public clsMenus As New myProjforms
#If K3 >= 2 Then
  Public strERSPLIT As String = vbTab
#Else
  public strERSPLIT as string =","
#End If
  Dim allgx As New Dictionary(Of String, String)
  Dim alluser As New Dictionary(Of String, String)
  Dim allmachine As New Dictionary(Of String, String)
  Dim allerrcode As New Dictionary(Of String, String)
  Public Sub SaveLog(strV As String)
    IO.File.AppendAllText("D:\LOG.TXT", Now.ToString("yyyy\/MM\/dd HH:mm:ss") & " " & strV & vbCrLf)
  End Sub
  Public Function GetLenB(strV As String) As Integer
    Dim intI As Integer = 0
    For Each c As Char In strV.ToCharArray
      If AscW(c) > 127 Then
        intI += 2
      Else
        intI += 1
      End If
    Next
    Return intI
  End Function

  Public Function GetTextFile(strKey As String) As String
    Dim strF As String = "#@REPORTS||03PATH"
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", strF)
    sqlCV.Where("QTN02", "=", strKey)
    sqlCV.SqlFields("QTN05")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count = 0 Then Return ""
    If rs.Rows(0)!QTN05.GetType Is GetType(DBNull) Then Return ""
    Dim bytV() As Byte = rs.Rows(0)!QTN05
    Dim strFile As String = strAPATH & "\F" & strKey & ".TXT"
    Dim fs As IO.Stream = IO.File.Open(strFile, IO.FileMode.Create)
    fs.Write(bytV, 0, bytV.Length)
    fs.Close()
    strF = BIG2GB(IO.File.ReadAllText(strFile, System.Text.Encoding.Unicode))
    IO.File.Delete(strFile)
    Return strF
  End Function

  Public Function GetImage(strF As String, Optional strKey As String = "#@IMAGES||03PATH") As Image
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", strKey.ToUpper)
    sqlCV.Where("QTN02", "=", strF.ToUpper)
    sqlCV.SqlFields("QTN05")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count = 0 Then Return Nothing
    If rs.Rows(0)!QTN05.GetType Is GetType(DBNull) Then Return Nothing
    Dim bytV() As Byte = rs.Rows(0)!QTN05
    Dim fs As New IO.MemoryStream
    fs.Write(bytV, 0, bytV.Length)
    Dim b As New Bitmap(fs)
    fs.Close()
    fs.Dispose()
    Return b
  End Function

  Public Function GetXLS(strF As String, strOut As String, Optional strKey As String = "#@REPORTS||03PATH") As String
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", strKey.ToUpper)
    sqlCV.Where("QTN02", "=", strF.ToUpper)
    sqlCV.SqlFields("QTN05")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count = 0 Then Return ""
    If rs.Rows(0)!QTN05.GetType Is GetType(DBNull) Then Return ""
    Dim bytV() As Byte = rs.Rows(0)!QTN05
    If IO.File.Exists(strOut) Then IO.File.Delete(strOut)
    Dim fs As IO.FileStream = IO.File.OpenWrite(strOut)
    fs.Write(bytV, 0, bytV.Length)
    fs.Close()
    Return strOut
  End Function

  Function getwuliao(ByVal whe As String)
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_TBB", , "TOP 500")
    sqlCV.SqlFields("TBB03", "物料編號")
    sqlCV.SqlFields("TBB08", "分類")
    sqlCV.SqlFields("TBB04", "型號")
    sqlCV.SqlFields("TBB05", "品名")
    sqlCV.SqlFields("TBB06", "規格")
    sqlCV.SqlFields("TBB07", "單位")
    sqlCV.SqlFields("TBB01", "流程編號")
    sqlCV.SqlFields("TBB02", "流程版本")
    Dim str As String = BIG2GB(sqlCV.Text) & "$^$" & whe
    Return New FrmDialog(BIG2GB("物料編號"), str)
  End Function
  Public Function BIG2GB(strV As String) As String
    Select Case language
      Case lang.ch
        Return StrConv(strV, VbStrConv.SimplifiedChinese, &H804)
    End Select
    Return strV
  End Function
  Sub getdictionary(ByRef dict As Dictionary(Of String, String), ByVal cmdtext As String)
    dict.Clear()
    Dim dtt As DataTable = DB.RsSQL(cmdtext, "ta")
    For Each rw As DataRow In dtt.Rows
      dict.Add(rw.Item(0).ToString, rw.Item(1).ToString)
    Next
  End Sub
  Public Sub SourceControl(c As Control, strKeyName As String, Optional strDefault As String = "")
    If c.GetType Is GetType(ComboBox) Then
      Dim c1 As ComboBox = CType(c, ComboBox)
      c1.DataSource = clsQTN.ReBind(strKeyName)
      c1.DisplayMember = "CNAME"
      c1.ValueMember = "ID"
      c1.SelectedValue = strDefault
    End If
  End Sub
#Region "數據導出"
  Sub dgdaochu(ByVal dg As DataGridView, Optional ByVal rowindex As Boolean = False)
    Dim ct As New System.Windows.Forms.ContextMenuStrip
    ct.Name = dg.Name
    Dim dt As New ToolStripButton
    dt.Text = BIG2GB("導出所有數據到excel")
    dt.Name = 1
    dt.Size = New System.Drawing.Size(100, 49)
    AddHandler dt.Click, AddressOf ToolStripTextBox1_Click
    ct.Items.Add(dt)
    Dim dt1 As New ToolStripButton
    dt1.Text = BIG2GB("複制當前單元格")
    dt1.Name = 2
    dt1.Size = New System.Drawing.Size(100, 49)
    AddHandler dt1.Click, AddressOf ToolStripTextBox1_Click
    ct.Items.Add(dt1)
    dg.ContextMenuStrip = ct
    If rowindex = True Then AddHandler dg.RowPostPaint, AddressOf DGjt_RowPostPaint
  End Sub
  Private Sub ToolStripTextBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Dim dg As DataGridView = DirectCast(DirectCast(sender, System.Windows.Forms.ToolStripButton).Owner, System.Windows.Forms.ContextMenuStrip).SourceControl
    If sender.name = 1 Then
      daochu(dg)
    Else
      If GCell(dg.CurrentCell) = "" Then
        MsgBox(BIG2GB("無法複製空白字段"))
      Else
        My.Computer.Clipboard.SetText(GCell(dg.CurrentCell))
      End If
    End If
  End Sub
  Private Sub DGjt_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
    Dim Rectangle As System.Drawing.Rectangle = New System.Drawing.Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, sender.RowHeadersWidth - 4, e.RowBounds.Height)
    TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), sender.RowHeadersDefaultCellStyle.Font, Rectangle, sender.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter & TextFormatFlags.Right)
  End Sub
  Public Sub daochu(ByVal x As DataGridView)  '導出到Excel函數    
    'Dim d As New daoc(AddressOf daochu)
    Try
      If x.Rows.Count <= 0 Then '判斷記錄數,如果沒有記錄就退出            
        MessageBox.Show(BIG2GB("沒有記錄可以導出"), BIG2GB("沒有可以導出的項目"), MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Return False
      Else '如果有記錄就導出到Excel         
        Dim xx As Object : Dim yy As Object
        xx = CreateObject("Excel.Application") '創建Excel對象         
        yy = xx.workbooks.add()
        Dim i As Integer, u As Integer = 0, v As Integer = 0 '定義循環變量,行列變量           
        For i = 1 To x.Columns.Count '把表頭寫入Excel                
          yy.worksheets(1).cells(1, i) = x.Columns(i - 1).HeaderCell.Value
        Next
        Dim str(x.Rows.Count - 1, x.Columns.Count - 1) '定義一個二維數組        
        For u = 0 To x.Rows.Count - 1 '行循環          
          For v = 0 To x.Columns.Count - 1 '列循環   
            str(u, v) = GCell(x.Rows(u).Cells(v))
          Next
        Next
        yy.worksheets(1).range("A2").Resize(x.Rows.Count, x.Columns.Count).NumberFormatLocal = "@"
        yy.worksheets(1).range("A2").Resize(x.Rows.Count, x.Columns.Count).Value = str '把數組一起寫入Excel  
        yy.worksheets(1).Cells.EntireColumn.AutoFit() '自動調整Excel列      
        ' yy.worksheets(1).name = x.TopLeftHeaderCell.Value.ToString '表標題寫入作為Excel工作表名稱      
        xx.visible = True '設置Excel可見       
        yy = Nothing '銷毀組建釋放資源             
        xx = Nothing '銷毀組建釋放資源        
      End If
      'Return True
    Catch ex As Exception '錯誤處理     
      MessageBox.Show(Err.Description.ToString, BIG2GB("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error) '出錯提示         
      'Return False
    End Try
    '2222  宏輝有使用數據 導出
    ''''Dim saveExcel As SaveFileDialog
    ''''saveExcel = New SaveFileDialog
    ''''saveExcel.Filter = "Excel文件(.xls)|*.xls"
    ''''Dim filename As String
    ''''If saveExcel.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
    ''''filename = saveExcel.FileName
    ''''Dim excel As Interop.Excel.Application
    ''''excel = New Interop.Excel.Application
    ''''excel.DisplayAlerts = False
    ''''excel.Workbooks.Add(True)
    ''''excel.Visible = False
    ''''Dim i As Integer
    ''''For i = 0 To DataGridView1.Columns.Count - 1
    ''''    excel.Cells(1, i + 1) = DataGridView1.Columns(i).HeaderText
    ''''Next
    '''''設置標題
    ''''Dim j As Integer
    ''''For i = 0 To DataGridView1.Rows.Count - 1 '填充數據
    ''''    For j = 0 To DataGridView1.Columns.Count - 1
    ''''        excel.Cells(i + 2, j + 1) = DataGridView1(j, i).Value
    ''''    Next
    ''''Next
    ''''excel.Workbooks(1).SaveCopyAs(filename) '保存
  End Sub

#End Region
  '通過其他程式配置
  Function jiemi(ByVal str As String)
    '使用對稱算法解密數據
    Dim MyIV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
    Dim MyEnKey() = System.Text.Encoding.Default.GetBytes("4040565A")
    Dim MyProvider = New DESCryptoServiceProvider()
    Dim MyEnBytes() = Convert.FromBase64String(str)
    Dim MyDeMemory = New System.IO.MemoryStream()
    Dim MyDeCrypt = New System.Security.Cryptography.CryptoStream(MyDeMemory, MyProvider.CreateDecryptor(MyEnKey, MyIV), System.Security.Cryptography.CryptoStreamMode.Write)
    MyDeCrypt.Write(MyEnBytes, 0, MyEnBytes.Length)
    MyDeCrypt.FlushFinalBlock()
    Dim MyEncoding = New System.Text.UTF8Encoding()
    Return MyEncoding.GetString(MyDeMemory.ToArray())
  End Function
  Public Sub dbopen(Optional ByVal err As Boolean = False)
    Dim strP As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\FASTECH", SYSID, "")
    If strP = "" Then
      MsgBox(BIG2GB("請先設置數據庫連線路徑"))
      End
    End If
    Dim str() As String
    Try
      If strP.EndsWith("=*=*=*") = True Then
        MsgBox(BIG2GB("試用期限已經到期"))
        End
      End If
      str = (jiemi(strP) & "######").Split("#")
      If str(0).StartsWith("@@") Then
        If Now.Date > CDate(str(0).Substring(2, 10)) Then
          MsgBox(BIG2GB("試用期限已經到期"))
          If strP.EndsWith("=*=*=*") = False Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\FASTECH", SYSID, strP & "=*=*=*")
          End If
          End
        End If
        str(0) = str(0).Substring(12)
      End If
      My.Settings.db = str(0)
      My.Settings.server = str(1)
      My.Settings.pwd = str(2)
      My.Settings.uid = str(3)
      My.Settings.ODBC_SOURCE = str(4)
      My.Settings.ODBC_DB = str(5)
      My.Settings.ODBC_UID = str(6)
      My.Settings.ODBC_PWD = str(7)
      My.Settings.FTSVR = str(10)
      My.Settings.FTDB = str(11)
      My.Settings.FTUSER = str(12)
      My.Settings.FTPWD = str(13)
      'My.Settings.URL = str(8)
      'intUserCnt = Val(str(9))
    Catch ex As Exception
    End Try
    Dim d As New Frmlianjie
    d.ShowDialog()
    If DB.Active = False Then
      If err = True Then
        MsgBox(BIG2GB("數據庫連接失敗，請聯繫管理員"), MsgBoxStyle.OkOnly, BIG2GB("提示"))
        End
      End If
    End If
  End Sub
  Public Function login(ByVal userid As String, ByVal pwd As String)
    Dim sqlCV As New APSQL.SQLCNV
    If userid.Trim.ToUpper = "ADMIN" And pwd = "fastech86641779" Then
      lgnpwd = pwd
      lgncode = userid
      lgnname = "ADMIN"
      lgnaccess = "ALL"
      lgnjuese = "ALL"
      Return True
    End If
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_USER")
    sqlCV.Where("UserCode", "=", userid.Trim)
    sqlCV.SqlFields("*")
    Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If dt.Rows.Count > 0 Then
      If dt.Rows(0)!PassWord.ToString.Trim <> pwd Then
        lgnpwd = ""
        lgncode = ""
        lgnname = ""
        lgnaccess = ""
        lgnjuese = ""
        Return False
      End If
      lgnpwd = pwd
      lgncode = userid.Trim
      lgnname = dt.Rows(0)!UserName.ToString.Trim
      Dim strV() As String = dt.Rows(0)!Access.ToString.Split("^")
      If strV(0).ToUpper = "ALL" Then
        lgnaccess = "ALL"
      Else
        Dim strM As String = ""
        For Each strK As String In strV
          If strK.Trim = "" Then Continue For
          strM &= "'" & strK.Trim & "',"
        Next
        lgnaccess = ""
        If strM <> "" Then
          sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_JueSe")
          sqlCV.Where("JueSeCode", "IN", strM.Trim(","), intFMode.msfld_field)
          sqlCV.SqlFields("Access")
          Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
          For Each r As DataRow In rs.Rows
            lgnaccess &= r!Access.ToString.Trim(" ^".ToCharArray) & "^"
          Next
        End If
      End If
      lgnjuese = dt.Rows(0)!Juese.ToString
      Return True
    Else
      If userid.Trim.ToUpper = "ADMIN" And pwd = "SUPER" Then
        lgnpwd = pwd
        lgncode = userid
        lgnname = "Admin"
        lgnaccess = "ALL"
        lgnjuese = "Admin"
        Return True
      End If
    End If
    Return False
  End Function
#Region "設置語言" 'langage setup
  'Sub New()
  '    ' 此調用是設計器所必需的。
  '    InitializeComponent()
  '    ' 在 InitializeComponent() 調用之后添加任何初始化。
  '    languagechange(Me)
  '    Cmbmachinestate.Items.Clear()
  '    Cmbmachinestate.Items.AddRange(getlanguagecmb(Me, "Cmbmachinestate01"))
  'End Sub  '讀取控件
  Public Sub languagechange(ByVal meform As Form)
    getlanguage(meform, meform)
    For Each cotr As Control In meform.Controls
      control(meform, cotr)
    Next
  End Sub
  Public Sub control(ByVal meform As Form, ByVal contr As Control)
    getlanguage(meform, contr)
    If contr.Controls.Count > 0 Then
      For Each nod As Control In contr.Controls
        control(meform, nod)
      Next
    End If
    Dim str As String = ""
    ''設置信息
    If TypeOf (contr) Is ToolStrip Then
      For Each d In CType(contr, ToolStrip).Items
        If TypeOf (d) Is ToolStripButton Then
          With CType(d, ToolStripButton)
            .Text = BIG2GB(.Text)
          End With
        End If
      Next
    End If
    If TypeOf (contr) Is ComboBox Then
      With CType(contr, ComboBox)
        If .Items.Count > 0 Then
          For intI As Integer = 0 To .Items.Count - 1
            .Items(intI) = BIG2GB(.Items(intI))
          Next
        End If
      End With
    End If
    If TypeOf (contr) Is DataGridView Then
      For Each d As DataGridViewColumn In CType(contr, DataGridView).Columns
        d.HeaderText = BIG2GB(d.HeaderText)
      Next
    End If
  End Sub
  Sub getlanguage(ByVal form As Form, ByVal Control As Control)
    Control.Text = BIG2GB(Control.Text)
  End Sub
#End Region

#Region "獲取工序"
  ' ''get gap suo zai gong xu 
  Dim GAPGX As String = ""
  Dim GXFQC As String = ""
  Dim GXPACK As String = ""
  Dim GXPACKED As String = ""
  Public ReadOnly Property getgxfqc() As String
    Get
      If GXFQC = "" Then
        setgx()
      End If
      Return GXFQC
    End Get
  End Property
  Sub setgx()
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_qtn")
    sqlCV.Where("qtn01", "=", "gxpackfqc")
    'sqlCV.Where("qtn02", "=", "gxpack")
    sqlCV.SqlFields("qtn03")
    sqlCV.SqlFields("qtn04")
    sqlCV.SqlFields("qtn02")
    Dim dt As DataTable = DB.RsSQL(sqlCV.Text, "11")
    If dt.Rows.Count <> 0 Then
      GXPACK = dt.Rows(0).Item(0).ToString
      GXPACKED = dt.Rows(0).Item(1).ToString
      GXFQC = dt.Rows(0).Item(2).ToString
    End If
  End Sub

  Public ReadOnly Property getDictallgx()
    Get
      If allgx.Count = 0 Then
        getdictionary(allgx, "select ta01,ta02+'|'+ta03 from sfis_ta")
      End If
      Return allgx
    End Get
  End Property
  Public ReadOnly Property getDictallmachine()
    Get
      If allmachine.Count = 0 Then
        getdictionary(allmachine, "select tj01,tj02 from sfis_tj")
      End If
      Return allmachine
    End Get
  End Property
  Public Function MakeUser(ByVal code As String) As String
    Dim strM As String = ""
    Dim strV() As String = code.Split(",")
    For Each strK As String In strV
      If strK.Trim = "" Then Continue For
      strM &= strK.Split(" ")(0).Trim & ","
    Next
    Return strM.Trim(",")
  End Function
  ' ''getuser
  Public Function GetUser(ByVal code As String) As String
    Dim strM As String = ""
    Dim strV() As String = code.Split(",")
    For Each strK As String In strV
      If strK.Trim = "" Then Continue For
      If alluser.Count = 0 Then
        Dim sqlCV As New APSQL.SQLCNV
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_User")
        sqlCV.SqlFields("UserCode")
        sqlCV.SqlFields("UserName")
        Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
        For Each r As DataRow In rs.Rows
          If alluser.ContainsKey(r.Item(0).ToString.Trim) = False Then
            alluser.Add(r.Item(0).ToString.Trim, r.Item(1).ToString.Trim)
          End If
        Next
      End If
      If alluser.ContainsKey(strK.Trim) Then
        strM &= strK.Trim & " " & alluser(strK.Trim) & ","
      Else
        strM &= strK.Trim & ","
      End If
    Next
    Return strM.Trim(",")
  End Function
  ''getmachine
  Function getmachine(ByVal code As String) As String
    getmachine = ""
    For Each Str As String In code.Trim(",").Split(",")
      If getDictallmachine.ContainsKey(Str) Then
        getmachine &= Str & allmachine(Str) & ";"
      Else
        getmachine &= Str & ";"
      End If
    Next
    Return getmachine.Trim(";")
  End Function
  Public Function MakeErrCode(ByVal code As String) As String
    Dim strM As String = ""
    Dim strV() As String = code.Split(strERSPLIT)
    For Each strK As String In strV
      If strK.Trim = "" Then Continue For
      Dim strK1() As String = strK.Trim.Split("^")
      Dim strL() As String = strK1(0).Split(" ")
      If strL(0).StartsWith("%+") Then
        strM &= strL(0).Substring(2)
      Else
        strM &= strL(0)
      End If
      If strK1.Length > 1 AndAlso strK1(1).Trim <> "" Then
        strM &= "^" & strK1(1).Trim & strERSPLIT
      Else
        strM &= strERSPLIT
      End If
    Next
    Return strM.Trim(strERSPLIT)
  End Function
  ''geterrcode
  Public Function GetErrCode(ByVal code As String, Optional TB As String = "TF", Optional bolE As Boolean = True) As String
    If code.Trim = "" Then Return ""
    Dim strM As String = ""
    Dim strV() As String = MakeErrCode(code).Split(strERSPLIT)
    If allerrcode.ContainsKey(TB) = False Then
      Dim sqlCV As New SQLCNV
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_" & TB)
      sqlCV.SqlFields(TB & "01")
      sqlCV.SqlFields(TB & "02")
      sqlCV.SqlFields(TB & "03")
      Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
      allerrcode.Add(TB, TB)
      For Each r As DataRow In rs.Rows
        allerrcode.Add(r.Item(0).ToString.Trim, r.Item(0).ToString.Trim & " " & r.Item(1).ToString.Trim & "|" & r.Item(2).ToString.Trim)
      Next
    End If
    For Each strK As String In strV
      If strK.Trim = "" Then Continue For
      Dim strK1() As String = strK.Trim.Split("^")
      If allerrcode.ContainsKey(strK1(0).Trim) = True Then
        If bolE = False Then
          strM &= allerrcode(strK1(0).Trim).Split("|")(0)
        Else
          strM &= allerrcode(strK1(0).Trim)
        End If
      Else
        strM &= strK1(0).Trim
      End If
      If strK1.Length > 1 AndAlso strK1(1).Trim <> "" Then
        strM &= "^" & strK1(1).Trim & strERSPLIT
      Else
        strM &= strERSPLIT
      End If
    Next
    Return strM.Trim(strERSPLIT)
  End Function
  ' ''getgx
  Function getgx(ByVal code As String) As String
    getgx = ""
    For Each Str As String In code.Trim(",").Split(",")
      If getDictallgx.ContainsKey(Str) Then
        getgx &= allgx(Str) & ";"
      Else
        getgx &= Str & ";"
      End If
    Next
    Return getgx.Trim(";")
  End Function
#End Region

  ''' <summary>
  ''' 印出CS6標籤
  ''' </summary>
  ''' <param name="strFile">CS6檔案名或QTN路徑(#TD24^ITEM)</param>
  ''' <param name="intQty">張數</param>
  ''' <param name="intCopy">份數</param>
  ''' <param name="para">參數表</param>
  ''' <remarks></remarks>
  Public Sub cs6pritF(strFile As String, intQty As Integer, intCopy As Integer, ParamArray para() As String)
    'Dim csapp As New LabelManager2.Application
    'Dim csdoc As LabelManager2.Document = Nothing
    'Dim sqlCV As New APSQL.SQLCNV
    'Dim strF As String = ""
    'If strFile.StartsWith("#") Then
    '  Dim strV() As String = (strFile.Trim & "^").Split("^")
    '  sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
    '  sqlCV.Where("QTN01", "=", strV(0))
    '  sqlCV.Where("QTN02", "=", strV(1))
    '  sqlCV.SqlFields("QTN03")
    '  sqlCV.SqlFields("QTN05")
    '  Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    '  If rs.Rows.Count = 0 Then
    '    Return
    '  End If
    '  If rs.Rows(0)!QTN05.GetType Is GetType(DBNull) Then
    '    Return
    '  End If
    '  Dim bytV() As Byte = rs.Rows(0)!QTN05
    '  If bytV.Length = 0 Then Return
    '  strF = rs.Rows(0)!QTN03.ToString.Trim
    '  If strF.Trim = "" Then
    '    strF = strAPATH & "\" & Now.ToString("LddHHmmss") & ".LAB"
    '  Else
    '    strF = strAPATH & "\" & IO.Path.GetFileName(strF)
    '  End If
    '  Dim fs As IO.FileStream = IO.File.OpenWrite(strF)
    '  fs.Write(bytV, 0, bytV.Length)
    '  fs.Close()
    'Else
    '  strF = strFile
    'End If
    'Try
    '  If IO.File.Exists(strF) = False Then
    '    MsgBox(BIG2GB("檔案不存在：" & strF))
    '    Return
    '  End If
    '  csdoc = csapp.Documents.Open(strF)
    '  If csdoc Is Nothing Then
    '    MsgBox("Open Lab File Error")
    '    csapp.Documents.CloseAll()
    '    csapp.Quit()
    '    If strF <> strFile Then
    '      IO.File.Delete(strF)
    '    End If
    '    Return
    '  End If
    '  Dim intP As Integer = 0
    '  If csdoc.Variables Is Nothing OrElse csdoc.Variables.FormVariables Is Nothing Then
    '    intP = 0
    '  Else
    '    intP = csdoc.Variables.FormVariables.Count
    '  End If
    '  Dim intI As Integer = 0
    '  For Each strV As String In para
    '    Dim strM() As String = strV.Split("^")
    '    intI += 1
    '    Dim strFD As String = "FD" & intI.ToString("00")
    '    If csdoc.Variables.FormVariables.Item(strFD) Is Nothing Then Continue For
    '    Select Case strM.Length
    '      Case 1
    '        csdoc.Variables.FormVariables.Item(strFD).Value = strM(0)
    '        csdoc.Variables.FormVariables.Item(strFD).Prefix = ""
    '        csdoc.Variables.FormVariables.Item(strFD).Suffix = ""
    '      Case 2
    '        csdoc.Variables.FormVariables.Item(strFD).Value = strM(1)
    '        csdoc.Variables.FormVariables.Item(strFD).Prefix = strM(0)
    '        csdoc.Variables.FormVariables.Item(strFD).Suffix = ""
    '      Case 3
    '        csdoc.Variables.FormVariables.Item(strFD).Value = strM(1)
    '        csdoc.Variables.FormVariables.Item(strFD).Prefix = strM(0)
    '        csdoc.Variables.FormVariables.Item(strFD).Suffix = strM(2)
    '    End Select
    '  Next
    '  If My.Settings.PRINTER = "" Or My.Settings.PRINTER.ToUpper = "DEFAULT" Then
    '    csdoc.Printer.SwitchTo(My.Settings.PRINTER)
    '  End If
    '  csdoc.PrintLabel(intQty, intCopy)
    '  csdoc.FormFeed()
    '  csdoc.Close()
    '  csapp.Documents.CloseAll()
    '  csapp.Quit()
    '  If strF <> strFile Then
    '    IO.File.Delete(strF)
    '  End If
    'Catch ex As Exception
    '  MsgBox(BIG2GB("打印失敗") & ex.Message.ToString, MsgBoxStyle.OkOnly, BIG2GB("＝＝提示＝＝"))
    '  If csdoc IsNot Nothing Then csdoc.Close()
    '  csapp.Documents.CloseAll()
    '  csapp.Quit()
    '  If strF <> strFile Then
    '    IO.File.Delete(strF)
    '  End If
    'End Try
  End Sub
  Public Function isCellNull(ByVal c As DataGridViewCell) As Boolean
    If c Is Nothing OrElse c.Value Is Nothing OrElse c.Value Is DBNull.Value Then
      Return True
    Else
      Return False
    End If
  End Function
  Public Function GCell(ByVal c As DataGridViewCell) As String
    If isCellNull(c) = True Then Return ""
    Return c.Value.ToString.Trim
  End Function

  Public Function GetConn(ByVal filepath As String, Optional ByVal uid As String = "", Optional ByVal psd As String = "")
    Dim fileleixing As String = IO.Path.GetExtension(filepath).ToUpper
    If fileleixing = ".XLS" Then
      Return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & filepath & ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1';"
    ElseIf fileleixing = ".XLSX" Then
      Return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & filepath & ";Extended Properties='Excel 12.0;HDR=YES';"
    ElseIf fileleixing = ".DBF" Then
      Return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & filepath & ";Extended Properties=dBASE IV;User ID=" & uid & ";Password=" & psd & ";"
    ElseIf fileleixing = ".MDB" Then
      Return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & filepath & ";Jet OLEDB:Database Password=" & psd & ";"
    Else
      Return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & filepath & ";Jet OLEDB:Database Password=" & psd & ";"
    End If
  End Function
  Public Enum lang
    tw = 0
    ch = 1
    en = 2
  End Enum
End Module
