using UnityEngine;
using UnityEngine.UI;

public class WorldColorMatchUI : MonoBehaviour
{
    public Image img;

    private void Start()
    {
        // Player updates with each new scene load in Awake prior to this
        img.color = Player.worldBackgroundColor;
    }
}