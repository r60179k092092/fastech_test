Public Class clsPowerOnReport
  Private intDataCount As Integer = 0
  Private DataRS As DataTable = Nothing
  Private aryData As New Dictionary(Of String, String)
  Private aryDataGrp As New Dictionary(Of String, Integer)
  Private strTestType As String = ""
  Public Property TestType As String
    Get
      Return strTestType
    End Get
    Set(value As String)
      strTestType = value
    End Set
  End Property

  Sub New(rs As DataTable)
    DataRS = rs
    Dim rw As DataRow = rs.Rows(0)
    Dim strTM7 As String = rw!TM07.ToString
    Dim bolClrTmp As Boolean = False
    While bolClrTmp = False
      If strTM7.Contains("^") Then
        Dim intM As Integer = strTM7.IndexOf("^")
        Dim intP As Integer = strTM7.IndexOf("|")
        If intM >= 0 And intP >= 0 Then
          Dim strG As String = strTM7.Substring(intM + 1, intP - intM - 1)
          If aryDataGrp.ContainsKey(strG) = False Then
            aryDataGrp.Add(strG, 1)
            intDataCount = aryDataGrp(strG)
          Else
            aryDataGrp(strG) += 1
            intDataCount = aryDataGrp(strG)
          End If
          strTM7 = strTM7.Substring(intP + 1)
        Else
          If intM > 0 Then
            If intP > 0 Then
              strTM7 = strTM7.Substring(intP + 1)
            Else
              strTM7 = strTM7.Substring(intM + 1)
            End If
          End If
        End If
      Else
        bolClrTmp = True
      End If
    End While
    If intDataCount = 1 Then
      strTestType = "S"  '單色
    ElseIf intDataCount = 3 Then
      strTestType = "D"  '雙色
    ElseIf intDataCount = 4 Then
      strTestType = "G"  '2.4G
    End If
  End Sub
  Public Sub SetReport2DG(DG As DataGridView)
    Dim rsReport As New DataTable
    rsReport.Columns.Add(BIG2GB("序號"))
    rsReport.Columns.Add(BIG2GB("燈具二維碼")) 'PPID
    If intDataCount >= 3 Then
      rsReport.Columns.Add(BIG2GB("色溫"))
    End If
    rsReport.Columns.Add(BIG2GB("輸入電壓(V)"))
    rsReport.Columns.Add(BIG2GB("輸入電流(A)"))
    rsReport.Columns.Add(BIG2GB("功率(W)"))
    rsReport.Columns.Add(BIG2GB("PF"))
    rsReport.Columns.Add(BIG2GB("測試時間"))
    rsReport.Columns.Add(BIG2GB("判定"))

    SeprtData()
    If aryData.Count > 0 Then
      Dim intX As Integer = 0
      Dim intC As Integer = 0
      Dim strD As String = ""
      For Each s As String In aryData.Keys
        Dim strK() As String = Split(s, "|")
        Dim strV() As String = Split(aryData(s), ",")
        If strD <> strK(0) Then
          intC = 0
          strD = strK(0)
        End If
        If intDataCount > 1 Then
          If intC = 0 Then
            rsReport.Rows.Add(intX, strK(0), strK(1), strV(0), strV(1), strV(2), strV(3), strV(4), strV(5))
          Else
            rsReport.Rows.Add(intX, "", strK(1), strV(0), strV(1), strV(2), strV(3), strV(4), strV(5))
          End If
          intC += 1
        Else
          rsReport.Rows.Add(intX, strK(0), strK(1), strV(0), strV(1), strV(2), strV(3), strV(4))
        End If
        intX += 1
      Next
    End If
    DG.DataSource = rsReport
    'SetDGGridCell(DG)
    'SetDGGridCellBorderLine(DG)
  End Sub
  Private Sub SeprtData()
    For Each r As DataRow In DataRS.Rows
      Dim strS() As String = Split(r!TM07.ToString, "^")
      Dim strPPID As String = r!TM01.ToString
      Dim strTm As String = r!TM06.ToString
      Dim strReslt As String = r!TM08.ToString
      Dim strLight As String = ""
      For Each s1 As String In strS
        If s1.Contains("JUDGE") Or s1.Trim = "" Then Continue For
        Dim strS1() As String = Split(s1, "|")
        Dim strS2() As String = Split(strS1(1), "=")
        If aryData.ContainsKey(strPPID & "|" & strS2(0)) = False Then
          aryData.Add(strPPID & "|" & strS2(0), strS2(1))
        Else
          aryData(strPPID & "|" & strS2(0)) &= "," & strS2(1)
        End If
        Dim strD() As String = Split(aryData(strPPID & "|" & strS2(0)).Trim, ",")
        Dim intD As Integer = strD.Count
        If intD = aryDataGrp.Count Then
          If strReslt = "2" Or strReslt = "1" Then
            strReslt = "NG"
          ElseIf strReslt = "0" Then
            strReslt = "OK"
          End If
          aryData(strPPID & "|" & strS2(0)) &= "," & strTm & "," & strReslt
        End If
      Next
    Next
  End Sub
  Private Sub SetDGGridCell(DG As DataGridView, Optional intD As Integer = -1)
    For Each c As DataGridViewColumn In DG.Columns
      If intD >= 0 Then
        If c.Index = intD Then
          c.CellTemplate = New clsGridCell
        End If
      End If
    Next
  End Sub
  Private Sub SetDGGridCellBorderLine(DG As DataGridView)
    Dim clsGrid As clsGridCell
    Dim intR As Integer = 0
    For i As Integer = 0 To DG.Rows.Count - 1
      For j As Integer = 0 To DG.Columns.Count - 1
        clsGrid = DG.Rows(i).Cells(j)
      Next
    Next
    For Each r As DataGridViewRow In DG.Rows
      clsGrid = r.Cells(1)
      If intR = DG.Rows.Count - 1 Then
        clsGrid.SetBorder(False, True, True, True)
      Else
        If intDataCount Mod 3 = 1 Then
          clsGrid.SetBorder(True, False, True, True)
        Else
          clsGrid.SetBorder(False, False, True, True)
        End If
      End If
      intR += 1
    Next
  End Sub
End Class
