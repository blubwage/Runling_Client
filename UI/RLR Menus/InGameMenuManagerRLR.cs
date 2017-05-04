﻿using Assets.Scripts.RLR;
using Assets.Scripts.Launcher;
using Assets.Scripts.UI.RLR_Menu;
using UnityEngine;

namespace Assets.Scripts.UI.RLR_Menus
{
    public class InGameMenuManagerRLR : MonoBehaviour
    {
        public InGameMenuRLR InGameMenu;
        public ControlRLR ControlRLR;
        public OptionsMenu.OptionsMenu OptionsMenu;

        public GameObject InGameMenuObject;
        public GameObject OptionsMenuObject;
        public GameObject WinScreen;
        public GameObject PauseScreen;

        public bool MenuOn;
        private bool _pause;

        private void Awake()
        {
            MenuOn = false;
            OptionsMenu.OptionsMenuActive = false;
            _pause = false;
        }

        public void CloseMenus()
        {
            InGameMenuObject.SetActive(false);
            OptionsMenuObject.SetActive(false);
        }

        void Update()
        {
            // Navigate menu with esc
            if (InputManager.Instance.GetButtonDown(HotkeyAction.NavigateMenu))
            {
                if (!MenuOn && !WinScreen.gameObject.activeSelf)
                {
                    InGameMenuObject.SetActive(true);
                    Time.timeScale = 0;
                    MenuOn = true;
                }
                else if (MenuOn && OptionsMenu.OptionsMenuActive)
                {
                    OptionsMenu.DiscardChanges();
                }
                else
                {
                    InGameMenu.BackToGame();
                }
            }

            //pause game
            if (InputManager.Instance.GetButtonDown(HotkeyAction.Pause))
            {
                if (!_pause)
                {
                    Time.timeScale = 0;
                    _pause = true;
                    PauseScreen.SetActive(true);
                }
                else if (_pause)
                {
                    Time.timeScale = 1;
                    _pause = false;
                    PauseScreen.SetActive(false);
                }
            }
        }
    }
}