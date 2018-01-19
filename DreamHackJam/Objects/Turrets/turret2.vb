Public Class turret2

    Public name As String = "Shotgun Turret"

    Public pos As New Vector2(100, 100)
    Public size As New Vector2(50, 50)

    Public Shared bullets As New List(Of Bullet)

    Public textureName As String = "8 Side Turret Level 1"

    Public health As Integer = 100

    Public range As Integer = 500

    Public firerate As Integer = 1000
    Public fireTimer As Stopwatch = New Stopwatch

    Public upgradePrice As Integer = 20
    Public level As Integer = 1

    Public colbox As collisionBox

    Public hpBar As healthBar

    Public speed As Integer = 2

    Public realPos As Vector2 = pos - New Vector2(size.X / 2, size.Y / 2)

    Public Sub New(position As Vector2)

        pos = position

        fireTimer.Start()

        realPos = pos - New Vector2(size.X / 2, size.Y / 2)

        colbox = New collisionBox(realPos, size, "turret2")
        hpBar = New healthBar(New Vector2(size.X * 1.02, 5), health, colbox.colRect)

    End Sub

    Public Sub update()

        colbox.update(realPos)

        If fireTimer.ElapsedMilliseconds >= firerate Then
            For Each e As EnemyBasic In Game1.gameLoop.gameScene.basicEnemies

                Dim distance As Integer = rotationCalc.distanceToPoint(realPos, e.realPos)

                If distance < range Then

                    Dim centerPos As Vector2 = New Vector2(realPos.X + size.X / 2, realPos.Y + size.Y / 2)

                    Dim createbullets As New List(Of Bullet)

                    createbullets.Add(New Bullet(New Vector2(centerPos.X + 1, centerPos.Y), centerPos, False, range))
                    createbullets.Add(New Bullet(New Vector2(centerPos.X - 1, centerPos.Y), centerPos, False, range))
                    createbullets.Add(New Bullet(New Vector2(centerPos.X + 1, centerPos.Y - 1), centerPos, False, range))
                    createbullets.Add(New Bullet(New Vector2(centerPos.X - 1, centerPos.Y + 1), centerPos, False, range))
                    createbullets.Add(New Bullet(New Vector2(centerPos.X, centerPos.Y + 1), centerPos, False, range))
                    createbullets.Add(New Bullet(New Vector2(centerPos.X, centerPos.Y - 1), centerPos, False, range))
                    createbullets.Add(New Bullet(New Vector2(centerPos.X - 1, centerPos.Y - 1), centerPos, False, range))
                    createbullets.Add(New Bullet(New Vector2(centerPos.X + 1, centerPos.Y + 1), centerPos, False, range))

                    Game1.gameLoop.gameScene.playerBullets.AddRange(createbullets)

                    fireTimer.Restart()
                    Exit For

                End If

            Next
        End If


        Dim tempBullets As New List(Of Bullet)(bullets)
        For Each b As Bullet In tempBullets
            b.update()
        Next


        realPos = pos - New Vector2(size.X / 2, size.Y / 2)

        If health <= 0 Then
            colbox.destroy()
        End If

        If Not colbox.isAlive = True Then
            destroy()
        End If

        hpBar.update(health, New Rectangle(realPos.X, realPos.Y, size.X, size.Y))

    End Sub

    Public Sub destroy()

        Game1.gameLoop.gameScene.turret2s.Remove(Me)

    End Sub

    Public Sub levelUp()

        level += 1

        Select Case level
            Case 1
                health = 100
                range = 400
                firerate = 600
                upgradePrice = 20
                textureName = "8 Side Turret Level 1"
            Case 2
                health = 100
                range = 450
                firerate = 400
                upgradePrice = 50
                textureName = "8 Side Turret Level 2"
            Case 3
                health = 100
                range = 500
                firerate = 200
                upgradePrice = -1
                textureName = "8 Side Turret Level 3"
        End Select

    End Sub

    Public Sub draw(sb As SpriteBatch)

        Dim tempSeackingBullets As New List(Of Bullet)(bullets)
        For Each b As Bullet In tempSeackingBullets
            b.draw(sb)
        Next

        Dim texture As Texture2D = Game1.contentMnger.loadTexture(textureName)
        sb.Draw(texture, New Rectangle(pos.X + Globals.cameraLoc.X, pos.Y + Globals.cameraLoc.Y, size.X, size.Y), Nothing, Color.White, 0, New Vector2(texture.Width / 2.0F, texture.Height / 2.0F), Nothing, 0.19)

        hpBar.draw(sb)

    End Sub

End Class
