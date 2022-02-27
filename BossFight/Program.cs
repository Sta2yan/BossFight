using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            int playerHealth = rand.Next(70, 101);
            char userInput;
            int bossHealth = rand.Next(200, 301);
            int bossAttackPhase;
            int bossDamage;
            int bossHealing;
            int damageRashamonAttack = 10;
            int damageHuganzakuraAttack = 30;
            int healingDimensionalRiftAttack = 30;
            int damageCloneAttack = 50;
            int healingAlpacaAttack;
            int cloneAttackChance;
            int alpacaAttackChance;
            string rashamonAttack = "rashamon";
            string huganzakuraAttack = "huganzakura";
            string dimensionalRiftAttack = "dimensional rift";
            string cloneAttack = "clone";
            string alpacaAttack = "alpaca";
            string lastAttack = "none";
            bool isInvisible = false;

            while (playerHealth > 0 && bossHealth > 0)
            {
                Console.WriteLine($"       Ваше здоровье => {playerHealth}       |       Здоровье врага => {bossHealth}" +
                                  $"\nКак будем атаковать?" +
                                  $"\n1. Рашамон (Призывает теневого духа для нанесения атаки)   |   Отнимает 10 хп игроку)" +
                                  $"\n2. Хуганзакура (Может быть выполнен только после призыва теневого духа!)   |   Наносит 30 ед. урона" +
                                  $"\n3. Межпространственный разлом – позволяет скрыться в разломе и восстановить 30 хп. " +
                                  $"Урон босса по вам не проходит (Не может быть использовано подряд)" +
                                  $"\n4. Клонирование (Создает вашего клона и если враг попадает по нему наносит 50 ед. урона врагу)" +
                                  $"\n5. Альпака (Шанс, что она в вас плюнет и увеличит ваше здоровье в 2 раза равен 10%)" +
                                  $"\n-------------------------------------------");
                userInput = Console.ReadKey().KeyChar;

                switch (userInput)
                {
                    case '1':
                        bossHealth -= damageRashamonAttack;
                        lastAttack = rashamonAttack;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nВы использовали Рашамон!");
                        break;
                    case '2':
                        if (lastAttack.Equals(rashamonAttack))
                        {
                            bossHealth -= damageHuganzakuraAttack;
                            lastAttack = huganzakuraAttack;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nВы использовали Хуганзакуру!");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nВы не смогли использовать Хуганзакура!");
                        }
                        break;
                    case '3':
                        if (lastAttack.Equals(dimensionalRiftAttack))
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nВы не смогли использовать Межпространственный разлом!");
                        }
                        else
                        {
                            isInvisible = true;
                            playerHealth += healingDimensionalRiftAttack;
                            lastAttack = dimensionalRiftAttack;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nВы использовали Межпространственный разлом!");
                        }
                        break;
                    case '4':
                        cloneAttackChance = rand.Next(1, 7);
                        if (cloneAttackChance == 1)
                        {
                            bossHealth -= damageCloneAttack;
                            lastAttack = cloneAttack;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nВы использовали Клонирование!" +
                                              "\nВрагу нанесён урон в 50 единиц!");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nВы использовали Клонирование!" +
                                              "\nКлонирование не сработало!");
                        }
                        break;
                    case '5':
                        alpacaAttackChance = rand.Next(1, 11);
                        if (alpacaAttackChance == 1)
                        {
                            healingAlpacaAttack = playerHealth / 2;
                            playerHealth += healingAlpacaAttack;
                            lastAttack = alpacaAttack;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nВы призвали Альпаку!" +
                                              "\nВы увеличили здоровье в 2 раза!");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nВы призвали Альпаку!" +
                                              "\nАльпака убежал :'/");
                        }
                        break;
                    default:
                        lastAttack = "none";
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nВы промахнулись атакой!");
                        break;
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("-------------------------------------------");

                bossAttackPhase = rand.Next(1, 4);

                if (bossAttackPhase == 1)
                {
                    bossHealing = rand.Next(10, 21);
                    bossHealth += bossHealing;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Враг вылечился на {bossHealing} единиц!");
                }
                else
                {
                    if (isInvisible == false)
                    {
                        bossDamage = rand.Next(20, 31);
                        playerHealth -= bossDamage;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Враг нанес урон на {bossDamage} единиц!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Враг не смог нанести урон!");
                    }
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("-------------------------------------------");

                isInvisible = false;
                Console.ReadKey();
                Console.Clear();
            }

            if (playerHealth > 0)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Clear();
                Console.WriteLine($"Поздравляем с победой! Оставшиеся очки здоровья: {playerHealth} единиц.");
            }
            else if(bossHealth > 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.WriteLine($"Вас убили! Оставшиеся очки здоровья врага: {bossHealth} единиц.");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Clear();
                Console.WriteLine("Ничья, вы оба мертвы! Да, и такое бывает.");
            }
        }
    }
}