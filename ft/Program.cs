using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ft.Resolver;
using ft.Finder;
using System.IO;

namespace ft
{
    class Program
    {
        /// <summary>
        /// -r 查询正则表达式
        /// -g 将分组捕获为结果，默认将匹配作为结果
        /// -s s为单行，m为多行，i为不区分大小写
        /// -ms 匹配结果之间的分隔符，默认为换行\r\n
        /// -gs 捕获分组作为结果时，各分组之间的分隔符，默认为制表符\t，非分组捕获时该选项无效
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            if (args.Length == 1 &&( args[0] == "-help" || args[0]=="-?"))
            {
                Console.WriteLine("-r 查询正则表达式");
                Console.WriteLine("-g 将分组捕获为结果，默认将匹配作为结果");
                Console.WriteLine("-s s为单行，m为多行，i为不区分大小写");
                Console.WriteLine("-ms 匹配结果之间的分隔符，默认为换行\\r\\n");
                Console.WriteLine("-gs 捕获分组作为结果时，各分组之间的分隔符，默认为制表符\\t，非分组捕获时该选项无效");
                return;
            }
            FinderResolver fr =  new FinderResolver(args);
            FinderBase fb = fr.Resolve();
            StreamReader reader = new StreamReader( Console.OpenStandardInput());
            string result = fb.Find(reader.ReadToEnd());
            Console.Write(result);
        }
    }
}
