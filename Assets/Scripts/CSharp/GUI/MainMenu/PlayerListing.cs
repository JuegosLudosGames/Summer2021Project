using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

using summer2021.csharp.networking;

namespace summer2021.csharp.gui.mainMenu
{  
    //Added by Kyle | May 25 2021
    public class PlayerListing : NetworkBehaviour
    {

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