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

        public MainWindow() {

            InitializeComponent();
            Title = notepad.GetCurrentWorkingFileName() + " - Notatnik";
            this.KeyDown += MainWindow_KeyDown;
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.S && Keyboard.Modifiers == ModifierKeys.Control)
            {
                SaveCommandHandler();

                e.Handled = true;
            }
        }
        private void NotepadTextBoxLoaded(object sender, RoutedEventArgs e)
        {

            notepadTextBox.Focus();
            
        }

        private void NotepadTextBoxChanged(object sender, RoutedEventArgs e)
        {
            notepad.textData = notepadTextBox.Text;
            if (!notepad.isSaved)
            {
                Title = "*" + notepad.GetCurrentWorkingFileName() + " - Notatnik";
            }
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

        private void NewCommandHandler () {
            notepadTextBox.Text = "";
            notepad.SetCurrentWorkingFileName(null);
        }

        private void OpenCommandHandler () {
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
                notepad.SetCurrentWorkingFileName(System.IO.Path.GetFileName(openFileDialog.FileName));
                Title = "*" + notepad.GetCurrentWorkingFileName() + " - Notatnik";

                string directoryPath = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
                notepad.SetCurrentWorkingDirectory(directoryPath);

            }

        }

        private void SaveCommandHandler () {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*|HTML Files (*.html)|*.html";
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.InitialDirectory = "C:\\";

            if (notepad.GetCurrentWorkingFileName() != null)
            {
                System.IO.File.WriteAllText(notepad.GetCurrentWorkingFileName(), notepad.textData);
                Title = notepad.GetCurrentWorkingFileName() + " - Notatnik";
            }
            else
            {
                SaveAsCommandHandler();
            }
        }

        private void SaveAsCommandHandler() {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*|HTML Files (*.html)|*.html";
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.InitialDirectory = "C:\\";

            Nullable<bool> result = saveFileDialog.ShowDialog();

            if (result == true)
            {
                notepad.SetCurrentWorkingFileName(System.IO.Path.GetFileName(saveFileDialog.FileName));
                System.IO.File.WriteAllText(notepad.GetCurrentWorkingFileName(), notepad.textData);
            }

        } 

        private void PrintCommandHandler()
        {
            FlowDocument flowDocument = new FlowDocument();
            Paragraph paragraph = new Paragraph(new Run(notepad.textData));
            flowDocument.Blocks.Add(paragraph);

            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == true)
            {
                flowDocument.PageHeight = printDialog.PrintableAreaHeight;
                flowDocument.PageWidth = printDialog.PrintableAreaWidth;

                flowDocument.PagePadding = new Thickness(90);

                IDocumentPaginatorSource paginatorSource = flowDocument;
                DocumentPaginator paginator = paginatorSource.DocumentPaginator;

                printDialog.PrintDocument(paginator, "Dokument Textowy");
            }
        }

        private void ExitCommandHandler()
        {
            Environment.Exit(0);
        }

        private void NewWindowCommandHandler()
        {
            MainWindow newWindow = new MainWindow();
            newWindow.Show();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {

            Button clickedButton = sender as Button;
            clickedButton.ContextMenu.IsOpen = true;

        }
        
        private void MenuItemClick(object sender, RoutedEventArgs e)
        {
            
            MenuItem item = sender as MenuItem;

            switch (item.Name)
            {
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
            }
            
            
        }
    }
}
