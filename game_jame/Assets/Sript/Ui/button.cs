using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class button : MonoBehaviour
{
    [SerializeField] Slider slider;
    public void LoadScen(int id)
    {
        SceneManager.LoadScene(id);
    }
    public void ChangeVolue()
    {
        PlayerPrefs.SetFloat("Volume",slider.value);
    }
    public void Exit()
    {
        Debug.Log("exit");
        Application.Quit();
    }
}
