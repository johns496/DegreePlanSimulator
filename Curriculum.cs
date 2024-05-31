using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Globalization;
using static System.Console;

namespace CurricularAnalytics
{

    public class CurrRec
    {
        public int? CourseID { get; set; }
        public string? CourseName { get; set; }
        public string? Prefix { get; set; }
        public string? Number { get; set; }
        public string? Prerequisites { get; set; }
        public string? Corequisites { get; set; }
        public string? StrictCorequisites { get; set; }
        public int? CreditHours { get; set; }
        public string? Institution { get; set; }
        public string CanonicalName { get; set; }
        public int? NumPrereq { get; set; }
        public int? Pre1 { get; set; }
        public int? Pre2 { get; set; }
        public int? Pre3 { get; set; }
        public int? Pre4 { get; set; }
        public int? Pre5 { get; set; }
        public int? NumCoreq { get; set; }
        public int? Co1 { get; set; }
        public int? Co2 { get; set; }
        public int? Co3 { get; set; }
        public int? Co4 { get; set; }
        public int? Co5 { get; set; }
        public int? NumSCoreq { get; set; }
        public int? SCo1 { get; set; }
        public int? SCo2 { get; set; }
        public int? SCo3 { get; set; }
        public int? SCo4 { get; set; }
        public int? SCo5 { get; set; }

        public int[] prereq = null;
        public int[] coreq = null;
        public int[] scoreq = null;

        public void buildLists()
        {
            if (NumPrereq > 0)
            {
                prereq = new int[(int)NumPrereq];
                prereq[0] = (int)Pre1;
                if (NumPrereq > 1)
                    prereq[1] = (int)Pre2;
                if (NumPrereq > 2)
                    prereq[2] = (int)Pre3;
                if (NumPrereq > 3)
                    prereq[3] = (int)Pre4;
                if (NumPrereq > 4)
                    prereq[4] = (int)Pre5;

            }
            if (NumCoreq > 0)
            {
                coreq = new int[(int)NumCoreq];
                coreq[0] = (int)Co1;
                if (NumCoreq > 1)
                    coreq[1] = (int)Co2;
                if (NumCoreq > 2)
                    coreq[2] = (int)Co3;
                if (NumCoreq > 3)
                    coreq[3] = (int)Co4;
                if (NumCoreq > 4)
                    coreq[4] = (int)Co5;

            }
        }
        public string getString()
        {
            string str = CourseName;
            if (prereq != null)
            {
                for (int i = 0; i < prereq.Length; i++)
                {
                    str = str + "P" + prereq[i] + ",";
                }
            }
            if (coreq != null)
            {
                for (int i = 0; i < coreq.Length; i++)
                {
                    str = str + "C" + coreq[i] + ",";
                }
            }
            return str;
        }

    }
    public class Curriculum
    {
        public bool isPrereq = true;
        public bool isFailCalc2 = false;
        public bool isAllCredits = false;
        string prereqPath = @"ProcessedCA\Prereq\";
        string coreqPath = @"ProcessedCA\Coreq\";
        string failcalc2Path = @"ProcessedCA\FailCalc2\";
        string allcreditsPath = @"ProcessedCA\AllCredits\";
        string outprereqPath = @"Output\Prereq\";
        string outcoreqPath = @"Output\Coreq\";
        string outfailcalc2Path = @"Output\FailCalc2\";
        string outallcreditsPath = @"Output\AllCredits\";
        public string filename = null;
        //string filepath = @"C:\Users\johns\Dropbox\SoftwareTest\CurricularAnalytics\ProcessedCA\Prereq\";
        public static int maxCourses = 45;
        public CurrRec[] Courses = new CurrRec[maxCourses];
        public int totalcourses = 0;
        public int totalcoreqs = 0;

        public int getClassCount()
        {
            return totalcourses;
        }
        public int getTotalCredits()
        {
            int credits = 0;
            for (int i = 0; i < maxCourses; i++)
                if(Courses[i] != null)
                    credits += (int)Courses[i].CreditHours;
            return credits;
        }
        public string getPath()
        {
            if(isPrereq)
                return CAMain.rootpath+ prereqPath + filename + ".csv";
            if (isFailCalc2)
                return CAMain.rootpath + failcalc2Path + filename + ".csv";
            if (isAllCredits)
                return CAMain.rootpath + allcreditsPath + filename + ".csv";
            return CAMain.rootpath + coreqPath + filename + ".csv";
        }

