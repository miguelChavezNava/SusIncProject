using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject turretBullet; 
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("shoot", 0.1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void shoot(){

    Instantiate(turretBullet, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), transform.rotation);
    }
}
