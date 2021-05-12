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
    public partial class FormInserirLocal : MaterialForm
    {
        DataTable dt = new DataTable();
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        readonly string caminho;
        readonly    string images;
        int n = -1;
        readonly List<string> ficheiros = new List<string>();
        public FormInserirLocal(string dbCaminho, string imagesCaminho)
        {
            InitializeComponent();
            caminho = dbCaminho;
            images = imagesCaminho;
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Blue800, MaterialSkin.Primary.Blue900, MaterialSkin.Primary.Blue500, MaterialSkin.Accent.Blue200, MaterialSkin.TextShade.WHITE);
            
        }

        private void materialRaisedButton_img_Click(object sender, EventArgs e)
        {
            ficheiros.Clear();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Fotos (JPG) (*.jpg)|*.jpg";
            openFileDialog1.Multiselect = true;
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
                //Faz nada
            }
            else
            {
                pictureBox1.Load(ficheiros[0]);
            }
            materialRaisedButton1_next.Visible = true;
        }

        private void materialRaisedButton_inserir_Click(object sender, EventArgs e)
        {
            if (materialSingleLineTextField_nome.Text != "" && txt_desc.Text != "" && materialSingleLineTextField_latitude.Text != "" && materialSingleLineTextField_longitude.Text != "" && materialSingleLineTextField_morada.Text != "" && textBox_descEng.Text != "")
            {
                if (ficheiros.Count() == 3)
                {
                    try
                    {
                        string imagemURL = "./";
                        Local l = new Local();
                        dt = DBHelper.ObterIDProx(caminho);
                        int id = Convert.ToInt32(dt.Rows[2].ItemArray[1].ToString())+1;
                        string ficheiro = images + @"\" + id;
                        System.IO.Directory.CreateDirectory(ficheiro);
                        string[] lista = ficheiro.Split('\\');
                        int m = Array.IndexOf(lista, "assets");
                        imagemURL = imagemURL + lista[m--] + '/';
                        imagemURL = imagemURL + lista[m + 2] + '/';
                        imagemURL = imagemURL + lista[m + 3] + "/a";
                        materialRaisedButton1_next.Visible = true;

                        l.nome = materialSingleLineTextField_nome.Text;
                        l.desc = txt_desc.Text;
                        l.imagemUrl = imagemURL;
                        l.horario = textBox1.Text;
                        l.contacto = materialSingleLineTextField_contacto.Text;
                        l.latitude = materialSingleLineTextField_latitude.Text;
                        l.longitude = materialSingleLineTextField_longitude.Text;
                        l.morada = materialSingleLineTextField_morada.Text;
                        l.descEng = textBox_descEng.Text;
                        l.horarioEng = textBox2.Text;
                        if (materialSingleLineTextField_trivago.Text == "")
                        {
                            l.trivago = null;
                        }
                        else
                        {
                            l.trivago = materialSingleLineTextField_trivago.Text;
                        }

                        dt = DBHelper.ExisteLocal(caminho, l.nome);

                        if (dt.Rows.Count == 0)
                        {

                            for (int i = 0; i < 3; i++)
                            {
                                System.IO.File.Copy(ficheiros[i], ficheiro + "/a" + i + ".jpg");
                            }

                            DBHelper.AdicionarLocal(l, caminho);
                            MessageBox.Show("Local adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("O Local já existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Apenas pode carregar 3 Imagens para um Local!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            else
            {
                MessageBox.Show("É necessário preencher os todos os parâmetros requeridos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void materialRaisedButton1_next_Click(object sender, EventArgs e)
        {
            n = n+1;
            if (n == 0)
            {
                materialRaisedButton_antes.Visible = true;
                materialRaisedButton1_next.Visible = true;
                pictureBox1.Load(ficheiros[1]);
            }
            else
            {
                if (n == 1)
                {
                    materialRaisedButton_antes.Visible = true;
                    materialRaisedButton1_next.Visible = false;
                    pictureBox1.Load(ficheiros[2]);
                }
                else
                {
                    materialRaisedButton_antes.Visible = false;
                    pictureBox1.Load(ficheiros[0]);
                }
            }
        }
        private void materialRaisedButton_antes_Click(object sender, EventArgs e)
        {
            n = n-1;
            if (n == 0)
            {
                materialRaisedButton_antes.Visible = true;
                materialRaisedButton1_next.Visible = true;
                pictureBox1.Load(ficheiros[1]);
            }
            else
            {
                if (n == 1)
                {
                    materialRaisedButton_antes.Visible = true;
                    materialRaisedButton1_next.Visible = false;
                    pictureBox1.Load(ficheiros[2]);
                }
                else
                {
                    materialRaisedButton_antes.Visible = false;
                    pictureBox1.Load(ficheiros[0]);
                }
            }
        }

    }
}
