'---------------------------------------------------------------------------------------------------
' file:		Module1.vb
'
' summary:	Module 1 class
'---------------------------------------------------------------------------------------------------

Imports EG.EnviaFactura
Imports System.Threading


Module Module1

	<MTAThread>
	Sub Main()

		Dim CSA As New confComunicacion With {
				.apiUsuario = "cpj-3-002-182080@prod.comprobanteselectronicos.go.cr",
				.apiClave = ".>TR?@4o=aL%5)^(Z7!l",
				.apiURL = "https://api.comprobanteselectronicos.go.cr/recepcion/v1/",
				.apiIDP = "https://idp.comprobanteselectronicos.go.cr/auth/realms/rut/protocol/openid-connect/token",
				.llaveRuta = "C:\Users\asus casa\Desktop\eFactura\cert\CSA_produccion\300218208010_prod.p12",
				.llavePIN = "2015"
		  }
		Dim CSAprueba As New confComunicacion With {
				.apiUsuario = "cpj-3-002-182080@stag.comprobanteselectronicos.go.cr",
				.apiClave = "ucheq:;VA&P2.:+>-L&+",
				.apiURL = "https://api.comprobanteselectronicos.go.cr/recepcion-sandbox/v1/",
				.apiIDP = "https://idp.comprobanteselectronicos.go.cr/auth/realms/rut-stag/protocol/openid-connect/token",
				.llaveRuta = "D:\eFactura\cert\CSA_sandbox\300218208010.p12",
				.llavePIN = "1956"
		  }


		'Dim jl_prod As New confComunicacion With {
		'    .apiUsuario = "cpf-05-0269-0349@prod.comprobanteselectronicos.go.cr",
		'    .apiClave = "Z?{wV_G8_:*^R/7PVB/+",
		'    .apiURL = "https://api.comprobanteselectronicos.go.cr/recepcion/v1/",
		'    .apiIDP = "https://idp.comprobanteselectronicos.go.cr/auth/realms/rut/protocol/openid-connect/token",
		'    .llaveRuta = "D:\eFactura\cert\050269034918.p12",
		'    .llavePIN = "1971"
		'}


		'Dim jl_stag As New confComunicacion With {
		'    .apiUsuario = "cpf-05-0269-0349@stag.comprobanteselectronicos.go.cr",
		'    .apiClave = "s@/!2:_8>5s?xD!&wO>r",
		'     .apiURL = "https://api.comprobanteselectronicos.go.cr/recepcion-sandbox/v1/",
		'    .apiIDP = "https://idp.comprobanteselectronicos.go.cr/auth/realms/rut-stag/protocol/openid-connect/token",
		'    .llaveRuta = "D:\eFactura\cert\050269034918stag.p12",
		'    .llavePIN = "1971"
		'}

		Dim EmisorConf As confComunicacion = CSAprueba

		'' envia factura
		'' Console.WriteLine(envia.Procesa("C:\Users\asus casa\Desktop\xmls\50604121800050269034900100001010000008105126205075.xml"))

		'Dim ruta As String = "D:\eFactura\xml_pdf\"
		'Dim clave As String = "50611121800300218208000100001010000000049135965511"

		''MsgBox(envia.Procesa(ruta & clave & ".xml"))


		''consulta si el servidor envia
		'envia.consultar(clave)    ''ok
		'Console.WriteLine(envia.respuesta)
		'Console.WriteLine(envia.datos)

		'consulta un comprobante por clave
		' 

		Dim iTokenHacienda As New TokenHacienda
		iTokenHacienda.GetTokenHacienda(EmisorConf.apiUsuario, EmisorConf.apiClave)
		Dim TK = iTokenHacienda.accessToken

		Dim compro As New EG.EnviaFactura.Comprobante
		Dim envia = New enviaHacienda(EmisorConf)

		compro = envia.comprobante("50620121800300218208000100001010000003210126479880", TK)  ''ok
		Console.WriteLine(envia.isSuccess)
		Console.WriteLine(envia.response)
		'' devueleve una lista de comprobantes de un proveedor


		'    Dim envia = New enviaHacienda(EmisorConf)

		'    Dim watch As Stopwatch = Stopwatch.StartNew()
		'        '' consulta lista de comprobantes
		'        Dim lComprobantes As List(Of Comprobante) = envia.comprobantesReceptor(1, 10, "01000502690349", "02003002182080") ''ok
		'        Console.WriteLine(lComprobantes.Count)

		'        watch.Stop()
		'        Console.WriteLine("Tiempo consulta:" & watch.Elapsed.TotalSeconds)
		'        watch.Reset()
		'        watch.Start()

		'    ''***********************
		'    If lComprobantes.Count > 0 Then

		'        Dim consultas As Integer = lComprobantes.Count            '' max 64
		'        '' Const clave As String = "50628111800050269034900100001010000000012162217903"

		'        Dim doneEvents(consultas - 1) As ManualResetEvent
		'        Dim hilosArray(consultas - 1) As iEnviaFactura

		'        Console.WriteLine($"Procesando {consultas} consultas...")

		'        For i As Integer = 0 To consultas - 1
		'            doneEvents(i) = New ManualResetEvent(False)
		'            Dim f As iEnviaFactura
		'            f = New iEnviaFactura(EmisorConf, lComprobantes(i).clave, doneEvents(i))
		'            hilosArray(i) = f
		'            ThreadPool.QueueUserWorkItem(AddressOf f.GrupoHilos, i)
		'        Next

		'        WaitHandle.WaitAll(doneEvents)   '' espera que terminen todo los hilos
		'        Console.WriteLine("Todas las consultas se completaron.")

		'        '? Muestra los resultados
		'        For i As Integer = 0 To consultas - 1
		'            Dim f As iEnviaFactura = hilosArray(i)
		'            Console.WriteLine($"{f.archivo} = {f.resultado}")
		'        Next

		'        ''*****************
		'        watch.Stop()
		'        Console.WriteLine("Tiempo :" & watch.Elapsed.TotalSeconds)
		'    End If

		'    Console.WriteLine("Presione una tecla para salir")
		'    Console.ReadKey()
	End Sub

End Module

Public Class iEnviaFactura

	Private _doneEvent As ManualResetEvent

	Public ReadOnly Property archivo As String
	Public ReadOnly Property emisor As confComunicacion
	Public Property resultado As String

	Public Sub New(_emisor As confComunicacion, _archivo As String, doneEvent As ManualResetEvent)
		Me.archivo = _archivo
		Me.emisor = _emisor

		_doneEvent = doneEvent
	End Sub

	Public Sub GrupoHilos(threadContext As Object)
		'Dim threadIndex As Integer = CType(threadContext, Integer)

		'' codigo de ejecución
		'Dim envia = New enviaHacienda(archivo, emisor)
		'resultado = envia.Procesa()
		'' fin de codidgo de ejecución

		'_doneEvent.Set()
	End Sub

End Class

