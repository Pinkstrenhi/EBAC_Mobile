using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
public class ManagerArt : Singleton<ManagerArt>
{
    public enum ArtType
    {
        Type01,
        Type02
    }

    public List<ArtSetup> artSetups;

    public ArtSetup GetSetupByArtType(ArtType artType)
    {
        return artSetups.Find(i => i.artType == artType);
    }
}
[System.Serializable]
public class ArtSetup
{
    public ManagerArt.ArtType artType;
    public GameObject gameObject;
}