Imports LABTRANx64.Labtran
Imports LABTRANx64
Imports APSQL
Public Class FormSet
  Private sqlcv As New SQLCNV
  Private fldVH As Flds
  Public Event DataChange(ByVal sender As FormSet, ByVal fld As Flds)

  Sub New(ByVal fld As Flds)

    ' 此為 Windows Form 設計工具所需的呼叫。
    InitializeComponent()

    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    languagechange(Me)
    If fld Is Nothing Then
      fldVH = New Flds
      fldVH.Name = "PAGE"
    Else
      fldVH = fld
    End If
    NewForm()
  End Sub
  Sub New()

    ' 此為 Windows Form 設計工具所需的呼叫。
    InitializeComponent()

    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    fldVH = New Flds
    fldVH.Name = "PAGE"
    NewForm()
  End Sub
  Private Sub NewForm()
    If fldVH.Hpos Is Nothing Then
      fldVH.Hpos = New HandPosi
      fldVH.Hpos.FDW = 100
      fldVH.Hpos.FDH = 100
      fldVH.Hpos.Resolution = 300
    End If
    If fldVH.Cell Is Nothing Then
      fldVH.Cell = New PageCell
      With CType(fldVH.Cell, PageCell)
        .Resolution = fldVH.Hpos.Resolution
        .PageArrayX = 1
        .PageArrayY = 1
        .PagePitch = fldVH.Hpos.FDH + 3
        .PagePitchX = fldVH.Hpos.FDW
        .PagePitchY = fldVH.Hpos.FDH
        '.PageWidth = fldVH.Hpos.FDW
      End With
    End If
    TB06.Text = fldVH.Name
    TB02.Text = fldVH.Hpos.Resolution
    With CType(fldVH.Cell, PageCell)
      TB07.Text = (fldVH.Hpos.FDW - ((.PageArrayX - 1) * .PagePitchX)).ToString("0.00")
      TB08.Text = (fldVH.Hpos.FDH - ((.PageArrayY - 1) * .PagePitchY)).ToString("0.00")
      TB09.Text = (.PagePitch - fldVH.Hpos.FDH).ToString("0.00")
      TB10.Text = .PageArrayX
      TB11.Text = .PageArrayY
      TB12.Text = (.PagePitchX).ToString("0.00")
      TB13.Text = (.PagePitchY).ToString("0.00")
      PGR.Text = .Round.ToString("0.00")
    End With
  End Sub
  Public ReadOnly Property GerFLDS() As Flds
    Get
      Return fldVH
    End Get
  End Property

  Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
    CType(fldVH.Cell, PageCell).Round = Val(PGR.Text)
    RaiseEvent DataChange(Me, fldVH)
    Me.Close()
  End Sub

  Private Sub TB_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB02.Leave, TB06.Leave, TB07.Leave, TB08.Leave, TB09.Leave, TB10.Leave, TB11.Leave, TB12.Leave, TB13.Leave
    Dim T As TextBox = sender
    If T.Name <> "TB06" AndAlso Val(T.Text) <= 0 Then T.Text = 1
    If T.Name = "TB07" Then
      If Int(Val(TB10.Text)) = 1 Then TB12.Text = Val(TB07.Text)
    ElseIf T.Name = "TB12" Then
      If Int(Val(TB10.Text)) = 1 Or Val(TB07.Text) > Val(TB12.Text) Then TB07.Text = Val(TB12.Text)
    ElseIf T.Name = "TB08" Then
      TB13.Text = Val(TB08.Text)
    ElseIf T.Name = "TB13" Then
      TB08.Text = Val(TB13.Text)
    End If
    fldVH.Name = TB06.Text.Trim
    fldVH.Hpos.Resolution = Val(TB02.Text)
    With CType(fldVH.Cell, PageCell)
      .PageArrayX = Int(Val(TB10.Text))
      .PageArrayY = Int(Val(TB11.Text))
      .PagePitchX = Val(TB12.Text)
      .PagePitchY = Val(TB13.Text)
      .Resolution = fldVH.Hpos.Resolution
      .Round = Val(PGR.Text)
      fldVH.Hpos.FDW = (.PageArrayX - 1) * .PagePitchX + Val(TB07.Text)
      fldVH.Hpos.FDH = (.PageArrayY - 1) * .PagePitchY + Val(TB08.Text)
      '.PageWidth = fldVH.Hpos.FDW
      .PagePitch = Val(TB09.Text) + fldVH.Hpos.FDH
      If .PageArrayX > 1 Then
        TB.Text = "(" & .PagePitchX.ToString("0.0") & "*" & .PageArrayX.ToString("0.0")
        If Val(TB07.Text) < Val(.PagePitchX.ToString("0.0")) Then
          TB.Text = "間" & Val(.PagePitchX.ToString("0.0")) - Val(TB07.Text) & ")*"
        Else
          TB.Text &= ")*"
        End If
      Else
        TB.Text = fldVH.Hpos.FDW.ToString("0.0") & "*"
      End If
      If .PageArrayY > 1 Then
        TB.Text &= "(" & .PagePitchY.ToString("0.0") & "*" & .PageArrayY & ")"
      Else
        TB.Text &= fldVH.Hpos.FDH.ToString("0.0")
      End If
    End With
  End Sub

  Private Sub FormSet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

  End Sub
End Class