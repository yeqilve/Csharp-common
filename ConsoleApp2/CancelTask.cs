using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    public class CancelTask
    {
        public static void CancelParallelFor()
        {
            var cts = new CancellationTokenSource();

            cts.Token.Register(() => Console.WriteLine("***Token calceled**"));
            cts.CancelAfter(500);
            try
            {
                var result = Parallel.For(0, 100, new ParallelOptions
                {
                    CancellationToken = cts.Token,
                },
                x =>
                {
                    Console.WriteLine($"loop {x} times");
                    int sum = 0;
                    for (int i = 0; i < 100; i++)
                    {
                        Task.Delay(2).Wait();
                        sum += i;
                    }
                    Console.WriteLine($"loop finished {sum}");
                }
                );

            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine($"errorMessage: {ex.Message}");

            }

        }
    }
}
