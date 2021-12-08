Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Common.ServiceLayer
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class OriginalCaptionsPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IOriginalCaptionsView, TM)

        Public Sub New(view As IOriginalCaptionsView)
            MyBase.New(view)
            Service = New CommonService("OriginalCaptions")
            TableName = "OriginalCaptions"
            SortOrderKey = "Caption"
            TreeViewMainField = "Caption"
            TreeViewSecondaryField = Nothing
        End Sub

        Public Function GetOriginalCaptionsList(Optional ByVal sortKey As String = "") As List(Of TM)
            Dim xModel As New TM
            Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of TM)(sortKey, xModel)
            Dim modelData = Service.GetAll(Of TM)(newSortOrderKey)
            If TreeViewList IsNot Nothing And TreeViewList.Count > 0 Then
                TreeViewList.Clear()
            End If
            For Each modData In modelData
                Dim modelTb As New TM
                GlobalVariables.Mapper.Map(modData, modelTb)
                TreeViewList.Add(modelTb)
            Next
            Return TreeViewList
        End Function

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            If CheckDependentRecords(Of Int32)(View.IdNo, "FormItems", "CaptionIdNo") Then
                Return True
            ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "SystemViewItem", "CaptionIdNo") Then
                Return True
            ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "TranslatedCaption", "CaptionIdNo") Then
                Return True
            End If
            Return False
        End Function

    End Class

End Namespace