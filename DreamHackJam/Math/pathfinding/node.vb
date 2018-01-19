Public Class node

    Public location As Vector2
    Public parent As node
    Public xy As Vector2
    Public taken As Boolean = False

    Public nodeCost As Integer = 0

    Public Sub New(loc As Vector2, xy As Vector2)
        location = loc
    End Sub

End Class
