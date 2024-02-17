using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnsScript : MonoBehaviour
{
    public float speed;

    private void FixedUpdate()
    {
        if (!BirdScript.isEnd)
        transform.Translate(new Vector3(speed, 0, 0));        
    }
}