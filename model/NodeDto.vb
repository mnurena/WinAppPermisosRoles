﻿Public Class NodeRootDto

    Public Property Node As List(Of NODOPADRE)

End Class

Public Class NODOPADRE

    Public Property Id As String
    Public Property Name As String
    Public Property Value As Boolean
    Public Property Nodo As List(Of NODOHIJO)

End Class

Public Class NODOHIJO

    Public Property Id As String
    Public Property Name As String
    Public Property Value As Boolean
    Public Property SubNodo As List(Of Actions)

End Class
' ##############################################
' ESTO FUE LO QUE AGREGUE NUEVO
Public Class Actions

    Public Property Id As String
    Public Property Name As String
    Public Property Value As Boolean

End Class

