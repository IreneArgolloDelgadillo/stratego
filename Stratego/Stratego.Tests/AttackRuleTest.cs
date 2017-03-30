using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stratego.Playrules.Attack;
using Stratego.Pieces;

namespace Stratego.Tests
{
    [TestClass]
    public class AttackRuleTest
    {
        private IAttackRule rule;
        private Gamer juan, pedro;
        private Piece attacker, attacked;

        [TestInitialize]
        public void Inicialice()
        {
            juan = new Gamer("Juan");
            pedro = new Gamer("Pedro");
        }

        [TestMethod]
        public void TestVerifyAccepCriteriorToAttack()
        {
            rule = new RankRule();

            attacker = new Marshal(juan);
            attacked = new Miner(pedro);
            Assert.AreEqual(AttackResult.Win, rule.AcceptCriterion(attacker, attacked));
            
            attacker = new Coronel(juan);
            attacked = new Lake();
            Assert.AreEqual(AttackResult.NoAttack, rule.AcceptCriterion(attacker, attacked));

            attacker = new Spy(juan);
            attacked = new Flag(pedro);
            Assert.AreEqual(AttackResult.Win, rule.AcceptCriterion(attacker, attacked));

            attacker = new Coronel(juan);
            attacked = new General(pedro);
            Assert.AreEqual(AttackResult.Lose, rule.AcceptCriterion(attacker, attacked));

            attacker = new Lieutentaium(juan);
            attacked = new Lieutentaium(pedro);
            Assert.AreEqual(AttackResult.Draw, rule.AcceptCriterion(attacker, attacked));
        }

        [TestMethod]
        public void TestAttackCaseMarshalSpy()
        {
            rule = new StrategicAttackRule();

            attacker = new Spy(juan);
            attacked = new Marshal(pedro);
            Assert.AreEqual(AttackResult.Win, rule.AcceptCriterion(attacker, attacked));

            attacker = new Marshal(juan);
            attacked = new Spy(pedro);
            Assert.AreEqual(AttackResult.Win, rule.AcceptCriterion(attacker, attacked));
        }

        [TestMethod]
        public void TestAttackBombMiner()
        {
            rule = new ExplotionRule();

            attacker = new Miner(juan);
            attacked = new Bomb(pedro);
            Assert.AreEqual(AttackResult.Win, rule.AcceptCriterion(attacker, attacked));

            attacker = new Scout(juan);
            attacked = new Bomb(pedro);
            Assert.AreEqual(AttackResult.Win, rule.AcceptCriterion(attacker, attacked));
        }

    }
}
