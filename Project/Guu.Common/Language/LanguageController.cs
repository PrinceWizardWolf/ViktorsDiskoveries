﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;

using SRML.SR;
using SRML.Utils;

namespace Guu.Language
{
	/// <summary>
	/// A controller to deal with language
	/// </summary>
	public static class LanguageController
	{
		// To lock the system before it actually reads the language
		// This prevents the auto select system from the game from loading files it can't yet access
		private static bool firstLock = true;

		// The current language to prevent the load for happening every time a scene changes
		private static MessageDirector.Lang? currLang = null;

		/// <summary>
		/// Sets the translations from the language file for the current language
		/// <para>This will load keys from the language file and add them to
		/// the game's translation directly</para>
		/// </summary>
		/// <param name="yourAssembly">The assembly you want to get it from 
		/// (if null will get the relevant assembly for your mod)</param>
		[SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
		public static void SetTranslations(Assembly yourAssembly = null)
		{
			if (firstLock)
			{
				firstLock = false;
				return;
			}

			MessageDirector.Lang lang = (MessageDirector.Lang)GameContext.Instance.AutoSaveDirector.ProfileManager.Settings.options.language;

			if (Levels.isMainMenu() || currLang == lang)
				return;

			Assembly assembly = yourAssembly ?? ReflectionUtils.GetRelevantAssembly();
			string code = lang.ToString().ToLower();

			string codeBase = assembly.CodeBase;
			UriBuilder uri = new UriBuilder(codeBase);
			string path = Uri.UnescapeDataString(uri.Path);
			
			FileInfo langFile = new FileInfo(Path.Combine(Path.GetDirectoryName(path), $"Resources\\Lang\\{code}.yaml"));

			using (StreamReader reader = new StreamReader(langFile.FullName))
			{
				foreach (string line in reader.ReadToEnd().Split('\n'))
				{
					if (!line.StartsWith("@import ")) continue;
					
					string imp = line.Replace("@import ", "").Trim().Replace("/", "\\");
					FileInfo extFile = new FileInfo(Path.Combine(Path.GetDirectoryName(path), $"Resources\\Lang\\{code}\\{imp}"));

					if (extFile.Exists)
						SetTranslations(extFile);
				}
			}

			currLang = lang;
		}

		/// <summary>
		/// Sets the translations from a language file for the current language
		/// <para>USE THIS ONLY FOR CUSTOM OR EXTERNAL FILES</para>
		/// </summary>
		/// <param name="file">The language file to load</param>
		[SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
		public static void SetTranslations(FileInfo file)
		{
			using (StreamReader reader = new StreamReader(file.FullName))
			{
				foreach (string line in reader.ReadToEnd().Split('\n'))
				{
					if (line.StartsWith("@import "))
					{
						string imp = line.Replace("@import ", "").Trim().Replace("/", "\\");
						FileInfo extFile = new FileInfo(Path.Combine(file.DirectoryName, imp));

						if (extFile.Exists)
							SetTranslations(extFile);
					}

					if (line.StartsWith("#") || line.Equals(string.Empty) || !line.Contains(":"))
						continue;

					string[] args = line.Split(':');
					TranslationPatcher.AddTranslationKey(args[0], args[1], args[2].TrimStart());
				}
			}
		}
	}
}
