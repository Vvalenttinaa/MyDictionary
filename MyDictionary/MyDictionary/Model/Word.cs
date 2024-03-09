using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace MyDictionary.Model
{

    public class Word
    {
        public int Id;
        public string Content;
        public string Translation;
        public Boolean Idiom;
        public int NumTested;
        public int NumPass;
        public Boolean like;


        public event EventHandler<int> HeartButtonClick;
        public event EventHandler<int> DeleteButtonClick;

        // Methods to raise events
        public void RaiseHeartButtonClick()
        {
            HeartButtonClick?.Invoke(this, Id);
        }

        public void RaiseDeleteButtonClick()
        {
            DeleteButtonClick?.Invoke(this, Id);
        }

        public override string? ToString()
        {
            return  Content + " - " + Translation;
        }

        
    }
}
