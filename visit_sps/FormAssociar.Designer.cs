namespace visit_sps
{
    partial class FormAssociar
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.materialRaisedButton_procurar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialSingleLineTextField_procurar = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialRaisedButton_associar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Font = new System.Drawing.Font("Roboto", 11F);
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(13, 196);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(255, 251);
            this.checkedListBox1.TabIndex = 0;
            this.checkedListBox1.Visible = false;
            // 
            // materialRaisedButton_procurar
            // 
            this.materialRaisedButton_procurar.AutoSize = true;
            this.materialRaisedButton_procurar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialRaisedButton_procurar.Depth = 0;
            this.materialRaisedButton_procurar.Icon = null;
            this.materialRaisedButton_procurar.Location = new System.Drawing.Point(93, 140);
            this.materialRaisedButton_procurar.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton_procurar.Name = "materialRaisedButton_procurar";
            this.materialRaisedButton_procurar.Primary = true;
            this.materialRaisedButton_procurar.Size = new System.Drawing.Size(92, 36);
            this.materialRaisedButton_procurar.TabIndex = 14;
            this.materialRaisedButton_procurar.Text = "Procurar";
            this.materialRaisedButton_procurar.UseVisualStyleBackColor = true;
            this.materialRaisedButton_procurar.Click += new System.EventHandler(this.materialRaisedButton_procurar_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(36, 80);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(217, 19);
            this.materialLabel1.TabIndex = 13;
            this.materialLabel1.Text = "Insera o ID do Local a associar";
            // 
            // materialSingleLineTextField_procurar
            // 
            this.materialSingleLineTextField_procurar.Depth = 0;
            this.materialSingleLineTextField_procurar.Hint = "";
            this.materialSingleLineTextField_procurar.Location = new System.Drawing.Point(120, 111);
            this.materialSingleLineTextField_procurar.MaxLength = 32767;
            this.materialSingleLineTextField_procurar.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField_procurar.Name = "materialSingleLineTextField_procurar";
            this.materialSingleLineTextField_procurar.PasswordChar = '\0';
            this.materialSingleLineTextField_procurar.SelectedText = "";
            this.materialSingleLineTextField_procurar.SelectionLength = 0;
            this.materialSingleLineTextField_procurar.SelectionStart = 0;
            this.materialSingleLineTextField_procurar.Size = new System.Drawing.Size(40, 23);
            this.materialSingleLineTextField_procurar.TabIndex = 12;
            this.materialSingleLineTextField_procurar.TabStop = false;
            this.materialSingleLineTextField_procurar.UseSystemPasswordChar = false;
            // 
            // materialRaisedButton_associar
            // 
            this.materialRaisedButton_associar.AutoSize = true;
            this.materialRaisedButton_associar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialRaisedButton_associar.Depth = 0;
            this.materialRaisedButton_associar.Icon = null;
            this.materialRaisedButton_associar.Location = new System.Drawing.Point(98, 473);
            this.materialRaisedButton_associar.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton_associar.Name = "materialRaisedButton_associar";
            this.materialRaisedButton_associar.Primary = true;
            this.materialRaisedButton_associar.Size = new System.Drawing.Size(87, 36);
            this.materialRaisedButton_associar.TabIndex = 15;
            this.materialRaisedButton_associar.Text = "Associar";
            this.materialRaisedButton_associar.UseVisualStyleBackColor = true;
            this.materialRaisedButton_associar.Visible = false;
            this.materialRaisedButton_associar.Click += new System.EventHandler(this.materialRaisedButton_associar_Click);
            // 
            // FormAssociar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 522);
            this.Controls.Add(this.materialRaisedButton_associar);
            this.Controls.Add(this.materialRaisedButton_procurar);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.materialSingleLineTextField_procurar);
            this.Controls.Add(this.checkedListBox1);
            this.Name = "FormAssociar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Associar Categorias a um Local";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton_procurar;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField_procurar;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton_associar;
    }
}