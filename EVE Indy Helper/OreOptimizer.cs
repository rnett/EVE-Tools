using EVE;
using Google.OrTools.LinearSolver;
using Newtonsoft.Json.Linq;
using SDEModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace CapitalBuildManagerApp
{
	public class OreOptimizer
	{

		private SDEEntities _sde;

		public Dictionary<ore, double> Prices { get; }

		public OreOptimizer(SDEEntities sde)
		{
			this._sde = sde;
			this.Prices = new Dictionary<ore, double>();
			try
			{
				string types = "";

				foreach (ore ore in _sde.ores)
				{
					types += ore.typeID + ",";

				}

				types = types.Substring(0, types.Length - 1);

				string json;
				using (WebClient wc = new WebClient())
				{
                    string url = "https://market.fuzzwork.co.uk/aggregates/?station=60003760&types=" + types;

                    json = wc.DownloadString(url);
				}

				JObject jsonObj = JObject.Parse(json);

				foreach (ore ore in _sde.ores)
				{
					ore.name = ore.name.TrimEnd();

                    double price = (double)jsonObj[ore.typeID.ToString()]["sell"]["min"];
                    int vol = (int)double.Parse((string)jsonObj[ore.typeID.ToString()]["sell"]["volume"]);

                    if (price < 100 || vol < 20)
                        continue;

					Prices.Add(ore, price);
				}

			}
			catch(Exception except)
			{
				Console.WriteLine("Could not update prices");  //TODO use cached prices (need to cache prices 1st)
			}
		}

		public Tuple<double, ItemList> getOre(double refineRate, int trit, int pyer, int mex, int iso, int nocx, int zyd, int mega, int morph)
		{
			Solver solver = new Solver("Ore Solver", Solver.GLOP_LINEAR_PROGRAMMING);

			Dictionary<Variable, ore> vars = new Dictionary<Variable, ore>();

			foreach(ore ore in Prices.Keys)
			{
				vars.Add(solver.MakeIntVar(0.0, double.PositiveInfinity, ore.name), ore);
			}

			Objective end = solver.Objective();

			end.SetMinimization();

			foreach (KeyValuePair<Variable, ore> var in vars)
			{
				end.SetCoefficient(var.Key, Prices[var.Value]);
			}

			Constraint tritConst = solver.MakeConstraint((double)trit, double.PositiveInfinity);
			foreach (KeyValuePair<Variable, ore> var in vars)
			{
				tritConst.SetCoefficient(var.Key, var.Value.Tritanium * refineRate);
			}

			Constraint pyerConst = solver.MakeConstraint((double)pyer, double.PositiveInfinity);
			foreach (KeyValuePair<Variable, ore> var in vars)
			{
				pyerConst.SetCoefficient(var.Key, var.Value.Pyerite * refineRate);
			}

			Constraint mexConst = solver.MakeConstraint((double)mex, double.PositiveInfinity);
			foreach (KeyValuePair<Variable, ore> var in vars)
			{
				mexConst.SetCoefficient(var.Key, var.Value.Mexallon * refineRate);
			}

			Constraint isoConst = solver.MakeConstraint((double)iso, double.PositiveInfinity);
			foreach (KeyValuePair<Variable, ore> var in vars)
			{
				isoConst.SetCoefficient(var.Key, var.Value.Isogen * refineRate);
			}

			Constraint nocxConst = solver.MakeConstraint((double)nocx, double.PositiveInfinity);
			foreach (KeyValuePair<Variable, ore> var in vars)
			{
				nocxConst.SetCoefficient(var.Key, var.Value.Nocxium * refineRate);
			}

			Constraint zydConst = solver.MakeConstraint((double)zyd, double.PositiveInfinity);
			foreach (KeyValuePair<Variable, ore> var in vars)
			{
				zydConst.SetCoefficient(var.Key, var.Value.Zydrine * refineRate);
			}

			Constraint megaConst = solver.MakeConstraint((double)mega, double.PositiveInfinity);
			foreach (KeyValuePair<Variable, ore> var in vars)
			{
				megaConst.SetCoefficient(var.Key, var.Value.Megacyte * refineRate);
			}

			Constraint morphConst = solver.MakeConstraint((double)morph, double.PositiveInfinity);
			foreach (KeyValuePair<Variable, ore> var in vars)
			{
				morphConst.SetCoefficient(var.Key, var.Value.Morphite * refineRate);
			}

			solver.Solve();

			double price = end.Value();

			ItemList list = new ItemList();

			foreach (KeyValuePair<Variable, ore> var in vars)
			{
				if (var.Key.SolutionValue() > 0)
				{
					list.Add(var.Value.invType, (int)var.Key.SolutionValue());
				}
			}

			return new Tuple<double, ItemList>(price, list);

		}

	}

}
