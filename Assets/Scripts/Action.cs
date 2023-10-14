using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Actions/Help")]
public abstract class Action : ScriptableObject
{
    public string keyword;
    
    public abstract void RespondtoInput(GameController controller,string noun);
}
