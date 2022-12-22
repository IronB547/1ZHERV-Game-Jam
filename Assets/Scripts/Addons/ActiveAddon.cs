using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAddon : MonoBehaviour
{
    //define the active addon for this game
    private static Addon activeAddon;

    public static void SetActiveAddon(Addon addon)
    {
        activeAddon = addon;
    }

    public static Addon GetActiveAddon()
    {
        return activeAddon;
    }

    public static void ClearActiveAddon()
    {
        activeAddon = null;
    }

    public static bool HasActiveAddon()
    {
        return activeAddon != null;
    }

}