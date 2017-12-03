using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestManager : MonoBehaviour
{
    public static GuestManager instance;

    public bool CanMove { get; set; }

    public GameObject guestPrefab;
    public Transform guestSpawnLocation;
    public Transform playerHand;
    public Transform playerHead;

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

    private void Start()
    {
        StartCoroutine(SpawnFirstGuests());
    }

    private IEnumerator SpawnFirstGuests()
    {
        for (int i = 0; i < 12; i++)
        {
            SpawnGuest();
            yield return new WaitForSeconds(Random.Range(1.0f, 1.25f));
        }
    }

    public void SpawnGuest()
    {
        IKThingy i = Instantiate(guestPrefab, guestSpawnLocation.position, guestSpawnLocation.rotation).GetComponentInChildren<IKThingy>();
        i.pressanKasi = playerHand;
        i.pressanPaa = playerHead;
    }
}
