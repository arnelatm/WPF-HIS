Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Forms

    Public Class ItemDetailsEntry
        Implements IItemDetailsView


        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

        End Sub

#Region "Field Items"

        Public Property IdNo As Int32 Implements IItemDetailsView.IdNo
            Get
                If TxtIdNo.Text <> "" Then
                    Return Convert.ToInt32(TxtIdNo.Text)
                Else
                    Return 0
                End If
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property ItemDetailsCode As String Implements IItemDetailsView.ItemDetailsCode
            Get
                Return TxtItemDetailsCode.Text
            End Get
            Set
                TxtItemDetailsCode.Text = If(Value, "")
            End Set
        End Property

        Public Overloads Property ItemNameEnglish As String Implements IItemDetailsView.ItemDetailsName
            Get
                Return TxtItemDetailsName.Text
            End Get
            Set
                TxtItemDetailsName.Text = Value
            End Set
        End Property

        Private _itemGroup = "MD"
        Public Property ItemGroup As String Implements IItemDetailsView.ItemGroup
            Get
                Return "MD"
            End Get
            Set(value As String)
                _itemGroup = value
            End Set
        End Property

        Private _pack1 As Short
        Public Property Pack1 As Short Implements IItemDetailsView.Pack1
            Get
                Return 1
            End Get
            Set(value As Short)
                _pack1 = value
            End Set
        End Property

        Private _pack2 As Short
        Public Property Pack2 As Short Implements IItemDetailsView.Pack2
            Get
                Return 1
            End Get
            Set(value As Short)
                _pack2 = value
            End Set
        End Property

        Private _pack3 As Short
        Public Property Pack3 As Short Implements IItemDetailsView.Pack3
            Get
                Return 1
            End Get
            Set(value As Short)
                _pack3 = value
            End Set
        End Property

        Private _branchID As String
        Public Property BranchID As String Implements IItemDetailsView.BranchID
            Get
                Return "01"
            End Get
            Set(value As String)
                _branchID = value
            End Set
        End Property

        Private _created_By_Branch As String
        Public Property Created_By_Branch As String Implements IItemDetailsView.Created_By_Branch
            Get
                Return "01"
            End Get
            Set(value As String)
                _category = value
            End Set
        End Property

        Private _category As String
        Public Property Category As String Implements IItemDetailsView.Category
            Get
                Return "XX"
            End Get
            Set(value As String)
                _category = value
            End Set
        End Property

        Private _saleStrip As String
        Public Property SaleStrip As String Implements IItemDetailsView.SaleStrip
            Get
                Return "N"
            End Get
            Set(value As String)
                _category = value
            End Set
        End Property

        Private _Item_Status As String
        Public Property Item_Status As String Implements IItemDetailsView.Item_Status
            Get
                Return "S"
            End Get
            Set(value As String)
                _category = value
            End Set
        End Property

        Private _userID As String
        Public Property UserID As String Implements IItemDetailsView.UserId
            Get
                Return GlobalVariables.UserName
            End Get
            Set(value As String)
                _category = value
            End Set
        End Property

#End Region

    End Class

End Namespace