using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBarMovement : MonoBehaviour
{
    public float speed = 10;
    public Transform playField;

    void Update()
    {
        float maxMapWidth = ((playField.localScale.z * 10) * 0.5f) - (transform.localScale.z * 0.5f);
        float nextPos = transform.position.z + (Input.GetAxis("Horizontal") * Time.deltaTime * speed);
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(nextPos, -maxMapWidth, maxMapWidth));
    }


}
