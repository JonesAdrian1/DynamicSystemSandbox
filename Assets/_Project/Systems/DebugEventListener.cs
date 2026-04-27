using UnityEngine;

public class DebugEventListener : MonoBehaviour
{
    void OnEnable()
    {
        EventBus.Subscribe<HungerLowEvent>(OnHungerLow);
        EventBus.Subscribe<EnergyLowEvent>(OnEnergyLow);
    }

    void OnHungerLow(HungerLowEvent e)
    {
        Debug.Log($"{e.NPC.name} is hungry!");
    }

    void OnEnergyLow(EnergyLowEvent e)
    {
        Debug.Log($"{e.NPC.name} is tired!");
    }
}