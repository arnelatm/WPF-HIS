Imports System.Configuration
Imports AATM.DataLayer

Namespace Services

    Public Class TblColPropService
        Implements ITblColPropService

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Private Shared Shadows ReadOnly TblColPropDao As ITblColPropDao = Factory.TblColPropDao

        Public Property DataDao As ITblColPropDao

        Public Sub New()
            DataDao = TblColPropDao
        End Sub

        Public Function GetMainTableColumnProperties(tableName As String) _
            Implements ITblColPropService.GetMainTableColumnProperties
            Return DataDao.GetMainTableColumnProperties(tableName)
        End Function

        'Public Function GetControlTblColPropIdNo(searchValue As String) As String _
        '    Implements ITblColPropService.GetControlTblColPropIdNo
        '    Return DataDao.GetControlTblColPropIdNo(searchValue)
        'End Function

        'Public Function GetUserTblColProp(tblColPropObjectIdNo As Int32, tblColPropGroupIdNo As Int32) As ArrayList _
        '    Implements ITblColPropService.GetUserTblColProp
        '    Return DataDao.GetUserTblColProp(tblColPropObjectIdNo, tblColPropGroupIdNo)
        'End Function
    End Class

End Namespace