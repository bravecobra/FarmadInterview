using System;
using System.IO;
using System.Threading.Tasks;
// ReSharper disable All

namespace CodeReview
{
    class Program
    {
        public static int Main(string[] args)
        {
            var b = ReadFirstByte(args[0]).Result;
            return b;
        }

        /// <summary> Reads the first byte. </summary>
        static async Task<int> ReadFirstByte(string? fn)
        {
            var fileStream = File.Open(fn, FileMode.Open);

            try
            {
                var result = new byte[1];
                await fileStream.ReadAsync(result, offset: 0, count: 1);
                return result[0];
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                throw ex;
            }
        }
    }

    public static class Logger
    {
        public static void LogError(string errorMessage)
        {
            Console.WriteLine($"[ERR] {errorMessage}");
        }
    }
}
