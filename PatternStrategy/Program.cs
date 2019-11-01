using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternStrategy
{
    public interface IStrategy
    {
        bool Left { get; set; }
        string DrawEnd();
    }

    public class Romb : IStrategy
    {
        bool left = true;
        bool IStrategy.Left
        {
            get => left; set
            {
                left = value;
            }
        }


        string IStrategy.DrawEnd()
        {
            return "<>";
        }
    }

    public class Nothing : IStrategy
    {
        bool left = true;
        bool IStrategy.Left
        {
            get => left; set
            {
                left = value;
            }
        }


        string IStrategy.DrawEnd()
        {
            return "X";
        }
    }

    public class LinesEnd : IStrategy
    {
        bool left = true;
        bool IStrategy.Left
        {
            get => left; set
            {
                left = value;
            }
        }


        string IStrategy.DrawEnd()
        {
            if (left) return "<";
            return ">";
        }
    }
    public class Line
    {
        int x1, x2, y1, y2;
        string line;
        public Line(IStrategy a, IStrategy b, int x1, int y1, int x2, int y2)
        {
            a.Left = true;
            b.Left = false;
            this.x1 = x1; this.x2 = x2; this.y1 = y1; this.y2 = y2;
            this.line = a.DrawEnd() + "---" + b.DrawEnd();
        }
        public string DrawLine()
        {
            return String.Format("x1: {0}, y1: {1}. x2: {2}, y2: {3}. {4}", x1, y1, x2, y2, line);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Line> points = new List<Line>();
            Random rnd = new Random();
            while (true)
            {
                Console.WriteLine("1. add line");
                Console.WriteLine("2. print lines");
                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            Console.WriteLine("1. none, none");
                            Console.WriteLine("2. none, >");
                            Console.WriteLine("3. none, <>");
                            Console.WriteLine("4. <, none");
                            Console.WriteLine("5. <, >");
                            Console.WriteLine("6. <, <>");
                            Console.WriteLine("7. <>, none");
                            Console.WriteLine("8. <>, >");
                            Console.WriteLine("9. <>, <>");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    {
                                        points.Add(new Line(new Nothing(), new Nothing(), rnd.Next(-10, 11), rnd.Next(-10, 11), rnd.Next(-10, 11), rnd.Next(-10, 11)));
                                        break;
                                    }
                                case "2":
                                    {
                                        points.Add(new Line(new Nothing(), new LinesEnd(), rnd.Next(-10, 11), rnd.Next(-10, 11), rnd.Next(-10, 11), rnd.Next(-10, 11)));
                                        break;
                                    }
                                case "3":
                                    {
                                        points.Add(new Line(new Nothing(), new Romb(), rnd.Next(-10, 11), rnd.Next(-10, 11), rnd.Next(-10, 11), rnd.Next(-10, 11)));
                                        break;
                                    }
                                case "4":
                                    {
                                        points.Add(new Line(new LinesEnd(), new Nothing(), rnd.Next(-10, 11), rnd.Next(-10, 11), rnd.Next(-10, 11), rnd.Next(-10, 11)));
                                        break;
                                    }
                                case "5":
                                    {
                                        points.Add(new Line(new LinesEnd(), new LinesEnd(), rnd.Next(-10, 11), rnd.Next(-10, 11), rnd.Next(-10, 11), rnd.Next(-10, 11)));
                                        break;
                                    }
                                case "6":
                                    {
                                        points.Add(new Line(new LinesEnd(), new Romb(), rnd.Next(-10, 11), rnd.Next(-10, 11), rnd.Next(-10, 11), rnd.Next(-10, 11)));
                                        break;
                                    }
                                case "7":
                                    {
                                        points.Add(new Line(new Romb(), new Nothing(), rnd.Next(-10, 11), rnd.Next(-10, 11), rnd.Next(-10, 11), rnd.Next(-10, 11)));
                                        break;
                                    }
                                case "8":
                                    {
                                        points.Add(new Line(new Romb(), new LinesEnd(), rnd.Next(-10, 11), rnd.Next(-10, 11), rnd.Next(-10, 11), rnd.Next(-10, 11)));
                                        break;
                                    }
                                case "9":
                                    {
                                        points.Add(new Line(new Romb(), new Romb(), rnd.Next(-10, 11), rnd.Next(-10, 11), rnd.Next(-10, 11), rnd.Next(-10, 11)));
                                        break;
                                    }

                            }
                            break;
                        }
                    case "2":
                        {
                            foreach (Line i in points) Console.WriteLine(i.DrawLine());
                            break;
                        }
                }
            }
        }
    }
}
