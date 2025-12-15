using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    int ammoAmount = 10;

    public int GetCurentAmount()
    {
        {
            return ammoAmount;
        }
    }

    public void ReduceCurrentAmmo()
    {
        ammoAmount--;
    }
}
