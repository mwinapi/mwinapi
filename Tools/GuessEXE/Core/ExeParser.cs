using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GuessEXE.Core
{
    public class EXEFormatException : Exception
    {
        public EXEFormatException(string message) : base(message) { }
    }

    public class ImportTableEntry
    {
        private string dll;
        private IList<string> functions;

        public ImportTableEntry(string dll, IList<string> functions)
        {
            this.dll = dll;
            this.functions = functions;
        }

        public string DLL { get { return dll; } }
        public IList<string> Functions { get { return functions; } }
    }

    public class ExeSection
    {
        string name;
        int offset;
        int size;
        int voffset, vsize;

        public ExeSection(string _n, int _o, int _s, int _vo, int _vs)
        {
            name = _n;
            offset = _o;
            size = _s;
            voffset = _vo;
            vsize = _vs;
        }

        public string Name { get { return name; } }
        internal int Offset { get { return offset; } }
        internal int Size { get { return size; } }
        internal int VOffset { get { return voffset; } }
        internal int VSize { get { return vsize; } }
    }

    public class ExeParser : IDisposable
    {

        BinaryReader br;
        int offset;
        List<ExeSection> sections = new List<ExeSection>();
        KeyValuePair<int, int>[] dataDirectory = new KeyValuePair<int, int>[16];

        public ExeParser(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            br = new BinaryReader(fs);
            char[] mz = new char[2];
            br.Read(mz, 0, 2);
            if (mz[0] != 'M' || mz[1] != 'Z') throw new EXEFormatException("No MZ header found");
            br.BaseStream.Seek(0x3C, SeekOrigin.Begin);
            offset = br.ReadInt32();
            br.BaseStream.Seek(offset, SeekOrigin.Begin);
            char[] pe = new char[4];
            br.Read(pe, 0, 4);
            if (pe[0] != 'P' || pe[1] != 'E') throw new EXEFormatException("No PE header found");
            // skip file header
            br.BaseStream.Seek(20, SeekOrigin.Current);
            // skip optional header start (except datadirectory)
            br.BaseStream.Seek(96, SeekOrigin.Current);
            for (int i = 0; i < 16; i++)
            {
                int address = br.ReadInt32();
                int size = br.ReadInt32();
                dataDirectory[i] = new KeyValuePair<int, int>(address, size);
            }
            // parse section headers
            byte[] secname = new byte[8];

            for (int i = 0; i < 16; i++)
            {
                Array.Clear(secname, 0, 8);
                br.Read(secname, 0, 8);
                string s = Encoding.ASCII.GetString(secname);
                if (s.IndexOf('\0') != -1)
                    s = s.Substring(0, s.IndexOf('\0'));
                int vsize = br.ReadInt32();
                if (vsize == 0) break;
                int voffset = br.ReadInt32();
                int size = br.ReadInt32();
                int offs = br.ReadInt32();
                br.ReadInt64(); // relocations, line numbers,
                br.ReadInt64(); // characteristics
                sections.Add(new ExeSection(s, offs, size, voffset, vsize));
            }
        }


        public string StubSignature
        {
            get
            {
                string stub = BitConverter.ToString(ExeStub);
                if (stub == "0E-1F-BA-0E-00-B4-09-CD-21-B8-01-4C-CD-21-54-68-69-73-20-70-72-6F-67-72-61-6D-20-63-61-6E-6E-6F-74-20-62-65-20-72-75-6E-20-69-6E-20-44-4F-53-20-6D-6F-64-65-2E-0D-0D-0A-24-00-00-00-00-00-00-00")
                {
                    // This program cannot be run in DOS mode.
                    stub = "default";
                }
                else if (stub == "BA-0E-00-0E-1F-B4-09-CD-21-B8-01-4C-CD-21-57-69-6E-33-32-20-70-72-6F-67-72-61-6D-2E-0D-0A-24-00")
                {
                    // Win32 program.
                    stub = "short";
                }
                else if (stub == "BA-10-00-0E-1F-B4-09-CD-21-B8-01-4C-CD-21-90-90-54-68-69-73-20-70-72-6F-67-72-61-6D-20-6D-75-73-74-20-62-65-20-72-75-6E-20-75-6E-64-65-72-20-57-69-6E-33-32-0D-0A-24-37-00-00-00-00-00-00-00-00")
                {
                    // This program must be run under Win32
                    stub = "alternative";
                }
                else if (stub.StartsWith("0E-1F-BA-0E-00-B4-09-CD-21-B8-01-4C-CD-21-54-68-69-73-20-70-72-6F-67-72-61-6D-20-63-61-6E-6E-6F-74-20-62-65-20-72-75-6E-20-69-6E-20-44-4F-53-20-6D-6F-64-65-2E-0D-0D-0A-24-00-00-00-"))
                {
                    // This program cannot be run in DOS mode.
                    // last 4 bytes of stub "recycled"
                    stub = "default/" + stub.Substring(180);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("***" + ExtInfoLength + "+" + stub);
                }
                return ExtInfoLength + "+" + stub;
            }
        }
        public int ExtInfoLength
        {
            get
            {
                return Math.Max(0, (int)offset - 0x80);
            }
        }

        public byte[] ExeStub
        {
            get
            {
                int offs = 0x80;
                if (offs > offset) offs = offset;
                int length = (int)offs - 0x40;
                br.BaseStream.Seek(0x40, SeekOrigin.Begin);
                byte[] result = new byte[length];
                br.Read(result, 0, length);
                return result;
            }
        }

        public IList<ExeSection> Sections { get { return sections; } }

        public ExeSection getSectionByName(String name)
        {
            foreach (ExeSection s in sections)
            {
                if (s.Name == name) return s;
            }
            throw new KeyNotFoundException();
        }

        public IList<ImportTableEntry> ImportTable
        {
            get
            {
                List<ImportTableEntry> result = new List<ImportTableEntry>();
                KeyValuePair<int, int> imptbl = dataDirectory[1];
                if (imptbl.Key == 0) return result;
                int foffset;
                try
                {
                    foffset = TranslateVirtualOffset(imptbl.Key, imptbl.Value);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(">>" + e.Message);
                    return result;
                }
                br.BaseStream.Seek(foffset, SeekOrigin.Begin);
                for (int i = 0; i < imptbl.Value / 20; i++)
                {
                    int thunkPtr1 = br.ReadInt32();
                    br.ReadInt32();
                    br.ReadInt32();
                    int namePtr = br.ReadInt32();
                    int thunkPtr2 = br.ReadInt32();
                    if (namePtr == 0) break;
                    long offs = br.BaseStream.Position;
                    br.BaseStream.Seek(TranslateVirtualOffset(namePtr, 1), SeekOrigin.Begin);
                    string dll = readAsciiZ(br);
                    if (thunkPtr1 == 0) thunkPtr1 = thunkPtr2; // work around buggy linkers
                    br.BaseStream.Seek(TranslateVirtualOffset(thunkPtr1, 1), SeekOrigin.Begin);
                    List<string> importedFunctions = new List<string>();
                    int entry;
                    while ((entry = br.ReadInt32()) != 0)
                    {
                        if ((entry & 0x80000000) != 0)
                        {
                            // exported by ordinal
                            importedFunctions.Add("@" + (entry & 0x7FFFFFFF));
                        }
                        else
                        {
                            long savedoffset = br.BaseStream.Position;
                            br.BaseStream.Seek(TranslateVirtualOffset(entry, 3) + 2, SeekOrigin.Begin);
                            string func = readAsciiZ(br);
                            br.BaseStream.Seek(savedoffset, SeekOrigin.Begin);
                            importedFunctions.Add(func);
                        }
                    }
                    result.Add(new ImportTableEntry(dll, importedFunctions));
                    br.BaseStream.Seek(offs, SeekOrigin.Begin);
                }
                return result;
            }
        }

        private string readAsciiZ(BinaryReader br)
        {
            StringBuilder sb = new StringBuilder();
            byte b;
            while ((b = br.ReadByte()) != 0)
            {
                sb.Append(Encoding.Default.GetChars(new byte[] { b })[0]);
            }
            return sb.ToString();
        }

        public int TranslateVirtualOffset(int voffset, int vsize)
        {
            foreach (ExeSection s in sections)
            {
                if (voffset >= s.VOffset && voffset < s.VOffset + s.VSize)
                {
                    if (voffset + vsize > s.VOffset + s.VSize)
                        throw new ArgumentException("Not inside a section");
                    int offset = voffset - s.VOffset + s.Offset;
                    if (offset >= s.Offset + s.Size)
                    {
                        throw new ArgumentException("Inside uninitialized data");
                    }
                    if (offset + vsize > s.Offset + s.Size)
                        throw new ArgumentException("Partially uninitialized");
                    return offset;
                }
            }
            // TODO why does this happen?
            throw new ArgumentException("Invalid offset");
        }

        public void Dispose()
        {
            br.Close();
        }
    }
}
