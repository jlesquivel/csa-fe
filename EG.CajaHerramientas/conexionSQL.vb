Imports System.Data.SqlClient
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization
Imports System.Configuration
Imports System.Collections
Imports System.Threading
Imports System.Text.RegularExpressions
Imports System
Imports System.Data

Public Class ConexionSQL
	Implements IDisposable

#If DEBUG Then
	'Private vServidor As String = "(LocalDB)\v13.0"
	Private vServidor As String = "servidor-bd"
#Else
	 Private vServidor As String = "servidor-bd"
#End If
	Private seguridadIntegrada As Boolean = True
   Public vEspera As String = "5"   '' teimpo de de espera en segundos al servidor
   Private vbd As String = "colegio"
   Public vusuario As String = ""
	Public vpassword As String = ""
	Private vtabla As String = ""
	Private vcampos As String = ""
	Private vorden As String = ""
	Private vstrConn As String = ""
	Private colegioConnection As SqlConnection


	Shared ThreadProcConn As System.Data.SqlClient.SqlConnection
	Shared connectSuccess As Boolean = False

#Region " Propiedades "
	Public Property Servidor() As String
		Get
			Return vServidor
		End Get
		Set(ByVal Value As String)
			vServidor = Value
			Construye_String()
		End Set
	End Property

	Public Property Bd() As String
		Get
			Return vbd
		End Get

		Set(ByVal Value As String)
			vbd = Value
			Construye_String()
			colegioConnection.ConnectionString = vstrConn
		End Set
	End Property

	Public Property strConn() As String
		Get
			Return vstrConn
		End Get
		Set(ByVal Value As String)
			vstrConn = Value
		End Set
	End Property

	Public Property conexion() As SqlConnection
		Get
			Return colegioConnection
		End Get

		Set(ByVal Value As SqlConnection)
			colegioConnection = Value
		End Set
	End Property

#End Region

	'Sub New()
	'    ' carga el archivo de password general
	'    Try

	'        Dim musuario As Match = Regex.Match(My.Settings.conexionSQL, "User id=([A-Za-z0-9_$.]+)", RegexOptions.IgnoreCase)
	'        Dim mpass As Match = Regex.Match(My.Settings.conexionSQL, "Password=([A-Za-z0-9_$.]+)", RegexOptions.IgnoreCase)
	'        vusuario = musuario.Groups(1).Value
	'        vpassword = mpass.Groups(1).Value

	'        vstrConn = My.Settings.conexionSQL

	'        Construye_String()
	'        colegioConnection = New SqlConnection(vstrConn)

	'    Catch ex As Exception
	'        MessageBox.Show(ex.Message)
	'    End Try
	'End Sub

	Sub New(ByVal serv As String, ByVal base As String, ByVal cuenta As String, ByVal pass As String)

		vServidor = serv
		vbd = base
		vusuario = cuenta
		vpassword = pass

		Construye_String()
		colegioConnection = New SqlConnection(vstrConn)
	End Sub

	''' <summary>
	''' Crea una conexion a partir de un string de conexion
	''' </summary>
	''' <param name="stringConexion"></param>
	Sub New(ByVal stringConexion As String)

		Dim builder As SqlConnectionStringBuilder = New SqlConnectionStringBuilder(stringConexion)
		vusuario = builder.UserID
		vpassword = builder.Password
		vServidor = builder.DataSource
		vbd = builder.InitialCatalog

		vstrConn = stringConexion
		colegioConnection = New SqlConnection(vstrConn)
	End Sub


	Public Sub Dispose() Implements IDisposable.Dispose
		colegioConnection.Close()
		colegioConnection.Dispose()

		GC.SuppressFinalize(Me)
	End Sub

