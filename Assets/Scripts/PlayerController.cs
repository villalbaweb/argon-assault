using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float controlSpeed = 1f;
    [SerializeField] float xRange = 5f;

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
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, 0, xRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
