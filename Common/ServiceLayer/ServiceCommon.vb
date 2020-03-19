Imports System.Reflection
Imports AATM.Common.DataLayer
Imports AATM.ServicesLayer.Services

Namespace ServiceLayer

    Public Class ServiceCommon
        Inherits Service
        Implements IServiceCommon

        Protected Shared ReadOnly DaoFactoryCommonFactory As IDaoFactoryCommon = DaoFactoriesCommon.GetCommonFactory(Provider)

        'Protected Shared ReadOnly CommonDao As ICommonDao = DaoFactoryCommonFactory.CreateDao("Common")
        Private ReadOnly _branchDao As IBranchDao = DaoFactoryCommonFactory.CreateDao("Branch")

        Private ReadOnly _costCenterDao As ICostCenterDao = DaoFactoryCommonFactory.CreateDao("CostCenter")
        Private ReadOnly _countryDao As ICountryDao = DaoFactoryCommonFactory.CreateDao("Country")
        Private ReadOnly _departmentDao As IDepartmentDao = DaoFactoryCommonFactory.CreateDao("Department")
        Private ReadOnly _originalMessagesDao As IOriginalMessagesDao = DaoFactoryCommonFactory.CreateDao("OriginalMessages")
        Private ReadOnly _phoneTypeDao As IPhoneTypeDao = DaoFactoryCommonFactory.CreateDao("PhoneType")
        Private ReadOnly _profitCenterDao As IProfitCenterDao = DaoFactoryCommonFactory.CreateDao("ProfitCenter")
        Private ReadOnly _religionDao As IReligionDao = DaoFactoryCommonFactory.CreateDao("Religion")
        Private ReadOnly _revenueGroupDao As IRevenueGroupDao = DaoFactoryCommonFactory.CreateDao("RevenueGroup")
        Private ReadOnly _translatedMessagesDao As ITranslatedMessagesDao = DaoFactoryCommonFactory.CreateDao("TranslatedMessages")

        Public Sub New(accountName As String)
            Dim bizObject = $"AATM.Common.BusinessLayer." + accountName
            Dim dao = "_" + Strings.Left(accountName, 1).ToLower() + Strings.Mid(accountName, 2) + "Dao"
            DataBo = Activator.CreateInstance(Type.GetType(bizObject))
            If DataBo Is Nothing Then
                MessageBox.Show("Missing Business Object " + bizObject)
            End If
            Dim fldInfo As FieldInfo = Me.GetType().GetField(dao, BindingFlags.NonPublic Or BindingFlags.Instance)
            If fldInfo Is Nothing Then
                MessageBox.Show("Missing Data Access Object " + dao)
            End If
            DataDao = fldInfo.GetValue(Me)
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