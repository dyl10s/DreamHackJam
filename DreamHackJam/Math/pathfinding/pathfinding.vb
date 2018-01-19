Public Class pathfinding

    Public Function findPath(target As Vector2, curlocation As Vector2) As List(Of Vector2)

        Dim nodes(500, 500) As node

        Dim targetNode As node
        Dim curNode As node

        For x As Integer = 0 To nodes.GetLength(0)
            For y As Integer = 0 To nodes.GetLength(1)

                nodes(x, y) = New node(New Vector2(x * 32, y * 32), New Vector2(x, y))

                If nodes(x, y).location.X - target.X < 32 Then
                    If nodes(x, y).location.Y - target.Y < 32 Then
                        targetNode = nodes(x, y)
                    End If
                End If

                If nodes(x, y).location.X - curlocation.X < 32 Then
                    If nodes(x, y).location.Y - curlocation.Y < 32 Then
                        curNode = nodes(x, y)
                    End If
                End If

                For Each w As Wall In Game1.gameLoop.gameScene.walls

                    If w.colbox.colRect.Contains(nodes(x, y).location) Then
                        nodes(x, y).taken = True
                    End If

                Next

            Next
        Next


        'Check up





    End Function

End Class
