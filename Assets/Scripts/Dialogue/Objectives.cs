using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Objectives", menuName = "Objectives")]
public class Objectives : ScriptableObject
{
    [SerializeField] private string name;

    [TextArea(1, 5)] public string[] objectives;
}
