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

        public override void OnStartClient()
        {
            this.gameObject.transform.SetParent(networkManager.parentForListings.transform);
            this.gameObject.transform.localScale = Vector3.one;
        }
    }
}