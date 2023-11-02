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

namespace GoodAuthorization
{
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source = DESKTOP-CDGDDSG\MSSQLSERVER01; Initial Catalog = GoodDB; Integrated Security=True;");
        TextBox textBox;
        TextBox textBox1, Text12;
        TextBlock textBox2;
        Image getImage;
        Random random = new Random();

        string[] imageBase64;
        public bool ControlBox { get; private set; }
        public string Text { get; private set; }
        public MainWindow()
        {
            sqlConnection.Open();
            InitializeComponent();

           

            textBox = this.FindName("TextBox1") as TextBox;
            getImage = this.FindName("ulitimage") as Image;
            Text12 = this.FindName("ThirdBox") as TextBox;
            textBox1 = this.FindName("TextBox2") as TextBox;
            textBox2 = this.FindName("warmingCapa") as TextBlock;

            

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
           
         
           // getImage.Source = new Uri("pack://applic");



        }

        private void Buuton1_Click(object sender, RoutedEventArgs e)
        {
            string qreg = textBox1.Text;
            try
            {
                
                if (qreg.Length < 5)
                {
                    _ = ((short)MessageBox.Show("Длина пароля должны быть больше пяти"));
                    return;
                }
            }
            catch
            {
                _ = ((short)MessageBox.Show("Ошибка"));
                textBox2.Text = "Введите капчу в третье поле";
            }
            finally
            { }
            try
            {
                string parol = textBox1.Text;
                char[] ar = parol.ToCharArray();
                int[] ints = new int[ar.Length];
                int i = 0;
                foreach (char q in ar)
                {
                    ints[i] = (int)q;
                    i++;
                }
                List<int> singleDigitNumbers = new List<int>();
                foreach (int number in ints)
                {
                    string numberString = number.ToString();
                    foreach (char digitChar in numberString)
                    {
                        int digit = int.Parse(digitChar.ToString());
                        singleDigitNumbers.Add(digit);
                    }
                }
                int[] result = singleDigitNumbers.ToArray();
                Array.Sort(result);

                string s = result.Aggregate(string.Empty, (s, i) => s + i);
                if (randomTable.случай_база.UserTable.Where(w => w.Logun == textBox.Text).Select(s => s.Logun).ToList().Count() == 0)
                {
                    try
                    {
                        UserTable task = new UserTable();
                        task.Logun = textBox.Text;
                        task.Parol = s;
                        randomTable.случай_база.UserTable.Add(task);
                        randomTable.случай_база.SaveChanges();
                        return;
                    }
                    catch
                    {
                        _ = ((short)MessageBox.Show("Ошибка3"));
                        textBox2.Text = "Введите капчу в третье поле";
                    }
                }
                else
                {
                    string parol1 = textBox1.Text;
                    char[] ar1 = parol1.ToCharArray();
                    int[] ints12 = new int[ar.Length];
                    int i1 = 0;
                    foreach (char q in ar)
                    {
                        ints12[i1] = (int)q;
                        i1++;
                    }
                    List<int> singleDigitNumbers1 = new List<int>();
                    foreach (int number in ints12)
                    {
                        string numberString = number.ToString();
                        foreach (char digitChar in numberString)
                        {
                            int digit = int.Parse(digitChar.ToString());
                            singleDigitNumbers1.Add(digit);
                        }
                    }
                    int[] result1 = singleDigitNumbers1.ToArray();

                    Array.Sort(result1);
                  
                    string s1 = result1.Aggregate(string.Empty, (s, i) => s + i);

                    string _2 = randomTable.случай_база.UserTable.Where(w => w.Logun == textBox.Text).Select(S => S.Parol).ToList()[0].ToString();
                    try
                    {
                        if (String.IsNullOrEmpty(parol))
                        {
                            MessageBox.Show("Необходимо ввести пароль");
                        }
                        else if (_2.Replace(" ", "") == s1)
                        {
                            MessageBox.Show("успех");
                            textBox2.Text = "Введите капчу в третье поле";
                        }
                    }
                    catch
                    {
                        _ = ((short)MessageBox.Show("ошибка1"));
                        textBox2.Text = "Введите капчу в третье поле";
                    }
                }
            }
            catch
            {
                _ = ((short)MessageBox.Show("ошибка2"));
                textBox2.Text = "Введите капчу в третье поле";
            }
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
      
        public System.Windows.Controls.Image ConvertBase64ToImage2(string base64String)
        {
        
    
            byte[] image = Convert.FromBase64String(base64String);


            return image;

            //using (var stream = new SKMemoryStream(imageBytes))
            //{
            //    using (var codec = SKCodec.Create(stream))
            //    {
            //        var info = codec.Info;
            //        SKBitmap bitmap = new SKBitmap(info.Width, info.Height);
            //        codec.GetPixels(bitmap.Info, bitmap.GetPixels());


                    
            //        return bitmap.Copy();
            //    }
            //}
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Text12.Text == "0479")
                return;
            else if (Text12.Text == "2411")
                return;
            else if (Text12.Text == "8930")
                return;
            else if (Text12.Text == "7273")
                return;
            else if (Text12.Text == "7273")
                return;
            else if (Text12.Text == "7273")
                return;
            else if (Text12.Text == "4382")
                return;
            else if (Text12.Text == "7948")
                return;
            else if (Text12.Text == "5395")
                return;
            else if (Text12.Text == "8650")
                return;
            else if (Text12.Text == "9169")
                return;
            else if (Text12.Text == "4811")
                return;
            else if (Text12.Text == "1954")
                return;
            else if (Text12.Text == "3801")
                return;
            else if (Text12.Text == "9369")
                return;
            else
                this.Close();
        }
        public SKBitmap ConvertBase64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);

            using (SKBitmap bitmap = SKBitmap.Decode(imageBytes))
                return bitmap.Copy();
        }
    }
}