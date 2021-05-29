using System.Collections;
using System.Collections.Generic;
using System;
using System.Net;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using summer2021.csharp.networking;
using TMPro;
using Mirror;

namespace summer2021.csharp.gui.mainMenu
{
    public class MainMenuManager : MonoBehaviour
    {

        public static Regex IPV6_FORMAT = new Regex("((([0-9a-fA-F]){1,4})\\:){7}([0-9a-fA-F]){1,4}");
        public static MainMenuManager singleton;

        [SerializeField] private GameObject[] Menus;

        // Input Fields
        [SerializeField] private TMP_InputField portInput;
        [SerializeField] private TMP_InputField ipInput;

        // UI Text
        [SerializeField] private TMP_Text ipText;

        //game object reference
        [SerializeField] private GameObject parentForListings;

        [Header("Lobby Menu Reference")]
        [SerializeField] private int lobbyMenuIndex = 3;
        [SerializeField] private GameObject HostPanel;
        [SerializeField] private Button StartButton;
        [SerializeField] private TMP_Text StartButton_Text;
        [SerializeField] private TMP_Text ReadyButton_Text;

        private int currentMenu = 0;
        private ushort port = 7777;
        private string publicIp = "";
        private MapListing selectedScene;

        private NetworkManagerLobby networkManager;

        // Added by Kyle May 27, 2021
        private void Awake() {
            if(singleton == null)
                singleton = this;
        }

        // Added by Kyle May 27, 2021
        private void OnDestroy() {
            if(this == singleton) {
                singleton = null;
            }
        }

        // Updated by Kyle | May 25, 2021
        private void Start() {

            networkManager = (NetworkManagerLobby.singleton as NetworkManagerLobby);

            foreach(GameObject g in Menus) {
                g.SetActive(false);
            
            }
            Menus[0].SetActive(true);

            //grab public ip
            string[] webstring = new WebClient().DownloadString("http://ip4only.me/api/").Trim().Split(',');
            publicIp = webstring[1];
            ipText.text = publicIp;

            //set references in network Manager
            networkManager.parentForListings = parentForListings;
        }

        public void setMenu(int index) {
            Menus[currentMenu].SetActive(false);
            currentMenu = index;
            Menus[currentMenu].SetActive(true);
        }

        // Updated by John | May 24, 2021
        // Made Obsolete by Kyle | May 25, 2021
        [Obsolete("Not needed")]
        public void ValidateIPBeforeHosting()
        {

            if (string.IsNullOrEmpty(ipInput.text))
            {

                Debug.LogError("IP field is required");

            }
            else
            {

                networkManager.networkAddress = ipInput.text;
                ipText.text = ipInput.text;
                setMenu(2);

            }

        }

        // Updated by Kyle | May 25, 2021
        public void joinGame() {
            string[] segments = ipInput.text.Trim().Split(':');

            //validate ip
            if(!(isValidIpv4(segments[0]) || isValidIpv6(segments[0]) || segments[0].Equals("localhost"))) {
                Debug.LogError("Invalid IP " + segments[0]);
                return;
            }

            //validate port
            if(!ushort.TryParse(segments[1], out port)) {
                Debug.LogError("Invalid Port " + segments[1]);
                return;
            }

            networkManager.networkAddress = segments[0];
            networkManager.Tele.port = port;

            networkManager.StartClient();
            setMenu(3);
            updateLobby();
        }

        // Updated by John | May 24, 2021
        // Updated by Kyle | May 25, 2021
        public void hostGame() {
            
            if (!ushort.TryParse(portInput.text, out port))
            {
                Debug.LogError("Bad port input");
                return;
            }
            else
            {
                networkManager.Tele.port = port;
            }

            networkManager.networkAddress = "localhost";
            networkManager.StartHost();
            setMenu(3);
            updateLobby();
        }

        // Added by Kyle | May 27,2021
        public void ready() {
            PlayerDetails authPlayer = NetworkManagerLobby.ClientAuthOnject;

            authPlayer.CmdChangeReadyState(!authPlayer.readied);
        }

        public void quitLobby() {

        }

        public void startLobby() {
            PlayerDetails details = NetworkManagerLobby.ClientAuthOnject;
            if(details.isHost) {
                details.CmdStartGame(selectedScene.SceneName);
            }
        }

        public void quitApp() {
            Application.Quit();
        }

        //selected character
        private CharacterListing selected = null;
        private Image selectedChar = null;

        // Updated by Kyle | May 27, 2021
        public void selectCharacter(CharacterListing listing) {
            NetworkManagerLobby.ClientAuthOnject.CmdChangecharacter(listing.character.GetCharId());
        }

        // Added by Kyle | May 27, 2021
        public void selectMap(MapListing listing) {
            
            selectedScene.gameObject.GetComponent<Image>().color = Color.white;
            selectedScene = listing;
            selectedScene.gameObject.GetComponent<Image>().color = Color.yellow;

        }

        // Added by Kyle | May 27, 2021
        // Updated by Kyle | May 29, 2021
        public void updateLobby() {
            bool host = NetworkManagerLobby.ClientAuthOnject.isHost;
            bool lobbyAllReady = true;

            //Ready button status
            ReadyButton_Text.text = NetworkManagerLobby.ClientAuthOnject.readied? "UnReady" : "Ready";

            //check if all ready
            PlayerDetails[] players = (NetworkManager.singleton as NetworkManagerLobby).playerDetailsListing.Values.ToArray();
            foreach(PlayerDetails p in players) {
                if(!p.readied) {
                    lobbyAllReady = false;
                    break;
                }
            }

            StartButton.enabled = host && lobbyAllReady;

            if(host) {
                if(lobbyAllReady) {
                    StartButton_Text.text = "Start Game";
                } else {
                    StartButton_Text.text = "Waiting for Players";
                }
            } else {
                StartButton_Text.text = "Waiting for host";
            }

            HostPanel.SetActive(host);
        }

        // Updated by Kyle | May 27, 2021
        public void setCharHighlight(Image obj) {
            if(selectedChar != null)
                selectedChar.color = Color.white;
            selectedChar = obj;
            selectedChar.color = Color.yellow;
        }

        // Updated by Kyle | May 25, 2021
        public static bool isValidIpv4(string ip) {
            if(String.IsNullOrWhiteSpace(ip)) {
                return false;
            }

            //check number of segments
            string[] splitVals = ip.Split('.');
            if(splitVals.Length != 4) {
                return false;
            }

            byte parseCheck;
            return splitVals.All(r => byte.TryParse(r, out parseCheck));
        }

        // Updated by Kyle | May 25, 2021
        public static bool isValidIpv6(string ip) {
            return IPV6_FORMAT.IsMatch(ip);
        }
    }
}