using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guest : MonoBehaviour
{
    public AudioClip[] randomChatter;


    public Transform handTransform;
    public bool HasGreeted { get; set; }

    [HideInInspector] public IKThingy ik;
    [HideInInspector] public int greetLine;
    [HideInInspector] public int hurryLine;

    [SerializeField] private float speed;

    private Rigidbody rb;
    [HideInInspector] public AudioSource audio;
    private Bomb bomb;

    private bool hasShookHand;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        ik = GetComponentInChildren<IKThingy>();
        bomb = GetComponentInChildren<Bomb>();
    }

    private void Update()
    {
        if (ik.kattely) return;


        if (Random.value < 0.005f && !audio.isPlaying)
        {
            audio.PlayOneShot(randomChatter[Random.Range(0, randomChatter.Length)], 0.5f);
        }
    }
  
    private void FixedUpdate()
    {
        if (GuestManager.instance.CanMove || hasShookHand)
            rb.MovePosition(rb.position + transform.forward * speed * Time.deltaTime);
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        Debug.Log("Kättely!");

        GuestManager.instance.CanMove = false;
        yield return Rotate(-90.0f);
        ik.kattely = true;
    }

    public IEnumerator AfterHandshake()
    {
        ik.kattely = false;

        yield return Rotate(90.0f);

        if (bomb != null && !bomb.isDefused)
        {
            bomb.BlowUp();
            Debug.Log("Boooooooooooooooooooooooooooooooooooooooooooooom!");
        }

        hasShookHand = true;
        GuestManager.instance.CanMove = true;
        GuestManager.instance.SpawnGuest();
    }

    public IEnumerator Rotate(float degrees)
    {
        
        Quaternion oldRot = rb.rotation;
        Quaternion newRot = oldRot * Quaternion.AngleAxis(degrees, transform.up);

        float t = 0;

        while (t <= 1.0f)
        {
            rb.MoveRotation(Quaternion.Slerp(oldRot, newRot, t));
            t += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
}
