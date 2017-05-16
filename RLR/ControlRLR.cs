﻿using Assets.Scripts.Launcher;
using UnityEngine;

namespace Assets.Scripts.RLR
{
    public class ControlRLR : MonoBehaviour
    {
        public LevelManagerRLR LevelManager;
        public InitializeGameRLR InitializeGameRLR;
        public DeathRLR DeathRLR;
        public GameObject PracticeMode;

        public bool StopUpdate;

        void Start()
        {
            // Set current Level and movespeed, load drones and spawn immunity
            StopUpdate = true;
            GameControl.State.GameActive = true;
            GameControl.State.MoveSpeed = 13;
            if (GameControl.State.SetGameMode == Gamemode.Practice)
            {
                PracticeMode.SetActive(true);
            }

            InitializeGameRLR.InitializeGame();
        }

        //update when dead
        private void Update()
        {
            if (GameControl.State.IsDead && !StopUpdate)
            {
                StopUpdate = true;
                DeathRLR.Death(LevelManager, InitializeGameRLR, this);
            }

            if (GameControl.State.FinishedLevel && !StopUpdate)
            {
                LevelManager.EndLevel(0f);
            }

            // Press Ctrl to start autoclicking
            if (GameControl.InputManager.GetButtonDown(HotkeyAction.ActivateClicker))
            {
                if (!GameControl.State.AutoClickerActive)
                    GameControl.State.AutoClickerActive = true;
            }

            // Press Alt to stop autoclicking
            if (GameControl.InputManager.GetButtonDown(HotkeyAction.DeactivateClicker))
            {
                if (GameControl.State.AutoClickerActive)
                    GameControl.State.AutoClickerActive = false;
            }

            // Press 1 to be invulnerable
            if (GameControl.InputManager.GetButtonDown(HotkeyAction.ActivateGodmode) && !GameControl.State.GodModeActive)
            {
                GameControl.State.GodModeActive = true;
                if (GameControl.State.Player != null)
                {
                    GameControl.State.Player.transform.Find("GodMode").gameObject.SetActive(true);
                }
            }

            // Press 2 to be vulnerable
            if (GameControl.InputManager.GetButtonDown(HotkeyAction.DeactiveGodmode) && GameControl.State.GodModeActive)
            {
                GameControl.State.GodModeActive = false;
                if (GameControl.State.Player != null)
                {
                    GameControl.State.Player.transform.Find("GodMode").gameObject.SetActive(false);
                }
            }
        }
    }
}

