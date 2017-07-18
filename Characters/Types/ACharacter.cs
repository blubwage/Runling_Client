﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Characters.Types.Features;
using UnityEngine;

namespace Characters.Types
{
    public abstract class ACharacter : MonoBehaviour
    {
        public int PlayerId { get; protected set; } 
        

        public int Exp { get; protected set; }
        public int Level { get; protected set; }
        public int AbilityFirstLevel { get; protected set; }
        public int AbilitySecondLevel { get; protected set; }
        
        
        public int UnspentPoints { get; protected set; }

        public Energy Energy;
        public Speed Speed;

        protected static GameObject _player;

        protected ACharacter(CharacterDto chacterDto) // to delete prob.
        {
            
            Exp = chacterDto.Exp;
            Level = chacterDto.Level;
            AbilityFirstLevel = chacterDto.AbilityFirstLevel;
            AbilitySecondLevel = chacterDto.AbilitySecondLevel;
        }

        protected void InitiazlizeBase(CharacterDto chacterDto)
        {
            Energy = new Energy(chacterDto.EnergyPoints, chacterDto.RegenPoints, 20, 5, 0.5F, 1F);
            Speed = new Speed(10, 0.1F);
            Exp = chacterDto.Exp;
            Level = chacterDto.Level;
            AbilityFirstLevel = chacterDto.AbilityFirstLevel;
            AbilitySecondLevel = chacterDto.AbilitySecondLevel;
        }

        public abstract void Initizalize(CharacterDto character);

        public virtual void AddExp(int exp)
        {
            Exp += exp;
            //Debug.Log(string.Format("Added {0} exp", exp));

            IncrementLevelIfPossible();
        }

        public virtual void IncrementLevelIfPossible()
        {
            if (Exp == 0) return;
            while (Exp >= LevelingSystem.LevelExperienceCurve[Level])
            {
                Level++;
                //Debug.Log(string.Format("you lvled to {0} lvl", Level));
                UnspentPoints += LevelingSystem.NewPointsPerLevel;
            }
        }

        public virtual void IncrementSpeedPoints()
        {
            if (UnspentPoints > 0)
            {
                Speed.IncrementPoints();
                UnspentPoints--;
            }
        }

        public virtual void IncrementRegenPoints()
        {
            if (UnspentPoints > 0)
            {
                Energy.IncreasePointsRegen();
                UnspentPoints--;
            }
        }

        public virtual void IncrementEnergyPoints()
        {
            if (UnspentPoints > 0)
            {
                Energy.IncreasePointsEnergy();
                UnspentPoints--;
            }
        }

        public virtual void IncrementAbilityFirstLevel()
        {
            if (UnspentPoints > LevelingSystem.AbilityPointsCostPerLevel && AbilityFirstLevel < LevelingSystem.AbilityMaxLevel)
            {
                AbilityFirstLevel++;
                UnspentPoints-= LevelingSystem.AbilityPointsCostPerLevel;
            }
        }

        public virtual void IncrementAbilitySecondLevel()
        {
            if (UnspentPoints > LevelingSystem.AbilityPointsCostPerLevel && AbilitySecondLevel < LevelingSystem.AbilityMaxLevel)
            {
                AbilitySecondLevel++;
                UnspentPoints -= LevelingSystem.AbilityPointsCostPerLevel;
            }
        }

        public void Update()
        {
            Energy.RegenerateEnergy();
        }

    }

   
}


