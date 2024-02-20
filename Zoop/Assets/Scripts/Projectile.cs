using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;
    public float speed;
    public PlayerResources player;
    public GameObject splashEffect;
    private Vector3 dir;

    public void Seek(Transform newTarget)
    {
        target = newTarget;
        //targeting
        dir = target.position - transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            float distanceInFrame = speed * Time.deltaTime;
            transform.Translate(dir.normalized * distanceInFrame, Space.World);
            if(dir.magnitude <= distanceInFrame)
            {
                HitTarget();
                return;
            }
        }

    }

    private void HitTarget()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
        return;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Instantiate(splashEffect, transform.position, transform.rotation);
            player = other.gameObject.GetComponent<PlayerResources>();
            if (player.HP > 0)
            {
                player.HP -= 5f;
            }
            gameObject.SetActive(false);
            Destroy(gameObject);
            return;
        }
        else if (other.gameObject.tag == "barrier")
        {
            return;
        }

        //gameObject.SetActive(false);
        //Destroy(gameObject);
        return;

    }
}
