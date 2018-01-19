Public Class turret3

    Public name As String = "Bomb Turret"

    Public pos As New Vector2(100, 100)
    Public size As New Vector2(50, 50)

    Public health As Integer = 100

    Public range As Integer = 500

    Public textureName As String = "Big Boom Turret Level 1"

    Public rotation As Single = 0

    Public firerate As Integer = 1500
    Public fireTimer As Stopwatch = New Stopwatch

    Public upgradePrice As Integer = 100
    Public level As Integer = 1

    Public colbox As collisionBox

    Public hpBar As healthBar

    Public speed As Integer = 2

    Public realPos As Vector2 = pos - New Vector2(size.X / 2, size.Y / 2)

    Public Sub New(position As Vector2)

        pos = position

        fireTimer.Start()

        realPos = pos - New Vector2(size.X / 2, size.Y / 2)

        colbox = New collisionBox(realPos, size, "turret3")
        hpBar = New healthBar(New Vector2(size.X * 1.02, 5), health, colbox.colRect)

    End Sub

    Public Sub update()

        colbox.update(realPos)


        Dim closeE As EnemyBasic
        Dim distanceE As Integer = 10000000

        For Each e As EnemyBasic In Game1.gameLoop.gameScene.basicEnemies

            Dim distance As Integer = rotationCalc.distanceToPoint(realPos, e.realPos)

            If distance < range Then

                If distance < distanceE Then
                    distanceE = distance
                    closeE = e
                End If

            End If

        Next

        If Not closeE Is Nothing Then
            rotation = rotationCalc.findRotationToPoint(closeE.realPos, realPos)
            If fireTimer.ElapsedMilliseconds >= firerate Then
                Game1.gameLoop.gameScene.bombs.Add(New bomb(closeE.pos, realPos + New Vector2(size.X / 2, size.Y / 2), False, 500))
                fireTimer.Restart()
            End If
        End If

        realPos = pos - New Vector2(size.X / 2, size.Y / 2)

        If health <= 0 Then
            colbox.destroy()
        End If

        If Not colbox.isAlive = True Then
            destroy()
        End If

        hpBar.update(health, New Rectangle(realPos.X, realPos.Y, size.X, size.Y))

    End Sub

    Public Sub levelUp()

        level += 1

        Select Case level
            Case 1
                health = 100
                range = 500
                firerate = 1500
                upgradePrice = 100
                textureName = "Big Boom Turret Level 1"
            Case 2
                health = 100
                range = 600
                firerate = 1200
                upgradePrice = 150
                textureName = "Big Boom Turret Level 2"
            Case 3
                health = 100
                range = 700
                firerate = 900
                upgradePrice = -1
                textureName = "Big Boom Turret Level 3"
        End Select

    End Sub

    Public Sub destroy()

        Game1.gameLoop.gameScene.turret3s.Remove(Me)

    End Sub

    Public Sub draw(sb As SpriteBatch)

        Dim texture As Texture2D = Game1.contentMnger.loadTexture(textureName)
        sb.Draw(texture, New Rectangle(pos.X + Globals.cameraLoc.X, pos.Y + Globals.cameraLoc.Y, size.X, size.Y), Nothing, Color.White, rotation, New Vector2(texture.Width / 2.0F, texture.Height / 2.0F), Nothing, 0.19)

        hpBar.draw(sb)

    End Sub

End Class
