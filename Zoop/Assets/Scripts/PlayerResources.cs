using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    public float HP;
    public int Zoops;
    public int MaxZoops;
    public bool recharging;
    public StatBar bar;

    public Transform respawn;

    void Start()
    {
        HP = 100f;
        Zoops = 1;
        MaxZoops = 1;
        recharging = false;
        bar = GameObject.Find("HP").GetComponent<StatBar>();

        respawn = GameObject.Find("Respawn").transform;
    }

    void Update()
    {
        bar.SetVal(HP);

        if (Zoops < MaxZoops && !recharging)
        {
            StartCoroutine(Recharge());
        }

        if (Input.GetKeyDown("e") && Zoops > 0)
        {
            Zoops--;
        }

        if (HP <= 0)
        {
            this.gameObject.transform.position = respawn.position;
            HP = 50f;
        }
    }

    IEnumerator Recharge()
    {
        recharging = true;
        yield return new WaitForSeconds(1.0f);
        Zoops++;
        recharging = false;
    }
}
