using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gens : MonoBehaviour
{
    public static Gens Instance;

    [SerializeField] private int spawnTime;
    [SerializeField] private int energyDrain;
    [SerializeField] private int drainTime;
    [SerializeField] private int BlackOut;
    [SerializeField] private int CapBlackOut = -10;
    [SerializeField] private Color greyColor;
    [SerializeField] private Color defaultColor;

    [Header("OnGens")] 
    public int OnGenswood = 0;
    public int OnGensstone = 0;
    public int OnGenscopper = 0;
    public int OnGensiron = 0;
    public int OnGensgold = 0;
    public int Breakpoint = 0;

    //private variable
    private int _baseLv = 1;
    private bool _placed;
    private SpriteRenderer _spriteRend;
    private bool _isOut;
    //public variable
    public CostBuilding Building;
    [HideInInspector] public bool IsWork;

    #region Unity Method

    private void Awake()
    {
        _spriteRend = GetComponentInChildren<SpriteRenderer>();
        _isOut = false;
        IsWork = true;
    }

    private void OnMouseUp()
    {
        
        if (_placed)
        {
            return;
        }

        if (BuildingSystem.Instance.Placed)
        {
            switch (Building.NameBuilding)
            {
                case "Solar":
                case "Hydroelectricplant":
                case "Windmill":
                    StartCoroutine(energyGen());
                    break;
                case "Sawmill":
                    StartCoroutine(woodGen());
                    break;
                case "Stonemine":
                    StartCoroutine(stoneGen());
                    break;
                case "Coppermine":
                    StartCoroutine(copperGen());
                    break;
                case "Ironmine":
                    StartCoroutine(ironGen());
                    break;
                case "Goldmine":
                    StartCoroutine(goldGen());
                    break;
                case "Thermalplant":
                    StartCoroutine(energyGen());
                    StartCoroutine(thermalGen());
                    break;
            }
            if (StatsResource.TotalEnergy > CapBlackOut)
            {
                StatsResource.TotalEnergy -= energyDrain;
                _placed = true;
                GridBuildingSystem.Instance.IsSpawningObj = true;
            }
            else
            {
                StatsResource.TotalEnergy = CapBlackOut;
            }
        }
    }


    IEnumerator energyGen()
    {
        yield return new WaitForSeconds(spawnTime);
        StatsResource.TotalEnergy += (int)(_baseLv * Building.DeductENG);
    }

    IEnumerator woodGen()
    {
        yield return new WaitForSeconds(spawnTime);
        if (StatsResource.TotalEnergy > BlackOut)
        {
            _spriteRend.color = defaultColor;
            StatsResource.TotalWood += (int)(_baseLv * Building.DrainResource);
             OnGenswood -= (int)(_baseLv * Building.DrainResource);

             if (OnGenswood == Breakpoint)
             {
                _spriteRend.color = greyColor;
                yield break;
             }
        }
        else
        {
            _spriteRend.color = greyColor;
        }
        
        StartCoroutine(woodGen());
        
    }

    IEnumerator stoneGen()
    {
        yield return new WaitForSeconds(spawnTime);
        if (StatsResource.TotalEnergy > BlackOut)
        {
            _spriteRend.color = defaultColor;
            StatsResource.TotalStone += (int)(_baseLv * Building.DrainResource);
            OnGensstone -= (int)(_baseLv * Building.DrainResource);

            if (OnGensstone == Breakpoint)
            {
                _spriteRend.color = greyColor;
                yield break;
            }
        }
        else
        {
            _spriteRend.color = greyColor;
        }
        StartCoroutine(stoneGen());
    }

    IEnumerator copperGen()
    {
        yield return new WaitForSeconds(spawnTime);
        if (StatsResource.TotalEnergy > BlackOut)
        {
            _spriteRend.color = defaultColor;
            StatsResource.TotalCopper += (int)(_baseLv * Building.DrainResource);
            OnGenscopper -= (int)(_baseLv * Building.DrainResource);

            if (OnGenscopper == Breakpoint)
            {
                _spriteRend.color = greyColor;
                yield break;
            }
        }
        else
        {
            _spriteRend.color = greyColor;
        }
        StartCoroutine(copperGen());
    }

    IEnumerator ironGen()
    {
        yield return new WaitForSeconds(spawnTime);
        if (StatsResource.TotalEnergy > BlackOut)
        {
            _spriteRend.color = defaultColor;
            StatsResource.TotalIron += (int)(_baseLv * Building.DrainResource);
            OnGensiron -= (int)(_baseLv * Building.DrainResource);

            if (OnGensiron == Breakpoint)
            {
                _spriteRend.color = greyColor;
                yield break;
            }
        }
        else
        {
            _spriteRend.color = greyColor;
        }
        StartCoroutine(ironGen());
    }

    IEnumerator goldGen()
    {
        yield return new WaitForSeconds(spawnTime);
        if (StatsResource.TotalEnergy > BlackOut)
        {
            _spriteRend.color = defaultColor;
            StatsResource.TotalGold += (int)(_baseLv * Building.DrainResource);
            OnGensgold -= (int)(_baseLv * Building.DrainResource);

            if (OnGensgold == Breakpoint)
            {
                _spriteRend.color = greyColor;
                yield break;
            }
        }
        else
        {
            _spriteRend.color = greyColor;
        }
        StartCoroutine(goldGen());
    }

    public IEnumerator thermalGen()
    {
        yield return new WaitForSeconds(drainTime);
        
        if (StatsResource.TotalWood > Breakpoint )
        {
            if (_isOut)
            {
                StatsResource.TotalEnergy += Building.DeductENG;
                _isOut = false;
            }
            else
            {
                
                _spriteRend.color = defaultColor;
                StatsResource.TotalWood -= (int)(_baseLv * Building.DrainResource);
                if (StatsResource.TotalWood <= Breakpoint)
                {
                    StatsResource.TotalWood = Breakpoint;
                }
                IsWork = true;
                Debug.Log("Thermal" + IsWork);
            }
            
            
        }
        else
        {
            _spriteRend.color = greyColor;
            if (StatsResource.TotalWood <= Breakpoint && !_isOut)
            {
                StatsResource.TotalWood = Breakpoint;
                StatsResource.TotalEnergy -= Building.DeductENG;
                IsWork = false;
                _isOut = true;
                Debug.Log("Thermal" + IsWork);
            }
        }
       
        StartCoroutine(thermalGen());
    }

    
    
    #endregion
}