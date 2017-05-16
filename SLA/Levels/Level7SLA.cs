﻿using Assets.Scripts.Drones;
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

        public override void CreateDrones()
        {
            // Spawn Bouncing Drones
            DroneFactory.SpawnAndAddDrones(new RandomDrone(6f, 1.5f, DroneColor.Red), 15, 6f, BoundariesSLA.BouncingSla);

            DroneFactory.SpawnDrones(new MineDrone(5, 3, DroneColor.Red, new Pat360Drones(64, 4, true, false, 0, 720, changeDirection: true),
                new DefaultDrone(8, 1.3f, DroneColor.Cyan)), area: BoundariesSLA.FlyingSla);
        }
    }
}