Imports Newtonsoft.Json

Public Class producto
    Private cCantidad As Integer
    Private cProducto As Integer

    <JsonProperty>
    Public Property producto As Integer
        Get
            Return cProducto
        End Get
        Set
            cProducto = Value
        End Set
    End Property

    <JsonProperty>
    Public Property cantidad As Integer
        Get
            Return cCantidad
        End Get
        Set
            cCantidad = Value
        End Set
    End Property
End Class
