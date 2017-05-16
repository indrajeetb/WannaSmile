using System;
using System.ServiceProcess;
using System.Text;
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
        static bool IPBlocked = false;
        static HttpListener server = new HttpListener();

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // powershell command to disable SMBs
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            process.StartInfo.FileName = "powershell.exe";
            process.StartInfo.Arguments = "Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\LanmanServer\\Parameters\" SMB1 -Type DWORD -Value 0 -Force; Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\LanmanServer\\Parameters\" SMB2 -Type DWORD -Value 0 -Force";
            process.Start();
            // end powershell

            // check if etc\hosts already blocks wannacry domains
            string line;
            string domain = "127.0.0.1 www.iuqerfsodp9ifjaposdfjhgosurijfaewrwergwea.com";
            System.IO.StreamReader file = new System.IO.StreamReader("C:\\Windows\\System32\\drivers\\etc\\hosts");
            while ((line = file.ReadLine()) != null)
            {
                if (line == domain)
                {
                    IPBlocked = true;
                    break;
                }
            }

            file.Close();
      
            // update hosts files
            if (!IPBlocked)
            {
                File.AppendAllText(@"C:\\Windows\\System32\\drivers\\etc\\hosts", "\n127.0.0.1 www.iuqerfsodp9ifjaposdfjhgosurijfaewrwergwea.com");
                File.AppendAllText(@"C:\\Windows\\System32\\drivers\\etc\\hosts", "\n127.0.0.1 iuqerfsodp9ifjaposdfjhgosurijfaewrwergwea.com");
                File.AppendAllText(@"C:\\Windows\\System32\\drivers\\etc\\hosts", "\n127.0.0.1 www.ifferfsodp9ifjaposdfjhgosurijfaewrwergwea.com");
                File.AppendAllText(@"C:\\Windows\\System32\\drivers\\etc\\hosts", "\n127.0.0.1 ifferfsodp9ifjaposdfjhgosurijfaewrwergwea.com");
                File.AppendAllText(@"C:\\Windows\\System32\\drivers\\etc\\hosts", "\n127.0.0.1 www.iuqssfsodp9ifjaposdfjhgosurijfaewrwergwea.com");
                File.AppendAllText(@"C:\\Windows\\System32\\drivers\\etc\\hosts", "\n127.0.0.1 iuqssfsodp9ifjaposdfjhgosurijfaewrwergwea.com");
                File.AppendAllText(@"C:\\Windows\\System32\\drivers\\etc\\hosts", "\n127.0.0.1 www.ayylmaotjhsstasdfasdfasdfasdfasdfasdfasdf.com");
                File.AppendAllText(@"C:\\Windows\\System32\\drivers\\etc\\hosts", "\n127.0.0.1 ayylmaotjhsstasdfasdfasdfasdfasdfasdfasdf.com");
            }

            //end updating

            isRunning = true;
            server.Prefixes.Add("http://127.0.0.1/");
            server.Prefixes.Add("http://localhost/");
            server.Start(); 
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
            byte[] _responseArray = Encoding.UTF8.GetBytes("<html><head><title>WannaSmile</title></head>" +
            "<body>Safe from WannaCry :) <a href=\"https://github.com/indrajeetb/WannaSmile\">- wannasmile</a></body></html>"); 
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
