using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.IO;

namespace Mod12_Homework
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

        async private void btnWriteFile_Click(object sender, RoutedEventArgs e)
        {
            await WriteFileAsync();
        }

        async private void btnReadFile_Click(object sender, RoutedEventArgs e)
        {
            await ReadFileAsync();
        }

        async public Task WriteFileAsync()
        {
            string filePath = @"SampleFile.txt";
            string text = txtContents.Text;

            await WriteTextAsync(filePath, text);
        }

        async private Task WriteTextAsync(string filePath, string text)
        {
            byte[] encodedText = Encoding.Unicode.GetBytes(text);

            using (FileStream sourceStream = new FileStream(filePath,
                FileMode.Append, FileAccess.Write, FileShare.None,
                bufferSize: 4096, useAsync: true))
            {
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
            };
        }

        async public Task ReadFileAsync()
        {
            string filePath = @"SampleFile.txt";

            if (File.Exists(filePath) == false)
            {
                MessageBox.Show(filePath + " not found", "File Error", MessageBoxButton.OK);
            }
            else
            {
                try
                {
                    string text = await ReadText(filePath);
                    txtContents.Text = text;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        async Task<string> ReadText(string filePath)
        {
            using (FileStream sourceStream = new FileStream(filePath,
                FileMode.Open, FileAccess.Read, FileShare.Read,
                bufferSize: 4096, useAsync: true))
            {
                StringBuilder sb = new StringBuilder();

                byte[] buffer = new byte[0x1000];
                int numRead;
                while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    string text = Encoding.Unicode.GetString(buffer, 0, numRead);
                    sb.Append(text);
                }

                return sb.ToString();
            }
        }


    }
}
