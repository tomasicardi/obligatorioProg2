using Obligatorio_Entidades;
using Obligatorio_Negocio;

namespace Obligatorio_Presentacion
{
    // Listado de clientes: buscar, nuevo, modificar y desactivar (CU01 a CU04)
    public partial class FrmClientes : Form
    {
        private IClienteServicio _clienteServicio = new ClienteServicio();

        public FrmClientes()
        {
            InitializeComponent();
            // Usamos solo las columnas definidas en el diseñador. La lista mezcla
            // Particular, Empresa y Organizacion, y así se muestra igual para todos.
            dgvClientes.AutoGenerateColumns = false;
            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                dgvClientes.DataSource = null;
                dgvClientes.DataSource = _clienteServicio.Buscar(txtBuscar.Text);
            }
            catch (Exception ex)
            {
                MensajeHelper.MostrarError(ex);
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmCliente frmCliente = new FrmCliente(null);
            if (frmCliente.ShowDialog() == DialogResult.OK)
            {
                MensajeHelper.MostrarInfo("El cliente fue registrado correctamente.");
                CargarClientes();
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            Cliente seleccionado = GrillaHelper.ObtenerSeleccionado<Cliente>(dgvClientes);
            if (seleccionado == null)
            {
                MensajeHelper.MostrarInfo("Seleccione un cliente de la lista.");
                return;
            }

            try
            {
                // Lo pedimos de nuevo a la base para tener los datos actualizados.
                Cliente cliente = _clienteServicio.ObtenerPorId(seleccionado.Id);
                FrmCliente frmCliente = new FrmCliente(cliente);
                if (frmCliente.ShowDialog() == DialogResult.OK)
                {
                    MensajeHelper.MostrarInfo("El cliente fue modificado correctamente.");
                    CargarClientes();
                }
            }
            catch (Exception ex)
            {
                MensajeHelper.MostrarError(ex);
            }
        }

        private void BtnDesactivar_Click(object sender, EventArgs e)
        {
            Cliente seleccionado = GrillaHelper.ObtenerSeleccionado<Cliente>(dgvClientes);
            if (seleccionado == null)
            {
                MensajeHelper.MostrarInfo("Seleccione un cliente de la lista.");
                return;
            }

            if (!MensajeHelper.Confirmar($"¿Desea desactivar al cliente {seleccionado.Nombre}?"))
                return;

            try
            {
                _clienteServicio.Desactivar(seleccionado.Id);
                MensajeHelper.MostrarInfo("El cliente fue desactivado.");
                CargarClientes();
            }
            catch (Exception ex)
            {
                MensajeHelper.MostrarError(ex);
            }
        }
    }
}
