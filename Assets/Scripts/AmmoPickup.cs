using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField]
    private int ammoAmount = 5;

    [SerializeField]
    private AmmoType ammoType;

    private bool _isPickedUp = false;

    private void OnTriggerEnter(Collider other)
    {
        if (_isPickedUp)
            return;

        if (!other.TryGetComponent<Ammo>(out Ammo ammo))
            return;

        _isPickedUp = true;
        ammo.IncreaseCurrentAmmo(ammoType, ammoAmount);
        Destroy(gameObject);
    }
}
