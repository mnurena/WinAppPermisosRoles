﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'StronglyTypedResourceBuilder generó automáticamente esta clase
    'a través de una herramienta como ResGen o Visual Studio.
    'Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    'con la opción /str o recompile su proyecto de VS.
    '''<summary>
    '''  Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Public Class Resource
        
        Private Shared resourceMan As Global.System.Resources.ResourceManager
        
        Private Shared resourceCulture As Global.System.Globalization.CultureInfo
        
        <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>  _
        Friend Sub New()
            MyBase.New
        End Sub
        
        '''<summary>
        '''  Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Public Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("WinAppPermisosRoles.Resource", GetType(Resource).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        '''  búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Public Shared Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Error cargando los permisos del ROL.
        '''</summary>
        Public Shared ReadOnly Property RolPermisos_Mensaje_Error() As String
            Get
                Return ResourceManager.GetString("RolPermisos_Mensaje_Error", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a SE GUARDO CORRECTAMENTE.
        '''</summary>
        Public Shared ReadOnly Property RolPermisos_Mensaje_Ok() As String
            Get
                Return ResourceManager.GetString("RolPermisos_Mensaje_Ok", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a CLAVE.
        '''</summary>
        Public Shared ReadOnly Property Security_Key() As String
            Get
                Return ResourceManager.GetString("Security_Key", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Archivo.
        '''</summary>
        Public Shared ReadOnly Property TREENODE_FILE() As String
            Get
                Return ResourceManager.GetString("TREENODE_FILE", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Nuevo.
        '''</summary>
        Public Shared ReadOnly Property TREENODE_NEW() As String
            Get
                Return ResourceManager.GetString("TREENODE_NEW", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Abrir.
        '''</summary>
        Public Shared ReadOnly Property TREENODE_OPEN() As String
            Get
                Return ResourceManager.GetString("TREENODE_OPEN", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Imprimir.
        '''</summary>
        Public Shared ReadOnly Property TREENODE_PRINT() As String
            Get
                Return ResourceManager.GetString("TREENODE_PRINT", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Guardar.
        '''</summary>
        Public Shared ReadOnly Property TREENODE_SAVE() As String
            Get
                Return ResourceManager.GetString("TREENODE_SAVE", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Guardar como.
        '''</summary>
        Public Shared ReadOnly Property TREENODE_SAVEAS() As String
            Get
                Return ResourceManager.GetString("TREENODE_SAVEAS", resourceCulture)
            End Get
        End Property
    End Class
End Namespace