        public string getOutpath(string filepostfix)
        {
            if (isPrereq)
                return CAMain.rootpath + outprereqPath +filename+ filepostfix;
            if (isFailCalc2)
                return CAMain.rootpath + outfailcalc2Path + filename + filepostfix;
            return CAMain.rootpath + outcoreqPath +filename+ filepostfix;
        }

        public Curriculum(string infile, bool isprereq=true, bool isfailcalc2=false)
        {
            filename = infile;
            isPrereq = isprereq;
            isFailCalc2= isfailcalc2;
        }

        string complexRptStr = null;

        public string ComplexityReport()
        {
            complexRptStr = "Complexity Report\n";
            StreamWriter outputFile = new StreamWriter(getOutpath("-stats.txt"));
            ComputeComplexityVerbose();
            outputFile.WriteLine(complexRptStr);
            outputFile.Close();
            return complexRptStr;
        }

        

        // Compute Complexity
        public int complexity = 0;
        public int blocking = 0;
        public int longestpath = 0;

        public void ComputeComplexity()
        {
            int curblock = 0;
            int curpath = 0;
            for (int i = 0; i < maxCourses; i++)
            {
                if (Courses[i] != null)
                {
                    curDescendants = new List<int>();
                    computeDescendantsVerbose((int)Courses[i].CourseID);
                    curblock = curDescendants.Count - 1; // Node is counted as descedent
                    blocking += curblock;
                    curpath = computeLongestPath((int)Courses[i].CourseID);
                    longestpath += curpath;
                    complexity += curblock + curpath;


                }
            }
        }

        // Alternate handling of corequisites
        public int complexityCo = 0;
        public int longestpathCo = 0;

        public static int maxPaths = 12;
        public int[] pathcount=new int[maxPaths];
        public int[] pathcountCo = new int[maxPaths];

        public string ComputeComplexityVerbose(bool genreport=false)
        {
            int curblock = 0;
            int curpath = 0;
            int curpathCo = 0;
            int coursecount = 0;
            for(int i=0; i<maxPaths; i++)
            {
                pathcount[i] = 0;
                pathcountCo[i] = 0;
            }
            for (int i = 0; i < maxCourses; i++)
            {
                if (Courses[i] != null)
                {
                    coursecount++;
                    complexRptStr += "Course " + i + "\n";
                    curDescendants = new List<int>();
                    computeDescendantsVerbose((int)Courses[i].CourseID);
                    curblock = curDescendants.Count - 1; // Node is counted as descedent
                    complexRptStr += "    Descendents " + curblock + "\n";
                    blocking += curblock;
                    curpath = computeLongestPathVerbose((int)Courses[i].CourseID);
                    string verbRptSave = verbReport;
                    curpathCo = computeLongestPathVerbose((int)Courses[i].CourseID, true);
                    pathcount[curpath] = pathcount[curpath] + 1;
                    pathcountCo[curpathCo] = pathcountCo[curpathCo] + 1;
                    longestpath += curpath;
                    complexity += curblock + curpath;
                    complexityCo += curblock + curpathCo;
                    complexRptStr += "    Descendents ";
                    for (int j=0; j < curDescendants.Count; j++)
                    {
                        complexRptStr += curDescendants[j] + " '";
                    }
                    complexRptStr += "\n";
                    complexRptStr += verbRptSave;

                }
            }
            complexRptStr += "    Total Complexity " + complexity + "\n";
            if(!genreport)
                return "Complexity" + complexity + "\n"+"***************************************************\n\n";
            if (genreport)
            {
                string str = filename + ',' + coursecount + ',' + complexity + ',' + blocking + ',' + longestpath + ','
                    + (double)complexity / (double)coursecount + ',' + complexityCo+','+(double)complexityCo / (double)coursecount;
                for(int i = 0; i < maxPaths; i++)
                {
                    str = str + ","+pathcount[i];
                }
                for (int i = 0; i < maxPaths; i++)
                {
                    str = str + "," + pathcountCo[i];
                }
                str =str+ "\n";
                return str;
            }
            return "No Report\n";
        }

