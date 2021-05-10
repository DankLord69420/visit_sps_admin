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
    public partial class FormAlterarLocal : MaterialForm
    {
        DataTable dt = new DataTable();
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        readonly string caminho;

        
        public FormAlterarLocal(string dbCaminho)
        {
            InitializeComponent();
            caminho = dbCaminho;
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Blue800, MaterialSkin.Primary.Blue900, MaterialSkin.Primary.Blue500, MaterialSkin.Accent.Blue200, MaterialSkin.TextShade.WHITE);
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (materialSingleLineTextField_procurar.Text != "")
            {
                try
                {
                    dt = DBHelper.ObterLocal(Convert.ToInt32(materialSingleLineTextField_procurar.Text), caminho);
                    if (dt.Rows.Count == 1)
                    {
                        materialSingleLineTextField_nome.Text = dt.Rows[0].ItemArray[1].ToString();
                        txt_desc.Text = dt.Rows[0].ItemArray[2].ToString();
                        textBox1.Text = dt.Rows[0].ItemArray[4].ToString();
                        materialSingleLineTextField_contacto.Text = dt.Rows[0].ItemArray[5].ToString();
                        materialSingleLineTextField_latitude.Text = dt.Rows[0].ItemArray[6].ToString().Replace(",", ".");
                        materialSingleLineTextField_longitude.Text = dt.Rows[0].ItemArray[7].ToString().Replace(",", ".");
                        materialSingleLineTextField_morada.Text = dt.Rows[0].ItemArray[8].ToString();
                        textBox_descEng.Text = dt.Rows[0].ItemArray[10].ToString();
                        textBox2.Text = dt.Rows[0].ItemArray[11].ToString();
                        materialSingleLineTextField_trivago.Text = dt.Rows[0].ItemArray[12].ToString();

                        materialLabel1.Visible = true;
                        materialLabel3.Visible = true;
                        materialLabel4.Visible = true;
                        materialLabel5.Visible = true;
                        materialLabel6.Visible = true;
                        materialLabel7.Visible = true;
                        materialLabel8.Visible = true;
                        materialLabel9.Visible = true;
                        materialLabel10.Visible = true;
                        materialLabel11.Visible = true;
                        materialLabel12.Visible = true;

                        materialSingleLineTextField_nome.Visible = true;
                        txt_desc.Visible = true;
                        textBox1.Visible = true;
                        materialSingleLineTextField_contacto.Visible = true;
                        materialSingleLineTextField_latitude.Visible = true;
                        materialSingleLineTextField_longitude.Visible = true;
                        materialSingleLineTextField_morada.Visible = true;
                        textBox_descEng.Visible = true;
                        textBox2.Visible = true;
                        materialSingleLineTextField_trivago.Visible = true;
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
                MessageBox.Show("É necessário indicar um ID!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
            
        }

        private void materialRaisedButton_alterar_Click(object sender, EventArgs e)
        {
            if (materialSingleLineTextField_nome.Text != "" && txt_desc.Text != "" && materialSingleLineTextField_latitude.Text != "" && materialSingleLineTextField_longitude.Text != "" && materialSingleLineTextField_morada.Text != "" && textBox_descEng.Text != "")
            {
                Local l = new Local();
                l.id = Convert.ToInt32(materialSingleLineTextField_procurar.Text);
                l.nome = materialSingleLineTextField_nome.Text;
                l.desc = txt_desc.Text;
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

                DBHelper.AlterLocal(l, caminho);
                MessageBox.Show("Local alterado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("É necessário preencher os todos os parâmetros requeridos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            

        }
    }
}
