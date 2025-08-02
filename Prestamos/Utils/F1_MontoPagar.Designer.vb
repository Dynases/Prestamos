<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class F1_MontoPagar
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
        Dim cbCambioDolar_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F1_MontoPagar))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.swMoneda = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.tbPagar = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tbPagado = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.lbGlosa = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.tbCuota = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.tbMontoBs = New DevComponents.Editors.DoubleInput()
        Me.tbFechaPago = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.tbFechaCuota = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.BtnSalir = New DevComponents.DotNetBar.ButtonX()
        Me.btnContinuar = New DevComponents.DotNetBar.ButtonX()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SwitchButton1 = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.tbTotal = New DevComponents.Editors.DoubleInput()
        Me.cbCambioDolar = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btgrupo1 = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX20 = New DevComponents.DotNetBar.LabelX()
        Me.tbMontoDolar = New DevComponents.Editors.DoubleInput()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.GroupBox2.SuspendLayout()
        CType(Me.tbMontoBs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbFechaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbFechaCuota, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.tbTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCambioDolar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbMontoDolar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.BackgroundImage = Global.Prestamos.My.Resources.Resources.fondo1
        Me.GroupBox2.Controls.Add(Me.swMoneda)
        Me.GroupBox2.Controls.Add(Me.LabelX4)
        Me.GroupBox2.Controls.Add(Me.LabelX1)
        Me.GroupBox2.Controls.Add(Me.tbPagar)
        Me.GroupBox2.Controls.Add(Me.tbPagado)
        Me.GroupBox2.Controls.Add(Me.LabelX3)
        Me.GroupBox2.Controls.Add(Me.lbGlosa)
        Me.GroupBox2.Controls.Add(Me.LabelX2)
        Me.GroupBox2.Controls.Add(Me.tbCuota)
        Me.GroupBox2.Controls.Add(Me.LabelX5)
        Me.GroupBox2.Controls.Add(Me.tbMontoBs)
        Me.GroupBox2.Controls.Add(Me.tbFechaPago)
        Me.GroupBox2.Controls.Add(Me.tbFechaCuota)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Gold
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(526, 344)
        Me.GroupBox2.TabIndex = 364
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalle Cuota:"
        '
        'swMoneda
        '
        '
        '
        '
        Me.swMoneda.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swMoneda.IsReadOnly = True
        Me.swMoneda.Location = New System.Drawing.Point(329, 12)
        Me.swMoneda.Name = "swMoneda"
        Me.swMoneda.OffBackColor = System.Drawing.Color.Gold
        Me.swMoneda.OffText = "BOLIVIANOS"
        Me.swMoneda.OffTextColor = System.Drawing.Color.Black
        Me.swMoneda.OnBackColor = System.Drawing.Color.Green
        Me.swMoneda.OnText = "DOLARES"
        Me.swMoneda.OnTextColor = System.Drawing.Color.White
        Me.swMoneda.Size = New System.Drawing.Size(170, 22)
        Me.swMoneda.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swMoneda.TabIndex = 385
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.White
        Me.LabelX4.Location = New System.Drawing.Point(261, 63)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX4.Size = New System.Drawing.Size(98, 18)
        Me.LabelX4.TabIndex = 384
        Me.LabelX4.Text = "A Pagar:"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.White
        Me.LabelX1.Location = New System.Drawing.Point(264, 95)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX1.Size = New System.Drawing.Size(98, 18)
        Me.LabelX1.TabIndex = 383
        Me.LabelX1.Text = "Pagado:"
        '
        'tbPagar
        '
        Me.tbPagar.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.tbPagar.Border.Class = "TextBoxBorder"
        Me.tbPagar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbPagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.tbPagar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.tbPagar.Location = New System.Drawing.Point(379, 60)
        Me.tbPagar.MaxLength = 25
        Me.tbPagar.Name = "tbPagar"
        Me.tbPagar.PreventEnterBeep = True
        Me.tbPagar.ReadOnly = True
        Me.tbPagar.Size = New System.Drawing.Size(120, 26)
        Me.tbPagar.TabIndex = 382
        '
        'tbPagado
        '
        Me.tbPagado.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.tbPagado.Border.Class = "TextBoxBorder"
        Me.tbPagado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbPagado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.tbPagado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.tbPagado.Location = New System.Drawing.Point(378, 92)
        Me.tbPagado.MaxLength = 25
        Me.tbPagado.Name = "tbPagado"
        Me.tbPagado.PreventEnterBeep = True
        Me.tbPagado.ReadOnly = True
        Me.tbPagado.Size = New System.Drawing.Size(120, 26)
        Me.tbPagado.TabIndex = 381
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.White
        Me.LabelX3.Location = New System.Drawing.Point(30, 128)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX3.Size = New System.Drawing.Size(92, 18)
        Me.LabelX3.TabIndex = 380
        Me.LabelX3.Text = "Fecha Pago:"
        '
        'lbGlosa
        '
        Me.lbGlosa.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lbGlosa.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbGlosa.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbGlosa.ForeColor = System.Drawing.Color.White
        Me.lbGlosa.Location = New System.Drawing.Point(16, 20)
        Me.lbGlosa.Name = "lbGlosa"
        Me.lbGlosa.SingleLineColor = System.Drawing.SystemColors.Control
        Me.lbGlosa.Size = New System.Drawing.Size(98, 18)
        Me.lbGlosa.TabIndex = 374
        Me.lbGlosa.Text = "Cuota:"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.White
        Me.LabelX2.Location = New System.Drawing.Point(16, 95)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX2.Size = New System.Drawing.Size(98, 18)
        Me.LabelX2.TabIndex = 379
        Me.LabelX2.Text = "Fecha Cuota:"
        '
        'tbCuota
        '
        Me.tbCuota.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.tbCuota.Border.Class = "TextBoxBorder"
        Me.tbCuota.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbCuota.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.tbCuota.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.tbCuota.Location = New System.Drawing.Point(127, 17)
        Me.tbCuota.MaxLength = 25
        Me.tbCuota.Name = "tbCuota"
        Me.tbCuota.PreventEnterBeep = True
        Me.tbCuota.ReadOnly = True
        Me.tbCuota.Size = New System.Drawing.Size(120, 26)
        Me.tbCuota.TabIndex = 372
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.White
        Me.LabelX5.Location = New System.Drawing.Point(24, 55)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX5.Size = New System.Drawing.Size(98, 18)
        Me.LabelX5.TabIndex = 64
        Me.LabelX5.Text = "M.Pagado Bs.:"
        '
        'tbMontoBs
        '
        '
        '
        '
        Me.tbMontoBs.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbMontoBs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbMontoBs.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.tbMontoBs.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbMontoBs.ForeColor = System.Drawing.Color.Black
        Me.tbMontoBs.Increment = 1.0R
        Me.tbMontoBs.Location = New System.Drawing.Point(125, 55)
        Me.tbMontoBs.MinValue = 0R
        Me.tbMontoBs.Name = "tbMontoBs"
        Me.tbMontoBs.Size = New System.Drawing.Size(120, 26)
        Me.tbMontoBs.TabIndex = 2
        Me.tbMontoBs.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Right
        '
        'tbFechaPago
        '
        '
        '
        '
        Me.tbFechaPago.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbFechaPago.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFechaPago.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.tbFechaPago.ButtonDropDown.Visible = True
        Me.tbFechaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.tbFechaPago.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tbFechaPago.IsPopupCalendarOpen = False
        Me.tbFechaPago.Location = New System.Drawing.Point(126, 120)
        '
        '
        '
        '
        '
        '
        Me.tbFechaPago.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFechaPago.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.tbFechaPago.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.tbFechaPago.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.tbFechaPago.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.tbFechaPago.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.tbFechaPago.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.tbFechaPago.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.tbFechaPago.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.tbFechaPago.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFechaPago.MonthCalendar.DisplayMonth = New Date(2023, 10, 1, 0, 0, 0, 0)
        Me.tbFechaPago.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.tbFechaPago.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.tbFechaPago.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.tbFechaPago.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.tbFechaPago.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFechaPago.MonthCalendar.TodayButtonVisible = True
        Me.tbFechaPago.Name = "tbFechaPago"
        Me.tbFechaPago.Size = New System.Drawing.Size(121, 26)
        Me.tbFechaPago.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tbFechaPago.TabIndex = 378
        '
        'tbFechaCuota
        '
        '
        '
        '
        Me.tbFechaCuota.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbFechaCuota.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFechaCuota.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.tbFechaCuota.ButtonDropDown.Visible = True
        Me.tbFechaCuota.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.tbFechaCuota.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tbFechaCuota.IsInputReadOnly = True
        Me.tbFechaCuota.IsPopupCalendarOpen = False
        Me.tbFechaCuota.Location = New System.Drawing.Point(125, 87)
        '
        '
        '
        '
        '
        '
        Me.tbFechaCuota.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFechaCuota.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.tbFechaCuota.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.tbFechaCuota.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.tbFechaCuota.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.tbFechaCuota.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.tbFechaCuota.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.tbFechaCuota.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.tbFechaCuota.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.tbFechaCuota.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFechaCuota.MonthCalendar.DisplayMonth = New Date(2023, 10, 1, 0, 0, 0, 0)
        Me.tbFechaCuota.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.tbFechaCuota.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.tbFechaCuota.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.tbFechaCuota.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.tbFechaCuota.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbFechaCuota.MonthCalendar.TodayButtonVisible = True
        Me.tbFechaCuota.Name = "tbFechaCuota"
        Me.tbFechaCuota.Size = New System.Drawing.Size(121, 26)
        Me.tbFechaCuota.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tbFechaCuota.TabIndex = 377
        '
        'BtnSalir
        '
        Me.BtnSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.BtnSalir.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.Image = Global.Prestamos.My.Resources.Resources.cancel
        Me.BtnSalir.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.BtnSalir.Location = New System.Drawing.Point(162, 94)
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(110, 39)
        Me.BtnSalir.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.BtnSalir.TabIndex = 371
        Me.BtnSalir.Text = "Salir"
        '
        'btnContinuar
        '
        Me.btnContinuar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnContinuar.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnContinuar.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContinuar.Image = Global.Prestamos.My.Resources.Resources.checked
        Me.btnContinuar.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.btnContinuar.Location = New System.Drawing.Point(283, 94)
        Me.btnContinuar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnContinuar.Name = "btnContinuar"
        Me.btnContinuar.Size = New System.Drawing.Size(110, 39)
        Me.btnContinuar.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.btnContinuar.TabIndex = 3
        Me.btnContinuar.Text = "Continuar"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.BackgroundImage = Global.Prestamos.My.Resources.Resources.fondo1
        Me.GroupBox1.Controls.Add(Me.SwitchButton1)
        Me.GroupBox1.Controls.Add(Me.LabelX8)
        Me.GroupBox1.Controls.Add(Me.LabelX7)
        Me.GroupBox1.Controls.Add(Me.tbTotal)
        Me.GroupBox1.Controls.Add(Me.BtnSalir)
        Me.GroupBox1.Controls.Add(Me.btnContinuar)
        Me.GroupBox1.Controls.Add(Me.cbCambioDolar)
        Me.GroupBox1.Controls.Add(Me.btgrupo1)
        Me.GroupBox1.Controls.Add(Me.LabelX20)
        Me.GroupBox1.Controls.Add(Me.tbMontoDolar)
        Me.GroupBox1.Controls.Add(Me.LabelX6)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Gold
        Me.GroupBox1.Location = New System.Drawing.Point(0, 172)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(526, 172)
        Me.GroupBox1.TabIndex = 362
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Formas de Pago:"
        '
        'SwitchButton1
        '
        '
        '
        '
        Me.SwitchButton1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SwitchButton1.Location = New System.Drawing.Point(189, 28)
        Me.SwitchButton1.Name = "SwitchButton1"
        Me.SwitchButton1.OffBackColor = System.Drawing.Color.Gold
        Me.SwitchButton1.OffText = "PLANILLA"
        Me.SwitchButton1.OffTextColor = System.Drawing.Color.Black
        Me.SwitchButton1.OnBackColor = System.Drawing.Color.Green
        Me.SwitchButton1.OnText = "TRANSFERENCIA"
        Me.SwitchButton1.OnTextColor = System.Drawing.Color.White
        Me.SwitchButton1.Size = New System.Drawing.Size(170, 22)
        Me.SwitchButton1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SwitchButton1.TabIndex = 386
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX8.ForeColor = System.Drawing.Color.White
        Me.LabelX8.Location = New System.Drawing.Point(78, 28)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX8.Size = New System.Drawing.Size(90, 18)
        Me.LabelX8.TabIndex = 379
        Me.LabelX8.Text = "Por:"
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.ForeColor = System.Drawing.Color.White
        Me.LabelX7.Location = New System.Drawing.Point(313, 84)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX7.Size = New System.Drawing.Size(58, 18)
        Me.LabelX7.TabIndex = 378
        Me.LabelX7.Text = "Total:"
        Me.LabelX7.Visible = False
        '
        'tbTotal
        '
        '
        '
        '
        Me.tbTotal.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbTotal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.tbTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTotal.ForeColor = System.Drawing.Color.Black
        Me.tbTotal.Increment = 1.0R
        Me.tbTotal.IsInputReadOnly = True
        Me.tbTotal.Location = New System.Drawing.Point(379, 76)
        Me.tbTotal.MinValue = 0R
        Me.tbTotal.Name = "tbTotal"
        Me.tbTotal.Size = New System.Drawing.Size(120, 26)
        Me.tbTotal.TabIndex = 377
        Me.tbTotal.Visible = False
        Me.tbTotal.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Right
        '
        'cbCambioDolar
        '
        Me.cbCambioDolar.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat
        Me.cbCambioDolar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        cbCambioDolar_DesignTimeLayout.LayoutString = resources.GetString("cbCambioDolar_DesignTimeLayout.LayoutString")
        Me.cbCambioDolar.DesignTimeLayout = cbCambioDolar_DesignTimeLayout
        Me.cbCambioDolar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCambioDolar.Location = New System.Drawing.Point(137, 49)
        Me.cbCambioDolar.Name = "cbCambioDolar"
        Me.cbCambioDolar.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.cbCambioDolar.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.cbCambioDolar.SelectedIndex = -1
        Me.cbCambioDolar.SelectedItem = Nothing
        Me.cbCambioDolar.Size = New System.Drawing.Size(121, 22)
        Me.cbCambioDolar.TabIndex = 376
        Me.cbCambioDolar.Visible = False
        Me.cbCambioDolar.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btgrupo1
        '
        Me.btgrupo1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btgrupo1.BackColor = System.Drawing.Color.Transparent
        Me.btgrupo1.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.btgrupo1.Image = Global.Prestamos.My.Resources.Resources.add
        Me.btgrupo1.ImageFixedSize = New System.Drawing.Size(25, 23)
        Me.btgrupo1.Location = New System.Drawing.Point(264, 49)
        Me.btgrupo1.Name = "btgrupo1"
        Me.btgrupo1.Size = New System.Drawing.Size(28, 23)
        Me.btgrupo1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btgrupo1.TabIndex = 369
        Me.btgrupo1.Visible = False
        '
        'LabelX20
        '
        Me.LabelX20.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX20.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX20.ForeColor = System.Drawing.Color.White
        Me.LabelX20.Location = New System.Drawing.Point(24, 52)
        Me.LabelX20.Name = "LabelX20"
        Me.LabelX20.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX20.Size = New System.Drawing.Size(90, 18)
        Me.LabelX20.TabIndex = 370
        Me.LabelX20.Text = "Tipo Cambio:"
        Me.LabelX20.Visible = False
        '
        'tbMontoDolar
        '
        '
        '
        '
        Me.tbMontoDolar.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tbMontoDolar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbMontoDolar.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.tbMontoDolar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbMontoDolar.ForeColor = System.Drawing.Color.Black
        Me.tbMontoDolar.Increment = 1.0R
        Me.tbMontoDolar.Location = New System.Drawing.Point(379, 52)
        Me.tbMontoDolar.MinValue = 0R
        Me.tbMontoDolar.Name = "tbMontoDolar"
        Me.tbMontoDolar.Size = New System.Drawing.Size(120, 26)
        Me.tbMontoDolar.TabIndex = 100
        Me.tbMontoDolar.Visible = False
        Me.tbMontoDolar.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Right
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.ForeColor = System.Drawing.Color.White
        Me.LabelX6.Location = New System.Drawing.Point(313, 56)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX6.Size = New System.Drawing.Size(60, 18)
        Me.LabelX6.TabIndex = 66
        Me.LabelX6.Text = "Mont. $:"
        Me.LabelX6.Visible = False
        '
        'F1_MontoPagar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 344)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "F1_MontoPagar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "F1_MontoPagar"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.tbMontoBs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbFechaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbFechaCuota, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.tbTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCambioDolar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbMontoDolar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents tbMontoBs As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbMontoDolar As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents BtnSalir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnContinuar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btgrupo1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX20 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lbGlosa As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbCuota As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cbCambioDolar As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbPagar As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tbPagado As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbFechaPago As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents tbFechaCuota As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbTotal As DevComponents.Editors.DoubleInput
    Friend WithEvents swMoneda As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents SwitchButton1 As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
End Class
