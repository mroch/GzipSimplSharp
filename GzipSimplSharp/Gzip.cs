using System;
using System.Text;
using Crestron.SimplSharp;      // For Basic SIMPL# Classes
using Crestron.SimplSharp.CrestronIO;
using Crestron.SimplSharp.CrestronIO.Compression;

namespace GzipSimplSharp
{
    public class Gzip
    {

        /// <summary>
        /// SIMPL+ can only execute the default constructor. If you have variables that require initialization, please
        /// use an Initialize method
        /// </summary>
        public Gzip()
        {
        }

        /// <summary>
        /// Decompresses a SIMPL+ string containing gzipped data.
        /// </summary>
        public string Decompress(string str)
        {
            byte[] bytes = StringToBytes(str);
            using (MemoryStream src = new MemoryStream(bytes),
                                dest = new MemoryStream())
            {
                using (var gs = new GZipStream(src, CompressionMode.Decompress))
                {
                    byte[] tmp = new byte[4096];
                    int cnt;
                    while ((cnt = gs.Read(tmp, 0, tmp.Length)) != 0)
                    {
                        dest.Write(tmp, 0, cnt);
                    }
                }
                byte[] outbytes = dest.ToArray();
                string outstr = BytesToString(outbytes);
                return outstr;
            }
        }

        /// <summary>
        /// Converts a UTF-16 string to an array of bytes, throwing away the
        /// upper byte. Crestron strings are UTF-16LE, so "\x3F" in SIMPL+ is
        /// \u003F (\x3F\x00, since it's little endian) in C#; this function
        /// drops the \x00.
        /// </summary>
        private byte[] StringToBytes(string str)
        {
            byte[] bytes = new byte[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                bytes[i] = (byte)str[i];
            }
            return bytes;
        }

        /// <summary>
        /// Converts a byte array to a UTF-16 string, converting each byte into
        /// a 16-bit char by padding the upper 8 bits with zeros. For example,
        /// \x3F becomes \u003F.
        /// </summary>
        private string BytesToString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length];
            for (int i = 0; i < bytes.Length; i++)
            {
                chars[i] = (char)bytes[i];
            }
            return new string(chars);
        }
    }
}