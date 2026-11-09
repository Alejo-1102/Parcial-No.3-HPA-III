namespace Problema3_LoginBCrypt;

public class FrmRegistro : Form
{
    private TextBox txtUsuario;
    private TextBox txtNombre;
    private TextBox txtClave;
    private Button btnGuardar;

    public FrmRegistro()
    {
        Text = "Crear usuario";
        ClientSize = new Size(320, 270);
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;

        Label lblUsuario = new Label { Text = "Usuario:", Location = new Point(30, 20), AutoSize = true };
        txtUsuario = new TextBox { Location = new Point(30, 40), Width = 260 };

        Label lblNombre = new Label { Text = "Nombre completo:", Location = new Point(30, 75), AutoSize = true };
        txtNombre = new TextBox { Location = new Point(30, 95), Width = 260 };

        Label lblClave = new Label { Text = "Contraseña:", Location = new Point(30, 130), AutoSize = true };
        txtClave = new TextBox { Location = new Point(30, 150), Width = 260, UseSystemPasswordChar = true };

        btnGuardar = new Button { Text = "Guardar", Location = new Point(30, 200), Width = 260 };
        btnGuardar.Click += BtnGuardar_Click;

        Controls.AddRange(new Control[] { lblUsuario, txtUsuario, lblNombre, txtNombre, lblClave, txtClave, btnGuardar });
    }

    private void BtnGuardar_Click(object sender, EventArgs e)
    {
        if (txtUsuario.Text.Trim() == "" || txtNombre.Text.Trim() == "" || txtClave.Text == "")
        {
            MessageBox.Show("Complete todos los campos.", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            bool creado = UsuarioDatos.Registrar(txtUsuario.Text.Trim(), txtNombre.Text.Trim(), txtClave.Text);

            if (creado)
            {
                MessageBox.Show("Usuario creado. La contraseña se guardó como hash BCrypt.", "Listo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Ese nombre de usuario ya existe.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error con la base de datos: " + ex.Message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
