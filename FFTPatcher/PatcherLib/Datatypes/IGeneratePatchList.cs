﻿using System.Collections.Generic;

namespace PatcherLib.Datatypes
{
    public interface IGeneratePatchList
    {
        bool[] ENTD { get; }
        bool FONT { get; }
        bool RegenECC { get; }
        string FileName { get; }
        bool Abilities { get; }
        bool AbilityEffects { get; }
        bool FontWidths { get; }
        bool MoveFindItems { get; }
        bool Items { get; }
        bool ItemAttributes { get; }
        bool Jobs { get; }
        bool JobLevels { get; }
        bool Skillsets { get; }
        bool MonsterSkills { get; }
        bool ActionMenus { get; }
        bool StatusAttributes { get; }
        bool InflictStatus { get; }
        bool Poach { get; }
        IList<PatchedByteArray> OtherPatches { get; }
        int PatchCount { get; }
    }

}