using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace visit_sps
{
    public partial class FormListar : MaterialForm 
    {
        DataTable dt = new DataTable();
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        readonly string caminho;
        public FormListar(string dbCaminho)
        {
            InitializeComponent();
            caminho = dbCaminho;
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Blue800, MaterialSkin.Primary.Blue900, MaterialSkin.Primary.Blue500, MaterialSkin.Accent.Blue200, MaterialSkin.TextShade.WHITE);
        }

        private void FormListar_Load(object sender, EventArgs e)
        {
            dt = DBHelper.BuscarID( caminho);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int id = Convert.ToInt32(dt.Rows[i].ItemArray[0].ToString());
                string nome =  dt.Rows[i].ItemArray[1].ToString();
                var item = new ListViewItem(new[] { id.ToString(), nome });
                materialListView1.Items.Add(item);

            }

            dt.Clear();

            dt = DBHelper.BuscarCat(caminho);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int id = Convert.ToInt32(dt.Rows[i].ItemArray[0].ToString());
                string nome = dt.Rows[i].ItemArray[1].ToString();
                var item = new ListViewItem(new[] { id.ToString(), nome });
                materialListView2.Items.Add(item);
            }

            dt.Clear();

            dt = DBHelper.BuscarPercurso(caminho);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int id = Convert.ToInt32(dt.Rows[i].ItemArray[0].ToString());
                string nome = dt.Rows[i].ItemArray[1].ToString();
                var item = new ListViewItem(new[] { id.ToString(), nome });
                materialListView_percursos.Items.Add(item);
            }


        }
    }
}
