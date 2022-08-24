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
using UnityEngine;


namespace Articy.Littletown.GlobalVariables
{
    
    
    [Serializable()]
    [CreateAssetMenu(fileName="ArticyGlobalVariables", menuName="Create GlobalVariables", order=620)]
    public class ArticyGlobalVariables : BaseGlobalVariables
    {
        
        [SerializeField()]
        [HideInInspector()]
        private Harry mHarry = new Harry();
        
        [SerializeField()]
        [HideInInspector()]
        private Emily mEmily = new Emily();
        
        [SerializeField()]
        [HideInInspector()]
        private Shihuangren mShihuangren = new Shihuangren();
        
        [SerializeField()]
        [HideInInspector()]
        private Player mPlayer = new Player();
        
        [SerializeField()]
        [HideInInspector()]
        private day_and_time mDay_and_time = new day_and_time();
        
        #region Initialize static VariableName set
        static ArticyGlobalVariables()
        {
            variableNames.Add("Harry.NextState");
            variableNames.Add("Harry.Refresh");
            variableNames.Add("Harry.Action");
            variableNames.Add("Harry.Expression");
            variableNames.Add("Emily.NextState");
            variableNames.Add("Emily.Refresh");
            variableNames.Add("Emily.Expression");
            variableNames.Add("Emily.Action");
            variableNames.Add("Shihuangren.NextState");
            variableNames.Add("Shihuangren.Refresh");
            variableNames.Add("Shihuangren.Action");
            variableNames.Add("Player.Action");
            variableNames.Add("Player.Expression");
            variableNames.Add("day_and_time.days");
            variableNames.Add("day_and_time.hours");
            variableNames.Add("day_and_time.minutes");
            variableNames.Add("day_and_time.seconds");
        }
        #endregion
        
        public Harry Harry
        {
            get
            {
                return mHarry;
            }
        }
        
        public Emily Emily
        {
            get
            {
                return mEmily;
            }
        }
        
        public Shihuangren Shihuangren
        {
            get
            {
                return mShihuangren;
            }
        }
        
        public Player Player
        {
            get
            {
                return mPlayer;
            }
        }
        
        public day_and_time day_and_time
        {
            get
            {
                return mDay_and_time;
            }
        }
        
        public static ArticyGlobalVariables Default
        {
            get
            {
                return ((ArticyGlobalVariables)(Articy.Unity.ArticyDatabase.DefaultGlobalVariables));
            }
        }
        
        public override void Init()
        {
            Harry.RegisterVariables(this);
            Emily.RegisterVariables(this);
            Shihuangren.RegisterVariables(this);
            Player.RegisterVariables(this);
            day_and_time.RegisterVariables(this);
        }
        
        public static ArticyGlobalVariables CreateGlobalVariablesClone()
        {
            return Articy.Unity.BaseGlobalVariables.CreateGlobalVariablesClone<ArticyGlobalVariables>();
        }
    }
}
