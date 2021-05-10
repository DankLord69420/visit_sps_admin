using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace visit_sps
{
    public partial class FormRemoverCategoria : MaterialForm
    {
        DataTable dt = new DataTable();
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        readonly string caminho;
        public FormRemoverCategoria(string dbCaminho)
        {
            InitializeComponent();
            caminho = dbCaminho;
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Blue800, MaterialSkin.Primary.Blue900, MaterialSkin.Primary.Blue500, MaterialSkin.Accent.Blue200, MaterialSkin.TextShade.WHITE);
        }

        private void materialRaisedButton_remover_Click(object sender, EventArgs e)
        {
            if (materialSingleLineTextField_remover.Text != "")
            {
                try
                {
                    dt = DBHelper.ObterCat(Convert.ToInt32(materialSingleLineTextField_remover.Text), caminho);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("O ID indicado não existe!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        DBHelper.RemoverCat(Convert.ToInt32(materialSingleLineTextField_remover.Text), caminho);
                        MessageBox.Show("Eliminado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    
                }
                catch (FormatException)
                {
                    MessageBox.Show("Introduza o tipo de dados correto!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("É necessário indicar um ID!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}
