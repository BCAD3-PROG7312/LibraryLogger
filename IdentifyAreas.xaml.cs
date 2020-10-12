using LibraryLogger.Functions;
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
    public partial class IdentifyAreas : Window
    {
        public List<string> values = new List<string>();
        public List<string> keys = new List<string>();

        public RandomGenerators randomGen = new RandomGenerators();
        public Score score = new Score();
        public ListboxFunctions listboxFunctions = new ListboxFunctions();

        public Dictionary<string, string> callNumbers;
        public Dictionary<string, string> userColumns = new Dictionary<string, string>();

        public int correct;
        public int matches;
        public int timeCounter;
        public int chooseList;
        public int difficulty;

        DispatcherTimer _timer;
        TimeSpan _time;

        public IdentifyAreas(int difficulty)
        {
            InitializeComponent();
            this.difficulty = difficulty;
            init(this.difficulty);
        }

        public void init(int difficulty) {
            switch (difficulty) {
                case 0:
                    matches = 4;
                    timeCounter = 300;
                    break;
                case 1:
                    matches = 7;
                    timeCounter = 150;
                    break;
                case 2:
                    matches = 10;
                    timeCounter = 60;
                    break;
                default:
                    matches = 4;
                    timeCounter = 300;
                    break;
            }

            callNumbers = randomGen.generateNumbersAndDescription(matches + 3);
            chooseList = randomGen.chooseList();
            switch (chooseList) {
                case 0:
                    keys = callNumbers.Keys.Take(matches).ToList();
                    values = callNumbers.Values.OrderBy(a => Guid.NewGuid()).ToList();
                    FirstList.ItemsSource = keys;
                    SecondList.ItemsSource = values;
                    break;
                case 1:
                    SecondList.ItemsSource = null;
                    keys = callNumbers.Keys.OrderBy(a => Guid.NewGuid()).ToList();
                    values = callNumbers.Values.Take(matches).ToList();
                    FirstList.ItemsSource = values;
                    SecondList.ItemsSource = keys;
                    break;
            }

            initTimer();
            listboxFunctions.enableDragAndDrop(SecondList, values, (Style)FindResource("MaterialDesignListBoxItem"));
        }

        public void initTimer() {
            _time = TimeSpan.FromSeconds(timeCounter);

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
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

        private void checkColumns_Click(object sender, RoutedEventArgs e) {
            _timer.IsEnabled = false;
            checkScore();
        }

        public void checkScore() {
            SecondList.ItemContainerStyle = null;
            SecondList.ItemsSource = null;
            userColumns.Clear();
            correct = 0;

            switch (chooseList) {
                case 0:
                    for (int i = 0; i < matches; i++) {
                        userColumns.Add(keys[i], values[i]);
                        if (userColumns.Values.ElementAt(i) == callNumbers.Values.ElementAt(i)) {
                            SecondList.Items.Add(new ListBoxItem { Content = callNumbers.Values.ElementAt(i), Background = Brushes.DarkGreen });
                            correct++;
                        } else {
                            SecondList.Items.Add(new ListBoxItem { Content = callNumbers.Values.ElementAt(i), Background = Brushes.DarkRed });
                        }
                    }
                    break;
                case 1:
                    for (int i = 0; i < matches; i++) {
                        userColumns.Add(keys[i], values[i]);
                        if (userColumns.Keys.ElementAt(i) == callNumbers.Keys.ElementAt(i)) {
                            SecondList.Items.Add(new ListBoxItem { Content = callNumbers.Keys.ElementAt(i), Background = Brushes.DarkGreen });
                            correct++;
                        } else {
                            SecondList.Items.Add(new ListBoxItem { Content = callNumbers.Keys.ElementAt(i), Background = Brushes.DarkRed });
                        }
                    }
                    break;
            }
            
            scoreText.Text = $"You scored {correct}/{matches}. {score.getScoreStatement(correct, matches)}";

            scoreCard.Visibility = Visibility.Visible;
            checkColumns.Visibility = Visibility.Collapsed;
            reset.Visibility = Visibility.Visible;
        }

        private void goBack_Click(object sender, RoutedEventArgs e) {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void reset_Click(object sender, RoutedEventArgs e) {
            FirstList.ItemsSource = null;
            FirstList.Items.Clear();
            SecondList.ItemsSource = null;
            SecondList.Items.Clear();
            callNumbers.Clear();
            callNumbers = null;
            keys = new List<string>();
            values = new List<string>();
            scoreCard.Visibility = Visibility.Collapsed;
            checkColumns.Visibility = Visibility.Visible;
            reset.Visibility = Visibility.Collapsed;
            init(difficulty);
        }
    }
}
