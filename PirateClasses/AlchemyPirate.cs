using System;

namespace CharacterCreationSystem
{
    public class AlchemyPirate : Pirate
    {
        public AlchemyPirate() : base()
        {
            SetDefaultStats(50, 50, 50, 50, 50);
        }

        public void SetDefaultStats(int agility, int charisma, int health, int intelligence, int strength)
        {
            this.CharacterStats.Agility = agility;
            this.CharacterStats.Charisma = charisma;
            this.CharacterStats.Health = health;
            this.CharacterStats.Intelligence = intelligence;
            this.CharacterStats.Strength = strength;
        }


        public override void AdditionalAttack()
        {
            throw new NotImplementedException();
        }

        public override void MainAttack()
        {
            throw new NotImplementedException();
        }

        public override void NatureAttack()
        {
            throw new NotImplementedException();
        }

        public override void SecondAttack()
        {
            throw new NotImplementedException();
        }

        
    }
}