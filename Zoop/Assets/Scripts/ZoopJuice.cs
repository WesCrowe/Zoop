using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoopJuice : MonoBehaviour
{
    public GameObject[] zoops;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerArmature");

        zoops = new GameObject[3];
        zoops[0] = this.gameObject.transform.GetChild(0).gameObject;
        zoops[1] = this.gameObject.transform.GetChild(1).gameObject;
        zoops[2] = this.gameObject.transform.GetChild(2).gameObject;

        zoops[0].GetComponent<Image>().color = Color.green;
        zoops[1].GetComponent<Image>().color = Color.green;
        zoops[2].GetComponent<Image>().color = Color.green;

        zoops[1].SetActive(false);
        zoops[2].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerResources>().MaxZoops == 1)
        {
            zoops[0].SetActive(true);
        }
        else if (player.GetComponent<PlayerResources>().MaxZoops == 2)
        {
            zoops[1].SetActive(true);
        }
        else
        {
            zoops[2].SetActive(true);
        }

        
        int zoopsLeft = player.GetComponent<PlayerResources>().Zoops;
        int maxZoops = player.GetComponent<PlayerResources>().MaxZoops;
        for (int z = zoopsLeft-1; z >= 0 ; z--)
        {
            zoops[z].GetComponent<Image>().color = Color.green;
        }

        if (zoopsLeft < maxZoops)
        {
            for (int h = zoopsLeft; h < maxZoops; h++)
            {
                zoops[h].GetComponent<Image>().color = Color.red;
            }
        }
    }
}
