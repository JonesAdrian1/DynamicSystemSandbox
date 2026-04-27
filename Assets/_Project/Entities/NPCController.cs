using UnityEngine;

public class NPCController : MonoBehaviour
{
    [Header("Needs")]
    public float Hunger = 100f;
    public float Energy = 100f;

    [Header("Decay Rates")]
    public float HungerDecayRate = 5f;
    public float EnergyDecayRate = 2f;

    public Vector3 TargetPosition;

    [Header("Move Speed")]
    public float MoveSpeed = 3f;

    public bool HasTarget = false;

    private bool _hasTriggeredHungerLow;
    private bool _hasTriggeredEnergyLow;
    private float decisionTimer = 0f;
    private float decisionInterval = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateNeeds();
        MoveToTarget();

        decisionTimer += Time.deltaTime;

        if (decisionTimer >= decisionInterval)
        {
            decisionTimer = 0f;
            EvaluateNeedsDirectly();
        }
    }

    void UpdateNeeds()
    {
        Hunger -= HungerDecayRate * Time.deltaTime;
        Energy -= EnergyDecayRate * Time.deltaTime;

        Hunger = Mathf.Clamp(Hunger, 0f, 100f);
        Energy = Mathf.Clamp(Energy, 0f, 100f);

        if (Hunger < 30f && !_hasTriggeredHungerLow)
        {
            _hasTriggeredHungerLow = true;
            EventBus.Publish(new HungerLowEvent(this));
        }

        if (Energy < 30f && !_hasTriggeredEnergyLow)
        {
            _hasTriggeredEnergyLow = true;
            EventBus.Publish(new EnergyLowEvent(this));
        }
    }

    void MoveToTarget()
    {
        if (!HasTarget) return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            TargetPosition,
            MoveSpeed * Time.deltaTime
        );

        float distance = Vector3.Distance(transform.position, TargetPosition);

        if (distance < 0.5f)
        {
            HasTarget = false;
            OnReachedTarget();
        }
    }

    void OnReachedTarget()
    {
        Debug.Log($"{name} reached target");

        // Simple interaction logic (temporary)
        Hunger = 100f;
        Energy = 100f;

        // Reset flags so events can fire again
        _hasTriggeredHungerLow = false;
        _hasTriggeredEnergyLow = false;
    }

    void EvaluateNeedsDirectly()
    {
        if (HasTarget) return;

        if (GetHighestNeed() == NeedType.Hunger && Hunger < 60f)
        {
            EventBus.Publish(new HungerLowEvent(this));
        }

        if (GetHighestNeed() == NeedType.Energy && Energy < 60f)
        {
            EventBus.Publish(new EnergyLowEvent(this));
        }
    }

    public NeedType GetHighestNeed()
    {
        float hungerPriority = 100f - Hunger;
        float energyPriority = 100f - Energy;

        return hungerPriority > energyPriority ? NeedType.Hunger : NeedType.Energy;
    }
}
