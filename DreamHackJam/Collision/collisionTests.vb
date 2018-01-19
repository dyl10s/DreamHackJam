Public Class collisionTests

    Public Shared Function isCollision(type As String, myBox As Rectangle) As collisionBox

        For Each colbox As collisionBox In collisionBox.colboxes
            If myBox.Intersects(colbox.colRect) Then
                If colbox.type = type Then
                    Return colbox
                End If
            End If
        Next

        Return Nothing

    End Function

    Public Shared Function moveWithCollosion(location As Vector2, movement As Vector2, findType As String, colbox As collisionBox) As Vector2

        Dim finalLocation As Vector2 = location + movement
        Dim finalColbox As New Rectangle(finalLocation.X, finalLocation.Y, colbox.colRect.Width, colbox.colRect.Height)

        Dim hitColBoxs As New List(Of collisionBox)

        For Each cBox As collisionBox In collisionBox.colboxes
            If cBox.type = findType Then
                If cBox.colRect.Intersects(finalColbox) Then

                    hitColBoxs.Add(cBox)

                End If
            End If
        Next

        If hitColBoxs.Count = 0 Then
            Return movement
        End If

        For Each box As collisionBox In hitColBoxs

            If colbox.colRect.X >= box.colRect.X + box.colRect.Width Then

                If box.colRect.Width = 19 Then
                    movement.X = (box.colRect.X + box.colRect.Width + 1) - colbox.colRect.X
                Else
                    movement.X = (box.colRect.X + box.colRect.Width) - colbox.colRect.X
                End If

                GoTo NextBox

            ElseIf colbox.colRect.X + colbox.colRect.Width <= box.colRect.X Then

                movement.X = box.colRect.X - (colbox.colRect.X + colbox.colRect.Width)
                GoTo NextBox

            End If

            If colbox.colRect.Y >= box.colRect.Y + box.colRect.Height Then

                movement.Y = (box.colRect.Y + box.colRect.Height) - colbox.colRect.Y
                GoTo NextBox

            ElseIf colbox.colRect.Y + colbox.colRect.Height <= box.colRect.Y Then

                movement.Y = box.colRect.Y - (colbox.colRect.Y + colbox.colRect.Height)
                GoTo NextBox

            End If

NextBox:

        Next

        Return movement

    End Function

End Class
