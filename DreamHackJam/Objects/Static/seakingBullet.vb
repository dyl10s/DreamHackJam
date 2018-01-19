Public Class seakingBullet

    Public pos As New Vector2(250, 250)
    Public size As New Vector2(10, 10)
    Public vel As Vector2

    Public colbox As collisionBox

    Public objectTarget As EnemyBasic

    Public target As Vector2


    Public speed As Integer = 5

    Public startingPos As Vector2

    Public range As Integer = 5000

    Public realPos As Vector2 = pos - New Vector2(size.X / 2, size.Y / 2)

    Public Sub New(shootTarget As EnemyBasic, startPos As Vector2, shotRange As Integer)

        objectTarget = shootTarget
        target = shootTarget.pos
        pos = startPos
        startingPos = pos

        range = shotRange

        vel = rotationCalc.findNextStep(target, pos, speed)

        realPos = pos - New Vector2(size.X / 2, size.Y / 2)
        colbox = New collisionBox(realPos, size, "bullet")

    End Sub

    Public Sub update()

        colbox.update(realPos)

        vel = rotationCalc.findNextStep(objectTarget.pos, pos, speed)

        If rotationCalc.distanceToPoint(objectTarget.pos, pos) < 10 Then
            colbox.destroy()
        End If

        pos += vel

        realPos = pos - New Vector2(size.X / 2, size.Y / 2)

        If rotationCalc.distanceToPoint(startingPos, pos) > range Then
            'colbox.destroy()
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

        For Each t As turret1 In Game1.gameLoop.gameScene.turret1s
            If t.seakingBullets.Contains(Me) Then
                t.seakingBullets.Remove(Me)
            End If
        Next

    End Sub

    Public Sub draw(sb As SpriteBatch)

        Dim texture As Texture2D = Game1.contentMnger.loadTexture("white")
        sb.Draw(texture, New Rectangle(pos.X + Globals.cameraLoc.X, pos.Y + Globals.cameraLoc.Y, size.X, size.Y), Nothing, Color.Black, Nothing, New Vector2(texture.Width / 2.0F, texture.Height / 2.0F), Nothing, Nothing)

    End Sub

End Class
