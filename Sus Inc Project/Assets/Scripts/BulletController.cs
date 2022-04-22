using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float speed = 10.0f;
    public static bool isFired = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if(transform.position.x >= 50)
        {
            Destroy(gameObject);
            setIsFired(false);
        }
    }
    public static void setIsFired(bool change)
    {
        isFired = change;
    }
}
