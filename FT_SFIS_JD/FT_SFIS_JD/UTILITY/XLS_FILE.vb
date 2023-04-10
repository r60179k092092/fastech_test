Public Enum BorderType
    'Left = 1
    'Right = 2
    'Top = 4
    'Bottom = 8
    'ALL = 15
    'VertLines = 16
    'HorzLines = 32
    'ALLLines = ALL + 48
    Left = 1
    Right = 2
    Top = 4
    Bottom = 8
    ALL = 15
    ULeft2DRight = 16
    DLeft2URight = 32
    VertLines = 64
    HorzLines = 128
    ALLLines = ALL + 192
    'UL2DR = 5 '左上右下
    'DL2UR = 6 '左下右上

End Enum
Public Enum ExcelPara
    xlDiagonalDown = 5
    xlDiagonalUp = 6
    'xlEdgeBottom = 9
    'xlEdgeLeft = 7
    'xlEdgeRight = 10
    'xlEdgeTop = 8
    xlEdgeBottom = 4
    xlEdgeLeft = 1
    xlEdgeRight = 2
    xlEdgeTop = 3
    xlInsideHorizontal = 12
    xlInsideVertical = 11
    xlHairline = 1
    xlMedium = -4138
    xlThick = 4
    xlThin = 2
    xlContinuous = 1
    xlDash = -4115
    xlDashDot = 4
    xlDashDotDot = 5
    xlDot = -4118
    xlDouble = -4119
    xlLineStyleNone = -4142
    xlSlantDashDot = 13
    xlAutomatic = -4105
