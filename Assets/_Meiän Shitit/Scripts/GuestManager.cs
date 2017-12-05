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

    public GameObject startPanel;
    private bool gameStarted;

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

    private void Update()
    {
        if (!gameStarted && OVRInput.Get(OVRInput.Button.One))
        {
            StartCoroutine(SpawnFirstGuests());
            gameStarted = true;
            startPanel.SetActive(false);
        }
    }

    private IEnumerator SpawnFirstGuests()
    {
        for (int i = 0; i < 11; i++)
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
