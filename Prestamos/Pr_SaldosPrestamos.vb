Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Public Class Pr_SaldosPrestamos

    Private Sub IniciarTodo()

        'CheckTodos.Checked = True
        '_prCargarComboCliente(cbCliente)
        _prCargarMoneda(cbMoneda)
    End Sub

    Private Sub _prCargarMoneda(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo)
        Dim dt As New DataTable
        dt = L_prLibreriaDetalleGeneral(10, 1)
        Dim fila = dt.NewRow()
        fila(0) = 0
        fila(1) = "TODOS"
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
            cbMoneda.SelectedIndex = 0
        End If
    End Sub
    Private Sub CheckUna_CheckedChanged(sender As Object, e As EventArgs)
        'If CheckUna.Checked = True Then
        '    If CheckTodos.Checked = True Then
        '        CheckTodos.Checked = False
        '        cbCliente.Enabled = True
        '    End If
        'End If
    End Sub

    Private Sub CheckTodos_CheckedChanged(sender As Object, e As EventArgs)
        'If CheckTodos.Checked = True Then
        '    If CheckUna.Checked = True Then
        '        CheckUna.Checked = False
        '    End If
        '    cbCliente.Enabled = False
        '    cbCliente.Value = 0
        'End If
    End Sub

    Private Sub Pr_PrestamosCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        IniciarTodo()
    End Sub

    'Private Sub _prCargarComboCliente(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo)
    '    Dim dt As New DataTable
    '    dt = L_fnListarClientes()
    '    Dim fila = dt.NewRow()
    '    fila(0) = 0

    '    fila(1) = "SELECCIONE CLIENTE"

    '    dt.Rows.InsertAt(fila, 0)
    '    'a.ylcod1 ,a.yldes1 
    '    With mCombo

    '        .DropDownList.Columns.Add("nombre").Width = cbCliente.Width
    '        .DropDownList.Columns("nombre").Caption = "DESCRIPCION"
    '        .ValueMember = "ydnumi"
    '        .DisplayMember = "nombre"
    '        .DataSource = dt
    '        .Refresh()
    '    End With
    '    If (CType(cbCliente.DataSource, DataTable).Rows.Count > 0) Then
    '        cbCliente.SelectedIndex = 0
    '    End If
    'End Sub
    Private Function Validar() As Boolean
        'If CheckUna.Checked Then
        '    If cbCliente.Value = 0 Then
        '        Dim img As Bitmap = New Bitmap(My.Resources.mensaje, 50, 50)
        '        ToastNotification.Show(Me, "Seleccione un cliente".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomLeft)
        '        Return True
        '    End If
        'End If
        Return False

    End Function

    Private Sub _prInterpretarDatos(ByRef _dt As DataTable)
        _dt = L_fnCargarSaldos(cbMoneda.Value)
    End Sub
    Private Sub GenerarReporte()
        If Validar() Then
            Exit Sub
        End If
        Dim _dt As New DataTable
        _prInterpretarDatos(_dt)
        If (_dt.Rows.Count > 0) Then
            Dim objrep As New R_SaldosPrestamos
            objrep.SetDataSource(_dt)

            'objrep.SetParameterValue("CodCan", CodCan)
            'objrep.SetParameterValue("CodIns", CodIns)
            'objrep.SetParameterValue("Canero", Canero)
            'objrep.SetParameterValue("Institucion", Institucion)


            MReportViewer.ReportSource = objrep
            MReportViewer.Show()
            MReportViewer.BringToFront()
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