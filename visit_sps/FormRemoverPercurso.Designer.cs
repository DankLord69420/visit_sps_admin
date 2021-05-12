
namespace visit_sps
{
    partial class FormRemoverPercurso
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
            this.materialRaisedButton_remover = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialSingleLineTextField_remover = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.SuspendLayout();
            // 
            // materialRaisedButton_remover
            // 
            this.materialRaisedButton_remover.AutoSize = true;
            this.materialRaisedButton_remover.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialRaisedButton_remover.Depth = 0;
            this.materialRaisedButton_remover.Icon = null;
            this.materialRaisedButton_remover.Location = new System.Drawing.Point(78, 152);
            this.materialRaisedButton_remover.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton_remover.Name = "materialRaisedButton_remover";
            this.materialRaisedButton_remover.Primary = true;
            this.materialRaisedButton_remover.Size = new System.Drawing.Size(84, 36);
            this.materialRaisedButton_remover.TabIndex = 17;
            this.materialRaisedButton_remover.Text = "Remover";
            this.materialRaisedButton_remover.UseVisualStyleBackColor = true;
            this.materialRaisedButton_remover.Click += new System.EventHandler(this.materialRaisedButton_remover_Click_1);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(7, 82);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(232, 19);
            this.materialLabel1.TabIndex = 16;
            this.materialLabel1.Text = "Insira o ID do Percurso a eliminar";
            // 
            // materialSingleLineTextField_remover
            // 
            this.materialSingleLineTextField_remover.Depth = 0;
            this.materialSingleLineTextField_remover.Hint = "";
            this.materialSingleLineTextField_remover.Location = new System.Drawing.Point(94, 116);
            this.materialSingleLineTextField_remover.MaxLength = 32767;
            this.materialSingleLineTextField_remover.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField_remover.Name = "materialSingleLineTextField_remover";
            this.materialSingleLineTextField_remover.PasswordChar = '\0';
            this.materialSingleLineTextField_remover.SelectedText = "";
            this.materialSingleLineTextField_remover.SelectionLength = 0;
            this.materialSingleLineTextField_remover.SelectionStart = 0;
            this.materialSingleLineTextField_remover.Size = new System.Drawing.Size(53, 23);
            this.materialSingleLineTextField_remover.TabIndex = 15;
            this.materialSingleLineTextField_remover.TabStop = false;
            this.materialSingleLineTextField_remover.UseSystemPasswordChar = false;
            // 
            // FormRemoverPercurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 210);
            this.Controls.Add(this.materialRaisedButton_remover);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.materialSingleLineTextField_remover);
            this.Name = "FormRemoverPercurso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remover Percurso";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton_remover;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField_remover;
    }
}