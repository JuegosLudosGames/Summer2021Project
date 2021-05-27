using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace summer2021.csharp.game.character
{
    //Added by Kyle | May 25, 2021
    [CreateAssetMenu(fileName="PlayableCharacter", menuName="PlayableCharacter")]
    public class PlayableCharacter : ScriptableObject
    {
        [SerializeField] private byte CharId;
        [SerializeField] private Sprite ImageSprite;
        [SerializeField] private GameObject PlayerPrefab;

        public byte GetCharId() { return CharId; }
        public Sprite GetImageSprite() { return ImageSprite; }
        public GameObject GetPlayerPrefab() { return PlayerPrefab; }

    }
}