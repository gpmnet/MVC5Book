using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CH07;


namespace Ch07
{
    //僅包含一條主執行緒被稱為安全執行緒(thread-safe)
    //單核處理器，作業系統廠會分配片段時間給執行緒執行(約20ms)
    //Task類別中Run method為執行Thread,傳回值為Task或Task<T>，其中<T>可透過Result屬性取得
    //，Wait為封鎖Thread往下執行，直到Task完成
    //ContinueWith及GetAwaiter()是可以實作Task完成時呼叫的Method(所謂接續工作，Continuation)
    class Program
    {
        static void Main(string[] args)
        {
            // 範例一
            //Console.WriteLine("********** 請輸入 PID **********");
            //Console.Write("PID：");
            //string PID = Console.ReadLine();
            //int procID = int.Parse(PID);
            //sample.EnumThreadsForPID(procID);
            //Console.ReadLine();

            // 範例二
            //sample.Write1To50();
            //sample.Write51To100();
            //Console.ReadLine();

            // 範例三
            //  // 建立新執行緒
            //  Thread t = new Thread(sample.Write1To50);
            //  // 啟動執行緒
            //  t.Start();
            //  // 同時主執行緒也會執行
            //  sample.Write51To100();
            //  Console.ReadLine();

            // 範例四
//            sample.new10Thread();

            // 範例五
//            for (int i = 0; i < 10; i++)
//            {
//                sample.new10Thread(i);
//            }
//            Console.ReadLine();

//             範例六
//              // 建立新執行緒
//              Thread t = new Thread(sample.Write1To50);
//              // 啟動執行緒
//              t.Start();
//              // 主執行緒暫停1秒
//              Thread.Sleep(1000);
//              sample.Write51To100();
//              Console.ReadLine();

            // 範例七
            // Task.Run(() => Console.WriteLine("From Task."));
            // Console.ReadLine();

            // 範例八
//            sample.TaskRun1();

            // 範例九
//            sample.TaskRun2();

            // 範例十
            //sample.TaskRun3();

            // 範例十一
//            sample.ContinueWith();

            // 範例十二
//             sample.Awaiter();

            // 範例十三
            //sample.TaskDelayContinueWith();

            // 範例十四
            //sample.TaskDelayAwaiter();

            // 範例十五
            //sample.ParallelFor();

            // 範例十六
            sample.ParallelForEach();

            // 範例十七
            //sample.ParallelInvoke();

            // 範例十八
            //Stopwatch main_timer = new Stopwatch();
            //main_timer.Start();
            //for (int i = 0; i < 10; i++)
            //{
            //    LongTimeWork1();
            //    LongTimeWork2();
            //}
            //main_timer.Stop();
            //Console.WriteLine("工作1費時: {0} ms", w1_timer.ElapsedMilliseconds);
            //Console.WriteLine("工作2費時: {0} ms", w2_timer.ElapsedMilliseconds);
            //Console.WriteLine("總共費時: {0} ms", main_timer.ElapsedMilliseconds);
            //
            //Console.ReadLine();

            // 範例十九
            //Stopwatch main_timer = new Stopwatch();
            //main_timer.Start();
            //DoWork().Wait();
            //main_timer.Stop();
            //Console.WriteLine("工作1費時: {0} ms", w3_timer.ElapsedMilliseconds);
            //Console.WriteLine("工作2費時: {0} ms", w4_timer.ElapsedMilliseconds);
            //Console.WriteLine("總共費時: {0} ms", main_timer.ElapsedMilliseconds);
            //
            //Console.ReadLine();

        }

        // 範例十八
        private static Stopwatch w1_timer = new Stopwatch();
        private static void LongTimeWork1()
        {
            w1_timer.Start();
            // Wait() 等待Task完成
            Task.Delay(300).Wait();
            w1_timer.Stop();
        }

        private static Stopwatch w2_timer = new Stopwatch();
        private static void LongTimeWork2()
        {
            w2_timer.Start();
            Task.Delay(400).Wait();
            w2_timer.Stop();
        }

        // 範例十九
        static Stopwatch w3_timer = new Stopwatch();
        static void LongTimeWork3()
        {
            w3_timer.Start();
            // Wait() 等待Task完成
            Task.Delay(300).Wait();
            w3_timer.Stop();
        }

        static Stopwatch w4_timer = new Stopwatch();
        static async Task LongTimeWork4()
        {
            w4_timer.Start();
            await Task.Delay(400);
            w4_timer.Stop();
        }

        static async Task DoWork()
        {
            Task result = null;
            for (int i = 0; i < 10; i++)
            {
                LongTimeWork3();
                if (result != null)
                {
                    await result;
                }
                result = LongTimeWork4();
            }
            await result;
        }

    }
}
