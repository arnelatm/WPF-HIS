'Public Class PropertyMatcher(Of TParent As Class, TChild As Class)
Public Class PropertyMatcher

    Public Shared Sub GenerateMatchedObject(Of TParent, TChild)(ByVal parent As TParent, ByVal child As TChild)
        Dim childProperties = child.[GetType]().GetProperties()

        For Each childProperty In childProperties
            Dim attributesForProperty = childProperty.GetCustomAttributes(GetType(MatchParentAttribute), True)
            Dim isOfTypeMatchParentAttribute = False
            Dim currentAttribute As MatchParentAttribute = Nothing

            For Each attribute In attributesForProperty

                If attribute.[GetType]() = GetType(MatchParentAttribute) Then
                    isOfTypeMatchParentAttribute = True
                    currentAttribute = CType(attribute, MatchParentAttribute)
                    Exit For
                End If
            Next

            'If isOfTypeMatchParentAttribute Then
            Dim parentProperties = parent.[GetType]().GetProperties()
            Dim parentPropertyValue As Object = Nothing

            For Each parentProperty In parentProperties

                If parentProperty.Name = currentAttribute.ParentPropertyName Then

                    If parentProperty.PropertyType = childProperty.PropertyType Then
                        parentPropertyValue = parentProperty.GetValue(parent)
                    End If
                End If
            Next

            childProperty.SetValue(child, parentPropertyValue)

            'End If
        Next
    End Sub

End Class