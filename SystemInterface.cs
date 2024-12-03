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
        void MainAttack();
        void SecondAttack();
        void NatureAttack();
        void AdditionalAttack();
    }

    public interface IDefend
    {

    }

    public interface IHeal
    {

    }
}