        public int computeLongestPath(int par)
        {
            int longestChild = computeLongestChildren(par);
            int longestAncenstor = computeLongestAncenstor(par);
            return 1 + longestAncenstor + longestChild;
        }

        string verbReport = "Verbose Children\n";

        public int computeLongestPathVerbose(int par, bool altCoReq=false)
        {
            verbReport="Longest Path Node "+ par+ "\n";

            int longestChild = computeLongestChildrenVerbose(par, altCoReq);
            int longestAncenstor = computeLongestAncenstorVerbose(par, altCoReq);
            if(!altCoReq)
                complexRptStr += "    Longest Path " + (1 + longestAncenstor + longestChild) + "\n";
            else
                complexRptStr += "    Longest Path Co" + (1 + longestAncenstor + longestChild) + "\n";
            return 1 + longestAncenstor + longestChild;
        }

        public int computeLongestChildren(int par)
        {
            int longest = 0;
            List<int> children = ComputePrereqFor(par);
            if (children.Count == 0) return 0;
            foreach (int child in children)
            {
                int curlong = 1 + computeLongestChildren(child);
                if (curlong > longest) longest = curlong;
            }
            return longest;
        }

        public int computeLongestChildrenVerbose(int par, bool altCoReq=false)
        {
            int longest = 0;
            List<int> children = ComputePrereqFor(par, true, false); // handle pre
            List<int> childrenCo = ComputePrereqFor(par, false, true); // handle pre
            if (children.Count == 0 && childrenCo.Count==0) return 0;
            foreach (int child in children)
            {
                int curlong = 1 + computeLongestChildrenVerbose(child, altCoReq);
                if (curlong > longest) { 
                    longest = curlong;
                    verbReport += "Longest Child Pre par=" + par + " Child=" + child + " longest=" + longest + "\n"; 
                }
            }
            foreach (int child in childrenCo)
            {
                int curlong = 1 + computeLongestChildrenVerbose(child, altCoReq);
                if (altCoReq)
                {
                    curlong = computeLongestChildrenVerbose(child, altCoReq);
                }
                if (curlong > longest)
                {
                    longest = curlong;
                    verbReport += "Longest Child Co par=" + par + " Child=" + child + " longest=" + longest + "\n";
                }
            }
            return longest;
        }

        public int computeLongestAncenstor(int par)
        {
            int longest = 0;
            if ((int)Courses[par].NumPrereq == 0 && (int)Courses[par].NumCoreq == 0) return 0;
            for (int i = 0; i < Courses[par].NumPrereq; i++)
            {
                int curlong = 1 + computeLongestAncenstor(Courses[par].prereq[i]);
                if (curlong > longest) longest = curlong;
            }
            for (int i = 0; i < Courses[par].NumCoreq; i++)
            {
                int curlong = 1 + computeLongestAncenstor(Courses[par].coreq[i]);
                if (curlong > longest) longest = curlong;
            }
            return longest;
        }

        public int computeLongestAncenstorVerbose(int par, bool altCoReq = false)
        {
            int longest = 0;
            if ((int)Courses[par].NumPrereq == 0 && (int)Courses[par].NumCoreq == 0) return 0;
            for (int i = 0; i < Courses[par].NumPrereq; i++)
            {
                int curlong = 1 + computeLongestAncenstorVerbose(Courses[par].prereq[i], altCoReq);
                if (curlong > longest)
                {
                    longest = curlong;
                    verbReport += "Longest Child Co par=" + par + " Child=" + Courses[par].prereq[i] + " longest=" + longest + "\n";
                }
            }
            for (int i = 0; i < Courses[par].NumCoreq; i++)
            {
                int curlong = 1 + computeLongestAncenstorVerbose(Courses[par].coreq[i], altCoReq);
                if (altCoReq)
                {
                    curlong = computeLongestAncenstorVerbose(Courses[par].coreq[i], altCoReq);
                }
                if (curlong > longest)
                {
                    longest = curlong;
                    verbReport += "Longest Child Co par=" + par + " Child=" + Courses[par].coreq[i] + " longest=" + longest + "\n";
                }
            }
            return longest;
        }

