using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    float timeCount = 0;//経過時間
    [SerializeField] GameObject shotBullet;//発射する弾

    // Start is called before the first frame update
    void Start()
    {
        //何も書かない
    }

    // Update is called once per frame
    void Update()
    {
        //前フレームからの時間の差を加算
        timeCount += Time.deltaTime;

        //1秒を超えているか
        if (timeCount > 1.0f) 
        {
            timeCount = 0;//再発射のために時間をリセット

            //GameObjectを新たに生成する
            //第一引数：生成するGameObject
            //第二引数：生成する座標
            //第三引数：生成する角度
            Instantiate(shotBullet,transform.position,Quaternion.identity);
        }

    }
}
