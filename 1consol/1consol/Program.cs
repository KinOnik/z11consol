using System;
using System.Text;

namespace _1consol
{

    internal class Program
    {
        class myStr
        {
            //a	Поля
            private StringBuilder Line;
            private int n;

            //b	Конструктор, позволяющий создать строку из n символов.
            public myStr(string bufstr, int bufN)
            {
                Line = new StringBuilder(bufstr);
                if (Line.Length < bufN)
                {
                    n = Line.Length ;
                }
                else
                {
                    n = bufN;
                }
                Line.Remove(n, Line.Length - n);
            }
            public myStr(string bufstr)
            {
                Line = new StringBuilder(bufstr);
                n = Line.Length;

                Line.Remove(n, Line.Length - n);
            }

            //c Методы, позволяющие:
            //	1 подсчитать количество пробелов в строке;
            public int countSpace()
            {
                int buf = 0;
                for (int i = 0; i < n; i++)
                {
                    if (Line[i] == ' ')
                    {
                        buf++;
                    }
                }
                return buf;
            }


            //	2 заменить в строке все прописные символы на строчные;
            public void goToUpper()
            {
                Line.Replace(Line.ToString(), Line.ToString().ToUpper());
            }


            //	3 удалить из строки все знаки препинания.
            public void deleteSymbol()
            {
                char[] buf = { '.', ',', '!', '?', ':', ';', '\\', '\'', '\"', '(', ')', '&', '*', '`', '[', ']', '{', '}', '|', '`'};
                for(int i = 0; i < buf.Length; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if(Line[j] == buf[i])
                        {
                            Line.Remove(j, 1);
                            n--;
                        }    
                    }
                }
            }


            //d свойства
            public int N
            {
                get 
                { 
                    return Line.Length; 
                }
            }

            public string Lines
            {
                get 
                { 
                    return Line.ToString(); 
                }
                set 
                {
                    Line = new StringBuilder(value);
                    n = Line.Length; 
                }
            }

            //вывод, для проверки строки
            public void printMyStr()
            {
                Console.Write($"\n\t{Line.ToString()}\n");
            }
        }
        static void Main(string[] args)
        {
            myStr str = new myStr("Это игра, она старая. О ней не говорят уже очень долгое время! Да?", 20);

            Console.Write($"\n\tИзначальная строка:");
            str.printMyStr();
            int cSpace = str.countSpace();
            Console.Write($"\n\tКоличество пробелов в строке: {cSpace}\n");

            str.goToUpper();
            Console.Write($"\n\tИзмененная строка(все буквы строчные):");
            str.printMyStr();

            str.deleteSymbol();
            Console.Write($"\n\tИзмененная строка(удалить все знаки препинания):");
            str.printMyStr();

            Console.Write($"\n\t Количество элементов в строке: {str.N}\n\n");

            str.Lines="Та самая строка из свойств";

            Console.Write($"\n\tСтрока записанная через свойства: \n\t\t{str.Lines}\n\tКоличество элементов в новой строке: {str.N}\n\n");
        }
    }
}
