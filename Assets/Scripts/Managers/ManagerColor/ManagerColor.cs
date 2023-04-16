using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
public class ManagerColor : Singleton<ManagerColor>
{
    public List<Material> materials;
    public List<ColorSetup> colorSetups; 

    public void ChangeColorByType(ManagerArt.ArtType artType)
    {
        var setup = colorSetups.Find(i => i.artType == artType);
        for (var i = 0; i < materials.Count; i++)
        {
            materials[i].SetColor("_Color",setup.colors[i]);
        }
    }
}
[System.Serializable]
public class ColorSetup
{
    public ManagerArt.ArtType artType;
    public List<Color> colors;
}