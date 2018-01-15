Public Class FichaAjedrez

    Private _nombre As String
    Private _equipo As String
    Private _tipo As String

    'Constructor de la clase FichaAjedrez

    Public Sub New(ByVal nombre As String, ByVal equipo As String, ByVal tipo As String)
        Me._nombre = nombre
        Me._equipo = equipo
        Me._tipo = tipo
    End Sub

    'Este metodo convierte una ficha en un cuadro vacio.

    Public Sub VaciarCuadro()
        Me._nombre = " (__) "
        Me._equipo = "vacio"
        Me._tipo = "vacio"
    End Sub

    'Este metodo modifica el tablero, posicionando la ficha en el lugar indicado.

    Public Sub PosicionarFicha(ByVal FichaSeleccionada As FichaAjedrez)
        Me._nombre = FichaSeleccionada.nombre
        Me._equipo = FichaSeleccionada.equipo
        Me._tipo = FichaSeleccionada.tipo
    End Sub

    'Metodo property para acceder y modificar la propiedad nombre

    Public Property nombre()
        Get
            Return _nombre
        End Get
        Set(ByVal value)
            _nombre = value
        End Set
    End Property

    'Metodo property para acceder y modificar la propiedad equipo

    Public Property equipo()
        Get
            Return _equipo
        End Get
        Set(ByVal value)
            _equipo = value
        End Set
    End Property

    'Metodo property para acceder y modificar la propiedad tipo

    Public Property tipo()
        Get
            Return _tipo
        End Get
        Set(ByVal value)
            _tipo = value
        End Set
    End Property

End Class
