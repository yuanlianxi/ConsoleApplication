using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ft.Finder
{
    public class GroupFinder:FinderBase
    {
        public string GS { get; set; }
        public GroupFinder(Regex reg,string ms="\r\n", string gs = "\t"):base(reg,ms) { GS = gs; }
        public override string Find(string content)
        {
            if (string.IsNullOrEmpty(content)) {
                return null;
            }
            string[] groupNames = Reg.GetGroupNames();
            MatchCollection matches = Reg.Matches(content);
            List<string> results = new List<string>();
            foreach (Match match in matches)
            {
                List<string> groupResult = new List<string>();
                for (int i = 1; i < groupNames.Length; i++)
                {
                    string groupName = groupNames[i];
                    groupResult.Add(match.Groups[groupName].Value);
                }
                results.Add(string.Join(GS, groupResult));
            }
            return string.Join(MS, results);
        }
    }
}
