using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavTile
{
    public Vector2 position;
    public float g_Cost;
    public float h_Cost;
    public bool is_available;

    public NavTile(Vector2 pos) {
        position = pos;
    }
    public float f_Cost() {
        return g_Cost + h_Cost;
    }

    public bool checkAvailibility() {
        return is_available;
    }
    
}
