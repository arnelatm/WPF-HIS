Imports System

Namespace Events

    Public Interface IEventAggregator

        Sub Publish(Of T As Libraries.IApplicationEvent)(ByVal message As T)

        Sub Subscribe(Of T As Libraries.IApplicationEvent)(ByVal action As Action(Of T))

        Sub Unsubscribe(Of T As Libraries.IApplicationEvent)(ByVal action As Action(Of T))

    End Interface

End Namespace