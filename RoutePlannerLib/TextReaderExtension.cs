using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhnw.Ecnf.RoutePlanner.RoutePlannerLib.Util
{
    public static class TextReaderExtension
    {
        public static IEnumerable<string[]> GetSplittedLines(this TextReader textReader, char separator)
        {
            var s = "";
            var sArray = new String[0];
            while ((s = textReader.ReadLine()) != null)
            {
                sArray = new String[s.Split(separator).Length];
                for (int i = 0; i < s.Split(separator).Length; i++)
                {
                    sArray[i] = s.Split(separator)[i];
                }
                yield return sArray;
            }
        }
    }
}
