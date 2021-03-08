using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBarMovement : MonoBehaviour
{
    public float speed = 10;
    public Transform playField;
    public GameObject ball;
    void Update()
    {
        float maxMapWidth = ((playField.localScale.z * 10) * 0.5f) - (transform.localScale.z * 0.5f);
        float nextPos = transform.position.z + Mathf.Clamp( ball.transform.position.z -transform.position.z, -1,1) * Time.deltaTime * speed;
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(nextPos, -maxMapWidth, maxMapWidth));
    }
}
