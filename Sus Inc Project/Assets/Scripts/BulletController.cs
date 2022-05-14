using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float speed = 10.0f;
    public bool isFired = false;
    private PlayerController playerCtrlScript;
    private bool direction = false;
    public int shootDirection = 1;
    public GameObject player;
   
    // Start is called before the first frame update
    void Start()
    {
        playerCtrlScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(shootDirection, 0, 0) * speed * Time.deltaTime);
        if(playerCtrlScript.getInput() < 0 && isFired)
        {
            shootDirection = -1;
            setIsFired(false);
        }
        else if(playerCtrlScript.getInput() >= 0 && isFired)
        {
            shootDirection = 1;
            setIsFired(false);
        }
        if (transform.position.x >= (playerCtrlScript.playerPosX + 10))
        {
            Destroy(gameObject);
            setIsFired(false);
        }
        if (transform.position.x <= (playerCtrlScript.playerPosX - 10))
        {
            Destroy(gameObject);
            setIsFired(false);
        }
        /*if (direction && isFired)
        {
            //transform.Translate(Vector3.right * speed * Time.deltaTime);
            shootDirection = 1;
            
            if (transform.position.x >= (playerCtrlScript.playerPosX + 10))
            {
                Destroy(gameObject);
                setIsFired(false);
            }
        }
        else if(!direction && isFired)
        {
            //transform.Translate(Vector3.left * speed * Time.deltaTime);
            shootDirection = -1;
            
            if (transform.position.x <= (playerCtrlScript.playerPosX - 10))
            {
                Destroy(gameObject);
                setIsFired(false);
            }
        }*/
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EndGame")
        {
            Destroy(other.gameObject);
            setIsFired(false);
        }
    }
    public void setIsFired(bool change)
    {
        isFired = change;
    }
    public void updateDirection(bool newDirection)
    {
        direction = newDirection;
    }
    public bool getIsFired()
    {
        return isFired;
    }
}
