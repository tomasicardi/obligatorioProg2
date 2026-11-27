using Obligatorio_Entidades;
using Obligatorio_Negocio;

namespace Obligatorio_Presentacion
{
    // Stock de elementos administrados por cantidad, por depósito (CU09)
    public partial class FrmStock : Form
    {
        private IEquipamientoServicio _equipamientoServicio = new EquipamientoServicio();
        private ITipoEquipamientoServicio _tipoServicio = new TipoEquipamientoServicio();
        private IDepositoServicio _depositoServicio = new DepositoServicio();

        public FrmStock()
        {
            InitializeComponent();
            CargarCombos();
            CargarStock();
        }

        private void CargarCombos()
        {
            try
            {
                cboDeposito.DisplayMember = "Nombre";
                cboDeposito.ValueMember = "Id";
                cboDeposito.DataSource = _depositoServicio.ObtenerTodos();

                // Solo los tipos que se administran por cantidad (no individualizables).
                cboTipo.DisplayMember = "Nombre";
                cboTipo.ValueMember = "Id";
                cboTipo.DataSource = _tipoServicio.ObtenerTodos()
                    .Where(t => !t.Individualizable)
                    .ToList();
            }
            catch (Exception ex)
            {
                MensajeHelper.MostrarError(ex);
            }
        }

        private void CargarStock()
        {
            try
            {
                dgvStock.DataSource = null;
                dgvStock.DataSource = _equipamientoServicio.ObtenerStock();
                GrillaHelper.OcultarColumna(dgvStock, "Id");
                GrillaHelper.CambiarTitulo(dgvStock, "Deposito", "Depósito");
            }
            catch (Exception ex)
            {
                MensajeHelper.MostrarError(ex);
            }
        }

        // Al hacer clic en una fila, cargamos el depósito, el tipo y la cantidad actual.
        private void DgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            StockDeposito stock = (StockDeposito)dgvStock.Rows[e.RowIndex].DataBoundItem;
            cboDeposito.SelectedValue = stock.Deposito.Id;
            cboTipo.SelectedValue = stock.Tipo.Id;
            nudCantidad.Value = stock.Cantidad;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Deposito deposito = cboDeposito.SelectedItem as Deposito;
            TipoEquipamiento tipo = cboTipo.SelectedItem as TipoEquipamiento;

            if (deposito == null || tipo == null)
            {
                MensajeHelper.MostrarInfo("Debe seleccionar un depósito y un tipo de equipamiento.");
                return;
            }

            try
            {
                _equipamientoServicio.AjustarStock(deposito.Id, tipo.Id, (int)nudCantidad.Value);
                MensajeHelper.MostrarInfo("El stock fue actualizado correctamente.");
                CargarStock();
            }
            catch (Exception ex)
            {
                MensajeHelper.MostrarError(ex);
            }
        }
    }
}
