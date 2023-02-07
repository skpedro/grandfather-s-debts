using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnWord : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Canvas startMenu;
    private string _text;

    private void Start()
    {
        _text = text.text;
        text.text = "";
        StartCoroutine(TextCoroutine());
    }

    IEnumerator TextCoroutine()
    {
        foreach (char abc in _text)
        {
            text.text += abc;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(1);
        startMenu.gameObject.SetActive(true);
    }
}
