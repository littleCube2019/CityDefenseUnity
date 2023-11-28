using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillTreeSystem<TSkill>
{
    public event EventHandler OnSkillChange;
    List<TSkill> totalSkill;
    List<TSkill> unLockList;
    List<TSkill> lockList;
    Dictionary<TSkill, List<TSkill>> requireSkillDict;
    public SkillTreeSystem(List<TSkill> unlockList, List<TSkill> lockList) { 
        this.unLockList = new List<TSkill>(unlockList);
        this.lockList = new List<TSkill>(lockList);
        this.totalSkill= new List<TSkill>();
        totalSkill.AddRange(unlockList);
        totalSkill.AddRange(lockList);
        requireSkillDict = new Dictionary<TSkill, List<TSkill>>();
        foreach(TSkill skill in totalSkill)
        {
            requireSkillDict[skill] = new List<TSkill>();
        }
    }
    public SkillTreeSystem(List<TSkill> totalSkill)
    {
        this.unLockList = new List<TSkill>();
        this.lockList = new List<TSkill>(totalSkill);
        this.totalSkill = new List<TSkill>(totalSkill);
        requireSkillDict = new Dictionary<TSkill, List<TSkill>>();
        foreach (TSkill skill in totalSkill)
        {
            requireSkillDict[skill] = new List<TSkill>();
        }
    }
    public void SetRequireSkill(TSkill skill, List<TSkill> requireSkill)
    {
        this.requireSkillDict[skill] = requireSkill;
    }
    public bool TryUnlock(TSkill skill)
    {
        if(IsUnlock(skill)) return false;
        if(CanUnlock(skill))
        {
            Unlock(skill);
            return true;
        }
        return false;
    }
    public bool CanUnlock(TSkill skill)
    {
        return requireSkillDict[skill].All(s => unLockList.Contains(s));
    }
    public void Unlock(TSkill skill)
    {
        if(lockList.Contains(skill)) lockList.Remove(skill);
        if(!unLockList.Contains(skill)) unLockList.Add(skill);
        OnSkillChange?.Invoke(this, EventArgs.Empty);
    }
    public bool IsUnlock(TSkill skill)
    {
        //return unLockList.Contains(skill);
        return !lockList.Contains(skill);
    }
    public void GetSkillTreeData(out List<TSkill> unLockList, out List<TSkill>  lockList)
    {
        unLockList = this.unLockList;
        lockList = this.lockList;
    }
}
