﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level6SLA : MonoBehaviour
{

    // attach scripts
    public SpawnDrone _spawnDrone;
    public AddDrone _addDrone;
    public BoundariesSLA _area;

        public void Level6Drones()
    {
        // Spawn drones (dronecount/delay, speed, size, color)
        _spawnDrone.RandomBouncingDrone(15, 7f, 1f, Color.blue, _area.bouncingSLA);
        _addDrone.RandomBouncingDrone(6f, 7f, 1f, Color.blue, _area.bouncingSLA);

        // Spawn green drones (initial delay, speed, size)
        StartCoroutine(GreenDronesLevel6Bottom(4f, 7f, 1.5f));
        StartCoroutine(GreenDronesLevel6Top(5f, 7f, 1.5f));
    }

    IEnumerator GreenDronesLevel6Bottom(float delay, float speed, float size)
    {
        while (true)
        {
            Vector3 startPos = new Vector3();
            float rotation;
            bool clockwise;
            startPos = Location(size, _area.flyingSLA);
            int droneCount = 0;

            if (startPos.x < 0)
            {
                rotation = 90f;
                clockwise = false;
            }
            else
            {
                rotation = -90f;
                clockwise = true;
            }


            _spawnDrone.DelayedStraightFlying360Drones(24+droneCount, 3f/(16+droneCount), speed, size, Color.green, startPos, rotation, clockwise);
            yield return new WaitForSeconds(delay);
            if (delay > 1.5f) { delay -= delay * 0.03f; }
            if (droneCount < 24) { droneCount +=2; }
        }
    }

    IEnumerator GreenDronesLevel6Top(float delay, float speed, float size)
    {
        while (true)
        {
            Vector3 startPos = new Vector3();
            float rotation;
            bool clockwise;

            startPos = OtherLocation(size, _area.flyingSLA);
            int droneCount = 0;            

            if (startPos.x < 0)
            {
                rotation = 90f;
                clockwise = true;
            }
            else
            {
                rotation = -90f;
                clockwise = false;
            }

            _spawnDrone.DelayedStraightFlying360Drones(24 + droneCount, 3f/(16+droneCount), speed, size, Color.green, startPos, rotation, clockwise);
            yield return new WaitForSeconds(delay);
            if (delay > 1.5f) { delay -= delay * 0.04f; }
            if (droneCount < 24) { droneCount +=2; }
        }
    }

    public Vector3 Location(float size, Area boundary)
    {
        Vector3 startPos = new Vector3();
        int location = Random.Range(0, 7);

        if (location == 0)
        {
            startPos.Set(boundary.leftBoundary + (10.5f + size / 2), 0.6f, boundary.bottomBoundary + (0.5f + size / 2));
        }
        else if (location == 1)
        {
            startPos.Set(boundary.rightBoundary - (10.5f + size / 2), 0.6f, boundary.bottomBoundary + (0.5f + size / 2));
        }
        else if (location == 2)
        {
            startPos.Set(boundary.leftBoundary + (20.5f + size / 2), 0.6f, boundary.bottomBoundary + (0.5f + size / 2));
        }
        else if (location == 3)
        {
            startPos.Set(boundary.rightBoundary - (20.5f + size / 2), 0.6f, boundary.bottomBoundary + (0.5f + size / 2));
        }
        else if (location == 4)
        {
            startPos.Set(boundary.leftBoundary + (30.5f + size / 2), 0.6f, boundary.bottomBoundary + (0.5f + size / 2));
        }
        else if (location == 5)
        {
            startPos.Set(boundary.rightBoundary - (30.5f + size / 2), 0.6f, boundary.bottomBoundary + (0.5f + size / 2));
        }
        else if (location == 6)
        {
            startPos.Set(0, 0.6f, boundary.bottomBoundary + (0.5f + size / 2));
        }

        return startPos;
    }

    public Vector3 OtherLocation(float size, Area boundary)
    {
        Vector3 startPos = new Vector3();
        int location = Random.Range(0, 7);

        if (location == 0)
        {
            startPos.Set(boundary.leftBoundary + (10.5f + size / 2), 0.6f, boundary.topBoundary - (0.5f + size / 2));
        }
        else if (location == 1)
        {
            startPos.Set(boundary.rightBoundary - (10.5f + size / 2), 0.6f, boundary.topBoundary - (0.5f + size / 2));
        }
        else if (location == 2)
        {
            startPos.Set(boundary.leftBoundary + (20.5f + size / 2), 0.6f, boundary.topBoundary - (0.5f + size / 2));
        }
        else if (location == 3)
        {
            startPos.Set(boundary.rightBoundary - (20.5f + size / 2), 0.6f, boundary.topBoundary - (0.5f + size / 2));
        }
        else if (location == 4)
        {
            startPos.Set(boundary.leftBoundary + (30.5f + size / 2), 0.6f, boundary.topBoundary - (0.5f + size / 2));
        }
        else if (location == 5)
        {
            startPos.Set(boundary.rightBoundary - (30.5f + size / 2), 0.6f, boundary.topBoundary - (0.5f + size / 2));
        }
        else if (location == 6)
        {
            startPos.Set(0, 0.6f, boundary.topBoundary - (0.5f + size / 2));
        }

        return startPos;
    }
}
