using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isMoving;
    private float turnDirection;
    private Rigidbody2D playerRigidbody;
    private bool hasShield = false;
    private AudioSource collisionAudio;

    public float speed = 1.0f;
    public float turnSpeed = 1.0f;
    public Bullet bulletPrefab;
    public bool canMove = true;
    public float hasShieldTime = 8.0f;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        collisionAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (canMove)
        {
            //check input
            isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                turnDirection = 1.0f;
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                turnDirection = -1.0f;
            }
            else
            {
                turnDirection = 0;
            }

            //shoot
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            //move player
            if (isMoving)
            {
                playerRigidbody.AddForce(this.transform.up * this.speed);
            }

            if (turnDirection != 0)
            {
                playerRigidbody.AddTorque(turnDirection * this.turnSpeed);
            }
        }
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasShield && collision.gameObject.tag == "Asteroid")
        {
            collisionAudio.Play();
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.angularVelocity = 0.0f;
            this.gameObject.SetActive(false);
            FindObjectOfType<GameManager>().PlayerDied();
        }
        if (collision.gameObject.tag == "Pickup")
        {
            Destroy(collision.gameObject);
            hasShield = true;
            Invoke(nameof(shieldReset), this.hasShieldTime);
        }
    }

    private void shieldReset()
    {
        hasShield = false;
    }
}
