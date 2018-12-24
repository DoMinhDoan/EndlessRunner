using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    private float distanceToTarget;

    private void Start()
    {
        distanceToTarget = transform.position.x - target.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x + distanceToTarget, transform.position.y, transform.position.z);
    }
}
