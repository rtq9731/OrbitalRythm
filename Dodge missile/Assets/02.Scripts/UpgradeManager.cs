using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeCode
{
    Attack_MoreMissile,
    Attack_ActiveMissile,
    Attack_FastMissile,
    Attack_SlowMotion,
    Move_MoreAcceleration,
    Move_Warp,
    Defense_ShockWave,
    Defense_MoreHP,
    Defense_RecoverHP,
    Defense_ForceField
}

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<UpgradeManager>();
                if(_instance == null)
                {
                    _instance = Instantiate(Resources.Load<UpgradeManager>("UpgradeManager"));
                }
            }

            return _instance;
        }
    }

    PlayerInfo _upgradeData = new PlayerInfo();

    private static UpgradeManager _instance = null;

    private void Awake()
    {
        if(_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }

    public void Upgrade(UpgradeCode upgradeCode, Action callBack = null)
    {
        _upgradeData.Upgrade(upgradeCode, callBack = null);
    }
}

[System.Serializable]
public class PlayerInfo
{
    public event Action<UpgradeCode> onFirstUpgrade = (x) => {};

    [SerializeField] private bool canShootActiveMissile = false;
    [SerializeField] private bool canSlowMotion = false;
    [SerializeField] private bool canShield = false;
    [SerializeField] private bool canShockWave = false;
    [SerializeField] private bool canWarp = false;

    [SerializeField] private int initMissileCount = 3;
    
    [SerializeField] private float initMissileTime = 2f;
    [SerializeField] private float initAccleration = 3f;
    
    [SerializeField] private int moreMissileUpgradeCount = 0;
    [SerializeField] private int fastMissileUpgradeCount = 0;
    [SerializeField] private int moreAcclerationUpgradeCount = 0;
    [SerializeField] private int forceFieldUpgradeCount = 0;

    [SerializeField] private float curMissileTime = 0f;
    [SerializeField] private float curAccleration = 0f;
   
    [SerializeField] private int curMissileCount = 0;
    [SerializeField] private float fieldRecoverPerSec = 0f;
    [SerializeField] private float curHPMax = 0f;

    public void Upgrade(UpgradeCode upgradeCode, Action callBack = null)
    {
        bool finishUpgrade = false;

        switch (upgradeCode)
        {
            case UpgradeCode.Attack_MoreMissile:
                {
                    moreMissileUpgradeCount++;
                    finishUpgrade = true;
                    break;
                }
            case UpgradeCode.Attack_ActiveMissile:
                {
                    if(!canShootActiveMissile)
                    {
                        onFirstUpgrade?.Invoke(UpgradeCode.Attack_ActiveMissile);
                        canShootActiveMissile = true;
                        finishUpgrade = true;
                    }
                }
                break;
            case UpgradeCode.Attack_FastMissile:
                {
                    fastMissileUpgradeCount++;
                    finishUpgrade = true;
                }
                break;
            case UpgradeCode.Attack_SlowMotion:
                {
                    if(!canSlowMotion)
                    {
                        onFirstUpgrade?.Invoke(UpgradeCode.Attack_SlowMotion);
                        canSlowMotion = true;
                        finishUpgrade = true;
                    }
                }
                break;
            case UpgradeCode.Move_MoreAcceleration:
                {
                    moreAcclerationUpgradeCount++;
                    finishUpgrade = true;
                }
                break;
            case UpgradeCode.Move_Warp:
                {
                    if (!canWarp)
                    {
                        onFirstUpgrade?.Invoke(UpgradeCode.Move_Warp);
                        canWarp = true;
                        finishUpgrade = true;
                    }
                }
                break;
            case UpgradeCode.Defense_ShockWave:
                {
                    canShockWave = true;
                    finishUpgrade = true;
                }
                break;
            case UpgradeCode.Defense_MoreHP:
                {
                    finishUpgrade = true;
                }
                break;
            case UpgradeCode.Defense_RecoverHP:
                {
                    finishUpgrade = true;
                }
                break;
            case UpgradeCode.Defense_ForceField:
                {
                    if (!canShield && forceFieldUpgradeCount <= 0)
                    {
                        onFirstUpgrade(UpgradeCode.Defense_ForceField);
                        canShield = true;
                    }
                    forceFieldUpgradeCount++;
                    finishUpgrade = true;
                }
                break;
            default:
                break;
        }

        if (finishUpgrade)
            callBack?.Invoke();
    }
}
