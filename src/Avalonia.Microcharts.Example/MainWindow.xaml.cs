using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avalonia.Microcharts.Example
{
    public class MainWindow : Window
    {
        List<Entry> Entries { get; } = [];

        public MainWindow()
        {
            AvaloniaXamlLoader.Load(this);
            Run();
        }

        private async void Run()
        {
            var rnd = new Random();
            var control = this.FindControl<MicrochartControl>("Chart");
            while(true)
            {
                Entries.Add(new Entry() { Value = rnd.Next(0, 100), Label = DateTime.UtcNow.ToString() });

                control.Chart = new LineChart() { Entries = Entries };

                await Task.Delay(1000);
            }
        }
    }
}