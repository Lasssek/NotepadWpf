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

namespace Notepad {

    public partial class MainWindow : Window {

        NotepadClass notepad = new NotepadClass();

        public MainWindow() {

            InitializeComponent();
            Title = notepad.getCurrentTextFileTitle();
            this.KeyDown += MainWindow_KeyDown;
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e) {

            switch (e.Key) {
                case Key.S:
                    if (Keyboard.Modifiers == ModifierKeys.Control) {
                        SaveCommandHandler();

                        e.Handled = true;
                    }
                    else if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control && (Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift) {
                        SaveAsCommandHandler();

                        e.Handled = true;
                    }
                    break;
                case Key.N:
                    if (Keyboard.Modifiers == ModifierKeys.Control)
                    {
                        NewCommandHandler();

                        e.Handled = true;
                    }
                    else if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control && (Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift) {
                        NewWindowCommandHandler();

                        e.Handled = true;
                    }
                    break;
                case Key.O:
                    if (Keyboard.Modifiers == ModifierKeys.Control)
                    {
                        OpenCommandHandler();

                        e.Handled = true;
                    }
                    break;
                case Key.P:
                    if (Keyboard.Modifiers == ModifierKeys.Control)
                    {
                        PrintCommandHandler();

                        e.Handled = true;
                    }
                    break;
                case Key.Enter:
    
                    
                    int caretIndex = notepadTextBox.CaretIndex;

                    notepadTextBox.Text = notepadTextBox.Text.Insert(caretIndex, "\n");
                    notepadTextBox.CaretIndex = caretIndex + 1;

                    e.Handled = true;
                    break;
            }
        }

        private void NotepadTextBoxLoaded (object sender, RoutedEventArgs e) {

            notepadTextBox.FontSize = notepad.fontSize;
            notepadTextBox.Focus();
        }

        private void NotepadTextBoxChanged (object sender, RoutedEventArgs e) {

            notepad.textData = notepadTextBox.Text;
            if (notepad.textData != notepad.getDataBufferBeforeSaved()) {

                Title = "*" + notepad.getCurrentTextFileTitle();
            }
            else {

                Title = notepad.getCurrentTextFileTitle();
            }
        }

        private void ButtonHover (object sender, MouseEventArgs e) {

            Button hoveredButton = sender as Button;

            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e5f3ff"));

            if (e.RoutedEvent == Mouse.MouseEnterEvent) {
            
                hoveredButton.Background = brush;
            }
            else if (e.RoutedEvent == Mouse.MouseLeaveEvent) {

                hoveredButton.Background = Brushes.White;
            }
        }

        private void ButtonClick(object sender, RoutedEventArgs e) {

            Button clickedButton = sender as Button;
            clickedButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e8f2fa"));
            clickedButton.ContextMenu.IsOpen = true;

        }

        private void NewCommandHandler () {

            notepadTextBox.Text = "";
            notepad.SetCurrentWorkingFileName("Bez tytułu");
            notepad.setDataBufferBeforeSaved("");
            Title = notepad.getCurrentTextFileTitle();

        }

        private void OpenCommandHandler () {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*|HTML Files (*.html)|*.html";
            openFileDialog.DefaultExt = ".txt";

            if (notepad.GetCurrentWorkingDirectory() != null) {

                openFileDialog.InitialDirectory = notepad.GetCurrentWorkingDirectory();
            }
            else {

                openFileDialog.InitialDirectory = "C:\\";
            }

            Nullable<bool> openResult = openFileDialog.ShowDialog();

            if (openResult == true) {

                notepadTextBox.Text = System.IO.File.ReadAllText(openFileDialog.FileName);
                notepad.SetCurrentWorkingFileName(System.IO.Path.GetFileName(openFileDialog.FileName));
                Title = notepad.getCurrentTextFileTitle();

                notepad.SetCurrentWorkingDirectory(openFileDialog.FileName);
                notepad.setDataBufferBeforeSaved(notepadTextBox.Text);

            }

        }

        private void SaveCommandHandler () {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*|HTML Files (*.html)|*.html";
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.InitialDirectory = "C:\\";

            if (notepad.GetCurrentWorkingDirectory() != null) {

                System.IO.File.WriteAllText(notepad.GetCurrentWorkingDirectory(), notepad.textData);
                Title = notepad.getCurrentTextFileTitle();
                notepad.setDataBufferBeforeSaved(notepadTextBox.Text);
            }
            else {

                SaveAsCommandHandler();
            }
        }

        private void SaveAsCommandHandler() {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*|HTML Files (*.html)|*.html";
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.InitialDirectory = "C:\\";

            Nullable<bool> result = saveFileDialog.ShowDialog();

            if (result == true) {

                notepad.SetCurrentWorkingDirectory(saveFileDialog.FileName);
                notepad.SetCurrentWorkingFileName(System.IO.Path.GetFileName(saveFileDialog.FileName));
                System.IO.File.WriteAllText(notepad.GetCurrentWorkingDirectory(), notepad.textData);
                notepad.setDataBufferBeforeSaved(notepadTextBox.Text);
                Title = notepad.getCurrentTextFileTitle();
            }

        } 

        private void PrintCommandHandler () {

            FlowDocument flowDocument = new FlowDocument();
            Paragraph paragraph = new Paragraph(new Run(notepad.textData));
            flowDocument.Blocks.Add(paragraph);

            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == true) {

                flowDocument.PageHeight = printDialog.PrintableAreaHeight;
                flowDocument.PageWidth = printDialog.PrintableAreaWidth;

                flowDocument.PagePadding = new Thickness(90);

                IDocumentPaginatorSource paginatorSource = flowDocument;
                DocumentPaginator paginator = paginatorSource.DocumentPaginator;

                printDialog.PrintDocument(paginator, "Dokument Textowy");
            }
        }

        private void ExitCommandHandler () {

            Environment.Exit(0);
        }

        private void NewWindowCommandHandler () {

            MainWindow newWindow = new MainWindow();
            newWindow.Show();
        }

        private void TextWrapCommandHandler (MenuItem item) {

            if (item.IsChecked) {
                item.IsChecked = false;
                notepadScroll.SetValue(ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Visible);
                notepadTextBox.TextWrapping = TextWrapping.NoWrap;
            }
            else {
                item.IsChecked = true;
                notepadScroll.SetValue(ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Disabled);
                notepadTextBox.TextWrapping = TextWrapping.Wrap;
            }
            
        }
        
        private void MenuItemClick (object sender, RoutedEventArgs e) {
            
            MenuItem item = sender as MenuItem;

            switch (item.Name) {

                case "New":

                    NewCommandHandler();
                    break;

                case "SaveAs":

                    SaveAsCommandHandler();
                    break;

                case "Save":

                    SaveCommandHandler();
                    break;

                case "Open":

                    OpenCommandHandler();
                    break;

                case "Print":

                    PrintCommandHandler();
                    break;

                case "Exit":

                    ExitCommandHandler();
                    break;

                case "NewWindow":

                    NewWindowCommandHandler();
                    break;

                case "TextWrap":

                    TextWrapCommandHandler(item);
                    break;

            }
        }
    }
}
