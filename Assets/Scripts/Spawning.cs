
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public float trajectoryVariance = 15.0f; 
    public Asteroid asteroidPrefab;
    public float spawnTime = 2.0f;
    public int spawnAmount = 1;
    public float spawnDistance = 15.0f; 

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), this.spawnTime, this.spawnTime); 
    } 

    private void Spawn()
    {
        for (int i = 0; i < this.spawnAmount; i++) { 


            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;

            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);  

            Asteroid asteroid = Instantiate(this.asteroidPrefab, spawnPoint, rotation);

            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
            asteroid.SetTrajectory(rotation * -spawnDirection);
        }
    }

   
}
