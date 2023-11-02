using GoodAuthorization.Models;
using Microsoft.Data.SqlClient;
using qwewr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using SkiaSharp;
using System.Windows.Media.Imaging;
using System.IO;
using System.Diagnostics;
using Microsoft.VisualBasic;

namespace GoodAuthorization
{
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source = DESKTOP-CK5JL4S; Initial Catalog = GoodDB; Integrated Security=True;");
        TextBox fildForlogin,fildForPassword, fildForCaptha;
        TextBlock textBox3;
        Image imageForDisplayCaptha;


        string[] imageBase64;
        public bool ControlBox { get; private set; }
        public string Text { get; private set; }
        public MainWindow()
        {
            sqlConnection.Open();
            InitializeComponent();

            fildForlogin = this.FindName("fildForInputLogin") as TextBox;
            imageForDisplayCaptha = this.FindName("imageForCaptah") as Image;
            fildForCaptha = this.FindName("fildForInputCaptha") as TextBox;
            fildForPassword = this.FindName("fildForInputPassword") as TextBox;
            textBox3 = this.FindName("warmingCapa") as TextBlock;

            imageBase64 = new string[1000];

            SqlCommand sqlCommand = new SqlCommand("SELECT capcha, text FROM kapchaTable", sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                int i3 = 0;
                while (reader.Read())
                {
                    imageBase64[i3] = Convert.ToString(reader.GetValue(0));
                    i3++;
                }
            }

            reader.Close();

            imageForDisplayCaptha.Source = ConvertBase64ToImage(imageBase64[15]);
        }

        private void Buuton1_Click(object sender, RoutedEventArgs e)
        {
            string textBoxOne = fildForPassword.Text;

            if (textBoxOne.Length < 5)
            {
                MessageBox.Show("Длина пароля должны быть больше пяти");
                return;
            }
            else
            {
                MessageBox.Show("Ошибка1");
                textBox3.Text = "Введите капчу в третье поле";
            }

            try
            {
                string parol = fildForPassword.Text;
                char[] charFromParol = parol.ToCharArray();
               
                List<int> singleDigitNumbers = new List<int>();
          
                foreach (char ch in fildForPassword.Text) // превращает каждай символ из паролья, в его аналог из unicode, и записывает каждую циру по одному
                    foreach (char digitChar in ((int)ch).ToString())
                        singleDigitNumbers.Add(int.Parse(digitChar.ToString()));

                #region
                //foreach (int number in ints)
                //{
                //    string numberString = number.ToString();
                //    foreach (char digitChar in numberString)
                //    {
                //        singleDigitNumbers.Add(int.Parse(digitChar.ToString()));
                //    }
                //}
                #endregion

                int[] result = singleDigitNumbers.ToArray();

                Array.Sort(result);

                string s = result.Aggregate(string.Empty, (s, i) => s + i);

                if (randomTable.случай_база.UserTable.Where(w => w.Logun == fildForlogin.Text).Select(s => s.Logun).ToList().Count() == 0)
                {
                    try
                    {
                        UserTable task = new UserTable();
                        task.Logun = fildForlogin.Text;
                        task.Parol = s;
                        randomTable.случай_база.UserTable.Add(task);
                        randomTable.случай_база.SaveChanges();
                        return;
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка3");
                        textBox3.Text = "Введите капчу в третье поле";
                    }
                }
                else
                {
                    string parol1 = fildForPassword.Text;
                    char[] ar1 = parol1.ToCharArray();
                    
                    List<int> singleDigitNumbers1 = new List<int>();

                    foreach (char ch in charFromParol)
                        foreach (char digitChar in ((int)ch).ToString())
                            singleDigitNumbers1.Add(int.Parse(digitChar.ToString()));

                    #region
                    //foreach (int number in ints12)
                    //{
                    //    string numberString = number.ToString();
                    //    foreach (char digitChar in numberString)
                    //    {
                    //        int digit = int.Parse(digitChar.ToString());
                    //        singleDigitNumbers1.Add( int.Parse(digitChar.ToString()));
                    //    }
                    //}
                    #endregion

                    int[] result1 = singleDigitNumbers1.ToArray();

                    Array.Sort(result1);

                    string s1 = result1.Aggregate(string.Empty, (s, i) => s + i);

                    string _2 = randomTable.случай_база.UserTable.Where(w => w.Logun == fildForlogin.Text).Select(S => S.Parol).ToList()[0].ToString();
                    try
                    {
                        if (String.IsNullOrEmpty(parol))
                        {
                            MessageBox.Show("Необходимо ввести пароль");
                        }
                        else if (_2.Replace(" ", "") == s1)
                        {
                            MessageBox.Show("успех");
                            textBox3.Text = "Введите капчу в третье поле";
                        }
                    }
                    catch
                    {
                        MessageBox.Show("ошибка4");
                        textBox3.Text = "Введите капчу в третье поле";
                    }
                }
            }
            catch
            {
                MessageBox.Show("ошибка2");
                textBox3.Text = "Введите капчу в третье поле";
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public BitmapImage ConvertBase64ToImage(string base64String)
        {
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = new MemoryStream(Convert.FromBase64String(base64String));
            bi.EndInit();

            return bi;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] capthaNumber = { "0479", "2411", "8930", "4382", "7948", "5395", "8650", "9169", "4811", "1954", "3801", "9369" };

            if (Array.IndexOf(capthaNumber, fildForCaptha.Text.Replace(" ", "")) == -1)
                return;
        }
    }
}