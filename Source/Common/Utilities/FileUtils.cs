using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoR.Common.Utilities
{
    public static class FileUtils
    {
        public static string FileSizeBytesToReadableValue(ulong bytes)
        {
            if (bytes < 0x400L)
            {
                return (bytes.ToString("N0") + " Bytes");
            }
            if (bytes < 0x100000L)
            {
                var num = ((double)bytes) / 1024.0;
                return (num.ToString("N2") + " KB");
            }
            if (bytes < 0x40000000L)
            {
                var num2 = ((double)bytes) / 1048576.0;
                return (num2.ToString("N2") + " MB");
            }
            if (bytes < 0x10000000000L)
            {
                var num3 = ((double)bytes) / 1073741824.0;
                return (num3.ToString("N2") + " GB");
            }
            var num4 = ((double)bytes) / 1099511627776.0;
            return (num4.ToString("N2") + " TB");
        }

        public static long FileSize(string file)
        {
            var fInfo = new FileInfo(file);
            return fInfo.Length;
        }

        public static long DirSize(string dirName)
        {
            var dir = new DirectoryInfo(dirName);
            return DirSize(dir);
        }

        public static long DirSize(DirectoryInfo dir)
        {
            return dir.GetFiles().Sum(fi => fi.Length) +
                   dir.GetDirectories().Sum(di => DirSize(di));
        }

        public static string Combine(string path1, params string[] paramstrs)
        {
            if (paramstrs == null || paramstrs.Length == 0)
                return path1;

            return CombineInternal(Path.DirectorySeparatorChar, path1, paramstrs[0], paramstrs.Skip(1).ToArray());
        }

        private static string CombineInternal(char slash, string path1, string path2, params string[] paramstrs)
        {
            return string.Format("{0}{1}{2}{3}", path1.RemoveLastChar(slash), slash, path2.RemoveFirstChar(slash), (paramstrs == null || paramstrs.Length == 0) ? string.Empty : PathString(paramstrs, slash));
        }

        private static string PathString(string[] paramstrs, char slash)
        {
            var sb = new StringBuilder();
            foreach (var item in paramstrs)
            {
                sb.Append(StringUtils.RemoveLastCharAndAddFirstChar(item, slash));
            }

            return sb.ToString();
        }

    }

}