End Enum
Public Class XLS_FILE
    Private Const strALPH As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
    Private APP As Object = Nothing
    Private WB As Object = Nothing
    Private SHT As Object = Nothing
    Private intCSht As Integer = 0
    Private bolUpdate As Boolean = False
    Sub New()
        APP = CreateObject("Excel.Application") '创建Excel对象         
        WB = APP.workbooks.add()
        intCSht = 0
    End Sub
    Sub New(strF As String)
        If IO.File.Exists(strF) = False Then
            APP = CreateObject("Excel.Application") '创建Excel对象         
            WB = APP.workbooks.add()
            intCSht = 0
        Else
            APP = CreateObject("Excel.Application") '创建Excel对象         
            WB = APP.workbooks.open(strF)
            intCSht = 0
        End If
    End Sub
    Private Function strFN(intV As Integer) As String
        Dim strV As String = ""
        If intV >= strALPH.Length Then
            strV &= strALPH.Substring((intV \ strALPH.Length) - 1, 1) & strALPH.Substring(intV Mod strALPH.Length, 1)
        Else
            strV = strALPH.Substring(intV, 1)
        End If
        Return strV
    End Function
    Private Sub ASheet(strSHTN As String)
        Dim intI As Integer = WB.sheets.Count
        strSHTN = strSHTN.Replace("/", "-").Replace("[", "(").Replace("]", ")").Replace("*", ".")
        For intJ = 1 To intI
            If WB.sheets(intJ).Name = strSHTN Then
                SHT = WB.sheets(intJ)
                Return
            End If
        Next
        If intCSht >= intI Then
            SHT = WB.Sheets.Add(After:=WB.Sheets(intI))
            intCSht += 1
        Else
            intCSht += 1
            SHT = WB.Sheets(intCSht)
        End If
        SHT.Name = strSHTN
    End Sub
    Public Sub SetNewSheet(strH As String)
        ASheet(strH)
    End Sub
    Public Sub AddCell(x As Integer, y As Integer, v As Object, Optional fmt As String = "")
        SHT.cells(x, y) = v
        If fmt <> "" Then
            SHT.range(strFN(x) & y.ToString("0")).NumberFormatLocal = fmt
        End If
    End Sub
    Public Function GetCell(x, y) As Object
        Return SHT.cells(x, y)
    End Function
    Public Sub AddBorder(x As Integer, y As Integer, x1 As Integer, y1 As Integer, bord As BorderType, thick As ExcelPara)
        Dim strRng As String = strFN(x) & y.ToString("0") & ":" & strFN(x1) & y1.ToString(0)
        With SHT.Range(strRng)
            With .Borders(ExcelPara.xlDiagonalDown) '左下右上
                If bord And BorderType.DLeft2URight Then
                    .LineStyle = ExcelPara.xlContinuous
                    .ColorIndex = ExcelPara.xlAutomatic
                    '.TintAndShade = 0
                    .Weight = thick
                Else
                    .LineStyle = ExcelPara.xlLineStyleNone
                End If
            End With
            With .Borders(ExcelPara.xlDiagonalUp) '左上右下
                If bord And BorderType.ULeft2DRight Then
                    .LineStyle = ExcelPara.xlContinuous
                    .ColorIndex = ExcelPara.xlAutomatic
                    '.TintAndShade = 0
                    .Weight = thick
                Else
                    .LineStyle = ExcelPara.xlLineStyleNone
                End If
            End With
            With .Borders(ExcelPara.xlEdgeTop)
                If bord And BorderType.Top Then
                    .LineStyle = ExcelPara.xlContinuous
                    .ColorIndex = ExcelPara.xlAutomatic
                    '.TintAndShade = 0
                    .Weight = thick
                Else
                    .LineStyle = ExcelPara.xlLineStyleNone
                End If
            End With
            With .Borders(ExcelPara.xlEdgeBottom)
                If bord And BorderType.Bottom Then
                    .LineStyle = ExcelPara.xlContinuous
                    .ColorIndex = ExcelPara.xlAutomatic
                    '.TintAndShade = 0
                    .Weight = thick
                Else
                    .LineStyle = ExcelPara.xlLineStyleNone
                End If
            End With
            With .Borders(ExcelPara.xlEdgeLeft)
                If bord And BorderType.Left Then
                    .LineStyle = ExcelPara.xlContinuous
                    .ColorIndex = ExcelPara.xlAutomatic
                    '.TintAndShade = 0
                    .Weight = thick
                Else
                    .LineStyle = ExcelPara.xlLineStyleNone
                End If
            End With
            With .Borders(ExcelPara.xlEdgeRight)
                If bord And BorderType.Right Then
                    .LineStyle = ExcelPara.xlContinuous
                    .ColorIndex = ExcelPara.xlAutomatic
                    '.TintAndShade = 0
                    .Weight = thick
                Else
                    .LineStyle = ExcelPara.xlLineStyleNone
                End If
            End With
            With .Borders(ExcelPara.xlInsideHorizontal)
                If bord And BorderType.HorzLines Then
                    .LineStyle = ExcelPara.xlContinuous
                    .ColorIndex = ExcelPara.xlAutomatic
                    '.TintAndShade = 0
                    .Weight = thick
                Else
                    .LineStyle = ExcelPara.xlLineStyleNone
                End If
            End With
            With .Borders(ExcelPara.xlInsideVertical)
                If bord And BorderType.VertLines Then
                    .LineStyle = ExcelPara.xlContinuous
                    .ColorIndex = ExcelPara.xlAutomatic
                    '.TintAndShade = 0
                    .Weight = thick
                Else
                    .LineStyle = ExcelPara.xlLineStyleNone
                End If
            End With
        End With
    End Sub
    Public Sub CombineCells(x As Integer, y As Integer, x1 As Integer, y1 As Integer, Optional bolM As Boolean = False)
        Dim strRng As String = strFN(x) & y.ToString("0") & ":" & strFN(x1) & y1.ToString(0)
        With SHT.Range(strRng)
            If bolM = False Then
                .HorizontalAlignment = -4108
                .VerticalAlignment = -4108
                '.WrapText = False
                '.Orientation = 0
                '.AddIndent = False
                '.IndentLevel = 0
                '.ShrinkToFit = False
                '.ReadingOrder = -5002
                .MergeCells = True
            Else
                .HorizontalAlignment = 1
                .VerticalAlignment = -4108
                '.WrapText = False
                '.Orientation = 0
                '.AddIndent = False
                '.IndentLevel = 0
                '.ShrinkToFit = False
                '.ReadingOrder = -5002
                .MergeCells = False
            End If
        End With
    End Sub
    Public Sub DG2XLS(DG As DataGridView, strH As String, strMO As String, Optional strL As String = "", Optional bolWithHeader As Boolean = True)
        Try
            bolUpdate = False
            If DG Is Nothing OrElse DG.DataSource Is Nothing Then Return
            If APP Is Nothing Or WB Is Nothing Then Return
            bolUpdate = True
            'If rs.Rows.Count <= 0 Then '判断记录数,如果没有记录就退出            
            '  MessageBox.Show("没有记录可以导出", "没有可以导出的项目", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If
            ASheet(strH)
            '如果有记录就导出到Excel         
            Dim u As Integer = 0, v As Integer = 0 '定义循环变量,行列变量    
            If strMO.Trim <> "" Then
                Dim strP() As String = strMO.Split(","), intP As Integer = 0
                For Each strP1 As String In strP
                    intP += 1
                    SHT.cells(1, intP) = strP1
                Next
            End If
            If bolWithHeader Then
                For v = 1 To DG.Columns.Count '把表头写入Excel   
                    If strMO.Trim <> "" Then
                        SHT.cells(2, v) = DG.Columns(v - 1).HeaderText.ToString
                    Else
                        SHT.cells(1, v) = DG.Columns(v - 1).HeaderText.ToString
                    End If
                Next
            End If
            Dim strV(DG.Rows.Count - 1, DG.Columns.Count - 1) '定义一个二维数组        
            For Each r As DataGridViewRow In DG.Rows '行循环
                v = 0
                For v = 0 To DG.ColumnCount - 1  '列循环  
                    If isCellNull(r.Cells(v)) = True Then
                        strV(u, v) = ""
                    Else
                        strV(u, v) = r.Cells(v).FormattedValue
                    End If
                Next
                u += 1
            Next
            Dim intI As Integer = 0
            If DG.Rows.Count > 0 And DG.Columns.Count > 0 Then
                If strMO.Trim <> "" Then
                    For Each c As Char In strL.ToCharArray
                        If c = "1"c Then
                            Dim str1 As String = strFN(intI)
                            SHT.range(str1 & ":" & str1).NumberFormatLocal = "@" '"G/通用格式" '把数组一起写入Excel      
                        End If
                        intI += 1
                    Next
                    If bolWithHeader = True Then
                        SHT.range("A3").Resize(DG.Rows.Count, DG.Columns.Count).Value = strV '把数组一起写入Excel      
                    Else
                        SHT.range("A2").Resize(DG.Rows.Count, DG.Columns.Count).Value = strV '把数组一起写入Excel      
                    End If
                Else
                    For Each c As Char In strL.ToCharArray
                        If c = "1"c Then
                            Dim str1 As String = strFN(intI)
                            SHT.range(str1 & ":" & str1).NumberFormatLocal = "@" '"G/通用格式" '把数组一起写入Excel      
                        End If
                        intI += 1
                    Next
                    If bolWithHeader = True Then
                        SHT.range("A2").Resize(DG.Rows.Count, DG.Columns.Count).Value = strV '把数组一起写入Excel      
                    Else
                        SHT.range("A1").Resize(DG.Rows.Count, DG.Columns.Count).Value = strV '把数组一起写入Excel      
                    End If
                End If
            End If
            SHT.Cells.EntireColumn.AutoFit() '自动调整Excel列      
        Catch ex As Exception '错误处理     
            MessageBox.Show(Err.Description.ToString, BIG2GB("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error) '出错提示         
        End Try
    End Sub
    Public Sub Rs2XLS(ByVal rs As DataTable, strH As String, strMO As String, Optional strL As String = "", Optional bolWithHeader As Boolean = True)  '导出到Excel函数    
        Try
            bolUpdate = False
            If rs Is Nothing Then Return
            If APP Is Nothing Or WB Is Nothing Then Return
            bolUpdate = True
            'If rs.Rows.Count <= 0 Then '判断记录数,如果没有记录就退出            
            '  MessageBox.Show("没有记录可以导出", "没有可以导出的项目", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If
            If strH IsNot Nothing And strH <> "" And strH.Length > 0 Then
                ASheet(strH)
            End If
            '如果有记录就导出到Excel         
            Dim u As Integer = 0, v As Integer = 0 '定义循环变量,行列变量    
            If strMO.Trim <> "" Then
                SHT.cells(1, 1) = "MO"
                SHT.cells(1, 2) = strMO
                SHT.cells(1, 3) = "WO"
                SHT.cells(1, 4) = strH
            End If
            If bolWithHeader = True Then
                For v = 1 To rs.Columns.Count '把表头写入Excel   
                    If strMO.Trim <> "" Then
                        SHT.cells(2, v) = rs.Columns(v - 1).ColumnName.ToString
                    Else
                        SHT.cells(1, v) = rs.Columns(v - 1).ColumnName.ToString
                    End If
                Next
            End If
            Dim strV(rs.Rows.Count - 1, rs.Columns.Count - 1) '定义一个二维数组        
            For Each r As DataRow In rs.Rows '行循环
                Dim strG As Object = r.ItemArray
                v = 0
                For Each k As Object In strG  '列循环  
                    Try
                        If k Is Nothing Then
                            strV(u, v) = ""
                        Else
                            strV(u, v) = k.ToString.Trim
                        End If
                        v += 1
                    Catch ex As Exception
                    End Try
                Next
                u += 1
            Next
            Dim intI As Integer = 0
            If rs.Rows.Count > 0 And rs.Columns.Count > 0 Then
                If strMO.Trim <> "" Then
                    For Each c As Char In strL.ToCharArray
                        If c = "1"c Then
                            Dim str1 As String = strFN(intI)
                            SHT.range(str1 & ":" & str1).NumberFormatLocal = "@" '"G/通用格式" '把数组一起写入Excel      
                        End If
                        intI += 1
                    Next
                    If bolWithHeader = True Then
                        SHT.range("A3").Resize(rs.Rows.Count, rs.Columns.Count).Value = strV '把数组一起写入Excel      
                    Else
                        SHT.range("A2").Resize(rs.Rows.Count, rs.Columns.Count).Value = strV '把数组一起写入Excel      
                    End If
                Else
                    For Each c As Char In strL.ToCharArray
                        If c = "1"c Then
                            Dim str1 As String = strFN(intI)
                            SHT.range(str1 & ":" & str1).NumberFormatLocal = "@" '"G/通用格式" '把数组一起写入Excel      
                        End If
                        intI += 1
                    Next
                    If bolWithHeader = True Then
                        SHT.range("A2").Resize(rs.Rows.Count, rs.Columns.Count).Value = strV '把数组一起写入Excel      
                    Else
                        SHT.range("A1").Resize(rs.Rows.Count, rs.Columns.Count).Value = strV '把数组一起写入Excel      
                    End If
                End If
            End If
            SHT.Cells.EntireColumn.AutoFit() '自动调整Excel列      
        Catch ex As Exception '错误处理     
            MessageBox.Show(Err.Description.ToString, BIG2GB("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error) '出错提示         
        End Try
    End Sub

    Public Function ShowSheet() As ArrayList
        Dim aryV As New ArrayList
        aryV.Clear()
        For i = 1 To WB.Sheets.Count
            aryV.Add(WB.Sheets(i).Name)
        Next
        Return aryV
    End Function

    ''' <summary>
    ''' 依表單序號取得datatable，序號由0開始
    ''' </summary>
    ''' <param name="intI">表單號，第一張表單為0，第二張表單為1，依此類推</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function XLS2Rs(intI As Integer, Optional intB As Integer = 0, Optional intE As Integer = 0, Optional bolHead As Boolean = False) As DataTable
        Dim aryST As ArrayList = ShowSheet()
        If intI < 0 OrElse intI > aryST.Count Then Return Nothing
        Try
            Return XLS2Rs(aryST(intI), intB, intE, bolHead)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function XLS2Rs(strH As String, Optional intB As Integer = 0, Optional intE As Integer = 0, Optional bolHead As Boolean = False) As DataTable
        SHT = Nothing
        'If Char.IsDigit(strH) = True Then
        'If WB.Sheets.Count <= Val(strH) Then SHT = WB.Sheets(Val(strH))
        'Else
        For intI As Integer = 1 To WB.Sheets.Count
            If WB.Sheets(intI).Name.Toupper = strH.ToUpper Then
                SHT = WB.Sheets(intI)
                Exit For
            End If
        Next
        'End If
        If SHT Is Nothing Then Return Nothing
        Dim a(,) As Object
        Dim rs As New DataTable
        a = SHT.UsedRange.Value
        Dim aryT As New ArrayList
        If intB = 0 Then intB = 1
        If intE = 0 Then intE = a.GetUpperBound(0)
        If bolHead Then
            For intI As Integer = 1 To a.GetUpperBound(1)
                aryT.Add(intI)
                rs.Columns.Add("F" & intI, GetType(String))
            Next
        Else
            For intI As Integer = 1 To a.GetUpperBound(1)
                If a(intB, intI) Is Nothing Then Continue For
                aryT.Add(intI)
                rs.Columns.Add(a(intB, intI).ToString.Trim, GetType(String))
            Next
        End If
        If bolHead Then
            intB -= 1
        End If
        For intI As Integer = intB + 1 To intE
            Dim r As DataRow = rs.NewRow
            Dim bolE As Boolean = False
            For intJ As Integer = 1 To aryT.Count
                If a(intI, aryT(intJ - 1)) Is Nothing Then
                    r.Item(intJ - 1) = ""
                Else
                    r.Item(intJ - 1) = a(intI, aryT(intJ - 1)).ToString.Trim
                    bolE = True
                End If
            Next
            If bolE = False Then Continue For
            rs.Rows.Add(r)
        Next
        Return rs
    End Function

    Public Function XLS2Rs(strH As String, Optional intB As Integer = 0, Optional intE As Integer = 0) As DataTable
        SHT = Nothing
        'If Char.IsDigit(strH) = True Then
        'If WB.Sheets.Count <= Val(strH) Then SHT = WB.Sheets(Val(strH))
        'Else
        For intI As Integer = 1 To WB.Sheets.Count
            If WB.Sheets(intI).Name.Toupper = strH.ToUpper Then
                SHT = WB.Sheets(intI)
                Exit For
            End If
        Next
        'End If
        If SHT Is Nothing Then Return Nothing
        Dim a(,) As Object
        Dim rs As New DataTable
        a = SHT.UsedRange.Value
        Dim aryT As New ArrayList
        If intB = 0 Then intB = 1
        If intE = 0 Then intE = a.GetUpperBound(0)
        For intI As Integer = 1 To a.GetUpperBound(1)
            If a(intB, intI) Is Nothing Then Continue For
            aryT.Add(intI)
            rs.Columns.Add(a(intB, intI).ToString.Trim, GetType(String))
        Next
        For intI As Integer = intB + 1 To intE
            Dim r As DataRow = rs.NewRow
            Dim bolE As Boolean = False
            For intJ As Integer = 1 To aryT.Count
                If a(intI, aryT(intJ - 1)) Is Nothing Then
                    r.Item(intJ - 1) = ""
                Else
                    r.Item(intJ - 1) = a(intI, aryT(intJ - 1)).ToString.Trim
                    bolE = True
                End If
            Next
            If bolE = False Then Continue For
            rs.Rows.Add(r)
        Next
        Return rs
    End Function
    Public Sub Quit()
        Try
            If WB IsNot Nothing Then
                WB.Close(False)
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(WB)
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(APP.workbooks)
                WB = Nothing
            End If
            If APP IsNot Nothing Then
                APP.Quit()
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(APP)
                APP = Nothing
            End If
        Catch ex As Exception

        End Try
        GC.Collect()
    End Sub
    Public Sub Close(strF As String)
        If strF.Trim = "" Then
            APP.visible = True '设置Excel可见
        Else
            APP.DisplayAlerts = False
            If bolUpdate = True Then
                Try
                    'If IO.Path.GetExtension(strF).ToUpper = "XLSX" Then
                    '  WB.SaveAS(strF, 51)
                    'Else
                    WB.Saveas(strF)
                    'End If
                    WB.Close(False)
                Catch ex As Exception
                    MsgBox(BIG2GB(ex.Message))
                End Try
            End If
            APP.Quit()
            GC.Collect()
        End If
        APP = Nothing
        WB = Nothing
    End Sub
    Public Sub Free2XLS(Optional bolAuto As Boolean = False)
        bolUpdate = True
        If bolAuto = True Then SHT.Cells.EntireColumn.AutoFit() 'PIE圖的話讓COLUMN項隨著文字大小而改變大小
    End Sub
End Class
