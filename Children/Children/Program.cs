using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;
using Dropbox.Api;
using Dropbox.Api.Files;
using Microsoft.Win32;
using ScreenCapture;

namespace Children
{
    class Date
    {
        public int day      { get; set; }
        public int month    { get; set; }
        public int year     { get; set; }

        public Date() => (day, month, year) = (1, 1, 1900);
        public Date(int _day, int _month, int _year) => (day, month, year) = (_day, _month, _year);
        public Date(string str)
        {
            this.day = Int32.Parse(str.Substring(0, str.IndexOf('/')));
            this.month = Int32.Parse(str.Substring(str.IndexOf('/') + 1, str.LastIndexOf('/') - str.IndexOf('/') - 1));
            this.year = Int32.Parse(str.Substring(str.LastIndexOf('/') + 1));
        }

        public void CurrentDate()
        {
            this.day = DateTime.Now.Day;
            this.month = DateTime.Now.Month;
            this.year = DateTime.Now.Year;
        }
        public override string ToString()
        {
            string date = "";
            if (day < 10) date += "0";
            date += day.ToString() + "/";
            if (month < 10) date += "0";
            date += month.ToString() + "/";
            date += year.ToString();
            return date;
        }

        public override bool Equals(object o)
        {
            if (((Date)o).day == this.day && ((Date)o).month == this.month && ((Date)o).year == this.year)
                return true;
            else return false;
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public static bool operator ==(Date a, Date b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Date a, Date b)
        {
            return !a.Equals(b);
        }
    }
    class Time
    {
        public int hour { get; set; }
        public int minute { get; set; }
        public int second { get; set; }

        public Time() => (hour, minute, second) = (0, 0, 0);
        public Time(int _second) => (hour, minute, second) = (_second / 3600, _second / 60 - _second / 3600 * 60, _second % 60);
        public Time(int _hour, int _minute, int _second) => (hour, minute, second) = (_hour, _minute, _second);
        public Time(string str)
        {
            if (str.Substring(str.IndexOf(':') + 1).IndexOf(':') != -1)
            {
                this.hour = Int32.Parse(str.Substring(0, str.IndexOf(':')));
                this.minute = Int32.Parse(str.Substring(str.IndexOf(':') + 1, str.LastIndexOf(':') - str.IndexOf(':') - 1));
                this.second = Int32.Parse(str.Substring(str.LastIndexOf(':') + 1));
            }
            else
            {
                this.hour = Int32.Parse(str.Substring(0, str.IndexOf(':')));
                this.minute = Int32.Parse(str.Substring(str.IndexOf(':') + 1));
                this.second = 0;
            }

            fit();
        }

        public int getTime()
        {
            return hour * 3600 + minute * 60 + second;
        }
        public void setTime(int _hour, int _minute, int _second)
        {
            this.hour = _hour;
            this.minute = _minute;
            this.second = _second;
        }
        public void CurrentTime()
        {
            this.hour = DateTime.Now.Hour;
            this.minute = DateTime.Now.Minute;
            this.second = DateTime.Now.Second;
        }

        public void fit()
        {
            if (this.second >= 60)
            {
                this.minute = minute + second / 60;
                this.second = second % 60;
            }
            if (this.minute >= 60)
            {
                this.hour = hour + minute / 60;
                this.minute = minute % 60;
            }
        }
        public void unfit()
        {
            if (this.minute < 0)
            {
                this.hour = hour - 1;
                this.minute = minute + 60;
            }
            if (this.second < 0)
            {
                this.minute = minute - 1;
                this.second = second + 60;
            }
        }
        public override string ToString()
        {
            string time = "";
            if (hour < 10) time += "0";
            time += hour.ToString() + ":";
            if (minute < 10) time += "0";
            time += minute.ToString() + ":";
            if (second < 10) time += "0";
            time += second.ToString();
            return time;
        }

