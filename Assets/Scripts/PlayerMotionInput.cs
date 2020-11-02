using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMotionInput : MonoBehaviour
{
    public Transform transform;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float rotation = 0;
        if (Input.GetKey("q")) rotation++;
        if (Input.GetKey("e")) rotation--;

        transform.Translate(new Vector3(moveHorizontal/10f, 0f, moveVertical/10f));
        transform.Rotate(0F,rotation,0F,Space.Self);
    }

}
