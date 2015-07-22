using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ft.Finder;
using System.Text.RegularExpressions;

namespace ft.Resolver
{
    public  class FinderResolver
    {
        protected Dictionary<string, string> Paras{get;set;}
        public FinderResolver(string[] args){
            if (args == null || args.Length < 1)
            {
                throw new Exception("参数个数不能小于0!");
            }

            Paras = new Dictionary<string, string>();
            for (int i = 0; i < args.Length;)
			{
                string argName = args[i].ToLower().Trim();
                string argValue = null;
                if (!argName.Contains("-m") && !argName.Contains("-g"))
                {
                    if (i < args.Length)
                    {
                        i++;
                        argValue = args[i];
                    }
                }
                if (Paras.ContainsKey(argName))
                {
                    Paras[argName] = argValue;
                }
                else
                {
                    Paras.Add(argName, argValue);
                }
                i++;
			}

            if (!Paras.ContainsKey("-r"))
            {
                throw new Exception("-r参数不能为空!");
            }
        }



        public FinderBase Resolve()
        {
            Regex regex = CreateFinderRegex();
            
            string ms ;
            string gs ;
            ms = Paras.ContainsKey("-ms") ? Paras["-ms"] : "\r\n";
            gs = Paras.ContainsKey("-gs") ? Paras["-gs"] : "\t";
            if (Paras.ContainsKey("-g"))
            {
               return new GroupFinder(regex, ms,gs);
            }
            else
            {
                return new MatchFinder(regex,ms);
            }
        }

        private Regex CreateFinderRegex()
        {
            RegexOptions ro = new RegexOptions();
            if (Paras.ContainsKey("-s"))
            {
                string options = Paras["-s"].ToLower().Trim();
                if (options.Contains('s'))
                {
                    ro |= RegexOptions.Singleline;    
                }
                else
                {
                    ro |= RegexOptions.Multiline;
                }

                if (options.Contains('i'))
                {
                    ro |= RegexOptions.IgnoreCase;
                }
            }
            Regex regex = new Regex(Paras["-r"],ro);

            return regex;
        }

    }
}
