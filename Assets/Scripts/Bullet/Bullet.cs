using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;

    public float speed = 10f;

    public GameObject particle;
    public float Damage;
    public void Seek(Transform target)
    {
        this.target = target;
    }
    public void Launch(Transform firePoint, Transform target)
    {
        transform.position = firePoint.position;
        this.target = target;
    }
    private void Update()
    {
        if (target == null)
        {
            gameObject.SetActive(false);
            return;
        }

        Vector3 direction = target.transform.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //Instantiate(impactParticle, transform.position, transform.rotation);
            other.GetComponent<EnemyHealth>().TakeDamage(Damage);
            gameObject.SetActive(false);
        }
    }
}
