using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D bulletRigidBody;

    public float speed = 500.0f;
    public float maxLifeTime = 10.0f;
    private void Awake()
    {
        bulletRigidBody = GetComponent<Rigidbody2D>();
    }

    public void Project(Vector2 direction)
    {
        bulletRigidBody.AddForce(direction * this.speed);
        Destroy(this.gameObject, this.maxLifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
