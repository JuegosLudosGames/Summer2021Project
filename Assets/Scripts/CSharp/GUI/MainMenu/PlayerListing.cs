using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

using summer2021.csharp.networking;

namespace summer2021.csharp.gui.mainMenu
{  
    //Added by Kyle | May 25 2021
    public class PlayerListing : NetworkBehaviour
    {
        //Added by John | May 25 2021
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text characterText;
        [SerializeField] private TMP_Text readyText;
        
        [SyncVar] public byte playerId = 0;

        //Added by Kyle | May 27, 2021
        private bool _isReady = false;
        public bool isReady {
            get {
                return _isReady;
            }
            set {
                _isReady = value;
                if(isReady) {
                    readyText.text = "Ready";
                } else {
                    readyText.text = "Not Ready";
                }
                MainMenuManager.singleton.updateLobby();
            }
        }

        public TMP_Text NameText
        {

            get
            {
                return nameText;
            }

            private set { }

        }

        public TMP_Text CharacterText
        {

            get
            {
                return characterText;
            }

            set { }

        }


        private NetworkManagerLobby _networkManager = null;
        private NetworkManagerLobby networkManager
        {
            get
            {
                if (_networkManager != null) return _networkManager;
                return _networkManager = NetworkManager.singleton as NetworkManagerLobby;
            }
        }

        // Updated by Kyle | May 29, 2021
        public override void OnStartClient()
        {
            this.gameObject.transform.SetParent(networkManager.parentForListings.transform);
            this.gameObject.transform.localScale = Vector3.one;

            //set owner player to itself
            networkManager.playerDetailsListing.TryGetValue(playerId, out PlayerDetails playerDetails);
            playerDetails.lobbyListing = this;

            //update main menu
            if(MainMenuManager.singleton != null) {
                MainMenuManager.singleton.updateLobby();
            }
        }
    }
}