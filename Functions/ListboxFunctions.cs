
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LibraryLogger.Functions {
    public class ListboxFunctions {
        public ListBox temp;
        public List<String> tempList;
        public void enableDragAndDrop(ListBox listBox, List<String> vs, Style listBoxItem) {
            Style itemContainerStyle = new Style(typeof(ListBoxItem));
            itemContainerStyle.Setters.Add(new Setter(ListBoxItem.AllowDropProperty, true));
            itemContainerStyle.Setters.Add(new EventSetter(ListBoxItem.PreviewMouseLeftButtonDownEvent, new MouseButtonEventHandler(s_PreviewMouseLeftButtonDown)));
            itemContainerStyle.Setters.Add(new EventSetter(ListBoxItem.DropEvent, new DragEventHandler(dropMethod)));

            itemContainerStyle.BasedOn = listBoxItem;
            listBox.ItemContainerStyle = itemContainerStyle;
            temp = listBox;
            tempList = vs;
        }

        public void s_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            if (sender is ListBoxItem) {
                ListBoxItem draggedItem = sender as ListBoxItem;
                DragDrop.DoDragDrop(draggedItem, draggedItem.DataContext, DragDropEffects.Move);
                draggedItem.IsSelected = true;
            }
        }

        public void dropMethod(object sender, DragEventArgs e) {
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
    }
}
