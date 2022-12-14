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
        
        [SerializeField()]
        [HideInInspector()]
        private Alex mAlex = new Alex();
        
        [SerializeField()]
        [HideInInspector()]
        private AFather mAFather = new AFather();
        
        [SerializeField()]
        [HideInInspector()]
        private Ason mAson = new Ason();
        
        [SerializeField()]
        [HideInInspector()]
        private Grandma_0 mGrandma_0 = new Grandma_0();
        
        [SerializeField()]
        [HideInInspector()]
        private Grandma_1 mGrandma_1 = new Grandma_1();
        
        [SerializeField()]
        [HideInInspector()]
        private Grandma_2 mGrandma_2 = new Grandma_2();
        
        [SerializeField()]
        [HideInInspector()]
        private Grandpa_0 mGrandpa_0 = new Grandpa_0();
        
        [SerializeField()]
        [HideInInspector()]
        private Grandpa_1 mGrandpa_1 = new Grandpa_1();
        
        [SerializeField()]
        [HideInInspector()]
        private Wasang mWasang = new Wasang();
        
        [SerializeField()]
        [HideInInspector()]
        private Kaka mKaka = new Kaka();
        
        [SerializeField()]
        [HideInInspector()]
        private Lisa mLisa = new Lisa();
        
        [SerializeField()]
        [HideInInspector()]
        private Pidan mPidan = new Pidan();
        
        [SerializeField()]
        [HideInInspector()]
        private Hegel mHegel = new Hegel();
        
        [SerializeField()]
        [HideInInspector()]
        private Qingjiedashen mQingjiedashen = new Qingjiedashen();
        
        [SerializeField()]
        [HideInInspector()]
        private GlobalVariables mGlobalVariables = new GlobalVariables();
        
        [SerializeField()]
        [HideInInspector()]
        private PidanMom mPidanMom = new PidanMom();
        
        [SerializeField()]
        [HideInInspector()]
        private BigAunt mBigAunt = new BigAunt();
        
        [SerializeField()]
        [HideInInspector()]
        private TheWife mTheWife = new TheWife();
        
        [SerializeField()]
        [HideInInspector()]
        private TheHusband mTheHusband = new TheHusband();
        
        [SerializeField()]
        [HideInInspector()]
        private Hebaodan mHebaodan = new Hebaodan();
        
        [SerializeField()]
        [HideInInspector()]
        private KakaMom mKakaMom = new KakaMom();
        
        [SerializeField()]
        [HideInInspector()]
        private Bunny mBunny = new Bunny();
        
        [SerializeField()]
        [HideInInspector()]
        private Police mPolice = new Police();
        
        [SerializeField()]
        [HideInInspector()]
        private BunnyMom mBunnyMom = new BunnyMom();
        
        [SerializeField()]
        [HideInInspector()]
        private BigUncle mBigUncle = new BigUncle();
        
        [SerializeField()]
        [HideInInspector()]
        private Dialogue mDialogue = new Dialogue();
        
        [SerializeField()]
        [HideInInspector()]
        private Slavoj mSlavoj = new Slavoj();
        
        [SerializeField()]
        [HideInInspector()]
        private Lacan mLacan = new Lacan();
        
        [SerializeField()]
        [HideInInspector()]
        private Scavenger mScavenger = new Scavenger();
        
        [SerializeField()]
        [HideInInspector()]
        private GarbageStaff mGarbageStaff = new GarbageStaff();
        
        [SerializeField()]
        [HideInInspector()]
        private CatGG mCatGG = new CatGG();
        
        [SerializeField()]
        [HideInInspector()]
        private Memo mMemo = new Memo();
        
        #region Initialize static VariableName set
        static ArticyGlobalVariables()
        {
            variableNames.Add("Harry.NextState");
            variableNames.Add("Harry.Refresh");
            variableNames.Add("Harry.Action");
            variableNames.Add("Harry.Expression");
            variableNames.Add("Harry.disappear");
            variableNames.Add("Emily.NextState");
            variableNames.Add("Emily.Refresh");
            variableNames.Add("Emily.Expression");
            variableNames.Add("Emily.Action");
            variableNames.Add("Emily.TalkTimes");
            variableNames.Add("Emily.Favorability");
            variableNames.Add("Emily.TalkTimesWithPlayerFindingAlex");
            variableNames.Add("Emily.knowSlavojNearDeath");
            variableNames.Add("Emily.Flavorability");
            variableNames.Add("Emily.FromState");
            variableNames.Add("Emily.AddLollipop");
            variableNames.Add("Emily.Present");
            variableNames.Add("Emily.Disappear");
            variableNames.Add("Emily.Absence");
            variableNames.Add("Emily.SummonLacanSuccess");
            variableNames.Add("Emily.CheckTime");
            variableNames.Add("Shihuangren.NextState");
            variableNames.Add("Shihuangren.Refresh");
            variableNames.Add("Shihuangren.Action");
            variableNames.Add("Shihuangren.BeDrivenAway");
            variableNames.Add("Player.Action");
            variableNames.Add("Player.Expression");
            variableNames.Add("Player.haveBread");
            variableNames.Add("Player.haveWater");
            variableNames.Add("Player.knowRosmontis");
            variableNames.Add("Player.haveBadge");
            variableNames.Add("Player.haveMagicWand");
            variableNames.Add("Player.haveRosmontis");
            variableNames.Add("Player.haveShenguangbang");
            variableNames.Add("Player.haveTurtle");
            variableNames.Add("Player.haveUFO");
            variableNames.Add("Player.knowTownMayor");
            variableNames.Add("Player.haveBall");
            variableNames.Add("Player.knowRebuild");
            variableNames.Add("Player.metBigUncle");
            variableNames.Add("Player.heardHegel");
            variableNames.Add("Player.knowAlex");
            variableNames.Add("Player.knowHegel");
            variableNames.Add("Player.knowKaka");
            variableNames.Add("Player.knowLisa");
            variableNames.Add("Player.knowWasang");
            variableNames.Add("Player.metEmily");
            variableNames.Add("Player.metKaka");
            variableNames.Add("Player.metLisa");
            variableNames.Add("Player.metWasang");
            variableNames.Add("Player.MissionDogFound");
            variableNames.Add("Player.MissionLookForDog");
            variableNames.Add("Player.MissionLookForDogResult");
            variableNames.Add("Player.haveRadio");
            variableNames.Add("Player.haveBean");
            variableNames.Add("Player.haveHelpedBigAunt");
            variableNames.Add("Player.haveCheatedToLittleCouple");
            variableNames.Add("Player.knowPoliceOffice");
            variableNames.Add("Player.knowWasangsPurpose");
            variableNames.Add("Player.WantToHelpWasang");
            variableNames.Add("Player.haveTalkedWithWasangBeforeEmilyHome");
            variableNames.Add("Player.haveTalkedWithWasangBeforeBitten");
            variableNames.Add("Player.haveHair");
            variableNames.Add("Player.haveBeenBittenBySlavoj");
            variableNames.Add("Player.haveGivenHairToWasang");
            variableNames.Add("Player.haveFoundHair");
            variableNames.Add("Player.knowSlavojNearDeath");
            variableNames.Add("Player.haveAttendedWasang");
            variableNames.Add("Player.knowEmilyKnowSlavojNearDeath");
            variableNames.Add("Player.AccompanyWasangToApologize");
            variableNames.Add("Player.knowWasangApologize");
            variableNames.Add("Player.knowKakaHaveRadio");
            variableNames.Add("Player.knowWasangsPosion");
            variableNames.Add("Player.knowWasangCanSeeGhosts");
            variableNames.Add("Player.knowWasangCanTalkWithGhosts");
            variableNames.Add("Player.haveSuspectedKaka");
            variableNames.Add("Player.haveFinishedRadio");
            variableNames.Add("Player.haveMetAlexInForest");
            variableNames.Add("Player.haveMetAlexInLane");
            variableNames.Add("Player.knowPidan");
            variableNames.Add("Player.knowHebaodan");
            variableNames.Add("Player.haveFinishedTalkingWithEmilyInForest");
            variableNames.Add("Player.haveFinishedEmilyAndPidan");
            variableNames.Add("Player.haveTalkedWithEmilyAboutFindingAlex");
            variableNames.Add("Player.talkTimesInUselessCare");
            variableNames.Add("Player.haveKilledSlavoj");
            variableNames.Add("Player.attitudeToCureSlavoj");
            variableNames.Add("Player.talkTimesPhysicalExam");
            variableNames.Add("Player.knowBunnyLonely");
            variableNames.Add("Player.ReprimandPidan");
            variableNames.Add("Player.ComfortPidan");
            variableNames.Add("Player.SavedHegel");
            variableNames.Add("Player.knowEmilysResponce");
            variableNames.Add("Player.knowEmilyNeedHelp");
            variableNames.Add("Player.knowPidanWantAskEmilyForHelp");
            variableNames.Add("Player.FindPidanHelpEmily");
            variableNames.Add("Player.knowWasangLostMaterial");
            variableNames.Add("Player.knowLisaLoveBook");
            variableNames.Add("Player.knowEmilyNeedLisaHelp");
            variableNames.Add("Player.FindWasangHelpEmily");
            variableNames.Add("Player.haveWasangsMaterial");
            variableNames.Add("Player.DriveAwayPidanTalkTimes");
            variableNames.Add("Player.haveMedicine");
            variableNames.Add("Player.interveneKakaPickGarbage");
            variableNames.Add("Player.interveneKakaCantCollectEnoughBottle");
            variableNames.Add("Player.interveneLittleCoupleAndRadio");
            variableNames.Add("Player.haveAskedPoetsFrom");
            variableNames.Add("Player.knowBunny");
            variableNames.Add("day_and_time.days");
            variableNames.Add("day_and_time.hours");
            variableNames.Add("day_and_time.minutes");
            variableNames.Add("day_and_time.seconds");
            variableNames.Add("Alex.Action");
            variableNames.Add("Alex.Expression");
            variableNames.Add("Alex.NextState");
            variableNames.Add("Alex.Refresh");
            variableNames.Add("Alex.InterFereTimes");
            variableNames.Add("Alex.Disappear");
            variableNames.Add("AFather.Action");
            variableNames.Add("AFather.Expression");
            variableNames.Add("AFather.NextState");
            variableNames.Add("AFather.Refresh");
            variableNames.Add("Ason.Refresh");
            variableNames.Add("Ason.NextState");
            variableNames.Add("Ason.Action");
            variableNames.Add("Ason.Expression");
            variableNames.Add("Grandma_0.Action");
            variableNames.Add("Grandma_0.Expression");
            variableNames.Add("Grandma_0.NextState");
            variableNames.Add("Grandma_0.Refresh");
            variableNames.Add("Grandma_1.Action");
            variableNames.Add("Grandma_1.Expression");
            variableNames.Add("Grandma_1.NextState");
            variableNames.Add("Grandma_1.Refresh");
            variableNames.Add("Grandma_2.Action");
            variableNames.Add("Grandma_2.Expression");
            variableNames.Add("Grandma_2.NextState");
            variableNames.Add("Grandma_2.Refresh");
            variableNames.Add("Grandpa_0.Action");
            variableNames.Add("Grandpa_0.Expression");
            variableNames.Add("Grandpa_0.NextState");
            variableNames.Add("Grandpa_0.Refresh");
            variableNames.Add("Grandpa_1.Action");
            variableNames.Add("Grandpa_1.Expression");
            variableNames.Add("Grandpa_1.NextState");
            variableNames.Add("Grandpa_1.Refresh");
            variableNames.Add("Wasang.NextState");
            variableNames.Add("Wasang.Refresh");
            variableNames.Add("Wasang.Action");
            variableNames.Add("Wasang.Expression");
            variableNames.Add("Wasang.CountTimes");
            variableNames.Add("Wasang.SelectTimes");
            variableNames.Add("Wasang.InsectTimes");
            variableNames.Add("Wasang.GhostTimes");
            variableNames.Add("Wasang.GiveUpLookingForHair");
            variableNames.Add("Wasang.LookingForHairWithPlayer");
            variableNames.Add("Wasang.haveHair");
            variableNames.Add("Wasang.haveBeenBittenBySlavoj");
            variableNames.Add("Wasang.knowSlavojNearDeath");
            variableNames.Add("Wasang.ApologizeWithPlayerTogether");
            variableNames.Add("Wasang.ApologizeAlone");
            variableNames.Add("Wasang.BeFriendWithEmily");
            variableNames.Add("Wasang.CompleteCollection");
            variableNames.Add("Wasang.Disappear");
            variableNames.Add("Wasang.Absence");
            variableNames.Add("Wasang.GuaTimes");
            variableNames.Add("Kaka.NextState");
            variableNames.Add("Kaka.Refresh");
            variableNames.Add("Kaka.Action");
            variableNames.Add("Kaka.Expression");
            variableNames.Add("Kaka.EatEgg");
            variableNames.Add("Kaka.TalkSelf");
            variableNames.Add("Kaka.introductionToTwo");
            variableNames.Add("Kaka.TalkEgg");
            variableNames.Add("Kaka.RocketTimes");
            variableNames.Add("Kaka.DoubtKaka");
            variableNames.Add("Kaka.AskedSmell");
            variableNames.Add("Kaka.DoubtSmell");
            variableNames.Add("Kaka.Opinion");
            variableNames.Add("Kaka.Happiness");
            variableNames.Add("Kaka.Likeability");
            variableNames.Add("Kaka.DistubedTimes");
            variableNames.Add("Kaka.Disappear");
            variableNames.Add("Kaka.haveWrappedWasang");
            variableNames.Add("Kaka.knowPlayer");
            variableNames.Add("Kaka.TrashMorningState");
            variableNames.Add("Kaka.BackHomeEarly");
            variableNames.Add("Kaka.CollectBottles");
            variableNames.Add("Kaka.Delay");
            variableNames.Add("Kaka.PatienceofWorker");
            variableNames.Add("Kaka.Present");
            variableNames.Add("Kaka.Absence");
            variableNames.Add("Kaka.CollectEnoughBottles");
            variableNames.Add("Kaka.BottlesFarFromEnough");
            variableNames.Add("Kaka.BottlesNotEnough");
            variableNames.Add("Kaka.goSellHours");
            variableNames.Add("Kaka.goSellMinutes");
            variableNames.Add("Kaka.goSell");
            variableNames.Add("Kaka.haveRadio");
            variableNames.Add("Kaka.SellWasteSuccess");
            variableNames.Add("Lisa.NextState");
            variableNames.Add("Lisa.Refresh");
            variableNames.Add("Lisa.Action");
            variableNames.Add("Lisa.Expression");
            variableNames.Add("Lisa.Intervene");
            variableNames.Add("Lisa.Choose");
            variableNames.Add("Lisa.LisaReturnWithEase");
            variableNames.Add("Lisa.FollowPlayer");
            variableNames.Add("Pidan.NextState");
            variableNames.Add("Pidan.Refresh");
            variableNames.Add("Pidan.Action");
            variableNames.Add("Pidan.Expression");
            variableNames.Add("Pidan.Present");
            variableNames.Add("Pidan.TrashTimes");
            variableNames.Add("Pidan.knowPlayer");
            variableNames.Add("Pidan.Likeability");
            variableNames.Add("Pidan.disappear");
            variableNames.Add("Pidan.CurrentState");
            variableNames.Add("Pidan.FindBunny");
            variableNames.Add("Pidan.Absence");
            variableNames.Add("Pidan.doGood");
            variableNames.Add("Pidan.lost");
            variableNames.Add("Hegel.NextState");
            variableNames.Add("Hegel.Refresh");
            variableNames.Add("Hegel.Action");
            variableNames.Add("Hegel.Expression");
            variableNames.Add("Hegel.Health");
            variableNames.Add("Qingjiedashen.NextState");
            variableNames.Add("Qingjiedashen.Refresh");
            variableNames.Add("Qingjiedashen.Action");
            variableNames.Add("Qingjiedashen.Expression");
            variableNames.Add("GlobalVariables.Memo");
            variableNames.Add("GlobalVariables.RandomNum");
            variableNames.Add("PidanMom.NextState");
            variableNames.Add("PidanMom.Refresh");
            variableNames.Add("PidanMom.Action");
            variableNames.Add("PidanMom.Expression");
            variableNames.Add("BigAunt.NextState");
            variableNames.Add("BigAunt.Refresh");
            variableNames.Add("BigAunt.Action");
            variableNames.Add("BigAunt.Expression");
            variableNames.Add("TheWife.NextState");
            variableNames.Add("TheWife.Refresh");
            variableNames.Add("TheWife.Action");
            variableNames.Add("TheWife.Expression");
            variableNames.Add("TheWife.RadioState");
            variableNames.Add("TheHusband.NextState");
            variableNames.Add("TheHusband.Refresh");
            variableNames.Add("TheHusband.Action");
            variableNames.Add("TheHusband.Expression");
            variableNames.Add("TheHusband.InterferedWork");
            variableNames.Add("TheHusband.RadioState");
            variableNames.Add("Hebaodan.NextState");
            variableNames.Add("Hebaodan.Refresh");
            variableNames.Add("Hebaodan.Action");
            variableNames.Add("Hebaodan.Expression");
            variableNames.Add("KakaMom.NextState");
            variableNames.Add("KakaMom.Refresh");
            variableNames.Add("KakaMom.Action");
            variableNames.Add("KakaMom.Expression");
            variableNames.Add("Bunny.NextState");
            variableNames.Add("Bunny.Refresh");
            variableNames.Add("Bunny.Action");
            variableNames.Add("Bunny.Expression");
            variableNames.Add("Police.NextState");
            variableNames.Add("Police.Refresh");
            variableNames.Add("Police.Action");
            variableNames.Add("Police.Expression");
            variableNames.Add("BunnyMom.NextState");
            variableNames.Add("BunnyMom.Refresh");
            variableNames.Add("BunnyMom.Action");
            variableNames.Add("BunnyMom.Expression");
            variableNames.Add("BigUncle.NextState");
            variableNames.Add("BigUncle.Refresh");
            variableNames.Add("BigUncle.Action");
            variableNames.Add("BigUncle.Expression");
            variableNames.Add("BigUncle.talkChance");
            variableNames.Add("BigUncle.haveFinishedShenguangbang");
            variableNames.Add("BigUncle.AttentionNumberAlex");
            variableNames.Add("BigUncle.AttentionNumberKaka");
            variableNames.Add("BigUncle.feelHappy");
            variableNames.Add("Dialogue.fromWhoIsEmily1");
            variableNames.Add("Dialogue.fromWhoIsEmily2");
            variableNames.Add("Dialogue.fromWantToHelpWasang1");
            variableNames.Add("Dialogue.fromWhoIsEmily3");
            variableNames.Add("Dialogue.fromKakaCallRB");
            variableNames.Add("Dialogue.fromKakaAbourAlien");
            variableNames.Add("Dialogue.fromKakaPickGarbage");
            variableNames.Add("Dialogue.fromKakaAndEmily");
            variableNames.Add("Dialogue.fromPidanCareHegel");
            variableNames.Add("Dialogue.fromDontHit");
            variableNames.Add("Dialogue.toSpeakIllofKaka");
            variableNames.Add("Dialogue.toDpntHit");
            variableNames.Add("Dialogue.toDontHit");
            variableNames.Add("Dialogue.toFightFinished");
            variableNames.Add("Dialogue.playerFinishedChocolateWafer");
            variableNames.Add("Dialogue.fromPidanHitAlex");
            variableNames.Add("Dialogue.fromKakaGoToEmilyHome");
            variableNames.Add("Dialogue.fromSeeSprite");
            variableNames.Add("Dialogue.fromBeforeKakaSellGarbage");
            variableNames.Add("Slavoj.BeKilled");
            variableNames.Add("Slavoj.BeThrewAway");
            variableNames.Add("Slavoj.Died");
            variableNames.Add("Slavoj.BeHidden");
            variableNames.Add("Slavoj.NearDeath");
            variableNames.Add("Slavoj.NextState");
            variableNames.Add("Lacan.NextState");
            variableNames.Add("Lacan.Refresh");
            variableNames.Add("Lacan.Action");
            variableNames.Add("Lacan.Expression");
            variableNames.Add("Scavenger.NextState");
            variableNames.Add("Scavenger.Refresh");
            variableNames.Add("Scavenger.Action");
            variableNames.Add("Scavenger.Expression");
            variableNames.Add("GarbageStaff.NextState");
            variableNames.Add("GarbageStaff.Refresh");
            variableNames.Add("GarbageStaff.Action");
            variableNames.Add("GarbageStaff.Expression");
            variableNames.Add("GarbageStaff.atWork");
            variableNames.Add("GarbageStaff.offHours");
            variableNames.Add("GarbageStaff.offMinutes");
            variableNames.Add("CatGG.NextState");
            variableNames.Add("CatGG.Refresh");
            variableNames.Add("CatGG.Action");
            variableNames.Add("CatGG.Expression");
            variableNames.Add("Memo.AlexLoveBean");
            variableNames.Add("Memo.AlexTameCat");
            variableNames.Add("Memo.KnowAlex");
            variableNames.Add("Memo.KnowDeveloper");
            variableNames.Add("Memo.HerryEmilyArgue");
            variableNames.Add("Memo.HerryHitBottle");
            variableNames.Add("Memo.HerryEatRotApple");
            variableNames.Add("Memo.HerryEatIron");
            variableNames.Add("Memo.HerryDisappear");
            variableNames.Add("Memo.KnowEmilyFirst");
            variableNames.Add("Memo.FindAlex");
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
        
        public Alex Alex
        {
            get
            {
                return mAlex;
            }
        }
        
        public AFather AFather
        {
            get
            {
                return mAFather;
            }
        }
        
        public Ason Ason
        {
            get
            {
                return mAson;
            }
        }
        
        public Grandma_0 Grandma_0
        {
            get
            {
                return mGrandma_0;
            }
        }
        
        public Grandma_1 Grandma_1
        {
            get
            {
                return mGrandma_1;
            }
        }
        
        public Grandma_2 Grandma_2
        {
            get
            {
                return mGrandma_2;
            }
        }
        
        public Grandpa_0 Grandpa_0
        {
            get
            {
                return mGrandpa_0;
            }
        }
        
        public Grandpa_1 Grandpa_1
        {
            get
            {
                return mGrandpa_1;
            }
        }
        
        public Wasang Wasang
        {
            get
            {
                return mWasang;
            }
        }
        
        public Kaka Kaka
        {
            get
            {
                return mKaka;
            }
        }
        
        public Lisa Lisa
        {
            get
            {
                return mLisa;
            }
        }
        
        public Pidan Pidan
        {
            get
            {
                return mPidan;
            }
        }
        
        public Hegel Hegel
        {
            get
            {
                return mHegel;
            }
        }
        
        public Qingjiedashen Qingjiedashen
        {
            get
            {
                return mQingjiedashen;
            }
        }
        
        public GlobalVariables GlobalVariables
        {
            get
            {
                return mGlobalVariables;
            }
        }
        
        public PidanMom PidanMom
        {
            get
            {
                return mPidanMom;
            }
        }
        
        public BigAunt BigAunt
        {
            get
            {
                return mBigAunt;
            }
        }
        
        public TheWife TheWife
        {
            get
            {
                return mTheWife;
            }
        }
        
        public TheHusband TheHusband
        {
            get
            {
                return mTheHusband;
            }
        }
        
        public Hebaodan Hebaodan
        {
            get
            {
                return mHebaodan;
            }
        }
        
        public KakaMom KakaMom
        {
            get
            {
                return mKakaMom;
            }
        }
        
        public Bunny Bunny
        {
            get
            {
                return mBunny;
            }
        }
        
        public Police Police
        {
            get
            {
                return mPolice;
            }
        }
        
        public BunnyMom BunnyMom
        {
            get
            {
                return mBunnyMom;
            }
        }
        
        public BigUncle BigUncle
        {
            get
            {
                return mBigUncle;
            }
        }
        
        public Dialogue Dialogue
        {
            get
            {
                return mDialogue;
            }
        }
        
        public Slavoj Slavoj
        {
            get
            {
                return mSlavoj;
            }
        }
        
        public Lacan Lacan
        {
            get
            {
                return mLacan;
            }
        }
        
        public Scavenger Scavenger
        {
            get
            {
                return mScavenger;
            }
        }
        
        public GarbageStaff GarbageStaff
        {
            get
            {
                return mGarbageStaff;
            }
        }
        
        public CatGG CatGG
        {
            get
            {
                return mCatGG;
            }
        }
        
        public Memo Memo
        {
            get
            {
                return mMemo;
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
            Alex.RegisterVariables(this);
            AFather.RegisterVariables(this);
            Ason.RegisterVariables(this);
            Grandma_0.RegisterVariables(this);
            Grandma_1.RegisterVariables(this);
            Grandma_2.RegisterVariables(this);
            Grandpa_0.RegisterVariables(this);
            Grandpa_1.RegisterVariables(this);
            Wasang.RegisterVariables(this);
            Kaka.RegisterVariables(this);
            Lisa.RegisterVariables(this);
            Pidan.RegisterVariables(this);
            Hegel.RegisterVariables(this);
            Qingjiedashen.RegisterVariables(this);
            GlobalVariables.RegisterVariables(this);
            PidanMom.RegisterVariables(this);
            BigAunt.RegisterVariables(this);
            TheWife.RegisterVariables(this);
            TheHusband.RegisterVariables(this);
            Hebaodan.RegisterVariables(this);
            KakaMom.RegisterVariables(this);
            Bunny.RegisterVariables(this);
            Police.RegisterVariables(this);
            BunnyMom.RegisterVariables(this);
            BigUncle.RegisterVariables(this);
            Dialogue.RegisterVariables(this);
            Slavoj.RegisterVariables(this);
            Lacan.RegisterVariables(this);
            Scavenger.RegisterVariables(this);
            GarbageStaff.RegisterVariables(this);
            CatGG.RegisterVariables(this);
            Memo.RegisterVariables(this);
        }
        
        public static ArticyGlobalVariables CreateGlobalVariablesClone()
        {
            return Articy.Unity.BaseGlobalVariables.CreateGlobalVariablesClone<ArticyGlobalVariables>();
        }
    }
}
