Imports Logica.AccesoLogica
Imports Modelo.MGlobal
Imports DevComponents.DotNetBar.Controls
Imports DevComponents.DotNetBar.Metro
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Rendering

Public Class P_Principal

#Region "Atributos"

#End Region

    'Dim FVentas As F0_Ventas
    'Dim FSearchProductos As F0_BuscarProductos

#Region "Metodos Privados"

    Public Sub New()
        _prCambiarStyle()
        ' This call is required by the designer.
        InitializeComponent()
        FP_Configuracion.Select ()

        ' Add any initialization after the InitializeComponent() call.
        cargarProgramaVentas()
    End Sub
    Private Sub _prIniciarTodo()
        'Leer Archivo de Configuración
        _prLeerArchivoConfig()

        L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, gs_NombreBD)
        ''L_prAbrirConexionBitacora(gs_Ip, gs_UsuarioSql, gs_ClaveSql, "BDDiconDinoEco")

        Me.WindowState = FormWindowState.Maximized

        'iniciar login de usuario
        _prLogin()
        Try
            If System.IO.File.Exists(gs_CarpetaRaiz + "\LogoIco.ico") Then
                Me.Icon = Icon.ExtractAssociatedIcon(gs_CarpetaRaiz + "\LogoIco.ico")
            End If

        Catch ex As Exception

        End Try


    End Sub


    Private Sub _prCambiarStyle()
        'tratar de cambiar estilo
        'RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(Me, DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.Silver, Color.FromArgb(0, 85, 139))

        RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(Me, DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.VistaGlass)
        'RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(Me, eStyle.VisualStudio2012Dark)
        'RibbonPredefinedColorSchemes.ChangeStyle(eStyle.VisualStudio2012Dark)

        'cambio de otros colores
        Dim table As Office2007ColorTable = CType(GlobalManager.Renderer, Office2007Renderer).ColorTable
        Dim ct As SideNavColorTable = table.SideNav
        ''  ct.TitleBackColor = Color.FromArgb(49, 59, 66)
        'ct.SideNavItem.MouseOver.BackColors = New Color() {Color.Red, Color.Yellow}
        ct.SideNavItem.MouseOver.BorderColors = New Color() {Color.FromArgb(49, 59, 66)} ' No border
        ct.SideNavItem.Selected.BackColors = New Color() {Color.Yellow}
        ''     ct.BorderColors = New Color() {Color.FromArgb(49, 59, 66)} ' Control border color

        ''  ct.PanelBackColor = Color.FromArgb(49, 59, 66)
    End Sub

    Private Sub _prLeerArchivoConfig()
        Dim Archivo() As String = IO.File.ReadAllLines(Application.StartupPath + "\CONFIG.TXT")
        gs_Ip = Archivo(0).Split("=")(1).Trim
        gs_UsuarioSql = Archivo(1).Split("=")(1).Trim
        gs_ClaveSql = Archivo(2).Split("=")(1).Trim
        gs_NombreBD = Archivo(3).Split("=")(1).Trim
        gs_CarpetaRaiz = Archivo(4).Split("=")(1).Trim
    End Sub

    Private Sub _prLogin()
        Dim ef = New Efecto
        ef.tipo = 4
        ef.ShowDialog()

        L_Usuario = gs_user
        Modelo.MGlobal.gs_usuario = gs_user

        'lbUsuario.Text = gs_user
        'lbUsuario.Font = New Font("Tahoma", 12, FontStyle.Bold)

        If gs_user = "DEFAULT" Then
            SideNav1.Enabled = False
        Else
            _PCargarPrivilegios()
            _prCargarConfiguracionSistema()
            SideNav1.Enabled = True
        End If

        P_prCargarParametros()
        _prValidarMayusculas()
    End Sub
    Public Sub _prValidarMayusculas()
        Dim dt As DataTable = L_fnPorcUtilidad()
        If (dt.Rows.Count > 0) Then
            Modelo.MGlobal.gs_mayusuculas = dt.Rows(0).Item("mayusculas")
        End If
    End Sub

    Private Sub P_prCargarParametros()
        Dim dtConfSistema As DataTable = L_fnConfSistemaGeneral()

        gb_FacturaEmite = dtConfSistema.Rows(0).Item("cccefac")
        gi_FacturaTipo = dtConfSistema.Rows(0).Item("ccctfac")
        gi_FacturaCantidadItems = dtConfSistema.Rows(0).Item("ccccite")
        gb_FacturaIncluirICE = dtConfSistema.Rows(0).Item("ccciice")
        'gi_codeBar = dtConfSistema.Rows(0).Item("ccciice")
        gb_CodigoBarra = dtConfSistema.Rows(0).Item("ccccbar")
        gb_DetalleProducto = dtConfSistema.Rows(0).Item("cccdetp")

        gb_UbiLogo = dtConfSistema.Rows(0).Item("cccubilogo")
        gb_NotaAdicional = dtConfSistema.Rows(0).Item("cccnotaadic")
    End Sub

    Private Sub _prCargarConfiguracionSistema()
        'Dim dtConf As DataTable = L_prConGlobalGeneral()
        'gd_notaAproTeo = dtConf.Rows(0).Item("gbaproteo")

    End Sub

    Private Sub _PCargarPrivilegios()
        Dim listaTabs As New List(Of DevComponents.DotNetBar.Metro.MetroTilePanel)
        listaTabs.Add(MetroTilePanel1)
        listaTabs.Add(MetroTilePanel2)
        'listaTabs.Add(MetroTilePanel6)
        'listaTabs.Add(MetroTilePanel7)
        'listaTabs.Add(MetroTilePanelVentas)
        listaTabs.Add(MenuCreditos)


        Dim idRolUsu As String = gi_userRol

        Dim dtModulos As DataTable = L_prLibreriaDetalleGeneral(gi_LibSistema, gi_LibSISModulo)
        Dim listFormsModulo As New List(Of String)

        For i = 0 To dtModulos.Rows.Count - 1
            Dim dtDetRol As DataTable = L_RolDetalle_General(-1, idRolUsu, dtModulos.Rows(i).Item("cnnum"))
            listFormsModulo = New List(Of String)

            If dtDetRol.Rows.Count > 0 Then
                'cargo los nombres de los programas(botones) del modulo
                For Each fila As DataRow In dtDetRol.Rows
                    listFormsModulo.Add(fila.Item("yaprog").ToString.ToUpper)
                Next
                'recorro el modulo(tab) que corresponde
                For Each _item As DevComponents.DotNetBar.BaseItem In listaTabs.Item(i).Items
                    If TypeOf (_item) Is DevComponents.DotNetBar.Metro.MetroTileItem Then 'es un boton del modulo
                        Dim btn As DevComponents.DotNetBar.Metro.MetroTileItem = CType(_item, DevComponents.DotNetBar.Metro.MetroTileItem)
                        If listFormsModulo.Contains(btn.Name.ToUpper) Then 'si el nombre del boton pertenece a la lista de formularios del modulo
                            Dim Texto As String = btn.Text
                            Dim TTexto As String = btn.TitleText
                            Dim f As Integer = listFormsModulo.IndexOf(btn.Name.ToUpper)
                            If Texto = "" Then 'esta usando el Title Text
                                btn.TitleText = dtDetRol.Rows(f).Item("yatit").ToString.ToUpper
                            Else 'esta usando el Text
                                btn.Text = dtDetRol.Rows(f).Item("yatit").ToString.ToUpper
                            End If

                            If dtDetRol.Rows(f).Item("ycshow") = True Or dtDetRol.Rows(f).Item("ycadd") = True Or dtDetRol.Rows(f).Item("ycmod") = True Or dtDetRol.Rows(f).Item("ycdel") = True Then
                                btn.Visible = True
                            Else
                                btn.Visible = False
                            End If
                        Else 'si no pertenece lo oculto
                            btn.Visible = False
                        End If
                    Else 'seria un sub grupo en el modulo
                        'recorro todos los elementos del sub grupo
                        If TypeOf _item Is ItemContainer Then
                            For Each _subItem In _item.SubItems
                                Dim _subBtn As MetroTileItem = CType(_subItem, MetroTileItem)
                                If listFormsModulo.Contains(_subBtn.Name.ToUpper) Then
                                    Dim Texto As String = _subBtn.Text
                                    Dim TTexto As String = _subBtn.TitleText
                                    Dim f As Integer = listFormsModulo.IndexOf(_subBtn.Name.ToUpper)
                                    If Texto = "" Then 'esta usando el Title Text
                                        _subBtn.TitleText = dtDetRol.Rows(f).Item("yatit").ToString.ToUpper
                                    Else 'esta usando el Text
                                        _subBtn.Text = dtDetRol.Rows(f).Item("yatit").ToString.ToUpper
                                    End If

                                    If dtDetRol.Rows(f).Item("ycshow") = True Or dtDetRol.Rows(f).Item("ycadd") = True Or dtDetRol.Rows(f).Item("ycmod") = True Or dtDetRol.Rows(f).Item("ycdel") = True Then
                                        _subBtn.Visible = True
                                    Else
                                        _subBtn.Visible = False
                                    End If
                                Else
                                    _subBtn.Visible = False
                                End If
                            Next
                        End If

                    End If
                Next
            Else ' no exiten formulario registrados en el modulo pero igual hay que ocultar los botones y los subbotones que tenga
                For Each _item As DevComponents.DotNetBar.BaseItem In listaTabs.Item(i).Items
                    If TypeOf (_item) Is DevComponents.DotNetBar.Metro.MetroTileItem Then 'es un boton del modulo
                        Dim btn As DevComponents.DotNetBar.Metro.MetroTileItem = CType(_item, DevComponents.DotNetBar.Metro.MetroTileItem)
                        btn.Visible = False
                    Else 'seria un sub grupo en el modulo
                        'recorro todos los elementos del sub grupo
                        If TypeOf _item Is ItemContainer Then
                            For Each _subItem In _item.SubItems
                                Dim _subBtn As MetroTileItem = CType(_subItem, MetroTileItem)
                                _subBtn.Visible = False
                            Next
                        End If

                    End If
                Next

            End If

        Next

        'refrescar el formulario
        Me.Refresh()
    End Sub
