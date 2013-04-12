using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nursery.Service;
using Nursery.Entity;

namespace Nursery.Presentation.Desktop
{
    public partial class frmLogIn : Form
    {
        private readonly UserService userService;
        private string Status = "Activo";

        public frmLogIn()
        {
            InitializeComponent();
            userService = new UserService();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" && txtPassword.Text == "")
            {
                MessageBox.Show(this, "Ingresar usuario y contraseña", "Falta información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txtUserName.Text == "")
            {
                MessageBox.Show(this, "Ingresar usuario", "Falta usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show(this, "Ingresar contraseña", "Falta contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                User user = new User();
                user.Password = txtPassword.Text;
                user.UserName = txtUserName.Text;
                user.Status = Status;

                if (userService.ValidateUser(user) != 0)
                {
                    MessageBox.Show(this, "Bienvenido + Nombre de la persona!!", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    frmPrincipal frmPrincipal = new frmPrincipal();
                    frmPrincipal.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(this, "Usuario o contraseña inválido", "Invalid Log On", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmLogIn_Load(object sender, EventArgs e)
        {

        }
    }
}
