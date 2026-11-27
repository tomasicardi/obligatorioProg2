using Obligatorio_Entidades;
using Obligatorio_Negocio;

namespace Obligatorio_Presentacion
{
    // Alta, modificación, baja y listado de depósitos (CU05)
    public partial class FrmDepositos : Form
    {
        private IDepositoServicio _depositoServicio = new DepositoServicio();
        private Deposito _depositoEnEdicion; // null = estamos dando de alta uno nuevo

        public FrmDepositos()
        {
            InitializeComponent();
            CargarDepositos();
            LimpiarFormulario();
        }

        private void CargarDepositos()
        {
            try
            {
                dgvDepositos.DataSource = null;
                dgvDepositos.DataSource = _depositoServicio.ObtenerTodos();
                GrillaHelper.OcultarColumna(dgvDepositos, "Activo");
                GrillaHelper.CambiarTitulo(dgvDepositos, "Direccion", "Dirección");
            }
            catch (Exception ex)
            {
                MensajeHelper.MostrarError(ex);
            }
        }

        private void LimpiarFormulario()
        {
            _depositoEnEdicion = null;
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            grpDatos.Text = "Nuevo depósito";
        }

        // Al hacer clic en una fila, cargamos sus datos para modificarlos.
        private void DgvDepositos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            _depositoEnEdicion = (Deposito)dgvDepositos.Rows[e.RowIndex].DataBoundItem;
            txtNombre.Text = _depositoEnEdicion.Nombre;
            txtDireccion.Text = _depositoEnEdicion.Direccion;
            grpDatos.Text = "Modificar depósito";
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Deposito deposito = new Deposito
                {
                    Nombre = txtNombre.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim()
                };

                if (_depositoEnEdicion == null)
                {
                    _depositoServicio.Alta(deposito);
                    MensajeHelper.MostrarInfo("El depósito fue registrado correctamente.");
                }
                else
                {
                    deposito.Id = _depositoEnEdicion.Id;
                    _depositoServicio.Modificar(deposito);
                    MensajeHelper.MostrarInfo("El depósito fue modificado correctamente.");
                }

                CargarDepositos();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MensajeHelper.MostrarError(ex);
            }
        }

        private void BtnBaja_Click(object sender, EventArgs e)
        {
            Deposito seleccionado = GrillaHelper.ObtenerSeleccionado<Deposito>(dgvDepositos);
            if (seleccionado == null)
            {
                MensajeHelper.MostrarInfo("Seleccione un depósito de la lista.");
                return;
            }

            if (!MensajeHelper.Confirmar($"¿Desea dar de baja el depósito {seleccionado.Nombre}?"))
                return;

            try
            {
                _depositoServicio.Baja(seleccionado.Id);
                MensajeHelper.MostrarInfo("El depósito fue dado de baja.");
                CargarDepositos();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MensajeHelper.MostrarError(ex);
            }
        }
    }
}
