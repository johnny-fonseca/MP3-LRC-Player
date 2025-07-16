Imports System.IO
Imports System.Text.RegularExpressions
Imports AxWMPLib

Public Class Form1

    Dim canciones As List(Of String) = New List(Of String)()
    Dim indiceActual As Integer = 0
    Dim enPausa As Boolean = False
    Dim lrcLetras As New List(Of Tuple(Of TimeSpan, String))
    Dim indiceLetraActual As Integer = -1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        player.settings.autoStart = False
        TimerLRC.Interval = 300
        TimerLRC.Start()
    End Sub

    Private Sub btnSeleccionarCarpeta_Click(sender As Object, e As EventArgs) Handles btnSeleccionarCarpeta.Click
        Using folderDialog As New FolderBrowserDialog()
            If folderDialog.ShowDialog() = DialogResult.OK Then
                canciones = Directory.GetFiles(folderDialog.SelectedPath, "*.*", SearchOption.TopDirectoryOnly).
                    Where(Function(f) f.ToLower().EndsWith(".mp3") OrElse f.ToLower().EndsWith(".wav")).ToList()

                If canciones.Count > 0 Then
                    indiceActual = 0
                    ReproducirCancion()
                Else
                    MessageBox.Show("No se encontraron canciones en la carpeta.")
                End If
            End If
        End Using
    End Sub

    Private Sub ReproducirCancion()
        If indiceActual >= 0 AndAlso indiceActual < canciones.Count Then
            Dim rutaCancion = canciones(indiceActual)
            player.URL = rutaCancion
            lblCancionActual.Text = "Reproduciendo: " & Path.GetFileName(rutaCancion)
            player.Ctlcontrols.play()
            enPausa = False

            Dim rutaLRC = Path.ChangeExtension(rutaCancion, ".lrc")
            CargarLRC(rutaLRC)
        End If
    End Sub

    Private Sub btnPlayPause_Click(sender As Object, e As EventArgs) Handles btnPlayPause.Click
        If canciones.Count = 0 Then Return

        If enPausa Then
            player.Ctlcontrols.play()
            enPausa = False
        Else
            player.Ctlcontrols.pause()
            enPausa = True
        End If
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If indiceActual < canciones.Count - 1 Then
            indiceActual += 1
            ReproducirCancion()
        End If
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        If indiceActual > 0 Then
            indiceActual -= 1
            ReproducirCancion()
        End If
    End Sub

    ' --------------------------------------------------------------------------------
    ' Sincronización de letras tipo karaoke
    ' --------------------------------------------------------------------------------
    Private Sub TimerLRC_Tick(sender As Object, e As EventArgs) Handles TimerLRC.Tick
        If player.playState = WMPLib.WMPPlayState.wmppsPlaying Then
            Dim tiempoActual = TimeSpan.FromSeconds(player.Ctlcontrols.currentPosition)

            For i = 0 To lrcLetras.Count - 1
                If tiempoActual < lrcLetras(i).Item1 Then
                    If i > 0 AndAlso i - 1 <> indiceLetraActual Then
                        indiceLetraActual = i - 1
                        lstLetras.SelectedIndex = indiceLetraActual
                        lstLetras.TopIndex = Math.Max(0, indiceLetraActual - 3) ' Desplazar un poco arriba
                    End If
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub CargarLRC(rutaLRC As String)
        lrcLetras.Clear()
        lstLetras.Items.Clear()
        indiceLetraActual = -1

        If Not File.Exists(rutaLRC) Then
            lstLetras.Items.Add("(Letra no disponible)")
            Return
        End If

        Try
            Dim lineas = File.ReadAllLines(rutaLRC)
            Dim regex = New Regex("\[(\d+):(\d+\.\d+)\](.*)")

            For Each linea In lineas
                Dim match = regex.Match(linea)
                If match.Success Then
                    Dim minutos = Integer.Parse(match.Groups(1).Value)
                    Dim segundos = Double.Parse(match.Groups(2).Value, Globalization.CultureInfo.InvariantCulture)
                    Dim texto = match.Groups(3).Value.Trim()
                    lrcLetras.Add(Tuple.Create(TimeSpan.FromMinutes(minutos) + TimeSpan.FromSeconds(segundos), texto))
                End If
            Next

            lrcLetras = lrcLetras.OrderBy(Function(t) t.Item1).ToList()

            For Each l In lrcLetras
                lstLetras.Items.Add(l.Item2)
            Next

        Catch ex As Exception
            MessageBox.Show("Error al cargar LRC: " & ex.Message)
        End Try
    End Sub

End Class