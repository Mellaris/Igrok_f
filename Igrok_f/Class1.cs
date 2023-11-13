using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igrok_f
{
    internal class Class1
    {
        private string name;
        private int x;
        private int y;
        private bool l;
        private int kol;
        private string dr;
        private int a;
        private int b;
        private string name_2;
        private string dr_2;
        private int kol_2;
        private bool l_2;
        private string vi;
        private int ur;
        private int koll;
        private int i;
        private int lech;
        public void Info()
        {
            Console.Write("Укажите название персонажа: ");
            name = Console.ReadLine();
            Console.Write("Укажите координаты расположения вашего персонажа: x = ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("y = ");
            y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Укажите к какому лагерю хотите принадлежать: (Друг или Враг) ");
            dr = Console.ReadLine();
            if (dr == "Друг")
            {
                l = true;
            }
            else if (dr == "Враг")
            {
                l = false;
            }
            Console.WriteLine("Укажите количество ваших жизней: ");
            kol = Convert.ToInt32(Console.ReadLine());
            koll = kol;
            Perem();
        }
        public void Info_2()
        {
            name_2 = "Саша";
            Random rdn = new Random();
            a = 5/*rdn.Next(1, 25)*/;
            b = 5/*rdn.Next(1, 25)*/;
            dr_2 = "Враг";
            if (dr_2 == "Друг")
            {
                l_2 = true;
            }
            else if (dr_2 == "Враг")
            {
                l_2 = false;
            }
            kol_2 = 10;
        }
        public void Print()
        {
            Console.WriteLine($"Название персонажа: {name}");
            Console.WriteLine($"x = {x}");
            Console.WriteLine($"y = {y}");
            Console.WriteLine($"Ваш лагерь: {dr}");
            Console.WriteLine($"Количество жизней: {kol}");
        }
        private void Perem()
        {
            Info_2();
            ConsoleKeyInfo k;
            do
            {
                k = Console.ReadKey(true);
                if (x == a && y == b)
                {
                    if (l == l_2)
                    {
                        do
                        {
                            Console.WriteLine("Бой невозможен, смените лагерь");
                            Console.WriteLine("Вы хотите сменить лагерь? Напишите да или нет");
                            vi = Console.ReadLine();
                            if (vi == "да")
                            {
                                lager();
                                vibor();
                            }
                            else
                            {
                                Console.WriteLine("Бой невозможен");
                            }
                        } while (vi == "нет");
                    }
                    else
                    {
                        vibor();
                    }
                }
                Console.Write("Укажите координаты расположения вашего персонажа: x = ");
                x = Convert.ToInt32(Console.ReadLine());
                Console.Write("y = ");
                y = Convert.ToInt32(Console.ReadLine());
            } while (k.Key != ConsoleKey.Escape);
        }
        private bool lager()
        {
            if (l == true)
            {
                l = false;
                Console.WriteLine("Теперь ваш персонаж - Враг");
            }
            if (l == false)
            {
                l = true;
                Console.WriteLine("Теперь ваш персонаж - Друг");
            }
            return l;
        }
        private void vibor()
        {
            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("1. Нанести урон; 2. Лечение; 3. Полное восстановление; 4. Просмотреть информацию до игры ");
            int v = Convert.ToInt32(Console.ReadLine());
            if (v == 1)
            {
                uron();
            }
            if (v == 2)
            {
                doc();
            }
            if (v == 3)
            {
                if (i == 0)
                {
                    vost();
                    i++;
                }
                if (i > 0)
                {
                    Console.WriteLine("Вы больше не можете полностью восстановить здоровье");
                    vibor();
                }
            }
            if (v == 4)
            {
                Print();
            }
        }
        private void uron()
        {
            Random rd = new Random();
            ur = rd.Next(1, 4);
            Console.WriteLine($"Вы нанесли: {ur} урона вашему врагу");
            kol_2 = kol_2 - ur;
            Console.WriteLine($"У него осталось: {kol_2} здоровья");
            Console.ReadKey();
            if (kol_2 <= 0)
            {
                del();
            }
            if (kol_2 > 0)
            {
                ur = rd.Next(1, 4);
                Console.WriteLine($"Вам нанесли: {ur} урона");
                kol = kol - ur;
                Console.WriteLine($"У вас осталось: {kol} здоровья");
            } 
            if (kol > 0 && kol_2 > 0)
            {
                vibor();
            }
            else del();
        }
        private void del()
        {
            if (kol_2 <= 0)
            {
                Console.WriteLine("Вы убили врага!");
            }

            else if (kol <= 0 && kol_2 > 0)
            {
                Console.WriteLine("Вас убили!");
            }
        }
        private void doc()
        {
            Random rd = new Random();
            lech = rd.Next(1, 3);
            kol = kol + lech;
            if (kol > 10)
            {
                kol = 10;
            }
            else { Console.WriteLine($"Вы получили лечение: {lech}"); }
            Console.WriteLine($"У вас осталось: {kol} здоровья");
            Console.ReadKey();
            vibor();
        }
        private void vost()
        {
            int vosst = koll - kol;
            kol = kol + vosst;
            Console.WriteLine("Вы полностью восстановили свое здоровье");
            i++;
            vibor();
        }
    }
}