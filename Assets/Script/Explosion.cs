using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    float currentTime = 0;
    float destroyTime = 1.5f;
    public GameObject exp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > destroyTime)
        {
            Destroy(exp);
        }
    }
}
