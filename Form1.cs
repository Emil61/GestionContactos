using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GestionContactos
{
    public partial class Form1 : Form
    {
        private ContactoDAL contactoDAL = new ContactoDAL();
        private int idSeleccionado = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarContactos();
        }

        private void CargarContactos()
        {
            dgvContactos.DataSource = null;
            dgvContactos.DataSource = contactoDAL.ObtenerContactos();

            if (dgvContactos.Columns["Id"] != null)
                dgvContactos.Columns["Id"].Visible = false;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarContactos();
            LimpiarCampos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtTelefono.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Por favor completa todos los campos.");
                return;
            }

            Contacto c = new Contacto
            {
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                Email = txtEmail.Text
            };

            contactoDAL.AgregarContacto(c);
            MessageBox.Show("Contacto agregado exitosamente.");
            CargarContactos();
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un contacto de la tabla para editar.");
                return;
            }

            Contacto c = new Contacto
            {
                Id = idSeleccionado,
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                Email = txtEmail.Text
            };

            contactoDAL.EditarContacto(c);
            MessageBox.Show("Contacto actualizado.");
            CargarContactos();
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un contacto para eliminar.");
                return;
            }

            contactoDAL.EliminarContacto(idSeleccionado);
            MessageBox.Show("Contacto eliminado.");
            CargarContactos();
            LimpiarCampos();
        }

        private void dgvContactos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvContactos.Rows[e.RowIndex];
                idSeleccionado = Convert.ToInt32(fila.Cells["Id"].Value);
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                txtEmail.Text = fila.Cells["Email"].Value.ToString();
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            idSeleccionado = -1;
        }

        // Eventos vacíos que puedes eliminar si no usas
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void txtTelefono_TextChanged(object sender, EventArgs e) { }
        private void txtEmail_TextChanged(object sender, EventArgs e) { }
        private void dgvContactos_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}

