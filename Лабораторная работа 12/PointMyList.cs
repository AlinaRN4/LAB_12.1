using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_12
{
    public class Point<T> /*where T : IComparable<T>*/
    {
        public T Data { get; set; }
        public Point<T> Next { get; set; }
        public Point<T>? Pred { get; set; }

        public Point()
        {
            this.Data = Activator.CreateInstance<T>();
            this.Pred = null;
            this.Next = null;
        }

        public Point(T data)
        {
            this.Data = data;
            this.Pred = null;
            this.Next = null;
        }
        
        public override string ToString()
        {
            return Data == null ? "" : Data.ToString();
        }

        public override int GetHashCode()
        {
            return Data == null ? 0 : Data.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Point<T> p)
            {
                return this.Data.Equals(p.Data) && this.Next.Equals(p.Next) && this.Pred.Equals(p.Pred);

            }
            else { return false; }
        }
    }
}
