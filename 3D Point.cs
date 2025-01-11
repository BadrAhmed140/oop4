using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp4
{
    public class _3D_Point :IComparable<_3D_Point>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public _3D_Point(int x, int y, int z) 
        {
            X = x;
            Y = y;
            Z = z;
        }
        public _3D_Point() : this(0,0,0) {}
        public _3D_Point(int x, int y) : this(x, y, 0) { }

        public override string ToString()
        {
            return $"Point Coordinates: ({X}, {Y}, {Z})";
        }


        public static bool operator ==(_3D_Point p1, _3D_Point p2)
        {

            return p1.X == p2.X && p1.Y == p2.Y && p1.Z == p2.Z;
        }

        public static bool operator !=(_3D_Point p1, _3D_Point p2)
        {

      return !(p1 == p2);
        }


        public int CompareTo(_3D_Point other)
        {
            if (X != other.X)
                return X.CompareTo(other.X);
            if (Y != other.Y)
                return Y.CompareTo(other.Y);
            return Z.CompareTo(other.Z);
        }



        public object Clone()
        {
            return new _3D_Point(X, Y, Z);
        }

    }
}
