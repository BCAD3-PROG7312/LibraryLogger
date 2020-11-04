
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using LibraryLogger.Functions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace LibraryLogger.Functions {
    public class ElementFunctions {
        public ListBox temp;
        public List<String> tempList = new List<String>();
        public void EnableDragAndDrop(ListBox listBox, List<String> vs, Style listBoxItemStyle, Style listStyle) {
            Style listboxStyle = new Style(typeof(ListBox));
            Style itemContainerStyle = new Style(typeof(ListBoxItem));
            itemContainerStyle.Setters.Add(new Setter(ListBoxItem.AllowDropProperty, true));
            itemContainerStyle.Setters.Add(new EventSetter(ListBoxItem.PreviewMouseLeftButtonDownEvent, new MouseButtonEventHandler(PreviewMouseLeftButtonDown)));
            itemContainerStyle.Setters.Add(new EventSetter(ListBoxItem.DropEvent, new DragEventHandler(DropMethod)));

            itemContainerStyle.BasedOn = listBoxItemStyle;
            listboxStyle.BasedOn = listStyle;
            //listBox.Style = listboxStyle;
            listBox.ItemContainerStyle = itemContainerStyle;
            temp = listBox;
            tempList = vs;
        }

        public void PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            if (sender is ListBoxItem) {
                ListBoxItem draggedItem = sender as ListBoxItem;
                DragDrop.DoDragDrop(draggedItem, draggedItem.DataContext, DragDropEffects.Move);
                draggedItem.IsSelected = true;
            }
        }

        public void DropMethod(object sender, DragEventArgs e) {
            String droppedData = e.Data.GetData(typeof(String)) as String;
            String target = ((ListBoxItem)(sender)).DataContext as String;

            int removedIdx = temp.Items.IndexOf(droppedData);
            int targetIdx = temp.Items.IndexOf(target);

            if (removedIdx < targetIdx) {
                tempList.Insert(targetIdx + 1, droppedData);
                tempList.RemoveAt(removedIdx);
            } else {
                int remIdx = removedIdx + 1;
                if (tempList.Count + 1 > remIdx) {
                    tempList.Insert(targetIdx, droppedData);
                    tempList.RemoveAt(remIdx);
                }
            }
            temp.Items.Refresh();
        }

        public Card GetScoreCard(String score, int no, Style style) {
            TextBlock text = new TextBlock {
                HorizontalAlignment = HorizontalAlignment.Center,
                Padding = new Thickness(10),
                Style = style,
                Text = score,
                Foreground = Brushes.Black,
                TextWrapping = TextWrapping.Wrap
            };

            TextBlock itemNo = new TextBlock {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                Padding = new Thickness(5),
                Style = style,
                Text = (no+1) + "#",
                FontSize = 10,
                Foreground = Brushes.DarkGray,
                TextWrapping = TextWrapping.Wrap
            };

            Grid grid = new Grid {
                Children = {text, itemNo}
            };

            Card card = new Card {
                Margin = new Thickness(5),
                Background = Brushes.WhiteSmoke,
                Content = grid
            };

            return card;
        }
    }
}
