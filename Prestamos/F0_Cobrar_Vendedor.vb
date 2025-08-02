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
Imports DevComponents.DotNetBar.SuperGrid
Imports GMap.NET.MapProviders
Imports GMap.NET
Imports GMap.NET.WindowsForms.Markers
Imports System.Reflection
Imports System.Runtime.InteropServices
Public Class F0_Cobrar_Vendedor
#Region "Variables Globales"
    Dim precio As DataTable
    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem
    Dim Bin As New MemoryStream
    Dim _inter As Integer = 0

    ''Modo de Pago
    Dim Saldo As Double = 0
    Dim Total1 As Double = 0

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
    Public idPago As Integer = 0




#End Region
#Region "METODOS PRIVADOS"

    Private Sub _IniciarTodo()

        GroupPanel2.Width = Me.Width / 2
        L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, gs_NombreBD)
        'Me.WindowState = FormWindowState.Maximized
        _prAsignarPermisos()
        _prCargarComboCliente(cbCliente)
        Me.Text = "PAGO CLIENTE POR VENDEDOR"
        Dim blah As New Bitmap(New Bitmap(My.Resources.cobro), 20, 20)
        Dim ico As Icon = Icon.FromHandle(blah.GetHicon())
        Me.Icon = ico
        '_prCargarTablaPagos2(-1)
        tbCodigo.ReadOnly = True
        tbNombre.ReadOnly = True
        tbFechaVenta.Value = Now.Date
        tbFechaFactura.Value = Now.Date
        tbCodigo.Focus()
        InHabilitar()
        _prCargarPagos()
    End Sub

    Private Sub Habilitar()
        'ButtonX4.Visible = True
        ButtonX3.Enabled = False
        ButtonX1.Enabled = True
        'tbCodigo.ReadOnly = False
        tbFechaVenta.Enabled = True
        'tbMonto.ReadOnly = True
        'tbNombre.ReadOnly = False
        tbGlosa.ReadOnly = False
        btnAnterior.Enabled = False
        btnPrimero.Enabled = False
        btnSiguiente.Enabled = False
        btnUltimo.Enabled = False
        cbCliente.ReadOnly = False
        'cbCliente.DropDownList.VisibleRows = False
        TextBoxX1.ReadOnly = False
    End Sub
    Private Sub InHabilitar()
        'ButtonX4.Visible = False
        ButtonX3.Enabled = True
        ButtonX1.Enabled = False
        'tbCodigo.ReadOnly = True
        tbFechaVenta.Enabled = False
        'tbMonto.ReadOnly = True
        'tbNombre.ReadOnly = True
        tbGlosa.ReadOnly = True
        btnAnterior.Enabled = True
        btnPrimero.Enabled = True
        btnSiguiente.Enabled = True
        btnUltimo.Enabled = True
        cbCliente.ReadOnly = True
        TextBoxX1.ReadOnly = True
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
    Private Sub _prCargarPagos()
        Dim dt As DataTable = TraerPagosTodos()

        '_prCargarIconDelete(dt)
        JGrM_Pagos.DataSource = dt
        JGrM_Pagos.RetrieveStructure()
        JGrM_Pagos.AlternatingColors = True

        With JGrM_Pagos.RootTable.Columns("tcnumi")
            .Width = 40
            .Visible = True
            .Caption = "ID"
            .TextAlignment = TextAlignment.Far
        End With
        With JGrM_Pagos.RootTable.Columns("tctp1numi")
            .Width = 50
            .Visible = True
            .Caption = "COD. PRESTAMO"
            .TextAlignment = TextAlignment.Far
        End With
        With JGrM_Pagos.RootTable.Columns("tcfdoc")
            .Width = 100
            .Caption = "FECHA"
            .Visible = True
            .FormatString = "dd/MM/yyyy"
        End With
        With JGrM_Pagos.RootTable.Columns("tcobs")
            .Width = 150
            .Visible = False
            .Caption = "COD. CLIENTE"
        End With
        With JGrM_Pagos.RootTable.Columns("tctot")
            .Width = 150
            .Visible = True
            .Caption = "TOTAL"
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
        End With
        With JGrM_Pagos.RootTable.Columns("tcty4clie")
            .Width = 250
            .Visible = False
            .Caption = "GLOSA"
        End With
        With JGrM_Pagos.RootTable.Columns("nombre")
            .Width = 250
            .Visible = True
            .Caption = "CLIENTE"
        End With
        With JGrM_Pagos.RootTable.Columns("ydcod")
            .Width = 250
            .Visible = False
            .Caption = "CLIENTE"
        End With

        With JGrM_Pagos
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

    Private Sub cargarDetallePagos(numi As Integer)
        Dim dt As DataTable = TraerPagos(numi)

        '_prCargarIconDelete(dt)
        gr_detalle.DataSource = dt
        gr_detalle.RetrieveStructure()
        gr_detalle.AlternatingColors = True

        With gr_detalle.RootTable.Columns("tdcuota")
            .Width = 100
            .Visible = True
            .Caption = "CUOTA"
            .TextAlignment = TextAlignment.Far
        End With
        With gr_detalle.RootTable.Columns("tdfact")
            .Width = 150
            .Visible = True
            .Caption = "FECHA"
            .FormatString = "dd/MM/yyyy"
        End With
        With gr_detalle.RootTable.Columns("monto")
            .Width = 150
            .Visible = True
            .Caption = "MONTO"
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
        End With
        With gr_detalle.RootTable.Columns("tdpagado")
            .Width = 150
            .Visible = True
            .Caption = "PAGADO"
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
        End With
        With gr_detalle.RootTable.Columns("estado")
            .Width = 250
            .Visible = True
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
    Private Sub _prCargarTablaPagos2(_numi As Integer)

        Dim dt As New DataTable
        dt = L_fnObtenerLasVentasCreditoPorVendedorFecha(_numi, tbFechaFactura.Value.ToString("yyyy/MM/dd"))

        '_prCargarIconDelete(dt)
        gr_detalle.DataSource = dt
        gr_detalle.RetrieveStructure()
        gr_detalle.AlternatingColors = True
        '      ' a.tcnumi, NroDoc,as factura,a.tctv1numi ,a.tcty4clie ,  cliente,a.tcty4vend, vendedor,a.tcfdoc
        ',a.tcfvencre,totalfactura, pendiente, PagoAc, Pagar
        'With gr_detalle.RootTable.Columns("factura")
        '    .Width = 100
        '    .Visible = False
        'End With
        With gr_detalle.RootTable.Columns("tctv1numi")
            .Width = 100
            .Visible = False
        End With
        With gr_detalle.RootTable.Columns("tcty4vend")
            .Width = 100
            .Visible = False
        End With
        With gr_detalle.RootTable.Columns("vendedor")
            .Width = 100
            .Visible = False
        End With
        With gr_detalle.RootTable.Columns("tcnumi")
            .Width = 100
            .Visible = False
        End With
        With gr_detalle.RootTable.Columns("NroDoc")
            .Width = 120
            .Visible = True
            .TextAlignment = TextAlignment.Far
            .Caption = "Nro documento"
        End With

        With gr_detalle.RootTable.Columns("tcty4clie")
            .Width = 150
            .Visible = True
            .Caption = "Codigo Cliente"
        End With
        With gr_detalle.RootTable.Columns("cliente")
            .Width = 200
            .Visible = True
            .Caption = "Cliente"
        End With

        With gr_detalle.RootTable.Columns("tcfdoc")
            .Caption = "Fecha Factura"
            .Width = 120
            .TextAlignment = TextAlignment.Center
            .Visible = True
        End With

        With gr_detalle.RootTable.Columns("tcfvencre")
            .Caption = "Fecha Vencimiento"
            .TextAlignment = TextAlignment.Center
            .Width = 160
            .Visible = True
        End With
        With gr_detalle.RootTable.Columns("totalfactura")
            .Caption = "Monto Total"
            .Width = 120
            .TextAlignment = TextAlignment.Far
            .FormatString = "0.00"
            .AggregateFunction = AggregateFunction.Sum
            .Visible = True
        End With
        With gr_detalle.RootTable.Columns("pendiente")
            .Caption = "Saldo"
            .Width = 120
            .TextAlignment = TextAlignment.Far
            .FormatString = "0.00"
            .AggregateFunction = AggregateFunction.Sum
            .Visible = True
        End With

        With gr_detalle.RootTable.Columns("PagoAc")
            .Caption = "Total Pagado"
            .Width = 180
            .TextAlignment = TextAlignment.Far
            .FormatString = "0.00"
            .AggregateFunction = AggregateFunction.Sum
            .Visible = True
        End With

        With gr_detalle.RootTable.Columns("Pagar")
            .Width = 100
            .Visible = True
            .Caption = "Pagar!"
        End With



        With gr_detalle
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007


            .VisualStyle = VisualStyle.Office2007


            .RowHeaders = InheritableBoolean.True
            .TotalRow = InheritableBoolean.True
            .TotalRowFormatStyle.BackColor = Color.Gold
            .TotalRowPosition = TotalRowPosition.BottomFixed
        End With
        _prAplicarCondiccionJanus()
        _prCalcularTotal()
    End Sub

    Private Sub _Limpiar()
        tbCodigo.Clear()
        tbFechaVenta.Value = Now.Date
        tbNombre.Clear()
        tbMonto.Text = "0.00"
        tbTotalCobrado.Text = 0
        tbTotalCobrar.Text = 0
        tbSaldo.Text = 0
        tbCodigo.Clear()
        tbNombre.Clear()
        tbFechaFactura.Value = Now.Date
        '_prCargarTablaPagos2(-1)
        '_prAddDetalle()
        tbCodigo.Focus()
        cbCliente.Value = 0
        _CodCliente = 0
        TextBoxX1.Clear()
        cargarDetallePagos(-1)


    End Sub
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

    Public Sub _prCargarIconPagar()
        For i As Integer = 0 To CType(gr_detalle.DataSource, DataTable).Rows.Count - 1 Step 1
            Dim Bin As New MemoryStream
            Dim img As New Bitmap(My.Resources.pagar, 60, 28)
            img.Save(Bin, Imaging.ImageFormat.Png)

            Dim Bin2 As New MemoryStream
            Dim img2 As New Bitmap(My.Resources.pagado, 60, 28)
            img2.Save(Bin2, Imaging.ImageFormat.Png)
            If CType(gr_detalle.DataSource, DataTable).Rows(i).Item("pendiente") = 0 Then
                CType(gr_detalle.DataSource, DataTable).Rows(i).Item("check1") = Bin2.GetBuffer
                gr_detalle.RootTable.Columns("check1").Visible = True
                gr_detalle.RootTable.Columns("check1").CellStyle.ImageHorizontalAlignment = ImageHorizontalAlignment.Center
            Else
                CType(gr_detalle.DataSource, DataTable).Rows(i).Item("check1") = Bin.GetBuffer
                gr_detalle.RootTable.Columns("check1").Visible = True
                gr_detalle.RootTable.Columns("check1").CellStyle.ImageHorizontalAlignment = ImageHorizontalAlignment.Center
            End If

        Next

    End Sub
    Private Sub _prCargarTablaPagos(_numi As Integer)

        Dim dt As New DataTable
        dt = L_fnObtenerLasVentasCreditoPorVendedorFecha(_numi, tbFechaFactura.Value.ToString("yyyy/MM/dd"))
        If (dt.Rows.Count <= 0) Then
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "No Hay Datos Para Mostrar".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            Return
        End If
        '_prCargarIconDelete(dt)
        gr_detalle.DataSource = dt
        gr_detalle.RetrieveStructure()
        gr_detalle.AlternatingColors = True
        '      ' a.tcnumi, NroDoc,as factura,a.tctv1numi ,a.tcty4clie ,  cliente,a.tcty4vend, vendedor,a.tcfdoc
        ',a.tcfvencre,totalfactura, pendiente, PagoAc, Pagar
        With gr_detalle.RootTable.Columns("factura")
            .Width = 100
            .Visible = False
        End With
        With gr_detalle.RootTable.Columns("tctv1numi")
            .Width = 100
            .Visible = False
        End With
        With gr_detalle.RootTable.Columns("tcty4vend")
            .Width = 100
            .Visible = False
        End With
        With gr_detalle.RootTable.Columns("vendedor")
            .Width = 100
            .Visible = False
        End With
        With gr_detalle.RootTable.Columns("tcnumi")
            .Width = 100
            .Visible = False
        End With
        With gr_detalle.RootTable.Columns("NroDoc")
            .Width = 120
            .Visible = True
            .TextAlignment = TextAlignment.Far
            .Caption = "Nro documento"
        End With

        With gr_detalle.RootTable.Columns("tcty4clie")
            .Width = 150
            .Visible = True
            .Caption = "Codigo Cliente"
        End With
        With gr_detalle.RootTable.Columns("cliente")
            .Width = 200
            .Visible = True
            .Caption = "Razón Social"
        End With

        With gr_detalle.RootTable.Columns("tcfdoc")
            .Caption = "Fecha Factura"
            .Width = 120
            .TextAlignment = TextAlignment.Center
            .Visible = True
            .FormatString = "dd/MM/yyyy"
        End With

        With gr_detalle.RootTable.Columns("tcfvencre")
            .Caption = "Fecha Vencimiento"
            .TextAlignment = TextAlignment.Center
            .Width = 160
            .Visible = True

        End With
        With gr_detalle.RootTable.Columns("totalfactura")
            .Caption = "Monto Total"
            .Width = 120
            .TextAlignment = TextAlignment.Far
            .FormatString = "0.00"
            .AggregateFunction = AggregateFunction.Sum
            .Visible = True
        End With
        With gr_detalle.RootTable.Columns("pendiente")
            .Caption = "Saldo"
            .Width = 120
            .TextAlignment = TextAlignment.Far
            .FormatString = "0.00"
            .AggregateFunction = AggregateFunction.Sum
            .Visible = True
        End With

        With gr_detalle.RootTable.Columns("PagoAc")
            .Caption = "Total Pagado"
            .Width = 180
            .TextAlignment = TextAlignment.Far
            .FormatString = "0.00"
            .AggregateFunction = AggregateFunction.Sum
            .Visible = True
        End With

        With gr_detalle.RootTable.Columns("Pagar")
            .Width = 100
            .Visible = True
            .Caption = "Pagar!"
        End With

        With gr_detalle.RootTable.Columns("pendiente2")
            .Width = 100
            .Visible = False
        End With

        With gr_detalle
            .GroupByBoxVisible = False
            'diseño de la grilla
            .VisualStyle = VisualStyle.Office2007


            .VisualStyle = VisualStyle.Office2007


            .RowHeaders = InheritableBoolean.True
            .TotalRow = InheritableBoolean.True
            .TotalRowFormatStyle.BackColor = Color.Gold
            .TotalRowPosition = TotalRowPosition.BottomFixed
        End With
        _prAplicarCondiccionJanus()
        _prCalcularTotal()
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


    Private Sub tbCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles tbCodigo.KeyDown
        'If (_fnAccesible()) Then
        If e.KeyData = Keys.Control + Keys.Enter Then
            _Limpiar()
            Dim dt As DataTable

            dt = L_fnListarClientesTodos()
            '              a.ydnumi, a.ydcod, a.yddesc, a.yddctnum, a.yddirec
            ',a.ydtelf1 ,a.ydfnac 

            Dim listEstCeldas As New List(Of Modelo.Celda)
            listEstCeldas.Add(New Modelo.Celda("ydnumi,", False, "ID", 50))
            listEstCeldas.Add(New Modelo.Celda("ydcod", True, "CODIGO", 80))
            listEstCeldas.Add(New Modelo.Celda("nombre", True, "NOMBRE CLIENTE", 200))
            listEstCeldas.Add(New Modelo.Celda("yddct", True, "N. Documento".ToUpper, 150))
            listEstCeldas.Add(New Modelo.Celda("yddirdom", True, "DIRECCION", 220))
            listEstCeldas.Add(New Modelo.Celda("ydcel", True, "Telefono".ToUpper, 200))

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
                    tbCodigo.Text = Row.Cells("ydcod").Value
                    tbNombre.Text = Row.Cells("nombre").Value
                    '_prCargarTablaPagos(Row.Cells("ydnumi").Value)
                Catch ex As Exception

                End Try
            Else
                _CodCliente = 0
                tbCodigo.Clear()
                tbNombre.Clear()
                Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
                ToastNotification.Show(Me, "Los Datos Del Cliente No Existe en el sistema".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            End If

        End If
        'End If
    End Sub

    Private Sub _prMostrarRegistro(N As Integer)
        With JGrM_Pagos
            idPago = .GetValue("tcnumi")
            tbCodigo.Text = .GetValue("ydcod")
            TextBoxX1.Text = .GetValue("nombre")
            tbMonto.Text = .GetValue("tctot")
            tbGlosa.Text = .GetValue("tcobs")
            _CodCliente = .GetValue("tcty4clie")
            tbFechaVenta.Value = .GetValue("tcfdoc")
            'tbTotalCobrado.Text = .GetValue("pccdo")
            'tbTotalCobrar.Text = .GetValue("pccob")
            'tbSaldo.Text = .GetValue("pcsal")

            .TotalRow = InheritableBoolean.True
            .TotalRowFormatStyle.BackColor = Color.Gold
            .TotalRowPosition = TotalRowPosition.BottomFixed
        End With
        cargarDetallePagos(idPago)
        LblPaginacion.Text = Str(JGrM_Pagos.Row + 1) + "/" + JGrM_Pagos.RowCount.ToString
    End Sub

    Private Sub Bt1Generar_Click(sender As Object, e As EventArgs) Handles Bt1Generar.Click
        If (tbCodigo.Text <> String.Empty) Then
            tbSaldo.Value = 0
            tbTotalCobrado.Value = 0
            tbTotalCobrar.Value = 0
            _prCargarTablaPagos(tbCodigo.Text)
        End If
    End Sub
    Private Function Accesible() As Boolean
        If ButtonX3.Enabled = False Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub gr_detalle_EditingCell(sender As Object, e As EditingCellEventArgs) Handles gr_detalle.EditingCell
        If Accesible() Then
            If (e.Column.Index = gr_detalle.RootTable.Columns("check1").Index) Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub gr_detalle_CellValueChanged(sender As Object, e As ColumnActionEventArgs) Handles gr_detalle.CellValueChanged
        ''Dim rowIndex As Integer = gr_detalle.CurrentRow.RowIndex
        Dim rowIndex As Integer = gr_detalle.Row
        'Columna de Precio Venta



        If (e.Column.Index = gr_detalle.RootTable.Columns("check1").Index) Then
            Dim ob As Boolean = gr_detalle.GetValue("check1")

            If (ob = True) Then
                If Saldo > 0 And Total1 > 0 Then
                    If gr_detalle.GetValue("pendiente") < Saldo And gr_detalle.GetValue("pendiente") < Total1 Then
                        'pendiente, PagoAc, Pagar
                        tbTotalCobrado.Value = tbTotalCobrado.Value + gr_detalle.GetValue("pendiente")
                        tbSaldo.Value = tbSaldo.Value - gr_detalle.GetValue("pendiente")

                        gr_detalle.SetValue("pagar", gr_detalle.GetValue("pendiente"))
                        gr_detalle.SetValue("pendiente", 0)
                        Saldo = Saldo - gr_detalle.GetValue("pagar")
                        Total1 = Total1 - gr_detalle.GetValue("pagar")

                    Else
                        tbTotalCobrado.Value = tbTotalCobrado.Value + Total1
                        tbSaldo.Value = tbSaldo.Value - Saldo
                        gr_detalle.SetValue("pagar", Total1)
                        gr_detalle.SetValue("pendiente", gr_detalle.GetValue("pendiente") - Total1)
                        Saldo = 0
                        Total1 = 0
                    End If
                Else
                    gr_detalle.SetValue("check1", False)
                End If

            Else
                'If gr_detalle.GetValue("pendiente") > 0 Then
                tbTotalCobrado.Value = tbTotalCobrado.Value - gr_detalle.GetValue("pagar")
                tbSaldo.Value = tbSaldo.Value + gr_detalle.GetValue("pagar")
                Saldo = Saldo + gr_detalle.GetValue("pagar")
                Total1 = Total1 + gr_detalle.GetValue("pagar")
                gr_detalle.SetValue("pendiente", gr_detalle.GetValue("pendiente") + gr_detalle.GetValue("pagar"))
                gr_detalle.SetValue("pagar", 0)

            End If
            '_prCalcularTotal()
        End If
    End Sub
    Public Sub _prCalcularTotal()
        tbTotalCobrado.Text = tbMonto.Text  'IIf(IsDBNull(CType(gr_detalle.DataSource, DataTable).Compute("sum(monto)", "check1 = True")), 0, CType(gr_detalle.DataSource, DataTable).Compute("sum(monto)", "check1 = True"))
        Dim monto As Double
        'monto = IIf(tbMonto.Text = "", 0, CDbl(tbMonto.Text))
        If tbMonto.Text = "" Then
            monto = 0
        Else
            monto = CDbl(tbMonto.Text)
        End If
        tbSaldo.Text = CDbl(tbTotalCobrar.Text) - monto
        'CType(gr_detalle.DataSource, DataTable).Compute("sum(monto)", "check1 = False")
        'tbSaldo.Text = gr_detalle.GetTotal(gr_detalle.RootTable.Columns("pendiente"), AggregateFunction.Sum)
        'tbTotalCobrar.Text = gr_detalle.GetTotal(gr_detalle.RootTable.Columns("PagoAc"), AggregateFunction.Sum) + gr_detalle.GetTotal(gr_detalle.RootTable.Columns("pendiente"), AggregateFunction.Sum)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        _modulo.Select()
        _tab.Close()
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        '_modulo.Select()
        If ButtonX1.Enabled = True Then
            _prCargarPagos()
            InHabilitar()
        Else
            Close()
        End If

    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs)
        Dim numi As String = ""
        Dim img2 As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
        If (_CodCliente < 0) Then
            ToastNotification.Show(Me, "No existen datos validos".ToUpper, img2, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            Return

        End If
        If (CType(gr_detalle.DataSource, DataTable).Rows.Count <= 0) Then
            ToastNotification.Show(Me, "No existen datos validos".ToUpper, img2, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            Return

        End If
        Dim dtCobro As DataTable = L_fnCobranzasObtenerLosPagos(-1)
        Dim bandera As Boolean = False
        _prInterpretarDatosCobranza(dtCobro, bandera)
        If (bandera = False) Then
            ToastNotification.Show(Me, "Seleccione un detalle de la lista de pendientes".ToUpper, img2, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            Return
        End If
        Dim res As Boolean = L_fnGrabarCobranza2(numi, tbFechaVenta.Value.ToString("yyyy/MM/dd"), 0, "", dtCobro)


        If res Then

            Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
            ToastNotification.Show(Me, "El Pago Ha Sido ".ToUpper + " Grabado con Exito.".ToUpper,
                                      img, 2000,
                                      eToastGlowColor.Green,
                                      eToastPosition.TopCenter
                                      )


            _Limpiar()

        Else
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "La Compra no pudo ser insertado".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)

        End If
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
            Dim estado As Boolean = dtcobro.Rows(i).Item("check1")
            If (estado = True) Then
                '             td.tdtv12numi ,@tenumi ,td.tdnrodoc ,@newFecha ,td.tdmonto ,td.tdnrorecibo ,td.tdty3banco,
                'td.tdnrocheque, @newFecha  ,@newHora  ,@teuact

                '              a.tcnumi, NroDoc,as factura, a.tctv1numi, a.tcty4clie, cliente, a.tcty4vend, vendedor, a.tcfdoc
                ',a.tcfvencre,totalfactura, pendiente, PagoAc, Pagar

                dt.Rows.Add(dtcobro.Rows(i).Item("cuota"), dtcobro.Rows(i).Item("fecha"),
                                            dtcobro.Rows(i).Item("monto"), dtcobro.Rows(i).Item("estado"), dtcobro.Rows(i).Item("pagado"), dtcobro.Rows(i).Item("pendiente"), dtcobro.Rows(i).Item("pagar"), dtcobro.Rows(i).Item("saldo"), dtcobro.Rows(i).Item("saldo2"), dtcobro.Rows(i).Item("check1"))
                bandera = True

            End If

        Next
    End Sub


    Private Sub ButtonX1_Click_1(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Dim numi As String = ""
        Dim img2 As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
        If (_CodCliente < 0) Then
            ToastNotification.Show(Me, "No existen datos validos".ToUpper, img2, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            Return

        End If
        If (CType(gr_detalle.DataSource, DataTable).Rows.Count <= 0) Then
            ToastNotification.Show(Me, "No existen datos validos".ToUpper, img2, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            Return

        End If
        If (tbMonto.Text = "" Or tbMonto.Text = "0.00") Then
            ToastNotification.Show(Me, "Seleccione una cuota a pagar".ToUpper, img2, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            Return

        End If
        Dim dtCobro As DataTable = L_fnCargarPagos2(-1)
        Dim bandera As Boolean = False
        Dim Notas As String = ""
        _prInterpretarDatosCobranza(dtCobro, bandera)
        If (bandera = False) Then
            ToastNotification.Show(Me, "Seleccione un detalle de la lista de pendientes".ToUpper, img2, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            Return
        End If

        Dim res As Integer = L_fnGrabarCobranza(grPrestamo.GetValue("numi"), tbFechaVenta.Value.ToString("dd/MM/yyyy"), _CodCliente, CDbl(tbMonto.Text), tbGlosa.Text, gi_userSuc, dtCobro)




        If res <> 0 Then

            Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
            ToastNotification.Show(Me, "El Pago Ha Sido ".ToUpper + " Grabado con Exito.".ToUpper,
                                      img, 2000,
                                      eToastGlowColor.Green,
                                      eToastPosition.TopCenter
                                      )

            _prGuardarMontos(grPrestamo.GetValue("numi"), res, TotalBs, TotalSus, TipoCambio)
            _Limpiar()
            _prCargarPagos()
            InHabilitar()

        Else
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "Los Pagos no pudieron ser insertados".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)

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

    Private Sub btnAutoChekear_Click(sender As Object, e As EventArgs) Handles btnAutoChekear.Click
        Dim Saldo As Double = 0

        Dim dt As DataTable = CType(gr_detalle.DataSource, DataTable)
        If (dt.Rows.Count > 0) Then
            For i As Integer = 0 To dt.Rows.Count - 1 Step 1
                If (CType(gr_detalle.DataSource, DataTable).Rows(i).Item("Pagar") = False) Then
                    If Total1 > 0 Then
                        If CType(gr_detalle.DataSource, DataTable).Rows(i).Item("pendiente") < Total1 Then
                            CType(gr_detalle.DataSource, DataTable).Rows(i).Item("Pagar") = True
                            Total1 = Total1 - CType(gr_detalle.DataSource, DataTable).Rows(i).Item("pendiente")
                            CType(gr_detalle.DataSource, DataTable).Rows(i).Item("PagoAc") = CType(gr_detalle.DataSource, DataTable).Rows(i).Item("pendiente")
                            CType(gr_detalle.DataSource, DataTable).Rows(i).Item("pendiente") = 0
                            tbTotalCobrado.Value = tbTotalCobrado.Value + CType(gr_detalle.DataSource, DataTable).Rows(i).Item("PagoAc")
                            tbSaldo.Value = 0
                        Else
                            CType(gr_detalle.DataSource, DataTable).Rows(i).Item("Pagar") = True
                            CType(gr_detalle.DataSource, DataTable).Rows(i).Item("PagoAc") = Total1
                            CType(gr_detalle.DataSource, DataTable).Rows(i).Item("pendiente") = CType(gr_detalle.DataSource, DataTable).Rows(i).Item("pendiente") - Total1
                            tbTotalCobrado.Value = tbTotalCobrado.Value + CType(gr_detalle.DataSource, DataTable).Rows(i).Item("PagoAc")
                            Total1 = 0
                            Saldo = Saldo = CType(gr_detalle.DataSource, DataTable).Rows(i).Item("pendiente")
                        End If
                    End If
                    If Total1 = 0 Then
                        Saldo = Saldo + CType(gr_detalle.DataSource, DataTable).Rows(i).Item("pendiente")
                    End If
                End If
            Next
        End If
        tbSaldo.Value = Saldo
        'Dim b As Boolean = False
        'Dim b2 As Boolean = _fnIsALl()
        'If (tbTotalCobrado.Value >= 0) Then
        '    b = True
        'Else
        '    b = False
        'End If
        'If (dt.Rows.Count > 0) Then
        '    For i As Integer = 0 To dt.Rows.Count - 1 Step 1
        '        If (b = True) Then
        '            If (CType(gr_detalle.DataSource, DataTable).Rows(i).Item("Pagar") = False) Then
        '                CType(gr_detalle.DataSource, DataTable).Rows(i).Item("Pagar") = True

        '                CType(gr_detalle.DataSource, DataTable).Rows(i).Item("PagoAc") = CType(gr_detalle.DataSource, DataTable).Rows(i).Item("pendiente")
        '                CType(gr_detalle.DataSource, DataTable).Rows(i).Item("pendiente") = 0
        '                tbTotalCobrado.Value = tbTotalCobrado.Value + CType(gr_detalle.DataSource, DataTable).Rows(i).Item("PagoAc")
        '                tbSaldo.Value = 0
        '            End If



        '        End If
        '        If (b2) Then
        '            CType(gr_detalle.DataSource, DataTable).Rows(i).Item("Pagar") = False
        '            tbTotalCobrado.Value = 0
        '            tbSaldo.Value = tbTotalCobrar.Value

        '            CType(gr_detalle.DataSource, DataTable).Rows(i).Item("pendiente") = CType(gr_detalle.DataSource, DataTable).Rows(i).Item("PagoAc")
        '            CType(gr_detalle.DataSource, DataTable).Rows(i).Item("PagoAc") = 0
        '        End If
        '    Next

        'End If
    End Sub
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
    Private Sub _prGuardarCobro(dtCobro As DataTable)
        Dim Notas As String = ""
        For i As Integer = 0 To dtCobro.Rows.Count - 1 Step 1
            Dim x As Integer = InStr(1, dtCobro.Rows(i).Item("tdnrodoc"), "-")
            Notas = Notas + dtCobro.Rows(i).Item("tdnrodoc").ToString.Substring(0, x)
        Next
        Dim id As DataTable = _GuadarCobroCliente(_CodCliente, tbGlosa.Text, CDbl(tbMonto.Text), tbFechaVenta.Value.ToString("dd/MM/yyyy"), CDbl(tbTotalCobrar.Text), CDbl(tbTotalCobrado.Text), CDbl(tbSaldo.Text), CType(gr_detalle.DataSource, DataTable))
        Dim numi As Integer = id.Rows(0).Item("numi")
        _prAgregarCobro(numi, 2, "VENTA CREDITO Nº " + Notas, TotalBs, TotalSus, TotalTarjeta, cambio, Banco, Glosa, gi_userSuc, TipoCambio)

        If TotalTarjeta > 0 Then
            L_prMovimientoGrabar("", tbFechaVenta.Value.ToString("dd/MM/yyyy"), 1, gi_userSuc, Banco, "", "CUENTA POR COBRAR", TotalTarjeta, Glosa)
        End If

    End Sub
    Private Sub limpiarCheck()
        For i As Integer = 0 To gr_detalle.RowCount - 1 Step 1
            CType(gr_detalle.DataSource, DataTable).Rows(i).Item("check1") = False
        Next
    End Sub

    Private Sub MostrarAyuda()
        Dim ef As F1_MontoPagar
        ef = New F1_MontoPagar

        'ef.TotalVenta = Math.Round(tbtotal.Value, 2)
        'ef.tipoVenta = IIf(swTipoVenta.Value = True, 1, 0)
        'ef.Cobrado = False
        'ef.CostoEnvio = tbEnvio.Text
        With gr_detalle
            ef.cuota = .GetValue("cuota")
            ef.FechaC = .GetValue("fecha")
            ef.Pagado = .GetValue("Pagado")
            ef.Apagar = .GetValue("Pendiente")

        End With
        ef.moneda = grPrestamo.GetValue("pmon")

        ef.ShowDialog()
        Dim bandera As Boolean = False
        bandera = ef.Bandera

        If (bandera = True) Then
            Dim Total As Double
            If grPrestamo.GetValue("pmon") = 2 Then
                Total = ef.TotalBs + (ef.TotalSus * ef.TCambio)
            Else
                Total = ef.TotalSus + (ef.TotalBs / ef.TCambio)
            End If
            GrabarCobranzaCuota(grPrestamo.GetValue("numi"), _CodCliente, ef.FechaP, Total, "", ef.cuota, ef.TotalBs, ef.TotalSus, ef.TCambio, gr_detalle.GetValue("Pendiente"))

            ToastNotification.Show(Me, "Pago realizado con exito ".ToUpper, My.Resources.GRABACION_EXITOSA, 4000, eToastGlowColor.Red, eToastPosition.TopCenter)
            'TotalBs = ef.TotalBs
            'TotalSus = ef.TotalSus
            'TotalTarjeta = ef.TotalTarjeta
            'TipoCambio = ef.TipoCambio
            'TipoVenta = ef.tipoVenta
            'FechaVenc = ef.tbFechaVenc.Value
            'Banco = ef.cbBanco.Value
            'Glosa = ef.tbCuota.Text
            'CostoEnvio = ef.tbCostoEnvio.Value



            'If grPrestamo.GetValue("pmon") <> 1 Then
            '    tbMonto.Text = CDbl(TotalBs + TotalTarjeta + (TotalSus * TipoCambio)).ToString("0.00")
            '    Saldo = CDbl(TotalBs + TotalTarjeta + (TotalSus * TipoCambio))
            '    Total = CDbl(TotalBs + TotalTarjeta + (TotalSus * TipoCambio))
            'Else
            '    tbMonto.Text = CDbl((TotalBs / TipoCambio) + TotalTarjeta + TotalSus).ToString("0.00")
            '    Saldo = CDbl((TotalBs / TipoCambio) + TotalTarjeta + TotalSus)
            '    Total = CDbl((TotalBs / TipoCambio) + TotalTarjeta + TotalSus)
            'End If
            ''btnAutoChekear.PerformClick()
            'cambio = Convert.ToDouble(tbMonto.Text - tbTotalCobrado.Text)

        Else
            ToastNotification.Show(Me, "No se realizó ninguna operación ".ToUpper, My.Resources.WARNING, 4000, eToastGlowColor.Red, eToastPosition.TopCenter)

        End If
    End Sub
    Private Sub btnCobrar_Click(sender As Object, e As EventArgs) Handles btnCobrar.Click
        'limpiarCheck()
        'Dim ef As F1_MontoPagar
        'ef = New F1_MontoPagar

        ''ef.TotalVenta = Math.Round(tbtotal.Value, 2)
        ''ef.tipoVenta = IIf(swTipoVenta.Value = True, 1, 0)
        ''ef.Cobrado = False
        ''ef.CostoEnvio = tbEnvio.Text

        'ef.lbCostoEnvio.Visible = False
        'ef.tbCostoEnvio.Visible = False

        'ef.TotalVenta = Math.Round(tbTotalCobrar.Value, 2)
        'ef.tipoVenta = 0

        'ef.ShowDialog()
        'Dim bandera As Boolean = False
        'bandera = ef.Bandera

        'If (bandera = True) Then

        '    TotalBs = ef.TotalBs
        '    TotalSus = ef.TotalSus
        '    TotalTarjeta = ef.TotalTarjeta
        '    TipoCambio = ef.TipoCambio
        '    TipoVenta = ef.tipoVenta
        '    FechaVenc = ef.tbFechaVenc.Value
        '    Banco = ef.cbBanco.Value
        '    Glosa = ef.tbCuota.Text
        '    CostoEnvio = ef.tbCostoEnvio.Value



        '    If grPrestamo.GetValue("pmon") <> 1 Then
        '        tbMonto.Text = CDbl(TotalBs + TotalTarjeta + (TotalSus * TipoCambio)).ToString("0.00")
        '        Saldo = CDbl(TotalBs + TotalTarjeta + (TotalSus * TipoCambio))
        '        Total = CDbl(TotalBs + TotalTarjeta + (TotalSus * TipoCambio))
        '    Else
        '        tbMonto.Text = CDbl((TotalBs / TipoCambio) + TotalTarjeta + TotalSus).ToString("0.00")
        '        Saldo = CDbl((TotalBs / TipoCambio) + TotalTarjeta + TotalSus)
        '        Total = CDbl((TotalBs / TipoCambio) + TotalTarjeta + TotalSus)
        '    End If
        '    'btnAutoChekear.PerformClick()
        '    cambio = Convert.ToDouble(tbMonto.Text - tbTotalCobrado.Text)

        'Else
        '    ToastNotification.Show(Me, "No se realizó ninguna operación ".ToUpper, My.Resources.WARNING, 4000, eToastGlowColor.Red, eToastPosition.TopCenter)

        'End If

    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        _Limpiar()
        Habilitar()
    End Sub

    Private Sub tbGlosa_TextChanged(sender As Object, e As EventArgs) Handles tbGlosa.TextChanged

    End Sub

    Private Sub JGrM_Pagos_SelectionChanged(sender As Object, e As EventArgs) Handles JGrM_Pagos.SelectionChanged
        If (JGrM_Pagos.RowCount >= 0 And JGrM_Pagos.Row >= 0) Then

            _prMostrarRegistro(JGrM_Pagos.Row)
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

    Private Sub GenerarReporte()
        Dim dt As DataTable = CType(gr_detalle.DataSource, DataTable)
        Dim _TotalLi As Decimal
        Dim _Literal, _TotalDecimal, _TotalDecimal2 As String

        _TotalLi = CDbl(tbMonto.Text)
        _TotalDecimal = _TotalLi - Math.Truncate(_TotalLi)
        _TotalDecimal2 = CDbl(_TotalDecimal) * 100


        ' _Literal = Facturacion.ConvertirLiteral.A_fnConvertirLiteral(CDbl(_TotalLi) - CDbl(_TotalDecimal)) + "  " + IIf(_TotalDecimal2.Equals("0"), "00", _TotalDecimal2) + "/100 Bolivianos"

        Dim usuario As String

        If (gi_NumiVenedor > 0) Then

            Dim dt2 As DataTable
            dt2 = L_fnListarEmpleado()
            For i As Integer = 0 To dt.Rows.Count - 1 Step 1
                If (dt2.Rows(i).Item("ydnumi") = gi_NumiVenedor) Then

                    usuario = dt2.Rows(i).Item("yddesc")
                End If

            Next

        End If
        P_Global.Visualizador = New Visualizador

        'Dim objrep As New R_NotaPagoCredito
        '' GenerarNro(_dt)
        ''objrep.SetDataSource(Dt1Kardex)

        'objrep.SetDataSource(dt)
        'objrep.SetParameterValue("literal", _Literal)

        'objrep.SetParameterValue("glosa", tbGlosa.Text)
        'objrep.SetParameterValue("fecha", tbFechaVenta.Value.ToString("dd/MM/yyyy"))
        'objrep.SetParameterValue("numi", idPago)
        'objrep.SetParameterValue("usuario", IIf(usuario = String.Empty, gs_user, usuario))
        'P_Global.Visualizador.CrGeneral.ReportSource = objrep 'Comentar
        'P_Global.Visualizador.ShowDialog() 'Comentar
        'P_Global.Visualizador.BringToFront() 'Comentar

    End Sub

    Private Sub JGrM_Pagos_EditingCell(sender As Object, e As EditingCellEventArgs) Handles JGrM_Pagos.EditingCell
        e.Cancel = True
    End Sub

    Private Sub JGrM_Pagos_DoubleClick(sender As Object, e As EventArgs) Handles JGrM_Pagos.DoubleClick
        SuperTabPrincipal.SelectedTabIndex = 0
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        GenerarReporte()
    End Sub

    Private Sub CargarPrestamoCliente(cod As Integer)
        Dim dt As DataTable = L_fnCargarPrestamoCliente(cod)

        '_prCargarIconDelete(dt)
        grPrestamo.DataSource = dt
        grPrestamo.RetrieveStructure()
        grPrestamo.AlternatingColors = True

        With grPrestamo.RootTable.Columns("numi")
            .Width = 100
            .Visible = True
            .Caption = "ID"
            .TextAlignment = TextAlignment.Far
        End With
        With grPrestamo.RootTable.Columns("fecha")
            .Width = 150
            .Visible = True
            .Caption = "FECHA"
            .FormatString = "dd/MM/yyyy"
        End With
        With grPrestamo.RootTable.Columns("pcapi")
            .Width = 150
            .Visible = True
            .Caption = "CAPITAL"
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
        End With
        With grPrestamo.RootTable.Columns("pcicp")
            .Width = 250
            .Visible = False
            .TextAlignment = TextAlignment.Far
        End With
        With grPrestamo.RootTable.Columns("ptiem")
            .Width = 100
            .Visible = True
            .Caption = "TIEMPO"
            .TextAlignment = TextAlignment.Far
        End With
        With grPrestamo.RootTable.Columns("pmon")
            .Width = 70
            .Visible = False
        End With
        With grPrestamo.RootTable.Columns("ycdes3")
            .Width = 120
            .Visible = True
            .Caption = "MONEDA"
        End With
        With grPrestamo.RootTable.Columns("pinte")
            .Width = 100
            .Visible = True
            .Caption = "INTERES"
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
        End With
        With grPrestamo.RootTable.Columns("ptot")
            .Width = 100
            .Visible = True
            .Caption = "TOTAL"
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
        End With
        With grPrestamo.RootTable.Columns("amortizado")
            .Width = 100
            .Visible = True
            .Caption = "AMORTIZADO"
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
        End With
        With grPrestamo.RootTable.Columns("Saldo")
            .Width = 100
            .Visible = True
            .Caption = "SALDO"
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
        End With
        With grPrestamo
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
    Private Sub tbCodigo_TextChanged(sender As Object, e As EventArgs) Handles tbCodigo.TextChanged
        CargarPrestamoCliente(_CodCliente)
    End Sub

    Private Sub F0_Cobrar_Vendedor_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        GroupPanel2.Width = Me.Width / 2
    End Sub

    Private Sub CargarPrestamoDetalle(cod As Integer)
        Dim dt As DataTable = L_fnCargarPagos2(cod)

        '_prCargarIconDelete(dt)
        gr_detalle.DataSource = dt
        gr_detalle.RetrieveStructure()
        gr_detalle.AlternatingColors = True

        With gr_detalle.RootTable.Columns("cuota")
            .Width = 100
            .Visible = True
            .Caption = "CUOTA"
            .FormatString = "0"
            .TextAlignment = TextAlignment.Far
        End With
        With gr_detalle.RootTable.Columns("fecha")
            .Width = 100
            .Visible = True
            .Caption = "FECHA"
            .FormatString = "dd/MM/yyyy"
        End With
        With gr_detalle.RootTable.Columns("capital")
            .Width = 100
            .Visible = True
            .Caption = "CAPITAL"
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
            .AggregateFunction = AggregateFunction.Sum
        End With
        With gr_detalle.RootTable.Columns("interes")
            .Width = 100
            .Visible = True
            .Caption = "INTERES"
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
            .AggregateFunction = AggregateFunction.Sum
        End With
        With gr_detalle.RootTable.Columns("monto")
            .Width = 100
            .Visible = True
            .Caption = "MONTO"
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
            .AggregateFunction = AggregateFunction.Sum
        End With
        With gr_detalle.RootTable.Columns("estado")
            .Width = 100
            .Visible = True
            .Caption = "ESTADO"
        End With
        With gr_detalle.RootTable.Columns("pagado")
            .Width = 100
            .Visible = True
            .Caption = "PAGADO"
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
        End With
        With gr_detalle.RootTable.Columns("pendiente")
            .Width = 100
            .Visible = True
            .Caption = "PENDIENTE"
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
        End With
        With gr_detalle.RootTable.Columns("pagar")
            .Width = 100
            .Visible = False
            .Caption = "A PAGAR"
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
        End With
        With gr_detalle.RootTable.Columns("saldo")
            .Width = 100
            .Visible = False
            .Caption = "SALDO"
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
        End With
        With gr_detalle.RootTable.Columns("saldo2")
            .Width = 100
            .Visible = False
            .Caption = "PENDIENTE"
            .FormatString = "0.00"
            .TextAlignment = TextAlignment.Far
        End With
        With gr_detalle.RootTable.Columns("check1")
            .Width = 100
            .Visible = True
            .TextAlignment = TextAlignment.Center
            .Caption = ""
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
        If ButtonX3.Enabled = False Then
            If CType(gr_detalle.DataSource, DataTable).Rows.Count > 0 Then
                P_prPonerCodicion()
            End If
        End If
    End Sub
    Private Sub P_prPonerCodicion()
        'poner color a la fila de acuerdo a la condicion 
        Dim fc As GridEXFormatCondition
        fc = New GridEXFormatCondition(gr_detalle.RootTable.Columns("cuota"), ConditionOperator.Equal, CType(gr_detalle.DataSource, DataTable).Rows(0).Item("cuota"))
        fc.FormatStyle.BackColor = Color.Yellow
        fc.FormatStyle.ForeColor = Color.Black

        gr_detalle.RootTable.FormatConditions.Add(fc)
    End Sub
    Private Sub grPrestamo_SelectionChanged(sender As Object, e As EventArgs) Handles grPrestamo.SelectionChanged
        If ButtonX3.Enabled = False Then
            CargarPrestamoDetalle(grPrestamo.GetValue("numi"))
            _prCalcularTotal()
            tbMonto.Text = "0.00"
            Dim saldo As Double = 0
            'For i As Integer = 0 To gr_detalle.RowCount - 1 Step 1
            '    If CType(gr_detalle.DataSource, DataTable).Rows(i).Item("check1") = False Then
            '        saldo = saldo + CDbl(CType(gr_detalle.DataSource, DataTable).Rows(i).Item("monto"))
            '    End If
            'Next
            tbTotalCobrar.Text = saldo.ToString
            _prCargarIconPagar()
        End If
        ButtonX4.Focus()
    End Sub

    Private Sub grPrestamo_EditingCell(sender As Object, e As EditingCellEventArgs) Handles grPrestamo.EditingCell
        e.Cancel = True
    End Sub

    Private Sub gr_detalle_CellEdited(sender As Object, e As ColumnActionEventArgs) Handles gr_detalle.CellEdited
        ' _prCalcularTotal()
    End Sub

    Private Sub tbNombre_TextChanged(sender As Object, e As EventArgs) Handles tbNombre.TextChanged

    End Sub

    Private Sub cbCliente_ValueChanged(sender As Object, e As EventArgs) Handles cbCliente.ValueChanged
        'If ButtonX3.Enabled = False Then
        '    Dim nombre As String = cbCliente.Text
        '    CargarComboCliente2(cbCliente, nombre)
        '    '_CodCliente = cbCliente.Value
        '    'CargarPrestamoCliente(_CodCliente)
        '    cbCliente.Text = nombre
        'End If
    End Sub

    Private Sub TextBoxX1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX1.TextChanged
        If ButtonX3.Enabled = False Then
            Dim nombre As String = TextBoxX1.Text
            CargarComboCliente2(nombre)
            '_CodCliente = cbCliente.Value
            'CargarPrestamoCliente(_CodCliente)
            If CType(grClientes.DataSource, DataTable).Rows.Count > 0 Then
                grClientes.Visible = True
            End If
            If _CodCliente <> 0 Then
                CargarPrestamoCliente(_CodCliente)
            End If
            If TextBoxX1.Text = "" Then
                grClientes.Visible = False
            End If
        End If

    End Sub

    Private Sub grClientes_EditingCell(sender As Object, e As EditingCellEventArgs) Handles grClientes.EditingCell
        e.Cancel = True
    End Sub

    Private Sub grClientes_SelectionChanged(sender As Object, e As EventArgs) Handles grClientes.SelectionChanged
        ' grClientes.Visible = False
    End Sub

    Private Sub grClientes_Click(sender As Object, e As EventArgs) Handles grClientes.Click
        _CodCliente = grClientes.GetValue("ydnumi")
        TextBoxX1.Text = grClientes.GetValue("nombre")
        grClientes.Visible = False
    End Sub

    Private Sub JGrM_Buscador_Click(sender As Object, e As EventArgs) Handles JGrM_Buscador.Click

    End Sub

    Private Sub gr_detalle_Click(sender As Object, e As EventArgs) Handles gr_detalle.Click

        If (Not Accesible()) Then
            Return
        End If
        If (CType(gr_detalle.DataSource, DataTable).Rows.Count > 0 And gr_detalle.GetValue("pendiente") <> 0) Then
            'If (gr_detalle.CurrentColumn.Index = gr_detalle.RootTable.Columns("check1").Index) Then
            MostrarAyuda()

            CargarPrestamoDetalle(grPrestamo.GetValue("numi"))
            _prCalcularTotal()
            tbMonto.Text = "0.00"
            Dim saldo As Double = 0
            'For i As Integer = 0 To gr_detalle.RowCount - 1 Step 1
            '    If CType(gr_detalle.DataSource, DataTable).Rows(i).Item("check1") = False Then
            '        saldo = saldo + CDbl(CType(gr_detalle.DataSource, DataTable).Rows(i).Item("monto"))
            '    End If
            'Next
            tbTotalCobrar.Text = saldo.ToString
            _prCargarIconPagar()
            'End If
        End If

    End Sub

    Private Sub ButtonX4_Click(sender As Object, e As EventArgs) Handles ButtonX4.Click
        If (Not Accesible()) Then
            Return
        End If
        If (CType(gr_detalle.DataSource, DataTable).Rows.Count > 0) Then
            'If (gr_detalle.CurrentColumn.Index = gr_detalle.RootTable.Columns("check1").Index) Then
            MostrarAyuda()

            CargarPrestamoDetalle(grPrestamo.GetValue("numi"))
            _prCalcularTotal()
            tbMonto.Text = "0.00"
            Dim saldo As Double = 0
            'For i As Integer = 0 To gr_detalle.RowCount - 1 Step 1
            '    If CType(gr_detalle.DataSource, DataTable).Rows(i).Item("check1") = False Then
            '        saldo = saldo + CDbl(CType(gr_detalle.DataSource, DataTable).Rows(i).Item("monto"))
            '    End If
            'Next
            tbTotalCobrar.Text = saldo.ToString
            _prCargarIconPagar()
            'End If
        End If
        _Limpiar()
        TextBoxX1.Focus()
    End Sub

    Private Sub tbAnular_Click(sender As Object, e As EventArgs) Handles tbAnular.Click

    End Sub




#End Region

End Class