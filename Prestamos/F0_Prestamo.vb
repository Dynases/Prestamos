Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.ToolTips
Imports System.Drawing
Imports DevComponents.DotNetBar.Controls
Imports System.Threading
Imports System.Drawing.Text
Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports System.IO
Imports System.Data.OleDb
Imports DevComponents.DotNetBar.SuperGrid
Imports GMap.NET.MapProviders
Imports GMap.NET
Imports GMap.NET.WindowsForms.Markers
Imports System.Reflection
Imports System.Runtime.InteropServices
Public Class F0_Prestamo
#Region "Variables Globales"
    Dim precio As DataTable
    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem
    Dim Bin As New MemoryStream
    Dim _inter As Integer = 0

    ''Modo de Pago
    Public TotalBs As Double = 0
    Public TotalSus As Double = 0
    Public TotalTarjeta As Double = 0
    Public TipoCambio As Double = 0
    Public TipoVenta As Integer = 1
    Public FechaVenc As Date
    Public Banco As Integer = 0
    Public Glosa As String
    Public CostoEnvio As Double = 0
    Public cambio As Double = 0
    Dim _CodCliente As Integer = 0
    Dim idPago As Integer = 0

    Dim Saldo As Double = 0
    Dim Total As Double = 0

    Dim Refinanciamiento As Boolean = False
    Dim CodRef As Integer = 0

    Dim cuotafija As Double = 0


    Dim ProductosImport As New DataTable

    Dim aux As Integer = 0

