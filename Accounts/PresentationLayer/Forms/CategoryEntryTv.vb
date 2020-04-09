Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms

    Public Class CategoryEntryTv
        Implements ICategoryView

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "Category"
            TvMainFieldName = "CategoryName"
            TvSecondaryFieldName = "CategoryCode"
            SortOrderKey = "CategoryName"
            FirstControl = txtCategoryCode

            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New CategoryPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)
            'CreateEnumResourceFile()
            'ResourceEnumConverter.MakeResource("CategoryTypeSelection", GetType(CategoryTypeSelection))
        End Sub

        Public Sub CreateEnumResourceFile()
            'ResourceEnumConverter.MakeResource("YesNoSelection", GetType(YesNoSelection))
            'ResourceEnumConverter.MakeResource("CategoryTypeSelection", GetType(CategoryTypeSelection))
            'ResourceEnumConverter.MakeResource("ImageTypeSelection", GetType(ImageTypeSelection))
        End Sub

        Private _fieldObject As List(Of Object)

        Public Property FieldObject As List(Of Object)
            Get
                Return _fieldObject
            End Get
            Set(value As List(Of Object))
                _fieldObject = value
            End Set
        End Property

        Public Property IDNo As Integer Implements ICategoryView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int32)(TxtIDNo.Text)
            End Get
            Set
                TxtIDNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property CategoryCode As String Implements ICategoryView.CategoryCode
            Get
                Return txtCategoryCode.Text
            End Get
            Set
                txtCategoryCode.Text = Value
            End Set
        End Property

        Public Property CategoryName As String Implements ICategoryView.CategoryName
            Get
                Return txtCategoryName.Text
            End Get
            Set
                txtCategoryName.Text = Value
            End Set
        End Property

        Public Property CategoryNameAra As String Implements ICategoryView.CategoryNameAra
            Get
                Return txtCategoryNameAra.Text
            End Get
            Set
                txtCategoryNameAra.Text = Value
            End Set
        End Property

        Public Property Notes As String Implements ICategoryView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = If(Value, "")
            End Set
        End Property

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
                    {
                    {"CategoryCode", txtCategoryCode},
                    {"CategoryName", txtCategoryName},
                    {"CategoryNameAra", txtCategoryNameAra},
                    {"IDNo", TxtIDNo},
                    {"Notes", txtNotes}
                    }
        End Sub

    End Class

End Namespace