Public Class money

    Public pos As Vector2
    Public realPos As Vector2 = pos - New Vector2(size.X / 2, size.Y / 2)

    Public size As Vector2 = New Vector2(40, 25)

    Public colbox As collisionBox


    Public Sub New(location As Vector2)

        pos = location
        realPos = pos - New Vector2(size.X / 2, size.Y / 2)

        colbox = New collisionBox(realPos, size, "money")

    End Sub

    Public Sub update()

        colbox.update(realPos)

        For Each p As player In Game1.gameLoop.gameScene.players
            If rotationCalc.distanceToPoint(p.pos, pos) < 200 Then
                pos += rotationCalc.findNextStep(p.pos, pos, 5)
            End If
        Next


        Dim hitPlayer As collisionBox = collisionTests.isCollision("player", colbox.colRect)

        If Not hitPlayer Is Nothing Then
            For Each p As player In Game1.gameLoop.gameScene.players

                If p.colbox Is hitPlayer Then
                    p.money += 10
                    colbox.destroy()
                End If

            Next
        End If

        If Not colbox.isAlive = True Then
            destroy()
        End If

        realPos = pos - New Vector2(size.X / 2, size.Y / 2)

    End Sub

    Public Sub destroy()

        Game1.gameLoop.gameScene.moneys.Remove(Me)

    End Sub

    Public Sub draw(sb As SpriteBatch)

        Dim texture As Texture2D = Game1.contentMnger.loadTexture("MoneyDrop")
        sb.Draw(texture, New Rectangle(pos.X + Globals.cameraLoc.X, pos.Y + Globals.cameraLoc.Y, size.X, size.Y), Nothing, Color.White, Nothing, New Vector2(texture.Width / 2.0F, texture.Height / 2.0F), Nothing, 0.1)

    End Sub

End Class
