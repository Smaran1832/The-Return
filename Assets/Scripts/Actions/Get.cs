using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Actions/Get")]
public class Get : Action
{
    
    public override void RespondtoInput(GameController controller,string noun)
    {
        Debug.Log(controller.player.currentLocation);   
        foreach(Item item in controller.player.currentLocation.items)
        { 
            if(item.itemEnabled && (item.itemName == noun))
            {
                Debug.Log("entered the get if loop 1");
                if(item.playerCanTake)
                {
                    Debug.Log("entered the get if loop 2");
                    controller.player.inventory.Add(item);
                    controller.player.currentLocation.items.Remove(item);
                    controller.currentText.text="You Take the "+noun;
                    return ;
                }
            }
        }
        controller.currentText.text="You can't get that";
    }

}
