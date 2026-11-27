namespace Obligatorio_Presentacion
{
    partial class FrmStock
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
            dgvStock = new DataGridView();
            grpDatos = new GroupBox();
            lblDeposito = new Label();
            cboDeposito = new ComboBox();
            lblTipo = new Label();
            cboTipo = new ComboBox();
            lblCantidad = new Label();
            nudCantidad = new NumericUpDown();
            btnGuardar = new Button();
            lblAyuda = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvStock).BeginInit();
            grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            SuspendLayout();
            //
            // dgvStock
            //
            dgvStock.AllowUserToAddRows = false;
            dgvStock.AllowUserToDeleteRows = false;
            dgvStock.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStock.Location = new Point(12, 12);
            dgvStock.MultiSelect = false;
            dgvStock.Name = "dgvStock";
            dgvStock.ReadOnly = true;
            dgvStock.RowHeadersVisible = false;
            dgvStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStock.Size = new Size(440, 396);
            dgvStock.TabIndex = 0;
            dgvStock.CellClick += DgvStock_CellClick;
            //
            // grpDatos
            //
            grpDatos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpDatos.Controls.Add(lblDeposito);
            grpDatos.Controls.Add(cboDeposito);
            grpDatos.Controls.Add(lblTipo);
            grpDatos.Controls.Add(cboTipo);
            grpDatos.Controls.Add(lblCantidad);
            grpDatos.Controls.Add(nudCantidad);
            grpDatos.Controls.Add(btnGuardar);
            grpDatos.Location = new Point(465, 12);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(283, 225);
            grpDatos.TabIndex = 1;
            grpDatos.TabStop = false;
            grpDatos.Text = "Cargar / ajustar stock";
            //
            // lblDeposito
            //
            lblDeposito.AutoSize = true;
            lblDeposito.Location = new Point(15, 25);
            lblDeposito.Name = "lblDeposito";
            lblDeposito.Size = new Size(57, 15);
            lblDeposito.TabIndex = 0;
            lblDeposito.Text = "Depósito:";
            //
            // cboDeposito
            //
            cboDeposito.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDeposito.Location = new Point(15, 43);
            cboDeposito.Name = "cboDeposito";
            cboDeposito.Size = new Size(252, 23);
            cboDeposito.TabIndex = 1;
            //
            // lblTipo
            //
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(15, 75);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(129, 15);
            lblTipo.TabIndex = 2;
            lblTipo.Text = "Tipo de equipamiento:";
            //
            // cboTipo
            //
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipo.Location = new Point(15, 93);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(252, 23);
            cboTipo.TabIndex = 3;
            //
            // lblCantidad
            //
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(15, 125);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(103, 15);
            lblCantidad.TabIndex = 4;
            lblCantidad.Text = "Cantidad total:";
            //
            // nudCantidad
            //
            nudCantidad.Location = new Point(15, 143);
            nudCantidad.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(120, 23);
            nudCantidad.TabIndex = 5;
            //
            // btnGuardar
            //
            btnGuardar.Location = new Point(15, 180);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(252, 30);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar cantidad";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += BtnGuardar_Click;
            //
            // lblAyuda
            //
            lblAyuda.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblAyuda.Location = new Point(465, 245);
            lblAyuda.Name = "lblAyuda";
            lblAyuda.Size = new Size(283, 60);
            lblAyuda.TabIndex = 2;
            lblAyuda.Text = "Aquí solo aparecen los tipos que se administran por cantidad (no individualizables). La cantidad que se guarda es el total que hay en ese depósito.";
            //
            // FrmStock
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 420);
            Controls.Add(lblAyuda);
            Controls.Add(grpDatos);
            Controls.Add(dgvStock);
            Name = "FrmStock";
            Text = "Stock por cantidad";
            ((System.ComponentModel.ISupportInitialize)dgvStock).EndInit();
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvStock;
        private GroupBox grpDatos;
        private Label lblDeposito;
        private ComboBox cboDeposito;
        private Label lblTipo;
        private ComboBox cboTipo;
        private Label lblCantidad;
        private NumericUpDown nudCantidad;
        private Button btnGuardar;
        private Label lblAyuda;
    }
}
