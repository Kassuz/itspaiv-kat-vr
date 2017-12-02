using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guest : MonoBehaviour
{
    public bool hasShookHand;

    [SerializeField] private float speed;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
  
    private void FixedUpdate()
    {
        if (GuestManager.instance.CanMove || hasShookHand)
            rb.MovePosition(rb.position + transform.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Kättely!");
        GuestManager.instance.CanMove = false;
    }
}
