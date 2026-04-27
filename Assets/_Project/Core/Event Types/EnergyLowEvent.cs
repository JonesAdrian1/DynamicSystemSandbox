using UnityEngine;

public struct EnergyLowEvent
{
    public NPCController NPC;

    public EnergyLowEvent(NPCController npc)
    {
        NPC = npc;
    }
}
