namespace CurricularAnalytics
{
    public partial class CAMain : Form
    {
        public static string rootpath = @"C:\Users\johns\Dropbox\SoftwareTest\CurricularAnalytics\";
        public CAMain()
        {
            InitializeComponent();
        }

        public Curriculum CU = null;
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            CU = new Curriculum("Alabama");
            //CU = new Curriculum("test2");
            richTextBoxOutput.Text = CU.load();
        }
        private void runDegreePlans()
        {
            DegreePlans DP = new DegreePlans(CU, this);
            DP.EnumerateDP();
            string str = DP.DegreePlanReport();
            richTextBoxOutput.Text = str;
        }
        private void buttonDegreePlans_Click(object sender, EventArgs e)
        {
            runDegreePlans();
            
            
        }
        public void setCount(int i)
        {
            textBoxDegreePlans.Text = i.ToString();
        }

        private void buttonPrereq_Click(object sender, EventArgs e)
        {
            string filepath = @"C:\Users\johns\Dropbox\SoftwareTest\CurricularAnalytics\ProcessedCA\Prereq\";
            FileNameForm DI = new FileNameForm(filepath);
            DI.ShowDialog();
            string name = DI.getName();
            CU = new Curriculum(name);
            //CU = new Curriculum("test2");
            string str = CU.load();
            richTextBoxOutput.Text = str;
            DegreePlans DP = new DegreePlans(CU, this);
            DP.EnumerateDP();
            str = str+ DP.DegreePlanReport();
            richTextBoxOutput.Text = str;
        }

        private void buttonCoreq_Click(object sender, EventArgs e)
        {
            string filepath = @"C:\Users\johns\Dropbox\SoftwareTest\CurricularAnalytics\ProcessedCA\Coreq\";
            FileNameForm DI = new FileNameForm(filepath);
            DI.ShowDialog();
            string name = DI.getName();
            CU = new Curriculum(name, false);
            //CU = new Curriculum("test2");
            string str = CU.load();
            richTextBoxOutput.Text = str;
            DegreePlans DP = new DegreePlans(CU, this);
            DP.EnumerateDP();
            str = str + DP.DegreePlanReport();
            richTextBoxOutput.Text = str;
        }

        private void buttonFailCalc2_Click(object sender, EventArgs e)
        {
            string filepath = @"C:\Users\johns\Dropbox\SoftwareTest\CurricularAnalytics\ProcessedCA\FailCalc2\";
            FileNameForm DI = new FileNameForm(filepath);
            DI.ShowDialog();
            string name = DI.getName();
            CU = new Curriculum(name, false, true);
            //CU = new Curriculum("test2");
            string str = CU.load();
            richTextBoxOutput.Text = str;
            DegreePlans DP = new DegreePlans(CU, this);
            DP.EnumerateDP();
            str = str + DP.DegreePlanReport();
            richTextBoxOutput.Text = str;
        }

        private void buttonPrereqStats_Click(object sender, EventArgs e)
        {
            string filepath = @"C:\Users\johns\Dropbox\SoftwareTest\CurricularAnalytics\ProcessedCA\Prereq\";
            FileNameForm DI = new FileNameForm(filepath);
            DI.ShowDialog();
            string name = DI.getName();
            CU = new Curriculum(name);
            //CU = new Curriculum("test2");
            string str = CU.load();
            str += CU.ComplexityReport();
            richTextBoxOutput.Text = str;
        }

        private void buttonCoreqStats_Click(object sender, EventArgs e)
        {
            string filepath = @"C:\Users\johns\Dropbox\SoftwareTest\CurricularAnalytics\ProcessedCA\Coreq\";
            FileNameForm DI = new FileNameForm(filepath);
            DI.ShowDialog();
            string name = DI.getName();
            CU = new Curriculum(name, false);
            //CU = new Curriculum("test2");
            string str = CU.load();
            str += CU.ComplexityReport();
            richTextBoxOutput.Text = str;
        }

        private void buttonGenReport_Click(object sender, EventArgs e)
        {
            string str = "name, courses, complexity, blocking, longestpath, specificcomplexity, complexityCo, specificcomplexityCo";
            for(int i=0; i<Curriculum.maxPaths; i++)
            {
                str = str + ", path" + i;
            }
            for (int i = 0; i < Curriculum.maxPaths; i++)
            {
                str = str + ", pathCo" + i;
            }
            str = str + "\n";
            string filepath = @"C:\Users\johns\Dropbox\SoftwareTest\CurricularAnalytics\ProcessedCA\Prereq\";
            string outfilepath = @"C:\Users\johns\Dropbox\SoftwareTest\CurricularAnalytics\Output\genstats.csv";
            DirectoryInfo DI = new DirectoryInfo(filepath);
            foreach (FileInfo fi in DI.GetFiles())
            {
                int fileExtPos = fi.Name.LastIndexOf(".");
                if (fileExtPos >= 0)
                {
                    string filecore = fi.Name.Substring(0, fileExtPos);
                    CU = new Curriculum(filecore);
                  
                    CU.load();
                    str += CU.ComputeComplexityVerbose(true);
                }
            }

            string cofilepath = @"C:\Users\johns\Dropbox\SoftwareTest\CurricularAnalytics\ProcessedCA\Coreq\";
           
            DI = new DirectoryInfo(cofilepath);
            foreach (FileInfo fi in DI.GetFiles())
            {
                int fileExtPos = fi.Name.LastIndexOf(".");
                if (fileExtPos >= 0)
                {
                    string filecore = fi.Name.Substring(0, fileExtPos);
                    CU = new Curriculum(filecore, false);

                    CU.load();
                    str += CU.ComputeComplexityVerbose(true);
                }
            }

            StreamWriter outputFile = new StreamWriter(outfilepath);
            
            outputFile.WriteLine(str);
            outputFile.Close();

            richTextBoxOutput.Text = str;
        }

        private void buttonGenReportFull_Click(object sender, EventArgs e)
        {
            string str = "name, courses, complexity, blocking, longestpath, specificcomplexity, complexityCo, specificcomplexityCo";
            for (int i = 0; i < Curriculum.maxPaths; i++)
            {
                str = str + ", path" + i;
            }
            for (int i = 0; i < Curriculum.maxPaths; i++)
            {
                str = str + ", pathCo" + i;
            }
            str = str + "\n";
            string filepath = @"C:\Users\johns\Dropbox\SoftwareTest\CurricularAnalytics\ProcessedCA\AllCredits\";
            string outfilepath = @"C:\Users\johns\Dropbox\SoftwareTest\CurricularAnalytics\Output\genstats-full.csv";
            DirectoryInfo DI = new DirectoryInfo(filepath);
            foreach (FileInfo fi in DI.GetFiles())
            {
                int fileExtPos = fi.Name.LastIndexOf(".");
                if (fileExtPos >= 0)
                {
                    string filecore = fi.Name.Substring(0, fileExtPos);
                    CU = new Curriculum(filecore);
                    CU.isAllCredits = true;
                    CU.isPrereq = false;
                    CU.load();
                    str += CU.ComputeComplexityVerbose(true);
                }
            }

            

            StreamWriter outputFile = new StreamWriter(outfilepath);

            outputFile.WriteLine(str);
            outputFile.Close();

            richTextBoxOutput.Text = str;
        }
    }
}