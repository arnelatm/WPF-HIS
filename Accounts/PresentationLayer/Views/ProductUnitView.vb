Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class ProductUnitView
        Implements IProductUnitView

        Public Property IdNo As Int32 Implements IProductUnitView.IdNo
        Public Property DataFilter As String Implements IView.DataFilter
        Public Property UnitIdNo As Int16 Implements IProductUnitView.UnitIdNo
        Public Property ProductIdNo As Int32 Implements IProductUnitView.ProductIdNo


        Private _multiplier As Int16 = 0
        Public Property Multiplier As Short Implements IProductUnitView.Multiplier
            Get
                Return _multiplier
            End Get
            Set(value As Short)
                _multiplier = value
            End Set
        End Property

        Private _baseQty As Int16 = 0

        Public Property BaseQty As Short Implements IProductUnitView.BaseQty
            Get
                Return _baseQty
            End Get
            Set(value As Short)
                If _baseQty = 0 Then
                    _baseQty = 1
                End If
            End Set
        End Property

        Public Property Errors As List(Of String) Implements IView.Errors


    End Class

End Namespace