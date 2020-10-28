using UnityEngine;

public class FindTargetPlayer : MonoBehaviour
{
    [SerializeField] private GameObject[] allEnemy;
    
    [SerializeField] private ShootPlayer shootPlayer;
    private RaycastHit hit;
    private GameObject targetEnemy;
    public void Start()
    {
        allEnemy = GameObject.FindGameObjectsWithTag("Enemy"); // поиск всех врагов на сцене под тегом Enemy
    }



    private void Update()
    {
        FindNearbyEnemy();
    }
    
        private void FindNearbyEnemy()
    {
        float distanceEnemy = Mathf.Infinity; // дистаниция самого ближайшего врага
        foreach (GameObject enemy in allEnemy)
        {
            Ray ray = new Ray(transform.position, enemy.transform.position - transform.position);
            if (Physics.Raycast(ray, out hit, 1000f))
            {
                if (hit.collider.tag == "Enemy")
                {
                    if (hit.distance <= 10f) // Если дистанция до противника <= 10
                    {
                        if (enemy != targetEnemy) // Проверяем для того, чтобы не вызывать метод каждыый кадр
                        {
                            shootPlayer.StartShoot(); // запускаем стрельбу
                        }
                    }
                    if (allEnemy.Length > 1)
                    {
                        Vector3 amountDistance = enemy.transform.position - transform.position;
                        float currentDistance = amountDistance.sqrMagnitude;
                        if (currentDistance <= distanceEnemy)
                        {
                            targetEnemy = enemy;
                            distanceEnemy = currentDistance;
                        }
                    }
                    else
                    {
                        targetEnemy = enemy;
                    }
                }
                else
                {
                    if (enemy == targetEnemy)
                        shootPlayer.StopShoot(); // останавливаем стрельбу
                    targetEnemy = null;
                }
            }
        }
        TurnTarget();
    }
    private void TurnTarget()
    {
        if (targetEnemy != null)
        {
            Vector3 Position = targetEnemy.transform.position - transform.position;
            Position.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-Position), 15f * Time.deltaTime);
        }
    }
}
