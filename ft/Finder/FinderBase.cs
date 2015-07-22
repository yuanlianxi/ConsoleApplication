using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ft.Finder
{
    public abstract class FinderBase
    {
        public Regex Reg { get; set; } 
        public string MS { get; set; }
        public FinderBase(Regex reg, string ms) { Reg = reg; MS = ms; }
        public abstract string Find(string content);
    }
}
