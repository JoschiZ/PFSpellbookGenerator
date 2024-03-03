﻿using System.Globalization;
using System.Reflection;
using System.Text;

namespace Shared;

public class Spell
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string School { get; set; } = "";
    public string SubSchool { get; set; } = "";
    public string Descriptor { get; set; } = "";
    public string CastingTime { get; set; } = "";
    public string Components { get; set; } = "";
    public string Range { get; set; } = "";
    public string Area { get; set; } = "";
    public string Targets { get; set; } = "";
    public string Duration { get; set; } = "";
    public string SavingThrow { get; set; } = "";
    public string SpellResistance { get; set; } = "";
    public string DescriptionFormatted { get; set; } = "";
    public SpellGrades SpellGrades { get; set; } = new();
    public string ShortDescription { get; set; } = "";
    public string Source { get; set; } = "";
}

public class SpellGrades
{
    public int? Sorcerer { get; set; }
    public int? Wizard { get; set; }
    public int? Cleric { get; set; }
    public int? Druid { get; set; }
    public int? Ranger { get; set; }
    public int? Bard { get; set; }
    public int? Paladin { get; set; }
    public int? Alchemist { get; set; }
    public int? Summoner { get; set; }
    public int? Witch { get; set; }
    public int? Inquisitor { get; set; }
    public int? Oracle { get; set; }
    public int? AntiPaladin { get; set; }
    public int? Magus { get; set; }
    public int? Adept { get; set; }
    public int? BloodRager { get; set; }
    public int? Shaman { get; set; }
    public int? Psychic { get; set; }
    public int? Medium { get; set; }
    public int? Mesmerist { get; set; }
    public int? Occultist { get; set; }
    public int? Spiritualist { get; set; }
    public int? Skald { get; set; }
    public int? Investigator { get; set; }
    public int? Hunter { get; set; }

    public int GetLowestSpellGrade()
    {
        var grades = typeof(SpellGrades).GetProperties(BindingFlags.Instance | BindingFlags.Public);
        return (int)grades
            .Select(info => (int?)info.GetValue(this))
            .Where(grade => grade.HasValue)
            .Min()!; // There is always at least on class with a non null value
    }

    public int? GetGradeForClass(CharacterClass characterClass) => characterClass switch
    {
        CharacterClass.AllSpells => GetLowestSpellGrade(),
        CharacterClass.Sorcerer => Sorcerer,
        CharacterClass.Wizard => Wizard,
        CharacterClass.Cleric => Cleric,
        CharacterClass.Druid => Druid,
        CharacterClass.Ranger => Ranger,
        CharacterClass.Bard => Bard,
        CharacterClass.Paladin => Paladin,
        CharacterClass.Alchemist => Alchemist,
        CharacterClass.Summoner => Summoner,
        CharacterClass.Witch => Witch,
        CharacterClass.Inquisitor => Inquisitor,
        CharacterClass.Oracle => Oracle,
        CharacterClass.AntiPaladin => AntiPaladin,
        CharacterClass.Magus => Magus,
        CharacterClass.Adept => Adept,
        CharacterClass.BloodRager => BloodRager,
        CharacterClass.Shaman => Shaman,
        CharacterClass.Psychic => Psychic,
        CharacterClass.Medium => Medium,
        CharacterClass.Mesmerist => Mesmerist,
        CharacterClass.Occultist => Occultist,
        CharacterClass.Spiritualist => Spiritualist,
        CharacterClass.Skald => Skald,
        CharacterClass.Investigator => Investigator,
        CharacterClass.Hunter => Hunter,
        _ => throw new ArgumentOutOfRangeException(nameof(characterClass), characterClass, null)
    };
}