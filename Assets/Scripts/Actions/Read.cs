using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Read")]
public class Read : Action
{
    public override void RespondtoInput(GameController controller, string noun)
    {
        //location items to check
        if (ReadItem(controller, controller.player.currentLocation.items, noun))
            return ;
        //inventory items to check
        if (ReadItem(controller, controller.player.inventory, noun))
            return ;
    }

    private bool ReadItem(GameController controller,List<Item> items,string noun)
    {
        foreach(Item item in items)
        {
            if(item.itemName==noun && item.itemEnabled)
            {
                if(controller.player.CanReadItem(controller,item))
                {
                    if (item.InteractWith(controller, "read"))
                        return true;
                }
                controller.currentText.text = "There is nothing to read on the " + noun;
                return true;
            }
        }
        return false;
    }
}
