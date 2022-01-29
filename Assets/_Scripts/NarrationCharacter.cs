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

    public void FooBar() 
    {
        Sprite sprite = Sprite.Create(characterPortrait, new Rect(0.0f, 0.0f, characterPortrait.width,characterPortrait.height), new Vector2(0.5f, 0.5f), 100.0f);
        characterPortraitImage.sprite = sprite;
    }
}
