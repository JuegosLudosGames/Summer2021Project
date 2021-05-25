using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace summer2021.csharp.game.character
{
    //Added by Kyle | May 25, 2021
    public class PlayableCharacter : ScriptableObject
    {
        [SerializeField] private byte charId;
        [SerializeField] private Sprite ImageSprite;
        [SerializeField] private GameObject PlayerPrefab;
    }
}