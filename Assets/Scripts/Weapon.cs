using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    Camera FPCamera;

    [SerializeField]
    float range = 100f;

    [SerializeField]
    private float fireRate = 0.1f; // 0.1s = 10 viên/s

    [SerializeField]
    float damage = 30f;

    [SerializeField]
    ParticleSystem muzzleFlash;

    [SerializeField]
    GameObject hitEffect;

    [SerializeField]
    Ammo ammoSlot;

    [SerializeField]
    float timeBetweenShots = 0.5f;
    private MyInputs inputs;
    private bool isShooting;
    private float nextFireTime = 0f;

    bool canShoot = true;

    private void Awake()
    {
        inputs = new MyInputs();
    }

    private void OnEnable()
    {
        inputs.Enable();
        inputs.Player.Shoot.started += OnShootStarted;
        inputs.Player.Shoot.canceled += OnShootCanceled;
    }

    private void OnDisable()
    {
        inputs.Player.Shoot.started -= OnShootStarted;
        inputs.Player.Shoot.canceled -= OnShootCanceled;
        inputs.Disable();
    }

    private void Update()
    {
        if (isShooting && Time.time >= nextFireTime && canShoot == true)
        {
            StartCoroutine(Shoot());
            nextFireTime = Time.time + fireRate;
        }
    }

    private void OnShootStarted(InputAction.CallbackContext ctx)
    {
        isShooting = true;
    }

    private void OnShootCanceled(InputAction.CallbackContext ctx)
    {
        isShooting = false;
    }

    private void OnShoot(InputAction.CallbackContext ctx)
    {
        Shoot();
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurentAmount() > 0)
        {
            ammoSlot.ReduceCurrentAmmo(); // Reduce ammo count by 1
            PlayMuzzleFlash();
            ProcessRaycast();
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private bool ProcessRaycast()
    {
        RaycastHit hit;
        if (
            Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range)
        )
        {
            // Debug.Log("I think this thing: " + hit.transform.name);
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null)
                return false;
            target.TakeDamage(damage);
        }
        else
        {
            return false;
        }

        return true;
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}