        public static Time operator +(Time a, Time b)
        {
            Time t = new Time
            {
                hour = a.hour + b.hour,
                minute = a.minute + b.minute,
                second = a.second + b.second,
            };
            t.fit();
            return t;
        }
        public static Time operator +(Time a, int s)
        {
            Time t = new Time
            {
                hour = a.hour + (s / 3600),
                minute = a.minute + (s / 60 - s / 3600 * 60),
                second = a.second + (s % 60),
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
                second = a.second - b.second,
            };
            t.unfit();
            return t;
        }
        public static Time operator -(Time a, int s)
        {
            Time t = new Time
            {
                hour = a.hour - (s / 3600),
                minute = a.minute - (s / 60 - s / 3600 * 60),
                second = a.second - (s % 60),
            };
            t.unfit();
            return t;
        }
        public override bool Equals(object o)
        {
            if (((Time)o).hour == this.hour && ((Time)o).minute == this.minute && ((Time)o).second == this.second)
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
            if (a.hour * 3600 + a.minute * 60 + a.second > b.hour * 3600 + b.minute * 60 + b.second)
                return true;
            else return false;
        }
        public static bool operator <(Time a, Time b)
        {
            if (a.hour * 3600 + a.minute * 60 + a.second < b.hour * 3600 + b.minute * 60 + b.second)
                return true;
            else return false;
        }
        public static bool operator >=(Time a, Time b)
        {
            if (a.hour * 3600 + a.minute * 60 + a.second >= b.hour * 3600 + b.minute * 60 + b.second)
                return true;
            else return false;
        }
        public static bool operator <=(Time a, Time b)
        {
            if (a.hour * 3600 + a.minute * 60 + a.second <= b.hour * 3600 + b.minute * 60 + b.second)
                return true;
            else return false;
        }
    }

    class TimeTable
    {
        public Time F { get; set; }
        public Time T { get; set; }
        public int D { get; set; }
        public int I { get; set; }
        public int S { get; set; }

        public TimeTable(Time _F, Time _T) => (F, T, D, I, S) = (_F, _T, 0, 0, 0);
        public TimeTable(Time _F, Time _T, int _S) => (F, T, D, I, S) = (_F, _T, 0, 0, _S);
        public TimeTable(Time _F, Time _T, int _D, int _I) => (F, T, D, I, S) = (_F, _T, _D, _I, 0);
        public TimeTable(Time _F, Time _T, int _D, int _I, int _S) => (F, T, D, I, S) = (_F, _T, _D, _I, _S);
    }

    public partial class NativeMethods
    {
        [DllImport("user32.dll", EntryPoint = "BlockInput")]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        public static extern bool BlockInput([MarshalAsAttribute(UnmanagedType.Bool)] bool fBlockIt);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindowByCaption(IntPtr zeroOnly, string lpWindowName);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        public static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        
    }

    public class TestTrapCtrlC
    {
        static bool exitSystem = false;

        #region Trap application termination
        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(EventHandler handler, bool add);

        private delegate bool EventHandler(CtrlType sig);
        static EventHandler _handler;

        enum CtrlType
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }

        private static bool Handler(CtrlType sig)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().IndexOf("Children")) + @"Children\\TurnOff.bat";
            proc.StartInfo.CreateNoWindow = false;
            proc.Start();
            proc.WaitForExit();

            //allow main to run off
            exitSystem = true;

            //shutdown right away so there are no lingering threads
            Environment.Exit(-1);

