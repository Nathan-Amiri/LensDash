using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<Player>().Bouncer(transform.up);
        }
    }
}