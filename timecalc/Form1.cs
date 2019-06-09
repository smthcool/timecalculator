using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace timecalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            Pen p = new Pen(Color.Black, 2);
            Point p1 = new Point(0, 100);
            Point p2 = new Point(900, 100);
            gr.DrawLine(p, p1, p2);
            gr.Dispose();
        }

        private void button1_Click(object sender, EventArgs e) //Конвертация 
        {
            double result = 0;
            string path = @"c:\test\logfinal.txt";
            string input = textBox1.Text; //Проверка строки на ввод числа
            string input2 = textBox2.Text;
            string input3 = textBox3.Text;
            double h, m, s;
            if ((string.IsNullOrEmpty(input) && string.IsNullOrEmpty(input2)) && string.IsNullOrEmpty(input3))
            {
                MessageBox.Show("Ошибка! Не введены данные для конвертации!" + "\n\n");
                System.IO.File.AppendAllText(path, "Ошибка! Не введены данные для конвертации!" + "\n\n");
                return;
            }
            
            if (string.IsNullOrEmpty(input) && string.IsNullOrEmpty(input2)) // Если не введены часы и минуты
            {
                h = 0;
                m = 0;
                s = double.Parse(textBox3.Text);
            }
            else
            if (string.IsNullOrEmpty(input) && string.IsNullOrEmpty(input3)) // Если не введены часы и секунды
            {
                h = 0;
                m = double.Parse(textBox2.Text);
                s = 0;
            }
            else
            if (string.IsNullOrEmpty(input2) && string.IsNullOrEmpty(input3)) // Если не введены минуты и секунды
            {
                h = double.Parse(textBox1.Text);
                m = 0;
                s = 0;
            }
            else
            if (string.IsNullOrEmpty(input))//Поддержка ввода только некоторых единиц времени(можно не заполнять все поля и получать результат)
            {
                h = 0;
                m = double.Parse(textBox2.Text);
                s = double.Parse(textBox3.Text);
            }
            else
            if (string.IsNullOrEmpty(input2))
            {
                m = 0;
                h = double.Parse(textBox1.Text);
                s = double.Parse(textBox3.Text);
            }
            else
            if (string.IsNullOrEmpty(input3))
            {
                s = 0;
                h = double.Parse(textBox1.Text);
                m = double.Parse(textBox2.Text);
            }
           
            else
            {
                h = double.Parse(textBox1.Text);
                m = double.Parse(textBox2.Text);
                s = double.Parse(textBox3.Text);
            }

            if (h < 0 || m < 0 || s < 0)
            {
                MessageBox.Show("Ошибка! Введённое число не может быть отрицательным!");
                System.IO.File.AppendAllText(path, "Ошибка! Введённое число не может быть отрицательным!" + "\n\n");
            }
            else
            if ((comboBox1.Text == "Выберите формат конвератции"))
            {
                MessageBox.Show("Ошибка! Не выбран формат конвертации");
                System.IO.File.AppendAllText(path, "Ошибка! Не выбран формат конвертации");
            }
            else
            if ((comboBox1.Text == "Часы"))
            {
                result = h + m / 60 + s / 3600;
                textBox4.Text = result.ToString() + " Часов";
                System.IO.File.AppendAllText(path, "Выполнена конвертация в часы. Результат: " + textBox4.Text + "\n\n");
            }
            else
            if ((comboBox1.Text == "Минуты"))
            {
                result = h * 60 + m + s / 60;
                textBox4.Text = result.ToString() + " Минут";
                System.IO.File.AppendAllText(path, "Выполнена конвертация в минуты. Результат: " + textBox4.Text + "\n\n");
            }
            else
            if ((comboBox1.Text == "Секунды"))
            {
                result = h * 3060 + m * 60 + s;
                textBox4.Text = result.ToString() + " Секунд";
                System.IO.File.AppendAllText(path, "Выполнена конвертация в секунды. Результат: " + textBox4.Text + "\n\n");
            }

        }
        private void button4_Click(object sender, EventArgs e) //Секция вычислений
        {
            int hrs, mins, sec;
            string path = @"c:\test\logfinal.txt";
            string inputh1 = textBox5.Text; //Проверка строки на ввод числа
            string inputm1 = textBox6.Text;
            string inputs1 = textBox7.Text;
            string inputh2 = textBox10.Text;
            string inputm2 = textBox9.Text;
            string inputs2 = textBox8.Text;

            if (string.IsNullOrEmpty(inputh1) || string.IsNullOrEmpty(inputm1) || string.IsNullOrEmpty(inputs1) || string.IsNullOrEmpty(inputh2) || string.IsNullOrEmpty(inputm2) || string.IsNullOrEmpty(inputs2))
            {
                MessageBox.Show("Ошибка! Не все поля заполнены!");
                System.IO.File.AppendAllText(path, "Ошибка! Не все поля заполнены!" + "\n\n");
                return;
            }
                int h1 = Int32.Parse(inputh1);
                int m1 = Int32.Parse(inputm1);
                int s1 = Int32.Parse(inputs1);
                int h2 = Int32.Parse(inputh2);
                int m2 = Int32.Parse(inputm2);
                int s2 = Int32.Parse(inputs2);

            if (radioButton1.Checked)
            {
                hrs = h1 + h2;
                mins = m1 + m2;
                sec = s1 + s2;
                if (sec > 60)
                {
                    mins = mins + sec / 60;
                    sec = sec % 60;
                }
                if (mins >= 60)
                {
                    hrs = hrs + mins / 60;
                    mins = mins % 60;
                }
                
               
                    textBox11.Text = hrs.ToString() + " Часов " + mins.ToString() + " Минут " + sec.ToString() + " Секунд ";
                    System.IO.File.AppendAllText(path, "Выполнено сложение. Результат: " + textBox11.Text + "\n\n");
                
            }
            else
                if (radioButton2.Checked)
            {
                    hrs = h1 - h2;
                    mins = m1 - m2;
                    sec = s1 - s2;
                do
                {
                    mins = mins - 1;
                    sec = sec + 60;
                } while (sec < 0);

                do
                {
                    hrs = hrs - 1;
                    mins = mins + 60;
                } while (mins < 0);
                
                do
                {
                    mins = mins + 1;
                    sec = sec - 60;
                } while (sec >= 60);
                do
                {
                    hrs = hrs + 1;
                    mins = mins - 60;
                } while (mins >= 60);

                if (hrs < 0) //Проверяем, чтобы второй временной отрезок был меньше времени и не получался отрицательный ответ
                {
                    MessageBox.Show("Ошибка! Второй промежуток больше первого. Проверьте введённые значения!");
                    System.IO.File.AppendAllText(path, "Ошибка! Второй промежуток больше первого. Проверьте введённые значения!" + "\n\n");
                }
                else
                if (sec < 0)
                {
                    MessageBox.Show("Ошибка! Второй промежуток больше первого. Проверьте введённые значения!");
                    System.IO.File.AppendAllText(path, "Ошибка! Второй промежуток больше первого. Проверьте введённые значения!" + "\n\n");
                }
                else
                if (mins < 0)
                {
                    MessageBox.Show("Ошибка! Второй промежуток больше первого. Проверьте введённые значения!");
                    System.IO.File.AppendAllText(path, "Ошибка! Второй промежуток больше первого. Проверьте введённые значения!" + "\n\n");
                }
                else
                if (h1 < 0 || m1 < 0 || s1 < 0 || h2 < 0 || m2 < 0 || s2 < 0) //Проверяем введённое число на знак, не даём вводить отрицательные числа
                {
                    MessageBox.Show("Ошибка! Введённое число не может быть отрицательным!");
                    System.IO.File.AppendAllText(path, "Ошибка! Введённое число не может быть отрицательным!" + "\n\n");
                }
                else
                {
                    textBox11.Text = hrs.ToString() + " Часов " + mins.ToString() + " Минут " + sec.ToString() + " Секунд ";
                    System.IO.File.AppendAllText(path, "Выполнено вычитание. Результат: " + textBox11.Text + "\n\n");
                }
            }
        }
        //Лог
        private void button2_Click(object sender, EventArgs e)
        {
            string path = @"c:\test\logfinal.txt";
            System.IO.File.ReadAllText(path);
            richTextBox1.Text = File.ReadAllText(path);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string path = @"c:\test\logfinal.txt";
            File.WriteAllText(path, "");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string path = @"c:\test\logfinal.txt";
            Process.Start(path);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                // цифра
                return;
            }
            if (e.KeyChar == '.')
            {
                // точку заменим запятой
                e.KeyChar = ',';
            }
            if (e.KeyChar == ',')
            {
                if (textBox1.Text.IndexOf(',') != -1)
                {
                    // запятая уже есть в поле редактирования
                    e.Handled = true;
                }
                return;
            }
            if (Char.IsControl(e.KeyChar)) //Разрешаем использовать backspace
            {
                return;
            }
            // остальные символы и кнопки, которые не требуеются в работе запрещены
            e.Handled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var item in this.Controls) //обходим все элементы формы
            {
                if (item is TextBox) // проверяем, является ли элемент текстбоксом 
                    ((TextBox)item).KeyPress += textBox1_KeyPress; //приводим к типу и устанавливаем обработчик события  
                }
            }
        }
    }
