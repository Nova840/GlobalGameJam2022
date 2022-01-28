using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{

    [SerializeField]
    private float speed = 10;

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }

}