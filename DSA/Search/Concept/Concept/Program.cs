using System;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;

class Program {
    static void Main(string[] args) {;
        Thread thread1 = new Thread(_ => {
            using (var p = new Process()) {
                p.StartInfo.FileName = @"C:\Users\Xavier\Desktop\MSSA NOTES\Victor\MergeC\DSA\Search\Concept\BFS\bin\Debug\net7.0\BFS.exe";
                p.StartInfo.UseShellExecute = true;
                p.Start();
            }
        });

        Thread thread2 = new Thread(_ => {
            using (var p = new Process()) {
                p.StartInfo.FileName = @"C:\Users\Xavier\Desktop\MSSA NOTES\Victor\MergeC\DSA\Search\Concept\DFS\bin\Debug\net7.0\DFS.exe";
                p.StartInfo.UseShellExecute = true;
                p.Start();
                
            }
        });

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();


        // using (var p = new Process()) {
        //p.StartInfo.FileName = $"DFS.exe";
        // p.StartInfo.UseShellExecute = true;
        //   p.Start();
        // }
    }
}