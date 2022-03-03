using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text scoreText2;

    public float _time = 0f;
    public static GameManager _instance;
    public float score = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        score = Mathf.Round(_time);
        scoreText.text = "Score : " + score;
        scoreText2.text = "Score : " + score;
    }

    public void ShowGameOver()
    {
        Time.timeScale = 0f;
        gameOver.SetActive(true);
    }

    public void BtnRetry_OnClick()
    {
        Time.timeScale = 1f;
        gameOver.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
