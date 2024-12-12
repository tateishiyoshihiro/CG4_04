using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject gameOverText;
    public TextMeshProUGUI scoreText;
    public static int score = 0;

    //アイテム追加
    public GameObject itemPrefab;

    public bool IsGameOver()
    {
        return gameOverFlag;
    }

    private bool gameOverFlag = false;

    public void GameOverStart()
    {
        gameOverText.SetActive(true);
        gameOverFlag = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, false);
        Instantiate(enemy, new Vector3(0, 0, 7), Quaternion.identity);
        float x = Random.Range(-1.0f, 1.0f);
        Instantiate(enemy, new Vector3(x, 0, 7), Quaternion.identity);
        GameManager.score = 0;
    }

    private void FixedUpdate()
    {
        int r = Random.Range(0, 50);
        if (r == 0)
        {
            float x = Random.Range(-3.0f, 3.0f);
            Instantiate(enemy, new Vector3(x, 0, 7), Quaternion.identity);
            //アイテム出現
           // Instantiate(itemPrefab, transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //スコア表示
        scoreText.text = "SCORE" + score;
        if (gameOverFlag == true)
        {
            return;
        }

        //ゲームオーバーなら
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
