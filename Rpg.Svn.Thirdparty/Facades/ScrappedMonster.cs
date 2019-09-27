using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Rpg.Svn.Thirdparty.Facades
{
    class ScrappedMonster
    {
        /// <summary>
        /// Receives the Header block of the monster's sheet.
        /// </summary>
        /// Contains:
        /// Size, Type and Alignment
        /// <returns></returns>
        public IWebElement Header { get; set; }

        /// <summary>
        /// Receives the Attributes block of the monster's sheet.
        /// </summary>
        /// Contains:
        /// Armor Class, Hit points and Speed.
        /// <returns></returns>
        public IWebElement Attributes { get; set; }

        /// <summary>
        /// Receives the Abilities block of the monster's sheet.
        /// </summary>
        /// Contains:
        /// Strenght, Dexterity, Constitution, Intelligence, Wisdom, Charisma.
        /// <returns></returns>
        public IWebElement Abilities { get; set; }


        /// <summary>
        /// Receives the Tidbit block values of the monster's sheet.
        /// </summary>
        /// Contains:
        /// Saving throws, Skills, Damage Immunities, Senses, Languages, Challenge level.
        /// <returns></returns>
        public IWebElement Tidbits { get; set; }


        /// <summary>
        /// Receives the Actions descriptions of the monster's sheet.
        /// </summary>
        /// Contains:
        /// Actions.
        /// <returns></returns>
        public IWebElement Actions { get; set; }


        /// <summary>
        /// Receives the Image block of the monster's sheet.
        /// </summary>
        /// <returns></returns>
        public IWebElement Image { get; set; }


        /// <summary>
        /// Receives the Description block of the monster's sheet.
        /// </summary>
        /// <returns></returns>
        public IWebElement Description { get; set; }

        public ScrappedMonster(IWebElement monsterBlock)
        {
           Header = monsterBlock.FindElement(By.XPath("//div/div[@class='mon-stat-block__header']"));
           Attributes = monsterBlock.FindElement(By.XPath("//div/div[@class='mon-stat-block__attributes']"));
           Abilities = monsterBlock.FindElement(By.XPath("//div/div/div[@class='ability-block']"));
           Tidbits = monsterBlock.FindElement(By.ClassName("mon-stat-block__tidbit"));
           Actions = monsterBlock.FindElement(By.XPath("//div/div/div[@class='mon-stat-block__description-block-content']"));
           Image = monsterBlock.FindElement(By.XPath("//div/a/img[@class='monster-image']"));
           Description = monsterBlock.FindElement(By.XPath("//div/div/div/div[@class='mon-stat-block__description-block-content']"));


        }

        public Monster GenerateMonsterObjetct()
        {
            return new Monster();
        }
    }
}

