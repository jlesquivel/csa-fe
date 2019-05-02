<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucEmisor
   Inherits System.Windows.Forms.UserControl

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()>
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucEmisor))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.EFacturaDataSet = New gestionaFacturas.eFacturaDataSet()
        Me.EmisoresBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmisoresTableAdapter = New gestionaFacturas.eFacturaDataSetTableAdapters.EmisoresTableAdapter()
        Me.TableAdapterManager = New gestionaFacturas.eFacturaDataSetTableAdapters.TableAdapterManager()
        Me.ServidoresTableAdapter = New gestionaFacturas.eFacturaDataSetTableAdapters.ServidoresTableAdapter()
        Me.EmisoresBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.EmisoresBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.EmisoresDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ServidoresBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ServidoresDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn29 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn30 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn31 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn32 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn34 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn35 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn36 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn37 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn38 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn39 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.ReflectionLabel2 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        CType(Me.EFacturaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmisoresBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmisoresBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EmisoresBindingNavigator.SuspendLayout()
        CType(Me.EmisoresDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ServidoresBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ServidoresDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'EFacturaDataSet
        '
        Me.EFacturaDataSet.DataSetName = "eFacturaDataSet"
        Me.EFacturaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EmisoresBindingSource
        '
        Me.EmisoresBindingSource.DataMember = "Emisores"
        Me.EmisoresBindingSource.DataSource = Me.EFacturaDataSet
        '
        'EmisoresTableAdapter
        '
        Me.EmisoresTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.EmisoresTableAdapter = Me.EmisoresTableAdapter
        Me.TableAdapterManager.ServidoresTableAdapter = Me.ServidoresTableAdapter
        Me.TableAdapterManager.UpdateOrder = gestionaFacturas.eFacturaDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'ServidoresTableAdapter
        '
        Me.ServidoresTableAdapter.ClearBeforeFill = True
        '
        'EmisoresBindingNavigator
        '
        Me.EmisoresBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.EmisoresBindingNavigator.BindingSource = Me.EmisoresBindingSource
        Me.EmisoresBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.EmisoresBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.EmisoresBindingNavigator.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.EmisoresBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.EmisoresBindingNavigatorSaveItem})
        Me.EmisoresBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.EmisoresBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.EmisoresBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.EmisoresBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.EmisoresBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.EmisoresBindingNavigator.Name = "EmisoresBindingNavigator"
        Me.EmisoresBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.EmisoresBindingNavigator.Size = New System.Drawing.Size(944, 27)
        Me.EmisoresBindingNavigator.TabIndex = 62
        Me.EmisoresBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(24, 24)
        Me.BindingNavigatorAddNewItem.Text = "Agregar nuevo"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(48, 24)
        Me.BindingNavigatorCountItem.Text = "de {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Número total de elementos"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(24, 24)
        Me.BindingNavigatorDeleteItem.Text = "Eliminar"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(24, 24)
        Me.BindingNavigatorMoveFirstItem.Text = "Mover primero"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(24, 24)
        Me.BindingNavigatorMovePreviousItem.Text = "Mover anterior"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 27)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Posición"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 27)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Posición actual"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(24, 24)
        Me.BindingNavigatorMoveNextItem.Text = "Mover siguiente"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(24, 24)
        Me.BindingNavigatorMoveLastItem.Text = "Mover último"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'EmisoresBindingNavigatorSaveItem
        '
        Me.EmisoresBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EmisoresBindingNavigatorSaveItem.Image = CType(resources.GetObject("EmisoresBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.EmisoresBindingNavigatorSaveItem.Name = "EmisoresBindingNavigatorSaveItem"
        Me.EmisoresBindingNavigatorSaveItem.Size = New System.Drawing.Size(24, 24)
        Me.EmisoresBindingNavigatorSaveItem.Text = "Guardar datos"
        '
        'EmisoresDataGridView
        '
        Me.EmisoresDataGridView.AutoGenerateColumns = False
        Me.EmisoresDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.EmisoresDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight
        Me.EmisoresDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.EmisoresDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewCheckBoxColumn2, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15})
        Me.EmisoresDataGridView.DataSource = Me.EmisoresBindingSource
        Me.EmisoresDataGridView.Location = New System.Drawing.Point(13, 87)
        Me.EmisoresDataGridView.Name = "EmisoresDataGridView"
        Me.EmisoresDataGridView.RowHeadersWidth = 21
        Me.EmisoresDataGridView.RowTemplate.Height = 24
        Me.EmisoresDataGridView.Size = New System.Drawing.Size(921, 199)
        Me.EmisoresDataGridView.TabIndex = 62
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "id"
        Me.DataGridViewTextBoxColumn1.HeaderText = "id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 48
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "nombre_Emisor"
        Me.DataGridViewTextBoxColumn2.HeaderText = "nombre_Emisor"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 136
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "activo"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "activo"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Width = 51
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "nombre"
        Me.DataGridViewTextBoxColumn3.HeaderText = "nombre"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 85
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "nombreComercial"
        Me.DataGridViewTextBoxColumn4.HeaderText = "nombreComercial"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 147
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "tipoID"
        Me.DataGridViewTextBoxColumn5.HeaderText = "tipoID"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 73
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "numeroID"
        Me.DataGridViewTextBoxColumn6.HeaderText = "numeroID"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 98
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.DataPropertyName = "extranjero"
        Me.DataGridViewCheckBoxColumn2.HeaderText = "extranjero"
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        Me.DataGridViewCheckBoxColumn2.Width = 77
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "provincia"
        Me.DataGridViewTextBoxColumn7.HeaderText = "provincia"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 94
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "canton"
        Me.DataGridViewTextBoxColumn8.HeaderText = "canton"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 80
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "distrito"
        Me.DataGridViewTextBoxColumn9.HeaderText = "distrito"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 79
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "barrio"
        Me.DataGridViewTextBoxColumn10.HeaderText = "barrio"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Width = 74
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "otraSenas"
        Me.DataGridViewTextBoxColumn11.HeaderText = "otraSenas"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Width = 102
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "codigoArea"
        Me.DataGridViewTextBoxColumn12.HeaderText = "codigoArea"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Width = 109
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "telefono"
        Me.DataGridViewTextBoxColumn13.HeaderText = "telefono"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Width = 88
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "correo"
        Me.DataGridViewTextBoxColumn14.HeaderText = "correo"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.Width = 78
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "diaControl"
        Me.DataGridViewTextBoxColumn15.HeaderText = "diaControl"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.Width = 101
        '
        'ServidoresBindingSource
        '
        Me.ServidoresBindingSource.DataMember = "FK_Servidores_Emisores"
        Me.ServidoresBindingSource.DataSource = Me.EmisoresBindingSource
        '
        'ServidoresDataGridView
        '
        Me.ServidoresDataGridView.AllowUserToAddRows = False
        Me.ServidoresDataGridView.AllowUserToDeleteRows = False
        Me.ServidoresDataGridView.AllowUserToResizeRows = False
        Me.ServidoresDataGridView.AutoGenerateColumns = False
        Me.ServidoresDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.ServidoresDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.ServidoresDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ServidoresDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn20, Me.DataGridViewTextBoxColumn21, Me.DataGridViewTextBoxColumn22, Me.DataGridViewTextBoxColumn23, Me.DataGridViewTextBoxColumn24, Me.DataGridViewTextBoxColumn25, Me.DataGridViewTextBoxColumn26, Me.DataGridViewTextBoxColumn27, Me.DataGridViewTextBoxColumn28, Me.DataGridViewTextBoxColumn29, Me.DataGridViewTextBoxColumn30, Me.DataGridViewTextBoxColumn31, Me.DataGridViewTextBoxColumn32, Me.DataGridViewTextBoxColumn33, Me.DataGridViewTextBoxColumn34, Me.DataGridViewTextBoxColumn35, Me.DataGridViewTextBoxColumn36, Me.DataGridViewTextBoxColumn37, Me.DataGridViewTextBoxColumn38, Me.DataGridViewTextBoxColumn39})
        Me.ServidoresDataGridView.DataSource = Me.ServidoresBindingSource
        Me.ServidoresDataGridView.Location = New System.Drawing.Point(13, 367)
        Me.ServidoresDataGridView.Name = "ServidoresDataGridView"
        Me.ServidoresDataGridView.RowHeadersWidth = 21
        Me.ServidoresDataGridView.RowTemplate.Height = 24
        Me.ServidoresDataGridView.Size = New System.Drawing.Size(921, 138)
        Me.ServidoresDataGridView.TabIndex = 62
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "id"
        Me.DataGridViewTextBoxColumn16.HeaderText = "id"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.Visible = False
        Me.DataGridViewTextBoxColumn16.Width = 48
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "emisor"
        Me.DataGridViewTextBoxColumn17.HeaderText = "emisor"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.Visible = False
        Me.DataGridViewTextBoxColumn17.Width = 79
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "ClientID"
        Me.DataGridViewTextBoxColumn18.HeaderText = "ClientID"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        Me.DataGridViewTextBoxColumn18.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn18.Width = 85
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "API"
        Me.DataGridViewTextBoxColumn19.HeaderText = "API"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.Width = 58
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "IDP"
        Me.DataGridViewTextBoxColumn20.HeaderText = "IDP"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.Width = 59
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "ClientSecret"
        Me.DataGridViewTextBoxColumn21.HeaderText = "ClientSecret"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.Width = 113
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.DataPropertyName = "GrantType"
        Me.DataGridViewTextBoxColumn22.HeaderText = "GrantType"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.Width = 105
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.DataPropertyName = "auth"
        Me.DataGridViewTextBoxColumn23.HeaderText = "auth"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.Width = 65
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.DataPropertyName = "usuario"
        Me.DataGridViewTextBoxColumn24.HeaderText = "usuario"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.Width = 84
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.DataPropertyName = "clave"
        Me.DataGridViewTextBoxColumn25.HeaderText = "clave"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        Me.DataGridViewTextBoxColumn25.Width = 70
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.DataPropertyName = "rutaLlave"
        Me.DataGridViewTextBoxColumn26.HeaderText = "rutaLlave"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        Me.DataGridViewTextBoxColumn26.Width = 96
        '
        'DataGridViewTextBoxColumn27
        '
        Me.DataGridViewTextBoxColumn27.DataPropertyName = "pinllave"
        Me.DataGridViewTextBoxColumn27.HeaderText = "pinllave"
        Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
        Me.DataGridViewTextBoxColumn27.Width = 85
        '
        'DataGridViewTextBoxColumn28
        '
        Me.DataGridViewTextBoxColumn28.DataPropertyName = "connSQL"
        Me.DataGridViewTextBoxColumn28.HeaderText = "connSQL"
        Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
        Me.DataGridViewTextBoxColumn28.Width = 96
        '
        'DataGridViewTextBoxColumn29
        '
        Me.DataGridViewTextBoxColumn29.DataPropertyName = "rutaArch"
        Me.DataGridViewTextBoxColumn29.HeaderText = "rutaArch"
        Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
        Me.DataGridViewTextBoxColumn29.Width = 91
        '
        'DataGridViewTextBoxColumn30
        '
        Me.DataGridViewTextBoxColumn30.DataPropertyName = "ftpHost"
        Me.DataGridViewTextBoxColumn30.HeaderText = "ftpHost"
        Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
        Me.DataGridViewTextBoxColumn30.Width = 82
        '
        'DataGridViewTextBoxColumn31
        '
        Me.DataGridViewTextBoxColumn31.DataPropertyName = "ftpuser"
        Me.DataGridViewTextBoxColumn31.HeaderText = "ftpuser"
        Me.DataGridViewTextBoxColumn31.Name = "DataGridViewTextBoxColumn31"
        Me.DataGridViewTextBoxColumn31.Width = 81
        '
        'DataGridViewTextBoxColumn32
        '
        Me.DataGridViewTextBoxColumn32.DataPropertyName = "ftpPass"
        Me.DataGridViewTextBoxColumn32.HeaderText = "ftpPass"
        Me.DataGridViewTextBoxColumn32.Name = "DataGridViewTextBoxColumn32"
        Me.DataGridViewTextBoxColumn32.Width = 84
        '
        'DataGridViewTextBoxColumn33
        '
        Me.DataGridViewTextBoxColumn33.DataPropertyName = "emailHost"
        Me.DataGridViewTextBoxColumn33.HeaderText = "emailHost"
        Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
        Me.DataGridViewTextBoxColumn33.Width = 99
        '
        'DataGridViewTextBoxColumn34
        '
        Me.DataGridViewTextBoxColumn34.DataPropertyName = "emailPort"
        Me.DataGridViewTextBoxColumn34.HeaderText = "emailPort"
        Me.DataGridViewTextBoxColumn34.Name = "DataGridViewTextBoxColumn34"
        Me.DataGridViewTextBoxColumn34.Width = 96
        '
        'DataGridViewTextBoxColumn35
        '
        Me.DataGridViewTextBoxColumn35.DataPropertyName = "emailSend"
        Me.DataGridViewTextBoxColumn35.HeaderText = "emailSend"
        Me.DataGridViewTextBoxColumn35.Name = "DataGridViewTextBoxColumn35"
        Me.DataGridViewTextBoxColumn35.Width = 103
        '
        'DataGridViewTextBoxColumn36
        '
        Me.DataGridViewTextBoxColumn36.DataPropertyName = "emailSendPass"
        Me.DataGridViewTextBoxColumn36.HeaderText = "emailSendPass"
        Me.DataGridViewTextBoxColumn36.Name = "DataGridViewTextBoxColumn36"
        Me.DataGridViewTextBoxColumn36.Width = 134
        '
        'DataGridViewTextBoxColumn37
        '
        Me.DataGridViewTextBoxColumn37.DataPropertyName = "emailBody"
        Me.DataGridViewTextBoxColumn37.HeaderText = "emailBody"
        Me.DataGridViewTextBoxColumn37.Name = "DataGridViewTextBoxColumn37"
        Me.DataGridViewTextBoxColumn37.Width = 102
        '
        'DataGridViewTextBoxColumn38
        '
        Me.DataGridViewTextBoxColumn38.DataPropertyName = "emailNombre"
        Me.DataGridViewTextBoxColumn38.HeaderText = "emailNombre"
        Me.DataGridViewTextBoxColumn38.Name = "DataGridViewTextBoxColumn38"
        Me.DataGridViewTextBoxColumn38.Width = 120
        '
        'DataGridViewTextBoxColumn39
        '
        Me.DataGridViewTextBoxColumn39.DataPropertyName = "factParalelas"
        Me.DataGridViewTextBoxColumn39.HeaderText = "factParalelas"
        Me.DataGridViewTextBoxColumn39.Name = "DataGridViewTextBoxColumn39"
        Me.DataGridViewTextBoxColumn39.Width = 119
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Location = New System.Drawing.Point(13, 30)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(210, 51)
        Me.ReflectionLabel1.TabIndex = 63
        Me.ReflectionLabel1.Text = "<b><font size=""+6""><i>Emi</i><font color=""#B02B2C"">sores</font></font></b>"
        '
        'ReflectionLabel2
        '
        '
        '
        '
        Me.ReflectionLabel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel2.Location = New System.Drawing.Point(13, 310)
        Me.ReflectionLabel2.Name = "ReflectionLabel2"
        Me.ReflectionLabel2.Size = New System.Drawing.Size(210, 51)
        Me.ReflectionLabel2.TabIndex = 64
        Me.ReflectionLabel2.Text = "<b><font size=""+6""><i>Configuración</i> </font></b>"
        '
        'ucEmisor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ReflectionLabel2)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.ServidoresDataGridView)
        Me.Controls.Add(Me.EmisoresDataGridView)
        Me.Controls.Add(Me.EmisoresBindingNavigator)
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "ucEmisor"
        Me.Size = New System.Drawing.Size(944, 541)
        CType(Me.EFacturaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmisoresBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmisoresBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EmisoresBindingNavigator.ResumeLayout(False)
        Me.EmisoresBindingNavigator.PerformLayout()
        CType(Me.EmisoresDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ServidoresBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ServidoresDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
   Friend WithEvents EFacturaDataSet As eFacturaDataSet
   Friend WithEvents EmisoresBindingSource As BindingSource
   Friend WithEvents EmisoresTableAdapter As eFacturaDataSetTableAdapters.EmisoresTableAdapter
   Friend WithEvents TableAdapterManager As eFacturaDataSetTableAdapters.TableAdapterManager
   Friend WithEvents EmisoresBindingNavigator As BindingNavigator
   Friend WithEvents BindingNavigatorAddNewItem As ToolStripButton
   Friend WithEvents BindingNavigatorCountItem As ToolStripLabel
   Friend WithEvents BindingNavigatorDeleteItem As ToolStripButton
   Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
   Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
   Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
   Friend WithEvents BindingNavigatorPositionItem As ToolStripTextBox
   Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
   Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
   Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
   Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
   Friend WithEvents EmisoresBindingNavigatorSaveItem As ToolStripButton
   Friend WithEvents ServidoresTableAdapter As eFacturaDataSetTableAdapters.ServidoresTableAdapter
   Friend WithEvents EmisoresDataGridView As DataGridView
   Friend WithEvents ServidoresBindingSource As BindingSource
   Friend WithEvents ServidoresDataGridView As DataGridView
   Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
   Friend WithEvents ReflectionLabel2 As DevComponents.DotNetBar.Controls.ReflectionLabel
   Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewCheckBoxColumn1 As DataGridViewCheckBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewCheckBoxColumn2 As DataGridViewCheckBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn21 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn22 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn23 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn25 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn26 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn27 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn28 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn29 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn30 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn31 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn32 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn33 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn34 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn35 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn36 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn37 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn38 As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn39 As DataGridViewTextBoxColumn
End Class
