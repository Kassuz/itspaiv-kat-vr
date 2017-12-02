using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestManager : MonoBehaviour
{
    public static GuestManager instance;

    public bool CanMove { get; set; }

    public GameObject guestPrefab;
    public Transform guestSpawnLocation;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        CanMove = true;
    }

    public void SpawnGuest()
    {
        Instantiate(guestPrefab, guestSpawnLocation.position, guestSpawnLocation.rotation);
    }
}
