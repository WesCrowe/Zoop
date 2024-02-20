using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallZone : MonoBehaviour
{
    public Transform respawn;

    void Start()
    {
        respawn = GameObject.Find("Respawn").transform;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = respawn.position;
        }
    }
}
