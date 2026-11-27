using Obligatorio_Entidades;
using Obligatorio_Negocio;

namespace Obligatorio_Presentacion
{
    // Alta, modificación y baja de tipos de equipamiento con sus características (CU06)
    public partial class FrmTiposEquipamiento : Form
    {
        private ITipoEquipamientoServicio _tipoServicio = new TipoEquipamientoServicio();
        private ICatalogoServicio<Caracteristica> _caracteristicaServicio = new CaracteristicaServicio();
        private TipoEquipamiento _tipoEnEdicion; // null = nuevo

        public FrmTiposEquipamiento()
        {
            InitializeComponent();
            CargarCaracteristicas();
            CargarTipos();
            LimpiarFormulario();
        }

        // Llena la lista de casillas con todas las características existentes.
        private void CargarCaracteristicas()
        {
            try
            {
                clbCaracteristicas.Items.Clear();
                foreach (Caracteristica caracteristica in _caracteristicaServicio.ObtenerTodos())
                {
                    clbCaracteristicas.Items.Add(caracteristica);
                }
            }
            catch (Exception ex)
            {
                MensajeHelper.MostrarError(ex);
            }
        }

        private void CargarTipos()
        {
            try
            {
                dgvTipos.DataSource = null;
                dgvTipos.DataSource = _tipoServicio.ObtenerTodos();
                GrillaHelper.OcultarColumna(dgvTipos, "Caracteristicas");
                GrillaHelper.OcultarColumna(dgvTipos, "Activo");
                GrillaHelper.CambiarTitulo(dgvTipos, "Descripcion", "Descripción");
            }
            catch (Exception ex)
            {
                MensajeHelper.MostrarError(ex);
            }
        }

        private void LimpiarFormulario()
        {
            _tipoEnEdicion = null;
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            chkIndividualizable.Checked = false;
            for (int i = 0; i < clbCaracteristicas.Items.Count; i++)
                clbCaracteristicas.SetItemChecked(i, false);
            grpDatos.Text = "Nuevo tipo de equipamiento";
        }

        private void DgvTipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            _tipoEnEdicion = (TipoEquipamiento)dgvTipos.Rows[e.RowIndex].DataBoundItem;
            txtNombre.Text = _tipoEnEdicion.Nombre;
            txtDescripcion.Text = _tipoEnEdicion.Descripcion;
            chkIndividualizable.Checked = _tipoEnEdicion.Individualizable;

            // Marcamos las características que tiene este tipo.
            for (int i = 0; i < clbCaracteristicas.Items.Count; i++)
            {
                Caracteristica caracteristica = (Caracteristica)clbCaracteristicas.Items[i];
                bool laTiene = _tipoEnEdicion.Caracteristicas.Any(c => c.Id == caracteristica.Id);
                clbCaracteristicas.SetItemChecked(i, laTiene);
            }
            grpDatos.Text = "Modificar tipo de equipamiento";
        }

        // Devuelve los Id de las características marcadas.
        private List<int> ObtenerCaracteristicasMarcadas()
        {
            List<int> ids = new List<int>();
            foreach (Caracteristica caracteristica in clbCaracteristicas.CheckedItems)
            {
                ids.Add(caracteristica.Id);
            }
            return ids;
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                TipoEquipamiento tipo = new TipoEquipamiento
                {
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Individualizable = chkIndividualizable.Checked
                };
                List<int> caracteristicaIds = ObtenerCaracteristicasMarcadas();

                if (_tipoEnEdicion == null)
                {
                    _tipoServicio.Alta(tipo, caracteristicaIds);
                }
                else
                {
                    tipo.Id = _tipoEnEdicion.Id;
                    _tipoServicio.Modificar(tipo, caracteristicaIds);
                }

                MensajeHelper.MostrarInfo("El tipo de equipamiento fue guardado correctamente.");
                CargarTipos();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MensajeHelper.MostrarError(ex);
            }
        }

        private void BtnBaja_Click(object sender, EventArgs e)
        {
            TipoEquipamiento seleccionado = GrillaHelper.ObtenerSeleccionado<TipoEquipamiento>(dgvTipos);
            if (seleccionado == null)
            {
                MensajeHelper.MostrarInfo("Seleccione un tipo de equipamiento de la lista.");
                return;
            }

            if (!MensajeHelper.Confirmar($"¿Desea dar de baja el tipo {seleccionado.Nombre}?"))
                return;

            try
            {
                _tipoServicio.Baja(seleccionado.Id);
                MensajeHelper.MostrarInfo("El tipo de equipamiento fue dado de baja.");
                CargarTipos();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MensajeHelper.MostrarError(ex);
            }
        }
    }
}
