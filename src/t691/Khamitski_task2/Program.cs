using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Management;
using Microsoft.VisualBasic.Devices;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;

namespace ConsoleApp4
{
    class Program
    {



        class Bar
        {
            int size;
            PerformanceCounter counter;
            public

                Bar(string val)
            {
                if (val == "Memory")
                {
                    counter = new PerformanceCounter("Memory", "% Committed Bytes In Use");
                }
                else if (val == "CPU")
                {
                    counter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                }
            }


            public string Draw()
            {
                string bar = "";
                size = Convert.ToInt32(counter.NextValue());
                for (int i = 0; i < size; i++)
                {
                    bar += "|";
                }

                return bar;

            }
            public int inpersent()
            {
                return size;
            }

        }


        static void process()
        {

            foreach (Process j in Process.GetProcesses())
            {

                Console.WriteLine("ID: {0,-10}  Name: {1,-20} Memory Usage: {2,-2} mb", j.Id, j.ProcessName, j.WorkingSet64 / 1048576);
            }


            Console.WriteLine("press f to refresh");
            //  1637814
            /// 1048576 
        }


        static PerformanceCounter memory = new PerformanceCounter("Memory", "Available MBytes");

        static Bar memaa = new Bar("Memory");
        static Bar Cpucount = new Bar("CPU");


        static int mode = 1;

        static void memoryy()
        {

            Console.WriteLine("UserName: {0}", Environment.UserName);


            Console.Write("\rRAM:[ {0,-100}]({1}% freeram:{2} mb)\n ", memaa.Draw(), memaa.inpersent(), memory.NextValue());


            Console.Write("\rCPU:[ {0,-100}]({1}%)\n ", Cpucount.Draw(), Cpucount.inpersent());
            Thread.Sleep(500);

        }

        static void chouse()
        {
            while (true) {
                mode = Convert.ToInt32(Console.ReadLine()); 
            }
        }



        static void Main(string[] args)
        {


                Thread thread1 = new Thread(chouse);
            thread1.Start();

            while (true)
            {
                Console.WriteLine("chouse mode and press enter 1-memory 2-procees ");
                if (mode == 1)
                {
                    memoryy();
                }
                else
                {
                    process();
                    Console.ReadKey(); 
                }



               Console.Clear();
            }
            Console.ReadLine();

        }
    }
}
            


        

