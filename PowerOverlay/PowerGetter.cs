using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using OpenHardwareMonitor.Hardware;

namespace PowerOverlay
{

    class PowerGetter
    {
        const float GAUGE_MAX = 40;
        const int NUM_SAMPLES = 10;

        public Notifier pkgNotif = new Notifier();
        public Notifier corNotif = new Notifier();
        public Notifier gfxNotif = new Notifier();
        public Notifier drmNotif = new Notifier();

        Computer computer;
        UpdateVisitor updateVisitor;

        public PowerGetter()
        {
            computer = new Computer();
            updateVisitor = new UpdateVisitor();

            computer.CPUEnabled = true;
            computer.GPUEnabled = true;
            
            computer.Open();

            Console.WriteLine(computer.GetReport());
        }

        ~PowerGetter()
        {
            computer.Close();
        }
        public class UpdateVisitor : IVisitor
        {
            public void VisitComputer(IComputer computer)
            {
                computer.Traverse(this);
            }
            public void VisitHardware(IHardware hardware)
            {
                hardware.Update();
                foreach (IHardware subHardware in hardware.SubHardware) subHardware.Accept(this);
            }
            public void VisitSensor(ISensor sensor) { }
            public void VisitParameter(IParameter parameter) { }
        }
        public void GetSystemInfo()
        {

            computer.Accept(updateVisitor);
            for (int i = 0; i < computer.Hardware.Length; i++)
            {
                if (computer.Hardware[i].HardwareType == HardwareType.CPU)
                {
                                        
                    for (int j = 0; j < computer.Hardware[i].Sensors.Length; j++)
                    {
                        if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Power)
                        {
                            string n = computer.Hardware[i].Sensors[j].Name;
                            float w = (float)computer.Hardware[i].Sensors[j].Value;
                            if (n == "CPU Package")
                            {
                                pkgNotif.Angle = Lerp(-85, 85, (w / GAUGE_MAX));
                                pkgNotif.Watts = w;
                                pkgNotif.Name = computer.Hardware[i].Sensors[j].Name;
                            }
                            else if (n == "CPU Cores")
                            {
                                corNotif.Angle = Lerp(-85, 85, (w / GAUGE_MAX));
                                corNotif.Watts = w;
                                corNotif.Name = computer.Hardware[i].Sensors[j].Name;
                            }
                            else if (n == "CPU Graphics")
                            {
                                gfxNotif.Angle = Lerp(-85, 85, (w / GAUGE_MAX));
                                gfxNotif.Watts = w;
                                gfxNotif.Name = computer.Hardware[i].Sensors[j].Name;
                            }
                            else // CPU DRAM
                            {
                                drmNotif.Angle = Lerp(-85, 85, (w / GAUGE_MAX));
                                drmNotif.Watts = w;
                                drmNotif.Name = computer.Hardware[i].Sensors[j].Name;
                            }
                        }

                    }
                }
                else if (computer.Hardware[i].HardwareType == HardwareType.GpuNvidia)
                {
                    for (int j = 0; j < computer.Hardware[i].Sensors.Length; j++)
                    {
                        if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Power)
                        {
                            string n = computer.Hardware[i].Sensors[j].Name;
                            Console.WriteLine(n);
                            float w = (float)computer.Hardware[i].Sensors[j].Value;
                            if (n == "CPU Package")
                            {
                                pkgNotif.Angle = Lerp(-85, 85, (w / GAUGE_MAX));
                                pkgNotif.Watts = w;
                                pkgNotif.Name = computer.Hardware[i].Sensors[j].Name;
                            }
                            else if (n == "CPU Cores")
                            {
                                corNotif.Angle = Lerp(-85, 85, (w / GAUGE_MAX));
                                corNotif.Watts = w;
                                corNotif.Name = computer.Hardware[i].Sensors[j].Name;
                            }
                            else if (n == "CPU Graphics")
                            {
                                gfxNotif.Angle = Lerp(-85, 85, (w / GAUGE_MAX));
                                gfxNotif.Watts = w;
                                gfxNotif.Name = computer.Hardware[i].Sensors[j].Name;
                            }
                            else // CPU DRAM
                            {
                                drmNotif.Angle = Lerp(-85, 85, (w / GAUGE_MAX));
                                drmNotif.Watts = w;
                                drmNotif.Name = computer.Hardware[i].Sensors[j].Name;
                            }
                        }
                            
                    }
                }
                else if (computer.Hardware[i].HardwareType == HardwareType.GpuAti)
                {
                    for (int j = 0; j < computer.Hardware[i].Sensors.Length; j++)
                    {
                        if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Power)
                        {
                            string n = computer.Hardware[i].Sensors[j].Name;
                            Console.WriteLine(n);
                            float w = (float)computer.Hardware[i].Sensors[j].Value;
                            if (n == "CPU Package")
                            {
                                pkgNotif.Angle = Lerp(-85, 85, (w / GAUGE_MAX));
                                pkgNotif.Watts = w;
                                pkgNotif.Name = computer.Hardware[i].Sensors[j].Name;
                            }
                            else if (n == "CPU Cores")
                            {
                                corNotif.Angle = Lerp(-85, 85, (w / GAUGE_MAX));
                                corNotif.Watts = w;
                                corNotif.Name = computer.Hardware[i].Sensors[j].Name;
                            }
                            else if (n == "CPU Graphics")
                            {
                                gfxNotif.Angle = Lerp(-85, 85, (w / GAUGE_MAX));
                                gfxNotif.Watts = w;
                                gfxNotif.Name = computer.Hardware[i].Sensors[j].Name;
                            }
                            else // CPU DRAM
                            {
                                drmNotif.Angle = Lerp(-85, 85, (w / GAUGE_MAX));
                                drmNotif.Watts = w;
                                drmNotif.Name = computer.Hardware[i].Sensors[j].Name;
                            }
                        }

                    }
                }
            }
        }

        public class Notifier : INotifyPropertyChanged
        {
            public Notifier() { }
            public event PropertyChangedEventHandler PropertyChanged;

            public delegate void PropertyChangedValEventHandler(object sender, double val);
            public event PropertyChangedValEventHandler PropValChanged;

            private void NotifyPropertyChanged(string info)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                }
            }
            private void NotifyValChanged(double val)
            {
                if (PropValChanged != null)
                {
                    PropValChanged(this, val);
                }
            }

            int i = 0;
            readonly double[] _angle = new double[NUM_SAMPLES];
            readonly double[] _watts = new double[NUM_SAMPLES];
            string _name;            

            public double Angle
            {
                get { return _angle.Average(); }
                set { _angle[i] = value; NotifyPropertyChanged("Angle"); }
            }            
            public double Watts
            {
                get { return _watts.Average(); }
                set { _watts[i] = value; NotifyPropertyChanged("WattsFormatted"); NotifyValChanged(Watts); }
            }
            public string WattsFormatted
            {
                get { return Watts.ToString(".00") + " W"; }
            }            
            public string Name
            {
                get { return _name; }
                set { _name = value; i = (i + 1) % NUM_SAMPLES; NotifyPropertyChanged("Name"); }
            }
        }
        private float Lerp(float firstFloat, float secondFloat, float by)
        {
            return firstFloat * (1 - by) + secondFloat * by;
        }
    }
}