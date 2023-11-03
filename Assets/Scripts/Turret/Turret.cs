using UnityEngine;
public class Turret : MonoBehaviour
{
    [SerializeField] private TurretData data;
    public TurretData Data => data;
    private EnemyHealth targetEnemy;
    private float fireCountdown = 0f;

    public Transform partToRotate;
    public Animator anim;
    public Transform firePoint;

    private EnemyHealth nearestEnemy;
    private float damage;
    private float attackRange;
    private float attackSpeed;

    public float Damage => damage;
    public float AttackRange => attackRange;
    public float AttackSpeed => attackSpeed;

    private int level = 1;
    public int Level => level;
    private void Start()
    {
        Initiliaze();
    }
    private void Initiliaze()
    {
        damage = data.Damage; 
        attackRange = data.AttackRange;
        attackSpeed = data.AttackSpeed;
    }
    public void ApplyUpgradeValue()
    {
        level++;
        damage *= data.UpgradeData.DamageMultiplier;
        attackRange *= data.UpgradeData.AttackRangeMultiplier;
        attackSpeed *= data.UpgradeData.AttackSpeedMultiplier;
    }
    void Update()
    {
        targetEnemy = FindNearestEnemy();

        if(targetEnemy != null)
        {
            LockOnTarget(targetEnemy.transform);
        }
        else
        {
            anim.SetBool("Fire", false);
        }

        if (targetEnemy != null && fireCountdown <= 0f)
        {
            ShootEnemy();
            fireCountdown = 1f / attackSpeed;
        }

        fireCountdown -= Time.deltaTime;
    }

    private EnemyHealth FindNearestEnemy()
    {
        nearestEnemy = null;
        float shortestDistance = attackRange;

        foreach (EnemyHealth enemy in EnemyWave.Instance.GetEnemies())
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy <= attackRange && distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }

    private void LockOnTarget(Transform target)
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * 10f).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    private void ShootEnemy()
    {
        ILauncher launcher = GetComponent<ILauncher>();
        if (launcher != null)
        {
            launcher.Launch(firePoint, targetEnemy.transform);
            anim.SetBool("Fire", true);
        }
    }
}