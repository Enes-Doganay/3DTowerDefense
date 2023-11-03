using UnityEngine;

public class BulletLauncher : MonoBehaviour, ILauncher
{
    public Bullet bullet;
    private ObjectPool bulletPool;

    private void Start()
    {
        bulletPool = new ObjectPool(bullet.gameObject, 5);
    }
    public void Launch(Transform firePoint, Transform target)
    {
        Bullet bulletObj = bulletPool.GetObject().GetComponent<Bullet>();
        if (bulletObj != null)
        {
            bulletObj.Launch(firePoint, target);
            bulletObj.Damage = GetComponent<Turret>().Data.Damage;
        }
    }
}