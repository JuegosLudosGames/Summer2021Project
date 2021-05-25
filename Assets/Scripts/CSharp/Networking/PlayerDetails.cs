using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using summer2021.csharp.gui.mainMenu;
using TMPro;

// Updated by John | May 24, 2021
namespace summer2021.csharp.networking
{

    public class PlayerDetails : NetworkBehaviour
    {

        // Added by John | May 25, 2021
        [SyncVar(hook=nameof(HandleNameChange))] public string username = string.Empty;
        [SyncVar(hook=nameof(HandleCharacterChange))] public byte character = 0;
        public PlayerListing lobbyListing;

        // Added by John | May 25, 2021
        public void HandleNameChange(string oldName, string newName)
        {

        
            lobbyListing.NameText.text = newName;

        }

        // Added by John | May 25, 2021
        public void HandleCharacterChange(byte oldCharacter, byte newCharacter)
        {

            lobbyListing.CharacterText.text = newCharacter.ToString();

        }

    }

}

