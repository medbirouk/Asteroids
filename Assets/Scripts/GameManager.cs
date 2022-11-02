using UnityEngine.UI;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public AudioClip deathClip;
    public AudioClip asteroidExp; 
    public Player player;
    public ParticleSystem explosion;
    public float showUpTime = 3.5f;

    public float respawnTime = 2.5f; 
    public int lives = 3;
    public int score = 0;

    public Text scoreText;
    public Text livesText;

    void Start()
    {
        scoreText.text = "Score : " + score;
        livesText.text = "Lives : " + lives;




    }
    public void AsteroidDestroyed(Asteroid asteroid) {
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();
        


        if (asteroid.size < asteroid.maxSize * 0.5f)
        {

            this.score += 20;
            
            
            

        } else {
            this.score += 50;
            
           

        }

        scoreText.text = "Score : " + score;
        AudioSource.PlayClipAtPoint(asteroidExp, this.transform.position);

    }
    public void DeadPlayer()
    {

        this.explosion.transform.position = this.player.transform.position;
        this.explosion.Play();
        AudioSource.PlayClipAtPoint(deathClip, this.transform.position);
        



        this.lives--;

        if (this.lives <= 0)
        {
            GameOver();
        }
        else
        {
            Invoke(nameof(Respawn), this.respawnTime);
            livesText.text = "Lives : " + lives;
        }

    }

    private void Respawn()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("IgnoreCollision");
        this.player.gameObject.SetActive(true);
        Invoke(nameof(TurnOnCollisions), showUpTime);

    } 

    private void TurnOnCollisions()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver()
    {
        this.lives = 3;
        this.score = 0;
        Invoke(nameof(Respawn), this.respawnTime);
        scoreText.text = "Score : " + score;
        livesText.text = "Lives : " + lives;
    }
}
