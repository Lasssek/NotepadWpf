using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///
    public partial class MainWindow : Window
    {
        NotepadClass notepad = new NotepadClass();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void NotepadTextBoxLoaded(object sender, RoutedEventArgs e)
        {

            notepadTextBox.Focus();
            
        }
        private void ButtonHover(object sender, MouseEventArgs e)
        {

            Button hoveredButton = sender as Button;

            Color color = (Color)ColorConverter.ConvertFromString("#e5f3ff");
            SolidColorBrush brush = new SolidColorBrush(color);

            if (e.RoutedEvent == Mouse.MouseEnterEvent)
            {

                hoveredButton.Background = brush;
            }
            else if (e.RoutedEvent == Mouse.MouseLeaveEvent)
            {

                hoveredButton.Background = Brushes.White;
            }
        }
        private void ButtonClick(object sender, RoutedEventArgs e)
        {

            Button clickedButton = sender as Button;
            clickedButton.ContextMenu.IsOpen = true;

        }

        private void NotepadTextBoxChanged (object sender, RoutedEventArgs e)
        {
            notepad.textData = notepadTextBox.Text;
        }
        private void MenuItemClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*|HTML Files (*.html)|*.html";
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.InitialDirectory = "C:\\";
            MenuItem item = sender as MenuItem;

            switch (item.Name)
            {
                case "New":
                    notepadTextBox.Text = "";
                    notepad.SetCurrentWorkingFileName(null);

                    break;

                case "SaveAs":

                    Nullable<bool> result = saveFileDialog.ShowDialog();

                    if (result == true)
                    {
                        notepad.SetCurrentWorkingFileName(saveFileDialog.FileName);
                        System.IO.File.WriteAllText(notepad.GetCurrentWorkingFileName(), notepad.textData);
                    }
                    break;

                case "Save":
                    if (notepad.GetCurrentWorkingFileName() != null)
                    {
                        System.IO.File.WriteAllText(notepad.GetCurrentWorkingFileName(), notepad.textData);
                    }
                    else
                    {
                        MessageBox.Show("Nieudano sie zapisac stworz nowy plik aby zapisywac dane");
                    }
                    break;

                case "Open":
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*|HTML Files (*.html)|*.html";
                    openFileDialog.DefaultExt = ".txt";
                    if (notepad.GetCurrentWorkingDirectory() != null)
                    {
                        openFileDialog.InitialDirectory = notepad.GetCurrentWorkingDirectory();
                    }
                    else
                    {
                        openFileDialog.InitialDirectory = "C:\\";
                    }
                    

                    Nullable<bool> openResult = openFileDialog.ShowDialog();

                    if (openResult == true)
                    {
                        notepadTextBox.Text = System.IO.File.ReadAllText(openFileDialog.FileName);

                        notepad.SetCurrentWorkingFileName(openFileDialog.FileName);
                        string directoryPath = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
                        notepad.SetCurrentWorkingDirectory(directoryPath);

                    }
                    break;
            }
            
            
        }
    }
}
