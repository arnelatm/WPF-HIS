Imports AATM.ServicesLayer.Services

''' <summary>
'''     The Model in MVP design pattern.
'''     Implements IModel and communicates with WCF Service.
''' </summary>
Public Class ModelTblColProp
    Implements IModelTblColProp

    Private Shared ReadOnly TblColPropService = New TblColPropService()

    Public Function GetMainTableColumnProperties(tableName As String) As List(Of TblColPropModel) _
        Implements IModelTblColProp.GetMainTableColumnProperties

        Dim mainTableColumnProperties = TblColPropService.GetMainTableColumnProperties(tableName)
        Dim tblColPropModel As TblColPropModel
        Dim retTblColPropL As New List(Of TblColPropModel)
        For Each TblColProp In mainTableColumnProperties
            tblColPropModel = New TblColPropModel With {
                .FldName = TblColProp.FldName,
                .FldType = TblColProp.FldType,
                .MaxLength = TblColProp.MaxLength,
                .IsIdentity = TblColProp.IsIdentity,
                .IsNullable = TblColProp.IsNullable
                }
            retTblColPropL.Add(tblColPropModel)
        Next
        Return retTblColPropL
    End Function

End Class