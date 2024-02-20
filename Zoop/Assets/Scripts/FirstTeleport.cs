using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTeleport : MonoBehaviour
{

    public GameObject destination;

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown("e"))
            {
                other.gameObject.transform.position = destination.transform.position;
            }
        }
    }
}
