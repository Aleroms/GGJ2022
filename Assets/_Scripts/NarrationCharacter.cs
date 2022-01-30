using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Scriptable Objects/Narration/Character")]
public class NarrationCharacter : ScriptableObject
{
    [SerializeField] private string characterName;
    [SerializeField] private Texture2D characterPortrait;
    private Image characterPortraitImage;

    public string CharacterName => characterName;

    public Texture2D CharacterPortrait => characterPortrait;
}
