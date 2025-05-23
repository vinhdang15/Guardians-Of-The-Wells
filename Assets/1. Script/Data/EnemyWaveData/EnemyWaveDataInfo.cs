using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveDataInfo : MonoBehaviour
{
    private List<EnemyWaveData> EnemyWaveDataList= new()
    {
        new EnemyWaveData
        {
            mapID = 1,
            pathWayWaveList = new()
            {
                new PathWayWave
                {
                    pathID = 1,
                    EnemyWaveList = new()
                    {
                        new EnemyWave
                        {
                            waveNumber              = 1,
                            primaryEnemyID          = UnitID.Enemy_C_1.ToString(),
                            primaryEnemyCount       = 4,
                            secondaryEnemyID        = UnitID.none.ToString(),
                            secondaryEnemyCount     = 0,
                            timeBetweenEachSpawn    = 1f,
                            timeWaitForNextWave     = 10f,
                        },
                        new EnemyWave
                        {
                            waveNumber              = 2,
                            primaryEnemyID          = UnitID.Enemy_C_1.ToString(),
                            primaryEnemyCount       = 4,
                            secondaryEnemyID        = UnitID.none.ToString(),
                            secondaryEnemyCount     = 0,
                            timeBetweenEachSpawn    = 1.2f,
                            timeWaitForNextWave     = 5f,
                        },
                        new EnemyWave
                        {
                            waveNumber              = 3,
                            primaryEnemyID          = UnitID.Enemy_C_1.ToString(),
                            primaryEnemyCount       = 4,
                            secondaryEnemyID        = UnitID.Enemy_B_1.ToString(),
                            secondaryEnemyCount     = 2,
                            timeBetweenEachSpawn    = 1.2f,
                            timeWaitForNextWave     = 7f,
                        },
                        new EnemyWave
                        {
                            waveNumber              = 4,
                            primaryEnemyID          = UnitID.Enemy_C_1.ToString(),
                            primaryEnemyCount       = 0,
                            secondaryEnemyID        = UnitID.Enemy_B_1.ToString(),
                            secondaryEnemyCount     = 2,
                            timeBetweenEachSpawn    = 1.2f,
                            timeWaitForNextWave     = 5f,
                        },
                        new EnemyWave
                        {
                            waveNumber              = 5,
                            primaryEnemyID          = UnitID.Enemy_C_1.ToString(),
                            primaryEnemyCount       = 2,
                            secondaryEnemyID        = UnitID.Enemy_A_1.ToString(),
                            secondaryEnemyCount     = 1,
                            timeBetweenEachSpawn    = 1.2f,
                            timeWaitForNextWave     = 5f,
                        },
                    }
                },
            }
        },
        
        new EnemyWaveData
        {
            mapID = 2,
            pathWayWaveList = new()
            {
                new PathWayWave
                {
                    pathID = 1,
                    EnemyWaveList = new()
                    {
                        new EnemyWave
                        {
                            waveNumber              = 1,
                            primaryEnemyID          = UnitID.Enemy_C_1.ToString(),
                            primaryEnemyCount       = 4,
                            secondaryEnemyID        = UnitID.Enemy_B_1.ToString(),
                            secondaryEnemyCount     = 1,
                            timeBetweenEachSpawn    = 1.2f,
                            timeWaitForNextWave     = 5f,
                        },
                        new EnemyWave
                        {
                            waveNumber              = 2,
                            primaryEnemyID          = UnitID.Enemy_C_1.ToString(),
                            primaryEnemyCount       = 4,
                            secondaryEnemyID        = UnitID.Enemy_B_1.ToString(),
                            secondaryEnemyCount     = 1,
                            timeBetweenEachSpawn    = 1.2f,
                            timeWaitForNextWave     = 5f,
                        },
                        new EnemyWave
                        {
                            waveNumber              = 3,
                            primaryEnemyID          = UnitID.Enemy_C_1.ToString(),
                            primaryEnemyCount       = 4,
                            secondaryEnemyID        = UnitID.Enemy_B_1.ToString(),
                            secondaryEnemyCount     = 1,
                            timeBetweenEachSpawn    = 1.2f,
                            timeWaitForNextWave     = 5f,
                        },
                        new EnemyWave
                        {
                            waveNumber              = 4,
                            primaryEnemyID          = UnitID.Enemy_C_1.ToString(),
                            primaryEnemyCount       = 4,
                            secondaryEnemyID        = UnitID.Enemy_B_1.ToString(),
                            secondaryEnemyCount     = 1,
                            timeBetweenEachSpawn    = 1.2f,
                            timeWaitForNextWave     = 5f,
                        },
                        new EnemyWave
                        {
                            waveNumber              = 5,
                            primaryEnemyID          = UnitID.Enemy_C_1.ToString(),
                            primaryEnemyCount       = 4,
                            secondaryEnemyID        = UnitID.Enemy_B_1.ToString(),
                            secondaryEnemyCount     = 1,
                            timeBetweenEachSpawn    = 1.2f,
                            timeWaitForNextWave     = 5f,
                        },
                    }
                },

                new PathWayWave
                {
                    pathID = 2,
                    EnemyWaveList = new()
                    {
                        new EnemyWave
                        {
                            waveNumber              = 1,
                            primaryEnemyID          = UnitID.Enemy_C_1.ToString(),
                            primaryEnemyCount       = 4,
                            secondaryEnemyID        = UnitID.Enemy_B_1.ToString(),
                            secondaryEnemyCount     = 1,
                            timeBetweenEachSpawn    = 1.2f,
                            timeWaitForNextWave     = 5f,
                        },
                        new EnemyWave
                        {
                            waveNumber              = 2,
                            primaryEnemyID          = UnitID.Enemy_C_1.ToString(),
                            primaryEnemyCount       = 4,
                            secondaryEnemyID        = UnitID.Enemy_B_1.ToString(),
                            secondaryEnemyCount     = 1,
                            timeBetweenEachSpawn    = 1.2f,
                            timeWaitForNextWave     = 5f,
                        },
                        new EnemyWave
                        {
                            waveNumber              = 3,
                            primaryEnemyID          = UnitID.Enemy_C_1.ToString(),
                            primaryEnemyCount       = 4,
                            secondaryEnemyID        = UnitID.Enemy_B_1.ToString(),
                            secondaryEnemyCount     = 1,
                            timeBetweenEachSpawn    = 1.2f,
                            timeWaitForNextWave     = 5f,
                        },
                        new EnemyWave
                        {
                            waveNumber              = 4,
                            primaryEnemyID          = UnitID.Enemy_C_1.ToString(),
                            primaryEnemyCount       = 4,
                            secondaryEnemyID        = UnitID.Enemy_B_1.ToString(),
                            secondaryEnemyCount     = 1,
                            timeBetweenEachSpawn    = 1.2f,
                            timeWaitForNextWave     = 5f,
                        },
                        new EnemyWave
                        {
                            waveNumber              = 5,
                            primaryEnemyID          = UnitID.Enemy_C_1.ToString(),
                            primaryEnemyCount       = 4,
                            secondaryEnemyID        = UnitID.Enemy_B_1.ToString(),
                            secondaryEnemyCount     = 1,
                            timeBetweenEachSpawn    = 1.2f,
                            timeWaitForNextWave     = 5f,
                        },
                    }
                }
            }  
        }
    };

    public List<EnemyWaveData> GetEnemyWaveDataList()
    {
        return EnemyWaveDataList;
    }
}

[System.Serializable]
public class EnemyWaveData
{
    public int mapID;
    public List<PathWayWave> pathWayWaveList;
}

[System.Serializable]
public class PathWayWave
{
    
    public int pathID;
    public List<EnemyWave> EnemyWaveList;
}

[System.Serializable]
public class EnemyWave
{   
    public int      waveNumber;
    public string   primaryEnemyID;
    public int      primaryEnemyCount;
    public string   secondaryEnemyID;
    public int      secondaryEnemyCount;
    public float    timeBetweenEachSpawn;
    public float    timeWaitForNextWave;
}