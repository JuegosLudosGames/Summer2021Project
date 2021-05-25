using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

// Updated by John | May 24, 2021
namespace summer2021.csharp.networking{

    public class NetworkManagerLobby : NetworkManager
    {

        [Header("Scene Data")]
        [SerializeField] private string menuSceneName;

        [Header("Reference Data")]
        [SerializeField] private TelepathyTransport tele;
        [HideInInspector] public GameObject parentForListings;

        [Header("Prefabs")]
        [SerializeField] private GameObject playerListingPrefab;

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

        // Added by Kyle | May 25, 2021
        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            //full override, do not use base
            if(SceneManager.GetActiveScene().name.Equals(menuSceneName)) {

                //Instantiate Base object (details prefab)
                GameObject baseInstance = Instantiate(playerPrefab); 

                NetworkServer.AddPlayerForConnection(conn, baseInstance);

                //Add Listing object
                GameObject listing = Instantiate(playerListingPrefab, parentForListings.transform);

                NetworkServer.Spawn(listing, baseInstance);
            }
        }

    }

}
