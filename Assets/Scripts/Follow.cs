using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform follower, followee;
    private Vector3 offset = new Vector3(0f, 5f, -5f);
    private Quaternion cameraAngle = Quaternion.Euler(40f,0f,0f);

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotatedOffset = followee.rotation * offset;
        follower.position = followee.position + rotatedOffset;
        follower.rotation = followee.rotation * cameraAngle;
    }
}
