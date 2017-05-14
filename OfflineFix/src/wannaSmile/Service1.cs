using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Net;

namespace wannaSmile
{
    // windows service
    public partial class Service1 : ServiceBase
    {
        Thread th  = new Thread(DoThis);
        static bool isRunning = false;
        static HttpListener server = new HttpListener();

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // do powershell thing
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            process.StartInfo.FileName = "powershell.exe";
            process.StartInfo.Arguments = "Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\LanmanServer\\Parameters\" SMB1 -Type DWORD -Value 0 -Force; Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\LanmanServer\\Parameters\" SMB2 -Type DWORD -Value 0 -Force";
            process.Start();
            // end powershell
            // update hosts files
            File.AppendAllText(@"C:\\Windows\\System32\\drivers\\etc\\hosts", "\n127.0.0.1 www.iuqerfsodp9ifjaposdfjhgosurijfaewrwergwea.com" + Environment.NewLine);
            File.AppendAllText(@"C:\\Windows\\System32\\drivers\\etc\\hosts", "\n127.0.0.1 iuqerfsodp9ifjaposdfjhgosurijfaewrwergwea.com" + Environment.NewLine);
            //end updating
            isRunning = true;
            server.Prefixes.Add("http://127.0.0.1/");
            server.Prefixes.Add("http://localhost/");
            server.Start(); 
            //HttpListenerContext context = server.GetContext();
            //HttpListenerResponse response = context.Response;
            th.Start();
        }

        private static void DoThis()
        {
            while (isRunning)
            {
                handleRequest();
            }
        }
        static void handleRequest()
        {
            HttpListenerContext context = server.GetContext();
            byte[] _responseArray = Encoding.UTF8.GetBytes("<html><head><title>wannasmile</title></head>" +
            "<body>safe from wannacry :)</body></html>"); 
            context.Response.OutputStream.Write(_responseArray, 0, _responseArray.Length); 
            context.Response.KeepAlive = false; 
            context.Response.Close();
        }
        protected override void OnStop()
        {
            isRunning = false;
            server.Close();
            th = null;
        }
    }
    // end of windows service 
  
}
