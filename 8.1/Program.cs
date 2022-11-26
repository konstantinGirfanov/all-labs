﻿using System;
using System.Text;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Hello
{
    public class TextInfo
    {
        public int TimeStart { get; set; }
        public int TimeEnd { get; set; }
        public string? Position { get; set; }
        public string? Color { get; set; }
        public string? Words { get; set; }
    }

    public class Program
    {
        static int tick = 0;

        static TextInfo[]? subtitles;

        public static string GetTextPosition(string line)
        {
            StringBuilder sb = new();

            if (line[14].ToString() == "[")
            {
                for (int i = 15; i < line.Length; i++)
                {
                    if (line[i] != ',')
                    {
                        sb.Append(line[i]);
                    }
                    else
                    {
                        break;
                    }
                }

                return sb.ToString();
            }
            else
            {
                return "Bottom";
            }
        }

        public static string GetTextColor(string line)
        {
            StringBuilder sb = new();

            if (line[14].ToString() == "[")
            {
                string[] words = line.Split(", ");

                for (int i = 0; i < words[1].ToString().Length; i++)
                {
                    if (words[1].ToString()[i] != ']')
                    {
                        sb.Append(words[1].ToString()[i]);
                    }
                    else
                    {
                        break;
                    }
                }

                return sb.ToString();
            }
            else
            {
                return "White";
            }
        }

        public static int GetTextTimeStart(string line)
        {
            return int.Parse(line[0].ToString()) * 600
                + int.Parse(line[1].ToString()) * 60
                + int.Parse(line[3].ToString()) * 10
                + int.Parse(line[4].ToString());
        }

        public static int GetTextTimeEnd(string line)
        {
            return int.Parse(line[8].ToString()) * 600
                + int.Parse(line[9].ToString()) * 60
                + int.Parse(line[11].ToString()) * 10
                + int.Parse(line[12].ToString());
        }

        public static string GetText(string line)
        {
            StringBuilder sb = new();

            int beginIndex = 14;

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i].ToString() == "]")
                {
                    beginIndex = i + 2;
                    break;
                }
            }

            for (int i = beginIndex; i < line.Length; i++)
            {
                sb.Append(line[i]);
            }

            return sb.ToString();
        }

        public static void SetTextColorInConsole(TextInfo text)
        {
            switch (text.Color)
            {
                case "Red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "Green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "Blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "Yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "White":
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "Gray":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
        }

        // Установка позиции и действие на ней (вывод текста
        // определённого цвета или очистка позиции).
        public static void TextOutput(TextInfo text, string action)
        {
            int height = 20;
            int width = 90;

            if (text.Position == "Bottom")
            {
                ScreenWindowDraw();
                SetTextColorInConsole(text);
                Console.SetCursorPosition(width / 2 - text.Words.Length / 2, height);
                ExecuteAction(text, action);
            }
            else if (text.Position == "Top")
            {
                ScreenWindowDraw();
                SetTextColorInConsole(text);
                Console.SetCursorPosition(width / 2 - text.Words.Length / 2, 0 + 1);
                ExecuteAction(text, action);
            }
            else if (text.Position == "Left")
            {
                ScreenWindowDraw();
                SetTextColorInConsole(text);
                Console.SetCursorPosition(0 + 1, height / 2);
                ExecuteAction(text, action);
            }
            else if (text.Position == "Right")
            {
                ScreenWindowDraw();
                SetTextColorInConsole(text);
                Console.SetCursorPosition(width, height / 2);
                ExecuteAction(text, action);
            }
        }

        public static void ExecuteAction(TextInfo text, string action)
        {
            if (action == "Write")
            {
                Console.Write(text.Words);
            }
            else if (action == "Clear")
            {
                Console.Write(new String(' ', 60));
            }
        }

        public static void ScreenWindowDraw()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
            Console.Write("+");
            Console.SetCursorPosition(1, 0);
            for (int i = 0; i < 93; i++)
            {
                Console.Write("-");
            }
            Console.SetCursorPosition(93, 0);
            Console.Write("+");

            Console.SetCursorPosition(0, 1);
            for (int i = 1; i < 21; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("|");
                Console.SetCursorPosition(93, i);
                Console.Write("|");
            }
            Console.SetCursorPosition(0, 21);
            Console.Write("+");
            for (int i = 0; i < 93; i++)
            {
                Console.Write("-");
            }
            Console.SetCursorPosition(93, 21);
            Console.Write("+");
        }

        public static void SetTimer()
        {
            Timer timer1 = new Timer(1000);
            timer1.Elapsed += EveryTickDo;
            timer1.AutoReset = true;
            timer1.Enabled = true;
        }

        private static void EveryTickDo(Object source, ElapsedEventArgs e)
        {
            tick++;

            // Проход по всему массиву субтитров, вывод строк в нужный момент времени, 
            // или очистка позиций, где текст не нужен.
            for (int i = 0; i < subtitles.Length; i++)
            {
                if (tick >= subtitles[i].TimeStart && tick <= subtitles[i].TimeEnd)
                {
                    TextOutput(subtitles[i], "Write");
                }
                else if (tick > subtitles[i].TimeEnd)
                {
                    TextOutput(subtitles[i], "Clear");
                }
            }
        }

        public static void Main()
        {
            var file = File.ReadAllText("text.txt").Split("\r\n");

            // Создание массива субтитров и определение свойств каждого его элемента.
            subtitles = new TextInfo[file.Length];
            for (int i = 0; i < subtitles.Length; i++)
            {
                subtitles[i] = new TextInfo();
                subtitles[i].TimeStart = GetTextTimeStart(file[i]);
                subtitles[i].TimeEnd = GetTextTimeEnd(file[i]);
                subtitles[i].Position = GetTextPosition(file[i]);
                subtitles[i].Color = GetTextColor(file[i]);
                subtitles[i].Words = GetText(file[i]);
            }

            SetTimer();
            Console.ReadKey();
        }
    }
}