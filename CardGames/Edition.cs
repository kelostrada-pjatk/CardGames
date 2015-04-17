﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    public class Edition
    {
        public string Name { get; private set; }
        public int YearOfRelease { get; private set; }
        public Game Game { get; private set; }
        public CardList CardList { get; private set; }

        public Edition(Game game, string name, int yearOfRelease)
        {
            Game = game;
            Game.AddEdition(this);
            Name = name;
            YearOfRelease = yearOfRelease;
            CardList = new CardList();
        }


    }
}