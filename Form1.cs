using System;
using System.IO;
using System.Windows.Forms;
using System.Timers;

namespace TimeTracker
{
    public partial class FormMain : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        internal static extern IntPtr SetForegroundWindow(IntPtr hWnd);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        delegate void SetTextCallback();
        // Update frequency in milliseconds
        public int UpdateFrequency = 50;

        private DateTime startTime;
        private TimeSpan elapsedTime;
        private System.Timers.Timer updateTimer;
        private string timeStamp;

        private ulong timeBankSeconds;
        // Two last digits are the decimal places, 100 signifies 1,00 etc.
        private long currency;
        private byte hourlyRate;

        private SetTextCallback TimerTextUpdateCallback;
        private FileStream VolatileDataFileStream;
        byte[] programData;
        UInt16 dataVersion = 1;
        TimeSpan timeSinceLastStart;
        private bool firstTime = true;

        private string saveFile = "data.att";

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // #TODO Error handling
            VolatileDataFileStream = new FileStream(saveFile, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            ShowInTaskbar = false;
            notifyIcon.Visible = true;
            timeSinceLastStart = TimeSpan.Zero;
            TimerTextUpdateCallback = new SetTextCallback(UpdateTimerText);
            programData = new byte[10];

            updateTimer = new System.Timers.Timer(UpdateFrequency);
            updateTimer.Elapsed += new ElapsedEventHandler(Update);
            if (!LoadVolatileData())
            {
                Console.WriteLine("Couldn't read data from disk");
                Application.Exit();
            }
            else
                UpdateTimerText();

            Application.ApplicationExit += OnProcessExit;
        }

        private bool LoadVolatileData()
        {
            if (!File.Exists(saveFile))
                return false;

            VolatileDataFileStream.Position = 0;
            int offset = 0;

            try
            {
                //byte[] versionBytes = new byte[2];
                // Version data (2 bytes)
                VolatileDataFileStream.Read(programData, offset, 2);
                UInt16 loadedProgramDataVersion = BitConverter.ToUInt16(programData, 0);

                // Versioning: Handle loading possible old data formats here
                if (loadedProgramDataVersion == dataVersion)
                {
                    // Elapsed time (8 bytes)
                    offset = 2;
                    VolatileDataFileStream.Read(programData, offset, 8);
                }
                else if (loadedProgramDataVersion == 0)
                {
                    // No presaved data, let everything be at 0
                }
                else
                {
                    throw new Exception("Unknown saved data file version: " + loadedProgramDataVersion);
                }
                timeBankSeconds = BitConverter.ToUInt64(programData, 2);
                elapsedTime = TimeSpan.FromSeconds((double)timeBankSeconds);

                // #TODO Currency
                // #TODO Hourly rate
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private bool SaveVolatileData()
        {
            VolatileDataFileStream.Position = 0;
            int offset = 0;

            try
            {
                // Temp buffer for reading byte data, max size 8 bytes
                byte[] tempBytes = new byte[8];
                // Version (2-bytes)
                tempBytes = BitConverter.GetBytes(dataVersion);
                programData[0] = tempBytes[0];
                programData[1] = tempBytes[1];

                // Time (8-bytes)
                offset = 2;
                timeBankSeconds = (ulong)(timeSinceLastStart + elapsedTime).TotalSeconds;
                tempBytes = BitConverter.GetBytes(timeBankSeconds);
                for (int i = 0; i < 8; i++)
                {
                    programData[offset+i] = tempBytes[i];
                }

                // Save it all
                VolatileDataFileStream.Write(programData, 0, programData.Length);

                // #TODO Currency
                // #TODO Hourly rate
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void UpdateTimerText()
        {
            if (labelTimer.InvokeRequired)
            {
                BeginInvoke(TimerTextUpdateCallback);
            }
            else
            {
                TimeSpan timeText = timeSinceLastStart + elapsedTime;
                timeStamp = timeText.ToString(ConstructTimeFormatString(timeText));
                if (timeText < TimeSpan.Zero)
                    timeStamp = "-" + timeStamp;
                labelTimer.Text = timeStamp;
            }
        }
        

        private string ConstructTimeFormatString(TimeSpan ts)
        {
            string result = "";
            if (ts > TimeSpan.FromDays(1))
                result += "d'd '";
            if (ts > TimeSpan.FromHours(1))
                result += "h'h '";
            if (ts > TimeSpan.FromMinutes(1))
                result += "m'm '";
            result += "s's'";
            return result;
        }

        void Update(object sender, ElapsedEventArgs e)
        {
            if (updateTimer.Enabled)
                timeSinceLastStart = DateTime.Now - startTime;
            else
                timeSinceLastStart = TimeSpan.Zero;
            UpdateTimerText();
            timeBankSeconds = (ulong)(timeSinceLastStart + elapsedTime).TotalSeconds;
        }

        void OnProcessExit(object sender, EventArgs e)
        {
            SaveVolatileData();
            VolatileDataFileStream.Close();
            updateTimer.Elapsed -= Update;
            if (VolatileDataFileStream != null)
                VolatileDataFileStream.Close();
        }

        private void buttonStartTimer_Click(object sender, EventArgs e)
        {
            if (updateTimer.Enabled)
            {
                // Stopping
                updateTimer.Enabled = false;
                timeSinceLastStart = DateTime.Now - startTime;
                elapsedTime += timeSinceLastStart;
                timeSinceLastStart = TimeSpan.Zero;
                UpdateTimerText();
                SaveVolatileData();
                buttonStartTimer.Text = "Start Timer";
            }
            else
            {
                // Starting
                startTime = DateTime.Now;
                updateTimer.Enabled = true;
                buttonStartTimer.Text = "Stop Timer";
            }
        }

        private void ApplyTimeDifference(TimeSpan timespan)
        {
            elapsedTime += timespan;
            UpdateTimerText();
            SaveVolatileData();
        }

        private void buttonAddTime_Click(object sender, EventArgs e)
        {
            TimeSpan TimeToAdd = TimeSpan.Zero;
            TimeToAdd += TimeSpan.FromSeconds((double)numericUpDownSeconds.Value);
            TimeToAdd += TimeSpan.FromMinutes((double)numericUpDownMinutes.Value);
            TimeToAdd += TimeSpan.FromHours((double)numericUpDownHours.Value);

            Console.WriteLine("Time to add: " + TimeToAdd.ToString());
            ApplyTimeDifference(TimeToAdd);
        }

        private void buttonRemoveTime_Click(object sender, EventArgs e)
        {
            TimeSpan TimeToRemove = TimeSpan.Zero;
            TimeToRemove -= TimeSpan.FromSeconds((double)numericUpDownSeconds.Value);
            TimeToRemove -= TimeSpan.FromMinutes((double)numericUpDownMinutes.Value);
            TimeToRemove -= TimeSpan.FromHours((double)numericUpDownHours.Value);

            Console.WriteLine("Time to remove: " + TimeToRemove.ToString());
            ApplyTimeDifference(TimeToRemove);
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Activate();
            if (WindowState == FormWindowState.Minimized)
                WindowState = FormWindowState.Normal;
        }
    }
}
