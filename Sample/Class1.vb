Imports System.Collections.Generic
Imports System

Namespace BaseClassEvents
    ' Special EventArgs class to hold info about Shapes.
    Public Class ShapeEventArgs
        Inherits EventArgs
        Public Sub New(ByVal area As Double)
            NewArea = area
        End Sub

        Public ReadOnly Property NewArea As Double
    End Class

    ' Base class event publisher
    Public MustInherit Class Shape
        Protected _area As Double

        Public Property Area As Double
            Get
                Return _area
            End Get
            Set(ByVal value As Double)
                _area = value
            End Set
        End Property

        ' The event. Note that by using the generic EventHandler<T> event type
        ' we do not need to declare a separate delegate type.
        Public Event ShapeChanged As EventHandler(Of ShapeEventArgs)

        Public MustOverride Sub Draw()

        'The event-invoking method that derived classes can override.
        Protected Overridable Sub OnShapeChanged(ByVal e As ShapeEventArgs)
            ' Safely raise the event for all subscribers
            RaiseEvent ShapeChanged(Me, e)
        End Sub
    End Class

    Public Class Circle
        Inherits Shape
        Private _radius As Double

        Public Sub New(ByVal radius As Double)
            _radius = radius
            _area = 3.14 * _radius * _radius
        End Sub

        Public Sub Update(ByVal d As Double)
            _radius = d
            _area = 3.14 * _radius * _radius
            OnShapeChanged(New ShapeEventArgs(_area))
        End Sub

        Protected Overrides Sub OnShapeChanged(ByVal e As ShapeEventArgs)
            ' Do any circle-specific processing here.

            ' Call the base class event invocation method.
            MyBase.OnShapeChanged(e)
        End Sub

        Public Overrides Sub Draw()
            Console.WriteLine("Drawing a circle")
        End Sub
    End Class

    Public Class Rectangle
        Inherits Shape
        Private _length As Double
        Private _width As Double

        Public Sub New(ByVal length As Double, ByVal width As Double)
            _length = length
            _width = width
            _area = _length * _width
        End Sub

        Public Sub Update(ByVal length As Double, ByVal width As Double)
            _length = length
            _width = width
            _area = _length * _width
            OnShapeChanged(New ShapeEventArgs(_area))
        End Sub

        Protected Overrides Sub OnShapeChanged(ByVal e As ShapeEventArgs)
            ' Do any rectangle-specific processing here.

            ' Call the base class event invocation method.
            MyBase.OnShapeChanged(e)
        End Sub

        Public Overrides Sub Draw()
            Console.WriteLine("Drawing a rectangle")
        End Sub
    End Class

    ' Represents the surface on which the shapes are drawn
    ' Subscribes to shape events so that it knows
    ' when to redraw a shape.
    Public Class ShapeContainer
        Private ReadOnly _list As List(Of Shape)

        Public Sub New()
            _list = New List(Of Shape)()
        End Sub

        Public Sub AddShape(ByVal shape As Shape)
            _list.Add(shape)

            ' Subscribe to the base class event.
            AddHandler shape.ShapeChanged, AddressOf HandleShapeChanged
        End Sub

        ' ...Other methods to draw, resize, etc.

        Private Sub HandleShapeChanged(ByVal sender As Object, ByVal e As ShapeEventArgs)
            Dim shape As Shape = Nothing

            If CSharpImpl.__Assign(shape, TryCast(sender, Shape)) IsNot Nothing Then
                ' Diagnostic message for demonstration purposes.
                Console.WriteLine($"Received event. Shape area is now {e.NewArea}")

                ' Redraw the shape here.
                shape.Draw()
            End If
        End Sub

        Private Class CSharpImpl
            <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class
    End Class

    Friend Class Test
        Private Shared Sub Main()
            'Create the event publishers and subscriber
            Dim circle = New Circle(54)
            Dim rectangle = New Rectangle(12, 9)
            Dim container = New ShapeContainer()

            ' Add the shapes to the container.
            container.AddShape(circle)
            container.AddShape(rectangle)

            ' Cause some events to be raised.
            circle.Update(57)
            rectangle.Update(7, 7)

            ' Keep the console window open in debug mode.
            Console.WriteLine("Press any key to continue...")
            Console.ReadKey()
        End Sub
    End Class
End Namespace
' Output:
' Received event. Shape area is now 10201.86
' Drawing a circle
' Received event. Shape area is now 49
' Drawing a rectangle
' 