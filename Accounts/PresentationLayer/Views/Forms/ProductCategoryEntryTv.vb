Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class ProductCategoryEntryTv
        Implements IProductCategoryView

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "ProductCategory"
            TvMainFieldName = "ProductCategoryName"
            TvSecondaryFieldName = "ProductCategoryCode"
            SortOrderKey = "ProductCategoryName"
            FirstControl = txtProductCategoryCode

            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New ProductCategoryPresenter(Me)
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
        Public Property IdNo As Int16 Implements IProductCategoryView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property ProductCategoryCode As String Implements IProductCategoryView.ProductCategoryCode
            Get
                Return txtProductCategoryCode.Text
            End Get
            Set
                txtProductCategoryCode.Text = Value
            End Set
        End Property

        Public Property ProductCategoryName As String Implements IProductCategoryView.ProductCategoryName
            Get
                Return txtProductCategoryName.Text
            End Get
            Set
                txtProductCategoryName.Text = Value
            End Set
        End Property

        Public Property ProductCategoryNameAra As String Implements IProductCategoryView.ProductCategoryNameAra
            Get
                Return txtProductCategoryNameAra.Text
            End Get
            Set
                txtProductCategoryNameAra.Text = Value
            End Set
        End Property

        Public Property Notes As String Implements IProductCategoryView.Notes
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
                    {"ProductCategoryCode", txtProductCategoryCode},
                    {"ProductCategoryName", txtProductCategoryName},
                    {"ProductCategoryNameAra", txtProductCategoryNameAra},
                    {"IdNo", TxtIdNo},
                    {"Notes", txtNotes}
                    }
        End Sub

    End Class

End Namespace