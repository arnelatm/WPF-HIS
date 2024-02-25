Imports AATM.PresentationLayer.Views
Imports AATM.ServicesLayer.Services

Public Class DefaultFieldValuePresenter(Of TM As New)
    Inherits Presenter(Of IDefaultFieldValueView, TM)

    Public Sub New(view As IDefaultFieldValueView)
        MyBase.New(view)
        Service = New Service("DefaultFieldValue")
        TableName = "DefaultFieldValue_View"
        SortOrderKey = "SystemViewName + FieldName"
        TreeViewMainField = "SystemViewName"
        TreeViewSecondaryField = "FieldName"
    End Sub

    Protected Overrides Sub CreateDataSources()
        CreateEnumDataSource(Of DataTypeSelection)("DataType")
        MakeControlDataSources({New String() {"SystemView", "SystemViewIdNo", Nothing, Nothing}})
    End Sub

End Class