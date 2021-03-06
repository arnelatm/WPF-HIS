Imports System.ComponentModel
Imports System.Text

Public MustInherit Class BoBase
    Implements IDataErrorInfo
    Implements INotifyPropertyChanged

    Private _ValidationInstance As Validation

    Protected Sub New()
        ValidationInstance = New Validation
    End Sub


    Protected Friend Enum EntityStateType
        Unchanged
        Added
        Deleted
        Modified
    End Enum

    Private _EntityState As EntityStateType
    Protected Property EntityState() As EntityStateType
        Get
            Return _EntityState
        End Get
        Private Set(ByVal value As EntityStateType)
            _EntityState = value
        End Set
    End Property

    <BindableAttribute(False)>
    <BrowsableAttribute(False)>
    Public ReadOnly Property IsDirty() As Boolean
        Get
            Return Me.EntityState <> EntityStateType.Unchanged
        End Get
    End Property

    <BindableAttribute(False)>
    <BrowsableAttribute(False)>
    Public ReadOnly Property IsNew() As Boolean
        Get
            Return Me.EntityState = EntityStateType.Added
        End Get
    End Property

    '<Bindable(False)>
    '<BrowsableAttribute(False)>
    Public ReadOnly Property IsValid() As Boolean
        Get
            Return (ValidationInstance.Count = 0)
        End Get
    End Property

    Protected Property ValidationInstance() As Validation
        Get
            Return _ValidationInstance
        End Get
        Private Set(ByVal value As Validation)
            _ValidationInstance = value
        End Set
    End Property

    'Public ReadOnly Property Count() As Integer
    '    Get
    '        Return ValidationList.Count
    '    End Get
    'End Property


#Region " Properties required by the IDataErrorInfo"


    'The Error property uses the overridden ToString method of the validation class to return the full list of validation errors.
    <Bindable(False)>
    <BrowsableAttribute(False)>
    Public ReadOnly Property [Error]() As String _
           Implements IDataErrorInfo.Error
        Get
            Return ValidationInstance.ToString
        End Get
    End Property

    'The Item property provides access to the validation errors given a property name. 
    'This Property is implemented As the Class indexer In C#.
    <BrowsableAttribute(False)>
    <Bindable(False)>
    Default Protected ReadOnly Property Item(ByVal columnName _
           As String) As String _
           Implements IDataErrorInfo.Item
        Get
            Return ValidationInstance.Item(columnName)
        End Get
    End Property

#End Region

#Region " Events required by INotifyPropertyChanged"
    Public Event PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
#End Region


    'Since every business Object will have unique requirements For the save operation, 
    'the SaveItem method Is Not implemented. Rather it Is defined As abstract.
    Public MustOverride Function SaveItem() As Boolean

    'This Interface only defines a Single Event. This Event should be raised whenever the data Is changed.
    Protected Friend Sub SetEntityState(ByVal dataState As EntityStateType)
        SetEntityState(dataState, Nothing)
    End Sub


    'The SetEntityState method has two Overloads. The first Is used When changing the entity state In general And the second Is used When changing the entity state because a specific Property Is changed.
    'For example, when setting an object as Unchanged, Added, Or Deleted, it does Not matter which property was changed. But when a particular property Is changed, the code must also raise the PropertyChanged event.
    'In this case, the C# And VB code was implemented differently. In the C# code, the code to set the entity state Is in the first overload. The second overload then calls the first And then raises the event.
    'In the VB code, the first overload simply calls the second overload. The second overload then sets the entity state And then raises the event as appropriate. You can use either technique in either language.
    Protected Friend Sub SetEntityState(ByVal newEntityState As EntityStateType, ByVal propertyName As String)
        Select Case newEntityState
            Case EntityStateType.Deleted,
                 EntityStateType.Unchanged,
                 EntityStateType.Added

                Me.EntityState = newEntityState

            Case Else
                If Me.EntityState = EntityStateType.Unchanged Then
                    Me.EntityState = newEntityState
                End If
        End Select

        If Not String.IsNullOrEmpty(propertyName) Then
            Dim e As New PropertyChangedEventArgs(propertyName)
            RaiseEvent PropertyChanged(Me, e)
        End If
    End Sub

End Class


'Some additional suggestions

'ValidateAlphaNumeric
'ValidateDirectory
'ValidateEnum
'ValidateFileExists
'ValidateMinLength
'ValidateNonZero
'ValidateNoSpaces
'ValidateNumeric
'You can create any validation method you need For your application. Just add code To perform the validation And Then Call AddValidationError As appropriate.

'You call these validation methods from your business objects as shown below.

'Private _LastName As String
'Public Property LastName() As String
'    Get
'        Return _LastName
'    End Get
'    Set(ByVal value As String)
'        If _LastName Is Nothing OrElse _LastName <> value Then
'            Dim propertyName As String = "LastName"
'            _LastName = value

'            ' Validate the last name
'            ValidationInstance.ValidateClear(propertyName)
'            ValidationInstance.ValidateRequired(propertyName, value)
'        End If
'    End Set
'End Property


'Public Class Customer
'    Inherits BoBase

'    Private _LastName As String
'    Public Property LastName() As String
'        Get
'            Return _LastName
'        End Get
'        Set(ByVal value As String)
'            If _LastName Is Nothing OrElse _LastName <> value Then
'                Dim propertyName As String = "LastName"
'                _LastName = value

'                ' Validate the last name
'                ValidationInstance.ValidateClear(propertyName)
'                ValidationInstance.ValidateRequired(propertyName, value)

'                SetEntityState(EntityStateType.Modified, propertyName)
'            End If
'        End Set
'    End Property

'    Public Overrides Function SaveItem() As Boolean
'        ' TODO: Add code here
'    End Function
'End Class

'Notice how the Class statement includes the syntax To inherit from BoBase. The LastName Property uses the ValidationInstance defined In the base Class To validate the value. It also sets the entity state When the last name Is changed.
