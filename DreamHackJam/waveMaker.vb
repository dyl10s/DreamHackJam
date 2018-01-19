Public Class waveMaker

    Public people As Integer
    Public curPeople As Integer

    Public speed As Integer

    Public troup1s As Integer
    Public troup2s As Integer
    Public troup3s As Integer

    Public top As Integer
    Public bottom As Integer
    Public right As Integer
    Public left As Integer

    Public Sub New(rate As Integer, percentTop As Integer, percentBottom As Integer, percentRight As Integer, percentLeft As Integer, houseTroops As Integer, playerTroops As Integer, turretTroops As Integer)

        speed = rate

        troup1s = houseTroops
        troup2s = playerTroops
        troup3s = turretTroops

        people = troup1s + troup2s + troup3s

        top = percentTop
        bottom = percentBottom
        right = percentRight
        left = percentLeft

    End Sub

    Public Function update() As Boolean

        If curPeople >= people Then
            If Game1.gameLoop.gameScene.basicEnemies.Count = 0 Then
                Return True
            End If
            Return False
        End If

        Randomize()

        If Math.Floor(Rnd() * speed) = 1 Then

            Select Case Rnd() * 100
                Case < top
                    createNumberedTroop(Rnd() * Globals.map.X, 0)
                    curPeople += 1
                    Exit Select
                Case < top + bottom
                    createNumberedTroop(Rnd() * Globals.map.X, Globals.map.Y)
                    curPeople += 1
                    Exit Select
                Case < top + bottom + right
                    createNumberedTroop(Globals.map.X, Rnd() * Globals.map.Y)
                    curPeople += 1
                    Exit Select
                Case < top + bottom + right + left
                    createNumberedTroop(0, Rnd() * Globals.map.Y)
                    curPeople += 1
                    Exit Select
            End Select

        End If


        Return False

    End Function

    Public Sub createNumberedTroop(x As Integer, y As Integer)

        Dim findTroopNum As Integer = 0
        Dim totalTroops As Integer = troup1s + troup2s + troup3s

        Randomize()

        Select Case Math.Floor(Rnd() * totalTroops)
            Case < troup1s
                findTroopNum = 1
                Exit Select
            Case < troup2s + troup1s
                findTroopNum = 2
                Exit Select
            Case < troup3s + troup1s + troup2s
                findTroopNum = 3
                Exit Select
        End Select


        Select Case findTroopNum
            Case 1
                Game1.gameLoop.gameScene.basicEnemies.Add(New EnemyBasic(New Vector2(x, y), "house", "Mutant 1", 100, 3))
            Case 2
                Game1.gameLoop.gameScene.basicEnemies.Add(New EnemyBasic(New Vector2(x, y), "player", "Mutant 2", 50, 5))
            Case 3
                Game1.gameLoop.gameScene.basicEnemies.Add(New EnemyBasic(New Vector2(x, y), "turret", "Mutant 3", 200, 2))
        End Select

    End Sub

End Class
