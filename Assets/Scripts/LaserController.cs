using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public Sprite laserOnSprite;
    public Sprite laserOffSprite;

    public float toogleInterval = 0.5f;
    public float rotationSpeed = 30.0f;

    private float lastTimeToogleChange;
    private bool isLaserOn;

    private Collider2D laserCollider;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        laserCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastTimeToogleChange = Time.time;
        isLaserOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastTimeToogleChange > toogleInterval)
        {
            isLaserOn = !isLaserOn;
            laserCollider.enabled = isLaserOn;

            if (isLaserOn)
            {                
                spriteRenderer.sprite = laserOnSprite;
            }
            else
            {
                spriteRenderer.sprite = laserOffSprite;
            }

            lastTimeToogleChange += toogleInterval;
        }
        transform.RotateAround(transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
