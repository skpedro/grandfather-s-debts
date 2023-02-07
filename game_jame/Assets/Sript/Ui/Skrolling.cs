using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skrolling : MonoBehaviour
{
    [SerializeField] RawImage rawImage ;
    [SerializeField] float _x, _y;

    void Update()
    {
        rawImage.uvRect = new Rect(rawImage.uvRect.position + new Vector2(_x, _y) * Time.deltaTime,rawImage.uvRect.size);
    }
}
