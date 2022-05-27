using Manager.Core;
using UnityEngine;
using Utils;

[CreateAssetMenu(fileName = "NewStat", menuName = "Stat")]
public class Stat : ScriptableObject, ITableSetter
{
    [SerializeField] private ulong id;
    [SerializeField] private string unitName;
    [SerializeField] private int rarity;
    [SerializeField] private SchoolEnum school;
    [SerializeField] private CombatClass combatClass;
    [SerializeField] private Role role;
    [SerializeField] private CombatPosEnum combatPos;
    [SerializeField] private int bond;
    [SerializeField] private AtkTypeEnum atkType;
    [SerializeField] private DefTypeEnum defType;
    [SerializeField] private TerrainPower cityPower;
    [SerializeField] private TerrainPower desertPower;
    [SerializeField] private TerrainPower indoorPower;
    [SerializeField] private int equip1;
    [SerializeField] private int equip2;
    [SerializeField] private int equip3;
    [SerializeField] private FireArm fireArm;
    [SerializeField] private bool isCover;
        
    [Header("Stat")]
    [SerializeField] private int maxHealth;
    [SerializeField] private int atkPower;
    [SerializeField] private int defPower;
    [SerializeField] private int healPower;
    [SerializeField] private int accuRate;
    [SerializeField] private int evade;
    [SerializeField] private int crit;
    [SerializeField] private int critAtk;
    [SerializeField] private int critDef;
    [SerializeField] private int stable;
    [SerializeField] private int range;
    [SerializeField] private int cCAtk;
    [SerializeField] private int cCDef;
    [SerializeField] private int costGen;




    #region Getter
    public ulong ID => id;
    
    #endregion


    public void SetData(string[] fieldNames, string[] datas)
        => Util.SetPrivateData<Stat>(this, fieldNames, datas);
}


public enum SchoolEnum : sbyte
{
    None,
    Abydos,
    Gehenna,
    Millennium,
    Trinity,
    Hyakkiyako,
    Shanhaijing,
    RedWinter,
    Valkyrie,
    Arius,
    SRT,
    Chronos,
    WildHunt,
    Odyssey,
    Event = 99
}

public enum CombatClass : sbyte
{
    None,
    Striker,
    Special
}

public enum Role : sbyte
{
    None,
    Attacker,
    Supporter,
    Tank,
    Healer,
    Tactical
}

public enum CombatPosEnum : sbyte
{
    None,
    Front,
    Middle,
    Back
}

public enum AtkTypeEnum : sbyte
{
    None,
    Normal,
    Explosive,
    Piercing,
    Mystic,
    Siege
}

public enum DefTypeEnum : sbyte
{
    None,
    Light,
    Heavy,
    Special,
    Structure
}

public enum FireArm : sbyte
{
    None,
    HandGun,
    AssaultRifle,
    MachineGun,
    Shotgun,
    SubmachineGun,
    SniperRifle,
    Rifle,
    GrenadeLauncher,
    RocketLauncher,
    Railgun,
    Mortar
}

public enum TerrainPower : sbyte
{
    None,
    D,
    C,
    B,
    A,
    S
}