using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior1 : MonoBehaviour
{
    public Transform myPrefab;
    public GameObject parent;
    private Transform obj;
    private ArrayList spawns = new ArrayList();


    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<10; i++) {
            newCollectable();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void newCollectable() {
        seek_position:
        Vector3 vec = new Vector3(UnityEngine.Random.Range(-5,5)/100f,0.01f,UnityEngine.Random.Range(-5,5)/100f);
        foreach (Vector3 listVec in spawns) {
            if (listVec.Equals(vec)) {
                goto seek_position;
            }
        }
        spawns.Add(vec);
        obj = Instantiate(myPrefab, vec, new Quaternion(0,0,0,1));
        obj.parent = parent.transform;
    }
}
