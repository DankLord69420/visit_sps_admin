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

    public partial class FormInserirCategoria : MaterialForm
    {
        DataTable dt = new DataTable();
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        readonly string caminho;
        public FormInserirCategoria(string dbCaminho)
        {
            InitializeComponent();
            caminho = dbCaminho;
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Blue800, MaterialSkin.Primary.Blue900, MaterialSkin.Primary.Blue500, MaterialSkin.Accent.Blue200, MaterialSkin.TextShade.WHITE);
        }

        private void materialRaisedButton_alterar_Click(object sender, EventArgs e)
        {
            if (materialSingleLineTextField_nome.Text != "" && materialSingleLineTextField_icon.Text != "" && materialSingleLineTextField_nomeEng.Text != "")
            {
                try
                {

                    Categoria c = new Categoria();
                    c.icon = Convert.ToInt32(materialSingleLineTextField_icon.Text);
                    c.nome = materialSingleLineTextField_nome.Text;
                    c.nomeEng = materialSingleLineTextField_nomeEng.Text;
                    dt = DBHelper.ExisteCat(caminho, c.nome);

                    if (dt.Rows.Count == 0)
                    {
                        DBHelper.AdicionarCat(c, caminho);
                        MessageBox.Show("Categoria adicionada com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("A Categoria já existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        materialSingleLineTextField_nome.Focus();
                    }
                    

                    
                }
                catch (FormatException)
                {
                    MessageBox.Show("Introduza o tipo de dados correto!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("É necessário preencher os todos os parâmetros requeridos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
