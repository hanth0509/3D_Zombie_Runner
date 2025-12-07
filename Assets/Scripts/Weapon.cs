using UnityEngine;
using UnityEngine.InputSystem;
public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] private float fireRate = 0.1f; // 0.1s = 10 viên/s
    [SerializeField] float damage = 30f;
    private MyInputs inputs;
    private bool isShooting;
    private float nextFireTime = 0f;
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
        if (isShooting && Time.time >= nextFireTime)
        {
            Shoot();
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
    private void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(FPCamera.transform.position,FPCamera.transform.forward,out hit,range))
        { 
            Debug.Log("I think this thing: "+ hit.transform.name);
            //TODO :Add some hit effect for visual players 
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
           return;
        }
    }
}
