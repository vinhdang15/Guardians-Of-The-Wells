using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class EmptyPlot : MonoBehaviour
{
    public float X { get; private set; }
    public float Y { get; private set; }
    public bool isOccupied = false;

    public EmptyPlot(float x, float y)
    {
        X = x;
        Y = Y;
    }

    public Vector2 GetPos()
    {
        return transform.position;
    }

    internal void HideEmptyPlot()
    {
        gameObject.SetActive(false);
    }
    internal void ShowEmptyPlot()
    {
        gameObject.SetActive(true);
    }
}
