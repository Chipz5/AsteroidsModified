using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D asteroidRigidbody;

    public float size = 1.0f;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;
    public float speed = 50.0f;
    public float maxLifeTime = 30.0f;

    private void Awake()
    {
        asteroidRigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        this.transform.eulerAngles = new Vector3(0.0f,0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size;
        asteroidRigidbody.mass = this.size;
    }

    public void setTrajectory(Vector2 direction)
    {
        asteroidRigidbody.AddForce(direction * this.speed);
        Destroy(this.gameObject, this.maxLifeTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            if (this.size * 0.5f >= this.minSize)
            {
                CreateSplit();
                CreateSplit();
            }
            Destroy(this.gameObject);
        }
        
    }

    private void CreateSplit()
    {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;
        Asteroid asteroidHalf = Instantiate(this, position, this.transform.rotation);
        asteroidHalf.size = this.size * 0.5f;
        asteroidHalf.setTrajectory(Random.insideUnitCircle.normalized * this.speed);
    }
}
