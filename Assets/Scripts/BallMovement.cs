using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float maxX;
    public float maxZ;
    private Vector3 velocity;
    public Transform playField;
    public GameObject controller;

    void Start()
    {
        triggerNewRound();
    }

    public void triggerNewRound()
    {
        transform.position = new Vector3(0, 0.5f, 0);
        velocity = new Vector3(0, 0, 0);
        controller.GetComponent<Controller>().resetCountdown();
    }

    public void activateBall()
    {
        velocity = new Vector3(maxX, 0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bar"))
        {
            float maxDist = other.transform.localScale.z * 1 * 0.5f + transform.localScale.z * 1 * 0.5f;
            float dist = transform.position.z - other.transform.position.z;
            float nDist = dist / maxDist;
            
            velocity = new Vector3(-velocity.x, velocity.y, nDist * maxX);
        } else if (other.CompareTag("Wall"))
        {
            velocity = new Vector3(velocity.x, velocity.y, -velocity.z);
        }
        GetComponent<AudioSource>().Play();
    }

    private void resetBall()
    {
        if (velocity.x < 0)
        {
            controller.GetComponent<Controller>().incrementRedScore();
        }
        else
        {
            controller.GetComponent<Controller>().incrementBlueScore();
        }
        triggerNewRound();
    }
     
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
        if (transform.position.x - 5 > playField.localScale.x * 10 * 0.5f || transform.position.x + 5 < playField.localScale.x * 10 * 0.5f * (-1))
        {
            resetBall();
            
        }
    }
}
