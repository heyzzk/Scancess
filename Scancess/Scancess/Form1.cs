using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Scancess
{
    public partial class Form1 : Form
    {
        private bool securemode = true;
        private int devcount = 0;

        private DateTime _dt = DateTime.Now;  //定义一个成员函数用于保存每次的时间点
        private string currentFileName = "fzsdev-1.csv";
        public Form1()
        {
            InitializeComponent();
            textBox10.Text = getCSVcontent(currentFileName);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("init");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*
            DateTime tempDt = DateTime.Now;          //保存按键按下时刻的时间点
            TimeSpan ts = tempDt.Subtract(_dt);     //获取时间间隔
            if (ts.Milliseconds > 50)                           //判断时间间隔，如果时间间隔大于50毫秒，则将TextBox清空
                textBox1.Text = "";
            _dt = tempDt;
            */

            //禁止手动输入判断
            if (textBox1.Text.Contains("\r\n"))
            {
                Console.WriteLine("---------------new----------------");
                string rawdata = textBox1.Text;
                string[] arr = rawdata.Split(';');
                foreach (string s in arr)
                {
                    Console.WriteLine(s);
                }
                string mac = arr[0];
                string ssid = arr[1];
                string aa = arr[2];
                string bb = arr[3];
                string cc = arr[4];
                string dd = arr[5];
                string apname = arr[6];
                string appw = arr[7];

                textBox2.Text = mac;
                textBox3.Text = ssid;
                textBox4.Text = aa;
                textBox5.Text = bb;
                textBox6.Text = cc;
                textBox7.Text = dd;
                textBox8.Text = apname;
                textBox9.Text = appw;

                //清空textbox
                textBox1.Text = "";

                string newFileName = currentFileName;
                string clientDetails = mac + "," + ssid + "," + aa + "," + bb + "," + cc + "," + dd + "," + apname + "," + appw;

                if (getCSVcontent(newFileName).Contains(clientDetails))
                {
                    MessageBox.Show("设备信息已存在，无法保存！");
                    return;
                }

                if (!File.Exists(newFileName))
                {
                    string clientHeader = "MAC,SSID,IMEI0,IMSI,ICCID,devSn,ApName,ApPwd"+"\r\n";
                    File.WriteAllText(newFileName, clientHeader);
                }
                try
                {
                    devcount++;
                    if (securemode == true && devcount > 5)
                        return;
                    
                    File.AppendAllText(newFileName, clientDetails);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("CSV文件写入失败！error code="+ex);
                }

                textBox10.Text = getCSVcontent(currentFileName);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Scancess|版本v0.5\n2020-11-10");
        }

        private void 保存路径ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            textBox10.Text = getCSVcontent(currentFileName);
        }

        private string getCSVcontent(string filePath) {
            if (File.Exists(filePath))
            {
                try
                {
                    return File.ReadAllText(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("CSV文件读取失败！error code=" + ex);
                }
            }
            return "";
        }
    }
}
