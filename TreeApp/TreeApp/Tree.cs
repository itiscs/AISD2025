using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeApp
{
    public class Elem
    {
        public int Info;
        public Elem Left;
        public Elem Right;

        public Elem() { }
        public Elem(string str) 
        {
            if (str[0] != '(')
            {
                Info = int.Parse(str);
                return;
            }

            str = str[1..^1];
            int k = str.IndexOf(',');
            Info = int.Parse(str[..k]);

            str = str[(k + 1)..];
            int l = GetFirstComma(str);
            if (l != 0)
                Left = new Elem(str[..l]);
            str = str[(l + 1)..];
            if(str != "")
                Right = new Elem(str);
        }

        private int GetFirstComma(string s)
        {
            int k = 0;
            for(int i = 0;i<s.Length;i++)
            {

                if (s[i] == ',' && k == 0)
                    return i;
                if (s[i] == '(')
                    k++;
                if(s[i] == ')')
                    k--;
            }
            return -1;
        }

        public int Sum()
        {
            int k = Info;
            if (Left != null)
            {
                k += Left.Sum();
            }
            if (Right != null)
            {
                k += Right.Sum();
            }
            return k;
        }


        public override string ToString()
        {
            //if (Left == null && Right == null)
            if (Left == Right)
                return Info.ToString();  
            var sb = new StringBuilder();
            sb.Append($"({Info.ToString()},");
            if(Left != null) 
                sb.Append(Left.ToString());
            sb.Append(",");    
            if(Right != null)
                sb.Append(Right.ToString());
            sb.Append(")");            
            return sb.ToString();
        }
        
    }
    public class Tree
    {
        public Elem Root;

        public Tree(string str)
        {
            if (str == null)
                return;
            Root = new Elem(str);
        }
                
         public Tree()
        {
            Root = new Elem()
            {  
                Info = 5,
                Left = new Elem()
                {
                    Info = 6,
                    Left = new Elem()
                    { 
                        Info = 8
                    },
                    Right = new Elem()
                    { 
                        Info = 9
                    }
                },
                Right = new Elem()
                {
                    Info = 7,                    
                    Right = new Elem()
                    {
                        Info = 2,
                        Left = new Elem()
                        {
                            Info = 3
                        }
                    }
                }
            };
        }

        public override string ToString()
        {
            return Root.ToString();
        }


        public int TreeSum()
        {
            //if(Root == null)   
            //    return 0;
            //return Root.Sum();
            return  TreeSum2(Root);
        }


        private int TreeSum2(Elem el)
        {
            if(el == null) return 0;

            return el.Info + TreeSum2(el.Left) + TreeSum2(el.Right);
        }

      


    }
}
