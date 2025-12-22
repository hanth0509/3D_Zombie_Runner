using System;
using System.Collections;
using TMPro;
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
    AmmoType ammoType;

    [SerializeField]
    float timeBetweenShots = 0.5f;

    [SerializeField]
    TextMeshProUGUI ammoText;

    [SerializeField]
    private AudioSource shootingAudio;

    [SerializeField]
    private AudioClip shootingClip;

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
        canShoot = true;
        inputs.Enable();
        inputs.Player.Shoot.started += OnShootStarted;
        inputs.Player.Shoot.canceled += OnShootCanceled;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        inputs.Player.Shoot.started -= OnShootStarted;
        inputs.Player.Shoot.canceled -= OnShootCanceled;
        inputs.Disable();
    }

    private void Update()
    {
        DisplayAmmo();
        if (isShooting && Time.time >= nextFireTime && canShoot == true)
        {
            StartCoroutine(Shoot());
            nextFireTime = Time.time + fireRate;
        }
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurentAmount(ammoType);
        ammoText.text = $"Ammo: {currentAmmo}";
    }

    private void OnShootStarted(InputAction.CallbackContext ctx)
    {
        isShooting = true;
    }

    private void OnShootCanceled(InputAction.CallbackContext ctx)
    {
        isShooting = false;
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurentAmount(ammoType) > 0)
        {
            ammoSlot.ReduceCurrentAmmo(ammoType); // Reduce ammo count by 1
            PlayShootSound();
            PlayMuzzleFlash();
            ProcessRaycast();
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void PlayShootSound()
    {
        if (shootingAudio == null)
        {
            Debug.LogError("shootingAudio NULL");
            return;
        }

        if (shootingClip == null)
        {
            Debug.LogError("shootingClip NULL");
            return;
        }

        shootingAudio.PlayOneShot(shootingClip);
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
