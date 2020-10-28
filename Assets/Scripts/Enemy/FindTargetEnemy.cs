using UnityEngine;

public class FindTargetEnemy : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private RaycastHit hit;
    [SerializeField] private ShootEnemy shootEnemy;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // поиск игрока
    }


    private void Update()
    {
        FindPlayer();
    }




    private void FindPlayer()
    {
                Ray ray = new Ray(transform.position, player.transform.position - transform.position);
                if (Physics.Raycast(ray, out hit, 1000f))
                {
            if (hit.distance <= 10f) {
                if (hit.collider.tag == "Player")
                {
                    shootEnemy.StartShoot(); // запускаем стрельбу
                    TurnTarget();
                }
                else
                {
                    shootEnemy.StopShoot(); // останавливаем стрельбу
                }
            }
            else
            {
                shootEnemy.StopShoot(); // останавливаем стрельбу
            }
        }
    }
    private void TurnTarget()
    {
        if (player != null)
        {
            Vector3 Position = player.transform.position - transform.position;
            Position.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Position), 15f * Time.deltaTime);
        }
    }
}