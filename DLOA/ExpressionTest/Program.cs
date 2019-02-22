using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTest
{
    class Program
    {
        public delegate int AddSum(int a, int b);
        static void Main(string[] args)
        {
            //AddSum addsum = delegate (int a, int b) { return a + b; };
            AddSum addsum = (a, b) => a + b;
            addsum(1, 2);
            //使用lamada来构造Expression
            //Expression<Func<Person, bool>> e = c => (c.id == 1) && (c.Name.Contains("k"));
            // var func= e.Compile();
            //var result= func.Invoke(new Person {
            //     id = 1,
            //     Name = "kill"
            // });
            //使用API来构造Expression
            ParameterExpression param= Expression.Parameter(typeof(Person),"P");

            MemberExpression id= Expression.Property(param, typeof(Person).GetProperty("id"));
            ConstantExpression idvalue = Expression.Constant(1);
            BinaryExpression e1= Expression.Equal(id,idvalue);

            MemberExpression Name = Expression.Property(param, typeof(Person).GetProperty("Name"));
            ConstantExpression Namevalue = Expression.Constant("k");
            MethodCallExpression e2= Expression.Call(Name, typeof(string).GetMethod("Contains"), Namevalue);
            Expression e3 = Expression.And(e1,e2);
            //var func = e3.Compile();
            //var result = func.Invoke(new Person
            //{
            //    id = 1,
            //    Name = "kill"
            //});
            Console.WriteLine(e3);
            Console.ReadKey();
        }

    }
    public partial class Person
    {
         public string Name { get; set; }
        public int  id { get; set; }
    } 
}
