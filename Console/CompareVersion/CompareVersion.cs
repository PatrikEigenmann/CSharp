/* ---------------------------------------------------------------------------------------------------
 * CompareVersion.cs - Class CompareVersion with one static method to compare Version numbers. Version numbers
 * are stored in strings and can consist of but don't have the <major>.<minor>.<build>.<patch>.<compilation>.
 * So version numbers can look like "2" or "2.0.0". The method of the class should compare version1 and
 * version 2. The result of the compare is as follows:
 * version1 < version2 -> return -1
 * version1 = version2 -> return 0
 * version1 > version2 -> return 1
 * ---------------------------------------------------------------------------------------------------
 * Author : Patrik Eigenmann
 * eMail  : p.eigenmann@gmx.net
 * ---------------------------------------------------------------------------------------------------
 * Changelog
 * Sat 2023-12-23	File created													 Version 1.0.0.0.1
 * --------------------------------------------------------------------------------------------------- */

// Declare all usings
using System;			// Using System directive to simplify standart procedures in c#
using System.Linq;		// Using Language-Integrated Query to support complex data algorithms
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompareVersion
{
   /* ----------------------------------------------------------------------------------------------------
    * CustomCode - This class with the one static method VersionCompare to compare Version numbers. Version
    * numbers are stored in strings and can consist of but don't have the <major>.<minor>.<build>.<patch>.
    * <compilation>. So version numbers can look like "2" or "2.0.0". The method of the class should compare
    * version1 and version 2. The result of the compare is as follows:
    * version1 < version2 -> return -1
    * version1 = version2 -> return 0
    * version1 > version2 -> return 1
    * ---------------------------------------------------------------------------------------------------- */
    public static class CompareVersion
    {
        /* -------------------------------------------------------------------------------------------------
         * VersionCompare
         * @param1 string version1 - first version string 
         * @param2 string version2 - second version string
         * @return int (v1 < v2 -> -1, v1 = v2 -> 0, v1 > v2 -> 1)
         * ------------------------------------------------------------------------------------------------- */
        public static int VersionCompare(string version1, string version2)
        {
            // Split both parameters with the . seperator into the arrays v1 and v2
            var v1 = version1.Split('.').Select(int.Parse).ToArray();
            var v2 = version2.Split('.').Select(int.Parse).ToArray();

            // Iterate through the array and compare the parts from v1 and v2 to each other.
            for (int i = 0; i < Math.Max(v1.Length, v2.Length); i++)
            {
                // Taking each part of the version1 and
                // version2 and store it into part1 and part2
                int part1 = i < v1.Length ? v1[i] : 0;
                int part2 = i < v2.Length ? v2[i] : 0;

                if (part1 < part2) return -1;   // If part1 is smaller than part2 we can interrupt the loop and return -1

                if (part1 > part2) return 1;    // If part 1 is greater than part2 we can interrupt the loop and return 1
            }

            // If both version # are equal
            // we can return 0
            return 0;
        }
    }
}
