using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDataForJson : MonoBehaviour
{
    private List<BulletData> bulletDatas = new()
    {
        // Arrow bullet
        new BulletData
        {
            bulletID      = "Arrow_1",
            damage          = 20,
            speed           = 6,
            effectTyes      = "none",
        },
        new BulletData
        {
            bulletID      = "Arrow_2",
            damage          = 30,
            speed           = 6,
            effectTyes      = "Fire_DoT",
        },

        // MagicBall bullet
        new BulletData
        {
            bulletID      = "MagicBall_1",
            damage          = 35,
            speed           = 4,
            effectTyes      = "Magic_DoT",
        },
        new BulletData
        {
            bulletID      = "MagicBall_2",
            damage          = 35,
            speed           = 4,
            effectTyes      = "Magic_DoT;Slow"
        },

        // Bomb bullet
        new BulletData
        {
            bulletID      = "Bomb_1",
            damage          = 30,
            speed           = 6,
            effectTyes      = "Bomb_1_AoE20",
        },
        new BulletData
        {
            bulletID      = "Bomb_2",
            damage          = 40,
            speed           = 6,
            effectTyes      = "Bomb_2_AoE30",
        },
    };

     public List<BulletData> GetBulletDataForJson()
    {
        return bulletDatas;
    }
}
