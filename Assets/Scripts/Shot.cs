using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{

    [Min(0)]
    [SerializeField]
    private float speed = 10;

    [Min(0)]
    [SerializeField]
    private float destroyTime = 10;

    private IEnumerator Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
        if (destroyTime > 0)
            yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }

}