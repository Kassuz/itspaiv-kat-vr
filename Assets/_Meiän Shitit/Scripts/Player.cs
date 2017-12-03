using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public AudioClip[] hyvaaItsPaivaa;
    public AudioClip[] vauhtiaAanet;
    public AudioClip[] introduction;

    public AudioSource generalAudio;

    public Transform rightHand;
    public Transform handMeetingArea;

    private Guest currentGuest;
    
    private float handshakeTimer = 0.0f;
    private float irritationTimer = 0.0f;

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
            if (!generalAudio.isPlaying)
                generalAudio.PlayOneShot(introduction[Random.Range(0, introduction.Length)], 0.5f);

            irritationTimer = 0.0f;
            currentGuest = other.GetComponent<Guest>();
            currentGuest.greetLine = Random.Range(0, hyvaaItsPaivaa.Length);
            currentGuest.hurryLine = Random.Range(0, vauhtiaAanet.Length);
        }
    }

    

    private void Handshake()
    {
        irritationTimer += Time.deltaTime;
        if (irritationTimer >= 6.0f)
        {
            irritationTimer = 0.0f;
            currentGuest.audio.PlayOneShot(vauhtiaAanet[currentGuest.hurryLine]);
        }


        if ((rightHand.position - currentGuest.handTransform.position).sqrMagnitude > 0.01f) return;


        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.1f)
        {
            currentGuest.ik.pressanKasi = rightHand;

            if (!currentGuest.HasGreeted)
            {
                currentGuest.audio.Stop();
                currentGuest.audio.PlayOneShot(hyvaaItsPaivaa[currentGuest.greetLine]);
                currentGuest.HasGreeted = true;
            }

            handshakeTimer += Time.deltaTime;
        }
        else
        {
            currentGuest.ik.pressanKasi = handMeetingArea;
        }

    }
}
