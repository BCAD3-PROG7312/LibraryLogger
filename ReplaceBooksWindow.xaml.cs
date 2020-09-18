using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace LibraryLogger
{
    public partial class ReplaceBooksWindow : Window
    {
        public List<String> callNumbers = new List<string>();
        public List<String> correctOrder = new List<string>();
        public Random random = new Random();

        public ReplaceBooksWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 10; i++)
            {
                String part1 = random.Next(1000).ToString();
                if (int.Parse(part1) < 10)
                {
                    part1 = "00" + part1;
                } else if (int.Parse(part1) < 100)
                {
                    part1 = "0" + part1;
                }
                String part2 = random.Next(100).ToString();
                if (int.Parse(part2) < 10)
                {
                    part2 = "00" + part2;
                }
                String part3 = "";
                for (int k = 0; k < 3; k++)
                {
                    int temp = random.Next(65, 90);
                    part3 += (char)temp;
                }
                callNumbers.Add(part1 + "." + part2 + " " + part3);
                correctOrder.Add(part1 + "." + part2 + " " + part3);
            }
            ReplaceBooksList.ItemsSource = callNumbers;

            Style itemContainerStyle = new Style(typeof(ListBoxItem));
            itemContainerStyle.Setters.Add(new Setter(ListBoxItem.AllowDropProperty, true));
            itemContainerStyle.Setters.Add(new EventSetter(ListBoxItem.PreviewMouseLeftButtonDownEvent, new MouseButtonEventHandler(s_PreviewMouseLeftButtonDown)));
            itemContainerStyle.Setters.Add(new EventSetter(ListBoxItem.DropEvent, new DragEventHandler(ReplaceBooksList_Drop)));
            ReplaceBooksList.ItemContainerStyle = itemContainerStyle;
            ReplaceBooksList
        }

        void s_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e){
            if (sender is ListBoxItem){
                ListBoxItem draggedItem = sender as ListBoxItem;
                DragDrop.DoDragDrop(draggedItem, draggedItem.DataContext, DragDropEffects.Move);
                draggedItem.IsSelected = true;
            }
        }

        void ReplaceBooksList_Drop(object sender, DragEventArgs e){
            String droppedData = e.Data.GetData(typeof(String)) as String;
            String target = ((ListBoxItem)(sender)).DataContext as String;

            int removedIdx = ReplaceBooksList.Items.IndexOf(droppedData);
            int targetIdx = ReplaceBooksList.Items.IndexOf(target);

            if (removedIdx < targetIdx){
                callNumbers.Insert(targetIdx + 1, droppedData);
                callNumbers.RemoveAt(removedIdx);
            } else{
                int remIdx = removedIdx + 1;
                if (callNumbers.Count + 1 > remIdx){
                    callNumbers.Insert(targetIdx, droppedData);
                    callNumbers.RemoveAt(remIdx);
                }
            }
            ReplaceBooksList.Items.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            correctOrder.Sort();
            for (int i = 0; i < correctOrder.Count; i++){
                String temp1 = ReplaceBooksList.Items.GetItemAt(i).ToString(), temp2 = correctOrder.ElementAt(i);
                if (temp1.Equals(temp2)){
                    correctBooksList.Items.Add(new ListBoxItem { Content = correctOrder.ElementAt(i), Background = Brushes.DarkGreen });
                } else{
                    correctBooksList.Items.Add(new ListBoxItem { Content = correctOrder.ElementAt(i), Background = Brushes.DarkRed });
                }
            }
        }
    }
}
