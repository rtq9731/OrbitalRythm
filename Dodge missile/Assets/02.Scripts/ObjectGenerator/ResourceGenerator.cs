using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    [SerializeField] ResourceScript resourcePrefab = null;

    GenericPool<ResourceScript> resourcePool = null;



}
