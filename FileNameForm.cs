using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CurricularAnalytics
{
    public partial class FileNameForm : Form
    {
        public FileNameForm(string path)
        {

            InitializeComponent();
            DirectoryInfo DI = new DirectoryInfo(path);
            foreach (FileInfo fi in DI.GetFiles())
            {
                int fileExtPos = fi.Name.LastIndexOf(".");
                if (fileExtPos >= 0)
                {
                    string filecore = fi.Name.Substring(0, fileExtPos);
                    this.listBoxFileList.Items.Add(filecore);
                }
            }
        }
        public string getName()
        {
            return (string)listBoxFileList.SelectedItem;
        }
    }
}
