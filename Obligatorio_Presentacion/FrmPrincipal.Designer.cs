namespace Obligatorio_Presentacion
{
    partial class FrmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mnuPrincipal = new MenuStrip();
            mnuClientes = new ToolStripMenuItem();
            mnuDepositos = new ToolStripMenuItem();
            mnuEquipamiento = new ToolStripMenuItem();
            mnuCaracteristicas = new ToolStripMenuItem();
            mnuTiposEquipamiento = new ToolStripMenuItem();
            mnuUnidades = new ToolStripMenuItem();
            mnuStock = new ToolStripMenuItem();
            mnuSalir = new ToolStripMenuItem();
            mnuPrincipal.SuspendLayout();
            SuspendLayout();
            //
            // mnuPrincipal
            //
            mnuPrincipal.Items.AddRange(new ToolStripItem[] { mnuClientes, mnuDepositos, mnuEquipamiento, mnuSalir });
            mnuPrincipal.Location = new Point(0, 0);
            mnuPrincipal.Name = "mnuPrincipal";
            mnuPrincipal.Size = new Size(1000, 24);
            mnuPrincipal.TabIndex = 0;
            mnuPrincipal.Text = "menuStrip1";
            //
            // mnuClientes
            //
            mnuClientes.Name = "mnuClientes";
            mnuClientes.Size = new Size(61, 20);
            mnuClientes.Text = "Clientes";
            mnuClientes.Click += MnuClientes_Click;
            //
            // mnuDepositos
            //
            mnuDepositos.Name = "mnuDepositos";
            mnuDepositos.Size = new Size(71, 20);
            mnuDepositos.Text = "Depósitos";
            mnuDepositos.Click += MnuDepositos_Click;
            //
            // mnuEquipamiento
            //
            mnuEquipamiento.DropDownItems.AddRange(new ToolStripItem[] { mnuCaracteristicas, mnuTiposEquipamiento, mnuUnidades, mnuStock });
            mnuEquipamiento.Name = "mnuEquipamiento";
            mnuEquipamiento.Size = new Size(92, 20);
            mnuEquipamiento.Text = "Equipamiento";
            //
            // mnuCaracteristicas
            //
            mnuCaracteristicas.Name = "mnuCaracteristicas";
            mnuCaracteristicas.Size = new Size(230, 22);
            mnuCaracteristicas.Text = "Características";
            mnuCaracteristicas.Click += MnuCaracteristicas_Click;
            //
            // mnuTiposEquipamiento
            //
            mnuTiposEquipamiento.Name = "mnuTiposEquipamiento";
            mnuTiposEquipamiento.Size = new Size(230, 22);
            mnuTiposEquipamiento.Text = "Tipos de equipamiento";
            mnuTiposEquipamiento.Click += MnuTiposEquipamiento_Click;
            //
            // mnuUnidades
            //
            mnuUnidades.Name = "mnuUnidades";
            mnuUnidades.Size = new Size(230, 22);
            mnuUnidades.Text = "Unidades (individualizadas)";
            mnuUnidades.Click += MnuUnidades_Click;
            //
            // mnuStock
            //
            mnuStock.Name = "mnuStock";
            mnuStock.Size = new Size(230, 22);
            mnuStock.Text = "Stock (por cantidad)";
            mnuStock.Click += MnuStock_Click;
            //
            // mnuSalir
            //
            mnuSalir.Name = "mnuSalir";
            mnuSalir.Size = new Size(41, 20);
            mnuSalir.Text = "Salir";
            mnuSalir.Click += MnuSalir_Click;
            //
            // FrmPrincipal
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 650);
            Controls.Add(mnuPrincipal);
            IsMdiContainer = true;
            MainMenuStrip = mnuPrincipal;
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Alquiler de Equipamiento Audiovisual";
            WindowState = FormWindowState.Maximized;
            mnuPrincipal.ResumeLayout(false);
            mnuPrincipal.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnuPrincipal;
        private ToolStripMenuItem mnuClientes;
        private ToolStripMenuItem mnuDepositos;
        private ToolStripMenuItem mnuEquipamiento;
        private ToolStripMenuItem mnuCaracteristicas;
        private ToolStripMenuItem mnuTiposEquipamiento;
        private ToolStripMenuItem mnuUnidades;
        private ToolStripMenuItem mnuStock;
        private ToolStripMenuItem mnuSalir;
    }
}
