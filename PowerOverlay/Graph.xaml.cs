using System;
using System.Linq;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Diagnostics;

namespace PowerOverlay
{
    /// <summary>
    /// Interaction logic for Gauge.xaml
    /// </summary>
    public partial class Graph : UserControl
    {
        List<double> tx = new List<double>();
        List<double> ty = new List<double>();

        double startTime = DateTime.Now.Ticks;
        public Graph()
        {
            InitializeComponent();            
        }

        public void Plot(object sender, double x)
        {
            tx.Add(x);
            ty.Add((DateTime.Now.Ticks - startTime) * 0.0000001);
            this.Dispatcher.Invoke(() =>
            {
                linegraph.Plot(ty, tx);
            });
        }
    }
}
