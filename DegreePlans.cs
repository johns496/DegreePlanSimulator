using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace CurricularAnalytics
{
    
    // Single Semester
    public class SemPlan
    {
        public int[] Classes = null;
        public SemPlan(int[] incls)
        {
            if (incls == null) return;
            Classes = (int[])incls.Clone();
        }
        public string getReport()
        {
            if (Classes == null || Classes.Length==0) return "Empty";
            string str = "";
            for (int i = 0; i < Classes.Length; i++)
            {
                str = str + Classes[i] + ";";
            }
            return str;
        }
        public int getCreditHours(Curriculum Curr)
        {
            return Curr.getCreditHours(Classes);
        }
        public int getClassCount(Curriculum Curr)
        {
            if (Classes == null) return 0;
            return Classes.Length;
        }
    }
    public class DegreePlan
    {
        public SemPlan[] dp = null;
        public DegreePlan()
        {
            dp = new SemPlan[DegreePlans.maxsems];
        }
        public void AddPlan(SemStack[] sems)
        {
            dp=new SemPlan[sems.Length];
            for(int i=0; i<sems.Length; i++)
            {
                if (sems[i] == null) continue;
                dp[i] = sems[i].Top();

            }
        }
        public string getReport()
        {
            string str = "";
            for(int i=0; i<dp.Length; i++)
            {
                if(dp[i] != null)
                {
                    str = str + "Semester " + i +" - "+ dp[i].getReport();
                    str = str + " | ";
                }
            }
            return str;
        }
    }
    public class SemStack
    {
        public static int stackmax = 50000;
        public SemPlan[] SS = new SemPlan[stackmax];
        public int stackcounter=-1;
        public SemStack()
        {

        }
        public SemPlan Top()
        {
            if (stackcounter <0) return null;
            return SS[stackcounter];

        }
        public void Push(SemPlan tp)
        {
            stackcounter++;
            SS[stackcounter] = tp;
        }
        public void Pop() {
            if (stackcounter < 0)
            {
                string hello = null;
            }    
            stackcounter--;
        }
        public bool Empty()
        {
            return stackcounter < 0;
        }
    }
    public class DegreePlanStats
    {
        Curriculum Curr = null;
        public static int maxsems = 8;
        public static int maxsquare = 50000;
        int[] TotalPlans = new int[maxsems];
        ulong[] TotalPlansSquared = new ulong[maxsems];
        int[] TotalSquare = new int[maxsquare];
        ulong totalcoursesquared = 0;
        ulong totalcreditsquared = 0;
        ulong totaldegrees = 0;
        

        public DegreePlanStats(Curriculum C)
        {
            Curr = C;
            for(int i = 0; i < TotalPlans.Length; i++)
                TotalPlans[i] = 0;
            for (int i = 0; i < TotalPlansSquared.Length; i++)
                TotalPlansSquared[i] = 0;
            for (int i=0; i < TotalSquare.Length; i++)
                TotalSquare[i] = 0;
        }
        public void addPlan(DegreePlan dp)
        {
            if (dp == null) return;
            totaldegrees++;
            int len = 0;
            int creditSquared = 0;
            int coursesSquared = 0;
            int CH = 0;
            int CR = 0;
            for (int i = 0; i < dp.dp.Length; i++)
            {
                //Length of Plan 
                if (dp.dp[i] == null) continue;
                len++;
                CH = dp.dp[i].getCreditHours(Curr);
                creditSquared += CH*CH;
                CR = dp.dp[i].getClassCount(Curr);
                coursesSquared += CR*CR;
            }
            TotalPlans[len-1]++;
            TotalPlansSquared[len - 1]+= (ulong)coursesSquared;
            totalcoursesquared += (ulong)coursesSquared;
            totalcreditsquared += (ulong)creditSquared;
            TotalSquare[creditSquared]++;
        }
        public void writeStats(string duration)
        {
            Curr.ComputeComplexity();
            StreamWriter outputFile = new StreamWriter(Curr.getOutpath("-genstats.csv"));
            string header = "Name, Duration, Classes, Credits, DegreeCount, SemPlan4, SemPlan5,"+
                " Semplan6, SemPlan7, SemPlan8, TotalCourseSquared, TotalCreditSquared, AveCourseSquare, AveCredSquare,"+
                "Sem5Square, Sem6Square, Sem7Square,Sem8Square,"+
                "Blocking, LongestPath,Complexity";
            double Sem5Square = 0.0;
            double Sem6Square = 0.0;
            double Sem7Square = 0.0;
            double Sem8Square = 0.0;
            if (TotalPlans[4] > 0)
            {
                Sem5Square=Math.Sqrt((double)TotalPlansSquared[4]/(double)TotalPlans[4]);
            }
            if (TotalPlans[5] > 0)
            {
                Sem6Square = Math.Sqrt((double)TotalPlansSquared[5] / (double)TotalPlans[5]);
            }
            if (TotalPlans[6] > 0)
            {
                Sem7Square = Math.Sqrt((double)TotalPlansSquared[6] / (double)TotalPlans[6]);
            }
            if (TotalPlans[7] > 0)
            {
                Sem8Square = Math.Sqrt((double)TotalPlansSquared[7] / (double)TotalPlans[7]);
            }
            outputFile.WriteLine(header);
            string str = Curr.filename + ","+duration+"," + Curr.getClassCount() + "," + Curr.getTotalCredits() + "," + totaldegrees + "," + TotalPlans[3] + ","
                + TotalPlans[4] + "," + TotalPlans[5] + "," + TotalPlans[6] + "," + TotalPlans[7] + "," + 
                totalcoursesquared + "," + totalcreditsquared+","+ 
                Math.Sqrt((double)totalcoursesquared/(double)totaldegrees) + "," + Math.Sqrt((double)totalcreditsquared/(double)totaldegrees)+","+
                Sem5Square + "," + Sem6Square + "," + Sem7Square + "," + Sem8Square + "," + 
                Curr.blocking+","+Curr.longestpath+","+Curr.complexity;
            outputFile.WriteLine(str); 
            outputFile.Close();

            // Write Specturm of Course Squared
            StreamWriter credoutputFile = new StreamWriter(Curr.getOutpath("-credsquare.csv"));
            header = "CreditSquare, Count";
            credoutputFile.WriteLine(header);
            for(int i = 0; i <  TotalSquare.Length ; i++)
            {
                if(TotalSquare[i] != 0)
                    credoutputFile.WriteLine(""+i+","+TotalSquare[i]);
            }
          
            credoutputFile.Close();
        }
    }

    
    public class DegreePlans
    {
        public static int maxsems = 8;
        public static int minhours = 1;
        public static int maxhours = 15;

        public static int maxdegrees = 10000000;

        public DegreePlan[] degrees = new DegreePlan[maxdegrees];
        public long degreecount = -1;
       
        public int stacktop = -1;
        public SemStack[] semstack = new SemStack[maxsems];

        public DegreePlanStats Stats = null;

        public Stopwatch watch = null;

        public void Push(AvailableSems AS)
        {
            stacktop++;
            semstack[stacktop] = new SemStack();
            for (int i = 0; i < AS.availsems.Length; i++) {
                if(AS.availsems[i]!=null)
                    semstack[stacktop].Push(AS.availsems[i]);
            }
        }
        public void Pop()
        {
            if (stacktop < 0) return;
            if (semstack[stacktop].stackcounter == -1)
            {
                string hello = null;
            }
            semstack[stacktop].Pop();
            if (semstack[stacktop].stackcounter >= 0) return;
            // Pop until a non empty stack is found
            stacktop--;
            while(stacktop>=0 && semstack[stacktop].stackcounter == 0)
            {
                semstack[stacktop].Pop();
                stacktop--;
            }
            if (stacktop < 0) return;
            semstack[stacktop].Pop();
        }

        public Curriculum Curr = null;
        public CAMain MainWindow = null;
        public DegreePlans(Curriculum inCur, CAMain par)
        {
            Curr = inCur;
            MainWindow = par;
            Stats = new DegreePlanStats(Curr);
        }
        public bool storeDegrees=false;
        public int fractionStored = 1;
        public int outputDegreeCount = 0;
        public void AddDegreePlan()
        {
            degreecount++;
            DegreePlan dp  = new DegreePlan();
            dp.AddPlan(semstack);
            Stats.addPlan(dp);
            if (storeDegrees)
            {
                if (storeDegrees && (degreecount % fractionStored  == 0))
                {
                    degrees[outputDegreeCount] = dp;
                    outputDegreeCount++;
                }
            }
            // Add code to read degree plan off stack
        }
        public bool verbose = false;
        public string DegreePlanReport()
        {
            string str = "Degree Plan Report\n";
            str = str + "Degree Count " + (degreecount+1) + "\n";
            if (!verbose) return str;
            for(int i = 0; i <outputDegreeCount; i++)
            {
                str = str + "Degree Plan " + i + " - ";
                str = str + degrees[i].getReport();
                str =str + "\n";
            }
            return str+"\n";

        }
        public void WriteDegreePlans(Curriculum CU)
        {
            StreamWriter outputFile = new StreamWriter(CU.getOutpath("-degreeplans.txt"));
            for (int i = 0; i <outputDegreeCount; i++)
            {
                
                outputFile.WriteLine( degrees[i].getReport());
             
            }
            outputFile.Close();
            

        }
        


        public string getStackString()
        {
            string str = "Stack ";
            for (int i = 0; i <= stacktop; i++)
                str = str + semstack[i].stackcounter + "|";
            return str;
        }
        public string EnumerateDP()
        {
            watch = new Stopwatch();
            watch.Start();
            string str = "Start";
            ulong itercount = 0;
            UsedClasses UC = new UsedClasses();
            AvailableClasses AC = new AvailableClasses(Curr, UC);
            AvailableSems AS = new AvailableSems(Curr, AC, minhours, maxhours, UC);
            Push(AS);
            while (stacktop >= 0)
            {
                itercount++;
                if ((itercount % 1000000)==0) 
                {
                    System.Diagnostics.Debug.WriteLine("Iteration " + itercount+" DC: "+degreecount + "\n");
                    System.Diagnostics.Debug.WriteLine(getStackString());
                }
                UC = new UsedClasses();
                UC.computeUsed(semstack);
                if (Curr.isComplete(UC))
                {
                    // Degree Complete
                    AddDegreePlan();
                    
                    Pop();
                    continue;
                }
                // See if we are at 8 semesters
                if (stacktop == (maxsems - 1))
                {
                    Pop();
                    continue;
                }
                // Add another semester, unless new top is also complete
                UC = new UsedClasses();
                UC.computeUsed(semstack);
                if (!Curr.isComplete(UC))
                {
                    AC = new AvailableClasses(Curr, UC);
                    AS = new AvailableSems(Curr, AC, minhours, maxhours,UC);
                    if (AS.totalsems >= 0)
                        Push(AS);
                    else
                        Pop();
                }

            }
            watch.Stop();
            WriteDegreePlans(Curr);
            Stats.writeStats(watch.ElapsedMilliseconds.ToString());
            return str;
        }
    }
}
