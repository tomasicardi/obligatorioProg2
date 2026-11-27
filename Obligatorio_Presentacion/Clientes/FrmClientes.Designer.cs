namespace Obligatorio_Presentacion
{
    partial class FrmClientes
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
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            dgvClientes = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colTipo = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colIdentificacion = new DataGridViewTextBoxColumn();
            colTelefono = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colDireccion = new DataGridViewTextBoxColumn();
            colActivo = new DataGridViewCheckBoxColumn();
            btnNuevo = new Button();
            btnModificar = new Button();
            btnDesactivar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(14, 21);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(231, 20);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar por nombre o documento:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(229, 16);
            txtBuscar.Margin = new Padding(3, 4, 3, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(342, 27);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(583, 15);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(103, 33);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += BtnBuscar_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Columns.AddRange(new DataGridViewColumn[] { colId, colTipo, colNombre, colIdentificacion, colTelefono, colEmail, colDireccion, colActivo });
            dgvClientes.Location = new Point(14, 60);
            dgvClientes.Margin = new Padding(3, 4, 3, 4);
            dgvClientes.MultiSelect = false;
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.RowHeadersWidth = 51;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(955, 453);
            dgvClientes.TabIndex = 3;
            // 
            // colId
            // 
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colTipo
            // 
            colTipo.MinimumWidth = 6;
            colTipo.Name = "colTipo";
            colTipo.ReadOnly = true;
            // 
            // colNombre
            // 
            colNombre.MinimumWidth = 6;
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            // 
            // colIdentificacion
            // 
            colIdentificacion.MinimumWidth = 6;
            colIdentificacion.Name = "colIdentificacion";
            colIdentificacion.ReadOnly = true;
            // 
            // colTelefono
            // 
            colTelefono.MinimumWidth = 6;
            colTelefono.Name = "colTelefono";
            colTelefono.ReadOnly = true;
            // 
            // colEmail
            // 
            colEmail.MinimumWidth = 6;
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // 
            // colDireccion
            // 
            colDireccion.MinimumWidth = 6;
            colDireccion.Name = "colDireccion";
            colDireccion.ReadOnly = true;
            // 
            // colActivo
            // 
            colActivo.MinimumWidth = 6;
            colActivo.Name = "colActivo";
            colActivo.ReadOnly = true;
            // 
            // btnNuevo
            // 
            btnNuevo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnNuevo.Location = new Point(14, 531);
            btnNuevo.Margin = new Padding(3, 4, 3, 4);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(126, 40);
            btnNuevo.TabIndex = 4;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += BtnNuevo_Click;
            // 
            // btnModificar
            // 
            btnModificar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnModificar.Location = new Point(146, 531);
            btnModificar.Margin = new Padding(3, 4, 3, 4);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(126, 40);
            btnModificar.TabIndex = 5;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += BtnModificar_Click;
            // 
            // btnDesactivar
            // 
            btnDesactivar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDesactivar.Location = new Point(279, 531);
            btnDesactivar.Margin = new Padding(3, 4, 3, 4);
            btnDesactivar.Name = "btnDesactivar";
            btnDesactivar.Size = new Size(126, 40);
            btnDesactivar.TabIndex = 6;
            btnDesactivar.Text = "Desactivar";
            btnDesactivar.UseVisualStyleBackColor = true;
            btnDesactivar.Click += BtnDesactivar_Click;
            // 
            // FrmClientes
            // 
            AcceptButton = btnBuscar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(983, 587);
            Controls.Add(btnDesactivar);
            Controls.Add(btnModificar);
            Controls.Add(btnNuevo);
            Controls.Add(dgvClientes);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmClientes";
            Text = "Clientes";
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvClientes;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colTipo;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colIdentificacion;
        private DataGridViewTextBoxColumn colTelefono;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colDireccion;
        private DataGridViewCheckBoxColumn colActivo;
        private Button btnNuevo;
        private Button btnModificar;
        private Button btnDesactivar;
    }
}
