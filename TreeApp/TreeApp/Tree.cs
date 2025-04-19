using System;
using System.Collections.Generic;
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
