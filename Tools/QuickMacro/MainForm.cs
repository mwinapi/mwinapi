using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ManagedWinapi;
using ManagedWinapi.Hooks;
using System.Threading;
using QuickMacro.Properties;

namespace QuickMacro
{
    public partial class MainForm : Form
    {
        MacroState state = MacroState.STOPPED;
        int lastTickCount = 0;
        bool llhook, bi;

        // for journal hooks
        JournalRecordHook rec;
        JournalPlaybackHook play;
        int index;
        List<JournalMessage> macro = new List<JournalMessage>();

        // for low-level hooks
        LowLevelKeyboardHook kbd;
        LowLevelMouseHook mouse;
        InputBlocker iblock;
        List<LowLevelMessage> llmacro = new List<LowLevelMessage>();
        int llindex;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetHotkeys();
            trayIcon.Icon = Resources.stopped;
            this.Icon = Resources.stopped;
        }

        private void SetHotkeys()
        {
            playHotkey.Enabled = false;
            recHotkey.Enabled = false;
            recHotkey.KeyCode = recHotkeyBox.KeyCode;
            recHotkey.Ctrl = recHotkeyBox.Ctrl;
            recHotkey.Alt = recHotkeyBox.Alt;
            recHotkey.Shift = recHotkeyBox.Shift;
            recHotkey.WindowsKey = recHotkeyBox.WindowsKey;
            playHotkey.KeyCode = playHotkeyBox.KeyCode;
            playHotkey.Ctrl = playHotkeyBox.Ctrl;
            playHotkey.Alt = playHotkeyBox.Alt;
            playHotkey.Shift = playHotkeyBox.Shift;
            playHotkey.WindowsKey = playHotkeyBox.WindowsKey;
            llhook = lowLevelHook.Checked;
            bi = blockInput.Checked;
            try
            {
                playHotkey.Enabled = true;
                recHotkey.Enabled = true;
            }
            catch (HotkeyAlreadyInUseException)
            {
                MessageBox.Show("At least one hotkey is already in use.");
                playHotkey.Enabled = false;
                recHotkey.Enabled = false;
            }
        }

        private void set_Click(object sender, EventArgs e)
        {
            SetHotkeys();
        }

        private void recHotkey_HotkeyPressed(object sender, EventArgs e)
        {
            if (state == MacroState.STOPPED)
            {
                if (llhook)
                    llmacro.Clear();
                else
                    macro.Clear();
                state = MacroState.RECORDING;
                lastTickCount = 0;
                timer1.Enabled = true;
            }
            else if (state == MacroState.PLAYING)
            {
                // do nothing
            }
            else if (state == MacroState.RECORDING)
            {
                lastTickCount = Environment.TickCount;
                state = MacroState.RECORDING_DELAY;
                RemoveEvent(recHotkey.KeyCode);
            }
            else if (state == MacroState.RECORDING_DELAY)
            {
                state = MacroState.RECORDING;
                lastTickCount = Environment.TickCount - lastTickCount;
                RemoveEvent(recHotkey.KeyCode);
            }
            UpdateIcons();
        }

        private void UpdateIcons()
        {
            Icon ic;
            switch (state)
            {
                case MacroState.STOPPED: ic = Resources.stopped; break;
                case MacroState.PLAYING: ic = Resources.play; break;
                case MacroState.RECORDING: ic = Resources.record; break;
                case MacroState.RECORDING_DELAY: ic = Resources.recdelay; break;
                default: throw new Exception();
            }
            this.Icon = ic;
            trayIcon.Icon = ic;
        }

        void rec_RecordEvent(object sender, JournalRecordEventArgs e)
        {
            JournalMessage m = e.RecordedMessage;
            if (state == MacroState.RECORDING)
            {
                m.Time = lastTickCount;
                lastTickCount = 0;
            }
            else if (state == MacroState.RECORDING_DELAY)
            {
                int ltc = lastTickCount;
                lastTickCount = m.Time;
                m.Time -= ltc;
            }
            else
            {
                MessageBox.Show("Error: Invalid state");
            }
            macro.Add(m);
        }

