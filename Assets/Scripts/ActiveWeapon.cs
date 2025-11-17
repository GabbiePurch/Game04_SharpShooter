using UnityEngine;
using StarterAssets;
using Unity.Mathematics;

public class ActiveWeapon : MonoBehaviour
{

    [SerializeField] WeaponSO weaponSO;
    Animator animator;
    StarterAssetsInputs starterAssetsInputs;
    Weapon currentWeapon;

    const string SHOOT_STRING = "Shoot";

    float timeSinceLastShot= 0f;

    void Awake()
    {
        animator = GetComponent<Animator>();
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    void Start()
    {
        currentWeapon = GetComponentInChildren<Weapon>();
    }
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        HandleShoot();
        
    }

    void HandleShoot()
    {
        if (!starterAssetsInputs.shoot) return;

        if (timeSinceLastShot >= weaponSO.FireRate)
        {
            currentWeapon.Shoot(weaponSO);
            animator.Play(SHOOT_STRING, 0, 0f);
            timeSinceLastShot = 0f;
        }

        starterAssetsInputs.ShootInput(false);

    }
}
