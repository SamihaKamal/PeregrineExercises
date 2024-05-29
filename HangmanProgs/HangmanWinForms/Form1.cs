using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HangmanWinForms
{
    public partial class Form1 : Form
    {
        
        string contents = "";
        List<String> a = new List<string>();
        List<char> rightCharacters = new List<char>();
        List<char> wrongCharacters = new List<char>();
        List<char> usedCharacters = new List<char>();
        int guesses = 0;
        int count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void displayResult(List<String> a, int b)
        {
            var li = a[b];
            var searchedWord = li.ToLower();
            
            char[] result = new char[searchedWord.Length];
            for (int i = 0; i < searchedWord.Length; i++)
            {
                result[i] = '-';
            }

            for (int i = 0; i < searchedWord.Length; i++)
            {
                if (rightCharacters.Contains(searchedWord[i]))
                {
                    result[i] = searchedWord[i];
                }
            }
            label1.Text = new String(result);

            if (new String(result) == searchedWord)
            {
                label2.Text = $"Congratulations! You've found the word: {searchedWord}";
                count++;
                guesses = 0;
                usedCharacters.Clear();
                rightCharacters.Clear();
                wrongCharacters.Clear();
                displayResult(a, count);
                
            }

            if(guesses == 8)
            {
                label2.Text = $"You've run out of guesses for the previous word! It was {searchedWord}. Better luck next time.";
                count++;
                guesses = 0;
                usedCharacters.Clear();
                rightCharacters.Clear();
                wrongCharacters.Clear();
                displayResult(a, count);
            }
            displayCharacters();
        }

        private void displayCharacters()
        {
            label5.Text = "Right characters: " + string.Join(" ", rightCharacters);
            label6.Text = "Wrong characters: " + string.Join(" ", wrongCharacters);
            label7.Text = "Used characters: " + string.Join(" ", usedCharacters);
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string path = @"Files/word.txt";
                using (var sr = new StreamReader(path))
                {
                    contents = sr.ReadToEnd();
                }
            }
            catch (IOException)
            {
                Console.WriteLine("The file could not be read: ");
              
                return;
            }

            var words = contents.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            foreach(var word in words)
            {
                a.Add(word);
            }

            usedCharacters.Clear();
            rightCharacters.Clear();
            wrongCharacters.Clear();

            displayResult(a, count);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var searchedWord = a[count].ToLower();

            var userInput = char.Parse(textBox1.Text.ToLower());

            if (usedCharacters.Contains(userInput))
            {
                label2.Text = "You already used this letter. Try a different one.";

            }

            usedCharacters.Add(userInput);

            if (searchedWord.Contains(userInput))
            {
                label2.Text = "Letter found!";
                rightCharacters.Add(userInput);
            }
            else
            {
                guesses++;
                wrongCharacters.Add(userInput);
                label3.Text= "Letter not found!";
                label3.Text= $"You have {guesses}/8 guesses left";
            }


            displayResult(a, count);
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
