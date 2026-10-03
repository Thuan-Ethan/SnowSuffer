using UnityEngine;

[CreateAssetMenu(fileName = "Powerup", menuName = "PowerupSO")]
public class PowerupSO : ScriptableObject
{
    [SerializeField] string powerupType;
    [SerializeField] float valueChange;
    [SerializeField] float duration;

    public string getPowerupType()
    {
        return powerupType;
    }

    public float getValueChange()
    {
        return valueChange;
    }

    public float getDuration()
    {
        return duration;
    }
}
