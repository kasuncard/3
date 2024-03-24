using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        class users
        {
            public int id;
            public string last_name;
            public string name;
            public string patronymic;
            public string mail;
            public users(int id, string last_name, string name, string patronymic, string mail)
            {
                this.id = id;
                this.last_name = last_name;
                this.mail = mail;
                this.name = name;
                this.patronymic = patronymic;
            }
        }

        string delete_sub(string s)
        {
            string s1="";
            if (s.Length!=0)
                if (s[0]!=' ')
                    s1 += s[0];
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == ' ' && s[i - 1] != ' ')
                    s1 += s[i];
                if (s[i] != ' ')
                    s1 += s[i];
            }
            if (s1.Length!=0)
                if (s1[s1.Length - 1] == ' ')
                    s1=s1.Remove(s1.Length - 1);
            return s1;
        }

        List<users> test = new List<users>();
        public Form1()
        {
            InitializeComponent();
            users user1 = new users(1, "Иванов", "Александр", "Сергеевич", "ias@mail.ru");
            users user2 = new users(2, "Иванова", "Александра", "Сергеевна", "iac@mail.ru");
            users user3 = new users(3, "Привалов", "Александр", "Павлович", "pap@mail.ru");
            users user4 = new users(4, "Петров", "Иван", "Андреевич", "pia@mail.ru");
            users user5 = new users(5, "Иванов", "Александр", "Сергеевич", "nas@mail.ru");
            users user6 = new users(6, "Кожемятько", "Тамара", "Павловна", "ktp@mail.ru");
            test.Add(user1); test.Add(user2); test.Add(user3); test.Add(user4); test.Add(user5); test.Add(user6);
            for (int i=0; i<6; i++)
            {
                label1.Text += test[i].last_name+' '+test[i].name+' '+test[i].patronymic+' '+test[i].mail+ '\n';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            string s = delete_sub(textBox1.Text);
            if (s.Length>0)
            {
                string[] tokens=s.Split(' ');
                List<users> answer = new List<users>();
                if (tokens.Length == 3)
                {
                    for (int i = 0; i < test.Count; i++)
                    {
                        if ((test[i].last_name == tokens[0] && test[i].name == tokens[1] && test[i].patronymic == tokens[2])
                            || (test[i].last_name == tokens[2] && test[i].name == tokens[0] && test[i].patronymic == tokens[1]))
                            answer.Add(test[i]);
                    }
                }
                else if (tokens.Length == 2)
                {
                    for (int i = 0; i < test.Count; i++)
                    {
                        if ((test[i].last_name == tokens[0] && test[i].name == tokens[1])
                            || (test[i].last_name == tokens[1] && test[i].name == tokens[0]))
                            answer.Add(test[i]);
                    }
                }
                else if (tokens.Length == 1)
                {
                    for (int i = 0; i < test.Count; i++)
                    {
                        if (test[i].last_name.Contains(tokens[0]) || test[i].name.Contains(tokens[0])
                            || test[i].patronymic.Contains(tokens[0]))
                            answer.Add(test[i]);
                    }
                }
                else
                    label2.Text += "Количество строк в строке слишком велико!";
                if (answer.Count != 0)
                {
                    for (int i = 0; i < answer.Count(); i++)
                        label2.Text += answer[i].id + "." + answer[i].last_name + ' ' + answer[i].name + ' ' + answer[i].patronymic + ' ' + answer[i].mail + '\n';
                }
                else
                {
                    label2.Text += "По Вашему запросу ничего не найдено";
                }
            }
            else
                label2.Text = "Введите непустую строку!";
        }
    }
}
