using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using System.Security.AccessControl;
using Training_Practice_Day_6;

namespace Training_Practice_6
{
    public class Video61{
        private string _firstname;
        private string _lastname;

        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }
        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        public string GetFullName()
        {
            return _firstname + " ," + _lastname;
        }

    }

    public class Training
    {

        public static void Thread1Function_Video92()
        {
            Console.WriteLine("Thread 1 Executing");
            Thread.Sleep(5000);
            Console.WriteLine("Thead 1 Returning");
        }
        public static void Thread2Function_Video92()
        {

            Console.WriteLine("Thread 2 Executing");
            Thread.Sleep(5000);
            Console.WriteLine("Thead 2 Returning");
        }

        public static void Video92Invoker()
        {
            Console.WriteLine("Main Started");
            Thread T1 = new Thread(Training.Thread1Function_Video92);
            T1.Start();

            Thread T2 = new Thread(Training.Thread2Function_Video92);
            T2.Start();

            if (T1.Join(10))
            {
                Console.WriteLine("Thread1 has  completed in 10 milisecond");
            }
            else
            {
                Console.WriteLine("Thread1 has not completed in 10 milisecond");
            }
            Console.WriteLine("Threadone Completed");

            T2.Join();
            Console.WriteLine("Thread2 Completed");

            if (T1.IsAlive)
            {
                Console.WriteLine("Thread 1 is still doing its work");
            }
            else
            {
                Console.WriteLine("Threadone Completed");
            }

            Console.WriteLine("Main Completed");
        }
        static int Total = 0;
        static object _lock=new object();
        public static void AddOneMillion ()
        {
            for (int i = 1; i <= 1000000; i++)
            {
                //lock(_lock)
                //{Total++}
            
                Interlocked.Increment(ref Total);
                //Total++;
            }
        }
        public static void Video93Invoker()
        {
            Stopwatch s1= Stopwatch.StartNew();
            Thread T1 = new Thread(Training.AddOneMillion);
            Thread T2 = new Thread(Training.AddOneMillion);
            Thread T3 = new Thread(Training.AddOneMillion);
            T1.Start();T2.Start();T3.Start();
            T1.Join();T2.Join();T3.Join();
            //AddOneMillion();
            //AddOneMillion();
            //AddOneMillion();
            Console.WriteLine(" Total: {0}",Total);
            s1.Stop();
            Console.WriteLine("Elapsed Time:{0}", s1.ElapsedTicks);
            //1millisecond contains 10000 ticks
        }
        static int Total2 = 0;
        static object _lock2 = new object();
        public static void Video94()
        {
            for (int i = 1; i <= 1000000; i++)
            {
                Monitor.Enter(_lock2);

                try
                {
                    Total2++;
                }
                finally
                {
                    Monitor.Exit(_lock2);
                }
            }
        }

        public static void Video97_Even() 
        {
            double sum = 0;
            for(int i = 0; i <= 5000000; i++)
            {
                if (i % 2 == 0)
                {
                    sum += i;
                }
            }
            Console.WriteLine("Sum of Even Numbers", sum);
        }

        public static void Video97_Odd() 
        {

            double sum = 0;
            for (int i = 0; i <= 5000000; i++)
            {
                if (i % 3 == 0)
                {
                    sum += i;
                }
            }
            Console.WriteLine("Sum of Even Numbers", sum);
        }
        public static void Video97Invoker()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Video97_Even();
            Video97_Odd();
            stopwatch.Stop();
            Console.WriteLine("Without multithreading time taken:{0}",stopwatch.ElapsedTicks);

            stopwatch = Stopwatch.StartNew();
            Thread T1 = new Thread(Training.Video97_Odd);
            Thread T2 = new Thread(Training.Video97_Even);

            T1.Start();
            T2.Start();

            T1.Join();
            T2.Join();
            stopwatch.Stop();

            Console.WriteLine("With multithreading time taken:{0}", stopwatch.ElapsedTicks);

        }
        
        public class Video98
        {            
            public string Name { get; set; }
            public int code { get; set; }

        }
        public static bool FindEmployee(Video98 emp)
        {
            return emp.code == 102;
        }
        public static void Video98Invoker()
        {
            List<Video98> listEmployees = new List<Video98>()
            {
            new Video98{code=101,Name="Mark"},
            new Video98{code=102,Name="Mar"},
            new Video98{code=103,Name="Ma"},
            };
            Predicate<Video98> EmployeePredicate = new Predicate<Video98>(FindEmployee);
            
            Video98 v98=listEmployees.Find(emp=>FindEmployee(emp));
            Console.WriteLine("Id={0}, Name={1}", v98.code, v98.Name);

            v98=listEmployees.Find(delegate(Video98 x) { return x.code == 102; });
            Console.WriteLine("ID={0}, Name={1}", v98.code, v98.Name);
        }

        public static void Video99Invoker()
        {
            List<Video98> listEmployees = new List<Video98>()
            {
            new Video98{code=101,Name="Mark"},
            new Video98{code=102,Name="Mar"},
            new Video98{code=103,Name="Ma"},
            };

            Video98 v99 =listEmployees.Find(Emp => Emp.code == 102);
            Console.WriteLine("ID={0}, Name={1}", v99.code, v99.Name);

            int count = listEmployees.Count(x => x.Name.StartsWith("M"));

        }

        public class Video100
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }

        public static void Video100Invoker()
        {
            List<Video100> v100 = new List<Video100>()
            {
                new Video100{ID=100,Name="A"},
                new Video100{ID=101,Name="B"},
                new Video100{ID=102,Name="C"}
            };

            Func<Video100, string> selector = _v100 => "Name=" + _v100.Name;
            IEnumerable<string> names=v100.Select(selector);

            foreach(string name in names)
            {
                Console.WriteLine(name);
            }

        }
        public static int CountCharacters()
        {
            int count = 0;
            using(StreamReader sr=new StreamReader(@"Data-test.txt"))
            {
                
                string content = sr.ReadToEnd();
                Console.WriteLine(content);
                count = content.Length;
                Thread.Sleep(5000);
            }
            return count;
        }
        public async static void Video101()
        {
            Task<int> task = new Task<int>(CountCharacters);
            task.Start();

            Console.WriteLine("Waiting Task is executing");
            int count = await task;

            Console.WriteLine("{0} characters in a file.",count);
        }


            static void Main()
            {
            Video98Invoker();
            //Video61_1 v61 = new Video61_1();
            //v61.Samplepublicmethod();
            //Video101();
            //Video100Invoker();
            //Video97Invoker();
            //Console.WriteLine(Environment.ProcessorCount);
            //Video93Invoker();
            //Video94();
        }
    }
}