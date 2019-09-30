using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Rpg.Svn.Api.Extensions;

namespace Rpg.Svn.Thirdparty.Facades
{
    class MonsterFactory
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
        public List<IWebElement> Attributes { get; set; }

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
        public List<IWebElement> Tidbits { get; set; }


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

        private const string HEADER_CLASSNAME = "mon-stat-block__header";
        private const string ATTRIBUTES_XPATH = "//div/div[@class='mon-stat-block__attribute']";
        private const string ABILITIES_CLASSNAME = "ability-block";
        private const string TIDBITS_CLASSNAME = "mon-stat-block__tidbit";
        private const string ACTIONS_CLASSNAME = "mon-stat-block__description-block-content";
        private const string IMAGE_XPATH = "//div/a/img[@class='monster-image']";
        private const string DESCRIPTION_CLASSNAME = "mon-stat-block__description-block-content";

        public MonsterFactory(IWebElement monsterBlock)
        {
            Header = monsterBlock.GetElementByClassName(HEADER_CLASSNAME);
            Attributes = monsterBlock.GetElementsListByXpath(ATTRIBUTES_XPATH);
            Abilities = monsterBlock.GetElementByClassName(ABILITIES_CLASSNAME);
            Tidbits = monsterBlock.GetElementsListByClass(TIDBITS_CLASSNAME);
            Actions = monsterBlock.GetElementByClassName(ACTIONS_CLASSNAME);
            Image = monsterBlock.GetElementByXpath(IMAGE_XPATH);
            Description = monsterBlock.GetElementByClassName(DESCRIPTION_CLASSNAME);

            //Header = monsterBlock.FindElement(By.ClassName("mon-stat-block__header"));
            //Attributes = monsterBlock.FindElements(By.XPath("//div/div[@class='mon-stat-block__attribute']")).ToList();
            //Abilities = monsterBlock.FindElement(By.ClassName("ability-block"));
            //Tidbits = monsterBlock.FindElements(By.ClassName("mon-stat-block__tidbit")).ToList();
            //Actions = monsterBlock.FindElement(By.ClassName("mon-stat-block__description-block-content"));
            //Image = monsterBlock.FindElement(By.XPath("//div/a/img[@class='monster-image']"));
            //Description = monsterBlock.FindElement(By.ClassName("mon-stat-block__description-block-content"));
        }

        public Monster GenerateMonster()
        {
            var monster = new Monster()
            {
                Name = GetMonsterName(Header),
                SavingThrows = GetAttributeDictionary("Saving Throws", "tidbit", Tidbits),
                Skills = GetAttributeDictionary("Skills", "tidbit", Tidbits),
                ArmorClass = string.Join("", GetAttributeList("Armor Class", "attribute", Attributes).ToArray()),
                HitDies = GetAttributeList("Hit Points", "attribute", Attributes).ElementAt(1),
                HitPoints = GetAttributeList("Hit Points", "attribute", Attributes).FirstOrDefault(),
                DamageImunities = GetAttributeList("Damage Immunities", "tidbit", Tidbits),
                Senses = GetAttributeList("Senses", "tidbit", Tidbits),
                Languages = GetAttributeList("Languages", "tidbit", Tidbits),
                Challenge = string.Join("", GetAttributeList("Challenge", "tidbit", Tidbits).ToArray()),
                Alignment = GetMonsterAlignment(),
                Size = GetMonsterSize(),
                Type = GetMonsterType(),
                ImgUrl = Image.GetAttribute("src")
            };

            return monster;
        }

        private Dictionary<string, string> GetBlockDict(string label, List<IWebElement> elements)
        {
            var dict = new Dictionary<string, string>();
            foreach (var element in elements)
            {
                var component = new KeyValuePair<string, string>(element.GetElementByClassName("mon-stat-block__" + label + "-label").Text,
                                                              (label.Equals("attribute") ? element.GetElementByClassName("mon-stat-block__" + label + "-data-value").Text + ", " +
                                                              (element.GetElementByClassName("mon-stat-block__" + label + "-data-extra") is null ? "" :
                                                              element.GetElementByClassName("mon-stat-block__" + label + "-data-extra").Text) :
                                                              element.GetElementByClassName("mon-stat-block__" + label + "-data").Text));
                dict.Add(component.Key, component.Value);
            }

            return dict;
        }

        private IEnumerable<string> GetAttributeList(string label, string component, List<IWebElement> element)
        {
            GetBlockDict(component, element).TryGetValue(label, out var labelElement);
            char[] separators = { ',', ';' };
            var elementsList = labelElement.Replace("and","").Split(separators).ToList();
            elementsList.RemoveAll(s => s.Equals(""));
            //elementsList.ForEach(s => s.Trim());
            return elementsList;
        }

        private Dictionary<string, string> GetAttributeDictionary(string label, string component, List<IWebElement> element)
        {
            GetBlockDict(component, element).TryGetValue(label, out var labelElement);
            if (labelElement is null)
                return null;

            var attList = labelElement.Split(",").ToList();

            var attribute = new Dictionary<string, string>();
            foreach (var att in attList)
            {
                var atrib = att.Split(" ").ToList();
                atrib.RemoveAll(s => s.Equals(""));
                attribute.Add(atrib[0], atrib[1]);
            }
            return attribute;
        }
        private string GetMonsterName(IWebElement monsterElement) => monsterElement.FindElement(By.ClassName("mon-stat-block__name-link")).Text;
        private IEnumerable<string> GetMonsterHeaderList(IWebElement monsterElement) => monsterElement.FindElement(By.ClassName("mon-stat-block__meta")).Text.Split(",").ToList();
        private string GetMonsterAlignment() => GetMonsterHeaderList(Header).ElementAt(1);
        private string GetMonsterType() => GetMonsterHeaderList(Header).ElementAt(0).Split(" ").ElementAt(1);
        private string GetMonsterSize() => GetMonsterHeaderList(Header).ElementAt(0).Split(" ").ElementAt(0);
    }
}

