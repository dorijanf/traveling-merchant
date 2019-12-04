using UnityEngine;
using UnityEngine.UI;

/*
 * Tooltip that appears when the user hovers over an item stored in his inventory
 */

public class Tooltip : MonoBehaviour
{
    private Text tooltip;

    private void Start()
    {
        tooltip = GetComponentInChildren<Text>();
        gameObject.SetActive(false);
    }

    public void GenerateTooltip(Item item)
    {
        string tooltipText = string.Format("<b>{0}</b>\n{1}\n", item.name, item.description);
        tooltip.text = tooltipText;
        gameObject.SetActive(true);
    }
}
