Public Class player

    Public vel As New Vector2(0, 0)
    Public pos As New Vector2(Globals.map.X / 2, Globals.map.Y / 2)
    Public size As New Vector2(32, 32)

    Public hp As Integer = 200
    Public money As Integer = 100

    Public colbox As collisionBox

    Public speed As Integer = 5

    Public firerate As Integer = 250
    Public fireTimer As New Stopwatch

    Public realPos As Vector2 = pos - New Vector2(size.X / 2, size.Y / 2)

    Public rotation As Double = 0

    Public Sub New()

        fireTimer.Start()
        colbox = New collisionBox(realPos, size, "player")
        Globals.cameraLoc = New Vector2(-(Globals.map.X / 2) + (1280 / 2) , -(Globals.map.Y / 2) + (720 / 2))
    End Sub

    Public Sub update()

        colbox.update(realPos)

        Globals.totalMoney = money

        Dim ms As MouseState = Microsoft.Xna.Framework.Input.Mouse.GetState()
        rotation = rotationCalc.findRotationToPoint(New Vector2(ms.X, ms.Y), New Vector2(1280 / 2, 720 / 2))

        Dim ks As KeyboardState = Microsoft.Xna.Framework.Input.Keyboard.GetState

        'MOVEMENT 
        Dim newMove As New Vector2(0, 0)
        If ks.IsKeyDown(Keys.A) Then
            newMove.X -= speed
        ElseIf ks.IsKeyDown(Keys.D) Then
            newMove.X += speed
        End If

        If ks.IsKeyDown(Keys.W) Then
            newMove.Y -= speed
        ElseIf ks.IsKeyDown(Keys.s) Then
            newMove.Y += speed
        End If

        newMove = collisionTests.moveWithCollosion(realPos, newMove, "wall", colbox)
        newMove = collisionTests.moveWithCollosion(realPos, newMove, "house", colbox)
        newMove = collisionTests.moveWithCollosion(realPos, newMove, "turret1", colbox)
        newMove = collisionTests.moveWithCollosion(realPos, newMove, "turret2", colbox)
        newMove = collisionTests.moveWithCollosion(realPos, newMove, "turret3", colbox)
        newMove = collisionTests.moveWithCollosion(realPos, newMove, "enemybasic", colbox)

        If (pos + newMove).X < 640 Then
            newMove.X = 0
        End If

        If (pos + newMove).X > Globals.map.X - 640 Then
            newMove.X = 0
        End If

        If (pos + newMove).Y < 360 Then
            newMove.Y = 0
        End If

        If (pos + newMove).Y > Globals.map.Y - 360 Then
            newMove.Y = 0
        End If

        Globals.cameraLoc -= newMove
        pos += newMove

        'SHOOTING
        If ms.LeftButton = ButtonState.Pressed Then

            If fireTimer.ElapsedMilliseconds >= firerate Then

                Dim b As New Bullet(New Vector2(ms.X, ms.Y) - Globals.cameraLoc, New Vector2(1280 / 2, 720 / 2) - Globals.cameraLoc, False, 5000)
                Game1.gameLoop.gameScene.playerBullets.Add(b)
                fireTimer.Restart()

            End If

        End If

        Game1.gameLoop.gameScene.ui.update(hp, money)

        realPos = pos - New Vector2(size.X / 2, size.Y / 2)

        If hp <= 0 Then
            colbox.destroy()
        End If

        If Not colbox.isAlive = True Then
            destroy()
        End If

    End Sub

    Public Sub destroy()

        Game1.gameLoop.gameScene.players.Remove(Me)
        Globals.gameState = "lost"

    End Sub

    Public Sub draw(sb As SpriteBatch)

        Dim texture As Texture2D = Game1.contentMnger.loadTexture(Game1.contentMnger.player)
        sb.Draw(texture, New Rectangle(1280 / 2, 720 / 2, size.X, size.Y), Nothing, Color.White, rotation, New Vector2(texture.Width / 2.0F, texture.Height / 2.0F), Nothing, 0.2)
        sb.Draw(texture, New Rectangle(colbox.colRect.X - Globals.cameraLoc.X, colbox.colRect.Y - Globals.cameraLoc.Y, size.X, size.Y), Color.WhiteSmoke)
    End Sub

End Class
