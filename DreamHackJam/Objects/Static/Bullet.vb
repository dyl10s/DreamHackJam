Public Class Bullet

    Public pos As New Vector2(250, 250)
    Public size As New Vector2(5, 5)
    Public vel As Vector2

    Public colbox As collisionBox

    Public target As Vector2

    Public speed As Integer = 10

    Public startingPos As Vector2

    Public range As Integer = 5000
    Public seaking As Boolean = False

    Public realPos As Vector2 = pos - New Vector2(size.X / 2, size.Y / 2)

    Public Sub New(ByRef shootTarget As Vector2, startPos As Vector2, isSeaking As Boolean, shotRange As Integer)

        target = shootTarget
        pos = startPos
        startingPos = pos

        seaking = isSeaking
        range = shotRange

        vel = rotationCalc.findNextStep(target, pos, speed)

        realPos = pos - New Vector2(size.X / 2, size.Y / 2)
        colbox = New collisionBox(realPos, size, "bullet")

    End Sub

    Public Sub update()

        colbox.update(realPos)

        If seaking = True Then
            vel = rotationCalc.findNextStep(target, pos, speed)
        End If

        pos += vel

        realPos = pos - New Vector2(size.X / 2, size.Y / 2)

        If rotationCalc.distanceToPoint(startingPos, pos) > range Then
            colbox.destroy()
        End If

        If collisionTests.isCollision("wall", colbox.colRect) IsNot Nothing Then
            colbox.destroy()
        End If

        If collisionTests.isCollision("house", colbox.colRect) IsNot Nothing Then
            colbox.destroy()
        End If

        If colbox.isAlive = False Then
            destroy()
        End If

    End Sub

    Public Sub destroy()


        Game1.gameLoop.gameScene.playerBullets.Remove(Me)


    End Sub

    Public Sub draw(sb As SpriteBatch)

        Dim texture As Texture2D = Game1.contentMnger.loadTexture("White")
        sb.Draw(Game1.contentMnger.loadTexture("White"), New Rectangle(pos.X + Globals.cameraLoc.X, pos.Y + Globals.cameraLoc.Y, size.X, size.Y), Nothing, Color.Black, Nothing, New Vector2(texture.Width / 2.0F, texture.Height / 2.0F), Nothing, Nothing)

    End Sub

End Class
