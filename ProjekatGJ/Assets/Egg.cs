using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public int lives = 1;
    
    void Update()
    {
        if (lives <= 0)
        {
            
            Debug.Log("Game Over");
            
        };
        
    }
}
