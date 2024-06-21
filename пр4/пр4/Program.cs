using System;
using System.Collections.Generic;
using System.Linq;

namespace MageBattle
{
    // Інтерфейс заклять
    public interface ISpell
    {
        string Name { get; }
        int Power { get; }
        void Cast(Mage target);
    }

    // Абстрактний клас магів
    public abstract class Mage
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Health { get; protected set; }
        public List<ISpell> Spells { get; private set; }

        protected Mage(string name, int level)
        {
            Name = name;
            Level = level;
            Health = 100;
            Spells = new List<ISpell>();
        }

        public abstract void Attack(Mage target);
        public abstract void Defend(ISpell spell);

        public void AddSpell(ISpell spell)
        {
            Spells.Add(spell);
        }

        public bool IsAlive()
        {
            return Health > 0;
        }

        public void ShowStatus()
        {
            Console.WriteLine($"{Name} - Level: {Level}, Health: {Health}");
        }
    }

    // Реалізація заклять
    public class Fireball : ISpell
    {
        public string Name { get; } = "Fireball";
        public int Power { get; } = 20;

        public void Cast(Mage target)
        {
            Console.WriteLine($"{target.Name} is hit by {Name} for {Power} damage!");
            target.Defend(this);
        }
    }

    public class WaterShield : ISpell
    {
        public string Name { get; } = "Water Shield";
        public int Power { get; } = -15;  // Negative power for healing

        public void Cast(Mage target)
        {
            Console.WriteLine($"{target.Name} gains {Math.Abs(Power)} health from {Name}!");
            target.Defend(this);
        }
    }

    public class Earthquake : ISpell
    {
        public string Name { get; } = "Earthquake";
        public int Power { get; } = 25;

        public void Cast(Mage target)
        {
            Console.WriteLine($"{target.Name} is hit by {Name} for {Power} damage!");
            target.Defend(this);
        }
    }

    // Конкретні класи магів
    public class FireMage : Mage
    {
        public FireMage(string name, int level) : base(name, level) { }

        public override void Attack(Mage target)
        {
            if (Spells.Any())
            {
                foreach (var spell in Spells)
                {
                    Console.WriteLine($"{Name} attacks {target.Name} with {spell.Name}!");
                    spell.Cast(target);
                    if (!target.IsAlive()) break;
                }
            }
        }

        public override void Defend(ISpell spell)
        {
            Health -= spell.Power;
        }
    }

    public class WaterMage : Mage
    {
        public WaterMage(string name, int level) : base(name, level) { }

        public override void Attack(Mage target)
        {
            if (Spells.Any())
            {
                foreach (var spell in Spells)
                {
                    Console.WriteLine($"{Name} attacks {target.Name} with {spell.Name}!");
                    spell.Cast(target);
                    if (!target.IsAlive()) break;
                }
            }
        }

        public override void Defend(ISpell spell)
        {
            Health -= spell.Power;
        }
    }

    public class EarthMage : Mage
    {
        public EarthMage(string name, int level) : base(name, level) { }

        public override void Attack(Mage target)
        {
            if (Spells.Any())
            {
                foreach (var spell in Spells)
                {
                    Console.WriteLine($"{Name} attacks {target.Name} with {spell.Name}!");
                    spell.Cast(target);
                    if (!target.IsAlive()) break;
                }
            }
        }

        public override void Defend(ISpell spell)
        {
            Health -= spell.Power;
        }
    }

    // Основний клас гри
    class Program
    {
        static void Main(string[] args)
        {
            List<ISpell> availableSpells = new List<ISpell>
            {
                new Fireball(),
                new WaterShield(),
                new Earthquake()
            };

            // Вибір магів
            Mage player1 = ChooseMage("Player 1", availableSpells);
            Mage player2 = ChooseMage("Player 2", availableSpells);

            // Виведення початкового стану
            player1.ShowStatus();
            player2.ShowStatus();

            // Битва
            while (player1.IsAlive() && player2.IsAlive())
            {
                player1.Attack(player2);
                if (player2.IsAlive())
                {
                    player2.Attack(player1);
                }
                player1.ShowStatus();
                player2.ShowStatus();
            }

            // Визначення переможця
            if (player1.IsAlive())
            {
                Console.WriteLine($"{player1.Name} wins!");
            }
            else
            {
                Console.WriteLine($"{player2.Name} wins!");
            }
        }

        static Mage ChooseMage(string playerName, List<ISpell> availableSpells)
        {
            Console.WriteLine($"{playerName}, choose your mage:");
            Console.WriteLine("1. Fire Mage");
            Console.WriteLine("2. Water Mage");
            Console.WriteLine("3. Earth Mage");
            int choice = int.Parse(Console.ReadLine());

            Console.Write($"{playerName}, enter your mage's name: ");
            string mageName = Console.ReadLine();

            Mage mage;
            switch (choice)
            {
                case 1:
                    mage = new FireMage(mageName, 1);
                    break;
                case 2:
                    mage = new WaterMage(mageName, 1);
                    break;
                case 3:
                    mage = new EarthMage(mageName, 1);
                    break;
                default:
                    throw new InvalidOperationException("Invalid mage choice");
            }

            Console.WriteLine($"{playerName}, choose your spells (enter two numbers separated by spaces):");
            for (int i = 0; i < availableSpells.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availableSpells[i].Name} (Power: {availableSpells[i].Power})");
            }

            string[] spellChoices;
            while (true)
            {
                spellChoices = Console.ReadLine().Split(' ');
                if (spellChoices.Length == 2)
                {
                    break;
                }
                Console.WriteLine("Please choose exactly two spells:");
            }

            foreach (string spellChoice in spellChoices)
            {
                int spellIndex = int.Parse(spellChoice) - 1;
                if (spellIndex >= 0 && spellIndex < availableSpells.Count)
                {
                    mage.AddSpell(availableSpells[spellIndex]);
                }
            }

            return mage;
        }
    }
}

