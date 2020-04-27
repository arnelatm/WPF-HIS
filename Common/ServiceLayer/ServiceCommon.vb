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

        Private ReadOnly Property BranchDao As IDaoAll(Of Branch)
            Get
                Return DaoFactoryCommonFactory.CreateDao("Branch")
            End Get
        End Property

        Private ReadOnly Property CostCenterDao As IDaoAll(Of CostCenter)
            Get
                Return DaoFactoryCommonFactory.CreateDao("CostCenter")
            End Get
        End Property

        Private ReadOnly Property CountryDao As IDaoAll(Of Country)
            Get
                Return DaoFactoryCommonFactory.CreateDao("Country")
            End Get
        End Property

        Private ReadOnly Property DepartmentDao As IDaoAll(Of Department)
            Get
                Return DaoFactoryCommonFactory.CreateDao("Department")
            End Get
        End Property

        Private ReadOnly Property OriginalCaptionsDao As IDaoAll(Of OriginalCaptions)
            Get
                Return DaoFactoryCommonFactory.CreateDao("OriginalCaptions")
            End Get
        End Property

        Private ReadOnly Property OriginalMessagesDao As IDaoAll(Of OriginalMessages)
            Get
                Return DaoFactoryCommonFactory.CreateDao("OriginalMessages")
            End Get
        End Property

        Private ReadOnly Property PhoneTypeDao As IDaoAll(Of PhoneType)
            Get
                Return DaoFactoryCommonFactory.CreateDao("PhoneType")
            End Get
        End Property

        Private ReadOnly Property ProfitCenterDao As IDaoAll(Of ProfitCenter)
            Get
                Return DaoFactoryCommonFactory.CreateDao("ProfitCenter")
            End Get
        End Property

        Private ReadOnly Property ReligionDao As IDaoAll(Of Religion)
            Get
                Return DaoFactoryCommonFactory.CreateDao("Religion")
            End Get
        End Property

        Private ReadOnly Property RevenueGroupDao As IDaoAll(Of RevenueGroup)
            Get
                Return DaoFactoryCommonFactory.CreateDao("RevenueGroup")
            End Get
        End Property

        Private ReadOnly Property TranslatedCaptionDao As IDaoAll(Of TranslatedCaption)
            Get
                Return DaoFactoryCommonFactory.CreateDao("TranslatedCaption")
            End Get
        End Property

        Private ReadOnly Property TranslatedMessagesDao As IDaoAll(Of TranslatedMessages)
            Get
                Return DaoFactoryCommonFactory.CreateDao("TranslatedMessages")
            End Get
        End Property

        Public Sub New(accountName As String)
            Dim bizObject = $"AATM.Common.BusinessLayer." + accountName
            Dim dao = accountName + "Dao"
            DataBo = Activator.CreateInstance(Type.GetType(bizObject))
            If DataBo Is Nothing Then
                MessageBox.Show("Missing Business Object " + bizObject)
            End If
            DataDao = Me.GetType().GetProperty(dao, BindingFlags.NonPublic Or BindingFlags.Instance).GetValue(Me)
            If DataDao Is Nothing Then
                MessageBox.Show("Missing Data Access Object " + dao)
                Debugger.Break()
            End If

        End Sub

        Public Sub New()

        End Sub

    End Class

End Namespace