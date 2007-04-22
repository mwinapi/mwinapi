using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using ClipHancer.Properties;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ClipHancer
{
    class ClipboardEntry
    {

        readonly bool empty;
        readonly Dictionary<string, object> entries;
        readonly Dictionary<string, object> implicitEntries;
        readonly string caption;
        readonly Image previewImage;

        public bool Empty { get { return empty; } }

        public string Caption { get { return caption; } }

        public Image PreviewImage { get { return previewImage; } }



        public ClipboardEntry() : this(null) { }

        public ClipboardEntry(byte[] data, string prefix)
        {
            if (data.Length == 0)
            {
                empty = true;
                caption = "[Empty]";
                previewImage = new Bitmap(48, 48);
                Graphics g = Graphics.FromImage(previewImage);
                g.Clear(Color.White);
                g.Dispose();
                return;
            }
            MemoryStream ms = new MemoryStream(data);
            BinaryFormatter bf = new BinaryFormatter();
            empty = false;
            entries = (Dictionary<string, object>)bf.Deserialize(ms);
            implicitEntries = (Dictionary<string, object>)bf.Deserialize(ms);
            caption = prefix + (string)bf.Deserialize(ms);
            previewImage = (Image)bf.Deserialize(ms);
        }

        public ClipboardEntry(IDataObject ido)
        {
            previewImage = new Bitmap(48, 48);
            Graphics g = Graphics.FromImage(previewImage);
            g.Clear(Color.White);
            entries = new Dictionary<string, object>();
            implicitEntries = new Dictionary<string, object>();
            if (ido == null)
            {
                empty = true;
                caption = "[Empty]";
            }
            else
            {
                string[] formats = ido.GetFormats(false);
                if (formats.Length == 0)
                {
                    empty = true;
                    caption = "[Empty]";
                }
                else
                {
                    empty = false;
                    if (ido.GetDataPresent(DataFormats.StringFormat, true))
                    {
                        caption = (string)ido.GetData(DataFormats.StringFormat, true);
                        caption = caption.Replace('\r', ' ');
                        caption = caption.Replace('\n', ' ');
                        if (caption.Length > 100)
                        {
                            caption = caption.Substring(0, 100) + "...";
                        }
                    }
                    else if (ido.GetDataPresent(DataFormats.FileDrop, true))
                    {
                        string[] files = (string[])ido.GetData(DataFormats.FileDrop, true);
                        StringBuilder sb = new StringBuilder();
                        foreach (string file in files)
                        {
                            if (sb.Length != 0) sb.Append(",");
                            sb.Append(file);
                        }
                        caption = "{" + sb.ToString() + "}";
                    }
                    else
                    {
                        caption = "[" + formats[0] + "]";
                    }
                    foreach (string format in formats)
                    {
                        object value = ido.GetData(format, false);
                        if (value != null)
                        {
                            entries.Add(format, value);
                        }
                    }
                    string[] allFormats = ido.GetFormats(true);
                    foreach (string format in allFormats)
                    {
                        if (Array.IndexOf(formats, format) == -1)
                        {
                            object value = ido.GetData(format, false);
                            if (value != null)
                            {
                                implicitEntries.Add(format, value);
                            }
                        }
                    }
                    if (entries.Count == 0)
                    {
                        caption = "[All formats unusable!]";
                    }
                    if (ido.GetDataPresent(DataFormats.Bitmap, true))
                    {
                        Image image = (Image)ido.GetData(DataFormats.Bitmap, true);
                        g.DrawImage(image, 0, 0, 48, 48);
                    }
                    else if (ido.GetDataPresent(DataFormats.FileDrop, true))
                    {
                        g.DrawIcon(Resources.file, new Rectangle(0, 0, 48, 48));
                    }
                    else if (ido.GetDataPresent(DataFormats.Rtf, true))
                    {
                        g.DrawIcon(Resources.rtf, new Rectangle(0, 0, 48, 48));
                    }
                    else if (ido.GetDataPresent(DataFormats.Html, true))
                    {
                        g.DrawIcon(Resources.html, new Rectangle(0, 0, 48, 48));
                    }
                    else if (ido.GetDataPresent(DataFormats.Text, true))
                    {
                        g.DrawIcon(Resources.text, new Rectangle(0, 0, 48, 48));
                    }
                    else
                    {
                        g.DrawIcon(Resources.unknown, new Rectangle(0, 0, 48, 48));
                    }
                }
            }
            g.Dispose();
        }

        internal void CopyToClipboard()
        {
            if (empty)
            {
                Clipboard.Clear();
            }
            else
            {
                DataObject o = new DataObject();
                foreach (KeyValuePair<string, object> p in entries)
                {
                    o.SetData(p.Key, false, p.Value);
                }
                Clipboard.SetDataObject(o, true);
            }
        }

        internal void CopyToClipboard(string format)
        {
            if (format == null)
            {
                CopyToClipboard(); return;
            }
            object value = null;
            switch (format)
            {
                case "UnicodeText {CRLF}": format = "UnicodeText"; value = unicodeText().Replace("\r\n", "\n").Replace("\n", "\r\n"); break;
                case "UnicodeText {Single Line}": format = "UnicodeText"; value = unicodeText().Replace("\r\n", "\n").Replace("\n", " "); break;
                case "UnicodeText {Lower Case}": format = "UnicodeText"; value = unicodeText().ToLowerInvariant(); break;
                case "UnicodeText {Upper Case}": format = "UnicodeText"; value = unicodeText().ToUpperInvariant(); break;
                case "UnicodeText {No Whitespace}": format = "UnicodeText"; value = unicodeText().Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace(" ", ""); break;
                default: break;
            }
            if (format.StartsWith("UnicodeText {->"))
            {
                string s = unicodeText();
                string ss = s.Substring(3).Replace("\r\n", "\n");
                int pos = ss.IndexOf("\n");
                format = ss.Substring(0, pos);
                ss = ss.Substring(pos + 1);
                if (s.StartsWith("#%#"))
                {
                    value = ss;
                }
                else if (s.StartsWith("%#%"))
                {
                    value = ss.Split('\n');
                }
                else
                {
                    throw new Exception("Cannot parse: " + s);
                }
            }
            else if (format.EndsWith(" {->UnicodeText}"))
            {
                string f = format.Substring(0, format.Length - 16);
                format = "UnicodeText";
                object v = entries[f];
                if (v is string)
                {
                    value = "#%#" + f + "\r\n" + v;
                }
                else if (v is string[])
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("%#%" + f + "\r\n");
                    foreach (string vv in (string[])v)
                    {
                        sb.Append(vv + "\r\n");
                    }
                    value = sb.ToString();
                }
                else
                {
                    throw new Exception("Cannot parse: " + v);
                }
            }
            DataObject o = new DataObject();
            if (value == null) value = entries.ContainsKey(format) ? entries[format] : implicitEntries[format];
            o.SetData(format, false, value);
            Clipboard.SetDataObject(o, true);
        }

        internal IList<string> Formats
        {
            get
            {
                List<string> extra = new List<string>();
                if (empty) return extra;
                if (entries.ContainsKey("UnicodeText") || implicitEntries.ContainsKey("UnicodeText"))
                {
                    string s = unicodeText();
                    if (s.StartsWith("#%#") || s.StartsWith("%#%"))
                    {
                        string ss = s.Substring(3).Replace("\r\n", "\n");
                        int pos = ss.IndexOf("\n");
                        ss = ss.Substring(0, pos);
                        extra.Add("UnicodeText {->" + ss + "}");
                    }
                    else
                    {
                        extra.Add("UnicodeText {No Whitespace}");
                        if (s.Contains("\n"))
                        {
                            if (s != s.Replace("\r\n", "\n").Replace("\n", "\r\n"))
                            {
                                extra.Add("UnicodeText {CRLF}");
                            }
                            extra.Add("UnicodeText {Single Line}");
                        }
                        else
                        {
                            extra.Add("UnicodeText {Lower Case}");
                            extra.Add("UnicodeText {Upper Case}");
                        }
                    }
                }
                List<string> result = new List<string>();
                foreach (KeyValuePair<string, object> p in entries)
                {
                    result.Add(p.Key);
                    if (p.Key != "UnicodeText" && p.Key != "Text" && (p.Value is string || p.Value is string[]))
                    {
                        extra.Add(p.Key + " {->UnicodeText}");
                    }
                }
                if (implicitEntries.Keys.Count > 0 || extra.Count > 0)
                {
                    result.Add(null);
                    result.AddRange(implicitEntries.Keys);
                    if (extra.Count > 0)
                    {
                        result.Add(null);
                        result.AddRange(extra);
                    }
                }
                return result;
            }
        }

        private string unicodeText()
        {
            return (string)(entries.ContainsKey("UnicodeText") ? entries["UnicodeText"] : implicitEntries["UnicodeText"]);
        }

        public byte[] Serialize()
        {
            if (empty) return new byte[0];
            BinaryFormatter f = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            f.Serialize(ms, entries);
            f.Serialize(ms, implicitEntries);
            f.Serialize(ms, caption);
            f.Serialize(ms, previewImage);
            return ms.ToArray();
        }
    }
}
