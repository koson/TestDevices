using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Management;
using System.Configuration;

namespace TestDevices
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                _tmpDev = GetConfig();

                Application.Run(new Form1());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        static List<string> GetConfig()
        {
            var devices = ConfigurationManager.AppSettings.AllKeys;

            var tmpDev = new List<string>();
            foreach (var item in devices)
            {
                if (item.StartsWith("devices"))
                {
                    var tmpvalue = ConfigurationManager.AppSettings[item];
                    tmpDev.Add(tmpvalue);
                }
            }
            return tmpDev;
        }

        public static List<string> _tmpDev { get; private set; }
    }
}
