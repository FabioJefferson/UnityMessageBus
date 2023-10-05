using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    [SerializeField]
    private PawnType _type;
}

public enum PawnType
{
    CROSS = 51,
    DISK
}

#if FIKA
public class Much
{

}
#endif
