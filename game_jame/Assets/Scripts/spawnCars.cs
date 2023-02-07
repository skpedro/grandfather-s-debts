using UnityEngine;

public class spawnCars : MonoBehaviour
{
    // [SerializeField] private GameObject[] cars;
    public float carSpeed;

    private float[] ySpawn = {-1.34f, -2.78f, -4.1741f};
    private float[] xSpawn = {5.24f, 8f, 11f, 13.5f, 16.42f, 18.93f};
    
    void Start()
    {
        var randomYIndex = Random.Range(0, ySpawn.Length);
        var randomXIndex = Random.Range(0, xSpawn.Length);
        
        transform.position = new Vector2(xSpawn[randomXIndex], ySpawn[randomYIndex]);
    }
    void FixedUpdate()
    {
        if (GameManager.start)
        {
            SpawnRandom();
        }   
    }
 
    void SpawnRandom() 
    {
        var randomYIndex = Random.Range(0, ySpawn.Length);
        var randomXIndex = Random.Range(0, xSpawn.Length);

        if (transform.position.x < -16.5f)
        {
            transform.position = new Vector2(xSpawn[randomXIndex], ySpawn[randomYIndex]);
        }
       
        // transform.Translate(carSpeed, 0, 0);
        transform.Translate(Vector2.left * carSpeed * Time.fixedDeltaTime);
    }
       
    void OnCollisionEnter2D(Collision2D collision) 
    {
        var randomYIndex = Random.Range(0, ySpawn.Length);
        var randomXIndex = Random.Range(0, xSpawn.Length);

        if (collision.gameObject.CompareTag("Cars")) 
        {
            transform.position = new Vector2(xSpawn[randomXIndex], ySpawn[randomYIndex]);
        }
    }
}
