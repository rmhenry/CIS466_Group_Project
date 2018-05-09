﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    public class Battle
    {
        Character hero, monster;
        Dice battleDice;

        public string winner { get; set; }

        public Battle(Character[] characters, Dice _battleDice)
        {
            hero = characters[0];
            monster = characters[1];
            battleDice = _battleDice;
        }

        public void DoBattle()
        {
            Console.Clear();
            SetBonusValue();
            DisplayBonusValues(monster.attackBonus, hero.attackBonus);
            BattleLoop();
            DetermineWinner();
            DisplayWinner();
        }

        public void SetBonusValue()
        {
            monster.attackBonus = battleDice.Roll();
            hero.attackBonus = battleDice.Roll();
        }

        public void DisplayBonusValues(int monsterBonus, int heroBonus)
        {
            Console.WriteLine("Bonus Roll");
            Console.WriteLine($"Monster bonus attack = {monsterBonus}");
            Console.WriteLine($"Hero bonus attack = {heroBonus}");
            Console.WriteLine();
        }

        public void BattleLoop()
        {
            int roundNumber = 1;

            while (hero.health > 0 && monster.health > 0)
            {
                OffenseAndDefense();
                DisplayBattleStats(roundNumber);
                RemoveBonus();  // Stops bonus application after first round. Comment this line out to use bonus in every round.
                roundNumber++;
            }
        }

        public void OffenseAndDefense()
        {
            monster.Attack(battleDice);
            hero.Defend(monster.CurrentRoundDamage);
            hero.Attack(battleDice);
            monster.Defend(hero.CurrentRoundDamage);
        }

        public void DisplayBattleStats(int roundNumber)
        {
            Console.WriteLine($"Round #{roundNumber}");
            Console.WriteLine($"{monster.name} rolls a {monster.CurrentRoll}");
            Console.WriteLine($"{hero.name} rolls a {hero.CurrentRoll}");
            Console.Write($"{hero.name} | Health: {hero.PreviousRoundHealth} - {monster.CurrentRoundDamage} = {hero.health} | Damage Maximum: {hero.damageMax} | Attack Bonus: {hero.UseBonus}\n");
            Console.Write($"{monster.name} | Health: {monster.PreviousRoundHealth} - {hero.CurrentRoundDamage} = {monster.health} | Damage Maximum: {monster.damageMax} | Attack Bonus: {monster.UseBonus}\n");
            Console.WriteLine();
        }

        public void RemoveBonus()
        // Disables use of attack bonus when called
        {
            if (hero.UseBonus == true)
                hero.UseBonus = false;
            if (monster.UseBonus == true)
                monster.UseBonus = false;
        }

        public void DetermineWinner()
        {
            if (hero.health <= 0 && monster.health <= 0)
                winner = "The battle is a tie!";
            else if (hero.health <= 0 && monster.health > 0)
                winner = monster.name + " is the winner!";
            else
                winner = hero.name + " is the winner!";
        }

        public void DisplayWinner()
        {
            Console.WriteLine(winner);
            Console.WriteLine();
        }
    }
}
