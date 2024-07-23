Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.CBaseControlsLibrary

Namespace PresentationLayer.Presenters

    Public Class AppSettingPresenter(Of TM As New)
        Inherits CommonPresenter(Of IAppSettingView, TM)

        Public Sub New(itemView As IAppSettingView)
            MyBase.New(itemView)
            Service = New AccountsService("AppSetting")
            TableName = "AppSetting"
            SortOrderKey = "AppSettingGroupIdNo"
            WithTreeView = False
            'AddHandler View.LockGroupClicked, AddressOf LockGroupClicked
            AddHandler View.FilterRecords, AddressOf FilterRecords
            AddHandler View.AppSettingGroupValueChanged, AddressOf OnAppSettingGroupValueChanged
        End Sub

        Private Sub OnAppSettingGroupValueChanged(sender As Object)
            Dim cb As AtmComboBox = DirectCast(sender, AtmComboBox)
            Dim idNo As Int16 = cb.SelectedValue
            View.DataFilter = "AppSettingGroupIdNo = " & idNo.ToString()
            Dim appSettingGroup As Object
            appSettingGroup = Service.GetFieldsWithIdNo(idNo, "AppSettingGroup", "IdNo,AppSettingCode,AppSettingGroupName,AppSettingGroupNameAra,SelectorTable1,SelectorTable2,SelectorText1,SelectorText2,SelectorCount", "IdNo")
            If appSettingGroup IsNot Nothing Then
                View.AppSettingGroupIdNo = idNo
                View.SavedGroupIdNo = idNo
                View.Selector1Text = appSettingGroup.SelectorText1
                View.SelectorCount = appSettingGroup.SelectorCount
                Dim data As New ArrayList
                data.Add({appSettingGroup.SelectorTable1, "Selector1IdNo", Nothing, Nothing})
                If appSettingGroup.SelectorCount > 1 Then
                    View.Selector2Text = appSettingGroup.SelectorText2
                    data.Add({appSettingGroup.SelectorTable2, "Selector2IdNo", Nothing, Nothing})
                End If
                CreateControlDataSources(data)
            End If
            FilterRecords()
        End Sub

        Protected Overrides Sub CreateDataSources()
            Dim data As New ArrayList
            data.Add({"AppSettingGroup", "AppSettingGroupSelector", "IdNo,AppSettingGroupName,AppSettingCode", Nothing})
            CreateControlDataSources(data)
        End Sub

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            'If CheckDependentRecords(Of Int32)(View.IdNo, "AppSettingAccount", "AppSettingIdNo") Then
            '    Return True
            'ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "Supplier", "AppSettingIdNo") Then
            '    Return True
            'ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "Customer", "AppSettingIdNo") Then
            '    Return True
            'ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "Employee", "AppSettingIdNo") Then
            '    Return True
            'ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "PensionProvider", "AppSettingIdNo") Then
            '    Return True
            'End If
            Return False
        End Function

        'Public Sub LockGroupClicked()
        '    If View.LockGroup Then
        '        DataFilter = "CodeGroupIdNo = " & View.CodeGroupIdNo.ToString()
        '    Else
        '        DataFilter = ""
        '    End If
        '    DisplayTree()
        'End Sub


        Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            'If View.LockGroup Then
            View.AppSettingGroupIdNo = View.SavedGroupIdNo
            'End If
        End Sub

        Public Overrides Sub GoFilter()
            'If DataFilter Is Nothing Or DataFilter = "" Then
            '    DataFilter = "Active = 1"
            'Else
            '    DataFilter = ""
            'End If
            DisplayTree()
            GoFirstRecord()
        End Sub

        Public Sub FilterRecords()
            DataFilter = View.DataFilter
            'DisplayTree()
            If Not AddMode Then
                GoLastRecord()
            End If
        End Sub



    End Class

End Namespace