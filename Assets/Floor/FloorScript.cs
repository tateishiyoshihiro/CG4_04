using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    //FloorScriptで反射用のメンバー変数を宣言する
    ReflectionProbe probe;
    // Start is called before the first frame update
    void Start()
    {
        //Startでコンポーネントを獲得する(アタッチと同様)
        this.probe = GetComponent<ReflectionProbe>();
    }

    // Update is called once per frame
    void Update()
    {
        //yに1をかけて逆側に配置
        this.probe.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y * -1, Camera.main.transform.position.z);
        probe.RenderProbe();
    }
}
