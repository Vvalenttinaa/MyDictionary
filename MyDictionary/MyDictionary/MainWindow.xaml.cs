using MyDictionary.Model;
using MyDictionary.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace MyDictionary
{
    
    public partial class MainWindow : Window
    {
        List<Word> wordList;
        Random r = new Random();
        int max;

        Timer timer = new Timer(5000);
        MySqlWord mySqlWord = new MySqlWord();



        public MainWindow()
        {
            InitializeComponent();

            MySqlWord mySqlWord = new MySqlWord();
            wordList = mySqlWord.LoadData();
            foreach (Word word in wordList)
            {
                if (word.Idiom == false)
                {
                    lbVocabulary.Items.Add(word);
                }
                else
                {
                    lbIdioms.Items.Add(word);
                }
            }
            cbLetters.Items.Add("ABC...");
            for (char c = 'A'; c <= 'Z'; c++)
            {
                cbLetters.Items.Add(c);
            }

            max = wordList.Count;

            while (lbWordOfDay.Content == null || lbIdiomOfDay.Content == null)
            {
                int index = r.Next(max);
                Word word = wordList.ElementAt(index);
                if (lbWordOfDay.Content == null && word.Idiom == false)
                {
                    lbWordOfDay.Content = word.Content + "\n-\n" + word.Translation;
                }
                else if(lbIdiomOfDay.Content == null && word.Idiom != false)
                {
                    lbIdiomOfDay.Content = word.Content + "\n-\n" + word.Translation;
                }
            }

            timer.Elapsed += OnTimerElapsed;
            timer.Start();

            foreach (Word item in wordList)
            {
                item.HeartButtonClick += HandleHeartButtonClick;
                item.DeleteButtonClick += HandleDeleteButtonClick;
            }


        }

        private void HandleHeartButtonClick(object sender, int id)
        {
            MessageBox.Show($"Heart button clicked for item with ID: {id}");
        }

        private void HandleDeleteButtonClick(object sender, int id)
        {
            MessageBox.Show($"Delete button clicked for item with ID: {id}");
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                NextWord();
                NextIdiom();
            });

        }

        private void NextWord()
        {
            while (true)
            {
                int index = r.Next(max);
                Word word = wordList.ElementAt(index);
                if (word.Idiom == false)
                {
                    lbWordOfDay.Content = word.Content + "\n-\n" + word.Translation;
                    break;
                }
            }
        }

        private void NextIdiom()
        {
            while (true)
            {
                int index = r.Next(max);
                Word word = wordList.ElementAt(index);
                if (word.Idiom == true)
                {
                    lbIdiomOfDay.Content = word.Content + "\n-\n" + word.Translation;
                    break;
                }
            }
        }


        private void Sort(object sender, SelectionChangedEventArgs e)
        {
            if (cbLetters.SelectedItem != null)
            {
                string? s = cbLetters.SelectedItem.ToString();
                if (s.Length > 1)
                {
                    foreach (Word word in wordList)
                    {
                        if (word.Idiom == false)
                        {
                            lbVocabulary.Items.Add(word);
                        }
                    }
                }
                else
                {
                    lbVocabulary.Items.Clear();
                    char c = s.ElementAt(0);
                    foreach (Word word in wordList)
                    {
                        if (word.Idiom == false)
                        {
                            if (c == word.Content.ElementAt(0) || char.ToLower(c) == word.Content.ElementAt(0))
                            {
                                lbVocabulary.Items.Add(word);
                            }
                        }

                    }
                }
            }
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            foreach (Word word in wordList)
            {
                if (word.Content.ToUpper().Equals(tbSearch.Text.ToUpper()))
                {
                    Search search = new Search(word);
                    search.Show();

                }
            }
        }

        private void HeartButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
           
            if (button != null)
            {
              

                Image image = null;

                foreach (var element in ((StackPanel)button.Content).Children)
                {
                    if (element is Image)
                    {
                        image = element as Image;
                        break;
                    }
                }

                if (image != null && button.DataContext  is Word word)
                    
                {
                    if (image.Source.ToString().Contains("EmptyHeart.jpg"))
                    {
                        image.Source = new BitmapImage(new Uri("/RedHeart.png", UriKind.Relative));
                        mySqlWord.UpdateLiked(word.Id, true);
                        ToLearn.words.Add(word);

                    }
                    else
                    {
                        image.Source = new BitmapImage(new Uri("/EmptyHeart.jpg", UriKind.Relative));
                        mySqlWord.UpdateLiked(word.Id, false);
                    }
                }
            }
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button != null)
            {
                Image image = null;

                foreach (var element in ((StackPanel)button.Content).Children)
                {
                    if (element is Image)
                    {
                        image = element as Image;
                        break;
                    }
                }

                if (image != null)
                {
                    if (image.Source.ToString().Contains("Delete.jpg") && button.DataContext is Word word)
                    {
                        mySqlWord.UpdateDeleted(word.Id, true);
                        image.Source = new BitmapImage(new Uri("/Done.png", UriKind.Relative));
                    }

                }
            }
        }

        private void StartLearning(object sender, RoutedEventArgs e)
        {
            ToLearn toLearn = new ToLearn();
            toLearn.Show();
        }

        private void Search(object sender, DragEventArgs e)
        {
            foreach (Word word in wordList)
            {
                if (word.Content.ToUpper().Equals(tbSearch.Text.ToUpper()))
                {
                    Search search = new Search(word);
                    search.Show();

                }
            }
        }
    }
}
