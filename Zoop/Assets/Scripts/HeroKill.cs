using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroKill : MonoBehaviour
{

    public GameObject[] hero = new GameObject[3];
    public GameObject win;

    // Start is called before the first frame update
    void Start()
    {
        //win = GameObject.Find("Win");
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown("e"))
            {
                if (other.gameObject.GetComponent<PlayerResources>().Zoops > 0)
                {
                    foreach (GameObject part in hero)
                    {
                        part.SetActive(false);
                    }
                    StartCoroutine(ender());
                    win.SetActive(true);
                }
            }
        }
    }

    IEnumerator ender()
    {
        yield return new WaitForSeconds(5);
        Application.Quit();
    }
}
