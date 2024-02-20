using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public static Transform[] telelist;
    public static bool first = true;
    public Transform destination;

    // Start is called before the first frame update
    void Start()
    {

        if (first)
        {
            //stop other objects from performing this
            first = false;

            //initialize the list of teleporters
            telelist = new Transform[GameObject.Find("Teleporters").transform.childCount];
            
            //put all teleporters into the list
            for (int n=0; n<telelist.Length; n++)
            {
                telelist[n] = GameObject.Find("Teleporters").transform.GetChild(n);
            }

            //randomize the array of teleporters
            //Knuth shuffle algorithm courtesy of Wikipedia
            for (int t = 0; t < telelist.Length; t++)
            {
                Transform tmp = telelist[t];
                int r = Random.Range(t, telelist.Length);
                telelist[t] = telelist[r];
                telelist[r] = tmp;
            }

            //assign the destinations
            for (int i=0; i < telelist.Length; i+=2)
            {

                //account for out of bounds
                if (i + 1 >= telelist.Length)
                {
                    telelist[i].GetComponent<Teleport>().destination = telelist[0];
                    telelist[0].GetComponent<Teleport>().destination = telelist[i];
                }
                else if (i+2 > telelist.Length)
                {
                    telelist[i+1].GetComponent<Teleport>().destination = telelist[0];
                    telelist[0].GetComponent<Teleport>().destination = telelist[i+1];
                }
                else
                {
                    telelist[i].GetComponent<Teleport>().destination = telelist[i + 1];
                    telelist[i+1].GetComponent<Teleport>().destination = telelist[i];
                }
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown("e"))
            {

                if (other.gameObject.GetComponent<PlayerResources>().Zoops > 0)
                {
                    other.gameObject.transform.position = destination.position;
                }
                else
                {
                    print("Teleportation Fail");
                }
            }
        }
    }
}
