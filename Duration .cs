using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp4
{
    internal class Duration
    {
        public int Hours { get; private set; }
        public int Minutes { get; private set; }
        public int Seconds { get; private set; }



        public Duration(int totalSeconds)
        {
            Hours = totalSeconds / 3600;
            Minutes = (totalSeconds % 3600) / 60;
            Seconds = totalSeconds % 60;
        }
        public Duration (int hours, int minutes, int seconds)
        {


            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
            NormalizeTime();
        }


        public int ToTotalSeconds()
        {
            return Hours * 3600 + Minutes * 60 + Seconds;
        }
        private void NormalizeTime()
        {
            Minutes += Seconds / 60;
            Seconds %= 60;
            Hours += Minutes / 60;
            Minutes %= 60;
        }
        public override string ToString()
        {
            string result =null;
            if (Hours > 0) result += $"Hours: {Hours}, ";
            if (Minutes > 0 || Hours > 0) result += $"Minutes: {Minutes}, ";
            result += $"Seconds: {Seconds}";
            return result;
        }


        public override bool Equals(object? obj)
        {
            if (obj is Duration other)
            {

                return Hours == other.Hours && Minutes == other.Minutes && Seconds == other.Seconds; ;
            }
            return false;
        }


        public override int GetHashCode()
        {
            return HashCode.Combine(Hours, Minutes, Seconds);
        }

        public static Duration operator +(Duration d1, Duration d2)
        {
            return new Duration(d1.Hours + d2.Hours, d1.Minutes + d2.Minutes, d1.Seconds + d2.Seconds);
        }


        public static Duration operator +(Duration d1, int seconds)
        {
            return seconds+d1;
        }

        public static Duration operator +(int seconds, Duration d1)
        {
            return d1 + seconds;
        }


        public static Duration operator ++(Duration d)
        {
            return new Duration(d.ToTotalSeconds() + 60);
        }

        public static Duration operator --(Duration d)
        {
            return new Duration(d.ToTotalSeconds() - 60);
        }


        public static Duration operator -(Duration d1, Duration d2)
        {
            return new Duration(d1.ToTotalSeconds() - d2.ToTotalSeconds());
        }



        public static bool operator >(Duration d1, Duration d2)
        {
            return d1.ToTotalSeconds() > d2.ToTotalSeconds();
        }

        public static bool operator <(Duration d1, Duration d2)
        {
            return d1.ToTotalSeconds() > d2.ToTotalSeconds();
        }
        public static bool operator <=(Duration d1, Duration d2)
        {
            return d1.ToTotalSeconds() <= d2.ToTotalSeconds();
        }

        public static bool operator >=(Duration d1, Duration d2)
        {
            return d1.ToTotalSeconds() <= d2.ToTotalSeconds();
        }

        public static implicit operator bool(Duration d)
        {
            return d.ToTotalSeconds() > 0;
        }

        
        public static explicit operator DateTime(Duration d)
        {
            return new DateTime(1, 1, 1, d.Hours, d.Minutes, d.Seconds);
        }


    }
}
