using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "New Building", menuName = "Building")]
public class Building : ScriptableObject
{
    public new string name;

    public int cost;
    public Image resource1;
    public Image resource2;
    public Image resource3;
    public int[] resourceProduction0 = { 0, 0, 0 };
    public int[] resourceProduction1;
    public int[] resourceProduction2;
    public int[] resourceProduction3;
    public string resourceName1;
    public string resourceName2;
    public string resourceName3;

    public Sprite[] buildingSprite;

}
