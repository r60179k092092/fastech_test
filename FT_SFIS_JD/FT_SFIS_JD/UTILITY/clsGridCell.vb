Public Class clsGridCell
  Inherits DataGridViewTextBoxCell
  Private bolT As Boolean = False
  Private bolB As Boolean = False
  Private bolL As Boolean = False
  Private bolR As Boolean = False
  Public Sub SetBorder(T As Boolean, B As Boolean, L As Boolean, R As Boolean)
    bolT = T
    bolB = B
    bolL = L
    bolR = R
  End Sub
  Public Overrides Function AdjustCellBorderStyle(I As DataGridViewAdvancedBorderStyle, U As DataGridViewAdvancedBorderStyle, V As Boolean, H As Boolean, C As Boolean, R As Boolean) As DataGridViewAdvancedBorderStyle
    'Return MyBase.AdjustCellBorderStyle(dataGridViewAdvancedBorderStyleInput, dataGridViewAdvancedBorderStylePlaceholder, singleVerticalBorderAdded, singleHorizontalBorderAdded, isFirstDisplayedColumn, isFirstDisplayedRow)
    If C Or bolL = False Then
      U.Left = DataGridViewAdvancedCellBorderStyle.None
    Else
      U.Left = DataGridViewAdvancedCellBorderStyle.Single
    End If
    If R Or bolT = False Then
      U.Top = DataGridViewAdvancedCellBorderStyle.None
    Else
      U.Top = DataGridViewAdvancedCellBorderStyle.Single
    End If
    If bolB Then
      U.Bottom = DataGridViewAdvancedCellBorderStyle.Single
    Else
      U.Bottom = DataGridViewAdvancedCellBorderStyle.None
    End If
    If bolR Then
      U.Right = DataGridViewAdvancedCellBorderStyle.Single
    Else
      U.Right = DataGridViewAdvancedCellBorderStyle.None
    End If
    Return U
  End Function
End Class
