Module ConexionVB
    'La variable conexion es la que permite conectarnos a nuestro SQL
    'data source= donde esta conectada nuestra base de datos

    'Public conn As New SqlClient.SqlConnection("data source= DESKTOP-1SLCMB1\TEW_SQLEXPRESS; initial catalog=SistemaEscuela2; integrated security= SSPI; persist security info= false; trusted_connection = yes;")

    Public conn As New SqlClient.SqlConnection("data source= DESKTOP-5N1KP6P; initial catalog=SistemaEscuela2; integrated security= SSPI; persist security info= false; trusted_connection = yes;")

    'Nos permite ejecutar los comandos que  tienen que ver con los procedimientos
    'almacenados de sql
    Public cmd As SqlClient.SqlCommand
    'permite leer los datos
    Public sqlread As SqlClient.SqlDataReader
    Public Query As String
    Public Rol As String
    Public bandera = 0
    Public Caso As Integer
    Public paso As Integer = 0
End Module
