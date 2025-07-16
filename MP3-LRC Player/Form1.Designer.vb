<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    ' Limpiar recursos
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

    ' Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    ' NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.btnSeleccionarCarpeta = New System.Windows.Forms.Button()
        Me.btnAnterior = New System.Windows.Forms.Button()
        Me.btnPlayPause = New System.Windows.Forms.Button()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.lblCancionActual = New System.Windows.Forms.Label()
        Me.player = New AxWMPLib.AxWindowsMediaPlayer()
        Me.TimerLRC = New System.Windows.Forms.Timer(Me.components)
        Me.lstLetras = New System.Windows.Forms.ListBox()
        CType(Me.player, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSeleccionarCarpeta
        '
        Me.btnSeleccionarCarpeta.Location = New System.Drawing.Point(91, 12)
        Me.btnSeleccionarCarpeta.Name = "btnSeleccionarCarpeta"
        Me.btnSeleccionarCarpeta.Size = New System.Drawing.Size(137, 26)
        Me.btnSeleccionarCarpeta.TabIndex = 0
        Me.btnSeleccionarCarpeta.Text = "Seleccionar Carpeta"
        Me.btnSeleccionarCarpeta.UseVisualStyleBackColor = True
        '
        'btnAnterior
        '
        Me.btnAnterior.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.btnAnterior.Location = New System.Drawing.Point(77, 54)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(51, 35)
        Me.btnAnterior.TabIndex = 1
        Me.btnAnterior.Text = "⏮"
        Me.btnAnterior.UseVisualStyleBackColor = True
        '
        'btnPlayPause
        '
        Me.btnPlayPause.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.btnPlayPause.Location = New System.Drawing.Point(134, 54)
        Me.btnPlayPause.Name = "btnPlayPause"
        Me.btnPlayPause.Size = New System.Drawing.Size(51, 35)
        Me.btnPlayPause.TabIndex = 2
        Me.btnPlayPause.Text = "⏯"
        Me.btnPlayPause.UseVisualStyleBackColor = True
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.btnSiguiente.Location = New System.Drawing.Point(190, 54)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(51, 35)
        Me.btnSiguiente.TabIndex = 3
        Me.btnSiguiente.Text = "⏭"
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'lblCancionActual
        '
        Me.lblCancionActual.AutoSize = True
        Me.lblCancionActual.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblCancionActual.Location = New System.Drawing.Point(-3, 103)
        Me.lblCancionActual.Name = "lblCancionActual"
        Me.lblCancionActual.Size = New System.Drawing.Size(141, 19)
        Me.lblCancionActual.TabIndex = 4
        Me.lblCancionActual.Text = "Ninguna canción aún."
        '
        'player
        '
        Me.player.Enabled = True
        Me.player.Location = New System.Drawing.Point(301, 1)
        Me.player.Name = "player"
        Me.player.OcxState = CType(resources.GetObject("player.OcxState"), System.Windows.Forms.AxHost.State)
        Me.player.Size = New System.Drawing.Size(17, 24)
        Me.player.TabIndex = 5
        Me.player.Visible = False
        '
        'TimerLRC
        '
        Me.TimerLRC.Interval = 500
        '
        'lstLetras
        '
        Me.lstLetras.FormattingEnabled = True
        Me.lstLetras.Location = New System.Drawing.Point(12, 138)
        Me.lstLetras.Name = "lstLetras"
        Me.lstLetras.Size = New System.Drawing.Size(295, 355)
        Me.lstLetras.TabIndex = 7
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(321, 504)
        Me.Controls.Add(Me.lstLetras)
        Me.Controls.Add(Me.player)
        Me.Controls.Add(Me.lblCancionActual)
        Me.Controls.Add(Me.btnSiguiente)
        Me.Controls.Add(Me.btnPlayPause)
        Me.Controls.Add(Me.btnAnterior)
        Me.Controls.Add(Me.btnSeleccionarCarpeta)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reproductor Simple"
        CType(Me.player, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSeleccionarCarpeta As Button
    Friend WithEvents btnAnterior As Button
    Friend WithEvents btnPlayPause As Button
    Friend WithEvents btnSiguiente As Button
    Friend WithEvents lblCancionActual As Label
    Friend WithEvents player As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents TimerLRC As Timer
    Friend WithEvents lstLetras As ListBox
End Class