        public int computeDescendants(int par)
        {
            for (int i = 0; i < curDescendants.Count; i++)
            {
                if (curDescendants[i] == par) return 0; // already done
            }
            curDescendants.Add(par);
            List<int> immediateDescendants = ComputePrereqFor(par);
            int count = immediateDescendants.Count;
            if (count == 0) return 0;
            for(int i = 0; i < immediateDescendants.Count; i++)
                count+=computeDescendants(immediateDescendants[i]);
            return count;
        }

        // Keep track so do not double count
        List<int> curDescendants=new List<int>();
        public int computeDescendantsVerbose(int par)
        {
            // Check to see if this node already traversed
            for(int i = 0; i < curDescendants.Count; i++)
            {
                if (curDescendants[i] == par) return 0; // already done
            }
            curDescendants.Add(par);
            List<int> immediateDescendants = ComputePrereqFor(par);
            int count = immediateDescendants.Count;
            if (count == 0) return 0;
            for (int i = 0; i < immediateDescendants.Count; i++)
                count += computeDescendantsVerbose(immediateDescendants[i]);
            return count;
        }

        // Treat Prereq and Coreq the same
        public List<int> ComputePrereqFor(int cid, bool prereqonly=false, bool coreqonly=false)
        {
            List<int> plist = new List<int>();
            for (int i = 0; i < maxCourses; i++)
            {
                if (Courses[i] == null) continue;
                if (!coreqonly)
                {
                    if (Courses[i].NumPrereq > 0)
                    {
                        for (int j = 0; j < Courses[i].NumPrereq; j++)
                        {
                            if (Courses[i].prereq[j] == cid)
                                plist.Add(i);
                        }
                    }
                }
                if (!prereqonly)
                {
                    if (Courses[i].NumCoreq > 0)
                    {
                        for (int j = 0; j < Courses[i].NumCoreq; j++)
                        {
                            if (Courses[i].coreq[j] == cid)
                                plist.Add(i);
                        }
                    }
                }
                


            }
            return plist;
        }

        public string load()
        {
            
            string str = "CA";
            string fullname = getPath();
            using var reader = new StreamReader(fullname);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            // read CSV file
            var records = csv.GetRecords<CurrRec>();
            foreach (CurrRec r in records)
            {
                Courses[(int)r.CourseID] = r;
                totalcourses++;
                totalcoreqs += (int)r.NumCoreq;
            }
            for (int i = 0; i < maxCourses; i++)
            {
                if (Courses[i] != null)
                {
                    Courses[i].buildLists();
                    str = str + Courses[i].getString() + "\n";

                }
            }


            return str;

        }
        /*
        public string testload()
        {
            string str = "CA";
            string fullname = filepath + filename + ".csv";
            WriteLine(fullname);
            using var reader = new StreamReader(fullname);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            // read CSV file
            var records = csv.GetRecords<dynamic>();


            // output
            foreach (var r in records)
            {
                str=str+r.CourseName+"\n";
            }
            return str;
        }
        */
        public int getCreditHours(int[] cls)
        {
            int hours = 0;
            if (cls == null) return 0;
            for(int i = 0; i < cls.Length; i++)
            {
                hours = hours + (int)Courses[cls[i]].CreditHours;
            }
            return hours;
        }
        public bool isComplete(UsedClasses UC)
        {
            if (UC == null) return false;
            if(UC.totalused == totalcourses) return true;
            return false;
        }
    }
    public class UsedClasses
    {
        public bool[] used = new bool[Curriculum.maxCourses];
        public int totalused = 0;
        public UsedClasses()
        {
            for (int i = 0; i < Curriculum.maxCourses; i++)
            {
                used[i] = false;
            }
        }
        public void computeUsed(SemStack[] stack)
        {
            for (int i = 0; i < stack.Length; i++)
            {
                if (stack[i]!=null&& !stack[i].Empty()) {
                    SemPlan plan = stack[i].Top();
                    if (plan != null && plan.Classes != null)
                    {
                        for (int j = 0; j < plan.Classes.Length; j++)
                        {
                            used[plan.Classes[j]] = true;
                            totalused++;
                        }
                    }
                }
            }
        }
    }

