using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class followCamera : MonoBehaviour
{
    public GameObject target;
    Vector3 offset;
    void Start()
    {
        offset =  new Vector3(0, 2, -6);
    }


    void Update()
    {
        transform.LookAt(target.transform);
        transform.position = target.transform.position + offset;
    }
}
