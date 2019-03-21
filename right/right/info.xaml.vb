Public Class info
    Private Sub sds_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles sds.MouseDown
        sds.BorderThickness = New Thickness(3)
        Me.Cursor = Cursors.Hand
        Me.DragMove()


    End Sub
  
    Private Sub sds_DragLeave(ByVal sender As System.Object, ByVal e As System.Windows.DragEventArgs) Handles sds.DragLeave

    End Sub

    Private Sub sds_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles sds.MouseUp


    End Sub

    Private Sub sds_MouseLeave(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseEventArgs) Handles sds.MouseLeave
        If (Me.Top < 0) Then
            Me.Top = 5
        End If
        If (Me.Left < 0) Then
            Me.Left = 5
        End If


        sds.BorderThickness = New Thickness(0)
        Me.Cursor = Cursors.Arrow
    End Sub
    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded

    End Sub
End Class
