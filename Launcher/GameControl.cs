﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Launcher
{
    public class GameControl : MonoBehaviour {

        public static GameControl control;

        public static bool dead = true;                 //to set Player to dead/alive 
        public static bool gameActive = false;          //if a game is ongoing
        public static int currentLevel = 0;             //current active level
        public static float moveSpeed = 0;              //movespeed of your character


        //Keep Game Manager active and destroy any additional copys
        private void Awake()
        {
            if (control == null)
            {
                DontDestroyOnLoad(gameObject);
                control = this;
            }
            else if (control != this)
            {
                Destroy(gameObject);
            }
        }

        //Start Game
        private void Start()
        {
            SceneManager.LoadSceneAsync("MainMenu");
        }
    }
}
