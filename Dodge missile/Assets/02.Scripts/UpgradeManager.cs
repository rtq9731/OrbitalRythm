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

    UpgradeInfo _upgradeData = new UpgradeInfo();

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

    public void Upgrade(UpgradeCode upgradeCode)
    {
        _upgradeData.Upgrade(upgradeCode);
    }
}

[System.Serializable]
public class UpgradeInfo
{
    private bool canShootActiveMissile = false;
    private bool canSlowMotion = false;
    private bool canShield = false;
    private bool canShockWave = false;

    private int initMissileCount = 3;

    private float initMissileTime = 2f;
    private float initAccleration = 3f;

    private int moreMissileUpgradeCount = 0;
    private int fastMissileUpgradeCount = 0;
    private int slowMotionUpgradeCount = 0;
    private int moreAcclerationUpgradeCount = 0;
    private int shockWaveUpgradeCount = 0;
    private int forceFieldUpgradeCount = 0;

    private float curMissileTime = 0f;
    private float curAccleration = 0f;

    private int curMissileCount = 0;

    private float fieldRecoverPerSec = 0f;
    private float curHPMax = 0f;

    public void Upgrade(UpgradeCode upgradeCode)
    {
        switch (upgradeCode)
        {
            case UpgradeCode.Attack_MoreMissile:
                moreMissileUpgradeCount++;
                
                break;
            case UpgradeCode.Attack_ActiveMissile:
                
                
                break;
            case UpgradeCode.Attack_FastMissile:
                
                
                break;
            case UpgradeCode.Attack_SlowMotion:
                
                
                break;
            case UpgradeCode.Move_MoreAcceleration:
                
                
                break;
            case UpgradeCode.Move_Warp:
                
                
                break;
            case UpgradeCode.Defense_ShockWave:
                
                
                break;
            case UpgradeCode.Defense_MoreHP:


                break;
            case UpgradeCode.Defense_RecoverHP:


                break;
            case UpgradeCode.Defense_ForceField:
                canShield = true;

                break;
            default:
                break;
        }
    }
}
