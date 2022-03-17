using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace lab5.Views
{
    public partial class SetRegexWindow : Window
    {
        public SetRegexWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.FindControl<Button>("okButton").Click += async delegate
            {
                Close(this.FindControl<TextBox>("patternInput").Text); //тут нужно будет отправить данные
            };

            this.FindControl<Button>("cancelButton").Click += async delegate
            {
                Close();
            };

        }
        public SetRegexWindow(string pattern) : this()
        {
            this.FindControl<TextBox>("patternInput").Text = pattern;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
