﻿using System.Collections.Generic;
using VikDisk.Handlers;

namespace VikDisk
{
	public static class Configs
	{
		//---------------------------------------------------
		// FOOD RELATED
		//---------------------------------------------------

		public static class Food
		{
			// CONSTANTS
			public const int FAV_PROD = 2; // Amount produced by normal favorite foods
			public const int SCI_PROD = 6; // Amount of slime resources produced by Kookadoba and Spicy Tofu
			public const int GF_PROD = 3; // Amount produced by Gilded Ginger

			// KOOKADOBA FOOD RESULTS
			// KEY = TARGET; VALUE = NEW RESULT
			public static readonly Dictionary<Identifiable.Id, Identifiable.Id> kookaResults = new Dictionary<Identifiable.Id, Identifiable.Id>
			{
				{
					Identifiable.Id.PINK_PLORT,
					Identifiable.Id.JELLYSTONE_CRAFT
				},
				{
					Identifiable.Id.ROCK_PLORT,
					Identifiable.Id.SLIME_FOSSIL_CRAFT
				},
				{
					Identifiable.Id.PHOSPHOR_PLORT,
					Identifiable.Id.DEEP_BRINE_CRAFT
				},
				{
					Identifiable.Id.TABBY_PLORT,
					Identifiable.Id.ROYAL_JELLY_CRAFT
				},
				{
					Identifiable.Id.RAD_PLORT,
					Identifiable.Id.SPIRAL_STEAM_CRAFT
				},
				{
					Identifiable.Id.HONEY_PLORT,
					Identifiable.Id.WILD_HONEY_CRAFT
				},
				{
					Identifiable.Id.BOOM_PLORT,
					Identifiable.Id.LAVA_DUST_CRAFT
				},
				{
					Identifiable.Id.CRYSTAL_PLORT,
					Identifiable.Id.GLASS_SHARD_CRAFT
				},
				{
					Identifiable.Id.QUANTUM_PLORT,
					Identifiable.Id.PRIMORDY_OIL_CRAFT
				},
				{
					Identifiable.Id.DERVISH_PLORT,
					Identifiable.Id.SILKY_SAND_CRAFT
				},
				{
					Identifiable.Id.HUNTER_PLORT,
					Identifiable.Id.HEXACOMB_CRAFT
				},
				{
					Identifiable.Id.MOSAIC_PLORT,
					Identifiable.Id.INDIGONIUM_CRAFT
				},
				{
					Identifiable.Id.TANGLE_PLORT,
					Identifiable.Id.BUZZ_WAX_CRAFT
				},
				{
					Identifiable.Id.SABER_PLORT,
					Identifiable.Id.PEPPER_JAM_CRAFT
				}
			};

			// SPICY TOFU RESULTS
			// KEY = TARGET; VALUE = NEW RESULT
			public static readonly Dictionary<Identifiable.Id, Identifiable.Id> tofuResults = new Dictionary<Identifiable.Id, Identifiable.Id>
			{
				{
					Identifiable.Id.PINK_PLORT,
					Identifiable.Id.MANIFOLD_CUBE_CRAFT
				},
				{
					Identifiable.Id.CRYSTAL_PLORT,
					Identifiable.Id.STRANGE_DIAMOND_CRAFT
				}
			};

			// PINK SLIME FAVORITES
			public static readonly List<Identifiable.Id> pinkFavs = new List<Identifiable.Id>
			{
				Identifiable.Id.CARROT_VEGGIE,
				Identifiable.Id.POGO_FRUIT,
				Identifiable.Id.HEN
			};

			// SABER SLIME FAVORITES
			public static readonly List<Identifiable.Id> saberFavs = new List<Identifiable.Id>
			{
				Identifiable.Id.ELDER_HEN,
				Identifiable.Id.ELDER_ROOSTER
			};

			// GROWABLES TO ADD TO GARDENS
			// KEY = STUFF TO GROW; VALUE = IS VEGETABLE?
			public static readonly Dictionary<Identifiable.Id, bool> growables = new Dictionary<Identifiable.Id, bool>
			{
				{
					Identifiable.Id.KOOKADOBA_FRUIT,
					false
				},
				{
					Identifiable.Id.GINGER_VEGGIE,
					true
				}
			};
		}

		//---------------------------------------------------
		// MAIL RELATED
		//---------------------------------------------------

		public static class Mails
		{
			// ALL MAIL KEYS
			public const string INTRO_MAIL_KEY = "ViktorIntro";

			// MAIL INFOS
			public static readonly List<MailHandler.MailInfo> mails = new List<MailHandler.MailInfo>
			{
				new MailHandler.MailInfo(INTRO_MAIL_KEY, "New Findings on Slimes!!", "Viktor Humphries")
			};
		}
	}
}
