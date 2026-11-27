using Obligatorio_Entidades;
using Obligatorio_Negocio;

namespace Obligatorio_Presentacion
{
    // Alta y modificación de un cliente.
    // Si se recibe null es un alta; si se recibe un cliente, es una modificación.
    public partial class FrmCliente : Form
    {
        private IClienteServicio _clienteServicio = new ClienteServicio();
        private Cliente _cliente;

        public FrmCliente(Cliente cliente)
        {
            InitializeComponent();
            _cliente = cliente;
            cboTipo.DataSource = Enum.GetValues(typeof(TipoCliente));

            if (_cliente == null)
            {
                Text = "Nuevo cliente";
            }
            else
            {
                Text = "Modificar cliente";
                CargarDatos();
                cboTipo.Enabled = false; // el tipo de cliente no se cambia al modificar
            }
            ActualizarCamposSegunTipo();
        }

        private void CargarDatos()
        {
            cboTipo.SelectedItem = _cliente.ObtenerTipo();
            txtNombre.Text = _cliente.Nombre;
            txtTelefono.Text = _cliente.Telefono;
            txtEmail.Text = _cliente.Email;
            txtDireccion.Text = _cliente.Direccion;
            txtDocumento.Text = _cliente.Identificacion;

            if (_cliente is Organizacion organizacion)
                txtTipoOrganizacion.Text = organizacion.TipoOrganizacion;
        }

        private void CboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarCamposSegunTipo();
        }

        // Muestra "Documento" o "RUT", y el tipo de organización solo cuando corresponde.
        private void ActualizarCamposSegunTipo()
        {
            if (cboTipo.SelectedItem == null)
                return;

            TipoCliente tipo = (TipoCliente)cboTipo.SelectedItem;
            lblDocumento.Text = tipo == TipoCliente.Particular ? "Documento:" : "RUT:";

            bool esOrganizacion = tipo == TipoCliente.Organizacion;
            lblTipoOrganizacion.Visible = esOrganizacion;
            txtTipoOrganizacion.Visible = esOrganizacion;
        }

        // Crea el objeto correcto según el tipo elegido (polimorfismo).
        private Cliente CrearClienteDesdeFormulario()
        {
            TipoCliente tipo = (TipoCliente)cboTipo.SelectedItem;
            Cliente cliente;

            switch (tipo)
            {
                case TipoCliente.Particular:
                    cliente = new Particular { Documento = txtDocumento.Text.Trim() };
                    break;
                case TipoCliente.Empresa:
                    cliente = new Empresa { Rut = txtDocumento.Text.Trim() };
                    break;
                default:
                    cliente = new Organizacion
                    {
                        Rut = txtDocumento.Text.Trim(),
                        TipoOrganizacion = txtTipoOrganizacion.Text.Trim()
                    };
                    break;
            }

            cliente.Nombre = txtNombre.Text.Trim();
            cliente.Telefono = txtTelefono.Text.Trim();
            cliente.Email = txtEmail.Text.Trim();
            cliente.Direccion = txtDireccion.Text.Trim();

            if (_cliente != null)
            {
                cliente.Id = _cliente.Id;
                cliente.Activo = _cliente.Activo;
            }
            return cliente;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = CrearClienteDesdeFormulario();

                if (_cliente == null)
                    _clienteServicio.Registrar(cliente);
                else
                    _clienteServicio.Modificar(cliente);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                // No cerramos el formulario, así el usuario puede corregir los datos.
                MensajeHelper.MostrarError(ex);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
