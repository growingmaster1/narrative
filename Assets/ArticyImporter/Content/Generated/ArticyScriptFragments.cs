//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Articy.Unity;
using Articy.Unity.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Articy.Littletown.GlobalVariables
{
    
    
    [Articy.Unity.ArticyCodeGenerationHashAttribute(637959969189243843)]
    public class ArticyScriptFragments : BaseScriptFragments, ISerializationCallbackReceiver
    {
        
        #region Fields
        private System.Collections.Generic.Dictionary<uint, System.Func<ArticyGlobalVariables, Articy.Unity.IBaseScriptMethodProvider, bool>> Conditions = new System.Collections.Generic.Dictionary<uint, System.Func<ArticyGlobalVariables, Articy.Unity.IBaseScriptMethodProvider, bool>>();
        
        private System.Collections.Generic.Dictionary<uint, System.Action<ArticyGlobalVariables, Articy.Unity.IBaseScriptMethodProvider>> Instructions = new System.Collections.Generic.Dictionary<uint, System.Action<ArticyGlobalVariables, Articy.Unity.IBaseScriptMethodProvider>>();
        #endregion
        
        #region Script fragments
        /// <summary>
        /// ObjectID: 0x100000000000154
        /// Articy Object ref: articy://localhost/view/2268d930-7d19-44b4-b43c-9b9130bf4733/72057594037928276?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x100000000000154Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.player_to_als.interfere == false && aGlobalVariablesState.als.bean==false;;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000000155
        /// Articy Object ref: articy://localhost/view/2268d930-7d19-44b4-b43c-9b9130bf4733/72057594037928277?pane=selected&amp;tab=current
        /// </summary>
        public void Script_0x100000000000155Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            aGlobalVariablesState.als.bean = true;;
        }
        
        /// <summary>
        /// ObjectID: 0x1000000000001CB
        /// Articy Object ref: articy://localhost/view/2268d930-7d19-44b4-b43c-9b9130bf4733/72057594037928395?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x1000000000001CBText(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.player_to_als.interfere == true && aGlobalVariablesState.als.bean == false;
;
        }
        
        /// <summary>
        /// ObjectID: 0x1000000000001E1
        /// Articy Object ref: articy://localhost/view/2268d930-7d19-44b4-b43c-9b9130bf4733/72057594037928417?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x1000000000001E1Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.player_to_als.interfere == true && aGlobalVariablesState.als.bean == true && aGlobalVariablesState.player_to_als.interfere_time <1;
;
        }
        
        /// <summary>
        /// ObjectID: 0x1000000000001E2
        /// Articy Object ref: articy://localhost/view/2268d930-7d19-44b4-b43c-9b9130bf4733/72057594037928418?pane=selected&amp;tab=current
        /// </summary>
        public void Script_0x1000000000001E2Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            aGlobalVariablesState.player_to_als.interfere_time += 1;;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000000221
        /// Articy Object ref: articy://localhost/view/2268d930-7d19-44b4-b43c-9b9130bf4733/72057594037928481?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x100000000000221Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.player_to_als.interfere == true && aGlobalVariablesState.als.bean == true && aGlobalVariablesState.player_to_als.interfere_time >= 1;
;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000000222
        /// Articy Object ref: articy://localhost/view/2268d930-7d19-44b4-b43c-9b9130bf4733/72057594037928482?pane=selected&amp;tab=current
        /// </summary>
        public void Script_0x100000000000222Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            aGlobalVariablesState.player_to_als.interfere_time += 1;;
        }
        
        /// <summary>
        /// ObjectID: 0x10000000000022D
        /// Articy Object ref: articy://localhost/view/2268d930-7d19-44b4-b43c-9b9130bf4733/72057594037928493?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x10000000000022DText(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.player_to_als.interfere == true && aGlobalVariablesState.player_to_als.interfere_time >= 1;
;
        }
        
        /// <summary>
        /// ObjectID: 0x10000000000022E
        /// Articy Object ref: articy://localhost/view/2268d930-7d19-44b4-b43c-9b9130bf4733/72057594037928494?pane=selected&amp;tab=current
        /// </summary>
        public void Script_0x10000000000022EText(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            aGlobalVariablesState.player_to_als.interfere_time += 1;;
        }
        
        /// <summary>
        /// ObjectID: 0x10000000000024A
        /// Articy Object ref: articy://localhost/view/2268d930-7d19-44b4-b43c-9b9130bf4733/72057594037928522?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x10000000000024AText(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.player_to_als.interfere == true && aGlobalVariablesState.player_to_als.interfere_time < 1;
