using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using ReactiveUI;

namespace lab5.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        string regexByLine;
        string path;
        string waterMark;

        public MainWindowViewModel()
        {
            waterMark = "введите хуету";
        }

        public string RegexByLine
        {
            get => regexByLine;
            set { this.RaiseAndSetIfChanged(ref regexByLine, value); }
        }
        public string WaterMark
        {
            set { this.RaiseAndSetIfChanged(ref waterMark, value); }
            get => regexByLine;
        }

        public string Path
        {
            get => path;
            set { this.RaiseAndSetIfChanged(ref path, value); }
        }
    }
}
