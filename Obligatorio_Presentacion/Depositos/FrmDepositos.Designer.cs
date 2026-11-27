namespace Obligatorio_Presentacion
{
    partial class FrmDepositos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvDepositos = new DataGridView();
            grpDatos = new GroupBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblDireccion = new Label();
            txtDireccion = new TextBox();
            btnGuardar = new Button();
            btnNuevo = new Button();
            btnBaja = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDepositos).BeginInit();
            grpDatos.SuspendLayout();
            SuspendLayout();
            //
            // dgvDepositos
            //
            dgvDepositos.AllowUserToAddRows = false;
            dgvDepositos.AllowUserToDeleteRows = false;
            dgvDepositos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDepositos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDepositos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDepositos.Location = new Point(12, 12);
            dgvDepositos.MultiSelect = false;
            dgvDepositos.Name = "dgvDepositos";
            dgvDepositos.ReadOnly = true;
            dgvDepositos.RowHeadersVisible = false;
            dgvDepositos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDepositos.Size = new Size(420, 396);
            dgvDepositos.TabIndex = 0;
            dgvDepositos.CellClick += DgvDepositos_CellClick;
            //
            // grpDatos
            //
            grpDatos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpDatos.Controls.Add(lblNombre);
            grpDatos.Controls.Add(txtNombre);
            grpDatos.Controls.Add(lblDireccion);
            grpDatos.Controls.Add(txtDireccion);
            grpDatos.Controls.Add(btnGuardar);
            grpDatos.Controls.Add(btnNuevo);
            grpDatos.Location = new Point(445, 12);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(243, 195);
            grpDatos.TabIndex = 1;
            grpDatos.TabStop = false;
            grpDatos.Text = "Nuevo depósito";
            //
            // lblNombre
            //
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(15, 28);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            //
            // txtNombre
            //
            txtNombre.Location = new Point(15, 46);
            txtNombre.MaxLength = 80;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(212, 23);
            txtNombre.TabIndex = 1;
            //
            // lblDireccion
            //
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(15, 80);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(60, 15);
            lblDireccion.TabIndex = 2;
            lblDireccion.Text = "Dirección:";
            //
            // txtDireccion
            //
            txtDireccion.Location = new Point(15, 98);
            txtDireccion.MaxLength = 150;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(212, 23);
            txtDireccion.TabIndex = 3;
            //
            // btnGuardar
            //
            btnGuardar.Location = new Point(15, 142);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 30);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += BtnGuardar_Click;
            //
            // btnNuevo
            //
            btnNuevo.Location = new Point(127, 142);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(100, 30);
            btnNuevo.TabIndex = 5;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += BtnNuevo_Click;
            //
            // btnBaja
            //
            btnBaja.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBaja.Location = new Point(445, 220);
            btnBaja.Name = "btnBaja";
            btnBaja.Size = new Size(243, 30);
            btnBaja.TabIndex = 2;
            btnBaja.Text = "Dar de baja el seleccionado";
            btnBaja.UseVisualStyleBackColor = true;
            btnBaja.Click += BtnBaja_Click;
            //
            // FrmDepositos
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 420);
            Controls.Add(btnBaja);
            Controls.Add(grpDatos);
            Controls.Add(dgvDepositos);
            Name = "FrmDepositos";
            Text = "Depósitos";
            ((System.ComponentModel.ISupportInitialize)dgvDepositos).EndInit();
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvDepositos;
        private GroupBox grpDatos;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblDireccion;
        private TextBox txtDireccion;
        private Button btnGuardar;
        private Button btnNuevo;
        private Button btnBaja;
    }
}
