using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody rb;
    public Animator animator;

    float moveSpeed = 3.0f;

    private GameObject gameManager;
    private GameManager gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        //ゲームマネージャーのオブジェクトを探す
        gameManager = GameObject.Find("GameManager");
        //スクリプトを獲得
        gameManagerScript = gameManager.GetComponent<GameManager>();

        Destroy(gameObject, 15);
        transform.rotation = Quaternion.Euler(0, 180, 0);

        //乱数で左右に
        int r = Random.Range(0, 2);
        if (r == 0)
        {
            transform.rotation = Quaternion.Euler(0, 180 - 40, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180 + 40, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.IsGameOver() == true)
        {
            return;
        }
        Vector3 velocity = new Vector3(0, 0, moveSpeed * Time.deltaTime);
        transform.position += transform.rotation * velocity;

        //左右で反転
        if (transform.position.x > 4)
        {
            transform.rotation = Quaternion.Euler(0, 180 + 40, 0);
        }
        if (transform.position.x < -4)
        {
            transform.rotation = Quaternion.Euler(0, 180 - 40, 0);
        }
    }
}
