Public Class EnemyBasic

    Public vel As New Vector2(0, 0)
    Public pos As New Vector2(100, 100)
    Public size As New Vector2(50, 50)

    Public health As Integer = 100

    Public colbox As collisionBox

    Public hpBar As healthBar

    Public attackType As String = "house"
    Public texture As String = ""

    Public speed As Integer = 2

    Public realPos As Vector2 = pos - New Vector2(size.X / 2, size.Y / 2)

    Public rotation As Double = 0

    Public Sub New(location As Vector2, type As String, textureName As String, hp As Integer, enemySpeed As Integer)

        pos = location

        realPos = pos - New Vector2(size.X / 2, size.Y / 2)

        attackType = type.ToLower
        texture = textureName
        health = hp
        speed = enemySpeed

        colbox = New collisionBox(realPos, size, "enemybasic")
        hpBar = New healthBar(New Vector2(size.X * 1.02, 5), health, colbox.colRect)
    End Sub

    Public Sub update()

        colbox.update(realPos)
        hpBar.update(health, colbox.colRect)
        Dim newMove As Vector2

        Select Case attackType
            Case "house"

                Dim closestHouse As house
                Dim closeDistance As Integer = 100000000
                For Each h As house In Game1.gameLoop.gameScene.houses

                    If rotationCalc.distanceToPoint(pos, h.pos) < closeDistance Then
                        closeDistance = rotationCalc.distanceToPoint(pos, h.pos)
                        closestHouse = h
                    End If

                Next

                If closestHouse Is Nothing Then
                Else
                    rotation = rotationCalc.findRotationToPoint(closestHouse.realPos, realPos)
                    newMove = rotationCalc.findNextStep(closestHouse.realPos, realPos, speed)
                End If

            Case "player"

                Dim closestPlayer As player
                Dim closeDistance As Integer = 100000000
                For Each p As player In Game1.gameLoop.gameScene.players

                    If rotationCalc.distanceToPoint(pos, p.pos) < closeDistance Then
                        closeDistance = rotationCalc.distanceToPoint(pos, p.pos)
                        closestPlayer = p
                    End If

                Next

                rotation = rotationCalc.findRotationToPoint(closestPlayer.realPos, realPos)

                newMove = rotationCalc.findNextStep(closestPlayer.realPos, realPos, speed)

            Case "turret"

                Dim closestTurret1 As turret1
                Dim closestTurret2 As turret2
                Dim closestTurret3 As turret3

                Dim closeTNum As Integer = 0
                Dim closeDistance As Integer = 100000000

                For Each t As turret1 In Game1.gameLoop.gameScene.turret1s

                    If rotationCalc.distanceToPoint(pos, t.pos) < closeDistance Then
                        closeDistance = rotationCalc.distanceToPoint(pos, t.pos)
                        closestTurret1 = t
                        closeTNum = 1
                    End If

                Next

                For Each t As turret2 In Game1.gameLoop.gameScene.turret2s

                    If rotationCalc.distanceToPoint(pos, t.pos) < closeDistance Then
                        closeDistance = rotationCalc.distanceToPoint(pos, t.pos)
                        closestTurret2 = t
                        closeTNum = 2
                    End If

                Next

                For Each t As turret3 In Game1.gameLoop.gameScene.turret3s

                    If rotationCalc.distanceToPoint(pos, t.pos) < closeDistance Then
                        closeDistance = rotationCalc.distanceToPoint(pos, t.pos)
                        closestTurret3 = t
                        closeTNum = 3
                    End If

                Next

                Select Case closeTNum
                    Case 1
                        rotation = rotationCalc.findRotationToPoint(closestTurret1.realPos, realPos)
                        newMove = rotationCalc.findNextStep(closestTurret1.realPos, realPos, speed)
                    Case 2
                        rotation = rotationCalc.findRotationToPoint(closestTurret2.realPos, realPos)
                        newMove = rotationCalc.findNextStep(closestTurret2.realPos, realPos, speed)
                    Case 3
                        rotation = rotationCalc.findRotationToPoint(closestTurret3.realPos, realPos)
                        newMove = rotationCalc.findNextStep(closestTurret3.realPos, realPos, speed)
                End Select

                If closeTNum = 0 Then

                    Dim closestHouse As house
                    For Each h As house In Game1.gameLoop.gameScene.houses

                        If rotationCalc.distanceToPoint(pos, h.pos) < closeDistance Then
                            closeDistance = rotationCalc.distanceToPoint(pos, h.pos)
                            closestHouse = h
                        End If

                    Next

                    If closestHouse Is Nothing Then
                    Else
                        rotation = rotationCalc.findRotationToPoint(closestHouse.realPos, realPos)
                        newMove = rotationCalc.findNextStep(closestHouse.realPos, realPos, speed)
                    End If


                End If

        End Select


        Dim tempLocation As Vector2 = pos + newMove

        Dim hitWall As collisionBox = collisionTests.isCollision("wall", New Rectangle(realPos.X - 10, realPos.Y - 10, size.X + 20, size.Y + 20))

        If Not hitWall Is Nothing Then
            For Each w As Wall In Game1.gameLoop.gameScene.walls
                If w.colbox Is hitWall Then
                    w.hp -= 1
                End If
            Next
        End If

        Dim hitPlayer As collisionBox = collisionTests.isCollision("player", New Rectangle(realPos.X - 10, realPos.Y - 10, size.X + 20, size.Y + 20))

        If Not hitPlayer Is Nothing Then
            For Each p As player In Game1.gameLoop.gameScene.players
                If p.colbox Is hitPlayer Then
                    p.hp -= 1
                End If
            Next
        End If

        Dim hitt1 As collisionBox = collisionTests.isCollision("turret1", New Rectangle(realPos.X - 10, realPos.Y - 10, size.X + 20, size.Y + 20))

        If Not hitt1 Is Nothing Then
            For Each t As turret1 In Game1.gameLoop.gameScene.turret1s
                If t.colbox Is hitt1 Then
                    t.health -= 1
                End If
            Next
        End If

        Dim hitt2 As collisionBox = collisionTests.isCollision("turret2", New Rectangle(realPos.X - 10, realPos.Y - 10, size.X + 20, size.Y + 20))

        If Not hitt2 Is Nothing Then
            For Each t As turret2 In Game1.gameLoop.gameScene.turret2s
                If t.colbox Is hitt2 Then
                    t.health -= 1
                End If
            Next
        End If

        Dim hitt3 As collisionBox = collisionTests.isCollision("turret3", New Rectangle(realPos.X - 10, realPos.Y - 10, size.X + 20, size.Y + 20))

        If Not hitt3 Is Nothing Then
            For Each t As turret3 In Game1.gameLoop.gameScene.turret3s
                If t.colbox Is hitt3 Then
                    t.health -= 1
                End If
            Next
        End If

        Dim hitHouse As collisionBox = collisionTests.isCollision("house", New Rectangle(realPos.X - 10, realPos.Y - 10, size.X + 20, size.Y + 20))

        If Not hitHouse Is Nothing Then
            For Each h As house In Game1.gameLoop.gameScene.houses
                If h.colbox Is hitHouse Then
                    h.health -= 1
                End If
            Next
        End If

        newMove = collisionTests.moveWithCollosion(realPos, newMove, "wall", colbox)
        newMove = collisionTests.moveWithCollosion(realPos, newMove, "player", colbox)
        newMove = collisionTests.moveWithCollosion(realPos, newMove, "house", colbox)
        newMove = collisionTests.moveWithCollosion(realPos, newMove, "turret1", colbox)
        newMove = collisionTests.moveWithCollosion(realPos, newMove, "turret2", colbox)
        newMove = collisionTests.moveWithCollosion(realPos, newMove, "turret3", colbox)
        newMove = collisionTests.moveWithCollosion(realPos, newMove, "enemybasic", colbox)

        pos += newMove

        realPos = pos - New Vector2(size.X / 2, size.Y / 2)

        Dim hitColbox As collisionBox = collisionTests.isCollision("bullet", colbox.colRect)

        If Not hitColbox Is Nothing Then

            health -= 20
            hitColbox.destroy()

        End If

        Dim hit2Colbox As collisionBox = collisionTests.isCollision("bullet2", colbox.colRect)

        If Not hit2Colbox Is Nothing Then

            health -= 5

        End If

        If health <= 0 Then
            colbox.destroy()
        End If

        If Not colbox.isAlive = True Then
            destroy()
        End If

    End Sub

    Public Sub destroy()

        Game1.gameLoop.gameScene.moneys.Add(New money(pos))
        Game1.gameLoop.gameScene.basicEnemies.Remove(Me)
        Globals.points += 10

    End Sub

    Public Sub draw(sb As SpriteBatch)

        Dim texture As Texture2D = Game1.contentMnger.loadTexture(Me.texture)
        sb.Draw(texture, New Rectangle(pos.X + Globals.cameraLoc.X, pos.Y + Globals.cameraLoc.Y, size.X, size.Y), Nothing, Color.White, rotation, New Vector2(texture.Width / 2.0F, texture.Height / 2.0F), Nothing, 0.2)

        hpBar.draw(sb)

    End Sub

End Class
