using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public Transform rightHand;
    public Transform handMeetingArea;

    private Guest currentGuest;

    private float handshakeTimer = 0.0f;

    private void Update()
    {
        if (currentGuest != null)
        {
            Handshake();

            if (handshakeTimer >= 1.0f)
            {
                StartCoroutine(currentGuest.AfterHandshake());
                currentGuest = null;
                handshakeTimer = 0.0f;
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

    private void Handshake()
    {
        if ((rightHand.position - currentGuest.handTransform.position).sqrMagnitude > 0.01f) return;


        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.1f)
        {
            currentGuest.ik.pressanKasi = rightHand;

            handshakeTimer += Time.deltaTime;
        }
        else
        {
            currentGuest.ik.pressanKasi = handMeetingArea;
        }

    }
}
