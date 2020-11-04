using LibraryLogger.Functions;
using MaterialDesignThemes.Wpf;
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
using System.Windows.Threading;

namespace LibraryLogger
{
    public partial class IdentifyAreas : Window {
        public Dictionary<String, DeweyDecimalSystem> callNumbers = new Dictionary<string, DeweyDecimalSystem>();
        public List<string> values = new List<string>();
        public List<string> keys = new List<string>();

        public RandomGenerators randomGen = new RandomGenerators();
        public Score score = new Score();
        public ElementFunctions elementFunctions = new ElementFunctions();

        public int correct;
        public int matches;
        public int timeCounter;
        public int chooseList;
        public int difficulty;

        public List<int> scores = new List<int>();
        public List<Card> scoreCards = new List<Card>();

        DispatcherTimer _timer;
        TimeSpan _time;

        public IdentifyAreas(int difficulty) {
            InitializeComponent();
            this.difficulty = difficulty;
            Init();
        }

        public void Init() {
            switch (difficulty) {
                case 0:
                    matches = 4;
                    timeCounter = 300;
                    scrollView.MaxHeight = 346;
                    scrollView.Height = 345.5;
                    break;
                case 1:
                    matches = 7;
                    timeCounter = 150;
                    scrollView.MaxHeight = 441;
                    scrollView.Height = 440.5;
                    break;
                case 2:
                    matches = 10;
                    timeCounter = 60;
                    scrollView.MaxHeight = 536;
                    scrollView.Height = 535.5;
                    break;
                default:
                    matches = 4;
                    timeCounter = 300;
                    break;
            }
            callNumbers = randomGen.generateNumbersAndDescription(matches + 3);
            switch (ListToggle.IsChecked) {
                case false:
                    keys = callNumbers.Keys.Take(matches).ToList();
                    foreach (DeweyDecimalSystem item in callNumbers.Values) {
                        values.Add(item.High);
                    }
                    values = values.OrderBy(a => Guid.NewGuid()).ToList();

                    FirstList.ItemsSource = keys;
                    SecondList.ItemsSource = values;
                    elementFunctions.EnableDragAndDrop(SecondList, values, (Style)FindResource("MaterialDesignListBoxItem"));
                    break;
                case true:
                    SecondList.ItemsSource = null;
                    keys = callNumbers.Keys.OrderBy(a => Guid.NewGuid()).ToList();
                    foreach (DeweyDecimalSystem item in callNumbers.Values) {
                        values.Add(item.High);
                    }

                    FirstList.ItemsSource = values.Take(matches);
                    SecondList.ItemsSource = keys;
                    elementFunctions.EnableDragAndDrop(SecondList, keys, (Style)FindResource("MaterialDesignListBoxItem"));
                    break;
            }
            InitTimer();
        }

        public void InitTimer() {
            _time = TimeSpan.FromSeconds(timeCounter);

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                timer.Text = _time.ToString("c");
                if (_time == TimeSpan.Zero) {
                    _timer.Stop();
                    CheckScore();
                    timer.Visibility = Visibility.Collapsed;
                }
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            _timer.Start();
        }

        public void CheckScore() {
            SecondList.ItemContainerStyle = null;
            SecondList.ItemsSource = null;
            correct = 0;

            switch (ListToggle.IsChecked) {
                case false:
                    for (int i = 0; i < matches; i++) {
                        if (values[i] == callNumbers.Values.ElementAt(i).High) {
                            SecondList.Items.Add(new ListBoxItem { Content = callNumbers.Values.ElementAt(i).High, Background = Brushes.DarkGreen });
                            correct++;
                        } else {
                            SecondList.Items.Add(new ListBoxItem { Content = callNumbers.Values.ElementAt(i).High, Background = Brushes.DarkRed });
                        }
                    }
                    break;
                case true:
                    List<String> temp = new List<String>();
                    foreach(String item in keys) {
                        temp.Add(randomGen.GenerateDescriptions(item).High);
                    }
                    for (int i = 0; i < matches; i++) {
                        if (temp[i] == callNumbers.Values.ElementAt(i).High) {
                            SecondList.Items.Add(new ListBoxItem { Content = callNumbers.Keys.ElementAt(i), Background = Brushes.DarkGreen });
                            correct++;
                        } else {
                            SecondList.Items.Add(new ListBoxItem { Content = callNumbers.Keys.ElementAt(i), Background = Brushes.DarkRed });
                        }
                    }
                    break;
            }
            scoresPanel.Visibility = Visibility.Visible;
            historyPanel.Children.Add(elementFunctions.GetScoreCard($"{correct}/{matches}. {score.getScoreStatement(correct, matches)}", (Style)FindResource("MaterialDesignBody2TextBlock")));

            Double tempScore = (Double)correct / (Double)matches;
            tempScore *= 100;
            scores.Add((int)tempScore);
            averageScore.Text = $"{(int)scores.Average()}%";
            testsTaken.Text = scores.Count().ToString();

            checkOrder.Visibility = Visibility.Collapsed;
            reset.Visibility = Visibility.Visible;
        }

        private void CheckOrder_Click(object sender, RoutedEventArgs e) {
            _timer.IsEnabled = false;
            TogglePanel.Visibility = Visibility.Visible;
            CheckScore();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e) {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void Reset_Click(object sender, RoutedEventArgs e) {
            FirstList.ItemsSource = null;
            FirstList.Items.Clear();
            SecondList.ItemsSource = null;
            SecondList.Items.Clear();
            callNumbers.Clear();
            callNumbers = null;
            keys = new List<string>();
            values = new List<string>();
            checkOrder.Visibility = Visibility.Visible;
            reset.Visibility = Visibility.Collapsed;
            TogglePanel.Visibility = Visibility.Collapsed;
            Init();
        }
    }
}
