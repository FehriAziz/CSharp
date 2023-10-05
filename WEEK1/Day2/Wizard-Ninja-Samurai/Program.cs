using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Wizard JoeWiz = new Wizard("Joe Wizard");
            Ninja JoeNin = new Ninja("Joe Ninja");
            Samurai JoeSam = new Samurai("Joe Samurai");
            System.Console.WriteLine($"{JoeWiz.Name}'s health is: {JoeWiz.Health}");
            System.Console.WriteLine($"{JoeNin.Name}'s health is: {JoeNin.Health}");
            System.Console.WriteLine($"{JoeSam.Name}'s health is: {JoeSam.Health}");
            JoeWiz.Attack(JoeSam);
            System.Console.WriteLine("\n");
            System.Console.WriteLine($"{JoeWiz.Name}'s health is: {JoeWiz.Health}");
            System.Console.WriteLine($"{JoeNin.Name}'s health is: {JoeNin.Health}");
            System.Console.WriteLine($"{JoeSam.Name}'s health is: {JoeSam.Health}");
            JoeNin.Attack(JoeWiz);
            System.Console.WriteLine("\n");
            System.Console.WriteLine($"{JoeWiz.Name}'s health is: {JoeWiz.Health}");
            System.Console.WriteLine($"{JoeNin.Name}'s health is: {JoeNin.Health}");
            System.Console.WriteLine($"{JoeSam.Name}'s health is: {JoeSam.Health}");
            JoeWiz.Heal(JoeWiz);
            System.Console.WriteLine("\n");
            System.Console.WriteLine($"{JoeWiz.Name}'s health is: {JoeWiz.Health}");
            System.Console.WriteLine($"{JoeNin.Name}'s health is: {JoeNin.Health}");
            System.Console.WriteLine($"{JoeSam.Name}'s health is: {JoeSam.Health}");
            JoeSam.Meditate();
            System.Console.WriteLine("\n");
            System.Console.WriteLine($"{JoeWiz.Name}'s health is: {JoeWiz.Health}");
            System.Console.WriteLine($"{JoeNin.Name}'s health is: {JoeNin.Health}");
            System.Console.WriteLine($"{JoeSam.Name}'s health is: {JoeSam.Health}");
            JoeNin.Steal(JoeSam);
            System.Console.WriteLine("\n");
            System.Console.WriteLine($"{JoeWiz.Name}'s health is: {JoeWiz.Health}");
            System.Console.WriteLine($"{JoeNin.Name}'s health is: {JoeNin.Health}");
            System.Console.WriteLine($"{JoeSam.Name}'s health is: {JoeSam.Health}");
        }
    }

    class Human
    {
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        private int health;
        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public Human(string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
        }

        public Human(string name, int str, int intell, int dxt, int hp)
        {
            Name = name;
            Strength = str;
            Intelligence = intell;
            Dexterity = dxt;
            health = hp;
        }

        public virtual int Attack(Human target)
        {
            target.health -= Strength * 5;
            return target.Health;
        }
    }

    class Wizard : Human
    {
        public Wizard(string name) : base(name)
        {
            Health = 50;
            Intelligence = 25;
        }
        public override int Attack(Human target)
        {
            target.Health -= Intelligence * 5;
            this.Health += Intelligence * 5;
            return target.Health;
        }
        public int Heal(Human target)
        {
            target.Health += Intelligence * 10;
            return target.Health;
        }
    }

    class Ninja : Human
    {
        public Ninja(string name) : base(name)
        {
            Dexterity = 175;
        }
        public override int Attack(Human target)
        {
            Random rnd = new Random();
            if (rnd.Next(0, 5) == 0)
            {
                target.Health -= (Dexterity * 5) + 10;
            }
            else
            {
                target.Health -= Dexterity * 5;
            }
            return target.Health;
        }
        public int Steal(Human target)
        {
            target.Health -= 5;
            Health += 5;
            return Health;
        }
    }

    class Samurai : Human
    {
        public Samurai(string name) : base(name)
        {
            Health = 200;
        }
        public override int Attack(Human target)
        {
            int finisher = base.Attack(target);
            if (finisher < 50)
            {
                target.Health = 0;
            }
            return target.Health;
        }
        public int Meditate()
        {
            Health = 200;
            return Health;
        }
    }
}
