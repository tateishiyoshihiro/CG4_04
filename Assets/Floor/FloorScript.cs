using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    //FloorScript�Ŕ��˗p�̃����o�[�ϐ���錾����
    ReflectionProbe probe;
    // Start is called before the first frame update
    void Start()
    {
        //Start�ŃR���|�[�l���g���l������(�A�^�b�`�Ɠ��l)
        this.probe = GetComponent<ReflectionProbe>();
    }

    // Update is called once per frame
    void Update()
    {
        //y��1�������ċt���ɔz�u
        this.probe.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y * -1, Camera.main.transform.position.z);
        probe.RenderProbe();
    }
}
