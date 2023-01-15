using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : WeaponBase
{
    [SerializeField] private WeaponData _weaponData;
    [SerializeField] private ProjectileBase _projectilePrefab;
    [SerializeField] private Transform _muzzle;

    private bool _wantShooting;
    private bool _isShooting;
    private bool _stopedShooting = true;

    public override WeaponData weaponData => _weaponData;

    public override void StartShooting()
    {
        _stopedShooting = false;
        if (_isShooting)
        {
            if (!_wantShooting)
            {
                StartCoroutine(nameof(WantShooting));
            }
        }
        else
        {
            StartCoroutine(nameof(Shooting));
        }
    }

    public override void StopShooting()
    {
        _stopedShooting = true;
    }

    private IEnumerator WantShooting()
    {
        _wantShooting = true;
        while (_isShooting)
        {
            yield return null;
        }
        _wantShooting = false;
        StartCoroutine(nameof(Shooting));
    }

    private IEnumerator Shooting()
    {
        _isShooting = true;
        while (_isShooting && _stopedShooting == false)
        {
            Shoot();
            yield return new WaitForSeconds(1f / _weaponData.fireRate);
        }
        _isShooting = false;
    }

    private void Shoot()
    {
        ProjectileBase projectile = Instantiate(_projectilePrefab, _muzzle.position, _muzzle.rotation);
        projectile.Shoot(this);
    }
}
