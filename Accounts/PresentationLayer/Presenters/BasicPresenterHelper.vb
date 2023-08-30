Module BasicPresenterHelper

    Function AutoGenerateCode(tableName) As Boolean
        Dim autoCode As Boolean
        Select Case tableName
            Case "Unit"
                autoCode = True
            Case Else
                autoCode = False
        End Select
        Return autoCode
    End Function


End Module
