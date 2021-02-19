namespace IOStream{
    using System;
    public class OutStream{
        public static OutStream operator -(OutStream o, string s){ Console.Write(s); return o; }
        public static OutStream operator -(OutStream o, int i){ Console.Write(i); return o; }
        public static OutStream operator +(OutStream o, string s){ Console.WriteLine(s); return o; }
        public static OutStream operator +(OutStream o, int i){ Console.WriteLine(i); return o; }
        public static implicit operator OutStream(int i){ return new OutStream(); }
    }

    public class InStream{
        public static int operator -(InStream i){ return Console.Read(); }
        public static string operator +(InStream i){ return Console.ReadLine(); }
    }
}