using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    public GameObject explosionPrefab;
    public bool isDefused;

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
        isDefused = true;
    }

    public void BlowUp()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }
}
