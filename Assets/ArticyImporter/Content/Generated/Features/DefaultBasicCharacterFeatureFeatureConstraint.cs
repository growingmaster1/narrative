//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Articy.Littletown;
using Articy.Unity;
using Articy.Unity.Constraints;
using Articy.Unity.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Articy.Littletown.Features
{
    
    
    public class DefaultBasicCharacterFeatureFeatureConstraint
    {
        
        private Boolean mLoadedConstraints;
        
        private NumberConstraint mAge;
        
        private TextConstraint mSpecies;
        
        private TextConstraint mBornIn;
        
        private EnumConstraint mSex;
        
        private TextConstraint mOccupation;
        
        private TextConstraint mAccent;
        
        private TextConstraint mPersonality;
        
        private TextConstraint mAppearance;
        
        public NumberConstraint Age
        {
            get
            {
                EnsureConstraints();
                return mAge;
            }
        }
        
        public TextConstraint Species
        {
            get
            {
                EnsureConstraints();
                return mSpecies;
            }
        }
        
        public TextConstraint BornIn
        {
            get
            {
                EnsureConstraints();
                return mBornIn;
            }
        }
        
        public EnumConstraint Sex
        {
            get
            {
                EnsureConstraints();
                return mSex;
            }
        }
        
        public TextConstraint Occupation
        {
            get
            {
                EnsureConstraints();
                return mOccupation;
            }
        }
        
        public TextConstraint Accent
        {
            get
            {
                EnsureConstraints();
                return mAccent;
            }
        }
        
        public TextConstraint Personality
        {
            get
            {
                EnsureConstraints();
                return mPersonality;
            }
        }
        
        public TextConstraint Appearance
        {
            get
            {
                EnsureConstraints();
                return mAppearance;
            }
        }
        
        public virtual void EnsureConstraints()
        {
            if ((mLoadedConstraints == true))
            {
                return;
            }
            mLoadedConstraints = true;
            mAge = new Articy.Unity.Constraints.NumberConstraint(-3.40282346638529E+38D, 3.40282346638529E+38D, 0, 0, 0, null);
            mSpecies = new Articy.Unity.Constraints.TextConstraint(2048, "", null, true, false);
            mBornIn = new Articy.Unity.Constraints.TextConstraint(2048, "", null, true, false);
            mSex = new Articy.Unity.Constraints.EnumConstraint(true, "BySortIndex");
            mOccupation = new Articy.Unity.Constraints.TextConstraint(2048, "", null, true, false);
            mAccent = new Articy.Unity.Constraints.TextConstraint(2048, "", null, true, false);
            mPersonality = new Articy.Unity.Constraints.TextConstraint(2048, "", null, true, true);
            mAppearance = new Articy.Unity.Constraints.TextConstraint(2048, "", null, true, true);
        }
    }
}
