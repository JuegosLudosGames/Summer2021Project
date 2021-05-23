using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace summer2021.csharp.gui.mainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] Menus;
        private int currentMenu = 0;

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

        public void hostGame() {

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