            return true;
        }
        #endregion

        public void Start()
        {

        }
        public static void Run()
        {
            // Some boilerplate to react to close window event, CTRL-C, kill, etc
            _handler += new EventHandler(Handler);
            SetConsoleCtrlHandler(_handler, true);

            //start your multi threaded program here
            TestTrapCtrlC p = new TestTrapCtrlC();
            p.Start();

            //hold the console so it doesn’t run off the end
            while (!exitSystem)
            {
                Thread.Sleep(500);
            }
        }
    }

    class Program
    {
        static string path = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().IndexOf("Children")) + @"Children";
        static string PasswordParent = "";
        static string PasswordChildren = "";
        static string AccessToken = "r8d6PBzZBuEAAAAAAAAAAe_43Ery2nmzzh81x5QMmxZNdWPq94UekSxRSJF93UWk";
        static string remote_path = "";
        static string local_path = "";
        static string remote_changed = "/Public/~CHANGED.txt";
        static string local_changed = path + "\\Cloud\\~CHANGED.txt";
        static bool StopThread = false;
        static Time _StartTime = new Time();
        static Time _SleepTime = new Time();
        static DirectoryInfo dic;

        static async Task UploadToCloud()
        {
            using (var dbx = new DropboxClient(AccessToken))
            {
                using (var mem = new MemoryStream(File.ReadAllBytes(local_path)))
                {
                    var updated = dbx.Files.UploadAsync(remote_path, WriteMode.Overwrite.Instance, body: mem);
                    updated.Wait();
                }
            }
        }
        static async Task DownloadFromCloud()
        {
            using (var dbx = new DropboxClient(AccessToken))
            {
                using (var response = await dbx.Files.DownloadAsync(remote_path))
                {
                    var s = response.GetContentAsByteArrayAsync();
                    s.Wait();
                    var d = s.Result;

                    File.WriteAllBytes(local_path, d);
                }
            }
        }
        static async Task UploadV2ToCloud()
        {
            using (var dbx = new DropboxClient(AccessToken))
            {
                using (var mem = new MemoryStream(File.ReadAllBytes(local_changed)))
                {
                    var updated = dbx.Files.UploadAsync(remote_changed, WriteMode.Overwrite.Instance, body: mem);
                    updated.Wait();
                }
            }
        }
        static async Task DownloadV2FromCloud()
        {
            using (var dbx = new DropboxClient(AccessToken))
            {
                using (var response = await dbx.Files.DownloadAsync(remote_changed))
                {
                    var s = response.GetContentAsByteArrayAsync();
                    s.Wait();
                    var d = s.Result;

                    File.WriteAllBytes(local_changed, d);
                }
            }
        }

        public static List<TimeTable> ReadFile()
        {
            List<TimeTable> TimeTable = new List<TimeTable>();
            string[] lines = File.ReadAllLines(path + "\\Cloud\\Time.txt");

            foreach (string line in lines)
            {
                string[] split_line = line.Split(' ');
                Time F = new Time(split_line[0].Substring(1));
                Time T = new Time(split_line[1].Substring(1));

                if (split_line.Length == 2)
                    TimeTable.Add(new TimeTable(F, T));
                else if (split_line.Length == 3)
                {
                    int S = Int32.Parse(split_line[2].Substring(1));
                    TimeTable.Add(new TimeTable(F, T, S));
                }
                else if (split_line.Length == 4)
                {
                    int D = Int32.Parse(split_line[2].Substring(1));
                    int I = Int32.Parse(split_line[3].Substring(1));
                    TimeTable.Add(new TimeTable(F, T, D, I));
                }
                else if (split_line.Length == 5)
                {
                    int D = Int32.Parse(split_line[2].Substring(1));
                    int I = Int32.Parse(split_line[3].Substring(1));
                    int S = Int32.Parse(split_line[4].Substring(1));
                    TimeTable.Add(new TimeTable(F, T, D, I, S));
                }
                else continue;
            }

            for (int i = 0; i < TimeTable.Count - 1; i++)
                for (int j = i + 1; j < TimeTable.Count; j++)
                    if (TimeTable[i].F > TimeTable[j].F)
                    {
                        TimeTable temp = TimeTable[i];
                        TimeTable[i] = TimeTable[j];
                        TimeTable[j] = temp;
                    }

            return TimeTable;
        }
        public static bool CheckTimeTable(List<TimeTable> TimeTable)
        {
            Time CurrentTime = new Time();
            CurrentTime.CurrentTime();

            for (int i = 0; i < TimeTable.Count; i++)
            {
                if (TimeTable[i].F <= CurrentTime && CurrentTime <= TimeTable[i].T)
                    return true;
            }
            return false;
        }
        public static TimeTable AllowTimeTable(List<TimeTable> TimeTable)
        {
            Time CurrentTime = new Time();
            CurrentTime.CurrentTime();

            TimeTable timetable = new TimeTable(new Time(0), new Time(0));
            for (int i = 0; i < TimeTable.Count; i++)
            {
                if (TimeTable[i].F <= CurrentTime && CurrentTime <= TimeTable[i].T)
                {
                    timetable = TimeTable[i];
                    break;
                }
            }
            return timetable;
        }
        public static bool CheckChangedTimeTable()
        {
            return File.Exists(local_changed) && File.ReadAllText(local_changed).Equals("1");
        }
        public static Time NextTime(List<TimeTable> TimeTable)
        {
            Time CurrentTime = new Time();
            CurrentTime.CurrentTime();

            Time NextTime = TimeTable[0].F;
            for (int i = 0; i < TimeTable.Count; i++)
            {
                if (CurrentTime >= TimeTable[i].F)
                    continue;
                else
                {
                    NextTime = TimeTable[i].F;
                    break;
                }
            }
            return NextTime;
        }
        public static Time UseTime(TimeTable timetable)
        {
            Time WasteTime = new Time();
            string[] lines = File.ReadAllLines(path + "\\Cloud\\LogTime.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                if (i == 0) continue;

                if (lines[i].IndexOf(' ') != lines[i].LastIndexOf(' '))
                {
                    Time a = new Time(lines[i].Substring(0, lines[i].IndexOf(' ')));
                    Time b = new Time(lines[i].Substring(lines[i].IndexOf(' ') + 1, lines[i].LastIndexOf(' ') - lines[i].IndexOf(' ') - 1));
                    Time c = new Time(lines[i].Substring(lines[i].LastIndexOf(' ') + 1));
                    if ((timetable.F <= a && a <= timetable.T) && (timetable.F <= b && b <= timetable.T))
                        WasteTime = WasteTime + c;
                }
                else continue;
            }

            Time UseTime = new Time();
            UseTime.CurrentTime();
            if (timetable.S == 0)
                UseTime = timetable.T - UseTime;
            else
            {
                Time TempTime = new Time(timetable.S * 60);
                if (TempTime < timetable.T - UseTime)
                    UseTime = TempTime;
                else
                    UseTime = timetable.T - UseTime;
            }

            Time FullTime = new Time();
            if (timetable.S == 0)
                FullTime = timetable.T - timetable.F;
            else
            {
                Time TempTime = new Time(timetable.S * 60);
                FullTime = TempTime;
            }

            if (FullTime - WasteTime > UseTime) return UseTime;
            else return FullTime - WasteTime;
        }
        public static void DisplayTimeTable(TimeTable TimeTable)
        {
            Console.WriteLine("Khung gio duoc dung");
            Console.WriteLine("\tFrom: \t\t" + TimeTable.F.ToString());
            Console.WriteLine("\tTo: \t\t" + TimeTable.T.ToString());
            Console.WriteLine("\tDuration: \t" + TimeTable.D.ToString());
            Console.WriteLine("\tInterrupt: \t" + TimeTable.I.ToString());
            Console.WriteLine("\tSum: \t\t" + TimeTable.S.ToString());
            Console.WriteLine();
        }

        public static void TurnOff()
        {
            // Turn off
            Console.Clear();
            Process proc = new Process();
            proc.StartInfo.FileName = path + "\\TurnOff.bat";
            proc.StartInfo.CreateNoWindow = false;
            proc.Start();
            proc.WaitForExit();
            Environment.Exit(0);
        }
        public static void Lock(int second)
        {
            string originalTitle = Console.Title;
            string uniqueTitle = Guid.NewGuid().ToString();
            Console.Title = uniqueTitle; Thread.Sleep(50);

            Form form = new Form();
            form.FormBorderStyle = FormBorderStyle.None;
            form.WindowState = FormWindowState.Maximized;
            form.ShowInTaskbar = false;
            form.Show();
            IntPtr handle = NativeMethods.FindWindowByCaption(IntPtr.Zero, uniqueTitle);
            IntPtr ThisConsole = NativeMethods.GetConsoleWindow();

            int HIDE = 0;
            int MAXIMIZE = 3;
            int MINIMIZE = 6;
            int RESTORE = 9;
            while (second > 0)
            {
                Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                NativeMethods.ShowWindow(ThisConsole, MAXIMIZE);
              
                NativeMethods.SetForegroundWindow(handle);
                form.Show();

                _SleepTime = _SleepTime + 1;
                Thread.Sleep(1000);
                second--;
            }

            form.Close();
        }
        public static void LockAndSleep()
        {
            // Lock
            string originalTitle = Console.Title;
            string uniqueTitle = Guid.NewGuid().ToString();
            Console.Title = uniqueTitle; Thread.Sleep(50);

            Form form = new Form();
            form.FormBorderStyle = FormBorderStyle.None;
            form.WindowState = FormWindowState.Maximized;
            form.ShowInTaskbar = false;
            form.Show();
            IntPtr handle = NativeMethods.FindWindowByCaption(IntPtr.Zero, uniqueTitle);
            IntPtr ThisConsole = NativeMethods.GetConsoleWindow();

            int HIDE = 0;
            int MAXIMIZE = 3;
            int MINIMIZE = 6;
            int RESTORE = 9;
            int second = 600;
            while (second > 0)
            {
                Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                NativeMethods.ShowWindow(ThisConsole, MAXIMIZE);

                NativeMethods.SetForegroundWindow(handle);
                form.Show();

                _SleepTime = _SleepTime + 1;
                Thread.Sleep(1000);
                second--;
            }

            form.Close();

            // Turn off
            Process proc = new Process();
            proc.StartInfo.FileName = path + "\\TurnOff.bat";
            proc.StartInfo.CreateNoWindow = false;
            proc.Start();
            proc.WaitForExit();
            Environment.Exit(0);
        }
        public static void DeleteAllImage()
        {
            DirectoryInfo di = new DirectoryInfo(path + "\\Image");
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }
        public static string GetImageFileName()
        {
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            int second = DateTime.Now.Second;

            string fname = "";
            if (day < 10) fname += "0";
            fname += day.ToString();
            if (month < 10) fname += "0";
            fname += month.ToString();
            fname += year.ToString();
            if (hour < 10) fname += "0";
            fname += hour.ToString();
            if (minute < 10) fname += "0";
            fname += minute.ToString();
            if (second < 10) fname += "0";
            fname += second.ToString();

            return fname + "_ScreenShot.png";
        }
        public static string GetImageFolder()
        {
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            string fname = "";
            if (day < 10) fname += "0";
            fname += day.ToString();
            if (month < 10) fname += "0";
            fname += month.ToString();
            fname += year.ToString();

            return fname;
        }
        public static void ScreenCaptured(string filename)
        {
            dic = new DirectoryInfo(path + "\\Image");
            if (!dic.Exists)
                dic.Create();

            PrintScreen ps = new PrintScreen();
            ps.CaptureScreenToFile(path + "\\Image\\" + filename, System.Drawing.Imaging.ImageFormat.Png);
        }

        static void Main(string[] args)
        {
            Thread thread1 = new Thread(() =>
            {
                TestTrapCtrlC.Run();
            });
            thread1.Start();

            remote_path = "/Public/LogTime.txt";
            local_path = path + "\\Cloud\\LogTime.txt";
            var task0 = Task.Run((Func<Task>)DownloadFromCloud);
            task0.Wait();

            Date CurrentDate = new Date();
            CurrentDate.CurrentDate();
            Date date_in_file = new Date(File.ReadAllLines(path + "\\Cloud\\LogTime.txt")[0]);
            if (date_in_file != CurrentDate)
                File.WriteAllText(path + "\\Cloud\\LogTime.txt", CurrentDate.ToString() + "\n");
            SystemEvents.SessionEnding += (s, e) =>
            {
                File.AppendAllText(path + "\\Cloud\\LogTime.txt", _StartTime.ToString() + " ");
                Time _EndTime = new Time();
                _EndTime.CurrentTime();
                File.AppendAllText(path + "\\Cloud\\LogTime.txt", _EndTime.ToString() + " ");
                Time _DurationTime = _EndTime - _StartTime - _SleepTime;
                File.AppendAllText(path + "\\Cloud\\LogTime.txt", _DurationTime.ToString() + "\n");

                remote_path = "/Public/LogTime.txt";
                local_path = path + "\\Cloud\\LogTime.txt";
                var task = Task.Run((Func<Task>)UploadToCloud);
                task.Wait();

                Thread.Sleep(5000);
            };

            int WrongPasswordCount = 0;

            Thread thread2 = new Thread(() =>
            {
                while (true)
                {
                    var task = Task.Run((Func<Task>)DownloadV2FromCloud);
                    task.Wait();
                }
            });
            thread2.Start();

            remote_path = "/Public/PasswordChildren.txt";
            local_path = path + "\\PasswordChildren.txt";
            var task1 = Task.Run((Func<Task>)DownloadFromCloud);
            task1.Wait();
            remote_path = "/Public/PasswordParent.txt";
            local_path = path + "\\PasswordParent.txt";
            var task2 = Task.Run((Func<Task>)DownloadFromCloud);
            task2.Wait();
            remote_path = "/Public/Time.txt";
            local_path = path + "\\Cloud\\Time.txt";
            var task3 = Task.Run((Func<Task>)DownloadFromCloud);
            task3.Wait();

            PasswordParent = File.ReadAllText(path + "\\PasswordParent.txt");
            PasswordChildren = File.ReadAllText(path + "\\PasswordChildren.txt");

            while (true)
            {
                if (CheckChangedTimeTable())
                {
                    remote_path = "/Public/PasswordChildren.txt";
                    local_path = path + "\\PasswordChildren.txt";
                    task1 = Task.Run((Func<Task>)DownloadFromCloud);
                    task1.Wait();
                    remote_path = "/Public/PasswordParent.txt";
                    local_path = path + "\\PasswordParent.txt";
                    task2 = Task.Run((Func<Task>)DownloadFromCloud);
                    task2.Wait();

                    PasswordParent = File.ReadAllText(path + "\\PasswordParent.txt");
                    PasswordChildren = File.ReadAllText(path + "\\PasswordChildren.txt");

                    remote_path = "/Public/Time.txt";
                    local_path = path + "\\Cloud\\Time.txt";
                    task3 = Task.Run((Func<Task>)DownloadFromCloud);
                    task3.Wait();
                }

                List<TimeTable> TimeTable = ReadFile();
                StopThread = false;

                Time StartTime = new Time();
                StartTime.CurrentTime();
                Time EndTime = new Time();
                EndTime = StartTime + 15;

                Thread thread3 = new Thread(() =>
                {
                    while (true)
                    {
                        Time CurrentTime = new Time();
                        CurrentTime.CurrentTime();

                        if (StopThread) break;
                        if (EndTime == CurrentTime)
                        {
                            Console.Clear();
                            Console.WriteLine("May tinh dang tat...");
                            Thread.Sleep(1000);
                            TurnOff();
                            break;
                        }
                        Thread.Sleep(1000);
                    }
                })
                {

                };
                thread3.Start();

                Console.Write("Nhap mat khau: ");
                string PasswordUser = Console.ReadLine();
                StopThread = true;

                Console.Clear();
                if (PasswordUser == PasswordParent)
                {
                    Console.WriteLine("Ban la phu huynh!");
                    Thread.Sleep(3600000);
                }
                else
                {
                    if (CheckTimeTable(TimeTable))
                    {
                        if (PasswordUser == PasswordChildren)
                        {
                            Console.WriteLine("Ban la tre con!");
                            Thread.Sleep(1000);
                            Console.Clear();

                            _StartTime.CurrentTime();
                            DeleteAllImage();

                            TimeTable timetable = AllowTimeTable(TimeTable);
                            Time _UseTime = UseTime(timetable);
                            Time _NextTime = NextTime(TimeTable);

                            Time ZeroTime = new Time();
                            int count = 0;
                            int time_to_screenshot = 0;
                            do
                            {
                                if (CheckChangedTimeTable())
                                {
                                    File.WriteAllText(path + "\\Cloud\\~CHANGED.txt", "0");
                                    Thread thread4 = new Thread(() =>
                                    {
                                        remote_path = "/Public/Time.txt";
                                        local_path = path + "\\Cloud\\Time.txt";
                                        var task = Task.Run((Func<Task>)DownloadFromCloud);
                                        task.Wait();

                                        TimeTable = ReadFile();
                                        timetable = AllowTimeTable(TimeTable);
                                        _UseTime = UseTime(timetable);
                                        _NextTime = NextTime(TimeTable);
                                    });
                                    thread4.Start();

                                    Time CurrentTime = new Time();
                                    CurrentTime.CurrentTime();
                                    if (timetable.T < CurrentTime) break;
                                }

                                // Capture screen
                                if (time_to_screenshot < 180) time_to_screenshot++;
                                else
                                {
                                    Thread thread5 = new Thread(() =>
                                    {
                                        ScreenCaptured(GetImageFileName());

                                        remote_path = "/Image/" + GetImageFolder() + "/" + GetImageFileName();
                                        local_path = path + "\\Image\\" + GetImageFileName();
                                        var task = Task.Run((Func<Task>)UploadToCloud);
                                        task.Wait();
                                    });
                                    thread5.Start();
                                    time_to_screenshot = 0;
                                }

                                // Show timetable
                                DisplayTimeTable(timetable);

                                // Remaining time & next time
                                Console.WriteLine("Thoi gian con lai: \t" + _UseTime.ToString());
                                Console.WriteLine("Thoi gian mo lai: \t" + _NextTime.ToString());

                                _UseTime = _UseTime - 1;
                                if (_UseTime < new Time(60))
                                    Console.WriteLine("Con 1 phut nua se tat may!");

                                if (timetable.D * 60 != 0 && timetable.I * 60 != 0)
                                {
                                    if (count < timetable.D * 60)
                                        count++;
                                    else
                                    {
                                        count = 0;
                                        Lock(timetable.I * 60);

                                        Time CurrentTime = new Time();
                                        CurrentTime.CurrentTime();
                                        if (_UseTime > timetable.T - CurrentTime)
                                            _UseTime = timetable.T - CurrentTime;
                                    }
                                }

                                Thread.Sleep(1000);
                                Console.Clear();
                            } while (_UseTime > ZeroTime);

                            TurnOff();
                        }
                        else
                        {
                            WrongPasswordCount++;
                            Console.WriteLine("Ban nhap sai mat khau lan thu " + WrongPasswordCount.ToString() + "!");
                            Thread.Sleep(5000);
                            if (WrongPasswordCount == 3)
                            {
                                WrongPasswordCount = 0;
                                Console.WriteLine("May tinh cua ban se bi khoa 10 phut");
                                LockAndSleep();
                            }
                        }
                    }
                    else
                    {
                        Console.Write("Thoi gian mo lai: ");
                        Console.WriteLine(NextTime(TimeTable).ToString());
                        Thread.Sleep(5000);
                    }
                }

                Console.Clear();
            }
        }
    }
}