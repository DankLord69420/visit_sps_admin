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
using Microsoft.WindowsAPICodePack.Dialogs;

namespace visit_sps
{
    public partial class Form1 : MaterialForm
    {
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        public string dbCaminho;
        public string imagesCaminho;

        public Form1()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Blue800, MaterialSkin.Primary.Blue900, MaterialSkin.Primary.Blue500, MaterialSkin.Accent.Blue200, MaterialSkin.TextShade.WHITE);
        }

        private void materialRaisedButton_bd_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Ficheiro Base de Dados (*.db)|*.db";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dbCaminho = openFileDialog1.FileName;
                materialSingleLineTextField_bd.Text = dbCaminho;
            }
        }

        private void materialRaisedButton_assets_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog openFileDialog1 = new CommonOpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.IsFolderPicker = true;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == CommonFileDialogResult.Ok)
            {
                imagesCaminho = openFileDialog1.FileName;
                materialSingleLineTextField_images.Text = imagesCaminho;
            }
        }


        private void materialSingleLineTextField_bd_TextChanged(object sender, EventArgs e)
        {
            materialRaisedButton_inserirLocal.Enabled = !string.IsNullOrEmpty(materialSingleLineTextField_bd.Text) && !string.IsNullOrEmpty(materialSingleLineTextField_images.Text);
            materialRaisedButton_inserirCategoria.Enabled = !string.IsNullOrEmpty(materialSingleLineTextField_bd.Text) && !string.IsNullOrEmpty(materialSingleLineTextField_images.Text);
            materialRaisedButton_atualizarCategoria.Enabled = !string.IsNullOrEmpty(materialSingleLineTextField_bd.Text) && !string.IsNullOrEmpty(materialSingleLineTextField_images.Text);
            materialRaisedButton_atualizarLocal.Enabled = !string.IsNullOrEmpty(materialSingleLineTextField_bd.Text) && !string.IsNullOrEmpty(materialSingleLineTextField_images.Text);
            materialRaisedButton_eliminarLocal.Enabled = !string.IsNullOrEmpty(materialSingleLineTextField_bd.Text) && !string.IsNullOrEmpty(materialSingleLineTextField_images.Text);
            materialRaisedButton_eliminarCategoria.Enabled = !string.IsNullOrEmpty(materialSingleLineTextField_bd.Text) && !string.IsNullOrEmpty(materialSingleLineTextField_images.Text);
            materialRaisedButton_associar.Enabled = !string.IsNullOrEmpty(materialSingleLineTextField_bd.Text) && !string.IsNullOrEmpty(materialSingleLineTextField_images.Text);
            materialRaisedButton_listar.Enabled = !string.IsNullOrEmpty(materialSingleLineTextField_bd.Text) && !string.IsNullOrEmpty(materialSingleLineTextField_images.Text);
        }

        private void materialSingleLineTextField_images_TextChanged(object sender, EventArgs e)
        {
            materialRaisedButton_inserirLocal.Enabled = !string.IsNullOrEmpty(materialSingleLineTextField_bd.Text) && !string.IsNullOrEmpty(materialSingleLineTextField_images.Text);
            materialRaisedButton_inserirCategoria.Enabled = !string.IsNullOrEmpty(materialSingleLineTextField_bd.Text) && !string.IsNullOrEmpty(materialSingleLineTextField_images.Text);
            materialRaisedButton_atualizarCategoria.Enabled = !string.IsNullOrEmpty(materialSingleLineTextField_bd.Text) && !string.IsNullOrEmpty(materialSingleLineTextField_images.Text);
            materialRaisedButton_atualizarLocal.Enabled = !string.IsNullOrEmpty(materialSingleLineTextField_bd.Text) && !string.IsNullOrEmpty(materialSingleLineTextField_images.Text);
            materialRaisedButton_eliminarLocal.Enabled = !string.IsNullOrEmpty(materialSingleLineTextField_bd.Text) && !string.IsNullOrEmpty(materialSingleLineTextField_images.Text);
            materialRaisedButton_eliminarCategoria.Enabled = !string.IsNullOrEmpty(materialSingleLineTextField_bd.Text) && !string.IsNullOrEmpty(materialSingleLineTextField_images.Text);
            materialRaisedButton_associar.Enabled = !string.IsNullOrEmpty(materialSingleLineTextField_bd.Text) && !string.IsNullOrEmpty(materialSingleLineTextField_images.Text);
            materialRaisedButton_listar.Enabled = !string.IsNullOrEmpty(materialSingleLineTextField_bd.Text) && !string.IsNullOrEmpty(materialSingleLineTextField_images.Text);

        }

        private void materialRaisedButton_atualizarLocal_Click(object sender, EventArgs e)
        {
            FormAlterarLocal f2 = new FormAlterarLocal(dbCaminho);
            f2.ShowDialog();
        }

        private void materialRaisedButton_atualizarCategoria_Click(object sender, EventArgs e)
        {
            FormAlterarCategoria f2 = new FormAlterarCategoria(dbCaminho);
            f2.ShowDialog();
        }

        private void materialRaisedButton_eliminarLocal_Click(object sender, EventArgs e)
        {
            FormRemoverLocal f2 = new FormRemoverLocal(dbCaminho, imagesCaminho);
            f2.ShowDialog();
        }

        private void materialRaisedButton_eliminarCategoria_Click(object sender, EventArgs e)
        {
            FormRemoverCategoria f2 = new FormRemoverCategoria(dbCaminho);
            f2.ShowDialog();
        }

        private void materialRaisedButton_inserirCategoria_Click(object sender, EventArgs e)
        {
            FormInserirCategoria f2 = new FormInserirCategoria(dbCaminho);
            f2.ShowDialog();
        }

        private void materialRaisedButton_inserir_Click(object sender, EventArgs e)
        {
            FormInserirLocal f2 = new FormInserirLocal(dbCaminho, imagesCaminho);
            f2.ShowDialog();
        }

        private void materialRaisedButton_associar_Click(object sender, EventArgs e)
        {
            FormAssociar f2 = new FormAssociar(dbCaminho);
            f2.ShowDialog();
        }

        private void materialRaisedButton_listar_Click(object sender, EventArgs e)
        {
            FormListar f2 = new FormListar(dbCaminho);
            f2.ShowDialog();
        }
    }
    
}
