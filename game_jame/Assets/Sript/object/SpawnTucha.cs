using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTucha : MonoBehaviour
{
    public static SpawnTucha Instance { get; private set; }
    private Vector2 spawnPoint = new Vector2(132f, 4.85f);
    [SerializeField] GameObject tucha;
    private void Awake()
    {
        Instance = this;
    }
    public void SpawnTuches()
    {
        Instantiate(tucha, spawnPoint,Quaternion.identity);
    }
}
