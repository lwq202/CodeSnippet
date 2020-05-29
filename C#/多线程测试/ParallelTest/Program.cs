using System.Collections.Generic;
using System.Threading;
using System.Runtime.InteropServices;
using System;
using System.Threading.Tasks;

namespace ParallelTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // await WaitAll();
            // System.Console.WriteLine($"Parallel开始");
            // Parallel.For(1, 100, async i =>
            // {
            //     Thread.Sleep(1000);
            //     Console.WriteLine($"第{i}");
            // });
            // System.Console.WriteLine($"Parallel结束");
            await TaskTest();
        }
        static List<Task> tasks = new List<Task>();
        static TaskFactory factory = new TaskFactory();
        static async Task TaskTest()
        {
            int num = 0;
            while (true)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"主线程再运行,当前线程数为{tasks.Count}");
                if (tasks.Count < 20)
                {
                    var newNum = 10;
                    for (int i = 0; i < newNum; i++)
                    {
                        var task = factory.StartNew(() =>
                        {
                            Console.WriteLine($"正在执行第{++num}");
                            Thread.Sleep(2000);
                        });
                        task.ContinueWith((t, obj) =>
                        {
                            tasks.Remove(t);
                        }, num);
                        tasks.Add(task);
                    }

                }

            }

        }
        /// <summary>
        /// 测试三个并行任务开始 结束
        /// </summary>
        /// <returns></returns>
        static async Task WaitAll()
        {
            TaskFactory factory = new TaskFactory();
            Console.WriteLine("开始");
            Task[] tasks = new Task[]{
                factory.StartNew(()=>{
                    Console.WriteLine("第一次请求开始");
                    Thread.Sleep(1000);
                    Console.WriteLine("第一次请求结束");
                }),
                factory.StartNew(()=>{
                    Console.WriteLine("第二次请求开始");
                    Thread.Sleep(3000);
                    Console.WriteLine("第二次请求结束");
                }),
                factory.StartNew(()=>{
                    Console.WriteLine("第三次请求开始");
                    Thread.Sleep(2000);
                    Console.WriteLine("第三次请求结束");
                })
            };
            await Task.WhenAll(tasks);

            Console.WriteLine("结束");
        }
    }

}