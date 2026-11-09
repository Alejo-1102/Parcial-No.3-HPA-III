namespace Problema3_LoginBCrypt;

public class FrmBienvenida : Form
{
    public FrmBienvenida(string nombreUsuario)
    {
        Text = "Bienvenida";
        ClientSize = new Size(360, 140);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;

        Label lblBienvenida = new Label
        {
            Text = "¡Bienvenido, " + nombreUsuario + "!",
            Font = new Font("Segoe UI", 14, FontStyle.Bold),
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Fill
        };

        Controls.Add(lblBienvenida);
    }
}
