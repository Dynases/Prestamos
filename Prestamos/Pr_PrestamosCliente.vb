Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Public Class Pr_PrestamosCliente

    Private Sub IniciarTodo()
        tbFechaI.Value = Date.Now
        tbFechaF.Value = Date.Now
        CheckTodos.Checked = True
        _prCargarComboCliente(cbCliente)
        _prCargarMoneda(cbMoneda)
    End Sub
    Private Sub CheckUna_CheckedChanged(sender As Object, e As EventArgs) Handles CheckUna.CheckedChanged
        If CheckUna.Checked = True Then
            If CheckTodos.Checked = True Then
                CheckTodos.Checked = False
                cbCliente.Enabled = True
            End If
        End If
    End Sub

    Private Sub _prCargarMoneda(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo)
        Dim dt As New DataTable
        dt = L_prLibreriaDetalleGeneral(7, 1)
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
            cbMoneda.SelectedIndex = 0
        End If
    End Sub
    Private Sub CheckTodos_CheckedChanged(sender As Object, e As EventArgs) Handles CheckTodos.CheckedChanged
        If CheckTodos.Checked = True Then
            If CheckUna.Checked = True Then
                CheckUna.Checked = False
            End If
            cbCliente.Enabled = False
            cbCliente.Value = 0
        End If
    End Sub

    Private Sub Pr_PrestamosCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        IniciarTodo()
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
    Private Function Validar() As Boolean
        If CheckUna.Checked Then
            If cbCliente.Value = 0 Then
                Dim img As Bitmap = New Bitmap(My.Resources.mensaje, 50, 50)
                ToastNotification.Show(Me, "Seleccione un cliente".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomLeft)
                Return True
            End If
        End If
        If cbMoneda.Value = 0 Then
            Dim img As Bitmap = New Bitmap(My.Resources.mensaje, 50, 50)
            ToastNotification.Show(Me, "Seleccione una Moneda".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomLeft)
            Return True
        End If
        If swDetalle.Value = True Then
            If CheckTodos.Checked = True Then
                Dim img As Bitmap = New Bitmap(My.Resources.mensaje, 50, 50)
                ToastNotification.Show(Me, "Seleccione solo un cliente para el reporte".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomLeft)
                Return True
            End If
        End If
        Return False
    End Function

    Private Sub _prInterpretarDatos(ByRef _dt As DataTable)
        If swDetalle.Value = False Then
            _dt = L_fnCargarPrestamosaClientes(IIf(CheckUna.Checked, cbCliente.Value, -1), tbFechaI.Value.ToString("dd/MM/yyyy"), tbFechaF.Value.ToString("dd/MM/yyyy"), cbMoneda.Value)
        Else
            _dt = L_fnCargarPrestamosaClientes2(IIf(CheckUna.Checked, cbCliente.Value, -1), tbFechaI.Value.ToString("dd/MM/yyyy"), tbFechaF.Value.ToString("dd/MM/yyyy"), cbMoneda.Value)
            armarTabla(_dt)
        End If
    End Sub

    Private Sub armarTabla(ByRef dt As DataTable)

        Dim prestamo, cuota As Integer
        Dim prestamosAux As Integer = 0
        Dim cuotaAux As Integer = 0
        Dim monto As Double = 0
        Dim montoAux As Double = 0
        Dim saldo As Double

        For i = 0 To dt.Rows.Count - 1 Step 1
            prestamo = dt.Rows(i).Item("numi")
            cuota = dt.Rows(i).Item("cuota")
            monto = dt.Rows(i).Item("pagado")

            If prestamo = prestamosAux Then
                If cuota = cuotaAux Then
                    saldo = saldo - dt.Rows(i).Item("pagado")
                    dt.Rows(i).Item("pendiente") = saldo

                    If saldo = dt.Rows(i).Item("monto") Then
                        dt.Rows(i).Item("estado") = "PENDIENTE"
                    ElseIf saldo > 0 Then
                        dt.Rows(i).Item("estado") = "PARCIAL"
                    Else
                        dt.Rows(i).Item("estado") = "PAGADO"
                    End If
                Else
                    saldo = dt.Rows(i).Item("monto") - dt.Rows(i).Item("pagado")
                    dt.Rows(i).Item("pendiente") = saldo
                    If saldo = dt.Rows(i).Item("monto") Then
                        dt.Rows(i).Item("estado") = "PENDIENTE"
                    ElseIf saldo > 0 Then
                        dt.Rows(i).Item("estado") = "PARCIAL"
                    Else
                        dt.Rows(i).Item("estado") = "PAGADO"
                    End If

                    prestamosAux = prestamo
                    cuotaAux = cuota
                End If
            Else
                    saldo = dt.Rows(i).Item("monto") - dt.Rows(i).Item("pagado")
                dt.Rows(i).Item("pendiente") = saldo
                If saldo = dt.Rows(i).Item("monto") Then
                    dt.Rows(i).Item("estado") = "PENDIENTE"
                ElseIf saldo > 0 Then
                    dt.Rows(i).Item("estado") = "PARCIAL"
                Else
                    dt.Rows(i).Item("estado") = "PAGADO"
                End If

                prestamosAux = prestamo
                cuotaAux = cuota

            End If
        Next
    End Sub
    Private Sub GenerarReporte()
        If Validar() Then
            Exit Sub
        End If
        Dim _dt As New DataTable
        _prInterpretarDatos(_dt)
        If (_dt.Rows.Count > 0) Then
            If swDetalle.Value = False Then
                Dim objrep As New R_PrestamosCliente
                objrep.SetDataSource(_dt)
                Dim fechaI As String = tbFechaI.Value.ToString("dd/MM/yyyy")
                Dim fechaF As String = tbFechaF.Value.ToString("dd/MM/yyyy")
                'objrep.SetParameterValue("CodCan", CodCan)
                'objrep.SetParameterValue("CodIns", CodIns)
                'objrep.SetParameterValue("Canero", Canero)
                'objrep.SetParameterValue("Institucion", Institucion)

                objrep.SetParameterValue("fechaI", fechaI)
                objrep.SetParameterValue("fechaF", fechaF)
                MReportViewer.ReportSource = objrep
                MReportViewer.Show()
                MReportViewer.BringToFront()
            Else
                Dim objrep As New R_PrestamosClienteDetallePagos
                objrep.SetDataSource(_dt)
                Dim fechaI As String = tbFechaI.Value.ToString("dd/MM/yyyy")
                Dim fechaF As String = tbFechaF.Value.ToString("dd/MM/yyyy")
                objrep.SetParameterValue("cliente", cbCliente.Text)
                'objrep.SetParameterValue("CodIns", CodIns)
                'objrep.SetParameterValue("Canero", Canero)
                'objrep.SetParameterValue("Institucion", Institucion)

                objrep.SetParameterValue("fechaI", fechaI)
                objrep.SetParameterValue("fechaF", fechaF)
                MReportViewer.ReportSource = objrep
                MReportViewer.Show()
                MReportViewer.BringToFront()
            End If
        Else
                Dim img As Bitmap = New Bitmap(My.Resources.mensaje, 50, 50)
            ToastNotification.Show(Me, "No existen datos para mostrar".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomLeft)
        End If
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        GenerarReporte()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class