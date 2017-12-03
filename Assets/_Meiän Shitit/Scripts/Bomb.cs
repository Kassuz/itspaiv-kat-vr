using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    private Rigidbody rb;
    private MeshRenderer mesh;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshRenderer>();
    }

    private void FixedUpdate()
    {
        //rb.MovePosition(rb.position + Vector3.right * Time.deltaTime);
    }

    private void OnJointBreak()
    {
        mesh.material.color = Color.red;
    }
}
