using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD4T4
{
    internal class stats
    {
        public string name;
        public string description;
        public int damage;
        public float heal;
        public int cost;
        public float armourPenetration;
        public stats(string name, int damage, float heal, int cost, float armourPenetration, string description)
        {
            this.name = name;
            this.description = description;
            this.damage = damage;
            this.heal = heal;
            this.cost = cost;
            this.armourPenetration = armourPenetration;
        }
    }
    internal class player
    {
        public float health;
        public float maxhealth;
        public float energy;
        public float maxEnergy;
        public float armour;
        public string name;
        public stats skilledStatistics;
        public player(string name, float health, float energy, float armour)
        {
            this.name = name;
            this.health = health;
            this.energy = energy;
            this.armour = armour;
        }

        public string attack(player enemy)
        {
            string result;

            result = (name + " used skill " + skilledStatistics.name + " " + skilledStatistics.description + " against " + enemy.name + " doing " + DamageCalculator(enemy) + " damage ");
            if (DamageCalculator(enemy) > 0)
            {
                result += (name + " healed for " + skilledStatistics.cost + " health ");
                updateHealth(skilledStatistics.heal);
            }
            if (enemy.armour == 0)
            {
                result += (enemy.name + " died ");
            }
            else
            {
                result += (enemy.name + " is at " + (enemy.health % health));
            }
            return result;

        }
        public void updateHealth(float heal)
        {
            if (health > 0 && health + heal < maxhealth)
            {
                health += heal;
            }
        }
        public float updateArmour(player enemy)
        {
            return armour - enemy.skilledStatistics.armourPenetration;
        }
        public bool updateEnergy(int cost, string nam)
        {
            if (cost > energy)
            {
                Console.WriteLine("Player " + name + " tried to use " + nam + " but didn't have enough energy");
                return false;
            }
            else
            {
                if (energy > 0)
                {
                    energy = energy - cost;
                    return true;
                }
            }
            return false;
        }
        public float DamageCalculator(player enemy)
        {
            float d = skilledStatistics.damage * ((100 - enemy.armour) / 100);
            return d;
        }
        public bool learnSkill(stats skill)
        {
            if (updateEnergy(skill.cost, skill.name) == true)
            {
                skilledStatistics = skill;
                return true;
            }

            return false;

        }
        public bool displayInfo(string pName)
        {
            if (pName == name)
            {
                Console.WriteLine("Name: " + name);
                Console.WriteLine("MaxHealth: " + maxhealth);
                Console.WriteLine("Health: " + health);
                Console.WriteLine("Energy: " + energy);
                Console.WriteLine("MaxEnergy: " + maxEnergy);
                Console.WriteLine("Armour: " + armour);
                Console.ReadKey();
                return true;
            }
            return false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<player> p = new List<player>();
            List<stats> statistics = new List<stats>();
            int op=0;
            while (op != 6)
            {
                op = Menu();
                Console.Clear();
                if (op == 1)
                {
                    p.Add(AddPlayer());
                }
                if (op == 2)
                {
                    statistics.Add(AddStats());
                }
                if (op == 3)
                {
                    Console.WriteLine("Enter player Name: ");
                    string name = Console.ReadLine();
                    bool flag = false;
                    for (int i = 0; i < p.Count; i++)
                    {
                        flag = p[i].displayInfo(name);
                    }
                    if (flag == false)
                    {
                        Console.WriteLine("Player not found!");
                        Console.ReadKey();
                    }
                }
                if (op == 4)
                {
                    Console.WriteLine("Enter Player Name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter skill Name: ");
                    string skill = Console.ReadLine();
                    foreach (stats i in statistics)
                    {
                        if (i.name == skill)
                        {
                            foreach (player j in p)
                            {
                                j.learnSkill(i);
                                Console.WriteLine("Done!");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Skill not found");
                            Console.ReadKey();
                        }

                    }
                }
                if (op == 5)
                {
                    Console.WriteLine("Enter caster name: ");
                    string n = Console.ReadLine();

                    Console.WriteLine("Enter target name: ");
                    string t = Console.ReadLine();
                    foreach (player i in p)
                    {
                        if (n == i.name)
                        {
                            foreach (player j in p)
                            {
                                if (j.name == t)
                                {
                                    Console.WriteLine(i.attack(j));
                                }
                            }
                        }

                    }

                }
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
            }
          
        }
        static int Menu()
        {
            Console.Clear();
            Console.WriteLine("1. Add Player");
            Console.WriteLine("2. Add Skill Statistics");
            Console.WriteLine("3. Display Player Info");
            Console.WriteLine("4. Learn a skill");
            Console.WriteLine("5. Attack");
            Console.WriteLine("6. Exit");
            int op = int.Parse(Console.ReadLine());
            return op;
        }
        static player AddPlayer()
        {
            Console.WriteLine("Enter Player Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter player health: ");
            float h = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Player Energy: ");
            float e = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter player armour: ");
            float armour = float.Parse(Console.ReadLine());
            player p = new player(name, h, e, armour);
            return p;
        }
        static stats AddStats()
        {
            Console.WriteLine("Enter skill name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter skill description: ");
            string des = Console.ReadLine();
            Console.WriteLine("Enter its damage: ");
            int d = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter its heal: ");
            float h = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter its cost: ");
            int cost = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter its armour penetration: ");
            float AP = float.Parse(Console.ReadLine());
            stats s = new stats(name, d, h, cost, AP, des);
            return s;
        }
    }
}

    
