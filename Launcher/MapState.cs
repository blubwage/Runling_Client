﻿using System.Collections.Generic;
using Characters.Types;
using UnityEngine;

namespace Launcher
{
    public class MapState
    {
        public List<GameObject> SafeZones;
        public bool[] VisitedSafeZones;
        public GameObject DronesParent;

        //private Game

        public MapState()
        {
        }
    }
}
