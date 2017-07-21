﻿using System.IO;
using Characters.Types;
using Launcher;
using Players;
using UnityEngine;

namespace Characters
{
    public class PlayerFactory : MonoBehaviour
    {
        // class creates player gameobject in hierarchy
        // returns Player to GameControl.GameState.Player - // TODO maybe we should change names here?

        public Transform Player; // top position in hierarchy

        public GameObject ManticorePrefab;
        public GameObject UnicornPrefab;
        

        private PlayerFactory()
        {
        }

        public GameObject Create(CharacterDto character,  int? playerId = null)
        {
            switch (character.Character)
            {
                case "Manticore":
                {
                    var player = PhotonNetwork.Instantiate(Path.Combine("Characters", "Manticore"), Vector3.zero, Quaternion.identity, 0);
                    player.transform.SetParent(Player);
                    player.GetComponentInChildren<PlayerTrigger>().InitializeTrigger();
                    GameControl.PlayerState.CharacterController = player.AddComponent<Manticore>();
                    GameControl.PlayerState.CharacterController.Initialize(character);

                    return player;
                }
                case "Unicorn":
                {
                    var player = PhotonNetwork.Instantiate(Path.Combine("Characters", "Cat"), Vector3.zero, Quaternion.identity, 0);
                    player.transform.SetParent(Player);
                    GameControl.PlayerState.CharacterController = player.AddComponent<Unicorn>();
                    GameControl.PlayerState.CharacterController.Initialize(character);

                    return player;
                }
                default:
                {
                    Debug.Log("you want create non-existed character");
                    return null;
                }
            }
        }
    }
}