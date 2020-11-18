using System;

namespace FMI_TASK_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int healthspider = rnd.Next(300, 500);
            int damagespider;
            int healthplayer = rnd.Next(200, 300);
            int manaplayer = rnd.Next(200, 400);
            bool startGame = true;
            string castspell;

            Console.WriteLine("Вы попали в игру 'Убей паука'\n " +
                "\nВы можете использовать всего 4 заклинания:\n"+
                "1. fireball - Огненый шар наносит 50 урона, отнимает 15 единиц маны.\n" +
                "2. healing - Востанавливает игроку  20 здоровья, отнимает 30 единиц маны.\n" +
                "3. lightningbolt - Удар молнией наносит 100 урона, отнимает 50 единиц маны.\n" +
                "4. rockrain - Каменный дождь наносит 35 урона каждую секунду, отнимает 120 единиц маны.\n");

            while (startGame)
            {
                damagespider = rnd.Next(20, 85);
                Console.WriteLine($"\nСтатистика Паука: \n Здоровье: {healthspider} , Урон: {damagespider} \n\nСтатистика игрока: \n Здоровье: {healthplayer} , Мана: {manaplayer} \n");
                Console.Write("Введите заклинание: ");
                castspell = Console.ReadLine();
                if (manaplayer <= 15)
                {
                    startGame = false;
                    Console.WriteLine("\nИгра окончена, недостаточно маны для продолжения битвы");
                }
                else if (healthspider <= 0)
                {
                    startGame = false;
                    Console.WriteLine("\nПаук погиб");
                }
                else if (healthplayer <= 0)
                {
                    startGame = false;
                    Console.WriteLine("\nИгрок погиб");
                }
                else
                {
                    switch (castspell)
                    {
                        case "fireball":
                            if (manaplayer >= 15)
                            {
                                healthspider -= 40;
                                Console.WriteLine("\nПаук потерял 50 единиц здоровья");
                                manaplayer -= 15;
                                healthplayer -= damagespider;
                                Console.Write($"\nПаук атаковал ядом игрок потерял {damagespider} здоровья\n");
                            }
                            else
                            {
                                Console.WriteLine("\nУ вас не достаточно маны!");
                            }
                            break;
                        case "healing":
                            if (manaplayer >= 30)
                            {
                                manaplayer -= 30;
                                healthplayer += 20;
                                Console.WriteLine($"\nВаше текущее здоровье равно: {healthplayer}");
                            }
                            else if (healthplayer >= 349)
                            {
                                Console.WriteLine("\nУ вас полный запас здоровья");
                            }
                            else
                            {
                                Console.WriteLine("\nУ вас не достаточно маны!");
                            }
                            break;
                        case "lightningbolt":
                            if (manaplayer >= 50)
                            {
                                Console.WriteLine("\nПаук потерял 100 единиц здоровья");
                                healthspider -= 100;
                                manaplayer -= 50;
                                healthplayer -= damagespider;
                                Console.Write($"\nПаук выпустил маленьких пауков которые нанесли {damagespider} урона\n");
                            }
                            else
                            {
                                Console.WriteLine("\nУ вас не достаточно маны!");
                            }
                            break;
                        case "rockrain":
                            if (manaplayer >= 120)
                            {
                                int rockrain = 0;
                                for (int i = 1; i < 6; i++)
                                {
                                    rockrain += 35;
                                    healthspider -= 35;
                                    Console.Write($"Атака каменным дождем наносит урон пауку {rockrain}:  \nПродолжительность атаки {i} секунды");
                                    Console.WriteLine();
                                }
                                Console.WriteLine("\nПаук потерял после атаки 175 единиц здоровья");
                                manaplayer -= 40;
                                Console.Write($"\nПаук использовал пополнение здоровья {healthspider} единиц");
                                healthspider += 150;
                            }
                            else
                            {
                                Console.WriteLine("\nУ вас не достаточно маны!");
                            }
                            break;
                        default:
                            Console.WriteLine($"\nВам незнакомо {castspell} это заклинание");
                            break;
                    }

                }
            }
        }
    }
}
