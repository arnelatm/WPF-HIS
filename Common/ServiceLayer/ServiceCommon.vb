Imports System.Reflection
Imports AATM.Common.BusinessLayer
Imports AATM.Common.DataLayer
Imports AATM.DataLayer
Imports AATM.ServicesLayer.Services

Namespace ServiceLayer

    Public Class ServiceCommon
        Inherits Service
        Implements IServiceCommon

        Protected Shared ReadOnly DaoFactoryCommonFactory As IDaoFactoryCommon = DaoFactoriesCommon.GetCommonFactory(Provider)

        Public Sub New(accountName As String, Optional daoTableOrViewName As String = Nothing)
            Dim bizObject = $"AATM.Common.BusinessLayer." + accountName
            DataBo = Activator.CreateInstance(Type.GetType(bizObject))
            If DataBo Is Nothing Then
                MessageBox.Show("Missing Business Object " + bizObject)
                Debugger.Break()
            End If
            DataDao = DaoFactoryCommonFactory.CreateDao(accountName, daoTableOrViewName)
            If DataDao Is Nothing Then
                MessageBox.Show("Missing Data Access Object " + accountName.Trim() + "dao")
                Debugger.Break()
            End If

        End Sub

        Public Sub New()
        End Sub

        'Private ReadOnly Property BranchDao As IDaoAll(Of Branch)
        '    Get
        '        Return DaoFactoryCommonFactory.CreateDao("Branch")
        '    End Get
        'End Property

        'Private ReadOnly Property RevCostCenterDao As IDaoAll(Of RevCostCenter)
        '    Get
        '        Return DaoFactoryCommonFactory.CreateDao("RevCostCenter")
        '    End Get
        'End Property

        'Private ReadOnly Property CountryDao As IDaoAll(Of Country)
        '    Get
        '        Return DaoFactoryCommonFactory.CreateDao("Country")
        '    End Get
        'End Property

        'Private ReadOnly Property DepartmentDao As IDaoAll(Of Department)
        '    Get
        '        Return DaoFactoryCommonFactory.CreateDao("Department")
        '    End Get
        'End Property

        'Private ReadOnly Property OriginalCaptionsDao As IDaoAll(Of OriginalCaptions)
        '    Get
        '        Return DaoFactoryCommonFactory.CreateDao("OriginalCaptions")
        '    End Get
        'End Property

        'Private ReadOnly Property OriginalMessagesDao As IDaoAll(Of OriginalMessages)
        '    Get
        '        Return DaoFactoryCommonFactory.CreateDao("OriginalMessages")
        '    End Get
        'End Property

        'Private ReadOnly Property PhoneTypeDao As IDaoAll(Of PhoneType)
        '    Get
        '        Return DaoFactoryCommonFactory.CreateDao("PhoneType")
        '    End Get
        'End Property

        ''Private ReadOnly Property RevCostCenterDao As IDaoAll(Of RevCostCenter)
        ''    Get
        ''        Return DaoFactoryCommonFactory.CreateDao("RevCostCenter")
        ''    End Get
        ''End Property

        'Private ReadOnly Property ReligionDao As IDaoAll(Of Religion)
        '    Get
        '        Return DaoFactoryCommonFactory.CreateDao("Religion")
        '    End Get
        'End Property

        'Private ReadOnly Property RevenueGroupDao As IDaoAll(Of RevenueGroup)
        '    Get
        '        Return DaoFactoryCommonFactory.CreateDao("RevenueGroup")
        '    End Get
        'End Property

        'Private ReadOnly Property TranslatedCaptionDao As IDaoAll(Of TranslatedCaption)
        '    Get
        '        Return DaoFactoryCommonFactory.CreateDao("TranslatedCaption")
        '    End Get
        'End Property

        'Private ReadOnly Property TranslatedMessagesDao As IDaoAll(Of TranslatedMessages)
        '    Get
        '        Return DaoFactoryCommonFactory.CreateDao("TranslatedMessages")
        '    End Get
        'End Property

        'Private Shadows ReadOnly Property DefaultFieldValueDao As IDaoAll(Of DefaultFieldValue)
        '    Get
        '        Return DaoFactoryCommonFactory.CreateDao("DefaultFieldValue")
        '    End Get
        'End Property

    End Class

End Namespace