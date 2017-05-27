﻿using System;
using Launcher;
using Players.Camera;
using UnityEngine;

namespace UI.OptionsMenu
{
    public class OptionsMenu : MonoBehaviour
    {

        public GameObject Menu;
        public SetHotkeys SetHotkeys;
        public SetCamera SetCamera;
        public CameraHandleMovement CameraHandleMovement;
        public CameraMovement CameraMovement;

        public GameObject GeneralHotkeysSubmenu;
        public GameObject CameraSubmenu;
        public GameObject GraphicsSubmenu;

        public bool OptionsMenuActive;

        public void DiscardChanges()
        {
            SubmenuBuilder.DeleteHotkeyPrefabs(SetCamera.HotkeyList); 
            SubmenuBuilder.DeleteHotkeyPrefabs(SetHotkeys.HotkeyList);
            GameControl.InputManager.LoadHotkeys();
            var watchedPoint = CameraHandleMovement.GetWatchedPoint();
            GameControl.Settings.LoadSettings();
            CameraHandleMovement.SetCameraHandlePosition(watchedPoint);
            CameraMovement.SetCameraPitch(GameControl.Settings.CameraAngle.Val);
            
            

            OptionsMenuActive = false;
            gameObject.SetActive(false);
            Menu.gameObject.SetActive(true);
        }

        public void SaveChanges()
        {
            foreach (HotkeyAction action in Enum.GetValues(typeof(HotkeyAction)))
            {
                var kc = GameControl.InputManager.GetHotkey(action);
                if (kc != null)
                    PlayerPrefs.SetInt(action.ToString(), (int)kc);
            }
            SetCamera.SaveCameraOptions();

            OptionsMenuActive = false;
            gameObject.SetActive(false);
            Menu.gameObject.SetActive(true);
        }

        public void GeneralHotkeysToggle()
        {
            GeneralHotkeysSubmenu.SetActive(true);
            CameraSubmenu.SetActive(false);
            GraphicsSubmenu.SetActive(false);
        }

        public void CameraToggle()
        {
            GeneralHotkeysSubmenu.SetActive(false);
            CameraSubmenu.SetActive(true);
            GraphicsSubmenu.SetActive(false);
        }

        public void GraphicsToggle()
        {
            GeneralHotkeysSubmenu.SetActive(false);
            CameraSubmenu.SetActive(false);
            GraphicsSubmenu.SetActive(true);
        }

    }
}
