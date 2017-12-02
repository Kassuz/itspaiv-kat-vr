using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private Guest currentGuest;

    private void Update()
    {
        if (currentGuest != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentGuest.hasShookHand = true;
                currentGuest = null;
                GuestManager.instance.SpawnGuest();
                GuestManager.instance.CanMove = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Guest")
        {
            Debug.Log("New guest has appeared!");
            currentGuest = other.GetComponent<Guest>();
        }
    }
}
