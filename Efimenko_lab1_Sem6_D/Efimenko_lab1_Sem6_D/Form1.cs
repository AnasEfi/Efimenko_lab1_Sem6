using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace Efimenko_lab1_Sem6_D
{
    public partial class Form1 : Form
    {
        public int myCounter;
        Process childProcess = null;
        System.Threading.EventWaitHandle startEvent = new EventWaitHandle(false, EventResetMode.AutoReset, "StartEvent");
        System.Threading.EventWaitHandle stopEvent = new EventWaitHandle(false, EventResetMode.ManualReset, "StopEvent");
        System.Threading.EventWaitHandle confirmEvent = new EventWaitHandle(false, EventResetMode.AutoReset, "ConfirmEvent");
        public Form1()
        {
            InitializeComponent();

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (childProcess == null || childProcess.HasExited)
            {
                childProcess = Process.Start("C:/Users/Anastasya/source/repos/Efimenko_lab1_Sem6/Debug/Efimenko_lab1_Sem6.exe");
                label2.Text = "0";
                myCounter = 0;
            }
            else
            {
                startEvent.Set();
                ++myCounter;
                label2.Text = Convert.ToString(myCounter);
                confirmEvent.WaitOne();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!(childProcess == null || childProcess.HasExited))
            {
                stopEvent.Set();
                confirmEvent.WaitOne();
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
