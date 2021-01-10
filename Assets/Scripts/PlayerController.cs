using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("General Setup Settings")]

    [Header("Movement Setup Settings")]
    [Tooltip("How fast ships moves based on players input")]
    [SerializeField] float controlSpeed = 1f;
    [Tooltip("How fast can move along x axis")]
    [SerializeField] float xRange = 13f;
    [Tooltip("How fast ship can move along y axis")]
    [SerializeField] float yRange = 7f;

    [Header("Screen position based tunning")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 2f;

    [Header("Player input based tunning")]
    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float controlRollFactor = -20f;

    [Header("Laser particle system setup")]
    [Tooltip("Set the particle systems that will work as lasers")]
    [SerializeField] ParticleSystem[] lasers = null;




    float xThrow;
    float yThrow;

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    private void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            SetActivateLasers(true);
        } 
        else
        {
            SetActivateLasers(false);
        }
    }

    private void SetActivateLasers(bool isActive)
    {
        foreach (ParticleSystem laser in lasers)
        {
            var emision = laser.emission;
            emision.enabled = isActive;
        }
    }
}