#End Region

    Private Sub P_Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
        'cargarProgramaVentas()
    End Sub


    Public Sub cargarProgramaVentas()

        'VentanaVenta.Select()

        'FVentas = New F0_Ventas With {.TopLevel = False, .AutoSize = True}
        'FVentas._nameButton = btVentVenta.Name
        'FVentas._modulo = FP_INVENTARIO
        'FVentas._tab = Nothing
        'FVentas.Parent = PanelVentaAtajo
        'FVentas.Visible = False


        'FSearchProductos = New F0_BuscarProductos With {.TopLevel = False, .AutoSize = True}

        'FSearchProductos.Parent = PanelBuscador
        'FSearchProductos.Visible = False

        'f.Show()

        'Dim frm As New F0_Ventas
        'frm._nameButton = btConfCliente.Name
        'frm._modulo = FP_INVENTARIO
        'frm._tab = Nothing

        'Dim panel As Panel = P_Global._fnCrearPanelVentanas(frm)


        'PanelVentaAtajo.Controls.Add(panel)
        'frm.Show()


    End Sub

    Private Sub P_Principal_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
        _prLogin()
    End Sub

    Private Sub P_Principal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        _prLogin()
    End Sub

    Private Sub rmSesion_ItemClick(sender As Object, e As EventArgs) Handles rmSesion.ItemClick
        Dim item As RadialMenuItem = TryCast(sender, RadialMenuItem)
        If item IsNot Nothing AndAlso (Not String.IsNullOrEmpty(item.Text)) Then
            Select Case item.Name
                Case "btCerrarSesion"
                    _prLogin()
                Case "btSalir"
                    Me.Close()
                Case "btAbout"
                    'Dim frm As New P_Acerca
                    'frm.ShowDialog()
            End Select
        End If
    End Sub



    Private Sub btConfRoles_Click(sender As Object, e As EventArgs) Handles btConfRoles.Click
        'SideNav1.IsMenuExpanded = False
        'Ventana.Select()
        ''Dim frm As New F0_Roles
        Dim frm As New F1_Rol
        frm._nameButton = btConfRoles.Name
        frm._modulo = FP_Configuracion
        'Dim tab3 As SuperTabItem = superTabControl3.CreateTab(frm.Text)
        'tab3.RecalcSize()
        'tab3.ThemeAware = True
        'tab3.ShowSubItems = True
        'tab3.UpdateBindings()
        'frm._tab = tab3
        'Dim panel As Panel = P_Global._fnCrearPanelVentanas(frm)
        'superTabControl3.SelectedTabIndex = superTabControl3.Tabs.Count - 1
        'tab3.AttachedControl.Controls.Add(panel)
        frm.Show()
        'tab3.Text = frm.Text
        'tab3.Icon = frm.Icon
    End Sub

    Private Sub btConfUsuarios_Click(sender As Object, e As EventArgs) Handles btConfUsuarios.Click
        'SideNav1.IsMenuExpanded = False
        'Ventana.Select()
        Dim frm As New F0_Usuarios
        frm._nameButton = btConfUsuarios.Name
        frm._modulo = FP_Configuracion
        'Dim tab3 As SuperTabItem = superTabControl3.CreateTab(frm.Text)
        'frm._tab = tab3
        'Dim panel As Panel = P_Global._fnCrearPanelVentanas(frm)
        'superTabControl3.SelectedTabIndex = superTabControl3.Tabs.Count - 1
        'tab3.AttachedControl.Controls.Add(panel)
        frm.Show()
        'tab3.Text = frm.Text
        'tab3.Icon = frm.Icon

    End Sub



    Private Sub Ventana_Click(sender As Object, e As EventArgs) Handles Ventana.Click
        SideNav1.IsMenuExpanded = False
    End Sub

    Private Sub SideNav1_IsMenuExpandedChanged(sender As Object, e As EventArgs) Handles SideNav1.IsMenuExpandedChanged
        If (SideNav1.IsMenuExpanded = True) Then
            FP_Configuracion.Select()

        End If
    End Sub

    Private Sub SideNavItem3_Click(sender As Object, e As EventArgs) Handles SideNavItem3.Click
        rmSesion.IsOpen = True
        rmSesion.MenuLocation = New Point(Me.Width / 2, Me.Height / 3)
        SideNav_Conf.Select()

    End Sub

    Private Sub rmSesion_MenuClosed(sender As Object, e As EventArgs) Handles rmSesion.MenuClosed
        FP_Configuracion.Select()

    End Sub

    Private Sub btConfFabrica_Click(sender As Object, e As EventArgs) Handles btConfCliente.Click
        'SideNav1.IsMenuExpanded = False
        'Ventana.Select()
        F1_Clientes.AllowTransparency = True
        Dim frm As New F1_Clientes
        frm._Tipo = 1
        frm._nameButton = btConfCliente.Name
        frm._modulo = FP_Configuracion
        'Dim tab3 As SuperTabItem = superTabControl3.CreateTab(frm.Text)
        'frm._tab = tab3
        'Dim panel As Panel = P_Global._fnCrearPanelVentanas(frm)
        'superTabControl3.SelectedTabIndex = superTabControl3.Tabs.Count - 1
        'tab3.AttachedControl.Controls.Add(panel)
        frm.Show()
        'tab3.Text = frm.Text
        'tab3.Icon = frm.Icon

    End Sub



    Private Sub btCatCatalogo_Click(sender As Object, e As EventArgs) Handles btZonas.Click
        SideNav1.IsMenuExpanded = False
        Ventana.Select()
        Dim frm As New F1_Zonas
        frm._nameButton = btZonas.Name
        frm._modulo = FP_ZONAS
        Dim tab3 As SuperTabItem = superTabControl3.CreateTab(frm.Text)
        frm._tab = tab3
        Dim panel As Panel = P_Global._fnCrearPanelVentanas(frm)
        superTabControl3.SelectedTabIndex = superTabControl3.Tabs.Count - 1
        tab3.AttachedControl.Controls.Add(panel)
        frm.Show()
        tab3.Text = frm.Text
        tab3.Icon = frm.Icon
    End Sub



    Private Sub MetroTileItem12_Click(sender As Object, e As EventArgs)
        'SideNav1.IsMenuExpanded = False
        'Ventana.Select()
        Dim frm As New F1_Deposito
        frm._nameButton = btZonas.Name
        frm._modulo = FP_ZONAS
        'Dim tab3 As SuperTabItem = superTabControl3.CreateTab(frm.Text)
        'frm._tab = tab3
        'Dim panel As Panel = P_Global._fnCrearPanelVentanas(frm)
        'superTabControl3.SelectedTabIndex = superTabControl3.Tabs.Count - 1
        'tab3.AttachedControl.Controls.Add(panel)
        frm.Show()
        'tab3.Text = frm.Text
        'tab3.Icon = frm.Icon
    End Sub

    Private Sub btInvAmacen_Click(sender As Object, e As EventArgs)
        SideNav1.IsMenuExpanded = False
        Ventana.Select()
        Dim frm As New F1_Almacen
        frm._nameButton = btZonas.Name
        frm._modulo = FP_ZONAS
        Dim tab3 As SuperTabItem = superTabControl3.CreateTab(frm.Text)
        frm._tab = tab3
        Dim panel As Panel = P_Global._fnCrearPanelVentanas(frm)
        superTabControl3.SelectedTabIndex = superTabControl3.Tabs.Count - 1
        tab3.AttachedControl.Controls.Add(panel)
        frm.Show()
        tab3.Text = frm.Text
        tab3.Icon = frm.Icon
    End Sub



    Private Sub superTabControl3_TabItemClose(sender As Object, e As SuperTabStripTabItemCloseEventArgs) Handles superTabControl3.TabItemClose
        Dim cantidad As Integer = superTabControl3.Tabs.Count
        If cantidad = 1 Then
            FP_Configuracion.Select()
        End If
    End Sub




    Private Sub btConfAccesorio_Click(sender As Object, e As EventArgs) Handles btConfLibreria.Click
        'SideNav1.IsMenuExpanded = False
        'Ventana.Select()
        Dim frm As New F0_Libreria
        frm._nameButton = btConfLibreria.Name
        frm._modulo = FP_Configuracion
        'Dim tab3 As SuperTabItem = superTabControl3.CreateTab(frm.Text)
        'frm._tab = tab3
        'Dim panel As Panel = P_Global._fnCrearPanelVentanas(frm)
        'superTabControl3.SelectedTabIndex = superTabControl3.Tabs.Count - 1
        'tab3.AttachedControl.Controls.Add(panel)
        frm.Show()
        'tab3.Text = frm.Text
        'Dim blah As New Bitmap(New Bitmap(My.Resources.check_mark), 20, 20)
        'Dim ico As Icon = Icon.FromHandle(blah.GetHicon())
        'tab3.Icon = ico
    End Sub


    Private Sub btnCredPagoClienteVendedor_Click(sender As Object, e As EventArgs) Handles btnCredPagoClienteVendedor.Click
        'SideNav1.IsMenuExpanded = False
        'Ventana.Select()
        'Dim frm As New F0_Cobrar_Vendedor
        'frm._nameButton = btInvMovimiento.Name
        'frm._modulo = FP_CREDITOS
        'Dim tab3 As SuperTabItem = superTabControl3.CreateTab(frm.Text)
        'frm._tab = tab3
        'Dim panel As Panel = P_Global._fnCrearPanelVentanas(frm)
        'superTabControl3.SelectedTabIndex = superTabControl3.Tabs.Count - 1
        'tab3.AttachedControl.Controls.Add(panel)
        'frm.Show()
        'tab3.Text = frm.Text
        'tab3.Icon = frm.Icon


        Dim frm As New F0_Prestamo
        frm._nameButton = btnCredPagoClienteVendedor.Name
        frm._modulo = FP_CREDITOS
        frm.Show()

    End Sub




    Private Sub btZonas1_Click(sender As Object, e As EventArgs) Handles btZonas1.Click

        Dim frm As New F1_Zonas
        frm._nameButton = btZonas1.Name
        frm.Show()
    End Sub











    Private Sub btBancos_Click(sender As Object, e As EventArgs) Handles btBancos.Click
        Dim frm As New F1_Bancos
        frm._nameButton = btBancos.Name
        frm.Show()
    End Sub

    Private Sub lbUsuario_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btReportePrestamos_Click(sender As Object, e As EventArgs) Handles btReportePrestamos.Click
        Dim frm As New Pr_PrestamosCliente
        frm.Show()
    End Sub

    Private Sub btCobroPrestamo_Click(sender As Object, e As EventArgs) Handles btCobroPrestamo.Click
        Dim frm As New F0_Cobrar_Vendedor
        frm._nameButton = btCobroPrestamo.Name
        frm.Show()

    End Sub

    Private Sub btCreditosVencidos_Click(sender As Object, e As EventArgs) Handles btCreditosVencidos.Click
        Dim frm As New Pr_CreditosVencidos
        frm.Show()
    End Sub

    Private Sub btAbonoRealizado_Click(sender As Object, e As EventArgs) Handles btAbonoRealizado.Click
        Dim frm As New Pr_AbonosRealizados
        frm.Show()
    End Sub

    Private Sub btControlPagos_Click(sender As Object, e As EventArgs) Handles btControlPagos.Click
        Dim frm As New Pr_ControlPagos
        frm.Show()
    End Sub

    Private Sub btMorosidad_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnCuotasAdeudadas_Click(sender As Object, e As EventArgs) Handles btnCuotasAdeudadas.Click
        If Not IsNothing(P_Global.Visualizador) Then
            P_Global.Visualizador.Close()
        End If
        Dim dt As DataTable = cuotasAdeudadas()
        Dim objrep As New R_CuotasAdeudadas
        objrep.SetDataSource(dt)
        P_Global.Visualizador = New Visualizador
        P_Global.Visualizador.CrGeneral.ReportSource = objrep
        P_Global.Visualizador.ShowDialog()
        P_Global.Visualizador.BringToFront()
    End Sub

    Private Sub btnUtilidad_Click(sender As Object, e As EventArgs) Handles btnUtilidad.Click
        Dim frm As New Pr_Utilidad
        frm.Show()
    End Sub

    Private Sub btnUtilidad2_Click(sender As Object, e As EventArgs) Handles btnUtilidad2.Click
        Dim frm As New Pr_PrestamosCliente2
        frm.Show()
    End Sub

    Private Sub btSaldosPrestamos_Click(sender As Object, e As EventArgs) Handles btSaldosPrestamos.Click
        Dim frm As New Pr_SaldosPrestamos
        frm.Show()

    End Sub
End Class