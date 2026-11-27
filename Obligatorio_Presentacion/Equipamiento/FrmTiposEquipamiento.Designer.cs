namespace Obligatorio_Presentacion
{
    partial class FrmTiposEquipamiento
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
            dgvTipos = new DataGridView();
            grpDatos = new GroupBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            chkIndividualizable = new CheckBox();
            lblCaracteristicas = new Label();
            clbCaracteristicas = new CheckedListBox();
            btnGuardar = new Button();
            btnNuevo = new Button();
            btnBaja = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTipos).BeginInit();
            grpDatos.SuspendLayout();
            SuspendLayout();
            //
            // dgvTipos
            //
            dgvTipos.AllowUserToAddRows = false;
            dgvTipos.AllowUserToDeleteRows = false;
            dgvTipos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTipos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTipos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTipos.Location = new Point(12, 12);
            dgvTipos.MultiSelect = false;
            dgvTipos.Name = "dgvTipos";
            dgvTipos.ReadOnly = true;
            dgvTipos.RowHeadersVisible = false;
            dgvTipos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTipos.Size = new Size(460, 456);
            dgvTipos.TabIndex = 0;
            dgvTipos.CellClick += DgvTipos_CellClick;
            //
            // grpDatos
            //
            grpDatos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpDatos.Controls.Add(lblNombre);
            grpDatos.Controls.Add(txtNombre);
            grpDatos.Controls.Add(lblDescripcion);
            grpDatos.Controls.Add(txtDescripcion);
            grpDatos.Controls.Add(chkIndividualizable);
            grpDatos.Controls.Add(lblCaracteristicas);
            grpDatos.Controls.Add(clbCaracteristicas);
            grpDatos.Controls.Add(btnGuardar);
            grpDatos.Controls.Add(btnNuevo);
            grpDatos.Location = new Point(485, 12);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(323, 400);
            grpDatos.TabIndex = 1;
            grpDatos.TabStop = false;
            grpDatos.Text = "Nuevo tipo de equipamiento";
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
            txtNombre.Size = new Size(292, 23);
            txtNombre.TabIndex = 1;
            //
            // lblDescripcion
            //
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(15, 80);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(72, 15);
            lblDescripcion.TabIndex = 2;
            lblDescripcion.Text = "Descripción:";
            //
            // txtDescripcion
            //
            txtDescripcion.Location = new Point(15, 98);
            txtDescripcion.MaxLength = 250;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(292, 50);
            txtDescripcion.TabIndex = 3;
            //
            // chkIndividualizable
            //
            chkIndividualizable.AutoSize = true;
            chkIndividualizable.Location = new Point(15, 160);
            chkIndividualizable.Name = "chkIndividualizable";
            chkIndividualizable.Size = new Size(270, 19);
            chkIndividualizable.TabIndex = 4;
            chkIndividualizable.Text = "Individualizable (cada unidad tiene nro. de serie)";
            chkIndividualizable.UseVisualStyleBackColor = true;
            //
            // lblCaracteristicas
            //
            lblCaracteristicas.AutoSize = true;
            lblCaracteristicas.Location = new Point(15, 190);
            lblCaracteristicas.Name = "lblCaracteristicas";
            lblCaracteristicas.Size = new Size(87, 15);
            lblCaracteristicas.TabIndex = 5;
            lblCaracteristicas.Text = "Características:";
            //
            // clbCaracteristicas
            //
            clbCaracteristicas.CheckOnClick = true;
            clbCaracteristicas.FormattingEnabled = true;
            clbCaracteristicas.Location = new Point(15, 208);
            clbCaracteristicas.Name = "clbCaracteristicas";
            clbCaracteristicas.Size = new Size(292, 130);
            clbCaracteristicas.TabIndex = 6;
            //
            // btnGuardar
            //
            btnGuardar.Location = new Point(15, 352);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(140, 30);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += BtnGuardar_Click;
            //
            // btnNuevo
            //
            btnNuevo.Location = new Point(167, 352);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(140, 30);
            btnNuevo.TabIndex = 8;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += BtnNuevo_Click;
            //
            // btnBaja
            //
            btnBaja.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBaja.Location = new Point(485, 425);
            btnBaja.Name = "btnBaja";
            btnBaja.Size = new Size(323, 30);
            btnBaja.TabIndex = 2;
            btnBaja.Text = "Dar de baja el seleccionado";
            btnBaja.UseVisualStyleBackColor = true;
            btnBaja.Click += BtnBaja_Click;
            //
            // FrmTiposEquipamiento
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 480);
            Controls.Add(btnBaja);
            Controls.Add(grpDatos);
            Controls.Add(dgvTipos);
            Name = "FrmTiposEquipamiento";
            Text = "Tipos de equipamiento";
            ((System.ComponentModel.ISupportInitialize)dgvTipos).EndInit();
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvTipos;
        private GroupBox grpDatos;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private CheckBox chkIndividualizable;
        private Label lblCaracteristicas;
        private CheckedListBox clbCaracteristicas;
        private Button btnGuardar;
        private Button btnNuevo;
        private Button btnBaja;
    }
}
