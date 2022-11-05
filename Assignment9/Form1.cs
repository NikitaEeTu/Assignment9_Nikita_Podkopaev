using System.Diagnostics;

namespace Assignment9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;

            string[] words = text.Split(' ');

            Dictionary<char, int> letterNumberOccurencies = countTheCharacters(words);

            giveTheFormattedString(letterNumberOccurencies, textBox2);

        }

        private Dictionary<char, int> countTheCharacters(string[] arrOfWords)
        {
            Dictionary<char, int> letterOccurenciesInTheText = new Dictionary<char, int>();

            foreach (string word in arrOfWords)
            {
                foreach (char letter in word)
                {
                    Char letterLowerCase = Char.ToLower(letter);

                    if (letterOccurenciesInTheText.ContainsKey(letterLowerCase))
                    {
                        int numberOfOccurencies = letterOccurenciesInTheText[letterLowerCase];
                        numberOfOccurencies += 1;
                        letterOccurenciesInTheText[letterLowerCase] = numberOfOccurencies;
                    }
                    else
                    {
                        letterOccurenciesInTheText.Add(letterLowerCase, 1);
                    }
                }
            }
            return letterOccurenciesInTheText;
        }

        private void giveTheFormattedString(Dictionary<char, int> letterNumberOccurencies, TextBox resultTextBox)
        {
            foreach (KeyValuePair<char, int> letter in letterNumberOccurencies)
            {
                String newLetterMessage = String.Format("Letter {0} has appeared in the text for {1} times", letter.Key, letter.Value);

                resultTextBox.AppendText(newLetterMessage);
                resultTextBox.AppendText(Environment.NewLine);
            }
        }

    }
}