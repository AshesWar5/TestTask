using UnityEngine;

public class ShootEnemy : MonoBehaviour
{
    [SerializeField] private float speedBullet; // скорость патрона
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform positionSpawnBullet; // Transform откуда будет вылетать патрон
    [SerializeField] private float timeShoot, reloadTime;
    private bool shoot = false; // true, если враг стреляет
    private HPMob hPMob;


    private void Start()
    {
        hPMob = GetComponent<HPMob>();
        hPMob.OnChangeDied += (On) =>
        {
            this.enabled = On;
        };
    }


    public void StartShoot()
    {
        shoot = true;
    }


    public void StopShoot()
    {
        shoot = false;
        timeShoot = reloadTime;
    }



    private void Update()
    {
        if (shoot)
        {
            timeShoot -= Time.deltaTime;
            if (timeShoot <= 0)
            {
                Rigidbody rigidbody = Instantiate(bullet, positionSpawnBullet.position, Quaternion.identity).GetComponent<Rigidbody>();
                rigidbody.AddForce(transform.forward * speedBullet * Time.deltaTime);
                timeShoot = reloadTime;
            }
        }
    }
}