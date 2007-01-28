using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Microsoft.Win32;

namespace NeatKeys
{
    class PositionStore
    {

        static PositionStore instance;

        static readonly string REGISTRY_PATH = @"Software\SMsoft Michael Schierl\NeatKeys\0.1";

        public static PositionStore Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PositionStore();
                }
                return instance;
            }
        }

        bool modified = false;
        Rectangle?[] positions = new Rectangle?[36];


        private PositionStore()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(REGISTRY_PATH);
            if (key != null)
            {
                for (int i = 0; i < positions.Length; i++)
                {

                    string txt = (string)key.GetValue("" + i);
                    if (txt == "")
                    {
                        positions[i] = null;
                    }
                    else
                    {
                        string[] x = txt.Split(',');
                        positions[i] = new Rectangle(int.Parse(x[0]), int.Parse(x[1]), int.Parse(x[2]), int.Parse(x[3]));
                    }
                }
            }
        }
        
        public Rectangle? this[int i]
        {
            get
            {
                return positions[i];
            }
            set
            {
                positions[i] = value;
                modified = true;
            }
        }

        public void Save()
        {
            if (!modified) return;
            RegistryKey key = Registry.CurrentUser.CreateSubKey(REGISTRY_PATH);
            for (int i = 0; i < positions.Length; i++)
            {
                Rectangle? rr = positions[i];
                string txt = rr.HasValue ? (rr.Value.X+","+rr.Value.Y+","+rr.Value.Width+","+rr.Value.Height) : "";
                key.SetValue("" + i, txt);
            }
            modified = false;
        }
    }
}
