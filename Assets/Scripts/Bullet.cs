using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 7f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<HPBehaviour>())
        {
            other.GetComponent<HPBehaviour>().SetDamege(10);
        }
    }
}
