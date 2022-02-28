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
            const char IdRashamonAttack = '1';
            const char IdHuganzakuraAttack = '2';
            const char IdDimensionalRiftAttack = '3';
            const char IdCloneAttack = '4';
            const char IdAlpacaAttack = '5';

            Random random = new Random();

            int maximumPlayerHealth = 101;
            int minimumPlayerHealth = 70;
            int playerHealth = random.Next(minimumPlayerHealth, maximumPlayerHealth);
            int halfOfNumber = 2;
            int maximumBossHealth = 301;
            int minimumBossHealt = 200;
            int bossHealth = random.Next(minimumBossHealt, maximumBossHealth);
            int bossAttackPhase;
            int maximumBossAttackPhase = 4;
            int minimumBossAttackPhase = 1;
            int bossDamage;
            int maximumBossDamage = 31;
            int minimumBossDamage = 10;
            int bossHealing;
            int bossHealingChance = 1;
            int maximumBossHealing = 21;
            int minimumBossHealing = 10;
            int damageRashamonAttack = 10;
            int damageHuganzakuraAttack = 30;
            int healingDimensionalRiftAttack = 30;
            int damageCloneAttack = 50;
            int maximumCloneAttackChance = 7;
            int minimumCloneAttackChance = 1;
            int executeCloneAttack = 1;
            int cloneAttackChance;
            int healingAlpacaAttack;
            int percentAlpacaAttackChance = 10;
            int maximumAlpacaAttackChance = 11;
            int minimumAlpacaAttackChance = 1;
            int executeAlpacaAttack = 1;
            int alpacaAttackChance;
            char userInput;
            string rashamonAttack = "rashamon";
            string huganzakuraAttack = "huganzakura";
            string dimensionalRiftAttack = "dimensional rift";
            string cloneAttack = "clone";
            string alpacaAttack = "alpaca";
            string noneAttack = "none";
            string lastAttack = noneAttack;
            bool isInvisible = false;

            while (playerHealth > 0 && bossHealth > 0)
            {
                Console.WriteLine($"       Ваше здоровье => {playerHealth}       |       Здоровье врага => {bossHealth}" +
                                  $"\nКак будем атаковать?" +
                                  $"\n{IdRashamonAttack}. Рашамон (Призывает теневого духа для нанесения атаки)   |" +
                                  $"   Отнимает {damageRashamonAttack} хп игроку)" +
                                  $"\n{IdHuganzakuraAttack}. Хуганзакура (Может быть выполнен только после призыва теневого духа!)   |" +
                                  $"   Наносит {damageHuganzakuraAttack} ед. урона" +
                                  $"\n{IdDimensionalRiftAttack}. Межпространственный разлом – позволяет скрыться в разломе и " +
                                  $"восстановить {healingDimensionalRiftAttack} хп. " +
                                  $"Урон босса по вам не проходит (Не может быть использовано подряд)" +
                                  $"\n{IdCloneAttack}. Клонирование (Создает вашего клона и если враг попадает по нему наносит " +
                                  $"{damageCloneAttack} ед. урона врагу)" +
                                  $"\n{IdAlpacaAttack}. Альпака (Шанс, что она в вас плюнет и увеличит ваше здоровье в {halfOfNumber} " +
                                  $"раза равен {percentAlpacaAttackChance}%)" +
                                  $"\n-------------------------------------------" +
                                  $"\n\n-------Ваша последняя атака: {lastAttack}.-------");
                userInput = Console.ReadKey().KeyChar;

                switch (userInput)
                {
                    case IdRashamonAttack:
                        bossHealth -= damageRashamonAttack;
                        lastAttack = rashamonAttack;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nВы использовали Рашамон!");
                        break;
                    case IdHuganzakuraAttack:
                        if (lastAttack.Equals(rashamonAttack))
                        {
                            bossHealth -= damageHuganzakuraAttack;
                            lastAttack = huganzakuraAttack;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nВы использовали Хуганзакуру!");
                        }
                        else
                        {
                            lastAttack = noneAttack;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nВы не смогли использовать Хуганзакура!");
                        }
                        break;
                    case IdDimensionalRiftAttack:
                        if (lastAttack.Equals(dimensionalRiftAttack))
                        {
                            lastAttack = noneAttack;
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
                    case IdCloneAttack:
                        cloneAttackChance = random.Next(minimumCloneAttackChance, maximumCloneAttackChance);
                        if (cloneAttackChance == executeCloneAttack)
                        {
                            bossHealth -= damageCloneAttack;
                            lastAttack = cloneAttack;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\nВы использовали Клонирование!" +
                                              $"\nВрагу нанесён урон в {damageCloneAttack} единиц!");
                        }
                        else
                        {
                            lastAttack = cloneAttack;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nВы использовали Клонирование!" +
                                              "\nКлонирование не сработало!");
                        }
                        break;
                    case IdAlpacaAttack:
                        alpacaAttackChance = random.Next(minimumAlpacaAttackChance, maximumAlpacaAttackChance);
                        if (alpacaAttackChance == executeAlpacaAttack)
                        {
                            healingAlpacaAttack = playerHealth / halfOfNumber;
                            playerHealth += healingAlpacaAttack;
                            lastAttack = alpacaAttack;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\nВы призвали Альпаку!" +
                                              $"\nВы увеличили здоровье в {halfOfNumber} раза!");
                        }
                        else
                        {
                            lastAttack = alpacaAttack;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nВы призвали Альпаку!" +
                                              "\nАльпака убежал :'/");
                        }
                        break;
                    default:
                        lastAttack = noneAttack;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nВы промахнулись атакой!");
                        break;
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("-------------------------------------------");

                bossAttackPhase = random.Next(minimumBossAttackPhase, maximumBossAttackPhase);

                if (bossAttackPhase == bossHealingChance)
                {
                    bossHealing = random.Next(minimumBossHealing, maximumBossHealing);
                    bossHealth += bossHealing;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Враг вылечился на {bossHealing} единиц!");
                }
                else
                {
                    if (isInvisible == false)
                    {
                        bossDamage = random.Next(minimumBossDamage, maximumBossDamage);
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