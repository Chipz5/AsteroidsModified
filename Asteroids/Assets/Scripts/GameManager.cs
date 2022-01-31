
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public float respawnTime = 3.0f;
    public float canMoveTime = 5.0f;

    public void PlayerDied()
    {
        Invoke(nameof(Respawn), this.respawnTime);
    }

    private void Respawn()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.SetActive(true);
        this.player.canMove = true;
    }

    public void AsteroidRedCollided()
    {
        this.player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        this.player.GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
        this.player.canMove = false;
        Invoke(nameof(PlayerMobile), this.canMoveTime);
    }

    private void PlayerMobile()
    {
        this.player.canMove = true;
    }
}
