using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FetchImages
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int totalBytes;
        String baseURL = "http://51.91.120.89/TABLICE/";
        private async void button1_Click(object sender, EventArgs e)
        {
            totalBytes = 0;
            List<Task<int>> tasks = new List<Task<int>>();

            // declare progress object for notify UI controls
            IProgress<string> progress = new Progress<string>(message => {
                listBox1.Items.Add(message);
            });

            WebClient wb = new WebClient();
            string content = await wb.DownloadStringTaskAsync(baseURL);
            string[] lines = content.Split('\n');
            foreach (var line in lines)
            {

                String imageFile = line.Trim();
                if (String.IsNullOrEmpty(imageFile))
                    continue;

                Task<int> task = Task.Run(() => {

                String url = $"{baseURL}{imageFile}";

                    //listBox1.Items.Add($"Downloaded file: {url}"); doesn't work

                    //listBox1.Invoke(new Action(() => {
                    //    listBox1.Items.Add($"Downloaded file: {url}");
                    //}));

                    WebClient client = new WebClient();
                    byte[] data = client.DownloadData(url);
                    using (FileStream fs = new FileStream("c:/tmp/"+imageFile, FileMode.Create))
                    {
                        fs.Write(data, 0, data.Length);
                        fs.Flush();

                        //totalBytes += data.Length;
                        Interlocked.Add(ref totalBytes, data.Length);
                    }

                    progress.Report($"Downloaded file: {url}");
                    return data.Length;

                } );
                tasks.Add(task);
                //break;

            }

            await Task.WhenAll(tasks);
            int total = 0;
            tasks.ForEach(x => total += x.Result);
            MessageBox.Show($"Total bytes: {totalBytes} , {total}");

        }
    }
}
