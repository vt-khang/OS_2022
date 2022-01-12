using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parent
{
    class Time
    {
        public int hour    { get; set; }
        public int minute  { get; set; }

        public Time() => (hour, minute) = (0, 0);
        public Time(int minute) => (hour, minute) = (minute / 60, minute % 60);
        public Time(int _hour, int _minute) => (hour, minute) = (_hour, _minute);
        public Time(string str)
        {
            this.hour = Int32.Parse(str.Substring(0, str.IndexOf(":")));
            this.minute = Int32.Parse(str.Substring(str.IndexOf(":") + 1));

            fit();
        }


        public void CurrentTime()
        {
            this.hour = DateTime.Now.Hour;
            this.minute = DateTime.Now.Minute;
        }

        public void fit()
        {
            if (minute > 60)
            {
                this.hour = hour + minute / 60;
                this.minute = minute % 60;
            }
        }
        public void unfit()
        {
            if (minute < 0)
            {
                this.hour = hour - 1;
                this.minute = minute + 60;
            }
        }
        public override string ToString()
        {
            string time = "";
            if (hour < 10) time += "0";
            time += hour.ToString() + ":";
            if (minute < 10) time += "0";
            time += minute.ToString();
            return time;
        }
        public static int Convert(string str)
        {
            int hour = Int32.Parse(str.Substring(0, str.IndexOf(":")));
            int minute = Int32.Parse(str.Substring(str.IndexOf(":") + 1));
            return hour * 60 + minute;
        }

        public static Time operator +(Time a, Time b)
        {
            Time t = new Time
            {
                hour = a.hour + b.hour,
                minute = a.minute + b.minute,
            };
            t.fit();
            return t;
        }
        public static Time operator +(Time a, int m)
        {
            Time t = new Time
            {
                hour = a.hour + (m / 60),
                minute = a.minute + (m % 60),
            };
            t.fit();
            return t;
        }
        public static Time operator -(Time a, Time b)
        {
            Time t = new Time
            {
                hour = a.hour - b.hour,
                minute = a.minute - b.minute,
            };
            t.unfit();
            return t;
        }
        public static Time operator -(Time a, int m)
        {
            Time t = new Time
            {
                hour = a.hour - (m / 60),
                minute = a.minute - (m % 60),
            };
            t.unfit();
            return t;
        }
        public override bool Equals(object o)
        {
            if (((Time)o).hour == this.hour && ((Time)o).minute == this.minute)
                return true;
            else return false;
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public static bool operator ==(Time a, Time b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Time a, Time b)
        {
            return !a.Equals(b);
        }
        public static bool operator >(Time a, Time b)
        {
            if (a.hour * 60 + a.minute > b.hour * 60 + b.minute)
                return true;
            else return false;
        }
        public static bool operator <(Time a, Time b)
        {
            if (a.hour * 60 + a.minute < b.hour * 60 + b.minute)
                return true;
            else return false;
        }
        public static bool operator >=(Time a, Time b)
        {
            if (a.hour * 60 + a.minute >= b.hour * 60 + b.minute)
                return true;
            else return false;
        }
        public static bool operator <=(Time a, Time b)
        {
            if (a.hour * 60 + a.minute <= b.hour * 60 + b.minute)
                return true;
            else return false;
        }
    }

    class TimeTable
    {
        public Time F  { get; set; }
        public Time T  { get; set; }
        public int D   { get; set; }
        public int I   { get; set; }
        public int S   { get; set; }

        public TimeTable(Time _F, Time _T) => (F, T, D, I, S) = (_F, _T, 0, 0, 0);
        public TimeTable(Time _F, Time _T, int _S) => (F, T, D, I, S) = (_F, _T, 0, 0, _S);
        public TimeTable(Time _F, Time _T, int _D, int _I) => (F, T, D, I, S) = (_F, _T, _D, _I, 0);
        public TimeTable(Time _F, Time _T, int _D, int _I, int _S) => (F, T, D, I, S) = (_F, _T, _D, _I, _S);
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form());
        }
    }
}
