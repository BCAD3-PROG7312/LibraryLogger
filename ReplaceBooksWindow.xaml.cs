﻿using LibraryLogger.Functions;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace LibraryLogger {
    public partial class ReplaceBooksWindow : Window {
        public Dictionary<String, DeweyDecimalSystem> items = new Dictionary<string, DeweyDecimalSystem>();
        public List<String> callNumbers = new List<string>();
        public List<String> correctOrder = new List<string>();

        public RandomGenerators randomGen = new RandomGenerators();
        public ElementFunctions elementFunctions = new ElementFunctions();

        public int correct;
        public int matches;
        public int timeCounter;
        public int difficulty;

        public List<int> scores = new List<int>();
        public List<Card> scoreCards = new List<Card>();

        DispatcherTimer _timer;

        public ReplaceBooksWindow(int difficulty) {
            InitializeComponent();
            this.difficulty = difficulty;
            Init(this.difficulty);

            switch (difficulty) {
                case 0:
                    matches = 5;
                    timeCounter = 290;
                    scrollView.MaxHeight = 313;
                    scrollView.Height = 313;
                    break;
                case 1:
                    matches = 10;
                    timeCounter = 150;
                    scrollView.MaxHeight = 471;
                    scrollView.Height = 471;
                    break;
                case 2:
                    matches = 15;
                    timeCounter = 60;
                    scrollView.MaxHeight = 629;
                    scrollView.Height = 629;
                    break;
                default:
                    break;
            }
        }

        public void Init(int difficulty) {
            InitTimer();
            items = randomGen.generateNumbersAndDescription(matches);
            for (int i = 0; i < items.Count; i++) {
                callNumbers.Add(items.Keys.ElementAt(i));
                correctOrder.Add(items.Keys.ElementAt(i));
            }
            ReplaceBooksList.ItemsSource = callNumbers;
            ReplaceBooksList.HorizontalContentAlignment = HorizontalAlignment.Center; 

            elementFunctions.EnableDragAndDrop(ReplaceBooksList, callNumbers, (Style)FindResource("MaterialDesignListBoxItem"), (Style)FindResource("MaterialDesignToolVerticalToggleListBox"));
        }

        public void InitTimer() {
            TimeSpan _time = TimeSpan.FromSeconds(timeCounter);

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

        public void CheckScore() {
            Score score = new Score();
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
            correctBooksList.HorizontalContentAlignment = HorizontalAlignment.Center;
            historyPanel.Children.Insert(0, elementFunctions.GetScoreCard($"{correct}/{matches}. {score.getScoreStatement(correct, matches)}", scores.Count, (Style)FindResource("MaterialDesignBody2TextBlock")));

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
            CheckScore();
            correctBooksList.Width = 150;
        }

        private void GoBack_Click(object sender, RoutedEventArgs e) {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void Reset_Click(object sender, RoutedEventArgs e) {
            ReplaceBooksList.ItemsSource = null;
            ReplaceBooksList.Items.Clear();
            correctBooksList.ItemsSource = null;
            correctBooksList.Items.Clear();
            correctBooksList.Width = 0;
            callNumbers.Clear();
            callNumbers = new List<string>();
            correctOrder.Clear();
            correctOrder = new List<string>();
            checkOrder.Visibility = Visibility.Visible;
            reset.Visibility = Visibility.Collapsed;
            Init(difficulty);
        }
    }
}
