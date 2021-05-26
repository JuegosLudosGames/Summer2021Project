using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using summer2021.csharp.game.character;

namespace summer2021.csharp.gui.mainMenu
{
    //Added by Kyle | May 25, 2021
    [ExecuteAlways]
    public class CharacterListing : MonoBehaviour
    {
        public PlayableCharacter character;

        [Header("References")]
        [SerializeField] public Image displaySprite;

        private void Start() {
            if(character != null && displaySprite != null) {
                displaySprite.sprite = character.GetImageSprite();
            }
        }
    }
}