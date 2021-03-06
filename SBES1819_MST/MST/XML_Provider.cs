﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Contracts;

namespace MST
{
    public class XML_Provider : IXMLConfiguration_Service
    {
        // TODO: za sve metode koristi Read() i Write() iz XML_Worker-a
        // one rade sa upisom i citanjem liste<XLM_node> u/iz fajla


        private List<XML_Node> black_list = null;   // TODO: Dunja - da li ovo treba u konstruktoru klase ? 

        public XML_Provider()
        {
            if((black_list = XML_Worker.Instance().XML_Read()) == null)
            {
                Console.WriteLine("Error while reading Black List from file.");
                black_list = new List<XML_Node>();
            }
        }

        public void AllowProcess(string processName)
        {
            if ((black_list = XML_Worker.Instance().XML_Read()) == null)
            {
                Console.WriteLine("Error while reading Black List from file.");
                black_list = new List<XML_Node>();
            }

            black_list.RemoveAll(n => (n.ProcessName == processName));

            //foreach(XML_Node n in black_list)
            //{
            //    if(n.ProcessName == processName)
            //    {
            //        black_list.Remove(n);
            //    }
            //}

            XML_Worker.Instance().XML_Write(black_list);
        }

        public void BanGroup(string groupID, string processName)
        {
            if ((black_list = XML_Worker.Instance().XML_Read()) == null)
            {
                Console.WriteLine("Error while reading Black List from file.");
                black_list = new List<XML_Node>();
            }

            XML_Node n = new XML_Node("*", groupID, processName);
            black_list.Add(n);

            XML_Worker.Instance().XML_Write(black_list);
        }

        public void BanUser(string userID, string processName)
        {
            if ((black_list = XML_Worker.Instance().XML_Read()) == null)
            {
                Console.WriteLine("Error while reading Black List from file.");
                black_list = new List<XML_Node>();
            }

            XML_Node n = new XML_Node(userID, "*", processName);
            black_list.Add(n);

            XML_Worker.Instance().XML_Write(black_list);
        }

        public void BanUserInGroup(string userID, string groupID, string processName)
        {
            if ((black_list = XML_Worker.Instance().XML_Read()) == null)
            {
                Console.WriteLine("Error while reading Black List from file.");
                black_list = new List<XML_Node>();
            }

            XML_Node n = new XML_Node(userID, groupID, processName);
            black_list.Add(n);

            XML_Worker.Instance().XML_Write(black_list);
        }

        public void ForbidProcess(string processName)
        {
            if ((black_list = XML_Worker.Instance().XML_Read()) == null)
            {
                Console.WriteLine("Error while reading Black List from file.");
                black_list = new List<XML_Node>();
            }

            XML_Node n = new XML_Node("*", "*", processName);
            black_list.Add(n);

            XML_Worker.Instance().XML_Write(black_list);
        }

        public void LiftGroupBan(string groupID, string processName)
        {
            if ((black_list = XML_Worker.Instance().XML_Read()) == null)
            {
                Console.WriteLine("Error while reading Black List from file.");
                black_list = new List<XML_Node>();
            }

            black_list.RemoveAll(n => ((n.UserGroup == groupID) && (n.ProcessName == processName)));

            //foreach(XML_Node n in black_list)       // TODO: da li moze ovakvo brisanje u listi
            //{
            //    if((n.UserGroup == groupID) && (n.ProcessName == processName))
            //    {
            //        black_list.Remove(n);
            //    }
            //}

            XML_Worker.Instance().XML_Write(black_list);
        }

        public void LiftUserBan(string userID, string processName)
        {
            if ((black_list = XML_Worker.Instance().XML_Read()) == null)
            {
                Console.WriteLine("Error while reading Black List from file.");
                black_list = new List<XML_Node>();
            }

            black_list.RemoveAll(n => ((n.UserId == userID) && (n.ProcessName == processName)));

            XML_Worker.Instance().XML_Write(black_list);
        }

        public void LiftUserInGroupBan(string userID, string groupID, string processName)
        {
            if ((black_list = XML_Worker.Instance().XML_Read()) == null)
            {
                Console.WriteLine("Error while reading Black List from file.");
                black_list = new List<XML_Node>();
            }

            black_list.RemoveAll(n => ((n.UserId == userID) && (n.UserGroup == groupID) && (n.ProcessName == processName)));

            XML_Worker.Instance().XML_Write(black_list);
        }
    }
}
