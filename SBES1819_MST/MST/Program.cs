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
        
        static void Main(string[] args)
        {
            //TODO open host MST

            MST_Server server_MST = new MST_Server();
            server_MST.Open();
            

            //TODO open host XML...

<<<<<<< HEAD
            // ...

=======
            //**************************************************************

            List<XML_Node> lista = new List<XML_Node>();

            lista.Add(new XML_Node("aaa", "aaa", "aaa"));
            lista.Add(new XML_Node("bbb", "bbb", "bbb"));
            lista.Add(new XML_Node("ccc", "ccc", "ccc"));

            XML_Worker.Instance().XML_Write(lista);             // Poziv upisa
                
            List<XML_Node> lista2 = new List<XML_Node>();       // xml se nalazi u debag folderu
            lista2 = XML_Worker.Instance().XML_Read();          // Poziv iscitavanja

            foreach (XML_Node n in lista2)
            {
                Console.WriteLine(n.UserId + " " + n.UserGroup + " " + n.ProcessName);
            }

            //**************************************************************
>>>>>>> 6572823dc948cae0eee22253dbd210fe9cb56a39

            ThreadFunction tf = new ThreadFunction();

            Thread t = new Thread(tf.DetectProcesses);
            t.Start();
             


            Console.WriteLine("Press any key to close all hosts...");
            Console.ReadKey();

            // TODO close host MST

            server_MST.Close();
            // server_XML.Close();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
