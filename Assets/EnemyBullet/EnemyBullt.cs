using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullt : MonoBehaviour
{
    [SerializeField] float angle;//Šp“x
    [SerializeField] float speed;//‘¬“x
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        //x²•ûŒü‚ÌˆÚ“®—Êİ’è‚·‚é
        velocity.x=speed*Mathf.Cos(angle*Mathf.Deg2Rad);
        //z²•ûŒü‚ÌˆÚ“®—Êİ’è‚·‚é
        velocity.z=speed*Mathf.Sin(angle*Mathf.Deg2Rad);

        //’e‚ÌŒü‚«‚ğİ’è‚·‚é
        float zAngle = Mathf.Atan2(velocity.z, velocity.x) * Mathf.Rad2Deg - 90.0f;
        transform.rotation=Quaternion.Euler(0,0,zAngle);

        //5•bŒã‚Éíœ
        Destroy(gameObject,5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }

    //’Ç‰Á
    //Šp“x‚Æ‘¬“x‚ğİ’è‚·‚éŠÖ”
    public void init(float input_angle,float input_speed)
    {
        angle = input_angle;
        speed = input_speed;
    }

    private void OnCollisionEnter(Collision other)
    {
        
    }
}