    public class AvailableClasses
    {
        public int[] avail = new int[Curriculum.maxCourses];
        public int totalavail = -1;
        public AvailableClasses(Curriculum Curr, UsedClasses UC)
        {
            for (int i = 0; i < Curriculum.maxCourses; i++)
            {
                if (Curr.Courses[i] != null && !UC.used[i])
                {
                    bool prereqmet = true;
                    for (int j = 0; j < Curr.Courses[i].NumPrereq; j++)
                    {
                        if (!UC.used[Curr.Courses[i].prereq[j]]) prereqmet = false;
                    }
                    if (prereqmet)
                    {
                        totalavail++;
                        avail[totalavail] = i;
                    }


                }
            }
            // Copy to a reasonable size array
            if (totalavail < 0)
            {
                avail = null;
                return;
            }
            int[] outavail = new int[totalavail + 1];
            for(int i = 0; i<=totalavail; i++)
            {
                outavail[i] = avail[i];
            }
            avail = outavail;
        }
    }
    public class AvailableSems {
        public int totalsems = -1;
        public SemPlan[] availsems = null;
        public AvailableSems(Curriculum Cur, AvailableClasses AC, int minhours, int maxhours, UsedClasses UC)
        {
            int[][] comb = computeSemCombinations(AC.avail);
            availsems = new SemPlan[comb.Length];
            for (int i = 0; i < comb.Length; i++)
            {
                int credits = Cur.getCreditHours(comb[i]);
                if (credits >= minhours && credits <= maxhours)
                {
                    availsems[i] = new SemPlan(comb[i]);
                    totalsems++;
                }
                else
                {
                    availsems[i] = null;
                }
            }
            if (Cur.totalcoreqs == 0) return;
            // Check Coreqs
            
                for(int j=0; j<availsems.Length; j++)
                {
                    if (availsems[j] == null || availsems[j].Classes==null) continue;
                    for(int k=0; k<availsems[j].Classes.Length; k++)
                    {
                        int numco = (int)Cur.Courses[availsems[j].Classes[k]].NumCoreq;
                        if (numco == 0) continue;
                        
                    bool coreqSatisfied=true;
                    for (int l = 0; l < numco; l++)
                    {

                        int coreq = Cur.Courses[availsems[j].Classes[k]].coreq[l];
                        // Check if co-req already taken
                        if (UC.used[coreq])
                        {
                            continue; // coreq satisfied

                        }
                        // See if co-req in in the current semester
                        bool found = false;
                        for (int m = 0; m < availsems[j].Classes.Length; m++)
                        {
                            if (availsems[j].Classes[m] == coreq)
                            {
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            coreqSatisfied = false;
                            break;
                        }
                    }
                    if (!coreqSatisfied)
                        {
                            availsems[j] = null;
                            totalsems--;
                            break;
                        }
                        

                    }
                }
                
        }
        public int [][] computeSemCombinations(int[] cls)
        {
            int total = -1;
            if (cls == null) return null;
            int len = (int) Math.Pow(2, cls.Length)-1; // Do not use the empty set
            int[][] subsets = new int[len][]; // Make jaggest array
            // Add the first element alone
            total++;
            subsets[total] = new int[1];
            subsets[total][0] = cls[0];
            if (cls.Length == 1) return subsets;
            int[] cldcls = new int[cls.Length-1];
            for(int i = 1; i < cls.Length; i++)
            {
                cldcls[i-1] = cls[i];
            }
            int[][] cldcmb = computeSemCombinations(cldcls);
            for(int i = 0; i < cldcmb.Length; i++)
            {
                total++;
                subsets[total] = cldcmb[i];
            }
            // Append first element
            for (int i = 0; i < cldcmb.Length; i++)
            {
                total++;
                subsets[total] = new int[cldcmb[i].Length+1];
                subsets[total][0] = cls[0];
                for(int j = 0; j < cldcmb[i].Length; j++)
                {
                    subsets[total][j + 1] = cldcmb[i][j];
                }
            }
            return subsets;

        }
    }

}
