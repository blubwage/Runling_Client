﻿using System.Collections.Generic;
using Assets.Scripts.Drones;
using Assets.Scripts.Launcher;
using UnityEngine;

namespace Assets.Scripts.RLR.Levels
{
    public class Level9HardRLR : ALevelRLR
    {
        public Level9HardRLR(LevelManagerRLR manager) : base(manager)
        {
        }

        protected override float SetAirCollider()
        {
            return 10;
        }

        public override void SetChasers()
        {
            Manager.RunlingChaser.SetChaserPlatforms(new DefaultDrone(9, 1f, DroneColor.DarkGreen, moveDelegate: DroneMovement.ChaserMovement), new int[1] { 1}, new int[1] { 4});
        }


        public override void CreateDrones()
        {
            Area[] laneArea = Manager.GenerateMapRLR.GetDroneSpawnArea();

            // Spawn bouncing drones
            for (var i = 1; i < laneArea.Length - 2; i++)
            {
                DroneFactory.SpawnDrones(new RandomDrone(7, 2f, DroneColor.Grey), (int)(11 - i * 0.4f), area: laneArea[i]);
            }
            DroneFactory.SpawnDrones(new RandomDrone(7, 2f, DroneColor.Grey), 4, area: laneArea[19]);
            DroneFactory.SpawnDrones(new RandomDrone(7, 2f, DroneColor.Grey), 3, area: laneArea[20]);

            // Spawn blue drones
            DroneFactory.SetPattern(new Pat360Drones(48, 10, true, true, 270), new DefaultDrone(15, 2, DroneColor.Blue));
            DroneFactory.SetPattern(new Pat360Drones(48, 10, true, true, 90), new DefaultDrone(15, 2, DroneColor.Blue));

            // Spawn yellow drones
            DroneFactory.SetPattern(new Pat360Drones(40, repeat: true, pulseDelay: 6),
                new DefaultDrone(15, 2, DroneColor.Golden, moveDelegate: DroneMovement.CurvedMovement, curving: 7));
        }
    }
}
