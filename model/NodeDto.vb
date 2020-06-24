﻿' modelo que sera utilizado para poder ser asignados al TREEVIEW
' model that will be used to be assigned to TREEVIEW
Public Class BaseNodo

    'NOTA si tienes intensión de agregar más nodos se puede agregar estos 2 campos

    'Public Property NodoPadre As Integer

    'Public Property NodoHijo As Integer

    Public Property Id As String

    Public Property Name As String

    Public Property Value As Boolean

End Class

Public Class NodeRootDto : Inherits BaseNodo

    Public Property Node As List(Of NODOHIJO)

End Class


Public Class NODOHIJO : Inherits BaseNodo

    Public Property SubNodo As List(Of NODOHIJO)

End Class

