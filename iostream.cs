namespace IOStream{
    using System;
    using System.Threading;
    public class OutStream{
        public string outBuffer;

        public static OutStream operator -(OutStream o, string s){ Console.Write(s); return o; }
        public static OutStream operator -(OutStream o, int i){ Console.Write(i); return o; }
        // public static OutStream operator +(OutStream o, string s){ Console.WriteLine(s); return o; }
        // public static OutStream operator +(OutStream o, string[] s){ foreach(string i in s) Console.WriteLine(i); return o; }
        // public static OutStream operator +(OutStream o, int i){ Console.WriteLine(i); return o; }
        public static OutStream operator +(OutStream o, string s){ o.outBuffer += s + "\n"; return o; }
        public static OutStream operator +(OutStream o, string[] s){ foreach(string i in s) o.outBuffer += i; return o; }
        public static OutStream operator +(OutStream o, int i){ o.outBuffer += i; return o; }
        public static implicit operator OutStream(int i){ return new OutStream(); }

        public void WriteBuffer(){
            int i = 0;
            while(i < outBuffer.Length){
                if(outBuffer[i] == '\n')
                    Thread.Sleep(500);
                Console.Write(outBuffer[i]);
                Thread.Sleep(15);
                i++;
            }
            outBuffer = "";
        }
    }

    public class InStream{
        public static int operator -(InStream i){ return Console.Read(); }
        public static string operator +(InStream i){ return Console.ReadLine(); }
    }
}