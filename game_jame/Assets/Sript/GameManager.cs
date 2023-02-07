using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isgame = true;
    private int Lvlmoney;
    public static int score { get; set; }
    public static bool start = false;
    public static int coin { get; set; }
    [SerializeField] TextMeshProUGUI score_text;
    [SerializeField] TextMeshProUGUI moneyLocation1_text;
    [SerializeField] TextMeshProUGUI end_text;
    [SerializeField] Canvas DeathSrin;
    [SerializeField] Canvas VinSrin;
    [SerializeField] Canvas StartCan;
    [SerializeField] GameObject player;
    private AudioSource audio;

    public void Dead()
    {
        audio.Stop();
        score = 0;
        Lvlmoney = 0;
        DeathSrin.gameObject.SetActive(true);
    }

    public void Vin()
    {
        isgame = false;
        PlayerControl.money += Lvlmoney;
        PlayerPrefs.SetInt("Money", PlayerControl.money);
        moneyLocation1_text.text += PlayerControl.money;
        VinSrin.gameObject.SetActive(true);
    }

    public void End()
    {
        PlayerControl.money += Lvlmoney;
        PlayerPrefs.SetInt("Money", PlayerControl.money);
        if (PlayerPrefs.GetInt("Money")>=5000)
        {
            end_text.text = "congratulations, you will be put in jail for stealing money, but you have paid off your grandfather's debt)";
            moneyLocation1_text.text += (PlayerPrefs.GetInt("Money"));
            VinSrin.gameObject.SetActive(true);
        }
        else
        {
            end_text.text = "What a shame that you couldn't pay off your grandfather's debt and you'll have to go to prison.";
            moneyLocation1_text.text += (PlayerPrefs.GetInt("Money"));
            VinSrin.gameObject.SetActive(true);
        }
       
    }

    public void Increase()
    {
        Lvlmoney += 100;
        score_text.text = "Score:" + score;
        CheckCoin();
    }
    public void CheckCoin()
    {
        if (coin == 15)
        {
            Vin();
            start = false;
            Destroy(player);
        }
    }
    public void Restart(int indexScen)
    {
        Lvlmoney = 0;
        SceneManager.LoadScene(indexScen);
    }

    public void Restart2(int indexScen)
    {
        score = 0;
        PlayerControl.money = 0;
        PlayerPrefs.SetInt("Money", PlayerControl.money);
        SceneManager.LoadScene(indexScen);
    }

    public void NextLevel(int indexScen)
    {
        Lvlmoney = 0;
        SceneManager.LoadScene(indexScen);
    }

    private void Start()
    {
        
        audio = GetComponent<AudioSource>();
        audio.volume = PlayerPrefs.GetFloat("Volume");
        StartCoroutine(ShowStart());
        score_text.text = "score:" + score;
    }
    IEnumerator ShowStart()
    {
        yield return new WaitForSeconds(2);
        StartCan.gameObject.SetActive(false);
        coin = 0;
        start = true;
    }
}
