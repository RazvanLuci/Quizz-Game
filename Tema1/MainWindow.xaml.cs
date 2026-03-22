using System.Collections.Generic;
using System.Windows;

namespace Tema1
{
    public class QuizItem
    {
        public string Question { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string CorrectAnswer { get; set; }
    }

    public partial class MainWindow : Window
    {
        List<QuizItem> listaMea = new List<QuizItem>();
        int indexCurent = 0;
        int scor = 0;

        public MainWindow()
        {
            InitializeComponent();
            IncarcaDatele();
            AfiseazaIntrebare();
        }

        private void IncarcaDatele()
        {
            listaMea.Add(new QuizItem { Question = "Care e capitala Frantei?", AnswerA = "Berlin", AnswerB = "Madrid", AnswerC = "Paris", AnswerD = "Roma", CorrectAnswer = "C" });
            listaMea.Add(new QuizItem { Question = "2 + 2 = ?", AnswerA = "3", AnswerB = "4", AnswerC = "5", AnswerD = "6", CorrectAnswer = "B" });
            listaMea.Add(new QuizItem { Question = "Care este cel mai mare ocean?", AnswerA = "Atlantic", AnswerB = "Indian", AnswerC = "Arctic", AnswerD = "Pacific", CorrectAnswer = "D" });
        }

        private void AfiseazaIntrebare()
        {
            if (indexCurent < listaMea.Count)
            {
                var q = listaMea[indexCurent];
                TextBlockIntrebare.Text = q.Question;
                rbA.Content = q.AnswerA;
                rbB.Content = q.AnswerB;
                rbC.Content = q.AnswerC;
                rbD.Content = q.AnswerD;
                rbA.IsChecked = rbB.IsChecked = rbC.IsChecked = rbD.IsChecked = false;
                pbProgres.Value = ((double)(indexCurent + 1) / listaMea.Count) * 100;
            }
            else
            {
                ScoreWindow sw = new ScoreWindow(scor);
                sw.Show();
                this.Close();
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            string raspuns = "";
            if (rbA.IsChecked == true) raspuns = "A";
            else if (rbB.IsChecked == true) raspuns = "B";
            else if (rbC.IsChecked == true) raspuns = "C";
            else if (rbD.IsChecked == true) raspuns = "D";
            if (string.IsNullOrEmpty(raspuns))
            {
                MessageBox.Show("Te rugăm să alegi un răspuns!");
                return;
            }

            if (raspuns == listaMea[indexCurent].CorrectAnswer) scor++;

            indexCurent++;
            AfiseazaIntrebare();
        }
    }
}