﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeathSLA : MonoBehaviour
{
    public InitializeGameSLA _initializeGameSLA;

    //events following Deathtrigger
    public void Death()
    {

        _initializeGameSLA.newPlayer.SetActive(false);
    }
}