#End Region
#Region "METODOS PRIVADOS"

    Private Sub _IniciarTodo()


        L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, gs_NombreBD)
        'Me.WindowState = FormWindowState.Maximized
        _prAsignarPermisos()
        Me.Text = "REGISTRO DE PRESTAMOS"
        Dim blah As New Bitmap(New Bitmap(My.Resources.cobro), 20, 20)
        Dim ico As Icon = Icon.FromHandle(blah.GetHicon())
        Me.Icon = ico
        '_prCargarTablaPagos2(-1)
        _prCargarComboCliente(cbCliente)
        _prCargarComboCiclos(cbCicloPago)
        _prCargarMoneda(cbMoneda)
        _PMOInhabilitar()

        '_PMIniciarTodo()
        _prCargarPagos()

        SuperTabPrincipal.SelectedTabIndex = 0
    End Sub

    Private Sub _prCargarPagos()
        Dim dt As DataTable = L_fnCargarPrestamos()
        JGrM_Pagos.DataSource = dt
        JGrM_Pagos.RetrieveStructure()
        JGrM_Pagos.AlternatingColors = True

        'dar formato a las columnas
        'a.ygnumi, a.ygcod, a.ygdesc, a.ygpcv, a.ygfact, a.yghact, a.yguact
        With JGrM_Pagos.RootTable.Columns("numi")
            .Width = 100
            .Caption = "CODIGO"
            .Visible = True

        End With

        With JGrM_Pagos.RootTable.Columns("fecha")
            .Width = 100
            .Visible = True
            .Caption = "FECHA"
        End With

        With JGrM_Pagos.RootTable.Columns("pclie")
            .Caption = "DESCRIPCION"
            .Width = 200
            .Visible = False


        End With
        With JGrM_Pagos.RootTable.Columns("pcapi")
            .Width = 150
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            .Caption = "CAPITAL"
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far

        End With

        With JGrM_Pagos.RootTable.Columns("pcicp")
            .Width = 80
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
            .Caption = "ESTADO"

        End With
        With JGrM_Pagos.RootTable.Columns("ptiem")
            .Width = 80
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            '.CellStyle.TextAlignment = Janus.Windows.GridEX.format
            .Visible = False
            .FormatString = "0.00"
            .Caption = "MARGEN"
        End With
        With JGrM_Pagos.RootTable.Columns("pcuot")
            .Width = 80
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            .Caption = "CUOTAS"


        End With
        With JGrM_Pagos.RootTable.Columns("pmon")
            .Width = 50
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False



        End With
        With JGrM_Pagos.RootTable.Columns("pintE")
            .Width = 150
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            .Caption = "INTERES"
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far


        End With
        With JGrM_Pagos.RootTable.Columns("ptot")
            .Width = 200
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            .Caption = "TOTAL"
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far

        End With
        With JGrM_Pagos.RootTable.Columns("predo")
            .Width = 200
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
            .Caption = "INTERES"
        End With
        With JGrM_Pagos.RootTable.Columns("pest")
            .Width = 200
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
            .Caption = "INTERES"
        End With
        With JGrM_Pagos.RootTable.Columns("phor")
            .Width = 200
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
            .Caption = "INTERES"
        End With
        With JGrM_Pagos.RootTable.Columns("pusu")
            .Width = 200
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
            .Caption = "INTERES"
        End With
        With JGrM_Pagos.RootTable.Columns("pvfec")

            .Width = 200
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
            .Caption = "INTERES"
        End With
        With JGrM_Pagos.RootTable.Columns("pref")
            .Width = 200
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
            .Caption = "INTERES"
        End With
        With JGrM_Pagos.RootTable.Columns("pcodref")
            .Width = 200
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
            .Caption = "INTERES"
        End With
        With JGrM_Pagos.RootTable.Columns("nombre")
            .Width = 350
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            .Caption = "CLIENTE"
            .Position = 2
        End With
        With JGrM_Pagos.RootTable.Columns("psal")
            .Width = 100
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .Visible = True
            .Caption = "SALDO"
            .FormatString = "0.00"
        End With
        With JGrM_Pagos
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            '.FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .FilterMode = FilterMode.Automatic
        End With
    End Sub
    Private Sub _prCargarComboCliente(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo)
        Dim dt As New DataTable
        dt = L_fnListarClientes()
        Dim fila = dt.NewRow()
        fila(0) = 0

        fila(1) = "SELECCIONE CLIENTE"

        dt.Rows.InsertAt(fila, 0)
        'a.ylcod1 ,a.yldes1 
        With mCombo

            .DropDownList.Columns.Add("nombre").Width = cbCliente.Width
            .DropDownList.Columns("nombre").Caption = "DESCRIPCION"
            .ValueMember = "ydnumi"
            .DisplayMember = "nombre"
            .DataSource = dt
            .Refresh()
        End With
        If (CType(cbCliente.DataSource, DataTable).Rows.Count > 0) Then
            cbCliente.SelectedIndex = 0
        End If
    End Sub
    Private Sub _prCargarComboCiclos(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo)
        Dim dt As New DataTable
        dt = L_fnListarCiclos()
        Dim fila = dt.NewRow()
        fila(0) = 0
        fila(1) = "SELECCIONE CICLO DE PAGO"
        dt.Rows.InsertAt(fila, 0)
        'a.ylcod1 ,a.yldes1 
        With mCombo

            .DropDownList.Columns.Add("ycdes3").Width = cbCliente.Width
            .DropDownList.Columns("ycdes3").Caption = "DESCRIPCION"
            .ValueMember = "yccod3"
            .DisplayMember = "ycdes3"
            .DataSource = dt
            .Refresh()
        End With
        If (CType(cbCicloPago.DataSource, DataTable).Rows.Count > 0) Then
            cbCicloPago.Value = 1
        End If
    End Sub

    Private Sub _prCargarMoneda(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo)
        Dim dt As New DataTable
        dt = L_prLibreriaDetalleGeneral(7, 1)
        Dim fila = dt.NewRow()
        fila(0) = 0
        fila(1) = "SELECCIONE MONEDA"
        fila(2) = ""
        dt.Rows.InsertAt(fila, 0)
        'a.ylcod1 ,a.yldes1 
        With mCombo

            .DropDownList.Columns.Add("cndesc1").Width = cbMoneda.Width
            .DropDownList.Columns("cndesc1").Caption = "DESCRIPCION"
            .ValueMember = "cnnum"
            .DisplayMember = "cndesc1"
            .DataSource = dt
            .Refresh()
        End With
        If (CType(cbMoneda.DataSource, DataTable).Rows.Count > 0) Then
            cbMoneda.Value = 2
        End If
    End Sub

    Public Overrides Function _PMOGrabarRegistro() As Boolean
        Dim res As Boolean = GuardarNuevo()
        Return res
    End Function

    Public Overrides Sub _PMOGuardar()

        If _PMOValidarCampos() = False Then
            Exit Sub
        End If

        If _MNuevo Or (_MNuevo = False And _MModificar = False) Then
            If _PMOGrabarRegistro() = True Then
                'actualizar el grid de buscador
                _prCargarPagos()

                _PMOLimpiar()
                btnSalir.PerformClick()


            Else
                Exit Sub
            End If

        Else

            _PMOModificarRegistro()

            'actualizar el grid de buscador
            _prCargarPagos()

            'btnSalir.PerformClick()
        End If
        Refinanciamiento = False
    End Sub

    Public Overrides Sub _PMOFiltrar()
        'cargo el buscador
        _prCargarPagos()
        If JGrM_Buscador.RowCount > 0 Then
            _MPos = 0
            _PMOMostrarRegistro(_MPos)
        Else
            _PMOLimpiar()
            LblPaginacion.Text = "0/0"
        End If

    End Sub

    Public Overrides Function _PMOModificarRegistro() As Boolean
        If ValidarCampos() = False Then
            Return False
        End If
        Dim fecVen As String = CType(gr_detalle.DataSource, DataTable).Rows(gr_detalle.RowCount - 1).Item("fecha").ToString
        Dim res As Boolean = L_fnModificarPrestamo(CInt(tbCodigo.Text), _CodCliente, tbFecha.Value.ToString("dd/MM/yyyy"), tbCapital.Value, cbCicloPago.Value, CInt(tbTiempo.Text), CInt(tbCuotas.Text), cbMoneda.Value,
                                                tbInteres.Value, tbTotal.Value, tbRedondear.Value, gs_user, CType(gr_detalle.DataSource, DataTable), fecVen, IIf(Refinanciamiento, 1, 0), CodRef, Saldo)
        If res Then


            Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
            ToastNotification.Show(Me, "Préstamo nodificado con exito.".ToUpper,
                                      img, 2000,
                                      eToastGlowColor.Green,
                                      eToastPosition.TopCenter)

            _PMOLimpiar()
            _PMOInhabilitar()
            'btnAnterior.Enabled = True
            _prCargarPagos()

            btnAnterior.Enabled = True
            Return True


        Else
            Return False
        End If
    End Function

    Public Overrides Sub _PMOEliminarRegistro()

        If validarPagos() Then
            Dim ef = New Efecto
            ef.tipo = 2
            ef.Header = "¿Está seguro de anular el prestamo seleccionado?".ToUpper
            ef.Context = "mensaje principal".ToUpper
            ef.ShowDialog()
            Dim bandera As Boolean = False
            bandera = ef.band
            If (bandera = True) Then
                L_fnAnularPrestamos(CInt(tbCodigo.Text))
                Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
                ToastNotification.Show(Me, "El prestamo fue anulado correctamente".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
                _PMOLimpiar()
                '_PMOInhabilitar()
                _prCargarPagos()
            End If

        End If

    End Sub
    Public Overrides Function _PMOValidarCampos() As Boolean
        If Refinanciamiento Then
            If tbCapital.Value <= Saldo Then
                Dim img As Bitmap = New Bitmap(My.Resources.WARNING)
                ToastNotification.Show(Me, "Ingrese un monto mayor a Saldo del prestamo anterior como Capital. Saldo:" + Saldo.ToString + ".".ToUpper, img, 2000, eToastGlowColor.Green, eToastPosition.TopCenter)
                Return False
            End If
        End If
        Return True
    End Function

    Public Overrides Sub _PMOHabilitar()
        btnNuevo.Enabled = False
        btnGrabar2.Enabled = True
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        tbCapital.IsInputReadOnly = False
        tbCodigo.ReadOnly = False
        tbCuotas.ReadOnly = False
        tbFecha.Enabled = True
        tbInteres.IsInputReadOnly = False
        tbRedondear.IsInputReadOnly = False
        tbTiempo.ReadOnly = False
        tbTotal.IsInputReadOnly = False
        cbCicloPago.ReadOnly = False
        cbCliente.ReadOnly = False
        cbMoneda.ReadOnly = False

        btnAnterior.Enabled = False
        btnPrimero.Enabled = False
        btnSiguiente.Enabled = False
        btnUltimo.Enabled = False

        TextBoxX1.ReadOnly = False

        btnActualizar.Enabled = False

        ''  SuperTabItem1.Visible =True 
    End Sub
    Public Overrides Sub _PMOInhabilitar()
        btnNuevo.Enabled = True
        btnGrabar2.Enabled = False
        btnModificar.Enabled = True
        btnEliminar.Enabled = True
        tbCapital.IsInputReadOnly = True
        tbCodigo.ReadOnly = True
        tbCuotas.ReadOnly = True
        tbFecha.Enabled = False
        tbInteres.IsInputReadOnly = True
        tbRedondear.IsInputReadOnly = True
        tbTiempo.ReadOnly = True
        tbTotal.IsInputReadOnly = True
        cbCicloPago.ReadOnly = True
        cbCliente.ReadOnly = True
        cbMoneda.ReadOnly = True

        PanelNavegacion.Enabled = True
        btnAnterior.Enabled = True
        btnPrimero.Enabled = True
        btnSiguiente.Enabled = True
        btnUltimo.Enabled = True
        ' SuperTabItem1.Visible = False
        TextBoxX1.ReadOnly = True
        btnActualizar.Enabled = True
    End Sub


    Public Overrides Sub _PMOLimpiar()
        tbCapital.Value = 0
        tbCodigo.Clear()
        tbCuotas.Clear()

        tbFecha.Value = Date.Now
        tbInteres.Value = 0
        tbRedondear.Value = 0
        tbTiempo.Clear()
        tbTotal.Value = 0

        cbCicloPago.Value = 1
        cbCliente.Value = 0
        cbMoneda.Value = 2

        TextBoxX1.Clear()

        _CodCliente = 0
        CargarDetallePrestamo(-1)

        'GroupPanel4.Visible = False

        tbCodRef.Text = "0"
        tbPagado.Text = "0.00"
        tbSaldoAnt.Text = "0.00"

        Saldo = 0
    End Sub
    Public Overrides Function _PMOGetTablaBuscador() As DataTable
        'Dim dtBuscador As DataTable = L_fnCargarPrestamos()
        Return Nothing
    End Function

    Public Overrides Sub _PMOCargarBuscador()

    End Sub



    Public Overrides Function _PMOGetListEstructuraBuscador() As List(Of Modelo.Celda)
        Dim listEstCeldas As New List(Of Modelo.Celda)
        'a.ydnumi, a.ydcod, a.yddesc, a.ydzona, a.yddct, a.yddctnum, a.yddirec, a.ydtelf1, a.ydtelf2, a.ydcat,
        'a.ydest, a.ydlat, a.ydlongi, a.ydprconsu, a.ydobs, a.ydfnac, a.ydnomfac, a.ydtip, a.ydnit, a.ydfecing, a.ydultvent,
        'a.ydimg,
        'a.ydfact, a.ydhact, a.yduact

        listEstCeldas.Add(New Modelo.Celda("numi", True, "Codigo", 100))
        listEstCeldas.Add(New Modelo.Celda("fecha", True, "Fecha", 150, "dd/MM/yyyy"))
        listEstCeldas.Add(New Modelo.Celda("pclie", False))
        listEstCeldas.Add(New Modelo.Celda("pcapi", True, "Capital", 250, "0.00"))
        listEstCeldas.Add(New Modelo.Celda("pcicp", False))
        listEstCeldas.Add(New Modelo.Celda("ptiem", False))
        listEstCeldas.Add(New Modelo.Celda("pcuot", False))
        listEstCeldas.Add(New Modelo.Celda("pmon", False))
        listEstCeldas.Add(New Modelo.Celda("pinte", True, "Interes", 250, "0.00"))
        listEstCeldas.Add(New Modelo.Celda("ptot", True, "Total", 250, "0.00"))
        listEstCeldas.Add(New Modelo.Celda("predo", False))
        listEstCeldas.Add(New Modelo.Celda("phor", False))
        listEstCeldas.Add(New Modelo.Celda("pusu", False))
        listEstCeldas.Add(New Modelo.Celda("pref", False))
        listEstCeldas.Add(New Modelo.Celda("pcodref", False))
        listEstCeldas.Add(New Modelo.Celda("nombre", True, "Cliente", 350))
        Return listEstCeldas

        'GrM_Pagos.FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
    End Function

    Public Overrides Sub _PMOMostrarRegistro(_N As Integer)
        If JGrM_Pagos.RowCount > 0 Then
            'JGrM_Pagos.Row = _MPos
            'a.ydnumi, a.ydcod, a.yddesc, a.ydzona, a.yddct, a.yddctnum, a.yddirec, a.ydtelf1, a.ydtelf2, a.ydcat,
            'a.ydest, a.ydlat, a.ydlongi, a.ydprconsu, a.ydobs, a.ydfnac, a.ydnomfac, a.ydtip, a.ydnit, a.ydfecing, a.ydultvent,
            'a.ydimg,
            'a.ydfact, a.ydhact, a.yduact ,a.ydrut ,visita
            Dim dt As DataTable = CType(JGrM_Pagos.DataSource, DataTable)

            With JGrM_Pagos
                tbCodigo.Text = .GetValue("numi").ToString
                tbCapital.Value = .GetValue("pcapi").ToString
                tbCuotas.Text = .GetValue("pcuot").ToString
                tbFecha.Value = .GetValue("fecha").ToString
                tbInteres.Value = .GetValue("pinte")
                tbRedondear.Value = .GetValue("predo").ToString
                tbTiempo.Text = .GetValue("ptiem")
                tbTotal.Value = .GetValue("ptot").ToString
                cbCicloPago.Value = .GetValue("pcicp")
                _CodCliente = .GetValue("pclie")
                cbMoneda.Value = .GetValue("pmon")
                TextBoxX1.Text = .GetValue("nombre")
                CargarDetallePrestamo(.GetValue("numi"))
                Dim saldo As DataTable = ObtenerSaldoRefinanciar(CInt(.GetValue("numi").ToString))
                Dim sal As Double = saldo.Rows(0).Item("refinanciado")
                If sal = 0 Then
                    tbSaldoAnt.Text = saldo.Rows(0).Item("total").ToString
                Else
                    tbSaldoAnt.Text = saldo.Rows(0).Item("refinanciado").ToString
                End If

                tbPagado.Text = saldo.Rows(0).Item("pagado").ToString
                If .GetValue("pref") = 1 Then
                    'GroupPanel4.Visible = True
                    tbCodRef.Text = .GetValue("pcodref").ToString

                    LabelX14.Visible = True
                    tbCodRef.Visible = True

                    LabelX8.Location = New Point(39, 71)
                    tbPagado.Location = New Point(203, 76)

                    LabelX15.Location = New Point(39, 125)
                    tbSaldoAnt.Location = New Point(203, 121)

                    btRefinanciar.Enabled = False

                    btnModificar.Enabled = False
                Else
                    LabelX14.Visible = False
                    tbCodRef.Visible = False

                    LabelX8.Location = New Point(39, 23)
                    tbPagado.Location = New Point(203, 29)

                    LabelX15.Location = New Point(39, 72)
                    tbSaldoAnt.Location = New Point(203, 78)
                    'GroupPanel4.Visible = False
                    btRefinanciar.Enabled = True
                    btnModificar.Enabled = True
                End If
            End With

            LblPaginacion.Text = Str(_MPos + 1) + "/" + JGrM_Pagos.RowCount.ToString
        End If
    End Sub
    Private Sub cargarDetallePagos(numi As Integer)
        Dim dt As DataTable = TraerPagos(numi)

        '_prCargarIconDelete(dt)
        gr_detalle.DataSource = dt
        gr_detalle.RetrieveStructure()
        gr_detalle.AlternatingColors = True

        With gr_detalle.RootTable.Columns("tcnumi")
            .Width = 100
            .Visible = False
            .Caption = "ID"
        End With
        With gr_detalle.RootTable.Columns("NroDoc")
            .Width = 150
            .Visible = True
            .Caption = "NRO. DOC."
        End With
        With gr_detalle.RootTable.Columns("factura")
            .Width = 150
            .Visible = True
            .Caption = "FACTURA"
        End With
        With gr_detalle.RootTable.Columns("tctv1numi")
            .Width = 250
            .Visible = False
        End With
        With gr_detalle.RootTable.Columns("tcty4clie")
            .Width = 250
            .Visible = False
        End With
        With gr_detalle.RootTable.Columns("cliente")
            .Width = 250
            .Visible = True
            .Caption = "CLIENTE"
        End With
        With gr_detalle.RootTable.Columns("tcty4vend")
            .Width = 100
            .Visible = False
        End With
        With gr_detalle.RootTable.Columns("vendedor")
            .Width = 250
            .Visible = True
            .Caption = "VENDEDOR"
        End With
        With gr_detalle.RootTable.Columns("tcfdoc")
            .Width = 100
            .Visible = True
            .Caption = "FECHA"
            .FormatString = "dd/MM/yyyy"
        End With
        With gr_detalle.RootTable.Columns("tcfvencre")
            .Width = 100
            .Visible = True
            .Caption = "VENCIMIENTO"
            .FormatString = "dd/MM/yyyy"
        End With
        With gr_detalle.RootTable.Columns("totalfactura")
            .Width = 100
            .Visible = True
            .Caption = "TOTAL"
            .FormatString = "0.00"
        End With
        With gr_detalle.RootTable.Columns("pendiente")
            .Width = 100
            .Visible = True
            .Caption = "PENDIENETE"
            .FormatString = "0.00"
        End With
        With gr_detalle.RootTable.Columns("pagoAc")
            .Width = 100
            .Visible = True
            .Caption = "PAGO AC."
            .FormatString = "0.00"
        End With
        With gr_detalle.RootTable.Columns("Pagar")
            .Width = 100
            .Visible = True
            .Caption = "Pagar"
        End With
        With gr_detalle.RootTable.Columns("pendiente2")
            .Width = 100
            .Visible = False
            .Caption = "PAGO AC."
            .FormatString = "0.00"
        End With
        With gr_detalle
            .ColumnAutoResize = True
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007


            .VisualStyle = VisualStyle.Office2007


            '.RowHeaders = InheritableBoolean.True
            '.TotalRow = InheritableBoolean.True
            '.TotalRowFormatStyle.BackColor = Color.Gold
            '.TotalRowPosition = TotalRowPosition.BottomFixed
        End With
    End Sub

    Private Sub _Limpiar()



        '_prAddDetalle()



    End Sub

    Private Function validarPagos() As Boolean
        'If CDbl(tbPagado.Text) > 0 Then
        '    Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
        '    ToastNotification.Show(Me, "El prestamo tiene pagos realizados, no se puede anular".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
        '    Return False
        'End If
        If btRefinanciar.Enabled = False Then
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "El prestamo esta refinanciado, no se puede anular".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            Return False
        End If
        Return True
    End Function
    Private Sub _prAsignarPermisos()

        Dim dtRolUsu As DataTable = L_prRolDetalleGeneral(gi_userRol, _nameButton)

        Dim show As Boolean = dtRolUsu.Rows(0).Item("ycshow")
        Dim add As Boolean = dtRolUsu.Rows(0).Item("ycadd")
        Dim modif As Boolean = dtRolUsu.Rows(0).Item("ycmod")
        Dim del As Boolean = dtRolUsu.Rows(0).Item("ycdel")

        If add = False Then
            btnNuevo.Visible = False
        End If
        If modif = False Then
            btnModificar.Visible = False
        End If
        If del = False Then
            btnEliminar.Visible = False
        End If
    End Sub
    Public Sub _prAplicarCondiccionJanus()
        Dim fc As GridEXFormatCondition
        fc = New GridEXFormatCondition(gr_detalle.RootTable.Columns("pendiente"), ConditionOperator.Equal, 0)
        fc.FormatStyle.BackColor = Color.Green
        gr_detalle.RootTable.FormatConditions.Add(fc)
    End Sub


    Private Sub F0_Cobrar_Cliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _IniciarTodo()
    End Sub

    Private Sub tbCodigo_KeyDown(sender As Object, e As KeyEventArgs)
        'If (_fnAccesible()) Then
        If e.KeyData = Keys.Control + Keys.Enter Then
            _Limpiar()
            Dim dt As DataTable

            dt = L_fnListarClientesTodos()
            '              a.ydnumi, a.ydcod, a.yddesc, a.yddctnum, a.yddirec
            ',a.ydtelf1 ,a.ydfnac 

            Dim listEstCeldas As New List(Of Modelo.Celda)
            listEstCeldas.Add(New Modelo.Celda("ydnumi,", False, "ID", 50))
            listEstCeldas.Add(New Modelo.Celda("codigo,", False, "ID", 50))
            listEstCeldas.Add(New Modelo.Celda("ydcod", True, "CODIGO", 80))
            listEstCeldas.Add(New Modelo.Celda("ydrazonsocial", True, "RAZON SOCIAL", 200))
            listEstCeldas.Add(New Modelo.Celda("yddesc", True, "NOMBRE CLIENTE", 200))
            listEstCeldas.Add(New Modelo.Celda("yddctnum", True, "N. Documento".ToUpper, 150))
            listEstCeldas.Add(New Modelo.Celda("yddirec", True, "DIRECCION", 220))
            listEstCeldas.Add(New Modelo.Celda("ydtelf1", True, "Telefono".ToUpper, 200))
            listEstCeldas.Add(New Modelo.Celda("ydfnac", False, "F.Nacimiento".ToUpper, 150, "MM/dd,YYYY"))
            listEstCeldas.Add(New Modelo.Celda("ydnumivend,", False, "ID", 50))
            listEstCeldas.Add(New Modelo.Celda("vendedor,", False, "ID", 50))
            listEstCeldas.Add(New Modelo.Celda("yddias", False, "CRED", 50))
            Dim ef = New Efecto
            ef.tipo = 3
            ef.dt = dt
            ef.SeleclCol = 2
            ef.listEstCeldas = listEstCeldas
            ef.alto = 50
            ef.ancho = 350
            'ef.NameLabel = "CLIENTE :"
            'ef.NamelColumna = "yddesc"
            ef.Context = "Seleccione Cliente".ToUpper
            ef.ShowDialog()
            Dim bandera As Boolean = False
            bandera = ef.band
            If (bandera = True) Then
                Try
                    Dim Row As Janus.Windows.GridEX.GridEXRow = ef.Row
                    _CodCliente = Row.Cells("ydnumi").Value

                Catch ex As Exception

                End Try
            Else
                _CodCliente = 0

                Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
                ToastNotification.Show(Me, "Los Datos Del Cliente No Existe en el sistema".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            End If

        End If
        'End If
    End Sub

    Private Sub _prMostrarRegistro(N As Integer)
        With JGrM_Pagos
            tbCodigo.Text = .GetValue("numi").ToString
            tbCapital.Value = .GetValue("pcapi").ToString
            tbCuotas.Text = .GetValue("pcuot").ToString
            tbFecha.Value = .GetValue("fecha").ToString
            tbInteres.Value = .GetValue("pinte")
            tbRedondear.Value = .GetValue("predo").ToString
            tbTiempo.Text = .GetValue("ptiem")
            tbTotal.Value = .GetValue("ptot").ToString
            cbCicloPago.Value = .GetValue("pcicp")
            _CodCliente = .GetValue("pclie")
            cbMoneda.Value = .GetValue("pmon")
            TextBoxX1.Text = .GetValue("nombre")
            tbDeposito.Value = .GetValue("pcapi") - .GetValue("psal")
            CargarDetallePrestamo(.GetValue("numi"))
            Dim saldo As DataTable = ObtenerSaldoRefinanciar(CInt(.GetValue("numi").ToString))
            Dim sal As Double = saldo.Rows(0).Item("refinanciado")
            If sal = 0 Then
                tbSaldoAnt.Text = Format(saldo.Rows(0).Item("total"), "0.00").ToString
            Else
                tbSaldoAnt.Text = Format(saldo.Rows(0).Item("refinanciado"), "0.00").ToString
            End If

            tbPagado.Text = Format(saldo.Rows(0).Item("pagado"), "0.00").ToString
            If .GetValue("pref") = 1 Then
                'GroupPanel4.Visible = True
                tbCodRef.Text = .GetValue("pcodref").ToString

                LabelX14.Visible = True
                tbCodRef.Visible = True

                LabelX8.Location = New Point(39, 71)
                tbPagado.Location = New Point(203, 76)

                LabelX15.Location = New Point(39, 125)
                tbSaldoAnt.Location = New Point(203, 121)

                btRefinanciar.Enabled = False
                btnModificar.Enabled = False
            Else
                LabelX14.Visible = False
                tbCodRef.Visible = False

                LabelX8.Location = New Point(39, 23)
                tbPagado.Location = New Point(203, 29)

                LabelX15.Location = New Point(39, 72)
                tbSaldoAnt.Location = New Point(203, 78)
                'GroupPanel4.Visible = False
                btRefinanciar.Enabled = True
                btnModificar.Enabled = True
            End If
        End With

        LblPaginacion.Text = (JGrM_Pagos.Row + 1).ToString + "/" + JGrM_Pagos.RowCount.ToString.ToString
        'aux = 0
    End Sub

    Private Sub gr_detalle_EditingCell(sender As Object, e As EditingCellEventArgs) Handles gr_detalle.EditingCell

        e.Cancel = True

    End Sub





    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If btnGrabar2.Enabled = True Then
            _PMOLimpiar()
            _PMOInhabilitar()
            _prCargarPagos()
            '_PMIniciarTodo()
        Else
            _modulo.Select()
            Me.Close()
        End If

        '_tab.Close()
    End Sub



#End Region

#Region "Eventos Formulario"
    Sub _prInterpretarDatosCobranza(ByRef dt As DataTable, ByRef bandera As Boolean)


        '       numidetalle, NroDoc, factura, numiCredito, numiCobranza, A.tctv1numi
        ',a.tcty4clie ,cliente,detalle.tdfechaPago, PagoAc, NumeroRecibo, DescBanco, banco, detalle.tdnrocheque,
        'img,estado,pendiente
        Dim Bin As New MemoryStream
        Dim img As New Bitmap(My.Resources.delete, 28, 28)
        img.Save(Bin, Imaging.ImageFormat.Png)
        Dim dtcobro As DataTable = CType(gr_detalle.DataSource, DataTable)
        For i As Integer = 0 To dtcobro.Rows.Count - 1 Step 1
            Dim pago As Double = dtcobro.Rows(i).Item("PagoAc")
            Dim estado As Boolean = dtcobro.Rows(i).Item("Pagar")
            If (estado = True) Then
                '             td.tdtv12numi ,@tenumi ,td.tdnrodoc ,@newFecha ,td.tdmonto ,td.tdnrorecibo ,td.tdty3banco,
                'td.tdnrocheque, @newFecha  ,@newHora  ,@teuact

                '              a.tcnumi, NroDoc,as factura, a.tctv1numi, a.tcty4clie, cliente, a.tcty4vend, vendedor, a.tcfdoc
                ',a.tcfvencre,totalfactura, pendiente, PagoAc, Pagar
                If (pago > 0) Then
                    dt.Rows.Add(0, dtcobro.Rows(i).Item("tcnumi"), 0, dtcobro.Rows(i).Item("NroDoc"),
                                            Now.Date, pago, 0, 1, 0, Now.Date,
                                            "", "", Bin.ToArray, 0)
                    bandera = True
                End If

            End If

        Next
    End Sub


    Private Sub ButtonX1_Click_1(sender As Object, e As EventArgs)
        Dim numi As String = ""
        Dim img2 As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
        If (CType(gr_detalle.DataSource, DataTable).Rows.Count <= 0) Then
            ToastNotification.Show(Me, "No existen datos validos".ToUpper, img2, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            Return

        End If
        Dim dtCobro As DataTable = L_fnCobranzasObtenerLosPagos(-1)
        Dim bandera As Boolean = False
        Dim Notas As String = ""
        _prInterpretarDatosCobranza(dtCobro, bandera)
        If (bandera = False) Then
            ToastNotification.Show(Me, "Seleccione un detalle de la lista de pendientes".ToUpper, img2, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            Return
        End If

    End Sub

    Private Function _fnIsALl()
        Dim dt As DataTable = CType(gr_detalle.DataSource, DataTable)
        For i As Integer = 0 To dt.Rows.Count - 1 Step 1

            If (CType(gr_detalle.DataSource, DataTable).Rows(i).Item("Pagar") = False) Then
                Return False
            End If



        Next
        Return True
    End Function


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        _inter = _inter + 1
        If _inter = 1 Then
            Me.WindowState = FormWindowState.Normal
        Else
            Me.Opacity = 100
            Timer1.Enabled = False
        End If
    End Sub
    Private Sub _prModificarMontos(ByRef tabla As DataTable)
        tabla.Rows.Add(0, TotalBs, TotalSus, TotalTarjeta, TipoCambio, 2)
    End Sub





    Private Sub tbGlosa_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub JGrM_Pagos_SelectionChanged(sender As Object, e As EventArgs) Handles JGrM_Pagos.SelectionChanged
        If (JGrM_Pagos.RowCount >= 0 And JGrM_Pagos.Row >= 0) Then
            'If aux = 1 Then
            '    If JGrM_Pagos.Row > 0 Then
            '        aux = 0
            '        JGrM_Pagos.Row = JGrM_Pagos.Row - 1
            '    End If
            'Else
            _prMostrarRegistro(JGrM_Pagos.Row)
            ' End If

        End If
    End Sub

    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        Dim _pos As Integer = JGrM_Pagos.Row
        If JGrM_Pagos.RowCount > 0 Then
            _pos = JGrM_Pagos.RowCount - 1
            ''  _prMostrarRegistro(_pos)
            JGrM_Pagos.Row = _pos
        End If
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Dim _pos As Integer = JGrM_Pagos.Row
        If _pos < JGrM_Pagos.RowCount - 1 And _pos >= 0 Then
            _pos = JGrM_Pagos.Row + 1
            '' _prMostrarRegistro(_pos)
            JGrM_Pagos.Row = _pos
        End If
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Dim _MPos As Integer = JGrM_Pagos.Row
        If _MPos > 0 And JGrM_Pagos.RowCount > 0 Then
            _MPos = _MPos - 1
            ''  _prMostrarRegistro(_MPos)
            JGrM_Pagos.Row = _MPos
        End If
    End Sub

    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        Dim _MPos As Integer
        If JGrM_Pagos.RowCount > 0 Then
            _MPos = 0
            ''   _prMostrarRegistro(_MPos)
            JGrM_Pagos.Row = _MPos
        End If
    End Sub

    'Private Sub GenerarReporte()
    '    Dim dt As DataTable = CType(gr_detalle.DataSource, DataTable)
    '    Dim _TotalLi As Decimal
    '    Dim _Literal, _TotalDecimal, _TotalDecimal2 As String

    '    _TotalLi = CDbl(tbMonto.Text)
    '    _TotalDecimal = _TotalLi - Math.Truncate(_TotalLi)
    '    _TotalDecimal2 = CDbl(_TotalDecimal) * 100


    '    _Literal = Facturacion.ConvertirLiteral.A_fnConvertirLiteral(CDbl(_TotalLi) - CDbl(_TotalDecimal)) + "  " + IIf(_TotalDecimal2.Equals("0"), "00", _TotalDecimal2) + "/100 Bolivianos"

    '    Dim usuario As String

    '    If (gi_NumiVenedor > 0) Then

    '        Dim dt2 As DataTable
    '        dt2 = L_fnListarEmpleado()
    '        For i As Integer = 0 To dt.Rows.Count - 1 Step 1
    '            If (dt2.Rows(i).Item("ydnumi") = gi_NumiVenedor) Then

    '                usuario = dt2.Rows(i).Item("yddesc")
    '            End If

    '        Next

    '    End If
    '    P_Global.Visualizador = New Visualizador

    '    'Dim objrep As New R_NotaPagoCredito
    '    '' GenerarNro(_dt)
    '    ''objrep.SetDataSource(Dt1Kardex)

    '    'objrep.SetDataSource(dt)
    '    'objrep.SetParameterValue("literal", _Literal)

    '    'objrep.SetParameterValue("glosa", tbGlosa.Text)
    '    'objrep.SetParameterValue("fecha", tbFechaVenta.Value.ToString("dd/MM/yyyy"))
    '    'objrep.SetParameterValue("numi", idPago)
    '    'objrep.SetParameterValue("usuario", IIf(usuario = String.Empty, gs_user, usuario))
    '    'P_Global.Visualizador.CrGeneral.ReportSource = objrep 'Comentar
    '    'P_Global.Visualizador.ShowDialog() 'Comentar
    '    'P_Global.Visualizador.BringToFront() 'Comentar

    'End Sub

    Private Sub JGrM_Pagos_EditingCell(sender As Object, e As EditingCellEventArgs)
        e.Cancel = True
    End Sub

    Private Sub JGrM_Pagos_DoubleClick(sender As Object, e As EventArgs) Handles JGrM_Pagos.DoubleClick
        SuperTabPrincipal.SelectedTabIndex = 0
    End Sub

    Private Function accesibleCalculo() As Boolean
        If btnNuevo.Enabled = True Then
            Return False
        End If
        If tbCapital.Value <= 0 Then
            Return False
        End If
        If tbInteres.Value <= 0 Then
            Return False
        End If
        If tbTiempo.Text = String.Empty And tbTiempo.Text = "" Then
            Return False
        End If
        If cbCicloPago.SelectedIndex < 0 Then
            Return False
        End If
        Return True
    End Function

    Private Sub CalcularTotal()

        'Dim Interes As Double = CDbl(tbCapital.Value) * CDbl(tbInteres.Value) / 100 * CDbl(tbTiempo.Text)
        'Dim Total As Double = CDbl(tbCapital.Value) + Interes
        'tbTotal.Value = Total.ToString("0.00")

        Dim factorInt As Double = 1 + (tbInteres.Value / 100)
        Dim varX As Double = factorInt ^ (CInt(tbTiempo.Text) * -1)
        Dim cuotafija As Double = CDbl(tbCapital.Value * (tbInteres.Value / 100) / (1 - varX))
        'cuotafija = Format(cuotafija, "0.00")

        tbTotal.Value = cuotafija * CInt(tbTiempo.Text)

    End Sub
    Private Sub CalcularCuotas()
        Dim Cuota As Integer = CInt(tbTiempo.Text) / cbCicloPago.Value
        tbCuotas.Text = Cuota
        Dim pago As Double = CDbl(tbTotal.Value) / Cuota
        pago = pago.ToString("0.00")
        tbRedondear.Value = pago
    End Sub

    Private Sub tbTiempo_TextChanged(sender As Object, e As EventArgs) Handles tbTiempo.TextChanged
        If accesibleCalculo() Then
            CalcularTotal()
            CalcularCuotas()
        End If
    End Sub



    Private Function AccesibleCuota() As Boolean
        If btnNuevo.Enabled = True And btnGrabar2.Enabled = True Then
            Return False
        End If
        If tbCapital.Value <= 0 Then
            Return False
        End If
        If tbInteres.Value <= 0 Then
            Return False
        End If
        If cbCicloPago.SelectedIndex < 0 Then
            Return False
        End If
        If tbCuotas.Text = String.Empty And tbCuotas.Text = "" Then
            Return False
        End If
        Return True
    End Function
    Private Sub CalcularPago()
        Dim pago As Double = (CDbl(tbTotal.Value) / CInt(tbCuotas.Text)).ToString("0.00")
        tbRedondear.Value = pago
    End Sub
    Private Sub tbCuotas_TextChanged(sender As Object, e As EventArgs) Handles tbCuotas.TextChanged
        If AccesibleCuota() Then
            CalcularPago()
            CargarPagos2()
        End If
    End Sub

    Private Sub tbCapital_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbInteres_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbCapital_ValueChanged(sender As Object, e As EventArgs) Handles tbCapital.ValueChanged
        tbDeposito.Value = tbCapital.Value - Saldo
        If accesibleCalculo() Then
            Dim factorInt As Double = 1 + (tbInteres.Value / 100)
            Dim varX As Double = factorInt ^ (CInt(tbTiempo.Text) * -1)
            cuotafija = CDbl(tbCapital.Value * (tbInteres.Value / 100) / (1 - varX))
            CalcularTotal()
            CalcularCuotas()
            CargarPagos2()
        End If

    End Sub

    Private Sub tbInteres_ValueChanged(sender As Object, e As EventArgs) Handles tbInteres.ValueChanged
        If accesibleCalculo() Then
            Dim factorInt As Double = 1 + (tbInteres.Value / 100)
            Dim varX As Double = factorInt ^ (CInt(tbTiempo.Text) * -1)
            cuotafija = CDbl(tbCapital.Value * (tbInteres.Value / 100) / (1 - varX))
            CalcularTotal()
            CalcularCuotas()
            CargarPagos2()
        End If
    End Sub
    Private Sub CargarDetallePrestamo(numi As Integer)
        Dim dt As DataTable = L_fnCargarPagos(numi)
        gr_detalle.DataSource = dt
        gr_detalle.RetrieveStructure()
        gr_detalle.AlternatingColors = True

        With gr_detalle.RootTable.Columns("cuota")
            .Width = 100
            .Visible = True
            .Caption = "Nº CUOTA"
            .TextAlignment = TextAlignment.Far
        End With
        With gr_detalle.RootTable.Columns("fecha")
            .Width = 150
            .Visible = True
            .Caption = "FECHA"
            .FormatString = "dd/MM/yyyy"
        End With
        With gr_detalle.RootTable.Columns("tcfdoc")
            .Width = 200
            .Visible = True
            .Caption = "FECHA PAGADA"
            .FormatString = "dd/MM/yyyy"
        End With
        With gr_detalle.RootTable.Columns("capital")
            .Width = 200
            .Visible = True
            .Caption = "CAPITAL"
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
            .AggregateFunction = AggregateFunction.Sum
            .TotalFormatString = "0.00"
        End With
        With gr_detalle.RootTable.Columns("interes")
            .Width = 200
            .Visible = True
            .Caption = "INTERES"
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
            .AggregateFunction = AggregateFunction.Sum
            .TotalFormatString = "0.00"
        End With
        With gr_detalle.RootTable.Columns("monto")
            .Width = 200
            .Visible = True
            .Caption = "MONTO"
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
            .AggregateFunction = AggregateFunction.Sum
            .TotalFormatString = "0.00"
        End With
        With gr_detalle.RootTable.Columns("estado")
            .Width = 100
            .Visible = True
            .Caption = "ESTADO"
        End With
        With gr_detalle.RootTable.Columns("est")
            .Width = 100
            .Visible = False
            .Caption = "ESTADO"
        End With
        With gr_detalle
            .ColumnAutoResize = True
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007


            .VisualStyle = VisualStyle.Office2007


            .RowHeaders = InheritableBoolean.True
            .TotalRow = InheritableBoolean.True
            .TotalRowFormatStyle.BackColor = Color.Gold
            .TotalRowPosition = TotalRowPosition.BottomFixed
        End With
        P_prPonerCodicion()
    End Sub

    Private Sub P_prPonerCodicion()
        'poner color a la fila de acuerdo a la condicion 
        Dim fc As GridEXFormatCondition
        fc = New GridEXFormatCondition(gr_detalle.RootTable.Columns("est"), ConditionOperator.Equal, 1)
        fc.FormatStyle.BackColor = Color.LightGreen
        fc.FormatStyle.ForeColor = Color.Black
        gr_detalle.RootTable.FormatConditions.Add(fc)


        Dim fc1 As GridEXFormatCondition
        fc1 = New GridEXFormatCondition(gr_detalle.RootTable.Columns("est"), ConditionOperator.Equal, 2)
        fc1.FormatStyle.BackColor = Color.Gray
        fc1.FormatStyle.ForeColor = Color.White


        gr_detalle.RootTable.FormatConditions.Add(fc1)


        Dim fc2 As GridEXFormatCondition
        fc2 = New GridEXFormatCondition(gr_detalle.RootTable.Columns("est"), ConditionOperator.Equal, 0)
        fc2.FormatStyle.BackColor = Color.LightYellow
        fc2.FormatStyle.ForeColor = Color.Black


        gr_detalle.RootTable.FormatConditions.Add(fc2)


    End Sub
    Private Sub CargarPagos2()
        Dim dt As DataTable = L_fnCargarPagos(-1)
        Dim monto As Double = CDbl(tbTotal.Value)
        Dim montoAux As Double
        Dim dia As Integer = 0


        'Dim fecha As Date = tbFecha.Value.ToString("dd/MM/yyyy")
        Dim fecha As Date = DateAdd(DateInterval.Month, 1, tbFecha.Value).ToString("dd/MM/yyyy")
        Dim Mes As Integer = DatePart("m", fecha)
        Dim Anio As Integer = DatePart("yyyy", fecha)
        Dim cuotaActual As Double
        Dim saldo As Double = tbCapital.Value
        fecha = DateSerial(Anio, Mes, 1)

        fecha = fecha.ToString("dd/MM/yyyy")


        For i As Integer = 0 To CInt(tbCuotas.Text) - 1 Step 1

            cuotaActual = cuotafija - (saldo * tbInteres.Value / 100)
            montoAux = cuotafija - cuotaActual
            Dim fec As Date = DateAdd(DateInterval.Month, (cbCicloPago.Value) * (dia), fecha).ToString("dd/MM/yyyy")
            'Dim dia As String = Format(Day, fec)
            'If fec.DayOfWeek <> DayOfWeek.Sunday Then
            Dim row As DataRow = dt.NewRow()

            row("cuota") = i + 1
            row("fecha") = DateAdd(DateInterval.Month, (cbCicloPago.Value) * (dia), fecha).ToString("dd/MM/yyyy")
            If saldo - cuotaActual >= 0 Then
                'Dim cuotaActual2 As Double = Format(cuotaActual, "0.00")
                row("capital") = cuotaActual
                'Dim montoaux2 As Double = Format(monto, "0.00")
                row("interes") = montoAux
                Dim cuotafija2 As Double = Format(cuotafija, "0.00")
                row("monto") = cuotafija
                saldo = saldo - cuotaActual

            Else
                'Dim cuotaActual2 As Double = Format(cuotaActual, "0.00")

                row("capital") = saldo 'cuotaActual
                'Dim montoaux2 As Double = Format(monto, "0.00")
                row("interes") = cuotafija - saldo 'montoAux
                'Dim cuotafija2 As Double = Format(cuotafija, "0.00")
                row("monto") = cuotafija
                monto = 0
            End If
            row("estado") = "PENDIENTE"
            dt.Rows.Add(row)
            If monto = 0 Then
                Exit For
            End If

            'Else
            '    i = i - 1
            'End If
            dia = dia + 1
        Next

        gr_detalle.DataSource = dt
        gr_detalle.RetrieveStructure()
        gr_detalle.AlternatingColors = True

        With gr_detalle.RootTable.Columns("cuota")
            .Width = 100
            .Visible = True
            .Caption = "Nº CUOTA"
            .TextAlignment = TextAlignment.Far
        End With
        With gr_detalle.RootTable.Columns("fecha")
            .Width = 150
            .Visible = True
            .Caption = "FECHA"
            .FormatString = "dd/MM/yyyy"
        End With
        With gr_detalle.RootTable.Columns("capital")
            .Width = 200
            .Visible = True
            .Caption = "CAPITAL"
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
        End With
        With gr_detalle.RootTable.Columns("interes")
            .Width = 200
            .Visible = True
            .Caption = "INTERES"
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
        End With
        With gr_detalle.RootTable.Columns("monto")
            .Width = 200
            .Visible = True
            .Caption = "MONTO"
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
        End With
        With gr_detalle.RootTable.Columns("estado")
            .Width = 100
            .Visible = True
            .Caption = "ESTADO"
        End With
        With gr_detalle.RootTable.Columns("est")
            .Width = 100
            .Visible = False
            .Caption = "ESTADO"
        End With
        With gr_detalle
            .ColumnAutoResize = True
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007


            .VisualStyle = VisualStyle.Office2007


            '.RowHeaders = InheritableBoolean.True
            '.TotalRow = InheritableBoolean.True
            '.TotalRowFormatStyle.BackColor = Color.Gold
            '.TotalRowPosition = TotalRowPosition.BottomFixed
        End With

        If gr_detalle.RowCount < CInt(tbCuotas.Text) Then
            Dim couta As Integer = gr_detalle.RowCount
            tbCuotas.Text = couta.ToString
        End If
    End Sub
    Private Sub CargarPagos()
        Dim dt As DataTable = L_fnCargarPagos(-1)
        Dim monto As Double = CDbl(tbTotal.Value)
        Dim montoAux As Double = CDbl(tbCapital.Value) / CInt(tbCuotas.Text)
        Dim dia As Integer = 1
        'Dim fecha As Date = tbFecha.Value.ToString("dd/MM/yyyy")
        Dim fecha As Date = DateAdd(DateInterval.Month, 1, tbFecha.Value).ToString("dd/MM/yyyy")
        Dim Mes As Integer = DatePart("m", fecha)
        Dim Anio As Integer = DatePart("yyyy", fecha)

        fecha = DateSerial(Anio, Mes, 1)

        fecha = fecha.ToString("dd/MM/yyyy")
        fecha = tbFecha.Value.ToString("dd/MM/yyyy")
        For i As Integer = 0 To CInt(tbCuotas.Text) - 1 Step 1


            Dim fec As Date = DateAdd(DateInterval.Day, (cbCicloPago.Value) * (dia), fecha).ToString("dd/MM/yyyy")
            'Dim dia As String = Format(Day, fec)
            'If fec.DayOfWeek <> DayOfWeek.Sunday Then
            Dim row As DataRow = dt.NewRow()

            row("cuota") = i + 1
            row("fecha") = DateAdd(DateInterval.Day, (cbCicloPago.Value) * (dia), fecha).ToString("dd/MM/yyyy")
            If monto - CDbl(tbRedondear.Value) >= 0 Then
                row("capital") = montoAux
                row("interes") = CDbl(tbRedondear.Value) - montoAux
                row("monto") = CDbl(tbRedondear.Value)
                monto = monto - CDbl(tbRedondear.Value)

            Else
                row("monto") = monto
                monto = 0
            End If
            row("estado") = "PENDIENTE"
            dt.Rows.Add(row)
            If monto = 0 Then
                Exit For
            End If

            'Else
            '    i = i - 1
            'End If
            dia = dia + 1
        Next

        gr_detalle.DataSource = dt
        gr_detalle.RetrieveStructure()
        gr_detalle.AlternatingColors = True

        With gr_detalle.RootTable.Columns("cuota")
            .Width = 100
            .Visible = True
            .Caption = "Nº CUOTA"
            .TextAlignment = TextAlignment.Far
        End With
        With gr_detalle.RootTable.Columns("fecha")
            .Width = 150
            .Visible = True
            .Caption = "FECHA"
            .FormatString = "dd/MM/yyyy"
        End With
        With gr_detalle.RootTable.Columns("capital")
            .Width = 200
            .Visible = True
            .Caption = "CAPITAL"
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
        End With
        With gr_detalle.RootTable.Columns("interes")
            .Width = 200
            .Visible = True
            .Caption = "INTERES"
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
        End With
        With gr_detalle.RootTable.Columns("monto")
            .Width = 200
            .Visible = True
            .Caption = "MONTO"
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
        End With
        With gr_detalle.RootTable.Columns("estado")
            .Width = 100
            .Visible = True
            .Caption = "ESTADO"
        End With
        With gr_detalle.RootTable.Columns("est")
            .Width = 100
            .Visible = False
            .Caption = "ESTADO"
        End With
        With gr_detalle
            .ColumnAutoResize = True
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007


            .VisualStyle = VisualStyle.Office2007


            '.RowHeaders = InheritableBoolean.True
            '.TotalRow = InheritableBoolean.True
            '.TotalRowFormatStyle.BackColor = Color.Gold
            '.TotalRowPosition = TotalRowPosition.BottomFixed
        End With

        If gr_detalle.RowCount < CInt(tbCuotas.Text) Then
            Dim couta As Integer = gr_detalle.RowCount
            tbCuotas.Text = couta.ToString
        End If
    End Sub

    Private Sub tbRedondear_ValueChanged(sender As Object, e As EventArgs) Handles tbRedondear.ValueChanged
        If btnNuevo.Enabled = False Then
            If accesibleCalculo() Then
                If tbRedondear.Value * CInt(tbCuotas.Text) >= tbTotal.Value Then
                    cuotafija = tbRedondear.Value
                    tbTotal.Value = cuotafija * CInt(tbTiempo.Text)
                    CargarPagos2()

                End If
            End If
        End If
    End Sub
    Private Function ValidarCampos() As Boolean
        'If Refinanciamiento Then
        '    If tbCapital.Value <= Saldo Then
        '        Dim img As Bitmap = New Bitmap(My.Resources.mensaje)
        '        ToastNotification.Show(Me, "Ingrese un monto mayor a Saldo del prestamo anterior como Capital. Saldo:" + Saldo + ".".ToUpper, img, 2000, eToastGlowColor.Green, eToastPosition.TopCenter)
        '        Return False
        '    End If
        'End If
        'If tbInteres.Value = 0 Then
        '    Dim img As Bitmap = New Bitmap(My.Resources.mensaje)
        '    ToastNotification.Show(Me, "Ingrese un monto mayor a 0 como Interes".ToUpper, img, 2000, eToastGlowColor.Green, eToastPosition.TopCenter)
        '    Return False
        'End If
        'If tbTiempo.Text = "" Or tbTiempo.Text = String.Empty Then
        '    Dim img As Bitmap = New Bitmap(My.Resources.mensaje)
        '    ToastNotification.Show(Me, "Ingrese un tiempo maximo para el prestamo".ToUpper, img, 2000, eToastGlowColor.Green, eToastPosition.TopCenter)
        '    Return False
        'End If
        'If cbCicloPago.Value = 0 Then
        '    Dim img As Bitmap = New Bitmap(My.Resources.mensaje)
        '    ToastNotification.Show(Me, "Seleccione un ciclo de pago".ToUpper, img, 2000, eToastGlowColor.Green, eToastPosition.TopCenter)
        '    Return False
        'End If
        'If cbCliente.Value = 0 Then
        '    Dim img As Bitmap = New Bitmap(My.Resources.mensaje)
        '    ToastNotification.Show(Me, "Seleccione un cliente".ToUpper, img, 2000, eToastGlowColor.Green, eToastPosition.TopCenter)
        '    Return False
        'End If
        'If cbMoneda.Value = 0 Then
        '    Dim img As Bitmap = New Bitmap(My.Resources.mensaje)
        '    ToastNotification.Show(Me, "Seleccione una Moneda".ToUpper, img, 2000, eToastGlowColor.Green, eToastPosition.TopCenter)
        '    Return False
        'End If
        Return True
    End Function


    Private Function GuardarNuevo() As Boolean


        If ValidarCampos() = False Then
            Return False
        End If

        Dim fecVen As String = CType(gr_detalle.DataSource, DataTable).Rows(gr_detalle.RowCount - 1).Item("fecha").ToString
        Dim res As Boolean = L_fnGrabarPrestamo(_CodCliente, tbFecha.Value.ToString("dd/MM/yyyy"), tbCapital.Value, cbCicloPago.Value, CInt(tbTiempo.Text), CInt(tbCuotas.Text), cbMoneda.Value,
                                                tbInteres.Value, tbTotal.Value, tbRedondear.Value, gs_user, CType(gr_detalle.DataSource, DataTable), fecVen, IIf(Refinanciamiento, 1, 0), CodRef, Saldo)
        If res Then
            CambiarEstadoCuotas(CodRef)

            Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
            ToastNotification.Show(Me, "Préstamo registrado con exito.".ToUpper,
                                      img, 2000,
                                      eToastGlowColor.Green,
                                      eToastPosition.TopCenter)

            _PMOLimpiar()
            '_PMOInhabilitar()
            _prCargarPagos()


            Return True


        Else
            Return False
        End If
    End Function


    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        '_PMOGuardar()

        If 1 = 1 Then
            Console.WriteLine("aqui entro")
        End If
    End Sub
    Private Sub CargarComboCliente2(nombre As String)
        Dim dt As New DataTable
        dt = L_fnListarClientes2(nombre)
        'Dim fila = dt.NewRow()
        'fila(0) = 0

        'fila(1) = "SELECCIONE CLIENTE"

        'dt.Rows.InsertAt(fila, 0)
        'a.ylcod1 ,a.yldes1 
        grClientes.DataSource = dt
        grClientes.RetrieveStructure()
        grClientes.AlternatingColors = True
        With grClientes.RootTable.Columns("ydnumi")
            .Width = 100
            .Visible = False
            .Caption = "ID"
        End With
        With grClientes.RootTable.Columns("nombre")
            '.Width = 100
            .Visible = True
            .Caption = "NOMBRE"
        End With
        With grClientes
            .ColumnAutoResize = True
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007


            .VisualStyle = VisualStyle.Office2007


            '.RowHeaders = InheritableBoolean.True
            '.TotalRow = InheritableBoolean.True
            '.TotalRowFormatStyle.BackColor = Color.Gold
            '.TotalRowPosition = TotalRowPosition.BottomFixed
        End With
    End Sub

    Private Sub TextBoxX1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX1.TextChanged
        If btnNuevo.Enabled = False Then
            Dim nombre As String = TextBoxX1.Text
            CargarComboCliente2(nombre)
            '_CodCliente = cbCliente.Value
            'CargarPrestamoCliente(_CodCliente)
            If CType(grClientes.DataSource, DataTable).Rows.Count > 0 Then
                grClientes.Visible = True
            End If
            If TextBoxX1.Text = "" Then
                grClientes.Visible = False
            End If
        End If
    End Sub

    Private Sub grClientes_Click(sender As Object, e As EventArgs) Handles grClientes.Click
        _CodCliente = grClientes.GetValue("ydnumi")
        TextBoxX1.Text = grClientes.GetValue("nombre")
        grClientes.Visible = False
    End Sub

    Private Sub grClientes_EditingCell(sender As Object, e As EditingCellEventArgs) Handles grClientes.EditingCell
        e.Cancel = True
    End Sub

    Private Sub tbTotal_ValueChanged(sender As Object, e As EventArgs) Handles tbTotal.ValueChanged

    End Sub

    Private Sub LimpiarRefinanciado()

    End Sub
    Private Sub btRefinanciar_Click(sender As Object, e As EventArgs) Handles btRefinanciar.Click

        CodRef = CInt(JGrM_Pagos.GetValue("numi"))
        Dim dt As DataTable = ObtenerSaldoRefinanciar(CodRef)
        Dim Saldo1 As Double = dt.Rows(0).Item("Total")
        btRefinanciar.Enabled = False
        Dim codCliRef As Integer = _CodCliente
        Dim nomCliRef As String = TextBoxX1.Text
        _PMOHabilitar()
        _PMOLimpiar()
        Saldo = Saldo1
        _CodCliente = codCliRef
        TextBoxX1.Text = nomCliRef
        Refinanciamiento = True
        tbCapital.Value = Saldo
    End Sub

    Private Sub JGrM_Pagos_EditingCell_1(sender As Object, e As EditingCellEventArgs) Handles JGrM_Pagos.EditingCell
        e.Cancel = True

    End Sub



    Private Sub grClientes_KeyDown(sender As Object, e As KeyEventArgs) Handles grClientes.KeyDown
        If e.KeyData = Keys.Enter Then
            _CodCliente = grClientes.GetValue("ydnumi")
            TextBoxX1.Text = grClientes.GetValue("nombre")
            grClientes.Visible = False
        End If

    End Sub

    Private Sub cbCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles cbCliente.KeyDown
        If e.KeyData = Keys.Down Then
            grClientes.Focus()
        End If
    End Sub

    Private Sub TextBoxX1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxX1.KeyDown
        If e.KeyData = Keys.Down Then
            grClientes.Focus()
        End If
    End Sub



    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles btnGrabar2.Click
        'ProductosImport.Clear()
        'ProductosImport.Columns.Add("COD")
        'ProductosImport.Columns.Add("CAPITAL")
        'ProductosImport.Columns.Add("MESES")
        'ProductosImport.Columns.Add("INTERES")
        'ProductosImport.Columns.Add("CUOTA")

        'ImportarExcel()
        _PMOGuardar()
    End Sub


    Private Sub ImportarExcel()
        Try
            Dim folder As String = ""
            Dim doc As String = "Hoja3"
            Dim openfile1 As OpenFileDialog = New OpenFileDialog()

            If openfile1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                folder = openfile1.FileName
            End If

            If True Then
                Dim pathconn As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & folder & ";Extended Properties='Excel 12.0 Xml;HDR=Yes'"

                Dim con As OleDbConnection = New OleDbConnection(pathconn)
                Dim MyDataAdapter As OleDbDataAdapter = New OleDbDataAdapter("Select * from [" & doc & "$]", con)
                con.Open()

                MyDataAdapter.Fill(ProductosImport)
                CargarPrestamosExcel(ProductosImport)
                con.Close()

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarPrestamosExcel(dt As DataTable)
        For i = 0 To dt.Rows.Count - 1 Step 1
            _CodCliente = dt.Rows(i).Item("COD")
            tbCapital.Value = dt.Rows(i).Item("CAPITAL")
            tbTiempo.Text = dt.Rows(i).Item("MESES").ToString
            tbInteres.Value = dt.Rows(i).Item("INTERES")
            tbRedondear.Value = dt.Rows(i).Item("CUOTA")

            btnGrabar2.PerformClick()

        Next
    End Sub



    Private Sub JGrM_Pagos_KeyDown(sender As Object, e As KeyEventArgs) Handles JGrM_Pagos.KeyDown
        If e.KeyData = Keys.Enter Then
            e.Handled = True
            SuperTabPrincipal.SelectedTabIndex = 0
            'SuperTabPrincipal.SelectedTabIndex = 0
            'Dim numi1 As String = JGrM_Pagos.GetValue("numi").ToString
            'Dim numi2 As String = tbCodigo.Text
            'If numi1 = numi2 Then
            '    _prMostrarRegistro(JGrM_Pagos.Row)
            'Else
            '    aux = 1
            'End If
        End If
    End Sub





    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        _prMostrarRegistro(JGrM_Pagos.Row)
    End Sub

    Private Sub tbFecha_ValueChanged(sender As Object, e As EventArgs) Handles tbFecha.ValueChanged
        If btnNuevo.Enabled = False Then
            If accesibleCalculo() Then
                If tbRedondear.Value * CInt(tbTiempo.Text) >= tbTotal.Value Then
                    cuotafija = tbRedondear.Value
                    tbTotal.Value = cuotafija * CInt(tbTiempo.Text)
                    CargarPagos2()

                End If
            End If
        End If
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If JGrM_Pagos.Row >= 0 Then
            _MNuevo = False
            _MModificar = True

            _PMOHabilitar()
            btnNuevo.Enabled = False
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
            btnGrabar2.Enabled = True

            PanelNavegacion.Enabled = False

            'MRlAccion.Text = "MODIFICAR"
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim dt As DataTable = L_fnMontoLiquidar(CInt(tbCodigo.Text))
        If dt.Rows.Count > 0 Then
            Dim ef = New Efecto
            ef.tipo = 2
            ef.Header = "¿Está seguro de liquidar el prestamo seleccionado?" + vbCrLf + "El monto a cancelar es: " + (dt.Rows(0).Item("capital") + dt.Rows(0).Item("interes")).ToString.ToUpper
            ef.Context = "mensaje principal".ToUpper
            ef.ShowDialog()
            Dim bandera As Boolean = False
            bandera = ef.band
            If (bandera = True) Then
                L_fnLiquidarPrestamo(CInt(tbCodigo.Text), _CodCliente, Date.Now.ToString("dd/MM/yyyy"))
                btnActualizar.PerformClick()
            End If
        Else
            Dim img As Bitmap = New Bitmap(My.Resources.WARNING, 50, 50)
            ToastNotification.Show(Me, "No exiten cuotas pendientes por pagar.".ToUpper,
                                      img, 2000,
                                      eToastGlowColor.Green,
                                      eToastPosition.TopCenter)
        End If

    End Sub

    Private Sub cbCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbCliente.KeyPress

    End Sub



#End Region

End Class