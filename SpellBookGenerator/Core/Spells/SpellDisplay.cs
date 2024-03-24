﻿using System.Text.Json.Serialization;
using Shared;

namespace SpellBookGenerator.Core.Spells;

public abstract class SpellDisplay<TSpell> where TSpell: ISpell
{
    
    private protected SpellDisplay(TSpell spell)
    {
        Spell = spell;
    }
    

    public TSpell Spell { get; set; }
    public int CurrentSpellLevel { get; set; }
    public abstract string RangeDisplay { get; set; }
    public abstract string ArchivesOfNethysUrl { get; init; }

    
    public abstract int GetCurrentSpellLevel(TSpell spell);

    private protected abstract string GetRangeDisplay(TSpell spellBase);
}