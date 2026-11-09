namespace Problema3_LoginBCrypt;

public class FrmLogin : Form
{
    private TextBox txtUsuario;
    private TextBox txtClave;
    private Button btnIngresar;
    private Button btnRegistrar;

    public FrmLogin()
    {
        Text = "Login con BCrypt";
        ClientSize = new Size(320, 210);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;

        Label lblUsuario = new Label { Text = "Usuario:", Location = new Point(30, 25), AutoSize = true };
        txtUsuario = new TextBox { Location = new Point(30, 45), Width = 260 };

        Label lblClave = new Label { Text = "Contraseña:", Location = new Point(30, 80), AutoSize = true };
        txtClave = new TextBox { Location = new Point(30, 100), Width = 260, UseSystemPasswordChar = true };

        btnIngresar = new Button { Text = "Ingresar", Location = new Point(30, 145), Width = 120 };
        btnRegistrar = new Button { Text = "Crear usuario", Location = new Point(170, 145), Width = 120 };

        btnIngresar.Click += BtnIngresar_Click;
        btnRegistrar.Click += BtnRegistrar_Click;
        AcceptButton = btnIngresar;

        Controls.AddRange(new Control[] { lblUsuario, txtUsuario, lblClave, txtClave, btnIngresar, btnRegistrar });
    }

    private void BtnIngresar_Click(object sender, EventArgs e)
    {
        if (txtUsuario.Text.Trim() == "" || txtClave.Text == "")
        {
            MessageBox.Show("Escriba el usuario y la contraseña.", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            string nombre;
            bool ok = UsuarioDatos.ValidarLogin(txtUsuario.Text.Trim(), txtClave.Text, out nombre);

            if (ok)
            {
                MessageBox.Show("Acceso exitoso. Bienvenido, " + nombre + ".", "Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                FrmBienvenida bienvenida = new FrmBienvenida(nombre);
                Hide();
                bienvenida.ShowDialog();
                txtClave.Clear();
                Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtClave.Clear();
                txtClave.Focus();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error con la base de datos: " + ex.Message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnRegistrar_Click(object sender, EventArgs e)
    {
        using (FrmRegistro registro = new FrmRegistro())
        {
            registro.ShowDialog();
        }
    }
}
