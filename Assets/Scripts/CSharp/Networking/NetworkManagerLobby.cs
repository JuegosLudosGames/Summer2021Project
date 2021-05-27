using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;
using summer2021.csharp.gui.mainMenu;

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

        // Added by Kyle May 27, 2021
        // note: This object is the playerdetails object that the current client has full authority of
        // and has static reference
        [HideInInspector] public static PlayerDetails ClientAuthOnject;

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

                baseInstance.GetComponent<PlayerDetails>().lobbyListing = listing.GetComponent<PlayerListing>();

                NetworkServer.Spawn(listing, baseInstance);
            }
        }

    }

}
