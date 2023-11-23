using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Igrok_final_2
{
    internal class Igra
    {
        private string name;
        private int x;
        private int y;
        private bool l;
        private int kol;
        private int koll;
        private int dr;
        private int lech;
        private int i = 0;
        private int ur;
        private int help;
        private int help_2;

        public void Plays(List<Igra> igroki, List<Igra> dead_igrok, Igra plays)
        {
            Console.WriteLine("Перед началом игры создайте 2 персонажей!");
            Console.WriteLine("Нажмите Enter");
            while (igroki.Count < 2)
            {
                Console.ReadKey();
                Console.Clear();
                New_play(igroki);
            }
            Console.ReadKey();
            Console.Clear();
            Vibor_igroka(igroki, dead_igrok, plays);
        }
        private void New_play(List<Igra> igroki)
        {
            igroki.Add(new Igra());
            Igra plays = igroki.Last();
            plays.Info();
        }
        private void Vibor_igroka(List<Igra> igroki, List<Igra> dead_igrok, Igra plays)
        {
            Console.WriteLine("Кем хотите управлять? Укажите название персонажа: ");
            foreach (Igra perexod in igroki)
            {
                perexod.Print();
                Console.WriteLine();
            }
            string name_vib = Console.ReadLine();
            foreach (Igra perexod in igroki)
            {
                if (name_vib == perexod.name)
                {
                    perexod.Vibor(igroki, dead_igrok, plays);
                    break;
                }
            }
        }
        private void Vibor(List<Igra> igroki, List<Igra> dead_igrok, Igra plays)
        {
            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("\nВыберите действие:\n1 - Информация о персонаже\n2 - Переместиться по горизонтали\n3 - Переместиться по вертикали\n4 - Лечение\n5 - Сменить лагерь\n6 - Сменить персонажа\n7 - Полное восстановление\n8 - Создать нового персонажа");
            int v = Convert.ToInt32(Console.ReadLine());
            switch (v)
            {
                case 1:
                    {
                        Print();
                        Console.ReadKey();
                        Console.Clear();
                        Vibor(igroki, dead_igrok, plays);
                        break;
                    }
                case 2:
                    {
                        Perem_gor(igroki, dead_igrok, plays);
                        Console.ReadKey();
                        Console.Clear();
                        Vibor(igroki, dead_igrok, plays);
                        break;
                    }
                case 3:
                    {
                        Perem_vert(igroki, dead_igrok, plays);
                        Console.ReadKey();
                        Console.Clear();
                        Vibor(igroki, dead_igrok, plays);
                        break;
                    }
                case 4:
                    {
                        doc();
                        Console.ReadKey();
                        Console.Clear();
                        Vibor(igroki, dead_igrok, plays);
                        break;
                    }
                case 5:
                    {
                        lager();
                        Console.ReadKey();
                        Console.Clear();
                        Vibor(igroki, dead_igrok, plays);
                        break;
                    }
                case 6:
                    {
                        Vibor_igroka(igroki, dead_igrok, plays);
                        break;
                    }
                case 7:
                    {
                        if (this.i == 0 && kol == koll)
                        {
                            Console.WriteLine("Вы не можете восстановить здоровье, если оно заполнено");
                            Console.ReadKey();
                            Console.Clear();
                            Vibor(igroki, dead_igrok, plays);
                        }
                        if (this.i == 0 && kol < koll)
                        {
                            Vost(igroki, dead_igrok, plays);
                            i++;
                        }
                        if (this.i > 0)
                        {
                            Console.WriteLine("Вы больше не можете полностью восстановить здоровье");
                            Console.ReadKey();
                            Console.Clear();
                            Vibor(igroki, dead_igrok, plays);
                        }
                        break;
                    }
                case 8:
                    {
                        New_play(igroki);
                        Console.ReadKey();
                        Console.Clear();
                        Vibor(igroki, dead_igrok, plays);
                        break;
                    }
            }
        }
        private void Fight(List<Igra> igroki, List<Igra> dead_igrok, Igra plays)
        {
            foreach (Igra ydar in igroki)
            {
                if (name != ydar.name && x == ydar.x && y == ydar.y && dr != ydar.dr)
                {
                    Console.WriteLine("Бой начинается!");
                    while (kol > 0 && ydar.kol > 0)
                    {
                        Vibor_2(igroki, dead_igrok, plays);
                    }
                }
            }
        }
        private void Uron(List<Igra> igroki, List<Igra> dead_igrok, Igra plays)
        {
            Random rd = new Random();
            ur = rd.Next(1, 4);
            foreach (Igra ydar in igroki)
            {
                if (name != ydar.name && x == ydar.x && y == ydar.y && dr != ydar.dr)
                {
                    if (kol > 0)
                    {
                        Console.WriteLine($"Вы нанесли: {ur} урона вашему врагу");
                        ydar.kol = ydar.kol - ur;
                        Console.WriteLine($"У него осталось: {ydar.kol} здоровья");
                        help++;
                    }
                    if (ydar.kol > 0)
                    {
                        ur = rd.Next(1, 4);
                        Console.WriteLine($"Вам нанесли: {ur} урона");
                        kol = kol - ur;
                        Console.WriteLine($"У вас осталось: {kol} здоровья");
                        help_2++;
                    }
                    if (kol <= 0 || ydar.kol <= 0)
                    {
                        Console.WriteLine("Бой окончен!");
                        if (help > help_2)
                        {
                            dead_igrok.Add(igroki.Find(a => a.kol < this.kol));
                            igroki.Remove(dead_igrok.Find(a => a.kol < this.kol));
                            Console.WriteLine("Вы победили!");
                            Console.ReadKey();
                            Console.Clear();
                            Vibor_igroka(igroki, dead_igrok, plays);
                        }
                        else
                        {
                            dead_igrok.Add(igroki.Find(a => a.name == this.name));
                            igroki.Remove(dead_igrok.Find(a => a.name == this.name));
                            Console.WriteLine("Враг победил!");
                            Console.ReadKey();
                            Console.Clear();
                            Vibor_igroka(igroki, dead_igrok, plays);
                        }
                    }
                }
            }
        }
        private void Vibor_2(List<Igra> igroki, List<Igra> dead_igrok, Igra plays)
        {
            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("1. Нанести урон; 2. Лечение; ");
            int v = Convert.ToInt32(Console.ReadLine());
            if (v == 1)
            {
                Uron(igroki, dead_igrok, plays);
            }
            if (v == 2)
            {
                doc();
            }
        }
        private void Vost(List<Igra> igroki, List<Igra> dead_igrok, Igra plays)
        {
            int vosst = koll - kol;
            kol = kol + vosst;
            Console.WriteLine("Вы полностью восстановили свое здоровье");
            this.i++;
            Vibor(igroki, dead_igrok, plays);
        }
        private void Perem_gor(List<Igra> igroki, List<Igra> dead_igrok, Igra plays)
        {
            Console.Write("Переместиться на: ");
            int x_2 = Convert.ToInt32(Console.ReadLine());
            this.x = this.x + x_2;
            Console.WriteLine($"Новое расположение: {x}; {y}");
            Fight(igroki, dead_igrok, plays);
        }
        private void Perem_vert(List<Igra> igroki, List<Igra> dead_igrok, Igra plays)
        {
            Console.Write("Переместиться на: ");
            int y_2 = Convert.ToInt32(Console.ReadLine());
            this.y = this.y + y_2;
            Console.WriteLine($"Новое расположение: {x}; {y}");
            Fight(igroki, dead_igrok, plays);
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
        }
        private bool lager()
        {
            if (l == true)
            {
                l = false;
                dr = 2;
                Console.WriteLine("Теперь ваш лагерь - 2");
            }
            else if (l == false)
            {
                l = true;
                dr = 1;
                Console.WriteLine("Теперь ваш лагерь - 1");
            }
            return l;
        }
        private void Info()
        {
            Console.Write("Укажите название персонажа: ");
            name = Console.ReadLine();
            Console.Write("Укажите координаты расположения вашего персонажа: x = ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("y = ");
            y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Укажите к какому лагерю хотите принадлежать: (1 или 2) ");
            dr = Convert.ToInt32(Console.ReadLine());
            if (dr == 1)
            {
                l = true;
            }
            else if (dr == 2)
            {
                l = false;
            }
            Console.WriteLine("Укажите количество ваших жизней: ");
            kol = Convert.ToInt32(Console.ReadLine());
            koll = kol;
        }
        private void Print()
        {
            Console.WriteLine($"Название персонажа: {name}");
            Console.WriteLine($"x = {x}");
            Console.WriteLine($"y = {y}");
            Console.WriteLine($"Ваш лагерь: {dr}");
            Console.WriteLine($"Количество жизней: {kol}");
        }
    }
}