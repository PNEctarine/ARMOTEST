using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
namespace Program
{
	partial class Form1
	{
        void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Stopwatch Time = new Stopwatch();

            TreeNode newSelected = e.Node;
            listView.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;
            foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
            {
                item = new ListViewItem(dir.Name, 0);
                subItems = new ListViewItem.ListViewSubItem[] {new ListViewItem.ListViewSubItem(item, "Directory"), new ListViewItem.ListViewSubItem(item, dir.LastAccessTime.ToShortDateString())};
                item.SubItems.AddRange(subItems);
                listView.Items.Add(item);
            }
            int counter = 0;
            foreach (FileInfo file in nodeDirInfo.GetFiles())
            {

                if (FileTemplate.Text != "" && Symbols.Text == "")
                {
                    Time.Start();
                    if (file.Name == FileName)
                    {
                        item = new ListViewItem(file.Name, 1);
                        subItems = new ListViewItem.ListViewSubItem[] { new ListViewItem.ListViewSubItem(item, "File"),
                new ListViewItem.ListViewSubItem(item, file.LastAccessTime.ToShortDateString())};
                        item.SubItems.AddRange(subItems);
                        counter += 1;
                        listView.Items.Add(item);
                        ProcessedFilesNumber.Text = Convert.ToString(counter);
                        Time.Stop();
                        TimeMillisec.Text = Convert.ToString(Time.ElapsedMilliseconds);
                    }
                }
                else if (Symbols.Text != "" && FileTemplate.Text == "")
                {
                    Time.Start();
                    string SymbolsInFile;
                    SymbolsInFile = File.ReadAllText(file.FullName);
                    if (SymbolsInFile == Symbols.Text)
                    {
                        item = new ListViewItem(file.Name, 1);
                        subItems = new ListViewItem.ListViewSubItem[] { new ListViewItem.ListViewSubItem(item, "File"),
                new ListViewItem.ListViewSubItem(item, file.LastAccessTime.ToShortDateString())};
                        item.SubItems.AddRange(subItems);
                        counter += 1;
                        listView.Items.Add(item);
                        ProcessedFilesNumber.Text = Convert.ToString(counter);
                        Time.Stop();
                        TimeMillisec.Text = Convert.ToString(Time.ElapsedMilliseconds);
                    }
                }
                else if (FileTemplate.Text != "" && Symbols.Text != "")
                {
                    Time.Start();
                    string SymbolsInFile;
                    SymbolsInFile = File.ReadAllText(file.FullName);
                    if (file.Name == FileName && SymbolsInFile == Symbols.Text)
                    {
                        item = new ListViewItem(file.Name, 1);
                        subItems = new ListViewItem.ListViewSubItem[] { new ListViewItem.ListViewSubItem(item, "File"),
                new ListViewItem.ListViewSubItem(item, file.LastAccessTime.ToShortDateString())};
                        item.SubItems.AddRange(subItems);
                        counter += 1;
                        listView.Items.Add(item);
                        ProcessedFilesNumber.Text = Convert.ToString(counter);
                    }
                }
                Time.Stop();
                TimeMillisec.Text = Convert.ToString(Time.ElapsedMilliseconds);
            }

            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.LocationButton = new System.Windows.Forms.Button();
            this.FindButton = new System.Windows.Forms.Button();
            this.FileTemplate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Symbols = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DirectoryWay = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProcessedFiles = new System.Windows.Forms.Label();
            this.ProcessedFilesNumber = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.Label();
            this.TimeMillisec = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LocationButton
            // 
            this.LocationButton.Location = new System.Drawing.Point(728, 27);
            this.LocationButton.Name = "LocationButton";
            this.LocationButton.Size = new System.Drawing.Size(130, 20);
            this.LocationButton.TabIndex = 0;
            this.LocationButton.Text = "Выбрать папку";
            this.LocationButton.UseVisualStyleBackColor = true;
            this.LocationButton.Click += new System.EventHandler(this.LocationButton_Click);
            // 
            // FindButton
            // 
            this.FindButton.Location = new System.Drawing.Point(794, 387);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(75, 23);
            this.FindButton.TabIndex = 1;
            this.FindButton.Text = "Поиск";
            this.FindButton.UseVisualStyleBackColor = true;
            this.FindButton.Visible = false;
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // FileTemplate
            // 
            this.FileTemplate.Location = new System.Drawing.Point(719, 176);
            this.FileTemplate.Name = "FileTemplate";
            this.FileTemplate.Size = new System.Drawing.Size(251, 20);
            this.FileTemplate.TabIndex = 3;
            this.FileTemplate.TextChanged += new System.EventHandler(this.FileTemplate_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(630, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(594, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Шаблон имени файла:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(594, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Стартовая директория:";
            // 
            // Symbols
            // 
            this.Symbols.Location = new System.Drawing.Point(719, 269);
            this.Symbols.Name = "Symbols";
            this.Symbols.Size = new System.Drawing.Size(251, 20);
            this.Symbols.TabIndex = 7;
            this.Symbols.TextChanged += new System.EventHandler(this.Symbols_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(594, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Символы в файле:";
            // 
            // DirectoryWay
            // 
            this.DirectoryWay.AutoSize = true;
            this.DirectoryWay.Location = new System.Drawing.Point(725, 89);
            this.DirectoryWay.Name = "DirectoryWay";
            this.DirectoryWay.Size = new System.Drawing.Size(0, 13);
            this.DirectoryWay.TabIndex = 10;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView);
            this.splitContainer1.Size = new System.Drawing.Size(433, 580);
            this.splitContainer1.SplitterDistance = 166;
            this.splitContainer1.TabIndex = 11;
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageList;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(166, 580);
            this.treeView.TabIndex = 0;
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "FolderImage");
            this.imageList.Images.SetKeyName(1, "FileImage");
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(263, 580);
            this.listView.SmallImageList = this.imageList;
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Имя файла";
            this.columnHeader1.Width = 72;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Тип";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Последнее изменение";
            this.columnHeader3.Width = 130;
            // 
            // ProcessedFiles
            // 
            this.ProcessedFiles.AutoSize = true;
            this.ProcessedFiles.Location = new System.Drawing.Point(1028, 89);
            this.ProcessedFiles.Name = "ProcessedFiles";
            this.ProcessedFiles.Size = new System.Drawing.Size(176, 13);
            this.ProcessedFiles.TabIndex = 12;
            this.ProcessedFiles.Text = "Количество обработаных файлов";
            // 
            // ProcessedFilesNumber
            // 
            this.ProcessedFilesNumber.AutoSize = true;
            this.ProcessedFilesNumber.Location = new System.Drawing.Point(1111, 120);
            this.ProcessedFilesNumber.Name = "ProcessedFilesNumber";
            this.ProcessedFilesNumber.Size = new System.Drawing.Size(13, 13);
            this.ProcessedFilesNumber.TabIndex = 13;
            this.ProcessedFilesNumber.Text = "0";
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Location = new System.Drawing.Point(1050, 27);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(119, 13);
            this.Time.TabIndex = 14;
            this.Time.Text = "Время обработки (мс)";
            // 
            // TimeMillisec
            // 
            this.TimeMillisec.AutoSize = true;
            this.TimeMillisec.Location = new System.Drawing.Point(1111, 49);
            this.TimeMillisec.Name = "TimeMillisec";
            this.TimeMillisec.Size = new System.Drawing.Size(13, 13);
            this.TimeMillisec.TabIndex = 15;
            this.TimeMillisec.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 580);
            this.Controls.Add(this.TimeMillisec);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.ProcessedFilesNumber);
            this.Controls.Add(this.ProcessedFiles);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.DirectoryWay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Symbols);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FileTemplate);
            this.Controls.Add(this.FindButton);
            this.Controls.Add(this.LocationButton);
            this.Name = "Form1";
            this.Text = "Поиск файлов";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button LocationButton;
		private System.Windows.Forms.Button FindButton;
		private System.Windows.Forms.TextBox FileTemplate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox Symbols;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label DirectoryWay;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ImageList imageList;
        private Label ProcessedFiles;
        private Label ProcessedFilesNumber;
        private Label Time;
        private Label TimeMillisec;
    }
}

