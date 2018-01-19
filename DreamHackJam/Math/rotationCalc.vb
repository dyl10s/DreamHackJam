Public Class rotationCalc

    Public Shared Function findRotationToPoint(lookPos As Vector2, curPos As Vector2) As Double

        Return Math.Atan2(lookPos.Y - curPos.Y, lookPos.X - curPos.X)

    End Function

    Public Shared Function findNextStep(target As Vector2, curPos As Vector2, speed As Integer) As Vector2

        Dim yMove As Single = Math.Sin(findRotationToPoint(target, curPos))
        Dim xMove As Single = Math.Cos(findRotationToPoint(target, curPos))

        Dim moveVector As New Vector2(xMove, yMove)
        moveVector *= speed


        Return moveVector

    End Function

    Public Shared Function distanceToPoint(p1 As Vector2, p2 As Vector2) As Integer

        Return Math.Abs(p1.X - p2.X) + Math.Abs(p1.Y - p2.Y)

    End Function

End Class
