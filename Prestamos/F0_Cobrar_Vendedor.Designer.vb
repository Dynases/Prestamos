<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F0_Cobrar_Vendedor
    Inherits Modelo.ModeloF1


    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F0_Cobrar_Vendedor))
        Dim cbCliente_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.tbTotalCobrar = New DevComponents.Editors.DoubleInput()
        Me.tbSaldo = New DevComponents.Editors.DoubleInput()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbTotalCobrado = New DevComponents.Editors.DoubleInput()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbFechaVenta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Bt1Generar = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.tbCodigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tbNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.gr_detalle = New Janus.Windows.GridEX.GridEX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.tbFechaFactura = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.btnAutoChekear = New DevComponents.DotNetBar.ButtonX()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.btnCobrar = New DevComponents.DotNetBar.ButtonX()
        Me.tbMonto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.ButtonX3 = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.tbGlosa = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.JGrM_Pagos = New Janus.Windows.GridEX.GridEX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.grPrestamo = New Janus.Windows.GridEX.GridEX()
        Me.cbCliente = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.TextBoxX1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.grClientes = New Janus.Windows.GridEX.GridEX()
        Me.ButtonX4 = New DevComponents.DotNetBar.ButtonX()
        Me.tbAnular = New DevComponents.DotNetBar.ButtonX()
        CType(Me.SuperTabPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabPrincipal.SuspendLayout()
        Me.SuperTabControlPanelBuscador.SuspendLayout()
        Me.SuperTabControlPanelRegistro.SuspendLayout()
        Me.PanelSuperior.SuspendLayout()
        Me.PanelInferior.SuspendLayout()
        CType(Me.BubbleBarUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelToolBar1.SuspendLayout()
        Me.PanelToolBar2.SuspendLayout()
        Me.MPanelSup.SuspendLayout()
        Me.PanelPrincipal.SuspendLayout()
        Me.GroupPanelBuscador.SuspendLayout()
        Me.PanelUsuario.SuspendLayout()
        Me.PanelNavegacion.SuspendLayout()
        Me.MPanelUserAct.SuspendLayout()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.JGrM_Buscador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.tbTotalCobrar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTotalCobrado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbFechaVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gr_detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbFechaFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.JGrM_Pagos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.grPrestamo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SuperTabPrincipal
        '
        '
        '
        '
        '
        '
        '
        Me.SuperTabPrincipal.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabPrincipal.ControlBox.MenuBox.Name = ""
        Me.SuperTabPrincipal.ControlBox.Name = ""
        Me.SuperTabPrincipal.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabPrincipal.ControlBox.MenuBox, Me.SuperTabPrincipal.ControlBox.CloseBox})
        Me.SuperTabPrincipal.Margin = New System.Windows.Forms.Padding(2)
        Me.SuperTabPrincipal.Size = New System.Drawing.Size(1334, 691)
        Me.SuperTabPrincipal.TabIndex = 1
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelBuscador, 0)
        Me.SuperTabPrincipal.Controls.SetChildIndex(Me.SuperTabControlPanelRegistro, 0)
        '
        'SuperTabControlPanelBuscador
        '
        Me.SuperTabControlPanelBuscador.Controls.Add(Me.GroupPanel1)
        Me.SuperTabControlPanelBuscador.Margin = New System.Windows.Forms.Padding(2)
        Me.SuperTabControlPanelBuscador.Size = New System.Drawing.Size(1302, 691)
        '
        'SuperTabControlPanelRegistro
        '
        Me.SuperTabControlPanelRegistro.Margin = New System.Windows.Forms.Padding(2)
        Me.SuperTabControlPanelRegistro.Size = New System.Drawing.Size(1302, 691)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelSuperior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelInferior, 0)
        Me.SuperTabControlPanelRegistro.Controls.SetChildIndex(Me.PanelPrincipal, 0)
        '
        'PanelSuperior
        '
        Me.PanelSuperior.Controls.Add(Me.ButtonX2)
        Me.PanelSuperior.Controls.Add(Me.tbAnular)
        Me.PanelSuperior.Controls.Add(Me.ButtonX1)
        Me.PanelSuperior.Controls.Add(Me.ButtonX3)
        Me.PanelSuperior.Margin = New System.Windows.Forms.Padding(2)
        Me.PanelSuperior.Size = New System.Drawing.Size(1302, 72)
        Me.PanelSuperior.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelSuperior.Style.BackColor1.Color = System.Drawing.Color.DarkSlateGray
        Me.PanelSuperior.Style.BackColor2.Color = System.Drawing.Color.DarkSlateGray
        Me.PanelSuperior.Style.BackgroundImage = CType(resources.GetObject("PanelSuperior.Style.BackgroundImage"), System.Drawing.Image)
        Me.PanelSuperior.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelSuperior.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelSuperior.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelSuperior.Style.GradientAngle = 90
        Me.PanelSuperior.Controls.SetChildIndex(Me.ButtonX3, 0)
        Me.PanelSuperior.Controls.SetChildIndex(Me.ButtonX1, 0)
        Me.PanelSuperior.Controls.SetChildIndex(Me.tbAnular, 0)
        Me.PanelSuperior.Controls.SetChildIndex(Me.ButtonX2, 0)
        Me.PanelSuperior.Controls.SetChildIndex(Me.PanelToolBar1, 0)
        Me.PanelSuperior.Controls.SetChildIndex(Me.PanelToolBar2, 0)
        '
        'PanelInferior
        '
        Me.PanelInferior.Location = New System.Drawing.Point(0, 655)
        Me.PanelInferior.Margin = New System.Windows.Forms.Padding(2)
        Me.PanelInferior.Size = New System.Drawing.Size(1302, 36)
        Me.PanelInferior.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelInferior.Style.BackColor1.Color = System.Drawing.Color.DarkSlateGray
        Me.PanelInferior.Style.BackColor2.Color = System.Drawing.Color.DarkSlateGray
        Me.PanelInferior.Style.BackgroundImage = CType(resources.GetObject("PanelInferior.Style.BackgroundImage"), System.Drawing.Image)
        Me.PanelInferior.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelInferior.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelInferior.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelInferior.Style.GradientAngle = 90
        '
        'BubbleBarUsuario
        '
        '
        '
        '
        Me.BubbleBarUsuario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.BubbleBarUsuario.ButtonBackAreaStyle.BackColor = System.Drawing.Color.Transparent
        Me.BubbleBarUsuario.ButtonBackAreaStyle.BorderBottomWidth = 1
        Me.BubbleBarUsuario.ButtonBackAreaStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BubbleBarUsuario.ButtonBackAreaStyle.BorderLeftWidth = 1
        Me.BubbleBarUsuario.ButtonBackAreaStyle.BorderRightWidth = 1
        Me.BubbleBarUsuario.ButtonBackAreaStyle.BorderTopWidth = 1
        Me.BubbleBarUsuario.ButtonBackAreaStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BubbleBarUsuario.ButtonBackAreaStyle.PaddingBottom = 3
        Me.BubbleBarUsuario.ButtonBackAreaStyle.PaddingLeft = 3
        Me.BubbleBarUsuario.ButtonBackAreaStyle.PaddingRight = 3
        Me.BubbleBarUsuario.ButtonBackAreaStyle.PaddingTop = 3
        Me.BubbleBarUsuario.MouseOverTabColors.BorderColor = System.Drawing.SystemColors.Highlight
        Me.BubbleBarUsuario.SelectedTabColors.BorderColor = System.Drawing.Color.Black
        '
        'TxtNombreUsu
        '
        Me.TxtNombreUsu.Margin = New System.Windows.Forms.Padding(2)
        '
        'PanelToolBar1
        '
        Me.PanelToolBar1.Location = New System.Drawing.Point(320, 0)
        Me.PanelToolBar1.Margin = New System.Windows.Forms.Padding(2)
        Me.PanelToolBar1.Size = New System.Drawing.Size(196, 72)
        '
        'btnSalir
        '
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSalir.Size = New System.Drawing.Size(0, 72)
        Me.btnSalir.Visible = False
        '
        'btnGrabar
        '
        Me.btnGrabar.Visible = False
        '
        'btnEliminar
        '
        Me.btnEliminar.Visible = False
        '
        'btnModificar
        '
        Me.btnModificar.Visible = False
        '
        'btnNuevo
        '
        Me.btnNuevo.Visible = False
        '
        'PanelToolBar2
        '
        Me.PanelToolBar2.Controls.Add(Me.btnCobrar)
        Me.PanelToolBar2.Location = New System.Drawing.Point(878, 0)
        Me.PanelToolBar2.Margin = New System.Windows.Forms.Padding(2)
        Me.PanelToolBar2.Size = New System.Drawing.Size(160, 72)
        Me.PanelToolBar2.Controls.SetChildIndex(Me.btnImprimir, 0)
        Me.PanelToolBar2.Controls.SetChildIndex(Me.btnCobrar, 0)
        '
        'MPanelSup
        '
        Me.MPanelSup.Controls.Add(Me.grClientes)
        Me.MPanelSup.Controls.Add(Me.ButtonX4)
        Me.MPanelSup.Controls.Add(Me.TextBoxX1)
        Me.MPanelSup.Controls.Add(Me.cbCliente)
        Me.MPanelSup.Controls.Add(Me.GroupPanel2)
        Me.MPanelSup.Controls.Add(Me.tbGlosa)
        Me.MPanelSup.Controls.Add(Me.LabelX6)
        Me.MPanelSup.Controls.Add(Me.LabelX5)
        Me.MPanelSup.Controls.Add(Me.tbMonto)
        Me.MPanelSup.Controls.Add(Me.LabelX3)
        Me.MPanelSup.Controls.Add(Me.tbFechaFactura)
        Me.MPanelSup.Controls.Add(Me.LabelX1)
        Me.MPanelSup.Controls.Add(Me.tbFechaVenta)
        Me.MPanelSup.Controls.Add(Me.LabelX4)
        Me.MPanelSup.Controls.Add(Me.tbCodigo)
        Me.MPanelSup.Controls.Add(Me.tbNombre)
        Me.MPanelSup.Controls.Add(Me.LabelX2)
        Me.MPanelSup.Margin = New System.Windows.Forms.Padding(2)
        Me.MPanelSup.Size = New System.Drawing.Size(1302, 184)
        '
        'PanelPrincipal
        '
        Me.PanelPrincipal.Controls.Add(Me.Panel1)
        Me.PanelPrincipal.Margin = New System.Windows.Forms.Padding(2)
        Me.PanelPrincipal.Size = New System.Drawing.Size(1302, 583)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.MPanelSup, 0)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.Panel1, 0)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.GroupPanelBuscador, 0)
        '
        'GroupPanelBuscador
        '
        Me.GroupPanelBuscador.Controls.Add(Me.gr_detalle)
        Me.GroupPanelBuscador.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupPanelBuscador.Size = New System.Drawing.Size(1302, 285)
        '
        '
        '
        Me.GroupPanelBuscador.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanelBuscador.Style.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanelBuscador.Style.BackColorGradientAngle = 90
        Me.GroupPanelBuscador.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelBuscador.Style.BorderBottomWidth = 1
        Me.GroupPanelBuscador.Style.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanelBuscador.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelBuscador.Style.BorderLeftWidth = 1
        Me.GroupPanelBuscador.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelBuscador.Style.BorderRightWidth = 1
        Me.GroupPanelBuscador.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanelBuscador.Style.BorderTopWidth = 1
        Me.GroupPanelBuscador.Style.CornerDiameter = 4
        Me.GroupPanelBuscador.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanelBuscador.Style.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanelBuscador.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanelBuscador.Style.TextColor = System.Drawing.Color.White
        Me.GroupPanelBuscador.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanelBuscador.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanelBuscador.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanelBuscador.Controls.SetChildIndex(Me.gr_detalle, 0)
        Me.GroupPanelBuscador.Controls.SetChildIndex(Me.JGrM_Buscador, 0)
        '
        'PanelUsuario
        '
        Me.PanelUsuario.Controls.Add(Me.btnAutoChekear)
        Me.PanelUsuario.Controls.Add(Me.Bt1Generar)
        Me.PanelUsuario.Location = New System.Drawing.Point(1339, 140)
        Me.PanelUsuario.Controls.SetChildIndex(Me.Bt1Generar, 0)
        Me.PanelUsuario.Controls.SetChildIndex(Me.lblUsuario, 0)
        Me.PanelUsuario.Controls.SetChildIndex(Me.lblFecha, 0)
        Me.PanelUsuario.Controls.SetChildIndex(Me.lblHora, 0)
        Me.PanelUsuario.Controls.SetChildIndex(Me.btnAutoChekear, 0)
        Me.PanelUsuario.Controls.SetChildIndex(Me.lbUsuario, 0)
        Me.PanelUsuario.Controls.SetChildIndex(Me.lbFecha, 0)
        Me.PanelUsuario.Controls.SetChildIndex(Me.lbHora, 0)
        '
        'btnImprimir
        '
        Me.btnImprimir.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnImprimir.Location = New System.Drawing.Point(80, 0)
        Me.btnImprimir.Visible = False
        '
        'btnUltimo
        '
        Me.btnUltimo.Margin = New System.Windows.Forms.Padding(2)
        '
        'btnSiguiente
        '
        '
        'btnAnterior
        '
        '
        'btnPrimero
        '
        '
        'MPanelUserAct
        '
        Me.MPanelUserAct.Location = New System.Drawing.Point(796, 0)
        Me.MPanelUserAct.Margin = New System.Windows.Forms.Padding(2)
        '
        'JGrM_Buscador
        '
        Me.JGrM_Buscador.HeaderFormatStyle.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JGrM_Buscador.HeaderFormatStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.JGrM_Buscador.Margin = New System.Windows.Forms.Padding(2)
        Me.JGrM_Buscador.SelectedFormatStyle.BackColor = System.Drawing.Color.DodgerBlue
        Me.JGrM_Buscador.SelectedFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JGrM_Buscador.SelectedFormatStyle.ForeColor = System.Drawing.Color.White
        Me.JGrM_Buscador.Size = New System.Drawing.Size(1296, 262)
        Me.JGrM_Buscador.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.BackgroundImage = Global.Prestamos.My.Resources.Resources.fondo1
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 469)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1302, 114)
        Me.Panel1.TabIndex = 21
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = Global.Prestamos.My.Resources.Resources.fondo1
        Me.Panel2.Controls.Add(Me.tbTotalCobrar)
        Me.Panel2.Controls.Add(Me.tbSaldo)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.tbTotalCobrado)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(827, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(475, 114)
        Me.Panel2.TabIndex = 6
        Me.Panel2.Visible = False
        '
        'tbTotalCobrar
        '
        '
        '
        '
        Me.tbTotalCobrar.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbTotalCobrar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbTotalCobrar.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.tbTotalCobrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTotalCobrar.Increment = 1.0R
        Me.tbTotalCobrar.Location = New System.Drawing.Point(118, 24)
        Me.tbTotalCobrar.LockUpdateChecked = False
        Me.tbTotalCobrar.MinValue = 0R
        Me.tbTotalCobrar.Name = "tbTotalCobrar"
        Me.tbTotalCobrar.Size = New System.Drawing.Size(104, 21)
        Me.tbTotalCobrar.TabIndex = 3
        Me.tbTotalCobrar.Visible = False
        Me.tbTotalCobrar.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Right
        '
        'tbSaldo
        '
        '
        '
        '
        Me.tbSaldo.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbSaldo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbSaldo.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.tbSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSaldo.Increment = 1.0R
        Me.tbSaldo.Location = New System.Drawing.Point(118, 73)
        Me.tbSaldo.LockUpdateChecked = False
        Me.tbSaldo.MinValue = 0R
        Me.tbSaldo.Name = "tbSaldo"
        Me.tbSaldo.Size = New System.Drawing.Size(104, 21)
        Me.tbSaldo.TabIndex = 5
        Me.tbSaldo.Visible = False
        Me.tbSaldo.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(21, 24)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Total a Cobrar :"
        '
        'tbTotalCobrado
        '
        '
        '
        '
        Me.tbTotalCobrado.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbTotalCobrado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbTotalCobrado.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.tbTotalCobrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTotalCobrado.Increment = 1.0R
        Me.tbTotalCobrado.Location = New System.Drawing.Point(118, 50)
        Me.tbTotalCobrado.LockUpdateChecked = False
        Me.tbTotalCobrado.MinValue = 0R
        Me.tbTotalCobrado.Name = "tbTotalCobrado"
        Me.tbTotalCobrado.Size = New System.Drawing.Size(104, 21)
        Me.tbTotalCobrado.TabIndex = 4
        Me.tbTotalCobrado.Visible = False
        Me.tbTotalCobrado.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Location = New System.Drawing.Point(12, 50)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Total a Cobrado :"
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Location = New System.Drawing.Point(69, 73)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Saldo :"
        Me.Label3.Visible = False
        '
        'tbFechaVenta
        '
        '
        '
        '
        Me.tbFechaVenta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbFechaVenta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFechaVenta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.tbFechaVenta.ButtonDropDown.Visible = True
        Me.tbFechaVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbFechaVenta.IsPopupCalendarOpen = False
        Me.tbFechaVenta.Location = New System.Drawing.Point(107, 62)
        '
        '
        '
        '
        '
        '
        Me.tbFechaVenta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFechaVenta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.tbFechaVenta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.tbFechaVenta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.tbFechaVenta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.tbFechaVenta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.tbFechaVenta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.tbFechaVenta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.tbFechaVenta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.tbFechaVenta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFechaVenta.MonthCalendar.DisplayMonth = New Date(2017, 2, 1, 0, 0, 0, 0)
        Me.tbFechaVenta.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.tbFechaVenta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.tbFechaVenta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.tbFechaVenta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.tbFechaVenta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFechaVenta.MonthCalendar.TodayButtonVisible = True
        Me.tbFechaVenta.Name = "tbFechaVenta"
        Me.tbFechaVenta.Size = New System.Drawing.Size(120, 22)
        Me.tbFechaVenta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tbFechaVenta.TabIndex = 241
        Me.tbFechaVenta.Visible = False
        '
        'Bt1Generar
        '
        Me.Bt1Generar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Bt1Generar.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.Bt1Generar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt1Generar.Image = Global.Prestamos.My.Resources.Resources.list
        Me.Bt1Generar.ImageFixedSize = New System.Drawing.Size(40, 40)
        Me.Bt1Generar.Location = New System.Drawing.Point(-73, 86)
        Me.Bt1Generar.Name = "Bt1Generar"
        Me.Bt1Generar.Size = New System.Drawing.Size(150, 50)
        Me.Bt1Generar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bt1Generar.TabIndex = 240
        Me.Bt1Generar.Text = "Generar"
        Me.Bt1Generar.Visible = False
        '
        'LabelX4
        '
        Me.LabelX4.AutoSize = True
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX4.Location = New System.Drawing.Point(7, 62)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX4.Size = New System.Drawing.Size(95, 16)
        Me.LabelX4.TabIndex = 239
        Me.LabelX4.Text = "Fecha de Pago:"
        Me.LabelX4.Visible = False
        '
        'tbCodigo
        '
        Me.tbCodigo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.tbCodigo.Border.Class = "TextBoxBorder"
        Me.tbCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCodigo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.tbCodigo.Location = New System.Drawing.Point(187, 5)
        Me.tbCodigo.Name = "tbCodigo"
        Me.tbCodigo.PreventEnterBeep = True
        Me.tbCodigo.ReadOnly = True
        Me.tbCodigo.Size = New System.Drawing.Size(53, 22)
        Me.tbCodigo.TabIndex = 238
        Me.tbCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tbCodigo.Visible = False
        '
        'tbNombre
        '
        Me.tbNombre.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.tbNombre.Border.Class = "TextBoxBorder"
        Me.tbNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.tbNombre.Location = New System.Drawing.Point(187, 29)
        Me.tbNombre.Name = "tbNombre"
        Me.tbNombre.PreventEnterBeep = True
        Me.tbNombre.ReadOnly = True
        Me.tbNombre.Size = New System.Drawing.Size(249, 22)
        Me.tbNombre.TabIndex = 236
        Me.tbNombre.Visible = False
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX2.Location = New System.Drawing.Point(50, 31)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX2.Size = New System.Drawing.Size(51, 16)
        Me.LabelX2.TabIndex = 237
        Me.LabelX2.Text = "Cliente:"
        '
        'gr_detalle
        '
        Me.gr_detalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gr_detalle.FlatBorderColor = System.Drawing.SystemColors.HotTrack
        Me.gr_detalle.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle
        Me.gr_detalle.FocusStyle = Janus.Windows.GridEX.FocusStyle.None
        Me.gr_detalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gr_detalle.HeaderFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold)
        Me.gr_detalle.HeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.gr_detalle.Location = New System.Drawing.Point(0, 0)
        Me.gr_detalle.Margin = New System.Windows.Forms.Padding(2)
        Me.gr_detalle.Name = "gr_detalle"
        Me.gr_detalle.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.gr_detalle.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.gr_detalle.RowFormatStyle.BackColor = System.Drawing.Color.Transparent
        Me.gr_detalle.SelectedFormatStyle.BackColor = System.Drawing.Color.Transparent
        Me.gr_detalle.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black
        Me.gr_detalle.SelectedInactiveFormatStyle.BackColor = System.Drawing.Color.Transparent
        Me.gr_detalle.Size = New System.Drawing.Size(1296, 262)
        Me.gr_detalle.TabIndex = 2
        Me.gr_detalle.TableHeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.gr_detalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.ButtonX2.Dock = System.Windows.Forms.DockStyle.Left
        Me.ButtonX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX2.Image = Global.Prestamos.My.Resources.Resources.atras1
        Me.ButtonX2.ImageFixedSize = New System.Drawing.Size(48, 48)
        Me.ButtonX2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonX2.Location = New System.Drawing.Point(240, 0)
        Me.ButtonX2.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(80, 72)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 11
        Me.ButtonX2.Text = "SALIR"
        Me.ButtonX2.TextColor = System.Drawing.Color.White
        '
        'tbFechaFactura
        '
        '
        '
        '
        Me.tbFechaFactura.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbFechaFactura.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFechaFactura.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.tbFechaFactura.ButtonDropDown.Visible = True
        Me.tbFechaFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbFechaFactura.IsPopupCalendarOpen = False
        Me.tbFechaFactura.Location = New System.Drawing.Point(355, 63)
        '
        '
        '
        '
        '
        '
        Me.tbFechaFactura.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFechaFactura.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.tbFechaFactura.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.tbFechaFactura.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.tbFechaFactura.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.tbFechaFactura.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.tbFechaFactura.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.tbFechaFactura.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.tbFechaFactura.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.tbFechaFactura.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFechaFactura.MonthCalendar.DisplayMonth = New Date(2017, 2, 1, 0, 0, 0, 0)
        Me.tbFechaFactura.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.tbFechaFactura.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.tbFechaFactura.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.tbFechaFactura.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.tbFechaFactura.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFechaFactura.MonthCalendar.TodayButtonVisible = True
        Me.tbFechaFactura.Name = "tbFechaFactura"
        Me.tbFechaFactura.Size = New System.Drawing.Size(120, 22)
        Me.tbFechaFactura.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tbFechaFactura.TabIndex = 243
        Me.tbFechaFactura.Visible = False
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(255, 63)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX1.Size = New System.Drawing.Size(94, 16)
        Me.LabelX1.TabIndex = 242
        Me.LabelX1.Text = "Fecha Factura:"
        Me.LabelX1.Visible = False
        '
        'btnAutoChekear
        '
        Me.btnAutoChekear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAutoChekear.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnAutoChekear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutoChekear.Image = Global.Prestamos.My.Resources.Resources.GRABACION_EXITOSA
        Me.btnAutoChekear.ImageFixedSize = New System.Drawing.Size(40, 40)
        Me.btnAutoChekear.Location = New System.Drawing.Point(97, 86)
        Me.btnAutoChekear.Name = "btnAutoChekear"
        Me.btnAutoChekear.Size = New System.Drawing.Size(150, 50)
        Me.btnAutoChekear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAutoChekear.TabIndex = 244
        Me.btnAutoChekear.Text = "Auto Checkear"
        Me.btnAutoChekear.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.ButtonX1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ButtonX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX1.Image = Global.Prestamos.My.Resources.Resources.save
        Me.ButtonX1.ImageFixedSize = New System.Drawing.Size(48, 48)
        Me.ButtonX1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonX1.Location = New System.Drawing.Point(80, 0)
        Me.ButtonX1.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(80, 72)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 10
        Me.ButtonX1.Text = "GRABAR"
        Me.ButtonX1.TextColor = System.Drawing.Color.White
        Me.ButtonX1.Visible = False
        '
        'btnCobrar
        '
        Me.btnCobrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCobrar.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange
        Me.btnCobrar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCobrar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCobrar.Image = Global.Prestamos.My.Resources.Resources.cobro
        Me.btnCobrar.ImageFixedSize = New System.Drawing.Size(48, 48)
        Me.btnCobrar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnCobrar.Location = New System.Drawing.Point(0, 0)
        Me.btnCobrar.Name = "btnCobrar"
        Me.btnCobrar.Size = New System.Drawing.Size(80, 72)
        Me.btnCobrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCobrar.TabIndex = 15
        Me.btnCobrar.Text = "COBRAR"
        Me.btnCobrar.TextColor = System.Drawing.Color.White
        Me.btnCobrar.Visible = False
        '
        'tbMonto
        '
        Me.tbMonto.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.tbMonto.Border.Class = "TextBoxBorder"
        Me.tbMonto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbMonto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.tbMonto.Location = New System.Drawing.Point(107, 130)
        Me.tbMonto.Name = "tbMonto"
        Me.tbMonto.PreventEnterBeep = True
        Me.tbMonto.ReadOnly = True
        Me.tbMonto.Size = New System.Drawing.Size(120, 22)
        Me.tbMonto.TabIndex = 246
        Me.tbMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tbMonto.Visible = False
        '
        'LabelX3
        '
        Me.LabelX3.AutoSize = True
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX3.Location = New System.Drawing.Point(50, 132)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX3.Size = New System.Drawing.Size(47, 16)
        Me.LabelX3.TabIndex = 245
        Me.LabelX3.Text = "Monto:"
        Me.LabelX3.Visible = False
        '
        'LabelX5
        '
        Me.LabelX5.AutoSize = True
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Georgia", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX5.Location = New System.Drawing.Point(105, 14)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX5.Size = New System.Drawing.Size(55, 13)
        Me.LabelX5.TabIndex = 247
        Me.LabelX5.Text = "Ctrl+Enter"
        Me.LabelX5.Visible = False
        '
        'ButtonX3
        '
        Me.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.ButtonX3.Dock = System.Windows.Forms.DockStyle.Left
        Me.ButtonX3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX3.Image = Global.Prestamos.My.Resources.Resources.add2
        Me.ButtonX3.ImageFixedSize = New System.Drawing.Size(48, 48)
        Me.ButtonX3.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonX3.Location = New System.Drawing.Point(0, 0)
        Me.ButtonX3.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.Size = New System.Drawing.Size(80, 72)
        Me.ButtonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX3.TabIndex = 12
        Me.ButtonX3.Text = "NUEVO"
        Me.ButtonX3.TextColor = System.Drawing.Color.White
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX6.Location = New System.Drawing.Point(22, 154)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(75, 23)
        Me.LabelX6.TabIndex = 248
        Me.LabelX6.Text = "Glosa:"
        Me.LabelX6.TextAlignment = System.Drawing.StringAlignment.Far
        Me.LabelX6.Visible = False
        '
        'tbGlosa
        '
        '
        '
        '
        Me.tbGlosa.Border.Class = "TextBoxBorder"
        Me.tbGlosa.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbGlosa.Location = New System.Drawing.Point(107, 157)
        Me.tbGlosa.Name = "tbGlosa"
        Me.tbGlosa.PreventEnterBeep = True
        Me.tbGlosa.Size = New System.Drawing.Size(250, 20)
        Me.tbGlosa.TabIndex = 249
        Me.tbGlosa.Visible = False
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.JGrM_Pagos)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(1302, 691)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 0
        Me.GroupPanel1.Text = "B U S C A D O R"
        '
        'JGrM_Pagos
        '
        Me.JGrM_Pagos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.JGrM_Pagos.Location = New System.Drawing.Point(0, 0)
        Me.JGrM_Pagos.Name = "JGrM_Pagos"
        Me.JGrM_Pagos.Size = New System.Drawing.Size(1296, 670)
        Me.JGrM_Pagos.TabIndex = 0
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.grPrestamo)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupPanel2.Location = New System.Drawing.Point(602, 0)
        Me.GroupPanel2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(700, 184)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanel2.Style.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColor = System.Drawing.Color.White
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 250
        Me.GroupPanel2.Text = "PRESTAMOS"
        '
        'grPrestamo
        '
        Me.grPrestamo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grPrestamo.Location = New System.Drawing.Point(0, 0)
        Me.grPrestamo.Name = "grPrestamo"
        Me.grPrestamo.Size = New System.Drawing.Size(694, 161)
        Me.grPrestamo.TabIndex = 0
        '
        'cbCliente
        '
        cbCliente_DesignTimeLayout.LayoutString = resources.GetString("cbCliente_DesignTimeLayout.LayoutString")
        Me.cbCliente.DesignTimeLayout = cbCliente_DesignTimeLayout
        Me.cbCliente.Location = New System.Drawing.Point(105, 29)
        Me.cbCliente.Name = "cbCliente"
        Me.cbCliente.SelectedIndex = -1
        Me.cbCliente.SelectedItem = Nothing
        Me.cbCliente.Size = New System.Drawing.Size(400, 20)
        Me.cbCliente.TabIndex = 251
        Me.cbCliente.Visible = False
        '
        'TextBoxX1
        '
        '
        '
        '
        Me.TextBoxX1.Border.Class = "TextBoxBorder"
        Me.TextBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX1.Location = New System.Drawing.Point(105, 33)
        Me.TextBoxX1.Name = "TextBoxX1"
        Me.TextBoxX1.PreventEnterBeep = True
        Me.TextBoxX1.Size = New System.Drawing.Size(300, 20)
        Me.TextBoxX1.TabIndex = 252
        '
        'grClientes
        '
        Me.grClientes.Location = New System.Drawing.Point(105, 57)
        Me.grClientes.Name = "grClientes"
        Me.grClientes.Size = New System.Drawing.Size(400, 100)
        Me.grClientes.TabIndex = 253
        Me.grClientes.Visible = False
        '
        'ButtonX4
        '
        Me.ButtonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.ButtonX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX4.Image = Global.Prestamos.My.Resources.Resources.GRABACION_EXITOSA
        Me.ButtonX4.ImageFixedSize = New System.Drawing.Size(40, 40)
        Me.ButtonX4.Location = New System.Drawing.Point(240, 118)
        Me.ButtonX4.Name = "ButtonX4"
        Me.ButtonX4.Size = New System.Drawing.Size(150, 50)
        Me.ButtonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX4.TabIndex = 254
        Me.ButtonX4.Text = "Pagar"
        Me.ButtonX4.Visible = False
        '
        'tbAnular
        '
        Me.tbAnular.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.tbAnular.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.tbAnular.Dock = System.Windows.Forms.DockStyle.Left
        Me.tbAnular.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAnular.Image = Global.Prestamos.My.Resources.Resources.trash
        Me.tbAnular.ImageFixedSize = New System.Drawing.Size(48, 48)
        Me.tbAnular.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.tbAnular.Location = New System.Drawing.Point(160, 0)
        Me.tbAnular.Margin = New System.Windows.Forms.Padding(2)
        Me.tbAnular.Name = "tbAnular"
        Me.tbAnular.Size = New System.Drawing.Size(80, 72)
        Me.tbAnular.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tbAnular.TabIndex = 13
        Me.tbAnular.Text = "ANULAR"
        Me.tbAnular.TextColor = System.Drawing.Color.White
        '
        'F0_Cobrar_Vendedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1334, 691)
        Me.Controls.Add(Me.PanelUsuario)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "F0_Cobrar_Vendedor"
        Me.Opacity = 0.99R
        Me.Text = "F0_Cobrar_Vendedor"
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.Controls.SetChildIndex(Me.SuperTabPrincipal, 0)
        Me.Controls.SetChildIndex(Me.PanelUsuario, 0)
        CType(Me.SuperTabPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabPrincipal.ResumeLayout(False)
        Me.SuperTabControlPanelBuscador.ResumeLayout(False)
        Me.SuperTabControlPanelRegistro.ResumeLayout(False)
        Me.PanelSuperior.ResumeLayout(False)
        Me.PanelInferior.ResumeLayout(False)
        CType(Me.BubbleBarUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelToolBar1.ResumeLayout(False)
        Me.PanelToolBar2.ResumeLayout(False)
        Me.MPanelSup.ResumeLayout(False)
        Me.MPanelSup.PerformLayout()
        Me.PanelPrincipal.ResumeLayout(False)
        Me.GroupPanelBuscador.ResumeLayout(False)
        Me.PanelUsuario.ResumeLayout(False)
        Me.PanelUsuario.PerformLayout()
        Me.PanelNavegacion.ResumeLayout(False)
        Me.MPanelUserAct.ResumeLayout(False)
        Me.MPanelUserAct.PerformLayout()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.JGrM_Buscador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.tbTotalCobrar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSaldo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTotalCobrado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbFechaVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gr_detalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbFechaFactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.JGrM_Pagos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.grPrestamo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents tbTotalCobrar As DevComponents.Editors.DoubleInput
    Friend WithEvents tbSaldo As DevComponents.Editors.DoubleInput
    Friend WithEvents Label1 As Label
    Friend WithEvents tbTotalCobrado As DevComponents.Editors.DoubleInput
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents tbFechaVenta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Bt1Generar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents gr_detalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents tbFechaFactura As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnAutoChekear As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Protected WithEvents btnCobrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents tbMonto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ButtonX3 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents tbGlosa As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents JGrM_Pagos As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents grPrestamo As Janus.Windows.GridEX.GridEX
    Friend WithEvents cbCliente As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents grClientes As Janus.Windows.GridEX.GridEX
    Friend WithEvents TextBoxX1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ButtonX4 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents tbAnular As DevComponents.DotNetBar.ButtonX
End Class
