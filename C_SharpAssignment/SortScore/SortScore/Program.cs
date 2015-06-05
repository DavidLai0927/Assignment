using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortScore
{
    //定義學生類別
    //成員:學號,名子,5科分數,平均
    //方法:算出平均

    public class Student
    {
        public Student(string id, string name, int chinese, int english, int math, int physic, int chemistry)
        {
            this.id = id;
            this.name = name;
            this.chinese = chinese;
            this.english = english;
            this.math = math;
            this.physic = physic;
            this.chemistry = chemistry;
            this.avg = Average(chinese, english, math, physic, chemistry);
        }
        public string id;
        public string name;
        public int chinese, english, math, physic, chemistry;
        public float avg;
        public float Average(params int[] grades)
        {   
            float sum = 0,avg;
            foreach(int i in grades) 
            {
                sum+=i;
            }
            avg = (float)(sum / grades.Length);
            return avg;
        }
    }


    //自定義比較方法
    //當初未考慮分數相等 除錯卡了些時間
    //由caller提供whichsort來決定SORT方式

    public class myComparer : IComparer<Student>
    {
        int whichSort;
        public myComparer(int w)
        {
            this.whichSort = w;
        }
        enum Grade : int { chinese , english, math, physic, chemistry, avg };
        public int Compare(Student x, Student y)
        {
            if (x == null & y == null)
                return 0;
            else if (x == null) 
                return -1;
            else
            {
                if (y == null)
                {
                    return 1;
                }
                else
                {
                    switch (whichSort)
                    {
                        case (int)Grade.chinese:
                            return y.chinese.CompareTo(x.chinese);
                        case (int)Grade.english:
                            return y.english.CompareTo(x.english);
                        case (int)Grade.math:
                            return y.math.CompareTo(x.math);
                        case (int)Grade.physic:
                            return y.physic.CompareTo(x.physic);
                        case (int)Grade.chemistry:
                            return y.chemistry.CompareTo(x.chemistry);
                        case (int)Grade.avg:
                            return y.avg.CompareTo(x.avg);
                        default:
                            return y.avg.CompareTo(x.avg);
                    }
                }
            }
        }


    
    }



    class Program
    {

        //TIME Read&Write等
        static System.Diagnostics.Stopwatch stw = new System.Diagnostics.Stopwatch();
        static string inputFile;
        static string outputPath = "";
        static StreamReader sr;
        static StreamWriter sw;
        static List<Student> studentList;
        enum Grade : int { chinese, english, math, physic, chemistry, avg };
        static string[] outfile = { "國文.txt", "英文.txt", "數學.txt", "物理.txt", "化學.txt", "平均.txt" };


        //讀檔方法 只確認檔案沒問題可讀 建立輸出路徑outputPath

        static void ReadFile()
        {
            Console.WriteLine("Input file path Or draw file to Console");
            inputFile = Console.ReadLine();
            char[] delimiter = { '\\' };
            string[] field = inputFile.Split(delimiter);
            for (int i = 0; i < field.Length - 1; i++)
            {
                outputPath += field[i] + '\\';
            }
            //Console.WriteLine(outputPath);
            try
            {
                using (sr = new StreamReader(inputFile, System.Text.Encoding.GetEncoding("Unicode")))
                {
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read");
                Console.WriteLine(e.Message);
                Console.ReadLine(); // Pause
                System.Environment.Exit(System.Environment.ExitCode);

            }
        }

        //內容分割,並建立Student類別,加入studentlist

        static void SplitInput()
        {
            studentList = new List<Student>();
            char[] delimiter = { ',' };
            using (sr = new StreamReader(inputFile))
            {

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] field = line.Split(delimiter);
                    string id;
                    string name;
                    //Console.WriteLine(line);
                    int chinese, english, math, physic, chemistry;
                    try
                    {
                        id = field[0];
                        name = field[1];
                        chinese = Convert.ToInt32(field[2]);
                        english = Convert.ToInt32(field[3]);
                        math = Convert.ToInt32(field[4]);
                        physic = Convert.ToInt32(field[5]);
                        chemistry = Convert.ToInt32(field[6]);
                        Student s = new Student(id, name, chinese, english, math, physic, chemistry);
                        studentList.Add(s);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Something wrong in {0}", line);
                        Console.WriteLine(e.Message);

                        System.Environment.Exit(System.Environment.ExitCode);
                    }
                }
            }
        }

        //根據自訂方法 sort後輸出到 outputPath
        static void SortAndWrite()
        {
            string result;
            double totalTime = 0;
            stw.Reset(); stw.Start();
            studentList.Sort(new myComparer((int)Grade.chinese));
            result = stw.Elapsed.TotalMilliseconds.ToString();
            Console.WriteLine("Sort of Chinese Done , Time Elapsed " + result + " msec");
            WriteTofile(outfile[(int)Grade.chinese], (int)Grade.chinese);
            totalTime += Convert.ToDouble(result);
            stw.Reset(); stw.Start();
            studentList.Sort(new myComparer((int)Grade.english));
            result = stw.Elapsed.TotalMilliseconds.ToString();
            Console.WriteLine("Sort of English Done , Time Elapsed " + result + " msec");
            WriteTofile(outfile[(int)Grade.english], (int)Grade.english);
            totalTime += Convert.ToDouble(result);
            stw.Reset(); stw.Start();
            studentList.Sort(new myComparer((int)Grade.math));
            result = stw.Elapsed.TotalMilliseconds.ToString();
            Console.WriteLine("Sort of Math Done , Time Elapsed " + result + " msec");
            WriteTofile(outfile[(int)Grade.math], (int)Grade.math);
            totalTime += Convert.ToDouble(result);
            stw.Reset(); stw.Start();
            studentList.Sort(new myComparer((int)Grade.physic));
            result = stw.Elapsed.TotalMilliseconds.ToString();
            Console.WriteLine("Sort of Physic Done , Time Elapsed " + result + " msec");
            WriteTofile(outfile[(int)Grade.physic], (int)Grade.physic);
            totalTime += Convert.ToDouble(result);
            stw.Reset(); stw.Start();
            studentList.Sort(new myComparer((int)Grade.chemistry));
            result = stw.Elapsed.TotalMilliseconds.ToString();
            Console.WriteLine("Sort of Chemistry Done , Time Elapsed " + result + " msec");
            WriteTofile(outfile[(int)Grade.chemistry], (int)Grade.chemistry);
            totalTime += Convert.ToDouble(result);
            stw.Reset(); stw.Start();
            studentList.Sort(new myComparer((int)Grade.avg));
            result = stw.Elapsed.TotalMilliseconds.ToString();
            Console.WriteLine("Sort of Average Done , Time Elapsed " + result + " msec");
            totalTime += Convert.ToDouble(result);
            WriteTofile(outfile[(int)Grade.avg], (int)Grade.avg);
            Console.WriteLine("ALL Task Done, Time Elapsed " + totalTime + " msec");
        }

        //SortAndWrite() 呼叫 依據參數輸出不同檔案
        static void WriteTofile(string f, int which)
        {
            //rank由比較上一個分數的名次 若相同或較小則+1 需要例子來想
            f = outputPath + f;
            int rank = 0, cnt = 0;
            try
            {
                switch (which)
                {
                    case (int)Grade.chinese:
                        using (sw = new StreamWriter(f, false, System.Text.Encoding.GetEncoding("Unicode")))
                        {
                            foreach (Student sd in studentList)
                            {
                                if (sd.chinese == studentList[rank].chinese)
                                    cnt++;
                                else if (sd.chinese < studentList[rank].chinese)
                                {
                                    if (cnt == 0)
                                        rank++;
                                    rank += cnt;
                                    cnt = 1;
                                }

                                sw.WriteLine("{0},{1},{2},{3}", sd.id, sd.name, sd.chinese, rank + 1);
                            }
                        }
                        break;
                    case (int)Grade.english:
                        using (sw = new StreamWriter(f, false, System.Text.Encoding.GetEncoding("Unicode")))
                        {
                            foreach (Student sd in studentList)
                            {
                                if (sd.english == studentList[rank].english)
                                    cnt++;
                                else if (sd.english < studentList[rank].english)
                                {
                                    if (cnt == 0)
                                        rank++;
                                    rank += cnt;
                                    cnt = 1;
                                }
                                sw.WriteLine("{0},{1},{2},{3}", sd.id, sd.name, sd.english, rank + 1);
                            }
                        }
                        break;
                    case (int)Grade.math:
                        using (sw = new StreamWriter(f, false, System.Text.Encoding.GetEncoding("Unicode")))
                        {
                            foreach (Student sd in studentList)
                            {
                                if (sd.math == studentList[rank].math)
                                    cnt++;
                                else if (sd.math < studentList[rank].math)
                                {
                                    if (cnt == 0)
                                        rank++;
                                    rank += cnt;
                                    cnt = 1;
                                }
                                sw.WriteLine("{0},{1},{2},{3}", sd.id, sd.name, sd.math, rank + 1);
                            }
                        }
                        break;
                    case (int)Grade.physic:
                        using (sw = new StreamWriter(f, false, System.Text.Encoding.GetEncoding("Unicode")))
                        {
                            foreach (Student sd in studentList)
                            {
                                if (sd.physic == studentList[rank].physic)
                                    cnt++;
                                else if (sd.physic < studentList[rank].physic)
                                {
                                    if (cnt == 0)
                                        rank++;
                                    rank += cnt;
                                    cnt = 1;
                                }
                                sw.WriteLine("{0},{1},{2},{3}", sd.id, sd.name, sd.physic, rank + 1);
                            }
                        }
                        break;
                    case (int)Grade.chemistry:
                        using (sw = new StreamWriter(f, false, System.Text.Encoding.GetEncoding("Unicode")))
                        {
                            foreach (Student sd in studentList)
                            {
                                if (sd.chemistry == studentList[rank].chemistry)
                                    cnt++;
                                else if (sd.chemistry < studentList[rank].chemistry)
                                {
                                    if (cnt == 0)
                                        rank++;
                                    rank += cnt;
                                    cnt = 1;
                                }
                                sw.WriteLine("{0},{1},{2},{3}", sd.id, sd.name, sd.chemistry, rank + 1);
                            }
                        }
                        break;
                    case (int)Grade.avg:
                        using (sw = new StreamWriter(f, false, System.Text.Encoding.GetEncoding("Unicode")))
                        {
                            foreach (Student sd in studentList)
                            {
                                if (sd.avg == studentList[rank].avg)
                                    cnt++;
                                else if (sd.avg < studentList[rank].avg)
                                {
                                    if (cnt == 0)
                                        rank++;
                                    rank += cnt;
                                    cnt = 1;
                                }
                                sw.WriteLine("{0},{1},{2},{3}", sd.id, sd.name, sd.avg, rank + 1);
                            }
                        }
                        break;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine(); // Pause
                System.Environment.Exit(System.Environment.ExitCode);
            }
            finally
            {
                
            }

        }

        //Main() 使用者互動
        static void Main(string[] args)
        {
            
            ReadFile();
            SplitInput();
            SortAndWrite();
  

            Console.WriteLine("\r\n\r\nWrite output to " + outputPath);  
            Console.WriteLine("Press any key to leave...");
            Console.ReadLine(); // Pause
        }
    }
}
