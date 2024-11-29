using System;

namespace CharacterCreationSystem
{
    public interface IInformation
    {
        CharacterInfo CharacterInfo { get; set; }
        CharacterStats CharacterStats { get; set; }
        CharacterTraits CharacterTraits { get; set; }
    }

    public interface IAttack
    {
        void MainWeapon();
        void SecondarySkill();
        void NaturalSkill();
        void AdditionalSkill();
    }

    public interface IDefend
    {

    }

    public interface IHeal
    {

    }
}