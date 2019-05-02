Imports EG.CajaHerramientas

Module Module2_VerificaBD

	Sub Main()


		buscarDatosMalos()

		Console.ReadLine()
	End Sub

	Sub buscarDatosMalos()
		Dim conn As New ConexionSQL("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=eFactura;Integrated Security=True")
		Dim personas = conn.llenaTabla("SELECT [Id],[tipoID],[numeroID],[correo],[carnet] FROM [eFactura].[dbo].[tabla.personas] ")

		Dim oEmail As New email

		Console.WriteLine("Lista de correos malos   /////")
		Dim i = 0
		For Each persona In personas.Rows

			If Not oEmail.IsValidEmail(persona.item("correo")) Then

				Console.WriteLine($"{i}) carnet: {persona.item("carnet")} correo: '{persona.item("correo")}' ")
				i += 1
			End If
		Next

		Console.WriteLine(vbCrLf & "Lista de identificaciones malas   /////")
		i = 0
		Dim largo = 0
		Dim formato = ""

		For Each persona In personas.Rows
			Select Case persona.item("tipoID")
				Case 1
					largo = 9
					formato = "Ced física :9 números <999999999>"
				Case 2
					largo = 10
					formato = "Ced Jurídic: 10 números <9999999999>"
				Case 3
					largo = 12
					formato = "DIMEX 11 ó 12 números (cédula residencia) <99999999999> or <999999999999> "
				Case 4
					largo = 12
					formato = "NITE 10 números (Registro Hacienda) <9999999999>"
			End Select

			If Not (persona.item("numeroID").ToString.Length = largo And persona.item("numeroID").ToString.All(AddressOf Char.IsDigit)) Then

				Console.WriteLine($"{i}) carnet: {persona.item("carnet")}  ID: {persona.item("numeroID")} ; {formato}")
				i += 1
			End If
		Next

	End Sub


End Module


