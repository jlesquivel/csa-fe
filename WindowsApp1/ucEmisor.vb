Public Class ucEmisor

    Enum eServidores
      pruebas
      produccion
   End Enum

   Property tipoServidor As eServidores = eServidores.pruebas

    Private Sub ucEmisor_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Me.DesignMode Then
            ' The component is in design mode

        Else
            ' The component is in run mode
            CargarDatos()
        End If
    End Sub

    Sub CargarDatos()

      'DataTable1TableAdapter.Connection.ConnectionString = "Data Source=servidor-bd;Initial Catalog=Facturacion;User ID=colegiosa;Password=C$@123"
      'TODO: esta línea de código carga datos en la tabla 'EFacturaDataSet.Servidores' Puede moverla o quitarla según sea necesario.
      Me.ServidoresTableAdapter.Fill(Me.EFacturaDataSet.Servidores)
      'TODO: esta línea de código carga datos en la tabla 'EFacturaDataSet.Emisores' Puede moverla o quitarla según sea necesario.
      Me.EmisoresTableAdapter.Fill(Me.EFacturaDataSet.Emisores)
   End Sub

   Private Sub ucEmisor_Leave(sender As Object, e As EventArgs) Handles Me.Leave
        Me.Validate()
        Me.EmisoresBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.EFacturaDataSet)
    End Sub

   Private Sub EmisoresBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles EmisoresBindingNavigatorSaveItem.Click
      Me.Validate()
      Me.EmisoresBindingSource.EndEdit()
      Me.TableAdapterManager.UpdateAll(Me.EFacturaDataSet)

        'TODO: esta línea de código carga datos en la tabla 'EFacturaDataSet.Servidores' Puede moverla o quitarla según sea necesario.
        Me.ServidoresTableAdapter.Fill(Me.EFacturaDataSet.Servidores)
    End Sub
    
End Class