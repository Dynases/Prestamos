Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Imports GMap.NET.MapProviders
Imports GMap.NET
Imports GMap.NET.WindowsForms.Markers
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.ToolTips
Imports System.Drawing
Imports DevComponents.DotNetBar.Controls
Imports Logica.AccesoLogica
Public Class F1_MontoPagar

    Public Pagado As Double
    Public Bandera As Boolean = False
    Public Apagar As Double = 0
    Public moneda As Integer = 0
    Public tipo As Integer = 0
    Public FechaC As String = ""
    Public FechaP As String = ""
    Public cuota As Integer = 0
    Public TotalBs As Double = 0
    Public TotalSus As Double = 0
    Public TCambio As Double = 0



    Private Sub F1_MontoPagar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prCargarComboLibreria(cbCambioDolar, 9, 1)
        '_prCargarComboBanco(cbBanco)
        cbCambioDolar.SelectedIndex = CType(cbCambioDolar.DataSource, DataTable).Rows.Count - 1
        tbCuota.Text = cuota
        tbFechaCuota.Value = FechaC
        tbFechaPago.Value = Date.Now.ToString("dd/MM/yyyy")
        tbPagado.Text = Pagado
        tbPagar.Text = Apagar
        tbMontoBs.Value = Apagar
        If moneda = 1 Then
            swMoneda.Value = True
        Else
            swMoneda.Value = False
        End If

        btnContinuar.Focus()
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


    Private Sub tbMontoBs_ValueChanged(sender As Object, e As EventArgs) Handles tbMontoBs.ValueChanged
        'tbMontoDolar.Value = 0
        'tbMontoTarej.Value = 0
        Dim sumTotal As Double
        If swMoneda.Value = False Then
            sumTotal = tbMontoBs.Value + (tbMontoDolar.Value * CDbl(cbCambioDolar.Text))
            If sumTotal > CDbl(tbPagar.Text) Then
                ToastNotification.Show(Me, "El monto ingresado no puede ser mayor al monto a pagar ", My.Resources.WARNING, 4000, eToastGlowColor.Red, eToastPosition.TopCenter)
                tbMontoBs.Value = 0
            Else
                tbTotal.Value = sumTotal
            End If
        Else
            sumTotal = tbMontoDolar.Value + (tbMontoBs.Value / CDbl(cbCambioDolar.Text))
            If sumTotal > CDbl(tbPagar.Text) Then
                ToastNotification.Show(Me, "El monto ingresado no puede ser mayor al monto a pagar ", My.Resources.WARNING, 4000, eToastGlowColor.Red, eToastPosition.TopCenter)
                tbMontoBs.Value = 0
            Else
                tbTotal.Value = sumTotal
            End If
        End If


    End Sub

    Private Sub tbMontoDolar_ValueChanged(sender As Object, e As EventArgs) Handles tbMontoDolar.ValueChanged
        'tbMontoBs.Value = 0
        'tbMontoTarej.Value = 0
        Dim sumTotal As Double
        If swMoneda.Value = False Then
            sumTotal = tbMontoBs.Value + (tbMontoDolar.Value * CDbl(cbCambioDolar.Text))
            If sumTotal > CDbl(tbPagar.Text) Then
                ToastNotification.Show(Me, "El monto ingresado no puede ser mayor al monto a pagar ", My.Resources.WARNING, 4000, eToastGlowColor.Red, eToastPosition.TopCenter)
                tbMontoDolar.Value = 0
            Else
                tbTotal.Value = sumTotal
            End If
        Else
            sumTotal = tbMontoDolar.Value + (tbMontoBs.Value / CDbl(cbCambioDolar.Text))
            If sumTotal > CDbl(tbPagar.Text) Then
                ToastNotification.Show(Me, "El monto ingresado no puede ser mayor al monto a pagar ", My.Resources.WARNING, 4000, eToastGlowColor.Red, eToastPosition.TopCenter)
                tbMontoDolar.Value = 0
            Else
                tbTotal.Value = sumTotal
            End If
        End If
    End Sub

    Private Sub tbMontoTarej_ValueChanged(sender As Object, e As EventArgs)
        'tbMontoDolar.Value = 0
        'tbMontoBs.Value = 0


    End Sub

    Private Sub tbMontoBs_KeyDown(sender As Object, e As KeyEventArgs) Handles tbMontoBs.KeyDown

        If (e.KeyData = Keys.Up) Then
            'tbRazonSocial.Focus()
        End If
        If (e.KeyData = Keys.Right) Then
            tbMontoDolar.Focus()
        End If
        If (e.KeyData = Keys.Enter) Then
            'tbMontoDolar.Focus()
            btnContinuar.Focus()
        End If



    End Sub

    Private Sub tbMontoDolar_KeyDown(sender As Object, e As KeyEventArgs) Handles tbMontoDolar.KeyDown
        If (e.KeyData = Keys.Left) Then
            tbMontoBs.Focus()
        End If



    End Sub

    Private Sub tbMontoTarej_KeyDown(sender As Object, e As KeyEventArgs)
        If (e.KeyData = Keys.Up) Then
            tbMontoBs.Focus()
        End If
        If (e.KeyData = Keys.Enter) Then
            btnContinuar.Focus()
        End If
        If (e.KeyData = Keys.Left) Then
            tbMontoDolar.Focus()
        End If


    End Sub


    Private Sub btnContinuar_Click(sender As Object, e As EventArgs) Handles btnContinuar.Click

        cuota = tbCuota.Text
        Apagar = tbPagar.Text
        FechaP = tbFechaPago.Value.ToString("dd/MM/yyyy")

        TCambio = CDbl(cbCambioDolar.Text)
        TotalBs = tbMontoBs.Value
        TotalSus = tbMontoDolar.Value
        Bandera = True
        'TotalBs = tbMontoBs.Value
        'lSus = tbMontoDolar.Value

        'TipoCambio = cbCambioDolar.Text
        'tipoVenta = 0
        If tipo = 1 Then
            'Dim dt As DataTable = revisarMontos(cbBanco.Value)
            'Dim cam As Double = Convert.ToDouble(cbCambioDolar.Text)
            'If (dt.Rows(0).Item("Bs") + (dt.Rows(0).Item("Bs") * cam)) < (TotalBs + (TotalSus * cam)) Then
            '    ToastNotification.Show(Me, "No hay suficiente dinero en caja: " + (dt.Rows(0).Item("Bs") + (dt.Rows(0).Item("Bs") * cbCambioDolar.Value)).ToString, My.Resources.WARNING, 4000, eToastGlowColor.Red, eToastPosition.TopCenter)
            'Else
            '    If dt.Rows(0).Item("Banco") < TotalTarjeta Then
            '        ToastNotification.Show(Me, "No hay suficiente dinero en la cuenta: " + dt.Rows(0).Item("Banco").ToString, My.Resources.WARNING, 4000, eToastGlowColor.Red, eToastPosition.TopCenter)
            '    Else
            '        If (TotalBs + (TotalSus * cam) + TotalTarjeta) > TotalVenta Then
            '            ToastNotification.Show(Me, "Ingrese un monto menor o igual al total ", My.Resources.WARNING, 4000, eToastGlowColor.Red, eToastPosition.TopCenter)

            '        Else
            '            Me.Close()
            '        End If
            '    End If
            'End If

        Else
            Me.Close()
        End If





    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click

        Bandera = False
        Me.Close()

    End Sub



    Private Sub cbCambioDolar_ValueChanged(sender As Object, e As EventArgs) Handles cbCambioDolar.ValueChanged
        If cbCambioDolar.SelectedIndex < 0 And cbCambioDolar.Text <> String.Empty Then
            btgrupo1.Visible = True
        Else
            btgrupo1.Visible = False
        End If
    End Sub

    Private Sub btgrupo1_Click(sender As Object, e As EventArgs) Handles btgrupo1.Click
        Dim numi As String = ""

        If L_prLibreriaGrabar(numi, "9", "1", cbCambioDolar.Text, "") Then
            _prCargarComboLibreria(cbCambioDolar, "9", "1")
            cbCambioDolar.SelectedIndex = CType(cbCambioDolar.DataSource, DataTable).Rows.Count - 1
        End If
    End Sub

    Private Sub tbNit_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            ToastNotification.Show(Me, "Solo puede digitar números".ToUpper, My.Resources.WARNING, 1200, eToastGlowColor.Red, eToastPosition.TopCenter)

        End If
    End Sub



    Private Sub tbRazonSocial_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsLetter(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or Convert.ToChar(Keys.Back) = (e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub


    Private Sub MostrarMensajeError(mensaje As String)
        ToastNotification.Show(Me,
                               mensaje.ToUpper,
                               My.Resources.WARNING,
                               4000,
                               eToastGlowColor.Red,
                               eToastPosition.TopCenter)
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub
End Class