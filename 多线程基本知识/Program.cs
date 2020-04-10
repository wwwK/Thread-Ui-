using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 多线程基本知识
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("主线程开始"); //主线程完成输出。--这是主线程干的事
            Thread td = new Thread(
              (x) =>
              {
                  for (int i = 0; i < 100; i++)
                  {
                      Console.WriteLine(i);
                  }
                  Console.ReadKey();

              }
             );

            td.Start(23);

            Console.WriteLine("主线程开始2"); //主线程完成输出  --这是主线程干的事

            for (int i = 101; i < 200; i++)
            {
                Console.WriteLine(i);  //主线程完成输出  --这是主线程干的事
            }

            //在.net下是不允许跨线程访问的。解决跨线程访问的方法是：Control.CheckForIllegalCrossThreadCalls = false;
            Thread.Sleep(3000);//让当前线程停止3秒后再运行。
            Console.WriteLine("Hellow world");



        }
    }
}
