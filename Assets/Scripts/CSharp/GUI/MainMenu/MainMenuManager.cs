using System.Collections;
using System.Collections.Generic;
using System;
using System.Net;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using summer2021.csharp.networking;
using TMPro;

namespace summer2021.csharp.gui.mainMenu
{
    public class MainMenuManager : MonoBehaviour
    {

        public static Regex IPV6_FORMAT = new Regex("((([0-9a-fA-F]){1,4})\\:){7}([0-9a-fA-F]){1,4}");

        [SerializeField] private GameObject[] Menus;

        // Input Fields
        [SerializeField] private TMP_InputField portInput;
        [SerializeField] private TMP_InputField ipInput;

        // UI Text
        [SerializeField] private TMP_Text ipText;

        //game object reference
        [SerializeField] private GameObject parentForListings;

        private int currentMenu = 0;
        private ushort port = 7777;
        private string publicIp = "";

        private NetworkManagerLobby networkManager;

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

        }

        public void quitLobby() {

        }

        public void startLobby() {
            
        }

        public void quitApp() {
            Application.Quit();
        }

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

        public static bool isValidIpv6(string ip) {
            return IPV6_FORMAT.IsMatch(ip);
        }
    }
}