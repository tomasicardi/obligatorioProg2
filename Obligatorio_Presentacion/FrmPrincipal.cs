namespace Obligatorio_Presentacion
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        // Abre un formulario hijo dentro de la ventana principal (MDI).
        private void AbrirFormulario(Form formulario)
        {
            formulario.MdiParent = this;
            formulario.Show();
        }

        private void MnuClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmClientes());
        }

        private void MnuDepositos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmDepositos());
        }

        private void MnuCaracteristicas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmCaracteristicas());
        }

        private void MnuTiposEquipamiento_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmTiposEquipamiento());
        }

        private void MnuUnidades_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmUnidades());
        }

        private void MnuStock_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmStock());
        }

        private void MnuSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
