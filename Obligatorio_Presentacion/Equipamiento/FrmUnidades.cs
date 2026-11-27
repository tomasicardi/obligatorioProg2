using Obligatorio_Entidades;
using Obligatorio_Negocio;

namespace Obligatorio_Presentacion
{
    // Unidades de equipos individualizados: alta, modificación, búsqueda y cambio de estado (CU07, CU08)
    public partial class FrmUnidades : Form
    {
        private IEquipamientoServicio _equipamientoServicio = new EquipamientoServicio();
        private ITipoEquipamientoServicio _tipoServicio = new TipoEquipamientoServicio();
        private IDepositoServicio _depositoServicio = new DepositoServicio();
        private Unidad _unidadEnEdicion; // null = nueva

        public FrmUnidades()
        {
            InitializeComponent();
            CargarCombos();
            CargarUnidades();
            LimpiarFormulario();
        }

        private void CargarCombos()
        {
            try
            {
                // Solo los tipos individualizables tienen unidades.
                List<TipoEquipamiento> tipos = _tipoServicio.ObtenerTodos()
                    .Where(t => t.Individualizable)
                    .ToList();
                List<Deposito> depositos = _depositoServicio.ObtenerTodos();

                // --- Combos de filtros (con la opción "(Todos)" con Id = 0) ---
                List<TipoEquipamiento> filtroTipos = new List<TipoEquipamiento>();
                filtroTipos.Add(new TipoEquipamiento { Id = 0, Nombre = "(Todos)" });
                filtroTipos.AddRange(tipos);
                cboFiltroTipo.DataSource = filtroTipos;

                List<Deposito> filtroDepositos = new List<Deposito>();
                filtroDepositos.Add(new Deposito { Id = 0, Nombre = "(Todos)" });
                filtroDepositos.AddRange(depositos);
                cboFiltroDeposito.DataSource = filtroDepositos;

                cboFiltroEstado.Items.Clear();
                cboFiltroEstado.Items.Add("(Todos)");
                foreach (EstadoUnidad estado in Enum.GetValues(typeof(EstadoUnidad)))
                    cboFiltroEstado.Items.Add(estado);
                cboFiltroEstado.SelectedIndex = 0;

                // --- Combos de datos de la unidad ---
                // Usamos listas nuevas: si dos combos comparten la misma lista, se mueven juntos.
                cboTipo.DisplayMember = "Nombre";
                cboTipo.ValueMember = "Id";
                cboTipo.DataSource = new List<TipoEquipamiento>(tipos);

                cboDeposito.DisplayMember = "Nombre";
                cboDeposito.ValueMember = "Id";
                cboDeposito.DataSource = new List<Deposito>(depositos);

                // Estados que se pueden asignar a mano (ver EquipamientoServicio.CambiarEstado)
                cboNuevoEstado.DataSource = new List<EstadoUnidad>
                {
                    EstadoUnidad.Disponible,
                    EstadoUnidad.EnMantenimiento,
                    EstadoUnidad.FueraDeServicio
                };
            }
            catch (Exception ex)
            {
                MensajeHelper.MostrarError(ex);
            }
        }

        private void CargarUnidades()
        {
            try
            {
                int? tipoId = null;
                TipoEquipamiento tipo = cboFiltroTipo.SelectedItem as TipoEquipamiento;
                if (tipo != null && tipo.Id != 0)
                    tipoId = tipo.Id;

                int? depositoId = null;
                Deposito deposito = cboFiltroDeposito.SelectedItem as Deposito;
                if (deposito != null && deposito.Id != 0)
                    depositoId = deposito.Id;

                EstadoUnidad? estado = null;
                if (cboFiltroEstado.SelectedItem is EstadoUnidad estadoElegido)
                    estado = estadoElegido;

                dgvUnidades.DataSource = null;
                dgvUnidades.DataSource = _equipamientoServicio.BuscarUnidades(tipoId, depositoId, estado);
                GrillaHelper.OcultarColumna(dgvUnidades, "Valores");
                GrillaHelper.CambiarTitulo(dgvUnidades, "CodigoSerie", "Código de serie");
                GrillaHelper.CambiarTitulo(dgvUnidades, "Deposito", "Depósito");
            }
            catch (Exception ex)
            {
                MensajeHelper.MostrarError(ex);
            }
        }

        private void LimpiarFormulario()
        {
            _unidadEnEdicion = null;
            txtCodigoSerie.Text = string.Empty;
            txtMarca.Text = string.Empty;
            txtModelo.Text = string.Empty;
            grpUnidad.Text = "Nueva unidad";
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            CargarUnidades();
        }

        private void DgvUnidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            _unidadEnEdicion = (Unidad)dgvUnidades.Rows[e.RowIndex].DataBoundItem;
            txtCodigoSerie.Text = _unidadEnEdicion.CodigoSerie;
            txtMarca.Text = _unidadEnEdicion.Marca;
            txtModelo.Text = _unidadEnEdicion.Modelo;
            cboTipo.SelectedValue = _unidadEnEdicion.Tipo.Id;       // selecciona por Id (ValueMember)
            cboDeposito.SelectedValue = _unidadEnEdicion.Deposito.Id;
            grpUnidad.Text = "Modificar unidad";
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Unidad unidad = new Unidad
                {
                    CodigoSerie = txtCodigoSerie.Text.Trim(),
                    Marca = txtMarca.Text.Trim(),
                    Modelo = txtModelo.Text.Trim(),
                    Tipo = cboTipo.SelectedItem as TipoEquipamiento,
                    Deposito = cboDeposito.SelectedItem as Deposito
                };

                if (_unidadEnEdicion == null)
                {
                    _equipamientoServicio.RegistrarUnidad(unidad);
                }
                else
                {
                    unidad.Id = _unidadEnEdicion.Id;
                    _equipamientoServicio.ModificarUnidad(unidad);
                }

                MensajeHelper.MostrarInfo("La unidad fue guardada correctamente.");
                CargarUnidades();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MensajeHelper.MostrarError(ex);
            }
        }

        private void BtnCambiarEstado_Click(object sender, EventArgs e)
        {
            Unidad seleccionada = GrillaHelper.ObtenerSeleccionado<Unidad>(dgvUnidades);
            if (seleccionada == null)
            {
                MensajeHelper.MostrarInfo("Seleccione una unidad de la lista.");
                return;
            }

            try
            {
                EstadoUnidad nuevoEstado = (EstadoUnidad)cboNuevoEstado.SelectedItem;
                _equipamientoServicio.CambiarEstado(seleccionada.Id, nuevoEstado);
                MensajeHelper.MostrarInfo($"La unidad {seleccionada.CodigoSerie} pasó a {nuevoEstado}.");
                CargarUnidades();
            }
            catch (Exception ex)
            {
                MensajeHelper.MostrarError(ex);
            }
        }
    }
}
