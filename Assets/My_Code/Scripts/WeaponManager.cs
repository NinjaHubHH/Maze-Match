using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//WeaponManager bestimmt die Eigenschaften der Waffe/n
[System.Serializable]
public class WeaponManager : MonoBehaviour
{

    public string name = "Axt";

    public int attackDamage = 10;
    public float range = 100f;
}
