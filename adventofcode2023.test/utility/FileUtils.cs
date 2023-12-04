using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2023.test.utility
{
    internal class FileUtils
    {
        public static String[] ReadAllLines(String FilePath)
        {
            String RealPath = "..\\..\\..\\resources\\" + FilePath;
            return File.ReadAllLines(RealPath);
        }
    }
}
