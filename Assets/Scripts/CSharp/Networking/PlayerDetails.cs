using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using summer2021.csharp.gui.mainMenu;
using TMPro;

// Updated by John | May 24, 2021
namespace summer2021.csharp.networking
{

    public class PlayerDetails : NetworkBehaviour
    {

        // Added by John | May 25, 2021
        [SyncVar(hook=nameof(HandleNameChange))] public string username = string.Empty;
        [SyncVar(hook=nameof(HandleCharacterChange))] public byte character = 0;
        [SyncVar(hook=nameof(HandleReadyChange))] public bool readied = false;

        [SyncVar] public byte idNum = 0;

        public bool isHost = false;

        public PlayerListing lobbyListing;

        private NetworkManagerLobby _manager;
        private NetworkManagerLobby manager {
            get {
                if(_manager != null) {
                    return _manager;
                } else {
                    return _manager = NetworkManager.singleton as NetworkManagerLobby;
                }
            }
        }

        // Added by Kyle | May 27, 2021
        public override void OnStartAuthority()
        {
            NetworkManagerLobby.ClientAuthOnject = this;
        }

        // Added by Kyle | May 27, 2021
        public override void OnStartClient()
        {
            DontDestroyOnLoad(gameObject);
            if(!manager.playerDetailsListing.ContainsKey(idNum))
                manager.playerDetailsListing.Add(idNum, this);

            if(isHost)
                Debug.Log("I am host");
        }

        // Added by Kyle | May 27, 2021
        public override void OnStartServer()
        {
            DontDestroyOnLoad(gameObject);
            if(!manager.playerDetailsListing.ContainsKey(idNum))
                manager.playerDetailsListing.Add(idNum, this);
        }

        //Commands
        // Added by Kyle | May 27, 2021
        [Command]
        public void CmdChangecharacter(byte characterid) {
            character = characterid;
        }

        // Added by Kyle | May 27, 2021
        [Command]
        public void CmdChangeReadyState(bool state) {
            readied = state;
        }

        //Handlers
        // Added by John | May 25, 2021
        public void HandleNameChange(string oldName, string newName)
        {
            lobbyListing.NameText.text = newName;
        }

        // Added by John | May 25, 2021
        public void HandleCharacterChange(byte oldCharacter, byte newCharacter)
        {
            lobbyListing.CharacterText.text = newCharacter.ToString();
        }

        // Added by Kyle | May 27, 2021
        public void HandleReadyChange(bool oldState, bool newState) {
            lobbyListing.isReady = newState;
        } 

    }

}

