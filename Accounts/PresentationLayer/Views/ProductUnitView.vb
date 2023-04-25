Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class ProductUnitView
        Implements IProductUnitView

        Public Property IdNo As Int32 Implements IProductUnitView.IdNo
        Public Property DataFilter As String Implements IView.DataFilter
        Public Property UnitIdNo As Int16 Implements IProductUnitView.UnitIdNo
        Public Property ProductIdNo As Int32 Implements IProductUnitView.ProductIdNo


        Private _unitQty As Int16 = 0
        Public Property UnitQty As Short Implements IProductUnitView.UnitQty
            Get
                Return _unitQty
            End Get
            Set(value As Short)
                If value = 0 Then
                    _unitQty = 1
                Else
                    _unitQty = value
                End If
            End Set
        End Property

        Private _baseQty As Int16 = 0

        Public Property BaseQty As Short Implements IProductUnitView.BaseQty
            Get
                Return _baseQty
            End Get
            Set(value As Short)
                If value = 0 Then
                    _baseQty = 1
                Else
                    _baseQty = value
                End If
            End Set
        End Property

        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property Sequence As Int16 Implements IProductUnitView.Sequence

    End Class

End Namespace