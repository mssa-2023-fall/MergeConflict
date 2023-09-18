using System.Collections.Generic;

public class Program {
    public static void Main(string[] args) {
        int[] ary = new int[] { 2, 4, 6, 3, 7, 8 };

        DropWhile(ref ary, (int x) => x % 2 == 0);

        Console.WriteLine(string.Join("", ary));
    }

    public static void DropWhile<T>(ref T[] ary, Func<T, bool> predicate) {

        int stoppingPoint = 0;

        for (int i = 0; i < ary.Count(); i++) {
            if (predicate(ary[i])) { stoppingPoint++; }
            else { break; }
        }

        ary = ary[stoppingPoint..];

    }
}