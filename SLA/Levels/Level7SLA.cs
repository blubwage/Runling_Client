﻿using System.Collections;
using Assets.Scripts.Drones;
using UnityEngine;

namespace Assets.Scripts.SLA.Levels
{
    public class Level7SLA : ALevelSLA
    {
        public Level7SLA(LevelManagerSLA manager) : base(manager)
        {
        }

        public override float GetMovementSpeed()
        {
            return 11;
        }

        MineVariations MineVariations = new MineVariations();

        public override void CreateDrones()
        {
            // Spawn Bouncing Drones
            DroneFactory.SpawnAndAddDrones(new RandomBouncingDrone(6f, 1.5f, Color.red), 15, 6f);
            
            // Spawn Mine Drone
             var mine = DroneFactory.SpawnDrones(new MineDrone(5f, 3f, Color.black));

            // Spawn Green Drones
            MineVariations.DelayedStraightFlying360Drones(32, 2f, 2, 8f, 1.3f, Color.cyan, mine, DroneFactory);
        }
    }
}