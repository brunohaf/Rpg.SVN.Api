using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Rpg.Svn.Api.Extensions;
using Rpg.Svn.Api.Interfaces;
using Rpg.Svn.Thirdparty.Models;

namespace Rpg.Svn.Thirdparty.Factories
{
    class MonsterFactory : IMonsterFactory
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
        private const string MONSTER_BASE_URL = "https://www.dndbeyond.com/monsters/";
        private const string ERROR_CLASS_NAME = "//div[@class='error-page error-page-404']";
        private const string MONSTER_MAIN_BLOCK_XPATH = "//div[@class='mon-stat-block']";
        private const string MONSTER_NAME_LINK = "mon-stat-block__name-link";
        private const string META_STAT_CLASSNAME = "mon-stat-block__meta";
        private const string MONSTER_STAT_BLOCK_PRIOR_CLASSNAME = "mon-stat-block__";

        private readonly IWebDriver _webDriver;

        public MonsterFactory(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public Monster GenerateMonster(string monsterName)
        {
            InitManufature(monsterName);

            var monster = new Monster()
            {
                Name = GetMonsterName(Header),
                SavingThrows = GetAttributeDictionary("Saving Throws", "tidbit", Tidbits),
                Skills = GetAttributeDictionary("Skills", "tidbit", Tidbits),
                ArmorClass = string.Join("", GetAttributeList("Armor Class", "attribute", Attributes).ToArray()),
                HitDies = GetAttributeList("Hit Points", "attribute", Attributes).ElementAt(1),
                HitPoints = GetAttributeList("Hit Points", "attribute", Attributes).FirstOrDefault(),
                DamageImunities = GetAttributeList("Damage Immunities", "tidbit", Tidbits),
                ConditionImunities = GetAttributeList("Condition Immunities", "tidbit", Tidbits),
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

        private Dictionary<string, string> GetBlockDict(string fieldIdentifier, List<IWebElement> elements)
        {
            var dict = new Dictionary<string, string>();
            foreach (var element in elements)
            {
                var component = new KeyValuePair<string, string>(BuildElementFromContextByClassName(element, fieldIdentifier, "-label").Text,
                                                                (fieldIdentifier.Equals("attribute") ?
                                                                 BuildElementFromContextByClassName(element, fieldIdentifier, "-data-value").Text + ", " +
                                                                (BuildElementFromContextByClassName(element, fieldIdentifier, "-data-extra") is null ?
                                                                "" :
                                                                BuildElementFromContextByClassName(element, fieldIdentifier, "-data-extra").Text) :
                                                                BuildElementFromContextByClassName(element, fieldIdentifier, "-data").Text));
                dict.Add(component.Key, component.Value);
            }

            return dict;
        }

        private IWebElement BuildElementFromContextByClassName(IWebElement element, string fieldIdentifier, string context)
        {
            return element.GetElementByClassName(MONSTER_STAT_BLOCK_PRIOR_CLASSNAME + fieldIdentifier + context);
        }

        private IEnumerable<string> GetAttributeList(string label, string component, List<IWebElement> element)
        {
            GetBlockDict(component, element).TryGetValue(label, out var labelElement);
            char[] separators = { ',', ';' };
            var elementsList = default(List<string>);
            if (!string.IsNullOrEmpty(labelElement))
            {
                elementsList = labelElement.Replace("and", "").Split(separators).ToList();
                elementsList.RemoveAll(s => string.IsNullOrEmpty(s));
                for (int i = 0; i < elementsList.Count; i++)
                {
                    elementsList[i] = elementsList[i].Trim();
                }
            }

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
                atrib.RemoveAll(s => string.IsNullOrEmpty(s));
                attribute.Add(atrib[0], atrib[1]);
            }

            return attribute;
        }
        private string ParseMonsterNameToSearchInput(string monsterName)
        {
            return monsterName.Replace(" ", "-").ToLower().Trim();
        }
        private IWebElement GetMonsterElement(string monsterName)
        {
            _webDriver.GoToUrl(MONSTER_BASE_URL + ParseMonsterNameToSearchInput(monsterName));

            if (_webDriver.GetElementByXpath(ERROR_CLASS_NAME) != null)
            {
                return null;
            }

            return _webDriver.GetElementByXpath(MONSTER_MAIN_BLOCK_XPATH);
        }

        private void InitManufature(string monsterName)
        {
            var monsterBlock = GetMonsterElement(monsterName);
            Header = monsterBlock.GetElementByClassName(HEADER_CLASSNAME);
            Attributes = monsterBlock.GetElementsListByXpath(ATTRIBUTES_XPATH);
            Abilities = monsterBlock.GetElementByClassName(ABILITIES_CLASSNAME);
            Tidbits = monsterBlock.GetElementsListByClass(TIDBITS_CLASSNAME);
            Actions = monsterBlock.GetElementByClassName(ACTIONS_CLASSNAME);
            Image = monsterBlock.GetElementByXpath(IMAGE_XPATH);
            Description = monsterBlock.GetElementByClassName(DESCRIPTION_CLASSNAME);
        }
        private string GetMonsterName(IWebElement monsterElement) => monsterElement.GetElementByClassName(MONSTER_NAME_LINK).Text;
        private IEnumerable<string> GetMonsterHeaderList(IWebElement monsterElement) => monsterElement.GetElementByClassName(META_STAT_CLASSNAME).Text.Split(",").ToList();
        private string GetMonsterAlignment() => GetMonsterHeaderList(Header).ElementAt(1);
        private string GetMonsterType() => GetMonsterHeaderList(Header).FirstOrDefault().Split(" ").ElementAt(1);
        private string GetMonsterSize() => GetMonsterHeaderList(Header).FirstOrDefault().Split(" ").FirstOrDefault();
    }
}

