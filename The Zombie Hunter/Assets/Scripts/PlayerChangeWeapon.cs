using UnityEngine;

public class PlayerChangeWeapon : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) PlayerWeaponEvents.InvokeWeaponChanged(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2)) PlayerWeaponEvents.InvokeWeaponChanged(1);
        else if (Input.GetKeyDown(KeyCode.Alpha3)) PlayerWeaponEvents.InvokeWeaponChanged(2);
        else if (Input.GetKeyDown(KeyCode.Alpha4)) PlayerWeaponEvents.InvokeWeaponChanged(3);
        else if (Input.GetKeyDown(KeyCode.Alpha5)) PlayerWeaponEvents.InvokeWeaponChanged(4);
    }
}
