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
    public partial class FormAlterarCategoria : MaterialForm
    {
        DataTable dt = new DataTable();
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        readonly string caminho;
        public FormAlterarCategoria(string dbCaminho)
        {
            InitializeComponent();
            caminho = dbCaminho;
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Blue800, MaterialSkin.Primary.Blue900, MaterialSkin.Primary.Blue500, MaterialSkin.Accent.Blue200, MaterialSkin.TextShade.WHITE);
        }

        private void materialRaisedButton_procurar_Click(object sender, EventArgs e)
        {
            if (materialSingleLineTextField_procurar.Text != "")
            {
                try
                {
                    dt = DBHelper.ObterCat(Convert.ToInt32(materialSingleLineTextField_procurar.Text), caminho);
                    if (dt.Rows.Count == 1)
                    {
                        materialSingleLineTextField_icon.Text = dt.Rows[0].ItemArray[2].ToString();
                        materialSingleLineTextField_nome.Text = dt.Rows[0].ItemArray[1].ToString();
                        materialSingleLineTextField_nomeEng.Text = dt.Rows[0].ItemArray[3].ToString();
                        materialSingleLineTextField_icon.Visible = true;
                        materialSingleLineTextField_nome.Visible = true;
                        materialSingleLineTextField_nomeEng.Visible = true;
                        materialLabel1.Visible = true;
                        materialLabel3.Visible = true;
                        materialLabel4.Visible = true;
                        materialLabel5.Visible = true;
                        materialLabel2.Visible = true;
                        materialRaisedButton_alterar.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("O ID inserido não existe!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        materialSingleLineTextField_procurar.Focus();
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Introduza o tipo de dados correto!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Introduza um ID!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void materialRaisedButton_alterar_Click(object sender, EventArgs e)
        {
            if(materialSingleLineTextField_nome.Text != "" && materialSingleLineTextField_icon.Text != "" && materialSingleLineTextField_nomeEng.Text != "")
            {
                try
                {
                    Categoria c = new Categoria();
                    c.id_local = Convert.ToInt32(materialSingleLineTextField_procurar.Text);
                    c.icon = Convert.ToInt32(materialSingleLineTextField_icon.Text);
                    c.nome = materialSingleLineTextField_nome.Text;
                    c.nomeEng = materialSingleLineTextField_nomeEng.Text;
                    DBHelper.AlterCat(c, caminho);
                    MessageBox.Show("Alterado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
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
