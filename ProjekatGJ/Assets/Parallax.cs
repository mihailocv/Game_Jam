using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform mainCam;
    public Transform middleBG;
    public Transform sideBG;

    public float lenght = 5.11f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mainCam.position.x > middleBG.position.x) 
        {
            sideBG.position = middleBG.position + Vector3.right * 5.11f;
        }
        if (mainCam.position.x < middleBG.position.x)
        {
            sideBG.position = middleBG.position + Vector3.left * 5.11f;
        }
        if(mainCam.position.x > sideBG.position.x || mainCam.position.x<sideBG.position.x)
        {
            Transform z = middleBG;
            middleBG = sideBG;
            sideBG = z;
        }
    }
}
