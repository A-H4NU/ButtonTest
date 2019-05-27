using System;

using OpenTK.Graphics.OpenGL4;

namespace ButtonTest.Src.Main
{
    internal static class Logger
    {
        public static void Info(string text)
        {
            string[] lines = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string date = DateTime.Now.ToString("MM/dd-hh:mm:ss");

            foreach (string line in lines)
            {
                Console.WriteLine($"[{date}][INF] {line}");
            }
        }

        public static void Warn(string text)
        {
            string[] lines = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string date = DateTime.Now.ToString("MM/dd-hh:mm:ss");
            foreach (string line in lines)
            {
                Console.WriteLine($"[{date}][WRN] {line}");
            }
        }

        public static void Error(string text)
        {
            string[] lines = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string date = DateTime.Now.ToString("MM/dd-hh:mm:ss");
            foreach (string line in lines)
            {
                Console.WriteLine($"[{date}][ERR] {line}");
            }
        }

        public static void CheckError(string process)
        {
            ErrorCode error = GL.GetError();
            if (error != ErrorCode.NoError)
            {
                Error($"Error occured while {process}: {error}");
            }
        }
    }
}
