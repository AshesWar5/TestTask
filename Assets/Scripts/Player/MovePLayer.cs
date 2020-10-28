using UnityEngine;

public class MovePLayer : MonoBehaviour
{
    [SerializeField] private float speed; // скорость игрока
    [SerializeField] private Joystick joystick;
    private new Rigidbody rigidbody;

    private Vector3 move;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
            move.x = joystick.Horizontal;
            move.z = joystick.Vertical;
            rigidbody.velocity = -move * speed;
    }
}