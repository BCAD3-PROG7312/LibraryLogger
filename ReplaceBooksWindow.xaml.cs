using LibraryLogger.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace LibraryLogger
{
    public partial class ReplaceBooksWindow : Window
    {
        public List<String> callNumbers = new List<string>();
        public List<String> correctOrder = new List<string>();

        public RandomGenerators randomGen = new RandomGenerators();
        public Score score = new Score();
        public ListboxFunctions listboxFunctions = new ListboxFunctions();

        public int correct;
        public int matches;
        public int timeCounter;
        public int difficulty;

        DispatcherTimer _timer;
        TimeSpan _time;

        public ReplaceBooksWindow(int difficulty)
        {
            InitializeComponent();
            this.difficulty = difficulty;
            init(this.difficulty);
        }

        public void init(int difficulty) {
            switch (difficulty) {
                case 0:
                    matches = 5;
                    timeCounter = 300;
                    break;
                case 1:
                    matches = 10;
                    timeCounter = 150;
                    break;
                case 2:
                    matches = 15;
                    timeCounter = 60;
                    break;
                default:
                    matches = 5;
                    timeCounter = 300;
                    break;
            }

            initTimer();

            callNumbers = randomGen.generateRandomCallNumbers(matches);
            correctOrder.AddRange(callNumbers);

            ReplaceBooksList.ItemsSource = callNumbers;

            listboxFunctions.enableDragAndDrop(ReplaceBooksList, callNumbers, (Style)FindResource("MaterialDesignListBoxItem"));
        }

        public void initTimer() {
            _time = TimeSpan.FromSeconds(timeCounter);

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate {
                timer.Text = _time.ToString("c");
                if (_time == TimeSpan.Zero) {
                    _timer.Stop();
                    checkScore();
                    timer.Visibility = Visibility.Collapsed;
                }
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            _timer.Start();
        }

        public void checkScore() {
            correct = 0;
            ReplaceBooksList.ItemContainerStyle = null;
            correctOrder.Sort();
            for (int i = 0; i < correctOrder.Count; i++) {
                String temp1 = ReplaceBooksList.Items.GetItemAt(i).ToString(), temp2 = correctOrder.ElementAt(i);
                if (temp1.Equals(temp2)) {
                    correctBooksList.Items.Add(new ListBoxItem { Content = correctOrder.ElementAt(i), Background = Brushes.DarkGreen });
                    correct++;
                } else {
                    correctBooksList.Items.Add(new ListBoxItem { Content = correctOrder.ElementAt(i), Background = Brushes.DarkRed });
                }
            }
            scoreText.Text = $"You scored {correct}/{matches}. {score.getScoreStatement(correct, matches)}";

            scoreCard.Visibility = Visibility.Visible;
            checkOrder.Visibility = Visibility.Collapsed;
            reset.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            _timer.IsEnabled = false;
            checkScore();
        }

        private void reset_Click_1(object sender, RoutedEventArgs e) {
            ReplaceBooksList.ItemsSource = null;
            ReplaceBooksList.Items.Clear();
            correctBooksList.ItemsSource = null;
            correctBooksList.Items.Clear();
            callNumbers.Clear();
            callNumbers = new List<string>();
            correctOrder.Clear();
            correctOrder = new List<string>();
            scoreCard.Visibility = Visibility.Collapsed;
            checkOrder.Visibility = Visibility.Visible;
            reset.Visibility = Visibility.Collapsed;
            init(difficulty);
        }

        private void goBack_Click_1(object sender, RoutedEventArgs e) {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}
