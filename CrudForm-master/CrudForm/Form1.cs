using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudForm
{
    public partial class CrudForm : System.Windows.Forms.Form
    {
        public Boolean Adding = false;
        List<Contact> Contacts = new List<Contact>();

        public CrudForm()
        {
            InitializeComponent();
        }
        #region Botones


        private void btnBorrar_Click(object sender, EventArgs e)
                {
                    //Para borrar el primer registro en el datagridview
                    Contacts.RemoveAt(0);
                    MessageBox.Show("Se ha borrado el primer registro.");
                    DGVContacts.DataSource = Contacts;
                }
         private void btnAñadir_Click(object sender, EventArgs e)
            {
                //Para añadir un registro, se desabilitan los demas botones.
                EmptyControls();
                EnableControls(true);
                Adding = true;
                txtID.Text = Guid.NewGuid().ToString();
                btnAñadir.Enabled = false;
                btnBorrar.Enabled = false;
                btnCargar.Enabled = false;
            }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            GetContacts();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Save();
        }
        #endregion

        #region metodos
        private void EmptyControls()
        {
            //Para vaciar las cajas de texto tan pronto como los datos sean insertados en el datagridview.
            txtID.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtID.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCiudad.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtCelular.Text = string.Empty;
            txtPais.Text = string.Empty;
        }

        private void EnableControls(bool enabled)
        {
            //Para abilitar el caja de texto para insertar la informacion.
            txtNombre.Enabled = enabled;
            txtApellido.Enabled = enabled;
            txtID.Enabled = enabled;
            txtDireccion.Enabled = enabled;
            txtCiudad.Enabled = enabled;
            txtCorreo.Enabled = enabled;
            txtCelular.Enabled = enabled;
            txtPais.Enabled = enabled;
        }

        private void Save()
        {
            //Para guardar el registro en la clase que se mostrara en el datagridview
            if (Adding == true)
            {
                //Se añade un nuevo registro
                var contact = new Contact
                {
                    ID = txtID.Text,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Dirrecion = txtDireccion.Text,
                    Ciudad = txtCiudad.Text,
                    Pais = txtPais.Text,
                    Celular = txtCelular.Text,
                    Correo = txtCorreo.Text,
                };

                Contacts.Add(contact);

                MessageBox.Show("Contacto Registrado en la base de datos.");

                EmptyControls();
                EnableControls(false);

                btnAñadir.Enabled = true;
                btnBorrar.Enabled = true;
                btnActualizar.Enabled = true;
                btnCargar.Enabled = true;

            }
            else
            {
                //se actualiza un registro ya existente
            }
        }
        
        private void GetContacts()
        {//Para mostrar los usuarios registrados en el DataGrudView, y actualizarlos.
            
            MessageBox.Show("Se cargaran y/o actualizaran los datos registrados.");
            DGVContacts.DataSource = null;
            DGVContacts.DataSource = Contacts;   
        }

        #endregion
    }

    public class Contact
    {
        public string ID { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Dirrecion { get; set; }

        public string Pais { get; set; }

        public string Ciudad { get; set; }

        public string Celular { get; set; }

        public string Correo { get; set; }

    }
}
