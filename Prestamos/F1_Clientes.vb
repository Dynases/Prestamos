
Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports Janus.Windows.GridEX

Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid

Imports GMap.NET.MapProviders
Imports GMap.NET
Imports GMap.NET.WindowsForms.Markers
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.ToolTips
Imports DevComponents.DotNetBar.Controls


Public Class F1_Clientes
    Dim _Inter As Integer = 0
#Region "Variables Locales"
#Region "MApas"
    Dim _Punto As Integer
    Dim _ListPuntos As List(Of PointLatLng)
    Dim _Overlay As GMapOverlay
    Dim _latitud As Double = 0
    Dim _longitud As Double = 0
#End Region
    Dim RutaGlobal As String = gs_CarpetaRaiz
    Dim RutaTemporal As String = "C:\Temporal"
    Dim Modificado As Boolean = False
    Dim nameImg As String = "Default.jpg"
    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem
    Public _Tipo As Integer = 1
    Dim NumiVendedor As Integer
#End Region
#Region "Metodos Privados"

    Private Sub _prIniciarTodo()

        Me.Text = "CLIENTES"
        _prInicarMapa()

        _prMaxLength()
        _prAsignarPermisos()
        _PMIniciarTodo()
        _prCargarComboLibreria(cbInstitucion, "10", "1")
        SuperTabItem1.Visible = False

        Dim blah As New Bitmap(New Bitmap(My.Resources.man_18), 20, 20)
        Dim ico As Icon = Icon.FromHandle(blah.GetHicon())
        Me.Icon = ico


    End Sub
    Private Sub P_IniciarMap()
        Gmc_Cliente.DragButton = MouseButtons.Left
        Gmc_Cliente.CanDragMap = True
        Gmc_Cliente.MapProvider = GMapProviders.GoogleMap
        If (_latitud <> 0 And _longitud <> 0) Then

            Gmc_Cliente.Position = New PointLatLng(_latitud, _longitud)
        Else

            _Overlay.Markers.Clear()
            Gmc_Cliente.Position = New PointLatLng(-17.3931784, -66.1738852)
        End If

        Gmc_Cliente.MinZoom = 0
        Gmc_Cliente.MaxZoom = 24
        Gmc_Cliente.Zoom = 15.5
        Gmc_Cliente.AutoScroll = True

        GMapProvider.Language = LanguageType.Spanish
    End Sub
    Public Sub _prInicarMapa()
        _Punto = 0
        '_ListPuntos = New List(Of PointLatLng)
        _Overlay = New GMapOverlay("points")
        Gmc_Cliente.Overlays.Add(_Overlay)
        P_IniciarMap()
    End Sub
    Private Function _fnCopiarImagenRutaDefinida() As String
        'copio la imagen en la carpeta del sistema

        Dim file As New OpenFileDialog()
        file.Filter = "Ficheros JPG o JPEG o PNG|*.jpg;*.jpeg;*.png" & _
                      "|Ficheros GIF|*.gif" & _
                      "|Ficheros BMP|*.bmp" & _
                      "|Ficheros PNG|*.png" & _
                      "|Ficheros TIFF|*.tif"
        If file.ShowDialog() = DialogResult.OK Then
            Dim ruta As String = file.FileName


            If file.CheckFileExists = True Then
                Dim img As New Bitmap(New Bitmap(ruta))
                Dim imgM As New Bitmap(New Bitmap(ruta))
                Dim Bin As New MemoryStream
                imgM.Save(Bin, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim a As Object = file.GetType.ToString
                If (_fnActionNuevo()) Then

                    Dim mayor As Integer
                    mayor = JGrM_Buscador.GetTotal(JGrM_Buscador.RootTable.Columns("ydnumi"), AggregateFunction.Max)
                    nameImg = "\Imagen_" + Str(mayor + 1).Trim + ".jpg"
                    UsImg.pbImage.SizeMode = PictureBoxSizeMode.StretchImage
                    UsImg.pbImage.Image = Image.FromStream(Bin)

                    img.Save(RutaTemporal + nameImg, System.Drawing.Imaging.ImageFormat.Jpeg)
                    img.Dispose()
                Else

                    nameImg = "\Imagen_" + Str(tbCodigoOriginal.Text).Trim + ".jpg"


                    UsImg.pbImage.Image = Image.FromStream(Bin)
                    img.Save(RutaTemporal + nameImg, System.Drawing.Imaging.ImageFormat.Jpeg)
                    Modificado = True
                    img.Dispose()

                End If
            End If

            Return nameImg
        End If

        Return "default.jpg"
    End Function
    Public Sub _prStyleJanus()
        GroupPanelBuscador.Style.BackColor = Color.FromArgb(13, 71, 161)
        GroupPanelBuscador.Style.BackColor2 = Color.FromArgb(13, 71, 161)
        GroupPanelBuscador.Style.TextColor = Color.White
        JGrM_Buscador.RootTable.HeaderFormatStyle.FontBold = TriState.True
    End Sub

    Public Sub _prMaxLength()

        tbCI.MaxLength = 50
        tbCelular.MaxLength = 200
        tbCorreo.MaxLength = 50
        tbDirDomicilio.MaxLength = 50
        tbDirTrabajo.MaxLength = 150

    End Sub

    Private Sub _prCargarComboLibreria(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo, cod1 As String, cod2 As String)
        Dim dt As New DataTable
        dt = L_prLibreriaClienteLGeneral(cod1, cod2)
        With mCombo
            .DropDownList.Columns.Clear()
            .DropDownList.Columns.Add("yccod3").Width = 70
            .DropDownList.Columns("yccod3").Caption = "COD"
            .DropDownList.Columns.Add("ycdes3").Width = 200
            .DropDownList.Columns("ycdes3").Caption = "DESCRIPCION"
            .ValueMember = "yccod3"
            .DisplayMember = "ycdes3"
            .DataSource = dt
            .Refresh()
        End With
    End Sub
    Private Sub _prCargarComboLibreriaZona(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo)
        Dim dt As New DataTable
        dt = L_prLibreriaClienteLGeneralZonas()
        With mCombo
            .DropDownList.Columns.Clear()
            .DropDownList.Columns.Add("yccod3").Width = 60
            .DropDownList.Columns("yccod3").Caption = "COD"
            .DropDownList.Columns.Add("ycdes3").Width = 500
            .DropDownList.Columns("ycdes3").Caption = "DESCRIPCION"
            .ValueMember = "yccod3"
            .DisplayMember = "ycdes3"
            .DataSource = dt
            .Refresh()
        End With
    End Sub

    Private Sub _prCargarComboLibreriaFecuenciaVisita(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo)
        Dim dt As New DataTable
        dt = L_prLibreriaClienteLGeneralFrecVisita()
        With mCombo
            .DropDownList.Columns.Clear()
            .DropDownList.Columns.Add("yccod3").Width = 60
            .DropDownList.Columns("yccod3").Caption = "COD"
            .DropDownList.Columns.Add("ycdes3").Width = 500
            .DropDownList.Columns("ycdes3").Caption = "DESCRIPCION"
            .ValueMember = "yccod3"
            .DisplayMember = "ycdes3"
            .DataSource = dt
            .Refresh()
        End With
    End Sub
    Private Sub _prCargarComboLibreriaCategoriaPrecios(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo)
        Dim dt As New DataTable
        dt = L_prLibreriaClienteLGeneralPrecios()
        With mCombo
            .DropDownList.Columns.Clear()
            .DropDownList.Columns.Add("ygnumi").Width = 60
            .DropDownList.Columns("ygnumi").Caption = "COD"
            .DropDownList.Columns.Add("ygdesc").Width = 500
            .DropDownList.Columns("ygdesc").Caption = "DESCRIPCION"
            .ValueMember = "ygnumi"
            .DisplayMember = "ygdesc"
            .DataSource = dt
            .Refresh()
        End With
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
    Private Sub _prCrearCarpetaTemporal()

        If System.IO.Directory.Exists(RutaTemporal) = False Then
            System.IO.Directory.CreateDirectory(RutaTemporal)
        Else
            Try
                My.Computer.FileSystem.DeleteDirectory(RutaTemporal, FileIO.DeleteDirectoryOption.DeleteAllContents)
                My.Computer.FileSystem.CreateDirectory(RutaTemporal)
                'My.Computer.FileSystem.DeleteDirectory(RutaTemporal, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
                'System.IO.Directory.CreateDirectory(RutaTemporal)

            Catch ex As Exception

            End Try

        End If

    End Sub
    Private Sub _prCrearCarpetaImagenes()
        Dim rutaDestino As String = RutaGlobal + "\Imagenes\Imagenes ClienteDino\"

        If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes ClienteDino\") = False Then
            If System.IO.Directory.Exists(RutaGlobal + "\Imagenes") = False Then
                System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes")
                If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes ClienteDino") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes ClienteDino")
                End If
            Else
                If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes ClienteDino") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes ClienteDino")

                End If
            End If
        End If
    End Sub

    Private Sub _prCrearCarpetaReportes()
        Dim rutaDestino As String = RutaGlobal + "\Reporte\Reporte ClienteDino\"

        If System.IO.Directory.Exists(RutaGlobal + "\Reporte\Reporte ClienteDino\") = False Then
            If System.IO.Directory.Exists(RutaGlobal + "\Reporte") = False Then
                System.IO.Directory.CreateDirectory(RutaGlobal + "\Reporte")
                If System.IO.Directory.Exists(RutaGlobal + "\Reporte\Reporte ClienteDino") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Reporte\Reporte ClienteDino")
                End If
            Else
                If System.IO.Directory.Exists(RutaGlobal + "\Reporte\Reporte ClienteDino") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Reporte\Reporte ClienteDino")

                End If
            End If
        End If
    End Sub
    Private Sub _fnMoverImagenRuta(Folder As String, name As String)
        'copio la imagen en la carpeta del sistema
        If (Not name.Equals("Default.jpg") And File.Exists(RutaTemporal + name)) Then

            Dim img As New Bitmap(New Bitmap(RutaTemporal + name), 500, 300)

            UsImg.pbImage.Image.Dispose()
            UsImg.pbImage.Image = Nothing
            Try
                My.Computer.FileSystem.CopyFile(RutaTemporal + name,
     Folder + name, overwrite:=True)

            Catch ex As System.IO.IOException


            End Try



        End If
    End Sub
#End Region
#Region "METODOS SOBRECARGADOS"

    Public Overrides Sub _PMOHabilitar()
        cbInstitucion.ReadOnly = False
        tbNombres.ReadOnly = False
        tbApellidos.ReadOnly = False
        tbTelefono.ReadOnly = False
        tbCI.ReadOnly = False
        tbCelular.ReadOnly = False
        tbCorreo.ReadOnly = False
        tbDirDomicilio.ReadOnly = False
        tbDirTrabajo.ReadOnly = False

        tbGNombres.ReadOnly = False
        tbGApellidos.ReadOnly = False
        tbGTelefono.ReadOnly = False
        tbGCI.ReadOnly = False
        tbGCelular.ReadOnly = False
        tbGDirDomicilio.ReadOnly = False
        tbGDirTrabajo.ReadOnly = False
        tbNroCuenta.ReadOnly = False
        'tbFIngr.Enabled = True
        'tbUltVenta.Enabled = True

        _prCrearCarpetaImagenes()
        _prCrearCarpetaTemporal()
        BtAdicionar.Visible = True
        tbNombres.ReadOnly = False
        tbApellidos.Focus()
        ''  SuperTabItem1.Visible =True 
    End Sub

    Public Overrides Sub _PMOInhabilitar()
        cbInstitucion.ReadOnly = True
        tbApellidos.ReadOnly = True
        tbCodigoOriginal.ReadOnly = True
        tbNombres.ReadOnly = True
        tbCI.ReadOnly = True
        tbTelefono.ReadOnly = True
        tbCelular.ReadOnly = True
        tbCorreo.ReadOnly = True
        tbDirDomicilio.ReadOnly = True
        tbDirTrabajo.ReadOnly = True

        tbGNombres.ReadOnly = True
        tbGApellidos.ReadOnly = True
        tbGTelefono.ReadOnly = True
        tbGCI.ReadOnly = True
        tbGCelular.ReadOnly = True
        tbGDirDomicilio.ReadOnly = True
        tbGDirTrabajo.ReadOnly = True
        tbNroCuenta.ReadOnly = True

        BtAdicionar.Visible = False
        _prStyleJanus()
        JGrM_Buscador.Focus()

        ' SuperTabItem1.Visible = False
    End Sub

    Public Overrides Sub _PMOLimpiar()
        cbInstitucion.SelectedIndex = 0
        tbCodigoOriginal.Clear()
        tbNombres.Clear()
        tbCI.Clear()
        tbCelular.Clear()
        tbCorreo.Clear()
        tbApellidos.Clear()

        tbDirDomicilio.Clear()
        tbDirTrabajo.Clear()
        'cbCatPrec.SelectedIndex = -1
        'cbZona.SelectedIndex = -1
        'cbTipoDoc.SelectedIndex = -1

        UsImg.pbImage.Image = My.Resources.pantalla
        _Overlay.Markers.Clear()
        _latitud = 0
        _longitud = 0

        tbTelefono.Clear()

        tbGNombres.Clear()
        tbGApellidos.Clear()
        tbGTelefono.Clear()
        tbGCI.Clear()
        tbGCelular.Clear()
        tbGDirDomicilio.Clear()
        tbGDirTrabajo.Clear()
        tbNroCuenta.Clear()

    End Sub

    Public Overrides Sub _PMOLimpiarErrores()
        MEP.Clear()
        tbCI.BackColor = Color.White
        tbCelular.BackColor = Color.White
    End Sub

    Public Overrides Function _PMOGrabarRegistro() As Boolean

        'ByRef _ydnumi As String, _ydcod As String,
        '                                       _yddesc As String, _ydzona As Integer,
        '                                       _yddct As Integer, _yddctnum As String,
        '                                       _yddirec As String, _ydtelf1 As String,
        '                                       _ydtelf2 As String, _ydcat As Integer, _ydest As Integer, _ydlat As Double, _ydlongi As Double, _ydobs As String,
        '                                       _ydfnac As String, _ydnomfac As String,
        '                                       _ydtip As Integer, _ydnit As String, _ydfecing As String, _ydultvent As String, _ydimg As String

        Dim res As Boolean = L_fnGrabarCLiente(tbCodigoOriginal.Text, tbNombres.Text, tbApellidos.Text, tbCI.Text, tbTelefono.Text,
                                               tbCelular.Text, tbCorreo.Text, tbDirDomicilio.Text, tbDirTrabajo.Text, 1, tbNroCuenta.Text,
                                               "", "", 0, 0, 0, "", "", 0.000000000000, 0.00000000000, 1, Date.Now.ToString("dd/MM/yyyy"),
                                               nameImg, cbInstitucion.Value) 'NumiVendedor, cbZona.Value, cbTipoDoc.Value, tbNdoc.Text, tbCelular.Text, tbCorreo.Text, tbDirDomicilio.Text, cbCatPrec.Value, IIf(swEstado.Value = True, 1, 0), _latitud, _longitud, tbDirTrabajo.Text, tbFnac.Value.ToString("yyyy/MM/dd"), tbNombFac.Text, _Tipo, tbNit.Text, Tbdias.Text, TbLCred.Text, tbFIngr.Value.ToString("yyyy/MM/dd"), tbUltVenta.Value.ToString("yyyy/MM/dd"), nameImg, cbVisita.Value)


        If res Then
            If (gi_CodCliente = 1) Then
                gi_CodCliente = 2

                Me.Close()
                Exit Function
            End If
            Modificado = False
            _fnMoverImagenRuta(RutaGlobal + "\Imagenes\Imagenes ClienteDino", nameImg)
            nameImg = "Default.jpg"

            Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
            ToastNotification.Show(Me, "Código de Cliente ".ToUpper + tbCodigoOriginal.Text + " Grabado con Exito.".ToUpper,
                                      img, 2000,
                                      eToastGlowColor.Green,
                                      eToastPosition.TopCenter
                                      )
            tbCI.Focus()

        Else
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "El producto no pudo ser insertado".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)

        End If
        Return res

    End Function

    Public Overrides Function _PMOModificarRegistro() As Boolean
        Dim res As Boolean

        'Dim nameImage As String = JGrM_Buscador.GetValue("ydimg")
        If (Modificado = False) Then
            res = L_fnModificarClientes(tbCodigoOriginal.Text, tbNombres.Text, tbApellidos.Text, tbCI.Text, tbTelefono.Text,
                                               tbCelular.Text, tbCorreo.Text, tbDirDomicilio.Text, tbDirTrabajo.Text, 1, tbNroCuenta.Text,
                                               "", "", 0, 0, 0, "", "", 0.000000000000, 0.00000000000, 1, Date.Now.ToString("dd/MM/yyyy"),
                                               nameImg, cbInstitucion.Value)

        Else
            res = L_fnModificarClientes(tbCodigoOriginal.Text, tbNombres.Text, tbApellidos.Text, tbCI.Text, tbTelefono.Text,
                                               tbCelular.Text, tbCorreo.Text, tbDirDomicilio.Text, tbDirTrabajo.Text, 1, tbNroCuenta.Text,
                                               "", "", 0, 0, 0, "", "", 0.000000000000, 0.00000000000, 1, Date.Now.ToString("dd/MM/yyyy"),
                                               nameImg, cbInstitucion.Value)

        End If
        If res Then

            If (Modificado = True) Then
                _fnMoverImagenRuta(RutaGlobal + "\Imagenes\Imagenes ClienteDino", nameImg)
                Modificado = False
            End If
            nameImg = "Default.jpg"

            Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
            ToastNotification.Show(Me, "Código de Cliente ".ToUpper + tbCodigoOriginal.Text + " modificado con Exito.".ToUpper,
                                          img, 2000,
                                          eToastGlowColor.Green,
                                          eToastPosition.TopCenter)
            _PMInhabilitar()
            _PMOLimpiar()

        Else
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "EL Cliente no pudo ser modificado".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)

        End If
        Return res
    End Function


    Public Sub _PrEliminarImage()

        If (Not (_fnActionNuevo()) And (File.Exists(RutaGlobal + "\Imagenes\Imagenes ClienteDino\Imagen_" + tbCodigoOriginal.Text + ".jpg"))) Then
            UsImg.pbImage.Image.Dispose()
            UsImg.pbImage.Image = Nothing
            Try
                My.Computer.FileSystem.DeleteFile(RutaGlobal + "\Imagenes\Imagenes ClienteDino\Imagen_" + tbCodigoOriginal.Text + ".jpg")
            Catch ex As Exception

            End Try


        End If
    End Sub
    Public Function _fnActionNuevo() As Boolean
        Return tbCodigoOriginal.Text = String.Empty And tbCelular.ReadOnly = False
    End Function

    Public Overrides Sub _PMOEliminarRegistro()

        Dim ef = New Efecto


        ef.tipo = 2
        ef.Context = "¿esta seguro de eliminar el registro?".ToUpper
        ef.Header = "mensaje principal".ToUpper
        ef.ShowDialog()
        Dim bandera As Boolean = False
        bandera = ef.band
        If (bandera = True) Then
            Dim mensajeError As String = ""
            Dim res As Boolean = L_fnEliminarClientes(tbCodigoOriginal.Text, mensajeError)
            If res Then
                _PrEliminarImage()

                Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)

                ToastNotification.Show(Me, "Código de Cliente ".ToUpper + tbCodigoOriginal.Text + " eliminado con Exito.".ToUpper,
                                          img, 2000,
                                          eToastGlowColor.Green,
                                          eToastPosition.TopCenter)

                _PMFiltrar()
            Else
                Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
                ToastNotification.Show(Me, mensajeError, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            End If
        End If


    End Sub
    Public Overrides Function _PMOValidarCampos() As Boolean
        Dim _ok As Boolean = True
        MEP.Clear()

        If tbNroCuenta.Text = String.Empty Then
            tbNroCuenta.BackColor = Color.Red
            MEP.SetError(tbNroCuenta, "ingrese un numero de Cuenta!".ToUpper)
            _ok = False
        Else
            tbNroCuenta.BackColor = Color.White
            MEP.SetError(tbNroCuenta, "")
        End If

        MHighlighterFocus.UpdateHighlights()
        Return _ok
    End Function

    Public Overrides Function _PMOGetTablaBuscador() As DataTable
        Dim dtBuscador As DataTable = L_fnGeneralClientes(_Tipo)
        Return dtBuscador
    End Function

    Public Overrides Function _PMOGetListEstructuraBuscador() As List(Of Modelo.Celda)
        Dim listEstCeldas As New List(Of Modelo.Celda)
        'a.ydnumi, a.ydcod, a.yddesc, a.ydzona, a.yddct, a.yddctnum, a.yddirec, a.ydtelf1, a.ydtelf2, a.ydcat,
        'a.ydest, a.ydlat, a.ydlongi, a.ydprconsu, a.ydobs, a.ydfnac, a.ydnomfac, a.ydtip, a.ydnit, a.ydfecing, a.ydultvent,
        'a.ydimg,
        'a.ydfact, a.ydhact, a.yduact

        listEstCeldas.Add(New Modelo.Celda("ydnumi", True, "Código".ToUpper, 80))
        listEstCeldas.Add(New Modelo.Celda("ydcod", False, "Codigo".ToUpper, 80))
        listEstCeldas.Add(New Modelo.Celda("ydnom", True, "NOMBRES".ToUpper, 180))
        listEstCeldas.Add(New Modelo.Celda("ydapell", True, "AVAL".ToUpper, 250))
        listEstCeldas.Add(New Modelo.Celda("yddct", True, "N. Documento".ToUpper, 150))
        listEstCeldas.Add(New Modelo.Celda("ydtel", False))
        listEstCeldas.Add(New Modelo.Celda("ydcel", True, "CELULAR".ToUpper, 150))
        listEstCeldas.Add(New Modelo.Celda("ydcorr", False))
        listEstCeldas.Add(New Modelo.Celda("yddirdom", True, "Direccion".ToUpper, 180))
        listEstCeldas.Add(New Modelo.Celda("yddirtra", False))
        listEstCeldas.Add(New Modelo.Celda("ydgru", False))
        listEstCeldas.Add(New Modelo.Celda("ydGnom", False))
        listEstCeldas.Add(New Modelo.Celda("ydGapell", False))
        listEstCeldas.Add(New Modelo.Celda("ydGdct", False))
        listEstCeldas.Add(New Modelo.Celda("ydGtel", False))
        listEstCeldas.Add(New Modelo.Celda("ydGcel", False))
        listEstCeldas.Add(New Modelo.Celda("ydGdirdom", False))
        listEstCeldas.Add(New Modelo.Celda("ydGdirtra", False))
        listEstCeldas.Add(New Modelo.Celda("ydlat", False))
        listEstCeldas.Add(New Modelo.Celda("ydlongi", False))
        listEstCeldas.Add(New Modelo.Celda("ydest", False))
        listEstCeldas.Add(New Modelo.Celda("ydtip", False))
        listEstCeldas.Add(New Modelo.Celda("ydfecing", False))
        listEstCeldas.Add(New Modelo.Celda("ydimg", False))
        listEstCeldas.Add(New Modelo.Celda("ydhact", False))
        listEstCeldas.Add(New Modelo.Celda("yduact", False))
        listEstCeldas.Add(New Modelo.Celda("ydcuenta", True, "Nro Cuenta".ToUpper, 250))
        listEstCeldas.Add(New Modelo.Celda("ydins", False))
        Return listEstCeldas
    End Function

    Public Overrides Sub _PMOMostrarRegistro(_N As Integer)
        JGrM_Buscador.Row = _MPos
        'a.ydnumi, a.ydcod, a.yddesc, a.ydzona, a.yddct, a.yddctnum, a.yddirec, a.ydtelf1, a.ydtelf2, a.ydcat,
        'a.ydest, a.ydlat, a.ydlongi, a.ydprconsu, a.ydobs, a.ydfnac, a.ydnomfac, a.ydtip, a.ydnit, a.ydfecing, a.ydultvent,
        'a.ydimg,
        'a.ydfact, a.ydhact, a.yduact ,a.ydrut ,visita
        Dim dt As DataTable = CType(JGrM_Buscador.DataSource, DataTable)

        With JGrM_Buscador
            tbCodigoOriginal.Text = .GetValue("ydnumi").ToString
            tbNombres.Text = .GetValue("ydnom").ToString
            tbCI.Text = .GetValue("yddct").ToString
            tbApellidos.Text = .GetValue("ydapell").ToString
            tbTelefono.Text = .GetValue("ydtel").ToString
            tbCelular.Text = .GetValue("ydcel").ToString
            tbCorreo.Text = .GetValue("ydcorr").ToString
            tbDirDomicilio.Text = .GetValue("yddirdom").ToString
            tbDirTrabajo.Text = .GetValue("yddirtra")
            cbInstitucion.Value = .GetValue("ydins")
            tbGNombres.Text = .GetValue("ydGnom").ToString
            tbGCI.Text = .GetValue("ydGdct").ToString
            tbGApellidos.Text = .GetValue("ydGapell").ToString
            tbGTelefono.Text = .GetValue("ydGtel").ToString
            tbGCelular.Text = .GetValue("ydGcel").ToString
            tbGDirDomicilio.Text = .GetValue("ydGdirdom").ToString
            tbGDirTrabajo.Text = .GetValue("ydGdirtra")
            tbNroCuenta.Text = .GetValue("ydcuenta").ToString
            lbFecha.Text = CType(.GetValue("ydfecing"), Date).ToString("dd/MM/yyyy")
            lbHora.Text = .GetValue("ydhact").ToString
            lbUsuario.Text = .GetValue("yduact").ToString

        End With
        Dim name As String = JGrM_Buscador.GetValue("ydimg")
        If name.Equals("Default.jpg") Or Not File.Exists(RutaGlobal + "\Imagenes\Imagenes ClienteDino" + name) Then

            Dim im As New Bitmap(My.Resources.pantalla)
            UsImg.pbImage.Image = im
        Else
            If (File.Exists(RutaGlobal + "\Imagenes\Imagenes ClienteDino" + name)) Then
                Dim Bin As New MemoryStream
                Dim im As New Bitmap(New Bitmap(RutaGlobal + "\Imagenes\Imagenes ClienteDino" + name))
                im.Save(Bin, System.Drawing.Imaging.ImageFormat.Jpeg)
                UsImg.pbImage.SizeMode = PictureBoxSizeMode.StretchImage
                UsImg.pbImage.Image = Image.FromStream(Bin)
                Bin.Dispose()

            End If
        End If
        _dibujarUbicacion(JGrM_Buscador.GetValue("ydnom").ToString, JGrM_Buscador.GetValue("yddct").ToString)
        LblPaginacion.Text = Str(_MPos + 1) + "/" + JGrM_Buscador.RowCount.ToString

    End Sub

    Public Sub _dibujarUbicacion(_nombre As String, _ci As String)
        If (_latitud <> 0 And _longitud <> 0) Then
            Dim plg As PointLatLng = New PointLatLng(_latitud, _longitud)
            _Overlay.Markers.Clear()
            P_AgregarPunto(plg, _nombre, _ci)
        Else


            _Overlay.Markers.Clear()
            Gmc_Cliente.Position = New PointLatLng(-17.3931784, -66.1738852)
        End If
    End Sub
    Private Sub P_AgregarPunto(pointLatLng As PointLatLng, _nombre As String, _ci As String)
        If (Not IsNothing(_Overlay)) Then
            'añadir puntos
            'Dim markersOverlay As New GMapOverlay("markers")
            Dim marker As New GMarkerGoogle(pointLatLng, My.Resources.markerIcono)
            'añadir tooltip
            Dim mode As MarkerTooltipMode = MarkerTooltipMode.OnMouseOver
            marker.ToolTip = New GMapBaloonToolTip(marker)
            marker.ToolTipMode = mode
            Dim ToolTipBackColor As New SolidBrush(Color.Blue)
            marker.ToolTip.Fill = ToolTipBackColor
            marker.ToolTip.Foreground = Brushes.White
            'If (Not _nombre.ToString = String.Empty) Then
            '    marker.ToolTipText = "CLIENTE: " + _nombre & vbNewLine & " CI:" + _ci
            'End If
            _Overlay.Markers.Add(marker)
            'mapa.Overlays.Add(markersOverlay)
            Gmc_Cliente.Position = pointLatLng
        End If
    End Sub
    Public Overrides Sub _PMOHabilitarFocus()

        'With MHighlighterFocus
        '    .SetHighlightOnFocus(tbCodigo, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(tbCodProd, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(tbStockMinimo, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(tbCodBarra, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)

        '    .SetHighlightOnFocus(tbDescPro, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(tbDescCort, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(cbgrupo1, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(cbgrupo2, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(cbgrupo3, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(cbgrupo4, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(cbUMed, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(swEstado, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(cbUniVenta, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(cbUnidMaxima, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(tbConversion, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)


        'End With
    End Sub

#End Region



    Private Sub F1_Clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
        btnNuevo.PerformClick()
        If (gi_CodCliente = 1) Then
            _PMOHabilitar()
        End If

    End Sub

    Private Sub Gmc_Cliente_DoubleClick(sender As Object, e As EventArgs) Handles Gmc_Cliente.DoubleClick
        If (btnGrabar.Enabled = True) Then


            _Overlay.Markers.Clear()

            Dim gm As GMapControl = CType(sender, GMapControl)
            Dim hj As MouseEventArgs = CType(e, MouseEventArgs)
            Dim plg As PointLatLng = gm.FromLocalToLatLng(hj.X, hj.Y)
            _latitud = plg.Lat
            _longitud = plg.Lng
            ''  MsgBox("latitud:" + Str(plg.Lat) + "   Logitud:" + Str(plg.Lng))

            P_AgregarPunto(plg, "", "")

            '' _ListPuntos.Add(plg)
            'Btnx_ChekGetPoint.Visible = False
        End If
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        If (Gmc_Cliente.Zoom >= Gmc_Cliente.MinZoom) Then
            Gmc_Cliente.Zoom = Gmc_Cliente.Zoom - 1
        End If
    End Sub

    Private Sub ButtonX4_Click(sender As Object, e As EventArgs) Handles ButtonX4.Click
        If (Gmc_Cliente.Zoom <= Gmc_Cliente.MaxZoom) Then
            Gmc_Cliente.Zoom = Gmc_Cliente.Zoom + 1
        End If
    End Sub

    Private Sub BtAdicionar_Click(sender As Object, e As EventArgs) Handles BtAdicionar.Click
        _fnCopiarImagenRutaDefinida()
        btnGrabar.Focus()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If gi_CodCliente <> 0 Then
            Me.Close()
        Else
            If btnGrabar.Enabled = True Then
                _PMInhabilitar()
                _PMPrimerRegistro()

            Else
                '  Public _modulo As SideNavItem
                _modulo.Select()
                Me.Close()
            End If
        End If

    End Sub


    Private Sub JGrM_Buscador_KeyDown(sender As Object, e As KeyEventArgs) Handles JGrM_Buscador.KeyDown
        If e.KeyData = Keys.Enter Then
            If (MPanelSup.Visible = True) Then
                JGrM_Buscador.GroupByBoxVisible = True
                MPanelSup.Visible = False
                JGrM_Buscador.UseGroupRowSelector = True

            Else
                JGrM_Buscador.GroupByBoxVisible = False
                JGrM_Buscador.UseGroupRowSelector = True
                MPanelSup.Visible = True
            End If
        End If
    End Sub
    Function _fnAccesible() As Boolean
        Return tbCI.ReadOnly = False

    End Function
    Private Sub tbVendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles tbTelefono.KeyDown
        If (_fnAccesible()) Then
            If e.KeyData = Keys.Control + Keys.Enter Then

                Dim dt As DataTable

                dt = L_fnListarEmpleado()
                '              a.ydnumi, a.ydcod, a.yddesc, a.yddctnum, a.yddirec
                ',a.ydtelf1 ,a.ydfnac 

                Dim listEstCeldas As New List(Of Modelo.Celda)
                listEstCeldas.Add(New Modelo.Celda("ydnumi,", False, "ID", 50))
                listEstCeldas.Add(New Modelo.Celda("ydcod", True, "ID", 50))
                listEstCeldas.Add(New Modelo.Celda("yddesc", True, "NOMBRE", 280))
                listEstCeldas.Add(New Modelo.Celda("yddctnum", True, "N. Documento".ToUpper, 150))
                listEstCeldas.Add(New Modelo.Celda("yddirec", True, "DIRECCION", 220))
                listEstCeldas.Add(New Modelo.Celda("ydtelf1", True, "Telefono".ToUpper, 200))
                listEstCeldas.Add(New Modelo.Celda("ydfnac", True, "F.Nacimiento".ToUpper, 150, "MM/dd,YYYY"))
                Dim ef = New Efecto
                ef.tipo = 3
                ef.dt = dt
                ef.SeleclCol = 1
                ef.listEstCeldas = listEstCeldas
                ef.alto = 50
                ef.ancho = 350
                ef.Context = "Seleccione Vendedor".ToUpper
                ef.ShowDialog()
                Dim bandera As Boolean = False
                bandera = ef.band
                If (bandera = True) Then
                    Dim Row As Janus.Windows.GridEX.GridEXRow = ef.Row
                    If (IsNothing(Row)) Then
                        tbTelefono.Focus()
                        Return

                    End If
                    NumiVendedor = Row.Cells("ydnumi").Value
                    tbTelefono.Text = Row.Cells("yddesc").Value
                    tbCelular.Focus()

                End If

            End If

        End If
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs)
        If (_fnAccesible()) Then


            Dim dt As DataTable

            dt = L_fnListarEmpleado()
            '              a.ydnumi, a.ydcod, a.yddesc, a.yddctnum, a.yddirec
            ',a.ydtelf1 ,a.ydfnac 

            Dim listEstCeldas As New List(Of Modelo.Celda)
            listEstCeldas.Add(New Modelo.Celda("ydnumi,", True, "ID", 50))
            listEstCeldas.Add(New Modelo.Celda("ydcod", False, "ID", 50))
            listEstCeldas.Add(New Modelo.Celda("yddesc", True, "NOMBRE", 280))
            listEstCeldas.Add(New Modelo.Celda("yddctnum", True, "N. Documento".ToUpper, 150))
            listEstCeldas.Add(New Modelo.Celda("yddirec", True, "DIRECCION", 220))
            listEstCeldas.Add(New Modelo.Celda("ydtelf1", True, "Telefono".ToUpper, 200))
            listEstCeldas.Add(New Modelo.Celda("ydfnac", True, "F.Nacimiento".ToUpper, 150, "MM/dd,YYYY"))
            Dim ef = New Efecto
            ef.tipo = 3
            ef.dt = dt
            ef.SeleclCol = 1
            ef.listEstCeldas = listEstCeldas
            ef.alto = 50
            ef.ancho = 350
            ef.Context = "Seleccione Vendedor".ToUpper
            ef.ShowDialog()
            Dim bandera As Boolean = False
            bandera = ef.band
            If (bandera = True) Then
                Dim Row As Janus.Windows.GridEX.GridEXRow = ef.Row
                If (IsNothing(Row)) Then
                    tbTelefono.Focus()
                    Return

                End If
                NumiVendedor = Row.Cells("ydnumi").Value
                tbTelefono.Text = Row.Cells("yddesc").Value
                tbCelular.Focus()

            End If



        End If
    End Sub


    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        P_GenerarReporte()
    End Sub
    Private Sub P_GenerarReporte()
        'Dim dt As DataTable = L_fnReportecliente()

        'If Not IsNothing(P_Global.Visualizador) Then
        '    P_Global.Visualizador.Close()
        'End If

        'P_Global.Visualizador = New Visualizador

        'Dim objrep As New R_Clientes
        ''' GenerarNro(_dt)
        '''objrep.SetDataSource(Dt1Kardex)
        'objrep.SetDataSource(dt)

        'P_Global.Visualizador.CrGeneral.ReportSource = objrep 'Comentar
        'P_Global.Visualizador.Show() 'Comentar
        'P_Global.Visualizador.BringToFront() 'Comentar



    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        _Inter = _Inter + 1
        If _Inter = 1 Then
            Me.WindowState = FormWindowState.Normal

        Else
            Me.Opacity = 100
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub cbInstitucion_ValueChanged(sender As Object, e As EventArgs) Handles cbInstitucion.ValueChanged
        If cbInstitucion.SelectedIndex < 0 And cbInstitucion.Text <> String.Empty Then
            btConcepto.Visible = True
        Else
            btConcepto.Visible = False
        End If

    End Sub

    Private Sub btConcepto_Click(sender As Object, e As EventArgs) Handles btConcepto.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, "10", "1", cbInstitucion.Text, "") Then
            _prCargarComboLibreria(cbInstitucion, "10", "1")
            cbInstitucion.SelectedIndex = CType(cbInstitucion.DataSource, DataTable).Rows.Count - 1
        End If
    End Sub


End Class