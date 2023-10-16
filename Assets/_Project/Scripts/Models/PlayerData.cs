using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "MySO/PlayerDATA")]
public class PlayerData : ScriptableObject
{
    [SerializeField] float defaultHealth = 100;
    [SerializeField] float defaultMagic = 100;
    [HideInInspector] public GameObject myObject;
    public float Health;
    [HideInInspector] public float magic;
    [HideInInspector] public Vector3 currentPosition;


    public void ResetData()
    {
        myObject = null;
        Health = defaultHealth;
        magic = defaultMagic;
        currentPosition = Vector3.zero;
    }

    [Button]
    private void IncreaseHealth()
    {
        Health++;
    }
}
