using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationRandom : MonoBehaviour
{
    public Transform transform;
    private float xRot, yRot, zRot;
    private static int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        xRot = getRandomRotation();
        yRot = getRandomRotation();
        zRot = getRandomRotation();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xRot,yRot,zRot, Space.Self);
    }

    private float getRandomRotation() {
        return UnityEngine.Random.Range(-3f, 3f);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            score++;
            Destroy(transform.gameObject);
        }
    }
}
