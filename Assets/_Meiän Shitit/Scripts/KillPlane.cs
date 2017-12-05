using UnityEngine;
using System.Collections;

public class KillPlane : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
