using System;
using System.ComponentModel;
using WpfApp7.Models;
using WpfApp7.Persistence.Repository.Timer;

namespace WpfApp7.Dispatching
{
    public class DispatcherTimer : INotifyPropertyChanged
    {
        public System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
        public int Stunde = 0;
        public int Sekunde = 0;
        public int Minuten = 0;

        public event EventHandler<string> TimerFinished;

        /// <summary>
        /// Das TimerObject, das aus der Datenbank kommt
        /// </summary>
        private Models.Timer TimerContext { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private string timerLabelContent = "";
        private readonly TimerRepository Repository;

        public DispatcherTimer()
        {
            Repository = new TimerRepository();
            Timer.Tick += Second_Tick_Start;
        }
        public string TimerLabelContent
        {
            get { return this.timerLabelContent; }
            set
            {
                this.timerLabelContent = value;
                NotifyPropertyChanged("TimerLabelContent");  //Call the method to set off the PropertyChanged event.
            }
        }

        private int totalzeit = 0;
        public int Totalzeit
        {
            get { return this.totalzeit; }
            set
            {
                this.totalzeit = value;
                NotifyPropertyChanged("Totalzeit");  //Call the method to set off the PropertyChanged event.
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        void Second_Tick_Start(object sender, EventArgs e)
        {
            Sekunde--;

            if (Sekunde < 0)
            {
                Sekunde = 59;
                Minuten--;

                if (Minuten < 0)
                {
                    Sekunde = 59;
                    Minuten = 59;
                    Stunde--;
                }
            }

            if (Sekunde == 0 && Minuten == 0 && Stunde == 0)
            {
                TimerLabelContent = SetTimerLabelContent();
                StopTimer();
                TimerFinished.Invoke(this, "Timer finished");
            }

            TimerLabelContent = SetTimerLabelContent();

            Totalzeit--.ToString();
        }

        private string SetTimerLabelContent()
        {
            string stundeString = "";
            string minuteString = "";
            string sekundeString = "";

            stundeString = Stunde < 10 ? $"0{Stunde}" : $"{Stunde}";
            minuteString = Minuten < 10 ? $"0{Minuten}" : $"{Minuten}";
            sekundeString = Sekunde < 10 ? $"0{Sekunde}" : $"{Sekunde}";

            return $"{stundeString}:{minuteString}:{sekundeString}";
        }

        public void StartTimer(Models.Timer TimerContext, DateTime Timerstartzeit)
        {
            this.TimerContext = TimerContext;
            Minuten = Convert.ToInt32(Timerstartzeit.Minute) * 60;
            Stunde = Convert.ToInt32(Timerstartzeit.Hour) * 3600;
            Sekunde = Convert.ToInt32(Timerstartzeit.Second);
            Totalzeit = Minuten + Stunde + Sekunde;

            if (Totalzeit >= 3600)
            {

                Stunde = Totalzeit / 3600;
                int min = Totalzeit % 3600;

                if (min > 60)
                {
                    Minuten = min / 60;
                    Sekunde = min % 60;
                }

                // this.timer_label.Content = "0" + Stunde + " : " + "0" + minutes + " : " +  Sekunde;

            }
            else if (Totalzeit >= 60)
            {
                Stunde = 0;
                Minuten = Totalzeit / 60;
                Sekunde = Totalzeit % 60;
                // this.timer_label.Content = "/" + Stunde + " : " + "0" + minutes + " : " +  Sekunde;
            }
            else
            {
                Stunde = 0;
                Minuten = 0;
                Sekunde = Totalzeit;
                // this.timer_label.Content = "/" + Stunde + " : " + "/" + minutes + " : " +  Sekunde;
            }

            //  this.textboxzeit.Text = totals.ToString();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
        }

        public void StopTimer()
        {
            UpdateTimerContext();
            TimerLabelContent = "";
            Timer.Stop();
        }

        /// <summary>
        /// Timer Update in der DAtenbank
        /// </summary>
        private void UpdateTimerContext()
        {
            TimerContext.Timerstartzeit = timerLabelContent;
            if(TimerContext.Timerstartzeit == "00:00:00")
            {
                TimerContext.Status = TimerStatus.Fertig.ToString();
            }
            else
            {
                TimerContext.Status = TimerStatus.InBearbeitung.ToString();
            }
            Repository.TimerUpdate(TimerContext);
        }
    }
}
