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
            const char idRashamonAttack = '1';
            const char idHuganzakuraAttack = '2';
            const char idDimensionalRiftAttack = '3';
            const char idCloneAttack = '4';
            const char idAlpacaAttack = '5';

            Random random = new Random();

            int maximumPlayerHealth = 101;
            int minimumPlayerHealth = 70;
            int playerHealth = random.Next(minimumPlayerHealth, maximumPlayerHealth);
            int numberHealthPlayerDie = 0;
            int halfPlayerHealth = 2;
            int maximumBossHealth = 301;
            int minimumBossHealt = 200;
            int bossHealth = random.Next(minimumBossHealt, maximumBossHealth);
            int numberHealthBossDie = 0;
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
            int healingAlpacaAttack;
            int maximumCloneAttackChance = 7;
            int minimumCloneAttackChance = 1;
            int executeCloneAttack = 1;
            int cloneAttackChance;
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
            string lastAttack = "none";
            bool isInvisible = false;

            while (playerHealth > numberHealthPlayerDie && bossHealth > numberHealthBossDie)
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
                    case idRashamonAttack:
                        bossHealth -= damageRashamonAttack;
                        lastAttack = rashamonAttack;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nВы использовали Рашамон!");
                        break;
                    case idHuganzakuraAttack:
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
                    case idDimensionalRiftAttack:
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
                    case idCloneAttack:
                        cloneAttackChance = random.Next(minimumCloneAttackChance, maximumCloneAttackChance);
                        if (cloneAttackChance == executeCloneAttack)
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
                    case idAlpacaAttack:
                        alpacaAttackChance = random.Next(minimumAlpacaAttackChance, maximumAlpacaAttackChance);
                        if (alpacaAttackChance == executeAlpacaAttack)
                        {
                            healingAlpacaAttack = playerHealth / halfPlayerHealth;
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

            if (playerHealth > numberHealthPlayerDie)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Clear();
                Console.WriteLine($"Поздравляем с победой! Оставшиеся очки здоровья: {playerHealth} единиц.");
            }
            else if(bossHealth > numberHealthBossDie)
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