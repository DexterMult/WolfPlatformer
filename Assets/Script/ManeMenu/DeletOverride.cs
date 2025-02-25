using UnityEngine;
using UnityEngine.UI;
public class DeletOverride : MonoBehaviour
{
	public int LVLnum; 
	public Image img;
	void Start()
	{
		if(PlayerPrefs.GetInt("ComplitLVL"+(LVLnum-1)) == 1)
		{
			img.enabled = false;
		}
		else if(LVLnum == 1)
		{
			img.enabled = false;
		}
	}
}
