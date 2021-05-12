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
    public partial class FormInserirPercurso : MaterialForm
    {
        DataTable dt = new DataTable();
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        readonly string caminho;
        readonly string images;
        int n = -1;
        readonly List<string> ficheiros = new List<string>();
        public FormInserirPercurso(string dbCaminho, string imagesCaminho)
        {
            InitializeComponent();
            caminho = dbCaminho;
            images = imagesCaminho;
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Blue800, MaterialSkin.Primary.Blue900, MaterialSkin.Primary.Blue500, MaterialSkin.Accent.Blue200, MaterialSkin.TextShade.WHITE);

        }

        private void materialRaisedButton_img_Click_1(object sender, EventArgs e)
        {
            ficheiros.Clear();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Fotos (JPG) (*.jpg)|*.jpg";
            openFileDialog1.Multiselect = false;
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (String ficheiro in openFileDialog1.FileNames)
                {
                    ficheiros.Add(ficheiro);
                }
            }

            if (ficheiros.Count == 0)
            {

            }
            else
            {
                pictureBox1.Load(ficheiros[0]);
            }
            
        }

        private void materialRaisedButton_inserir_Click(object sender, EventArgs e)
        {
            if (materialSingleLineTextField_nome.Text != "" && txt_pontos.Text != "")
            {
                if (ficheiros.Count() == 1)
                {
                    try
                    {
                        string imagemURL = "./";
                        Percurso p = new Percurso();
                        dt = DBHelper.BuscarPercurso(caminho);
                        int id = Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString()) + 1;
                        string ficheiro = images + @"\percursos\b" + id;
                        string[] lista = ficheiro.Split('\\');
                        int m = Array.IndexOf(lista, "assets");
                        imagemURL = imagemURL + lista[m--] + '/';
                        MessageBox.Show(imagemURL);
                        imagemURL = imagemURL + lista[m + 2] + '/';
                        MessageBox.Show(imagemURL);
                        imagemURL = imagemURL + lista[m + 3] + '/';
                        MessageBox.Show(imagemURL);
                        imagemURL = imagemURL + lista[m + 4];
                        MessageBox.Show(imagemURL);

                        p.nome = materialSingleLineTextField_nome.Text;
                        p.pontos = txt_pontos.Text;
                        p.imagem = imagemURL;


                        dt = DBHelper.ExistePercurso(caminho, p.nome);

                        if (dt.Rows.Count == 0)
                        {
                                System.IO.File.Copy(ficheiros[0], ficheiro + ".jpg");

                            DBHelper.AdicionarPercurso(p, caminho);
                            MessageBox.Show("Pecurso adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("O Percurso já existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            materialSingleLineTextField_nome.Focus();
                        }





                        this.Close();
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Introduza o tipo de dados correto!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Apenas pode carregar 1 Imagen para um Percurso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("É necessário preencher os todos os parâmetros requeridos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

