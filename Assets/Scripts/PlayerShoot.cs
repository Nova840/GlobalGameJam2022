using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    [Min(0)]
    [SerializeField]
    private float shotSpeed = 10;

    [Min(0)]
    [SerializeField]
    private int shotDamage = 100;

    [SerializeField]
    private GameObject shotPrefab;

    [SerializeField]
    private Transform aimPoint;

    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        PauseManager.OnPauseUpdate += OnPauseUpdate;
    }

    private void OnDestroy()
    {
        PauseManager.OnPauseUpdate -= OnPauseUpdate;
    }

    private void OnPauseUpdate(bool isPaused)
    {
        if (isPaused)
            aimPoint.gameObject.SetActive(false);
        else
            aimPoint.gameObject.SetActive(playerInput.GetShootButtonDown());
    }

    private void Start()
    {
        aimPoint.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Time.timeScale == 0) return;

        if (playerInput.GetShootButtonUp())
        {
            Shot shot = Instantiate(shotPrefab, transform.position, Quaternion.LookRotation(Vector3.forward, playerInput.GetShootingInputVector())).GetComponent<Shot>();
            shot.Initialize(transform, shotSpeed, shotDamage);
            aimPoint.gameObject.SetActive(false);
        }
        else if (playerInput.GetShootButtonDown())
        {
            aimPoint.gameObject.SetActive(true);
        }

        aimPoint.rotation = Quaternion.LookRotation(Vector3.forward, playerInput.GetShootingInputVector());
    }

}