        void ll_MessageIntercepted(LowLevelMessage m, ref bool handled)
        {

            if (state == MacroState.RECORDING)
            {
                m.Time = lastTickCount;
                lastTickCount = 0;
            }
            else if (state == MacroState.RECORDING_DELAY)
            {
                int ltc = lastTickCount;
                lastTickCount = m.Time;
                m.Time -= ltc;
            }
            else
            {
                MessageBox.Show("Error: Invalid state");
            }
            llmacro.Add(m);

        }

        private void playHotkey_HotkeyPressed(object sender, EventArgs e)
        {
            if (state == MacroState.STOPPED)
            {
                lastTickCount = Environment.TickCount;
                state = MacroState.PLAYING;
                if (llhook)
                {
                    llindex = 0;
                    if(bi) iblock = new InputBlocker();
                    playTimer.Interval = 1;
                    playTimer.Enabled = true;
                }
                else
                {
                    index = 0;
                    play = new JournalPlaybackHook();
                    play.GetNextJournalMessage += new JournalPlaybackHook.JournalQuery(play_GetNextJournalMessage);
                    play.StartHook();
                }
            }
            else if (state == MacroState.PLAYING)
            {
                // do nothing
            }
            else
            {
                if (llhook)
                {
                    kbd.Unhook();
                    mouse.Unhook();
                }
                else
                {
                    rec.Unhook();
                }
                state = MacroState.STOPPED;
                RemoveEvent(playHotkey.KeyCode);
            }
            UpdateIcons();
        }

        private void RemoveEvent(Keys keys)
        {
            if (llhook)
            {
                for (int i = llmacro.Count - 1; i >= 0; i--)
                {
                    LowLevelKeyboardMessage llm = llmacro[i] as LowLevelKeyboardMessage;
                    if (llm != null && llm.VirtualKeyCode == (int)keys)
                    {
                        llmacro.RemoveAt(i);
                        return;
                    }
                }
                MessageBox.Show("Event not found!");
            }
            else
            {
                // not needed
            }
        }

        JournalMessage play_GetNextJournalMessage(ref int timestamp)
        {
            if (index >= macro.Count)
            {
                index = -1;
                timestamp = Environment.TickCount + 500;
                System.Diagnostics.Debug.WriteLine("NearEND");
                return null;
            }
            else if (index == -1)
            {
                state = MacroState.STOPPED;
                UpdateIcons();
                System.Diagnostics.Debug.WriteLine("END");
                return null;
            }
            else
            {
                int ltc = lastTickCount;
                timestamp = ltc + macro[index].Time;
                lastTickCount = timestamp;
                System.Diagnostics.Debug.WriteLine("REAL: " + timestamp + " " + Environment.TickCount + " " + macro[index]);
                index++;
                return macro[index - 1];
            }
        }

        private void playTimer_Tick(object sender, EventArgs e)
        {

            while (llindex < llmacro.Count)
            {
                int ltc = lastTickCount;
                int timestamp = ltc + llmacro[llindex].Time;
                if (timestamp > Environment.TickCount)
                {
                    playTimer.Interval = Math.Max(1, timestamp - Environment.TickCount - 5);
                    return;
                }
                llmacro[llindex].ReplayEvent();
                lastTickCount = timestamp;
                llindex++;
            }
            llindex = -1;
            state = MacroState.STOPPED;
            if (bi) iblock.Dispose();
            UpdateIcons();
            playTimer.Enabled = false;

        }

        private void hide_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void recordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void configureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (llhook)
            {
                kbd = new LowLevelKeyboardHook();
                mouse = new LowLevelMouseHook();
                kbd.MessageIntercepted += new LowLevelMessageCallback(ll_MessageIntercepted);
                mouse.MessageIntercepted += new LowLevelMessageCallback(ll_MessageIntercepted);
                kbd.StartHook();
                mouse.StartHook();
            }
            else
            {
                rec = new JournalRecordHook();
                rec.RecordEvent += new EventHandler<JournalRecordEventArgs>(rec_RecordEvent);
                rec.StartHook();
            }

        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Visible = true;
        }

        private void radio_Click(object sender, EventArgs e)
        {
            if (lowLevelHook.Checked)
            {
                blockInput.Enabled = true;
            }
            else
            {
                blockInput.Enabled = false;
                blockInput.Checked = true;
            }
        }
    }

    enum MacroState { STOPPED, RECORDING, RECORDING_DELAY, PLAYING }
}
