using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    [System.Serializable]
    public class Dialogue
    {
        public Sprite picture;
        public string name;
        [TextArea(3,10)] public string[] sentences;

    }
}
