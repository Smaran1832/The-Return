using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public bool itemEnabled=true;
    public bool playerCanTake;
    public Item targetItem=null;
    public bool playerCanTalkTo=false;
    public bool playerCanGiveTo = false;
    public bool playerCanRead = false;
    
    [TextArea]
    public string description;

    public Interaction[] interactions;
    
    public bool InteractWith(GameController controller,string actionKeyword,string noun="")
    {
        foreach(Interaction interaction in interactions)
        {
            if(interaction.action.keyword==actionKeyword)
            {

                    if (noun != "" && noun != interaction.textToMatch)
                    continue;

                    foreach (Item disableItem in interaction.itemToDisable)
                        disableItem.itemEnabled=false;
                    foreach(Item enableItem in interaction.itemToEnable)
                        enableItem.itemEnabled=true;   

                    foreach(Connection disableConnection in interaction.connectionToDisable)
                        disableConnection.connectionEnabled=false;
                    foreach(Connection enableConnection in interaction.connectionToEnable)
                        enableConnection.connectionEnabled=true;

                    if (interaction.teleportlocation != null)
                    controller.player.Teleport(controller, interaction.teleportlocation);

                    controller.currentText.text = interaction.response; 
                    controller.DisplayLocation(true);        
                    return true;    
                
            }
        }
        return false;
    }
}
