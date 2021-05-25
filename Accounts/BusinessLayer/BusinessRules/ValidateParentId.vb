Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer.BusinessRules
    ' length validation rule.
    ' length must be between given min and max values

    Public Class ValidateParentId
        Inherits BusinessRule

        Private ReadOnly _idNo As Int32
        Private ReadOnly _newParentId As Integer
        Private ReadOnly _tableName As String

        Public Sub New(propertyName As String, idNo As Int32, tableName As String)
            MyBase.New(propertyName)
            _idNo = idNo
            _tableName = tableName
            'If PresenterObj.EditMode Then
            '    Dim cOldParentId As String = PresenterObj.GetOriginalValue(tcbParentIdNo)
            '    If cOldParentId <> tcbParentIdNo.Text Then
            '        ParentID Is changed by the user so
            '         check for records which have this record as parent.
            '         check for matching children entries
            '        If CommonDaoOld.CountRecordWithKey(TxtIdNo.Text, MainTableName, "ParentIdNo") > 0 Then
            '            _MBParentWithChildrenChangedDisallowed.Show(Me)
            '            CancelSave = True
            '            Exit Sub
            '        End If
            '    End If
            'End If
            [Error] = "Changing this entry's parent is not allowed because this item has existing children entries!"
        End Sub

        Public Sub New(propertyName As String, errorMessage As String, idNo As Int32, tableName As String)
            Me.New(propertyName, idNo, tableName)
            [Error] = errorMessage
        End Sub

        'Public Overrides Function Validate(businessObject As AATM.BusinessLayer.BusinessObject) As Boolean
        '    Dim nCount = 0
        '    Dim idNo = GetPropertyValue("IdNo", businessObject)
        '    nCount = CommonDaoOld.CountRecordWithKey(idNo, _tableName, "ParentIdNo")
        '    Return nCount = 0
        'End Function

        Public Overrides Function Validate(businessObject As AATM.BusinessLayer.BusinessObject) As Boolean
            Throw New NotImplementedException
        End Function

    End Class

End Namespace