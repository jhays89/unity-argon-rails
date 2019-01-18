using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In m/s")][SerializeField] float xSpeed = 6f;
    [Tooltip("In m")] [SerializeField] float xRange = 5.5f;
    float xThrow;

    [Tooltip("In m/s")] [SerializeField] float ySpeed = 6f;
    [Tooltip("In m")] [SerializeField] float yRange = 5.5f;
    float yThrow;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;

    [SerializeField] float positionYawFactor = 4.5f;

    [SerializeField] float controlRollFactor = -20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessPosition();
        ProcessRotation();
    }

    public void ProcessPosition()
    {
        var xPos = GetXPos();
        var yPos = GetYPos();

        transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z);
    }

    public float GetXPos()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // This is used instead of 'key' -- allows for cross platform and I assume is good practice. can be found in edit > Project settings > input
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);

        return clampedXPos;
    }

    public float GetYPos()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical"); // This is used instead of 'key' -- allows for cross platform and I assume is good practice. can be found in edit > Project settings > input
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawNewYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);

        return clampedYPos;
    }

    public void ProcessRotation ()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll); //Quaternion.Euler(pitch, yaw, roll) or Quaternion.Euler(x, y, z)
    }
}
