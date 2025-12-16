using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField]
    private int currentWeapon = 0;

    private MyInputs inputs;
    private void Awake()
    {
        inputs = new MyInputs();
    }

    private void OnEnable()
    {
        inputs.Enable();

        // Scroll wheel
        inputs.Player.ScrollWeapon.performed += OnScrollWeapon;

        // Number keys
        inputs.Player.Weapon1.performed += _ => SwitchWeapon(0);
        inputs.Player.Weapon2.performed += _ => SwitchWeapon(1);
        inputs.Player.Weapon3.performed += _ => SwitchWeapon(2);
    }

    private void OnDisable()
    {
        inputs.Player.ScrollWeapon.performed -= OnScrollWeapon;

        inputs.Player.Weapon1.performed -= _ => SwitchWeapon(0);
        inputs.Player.Weapon2.performed -= _ => SwitchWeapon(1);
        inputs.Player.Weapon3.performed -= _ => SwitchWeapon(2);

        inputs.Disable();
    }

    private void Start()
    {
        SetWeaponActive();
    }

    // INPUT CALLBACKS

    private void OnScrollWeapon(InputAction.CallbackContext ctx)
    {
        float scrollY = ctx.ReadValue<Vector2>().y;

        if (scrollY < 0)
        {
            NextWeapon();
        }
        else if (scrollY > 0)
        {
            PreviousWeapon();
        }
    }

    // WEAPON LOGIC
    private void SwitchWeapon(int weaponIndex)
    {
        if (weaponIndex == currentWeapon)
            return;

        currentWeapon = Mathf.Clamp(weaponIndex, 0, transform.childCount - 1);
        SetWeaponActive();
    }

    private void NextWeapon()
    {
        currentWeapon++;
        if (currentWeapon >= transform.childCount)
        {
            currentWeapon = 0;
        }

        SetWeaponActive();
    }

    private void PreviousWeapon()
    {
        currentWeapon--;
        if (currentWeapon < 0)
        {
            currentWeapon = transform.childCount - 1;
        }

        SetWeaponActive();
    }

    private void SetWeaponActive()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == currentWeapon);
        }
    }
}
