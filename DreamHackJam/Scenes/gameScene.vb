Public Class gameScene

    Public players As New List(Of player)
    Public basicEnemies As New List(Of EnemyBasic)
    Public playerBullets As New List(Of Bullet)
    Public walls As New List(Of Wall)
    Public houses As New List(Of house)
    Public moneys As New List(Of money)

    Public messages As New List(Of message)

    Public peirceingBullets As New List(Of periceingBullet)
    Public bombs As New List(Of bomb)

    Public turret1s As New List(Of turret1)
    Public turret2s As New List(Of turret2)
    Public turret3s As New List(Of turret3)

    Public ui As New userInferface

    Public levelMaker As levelMaker

    Public Sub New()

        players.Add(New player)

        Dim addedX As Integer = 2115

        Dim fenceLong As Integer = 237
        Dim fenceWide As Integer = 19

        Dim house1Ratio As Integer = 1.29
        houses.Add(New house(New Vector2(2918 + 100, 2600), "House 1", New Vector2(200, 200 * house1Ratio)))

        Dim house2Ratio As Integer = 0.767
        houses.Add(New house(New Vector2(2918 + 100, 2263), "House 2", New Vector2(200 * house2Ratio, 200)))

        Dim house3Ratio As Integer = 1.27
        houses.Add(New house(New Vector2(2918 + 100, 1854 + 100), "House 3", New Vector2(200 * house3Ratio, 200)))

        Dim house4Ratio As Integer = 1.77
        houses.Add(New house(New Vector2(3223 + 215, 1869 + 100), "House 4", New Vector2(200 * house4Ratio, 200)))

        Dim house5Ratio As Integer = 1.003
        houses.Add(New house(New Vector2(3742 + 100, 1869 + 100), "House 5", New Vector2(200 * house5Ratio, 200)))

        Dim house6Ratio As Integer = 1
        houses.Add(New house(New Vector2(3742 + 100, 2454 + 100), "House 6", New Vector2(200 * house6Ratio, 200)))

        Dim house7Ratio As Integer = 0.97
        houses.Add(New house(New Vector2(3742 + 100, 2149 + 100), "House 7", New Vector2(200 * house7Ratio, 200)))

        For i As Integer = 0 To 4

            walls.Add(New Wall(contentMnger.fenceSIDE, New Vector2(fenceLong, fenceWide), New Vector2((i * fenceLong) + 2934, 1795), 0))

            If i <> 2 Then
                walls.Add(New Wall(contentMnger.fenceSIDE, New Vector2(fenceLong, fenceWide), New Vector2((i * fenceLong) + 2934, 2743), 0))
            End If

        Next

        For i As Integer = 0 To 3
            walls.Add(New Wall(contentMnger.fenceUP, New Vector2(fenceWide, fenceLong), New Vector2(2809, 1914 + (i * fenceLong)), 0))
            walls.Add(New Wall(contentMnger.fenceUP, New Vector2(fenceWide, fenceLong), New Vector2(4008, 1914 + (i * fenceLong)), 0))
        Next

        levelMaker = New levelMaker

    End Sub

    Public Sub update()

        'CREATE WAVE
        levelMaker.update()

        cursor.update()

        If houses.Count = 0 Then
            Globals.gameState = "lost"
        End If

        Dim tempPlayers As New List(Of player)(players)
        For Each p As player In tempPlayers
            p.update()
        Next

        Dim tempMoneys As New List(Of money)(moneys)
        For Each m As money In tempMoneys
            m.update()
        Next

        Dim tempBasicEnemies As New List(Of EnemyBasic)(basicEnemies)
        For Each be As EnemyBasic In tempBasicEnemies
            be.update()
        Next

        Dim tempBullet As New List(Of Bullet)(playerBullets)
        For Each bullet As Bullet In tempBullet
            bullet.update()
        Next

        Dim tempWalls As New List(Of Wall)(walls)
        For Each w As Wall In tempWalls
            w.update()
        Next

        Dim tempHouses As New List(Of house)(houses)
        For Each h As house In tempHouses
            h.update()
        Next

        Dim tempTurret1s As New List(Of turret1)(turret1s)
        For Each t As turret1 In tempTurret1s
            t.update()
        Next

        Dim tempTurret2s As New List(Of turret2)(turret2s)
        For Each t As turret2 In tempTurret2s
            t.update()
        Next

        Dim tempTurret3s As New List(Of turret3)(turret3s)
        For Each t As turret3 In tempTurret3s
            t.update()
        Next

        Dim temppBullets As New List(Of periceingBullet)(peirceingBullets)
        For Each pB As periceingBullet In temppBullets
            pB.update()
        Next

        Dim tempBombs As New List(Of bomb)(bombs)
        For Each bomb As bomb In tempBombs
            bomb.update()
        Next

        Dim tempMessages As New List(Of message)(messages)
        For Each m As message In tempMessages
            m.update()
        Next

    End Sub

    Public Sub draw(sb As SpriteBatch)

        sb.Begin(SpriteSortMode.FrontToBack, Nothing)

        sb.Draw(Game1.contentMnger.loadTexture("Full Map"), New Rectangle(0 + Globals.cameraLoc.X, 0 + Globals.cameraLoc.Y, 6739, 4590), Color.White)

        cursor.draw(sb)

        Dim tempPlayers As New List(Of player)(players)
        For Each p As player In players
            p.draw(sb)
        Next

        Dim tempBombs As New List(Of bomb)(bombs)
        For Each bomb As bomb In tempBombs
            bomb.draw(sb)
        Next

        Dim tempMoneys As New List(Of money)(moneys)
        For Each m As money In tempMoneys
            m.draw(sb)
        Next

        Dim tempBasicEnemies As New List(Of EnemyBasic)(basicEnemies)
        For Each be As EnemyBasic In basicEnemies
            be.draw(sb)
        Next

        Dim tempBullet As New List(Of Bullet)(playerBullets)
        For Each bullet As Bullet In playerBullets
            bullet.draw(sb)
        Next

        Dim tempWalls As New List(Of Wall)(walls)
        For Each w As Wall In tempWalls
            w.draw(sb)
        Next

        Dim tempHouses As New List(Of house)(houses)
        For Each h As house In tempHouses
            h.draw(sb)
        Next

        Dim tempTurret1s As New List(Of turret1)(turret1s)
        For Each t As turret1 In tempTurret1s
            t.draw(sb)
        Next

        Dim tempTurret2s As New List(Of turret2)(turret2s)
        For Each t As turret2 In tempTurret2s
            t.draw(sb)
        Next

        Dim tempTurret3s As New List(Of turret3)(turret3s)
        For Each t As turret3 In tempTurret3s
            t.draw(sb)
        Next

        Dim temppBullets As New List(Of periceingBullet)(peirceingBullets)
        For Each pB As periceingBullet In temppBullets
            pB.draw(sb)
        Next

        Dim tempMessages As New List(Of message)(messages)
        For Each m As message In tempMessages
            m.draw(sb)
        Next

        levelMaker.draw(sb)

        'Dim tempBoxes As New List(Of collisionBox)(collisionBox.colboxes)
        'For Each cb As collisionBox In tempBoxes
        '    cb.draw(sb)
        'Next

        ui.draw(sb)

        sb.End()

    End Sub

End Class
