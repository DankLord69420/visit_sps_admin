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
    public partial class FormAssociar : MaterialForm
    {
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        readonly string caminho;
        DataTable dt = new DataTable();

        public FormAssociar(string dbCaminho)
        {
            InitializeComponent();
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Blue800, MaterialSkin.Primary.Blue900, MaterialSkin.Primary.Blue500, MaterialSkin.Accent.Blue200, MaterialSkin.TextShade.WHITE);
            caminho = dbCaminho;
        }

        private void materialRaisedButton_procurar_Click(object sender, EventArgs e)
        {
            if (materialSingleLineTextField_procurar.Text != "")
            {
                try
                {
                    dt = DBHelper.ObterLocal(Convert.ToInt32(materialSingleLineTextField_procurar.Text), caminho);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("O ID indicado não existe!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        dt.Clear();
                        checkedListBox1.DataSource = null;
                        checkedListBox1.Items.Clear();
                        int pos = 0;
                        dt = DBHelper.BuscarCat(caminho);
                        Dictionary<int, string> test = new Dictionary<int, string>();

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int id = Convert.ToInt32(dt.Rows[i].ItemArray[0].ToString());
                            string nome = dt.Rows[i].ItemArray[1].ToString();
                            pos++;
                            test.Add(id, nome);
                        }
                        checkedListBox1.DataSource = new BindingSource(test, null);
                        checkedListBox1.DisplayMember = "Value";
                        checkedListBox1.ValueMember = "Key";

                        materialRaisedButton_associar.Visible = true;
                        checkedListBox1.Visible = true;
                        dt = DBHelper.BuscarIDLocalCategoria(caminho, Convert.ToInt32(materialSingleLineTextField_procurar.Text));


                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            for (int j = 0; j < pos; j++)
                            {
                                int key = ((KeyValuePair<int, string>)checkedListBox1.Items[j]).Key;

                                if (dt.Rows[i].ItemArray[0].ToString() == key.ToString())
                                {
                                    checkedListBox1.SetItemCheckState(j, CheckState.Checked);
                                }
                            }
                        }

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

        private void materialRaisedButton_associar_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                int key = ((KeyValuePair<int, string>)checkedListBox1.Items[i]).Key;
                   
                    if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                    {
                        DBHelper.inserirCatLocal(caminho, key, Convert.ToInt32(materialSingleLineTextField_procurar.Text));
                    }
                    else
                    {
                        DBHelper.removerCatLocal(caminho, key, Convert.ToInt32(materialSingleLineTextField_procurar.Text));
                    }

            }
            MessageBox.Show("Categorias adicionadas com sucesso a um Local!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
