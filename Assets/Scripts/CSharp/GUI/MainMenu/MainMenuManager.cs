using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using summer2021.csharp.networking;
using TMPro;

namespace summer2021.csharp.gui.mainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] Menus;

        // Input Fields
        [SerializeField] private TMP_InputField portInput;
        [SerializeField] private TMP_InputField ipInput;

        // UI Text
        [SerializeField] private TMP_Text ipText;

        private int currentMenu = 0;
        private ushort port = 7777;

        private void Start() {
            foreach(GameObject g in Menus) {
                g.SetActive(false);
            
            }
            Menus[0].SetActive(true);
        }

        public void setMenu(int index) {
            Menus[currentMenu].SetActive(false);
            currentMenu = index;
            Menus[currentMenu].SetActive(true);
        }

        // Updated by John | May 24, 2021
        public void ValidateIPBeforeHosting()
        {

            NetworkManagerLobby networkManager = (NetworkManagerLobby.singleton as NetworkManagerLobby);

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

        public void joinGame() {

        }

        // Updated by John | May 24, 2021
        public void hostGame() {

            NetworkManagerLobby networkManager = (NetworkManagerLobby.singleton as NetworkManagerLobby);

            if (!ushort.TryParse(portInput.text, out port))
            {

                Debug.LogError("Bad port input");

            }
            else
            {

                networkManager.Tele.port = port;

            }


        }

        public void quitLobby() {

        }

        public void startLobby() {
            
        }

        public void quitApp() {
            Application.Quit();
        }
    }
}