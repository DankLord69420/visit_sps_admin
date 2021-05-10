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

    public partial class FormRemoverLocal : MaterialForm
    {
        DataTable dt = new DataTable();
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        readonly string caminho;
        readonly string images;
        public FormRemoverLocal(string dbCaminho, string imagesCaminho)
        {
            InitializeComponent();
            caminho = dbCaminho;
            images = imagesCaminho;
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

                    dt = DBHelper.Generico(Convert.ToInt32(materialSingleLineTextField_remover.Text), caminho, "SELECT * FROM local WHERE id_local = ");
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("O ID indicado não existe!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        int id = Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString());
                        string ficheiro = images + @"\" + id;
                        System.IO.DirectoryInfo di = new DirectoryInfo(ficheiro);
                        foreach (FileInfo file in di.GetFiles())
                        {
                            file.Delete();
                        }

                        DBHelper.Generico(Convert.ToInt32(materialSingleLineTextField_remover.Text), caminho, "DELETE FROM local WHERE id_local=");
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
