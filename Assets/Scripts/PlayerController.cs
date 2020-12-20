using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float controlSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float newXPos = transform.localPosition.x + xOffset;

        float yOffset = yThrow * controlSpeed * Time.deltaTime;
        float newYPos = transform.localPosition.y + yOffset;

        transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);
    }
}
