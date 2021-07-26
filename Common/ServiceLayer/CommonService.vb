Imports AATM.Common.DataLayer
Imports AATM.ServicesLayer.Services

Namespace ServiceLayer

    Public Class CommonService
        Inherits Service
        Implements IServiceCommon

        Protected Shared ReadOnly DaoFactoryCommonFactory As IDaoFactoryCommon = DaoFactoriesCommon.GetCommonFactory(Provider)

        Public Sub New(objectName As String, Optional bizParam As Object = Nothing, Optional daoParam As Object = Nothing)
            CreateBusinessObject(objectName, bizParam)
            CreateDao(objectName, daoParam)
        End Sub

        Protected Overrides Sub CreateBusinessObject(objectName As String, Optional bizParam As Object = Nothing)
            Dim bizObject = $"AATM.Common.BusinessLayer." + objectName
            DataBo = Activator.CreateInstance(Type.GetType(bizObject))
            If DataBo Is Nothing Then
                MessageBox.Show("Missing Business Object " + bizObject)
                Debugger.Break()
            End If
        End Sub

        Protected Overrides Sub CreateDao(objectName As String, Optional daoParam As Object = Nothing)
            If daoParam Is Nothing OrElse daoParam.Length = 0 Then
                DataDao = DaoFactoryCommonFactory.CreateDao(objectName)
            Else
                DataDao = DaoFactoryCommonFactory.CreateDao(objectName, daoParam)
            End If
            If DataDao Is Nothing Then
                MessageBox.Show("Missing Data Access Object " + objectName.Trim() + "dao")
                Debugger.Break()
            End If
        End Sub

        Public Sub New()
        End Sub

    End Class

End Namespace