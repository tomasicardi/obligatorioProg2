namespace Obligatorio_Presentacion
{
    partial class FrmUnidades
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
            grpFiltros = new GroupBox();
            lblFiltroTipo = new Label();
            cboFiltroTipo = new ComboBox();
            lblFiltroDeposito = new Label();
            cboFiltroDeposito = new ComboBox();
            lblFiltroEstado = new Label();
            cboFiltroEstado = new ComboBox();
            btnFiltrar = new Button();
            dgvUnidades = new DataGridView();
            grpUnidad = new GroupBox();
            lblCodigoSerie = new Label();
            txtCodigoSerie = new TextBox();
            lblMarca = new Label();
            txtMarca = new TextBox();
            lblModelo = new Label();
            txtModelo = new TextBox();
            lblTipo = new Label();
            cboTipo = new ComboBox();
            lblDeposito = new Label();
            cboDeposito = new ComboBox();
            btnGuardar = new Button();
            btnNuevo = new Button();
            grpEstado = new GroupBox();
            lblNuevoEstado = new Label();
            cboNuevoEstado = new ComboBox();
            btnCambiarEstado = new Button();
            grpFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUnidades).BeginInit();
            grpUnidad.SuspendLayout();
            grpEstado.SuspendLayout();
            SuspendLayout();
            //
            // grpFiltros
            //
            grpFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpFiltros.Controls.Add(lblFiltroTipo);
            grpFiltros.Controls.Add(cboFiltroTipo);
            grpFiltros.Controls.Add(lblFiltroDeposito);
            grpFiltros.Controls.Add(cboFiltroDeposito);
            grpFiltros.Controls.Add(lblFiltroEstado);
            grpFiltros.Controls.Add(cboFiltroEstado);
            grpFiltros.Controls.Add(btnFiltrar);
            grpFiltros.Location = new Point(12, 8);
            grpFiltros.Name = "grpFiltros";
            grpFiltros.Size = new Size(876, 60);
            grpFiltros.TabIndex = 0;
            grpFiltros.TabStop = false;
            grpFiltros.Text = "Filtros";
            //
            // lblFiltroTipo
            //
            lblFiltroTipo.AutoSize = true;
            lblFiltroTipo.Location = new Point(10, 27);
            lblFiltroTipo.Name = "lblFiltroTipo";
            lblFiltroTipo.Size = new Size(34, 15);
            lblFiltroTipo.TabIndex = 0;
            lblFiltroTipo.Text = "Tipo:";
            //
            // cboFiltroTipo
            //
            cboFiltroTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFiltroTipo.Location = new Point(50, 23);
            cboFiltroTipo.Name = "cboFiltroTipo";
            cboFiltroTipo.Size = new Size(170, 23);
            cboFiltroTipo.TabIndex = 1;
            //
            // lblFiltroDeposito
            //
            lblFiltroDeposito.AutoSize = true;
            lblFiltroDeposito.Location = new Point(235, 27);
            lblFiltroDeposito.Name = "lblFiltroDeposito";
            lblFiltroDeposito.Size = new Size(57, 15);
            lblFiltroDeposito.TabIndex = 2;
            lblFiltroDeposito.Text = "Depósito:";
            //
            // cboFiltroDeposito
            //
            cboFiltroDeposito.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFiltroDeposito.Location = new Point(300, 23);
            cboFiltroDeposito.Name = "cboFiltroDeposito";
            cboFiltroDeposito.Size = new Size(170, 23);
            cboFiltroDeposito.TabIndex = 3;
            //
            // lblFiltroEstado
            //
            lblFiltroEstado.AutoSize = true;
            lblFiltroEstado.Location = new Point(485, 27);
            lblFiltroEstado.Name = "lblFiltroEstado";
            lblFiltroEstado.Size = new Size(45, 15);
            lblFiltroEstado.TabIndex = 4;
            lblFiltroEstado.Text = "Estado:";
            //
            // cboFiltroEstado
            //
            cboFiltroEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFiltroEstado.Location = new Point(540, 23);
            cboFiltroEstado.Name = "cboFiltroEstado";
            cboFiltroEstado.Size = new Size(150, 23);
            cboFiltroEstado.TabIndex = 5;
            //
            // btnFiltrar
            //
            btnFiltrar.Location = new Point(705, 21);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(90, 27);
            btnFiltrar.TabIndex = 6;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += BtnFiltrar_Click;
            //
            // dgvUnidades
            //
            dgvUnidades.AllowUserToAddRows = false;
            dgvUnidades.AllowUserToDeleteRows = false;
            dgvUnidades.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUnidades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUnidades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUnidades.Location = new Point(12, 76);
            dgvUnidades.MultiSelect = false;
            dgvUnidades.Name = "dgvUnidades";
            dgvUnidades.ReadOnly = true;
            dgvUnidades.RowHeadersVisible = false;
            dgvUnidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUnidades.Size = new Size(560, 472);
            dgvUnidades.TabIndex = 1;
            dgvUnidades.CellClick += DgvUnidades_CellClick;
            //
            // grpUnidad
            //
            grpUnidad.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpUnidad.Controls.Add(lblCodigoSerie);
            grpUnidad.Controls.Add(txtCodigoSerie);
            grpUnidad.Controls.Add(lblMarca);
            grpUnidad.Controls.Add(txtMarca);
            grpUnidad.Controls.Add(lblModelo);
            grpUnidad.Controls.Add(txtModelo);
            grpUnidad.Controls.Add(lblTipo);
            grpUnidad.Controls.Add(cboTipo);
            grpUnidad.Controls.Add(lblDeposito);
            grpUnidad.Controls.Add(cboDeposito);
            grpUnidad.Controls.Add(btnGuardar);
            grpUnidad.Controls.Add(btnNuevo);
            grpUnidad.Location = new Point(585, 76);
            grpUnidad.Name = "grpUnidad";
            grpUnidad.Size = new Size(303, 310);
            grpUnidad.TabIndex = 2;
            grpUnidad.TabStop = false;
            grpUnidad.Text = "Nueva unidad";
            //
            // lblCodigoSerie
            //
            lblCodigoSerie.AutoSize = true;
            lblCodigoSerie.Location = new Point(15, 25);
            lblCodigoSerie.Name = "lblCodigoSerie";
            lblCodigoSerie.Size = new Size(94, 15);
            lblCodigoSerie.TabIndex = 0;
            lblCodigoSerie.Text = "Código de serie:";
            //
            // txtCodigoSerie
            //
            txtCodigoSerie.Location = new Point(15, 43);
            txtCodigoSerie.MaxLength = 50;
            txtCodigoSerie.Name = "txtCodigoSerie";
            txtCodigoSerie.Size = new Size(272, 23);
            txtCodigoSerie.TabIndex = 1;
            //
            // lblMarca
            //
            lblMarca.AutoSize = true;
            lblMarca.Location = new Point(15, 73);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(43, 15);
            lblMarca.TabIndex = 2;
            lblMarca.Text = "Marca:";
            //
            // txtMarca
            //
            txtMarca.Location = new Point(15, 91);
            txtMarca.MaxLength = 60;
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(272, 23);
            txtMarca.TabIndex = 3;
            //
            // lblModelo
            //
            lblModelo.AutoSize = true;
            lblModelo.Location = new Point(15, 121);
            lblModelo.Name = "lblModelo";
            lblModelo.Size = new Size(51, 15);
            lblModelo.TabIndex = 4;
            lblModelo.Text = "Modelo:";
            //
            // txtModelo
            //
            txtModelo.Location = new Point(15, 139);
            txtModelo.MaxLength = 60;
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(272, 23);
            txtModelo.TabIndex = 5;
            //
            // lblTipo
            //
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(15, 169);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(129, 15);
            lblTipo.TabIndex = 6;
            lblTipo.Text = "Tipo de equipamiento:";
            //
            // cboTipo
            //
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipo.Location = new Point(15, 187);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(272, 23);
            cboTipo.TabIndex = 7;
            //
            // lblDeposito
            //
            lblDeposito.AutoSize = true;
            lblDeposito.Location = new Point(15, 217);
            lblDeposito.Name = "lblDeposito";
            lblDeposito.Size = new Size(57, 15);
            lblDeposito.TabIndex = 8;
            lblDeposito.Text = "Depósito:";
            //
            // cboDeposito
            //
            cboDeposito.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDeposito.Location = new Point(15, 235);
            cboDeposito.Name = "cboDeposito";
            cboDeposito.Size = new Size(272, 23);
            cboDeposito.TabIndex = 9;
            //
            // btnGuardar
            //
            btnGuardar.Location = new Point(15, 268);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(130, 30);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += BtnGuardar_Click;
            //
            // btnNuevo
            //
            btnNuevo.Location = new Point(157, 268);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(130, 30);
            btnNuevo.TabIndex = 11;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += BtnNuevo_Click;
            //
            // grpEstado
            //
            grpEstado.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpEstado.Controls.Add(lblNuevoEstado);
            grpEstado.Controls.Add(cboNuevoEstado);
            grpEstado.Controls.Add(btnCambiarEstado);
            grpEstado.Location = new Point(585, 396);
            grpEstado.Name = "grpEstado";
            grpEstado.Size = new Size(303, 115);
            grpEstado.TabIndex = 3;
            grpEstado.TabStop = false;
            grpEstado.Text = "Cambiar estado de la unidad seleccionada";
            //
            // lblNuevoEstado
            //
            lblNuevoEstado.AutoSize = true;
            lblNuevoEstado.Location = new Point(15, 25);
            lblNuevoEstado.Name = "lblNuevoEstado";
            lblNuevoEstado.Size = new Size(81, 15);
            lblNuevoEstado.TabIndex = 0;
            lblNuevoEstado.Text = "Nuevo estado:";
            //
            // cboNuevoEstado
            //
            cboNuevoEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNuevoEstado.Location = new Point(15, 43);
            cboNuevoEstado.Name = "cboNuevoEstado";
            cboNuevoEstado.Size = new Size(272, 23);
            cboNuevoEstado.TabIndex = 1;
            //
            // btnCambiarEstado
            //
            btnCambiarEstado.Location = new Point(15, 74);
            btnCambiarEstado.Name = "btnCambiarEstado";
            btnCambiarEstado.Size = new Size(272, 30);
            btnCambiarEstado.TabIndex = 2;
            btnCambiarEstado.Text = "Cambiar estado";
            btnCambiarEstado.UseVisualStyleBackColor = true;
            btnCambiarEstado.Click += BtnCambiarEstado_Click;
            //
            // FrmUnidades
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 560);
            Controls.Add(grpEstado);
            Controls.Add(grpUnidad);
            Controls.Add(dgvUnidades);
            Controls.Add(grpFiltros);
            Name = "FrmUnidades";
            Text = "Unidades (equipos individualizados)";
            grpFiltros.ResumeLayout(false);
            grpFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUnidades).EndInit();
            grpUnidad.ResumeLayout(false);
            grpUnidad.PerformLayout();
            grpEstado.ResumeLayout(false);
            grpEstado.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpFiltros;
        private Label lblFiltroTipo;
        private ComboBox cboFiltroTipo;
        private Label lblFiltroDeposito;
        private ComboBox cboFiltroDeposito;
        private Label lblFiltroEstado;
        private ComboBox cboFiltroEstado;
        private Button btnFiltrar;
        private DataGridView dgvUnidades;
        private GroupBox grpUnidad;
        private Label lblCodigoSerie;
        private TextBox txtCodigoSerie;
        private Label lblMarca;
        private TextBox txtMarca;
        private Label lblModelo;
        private TextBox txtModelo;
        private Label lblTipo;
        private ComboBox cboTipo;
        private Label lblDeposito;
        private ComboBox cboDeposito;
        private Button btnGuardar;
        private Button btnNuevo;
        private GroupBox grpEstado;
        private Label lblNuevoEstado;
        private ComboBox cboNuevoEstado;
        private Button btnCambiarEstado;
    }
}
