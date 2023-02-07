using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class spawnMonets : MonoBehaviour
{
    [SerializeField] GameObject moneyPref;
    Vector3 pos;
    [SerializeField]GameManager gameManager;
    private void Start()
    {
       StartCoroutine(SpawnRate());
    }

    IEnumerator SpawnRate()
    {
        while (gameManager.isgame)
        {
            pos = new Vector2(24f, Random.Range(-4.4f, -1.12f));
            gameManager.CheckCoin();
            Instantiate(moneyPref, pos, Quaternion.identity);
            yield return new WaitForSeconds(5);
        }
    }
}
