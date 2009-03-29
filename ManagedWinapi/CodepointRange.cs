using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ManagedWinapi
{
    /// <summary>
    /// The unicode range of codepoints supported by a font.
    /// </summary>
    public class CodepointRange
    {
        char[] ranges;
        readonly int codepointCount;

        /// <summary>
        /// Creates a new CodepointRange object for a font.
        /// </summary>
        public CodepointRange(Font font)
        {
            List<char> rangeList = new List<char>();
            Graphics g = Graphics.FromImage(new Bitmap(1, 1));
            IntPtr hdc = g.GetHdc();
            IntPtr hFont = font.ToHfont();
            IntPtr oldFont = SelectObject(hdc, hFont);
            uint size = GetFontUnicodeRanges(hdc, IntPtr.Zero);
            IntPtr glyphSet = Marshal.AllocHGlobal((int)size);
            GetFontUnicodeRanges(hdc, glyphSet);
            codepointCount = Marshal.ReadInt32(glyphSet, 8);
            int tmp = 0;
            int count = Marshal.ReadInt32(glyphSet, 12);
            for (int i = 0; i < count; i++)
            {
                char firstIncluded = (char)Marshal.ReadInt16(glyphSet, 16 + i * 4);
                char firstExcluded = (char)(firstIncluded + Marshal.ReadInt16(glyphSet, 18 + i * 4));
                if (firstExcluded == 0 && firstIncluded > 0)
                {
                    // when U+FFFF is included, firstExcluded will wrap around, so 
                    // provide a workaround here
                    tmp += 0x10000 - firstIncluded;
                }
                else if (firstExcluded > firstIncluded)
                {
                    tmp += firstExcluded - firstIncluded;
                }
                else
                {
                    throw new Exception("Invalid inclusion range: " + font.FontFamily.Name + " [" + ((int)firstIncluded).ToString("X4") + "-" + ((int)firstExcluded).ToString("X4") + "]");
                }
                rangeList.Add(firstIncluded);
                rangeList.Add(firstExcluded);
            }
            SelectObject(hdc, oldFont);
            DeleteObject(hFont);
            Marshal.FreeHGlobal(glyphSet);
            g.ReleaseHdc(hdc);
            g.Dispose();
            if (tmp != codepointCount) throw new Exception(font.FontFamily.Name);
            ranges = rangeList.ToArray();
            if (ranges.Length < 2) throw new Exception();
        }

        private CodepointRange(params char[] ranges)
        {
            if (ranges.Length < 2 || ranges.Length % 2 != 0)
                throw new ArgumentException();
            int tmp = 0;
            for (int i = 0; i < ranges.Length; i += 2)
            {
                char firstIncluded = ranges[i];
                char firstExcluded = ranges[i + 1];
                if (firstExcluded == 0 && firstIncluded > 0)
                {
                    // when U+FFFF is included, firstExcluded will wrap around, so 
                    // provide a workaround here
                    tmp += 0x10000 - firstIncluded;
                }
                else if (firstExcluded > firstIncluded)
                {
                    tmp += firstExcluded - firstIncluded;
                }
                else
                {
                    throw new Exception("Invalid inclusion range");
                }
            }
            codepointCount = tmp;
            this.ranges = ranges;
        }

        /// <summary>
        /// Returns a dictionary containing codepoint ranges of all fonts.
        /// If multiple fonts of one family (bold, italic, etc.) share their
        /// codepoint range, only their base font is included in this list,
        /// otherwise all different variants are included.
        /// </summary>
        public static Dictionary<Font, CodepointRange> GetRangesForAllFonts()
        {
            Dictionary<Font, CodepointRange> result = new Dictionary<Font, CodepointRange>();
            foreach (FontFamily ff in FontFamily.Families)
            {
                Font[] fonts = new Font[16];
                CodepointRange[] range = new CodepointRange[fonts.Length];
                for (int i = 0; i < fonts.Length; i++)
                {
                    if (ff.IsStyleAvailable((FontStyle)i))
                    {
                        fonts[i] = new Font(ff, 10, (FontStyle)i);
                        range[i] = new CodepointRange(fonts[i]);
                    }
                }
                int importantBits = 0;
                for (int bit = 1; bit < fonts.Length; bit <<= 1)
                {
                    for (int i = 0; i < fonts.Length; i++)
                    {
                        if ((i & bit) != 0) continue;
                        if (range[i] != null && range[i | bit] != null)
                        {
                            if (!range[i].Equals(range[i | bit]))
                            {
                                importantBits |= bit;
                                break;
                            }
                        }
                        else if (range[i] != null || range[i | bit] != null)
                        {
                            importantBits |= bit;
                            break;
                        }
                    }
                }
                for (int i = 0; i < fonts.Length; i++)
                {
                    if ((i & importantBits) != i || fonts[i] == null) continue;
                    result.Add(fonts[i], range[i]);
                }
            }
            return result;
        }

        /// <summary>
        /// The Multilingual European Subset No. 1.
        /// From CWA 13873:2000.
        /// </summary>
        public static readonly CodepointRange MES_1 = new CodepointRange(
            (char)0x0020, (char)0x007F, (char)0x00A0, (char)0x0100,
            (char)0x0100, (char)0x0114, (char)0x0116, (char)0x012C,
            (char)0x012E, (char)0x014E, (char)0x0150, (char)0x017F,
            (char)0x02C7, (char)0x02C8, (char)0x02D8, (char)0x02DC,
            (char)0x02DD, (char)0x02DE, (char)0x2015, (char)0x2016,
            (char)0x2018, (char)0x201A, (char)0x201C, (char)0x201E,
            (char)0x20AC, (char)0x20AD, (char)0x2122, (char)0x2123,
            (char)0x2126, (char)0x2127, (char)0x215B, (char)0x215F,
            (char)0x2190, (char)0x2194, (char)0x266A, (char)0x266B);


        /// <summary>
        /// The Multilingual European Subset No. 2.
        /// From CWA 13873:2000.
        /// </summary>
        public static readonly CodepointRange MES_2 = new CodepointRange(
            (char)0x0020, (char)0x007F, (char)0x00A0, (char)0x0100,
            (char)0x0100, (char)0x0180, (char)0x018F, (char)0x0190,
            (char)0x0192, (char)0x0193, (char)0x01B7, (char)0x01B8,
            (char)0x01DE, (char)0x01F0, (char)0x01FA, (char)0x0200,
            (char)0x0218, (char)0x021C, (char)0x021E, (char)0x0220,
            (char)0x0259, (char)0x025A, (char)0x027C, (char)0x027D,
            (char)0x0292, (char)0x0293, (char)0x02BB, (char)0x02BE,
            (char)0x02C6, (char)0x02C8, (char)0x02C9, (char)0x02CA,
            (char)0x02D8, (char)0x02DE, (char)0x02EE, (char)0x02EF,
            (char)0x0374, (char)0x0376, (char)0x037A, (char)0x037B,
            (char)0x037E, (char)0x037F, (char)0x0384, (char)0x038B,
            (char)0x038C, (char)0x038D, (char)0x038E, (char)0x03A2,
            (char)0x03A3, (char)0x03CF, (char)0x03D7, (char)0x03D8,
            (char)0x03DA, (char)0x03E2, (char)0x0400, (char)0x0460,
            (char)0x0490, (char)0x04C5, (char)0x04C7, (char)0x04C9,
            (char)0x04CB, (char)0x04CD, (char)0x04D0, (char)0x04EC,
            (char)0x04EE, (char)0x04F6, (char)0x04F8, (char)0x04FA,
            (char)0x1E02, (char)0x1E04, (char)0x1E0A, (char)0x1E0C,
            (char)0x1E1E, (char)0x1E20, (char)0x1E40, (char)0x1E42,
            (char)0x1E56, (char)0x1E58, (char)0x1E60, (char)0x1E62,
            (char)0x1E6A, (char)0x1E6C, (char)0x1E80, (char)0x1E86,
            (char)0x1E9B, (char)0x1E9C, (char)0x1EF2, (char)0x1EF4,
            (char)0x1F00, (char)0x1F16, (char)0x1F18, (char)0x1F1E,
            (char)0x1F20, (char)0x1F46, (char)0x1F48, (char)0x1F4E,
            (char)0x1F50, (char)0x1F58, (char)0x1F59, (char)0x1F5A,
            (char)0x1F5B, (char)0x1F5C, (char)0x1F5D, (char)0x1F5E,
            (char)0x1F5F, (char)0x1F7E, (char)0x1F80, (char)0x1FB5,
            (char)0x1FB6, (char)0x1FC5, (char)0x1FC6, (char)0x1FD4,
            (char)0x1FD6, (char)0x1FDC, (char)0x1FDD, (char)0x1FF0,
            (char)0x1FF2, (char)0x1FF5, (char)0x1FF6, (char)0x1FFF,
            (char)0x2013, (char)0x2016, (char)0x2017, (char)0x201F,
            (char)0x2020, (char)0x2023, (char)0x2026, (char)0x2027,
            (char)0x2030, (char)0x2031, (char)0x2032, (char)0x2034,
            (char)0x2039, (char)0x203B, (char)0x203C, (char)0x203D,
            (char)0x203E, (char)0x203F, (char)0x2044, (char)0x2045,
            (char)0x204A, (char)0x204B, (char)0x207F, (char)0x2080,
            (char)0x2082, (char)0x2083, (char)0x20A3, (char)0x20A5,
            (char)0x20A7, (char)0x20A8, (char)0x20AC, (char)0x20AD,
            (char)0x20AF, (char)0x20B0, (char)0x2105, (char)0x2106,
            (char)0x2116, (char)0x2117, (char)0x2122, (char)0x2123,
            (char)0x2126, (char)0x2127, (char)0x215B, (char)0x215F,
            (char)0x2190, (char)0x2196, (char)0x21A8, (char)0x21A9,
            (char)0x2200, (char)0x2201, (char)0x2202, (char)0x2204,
            (char)0x2206, (char)0x2207, (char)0x2208, (char)0x220A,
            (char)0x220F, (char)0x2210, (char)0x2211, (char)0x2213,
            (char)0x2219, (char)0x221B, (char)0x221E, (char)0x2220,
            (char)0x2227, (char)0x222C, (char)0x2248, (char)0x2249,
            (char)0x2259, (char)0x225A, (char)0x2260, (char)0x2262,
            (char)0x2264, (char)0x2266, (char)0x2282, (char)0x2284,
            (char)0x2295, (char)0x2296, (char)0x2297, (char)0x2298,
            (char)0x2302, (char)0x2303, (char)0x2310, (char)0x2311,
            (char)0x2320, (char)0x2322, (char)0x2329, (char)0x232B,
            (char)0x2500, (char)0x2501, (char)0x2502, (char)0x2503,
            (char)0x250C, (char)0x250D, (char)0x2510, (char)0x2511,
            (char)0x2514, (char)0x2515, (char)0x2518, (char)0x2519,
            (char)0x251C, (char)0x251D, (char)0x2524, (char)0x2525,
            (char)0x252C, (char)0x252D, (char)0x2534, (char)0x2535,
            (char)0x253C, (char)0x253D, (char)0x2550, (char)0x256D,
            (char)0x2580, (char)0x2581, (char)0x2584, (char)0x2585,
            (char)0x2588, (char)0x2589, (char)0x258C, (char)0x258D,
            (char)0x2590, (char)0x2594, (char)0x25A0, (char)0x25A1,
            (char)0x25AC, (char)0x25AD, (char)0x25B2, (char)0x25B3,
            (char)0x25BA, (char)0x25BB, (char)0x25BC, (char)0x25BD,
            (char)0x25C4, (char)0x25C5, (char)0x25CA, (char)0x25CC,
            (char)0x25D8, (char)0x25DA, (char)0x263A, (char)0x263D,
            (char)0x2640, (char)0x2641, (char)0x2642, (char)0x2643,
            (char)0x2660, (char)0x2661, (char)0x2663, (char)0x2664,
            (char)0x2665, (char)0x2667, (char)0x266A, (char)0x266C,
            (char)0xFB01, (char)0xFB03, (char)0xFFFD, (char)0xFFFE);

        /// <summary>
        /// The Multilingual European Subset No. 3B.
        /// From CWA 13873:2000.
        /// </summary>
        public static readonly CodepointRange MES_3B = new CodepointRange(
            (char)0x0020, (char)0x007F, (char)0x00A0, (char)0x0100,
            (char)0x0100, (char)0x0200, (char)0x0200, (char)0x0220,
            (char)0x0222, (char)0x0234, (char)0x0250, (char)0x02AE,
            (char)0x02B0, (char)0x02EF, (char)0x0300, (char)0x034F,
            (char)0x0360, (char)0x0363, (char)0x0374, (char)0x0376,
            (char)0x037A, (char)0x037B, (char)0x037E, (char)0x037F,
            (char)0x0384, (char)0x038B, (char)0x038C, (char)0x038D,
            (char)0x038E, (char)0x03A2, (char)0x03A3, (char)0x03CF,
            (char)0x03D0, (char)0x03D8, (char)0x03DA, (char)0x03F4,
            (char)0x0400, (char)0x0487, (char)0x0488, (char)0x048A,
            (char)0x048C, (char)0x04C5, (char)0x04C7, (char)0x04C9,
            (char)0x04CB, (char)0x04CD, (char)0x04D0, (char)0x04F6,
            (char)0x04F8, (char)0x04FA, (char)0x0531, (char)0x0557,
            (char)0x0559, (char)0x0560, (char)0x0561, (char)0x0588,
            (char)0x0589, (char)0x058B, (char)0x10D0, (char)0x10F7,
            (char)0x10FB, (char)0x10FC, (char)0x1E00, (char)0x1E9C,
            (char)0x1EA0, (char)0x1EFA, (char)0x1F00, (char)0x1F16,
            (char)0x1F18, (char)0x1F1E, (char)0x1F20, (char)0x1F46,
            (char)0x1F48, (char)0x1F4E, (char)0x1F50, (char)0x1F58,
            (char)0x1F59, (char)0x1F5A, (char)0x1F5B, (char)0x1F5C,
            (char)0x1F5D, (char)0x1F5E, (char)0x1F5F, (char)0x1F7E,
            (char)0x1F80, (char)0x1FB5, (char)0x1FB6, (char)0x1FC5,
            (char)0x1FC6, (char)0x1FD4, (char)0x1FD6, (char)0x1FDC,
            (char)0x1FDD, (char)0x1FF0, (char)0x1FF2, (char)0x1FF5,
            (char)0x1FF6, (char)0x1FFF, (char)0x2000, (char)0x2047,
            (char)0x2048, (char)0x204E, (char)0x206A, (char)0x2071,
            (char)0x2074, (char)0x208F, (char)0x20A0, (char)0x20B0,
            (char)0x20D0, (char)0x20E4, (char)0x2100, (char)0x213B,
            (char)0x2153, (char)0x2184, (char)0x2190, (char)0x21F4,
            (char)0x2200, (char)0x22F2, (char)0x2300, (char)0x237C,
            (char)0x237D, (char)0x239B, (char)0x2440, (char)0x244B,
            (char)0x2500, (char)0x2596, (char)0x25A0, (char)0x25F8,
            (char)0x2600, (char)0x2614, (char)0x2619, (char)0x2672,
            (char)0xFB00, (char)0xFB07, (char)0xFB13, (char)0xFB18,
            (char)0xFE20, (char)0xFE24, (char)0xFFF9, (char)0xFFFE);

        /// <summary>
        /// The number of codepoints supported by this font.
        /// </summary>
        public int SupportedCodepointCount { get { return codepointCount; } }

        /// <summary>
        /// The first (lowest) supported codepoint.
        /// </summary>
        public char FirstCodepoint { get { return ranges[0]; } }

        /// <summary>
        /// The last (highest) supported codepoint.
        /// </summary>
        public char LastCodepoint { get { return (char)(ranges[ranges.Length - 1] - 1); } }

        /// <summary>
        /// Tests whether a specific codepoint is supported by this font.
        /// </summary>
        public bool IsSupported(char codepoint)
        {
            bool result = false;
            bool first = true;
            foreach (char c in ranges)
            {
                if (c > codepoint || (c == 0 && !first)) break;
                first = false;
                result = !result;
            }
            return result;
        }

        /// <summary>
        /// Finds the next codepoint that is either supported or not.
        /// </summary>
        public char FindNext(char from, bool supported)
        {
            if (IsSupported(from) == supported) return from;
            foreach (char c in ranges)
            {
                if (c > from) return c;
            }
            return (char)0xFFFF;
        }

        /// <summary>
        /// Returns a <see cref="String"/> representation of this codepoint range.
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("[");
            for (int i = 0; i < ranges.Length; i++)
            {
                if (i % 2 == 1)
                {
                    if (ranges[i] == ranges[i - 1] + 1) continue;
                    sb.Append("-");
                }
                else if (i != 0)
                {
                    sb.Append(", ");
                }
                sb.Append(((int)ranges[i] - i % 2).ToString("X4"));
            }
            return sb.Append("]").ToString();
        }

        #region Equals and HashCode

        ///
        public override bool Equals(object obj)
        {
            CodepointRange cr = obj as CodepointRange;
            if (cr == null)
                return false;
            if (codepointCount != cr.codepointCount || ranges.Length != cr.ranges.Length)
                return false;
            for (int i = 0; i < ranges.Length; i++)
            {
                if (ranges[i] != cr.ranges[i])
                {
                    return false;
                }
            }
            return true;
        }

        ///
        public override int GetHashCode()
        {
            return 3 * codepointCount + 7 * ranges.Length + 9 * FirstCodepoint + 11 * LastCodepoint;
        }
        #endregion

        #region PInvoke Declarations
        [DllImport("gdi32.dll")]
        private static extern uint GetFontUnicodeRanges(IntPtr hdc, IntPtr lpgs);

        [DllImport("gdi32.dll")]
        private static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

        [DllImport("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);
        #endregion
    }
}
