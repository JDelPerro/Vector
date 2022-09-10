using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public struct MyRector
{
    public float magnitude => Mathf.Sqrt(x * x + y * y);
    public float x;
    public float y;

    public MyRector normalized
    {
        get
        {
            float distance = magnitude;
            if (distance < 0.0001f)
            {
                return new MyRector(0, 0);
            }
            return new MyRector(x / distance, y / distance);
        }
    }
    public MyRector(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
    public override string ToString()
    {
        return $"[{x},{y}]";
    }
    public static implicit operator Vector3(MyRector a)
    {
        return new Vector3(a.x, a.y, 0);
    }
    public MyRector Lerp(MyRector myVector, float t)
    {
        return this + (myVector - this) * t;
    }
    public void Draw(Color color)
    {
        Debug.DrawLine(new Vector3(0, 0, 0), this, color, 0);

    }
    public void Draw2(MyRector origin, Color color)
    {
        Debug.DrawLine(origin, this + origin, color, 0);

    }
    public void Normalize()
    {
        float magnitudeCache = magnitude;
        if (magnitudeCache < 0.001)
        {
            x = 0;
            y = 0;
        }
        else
        {
            x = x / magnitudeCache;
            y = y / magnitudeCache;
        }
    }
    public static MyRector operator +(MyRector a, MyRector b)
    {
        return new MyRector(a.x + b.x, a.y + b.y);

    }
    public static MyRector operator -(MyRector a, MyRector b)
    {
        return new MyRector(a.x - b.x, a.y - b.y);

    }
    public static MyRector operator *(MyRector a, float n)
    {
        return new MyRector(a.x * n, a.y * n);

    }
    public static implicit operator MyRector(Vector3 a)
    {
        return new MyRector(a.x, a.y);
    }
}