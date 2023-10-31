using GoodAuthorization.Models;
using Microsoft.Data.SqlClient;
using qwewr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.IO;
using SkiaSharp;
using System.Windows.Media;

namespace GoodAuthorization
{
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source = DESKTOP-CDGDDSG\MSSQLSERVER01; Initial Catalog = badDataBase; Integrated Security=True");
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
            InitializeComponent();
            object wantedNode = this.FindName("TextBox1");
            if (wantedNode is TextBox)
            {
                TextBox wantedChild = wantedNode as TextBox;
                textBox = wantedChild;
            }
            object wantedNodeImage = this.FindName("ulitimage");
            if (wantedNodeImage is Image)
            {
                Image wantedChild = wantedNodeImage as Image;
                getImage = wantedChild;
            }
            object wanted = this.FindName("ThirdBox");
            if (wanted is TextBox)
            {
                TextBox wantedChild = wanted as TextBox;
                Text12 = wantedChild;
            }
            object wantedDot = this.FindName("TextBox2");
            if (wantedNode is TextBox)
            {
                TextBox wantedChild = wantedDot as TextBox;
                textBox1 = wantedChild;
            }
            object wantedDotNew = this.FindName("warmingCapa");
            if (wantedDotNew is TextBlock)
            {
                TextBlock wantedChild = wantedDotNew as TextBlock;
                textBox2 = wantedChild;
            }
            imageBase64 = new string[1000];
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("SELECT capcha, text FROM kapchaTable", sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                int i3 = 0;
                while (reader.Read())
                {
                    object name = reader.GetValue(0);
                    imageBase64[i3] = Convert.ToString(name);
                    object price = reader.GetValue(1);
                    i3++;
                }
            }
            reader.Close();
            int[] array = { 1, 2, 3, 4, 5, 6 };
            int repeatCount = 3;
            int length = array.Length;
            for (int i = repeatCount; i < length; i++)
            {
                array[i] = array[i % repeatCount];
            }
        }
        static int[] BogoSort(int[] a)
        {
            while (!IsSorted(a))
                a = RandomPermutation(a);
            return a;
        }
        private void Buuton1_Click(object sender, RoutedEventArgs e)
        {
            string qreg = textBox1.Text;
            try
            {
                if (String.IsNullOrEmpty(qreg))
                { }
                else if (qreg.Length < 5)
                {
                    _ = ((short)MessageBox.Show("Длина пароля должны быть больше пяти"));
                    return;
                }
            }
            catch
            {
                _ = ((short)MessageBox.Show("エラー"));
                проверить_капча();
            }
            finally
            {   }
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
                int[] ints1 = BogoSort(result);
                string s = ints1.Aggregate(string.Empty, (s, i) => s + i);
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
                        _ = ((short)MessageBox.Show("エラー"));
                        проверить_капча();
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
                    int[] ints11 = BogoSort(result1);
                    string s1 = ints11.Aggregate(string.Empty, (s, i) => s + i);
                    string _2 = randomTable.случай_база.UserTable.Where(w => w.Logun == textBox.Text).Select(S => S.Parol).ToList()[0].ToString();
                    try
                    {
                        if (String.IsNullOrEmpty(parol))
                        {
                            MessageBox.Show("Необходимо ввести пароль");
                        }
                        else if (_2.Replace(" ", "") == s1)
                        {
                            MessageBox.Show("成功");
                            проверить_капча();
                        }
                    }
                    catch
                    {
                        _ = ((short)MessageBox.Show("エラー"));
                        проверить_капча();
                    }
                }
            }
            catch
            {
                _ = ((short)MessageBox.Show("エラー"));
                проверить_капча();
            }
        }
        private int[] digits(int[] ints)
        {
            throw new NotImplementedException();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow frm = new MainWindow();
            frm.Show();
            form1.Hide();
        }
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow frm = new MainWindow(); frm.Show();
            form1.Hide();
        }
        static bool IsSorted(int[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                if (a[i] > a[i + 1])
                    return false;
            }
            return true;
        }
        static int[] RandomPermutation(int[] a)
        {
            Random random = new Random();
            var n = a.Length;
            while (n > 1)
            {
                n--;
                var i = random.Next(n + 1);
                var temp = a[i];
                a[i] = a[n];
                a[n] = temp;
            }
            return a;
        }
        public void проверить_капча()
        {
            textBox2.Text = "Введите капчу в третье поле";
        }
        private ImageSource ConvertBase64ToImage2(MemoryStream memoryStream)
        {
            throw new NotImplementedException();
        }
        private ImageSource ConvertBase64ToImage(MemoryStream memoryStream)
        {
            throw new NotImplementedException();
        }
        public SKBitmap ConvertBase64ToImage2(string base64String)
        {
            byte[] imageBytes = System.Convert.FromBase64String(base64String);

            using (var stream = new SKMemoryStream(imageBytes))
            {
                using (var codec = SKCodec.Create(stream))
                {
                    var info = codec.Info;
                    var bitmap = new SKBitmap(info.Width, info.Height);
                    codec.GetPixels(bitmap.Info, bitmap.GetPixels());
                    return bitmap.Copy();
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Text12.Text == "0479      ".Replace(" ", ""))
                return;
            else if (Text12.Text == "2411      ".Replace(" ", ""))
                return;
            else if (Text12.Text == "8930      ".Replace(" ", ""))
                return;
            else if (Text12.Text == "7273      ".Replace(" ", ""))
                return;
            else if (Text12.Text == "7273      ".Replace(" ", ""))
                return;
            else if (Text12.Text == "7273      ".Replace(" ", ""))
                return;
            else if (Text12.Text == "4382      ".Replace(" ", ""))
                return;
            else if (Text12.Text == "7948      ".Replace(" ", ""))
                return;
            else if (Text12.Text == "5395      ".Replace(" ", ""))
                return;
            else if (Text12.Text == "8650      ".Replace(" ", ""))
                return;
            else if (Text12.Text == "9169      ".Replace(" ", ""))
                return;
            else if (Text12.Text == "4811      ".Replace(" ", ""))
                return;
            else if (Text12.Text == "1954      ".Replace(" ", ""))
                return;
            else if (Text12.Text == "3801      ".Replace(" ", ""))
                return;
            else if (Text12.Text == "9369      ".Replace(" ", ""))
                return;
            else
                this.Close();
        }
        public SKBitmap ConvertBase64ToImage(string base64String)
        {
            byte[] imageBytes = System.Convert.FromBase64String(base64String);

            using (SKBitmap bitmap = SKBitmap.Decode(imageBytes))
                return bitmap.Copy();
        }
    }
}
