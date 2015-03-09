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
            var sArray = new String[5];
            while ((s = textReader.ReadLine()) != null)
            {
                sArray[0] = s.Split(separator)[0];
                sArray[1] = s.Split(separator)[1];
                sArray[2] = s.Split(separator)[2];
                sArray[3] = s.Split(separator)[3];
                sArray[4] = s.Split(separator)[4];
                yield return sArray;
            }
        }
    }
}
