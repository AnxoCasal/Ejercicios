using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace PracticaGuiada
{
    public partial class SimpleService : ServiceBase
    {

        protected void writeEvent(string message)
        {
            string nombre = "SimpleService";
            string logDestino = "Application";
            if (!EventLog.SourceExists(nombre))
            {
                EventLog.CreateEventSource(nombre, logDestino);
            }
            EventLog.WriteEntry(nombre, message);
        }

        public SimpleService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            writeEvent("Running OnStart");
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 10000; // cada 10 segundos
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.TimerTick);
            timer.Start();
        }

        private int t = 0;
        public void TimerTick(object sender, System.Timers.ElapsedEventArgs args)
        {
            writeEvent(string.Format($"SimpleService running about {t} seconds"));
            t += 10;
        }
        protected override void OnPause()
        {
            writeEvent("Servicio en Pausa");
        }
        protected override void OnContinue()
        {
            writeEvent("Continuando servicio");
        }
        protected override void OnStop()
        {
            writeEvent("Deteniendo servicio");
            t = 0;
        }
    }
}
