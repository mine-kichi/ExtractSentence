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

namespace ExtractSentence
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // OpenFileDialogオブジェクトの生成
            OpenFileDialog od = new OpenFileDialog();
            od.Title = "ファイルを開く";  //ダイアログ名
            od.FileName = @"sample.txt";  //初期選択ファイル名
            od.Filter = "ログファイル(*.txt;*.log)|*.txt;*.log|すべてのファイル(*.*)|*.*";  //選択できる拡張子
            od.FilterIndex = 1;  //初期の拡張子

            // ダイアログを表示する
            DialogResult result = od.ShowDialog();


            // 選択後の判定
            if (result == DialogResult.OK)
            {
                //「開く」ボタンクリック時の処理
                string fileName = od.FileName;  //これで選択したファイルパスを取得できる
                textBox1.Text = fileName;
            }
            else if (result == DialogResult.Cancel)
            {
                //「キャンセル」ボタンクリック時の処理
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string inputFilePath = textBox1.Text;
            string outputFilePath = @"D:\work\test.txt";
            string searchString = textBox2.Text;
            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine("指定されたファイルが存在しません。");
                return;
            }

            var matchedLines = File.ReadAllLines(inputFilePath)
                                   .Where(line => line.Contains(searchString))
                                   .ToList();

            File.AppendAllLines(outputFilePath, matchedLines);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
