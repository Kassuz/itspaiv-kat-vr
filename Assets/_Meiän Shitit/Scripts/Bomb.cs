using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    public GameObject explosionPrefab;
    public bool isDefused;

    private Rigidbody rb;
    private MeshRenderer mesh;
    private LineRenderer lr;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshRenderer>();
        lr = GetComponent<LineRenderer>();
        
        
    }

    private void Update()
    {
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.parent.position);
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
