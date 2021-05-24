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
        [SerializeField] private TMP_InputField portInput;
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

        public void joinGame() {

        }

        // Updated by John | May 24, 2021
        public void hostGame() {

            if (!ushort.TryParse(portInput.text, out port))
            {

                Debug.Log("Bad port input");

            }
            else
            {

                (NetworkManagerLobby.singleton as NetworkManagerLobby).Tele.port = port;

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