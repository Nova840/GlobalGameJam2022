using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField]
    private GameObject shotPrefab;

    [SerializeField]
    private Transform aimPoint;

    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        aimPoint.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (playerInput.GetShootButtonUp())
        {
            Shot shot = Instantiate(shotPrefab, transform.position, Quaternion.LookRotation(Vector3.forward, playerInput.GetShootingInputVector())).GetComponent<Shot>();
            shot.Initialize(transform);
            aimPoint.gameObject.SetActive(false);
        }
        else if (playerInput.GetShootButtonDown())
        {
            aimPoint.gameObject.SetActive(true);
        }

        aimPoint.rotation = Quaternion.LookRotation(Vector3.forward, playerInput.GetShootingInputVector());
    }

}