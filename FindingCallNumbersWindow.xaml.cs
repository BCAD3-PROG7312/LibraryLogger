using LibraryLogger.Functions;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.Options;
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

namespace LibraryLogger {

    public partial class FindingCallNumbersWindow : Window {

        public int difficulty, matches, timeCounter, correct, answer;
        public int tier = 0;
        public Dictionary<String, DeweyDecimalSystem> callNumbers = new Dictionary<string, DeweyDecimalSystem>();

        public RandomGenerators randomGen = new RandomGenerators();
        public Score score = new Score();
        public ElementFunctions elementFunctions = new ElementFunctions();

        public List<int> scores = new List<int>();
        public List<Card> scoreCards = new List<Card>();

        DispatcherTimer _timer;
        TimeSpan _time;

        public FindingCallNumbersWindow(int difficulty) {
            InitializeComponent();
            this.difficulty = difficulty;

            switch (difficulty) {
                case 0:
                    matches = 4;
                    timeCounter = 300;
                    scrollView.MaxHeight = 306;
                    scrollView.Height = 305.5;
                    break;
                case 1:
                    matches = 5;
                    timeCounter = 150;
                    scrollView.MaxHeight = 401;
                    scrollView.Height = 400.5;
                    break;
                case 2:
                    matches = 6;
                    timeCounter = 60;
                    scrollView.MaxHeight = 496;
                    scrollView.Height = 495.5;
                    break;
                default:
                    break;
            }

            Init();
        }

        public void Init() {
            callNumbers = randomGen.FindingCallNumbers();
            answer = int.Parse(randomGen.GetRandomNumber(0, callNumbers.Count));
            question.Text = callNumbers.Values.ElementAt(answer).Low;

            firstPart.Text = callNumbers.Keys.ElementAt(answer).Substring(0, 1);
            secondPart.Text = callNumbers.Keys.ElementAt(answer).Substring(1, 1);
            thirdPart.Text = callNumbers.Keys.ElementAt(answer).Substring(2, 1);
            
            Level("00 ", "00", 0, 0, 999);
            InitTimer();
        }

        public void Level(String zeros, String randZeros, int substring, int tier, int nMax) {
            List<string> options = new List<string>();
            String newCall;
            DeweyDecimalSystem newOption = callNumbers.Values.ElementAt(answer);

            options.Add(callNumbers.Keys.ElementAt(answer).Substring(tier, 1) + zeros + GetTierDescription(newOption, tier));

            while (options.Count < matches) {
                string temp = callNumbers.Keys.ElementAt(answer).Substring(substring, 1) + randZeros;
                int min = int.Parse(temp);
                int max = min + nMax;
                newCall = randomGen.GetRandomNumber(min, max);
                newOption = randomGen.GenerateDescriptions(newCall.ToString());
                temp = newCall.ToString().Substring(tier, 1) + zeros + GetTierDescription(newOption, tier);
                if (!options.Contains(temp) && GetTierDescription(newOption, tier) != "") {
                    options.Add(temp);
                }
            }
            optionsListView.ItemsSource = options.OrderBy(a => Guid.NewGuid()).ToList();
        }

        public String GetTierDescription (DeweyDecimalSystem item, int tier) {
            switch (tier) {
                case 0:
                    return item.High;
                case 1:
                    return item.Mid;
                case 2:
                    return item.Low;
                default: return "";
            }
        }

        public void UpdateAnswers(String dewey, Card card) {
            if (optionsListView.SelectedItem.ToString().Contains(dewey)) {
                correct++;
                card.Background = Brushes.DarkGreen;
                card.BorderBrush = Brushes.DarkGreen;
            } else {
                card.Background = Brushes.DarkRed;
                card.BorderBrush = Brushes.DarkRed;
            }
        }

        public void CheckScore() {
            if (optionsListView.SelectedItem != null) {
                instruction.Text = "Click on the correct answer";
                instruction.Foreground = Brushes.White;

                switch (tier) {
                    case 0:
                        UpdateAnswers(callNumbers.Values.ElementAt(answer).High, answer1);
                        answer1.Visibility = Visibility.Visible;
                        Level("0 ", "00", 0, 1, 99);
                        tier++;
                        break;
                    case 1:
                        UpdateAnswers(callNumbers.Values.ElementAt(answer).Mid, answer2);
                        answer2.Visibility = Visibility.Visible;
                        Level(" ", "0", 1, 2, 9);
                        tier++;
                        break;
                    case 2:
                        UpdateAnswers(callNumbers.Values.ElementAt(answer).Low, answer3);
                        answer3.Visibility = Visibility.Visible;
                        tier = 0;
                        _timer.IsEnabled = false;

                        historyPanel.Children.Insert(0, elementFunctions.GetScoreCard($"{correct}/3. {score.getScoreStatement(correct, 3)}", scores.Count, (Style)FindResource("MaterialDesignBody2TextBlock")));
                        Double tempScore = (Double)correct / (Double)3;
                        tempScore *= 100;
                        scores.Add((int)tempScore);
                        averageScore.Text = $"{(int)scores.Average()}%";
                        testsTaken.Text = scores.Count().ToString();

                        checkOrder.Visibility = Visibility.Collapsed;
                        reset.Visibility = Visibility.Visible;
                        break;
                }
            } else {
                instruction.Text = "Please select and answer from the list";
                instruction.Foreground = Brushes.Red;
            }
        }

        public void InitTimer() {
            _time = TimeSpan.FromSeconds(timeCounter);

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate {
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

        private void Reset_Click(object sender, RoutedEventArgs e) {
            answer1.Visibility = Visibility.Collapsed;
            answer2.Visibility = Visibility.Collapsed;
            answer3.Visibility = Visibility.Collapsed;
            correct = 0;

            optionsListView.ItemsSource = null;
            optionsListView.Items.Clear();
            callNumbers.Clear();
            callNumbers = null;
            checkOrder.Visibility = Visibility.Visible;
            reset.Visibility = Visibility.Collapsed;
            TogglePanel.Visibility = Visibility.Collapsed;
            Init();
        }

        private void CheckOrder_Click(object sender, RoutedEventArgs e) {
            CheckScore();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e) {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}
