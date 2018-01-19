Public Class turret1

    Public name As String = "Seaking Turret"

    Public pos As New Vector2(100, 100)
    Public size As New Vector2(50, 50)

    Public seakingBullets As New List(Of seakingBullet)

    Public textureName As String = "Standard Tower Turret Level 1"

    Public health As Integer = 100
    Public range As Integer = 500
    Public firerate As Integer = 500

    Public rotation As Single = 0


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

        colbox = New collisionBox(realPos, size, "turret1")
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

                seakingBullets.Add(New seakingBullet(closeE, realPos + New Vector2(size.X / 2, size.Y / 2), 5000))
                fireTimer.Restart()

            End If
        End If


        Dim tempSeackingBullets As New List(Of seakingBullet)(seakingBullets)
        For Each b As seakingBullet In tempSeackingBullets
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

    Public Sub levelUp()

        level += 1

        Select Case level
            Case 1
                health = 100
                range = 500
                firerate = 500
                upgradePrice = 50
                textureName = "Standard Tower Turret Level 1"
            Case 2
                health = 100
                range = 700
                firerate = 400
                upgradePrice = 75
                textureName = "Standard Tower Turret Level 2"
            Case 3
                health = 100
                range = 800
                firerate = 300
                upgradePrice = -1
                textureName = "Standard Tower Turret Level 3"
        End Select

    End Sub


    Public Sub destroy()

        Game1.gameLoop.gameScene.turret1s.Remove(Me)

    End Sub

    Public Sub draw(sb As SpriteBatch)

        Dim tempSeackingBullets As New List(Of seakingBullet)(seakingBullets)
        For Each b As seakingBullet In tempSeackingBullets
            b.draw(sb)
        Next

        Dim texture As Texture2D = Game1.contentMnger.loadTexture(textureName)
        sb.Draw(texture, New Rectangle(pos.X + Globals.cameraLoc.X, pos.Y + Globals.cameraLoc.Y, size.X, size.Y), Nothing, Color.White, rotation, New Vector2(texture.Width / 2.0F, texture.Height / 2.0F), Nothing, 0.19)

        hpBar.draw(sb)

    End Sub

End Class
