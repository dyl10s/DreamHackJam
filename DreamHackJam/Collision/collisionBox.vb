Public Class collisionBox

    Public Shared colboxes As New List(Of collisionBox)

    Public colRect As Rectangle
    Public type As String = ""
    Dim pos As Vector2
    Dim size As Vector2

    Public Sub New(position As Vector2, objectSize As Vector2, objectType As String)

        pos = position
        size = objectSize
        type = objectType

        colRect = New Rectangle(pos.X, pos.Y, size.X, size.Y)

        colboxes.Add(Me)

    End Sub

    Public Sub update(position As Vector2)

        pos = position
        colRect = New Rectangle(pos.X, pos.Y, size.X, size.Y)

    End Sub

    Public Sub draw(sb As SpriteBatch)

        sb.Draw(Game1.contentMnger.loadTexture("black"), colRect, Color.White)

    End Sub

    Public Sub destroy()

        colboxes.Remove(Me)

    End Sub

    Public Function isAlive() As Boolean

        If colboxes.Contains(Me) Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
