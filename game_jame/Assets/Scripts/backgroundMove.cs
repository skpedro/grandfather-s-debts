using UnityEngine;

public class backgroundMove : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    
    public float scrollSpeed = -0.1f;
    public float objPosX, objPosY;

    void Update()
    {
        if (GameManager.start)
        {
            Vector2 spawnPoint = new Vector2(objPosX, objPosY);

            // float camWitdth = cm.orthographicSize * cm.aspect;

            if (transform.position.x <= -26f)
            {
                Instantiate(obj, spawnPoint, Quaternion.identity);
                Destroy(obj);
                // transform.position = new Vector2(objPosX, transform.position.y);
            }
            transform.Translate(scrollSpeed * Time.deltaTime, 0, 0);
        }
        
    }
}       