;
        }
        
        /// <summary>
        /// ObjectID: 0x10000000000024B
        /// Articy Object ref: articy://localhost/view/2268d930-7d19-44b4-b43c-9b9130bf4733/72057594037928523?pane=selected&amp;tab=current
        /// </summary>
        public void Script_0x10000000000024BText(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            aGlobalVariablesState.player_to_als.interfere_time += 1;;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000000167
        /// Articy Object ref: articy://localhost/view/2268d930-7d19-44b4-b43c-9b9130bf4733/72057594037928295?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x100000000000167Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.day_and_time.weekend == true;;
        }
        
        /// <summary>
        /// ObjectID: 0x10000000000019A
        /// Articy Object ref: articy://localhost/view/2268d930-7d19-44b4-b43c-9b9130bf4733/72057594037928346?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x10000000000019AText(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.day_and_time.weekend == false;;
        }
        
        /// <summary>
        /// ObjectID: 0x1000000000014AE
        /// Articy Object ref: articy://localhost/view/2268d930-7d19-44b4-b43c-9b9130bf4733/72057594037933230?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x1000000000014AEText(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.WorldDialogue.poet_visible == false;
        }
        
        /// <summary>
        /// ObjectID: 0x10000000000165B
        /// Articy Object ref: articy://localhost/view/2268d930-7d19-44b4-b43c-9b9130bf4733/72057594037933659?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x10000000000165BText(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.WorldDialogue.poet_canSeeSprite == true;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000001661
        /// Articy Object ref: articy://localhost/view/2268d930-7d19-44b4-b43c-9b9130bf4733/72057594037933665?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x100000000001661Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return aGlobalVariablesState.WorldDialogue.poet_canSeeSprite == false;
        }
        
        /// <summary>
        /// ObjectID: 0x1000000000001EE
        /// Articy Object ref: articy://localhost/view/2268d930-7d19-44b4-b43c-9b9130bf4733/72057594037928430?pane=selected&amp;tab=current
        /// </summary>
        public void Script_0x1000000000001EEText(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            aGlobalVariablesState.player_to_als.interfere_time = 0;;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000000236
        /// Articy Object ref: articy://localhost/view/2268d930-7d19-44b4-b43c-9b9130bf4733/72057594037928502?pane=selected&amp;tab=current
        /// </summary>
        public void Script_0x100000000000236Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            aGlobalVariablesState.player_to_als.interfere_time = 0;;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000001623
        /// Articy Object ref: articy://localhost/view/2268d930-7d19-44b4-b43c-9b9130bf4733/72057594037933603?pane=selected&amp;tab=current
        /// </summary>
        public void Script_0x100000000001623Text(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            aGlobalVariablesState.WorldDialogue.poet_visible = true;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000000DBF
        /// Articy Object ref: articy://localhost/view/2268d930-7d19-44b4-b43c-9b9130bf4733/72057594037931455?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x100000000000DBFExpression(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return true;
        }
        
        /// <summary>
        /// ObjectID: 0x100000000000DC4
        /// Articy Object ref: articy://localhost/view/2268d930-7d19-44b4-b43c-9b9130bf4733/72057594037931460?pane=selected&amp;tab=current
        /// </summary>
        public bool Script_0x100000000000DC4Expression(ArticyGlobalVariables aGlobalVariablesState, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            return true;
        }
        #endregion
        
        #region Unity serialization
        public override void OnBeforeSerialize()
        {
        }
        
        public override void OnAfterDeserialize()
        {
            Conditions = new System.Collections.Generic.Dictionary<uint, System.Func<ArticyGlobalVariables, Articy.Unity.IBaseScriptMethodProvider, bool>>();
            Instructions = new System.Collections.Generic.Dictionary<uint, System.Action<ArticyGlobalVariables, Articy.Unity.IBaseScriptMethodProvider>>();
            Conditions.Add(1u, this.Script_0x100000000000154Text);
            Instructions.Add(2u, this.Script_0x100000000000155Text);
            Conditions.Add(3u, this.Script_0x1000000000001CBText);
            Conditions.Add(4u, this.Script_0x1000000000001E1Text);
            Instructions.Add(5u, this.Script_0x1000000000001E2Text);
            Conditions.Add(6u, this.Script_0x100000000000221Text);
            Instructions.Add(7u, this.Script_0x100000000000222Text);
            Conditions.Add(8u, this.Script_0x10000000000022DText);
            Instructions.Add(9u, this.Script_0x10000000000022EText);
            Conditions.Add(10u, this.Script_0x10000000000024AText);
            Instructions.Add(11u, this.Script_0x10000000000024BText);
            Conditions.Add(12u, this.Script_0x100000000000167Text);
            Conditions.Add(13u, this.Script_0x10000000000019AText);
            Conditions.Add(14u, this.Script_0x1000000000014AEText);
            Conditions.Add(15u, this.Script_0x10000000000165BText);
            Conditions.Add(16u, this.Script_0x100000000001661Text);
            Instructions.Add(17u, this.Script_0x1000000000001EEText);
            Instructions.Add(18u, this.Script_0x100000000000236Text);
            Instructions.Add(19u, this.Script_0x100000000001623Text);
            Conditions.Add(20u, this.Script_0x100000000000DBFExpression);
            Conditions.Add(21u, this.Script_0x100000000000DC4Expression);
        }
        #endregion
        
        #region Script execution
        public override void CallInstruction(Articy.Unity.Interfaces.IGlobalVariables aGlobalVariables, uint aHandlerId, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            if ((Instructions.ContainsKey(aHandlerId) == false))
            {
                return;
            }
            if ((aMethodProvider != null))
            {
                aMethodProvider.IsCalledInForecast = aGlobalVariables.IsInShadowState;
            }
            Instructions[aHandlerId].Invoke(((ArticyGlobalVariables)(aGlobalVariables)), aMethodProvider);
        }
        
        public override bool CallCondition(Articy.Unity.Interfaces.IGlobalVariables aGlobalVariables, uint aHandlerId, Articy.Unity.IBaseScriptMethodProvider aMethodProvider)
        {
            if ((Conditions.ContainsKey(aHandlerId) == false))
            {
                return true;
            }
            if ((aMethodProvider != null))
            {
                aMethodProvider.IsCalledInForecast = aGlobalVariables.IsInShadowState;
            }
            return Conditions[aHandlerId].Invoke(((ArticyGlobalVariables)(aGlobalVariables)), aMethodProvider);
        }
        #endregion
    }
}
