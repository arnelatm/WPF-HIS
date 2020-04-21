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

        ''Protected Shared ReadOnly CommonDao As ICommonDao = DaoFactoryCommonFactory.CreateDao("Common")
        'Private ReadOnly _branchDao As IDaoAll(Of Branch) = DaoFactoryCommonFactory.CreateDao("Branch")

        'Private ReadOnly _costCenterDao As IDaoAll(Of CostCenter) = DaoFactoryCommonFactory.CreateDao("CostCenter")
        'Private ReadOnly _countryDao As IDaoAll(Of Country) = DaoFactoryCommonFactory.CreateDao("Country")
        'Private ReadOnly _departmentDao As IDaoAll(Of Department) = DaoFactoryCommonFactory.CreateDao("Department")
        'Private ReadOnly _originalCaptionsDao As IDaoAll(Of OriginalCaptions) = DaoFactoryCommonFactory.CreateDao("OriginalCaptions")
        'Private ReadOnly _originalMessagesDao As IDaoAll(Of OriginalMessages) = DaoFactoryCommonFactory.CreateDao("OriginalMessages")
        'Private ReadOnly _phoneTypeDao As IDaoAll(Of PhoneType) = DaoFactoryCommonFactory.CreateDao("PhoneType")
        'Private ReadOnly _profitCenterDao As IDaoAll(Of ProfitCenter) = DaoFactoryCommonFactory.CreateDao("ProfitCenter")
        'Private ReadOnly _religionDao As IDaoAll(Of Religion) = DaoFactoryCommonFactory.CreateDao("Religion")
        'Private ReadOnly _revenueGroupDao As IDaoAll(Of RevenueGroup) = DaoFactoryCommonFactory.CreateDao("RevenueGroup")
        'Private ReadOnly _translatedCaptionDao As IDao(Of TranslatedCaption) = DaoFactoryCommonFactory.CreateDao("TranslatedCaption")
        'Private ReadOnly _translatedMessagesDao As IDao(Of TranslatedMessages) = DaoFactoryCommonFactory.CreateDao("TranslatedMessages")

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

            'Dim fldInfo As FieldInfo = Me.GetType().GetField(dao, BindingFlags.NonPublic Or BindingFlags.Instance)
            'If fldInfo Is Nothing Then
            '    MessageBox.Show("Missing Data Access Object " + dao)
            'End If
            'DataDao = fldInfo.GetValue(Me)
        End Sub

        Public Sub New()

        End Sub

    End Class

    'Public Class ServiceBranch
    '    Inherits ServiceCommon

    '    Protected ReadOnly BranchDao As IBranchDao = DaoFactoryCommonFactory.BranchDao

    '    Public Sub New()
    '        DataDao = BranchDao
    '        DataBo = New Branch
    '    End Sub

    'End Class

    'Public Class ServiceCostCenter
    '    Inherits ServiceCommon

    '    Protected ReadOnly CostCenterDao As ICostCenterDao = DaoFactoryCommonFactory.CostCenterDao

    '    Public Sub New()
    '        DataDao = CostCenterDao
    '        DataBo = New CostCenter
    '    End Sub

    'End Class

    'Public Class ServiceCountry
    '    Inherits ServiceCommon

    '    Protected ReadOnly CountryDao As ICountryDao = DaoFactoryCommonFactory.CountryDao

    '    Public Sub New()
    '        DataDao = CountryDao
    '        DataBo = New Country
    '    End Sub

    'End Class

    'Public Class ServiceDepartment
    '    Inherits ServiceCommon

    '    Protected ReadOnly DepartmentDao As IDepartmentDao = DaoFactoryCommonFactory.DepartmentDao

    '    Public Sub New()
    '        DataDao = DepartmentDao
    '        DataBo = New Department
    '    End Sub

    'End Class

    'Public Class ServiceOriginalMessages
    '    Inherits ServiceCommon

    '    Protected ReadOnly OriginalMessagesDao As IOriginalMessagesDao = DaoFactoryCommonFactory.OriginalMessagesDao

    '    Public Sub New()
    '        DataDao = OriginalMessagesDao
    '        DataBo = New OriginalMessages
    '    End Sub

    'End Class

    'Public Class ServicePhoneType
    '    Inherits ServiceCommon

    '    Protected ReadOnly PhoneTypeDao As IPhoneTypeDao = DaoFactoryCommonFactory.PhoneTypeDao

    '    Public Sub New()
    '        DataDao = PhoneTypeDao
    '        DataBo = New PhoneType
    '    End Sub

    'End Class

    'Public Class ServiceProfitCenter
    '    Inherits ServiceCommon

    '    Protected ReadOnly ProfitCenterDao As IProfitCenterDao = DaoFactoryCommonFactory.ProfitCenterDao

    '    Public Sub New()
    '        DataDao = ProfitCenterDao
    '        DataBo = New ProfitCenter
    '    End Sub

    'End Class

    'Public Class ServiceReligion
    '    Inherits ServiceCommon

    '    Protected ReadOnly ReligionDao As IReligionDao = DaoFactoryCommonFactory.ReligionDao

    '    Public Sub New()
    '        DataDao = ReligionDao
    '        DataBo = New Religion
    '    End Sub

    'End Class

    'Public Class ServiceRevenueGroup
    '    Inherits ServiceCommon

    '    Protected ReadOnly RevenueGroupDao As IRevenueGroupDao = DaoFactoryCommonFactory.RevenueGroupDao

    '    Public Sub New()
    '        DataDao = RevenueGroupDao
    '        DataBo = New RevenueGroup
    '    End Sub

    'End Class

    'Public Class ServiceTranslatedMessages
    '    Inherits ServiceCommon

    '    Protected ReadOnly TranslatedMessagesDao As ITranslatedMessagesDao = DaoFactoryCommonFactory.TranslatedMessagesDao

    '    Public Sub New()
    '        DataDao = TranslatedMessagesDao
    '        DataBo = New TranslatedMessages
    '    End Sub

    'End Class
End Namespace