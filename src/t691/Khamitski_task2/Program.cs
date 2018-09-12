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
                if (val == "Memory" )
                {
                    counter = new PerformanceCounter("Memory", "% Committed Bytes In Use");
                }
                else if(val == "CPU")
                {
                    counter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                }
            }


          public  string Draw()
            {
                string bar = "";
                 size = Convert.ToInt32(counter.NextValue());
                for (int i = 0; i <size ; i++)
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
            //1637814

            /// 1048576 
        }





        static void Main(string[] args)
        {

      
            PerformanceCounter memory = new PerformanceCounter("Memory", "Available MBytes");


            
            Process[] All = Process.GetProcesses();

           
            Bar memaa = new Bar("Memory");
            Bar Cpucount = new Bar("CPU");



            process();

            Console.ReadLine();

            while (true)
            {       
                

                Console.WriteLine("UserName: {0}", Environment.UserName);

                Console.Write("\rRAM:[ {0,-100}]({1}% freeram:{2} mb)\n ",memaa.Draw(),memaa.inpersent(),memory.NextValue() );


                Console.Write("\rCPU:[ {0,-100}]({1}%)\n ", Cpucount.Draw(), Cpucount.inpersent());

              

                Thread.Sleep(500);
                Console.Clear();
            }





            Console.ReadLine();

        }
    }
}
