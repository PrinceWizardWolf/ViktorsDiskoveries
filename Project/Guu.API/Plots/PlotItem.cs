﻿using System.Collections.Generic;

using SRML;
using SRML.SR;
using UnityEngine;

namespace Guu.API.Plots
{
	/// <summary>
	/// This is the base class for all plot items
	/// </summary>
	public abstract class PlotItem : RegistryItem<PlotItem>
	{
		// Instance Bound
		protected GameObject Prefab { get; set; }

		// Abstracts
		protected abstract LandPlot.Id ID { get; }
		protected abstract GameObject UIPrefab { get; }
		protected abstract PediaDirector.Id PediaID { get; }
		
		// Virtual
		protected virtual string NamePrefix { get; } = "plot";
		protected virtual bool RegisterAsPurchasable { get; } = true;
		protected virtual int PlotCost { get; } = 0;
		
		protected virtual Sprite PlotIcon { get; } = null;
		protected virtual Sprite PlotImg { get; } = null;

		// Methods
		protected virtual bool IsUnlocked() => true;

		/// <summary>Registers the item into it's registry</summary>
		public override PlotItem Register()
		{
			Build();

			LookupRegistry.RegisterLandPlot(Prefab);
			if (RegisterAsPurchasable)
			{
				LandPlotRegistry.RegisterPurchasableLandPlot(new LandPlotRegistry.LandPlotShopEntry()
				{
					cost = PlotCost,
					icon = PlotIcon ?? SRObjects.MissingIcon,
					mainImg = PlotImg ?? PlotIcon ?? SRObjects.MissingImg,
					pediaId = PediaID,
					plot = ID,
					isUnlocked = IsUnlocked
				});
			}
			else
			{
				PediaRegistry.RegisterIdEntry(PediaID, PlotIcon ?? SRObjects.MissingIcon);
				PediaRegistry.SetPediaCategory(PediaID, PediaRegistry.PediaCategory.RANCH);
			}

			// TODO: Fix pedia behaviour

			return this;
		}

		/// <summary>
		/// Adds a new Upgrader to this plot
		/// </summary>
		/// <typeparam name="T">The type of upgrader to add</typeparam>
		/// <param name="config">The config method to configure it after being added</param>
		public void AddUpgrader<T>(System.Action<T> config) where T : PlotUpgrader
		{
			T upgrader = Prefab.AddComponent<T>();
			config?.Invoke(upgrader);
		}

		/// <summary>
		/// Adds a new plot object to this plot
		/// </summary>
		/// <param name="templateObj">The template object</param>
		/// <param name="pos">The position to align with (or null for default)</param>
		/// <param name="rot">The rotation to rotate by (or null for default)</param>
		public void AddPlotObject(GameObject templateObj, Vector3? pos, Vector3? rot)
		{
			GameObject obj = Object.Instantiate(templateObj, Prefab.transform);
			obj.transform.position = pos ?? Vector3.one;
			obj.transform.rotation = Quaternion.Euler(rot ?? Vector3.one);
		}
	}
}
