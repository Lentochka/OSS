using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using Microsoft.Win32;

namespace L_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Raschet_Click(object sender, RoutedEventArgs e)
        {
            ArrayList myAL = new ArrayList();
            int index;
            try
            {
                int itemCount = Convert.ToInt32(textBox1.Text);
                Random rnd1 = new Random();
                int number;
                int[] mass = new int[itemCount];
                listBox1.Items.Clear();
                for (index = 1; index <= itemCount; index++)
                {
                    number = -100 + rnd1.Next(200);
                    mass[index - 1] = number;
                    myAL.Add(number);
                    listBox1.Items.Add(number);
                }
                if (itemCount > 2)
                {
                    /*Вычисление количества больших своих соседей*/
                    int count = 0;
                    listBox1.Items.Add("Количсетво чисел больших своих соседей:");
                    for (index = 1; index < itemCount - 1; index++)
                    {
                        if (mass[index] > mass[index - 1] && mass[index] > mass[index + 1])
                        {
                            count++;
                        }
                    }
                    listBox1.Items.Add(count);
                    /*Нахождение номера первого элемента>25*/
                    int num25 = 0, account = 0, sum = 0;
                    for (index = 0; index < itemCount; index++)
                    {
                        if (account == 0 && mass[index] > 25)
                        {
                            num25 = index;
                            account = 1;
                        }
                        /*Сумма элементов,больших 2 элемента*/
                        if (mass[index] > mass[1])
                        {
                            sum = sum + mass[index];
                        }
                    }
                    if (account == 0)
                    {
                        listBox1.Items.Add("Нет элементов>25");
                        listBox1.Items.Add(num25 + 1);
                    }
                    else
                    {
                        listBox1.Items.Add("Номер первого элемента>25");
                        listBox1.Items.Add(num25 + 1);
                    }
                    listBox1.Items.Add("Сумма элементов > 2 элемента");
                    listBox1.Items.Add(sum);
                }
            }
            catch
            {
                textBox1.Clear();
                MessageBox.Show("Данные введены неверно!");

            }
        }

        private void Raschet2_Click(object sender, RoutedEventArgs e)
        {
            ArrayList myAL = new ArrayList();
            int index;
            try
            {
                int itemCount = Convert.ToInt32(textBox1.Text);
                Random rnd1 = new Random();
                int number;
                listBox1.Items.Clear();
                listBox1.Items.Add("Исходный массив");
                for (index = 1; index <= itemCount; index++)
                {
                    number = -100 + rnd1.Next(200);
                    myAL.Add(number);
                    listBox1.Items.Add(number);
                }
                myAL.Sort();
                listBox1.Items.Add("Отсортированный массив");
                foreach (int elem in myAL)
                {
                    listBox1.Items.Add(elem);
                }
            }
            catch
            {
                textBox1.Clear();
                MessageBox.Show("Данные введены неверно!");
            }
        }

        private void Soxranit_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog myDialog = new SaveFileDialog();
            myDialog.Filter = "Текст(*.TXT)|*.TXT" + "|Все файлы (*.*)|*.* ";

            if (myDialog.ShowDialog() == true)
            {
                string filename = myDialog.FileName;
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename, false))
                {
                    foreach (Object item in listBox1.Items)
                    {
                        file.WriteLine(item);
                    }
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
