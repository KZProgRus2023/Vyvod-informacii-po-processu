/* Created by SharpDevelop.
* User: user
* Date: 26.12.2012
* Time: 14:27
*
* To change this template use Tools | Options | Coding |
* Edit Standard Headers. */
using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Linq;
namespace app71_GetProcId
{
    class Program
    {
        public static Process theProc;
        static void EnumThreadsForPid(int pID)
        {
            theProc = null; // Process
            try
            {
                theProc = Process.GetProcessById(pID);
                Console.WriteLine("Имя компьютера: {0}",
                theProc.MachineName);
                
            if (theProc.MachineName == ".")
                    Console.WriteLine("Имя компьютера: текущий");
            }
            catch (ArgumentException ex)
            { Console.WriteLine(ex.Message); }
        }
        public static void Main()
        {
            Console.WriteLine("Данные по конкретному " +
            "запущенному процессу");
            EnumThreadsForPid(1572);
            Console.WriteLine("Потоки, используемые процессом: {0}",
            theProc.ProcessName);
            ProcessThreadCollection theThreads =
            theProc.Threads;
            // У свойства Threads тип ProcessThreadCollection,
            // а значение — массив типа ProcessThread
            foreach (ProcessThread pt in theThreads)
            {
                string info =
                string.Format("-> Thread ID: {0}\tStart Time {1}\tPriority {2}",
            pt.Id, pt.StartTime.ToShortTimeString(),
pt.PriorityLevel);
                Console.WriteLine(info);
            }
            Console.WriteLine("************* ^ " +
            "********************** \n");
            Console.Read();
        } // Main()
    } // Program
} // NameSpace