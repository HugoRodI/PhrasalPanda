using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PhrasalPanda
{
    public partial class PhrasalPandaFrm : Form
    {
        string selectedVerbMeaning;
        List<string> verbMeaningOptions = new List<string>();
        PhrasalVerb askedPhrasalVerb;
        List<Button> verbMeaningOptionsButtons = new List<Button>();
        Game game;
        
        public PhrasalPandaFrm()
        {
            InitializeComponent();
            PopulateVerbMeaningOptionButtonList();
            game = new Game();

            DisplayLevel();
        }
        
        public void DisplayLevel()
        {
            askedPhrasalVerb = game.GetPhrasalVerb();
            verbMeaningOptions = game.GetVerbMeaningOptions();

            askedPhrasalVerbLabel.Text = askedPhrasalVerb.VerbName;

            for (int i = 0; i < verbMeaningOptionsButtons.Count; i++)
                verbMeaningOptionsButtons[i].Text = verbMeaningOptions[i];

            punctuationLabel.Text = game.GetPunctuation();
        }

        private void CheckAnswer()
        {
            if (SelectedMeaningIsCorrect())
            {
                game.IncreasePunctuation();
                game.IncreaseLevel();
                DisplayLevel();
            }
            else
                RemovePandaHeart();

            if (game.GameOver())
                GameOver();
        }

        private bool SelectedMeaningIsCorrect()
        {
            if (askedPhrasalVerb.VerbMeaning == selectedVerbMeaning)
                return true;
            return false;
        }

        private void GameOver()
        {
            MessageBox.Show("All lives has been wasted!");
            Close();
        }

        private void RemovePandaHeart()
        {
            if (pandaHeartBox3.Image != null)
                pandaHeartBox3.Image = null;
            else if (pandaHeartBox2.Image != null)
                pandaHeartBox2.Image = null;
            else if (pandaHeartBox1.Image != null)
                pandaHeartBox1.Image = null;
            else
                ;

            game.RemoveLive();
        }

        private void phrasalVerbMeaningButtonA_Click(object sender, EventArgs e)
        {
            selectedVerbMeaning = (sender as Button).Text;
            CheckAnswer();
        }

        private void phrasalVerbMeaningButtonB_Click(object sender, EventArgs e)
        {
            selectedVerbMeaning = (sender as Button).Text;
            CheckAnswer();
        }
        
        private void phrasalVerbMeaningButtonC_Click(object sender, EventArgs e)
        {
            selectedVerbMeaning = (sender as Button).Text;
            CheckAnswer();
        }

        private void phrasalVerbMeaningButtonD_Click(object sender, EventArgs e)
        {
            selectedVerbMeaning = (sender as Button).Text;
            CheckAnswer();
        }
        
        private void PopulateVerbMeaningOptionButtonList()
        {
            verbMeaningOptionsButtons.Add(phrasalVerbMeaningButtonA);
            verbMeaningOptionsButtons.Add(phrasalVerbMeaningButtonB);
            verbMeaningOptionsButtons.Add(phrasalVerbMeaningButtonC);
            verbMeaningOptionsButtons.Add(phrasalVerbMeaningButtonD);
        }

    }
}
