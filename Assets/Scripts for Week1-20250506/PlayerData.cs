using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    public int score;
    public float force;
    public float health;
    public float GolemHealth;
    public bool LevelUp;
    public bool LevelUpdone;
    public int Chasers;
    public int Skeletons;
    public int Giants;
    public int Zombies;
    public int Level1coinamount;
    public int Level2coinamount;
    public int Level3coinamount;
    public int Level4coinamount;
    public int Level5coinamount;
    public int GemOneCoins;
    public int GemTwoCoins;
    public int GemThreeCoins;
    public int DoorKeyCoins;
    public float coinstonextlevup;
    public float coinstogo;
    public bool GemOneFound;
    public bool GemTwoFound;
    public bool GemThreeFound;
    public bool KeyFourFound;
    public bool SkeletonAttackTrigger;
    public bool GiantAttackTrigger;
    public bool playerdead;
    public bool Golemdead;
    
    
}
