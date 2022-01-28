using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField]
    private GameObject shotPrefab = default;

    [SerializeField]
    private Transform aimPoint = default;

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
            Instantiate(shotPrefab, transform.position, Quaternion.LookRotation(Vector3.forward, playerInput.GetShootingInputVector()));
            aimPoint.gameObject.SetActive(false);
        }
        else if (playerInput.GetShootButtonDown())
        {
            aimPoint.gameObject.SetActive(true);
        }

        aimPoint.rotation = Quaternion.LookRotation(Vector3.forward, playerInput.GetShootingInputVector());
    }

}