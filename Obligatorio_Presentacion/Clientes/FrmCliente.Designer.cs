namespace Obligatorio_Presentacion
{
    partial class FrmCliente
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
            lblTipo = new Label();
            cboTipo = new ComboBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblDireccion = new Label();
            txtDireccion = new TextBox();
            lblDocumento = new Label();
            txtDocumento = new TextBox();
            lblTipoOrganizacion = new Label();
            txtTipoOrganizacion = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            //
            // lblTipo
            //
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(20, 23);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(85, 15);
            lblTipo.TabIndex = 0;
            lblTipo.Text = "Tipo de cliente:";
            //
            // cboTipo
            //
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipo.Location = new Point(150, 20);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(240, 23);
            cboTipo.TabIndex = 1;
            cboTipo.SelectedIndexChanged += CboTipo_SelectedIndexChanged;
            //
            // lblNombre
            //
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(20, 58);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre:";
            //
            // txtNombre
            //
            txtNombre.Location = new Point(150, 55);
            txtNombre.MaxLength = 100;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(240, 23);
            txtNombre.TabIndex = 3;
            //
            // lblTelefono
            //
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(20, 93);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(55, 15);
            lblTelefono.TabIndex = 4;
            lblTelefono.Text = "Teléfono:";
            //
            // txtTelefono
            //
            txtTelefono.Location = new Point(150, 90);
            txtTelefono.MaxLength = 30;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(240, 23);
            txtTelefono.TabIndex = 5;
            //
            // lblEmail
            //
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(20, 128);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email:";
            //
            // txtEmail
            //
            txtEmail.Location = new Point(150, 125);
            txtEmail.MaxLength = 120;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(240, 23);
            txtEmail.TabIndex = 7;
            //
            // lblDireccion
            //
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(20, 163);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(60, 15);
            lblDireccion.TabIndex = 8;
            lblDireccion.Text = "Dirección:";
            //
            // txtDireccion
            //
            txtDireccion.Location = new Point(150, 160);
            txtDireccion.MaxLength = 150;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(240, 23);
            txtDireccion.TabIndex = 9;
            //
            // lblDocumento
            //
            lblDocumento.AutoSize = true;
            lblDocumento.Location = new Point(20, 198);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(73, 15);
            lblDocumento.TabIndex = 10;
            lblDocumento.Text = "Documento:";
            //
            // txtDocumento
            //
            txtDocumento.Location = new Point(150, 195);
            txtDocumento.MaxLength = 20;
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(240, 23);
            txtDocumento.TabIndex = 11;
            //
            // lblTipoOrganizacion
            //
            lblTipoOrganizacion.AutoSize = true;
            lblTipoOrganizacion.Location = new Point(20, 233);
            lblTipoOrganizacion.Name = "lblTipoOrganizacion";
            lblTipoOrganizacion.Size = new Size(124, 15);
            lblTipoOrganizacion.TabIndex = 12;
            lblTipoOrganizacion.Text = "Tipo de organización:";
            //
            // txtTipoOrganizacion
            //
            txtTipoOrganizacion.Location = new Point(150, 230);
            txtTipoOrganizacion.MaxLength = 50;
            txtTipoOrganizacion.Name = "txtTipoOrganizacion";
            txtTipoOrganizacion.Size = new Size(240, 23);
            txtTipoOrganizacion.TabIndex = 13;
            //
            // btnGuardar
            //
            btnGuardar.Location = new Point(184, 280);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 30);
            btnGuardar.TabIndex = 14;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += BtnGuardar_Click;
            //
            // btnCancelar
            //
            btnCancelar.Location = new Point(290, 280);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 30);
            btnCancelar.TabIndex = 15;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += BtnCancelar_Click;
            //
            // FrmCliente
            //
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(414, 330);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtTipoOrganizacion);
            Controls.Add(lblTipoOrganizacion);
            Controls.Add(txtDocumento);
            Controls.Add(lblDocumento);
            Controls.Add(txtDireccion);
            Controls.Add(lblDireccion);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtTelefono);
            Controls.Add(lblTelefono);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(cboTipo);
            Controls.Add(lblTipo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCliente";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTipo;
        private ComboBox cboTipo;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblDireccion;
        private TextBox txtDireccion;
        private Label lblDocumento;
        private TextBox txtDocumento;
        private Label lblTipoOrganizacion;
        private TextBox txtTipoOrganizacion;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}
