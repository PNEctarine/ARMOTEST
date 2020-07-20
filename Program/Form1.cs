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
using Program.Properties;


namespace Program
{
	public partial class Form1 : Form
	{
		string DirectoryLocation;
		string FileName;
		string FileSymbols;
		public Form1()
		{
			InitializeComponent();

			DirectoryLocation = Settings.Default.DirectoryWaySave;
			DirectoryWay.Text = Settings.Default.DirectoryWaySave;

			Symbols.Text = Settings.Default.SymbolsSave;
			FileTemplate.Text = Settings.Default.FileTemplateSave;

			if (DirectoryWay.Text != "")
			{
				FindButton.Visible = true;
			}
		}

		private void LocationButton_Click(object sender, EventArgs e)
		{
			DirectoryWay.Text = null;
			FolderBrowserDialog FolderBrowser = new FolderBrowserDialog();

			if (FolderBrowser.ShowDialog() == DialogResult.OK)
			{
				DirectoryLocation = FolderBrowser.SelectedPath;
				DirectoryWay.Text = DirectoryLocation;
			}
			FindButton.Visible = true;
			Settings.Default.DirectoryWaySave = DirectoryWay.Text;
			Settings.Default.Save();
		}

		private void FindButton_Click(object sender, EventArgs e)
		{
			Settings.Default.SymbolsSave = Symbols.Text;
			Settings.Default.Save();

			Settings.Default.FileTemplateSave = FileTemplate.Text;
			Settings.Default.Save();

			if (FileTemplate.Text == "" && Symbols.Text == "")
			{
				MessageBox.Show("Шаблон имени файла или символы в файле не может быть пустым!");
			}

			else
			{
				
				FileName = FileTemplate.Text;
				FileSymbols = Symbols.Text;
				DirectoryInfo DirectoryName = new DirectoryInfo(DirectoryLocation);

				if (DirectoryName.Exists)
				{
					TreeNode RootNode = new TreeNode(DirectoryName.Name);
					RootNode.Tag = DirectoryName;
					GetDirectories(DirectoryName.GetDirectories(), RootNode);
					treeView.Nodes.Add(RootNode);


				}
			}
		}
		private void GetDirectories(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
		{
			TreeNode aNode;
			DirectoryInfo[] subSubDirs;
			foreach (DirectoryInfo subDir in subDirs)
			{
				aNode = new TreeNode(subDir.Name, 0, 0);
				aNode.Tag = subDir;
				aNode.ImageKey = "folder";
				subSubDirs = subDir.GetDirectories();
				if (subSubDirs.Length != 0)
				{
					GetDirectories(subSubDirs, aNode);
				}
				nodeToAddTo.Nodes.Add(aNode);
			}
		}

        private void FileTemplate_TextChanged(object sender, EventArgs e)
        {
			Settings.Default.FileTemplateSave = FileTemplate.Text;
			Settings.Default.Save();
		}

        private void Symbols_TextChanged(object sender, EventArgs e)
        {
			Settings.Default.SymbolsSave = Symbols.Text;
			Settings.Default.Save();
		}
    }
}