#Region "CONEXION OK"
	''' <summary>
	''' Verifica si se puede establecer conexion con el servidor
	''' </summary>
	''' <returns>Valor booleano true indicando que conecto con el servidor</returns>
	''' <remarks></remarks>
	Function conexionOK() As Boolean

		Return QuickOpen(colegioConnection, CInt(vEspera))
	End Function


	Public Shared Sub ThreadProc()
		Try ' Try to open the connection, if anything goes wrong, make sure we set connectSuccess = false
			ThreadProcConn.Open()
			connectSuccess = True
		Catch
			connectSuccess = False
		End Try
	End Sub
	Public Shared Function QuickOpen(ByVal conn As Data.SqlClient.SqlConnection, ByVal timeout As Integer) As Boolean
		ThreadProcConn = conn
		Dim t As New Thread(AddressOf ThreadProc)
		Dim StartTime As Date = Date.Now
		' Make sure it’s marked as a background thread so it’ll get cleaned up automatically
		t.IsBackground = True
		t.Start()
		' Keep trying to join the thread until we either succeed or the timeout value has been exceeded
		While StartTime.AddSeconds(timeout) > Date.Now
			If t.Join(1) Then
				Exit While
			End If
		End While
		' If we didn’t connect successfully, throw an exception
		'If Not connectSuccess Then
		'    Throw New Exception("Server Unavailable")
		'End If

		Return connectSuccess

	End Function


#End Region
	''' <summary>
	''' Llena un dataset con la instruccion que recibe como parámetro
	''' </summary>
	''' <param name="ds"> devuelve el resultado</param>
	''' <param name="tabla">nombre tabla string</param>
	''' <param name="instruccion">instruccion sql </param>
	''' <remarks></remarks>
	Sub llena(ByRef ds As DataSet, ByVal tabla As String, ByVal instruccion As String)
		Try
			If colegioConnection.State = ConnectionState.Closed Then
				colegioConnection.Open()
			End If
			Dim da As New SqlDataAdapter(instruccion, conexion)
			If ds.Tables.Item(tabla) Is Nothing Then
				ds.Tables.Add(tabla)
			End If

			ds.Tables(tabla).Clear()
			da.Fill(ds, tabla)
		Catch ex As Exception
			'MessageBox.Show(ex.Message)
		End Try

	End Sub
	''' <summary>
	''' LLena ds con la instruccion en el  sqlcommand
	''' </summary>
	''' <param name="ds">dataset donde se entregara el resultado</param>
	''' <param name="tabla">tabla tipo string</param>
	''' <param name="instruccion">tipo SQLCommand</param>
	''' <remarks></remarks>
	Sub llena(ByRef ds As DataSet, ByVal tabla As String, ByVal instruccion As SqlCommand)
		Try
			If colegioConnection.State = ConnectionState.Closed Then
				colegioConnection.Open()
			End If
			Dim da As New SqlDataAdapter(instruccion)
			da.SelectCommand.Connection = conexion
			If ds.Tables.Item(tabla) Is Nothing Then
				ds.Tables.Add(tabla)
			End If

			ds.Tables(tabla).Clear()
			da.Fill(ds, tabla)
		Catch ex As Exception
			'MessageBox.Show(ex.Message)
		End Try
	End Sub

	Function llenaTabla(ByVal instruccion As String) As DataTable
		Try
			Dim res As Integer
			If colegioConnection.State = ConnectionState.Closed Then
				colegioConnection.Open()
			End If
			Dim cmd As New SqlCommand(instruccion)
			Dim da As New SqlDataAdapter(cmd)
			Dim dt As New DataTable

			da.SelectCommand.Connection = conexion
			res = da.Fill(dt)
			llenaTabla = dt

		Catch ex As Exception
			'MessageBox.Show("llena datatable " & ex.Message)
			llenaTabla = Nothing
		End Try
	End Function

	Function llena(ByVal instruccion As String) As ArrayList
		Dim arreglo As New ArrayList
		Dim pos As Integer = 0
		Try

			Dim ds As New DataSet
			Dim registros As Integer
			If colegioConnection.State = ConnectionState.Closed Then
				colegioConnection.Open()
			End If
			Dim da As New SqlDataAdapter(instruccion, conexion)

			registros = da.Fill(ds, 0)
			' convierte ds a un arreglo a partir de aqui

			For Each fila As DataRow In ds.Tables(0).Rows
				arreglo.Add(fila.ItemArray)
				pos = pos + 1
			Next

		Catch ex As Exception
			'MessageBox.Show(ex.Message)
		End Try
		Return arreglo
	End Function
	''' <summary>
	''' Ejecuta la instruccion pasada por parametro
	''' </summary>
	''' <param name="comando"></param>
	''' <remarks></remarks>
	Public Sub ejecuta(ByVal comando As String)
		Try
			Dim myCommand As New SqlCommand(comando) With {
					 .Connection = colegioConnection
				}
			If colegioConnection.State = ConnectionState.Closed Then
				colegioConnection.Open()
			End If
			myCommand.ExecuteNonQuery()
			myCommand.Connection.Close()
		Catch ex As Exception
			'MessageBox.Show(ex.Message)
		End Try
	End Sub

	Public Sub ejecuta_sinerror(ByVal comando As String)

		If colegioConnection.State = ConnectionState.Closed Then
			colegioConnection.Open()
		End If

		Dim myCommand As New SqlCommand(comando) With {
				.Connection = colegioConnection
		  }

		If myCommand.Connection.State = ConnectionState.Open Then
			myCommand.ExecuteNonQuery()
			myCommand.Connection.Close()
		End If
	End Sub

	Public Function GeneraArchivo(ByVal FilePath As String, ByVal ds As DataTable) As String
		'Variables para abrir el archivo en modo de escritura  
		Dim strStreamW As Stream = File.OpenWrite(FilePath)

		Dim strStreamWriter As StreamWriter = New StreamWriter(strStreamW,
							System.Text.Encoding.ASCII)

		Try
			Dim dr As DataRow
			Dim valor As Object
			Dim linea As String = ""

			For Each dr In ds.Rows         'Obtenemos los datos del dataset   
				For Each valor In dr.ItemArray
					linea = linea & CStr(valor)
				Next
				'Escribimos la línea en el achivo de texto 
				linea = linea.Replace("Ñ", "N")
				linea = linea.Replace("Á", "A")
				linea = linea.Replace("É", "E")
				linea = linea.Replace("Í", "I")
				linea = linea.Replace("Ó", "O")
				linea = linea.Replace("Ú", "U")
				linea = linea.Replace("Ü", "U")

				strStreamWriter.WriteLine(linea)
				linea = ""
			Next
			strStreamWriter.Close()
			Return ("El archivo se generó con éxito")
		Catch ex As Exception
			strStreamWriter.Close()
			'MessageBox.Show(ex.Message)
			Return ("El archivo se generó con ERROR")
		End Try
	End Function

	Private Sub Construye_String()
		Dim dominio As NetworkInformation = NetworkInformation.LocalComputer
		If dominio.Status = NetworkInformation.JoinStatus.Domain Then
			vstrConn = "data source=" & vServidor &
							";initial catalog=" & vbd &
							";integrated security=SSPI" &
							";persist security info=TRUE" &
							";packet size=8000"
		Else
			If vServidor = "(localdb)\v13.0" Then
				vstrConn = "Data Source=(localdb)\v13.0;" &
						  "AttachDbFilename=C:\SQLServer\colegio_Data.MDF;Integrated Security=True"
			Else
				vstrConn = "data source=" & vServidor &
									 ";initial catalog=" & vbd & ";persist security info=TRUE" &
									 " ;user id=" & vusuario & ";password=" & vpassword &
									 ";packet size=8000"
			End If
		End If

		vstrConn = vstrConn & " ;Connection Timeout=" & vEspera
	End Sub
	Public Function verifica_seguridad(ByVal pBasedato As String, ByVal ptabla As String) As Boolean
		Dim retorno As Boolean
		Try
			ejecuta_sinerror("Select TOP 1 * from " & ptabla)
			retorno = True

		Catch ex As Exception
			retorno = False
		End Try

		Return retorno
	End Function

	Protected Overrides Sub Finalize()
		MyBase.Finalize()
	End Sub





	'Private Function Busca_servidor() As String

	'    Dim resp As String = ""
	'    Try
	'        Dim i As Integer
	'        Dim oNames As SQLDMO.NameList
	'        Dim oSQLApp As SQLDMO.Application

	'        Dim val As String
	'        oSQLApp = New SQLDMO.ApplicationClass
	'        oNames = oSQLApp.Application.ListAvailableSQLServers

	'        For i = 1 To oNames.Count
	'            val = oNames.Item(i)
	'            If Left(val, 8) = "SERVIDOR" Then
	'                resp = val
	'            End If
	'        Next


	'    Catch ex As Exception
	'        MessageBox.Show(ex.Message)
	'    End Try

	'    Return resp
	'End Function
End Class
