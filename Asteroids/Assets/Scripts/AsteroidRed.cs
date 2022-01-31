using UnityEngine;

public class AsteroidRed : MonoBehaviour
{
    private Rigidbody2D asteroidRedRigidbody;

    public float size = 1.0f;
    public float speed = 50.0f;
    public float maxLifeTime = 30.0f;

    private void Awake()
    {
        asteroidRedRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size;
        asteroidRedRigidbody.mass = this.size;
    }

    public void setTrajectory(Vector2 direction)
    {
        asteroidRedRigidbody.AddForce(direction * this.speed);
        Destroy(this.gameObject, this.maxLifeTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            FindObjectOfType<GameManager>().AsteroidRedCollided();
            Destroy(this.gameObject);
        }

    }

}
