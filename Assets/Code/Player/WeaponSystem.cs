using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{

    public float emotionPowerUpTime;
    float emotionPowerUpTimer;

    // Reference of Guns
    public GameObject basicGun;
    public GameObject happyGun;
    public GameObject angryGun;
    public GameObject excitedGun;
    public GameObject scaredGun;
    public GameObject sadGun;

    enum gunTypes
    {
        Basic,
        Happy,
        Angry,
        Excited,
        Scared,
        Sad
    }

    gunTypes currentGunType;

    // Start is called before the first frame update
    void Start()
    {
        currentGunType = gunTypes.Basic;
    }

    // Update is called once per frame
    void Update()
    {
        if (emotionPowerUpTimer >= emotionPowerUpTime)
        {
            switch (currentGunType)
            {
                case gunTypes.Happy:
                    UIStatic.Instance.happyValue = 0;
                    break;
                case gunTypes.Angry:
                    UIStatic.Instance.angryValue = 0;
                    break;
                case gunTypes.Excited:
                    UIStatic.Instance.excitedValue = 0;
                    break;
                case gunTypes.Scared:
                    UIStatic.Instance.scaredValue = 0;
                    break;
                case gunTypes.Sad:
                    UIStatic.Instance.sadValue = 0;
                    break;
            }

            currentGunType = gunTypes.Basic;
            emotionPowerUpTimer = 0.0f;
            SwitchTo(gunTypes.Basic);
        }

        if (currentGunType != gunTypes.Basic)
        {
            
            emotionPowerUpTimer += Time.deltaTime;
        }
        else
        {
            CheckEmotions();
        }
    }

    void CheckEmotions()
    {
        if (UIStatic.Instance.happyValue >= 100)
        {
            currentGunType = gunTypes.Happy;
            SwitchTo(gunTypes.Happy);
        }
        if (UIStatic.Instance.angryValue >= 100)
        {
            currentGunType = gunTypes.Angry;
            SwitchTo(gunTypes.Angry);
        }
        if (UIStatic.Instance.excitedValue >= 100)
        {
            currentGunType = gunTypes.Excited;
            SwitchTo(gunTypes.Excited);
        }
        if (UIStatic.Instance.scaredValue >= 100)
        {
            currentGunType = gunTypes.Scared;
            SwitchTo(gunTypes.Scared);
        }
        if (UIStatic.Instance.sadValue >= 100)
        {
            currentGunType = gunTypes.Sad;
            SwitchTo(gunTypes.Sad);
        }
    }

    void SwitchTo(gunTypes gunType)
    {

        basicGun.SetActive(false);
        happyGun.SetActive(false);
        angryGun.SetActive(false);
        excitedGun.SetActive(false);
        scaredGun.SetActive(false);
        sadGun.SetActive(false);

        switch (gunType)
        {
            case gunTypes.Basic:
                basicGun.SetActive(true);
                break;
            case gunTypes.Happy:
                happyGun.SetActive(true);
                break;
            case gunTypes.Angry:
                angryGun.SetActive(true);
                break;
            case gunTypes.Excited:
                excitedGun.SetActive(true);
                break;
            case gunTypes.Scared:
                scaredGun.SetActive(true);
                break;
            case gunTypes.Sad:
                sadGun.SetActive(true);
                break;
        }
    }

    public void FlipGun(bool flip)
    {
        if (flip)
        {
            basicGun.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX = true;
            happyGun.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX = true;
            angryGun.transform.GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX = true;
            excitedGun.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX = true;
            scaredGun.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX = true;
            sadGun.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            basicGun.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX = false;
            happyGun.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX = false;
            angryGun.transform.GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX = false;
            excitedGun.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX = false;
            scaredGun.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX = false;
            sadGun.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
