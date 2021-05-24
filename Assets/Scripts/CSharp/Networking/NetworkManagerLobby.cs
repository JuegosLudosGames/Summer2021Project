using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

// Updated by John | May 24, 2021
namespace summer2021.csharp.networking{

    public class NetworkManagerLobby : NetworkManager
    {

        [SerializeField] private TelepathyTransport tele;

        public TelepathyTransport Tele{

            get
            {
                return tele;
            }
            private set { tele = value; }

        }

        public override void Awake()
        {

            if(NetworkManager.singleton != null)
            {

                Destroy(gameObject);
                return;

            }

            base.Awake();

        }

    }

}
