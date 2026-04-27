using UnityEngine;

public struct HungerLowEvent
{
    public NPCController NPC;

    public HungerLowEvent(NPCController npc)
    {
        NPC = npc;
    }
}
