Public Class userInferface

    Public money As Integer
    Public hp As Integer

    Public repairSelect As repairSelect
    Public upgradeSelect As upgradeSelect
    Public demoSelect As destroySelect

    Public t1Select As turretSelect
    Public t2Select As turretSelect
    Public t3Select As turretSelect

    Public Sub update(Health As Integer, totalMoney As Integer)

        hp = Health
        money = totalMoney

        If t1Select Is Nothing Then
        Else
            t1Select.update()
        End If

        If t2Select Is Nothing Then
        Else
            t2Select.update()
        End If

        If t3Select Is Nothing Then
        Else
            t3Select.update()
        End If

        If repairSelect Is Nothing Then
        Else
            repairSelect.update()
        End If

        If upgradeSelect Is Nothing Then
        Else
            upgradeSelect.update()
        End If

        If demoSelect Is Nothing Then
        Else
            demoSelect.update()
        End If

    End Sub

    Public Sub draw(sb As SpriteBatch)

        'sb.Draw(Game1.contentMnger.loadTexture("White"), New Rectangle(0, 650, 1280, 70), Nothing, Color.Black, Nothing, Nothing, Nothing, 0.7)
        sb.Draw(Game1.contentMnger.loadTexture("UI Bar Underlay"), New Rectangle(0, 650, 1280, 70), Nothing, Color.White, Nothing, Nothing, Nothing, 0.89)

        'DRAW HP

        Dim hpLeft As Integer = 215
        Dim hpY As Integer = 673

        Dim hpWidth As Integer = 289
        Dim hpHeight As Integer = 23

        sb.Draw(Game1.contentMnger.loadTexture("white"), New Rectangle(hpLeft, hpY, hpWidth, hpHeight), Nothing, Color.Red, Nothing, Nothing, Nothing, 0.9)
        Dim hpPercent As Double = hp / 200
        sb.Draw(Game1.contentMnger.loadTexture("white"), New Rectangle(hpLeft, hpY, hpWidth * hpPercent, hpHeight), Nothing, Color.Green, Nothing, Nothing, Nothing, 0.91)

        'DRAW MONEY
        Dim moneyLeft As Integer = 22
        Dim moneyY As Integer = 675

        'sb.DrawString(Game1.contentMnger.loadFont("mainFont"), "Money:", New Vector2(moneyLeft, moneyY), Color.Black, Nothing, Nothing, 1, Nothing, 0.999)
        sb.DrawString(Game1.contentMnger.loadFont("mainFont"), "$ " + money.ToString, New Vector2(moneyLeft + 75, moneyY), Color.Green, Nothing, Nothing, 1, Nothing, 0.999)

        'DRAW TURRET SELECTS
        Dim t1X As Integer = 556
        Dim t1Y As Integer = 668

        Dim spaceing As Integer = 25

        Dim t1Width As Integer = 35
        Dim t1height As Integer = 35

        If t1Select Is Nothing Then
            t1Select = New turretSelect(New Vector2(t1X + t1Width + spaceing, t1Y), New Vector2(t1Width, t1height), "Standard Tower Turret Icon", 1)
        End If

        t1Select.draw(sb)

        If t2Select Is Nothing Then
            t2Select = New turretSelect(New Vector2(t1X, t1Y), New Vector2(t1Width, t1height), "8 Side Turret Icon", 2)
        End If

        t2Select.draw(sb)

        If t3Select Is Nothing Then
            t3Select = New turretSelect(New Vector2(t1X + (2 * (t1Width + spaceing)), t1Y), New Vector2(t1Width, t1height), "Big Boom Turret Icon", 3)
        End If

        t3Select.draw(sb)

        If repairSelect Is Nothing Then
            repairSelect = New repairSelect(New Vector2(t1X, t1Y), New Rectangle(t1X + 392, 663, 43, 43))
        End If

        repairSelect.draw(sb)

        If upgradeSelect Is Nothing Then
            upgradeSelect = New upgradeSelect(New Vector2(t1X, t1Y), New Rectangle(t1X + 317, 663, 43, 43))
        End If

        upgradeSelect.draw(sb)

        If demoSelect Is Nothing Then
            demoSelect = New destroySelect(New Vector2(t1X, t1Y), New Rectangle(t1X + 466, 663, 43, 43))
        End If

        demoSelect.draw(sb)

        sb.Draw(Game1.contentMnger.loadTexture("UI Bar Overlay"), New Rectangle(0, 650, 1280, 70), Nothing, Color.DarkGray, Nothing, Nothing, Nothing, 0.9999999)

    End Sub

End Class
