using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace visit_sps
{

    public partial class FormRemoverPercurso : MaterialForm
    {
        DataTable dt = new DataTable();
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        readonly string caminho;
        readonly string images;
        public FormRemoverPercurso(string dbCaminho, string imagesCaminho)
        {
            InitializeComponent();
            caminho = dbCaminho;
            images = imagesCaminho;
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Blue800, MaterialSkin.Primary.Blue900, MaterialSkin.Primary.Blue500, MaterialSkin.Accent.Blue200, MaterialSkin.TextShade.WHITE);
        }

        private void materialRaisedButton_remover_Click_1(object sender, EventArgs e)
        {
            if (materialSingleLineTextField_remover.Text != "")
            {
                try
                {

                    dt = DBHelper.ObterPercurso(Convert.ToInt32(materialSingleLineTextField_remover.Text), caminho);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("O ID indicado não existe!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string ficheiro = dt.Rows[0].ItemArray[3].ToString();
                        string[] lista = ficheiro.Split('/');
                        ficheiro = images + '\\' + lista[3];

                        MessageBox.Show(Path.Combine(ficheiro, lista[4])+".jpg");
                        if (File.Exists(Path.Combine(ficheiro, lista[4]) + ".jpg"))
                        {
                            MessageBox.Show(lista[4]);
                            File.Delete(Path.Combine(ficheiro, lista[4] + ".jpg"));
                        }

                        DBHelper.RemoverPercurso(Convert.ToInt32(materialSingleLineTextField_remover.Text), caminho);
                        MessageBox.Show("Percurso eliminado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

