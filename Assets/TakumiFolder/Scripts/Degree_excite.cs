using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Degree_excite : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(new Vector3(0, 0, 1));
    }
}
