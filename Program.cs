using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Linq;


namespace hwapp
{

    static class IntExtension
    {
        public static int twice(this int self)
        {
            return self*2;
        }
        public static void times(this int self, Action action)
        {
            for(int i=0; i<self; ++i)
            action();
        }
    }
    public abstract class Union3<A, B, C>
    {
        public abstract T Match<T>(Func<A, T> f, Func<B, T> g, Func<C, T> h);
        // private ctor ensures no external classes can inherit
        private Union3() { } 

        public sealed class Case1 : Union3<A, B, C>
        {
            public readonly A Item;
            public Case1(A item) : base() { this.Item = item; }
            public override T Match<T>(Func<A, T> f, Func<B, T> g, Func<C, T> h)
            {
                return f(Item);
            }
        }

        public sealed class Case2 : Union3<A, B, C>
        {
            public readonly B Item;
            public Case2(B item) { this.Item = item; }
            public override T Match<T>(Func<A, T> f, Func<B, T> g, Func<C, T> h)
            {
                return g(Item);
            }
        }

        public sealed class Case3 : Union3<A, B, C>
        {
            public readonly C Item;
            public Case3(C item) { this.Item = item; }
            public override T Match<T>(Func<A, T> f, Func<B, T> g, Func<C, T> h)
            {
                return h(Item);
            }
        }
    }





    class Program
    {
        static void Main(string[] args)
        {

            Union3<int, char, string>[] unions = new Union3<int,char,string>[]
                {
                    new Union3<int, char, string>.Case1(5),
                    new Union3<int, char, string>.Case2('x'),
                    new Union3<int, char, string>.Case3("Juliet")
                };

            foreach (Union3<int, char, string> union in unions)
            {
                string value = union.Match(
                    num => num.ToString(),
                    character => new string(new char[] { character }),
                    word => word);
                Console.WriteLine("Matched union with value '{0}'", value);
            }
            
            var number = 3;
            switch (number)
            {
                case int even when even%2==0 :
                    Console.WriteLine("even");
                    break;
                case int odd when odd%2==1:
                    Console.WriteLine("odd");
                break;

            }

            3.times(()=>Console.WriteLine("Hello World!"));
        }
    }
}
