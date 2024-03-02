using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD4T3
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
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            player alice = new player("alice", 110, 50, 10);
            player bob = new player("bob", 100, 30, 20);
            stats fireBall = new stats("fire ball", 23, 1.2f, 5, 15, "a firey magical attack");
            bool isValid = false;
            isValid = alice.learnSkill(fireBall);
            if (isValid == true)
            {
                Console.WriteLine(alice.attack(bob));
                Console.ReadKey();
            }

            stats superBeam = new stats("super beam", 200, 50, 50, 75, " an over powered attack pls nerf");
            isValid = bob.learnSkill(superBeam);
            if (isValid == true)
            {
                Console.WriteLine(bob.attack(alice));
                Console.ReadKey();
            }

        }
    } 
}
