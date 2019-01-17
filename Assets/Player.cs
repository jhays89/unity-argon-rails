using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In m/s")][SerializeField] float xSpeed = 6f;
    [Tooltip("In m")] [SerializeField] float xRange = 5.5f;

    [Tooltip("In m/s")] [SerializeField] float ySpeed = 6f;
    [Tooltip("In m")] [SerializeField] float yRange = 5.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePos();
    }

    public void UpdatePos()
    {
        var xPos = GetXPos();
        var yPos = GetYPos();

        transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z);
    }

    public float GetXPos()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // This is used instead of 'key' -- allows for cross platform and I assume is good practice. can be found in edit > Project settings > input
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);

        return clampedXPos;
    }

    public float GetYPos()
    {
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical"); // This is used instead of 'key' -- allows for cross platform and I assume is good practice. can be found in edit > Project settings > input
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawNewYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);

        return clampedYPos;
    }
}
