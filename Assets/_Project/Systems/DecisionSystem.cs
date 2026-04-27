using UnityEngine;

public class DecisionSystem : MonoBehaviour
{
    private GameObject[] _foodSources;
    private GameObject[] _restAreas;

    void Start()
    {
        _foodSources = GameObject.FindGameObjectsWithTag("Food");
        _restAreas = GameObject.FindGameObjectsWithTag("Rest");
    }

    void OnEnable()
    {
        EventBus.Subscribe<HungerLowEvent>(OnHungerLow);
        EventBus.Subscribe<EnergyLowEvent>(OnEnergyLow);
    }

    void OnHungerLow(HungerLowEvent e)
    {
        var npc = e.NPC;

        if (_foodSources.Length == 0) return;

        if (npc.GetHighestNeed() != NeedType.Hunger)
            return;

        var target = DistanceHelper.FindClosest(_foodSources, npc.transform.position);

        npc.TargetPosition = target.transform.position;
        npc.HasTarget = true;

        Debug.Log($"{npc.name} chose FOOD");
    }

    void OnEnergyLow(EnergyLowEvent e)
    {
        var npc = e.NPC;

        if (_restAreas.Length == 0) return;

        if (npc.GetHighestNeed() != NeedType.Energy)
            return;

        var target = DistanceHelper.FindClosest(_restAreas, npc.transform.position);

        npc.TargetPosition = target.transform.position;
        npc.HasTarget = true;

        Debug.Log($"{npc.name} chose REST");
    }
}
