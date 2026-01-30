using UnityEngine;

public class Rotator : MonoBehaviour
{
    public bool rotateClockwise;

    private bool cooldown; // It's very easy for the player to trigger it twice near instantly
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (!cooldown && col.CompareTag("Player"))
        {
            col.GetComponent<Player>().Rotator(rotateClockwise);
            cooldown = true;
            Invoke(nameof(EndCooldown), 1);
        }
    }
    private void EndCooldown()
    {
        cooldown = false;
    }
}