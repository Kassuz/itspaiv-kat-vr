using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guest : MonoBehaviour
{
    public Transform handTransform;

    [HideInInspector] public IKThingy ik;

    [SerializeField] private float speed;

    private Rigidbody rb;
    private Bomb bomb;

    private bool hasShookHand;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ik = GetComponentInChildren<IKThingy>();
        bomb = GetComponentInChildren<Bomb>();
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
