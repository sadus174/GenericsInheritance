﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenericsInheritance
{
    public partial class Form1 : Form
    {
        class Users<T>
        {
            public T id;
            public string fio;
            public string passwd;

            public Users(T i, string f, string p)
            {
                id = i;
                fio = f;
                passwd = p;
            }

            public virtual void Display()
            {
                MessageBox.Show($"Код пользователя: {id.ToString()}, Имя пользователя {fio}, пароль пользователя {passwd}");
            }
        }

        class Admins<T> : Users<T>
        {
            public T id_admin;
            public string privilege;

            public Admins(T id_a, string priv, T i, string f, string p) : base (i, f, p)
            {
                id_admin = id_a;
                privilege = priv;
            }

            public override void Display()
            {
                MessageBox.Show($"Код системного администратора: {id_admin.ToString()}, Уровень прав: {privilege}, Имя пользователя {fio}, пароль пользователя {passwd}");
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Users<int> u1 = new Users<int>(1, "John Smith", "1qwerty234");
            u1.Display();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admins<int> a1 = new Admins<int>(1, "full", 2, "John Wick", "qwerty234");
            a1.Display();

            Users<int> a2 = new Admins<int>(2, "full", 3, "Frodo Beggins", "qw123erty");
            a2.Display();

        }
    }
}
