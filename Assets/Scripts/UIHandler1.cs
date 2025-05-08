using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class UIHandler1 : MonoBehaviour
{
   private VisualElement m_Healthbar;
   public static UIHandler1 instance { get; private set; }


   // Awake is called when the script instance is being loaded (in this situation, when the game scene loads)
   private void Awake()
   {
       instance = this;
   }




   // Start is called before the first frame update
   void Start()
   {
       UIDocument uiDocument = GetComponent<UIDocument>();
       m_Healthbar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
       SetHealthValue(1.0f);
   }




   public void SetHealthValue(float percentage)
   {
       m_Healthbar.style.width = Length.Percent(100 * percentage);


   }


}
