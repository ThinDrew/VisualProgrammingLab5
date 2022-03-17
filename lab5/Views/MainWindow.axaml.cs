using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using lab5.ViewModels;
using lab5.Models;
using Avalonia.Interactivity;
using MyRegex;

namespace lab5.Views
{
    public partial class MainWindow : Window
    {
        string? regexPattern;
        public MainWindow()
        {
            InitializeComponent();

            this.FindControl<TextBox>("inputTextBox").AddHandler(KeyUpEvent, TextBoxChange, RoutingStrategies.Tunnel);

            regexPattern = "";
            this.FindControl<Button>("OpenFileButton").Click += async delegate
            {
                var taskPath = new OpenFileDialog()
                {
                    Title = "Open File",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);
                string[]? path = await taskPath;

                var context = this.DataContext as MainWindowViewModel;
                try
                {
                    if (path != null)
                        context.Path = RegexAppLowLevel.LoadFromFile(string.Join(@"\", path));
                }
                catch (MyRegexException)
                {
                    context.Path = "";
                    context.WaterMark = "ѕуть не найден";
                }
                RegexByLineChange();
            };

            this.FindControl<Button>("SaveFileButton").Click += async delegate
            {
                var taskPath = new OpenFileDialog()
                {
                    Title = "Save File",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);
                string[]? path = await taskPath;

                try
                {
                    if (path != null)
                        RegexAppLowLevel.SaveFromFile(string.Join(@"\", path), this.FindControl<TextBox>("outputTextBox").Text);
                }
                catch (MyRegexException) { }
            };
       
        }
        private async void ClickEventSetRegexDialog(object sender, RoutedEventArgs e)
        {
            string? tmpPattern = await new SetRegexWindow(regexPattern).ShowDialog<string?>((Window)this.VisualRoot);
            if (tmpPattern != null)
            {
                regexPattern = tmpPattern;
                RegexByLineChange();
            }
        }

        private async void TextBoxChange(object sender, RoutedEventArgs e)
        {
            RegexByLineChange();
        }

        private void RegexByLineChange()
        {
            var context = this.DataContext as MainWindowViewModel;
            context.RegexByLine = RegexAppLowLevel.OutputDataByTemplate(this.FindControl<TextBox>("inputTextBox").Text, regexPattern);
        }
    }
}
