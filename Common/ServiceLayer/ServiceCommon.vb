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

        Public Sub New(objectName As String, Optional bizParam As Object = Nothing, Optional daoParam As Object = Nothing)
            CreateBusinessObject(objectName, bizParam)
            CreateDao(objectName, daoParam)
        End Sub

        Private Sub CreateBusinessObject(objectName As String, bizParam As Object)
            Dim bizObject = $"AATM.Common.BusinessLayer." + objectName
            DataBo = Activator.CreateInstance(Type.GetType(bizObject))
            If DataBo Is Nothing Then
                MessageBox.Show("Missing Business Object " + bizObject)
                Debugger.Break()
            End If
        End Sub

        Private Sub CreateDao(objectName As String, daoParam As Object)
            If daoParam Is Nothing Or daoParam.Length = 0 Then
                DataDao = DaoFactoryCommonFactory.CreateDao(objectName)
            Else
                DataDao = DaoFactoryCommonFactory.CreateDao(objectName, daoTableOrViewName)
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