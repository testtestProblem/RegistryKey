﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryKey_test
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataChoose;
            Console.WriteLine("[set] or [get] data from register");
            while ((dataChoose = Console.ReadLine()) != "") 
            {
                if (dataChoose == "set")
                {
                    string key, value;
                    Console.WriteLine("Key, Value");
                    key = Console.ReadLine();
                    value = Console.ReadLine();
                    if (key != "" && value != "") RegistryWindows.setValue(key, value);
                    Console.WriteLine("Ok");
                }
                else if (dataChoose == "get") 
                {
                    string key, dataGet = "";
                    Console.WriteLine("key");
                    key = Console.ReadLine();
                    if (key != "") dataGet = RegistryWindows.getValue(key);
                    Console.WriteLine("get value = " + dataGet);
                }
            }
        }
    }

    class RegistryWindows
    {
        private const string userRoot = "HKEY_CURRENT_USER";
        private static string subkey = @"SOFTWARE\HotTabTest1";
        //private static string subkey = @"SOFTWARE\HotTab10";
        private static string subkey1 = "abcd";
        private static string subkey2 = "efgh";
        //private static string keyPath = userRoot + "\\" + subkey;


        //private static RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(subkey);
        //Registry.CurrentUser.CreateSubKey(subkey);

        /*private string keyName(string name)
        {
            return keyPath += "\\" + name;
        }*/

        public static void setValue(string key, string value)
        {/*
            RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(subkey1, true);
            RegistryKey registryKey2 =registryKey.CreateSubKey(subkey2, true);
            //registryKey.SetValue(key, (string)value);
            registryKey2.SetValue(key, (string)value);
            registryKey2.Close();
            registryKey.Close();
            registryKey2.Dispose();
            registryKey.Dispose();*/

            RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(subkey);
            registryKey.SetValue(key, (string)value, RegistryValueKind.String);
            registryKey.Close();
        }

        public static string getValue(string key)
        {/*
            //RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(subkey);
            RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(subkey1);
            RegistryKey registryKey2 = registryKey.CreateSubKey(subkey2);
            string data = registryKey2.GetValue(key, "") as string;
            registryKey2.Close();
            registryKey.Close();
            registryKey2.Dispose();
            registryKey.Dispose();*/

            RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(subkey);
            string data = registryKey.GetValue(key, "") as string;
            registryKey.Close();

            if (data == "" || data == null) return "nothing";
            else return data;
        }
    }
}
