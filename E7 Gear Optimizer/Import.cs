using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E7_Gear_Optimizer
{
    public partial class Import : Form
    {

        public bool result;
        public Data data;
        public string fileName;
        public bool web;
        public bool append = false;
        public int ItemsImported;
        public int HeroesImported;
        public bool folder;

        public Import()
        {
            InitializeComponent();
        }

        public Import(Data data, string fileName, bool web, bool folder)
        {
            InitializeComponent();
            this.data = data;
            this.fileName = fileName;
            this.web = web;
            this.folder = folder;
        }

        public Import(Data data, string fileName, bool web, bool append, bool folder)
        {
            InitializeComponent();
            this.data = data;
            this.fileName = fileName;
            this.web = web;
            this.append = append;
            this.folder = folder;
        }

        private async void Import_Shown(object sender, EventArgs e)
        {
            Progress<int> progress = new Progress<int>(x => progressBar1.Value = x);
            (bool, int, int) results;
            if (web)
            {
                results = await Task.Run(() => data.importFromWeb(fileName, progress, append));
            }
            else if (folder)
            {
                await Task.Run(() => data.importFromOCR(fileName, progress));
                results = await Task.Run(() => data.importFromWeb("OCR/endure.json", progress, append));
            }
            else
            {
                results = await Task.Run(() => data.importFromThis(fileName, progress, append));
            }
            result = results.Item1;
            HeroesImported = results.Item2;
            ItemsImported = results.Item3;
            label4.Text = HeroesImported.ToString();
            label5.Text = ItemsImported.ToString();
            this.Close();
        }
    }
}
