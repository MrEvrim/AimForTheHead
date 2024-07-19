using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
    public Text Ammo;
    public Text ReloadTimeTxt;
    public GameObject bulletPrefab;
    public Transform firePoint;

    public AudioSource fireSound;
    public AudioClip fireClip;
    public AudioClip reloadClip;
    public int maxAmmo = 30;
    private int currentAmmo;
    private bool isReloading = false;

    public GameObject muzzleFlash;
    public float muzzleFlashDuration = 0.1f;

    public float reloadTime = 5f; // Reload süresi (saniye)

    void Start()
    {
        currentAmmo = maxAmmo;
        fireSound = GetComponent<AudioSource>();
        fireSound.clip = fireClip;
        ReloadTimeTxt.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo && !isReloading)
        {
            StartCoroutine(Reload());
        }

        // Mermi sayısını güncelle
        UpdateAmmoText();


        if (Input.GetButtonDown("Fire1") && currentAmmo > 0 && !isReloading)
        {
            Shoot();
        }

        if (currentAmmo == 0)
        {
            ReloadTimeTxt.gameObject.SetActive(true);
        }
        else
        {
            ReloadTimeTxt.gameObject.SetActive(false);
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;

        fireSound.clip = reloadClip;
        fireSound.Play();

        ReloadTimeTxt.gameObject.SetActive(true);

        yield return new WaitForSeconds(reloadTime);


        fireSound.clip = fireClip;
        currentAmmo = maxAmmo;
        isReloading = false;

        ReloadTimeTxt.gameObject.SetActive(false);
    }

    void Shoot()
    {
        fireSound.Play();
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        currentAmmo--; // Bir mermi harcandığında mevcut mermi sayısını azalt
        StartCoroutine(ShowMuzzleFlash());
    }

    IEnumerator ShowMuzzleFlash()
    {
        // Işık efektini aç
        muzzleFlash.SetActive(true);

        yield return new WaitForSeconds(muzzleFlashDuration);

        muzzleFlash.SetActive(false);
    }

    void UpdateAmmoText()
    {
        Ammo.text = currentAmmo.ToString();
    }
}