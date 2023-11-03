using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavePointIndex = 0;

    private float speed;
    private float startSpeed = 1.5f;

    void Start()
    {
        target = WayPoints.Instance.waypoints[0];
        speed = startSpeed;
    }

    void Update()
    {
        Vector3 targetPosition = target.position;
        targetPosition.y = transform.position.y;    // Keep the enemy's current y position
        Vector3 direction = targetPosition - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {
        if (wavePointIndex >= WayPoints.Instance.waypoints.Count - 1)
        {
            EndPath();
            return;
        }

        wavePointIndex++;
        target =  WayPoints.Instance.waypoints[wavePointIndex];

        Vector3 directionToTarget = (target.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);
    }

    void EndPath()
    {
        GameManager.Instance.DecreaseLives();
        gameObject.SetActive(false);
    }
}
