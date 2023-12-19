using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
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
        private float kol;
        private float koll;
        private int dr;
        private int lech;
        private int i = 0;
        private float ur = 0;
        private float ur_2;
        private int help_3;
        private int help_4;
        private int help_5;
        private int help_6;
        public void Plays(List<Igra> igroki, List<Igra> dead_igrok, Igra plays, List<Igra> Vragi, List<Igra> Friend)
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
            Vibor_igroka(igroki, dead_igrok, plays, Friend, Vragi);
        }
        private void New_play(List<Igra> igroki)
        {
            igroki.Add(new Igra());
            Igra plays = igroki.Last();
            plays.Info();
        }
        private void Vibor_igroka(List<Igra> igroki, List<Igra> dead_igrok, Igra plays, List<Igra> Vragi, List<Igra> Friend)
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
                    perexod.Vibor(igroki, dead_igrok, plays, Friend, Vragi);
                    break;
                }
            }
        }
        private void Vibor(List<Igra> igroki, List<Igra> dead_igrok, Igra plays, List<Igra> Vragi, List<Igra> Friend)
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
                        Vibor(igroki, dead_igrok, plays, Friend, Vragi);
                        break;
                    }
                case 2:
                    {
                        Perem_gor(igroki, dead_igrok, plays, Friend, Vragi);
                        Console.ReadKey();
                        Console.Clear();
                        Vibor(igroki, dead_igrok, plays, Friend, Vragi);
                        break;
                    }
                case 3:
                    {
                        Perem_vert(igroki, dead_igrok, plays, Friend, Vragi);
                        Console.ReadKey();
                        Console.Clear();
                        Vibor(igroki, dead_igrok, plays, Friend, Vragi);
                        break;
                    }
                case 4:
                    {
                        doc();
                        Console.ReadKey();
                        Console.Clear();
                        Vibor(igroki, dead_igrok, plays, Friend, Vragi);
                        break;
                    }
                case 5:
                    {
                        lager();
                        Console.ReadKey();
                        Console.Clear();
                        Vibor(igroki, dead_igrok, plays, Friend, Vragi);
                        break;
                    }
                case 6:
                    {
                        Vibor_igroka(igroki, dead_igrok, plays, Friend, Vragi);
                        break;
                    }
                case 7:
                    {
                        if (this.i == 0 && kol == koll)
                        {
                            Console.WriteLine("Вы не можете восстановить здоровье, если оно заполнено");
                            Console.ReadKey();
                            Console.Clear();
                            Vibor(igroki, dead_igrok, plays, Friend, Vragi);
                        }
                        if (this.i == 0 && kol < koll)
                        {
                            Vost(igroki, dead_igrok, plays, Friend, Vragi);
                            i++;
                        }
                        if (this.i > 0)
                        {
                            Console.WriteLine("Вы больше не можете полностью восстановить здоровье");
                            Console.ReadKey();
                            Console.Clear();
                            Vibor(igroki, dead_igrok, plays, Friend, Vragi);
                        }
                        break;
                    }
                case 8:
                    {
                        New_play(igroki);
                        Console.ReadKey();
                        Console.Clear();
                        Vibor(igroki, dead_igrok, plays, Friend, Vragi);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Попробуйте еще раз");
                        Console.ReadKey();
                        Vibor(igroki, dead_igrok, plays, Friend, Vragi);
                        break;
                    }
            }
        }
        private void Raspred(List<Igra> igroki, List<Igra> Vragi, List<Igra> Friend)
        {
            foreach (Igra proverka in igroki)
            {
                if (x == proverka.x && y == proverka.y)
                {
                    if (dr != proverka.dr)
                    {
                        Vragi.Add(proverka);
                    }
                    if (dr == proverka.dr)
                    {
                        Friend.Add(proverka);
                    }
                }
            }
        }
        private void Fight(List<Igra> igroki, List<Igra> dead_igrok, Igra plays, List<Igra> Vragi, List<Igra> Friend)
        {
            foreach (Igra ydar in igroki)
            {
                if (name != ydar.name && x == ydar.x && y == ydar.y && dr != ydar.dr)
                {
                    Console.WriteLine("Бой начинается!");
                    while (kol > 0 && ydar.kol > 0)
                    {
                        Vibor_2(igroki, dead_igrok, plays, Friend, Vragi);
                    }
                }
            }
        }
        private void Uron(List<Igra> igroki, List<Igra> dead_igrok, Igra plays, List<Igra> Vragi, List<Igra> Friend)
        {
            Raspred(igroki, Vragi, Friend);
            int count = Vragi.Count;
            Console.WriteLine(count);
            int count_2 = Friend.Count;
            Console.WriteLine(count_2);
            while (help_3 == 0)
            {
                foreach (Igra ydar in Friend)
                {
                    Random rd = new Random();
                    ydar.ur = rd.Next(1, 4);
                    ur = ydar.ur;
                }
                ur = ur * count_2;
                if (count > 1)
                {
                    ur = ur / count;
                }
                Console.WriteLine($"Ваш урон: {ur}");
                foreach (Igra ydar in Vragi)
                {
                    Random rd = new Random();
                    ydar.ur_2 = rd.Next(1, 4);
                    ur_2 = ydar.ur_2;
                }
                ur_2 = ur_2 * count;
                if (count_2 > 1)
                {
                    ur_2 = ur_2 / count_2;
                }
                Console.WriteLine($"Урон врагов: {ur_2}");
                help_3++;
            }
            foreach (Igra ydar in igroki)
            {
                if (name != ydar.name && x == ydar.x && y == ydar.y && dr != ydar.dr)
                {
                    foreach (Igra xdar in Vragi)
                    {
                        if (kol > 0)
                        {
                            while (Vragi.Count != help_5)
                            {
                                Console.WriteLine($"Вы нанесли: {ur} урона вашему врагу");
                                xdar.kol = xdar.kol - ur;
                                Console.WriteLine($"У него осталось: {xdar.kol} здоровья");
                                help_5++;
                                break;
                            }
                        }
                    }
                    foreach (Igra igra in Friend)
                    {
                        if (ydar.kol > 0)
                        {
                            while (Friend.Count != help_6)
                            {
                                Console.WriteLine($"Вам нанесли: {ur_2} урона");
                                igra.kol = igra.kol - ur_2;
                                Console.WriteLine($"У вас осталось: {kol} здоровья");
                                help_6++;
                                break;
                            }
                        }
                    }
                    if (kol <= 0 || ydar.kol <= 0)
                    {
                        Console.WriteLine("Бой окончен!");
                        foreach (Igra igra in Friend)
                        {
                            foreach (Igra xdar in Vragi)
                            {
                                if (igra.kol > xdar.kol)
                                {
                                    while (igroki.Count > help_4)
                                    {
                                        dead_igrok.Add(igroki.Find(a => a.kol == 0 || a.kol < 0));
                                        igroki.Remove(igroki.Find(a => a.kol == 0 || a.kol < 0));
                                        Friend.Clear();
                                        help_4++;
                                    }
                                    help_3 = 0;
                                    help_5 = 0;
                                    help_6 = 0;
                                    help_4 = 0;
                                    Vragi.Clear();
                                    Console.WriteLine("Вы победили!");
                                    Console.ReadKey();
                                    Console.Clear();
                                    Vibor_igroka(igroki, dead_igrok, plays, Friend, Vragi);
                                }
                                else
                                {
                                    while (igroki.Count > help_4)
                                    {
                                        dead_igrok.Add(igroki.Find(a => a.kol == 0 || a.kol < 0));
                                        igroki.Remove(igroki.Find(a => a.kol == 0 || a.kol < 0));
                                        Vragi.Clear();
                                        help_4++;
                                    }
                                    help_3 = 0;
                                    help_5 = 0;
                                    help_6 = 0;
                                    help_4 = 0;
                                    Friend.Clear();
                                    Console.WriteLine("Враг победил!");
                                    Console.ReadKey();
                                    Console.Clear();
                                    Vibor_igroka(igroki, dead_igrok, plays, Friend, Vragi);
                                }
                            }
                        }
                    }
                }
            }
        }
        private void Vibor_2(List<Igra> igroki, List<Igra> dead_igrok, Igra plays, List<Igra> Vragi, List<Igra> Friend)
        {
            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("1. Нанести урон; 2. Лечение; ");
            int v = Convert.ToInt32(Console.ReadLine());
            if (v == 1)
            {
                Uron(igroki, dead_igrok, plays, Friend, Vragi);
                help_5 = 0;
                help_6 = 0;
                Friend.Clear();
                Vragi.Clear();
            }
            if (v == 2)
            {
                doc();
            }
            else
            {
                Vibor_2(igroki, dead_igrok, plays, Friend, Vragi);
            }
        }
        private void Vost(List<Igra> igroki, List<Igra> dead_igrok, Igra plays, List<Igra> Vragi, List<Igra> Friend)
        {
            float vosst = koll - kol;
            kol = kol + vosst;
            Console.WriteLine("Вы полностью восстановили свое здоровье");
            this.i++;
            Vibor(igroki, dead_igrok, plays, Friend, Vragi);
        }
        private void Perem_gor(List<Igra> igroki, List<Igra> dead_igrok, Igra plays, List<Igra> Vragi, List<Igra> Friend)
        {
            Console.Write("Переместиться на: ");
            int x_2 = Convert.ToInt32(Console.ReadLine());
            this.x = this.x + x_2;
            Console.WriteLine($"Новое расположение: {x}; {y}");
            Fight(igroki, dead_igrok, plays, Friend, Vragi);
        }
        private void Perem_vert(List<Igra> igroki, List<Igra> dead_igrok, Igra plays, List<Igra> Vragi, List<Igra> Friend)
        {
            Console.Write("Переместиться на: ");
            int y_2 = Convert.ToInt32(Console.ReadLine());
            this.y = this.y + y_2;
            Console.WriteLine($"Новое расположение: {x}; {y}");
            Fight(igroki, dead_igrok, plays, Friend, Vragi);
        }
        private void doc()
        {
            Random rd = new Random();
            lech = rd.Next(1, 3);
            kol = kol + lech;
            if (kol > koll)
            {
                kol = koll;
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
            Console.WriteLine("Укажите количество ваших жизней: От 5 до 20");
            kol = Convert.ToInt32(Console.ReadLine());
            while (kol < 5 || kol > 20)
            {
                Console.WriteLine("Попробуйте еще раз");
                kol = Convert.ToInt32(Console.ReadLine());
            }
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