﻿using System.Collections.Generic;
using Assets.Scripts.Drones;
using UnityEngine;

namespace Assets.Scripts.RLR.Levels
{
    public class Level7HardRLR : ALevelRLR
    {
        public Level7HardRLR(LevelManagerRLR manager) : base(manager)
        {
        }

        public override void CreateDrones()
        {
            Area[] laneArea = Manager.GenerateMapRLR.GetDroneSpawnArea();

            // Spawn bouncing drones
            for (var i = 1; i < laneArea.Length - 2; i++)
            {
                DroneFactory.SpawnDrones(new RandomDrone(7, 2, DroneColor.Grey), (int)(11 - i * 0.4f), area: laneArea[i]);
            }
            DroneFactory.SpawnDrones(new RandomDrone(7, 2, DroneColor.Grey), 4, area: laneArea[19]);
            DroneFactory.SpawnDrones(new RandomDrone(7, 2, DroneColor.Grey), 3, area: laneArea[20]);

            // Spawn yellow drones
            DroneFactory.SetPattern(new PatContinuousSpawn(0.1f, 1),
                new RandomDrone(13, 2, DroneColor.Golden, restrictedZone: 0, droneType: DroneType.FlyingOnewayDrone, moveDelegate: DroneMovement.FixedCosinusoidalMovement, sinForce: 80, sinFrequency: 5.5f));
        }
    }
}
