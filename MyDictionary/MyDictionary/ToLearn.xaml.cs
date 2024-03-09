using MyDictionary.Model;
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
using System.Windows.Shapes;

namespace MyDictionary
{ 
    public partial class ToLearn : Window
    {
        public static List<Word> words = new List<Word>();

        public ToLearn()
        {
            InitializeComponent();
            foreach(Word word in words)
            {
                lbToLearn.Items.Add(word);
            }
        }

        public void add(Word word)
        {
            words.Add(word);
        }
    }
}
