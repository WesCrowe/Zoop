using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoopUp : MonoBehaviour
{

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerArmature");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerResources>().MaxZoops++;
            this.gameObject.SetActive(false);
        }
    }
}
