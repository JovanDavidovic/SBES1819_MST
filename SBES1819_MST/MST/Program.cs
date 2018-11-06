﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Threading;

namespace MST
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            MST_Server server_MST = new MST_Server();
            server_MST.Open();


            //TODO open host XML...

            //XML_Server server_XML = new XML_Server();
            //server_XML.Open();

            List<XML_Node> lista = new List<XML_Node>();

            lista.Add(new XML_Node("user1", "*", "Notepad"));
            lista.Add(new XML_Node("user2", "*", "Google Chrome"));
            lista.Add(new XML_Node("*", "Group5", "Microsoft Edge"));

            XML_Worker.Instance().XML_Write(lista);             // Poziv upisa
                
            List<XML_Node> lista2 = new List<XML_Node>();       // xml se nalazi u debag folderu
            lista2 = XML_Worker.Instance().XML_Read();          // Poziv iscitavanja

            foreach (XML_Node n in lista2)
            {
                Console.WriteLine(n.UserId + " " + n.UserGroup + " " + n.ProcessName);
            }

            ThreadFunction tf = new ThreadFunction();

            Thread t = new Thread(tf.DetectProcesses);
            t.Start();
             


            Console.WriteLine("Press any key to close all hosts...");
            Console.ReadKey();

            // TODO close host MST

            server_MST.Close();
            //server_XML.Close();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
