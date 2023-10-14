using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Actions/Go")]
public class Go : Action
{
    public override void RespondtoInput(GameController controller,string verb)
    {
       if(controller.player.ChangeLocation(controller,verb))
       {
          controller.DisplayLocation(); 
       }
       else
       {
          controller.currentText.text = "You can't go that way.";
       }
    }
}
