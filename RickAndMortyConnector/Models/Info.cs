﻿using System;
namespace RickAndMortyConnector.Models
{
	public class Info
	{
        public int count { get; set; }
        public int pages { get; set; }
        public string next { get; set; }
        public string prev { get; set; }

        public Info()
		{
		}
	}
}

