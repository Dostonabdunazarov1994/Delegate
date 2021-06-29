using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Лабораторная_3
{
    delegate void AccountHandler(string message);
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label3.Text = "";
            //timer1.Enabled = true;
            //timer1.Start();
        }
        
        Account acc;
        List<Account> list = new List<Account>();
        public void Display(string message)
        {
            MessageBox.Show(message, "Сообщение");
        }

        public void refresh()
        {
            listBox1.Items.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                listBox1.Items.Add(list[i].Fullinfo());
            }
            acc.RegisterHandler(Display);

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                acc = new Account(textBox1.Text);
                list.Add(acc);
                textBox1.Text = "";
                refresh();
            }
        }
        
        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Account a = null;
                for(int i = 0; i < list.Count; i++)
                {
                    if(listBox1.SelectedIndex == i)
                    {
                        a = list[i];
                    }
                }
                if(a != null)
                {
                    a.Put(int.Parse(textBox3.Text));
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (a.Name == list[i].Name)
                            list[i] = a;
                    }
                }
                textBox3.Text = "";
                
                refresh();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Account a = null;
                for(int i =0; i < list.Count; i++)
                {
                    if (listBox1.SelectedIndex == i)
                    {
                        a = list[i];
                    }
                }
                if(a != null)
                {
                    a.Withdraw(int.Parse(textBox4.Text));
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (a.Name == list[i].Name)
                            list[i] = a;
                    }
                }
                textBox4.Text = "";
                refresh();
            }
        }
        double sum1 = 0;
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Account ac = null;
            if ((int)numericUpDown2.Value >= 2021)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (listBox1.SelectedIndex == i)
                    {
                        ac = list[i];
                        sum1 = ac.Sum;
                    }
                }
                int d = (int)numericUpDown2.Value - 2020;
                if (ac != null)
                {
                    for (int i = 0; i < d; i++)
                    {
                        ac.Sum += ac.Sum * 0.05;
                    }
                    label3.Text = $"К {numericUpDown2.Value} году счет {ac.Name}a будет составлять {ac.Sum:f3} p";
                    ac.Sum = sum1;
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
