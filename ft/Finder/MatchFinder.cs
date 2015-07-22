using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ft.Finder
{
    public class MatchFinder : FinderBase
    {
        public MatchFinder(Regex reg,string ms= "\r\n") : base(reg,ms) { }

        public override string Find(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                return null;
            }
            MatchCollection matches = Reg.Matches(content);
            List<string> results = new List<string>();
            foreach (Match match in matches)
            {
                results.Add(match.Value);
            }
            return string.Join(MS, results);
        }
    }
}
