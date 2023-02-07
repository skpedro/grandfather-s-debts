using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTuchka : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Translate(Vector2.left *1.5f*Time.fixedDeltaTime);
        if (transform.position.x<=-23)
        {
            Destroy(gameObject);
            SpawnTucha.Instance.SpawnTuches();
        }
    }
}
