<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
   Inherits System.Windows.Forms.Form

   'Form reemplaza a Dispose para limpiar la lista de componentes.
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

   'Requerido por el Diseñador de Windows Forms
   Private components As System.ComponentModel.IContainer

   'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
   'Se puede modificar usando el Diseñador de Windows Forms.  
   'No lo modifique con el editor de código.
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
      Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
      Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
      Me.ComboBoxEx1 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
      Me.EmisoresBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.EFacturaDataSet = New gestionaFacturas.eFacturaDataSet()
      Me.SwitchButton2 = New DevComponents.DotNetBar.Controls.SwitchButton()
      Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
      Me.lbDisponible = New DevComponents.DotNetBar.LabelX()
      Me.lbReinicio = New DevComponents.DotNetBar.LabelX()
      Me.lbTotal = New DevComponents.DotNetBar.LabelX()
      Me.MicroChart1 = New DevComponents.DotNetBar.MicroChart()
      Me.cbCertificado = New DevComponents.DotNetBar.Controls.CheckBoxX()
      Me.cbAPI = New DevComponents.DotNetBar.Controls.CheckBoxX()
      Me.cbEmail = New DevComponents.DotNetBar.Controls.CheckBoxX()
      Me.cbWEB = New DevComponents.DotNetBar.Controls.CheckBoxX()
      Me.cbBD = New DevComponents.DotNetBar.Controls.CheckBoxX()
      Me.cbInternet = New DevComponents.DotNetBar.Controls.CheckBoxX()
      Me.CircularProgress1 = New DevComponents.DotNetBar.Controls.CircularProgress()
      Me.TextBoxResult = New DevComponents.DotNetBar.Controls.TextBoxX()
      Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
      Me.SwitchButton1 = New DevComponents.DotNetBar.Controls.SwitchButton()
      Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
      Me.SuperTabControlPanel5 = New DevComponents.DotNetBar.SuperTabControlPanel()
      Me.UcEmisor1 = New gestionaFacturas.ucEmisor()
      Me.SuperTabItem5 = New DevComponents.DotNetBar.SuperTabItem()
      Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
      Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
      Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
      Me.EmisoresTableAdapter = New gestionaFacturas.eFacturaDataSetTableAdapters.EmisoresTableAdapter()
      Me.TableAdapterManager = New gestionaFacturas.eFacturaDataSetTableAdapters.TableAdapterManager()
      CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuperTabControl1.SuspendLayout()
      Me.SuperTabControlPanel1.SuspendLayout()
      CType(Me.EmisoresBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.EFacturaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuperTabControlPanel5.SuspendLayout()
      Me.ContextMenuStrip1.SuspendLayout()
      Me.SuspendLayout()
      '
      'SuperTabControl1
      '
      Me.SuperTabControl1.BackColor = System.Drawing.Color.White
      '
      '
      '
      '
      '
      '
      Me.SuperTabControl1.ControlBox.CloseBox.Name = ""
      '
      '
      '
      Me.SuperTabControl1.ControlBox.MenuBox.Name = ""
      Me.SuperTabControl1.ControlBox.Name = ""
      Me.SuperTabControl1.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControl1.ControlBox.MenuBox, Me.SuperTabControl1.ControlBox.CloseBox})
      Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel1)
      Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel5)
      Me.SuperTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SuperTabControl1.ForeColor = System.Drawing.Color.Black
      Me.SuperTabControl1.Location = New System.Drawing.Point(0, 0)
      Me.SuperTabControl1.Name = "SuperTabControl1"
      Me.SuperTabControl1.ReorderTabsEnabled = True
      Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
      Me.SuperTabControl1.SelectedTabIndex = 0
      Me.SuperTabControl1.Size = New System.Drawing.Size(867, 528)
      Me.SuperTabControl1.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Left
      Me.SuperTabControl1.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.SuperTabControl1.TabIndex = 0
      Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem1, Me.SuperTabItem5})
      Me.SuperTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
      Me.SuperTabControl1.Text = "SuperTabControl1"
      '
      'SuperTabControlPanel1
      '
      Me.SuperTabControlPanel1.AutoScroll = True
      Me.SuperTabControlPanel1.Controls.Add(Me.ComboBoxEx1)
      Me.SuperTabControlPanel1.Controls.Add(Me.SwitchButton2)
      Me.SuperTabControlPanel1.Controls.Add(Me.LabelX15)
      Me.SuperTabControlPanel1.Controls.Add(Me.lbDisponible)
      Me.SuperTabControlPanel1.Controls.Add(Me.lbReinicio)
      Me.SuperTabControlPanel1.Controls.Add(Me.lbTotal)
      Me.SuperTabControlPanel1.Controls.Add(Me.MicroChart1)
      Me.SuperTabControlPanel1.Controls.Add(Me.cbCertificado)
      Me.SuperTabControlPanel1.Controls.Add(Me.cbAPI)
      Me.SuperTabControlPanel1.Controls.Add(Me.cbEmail)
      Me.SuperTabControlPanel1.Controls.Add(Me.cbWEB)
      Me.SuperTabControlPanel1.Controls.Add(Me.cbBD)
      Me.SuperTabControlPanel1.Controls.Add(Me.cbInternet)
      Me.SuperTabControlPanel1.Controls.Add(Me.CircularProgress1)
      Me.SuperTabControlPanel1.Controls.Add(Me.TextBoxResult)
      Me.SuperTabControlPanel1.Controls.Add(Me.LabelX13)
      Me.SuperTabControlPanel1.Controls.Add(Me.SwitchButton1)
      Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SuperTabControlPanel1.Location = New System.Drawing.Point(113, 0)
      Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
      Me.SuperTabControlPanel1.Size = New System.Drawing.Size(754, 528)
      Me.SuperTabControlPanel1.TabIndex = 1
      Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
      '
      'ComboBoxEx1
      '
      Me.ComboBoxEx1.DataSource = Me.EmisoresBindingSource
      Me.ComboBoxEx1.DisplayMember = "nombre"
      Me.ComboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
      Me.ComboBoxEx1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ComboBoxEx1.ForeColor = System.Drawing.Color.Black
      Me.ComboBoxEx1.FormattingEnabled = True
      Me.ComboBoxEx1.ItemHeight = 19
      Me.ComboBoxEx1.Location = New System.Drawing.Point(10, 79)
      Me.ComboBoxEx1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
      Me.ComboBoxEx1.Name = "ComboBoxEx1"
      Me.ComboBoxEx1.Size = New System.Drawing.Size(265, 25)
      Me.ComboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
      Me.ComboBoxEx1.TabIndex = 19
      Me.ComboBoxEx1.ValueMember = "numeroID"
      '
      'EmisoresBindingSource
      '
      Me.EmisoresBindingSource.DataMember = "Emisores"
      Me.EmisoresBindingSource.DataSource = Me.EFacturaDataSet
      '
      'EFacturaDataSet
      '
      Me.EFacturaDataSet.DataSetName = "eFacturaDataSet"
      Me.EFacturaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'SwitchButton2
      '
      '
      '
      '
      Me.SwitchButton2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
      Me.SwitchButton2.Enabled = False
      Me.SwitchButton2.Location = New System.Drawing.Point(279, 79)
      Me.SwitchButton2.Name = "SwitchButton2"
      Me.SwitchButton2.OffBackColor = System.Drawing.Color.DarkOrange
      Me.SwitchButton2.OffText = "PRUEBA"
      Me.SwitchButton2.OnBackColor = System.Drawing.Color.ForestGreen
      Me.SwitchButton2.OnText = "PRODUC.."
      Me.SwitchButton2.ReadOnlyMarkerColor = System.Drawing.SystemColors.ButtonHighlight
      Me.SwitchButton2.Size = New System.Drawing.Size(81, 25)
      Me.SwitchButton2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
      Me.SwitchButton2.SwitchWidth = 24
      Me.SwitchButton2.TabIndex = 18
      Me.SwitchButton2.Value = True
      Me.SwitchButton2.ValueObject = "Y"
      '
      'LabelX15
      '
      Me.LabelX15.BackColor = System.Drawing.Color.WhiteSmoke
      '
      '
      '
      Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
      Me.LabelX15.Location = New System.Drawing.Point(635, 89)
      Me.LabelX15.Name = "LabelX15"
      Me.LabelX15.Size = New System.Drawing.Size(8, 15)
      Me.LabelX15.TabIndex = 17
      Me.LabelX15.Text = "/"
      '
      'lbDisponible
      '
      Me.lbDisponible.BackColor = System.Drawing.Color.WhiteSmoke
      '
      '
      '
      Me.lbDisponible.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
      Me.lbDisponible.Location = New System.Drawing.Point(583, 89)
      Me.lbDisponible.Margin = New System.Windows.Forms.Padding(2)
      Me.lbDisponible.Name = "lbDisponible"
      Me.lbDisponible.RightToLeft = System.Windows.Forms.RightToLeft.Yes
      Me.lbDisponible.Size = New System.Drawing.Size(47, 15)
      Me.lbDisponible.TabIndex = 16
      '
      'lbReinicio
      '
      Me.lbReinicio.BackColor = System.Drawing.Color.WhiteSmoke
      '
      '
      '
      Me.lbReinicio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
      Me.lbReinicio.Location = New System.Drawing.Point(545, 70)
      Me.lbReinicio.Margin = New System.Windows.Forms.Padding(2)
      Me.lbReinicio.Name = "lbReinicio"
      Me.lbReinicio.RightToLeft = System.Windows.Forms.RightToLeft.Yes
      Me.lbReinicio.Size = New System.Drawing.Size(146, 19)
      Me.lbReinicio.TabIndex = 15
      '
      'lbTotal
      '
      Me.lbTotal.BackColor = System.Drawing.Color.WhiteSmoke
      '
      '
      '
      Me.lbTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
      Me.lbTotal.Location = New System.Drawing.Point(644, 89)
      Me.lbTotal.Margin = New System.Windows.Forms.Padding(2)
      Me.lbTotal.Name = "lbTotal"
      Me.lbTotal.Size = New System.Drawing.Size(47, 15)
      Me.lbTotal.TabIndex = 14
      '
      'MicroChart1
      '
      '
      '
      '
      Me.MicroChart1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
      Me.MicroChart1.ChartType = DevComponents.DotNetBar.eMicroChartType.HundredPercentBar
      Me.MicroChart1.Location = New System.Drawing.Point(401, 2)
      Me.MicroChart1.Name = "MicroChart1"
      Me.MicroChart1.Size = New System.Drawing.Size(212, 66)
      Me.MicroChart1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
      Me.MicroChart1.TabIndex = 12
      Me.MicroChart1.Text = "MicroChart1"
      '
      'cbCertificado
      '
      Me.cbCertificado.AutoCheck = False
      Me.cbCertificado.BackColor = System.Drawing.Color.Transparent
      '
      '
      '
      Me.cbCertificado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
      Me.cbCertificado.CheckSignSize = New System.Drawing.Size(14, 14)
      Me.cbCertificado.Location = New System.Drawing.Point(265, 50)
      Me.cbCertificado.Margin = New System.Windows.Forms.Padding(2)
      Me.cbCertificado.Name = "cbCertificado"
      Me.cbCertificado.Size = New System.Drawing.Size(95, 18)
      Me.cbCertificado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
      Me.cbCertificado.TabIndex = 11
      Me.cbCertificado.Text = "Certificado"
      '
      'cbAPI
      '
      Me.cbAPI.AutoCheck = False
      Me.cbAPI.BackColor = System.Drawing.Color.Transparent
      '
      '
      '
      Me.cbAPI.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
      Me.cbAPI.CheckSignSize = New System.Drawing.Size(14, 14)
      Me.cbAPI.Location = New System.Drawing.Point(265, 33)
      Me.cbAPI.Margin = New System.Windows.Forms.Padding(2)
      Me.cbAPI.Name = "cbAPI"
      Me.cbAPI.Size = New System.Drawing.Size(95, 18)
      Me.cbAPI.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
      Me.cbAPI.TabIndex = 10
      Me.cbAPI.Text = "API Hacienda"
      '
      'cbEmail
      '
      Me.cbEmail.AutoCheck = False
      Me.cbEmail.BackColor = System.Drawing.Color.Transparent
      '
      '
      '
      Me.cbEmail.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
      Me.cbEmail.CheckSignSize = New System.Drawing.Size(14, 14)
      Me.cbEmail.Location = New System.Drawing.Point(265, 14)
      Me.cbEmail.Margin = New System.Windows.Forms.Padding(2)
      Me.cbEmail.Name = "cbEmail"
      Me.cbEmail.Size = New System.Drawing.Size(95, 18)
      Me.cbEmail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
      Me.cbEmail.TabIndex = 9
      Me.cbEmail.Text = "Correo"
      '
      'cbWEB
      '
      Me.cbWEB.AutoCheck = False
      Me.cbWEB.BackColor = System.Drawing.Color.Transparent
      '
      '
      '
      Me.cbWEB.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
      Me.cbWEB.CheckSignSize = New System.Drawing.Size(14, 14)
      Me.cbWEB.Location = New System.Drawing.Point(152, 50)
      Me.cbWEB.Margin = New System.Windows.Forms.Padding(2)
      Me.cbWEB.Name = "cbWEB"
      Me.cbWEB.Size = New System.Drawing.Size(95, 18)
      Me.cbWEB.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
      Me.cbWEB.TabIndex = 8
      Me.cbWEB.Text = "Servidor WEB"
      '
      'cbBD
      '
      Me.cbBD.AutoCheck = False
      Me.cbBD.BackColor = System.Drawing.Color.Transparent
      '
      '
      '
      Me.cbBD.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
      Me.cbBD.CheckSignSize = New System.Drawing.Size(14, 14)
      Me.cbBD.Location = New System.Drawing.Point(152, 33)
      Me.cbBD.Margin = New System.Windows.Forms.Padding(2)
      Me.cbBD.Name = "cbBD"
      Me.cbBD.Size = New System.Drawing.Size(95, 18)
      Me.cbBD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
      Me.cbBD.TabIndex = 7
      Me.cbBD.Text = "Base de Datos"
      '
      'cbInternet
      '
      Me.cbInternet.AutoCheck = False
      Me.cbInternet.BackColor = System.Drawing.Color.Transparent
      '
      '
      '
      Me.cbInternet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
      Me.cbInternet.CheckSignSize = New System.Drawing.Size(14, 14)
      Me.cbInternet.Location = New System.Drawing.Point(152, 14)
      Me.cbInternet.Margin = New System.Windows.Forms.Padding(2)
      Me.cbInternet.Name = "cbInternet"
      Me.cbInternet.Size = New System.Drawing.Size(95, 18)
      Me.cbInternet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
      Me.cbInternet.TabIndex = 6
      Me.cbInternet.Text = "Internet"
      '
      'CircularProgress1
      '
      Me.CircularProgress1.BackColor = System.Drawing.Color.Transparent
      '
      '
      '
      Me.CircularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
      Me.CircularProgress1.Location = New System.Drawing.Point(639, 16)
      Me.CircularProgress1.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
      Me.CircularProgress1.Name = "CircularProgress1"
      Me.CircularProgress1.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
      Me.CircularProgress1.ProgressColor = System.Drawing.Color.Green
      Me.CircularProgress1.Size = New System.Drawing.Size(53, 52)
      Me.CircularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
      Me.CircularProgress1.TabIndex = 5
      '
      'TextBoxResult
      '
      Me.TextBoxResult.BackColor = System.Drawing.Color.White
      '
      '
      '
      Me.TextBoxResult.Border.Class = "TextBoxBorder"
      Me.TextBoxResult.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
      Me.TextBoxResult.DisabledBackColor = System.Drawing.Color.White
      Me.TextBoxResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.TextBoxResult.ForeColor = System.Drawing.Color.Black
      Me.TextBoxResult.Location = New System.Drawing.Point(10, 113)
      Me.TextBoxResult.Multiline = True
      Me.TextBoxResult.Name = "TextBoxResult"
      Me.TextBoxResult.PreventEnterBeep = True
      Me.TextBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.TextBoxResult.Size = New System.Drawing.Size(682, 406)
      Me.TextBoxResult.TabIndex = 3
      '
      'LabelX13
      '
      Me.LabelX13.BackColor = System.Drawing.Color.Transparent
      '
      '
      '
      Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
      Me.LabelX13.Location = New System.Drawing.Point(37, 7)
      Me.LabelX13.Name = "LabelX13"
      Me.LabelX13.Size = New System.Drawing.Size(85, 15)
      Me.LabelX13.TabIndex = 2
      Me.LabelX13.Text = "Estado"
      '
      'SwitchButton1
      '
      '
      '
      '
      Me.SwitchButton1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
      Me.SwitchButton1.Location = New System.Drawing.Point(10, 29)
      Me.SwitchButton1.Name = "SwitchButton1"
      Me.SwitchButton1.OffText = "Detenido"
      Me.SwitchButton1.OnText = "Ejecutando"
      Me.SwitchButton1.Size = New System.Drawing.Size(112, 35)
      Me.SwitchButton1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
      Me.SwitchButton1.TabIndex = 0
      Me.SwitchButton1.Value = True
      Me.SwitchButton1.ValueObject = "Y"
      '
      'SuperTabItem1
      '
      Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
      Me.SuperTabItem1.GlobalItem = False
      Me.SuperTabItem1.Name = "SuperTabItem1"
      Me.SuperTabItem1.Symbol = ""
      Me.SuperTabItem1.Text = "ESTADO"
      '
      'SuperTabControlPanel5
      '
      Me.SuperTabControlPanel5.AutoScroll = True
      Me.SuperTabControlPanel5.Controls.Add(Me.UcEmisor1)
      Me.SuperTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SuperTabControlPanel5.Location = New System.Drawing.Point(113, 0)
      Me.SuperTabControlPanel5.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
      Me.SuperTabControlPanel5.Name = "SuperTabControlPanel5"
      Me.SuperTabControlPanel5.Size = New System.Drawing.Size(754, 528)
      Me.SuperTabControlPanel5.TabIndex = 0
      Me.SuperTabControlPanel5.TabItem = Me.SuperTabItem5
      '
      'UcEmisor1
      '
      Me.UcEmisor1.BackColor = System.Drawing.Color.Gainsboro
      Me.UcEmisor1.Location = New System.Drawing.Point(1, 8)
      Me.UcEmisor1.Margin = New System.Windows.Forms.Padding(1)
      Me.UcEmisor1.Name = "UcEmisor1"
      Me.UcEmisor1.Size = New System.Drawing.Size(758, 512)
      Me.UcEmisor1.TabIndex = 64
      Me.UcEmisor1.tipoServidor = gestionaFacturas.ucEmisor.eServidores.pruebas
      '
      'SuperTabItem5
      '
      Me.SuperTabItem5.AttachedControl = Me.SuperTabControlPanel5
      Me.SuperTabItem5.GlobalItem = False
      Me.SuperTabItem5.Name = "SuperTabItem5"
      Me.SuperTabItem5.Symbol = "59471"
      Me.SuperTabItem5.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
      Me.SuperTabItem5.SymbolSize = 12.0!
      Me.SuperTabItem5.Text = "API Hacienda"
      '
      'StyleManager1
      '
      Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2016
      Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(199, Byte), Integer)))
      '
      'OpenFileDialog1
      '
      Me.OpenFileDialog1.FileName = "OpenFileDialog1"
      '
      'NotifyIcon1
      '
      Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
      Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
      Me.NotifyIcon1.Text = "gestionaFacturas"
      Me.NotifyIcon1.Visible = True
      '
      'ContextMenuStrip1
      '
      Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
      Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.SalirToolStripMenuItem})
      Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
      Me.ContextMenuStrip1.Size = New System.Drawing.Size(105, 40)
      Me.ContextMenuStrip1.Text = "Salir"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(101, 6)
      '
      'SalirToolStripMenuItem
      '
      Me.SalirToolStripMenuItem.Image = Global.gestionaFacturas.My.Resources.Resources.close_cancel_512
      Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
      Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(104, 30)
      Me.SalirToolStripMenuItem.Text = "Salir"
      '
      'BackgroundWorker1
      '
      '
      'EmisoresTableAdapter
      '
      Me.EmisoresTableAdapter.ClearBeforeFill = True
      '
      'TableAdapterManager
      '
      Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
      Me.TableAdapterManager.EmisoresTableAdapter = Me.EmisoresTableAdapter
      Me.TableAdapterManager.ServidoresTableAdapter = Nothing
      Me.TableAdapterManager.UpdateOrder = gestionaFacturas.eFacturaDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
      '
      'Form1
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
      Me.ClientSize = New System.Drawing.Size(867, 528)
      Me.Controls.Add(Me.SuperTabControl1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "Form1"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Generador Factura de Cobros 1.1"
      CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.SuperTabControl1.ResumeLayout(False)
      Me.SuperTabControlPanel1.ResumeLayout(False)
      CType(Me.EmisoresBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.EFacturaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
      Me.SuperTabControlPanel5.ResumeLayout(False)
      Me.ContextMenuStrip1.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
   Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
   Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
   Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
   Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
   Friend WithEvents OpenFileDialog1 As OpenFileDialog
   Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
   Friend WithEvents SwitchButton1 As DevComponents.DotNetBar.Controls.SwitchButton
   Friend WithEvents NotifyIcon1 As NotifyIcon
   Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
   Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
   Friend WithEvents CircularProgress1 As DevComponents.DotNetBar.Controls.CircularProgress
   Friend WithEvents TextBoxResult As DevComponents.DotNetBar.Controls.TextBoxX
   Friend WithEvents SuperTabControlPanel5 As DevComponents.DotNetBar.SuperTabControlPanel
   Friend WithEvents SuperTabItem5 As DevComponents.DotNetBar.SuperTabItem
   Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
   Friend WithEvents cbAPI As DevComponents.DotNetBar.Controls.CheckBoxX
   Friend WithEvents cbEmail As DevComponents.DotNetBar.Controls.CheckBoxX
   Friend WithEvents cbWEB As DevComponents.DotNetBar.Controls.CheckBoxX
   Friend WithEvents cbBD As DevComponents.DotNetBar.Controls.CheckBoxX
   Friend WithEvents cbInternet As DevComponents.DotNetBar.Controls.CheckBoxX
   Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
   Friend WithEvents cbCertificado As DevComponents.DotNetBar.Controls.CheckBoxX
   Friend WithEvents MicroChart1 As DevComponents.DotNetBar.MicroChart
   Friend WithEvents lbReinicio As DevComponents.DotNetBar.LabelX
   Friend WithEvents lbTotal As DevComponents.DotNetBar.LabelX
   Friend WithEvents lbDisponible As DevComponents.DotNetBar.LabelX
   Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
   Friend WithEvents EFacturaDataSet As eFacturaDataSet
   Friend WithEvents UcEmisor1 As ucEmisor
   Friend WithEvents SwitchButton2 As DevComponents.DotNetBar.Controls.SwitchButton
   Friend WithEvents ComboBoxEx1 As DevComponents.DotNetBar.Controls.ComboBoxEx
   Friend WithEvents EmisoresBindingSource As BindingSource
   Friend WithEvents EmisoresTableAdapter As eFacturaDataSetTableAdapters.EmisoresTableAdapter
   Friend WithEvents TableAdapterManager As eFacturaDataSetTableAdapters.TableAdapterManager
End Class
